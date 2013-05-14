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

public partial class CreateExam : System.Web.UI.Page
{
    string user = ""; string section = "";
    string course; string ops = "";
    string term;
    string OKs = "false"; string line = ""; string exname = ""; string editmode = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Page.Session["user"] == null)
        {

            Response.Redirect("LogIn.aspx");
        }
        else
        {
            StreamReader sr44 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr44.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource1.ConnectionString = sConnection2;
            try
            {
                ops = Page.Session["operation"].ToString();
                exname = Page.Session["exname"].ToString();
                editmode = Page.Session["editmode"].ToString(); 
                if (ops == "1")
                {
                    Button2.Visible = true;
                }

            }
            catch { }
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
                        Response.Redirect("LogIn.aspx");
                        break;
                    }
                }
                Reader.Close();
                Scon.Close();

            }
            if ((Page.Session["section"] == null) || (Page.Session["course"] == null))
            {
                Response.Redirect("Classlists.aspx");
            }
            else
            {
                if (Page.Session["warn"] == null)
                {
                    OKs = "";
                }
                else
                {
                    OKs = Page.Session["warn"].ToString();
                }
                section = Page.Session["section"].ToString();
                course = Page.Session["course"].ToString();
                user = Page.Session["user"].ToString();
            
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                SqlDataSource1.ConnectionString = sConnection;
                GridView1.DataBind();
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                string sql;
                sql = "Select * From course WHERE course_id = '" + course + "' AND sec_handler = '" + user + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    lblTitle.Text = (Reader["course_desc"].ToString());
                    lblTerm.Text = (Reader["term"].ToString());
                    term = (Reader["term"].ToString());
                    lblCourse.Text = (Reader["course_id"].ToString());
                }
                Reader.Close();
                Scon.Close();

                lblCourse.Text = course;
                //if (OKs == "true")
                //{
                //    Label3.Visible = true;
                //    Label3.Text = "Warning!The data was transferred from another file. Please check the list below, If you found an unnecessary line of data. Please delete it.";
                //}
                //else{
                //    Label3.Visible = false;
                //}
            
                
            }
     
           
        } 
    }
   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      

    }

    protected void TextBox18_TextChanged(object sender, EventArgs e)
    {
    }
    
      
    protected void GridView1_Load(object sender, EventArgs e)
    {
     
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
      
       
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
    protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
    {
      
     
    }
    protected void txtC_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
       
        

    }
    public void AnswerAdder(string control)
    {
    }
    protected void radA_CheckedChanged(object sender, EventArgs e)
    {
     
    }
    protected void radB_CheckedChanged(object sender, EventArgs e)
    {
     
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      
    }
   
   
  
    protected void radDiagram_CheckedChanged(object sender, EventArgs e)
    {
     
        
    }
    protected void imgA_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void radA_CheckedChanged1(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void imgG_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
  
    protected void drpExams_SelectedIndexChanged(object sender, EventArgs e)
    {
     
       

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Page.Session["exname"] = Label23.Text;
        Page.Session["user"] = user;
        //     Page.Session["numCol"] = basu;


        Response.Redirect("InsHome.aspx");
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void Button1_Click2(object sender, EventArgs e)
    {
        try
        {
            {

                TextBox txtNo = GridView1.HeaderRow.FindControl("studNo") as TextBox;
                TextBox txtNa = GridView1.HeaderRow.FindControl("studNa") as TextBox;




                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Insert Into classlist VAlUES('" + txtNo.Text + ":" + section + ":" + course + ":" + term + "','" + txtNo.Text.Trim().ToUpper() + "','" + user + "','" + section + "','" + lblCourse.Text + "','" + txtNa.Text.Trim().ToUpper() + "')";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                GridView1.DataBind();

                txtNo.Focus();
            }
        }
        catch { }
    }
    
    protected void AddtoEmpty(object sender, EventArgs e)
    {
        try
        {
            {


                TextBox txtNo = (TextBox)GridView1.Controls[0].Controls[0].FindControl("studNo");
                TextBox txtNa = (TextBox)GridView1.Controls[0].Controls[0].FindControl("studNa");




                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Insert Into classlist VAlUES('" + txtNo.Text + ":" + section + ":" + course + ":" + term + "','" + txtNo.Text.Trim().ToUpper() + "','" + user + "','" + section + "','" + lblCourse.Text + "','" + txtNa.Text.Trim().ToUpper() + "')";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                GridView1.DataBind();

            }
        }
        catch { }
    }
    protected void studNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtNo = (TextBox)GridView1.Controls[0].Controls[0].FindControl("studNo");
            TextBox txtNa = (TextBox)GridView1.Controls[0].Controls[0].FindControl("studNa");
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From user_table WHERE user_id = '" + txtNo.Text + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                txtNa.Text = (Reader["lname"].ToString().ToUpper() + ", " + (Reader["fname"].ToString().ToUpper()) + " (" + (Reader["bname"].ToString().ToUpper()) + ")");
                
            }
            Reader.Close();
            Scon.Close();
        }
        catch { }
    }
    protected void studNo_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void Button2_Click2(object sender, EventArgs e)
    {
        Page.Session["exname"] = exname;
        Page.Session["user"] = user;
        //     Page.Session["numCol"] = basu;
        Page.Session["editmode"] = editmode;
        Page.Session["operation"] = "";
        Response.Redirect("InsPublish.aspx");
        {
            //SqlConnection Scon;
            //SqlDataReader Reader;
            //SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            //string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //string sql;
            //sql = "Select * From classlist WHERE sec = '" + section+ "' AND  prof_id = '" + user + "' AND  course_code = '" +course + "'";
            //Scon = new SqlConnection(sConnection);
            //Scon.Open();
            //Cmd = new SqlCommand(sql, Scon);
            //Reader = Cmd.ExecuteReader();

            //while (Reader.Read())
            //{
            //    SqlConnection Scon2;
            //    SqlDataReader Reader2;
            //    SqlCommand Cmd2;
            //    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

            //    string sql2;
            //    sql2 = "Insert Into exam_results VAlUES('" + exname + ":" + Reader["stud_id"].ToString() + ":" + Label15.Text + ":" + Label14.Text + "','" + Reader["stud_id"].ToString() + "','" + exname + "','" + "" + "','" + 0 + "','" + TextBox3.Text + "','" + Label15.Text + "','" + Label14.Text + "','" + "NOT TAKEN" + "','" + 0 + "','" + TextBox6.Text.Trim() + ":0000" + "')";
            //    Scon2 = new SqlConnection(sConnection2);
            //    Scon2.Open();
            //    Cmd2 = new SqlCommand(sql2, Scon2);
            //    Reader2 = Cmd2.ExecuteReader();


            //}
            //Reader.Close();
            //Scon.Close();

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            {


                TextBox txtNo = (TextBox)GridView1.Controls[0].Controls[0].FindControl("studNo");
                TextBox txtNa = (TextBox)GridView1.Controls[0].Controls[0].FindControl("studNa");




                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Insert Into classlist VAlUES('" + txtNo.Text + ":" + section + ":" + course + ":" + term + "','" + txtNo.Text.Trim().ToUpper() + "','" + user + "','" + section + "','" + lblCourse.Text + "','" + txtNa.Text.Trim().ToUpper() + "')";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                GridView1.DataBind();

            }
        }
        catch { }
    }
}
