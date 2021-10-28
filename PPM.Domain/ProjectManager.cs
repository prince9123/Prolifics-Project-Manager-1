using Domain;
using PPM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace PPM.Domain
{
    public class ProjectManager : IOperations<Project>
    {
        public static List<Project> _projectList = new List<Project>();

        public void AddProject()
        {
            Project project = new Project();
            try
            {
                Console.WriteLine("Enter Project ProjecID");
                project.ProjecID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Project Name");
                project.Name = Console.ReadLine();
                Console.WriteLine("Enter Project Start_Date");
                project.Start_Date = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Project End_Date");
                project.End_Date = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Project Budget");
                project.Budget = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Ocurred!" + e.ToString());
            }
            var resultProject = Add(project);
            if (!resultProject.IsSuccess)
            {
                Console.WriteLine("Project failed to Add");
                Console.WriteLine(resultProject.Status);
            }
            else
            {
                Console.WriteLine(resultProject.Status);
            }
        }

        public Result Add(Project Proj)
        {
            Result result = new Result() { IsSuccess = true };
            try
            {
                _projectList.Add(Proj);
                result.Status = "Project added";
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                result.IsSuccess = false;
            }
            return result;
        }
        public Data_Result<Project> ListAll()
        {
            Data_Result<Project> result = new Data_Result<Project>() { IsSuccess = true };
            if (_projectList.Count > 0)
            {
                result.results = _projectList;
            }
            else
            {
                result.IsSuccess = false;
                result.Status = "faild";
            }
            return result;


        }

        public void DeleteProjectById()
        {
            ProjectManager projectManager = new ProjectManager();
            //Employee employee = new Employee();
            Console.WriteLine("Choose Project From Below Project List: Project ID:Project Name");
            var resPro = ListAll();
            if (resPro.IsSuccess)
            {
                foreach (Project res in resPro.results)
                {
                    Console.WriteLine(res.ProjecID + " : " + res.Name);
                }
            }
            else
            {
                Console.WriteLine(resPro.Status);
            }
            Console.Write("Enter The project Id wchich u want delete ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            var result = Remove(projectId);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Status);
            }
            else
            {
                Console.WriteLine(result.Status);
            }

        }

        public Result Remove(int id)
        {
            Project project = new Project();
            Result action = new Result() { IsSuccess = true };
            try
            {
                if (_projectList.Exists(p => p.ProjecID == id))
                {
                    var itemToRemove = _projectList.Single(s => s.ProjecID == id);
                    _projectList.Remove(itemToRemove);
                    action.Status = "Project is Deleted Successfully " + project.ProjecID;
                }
                else
                {
                    action.IsSuccess = false;
                    action.Status = "Project Id is not in the List!" + id;
                }
            }
            catch (Exception e)
            {
                action.IsSuccess = false;
                action.Status = "Exception Occured : " + e.ToString();
            }
            return action;
        }

        public Result Remove(Employee emp, int ProId2)
        {
            Result result = new Result() { IsSuccess = true };
            Project project = new Project();
            try
            {
                if (_projectList.Exists(p => p.ProjecID == ProId2))
                {
                    if (_projectList.Single(s => s.ProjecID == ProId2).EmpList.Exists(n => n.ID == emp.ID))
                    {
                        var itemToRemove = _projectList.Single(s => s.ProjecID == ProId2).EmpList.Single(e => e.ID == emp.ID);
                        _projectList.Single(s => s.ProjecID == ProId2).EmpList.Remove(itemToRemove);
                        result.Status = "Employee is Deleted Successfully " + emp.ID;
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Status = "Given Employee ID is not Present in the particular Project " + emp.ID;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Status = "Project Id is not in the List!" + ProId2;
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Status = "Exception Occured : " + e.ToString();
            }
            return result;


        }
        public void AddEmployeetoProject()
        {
            EmployeeManager m1 = new EmployeeManager();
            Employee employee = new Employee();
            Console.WriteLine("Choose Project From Below Project List: Project ID:Project Name");
            var resPro = ListAll();
            if (resPro.IsSuccess)
            {
                foreach (Project result in resPro.results)
                {
                    Console.WriteLine(result.ProjecID + " : " + result.Name);
                }
            }
            else
            {
                Console.WriteLine(resPro.Status);
            }
            Console.Write("Provide the project Id: ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Below is the Employee ID and respective Name to choose:");
            var res = m1.ListAll();
            if (res.IsSuccess)
            {
                foreach (Employee e in res.results)
                {
                    Console.WriteLine(e.ID + " : " + e.Rolename);
                }
            }
            else
            {
                Console.WriteLine(res.Status);
            }
            Console.Write("Enter the Id of the employee: ");
            employee.ID = Convert.ToInt32(Console.ReadLine());
            var valid = m1.IsvalidEmp(employee);
            if (valid.IsSuccess)
            {



                var obj = m1.GetEmployeetorole(employee);
                employee.Rolename = obj.Rolename;
                employee.EmpName = obj.EmpName;
                var result = AddEmployeetoProject(employee, projectId);



                if (!result.IsSuccess)
                {
                    Console.WriteLine("Failed to Add Employee into project");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
            }
            else
            {
                Console.WriteLine(valid.Status);
            }
        }
        public Result IsEmployeePresentinProject(int ProId1)
        {
            Result result = new Result() { IsSuccess = true };
            uint count = 0;
            if (_projectList.Count > 0)
            {
                foreach (Project Pro in _projectList)
                {
                    if (Pro.EmpList.Exists(prop => prop.ID == ProId1))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    result.Status = "Employee is present!";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Status = "Employee is not present in any project!";
                }
            }
            else
            {
                result.IsSuccess = false;
            }
            return result;

        }


        public Result AddEmployeetoProject(Employee emp, int ProId1)
        {
            Result result = new Result() { IsSuccess = true };

            try
            {
                if (_projectList.Count > 0)
                {
                    if (_projectList.Exists(p => p.ProjecID == ProId1))
                    {
                        if (_projectList.Single(p => p.ProjecID == ProId1).EmpList == null)
                        {
                            _projectList.Single(p => p.ProjecID == ProId1).EmpList = new List<Employee>();
                        }

                        if (_projectList.Single(p => p.ProjecID == ProId1).EmpList.Exists(e => e.ID == emp.ID))
                        {
                            result.Status = $"Employee Id : {emp.ID} already exists in this project: {ProId1}";
                        }
                        else
                        {
                            _projectList.Single(p => p.ProjecID == ProId1).EmpList.Add(emp);
                            result.Status = "Employee is Added to project";

                        }

                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Status = "Project Id not found!" + ProId1;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Status = "Project list is Empty!";
                }
            }





            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Status = "Exception Occured : " + e.ToString();
            }
            return result;

        }
    
        public Result ToXmlSerialization(string fileName)
        {
            Result actionResult = new Result() { IsSuccess = true };
            try
            {
                if (_projectList.Count > 0)
                {
                    //string filePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("F:\\PPM\\PPM.Model"), "AppData", fileName)
                    //var filePath = System.IO.File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + fileName)
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Project>));
                    using (TextWriter tw = new StreamWriter(fileName))
                    {
                        serializer.Serialize(tw, _projectList);
                        tw.Close();
                    }
                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Project List is Empty!";
                }
            }
            catch (Exception e)
            {
                actionResult.IsSuccess = false;
                actionResult.Status = "Error Ocooured!" + e.Message;
            }
            return actionResult;
        }

        public Result ToTxtFile(string fileName)
        {
            Result actionResult = new Result() { IsSuccess = true };
            try
            {
                if (_projectList.Count > 0)
                {
                    using (TextWriter sw = new StreamWriter(fileName))
                    {
                        foreach (Project pro in _projectList)
                        {
         sw.WriteLine("Project ID: " + pro.ProjecID + "\nProject Name: " + pro.Name + "\nStarting Date: " + pro.Start_Date.ToShortDateString() + 
                                "\nEnding Date: " + pro.End_Date.ToShortDateString() + "\nBudget: " + pro.Budget);
                            sw.WriteLine("Employee Assigned:");
                            if (pro.EmpName != null)
                            {
                                foreach (Employee e in pro.EmpList)
                                {
                                    sw.WriteLine("Employee Id: " + e.ID + " " + "|" + "Employee Name : " + e.EmpName + " " + "|" + "Role : " + e.Rolename);
                                }
                            }
                            else
                            {
                                sw.WriteLine("No Employee Assigned!");
                            }
                            sw.WriteLine("-------------------------------------------------------");
                            actionResult.Status = "Project Is Saved in The Text File!";
                        }
                    }
                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Project list is empty!";
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
            string str = "DROP TABLE IF EXISTS project";
            try
            {
                myConn.Open();
                using (SqlCommand command = new SqlCommand(str, myConn))
                {
                    command.ExecuteNonQuery();
                    actionResult.Status = "Old Data Dropped Successfully!";
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
                    using (SqlCommand command = new SqlCommand("CREATE TABLE project (Pro_Id int,ProjectName varchar(50), StartDate datetime, EndDate datetime, Budget decimal, EmpId int);", myConn))
                    {
                        command.ExecuteNonQuery();

                        foreach (Project project in _projectList)
                        {
                            foreach (Employee emp in project.EmpList)
                            {
                                int id = (int)project.ProjecID;
                                int EmpId = (int)emp.ID;
                                string insertQ = "INSERT INTO project values(@Pro_Id,@Name,@Start_Date, @End_Date, @Budget,@EmpId)";
                                SqlCommand command1 = new SqlCommand(insertQ, myConn);
                                command1.Parameters.AddWithValue("@ProjectId", project.ProjecID);
                                command1.Parameters.AddWithValue("@ProjectName", project.Name);
                                command1.Parameters.AddWithValue("@StartDate", project.Start_Date);
                                command1.Parameters.AddWithValue("@EndDate", project.End_Date);
                                command1.Parameters.AddWithValue("@Budget", project.Budget);
                               // command1.Parameters.AddWithValue("@EmpId", EmpId);
                                command1.ExecuteNonQuery();
                            }
                        }
                        actionResult.Status = actionResult.Status + "\n" + "Table project Added SuccessFully!";
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
            }
            return actionResult;
        }
        public Data_Result<Project> ToEFDB()
        {

            Data_Result<Project> actionResult = new Data_Result<Project>() { IsSuccess = true };
            try
            {

                if (_projectList.Count > 0)
                {

                    using (var db = new context())
                    {
                        Project project1 = new Project();
                        List<Project> projectList = db.Projects.ToList();
                        foreach (Project project in _projectList)
                        {
                            project1.ProjecID = project.ProjecID;
                            project1.Name = project.Name;
                            project1.Budget = project.Budget;
                            project1.End_Date = Convert.ToDateTime(project.End_Date.ToShortDateString());
                            project1.Start_Date = Convert.ToDateTime(project.Start_Date.ToShortDateString());
                            if (projectList.Exists(p => p.ProjecID == project.ProjecID))
                            {
                                var p = projectList.Single(p => p.ProjecID == project.ProjecID);
                                db.Projects.Remove(p);
                                db.SaveChanges();

                                db.Projects.Add(project1);
                                db.SaveChanges();
                            }
                            else
                            {
                                db.Projects.Add(project1);
                                db.SaveChanges();
                            }

                        }
                    }
                    actionResult.Status = "Project Saved to Database Successfully";
                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Project List is Empty!";
                }
            }
            catch (Exception e)
            {
                actionResult.IsSuccess = false;
                actionResult.Status = e.Message;
            }
            return actionResult;
        }
    }
}
    


   




