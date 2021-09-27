using System;
using System.Collections.Generic;
using Domain;
using MySqlX.XDevAPI.Common;
using PPM.Domain;
using PPM.Model;

namespace PPM.UI.CLI
{
    public class CommandInterface
    {
        public void StartProject()
        {

            Console.WriteLine("select the given nuber for operation");
            Console.WriteLine("1: Add Project");
            Console.WriteLine("2: View Project");
            Console.WriteLine("3: Add Employee");
            Console.WriteLine("4: View Employee");
            Console.WriteLine("5: Add Role");
            Console.WriteLine("6: View Role");
            Console.WriteLine("7: Add Employee to Project");
            Console.WriteLine("8: Delete Employee From Preoject");
            Console.WriteLine("9: View Project details");
            Console.WriteLine("10: Quit");

            bool j = true;
            while (j)
            {
                Console.WriteLine("select the given number for operation");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {

                    case 1:


                        Project Proj = new Project();
                        Console.WriteLine("Enter Project Pro_Id");
                        Proj.Pro_Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Project Name");
                        Proj.Name = Console.ReadLine();
                        Console.WriteLine("Enter Project Start_Date");
                        Proj.Start_Date = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter Project End_Date");
                        Proj.End_Date = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter Project Budget");
                        Proj.Budget = Convert.ToDecimal(Console.ReadLine());
                        ProjectManager Bk = new ProjectManager();
                        var Bp = Bk.AddProject(Proj);
                        if (!Bp.IsSuccess)
                        {
                            Console.WriteLine(Bp.Status);
                        }
                        else
                        {
                            Console.WriteLine(Bp.Status);
                        }
                        break;

                    case 2:

                        ProjectManager ProjManager = new ProjectManager();
                        var PP = ProjManager.GetProjectInfo();
                        if (PP.IsSuccess)
                        {
                            int c = 0;
                            foreach (Project item in PP.results)
                            {
                                Console.WriteLine("Project: " + c);
                                Console.WriteLine("Project id:" + item.Pro_Id);
                                Console.WriteLine("Project Name:" + item.Name);
                                Console.WriteLine("start date:" + item.Start_Date);
                                Console.WriteLine("End date:" + item.End_Date);
                                Console.WriteLine("budget:" + item.Budget);


                                c++;

                            }
                        }
                        else
                        {
                            Console.WriteLine(PP.Status);
                        }
                        break;
                    case 3:


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
                        var pe = employeeManager.AddEmployee(emp);
                        if (!pe.IsSuccess)
                        {
                            Console.WriteLine(pe.Status);
                        }
                        else
                        {
                            Console.WriteLine(pe.Status);
                        }

                        break;
                    case 4:
                        EmployeeManager employeeManage = new EmployeeManager();
                        var result = employeeManage.GetEmployeeInfo();
                        if (result.IsSuccess)
                        {
                            int i = 0;
                            foreach (Employee item in result.results)
                            {
                                Console.WriteLine("employee no: " + i);
                                Console.WriteLine("employee ID: " + item.ID);
                                Console.WriteLine("EmpName:" + item.EmpName);
                                Console.WriteLine("Contact:" + item.Contact);
                                Console.WriteLine("Email: " + item.Email);
                                Console.WriteLine("Role_id:" + item.Role_id);

                                i++;
                            }

                        }
                        else
                        {
                            Console.WriteLine(result.Status);
                        }
                        break;
                    case 5:
                        AddRole();
                        break;

                    case 6:
                        RoleManager roleMgr = new RoleManager();
                        var roleInfoResult = roleMgr.GetRoleInfo();
                        if (roleInfoResult.IsSuccess)
                        {
                            int count = 0;
                            foreach (Role item in roleInfoResult.results)


                            {
                                Console.WriteLine("Role no " + count);
                                Console.WriteLine("Role iD:" + item.RoleID);
                                Console.WriteLine("Role Name:" + item.Rolename);

                                count++;
                            }
                        }
                        else
                        {
                            Console.WriteLine(roleInfoResult.Status);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Add Employee to Project");
                        AddEmployeetoProject();
                        break;
                    case 8:
                        Console.WriteLine("Delete employee from Project");
                        DELETE_employeefromProj();
                        break;
                    case 9:
                        Console.WriteLine("Project Details with Employee Assigned:-");
                        ProjectManager projectctmana = new ProjectManager();
                        var resultPro = projectctmana.GetProjectInfo();
                        if (resultPro.IsSuccess)
                        {
                            foreach (Project Result in resultPro.results)
                            {
                                Console.WriteLine("Project ID: " + Result.Pro_Id + "\nProject Name: " + Result.Name + "\nStarting Date: " + Result.Start_Date + "\nEnd_Date: " + Result.End_Date + "\nBudget: " + Result.Budget);

                                Console.WriteLine("Employee Assigned: ");
                                if (Result.EmpList != null)
                                {
                                    foreach (Employee e in Result.EmpList)
                                    {
                                        Console.WriteLine("Employee Id: " + e.ID + " " + "Employee Name: " + e.EmpName + " " + "Employee Contact: " + e.Contact);
                                    }
                                }

                            }
                        }
                        break;
                    case 10:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
        private bool AddRole()
        {
            Role ROLE = new Role();
            try
            {
                Console.Write("Enter Role ID: ");
                ROLE.RoleID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Role Name: ");
                ROLE.Rolename = Console.ReadLine().ToUpper();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occoured!" + e.ToString());
                RoleManager pc = new RoleManager();
                pc.SubjectMenu();
            }


            RoleManager roleManager = new RoleManager();
            var resultRole = roleManager.AddRole(ROLE);
            if (!resultRole.IsSuccess)
            {
                Console.WriteLine("Role Failed to Add");
                Console.WriteLine(resultRole.Status);
            }
            else

            {
                Console.WriteLine(resultRole.Status);
            }
            return resultRole.IsSuccess;
        }


        public static bool AddEmployeetoProject()
        {
            Employee emp = new Employee();
            Console.WriteLine("Provide the project Id: ");
            int Pro_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name");
            emp.EmpName = Console.ReadLine();
            EmployeeManager employeeManager = new EmployeeManager();
            var valid = employeeManager.IsvalidEmp(emp);

            if (valid.IsSuccess)
            {
                ProjectManager projectmanger = new ProjectManager();
                var result = projectmanger.AddEmployeetoProject(emp, Pro_Id);

                if (!result.IsSuccess)
                {
                    Console.WriteLine("Employee failed to Add into project");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
                return result.IsSuccess;
            }
            else
            {
                Console.WriteLine(valid.Status);
            }
            return valid.IsSuccess;

        }
        public static bool DELETE_employeefromProj()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter project Proj_id");
            int Pro_Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of Employee: ");
            emp.EmpName = Console.ReadLine();
            EmployeeManager employeeManager = new EmployeeManager();
            var valid = employeeManager.IsvalidEmp(emp);
            if (!valid.IsSuccess)
            {
                ProjectManager Projectj = new ProjectManager();
                var result = Projectj.DELETE_employeefromProj(emp, Pro_Id);
                if (!result.IsSuccess)
                {
                    Console.WriteLine("Employee failed to remove from project");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
                return result.IsSuccess;
            }
            else
            {
                Console.WriteLine(valid.Status);
            }
            return valid.IsSuccess;
        }
    }
}
   


            


        

    

