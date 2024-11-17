using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace mohamedwalidw6
{
    class Databasecontext : DbContext
    {
       public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
