using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace dal
{
    public class DALClass
    {
        string coString =
             @"Data Source=.\sqlexpress;Database=myDB;Trusted_Connection=True;";
        SqlConnection con = new SqlConnection();
        public DataTable dt = new DataTable();

        public SqlDataReader ReadBooks(string filter)
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Book", con);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Book JOIN AuthorBook ON AuthorBook.BookId=Book.Id", con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Book JOIN Author ON Author.Id IN (SELECT AuthorId FROM AuthorBook WHERE BookId=Book.Id) WHERE Available LIKE @Filter ", con);
            cmd.Parameters.AddWithValue("@Filter", filter);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                return rd;
                //dt.Load(rd);
                //return dt;
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ReadHistory(string BName,string UName)
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            if (BName == "") BName = "%";
            if (UName == "") UName = "%";
            //SqlCommand cmd = new SqlCommand("SELECT History.Id,[User].UName,Book.Name,History.Date,History.[Return] FROM History,[User],Book WHERE [User].Id=History.UserId ( Book.Id=History.BookId", con);
            SqlCommand cmd = new SqlCommand("SELECT History.Id,Book.Name,[User].UName,History.[Return],History.[Date] FROM History JOIN Book ON History.BookId=Book.Id JOIN [User] ON History.UserId=[User].Id WHERE Book.Name LIKE @BName AND [User].UName LIKE @UName", con);
            cmd.Parameters.AddWithValue("@BName", BName);
            cmd.Parameters.AddWithValue("@UName", UName);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                return rd;
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ReadUsers()
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User]", con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                return rd;
            }
            catch
            {
                throw;
            }

        }
        public SqlDataReader ReadAuhtorsOfBook(int id)
        {
            //con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Author.Name FROM Author WHERE Auhtor.Id IN (SELECT AuhtorId From AuthorBook WHERE BookId=" + id + ")", con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                return rd;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadBookByID(int id)
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Book.Id,Book.Name,Book.Available,Author.Name FROM Book,Author WHERE Book.Id=" + id + " AND Author.Id IN (SELECT AuthorID FROM BookAuthor WHERE BookID=" + id + " )", con);

            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadAuthors()
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Author", con);

            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public void AddUser(string name,string email)
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [User] ([UName],[Email]) VALUES (@name,@email)",con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
        }
        public SqlDataReader BorrowBook(int BookId, int UserId)
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd1 = new SqlCommand("UPDATE Book SET Available=0 WHERE Id=@BookId", con);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO History (UserId,BookId) VALUES (@UserId,@BookId)", con);
            SqlCommand cmd3 = new SqlCommand("SELECT Book.Name,[User].UName,[User].Email FROM Book JOIN [User] ON @UserId=[User].Id WHERE Book.Id=@BookId", con);
            cmd1.Parameters.AddWithValue("@BookId", BookId);
            cmd2.Parameters.AddWithValue("@BookId", BookId);
            cmd2.Parameters.AddWithValue("@UserId", UserId);
            cmd3.Parameters.AddWithValue("@BookId", BookId);
            cmd3.Parameters.AddWithValue("@UserId", UserId);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            try
            {
                SqlDataReader rd = cmd3.ExecuteReader();
                return rd;
            }
            catch
            {
                throw;
            }      
        }
        public void ReturnBook(int BookId)
        {
            con.ConnectionString = coString;
            if (ConnectionState.Closed == con.State) con.Open();
            SqlCommand cmd1 = new SqlCommand("UPDATE Book SET Available=1 WHERE Id=@BookId", con);
            SqlCommand cmd2 = new SqlCommand("UPDATE History SET [Return]=1 WHERE BookId=@BookId", con);
            cmd1.Parameters.AddWithValue("@BookId", BookId);
            cmd2.Parameters.AddWithValue("@BookId", BookId);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
        }
    }
}
