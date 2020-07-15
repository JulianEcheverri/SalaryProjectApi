using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryProject.DataAccess.EmployeeClient
{
    public interface IEmployeeClient
    {
        Task<List<T>> GetEmployees<T>();
    }
}
