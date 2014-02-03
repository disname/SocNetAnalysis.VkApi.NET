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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SocNet.Domain;
using SocNet.Domain.Entities;

namespace VkAPI.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserViewModel Model { get; set; }
        public MainWindow(VkUser user)
        {
            Model=new UserViewModel(user);
            Model.CurrentUser.Friends = App.Instance.GetFriendList(Model.CurrentUser.Id).ToList<IUser>();
         
            InitializeComponent();
            this.DataContext = Model;
        }

  

        private void FriendsTree_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Model.SelectedUser = (VkUser)e.NewValue;
            Model.SelectedUser.Friends = App.Instance.GetFriendList(Model.SelectedUser.Id).ToList<IUser>();

        }
    }
}
