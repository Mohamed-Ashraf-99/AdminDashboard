using AdminDashboardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.Feature.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> Employee {  get;  }
        IGenericRepository<Department> Department {  get; }
        Task<int> Commit();

        
    }
}
