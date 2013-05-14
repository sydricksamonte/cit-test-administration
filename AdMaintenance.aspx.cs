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

public partial class Home : System.Web.UI.Page
{

    string user; string term; string line = "";
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
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
            try
            {
                if (Page.Session["message"].ToString() != "")
                {
                    MessageBox(Page.Session["message"].ToString());
                }
                else
                { }
              
                Page.Session["message"] = "";

            }
            catch { }

            StreamReader sr44 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr44.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource1.ConnectionString = sConnection2;
           
            //    SqlDataSource6.ConnectionString = sConnection2;
          

        }
    
    }
    public void checkUser()
    {
        {
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select type From user_table WHERE user_id = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                string type = Reader["type"].ToString();
                if (type == "STUDENT")
                {
                    Response.Redirect("LogIn.aspx");
                    break;
                }
            }
            Reader.Close();
            Scon.Close();

        }
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
       
    }
    protected void ins(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        {
            //SqlConnection Scon2;
            //SqlDataReader Reader2;
            //SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
            //string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //string sql2;
            //sql2 = " DELETE FROM course_bulk where course = '" + exname + "'";
            //Scon2 = new SqlConnection(sConnection2);
            //Scon2.Open();
            //Cmd2 = new SqlCommand(sql2, Scon2);
            //Reader2 = Cmd2.ExecuteReader();
        }
        Label14.Text = "Assigned course to faculty has been deleted."; 
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdCourses.aspx");
       
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
     
    }
}
