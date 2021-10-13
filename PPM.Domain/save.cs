using Domain;
using PPM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace PPM.Domain
{
    public class save {
        // public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        

    public void Save() {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
            TextWriter Filestream = new StreamWriter(@"C:\Users\PRINCE\source\repos\employees.xml");
            xmlSerializer.Serialize(Filestream, EmployeeManager ._employeeList);
            Filestream.Close();
            XmlSerializer ProjectxmlSerializer = new XmlSerializer(typeof(List<Project>));
            TextWriter ProjectFilestream = new StreamWriter(@"C:\Users\PRINCE\source\repos\projectss.xml");
            ProjectxmlSerializer.Serialize(ProjectFilestream, ProjectManager._projectList);

            ProjectFilestream.Close();
            XmlSerializer RolexmlSerializer = new XmlSerializer(typeof(List<Role>));
            TextWriter RoleFilestream = new StreamWriter(@"C:\Users\PRINCE\source\repos\roles.xml");
            RolexmlSerializer.Serialize(RoleFilestream, o: RoleManager._roleList);

            RoleFilestream.Close();
        }

       
    }
}
