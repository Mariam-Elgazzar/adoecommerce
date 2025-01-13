using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoecommerce.BL.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string address { get; set; }
        public bool isAdmin { get; set; }
        public string UserName { get; set; }
    }
}
