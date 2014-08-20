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
    public partial class GridViewHistory : System.Web.UI.Page
    {
        public List<History> history;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateData();
            }
        }

        public void UpdateData()
        {
            history = bal.BooksDataAccessLayer.GetHistory(tbBName.Text,tbUName.Text);
            GridView1.DataSource = history;
            GridView1.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            UpdateData();
        }


        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            bal.BooksDataAccessLayer.ReturnBook(Convert.ToInt32(tbReturnId.Text));
            UpdateData();
        }

        protected void BorrowBtn_Click(object sender, EventArgs e)
        {
            bal.BooksDataAccessLayer.BorrowBook(Convert.ToInt32(tbBookId.Text), Convert.ToInt32(tbUserId.Text));
            UpdateData();
        }
    }
}