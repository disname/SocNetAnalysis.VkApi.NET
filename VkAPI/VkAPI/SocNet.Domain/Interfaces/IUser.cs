using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.Domain
{
    public interface IUser
    {
        long Id { get; set; }
        String FirstName { get; set; }
        String LastName { get; set; }
        List<IUser> Friends { get; set; } 
    }
}
