using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal.Domain.Entities;
using WebPortal.Domain.Abstract;
using WebPortal.WebUI.Models;

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

        public ViewResult List(int page = 1)
        {
            EmployeesListViewModel model = new EmployeesListViewModel
            {
                Employees = repository.IEmployees
                .OrderBy(p => p.LastName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.IEmployees.Count()
                }
            };

            return View(model);
        }
    }
}