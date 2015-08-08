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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudentsGroup_XAML_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterStudent : Page
    {
        private const int MaxAge = 120;

        public RegisterStudent()
        {
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            for (int i = 1; i <= MaxAge; i++)
            {
                selectAgeBox.Items.Add(i.ToString());
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.FirstName = firstNameTextBox.Text;
            userInfo.SecondName = SecondNameTextBox.Text;
            userInfo.LastName = LastNameTextBox.Text;
            userInfo.Uri = ImageUrlTextBox.Text;
            int.TryParse(selectAgeBox.SelectedItem as string, out userInfo.Age);
            SchoolController.Instance.AddStudent(userInfo, new GroupID("C#-15-01"));
        }
    }
}
