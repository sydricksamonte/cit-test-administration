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

public partial class active : System.Web.UI.MasterPage
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
                    Label6.Text = "S.Y. " + Reader["term"].ToString();

                }
                Reader.Close();
                Scon.Close();
            }
           
        }

      
     
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Page.Session["user"] = null;
        Response.Redirect("LogIn.aspx");
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
      ////  Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/StudSummary.aspx', null,'top=1,left=1,center=yes,resizable=no,Width=1024px,Height= 700px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

      Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/ExamsStud.aspx', null,'top=1,left=1,center=yes,resizable=no,Width=1024px,Height= 600px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/ExamsStud.aspx', null,'top=1,left=1,center=yes,fullscreen=1,resizable=no,Width=1024px,Height= 600px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

    }
    protected void @out(object sender, EventArgs e)
    {
        Page.Session["user"] = null;
        Response.Redirect("LogIn.aspx");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Page.Session["user"] = user;
        Response.Redirect("Home.aspx");
    }
    protected void LinkButton1_Click2(object sender, EventArgs e)
    {

    }
}
