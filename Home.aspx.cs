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
    string user; string line = ""; string secret = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
            secret = Page.Session["secret"].ToString();
            Label8.Text = user;
            {
                StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr66.ReadLine();
                SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
               
                
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From classlist WHERE stud_id = '" + user + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    Label10.Text = (Reader["stud_name"].ToString().ToUpper());
                    Label11.Text = (Reader["stud_id"].ToString().ToUpper());
                    break;
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
            Label txtAE = (Label)row.FindControl("Label1");
            Label txtStat = (Label)row.FindControl("Label4");
            Button takeH = (Button)row.FindControl("Button1");
            ImageButton txtB = (ImageButton)row.FindControl("ImageButton1");
            HiddenField txtC = (HiddenField)row.FindControl("HiddenField1");
            {
               
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Select * From exam_results WHERE d_close = '" + "NOT TAKEN" + "' AND user_id='"+user+"' AND exam_code='"+txtC.Value.ToString()+"'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        if (txtC.Value == Reader2["exam_code"].ToString())
                        {
                            txtStat.Text = "UNAVAILABLE";
                        }
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;
                        StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr3.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Select * From exams WHERE pass = '" + secret + "' AND exname='"+Reader2["exam_code"].ToString()+"'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();

                        while (Reader.Read())
                        {
                            txtStat.Text = "NOT TAKEN";
                        }

                        Reader.Close();
                        Scon.Close();


                    }
                    Reader2.Close();
                    Scon2.Close();
                   
                    
             

            }
            if (txtStat.Text == "NOT TAKEN")
            {
                //  takeH.Visible = true;
            }
            else if (txtStat.Text.Contains("PROGRESS"))
            {
                //   takeH.Visible = true;
            }
            else
            {
                //    takeH.Visible = false;
            }
            if (txtAE.Text.Contains("EXAM"))
            {
                txtB.ImageUrl = "~/Images/type_exam.png";
            }
            if (txtAE.Text.Contains("SEAT"))
            {
                txtB.ImageUrl = "~/Images/t_seatwork.png";
            }
            if (txtAE.Text.Contains("EXAM_F"))
            {
                txtB.ImageUrl = "~/Images/t_f.png";
            }
            if (txtAE.Text.Contains("QUIZ"))
            {
                txtB.ImageUrl = "~/Images/type_quiz.png";
            }
            if (txtStat.Text == "UNAVAILABLE")
            {
                txtB.ImageUrl = "~/Images/t_unavailable.png";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/ExamsStud.aspx', null,'top=1,left=1,center=yes,resizable=no,Width=1024px,Height= 700px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
