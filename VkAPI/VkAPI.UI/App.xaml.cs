using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SocNet.Domain;

namespace VkAPI.UI
{
  
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly Lazy<ApiCaller> _instance = new Lazy<ApiCaller>(() => new ApiCaller());
        public static ApiCaller Instance
        {
            get
            {
                return _instance.Value;
            }
        }
       

       
    }
}
