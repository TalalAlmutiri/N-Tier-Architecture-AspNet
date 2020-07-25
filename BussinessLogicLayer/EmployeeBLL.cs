using BussinesObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer
{
   public class EmployeeBLL
    {
        public static IEnumerable<Employee> GetAllEmployee()
        {
            return (EmployeeDAL.GetAllEmployee());
        }

        public static Employee GetEmployee(int Id)
        {
            return (EmployeeDAL.GetEmployee(Id));
        }
        public static bool Add(string FirstName,string LastName,int Age,int CountryID)
        {
            Employee emp = new Employee();
            emp.FirstName = FirstName;
            emp.LastName = LastName;
            emp.Age = Age;
            emp.CountryID = CountryID;
            return (EmployeeDAL.Add(emp));
        }

        public static bool Update(int EmpID, string FirstName, string LastName, int Age, int CountryID)
        {
            Employee emp = new Employee();
            emp.EmpID = EmpID;
            emp.FirstName = FirstName;
            emp.LastName = LastName;
            emp.Age = Age;
            emp.CountryID = CountryID;
            return (EmployeeDAL.Update(emp));
        }
        public static bool Delete(int Id)
        {
            return (EmployeeDAL.Delete(Id));
        }
    }
}
