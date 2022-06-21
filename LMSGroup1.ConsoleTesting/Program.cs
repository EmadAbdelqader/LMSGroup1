using LMGroup1.DAL;
using LMSGroup1.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup1.ConsoleTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize the users business object
            UsersBO usersBo = new UsersBO();

            // Getting all users
            //var userlList = usersBo.GetUsers();

            //var user = usersBo.GetUserById(2);

            //var fullNames = usersBo.GetFullNames();

            // Get the users by userlevel

            //User usr = new User()
            //{
            //    UserId = 12,
            //    FirstName = "Emad",
            //    LastName = "Mahmoud",
            //    UserName = "sm234xxzz"
            //};

            //usersBo.Save(usr);
            string E = "Ahmad";

            usersBo.FakeDelete(2);
        }
    }
}
