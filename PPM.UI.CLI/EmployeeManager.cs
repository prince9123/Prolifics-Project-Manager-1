using PPM.Model;
using System;
using System.Collections.Generic;

namespace PPM.UI.CLI
{
    internal class EmployeeManager
    {
        public static List<Employee> _empList = new List<Employee>();
        public static List<Project> _projectList = new List<Project>();


        internal Data_Result<Employee> GetEmployeeInfo()
        {
            Data_Result<Employee> result = new Data_Result<Employee>() { IsSuccess = true };
            if (_empList.Count > 0)
            {
                result.results = _empList;
            }
            else
            {
                result.IsSuccess = false;
                result.Status = "faild";
            }
            return result;

        }
        internal Result IsvalidEmp(Employee emp)
        {
            Result result = new Result();
            try
            {
                if (_empList.Exists(e => e.ID == emp.ID))
                {
                    result.Status = "Validation Successful!";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Status = "ID is not in the Employee List " + emp.ID;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                result.IsSuccess = false;
            }
            return result;
        }
    }

    internal Result AddProject(Project Proj)
    {

    }
        internal Result AddEmployee(Employee emp)
        {

            Result result = new Result() { IsSuccess = true };
            try
            {
                _empList.Add(emp);
                result.Status = "Employee Added ";
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                result.IsSuccess = false;
            }
            return result;
            
        }
    }
}