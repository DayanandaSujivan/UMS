using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Model
{
    public class Student
    {
        public int Id { get; set; }
        public int NIC { get; set; }
        public string FullName { get; set; }
        public int phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePic { get; set; }
    }
}
