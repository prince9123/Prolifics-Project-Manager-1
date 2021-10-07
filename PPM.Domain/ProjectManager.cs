using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using PPM.Model;
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
                Console.WriteLine("Enter Project Pro_Id");
                project.Pro_Id = Convert.ToInt32(Console.ReadLine());
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
                    Console.WriteLine(res.Pro_Id + " : " + res.Name);
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
                if (_projectList.Exists(p => p.Pro_Id == id))
                {
                    var itemToRemove = _projectList.Single(s => s.Pro_Id == id);
                    _projectList.Remove(itemToRemove);
                    action.Status = "Project is Deleted Successfully " + project.Pro_Id;
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

        public Result Remove(Employee emp, int Pro_Id2)
        {
            Result result = new Result() { IsSuccess = true };
            Project project = new Project();
            try
            {
                if (_projectList.Exists(p => p.Pro_Id == Pro_Id2))
                {
                    if (_projectList.Single(s => s.Pro_Id == Pro_Id2).EmpList.Exists(n => n.ID == emp.ID))
                    {
                        var itemToRemove = _projectList.Single(s => s.Pro_Id == Pro_Id2).EmpList.Single(e => e.ID == emp.ID);
                        _projectList.Single(s => s.Pro_Id == Pro_Id2).EmpList.Remove(itemToRemove);
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
                    result.Status = "Project Id is not in the List!" + Pro_Id2;
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
            var resPro = ListAll ();
            if (resPro.IsSuccess)
            {
                foreach (Project result in resPro.results)
                {
                    Console.WriteLine(result.Pro_Id + " : " + result.Name);
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
            employee.ID  = Convert.ToInt32(Console.ReadLine());
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
        public Result IsEmployeePresentinProject(int Pro_Id1)
        {
            Result result = new Result() { IsSuccess = true };
            uint count = 0;
            if (_projectList.Count > 0)
            {
                foreach (Project Pro in _projectList)
                {
                    if (Pro.EmpList.Exists(prop => prop.ID == Pro_Id1))
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


        public Result AddEmployeetoProject(Employee emp, int Pro_Id1)
        {
            Result result = new Result() { IsSuccess = true };

            try
            {
                if (_projectList.Count > 0)
                {
                    if (_projectList.Exists(p => p.Pro_Id == Pro_Id1))
                    {
                        if (_projectList.Single(p => p.Pro_Id == Pro_Id1).EmpList == null)
                        {
                            _projectList.Single(p => p.Pro_Id == Pro_Id1).EmpList = new List<Employee>();
                        }

                        if (_projectList.Single(p => p.Pro_Id == Pro_Id1).EmpList.Exists(e => e.ID == emp.ID))
                        {
                            result.Status = $"Employee Id : {emp.ID} already exists in this project: {Pro_Id1}";
                        }
                        else
                        {
                            _projectList.Single(p => p.Pro_Id == Pro_Id1).EmpList.Add(emp);
                            result.Status = "Employee is Added to project";

                        }

                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Status = "Project Id not found!" + Pro_Id1;
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
    }
}

   




