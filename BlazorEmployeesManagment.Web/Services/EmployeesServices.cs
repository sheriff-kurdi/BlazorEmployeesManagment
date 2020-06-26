using BlazorEmployeesManagment.Web.Data;
using BlazorEmployeesManagment.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazorEmployeesManagment.Web.Services
{
    public class EmployeesServices
    {
        private readonly ApplicationDbContext db;

        public EmployeesServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Employee> Add (Employee employee)
        {
            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
            return employee;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await db.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Delete(int id)
        {
            var employee = await GetById(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var oldEmployee = await GetById(id);
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.Email = employee.Email;
            oldEmployee.DateOfBrith = employee.DateOfBrith;
            oldEmployee.Gender = employee.Gender;
            oldEmployee.DepartmentId = employee.DepartmentId;
            oldEmployee.PhotoPath = employee.PhotoPath;

            await db.SaveChangesAsync();
            return oldEmployee;


        }
    }
}
