using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdminDashboardDAL.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set;}

        [Required]
        public int Code { get; set;}

        public List<Employee>? Employees { get;}

    }
}
