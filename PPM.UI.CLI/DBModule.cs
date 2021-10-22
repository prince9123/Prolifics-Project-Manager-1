using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PPM.Domain;
using Domain;

namespace PPM.UI.CLI
{
    public class DBModule
    {
        public void DB_ADO()
        {
            static String GetTimestamp(DateTime value)
            {
                return value.ToString("yyyy/MM/dd/HH:mm:ss:dffff");
            }
            String timeStamp = GetTimestamp(DateTime.Now);
            Console.WriteLine(timeStamp);

            EmployeeManager employeeManager = new EmployeeManager();
            ProjectManager projectManager = new ProjectManager();
            RoleManager roleManager = new RoleManager();
            var saveRoleToDB = roleManager.ToAdoDB();
            var saveEmployee = employeeManager.ToAdoDB();
            var saveProject = projectManager.ToAdoDB();
            if (saveRoleToDB.IsSuccess || saveEmployee.IsSuccess || saveProject.IsSuccess)
            {
                Console.WriteLine(saveRoleToDB.Status + "\n" + saveEmployee.Status + "\n" + saveProject.Status);
                Console.WriteLine("Saved To Database Successfully!");

            }
            else
            {
                Console.WriteLine(saveRoleToDB.Status);
            }

        }
        
    }
}


