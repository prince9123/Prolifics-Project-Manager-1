using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Model
{
   public class Project
    {
        public int Pro_Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public decimal Budget { get; set; }
        public string EmpName { get; set; }
        public List<Employee> EmpList;
    }
}
