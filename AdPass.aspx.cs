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


public partial class Settings : System.Web.UI.Page
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
            if (Page.Session["user"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                user = Page.Session["user"].ToString();

                {
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
                        if (type == "STUDENT")
                        {
                            Panel3.Visible = false;
                            Response.Redirect("LogIn.aspx");
                            break;
                        }
                        else if (type == "FACULTY")
                        {
                            Panel3.Visible = false;
                            break;
                        }
                        else if (type == "ADMIN")
                        {
                            Panel3.Visible = true;
                            break;
                        }
                    }
                    Reader.Close();
                    Scon.Close();

                }
            }
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Page.Session["user"] = user;
        Response.Redirect("redirectMaintenance.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        if (NewPassword.Text.Length > 6)
        {
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select type From user_table WHERE user_id = '" + user + "'AND pass = '" + CurrentPassword.Text + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                //Label6.Visible = true;
              MessageBox("Incorrect current password, password was not changed");
                CurrentPassword.Focus();
                while (Reader.Read())
                {
                    {
                        SqlConnection Scon2;
                        SqlCommand Cmd2;
                        StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr2.ReadLine();
                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql2;
                        sql2 = "UPDATE  user_table SET pass ='" + NewPassword.Text.Trim() + "' WHERE user_id = '" + user + "'";
                        Scon2 = new SqlConnection(sConnection2);
                        Scon2.Open();
                        Cmd2 = new SqlCommand(sql2, Scon2);
                        Cmd2.ExecuteNonQuery();
                        Scon2.Close();
                        Label6.Visible = true;
                      MessageBox( "Password successfully changed");
                        Label6.Focus();
                    }

                }
                Reader.Close();
                Scon.Close();

            }
        }
        else
        {
          //  Label6.Visible = true;
           MessageBox( "Password should be atleast 7 characters.");
            
            CurrentPassword.Focus();
        }
      

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}
