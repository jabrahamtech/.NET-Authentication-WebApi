using jabr888.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace jabr888.Data
{
    public class DBWebAPIRepo : IWebAPIRepo
    {

        private readonly WebAPIDBContext _dbContext;
        public DBWebAPIRepo(WebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Users AddUser(Users User)
        {
            EntityEntry<Users> e = _dbContext.User.Add(User);
            Users c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            IEnumerable<Users> Users = _dbContext.User.ToList<Users>();
            return Users;
        }

        public Users GetUserByName(string name)
        {
            Users User = _dbContext.User.FirstOrDefault(e => e.UserName == name);
            return User;
        }

        public bool ValidLogin(string userName, string password)
        {
            Users c = _dbContext.User.FirstOrDefault(e => e.UserName == userName && e.Password == password);
            if (c == null)
                return false;
            else
                return true;
        }

        public Orders AddOrder(Orders order)
        {
            EntityEntry<Orders> e = _dbContext.Order.Add(order);
            Orders c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }
    }
}
