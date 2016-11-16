using EmployeeDataAccess;
using System;
using System.Linq;

namespace DemoWebApi
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            }
        }
    }
}