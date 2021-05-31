using employee_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_backend.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<IEnumerable<EmployeeModel>> SearchForLastName(string searchTerm);
        Task<EmployeeModel> Get(int Id);
        Task Update(EmployeeModel employee);
        Task Delete(int Id);
        Task<EmployeeModel> Create(EmployeeModel employee);

    }
}
