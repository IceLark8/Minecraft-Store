using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models.Entities.Abstarction;

namespace DB.Models.Entities
{
    public enum UserRole
    {
        Customer,
        Moderator,
        Admin
    }

    public class User : DbItem
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
