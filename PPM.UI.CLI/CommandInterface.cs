using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Domain;
using PPM.Domain;
using PPM.Model;

namespace PPM.UI.CLI
{
    public class CommandInterface 
    {

        public void StartProject()
        {

            Console.WriteLine("Choose the option you want to select:");
            Console.WriteLine("Press 1: Project Module");
            Console.WriteLine("Press 2: Employee Module");
            Console.WriteLine("Press 3: Role Module");
            Console.WriteLine("Press 4: Save into xml File");
            Console.WriteLine("Press 5: Exit");
            int i = 0;
            while (true)
            {
                try
                {

                    Console.WriteLine("choose the given option: ");
                    i = Convert.ToInt32(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            ProjectModule();
                            break;
                        case 2:
                            EmployeeModule();
                            break;
                        case 3:
                            RoleModule();
                            break;
                        case 4:
                            save p = new save();
                            p.Save();
                            break;
                        default:
                            Console.WriteLine("Option is not in the list!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("oops! Error Occured! Try Again");
                    StartProject();

                }

            }
        }

        public void ProjectModule()
        {
            Console.WriteLine("Choose the option you want to select:");
            Console.WriteLine("Press 1: Add Project");
            Console.WriteLine("Press 2: List Project");
            Console.WriteLine("Press 3: List Project by Id");
            Console.WriteLine("Press 4: Delete Project");
            Console.WriteLine("Press 5: Add Employee to project");
            Console.WriteLine("Press 6: Go to main Menu");
            int j = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose Your Option from 1 to 6 : ");
                    j = Convert.ToInt32(Console.ReadLine());
                    ProjectManager m1 = new ProjectManager();
                    switch (j)
                    {
                        case 1:
                            m1.AddProject();
                            break;
                        case 2:
                            Console.WriteLine("Project Details: ");
                            var ResPro = m1.ListAll();
                            if (ResPro.IsSuccess)
                            {
                                foreach (Project result1 in ResPro.results)
                                {
                                    Console.WriteLine("Project id: " + result1.Pro_Id + "\nProject Name: " + result1.Name + "\nstarting date: " + result1.Start_Date + "\nEnd Date:" + result1.End_Date + "\nBudget :" + result1.Budget);
                                }

                            }
                            else
                            {
                                Console.WriteLine(ResPro.Status);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter project id which u want to display");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Project Details:");
                            var ResPro1 = m1.ListAll();
                            if (ResPro1.IsSuccess)
                            {
                                foreach (Project result1 in ResPro1.results)
                                {
                                    if (result1.Pro_Id == n1)
                                    {
                                        Console.WriteLine("Project id: " + result1.Pro_Id + "\nProject Name: " + result1.Name + "\nstarting date: " + result1.Start_Date + "\nEnd Date:" + result1.End_Date + "\nBudget :" + result1.Budget);

                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(ResPro1.Status);
                            }
                            break;
                        case 4:
                            m1.DeleteProjectById();
                            break;
                        case 5:
                            m1.AddEmployeetoProject();
                            break;
                        case 6:
                            StartProject();
                            break;
                        default:
                            Console.WriteLine("OOPS!Error occured! Try Again");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("OOPS!Error Ocurred! try again");
                    StartProject();
                }
            }
        }

        public void EmployeeModule()
        {
            Console.WriteLine("Choose the Option you want to select:");
            Console.WriteLine("Press 1: Add Employee");
            Console.WriteLine("Press 2: List All Employee");
            Console.WriteLine("Press 3: List Employee by Id");
            Console.WriteLine("Press 4: Delete Employee");
            Console.WriteLine("Press 5: Return to main Menu");
            int j = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose Your option from 1 to 5: ");
                    j = Convert.ToInt32(Console.ReadLine());
                    EmployeeManager m2 = new EmployeeManager();
                    switch (j)
                    {
                        case 1:
                            m2.AddEmployee();
                            break;
                        case 2:
                            Console.WriteLine("Employee Details: ");
                            var ResEmp = m2.ListAll();
                            if (ResEmp.IsSuccess)
                            {
                                foreach (Employee e1 in ResEmp.results)
                                {
                                    Console.WriteLine("Employee id: " + e1.ID + "\nEmployee_Name Name: " + e1.EmpName + "\nContact: " + e1.Contact + "\nEmail :" + e1.Email + "\nRoleid :" + e1.Role_id);


                                }

                            }
                            else
                            {
                                Console.WriteLine(ResEmp.Status);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Employee id which u want to display");
                            int E1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Employee Details: ");
                            var ResEmp1 = m2.ListAll();
                            if (ResEmp1.IsSuccess)
                            {
                                foreach (Employee e1 in ResEmp1.results)
                                {
                                    if (e1.ID == E1)
                                    {
                                        Console.WriteLine("Employee id: " + e1.ID + "\nEmployee_Name Name: " + e1.EmpName + "\nContact: " + e1.Contact + "\nEmail :" + e1.Email + "\nRoleid :" + e1.Role_id);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(ResEmp1.Status);
                            }
                            break;
                        case 4:
                            m2.DeleteEmployeeByID();
                            break;
                        case 5:
                            StartProject();
                            break;
                        default:
                            Console.WriteLine("OOPS ! Error Occoured! Try Again");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("OOPS Error occured! try Again");
                }
            }
        }
        public void RoleModule()
        {
            Console.WriteLine("Choose the Option you want to select:");
            Console.WriteLine("Press 1: Add Role");
            Console.WriteLine("Press 2: List All Role");
            Console.WriteLine("Press 3: List Role by Id");
            Console.WriteLine("Press 4: Delete Role");
            Console.WriteLine("Press 5: GO to main Menu");
            int j = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose your options: ");
                    j = Convert.ToInt32(Console.ReadLine());
                    RoleManager m3 = new RoleManager();
                    switch (j)
                    {
                        case 1:
                            m3.AddRole();
                            break;
                        case 2:
                            Console.WriteLine("Role Details: ");
                            var Resrole = m3.ListAll();
                            if (Resrole.IsSuccess)
                            {
                                foreach (Role e2 in Resrole.results)
                                {
                                    Console.WriteLine("Role Id: " + e2.RoleID + "\nRole Name: " + e2.Rolename);

                                }

                            }
                            else
                            {
                                Console.WriteLine(Resrole.Status);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter project id which u want to display");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Project Details:");
                            var Resrole1 = m3.ListAll();
                            if (Resrole1.IsSuccess)
                            {
                                foreach (Role e2 in Resrole1.results)
                                {
                                    if (e2.RoleID == n1)
                                    {
                                        Console.WriteLine("Role Id: " + e2.RoleID + "\nRole Name: " + e2.Rolename);

                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(Resrole1.Status);
                            }
                            break;
                        case 4:
                            m3.DeleteRoleById();
                            break;
                        case 5:
                            StartProject();
                            break;
                        default:
                            Console.WriteLine("optipon is in the list!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("oops! Error occured! Try Again");
                }

            }
        }
    }
}