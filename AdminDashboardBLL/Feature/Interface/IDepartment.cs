using AdminDashboardBLL.Feature;
using AdminDashboardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.Feature.Interface
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAllAsync();
    
        Task<Department> GetByIdAsync(int id);

        Task CreateAsync(Department department);

        Task UpdateAsync(Department department);
        Task DeleteAsync(int id);

        
    }
}

