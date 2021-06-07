using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class Cinema8SystemDBContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
