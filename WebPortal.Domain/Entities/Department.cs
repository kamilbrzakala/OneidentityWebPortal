using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPortal.Domain.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public string UID_Department { get; set; }
        public string DepartmentName { get; set; }
        public string Fullpath { get; set; }
    }
}
