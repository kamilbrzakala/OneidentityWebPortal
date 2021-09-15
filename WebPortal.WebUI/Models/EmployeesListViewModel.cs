using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPortal.Domain.Entities;
using PagedList;
using PagedList.Mvc;

namespace WebPortal.WebUI.Models
{
    public class EmployeesListViewModel
    {
        public IPagedList<Person> Employees { get; set; }
        //public IEnumerable<Person> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}