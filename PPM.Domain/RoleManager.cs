using System;
using System.Collections.Generic;
using System.Text;
using PPM.Model;
namespace PPM.Domain
{
    public class RoleManager
    {
        private static List<Role>_roleList = new List<Role>();
        public int RoleID;
        public string Rolename;

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
        public Data_Result<Role> GetRoleInfo()
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

        public void SubjectMenu()
        {
            throw new NotImplementedException();
        } 
    }
}