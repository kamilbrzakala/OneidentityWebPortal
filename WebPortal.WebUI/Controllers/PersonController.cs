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
        public string Manager;
        IPagedList<Person> _employees;
        public string _employeeID;

        public PersonController(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public ViewResult List(string menu, string search, int? page = 1)
        {

            /*if (page is null)
            {
                page = 1;
            }*/

            if ((menu == "All Employees" || String.IsNullOrEmpty(menu)) && (search == null || String.IsNullOrEmpty(search) || !String.IsNullOrEmpty(search)))
            {
                _employees = repository.IEmployees.OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }
            else if (menu == "Name")
            {
                _employees = repository.IEmployees.Where(p => p.InternalName.Contains(search) || search == null).OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }
            else if (menu == "Mail")
            {
                _employees = repository.IEmployees.Where(p => p.DefaultEmailAddress.Contains(search) || search == null).OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }
            else if (menu == "Account Name")
            {
                _employees = repository.IEmployees.Where(p => p.CentralAccount == search || search == null).OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }
            else if (menu == "Employee ID")
            {
                _employees = repository.IEmployees.Where(p => p.PersonnelNumber == search || search == null).OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }
            else if (menu == "Manager")
            {
                _employeeID = repository.IEmployees.Where(p => search == null || p.DefaultEmailAddress.Contains(search) || p.InternalName.Contains(search)).FirstOrDefault().UID_Person;
                _employees = repository.IEmployees.Where(p => p.UID_PersonHead == _employeeID || search == null).OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }
            /*else if (menu == "Department")
            {
                _employees = repository.IEmployees.Where(p => p.InternalName.Contains(search) || search == null).OrderBy(p => p.InternalName).ToPagedList(page ?? 1, PageSize);
            }*/

            EmployeesListViewModel model = new EmployeesListViewModel
            {
                Employees = _employees,
                Managers = repository.IEmployees.OrderBy(p => p.InternalName),
                PagingInfo = new PagingInfo
                    {
                        CurrentPage = (int)page,
                        TotalItems = repository.IEmployees.Count()
                    },

                    Menu = new List<DropDownList>
                    {
                        new DropDownList() { MenuItem = "All Employees" },
                        new DropDownList() { MenuItem = "Name" },
                        new DropDownList() { MenuItem = "Mail" },
                        new DropDownList() { MenuItem = "Account Name" },
                        new DropDownList() { MenuItem = "Employee ID" },
                        new DropDownList() { MenuItem = "Manager" }
                    }
            };

            return View(model);
        }
    }
}