using System;
using System.Collections.Generic;
using PPM.Domain;
using PPM.Model;
using System.Text.RegularExpressions;
using Domain;
using Web.Controllers;

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
                            save();
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
                           CommandInterface.AddProject();
                            break;
                        case 2:
                            Console.WriteLine("Project Details: ");
                            var ResPro = m1.ListAll();
                            if (ResPro.IsSuccess)
                            {
                                foreach (Project result1 in ResPro.results)
                                {
                                    Console.WriteLine("Project id: " + result1.ProjecID + "\nProject Name: " + result1.Name + "\nstarting date: " + result1.Start_Date + "\nEnd Date:" + result1.End_Date + "\nBudget :" + result1.Budget);
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
                                    if (result1.ProjecID == n1)
                                    {
                                        Console.WriteLine("Project id: " + result1.ProjecID + "\nProject Name: " + result1.Name + "\nstarting date: " + result1.Start_Date + "\nEnd Date:" + result1.End_Date + "\nBudget :" + result1.Budget);

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
                            CommandInterface.AddEmployee();
                            break;
                        case 2:
                            Console.WriteLine("Employee Details: ");
                            var ResEmp = m2.ListAll();
                            if (ResEmp.IsSuccess)
                            {
                                foreach (Employee e1 in ResEmp.results)
                                {
                                    Console.WriteLine("Employee id: " + e1.ID + "\nEmployee_Name Name: " + e1.EmpName + "\nContact: " + e1.Contact + "\nEmail :"
                                        + e1.Email + "\nRoleid :" + e1.Role_id);


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
                            CommandInterface.AddRole();
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

        public void save()
        {
            try
            {
                Console.WriteLine("Press 1: Save as XML file");
                Console.WriteLine("Press 2: Save as TXT File");
                Console.WriteLine("Press 3: Save as DB-Ado");
                Console.WriteLine("Press 4: Save as DB-EF");
                Console.Write("Please Choose the Save Method: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                EmployeeManager employeeManager = new EmployeeManager();
                ProjectManager projectManager = new ProjectManager();
                RoleManager roleManager = new RoleManager();
                switch (choice)
                {

                    case 1:
                        Console.WriteLine("---SAVE AS XML FILE---");
                        static String GetTimestamp(DateTime value)
                        {
                            return value.ToString("yyyyMMddHHmmssffff");
                        }
                        //  ...later on in the code
                        String timeStamp = GetTimestamp(DateTime.Now);
                        Console.WriteLine(timeStamp);
                        var employeeSerialize = employeeManager.ToXmlSerialization("Employee.xml");
                        var projectSerialize = projectManager.ToXmlSerialization("Project.xml");
                        var roleSerialize = roleManager.ToXmlSerialization("Role.xml");

                        if (employeeSerialize.IsSuccess || projectSerialize.IsSuccess || roleSerialize.IsSuccess)
                        {
                            Console.WriteLine("Save Data Successfully!");
                            Console.WriteLine(employeeSerialize.Status + "\n" + projectSerialize.Status + "\n" + roleSerialize.Status);
                            Console.WriteLine(timeStamp);
                        }
                        else
                        {
                            Console.WriteLine(employeeSerialize.Status + "\n" + projectSerialize.Status + "\n" + roleSerialize.Status);
                        }
                        break;
                    case 2:
                        Console.WriteLine("---SAVE AS TEST FILE---");
                        //  ...later on in the code
                        String timeStampTxt = GetTimestamp(DateTime.Now);
                        Console.WriteLine(timeStampTxt);
                        var saveRoleToText = roleManager.ToTxtFile("role.txt");
                        var saveEmployeeToText = employeeManager.ToTxtFile("SaveEmployee.txt");
                        var saveProjectToText = projectManager.ToTxtFile("SaveProject.txt");
                        if (saveRoleToText.IsSuccess || saveEmployeeToText.IsSuccess || saveProjectToText.IsSuccess)
                        {
                            Console.WriteLine("Save Data To TEXT File Successfully!");
                            Console.WriteLine(saveRoleToText.Status + "\n" + saveProjectToText.Status + "\n" + saveEmployeeToText.Status);
                            Console.WriteLine(timeStampTxt);
                        }
                        else
                        {
                            Console.WriteLine(saveRoleToText.Status + "\n" + saveProjectToText.Status + "\n" + saveEmployeeToText.Status);
                        }
                        break;
                    case 3:
                        Console.WriteLine("---Save AS DB-ADO METHOD---");
                        DBModule dB = new DBModule();
                        dB.DB_ADO();
                        break;
                    case 4:
                        Console.WriteLine("---SAVE AS DB-EF METHOD---");
                        DBModule dB1 = new DBModule();
                        dB1.DB_EF();
                        break;


                }
            }
            catch (Exception)
            {
                Console.WriteLine("Oops, Error Occoured at Save State!");
                Console.WriteLine("-----------------------------------------------------");
                StartProject();

            }

        }
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
            EmployeeControllers employeController = new();
            employeController.AddEmployee(employee);
        }

        public static void AddRole()
        {
            Role ROLE = new Role();
            try
            {
                Console.Write("Enter Role ID: ");
                ROLE.RoleID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Role Name: ");
                ROLE.Rolename = Console.ReadLine().ToUpper();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Ocurred!" + ex.ToString());
            }
            RoleControllers roleController = new();
            roleController.AddRole(ROLE);
        }
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
            ProjectControllers projectController = new();
           projectController.AddProject(project);
        }
    }
}

namespace PPM.UI.CLI
{
    class EmployeeControllers
    {
    }
}
