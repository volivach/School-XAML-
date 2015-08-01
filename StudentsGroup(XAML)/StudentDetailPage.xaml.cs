using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using StudentsGroup_XAML_.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using StudentsGroup;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace StudentsGroup_XAML_
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class StudentDetailPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public StudentDetailPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            object navigationParameter;
            if (e.PageState != null && e.PageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = e.PageState["SelectedItem"];
            }

            // TODO: Assign a bindable group to this.DefaultViewModel["Group"]
            // TODO: Assign a collection of bindable items to this.DefaultViewModel["Items"]
            // TODO: Assign the selected item to this.flipView.SelectedItem
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// and <see cref="Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);

            User user = e.Parameter as User;
            if (user == null)
                return;

            Uri uri = new Uri(user.Uri);
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            //// download pic
            var bitmapImage = new BitmapImage();
            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(uri);
         
            byte[] b = await httpResponse.Content.ReadAsByteArrayAsync();

            // create a new in memory stream and datawriter
            using (var stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter dw = new DataWriter(stream))
                {
                    // write the raw bytes and store
                    dw.WriteBytes(b);
                    await dw.StoreAsync();

                    //// set the image source
                    stream.Seek(0);
                    bitmapImage.SetSource(stream);

                    // set image in first control
                    image.Source = bitmapImage;

                    // write to pictures library
                    var storageFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                        fileName,
                        CreationCollisionOption.ReplaceExisting);

                    using (var storageStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        await RandomAccessStream.CopyAndCloseAsync(stream.GetInputStreamAt(0), storageStream.GetOutputStreamAt(0));
                    }
                }
            }


            textBlock.Text = user.ToString();
            //// read from pictures library
            //var pictureFile = await KnownFolders.PicturesLibrary.GetFileAsync(fileName);
            //using (var pictureStream = await pictureFile.OpenAsync(FileAccessMode.Read))
            //{
            //    bitmapImage.SetSource(pictureStream);
            //}
            //image.Source = bitmapImage;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
