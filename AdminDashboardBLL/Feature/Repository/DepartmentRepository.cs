using AdminDashboardBLL.Feature.Interface;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDashboardDAL.Context;
using AdminDashboardDAL.Entities;

namespace AdminDashboardBLL.Feature.Repository
{
    public class DepartmentRepository : IDepartment
    {
        readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Department> GetByIdAsync(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(z => z.Id == id);

            return department;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments;
          
        }

        public async Task CreateAsync(Department department)
        {

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;

            await _context.SaveChangesAsync(); 

        }

        public async Task DeleteAsync(int id)
        {
            var oldDepartment = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (oldDepartment != null)
            {
                _context.Departments.Remove(oldDepartment);
                await _context.SaveChangesAsync();
            }
        }


    }
}
