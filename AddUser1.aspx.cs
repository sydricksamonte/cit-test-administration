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

        if ((TextBox6.Text.Contains("`")) || (TextBox6.Text.Contains("^")) || (TextBox6.Text.Contains("<")) || (TextBox6.Text.Contains(">")) || (TextBox6.Text.Contains("#")) || (TextBox6.Text.Contains("{")) || (TextBox6.Text.Contains("}")) || (TextBox6.Text.Contains("*")))
        {
            MessageBox("Lastname contains characters that are invalid");
        }
        else if ((TextBox7.Text.Contains("`")) || (TextBox7.Text.Contains("^")) || (TextBox7.Text.Contains("<")) || (TextBox7.Text.Contains(">")) || (TextBox7.Text.Contains("#")) || (TextBox7.Text.Contains("{")) || (TextBox7.Text.Contains("}")) || (TextBox7.Text.Contains("*")))
        {
            MessageBox("First name contains characters that are invalid");
        }
        else if ((TextBox8.Text.Contains("`")) || (TextBox8.Text.Contains("^")) || (TextBox8.Text.Contains("<")) || (TextBox8.Text.Contains(">")) || (TextBox8.Text.Contains("#")) || (TextBox8.Text.Contains("{")) || (TextBox8.Text.Contains("}")) || (TextBox8.Text.Contains("*")))
        {
            MessageBox("Middle name contains characters that are invalid");
        }
        else if ((TextBox1.Text.Contains("`")) || (TextBox1.Text.Contains("^")) || (TextBox1.Text.Contains("<")) || (TextBox1.Text.Contains(">")) || (TextBox1.Text.Contains("#")) || (TextBox1.Text.Contains("{")) || (TextBox1.Text.Contains("}")) || (TextBox1.Text.Contains("*")))
        {
            MessageBox("Username contains characters that are invalid");
        }
        else if ((TextBox2.Text.Contains("`")) || (TextBox2.Text.Contains("^")) || (TextBox2.Text.Contains("<")) || (TextBox2.Text.Contains(">")) || (TextBox2.Text.Contains("#")) || (TextBox2.Text.Contains("{")) || (TextBox2.Text.Contains("}")) || (TextBox2.Text.Contains("*")))
        {
            MessageBox("Password contains characters that are invalid");
        }
           
        else
        {
            {
                bool allow = true;
                try
                {
                    {

                        {
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Select type From user_table WHERE user_na = '" + TextBox1.Text + "' ";
                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();

                            while (Reader.Read())
                            {
                                allow = false;
                            }
                            Reader.Close();
                            Scon.Close();

                        }
                        try
                        {
                            //if (TextBox1.Text.Length < 6)
                            //{
                            //    MessageBox("Username must be at least 7 characters long");
                            //    //     Label17.Visible = true;
                            //}
                            //else
                            {
                                if (allow == true)
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
                                        sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Added new faculty member [" + TextBox6.Text + " " + TextBox7.Text + "] " + "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
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
                                        sql = "Insert Into user_table VAlUES('" + TextBox9.Text.Trim().ToUpper() + "','" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "','" + DropDownList6.Text + "','" + TextBox8.Text.Trim().ToUpper() + "','" + TextBox6.Text.Trim().ToUpper() + "','" + TextBox7.Text.Trim().ToUpper() + "','" + "" + "','" + DropDownList2.SelectedValue.ToString() + "','" + TextBox6.Text.ToUpper().Trim() + ", " + TextBox7.Text.ToUpper().Trim() + " (" + TextBox8.Text.ToUpper().Trim() + ")" + "')";

                                        Scon = new SqlConnection(sConnection);
                                        Scon.Open();
                                        Cmd = new SqlCommand(sql, Scon);
                                        Reader = Cmd.ExecuteReader();
                                        Reader.Close();
                                        Scon.Close();
                                        TextBox9.Text = "";
                                        TextBox1.Text = "";
                                        TextBox2.Text = "";
                                        TextBox8.Text = "";
                                        TextBox6.Text = "";
                                        TextBox7.Text = "";
                                        TextBox3.Text = "";
                                        //   Label5.Visible = true;
                                        Page.Session["message"] = "User successfully added.";
                                        Response.Redirect("AdUsers.aspx");
                                    }

                                }
                                else
                                {
                                    MessageBox("Username already exists.");
                                    //  Label17.Visible = true;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox("Username already exists.");
                            Label17.Visible = true;
                        }
                    }
                }
                catch
                {

                }
            }
        }
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
    int kagat = 0;
    protected void insa(object sender, EventArgs e)
    {

        upde(); 
            if (kagat == 1)
            {
                MessageBox("The Update was successful."); redir();
            }

        
    }
    private void upde()
    {
        SqlConnection Scon;
        SqlDataReader Reader;
        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        string sql;
        sql = "UPDATE user_table SET user_id ='" + TextBox9.Text.Trim().ToUpper() + "',user_na= '" + TextBox1.Text.Trim() + "',pass='" + TextBox2.Text.Trim() + "',type='" + type + "',bname='" + TextBox8.Text.Trim().ToUpper() + "',lname='" + TextBox6.Text.Trim().ToUpper() + "',fname='" + TextBox7.Text.Trim().ToUpper() + "',gender='" + DropDownList2.Text + "' WHERE user_id = '" + user + "'";
        // sql = "UPDATE dbSettings SET type ='" + "2" + "' WHERE dbData = '" + "db" + "'";
        Scon = new SqlConnection(sConnection);
        Scon.Open();
        Cmd = new SqlCommand(sql, Scon);
        Reader = Cmd.ExecuteReader();
        Reader.Close();
        Scon.Close();
       
        Page.Session["type"] = null;
        kagat = 1;  
    }
    private void redir()
    {
       
        //   Page.Session["message"] = ";
     //   Response.Redirect("AdHome.aspx");
    }
}
