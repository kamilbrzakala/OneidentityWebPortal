using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using Moq;
using WebPortal.Domain.Abstract;
using WebPortal.Domain.Entities;
using WebPortal.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using WebPortal.WebUI.Models;
using WebPortal.WebUI.HtmlHelpers;

namespace WebPortal.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
      /*  [TestMethod]
        public void Can_Paginate()
        {
            // prepare
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.IEmployees).Returns(new Person[] {
                new Person{UID_Person = "e47c9f4d-1c95-4587-af2b-083d4d227eb8", DefaultEmailAddress = "rusty.adelsperger@yahoo.com"},
                new Person{UID_Person = "cd024e57-5fd4-4dbf-9763-e2bedb944ead", DefaultEmailAddress = "nettie.aldaco@yahoo.com"},
                new Person{UID_Person = "e47c9f4d-1c95-4587-af2b-083d4d227eb8", DefaultEmailAddress = "rusty.adelsperger@yahoo.com"},
                new Person{UID_Person = "2d511560-e23e-4152-b200-081876e13c73", DefaultEmailAddress = "france.andrade@hotmail.com"},
                new Person{UID_Person = "9011a826-436a-4c9f-ad64-5c5263d4d0b9", DefaultEmailAddress = "naraiza@hotmail.com"},
                new Person{UID_Person = "ae6cba8e-2a5f-4493-af3c-536a7164deb5", DefaultEmailAddress = "ivan@gmail.com"},
                new Person{UID_Person = "24200a4a-5b47-4f18-9a27-6c9962c0b5db", DefaultEmailAddress = "casie@gmail.com"}
            });

            PersonController controller = new PersonController(mock.Object);
            controller.PageSize = 3;

            // action
            EmployeesListViewModel result = (EmployeesListViewModel)controller.List(2).Model;

            // assertion
            Person[] personArray = result.Employees.ToArray();
            Assert.IsTrue(personArray.Length == 3);
            
            Assert.AreEqual(personArray[0].DefaultEmailAddress, "france.andrade@hotmail.com");
            Assert.AreEqual(personArray[1].DefaultEmailAddress, "naraiza@hotmail.com");
        }*/
        
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // we need helper object to use extension method 'PageLinks'
            HtmlHelper myHelper = null;

            // prepare data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                ItemsPerPage = 10,
                TotalItems = 30
            };

            // prepare - configure delegatee with lambda expression
            // Declare a Func variable and assign a lambda expression to the
            // variable. The method takes an integer and converts it to string.
            Func<int, string> pageUrlDelegate = i => "Strona" + i;

            // action
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // assertion
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Strona1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Strona2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Strona3"">3</a>", result.ToString());

        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // prepare
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.IEmployees).Returns(new Person[] {
                new Person{UID_Person = "e47c9f4d-1c95-4587-af2b-083d4d227eb8", DefaultEmailAddress = "rusty.adelsperger@yahoo.com"},
                new Person{UID_Person = "cd024e57-5fd4-4dbf-9763-e2bedb944ead", DefaultEmailAddress = "nettie.aldaco@yahoo.com"},
                new Person{UID_Person = "e47c9f4d-1c95-4587-af2b-083d4d227eb8", DefaultEmailAddress = "rusty.adelsperger@yahoo.com"},
                new Person{UID_Person = "2d511560-e23e-4152-b200-081876e13c73", DefaultEmailAddress = "france.andrade@hotmail.com"},
                new Person{UID_Person = "9011a826-436a-4c9f-ad64-5c5263d4d0b9", DefaultEmailAddress = "naraiza@hotmail.com"},
                new Person{UID_Person = "ae6cba8e-2a5f-4493-af3c-536a7164deb5", DefaultEmailAddress = "ivan@gmail.com"},
                new Person{UID_Person = "24200a4a-5b47-4f18-9a27-6c9962c0b5db", DefaultEmailAddress = "casie@gmail.com"}
            });

            PersonController controller = new PersonController(mock.Object);
            controller.PageSize = 3;

            // action
            EmployeesListViewModel result = (EmployeesListViewModel)controller.List(2).Model;
            PagingInfo pagingInfo = result.PagingInfo;
            // assertion
            Assert.AreEqual(pagingInfo.TotalItems, 7);
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalPages, 3);
        }


    }
}
