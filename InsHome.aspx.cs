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
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

           StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine(); 
            SqlDataSource1.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; 
            SqlDataSource1.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
         
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; 
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
                line = sr2.ReadLine();
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select type From user_table WHERE user_id = '" + user+ "' ";
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
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();

                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From term ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                  Page.Session["term"] =Reader["term"].ToString();
                  
                }
                Reader.Close();
                Scon.Close();
            }
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
           // Label txtAE = (Label)row.FindControl("Label1");
            Label txtStat = (Label)row.FindControl("Label3");
            Button takeH = (Button)row.FindControl("Button1");
            Button takeHO = (Button)row.FindControl("Button2");
            ImageButton txtB = (ImageButton)row.FindControl("ImageButton1");
             HiddenField txtAE = (HiddenField)row.FindControl("HiddenField1");


            if (txtAE.Value.ToString().Contains("EXAM"))
            {
                txtB.ImageUrl = "~/Images/type_exam.png";
                
            }
            if (txtAE.Value.ToString().Contains("SEAT"))
            {
                txtB.ImageUrl = "~/Images/t_seatwork.png";
            }
            if (txtAE.Value.ToString().Contains("EXAM_F"))
            {
                txtB.ImageUrl = "~/Images/t_f.png";
            }
            if (txtAE.Value.ToString().Contains("QUIZ"))
            {
                txtB.ImageUrl = "~/Images/type_quiz.png";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label3.Text = GridView1.SelectedIndex.ToString();
   
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
        foreach (GridViewRow row in GridView1.Rows)
        {   Label txtStat = (Label)row.FindControl("Label3");
            HiddenField txtAE = (HiddenField)row.FindControl("HiddenField1");
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();

                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exam_period where exname = '" + txtAE.Value.ToString() + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {

                    txtStat.Text ="Access period: "+ Convert.ToDateTime(Reader["period1"].ToString()).ToShortDateString() + " " + Convert.ToDateTime(Reader["period1"].ToString()).ToShortTimeString() + " - " + Convert.ToDateTime(Reader["period2"].ToString()).ToShortDateString() + " " + Convert.ToDateTime(Reader["period2"].ToString()).ToShortTimeString();

                }
                Reader.Close();
                Scon.Close();
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Page.Session["user"] = user;
        
        Page.Session["exname"] = GridView1.SelectedDataKey[0].ToString();
        Response.Redirect("InsEditExam.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Session["user"] = user;
        Page.Session["exname"] = GridView1.SelectedDataKey[0].ToString();
        Response.Redirect("InsEditExam.aspx");
    }
}
