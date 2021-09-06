using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using WebPortal.Domain.Abstract;
using WebPortal.Domain.Entities;
using WebPortal.Domain.Concrete;

namespace WebPortal.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /*Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(m => m.IEmployees).Returns(new List<Person>
            {
                new Person {UID_Person = "ffx1234-d123f3d-54vc234-sdfx234", InternalName = "Kamil Brzakala", DefaultEmailAddress = "kamil.brzakala@oneidentity.com", CentralAccount = "kamilb"},
                new Person {UID_Person = "ffx1asd-d123f3d-54vc234-sdfx234", InternalName = "Mike Goldman", DefaultEmailAddress = "mike.goldman@oneidentity.com", CentralAccount = "mikeg"},
                new Person {UID_Person = "ffx1qwe-d123f3d-54vc234-sdfx234", InternalName = "Gary Pod", DefaultEmailAddress = "gary.pod@oneidentity.com", CentralAccount = "garyp"},
                new Person {UID_Person = "ffx1zxc-d123f3d-54vc234-sdfx234", InternalName = "Bill Single", DefaultEmailAddress = "bill.single@oneidentity.com", CentralAccount = "bills"},
                new Person {UID_Person = "ffx1wer-d123f3d-54vc234-sdfx234", InternalName = "Grant Winner", DefaultEmailAddress = "grant.winner@oneidentity.com", CentralAccount = "grantw"},
                new Person {UID_Person = "ffx1wer-d123f3d-54vc234-sdfx234", InternalName = "Alex Gray", DefaultEmailAddress = "alex.gray@oneidentity.com", CentralAccount = "alexg"}
            });

            kernel.Bind<IPersonRepository>().ToConstant(mock.Object);*/

            kernel.Bind<IPersonRepository>().To<EFPersonRepository>();
        }
    }
}