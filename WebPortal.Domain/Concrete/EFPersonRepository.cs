using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebPortal.Domain.Entities;
using WebPortal.Domain.Abstract;

namespace WebPortal.Domain.Concrete
{
    public class EFPersonRepository : IPersonRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Person> IEmployees
        {
            get { return context.Employees; }
        }
    }
}
