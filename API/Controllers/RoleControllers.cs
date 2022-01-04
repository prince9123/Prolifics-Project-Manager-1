using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Controllers
{
    public class RoleControllers
    {
        public IResult AddEmployee(Employee Emp)
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