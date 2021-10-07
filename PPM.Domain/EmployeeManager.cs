using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPM.Domain;
using PPM.Model;
namespace Domain
{
    public class EmployeeManager : IOperations<Employee>
    {
        private static List<Employee> _employeeList = new List<Employee>();
        public void AddEmployee()
        {
            Employee employee = new Employee();
            try
            {
                Console.WriteLine("Enter employee ID");
                employee.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the  name of employee");
                employee.EmpName = Console.ReadLine();
                Console.WriteLine("Enter employee Contact");
                employee.Contact = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter empoyee email");
                employee.Email = Console.ReadLine();
                Console.WriteLine("Enter the RoleId");
                employee.Role_id = Convert.ToInt32(Console.ReadLine());
                EmployeeManager employeeManager = new EmployeeManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Ocurred!" + ex.ToString());
            }
            var resultEmployee = Add(employee);
            if (!resultEmployee.IsSuccess)
            {
                Console.WriteLine("Employee failed to Add");
                Console.WriteLine(resultEmployee.Status);
            }
            else
            {
                Console.WriteLine(resultEmployee.Status);
            }
        }

        public Result Add(Employee emp)
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
        public Data_Result<Employee> ListAll()
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

        public  void DeleteEmployeeByID()
        {
            Console.WriteLine("Choose Employee From Below Employee List: Employee ID:Employee First Name");
            var resPro = ListAll();
            if (resPro.IsSuccess)
            {
                foreach (Employee res in resPro.results)
                {
                    Console.WriteLine(res.ID + " : " + res.EmpName);
                }
            }
            else
            {
                Console.WriteLine(resPro.Status);
            }
            Console.Write("Enter The Employee Id wchich u want delete ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            ProjectManager m1 = new ProjectManager();
            var result1 = m1.IsEmployeePresentinProject(n2);
            if (!result1.IsSuccess)
            {
                var result = Remove(n2);
                if (!result.IsSuccess)
                {
                    Console.WriteLine("Employee is not deleted");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
            }
            else
            {
                Console.WriteLine(result1.Status);
            }
        }
       
        public Result Remove(int Employeeid)
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

        public Employee GetEmployeetorole(Employee employeeId)
        {
            Employee emp = new Employee();
            emp.Rolename = _employeeList.Single(e => e.ID == employeeId.ID).Rolename;
            emp.EmpName = _employeeList.Single(e => e.ID == employeeId.ID).EmpName;
            return emp;
        }
    }
}





