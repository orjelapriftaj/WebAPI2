using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class EmployeeRepo: IEmployee
    {
        private readonly ApplicationContext _context;


        public EmployeeRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task  Delete(int id)
        {
            var employeeToDelete = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }








        //public Employee AddEmployee(Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //    _context.SaveChanges();
        //    return employee;
        //}
    }
}
