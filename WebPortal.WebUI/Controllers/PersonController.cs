using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal.Domain.Entities;
using WebPortal.Domain.Abstract;
using WebPortal.WebUI.Models;
using PagedList;
using PagedList.Mvc;

namespace WebPortal.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository repository;
        public int PageSize = 10;

        public PersonController(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public ViewResult List(string search, int? page)
        {
            const int PAGESIZE = 10;
            if (page is null)
            {
                page = 1;
            }

            EmployeesListViewModel model = new EmployeesListViewModel
            {
                Employees = repository.IEmployees
                .Where(p => search == null || p.InternalName.Contains(search)
               || p.PersonnelNumber.Contains(search)
               || p.CentralAccount.Contains(search)
               || p.DefaultEmailAddress.Contains(search))
                .OrderBy(p => p.LastName)
                .ToPagedList(page ?? 1, PAGESIZE),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = (int)page,
                    TotalItems = repository.IEmployees.Count()
                }
            };

            return View(model);
        }
    }
}