using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal.Domain.Entities;
using WebPortal.Domain.Abstract;

namespace WebPortal.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository repository;
        public int PageSize = 3;

        public PersonController(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public ViewResult List(int page = 1)
        {

            return View(repository.IEmployees
                .OrderBy(p => p.LastName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
        }
    }
}