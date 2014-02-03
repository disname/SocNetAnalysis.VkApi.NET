using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkToolkit.Enums;

namespace SocNet.Domain
{
    public class SettingsContainer
    {
        private int _appId;
        private string _email;
        private string _pass;
        private Settings _scope;

        public int AppId
        {
            get { return 4150601; }
        } 

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        } 

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        } 

        public Settings Scope
        {
            get { return Settings.All; }
        }

        public SettingsContainer(String email = "bojiand@gmail.com", String pass = "ohmygoditispass")
       {
           Email = email;
           Pass = pass;
       }

    }
}
