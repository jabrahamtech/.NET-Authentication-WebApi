using jabr888.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888.Data
{
    public class WebAPIDBContext : DbContext
    {
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Orders> Order { get; set; }
    }
}
