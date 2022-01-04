using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TechTalk.SpecFlow.CommonModels;


namespace API.Controllers
{
    public class EmployeeControllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public IResult AddEmployee(EmployeeControllers Emp)
        {
            if (Emp == null)
            {
                return NotFound();
            }
            EmployeeManager employeeManager = new();
            var addEmployee = employeeManager.Add(Emp);
            if (addEmployee.isSucess)
            {
                return Ok();
            }
            return ValidationProblem();
        }

        
    }
} 