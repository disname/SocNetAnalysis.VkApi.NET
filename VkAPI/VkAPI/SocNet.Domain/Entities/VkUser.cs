using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SocNet.Domain.Annotations;

namespace SocNet.Domain.Entities
{
    public class VkUser : IUser, INotifyPropertyChanged
    {
        private List<IUser> _friends;
        private string _lastName;
        private long _id;
        private string _firstName;

        public long Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        public  List<IUser> Friends
        {
            get { return _friends; }
            set { _friends = value; OnPropertyChanged("Friends"); }
        }

        public VkUser(long id,String fName,String sName)
        {
            Id = id;
            FirstName = fName;
            LastName = sName;
        }

        public void SetUsers(IEnumerable<IUser> friends)
        {
            Friends = new List<IUser>(friends);
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
