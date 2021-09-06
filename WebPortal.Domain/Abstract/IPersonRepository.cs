using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal.Domain.Entities;

namespace WebPortal.Domain.Abstract
{
    public interface IPersonRepository
    {
        IEnumerable<Person> IEmployees { get; }
    }
}
