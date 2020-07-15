using SalaryPorject.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryPorject.Business.Employees
{
    public interface IEmployee
    {
        Task<List<EmployeeModel>> GetEmployees<T>();

        Task<EmployeeModel> GetEmployee<T>(int id);
    }
}