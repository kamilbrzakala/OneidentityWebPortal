using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Domain.Entities
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public string UID_Person { get; set; }
        public string InternalName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CentralAccount { get; set; }
        public string PersonnelNumber { get; set; }
        private string _defaultEmailAddress;

        public string DefaultEmailAddress 
        { 
            get 
            {
                if (string.IsNullOrEmpty(_defaultEmailAddress))
                {
                    _defaultEmailAddress = "not set";
                }
                    return _defaultEmailAddress;
                }
            set
            {
                _defaultEmailAddress = value;
            }
        }
        public string UID_PersonHead { get; set; }
        [NotMapped]
        public string Manager { get; set; }
        [NotMapped]
        public string Department { get; set; }

    }
}
