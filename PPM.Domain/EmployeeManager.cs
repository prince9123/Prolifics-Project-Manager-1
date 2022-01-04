using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PPM.Domain;
using PPM.Model;
using System.Data.SqlClient;
using System.Data;


namespace Domain
{
    public class EmployeeManager : IOperations<Employee>
    {
        public static List<Employee> _employeeList = new List<Employee>();

        public SqlCommand command1 { get; private set; }

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
        public Result ToXmlSerialization(string fileName)
        {
            Result actionResult = new Result() { IsSuccess = true };
            try
            {
                if (_employeeList.Count > 0)
                {
                    //string filePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("F:\\PPM\\PPM.Model"), "AppData", fileName)
                    //var filePath = System.IO.File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + fileName)
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                    using (TextWriter tw = new StreamWriter(fileName))
                    {
                        serializer.Serialize(tw, _employeeList);
                        tw.Close();
                    }

                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Employee List is Empty!";
                }
            }
            catch (Exception e)
            {
                actionResult.IsSuccess = false;
                actionResult.Status = "Error Occoured!" + e.Message; 
            }
            return actionResult;
        }

        public Result ToTxtFile(string fileName)
        {
            Result actionResult = new Result() { IsSuccess = true };
            try
            {
                if (_employeeList.Count > 0)
                {
                    using (TextWriter sw = new StreamWriter(fileName))
                    {
                        foreach (Employee e in _employeeList)
                        {
                            sw.WriteLine("Employee Id: " + e.ID + "\nEmployee Name: " + e.EmpName + "\nContact Number : " + e.Contact+ "\nEmail :"
                                + e.Email + "\nRole Id: " + e.Role_id);
                            sw.WriteLine("--------------------------------------------------------------------------------------");
                            actionResult.Status = "Employee Is Saved in The Text File!";
                        }
                    }
                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Employee list is empty!";
                }
            }
            catch (Exception e)
            {
                actionResult.IsSuccess = false;
                actionResult.Status = "Error Occoured" + "\n" + e.Message;
            }

            return actionResult;
        }
        public Result ToAdoDB()
        {
            Result actionResult = new Result() { IsSuccess = true };
            string conn = "Server=(ESN0OA3)PRINCESQL; Database=mvcCrudedb;Integrated security=true;TrustServerCertificate=true";
            SqlConnection myConn = new SqlConnection(conn);
            string str = "DROP TABLE IF EXISTS employee";
            try
            {
                myConn.Open();
                using (SqlCommand command = new SqlCommand(str, myConn))
                {
                    command.ExecuteNonQuery();
                    actionResult.Status = "Old Data of Employee Dropped Successfully!";
                }
            }
            catch (Exception e)
            {
                actionResult.IsSuccess = false;
                actionResult.Status = e.Message;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            if (actionResult.IsSuccess)
            {
                try
                {
                    myConn.Open();
                    using (SqlCommand command = new SqlCommand("CREATE TABLE employee (Id int,EmpName varchar(50)," +
                        "Contact bigint, Role_id int);", myConn))
                    {
                        command.ExecuteNonQuery();

                        foreach (Employee employee in _employeeList)
                        {
                            int id = (int)employee.ID;
                            long contact = (long)employee.Contact;
                            string insertQ = "INSERT INTO employee values(@ID,@EmpName,@Contact,@Role_id)";
                            command1 = new SqlCommand(insertQ, myConn);
                            command1.Parameters.AddWithValue("@Id", id);
                            command1.Parameters.AddWithValue("@EmpName", employee.EmpName);
                            command1.Parameters.AddWithValue("@Contact", contact);
                            command1.Parameters.AddWithValue("@Email", employee.Email);
                            command1.Parameters.AddWithValue("@Role_id", employee.Role_id);
                            command1.ExecuteNonQuery();

                        }
                    }
                    actionResult.Status = actionResult.Status + "\n" + "Table employee Added SuccessFully!";


                }
                catch (Exception e)
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = e.Message;
                }
                finally
                {
                    if (myConn.State == ConnectionState.Open)
                    {
                        myConn.Close();
                    }
                }
            }
            return actionResult;
        }
        public Result ToEFDB()
        {
            Result actionResult = new Result() { IsSuccess = true };
            try
            {
                using (var db = new context())
                {
                    foreach (Employee employee in _employeeList)
                    {

                        db.Employees.Add(employee);
                        db.SaveChanges();
                    }
                }
                actionResult.Status = "Employee Saved to Database Successfully";
            }
            catch (Exception e)
            {
                actionResult.IsSuccess = true;
                actionResult.Status = e.Message;
            }
            return actionResult;
        }
    }
}






