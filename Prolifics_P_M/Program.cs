using PPM.Model;
using PPM.UI.CLI;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Prolifics_P_M
{
    public  class Program
    {
        public static void Main()
        {
            CommandInterface commandinterfac = new CommandInterface();
            commandinterfac.StartProject();
        }
    }

    
}

            //  Console.WriteLine("select the given nuber for operation");
            // Console.WriteLine("1: Add Project");
            //Console.WriteLine("2: View Project");
            // Console.WriteLine("3: Add Employee");
            //Console.WriteLine("4: View Employee");
            //Console.WriteLine("5: Add Role");
            //Console.WriteLine("6: View Role");

            // Console.WriteLine("7: Quit");


            //    List<Employee> emp2 = new List<Employee>();
            //  List<Project> Pro = new List<Project>();
            //  List<Role> Rol = new List<Role>();



            // bool j = true;
            // while (j)
            //    {
            //       Console.WriteLine("select the given nuber for operation");
            //       int num = int.Parse(Console.ReadLine());
            //    switch (num)
            //       {

            //          case 1:
            //            Project Proj = new Project();

            //
            //          Console.WriteLine("Enter Project Pro_Id");
            ///           Proj.Pro_Id = Convert.ToInt32(Console.ReadLine());
            ///           Console.WriteLine("Enter Project Name");
            //          Proj.Name = Console.ReadLine();
            /*        Console.WriteLine("Enter Project Start_Date");
                    Proj.Start_Date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Project End_Date");
                    Proj.End_Date = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Project Budget");
                    Proj.Budget = Convert.ToDecimal(Console.ReadLine());

                    if (Pro.Exists(P2 => P2.Pro_Id == Proj.Pro_Id))
                    {
                        Console.WriteLine("project already exists");
                    }
                    else
                    {
                        Pro.Add(Proj);
                    }
                    break;
                case 2:
                    int c = 0;


                    foreach (Project item in Pro)
                    {
                        Console.WriteLine("Project: " + c);
                        Console.WriteLine("Project id:" + item.Pro_Id);
                        Console.WriteLine("Project Name:" + item.Name);
                        Console.WriteLine("start date:" + item.Start_Date);
                        Console.WriteLine("end date:" + item.End_Date);
                        Console.WriteLine("budget:" + item.Budget);
                        c++;
                    }
                    break;
                case 3:

                    Employee emp = new Employee();

                    Console.WriteLine("Enter employee ID");
                    emp.ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter employee Empname");
                    emp.EmpName = Console.ReadLine();
                    Console.WriteLine("Enter employee Contact");
                    emp.Contact = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter empoyee email");
                    emp.Email = Console.ReadLine();
                    Console.WriteLine("Enter employee Rol_eid");
                    emp.Role_id = Convert.ToInt32(Console.ReadLine());



                    if (emp2.Exists(emp3 => emp3.ID == emp.ID))
                    {
                        Console.WriteLine("employee already exists");
                    }
                    else
                    {
                        emp2.Add(emp);
                    }
                    break;
                case 4:
                    int i = 0;
                    foreach (Employee item in emp2)
                    {
                        Console.WriteLine("employee no: " + num);
                        Console.WriteLine("employee ID: " + item.ID);
                        Console.WriteLine("EmpName:" + item.EmpName);
                        Console.WriteLine("Contact:" + item.Contact);
                        Console.WriteLine("Email: " + item.Email);
                        Console.WriteLine("Role_id:" + item.Role_id);

                        i++;
                    }
                    break;
                case 5:
                    string[] role = new string[2];
                    Role rol = new Role();

                    Console.WriteLine("Enter Role ID");
                    rol.RoleID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Rolename");
                    rol.Rolename = Console.ReadLine();
                    if (Rol.Exists(Rol2 => Rol2.RoleID == rol.RoleID))
                    {
                        Console.WriteLine("Role already exists");
                    }
                    else
                    {
                        Rol.Add(rol);
                    }

                    break;
                case 6:
                    int count = 0;
                    foreach (Role item in Rol)
                    {
                        Console.WriteLine("Role no: " + count);

                        Console.WriteLine("roleid:" + item.RoleID);
                        Console.WriteLine("rolename:" + item.Rolename);

                        count++;
                    }
                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }

    }
}
}
*/
        
    

