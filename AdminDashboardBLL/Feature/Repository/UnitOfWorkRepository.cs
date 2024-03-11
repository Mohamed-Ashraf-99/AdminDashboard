using AdminDashboardBLL.Feature.Interface;
using AdminDashboardDAL.Context;
using AdminDashboardDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.Feature.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Employee> Employee { get; private set; }
        public IGenericRepository<Department> Department { get; private set; }

        public UnitOfWorkRepository(
            ApplicationDbContext context)
        {
            _context = context;
            this.Employee = new GenericRepository<Employee>(_context);
            this.Department = new GenericRepository<Department>(_context);
        }

        public async Task<int> Commit()
            => await _context.SaveChangesAsync();

        public  void Dispose()
            =>  _context.Dispose();
    }
}
