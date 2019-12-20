using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Entities.Abstarction;

namespace DAL.Models.Entities
{
    public enum UserRole
    {
        Customer,
        Moderator,
        Admin
    }

    public class User : DbItem<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
