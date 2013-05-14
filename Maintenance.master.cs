using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using System.IO;


public partial class Instructor : System.Web.UI.MasterPage
{
    string user; string line = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
        }
        else
        {
            user = Page.Session["user"].ToString();
            {
                SqlConnection Scon6;
                SqlDataReader Reader6;
                SqlCommand Cmd6;
                StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr6.ReadLine();
                string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql6;
                sql6 = "Select * From user_table WHERE user_id = '" + user + "'";
                Scon6 = new SqlConnection(sConnection6);
                Scon6.Open();
                Cmd6 = new SqlCommand(sql6, Scon6);
                Reader6 = Cmd6.ExecuteReader();

                while (Reader6.Read())
                {
                    Label9.Text = "Welcome " + ((Reader6["fname"].ToString()) + " " + (Reader6["lname"].ToString()) + " (" + (Reader6["type"].ToString()) + ")");
                    //   wroA = (int.Parse(Reader6["incor"].ToString()));
                    if (Reader6["type"].ToString() == "Program Chair")
                    {
                        Label3.Text = "Malayan Colleges Laguna";
                        LinkButton2.Visible = false;
                        LinkButton13.Visible = false;
                        LinkButton14.Visible = false;
                    }
                    else
                    {
                        LinkButton2.Visible = true;
                        Label3.Text = "Maintenance Pages";
                    }
                }
                Reader6.Close();
                Scon6.Close();
            }
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From term ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    Label2.Text ="S.Y. "+ Reader["term"].ToString();

                }
                Reader.Close();
                Scon.Close();
            }
        }

    }
    int awt=0;
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string logUser = "";
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From user_table WHERE user_id = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                logUser = Reader["prog"].ToString();

            }
            Reader.Close();
            Scon.Close();

        }
        {
            SqlConnection Scon6;
            SqlDataReader Reader6;
            SqlCommand Cmd6; StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr6.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql6;
            sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "The user logged-out" + "','" + logUser +"','" + System.DateTime.Now.ToString() + "')";
            Scon6 = new SqlConnection(sConnection6);
            Scon6.Open();
            Cmd6 = new SqlCommand(sql6, Scon6);
            Reader6 = Cmd6.ExecuteReader();
            Reader6.Close();
            Scon6.Close();
            awt = 1;
        }
        if (awt == 1)
        {
            Page.Session["user"] = null;
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {

    }
}
