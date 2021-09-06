using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebPortal.Domain.Entities;

namespace WebPortal.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        // here we define properties for every table we want to use
        public DbSet<Person> Employees { get; set; }
    }
}
