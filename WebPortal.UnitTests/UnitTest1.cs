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
using PagedList;
using PagedList.Mvc;

namespace WebPortal.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
            EmployeesListViewModel result = (EmployeesListViewModel)controller.List("","",2).Model;

            // assertion
            IPagedList<Person> personArray = result.Employees;
            Assert.IsTrue(personArray.Count() == 3);

            Assert.AreEqual(personArray[0].DefaultEmailAddress, "france.andrade@hotmail.com");
            Assert.AreEqual(personArray[1].DefaultEmailAddress, "naraiza@hotmail.com");
        }

        /*[TestMethod]
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

        }*/

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
            EmployeesListViewModel result = (EmployeesListViewModel)controller.List("","",2).Model;
            IPagedList<Person> pagedList = result.Employees;
            // assertion
            Assert.AreEqual(pagedList.PageCount, 3);
            Assert.AreEqual(pagedList.TotalItemCount, 7);
            Assert.AreEqual(pagedList.PageSize, 3);
            Assert.AreEqual(pagedList.PageNumber, 2);
        }

        [TestMethod]
        public void Can_Use_Menu()
        {
            // prepare
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.IEmployees).Returns(new Person[] {
                new Person { InternalName = "Adelsperger, Rusty", DefaultEmailAddress = "rusty.adelsperger@yahoo.com", CentralAccount = "RUSTADE", PersonnelNumber = "123", Manager = "Andrade, France" },
                new Person { InternalName = "Aldaco, Nettie", DefaultEmailAddress = "nettie.aldaco@yahoo.com",CentralAccount = "NATTAL", PersonnelNumber = "234", Manager = "Andrade, France" },
                new Person { InternalName = "Adel, Rusty", DefaultEmailAddress = "rusty.adel@yahoo.com", CentralAccount = "RUSTADE1", PersonnelNumber = "345", Manager = "Andrade, France" },
                new Person { InternalName = "Andrade, France", DefaultEmailAddress = "france.andrade@hotmail.com", CentralAccount = "ANDRAF", PersonnelNumber = "456", Manager = "Andrade, France" },
                new Person { InternalName = "Nara, Iza", DefaultEmailAddress = "iza.nara@hotmail.com", CentralAccount = "IZAN", PersonnelNumber = "567", Manager = "Andrade, France" },
                new Person { InternalName = "Mbape, Ivan", DefaultEmailAddress = "ivan.mbape@gmail.com", CentralAccount = "IVANM", PersonnelNumber = "678", Manager = "Andrade, France" },
                new Person { InternalName = "Novic, Casie", DefaultEmailAddress = "casie.novic@gmail.com", CentralAccount = "CASIN", PersonnelNumber = "789", Manager = "Andrade, France" }
            });

            PersonController controller = new PersonController(mock.Object);
            controller.PageSize = 3;
            // action
            EmployeesListViewModel result1 = (EmployeesListViewModel)controller.List("All Employees", "", 2).Model;
            EmployeesListViewModel result2 = (EmployeesListViewModel)controller.List("Name", "Rusty", 1).Model;
            EmployeesListViewModel result3 = (EmployeesListViewModel)controller.List("Mail", "casie.novic@gmail.com", 1).Model;
            EmployeesListViewModel result4 = (EmployeesListViewModel)controller.List("Account Name", "RUSTADE1", 1).Model;
            EmployeesListViewModel result5 = (EmployeesListViewModel)controller.List("Employee ID", "678", 1).Model;
            EmployeesListViewModel result6 = (EmployeesListViewModel)controller.List("Manager", "", 3).Model;
            // assertion
            Assert.AreEqual(result1.Employees.ElementAtOrDefault(0).DefaultEmailAddress, "france.andrade@hotmail.com");
            Assert.AreEqual(result2.Employees.ElementAtOrDefault(1).InternalName, "Adelsperger, Rusty");
            Assert.AreEqual(result3.Employees.ElementAtOrDefault(0).DefaultEmailAddress, "casie.novic@gmail.com");
            Assert.AreEqual(result4.Employees.ElementAtOrDefault(0).CentralAccount, "RUSTADE1");
            Assert.AreEqual(result5.Employees.ElementAtOrDefault(0).PersonnelNumber, "678");
            Assert.AreEqual(result6.Employees.ElementAtOrDefault(0).Manager, "Andrade, France");
        }

    }
}
