using StudentsGroup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudentsGroup_XAML_
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SchoolController _schoolController = SchoolController.Instance;
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                await _schoolController.LoadData();
                foreach (var it in _schoolController.Users)
                {
                    listView.Items.Add(it);
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(StudentDetailPage), e.ClickedItem);
        }

        private void RegisterStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterStudent));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginPopup.IsOpen = true;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginText.Text;
            string password = PasswordText.Text;


            try
            {
                _schoolController.AuthManager.DoAuthentification(login, password);
            }
            catch (ErrorCredentialsException ex)
            {

            }
        }
    }
}
