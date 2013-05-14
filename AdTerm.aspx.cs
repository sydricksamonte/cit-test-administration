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
            checkUser();
            Label17.Visible = false;
            viewTerm();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    private void viewTerm()
    {
        {
         
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From term";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
               Label4.Text = Reader["term"].ToString();
            }
            Reader.Close();
            Scon.Close();

        }
    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void ins(object sender, EventArgs e)
    {
        term = TextBox9.Text.Trim() + "-" + TextBox1.Text + "/" + DropDownList1.Text.ToUpper();

          //try
        {
            if (TextBox9.Text.Length < 4)
            {
                MessageBox("Invalid year");
              //  Label17.Text = "";
             //   Label17.Visible = true;
            }
            //else if (TextBox2.Text.Length < 2)
            //{
            //    Label17.Text = "Invalid term";
            //    Label17.Visible = true;
            //}
            else if (TextBox1.Text.Length < 4)
            {
                MessageBox("Invalid year");
              //  Label17.Visible = true;
            }
            else
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
                    sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Changed the term from " + Label4.Text + " to " + TextBox9.Text + "-" + TextBox1.Text + "/" + DropDownList1.Text + "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();
                    Reader6.Close();
                    Scon6.Close();

                }
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; 
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  
                    line = sr.ReadLine();
                    string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "dELETE FROM term WHERE term LIKE '" + "2%" + "'";

                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                }

                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Insert Into term VAlUES('" + term + "','" + term + "')";

                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                   
                    TextBox1.Text = "";
                    //TextBox2.Text = "";
                    TextBox9.Text = "";
                    TextBox9.Focus();
                  MessageBox("The term has been changed");
                    viewTerm();
                }

            }
        }

        //catch
        //{
        //    Label17.Text = "A faculty member with the assigned course and section already exists.";
        //    Label17.Visible = true;
        //}



    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
  
    }
    int year2=0;
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
       // try{
       //     TextBox9.Text=ye
       //TextBox1.tex
    }
}
