using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryPorject.Business.Employees;
using SalaryPorject.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployee _employee;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployee employee)
        {
            _logger = logger;
            _employee = employee;
        }

        // GET: api/EmployeesController 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> Get()
        {
            try
            {
                List<EmployeeModel> employees = await _employee.GetEmployees<EmployeeModel>();
                if (employees.Count() <= default(int)) return StatusCode(StatusCodes.Status404NotFound);
                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError($"EmployeeController::GetEmployees.exception:{ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/EmployeesController/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> Get(int id)
        {
            try
            {
                EmployeeModel employee = await _employee.GetEmployee<EmployeeModel>(id);
                if (employee == null) return StatusCode(StatusCodes.Status404NotFound);
                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError($"EmployeeController::GetEmployees.exception:{ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
