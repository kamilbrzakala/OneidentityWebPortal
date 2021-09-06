using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using WebPortal.Domain.Abstract;
using WebPortal.Domain.Entities;
using WebPortal.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<Person> result = (IEnumerable<Person>)controller.List(2).Model;

            // assertion
            Person[] personArray = result.ToArray();
            Assert.IsTrue(personArray.Length == 3);
            
            Assert.AreEqual(personArray[0].DefaultEmailAddress, "france.andrade@hotmail.com");
            Assert.AreEqual(personArray[1].DefaultEmailAddress, "naraiza@hotmail.com");
        }
    }
}
