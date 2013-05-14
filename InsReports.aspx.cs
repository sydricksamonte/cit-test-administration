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
    string line = ""; string user = ""; string exname = ""; string course = ""; string sec = ""; string rep = ""; string term = ""; string exam = "";
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
            {
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine(); SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource2.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource3.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource5.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource6.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource4.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

            }
            {
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
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select term From term ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    term = Reader["term"].ToString();
                    Page.Session["term"] = term;
                    Label4.Text = term;
                }
                Reader.Close();
                Scon.Close();

            }
            {
                string type = "";
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Select * From user_table WHERE user_id = '" + user + "'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        Label9.Text = "Welcome " + ((Reader6["fname"].ToString()) + " " + (Reader6["lname"].ToString()) + " (" + (Reader6["type"].ToString()) + ")");
                        //   wroA = (int.Parse(Reader6["incor"].ToString()));
                        type = Reader6["type"].ToString();


                    }
                    Reader6.Close();
                    Scon6.Close();
                }
                if (type.ToUpper() != "FACULTY")
                {
                    Page.Session["user"] = null;
                    Response.Redirect("LogIn.aspx");
                }
            }
        }
        DropDownList3.DataBind();
        DropDownList4.DataBind();
        refresher();

        try
        {
            if (Page.Session["message"] != "")
            {
                string kabum = Page.Session["message"].ToString();
                MessageBox(kabum);
                Page.Session["message"] = "";
            }
        }
        catch { }

    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exam_results WHERE pname = '" + DropDownList1.Text + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                course = Reader["course"].ToString();
                sec = Reader["section"].ToString();
                break;
            }
            Reader.Close();
            Scon.Close();
            Label20.Text = course;
        }
        //course = DropDownList2.SelectedValue.ToString();
        //  sec = DropDownList6.SelectedValue.ToString();
        exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());
        Page.Session["term"] = term;
        Page.Session["rep"] = "exam_a";
        Page.Session["user"] = user;
        Page.Session["exname"] = exam;
        Page.Session["course"] = course;
        Page.Session["section"] = sec;
        Response.Redirect("Crystal_Classlist.aspx");
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
   


    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
  //      course = DropDownList2.SelectedValue.ToString();
   //     sec = DropDownList6.SelectedValue.ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label8.Text = DropDownList1.SelectedValue.ToString();
            exam = ChangeToExamId(Label8.ToString());
            DropDownList1.Enabled = true;
            refresher();
        }
        catch { DropDownList1.Enabled = false; }
    }
    string typeoex = "";
    private string ChangeToExamId(string val)
    {

        SqlConnection Scon;
        SqlDataReader Reader;
        SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        string sql;
        sql = "Select * From exams WHERE pname = '" + val + "' ";
        Scon = new SqlConnection(sConnection);
        Scon.Open();
        Cmd = new SqlCommand(sql, Scon);
        Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            exam = Reader["exname"].ToString();
            
            Page.Session["exam"] = exam;
            
        }
        Reader.Close();
        Scon.Close();

        return exam;
    }
    public void refresher()
    {
        {

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exams WHERE pname = '" + DropDownList1.Text + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                typeoex = Reader["exname"].ToString();

             

            }
            Reader.Close();
            Scon.Close();

           
        }
        if ((DropDownList3.Items.Count != 0) && (DropDownList4.Items.Count != 0))
        {
            Button11.Enabled = true;
        }
        else
        {
            Button11.Enabled = false;
        }
        if (DropDownList1.Items.Count != 0)// && (DropDownList1.Items.Count != 0))
        {
            if (typeoex.Contains("EXAM"))
            {
            Button2.Enabled = true;
            Button5.Enabled = true;
            Button7.Enabled = false;
            }
            else
            {
                Button2.Enabled = false;
                Button5.Enabled = false;
                 Button7.Enabled = true;
            }
        }
        else
        {
            Button2.Enabled = false;
            Button7.Enabled = false;
            Button5.Enabled = false;
        }
        if ((DropDownList5.Items.Count != 0) && (DropDownList7.Items.Count != 0) && (DropDownList8.Items.Count != 0))
        {
            Button9.Enabled = true;
            Button14.Enabled = true;
            Button12.Enabled = true;
            Button13.Enabled = true;
        }
        else
        {
            Button9.Enabled = false;
            Button14.Enabled = false;
            Button12.Enabled = false;
            Button13.Enabled = false;
            
        }
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exam_results WHERE pname = '" + DropDownList1.Text + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                sec = Reader["section"].ToString();
                course = Reader["course"].ToString();
                break;
            }
            Reader.Close();
            Scon.Close();

        }

        //course = DropDownList2.SelectedValue.ToString();
     //   sec = DropDownList6.SelectedValue.ToString();
        exam =ChangeToExamId(DropDownList1.SelectedValue.ToString());
        Page.Session["term"] = term;
        Page.Session["rep"] = "exam_b";
        Page.Session["user"] = user;
        Page.Session["exname"] = exam;
        Page.Session["course"] = course;
        Page.Session["section"] = sec;
        Response.Redirect("Crystal_Classlist.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        course = DropDownList3.SelectedValue.ToString();
     //   sec = DropDownList4.SelectedValue.ToString();
       // exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());
        Page.Session["term"] = term;
        Page.Session["rep"] = "class";
        Page.Session["user"] = user;
        Page.Session["exname"] = "";
        Page.Session["course"] = course;
        Page.Session["section"] = DropDownList4.Text;
        Response.Redirect("Crystal_Classlist.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        course = DropDownList7.SelectedValue.ToString();
        sec = DropDownList8.SelectedValue.ToString();
        try
        {
          //  Label8.Text = DropDownList1.Items[0].Value.ToString();
          //  exam = ChangeToExamId(Label8.ToString());
            DropDownList5.Enabled = true;
          //  refresher();
          //  exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());
         
            Page.Session["term"] = term;
            Page.Session["rep"] = "not";
            Page.Session["user"] = user;
            Page.Session["exname"] = DropDownList5.SelectedValue.ToString();
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
        catch { DropDownList1.Enabled = false; }
     
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        course = DropDownList7.SelectedValue.ToString();
        sec = DropDownList8.SelectedValue.ToString();
        try
        {
            //  Label8.Text = DropDownList1.Items[0].Value.ToString();
            //  exam = ChangeToExamId(Label8.ToString());
            DropDownList5.Enabled = true;
            //  refresher();
            //  exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());

            Page.Session["term"] = term;
            Page.Session["rep"] = "anal";
            Page.Session["user"] = user;
            Page.Session["exname"] = DropDownList5.SelectedValue.ToString();
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
        catch { DropDownList5.Enabled = false; }
        //course = DropDownList7.SelectedValue.ToString();
        //sec = DropDownList8.SelectedValue.ToString();
        //try
        //{
        //    Label8.Text = DropDownList5.Items[0].Value.ToString();
        //    exam = ChangeToExamId(Label8.ToString());
        //    DropDownList1.Enabled = true;
        //    refresher();

        //    exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());
        //    Page.Session["term"] = term;
        //    Page.Session["rep"] = "anal";
        //    Page.Session["user"] = user;
        //    Page.Session["exname"] = exam;
        //    Page.Session["course"] = course;
        //    Page.Session["section"] = Label9.Text;
        //    Response.Redirect("Crystal_Classlist.aspx");
        //}  
        //catch { DropDownList1.Enabled = false; }

    }
    protected void DropDownList5_DataBound(object sender, EventArgs e)
    {

    }
    protected void DropDownList6_DataBound(object sender, EventArgs e)
    {
        try
        {
            sec = DropDownList8.Items[0].Value.ToString();
            DropDownList8.Enabled = true;
            refresher();
            Label9.Text = sec;
        }
        catch { }
        try
        {
            exam = DropDownList5.Items[0].Value.ToString();
            DropDownList5.Enabled = true;
            refresher();
            DropDownList5.Text = exam;
        }
        catch { }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    protected void DropDownList2_DataBound(object sender, EventArgs e)
    {
        DropDownList8.DataBind(); DropDownList5.DataBind();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        refresher();
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        try
        {
            Label8.Text = DropDownList1.Items[0].Value.ToString();
            exam = ChangeToExamId(Label8.ToString());
            DropDownList1.Enabled = true;
            refresher();
        }
        catch { DropDownList1.Enabled = false; }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
      
    }
    protected void Button_Clickn(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exam_results WHERE pname = '" + DropDownList1.Text + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                sec = Reader["section"].ToString();
                course = Reader["course"].ToString();
                break;
            }
            Reader.Close();
            Scon.Close();

        }

        //course = DropDownList2.SelectedValue.ToString();
      //  sec = DropDownList6.SelectedValue.ToString();
        exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());
        Page.Session["term"] = term;
        Page.Session["rep"] = "examan";
        Page.Session["user"] = user;
        Page.Session["exname"] = exam;
        Page.Session["course"] = course;
        Page.Session["section"] = sec;
        Response.Redirect("Crystal_Classlist.aspx");

     
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        course = DropDownList7.SelectedValue.ToString();
        sec = DropDownList8.SelectedValue.ToString();
        try
        {
            //  Label8.Text = DropDownList1.Items[0].Value.ToString();
            //  exam = ChangeToExamId(Label8.ToString());
            DropDownList5.Enabled = true;
            //  refresher();
            //  exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());

            Page.Session["term"] = term;
            Page.Session["rep"] = "itfull";
            Page.Session["user"] = user;
            Page.Session["exname"] = DropDownList5.SelectedValue.ToString();
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
        catch { DropDownList5.Enabled = false; }
       

    }
    protected void Button9Click(object sender, EventArgs e)
    {
        course = DropDownList7.SelectedValue.ToString();
        sec = DropDownList8.SelectedValue.ToString();
        try
        {
            //  Label8.Text = DropDownList1.Items[0].Value.ToString();
            //  exam = ChangeToExamId(Label8.ToString());
            DropDownList5.Enabled = true;
            //  refresher();
            //  exam = ChangeToExamId(DropDownList1.SelectedValue.ToString());

            Page.Session["term"] = term;
            Page.Session["rep"] = "grades";
            Page.Session["user"] = user;
            Page.Session["exname"] = DropDownList5.SelectedValue.ToString();
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
        catch { DropDownList5.Enabled = false; }
        //course = DropDownList7.SelectedValue.ToString();
        //sec = DropDownList8.SelectedValue.ToString();

        //// try
        //{
        //    DropDownList5.Enabled = true;
        //    //    Label8.Text = DropDownList5.Text;
        //    //   exam = ChangeToExamId(DropDownList5.Text);
        //    //   DropDownList1.Enabled = true;
        //    //     refresher();

        //    //     exam = ChangeToExamId(DropDownList5.Text);
        //    Page.Session["term"] = term;
        //    Page.Session["rep"] = "grades";
        //    Page.Session["user"] = user;
        //    Page.Session["exname"] = DropDownList5.SelectedValue.ToString();
        //    Page.Session["course"] = course;
        //    Page.Session["section"] = DropDownList8.SelectedValue.ToString();
        //    Response.Redirect("Crystal_Classlist.aspx");
        //}
        ////  catch { DropDownList5.Enabled = false; }
    }
    protected void DropDownList3_DataBound(object sender, EventArgs e)
    {
        DropDownList4.DataBind();
        try
        {

          DropDownList4.SelectedIndex = 0;
            DropDownList4.Enabled = true;

        }
       catch {}
     
    }
    protected void DropDownList4_DataBound(object sender, EventArgs e)
    {
       try
        {
          //  DropDownList4.DataBind();
           // sec = DropDownList4.Items[0].Value.ToString();
            DropDownList4.Enabled = true;

        }
       catch {}
    }





    protected void asa_DataBound(object sender, EventArgs e)
    {
     
    }
}
