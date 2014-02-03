using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocNet.Domain.Entities;
using VkToolkit;
using VkToolkit.Enums;
using VkToolkit.Model;

namespace SocNet.Domain
{
    public class ApiCaller
    {
        private VkApi Api { get; set; }
        private VkUser CurrentUser { get; set; }

        public VkUser GetCurrentUser()
        {
            return CurrentUser;
        }

        public void SetCurrentUser(User vkVser)
        {
            CurrentUser = new VkUser(vkVser.Id, vkVser.FirstName, vkVser.LastName);
        }
        public User ReturnCurrentVkUser()
        {
            return Api.Users.Get(CurrentUser.Id);
        }

        
        public ApiCaller()
        {
            Api=new VkApi();
           
        }

        public Int32 Authorize(SettingsContainer container)
        {
            if (Api != null)
            {
                try
                {
                    Api.Authorize(container.AppId, container.Email, container.Pass,
                        container.Scope);
                }
                catch (VkToolkit.Exception.AccessDeniedException e)
                {
                    return -1;
                }
                SetCurrentUser(Api.Users.Get(Api.UserId,ProfileFields.All));
                return 1;
            }
            return 0;
        }

        public List<VkUser> GetFriendList(long userId)
        {
          IEnumerable<User> friendList= Api.Friends.Get(userId, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Uid);
            return friendList.Select(x => new VkUser(x.Id, x.FirstName, x.LastName)).ToList();
        }

        public IEnumerable<IUser> FillAllUserFrinds(List<IUser> users)
        {
            for (Int32 i = 0; i < users.Count(); i++)
            {
                users[i].Friends = GetFriendList((users[i].Id)).ToList<IUser>();
            }
            return users;
        }


    }
}
