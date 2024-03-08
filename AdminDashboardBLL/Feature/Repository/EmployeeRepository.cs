﻿using AdminDashboardBLL.Feature.Interface;
using AdminDashboardDAL.Context;
using AdminDashboardDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboardBLL.Feature.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> filter)
        {
            if (filter == null)
            {
                return await _context.Employees.ToListAsync();
            }
            var employees = await _context.Employees.Where(filter).ToListAsync();
            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            var oldEmployee = await _context.Employees.FindAsync(employee.Id);
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }



    }
}