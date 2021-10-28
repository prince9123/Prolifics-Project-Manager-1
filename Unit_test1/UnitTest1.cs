using System;
using NUnit.Framework;
using PPM.Model;
using PPM.Domain;
using Domain;
using PPM.UI.CLI;

namespace Unit_test1
{
    public class Tests
    {

        [Test]
        public void AddProjectTest1()
        {
            ProjectManager Pro = new ProjectManager();
            Project P1 = new Project();
            P1.ProjecID = 1;
            P1.Name = "Prince";
            P1.Start_Date = Convert.ToDateTime("1-3-2021");
            P1.End_Date = Convert.ToDateTime("3-3-2021");
            P1.Budget = 2000;
            var V2 = Pro.Add(P1); 
            if (V2.IsSuccess)
            {
                Assert.Pass();

            }
            else
            {
                Assert.Fail();

            }



        }


        [Test]
        public void AddEmployeeTest1()
        {
            EmployeeManager Emo = new EmployeeManager();
            Employee E1 = new Employee();
            E1.ID = 2;
            E1.EmpName = "ps";
            E1.Contact = 9123446828;
            E1.Email = "prince.kumar@prolifics.com";
            E1.Role_id = 20;
            var V3 = Emo.Add(E1);
            if (V3.IsSuccess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void AddRoleTest1()
        {
            RoleManager role = new RoleManager();
            Role RR = new Role();
            RR.RoleID = 2;
            RR.Rolename = "SD-1";
            var v4 = role.Add(RR);
            if (v4.IsSuccess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void AddEmployeetoProjectTest2()
        {
            Employee emp = new Employee();
            EmployeeManager em = new EmployeeManager();
            int Pro_Id = 1;
            emp.EmpName = "ps";
            var v1 = em.IsvalidEmp(emp);
            if (!v1.IsSuccess)
            {
                ProjectManager projectManager = new ProjectManager();
                var r1 = projectManager.AddEmployeetoProject(emp, Pro_Id);
                if (!r1.IsSuccess)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
        [Test]
        public void DELETE_employeefromProj()
        {
            Employee emp = new Employee();
            EmployeeManager em = new EmployeeManager();
            int Pro_Id = 1;
            emp.EmpName = "ps";
            var v1 = em.IsvalidEmp(emp);
            if (!v1.IsSuccess)
            {
                ProjectManager projectManager = new ProjectManager();
                var r1 = projectManager.AddEmployeetoProject(emp, Pro_Id);
                if (!r1.IsSuccess)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    } 
}