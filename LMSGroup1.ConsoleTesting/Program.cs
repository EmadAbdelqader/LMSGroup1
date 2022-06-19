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

            usersBo.FakeDelete(2);

            Get();
        }

        public static void Get()
        {
            string connectionString = "data source=.; database=LMDB; Integrated Security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM LookUp ;";
                    //SqlDataReader reader = command.ExecuteReader();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["LookupDescription"]);
                        }
                    }
                }
            }
        }
    }
}
