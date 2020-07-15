using SalaryPorject.Business.Enumerations;
using SalaryPorject.Business.Factories;
using SalaryPorject.Business.Models;
using SalaryProject.DataAccess.EmployeeClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryPorject.Business.Employees
{
    public class Employee: IEmployee
    {
        private readonly IEmployeeClient _employeeClient;

        public Employee(IEmployeeClient employeeClient)
        {
            _employeeClient = employeeClient;
        }

        public async Task<List<EmployeeModel>> GetEmployees<T>() 
        {
            return await GetAllEmployees<T>();
        }

        public async Task<EmployeeModel> GetEmployee<T>(int id)
        {
            List<EmployeeModel> employees = await GetAllEmployees<T>();
            return employees.FirstOrDefault(x=> x.Id == id);
        }

        public async Task<List<EmployeeModel>> GetAllEmployees<T>()
        {
            List<EmployeeModel> employees = await _employeeClient.GetEmployees<EmployeeModel>();
            if (employees.Count() > default(int))
            {
                foreach (var item in employees)
                {
                    ISalaryFactory salaryFactoryObject = SalaryFactory.SalaryFactoryCreator((EContractType)Enum.Parse(typeof(EContractType), item.ContractTypeName, true), item.HourlySalary, item.MonthlySalary);
                    item.AnnualSalary = salaryFactoryObject.GetAnnualSalary();
                }
            }
            return employees;
        }
    }
}
