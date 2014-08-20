using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dal;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace bal
{

    public class BooksDataAccessLayer
    {
        public static List<Book> GetAllBooks(string filter)
        {
            List<Book> listBooks = new List<Book>();
            DALClass dt = new DALClass();
            SqlDataReader rdr = dt.ReadBooks(filter);
            while (rdr.Read())
            {
                Book book = new Book();
                book.id = Convert.ToInt32(rdr["Id"]);
                book.name = rdr["Name"].ToString();
                book.available = Convert.ToInt32(rdr["Available"]);
                book.authors = rdr["AName"].ToString();
                listBooks.Add(book);
            }
            return listBooks;
        }

        public static List<User> GetAllUsers()
        {
            List<User> listUsers = new List<User>();
            DALClass dt = new DALClass();
            SqlDataReader rdr = dt.ReadUsers();
            while (rdr.Read())
            {
                User user = new User();
                user.id = Convert.ToInt32(rdr["Id"]);
                user.name = rdr["UName"].ToString();
                user.email = rdr["Email"].ToString();
                listUsers.Add(user);
            }
            return listUsers;
        }

        public static void AddUser(string name,string email)
        {
            DALClass dt = new DALClass();
            dt.AddUser(name, email);
        }

        public static List<History> GetHistory(string  BName,string UName)
        {
            List<History> listHistory = new List<History>();
            DALClass dt = new DALClass();
            SqlDataReader rdr = dt.ReadHistory(BName,UName);
            while (rdr.Read())
            {
                History record = new History();
                record.id = Convert.ToInt32(rdr["Id"]);
                record.bname = rdr["Name"].ToString();
                record.uname = rdr["UName"].ToString();
                record.date = Convert.ToDateTime(rdr["Date"]);
                record.returned = Convert.ToInt32(rdr["Return"]);
                listHistory.Add(record);
            }
            return listHistory;
        }

        public static void BorrowBook(int BookId, int UserId)
        {
            DALClass dt = new DALClass();
            SqlDataReader rdr = dt.BorrowBook(BookId, UserId);
            while (rdr.Read())
            {
                SendMail(rdr["Name"].ToString(), rdr["UName"].ToString(), rdr["Email"].ToString());
            }

        }

        public static void ReturnBook(int BookId)
        {
            DALClass dt = new DALClass();
            dt.ReturnBook(BookId);
        }
        public static void SendMail(string bookName, string userName, string email)
        {
            string mailFrom = "test_csharp@mail.ru";
            string mailTo = email;
            string mailSubject = "Test Message from Library";
            string mailBody =System.String.Format( "Good day {0}. You have borrowed the book. It's name is {1}.", userName, bookName);
            string mailSmtp = "smtp.inbox.ru";
            int mailPort = 25;
            string mailLogin = mailFrom;
            string mailPassword = "asdASD";

            MailMessage mail = new MailMessage(mailFrom, mailTo, mailSubject, mailBody);
            SmtpClient client = new SmtpClient(mailSmtp, mailPort);
            client.Credentials = new NetworkCredential(mailLogin, mailPassword);
            client.Send(mail);
        }
    }
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public int available { get; set; }
        public string authors { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class History
    {
        public int id { get; set; }
        public string bname { get; set; }
        public string uname { get; set; }
        public DateTime date { get; set; }
        public int returned { get; set; }
    }
}

