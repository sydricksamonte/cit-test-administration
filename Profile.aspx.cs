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

public partial class _Default : System.Web.UI.Page
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
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From user_table WHERE user_id = '" + user + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();
           
            while (Reader.Read())
            {
                lblStudname.Text = Reader["lname"].ToString() +", "+Reader["fname"].ToString()+" ("+ Reader["bname"].ToString()+")";
                lblProg.Text = Reader["prog"].ToString();
                lblStudnum.Text = Reader["user_id"].ToString();

            }
            Reader.Close();
            Scon.Close();
    
            
        }
       
    }
}
