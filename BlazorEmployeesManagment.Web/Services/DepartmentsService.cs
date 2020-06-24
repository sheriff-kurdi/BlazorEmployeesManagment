using BlazorEmployeesManagment.Web.Data;
using BlazorEmployeesManagment.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeesManagment.Web.Services
{
    public class DepartmentsService
    {
        private readonly ApplicationDbContext db;

        public DepartmentsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async void Add(Department department)
        {
            await db.Departments.AddAsync(department);
            await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await db.Departments
                .FirstOrDefaultAsync(e => e.DepartmentId == id);
        }
        public async void Delete(int id)
        {
            var department = await GetById(id);
            db.Departments.Remove(department);
            await db.SaveChangesAsync();
        }

        public async void Update(int id, Department department)
        {
            var oldEmployee = await GetById(id);
            oldEmployee.DepartmentName = department.DepartmentName;

            await db.SaveChangesAsync();

        }
    }
}
