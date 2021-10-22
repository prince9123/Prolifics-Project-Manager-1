using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PPM.Model;
namespace PPM.Domain
{
    public class RoleManager : IOperations<Role>
    {
        public static List<Role>_roleList = new List<Role>();
        public void AddRole()
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
            var resultRole = Add(ROLE);
            if (!resultRole.IsSuccess)
            {
                Console.WriteLine("Role failed to Add");
                Console.WriteLine(resultRole.Status);
            }
            else
            {
                Console.WriteLine(resultRole.Status);
            }
        }
        //public interface IOperations<T>
        //Add Result Add(T t)
               //ListById
        //Delete Result Remove(int id)
        public Result Add(Role ROLE)
            {
            Result result = new Result() { IsSuccess = true };

            try
            {
                _roleList.Add(ROLE);
                result.Status = "Role added";
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                result.IsSuccess = false;
            }
            return result;
            }
        public Data_Result<Role> ListAll()
        {
            Data_Result<Role> data = new Data_Result<Role> { IsSuccess = true };
            if (_roleList.Count > 0)
            {
                data.results = _roleList;
            }
            else
            {
                data.IsSuccess = false;
                data.Status = "List is Empty!";

            }
            return data;
        }
        public void DeleteRoleById()
        {
            RoleManager projectManager = new RoleManager();
            //Employee employee = new Employee();
            Console.WriteLine("Choose Role From Below Role List: Role ID:Role Name");
            var Resrole = ListAll();
            if (Resrole.IsSuccess)
            {
                foreach (Role res in Resrole.results)
                {
                    Console.WriteLine(res.RoleID + " : " + res.Rolename);
                }
            }
            else
            {
                Console.WriteLine(Resrole.Status);
            }
            Console.Write("Enter The Role Id wchich u want delete ");
            int RoleId = Convert.ToInt32(Console.ReadLine());
            var result = Remove(RoleId);
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
            Role role = new Role();
            Result action = new Result() { IsSuccess = true };
            try
            {
                if (_roleList.Exists(p => p.RoleID == id))
                {
                    var itemToRemove = _roleList.Single(s => s.RoleID == id);
                    _roleList.Remove(itemToRemove);
                    action.Status = "Project is Deleted Successfully " + role.RoleID;
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
        public Result ToXmlSerialization(string fileName)
        {
            Result actionResult = new Result() { IsSuccess = true };
            try
            {
                if (_roleList.Count > 0)
                {
                    //string filePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("F:\\PPM\\PPM.Model"), "AppData", fileName)
                    // var filePath = System.IO.File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + fileName)
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Role>));
                    using (TextWriter tw = new StreamWriter(fileName))
                    {
                        serializer.Serialize(tw, _roleList);
                        tw.Close();
                    }

                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Role list is Empty";
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
                if (_roleList.Count > 0)
                {
                    using (TextWriter sw = new StreamWriter(fileName))
                    {
                        foreach (Role r in _roleList)
                        {
                            sw.WriteLine("Role Id: " + r.RoleID + "\nRole Name: " + r.Rolename);
                            sw.WriteLine("--------------------------------------------------------------------------------------");
                            actionResult.Status = "Role Is Saved in The Text File!";
                        }
                    }
                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "Role list is empty!";
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
            string conn = "Server=(ESN0OA3)PRINCESQL; Database=model;Integrated security=true;TrustServerCertificate=true";
            SqlConnection myConn = new SqlConnection(conn);
            string str = "DROP TABLE IF EXISTS role";
            try
            {
                myConn.Open();
                using (SqlCommand command = new SqlCommand(str, myConn))
                {
                    command.ExecuteNonQuery();
                    actionResult.Status = "Old Data of Role Dropped Successfully!";
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
                    using (SqlCommand command = new SqlCommand("CREATE TABLE role (RoleId int,Rolename varchar(50));", myConn))
                    {
                        command.ExecuteNonQuery();

                        foreach (Role role in _roleList)
                        {
                            int id = (int)role.RoleID;
                            string insertQ = "INSERT INTO role values(@RoleId,@RoleName)";
                            SqlCommand command1 = new SqlCommand(insertQ, myConn);
                            command1.Parameters.AddWithValue("@RoleId", id);
                            command1.Parameters.AddWithValue("@Rolename", role.Rolename);
                            command1.ExecuteNonQuery();
                        }
                        actionResult.Status = actionResult.Status + "\n" + "Table role Added SuccessFully!";
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

    }
}