using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPM.Model;
namespace PPM.Domain
{
    public class RoleManager
    {
        private static List<Role>_roleList = new List<Role>();
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
            var resultRole = AddRole(ROLE);
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
            public Result AddRole(Role ROLE)
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
        public Data_Result<Role> GetAllRole()
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
            var Resrole = GetAllRole();
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
            Console.Write("Enter The project Id wchich u want delete ");
            int RoleId = Convert.ToInt32(Console.ReadLine());
            var result = RemoveProject(RoleId);
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Status);
            }
            else
            {
                Console.WriteLine(result.Status);
            }
        }
        public static Result RemoveProject(int id)
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

    }
}