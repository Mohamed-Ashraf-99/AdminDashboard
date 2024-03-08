using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardDAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Notes { get; set; }

        public DateTime HireDate { get; set; } 

        public bool IsDeleted { get; set;}

        public bool IsUpdated { get; set;}

        public bool IsActive { get; set;}

        public DateTime CreationDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
     
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
