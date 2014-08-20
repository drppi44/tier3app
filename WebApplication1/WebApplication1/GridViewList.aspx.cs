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
    public partial class GridViewList : System.Web.UI.Page
    {
        public List<Book> books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["sortOrder"] = "";
                UpdateData();
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            /*if (e.SortExpression == "name")
            {
                books = books.OrderBy(x => x.name).ToList();
            }*/
            UpdateData(e.SortExpression);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            UpdateData();
        }

        public string sorOrder
        {
            get
            {
                if (ViewState["sortOrder"].ToString() == "desc")
                {
                    ViewState["sortOrder"] = "asc";
                }
                else
                {
                    ViewState["sortOrder"] = "asc";
                }
                return ViewState["sortOrder"].ToString();
            }
            set
            {
                ViewState["sortOrder"] = value;
            }
        }

        public void UpdateData()
        {
            books = bal.BooksDataAccessLayer.GetAllBooks(BookFilter.SelectedValue.ToString());
            GridView1.DataSource = books;
            GridView1.DataBind();
        }

        public void UpdateData(string order)
        {
            books = bal.BooksDataAccessLayer.GetAllBooks(BookFilter.SelectedValue.ToString());
            switch (order)
            {
                case "name":
                    books = books.OrderBy(x => x.name).ToList();
                    break;
                case "authors":
                    books = books.OrderBy(x => x.authors).ToList();
                    break;
                case "id":
                    books = books.OrderBy(x => x.id).ToList();
                    break;
                case "available":
                    books = books.OrderBy(x => x.available).ToList();
                    break;
                default:
                    books = books.OrderBy(x => x.id).ToList();
                    break;
            }
            GridView1.DataSource = books;
            GridView1.DataBind();
        }


        protected void Update_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

    }
}