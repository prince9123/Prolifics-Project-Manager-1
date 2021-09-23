using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPM.Model;
namespace Domain
{
    public class EmployeeManager
    {
        private static List<Employee> _employeeList;
        static EmployeeManager()
        {
            _employeeList = new List<Employee>();
        }

        public Result AddEmployee(Employee emp)
        {
            Result result = new Result() { IsSuccess = true };
            try
            {
                _employeeList.Add(emp);
                result.Status = "Employee added";
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.ToString());
                result.IsSuccess = false;
            }
            return result;

        }
        public Data_Result<Employee> GetEmployeeInfo()
        {
            Data_Result<Employee> result = new Data_Result<Employee>() { IsSuccess = true };
            if (_employeeList.Count > 0)
            {
                result.results = _employeeList;
            }
            else
            {
                result.IsSuccess = false;
                result.Status = "List is empty!";
            }
            return result;
        }

        public Result IsvalidEmp(Employee emp)
        {
            //  throw new NotImplementedException();
            Result result = new Result() { IsSuccess = true };
            try
            {
                if (_employeeList.Exists(e => e.EmpName.ToUpper() == emp.EmpName.ToUpper()))
                {
                    result.IsSuccess = true;

                }
                else
                {
                  
                    result.IsSuccess = false;
                    result.Status = "Employee name is not in the list";
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
            }
            return result;

        }
    }
}

