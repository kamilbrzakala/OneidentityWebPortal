using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPortal.Domain.Entities
{
    public class Person
    {
        public string UID_Person { get; set; }
        public string InternalName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CentralAccount { get; set; }
        public string PersonnelNumber { get; set; }
        public string DefaultEmailAddress { get; set; }
    }
}
