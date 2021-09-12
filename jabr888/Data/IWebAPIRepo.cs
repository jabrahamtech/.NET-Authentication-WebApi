using jabr888.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888.Data
{
    public interface IWebAPIRepo
    {
        public IEnumerable<Users> GetAllUsers();
        public bool ValidLogin(string userName, string password);
        Users GetUserByName(string name);
        Users AddUser(Users user);
        Orders AddOrder(Orders order);
    }
}
