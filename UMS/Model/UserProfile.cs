using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Model
{
    public class UserProfile
    {
        public string FullName { get; set; }
        public string Role { get; set; }
        public byte[] ProfilePic { get; set; }
    }
}
