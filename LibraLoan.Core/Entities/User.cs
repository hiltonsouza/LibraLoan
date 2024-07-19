using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;

            Books = new List<Book>();
        }

        public string Name { get; private set; }
        public string Email { get;private set; }
        public string Password { get;private set; }
        public string Role { get;private set; }
        public List<Book>? Books { get; private set; }
    }
}
