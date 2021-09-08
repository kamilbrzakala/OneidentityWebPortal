using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPortal.Domain.Entities;

namespace WebPortal.WebUI.Models
{
    public class EmployeesListViewModel
    {
        public IEnumerable<Person> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}