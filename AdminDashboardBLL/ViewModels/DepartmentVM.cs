using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,ErrorMessage = "Maximum Length 50")]
        [MinLength(3,ErrorMessage = "Min Length 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [Range(1,10000,ErrorMessage = "Range between 1 to 10K")]
        public int Code { get; set; }
    }
}
