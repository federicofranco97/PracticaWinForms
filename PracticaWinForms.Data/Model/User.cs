using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaWinForms.Data.Model
{
    public class User
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }

    public enum Role
    {
        Administrator = 0,
        User = 1,
    }
}
