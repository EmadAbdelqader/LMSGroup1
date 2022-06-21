using LMGroup1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMSGroup1.BAL
{
    public class UsersBO
    {
        #region Private Variables

        /// <summary>
        /// The database context object
        /// </summary>
        private LMSDbContext dc;

        #endregion

        #region Constructors

        /// <summary>
        /// The main constructor
        /// </summary>
        public UsersBO()
        {
            dc = new LMSDbContext();
        }

        #endregion

        #region Get Methods

        public List<User> GetUsers()
        {
            // SELECT * FROM Users;
            return dc.Users.ToList();
        }

        public User GetUserById(int userId) // 2
        {
            // SELECT TOP(1) * FROM Users WHERE userId = @userId
            return dc.Users.Where(user => user.UserId == userId).FirstOrDefault();

            // SELECT * FROM Users WHERE userId = @userId
            //return dc.Users.SingleOrDefault(user=> user.UserId == userId);
        }

        public List<User> GetUsersByLevel(int userLevel)
        {
            return dc.Users.Where(u => u.UserLevel == userLevel).ToList();
        }

        public List<FullNameView> GetFullNames()
        {
            return (
                from u in dc.Users
                select new FullNameView()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    FullName = $"{u.FirstName} {u.LastName}"
                }).ToList();
        }

        #endregion

        #region Insert Methods

        public int Save(User _user)
        {
            bool isInsert = false;
            User newUser = dc.Users.Where(u => u.UserId == _user.UserId).FirstOrDefault();

            if (newUser == null)
            {
                newUser = new User();
                newUser.CreatedOn = DateTime.Now;
                newUser.CreatedBy = 2;
                isInsert = true;
            }
            else
            {
                newUser.UpdatedOn = DateTime.Now;
                newUser.UpdatedBy = 2;
            }

            newUser.FirstName = _user.FirstName;
            newUser.LastName = _user.LastName;
            newUser.Username = _user.Username;


            if (isInsert == true)
                dc.Users.InsertOnSubmit(newUser);

            dc.SubmitChanges();

            return newUser.UserId;
        }

        #endregion

        #region Delete Methods

        public void Delete(int userId) // 3
        {
            // SELECT * FROM Users WHERE userId = 3
            User delUser = dc.Users.Where(u => u.UserId == userId).FirstOrDefault();

            if (delUser == null) return;

            dc.Users.DeleteOnSubmit(delUser);
            dc.SubmitChanges();
        }

        public void FakeDelete(int userId)
        {
            // Trying to find a user by its user Id
            User delUser = dc.Users.Where(u => u.UserId == userId).FirstOrDefault();

            // Check the user existance
            if(delUser == null) return;

            // Update the IsDeleted column
            delUser.IsDeleted = true;

            // Submit the changes
            dc.SubmitChanges();

        }


        #endregion

    }

    

    public class FullNameView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}