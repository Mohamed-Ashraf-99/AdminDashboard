using AdminDashboardDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Range(200, 100000, ErrorMessage = "Salary must be between 2K and 100k.")]
        public decimal Salary { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(11, ErrorMessage = "Phone number must be 11")]
        [MinLength(11, ErrorMessage = "Phone number must be 11")]
        public string? Phone { get; set; }

        [RegularExpression("[1-9]{1,5}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}-[a-zA-Z]{1,10}", ErrorMessage ="Address must be with this format 123-Street-City-Country")]
        public string? Address { get; set; }

        public string? Notes { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsUpdated { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreationDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public IEnumerable<Department>? DepartmentsList { get; set; }
        public int DepartmentId { get; set; }

        public  Department? Department { get; set; }
    }
}
