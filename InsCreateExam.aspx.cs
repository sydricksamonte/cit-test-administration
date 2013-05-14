using System;
using System.Data;
using System.Data.Sql;
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


public partial class CreateExam : System.Web.UI.Page
{
    string user; string newtype = ""; string choice; string line = ""; string term = ""; string mes = "";
    protected void Page_Load(object sender, EventArgs e)
    {
          
        if (Page.Session["user"] == null)
        {
           
            Response.Redirect("LogIn.aspx");
        }
        else
        {

            try
            {
                Label19.Text = Page.Session["message"].ToString();
                Page.Session["message"] = "";
            }
            catch { }
            user = Page.Session["user"].ToString();
            string choice;
            Label3.Text = "";
               string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

           StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine(); SqlDataSource1.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource1.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource2.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource3.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource4.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string type = "";
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;  
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
                line = sr2.ReadLine();
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
                     type = Reader["type"].ToString();
                     if (type.ToUpper() != "FACULTY")
                    {
                        Response.Redirect("LogIn.aspx");
                        break;
                    }
                }
                Reader.Close();
                Scon.Close();
                if (type.ToUpper() != "FACULTY")
                {
                    Response.Redirect("LogIn.aspx");
                  
                }
            }
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From term  ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                   term = (Reader["term"].ToString());
              
                   Page.Session["term"] = term;
                 //  MessageBox(term);
                   break;
                }
                Reader.Close();
                Scon.Close();

            }
        
            //{
            //    SqlConnection Scon;
            //    SqlDataReader Reader;
            //    SqlCommand Cmd;
            //    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            //    line = sr2.ReadLine();
            //    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //    string sql;
            //    sql = "Select * From course WHERE sec_handler = '" + user + "' and term = '" + term + "' ";
            //    Scon = new SqlConnection(sConnection);
            //    Scon.Open();
            //    Cmd = new SqlCommand(sql, Scon);
            //    Reader = Cmd.ExecuteReader();

            //    while (Reader.Read())
            //    {
            //        DropDownList3.Items.Add(Reader["course_id"].ToString());

            //    }
            //    Reader.Close();
            //    Scon.Close();

            //}
           
      
        }
      
      
    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }

    protected void Proceed_Click(object sender, EventArgs e)
    {
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    string extype;
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
     
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex.ToString() == "-1")
        {
            MessageBox("Select an unpublished test ");
           
        }
        else if (DropDownList1.Text == "")
        {
            MessageBox("Select an unpublished test ");
           
        }
        else
        {

            {
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From exam_unpub WHERE exname = '" + DropDownList1.Text + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Page.Session["course"] = Reader["course"].ToString();



                    }
                    Reader.Close();
                    Scon.Close();


                }
                if (DropDownList1.Text.EndsWith("T") == true)
                { Page.Session["editmode"] = "0"; }
                else
                { Page.Session["editmode"] = "2"; }

                choice = "T_M_I";
                Page.Session["choice"] = choice;
                Page.Session["user"] = user;
                Page.Session["exname"] = DropDownList1.SelectedValue.ToString();
                Response.Redirect("CreateExam.aspx");
                //  Page.Session["course"] = TextBox1.Text.Substring(

            }

        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton2.Checked == true)
        {
            newtype = "own";
        }
        else
        {
            newtype = "";
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton2.Checked == true)
        {
            newtype = "own";
        }
        else
        {
            newtype = "";
        }
        if (RadioButton1.Checked == true)
        {
            newtype = "pre";
        }
        else
        {
            newtype = "";
        }
       
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        if (drpExtype.Text.Contains("1S"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "EXAM_1" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("2N"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "EXAM_2" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("3R"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "EXAM_3" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("4T"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "EXAM_4" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("5T"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "EXAM_5" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("FINA"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "EXAM_F" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("QUIZ"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "QUIZ_" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
        else if (drpExtype.Text.Contains("SEAT"))
        {
            Page.Session["course"] = DropDownList3.Text;
            TextBox1.Text = "SEAT_" + System.DateTime.Now.ToString().Replace(" ", "") + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + user + term;
        }
   
        string name = "";
        bool exist = false;
        Page.Session["course"] = DropDownList3.SelectedValue.ToString();
              
        ImageButton4.Enabled = true;
        if (TextBox1.Text.Contains("EXAM"))
        {
            extype = "exam";
        }
        else if (TextBox1.Text.Contains("SEAT"))
        {
            extype = "seat";
            TextBox1.Text = TextBox1.Text + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Millisecond.ToString();
        }
        if (TextBox1.Text.Contains("QUIZ"))
        {
            extype = "quiz";
            TextBox1.Text = TextBox1.Text + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Millisecond.ToString();
        }
        //if (RadioButton3.Checked == true)
        //{
        //    extype = "exam";
        //    TextBox1.Text = "EXAM_" + System.DateTime.Now.TimeOfDay.ToString() + "_" + user;
        //    RadioButton3.Focus();
        //    
        //    CheckBox1.Enabled = true;
        //    CheckBox2.Enabled = true;
        //    CheckBox3.Enabled = true;
         
        //}
        
        //if (RadioButton4.Checked == true)
        //{
        //    extype = "quiz";
        //    ImageButton4.Enabled = true;
        //    TextBox1.Text = "QUIZ_" + System.DateTime.Now.TimeOfDay.ToString() + "_" + user;
           
        //}
        //if (RadioButton5.Checked == true)
        //{
        //    extype = "seat work"; ImageButton4.Enabled = true;
        //    TextBox1.Text = "SEAT_" + System.DateTime.Now.TimeOfDay.ToString() + "_" + user;
            
        //}
       
        //if ((CheckBox1.Checked == true) && (CheckBox2.Checked == true) && (CheckBox3.Checked == true))
        //{
        //    choice = "T_M_I";
        //}



        //if ((CheckBox1.Checked == false) && (CheckBox2.Checked == true) && (CheckBox3.Checked == true))
        //{
        //    choice = "M_I";
        //}


        //if ((CheckBox1.Checked == false) && (CheckBox2.Checked == false) && (CheckBox3.Checked == true))
        //{
        //    choice = "I";
        //}

        //if ((CheckBox1.Checked == true) && (CheckBox2.Checked == false) && (CheckBox3.Checked == true))
        //{
        //    choice = "T_I";
        //}


        //if ((CheckBox1.Checked == false) && (CheckBox2.Checked == true) && (CheckBox3.Checked == false))
        //{
        //    choice = "M";
        //}

        //if ((CheckBox1.Checked == true) && (CheckBox2.Checked == true) && (CheckBox3.Checked == false))
        //{
        //    choice = "T_M";
        //}

        //if ((CheckBox1.Checked == true) && (CheckBox2.Checked == false) && (CheckBox3.Checked == false))
        //{
        //    choice = "T";
        //}
        //if ((CheckBox1.Checked == false) && (CheckBox2.Checked == false) && (CheckBox3.Checked == false))
        //{
        //    choice = "";
        //}
        //if (choice == "")
        //{
        //    Label3.Text = "Please choose question/s type";
        //    Label3.Visible = true;
        //}
        //else
        bool SyllaExist = false;
        {
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From course_topics WHERE week  LIKE '" +DropDownList3.Text+ "%'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    SyllaExist = true;
                }
                Reader.Close();
                Scon.Close();
            }
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From question_table WHERE exam_code = '" + drpExtype.SelectedValue.ToString() + "' AND exam_code LIKE '" + "EXAM" + "%'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    exist = true;
                }
                Reader.Close();
                Scon.Close();
            }
            Page.Session["editmode"] = "0";
            if (exist == false)
            {
               
                if (TextBox1.Text.Length <= 7)
                {
                    MessageBox("Please choose a test.");
                    ImageButton4.Focus();
                    //Label3.Text = "Please enter a more meaningful name.";
                    //Label3.Visible = true;
                }
                else
                {
                    Page.Session["course"] = DropDownList3.Text;
                    Label3.Visible = false;
                    string basu;
                    basu = TextBox1.Text;

                    Page.Session["exname"] = basu;
                    //     Page.Session["numCol"] = basu;
                    if (RadioButton2.Checked == true)
                    {
                        newtype = "own";
                    }

                    if (RadioButton1.Checked == true)
                    {
                        newtype = "pre";
                    }
                    if (newtype == "own")
                    {
                        SqlConnection Scon2;
                        SqlCommand Cmd2; SqlDataReader Reader2;
                        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql2;
                        sql2 = "Insert Into exam_unpub VAlUES('" + TextBox1.Text + "','" + DropDownList3.Text + "')";
                        Scon2 = new SqlConnection(sConnection2);
                        Scon2.Open();
                        Cmd2 = new SqlCommand(sql2, Scon2);
                        Reader2 = Cmd2.ExecuteReader();
                        Reader2.Close();
                        Scon2.Close();
                          Page.Session["user"] = user;
                        //   Page.Session["exname"] = DropDownList1.SelectedValue.ToString();
                      //  Page.Session["choice"] = choice;
                        Response.Redirect("CreateExam.aspx");
                    }
                    if (newtype == "pre")
                    {
                        if (SyllaExist == true)
                        {
                            Page.Session["user"] = user;
                            Page.Session["type"] = extype;

                            if (drpExtype.SelectedValue.ToString().Contains("EXAM"))
                            {
                                Page.Session["define"] = "1";
                            }
                            else
                            {
                                Page.Session["define"] = "0";
                            }
                            //    Page.Session["exname"] = DropDownList1.SelectedValue.ToString();
                            Response.Redirect("InsCreateExam_LOchoose.aspx");
                        }
                        else
                        {
                            string couu = "The course syllabus of " + DropDownList3.Text + " is unavailable.";
                            MessageBox(couu);
                        }
                    }
                   

                }
            }
            else
            {
               MessageBox( "The test you are trying to create is already on the database.");
              //  Label3.Visible = true;
               ImageButton4.Focus();
            }
        }
      
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
       
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
      
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
     
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
       
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      
     
    

      
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    private void refTests()
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exams WHERE exname = '" + DropDownList2.SelectedValue.ToString() + "' AND user_id ='" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                Label15.Text = Reader["exname"].ToString();
                lblCreated.Text = Reader["pub_date"].ToString();
                lblDura.Text = Reader["duration"].ToString().Substring(0,5);
                Label12.Text = Reader["frameA"].ToString();
                txtStatus.Text = Reader["pname"].ToString();
                TextBox12.Text = Reader["pass"].ToString();

                if ((Label12.Text == "OPEN")||(Label12.Text == "RE-OPEN"))
                {
                    //Button2.Visible = true;
                    //Button3.Visible = false;
                 
                }
                else
                {
                    //Button3.Visible = true;
                    //Button2.Visible = false;
                }
                string imgs = Reader["exname"].ToString();

                if (imgs.Contains("EXAM"))
                {
                    ImageButton1.ImageUrl = "~/Images/type_exam.png";
                }
                if (imgs.Contains("EXAM_F"))
                {
                    ImageButton1.ImageUrl = "~/Images/t_f.png";
                }
                if (imgs.Contains("SEAT"))
                {
                    ImageButton1.ImageUrl = "~/Images/t_seatwork.png";
                }
                if (imgs.Contains("QUIZ"))
                {
                    ImageButton1.ImageUrl = "~/Images/type_quiz.png";
                }
                break;
            }
            Reader.Close();
            Scon.Close();
        
        }
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        refTests();
        Button6.Visible = true;
        DropDownList2.Focus();
        btnPrev.Visible = true;
        Button4.Visible = true;
        Button51.Enabled = true;
        Button6.Visible = true;
        ImageButton1.Visible = true;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //show_confirm("w?");
        int numels = 0;
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select frameB From exams WHERE user_id = '" + user + "' AND exname='" + DropDownList2.SelectedValue.ToString() + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                numels = int.Parse(Reader["frameB"].ToString());
                numels++;
                break;
            }

            Reader.Close();
            Scon.Close();
        }
        {
            SqlConnection Scon;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE exams SET frameB='" + numels.ToString() + "', frameA ='" + "RE-OPEN" + "' WHERE user_id = '" + user + "' AND exname='" + DropDownList2.SelectedValue.ToString() + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Cmd.ExecuteNonQuery();
            Scon.Close();
            DropDownList2.Focus();
        } MessageBox("The test is now available.");

        //  try
        {
            refTests();
        }
        //  catch { } 
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE exams SET frameA ='" + "CLOSE" + "' WHERE user_id = '" + user + "' AND exname='" + DropDownList2.SelectedValue.ToString() + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Cmd.ExecuteNonQuery();
            Scon.Close();
            DropDownList2.Focus();
        }
        //  try
        {
            refTests();
        }
        //  catch { } 
        MessageBox("The test is now unavailable.");

    }
    protected void DropDownList2_DataBound(object sender, EventArgs e)
    {
        if (DropDownList2.Text == "")
        {
            ImageButton2.Enabled = false;
        }
        else
        {
            ImageButton2.Enabled = true;
        }
    }
    protected void DropDownList2_Load(object sender, EventArgs e)
    {
     
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        string exname="";
        SqlConnection Scon;
        SqlDataReader Reader;
        SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        string sql;
        sql = "Select * From exams WHERE exname = '" + DropDownList2.SelectedValue.ToString() + "'";
        Scon = new SqlConnection(sConnection);
        Scon.Open();
        Cmd = new SqlCommand(sql, Scon);
        Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            exname = Reader["exname"].ToString();
            break;
        }

        Reader.Close();
        Scon.Close();
        Page.Session["extype"] = "Fac";
        Page.Session["user"] = user;
        Page.Session["exname"] = exname;
        Response.Redirect("Exam.aspx");
      
    }
    protected void btnSatt_Click(object sender, EventArgs e)
    {
        string exname = "";
        string section = "";
        string course = "";
        SqlConnection Scon;
        SqlDataReader Reader;
        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        string sql;
        sql = "Select * From exam_results WHERE exam_code = '" + DropDownList2.SelectedValue.ToString() + "'";
        Scon = new SqlConnection(sConnection);
        Scon.Open();
        Cmd = new SqlCommand(sql, Scon);
        Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            exname = Reader["exam_code"].ToString();
            course = Reader["course"].ToString();
            section = Reader["section"].ToString();
            break;
        }

        Reader.Close();
        Scon.Close();
        Page.Session["course"] = course;
        Page.Session["section"] = section;
        Page.Session["user"] = user;
        Page.Session["exname"] = exname;
        Response.Redirect("InsExamScore.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE exams SET pass ='" + TextBox12.Text + "' WHERE user_id = '" + user + "' AND exname='" + DropDownList2.SelectedValue.ToString() + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Cmd.ExecuteNonQuery();
            Scon.Close();
            Label17.Visible = true;
            DropDownList2.Focus();
        }
    }
    protected void drpExtype_SelectedIndexChanged(object sender, EventArgs e)
    {
     //   DropDownList4.SelectedIndex = drpExtype.SelectedIndex;


    }
    int counth =0;
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpExtype.Items.Clear();
        Button7_Click(Button7, e);
        //drpExtype.Items.Clear();
        //DropDownList4.Items.Clear();
        //drpExtype.Focus();
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr2.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select DISTINCT course_desc From course WHERE sec_handler= '" + user + "' AND course_id='" + DropDownList3.Text + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == 0)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " 1ST LONG EXAM");
                      
                    }
                    else if (x == 1)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " 2ND LONG EXAM");
                    }
                    else if (x == 2)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " 3RD LONG EXAM");
                    }
                    else if (x == 3)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " 4TH LONG EXAM");
                    }
                    else if (x == 4)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " 5TH LONG EXAM");
                    }
                    else if (x == 5)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " QUIZ");
                    }
                    else if (x == 6)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " SEATWORK");
                    }
                    else if (x == 7)
                    {
                        drpExtype.Items.Add(Reader["course_desc"].ToString() + " FINAL EXAMINATION");
                    }
                }
               

              
            }
            Reader.Close();
            Scon.Close();

        }
    //    DropDownList3.Focus();
       drpExtype.DataBind();
       ImageButton4.Focus(); 
    }
    protected void DropDownList3_Load(object sender, EventArgs e)
    {
    //    drpExtype.DataBind();
    }
    protected void DropDownList3_DataBound(object sender, EventArgs e)
    {
        drpExtype.DataBind();
    }
    protected void drpExtype_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void drpExtype_DataBinding(object sender, EventArgs e)
    {
       
    }
    int i = 1;
    protected void drpExtype_DataBound(object sender, EventArgs e)
    {
      
    }
    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string exname = "";
        SqlConnection Scon;
        SqlDataReader Reader;
        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        string sql;
        sql = "Select * From exams WHERE exname = '" + DropDownList2.SelectedValue.ToString() + "'";
        Scon = new SqlConnection(sConnection);
        Scon.Open();
        Cmd = new SqlCommand(sql, Scon);
        Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            exname = Reader["exname"].ToString();
            break;
        }

        Reader.Close();
        Scon.Close();
        Page.Session["user"] = user;
        Page.Session["exname"] = exname;
        Response.Redirect("InsEditExam.aspx");
    }
    protected void Label19_Load(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
    //    Button7.Visible = false;
      //  Page.Session["message"] = "";
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList5_DataBound(object sender, EventArgs e)
    {
        DropDownList5.SelectedIndex = 0;
        DropDownList2.DataBind();
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {

    }
}
