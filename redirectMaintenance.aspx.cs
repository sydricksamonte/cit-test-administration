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
using System.Data.SqlClient; using System.IO;

public partial class redirectMaintenance : System.Web.UI.Page
{
    string user; string line = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
            checkUser();
        }
    }
    public void checkUser()
    {
        {
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select type From user_table WHERE user_id = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                string type = Reader["type"].ToString();
                if ((type == "ADMIN"))
                {
                    Response.Redirect("AdMaintenance.aspx");
                    break;
                }
                else
                {
                 
                    break;
                }
            }
            Reader.Close();
            Scon.Close();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        {
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select type From user_table WHERE user_id = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                string type = Reader["type"].ToString();
                if ((type == "STUDENT"))
                {
                    Page.Session["user"] = null;
                    Response.Redirect("LogIn.aspx");
                    break;
                }
                else
                {
                    Page.Session["user"] = user;
                    Response.Redirect("InsHome.aspx");
                    break;
                }
            }
            Reader.Close();
            Scon.Close();

        }
       
    }
}
