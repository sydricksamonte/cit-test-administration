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

public partial class Images_AdUsers : System.Web.UI.Page
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
            checkUser();
            Label17.Visible = false;
            StreamReader sr44 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr44.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource1.ConnectionString = sConnection2;
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

        }
    }
    public void checkUser()
    {
        {
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; 
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
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
        bool allow = true;
        try
        {
            {
                Label userIds = (Label)GridView1.Controls[0].Controls[0].FindControl("Label15");

                DropDownList DropDownList2s = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList1");

                TextBox userId = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox9");
                TextBox userNa = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox1");
                TextBox pass = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox2");
                TextBox bn = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox8");
                TextBox ln = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox6");
                TextBox fn = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox7");
                TextBox email = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox3");
                DropDownList gen = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList2");

                {
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select type From user_table WHERE user_na = '" + userNa.Text + "' ";
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
                    if (allow == true)
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Insert Into user_table VAlUES('" + userId.Text.Trim().ToUpper() + "','" + userNa.Text.Trim() + "','" + pass.Text.Trim() + "','" + DropDownList1.SelectedValue.ToString().ToUpper() + "','" + bn.Text.Trim().ToUpper() + "','" + ln.Text.Trim().ToUpper() + "','" + fn.Text.Trim().ToUpper() + "','" + email.Text.Trim().ToUpper() + "','" + gen.SelectedValue.ToString() + "','" + DropDownList2s.SelectedValue.ToString() + "')";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();
                        GridView1.DataBind();
                    }
                    else
                    {
                        userIds.Text = "Username already exists.";
                    }
                }
                catch
                {
                    userIds.Text = "Userid already exists.";
                }
            }
        }
        catch
        {

        }
    }
    protected void ins(object sender, EventArgs e)
    {
        bool allow = true;
        try
        {
            {
               
                {
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
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
                    if (TextBox1.Text.Length < 6)
                    {
                        Label17.Text = "Username must be at least 7 characters long";
                        Label17.Visible = true;
                    }
                    else
                    {
                        if (allow == true)
                        {
                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Insert Into user_table VAlUES('" + TextBox9.Text.Trim().ToUpper() + "','" + TextBox1.Text.Trim() + "','" + TextBox2.Text.Trim() + "','" + DropDownList6.SelectedValue.ToString().ToUpper() + "','" + TextBox8.Text.Trim().ToUpper() + "','" + TextBox6.Text.Trim().ToUpper() + "','" + TextBox7.Text.Trim().ToUpper() + "','" + TextBox3.Text.Trim().ToUpper() + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList3.SelectedValue.ToString() + "')";

                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();
                            GridView1.DataBind();
                            TextBox9.Text = "";
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            TextBox8.Text = "";
                            TextBox6.Text = "";
                            TextBox7.Text = "";
                            TextBox3.Text = "";

                            TextBox9.Focus();
                        }
                        else
                        {
                            Label17.Text = "Username already exists.";
                            Label17.Visible = true;
                        }
                    }
                }
                catch
                {
                    Label17.Text = "Userid already exists.";
                    Label17.Visible = true;
                }
            }
        }
        catch
        {

        }
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((DropDownList6.SelectedIndex == 1) || (DropDownList6.SelectedIndex == 2))
        {
            DropDownList3.SelectedIndex = -1;
            DropDownList3.Visible = false;
            Label12.Visible = false;
        }
        else
        {
            {
                DropDownList3.SelectedIndex = 0;
                DropDownList3.Visible = true;
                Label12.Visible = true;
            }
        }
        DropDownList6.Focus();
       
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUser1.aspx");
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}
