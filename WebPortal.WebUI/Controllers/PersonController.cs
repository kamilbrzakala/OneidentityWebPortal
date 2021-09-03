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
        
        public PersonController(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public ViewResult List()
        {
            return View(repository.Persons);
        }
    }
}