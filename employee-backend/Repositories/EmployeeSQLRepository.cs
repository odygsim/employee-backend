using employee_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_backend.Repositories
{
    public class EmployeeSQLRepository : IEmployeeRepository
    {
        
        private readonly EmployeeContext _context;
        public EmployeeSQLRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<EmployeeModel> Create(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task Delete(int Id)
        {
            var employeeToDelete = await _context.Employees.FindAsync(Id);
            _context.Employees.Remove(employeeToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeModel> Get(int Id)
        {
            return await _context.Employees.FindAsync(Id);
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<EmployeeModel>> SearchForLastName(string searchTerm)
        {
            var employees = from e in _context.Employees
                            where e.LastName.Contains(searchTerm)
                            select e;

            return await employees.ToListAsync();
        }

        public async Task Update(EmployeeModel employee)
        {
            // Update state of the employee
            _context.Entry(employee).State = EntityState.Modified;
            // Update in db
            await _context.SaveChangesAsync();
        }
    }
}
