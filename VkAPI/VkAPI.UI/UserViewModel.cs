using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SocNet.Domain.Annotations;
using SocNet.Domain.Entities;

namespace VkAPI.UI
{
   public  class UserViewModel:INotifyPropertyChanged
    {
       private VkUser _currentUser;
       private VkUser _selectedUser;

       public VkUser CurrentUser
       {
           get { return _currentUser; }
           set { _currentUser = value; OnPropertyChanged("CurrentUser"); }
       }

       public VkUser SelectedUser
       {
           get { return _selectedUser; }
           set { _selectedUser = value; OnPropertyChanged("SelectedUser"); }
       }

       public UserViewModel(VkUser user)
       {
           CurrentUser = user;
       }

       public UserViewModel()
       {
           var e = 1;
       }

       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
       }
    }
}
