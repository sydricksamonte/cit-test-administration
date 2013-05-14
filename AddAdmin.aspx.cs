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

public partial class _Default : System.Web.UI.Page
{
    string line = ""; string type = ""; string user = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
          
            try
            {
              // type = Page.Session["type"].ToString();
               Label8.Text = "Update user";
               
              // type = "Admin";
               if (kagat == 2)
               {
                   redir();
               }
               if (Page.Session["core"].ToString() == "1")
               {
                   string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

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
                       TextBox6.Text = Reader["lname"].ToString();
                       TextBox7.Text = Reader["fname"].ToString();
                       TextBox8.Text = Reader["bname"].ToString();
                       TextBox9.Text = Reader["user_id"].ToString();
                       TextBox1.Text = Reader["user_na"].ToString();
                      // TextBox2.Text = Reader["pass"].ToString();
                       DropDownList2.Text = Reader["gender"].ToString();
                   }
                   Reader.Close();
                   Scon.Close();
                   Page.Session["core"] = "2";
               }
               Button2.Visible = true;
               Button1.Visible = false;
            }
            catch
            {
              
            }
        
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
        SqlConnection Scon;
        SqlDataReader Reader;
        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        string sql;
        sql = "UPDATE user_table SET user_id ='" + TextBox9.Text.Trim().ToUpper() + "',user_na= '" + TextBox1.Text.Trim() + "',pass='" + TextBox2.Text.Trim() + "',type='" + "Admin" + "',bname='" + TextBox8.Text.Trim().ToUpper() + "',lname='" + TextBox6.Text.Trim().ToUpper() + "',fname='" + TextBox7.Text.Trim().ToUpper() + "',gender='" + DropDownList2.Text + "' WHERE user_id = '" + user.Trim() + "'";
        // sql = "UPDATE dbSettings SET type ='" + "2" + "' WHERE dbData = '" + "db" + "'";
        Scon = new SqlConnection(sConnection);
        Scon.Open();
        Cmd = new SqlCommand(sql, Scon);
        Reader = Cmd.ExecuteReader();
        Reader.Close();
        Scon.Close();
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    int kagat = 0; bool allow = false;
    protected void insa(object sender, EventArgs e)
    {

        upde();
       if(allow==true)
        {

            Page.Session["core"] = "2";
            Response.Redirect("AdHome.aspx");
        }
      
        
    }
    private void upde()
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
            sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Updated account information [" + user + "] " + "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
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
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE user_table SET user_id ='" + TextBox9.Text.Trim().ToUpper() + "',user_na= '" + TextBox1.Text.Trim() + "',type='" + "Admin" + "',bname='" + TextBox8.Text.Trim().ToUpper() + "',lname='" + TextBox6.Text.Trim().ToUpper() + "',fname='" + TextBox7.Text.Trim().ToUpper() + "',gender='" + DropDownList2.Text + "' WHERE user_id = '" + user.Trim() + "'";
            // sql = "UPDATE dbSettings SET type ='" + "2" + "' WHERE dbData = '" + "db" + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();
            Reader.Close();
            Scon.Close();
            
          
      
            Page.Session["message"] = "Updated successfully";
           // MessageBox("The Update was successful.");
            for (int j = 0; j < 1000; j++)
            {
                if (j == 700)
                {
                    allow = true;
                    break;
                }
            }
          
          
        }
    }
    private void redir()
    {
       
        //   Page.Session["message"] = ";
       
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {

    }
}
