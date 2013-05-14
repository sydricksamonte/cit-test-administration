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

public partial class Images_AdUsers : System.Web.UI.Page
{
    string user; string term; string line = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
   
        }
    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }



    protected void Button1_Click1(object sender, EventArgs e)
    {if (RadioButton3.Checked==true)
        {
            SqlConnection Scon;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE dbSettings SET type ='" + "1" + "' WHERE dbData = '" + "db"+ "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Cmd.ExecuteNonQuery();
            Scon.Close();

        }
        else if (RadioButton2.Checked == true)
        {
            SqlConnection Scon;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE dbSettings SET type ='" + "2" + "' WHERE dbData = '" + "db" + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Cmd.ExecuteNonQuery();
            Scon.Close();

        }
        else
        { }
    }
}
