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
        private static List<Employee> _employeeList = new List<Employee>();
        public void AddEmployee()
        {
            Employee employee = new Employee();
            try
            {
                Employee emp = new Employee();
                Console.WriteLine("Enter employee ID");
                emp.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the  name of employee");
                emp.EmpName = Console.ReadLine();
                Console.WriteLine("Enter employee Contact");
                emp.Contact = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter empoyee email");
                emp.Email = Console.ReadLine();
                Console.WriteLine("Enter the RoleId");
                emp.Role_id = Convert.ToInt32(Console.ReadLine());
                EmployeeManager employeeManager = new EmployeeManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Ocurred!" + ex.ToString());
            }
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
        public Data_Result<Employee> GetAllEmployee()
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
        public void DeleteEmployeeByID()
        {
            EmployeeManager employeeManager = new EmployeeManager();
            //Employee employee = new Employee();
            Console.WriteLine("Choose Employee From Below Employee List: Employee ID:Employee Name");
            var ResEmp = GetAllEmployee();
            if (ResEmp.IsSuccess)
            {
                foreach (Employee res in ResEmp.results)
                {
                    Console.WriteLine(res.ID + " : " + res.EmpName);
                }
            }
            else
            {
                Console.WriteLine(ResEmp.Status);
            }
            Console.Write("Enter The project Id wchich u want delete ");
            int Employeeid = Convert.ToInt32(Console.ReadLine());
            var result = RemoveEmployee(Employeeid);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Status);
            }
            else
            {
                Console.WriteLine(result.Status);
            }
        }
        public static Result RemoveEmployee(int Employeeid)
        {
            Employee employee = new Employee();
            Result valid = new Result() { IsSuccess = true };
            try
            {
                if (_employeeList.Exists(p => p.ID == Employeeid))
                {

                    var itemToRemove = _employeeList.Single(s => s.ID == Employeeid);
                    _employeeList.Remove(itemToRemove);
                    valid.Status = "Employee is Deleted Successfully " + employee.ID;

                }
                else
                {
                    valid.IsSuccess = false;
                    valid.Status = "Employee Id is not in the List!" + Employeeid;
                }
            }
            catch (Exception e)
            {
                valid.IsSuccess = false;
                valid.Status = "Exception Occured : " + e.ToString();
            }
            return valid;
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



