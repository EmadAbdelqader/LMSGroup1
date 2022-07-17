using LMSGroup1.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMSGroup1.Web.Users
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDefaultData();
            }
            FillData();
        }

        private void FillDefaultData()
        {
        }

        private void FillData()
        {
            UsersBO usersBo = new UsersBO();

            usersBo.UserId = txtUserID.Text == "" ? -1 : Convert.ToInt32(txtUserID.Text);
            usersBo.FirstName = txtFirstName.Text;
            usersBo.IsDeleted = Convert.ToInt32(ddlIsDeleted.SelectedValue);

            var users = usersBo.GetUsersBySearch();

            lvUsers.DataSource = users;
            lvUsers.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            FillData();
        }
    }
}