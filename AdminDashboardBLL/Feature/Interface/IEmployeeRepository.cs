using AdminDashboardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.Feature.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter);

        Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter);

        Task CreateAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteById(int id);

        //Task<Employee> GetByName(string name);
    }
}
