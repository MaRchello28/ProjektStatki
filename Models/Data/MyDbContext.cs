using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<HumanPlayer> users {  get; set; }
        public DbSet<Achievement> achievements { get; set; }
    }
}
