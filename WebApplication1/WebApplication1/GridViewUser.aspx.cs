using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bal;
using System.Data;

namespace WebApplication1
{
    public partial class GridViewUser : System.Web.UI.Page
    {
        public List<User> users = BooksDataAccessLayer.GetAllUsers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["sortOrder"] = "";
                UpdateData();
            }
        }

        protected void BtAddPeople(object sender,EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                BooksDataAccessLayer.AddUser(tbName.Text, tbEmail.Text);
            }
            UpdateData();
        }

        public void UpdateData()
        {
            users = BooksDataAccessLayer.GetAllUsers();
            GridView1.DataSource = users;
            GridView1.DataBind();
        }
    }
}