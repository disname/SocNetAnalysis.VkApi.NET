using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SocNet.Domain;

namespace VkAPI.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text;
            var pass = PasswordBox.Text;
           // var email ="bojiand@gmail.com";
           // var pass = "ohmygoditispass";
           int result =App.Instance.Authorize(new SettingsContainer(email,pass));
            if (result == 1)
            {
                this.Hide();
                MainWindow mWindow = new MainWindow(App.Instance.GetCurrentUser());
                mWindow.Closed += (x,y)=> { Application.Current.Shutdown(); };
                mWindow.Show();
            }
            else
            {
                MessageBox.Show("Ошибка афторизаци,петуx.");
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
