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
    string user; string newtype = ""; string durat = ""; string course = ""; string line = ""; string term = ""; string exname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {

            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
            exname = Page.Session["exname"].ToString(); Label15.Text = exname;
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exams WHERE exname = '" + exname+ "' AND user_id ='" + user + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    Label15.Text = Reader["pname"].ToString();

                    durat = Reader["duration"].ToString();
                    if (Reader["frameA"].ToString().Contains("PRINT"))
                    {
                        RadioButton3.Visible = false;
                        RadioButton2.Visible = false;
                        RadioButton5.Visible = false;
                     //   RadioButton4.Checked = true;
                    }
                    else
                    {
                        RadioButton3.Visible = true;
                        RadioButton2.Visible = true;
                        RadioButton5.Visible = true;
                    }
                }
                Reader.Close();
                Scon.Close();
            }
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exam_results WHERE exam_code = '" + exname + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    course = Reader["course"].ToString();
                    txtSe.Text = Reader["section"].ToString();
                    break;

                }
                Reader.Close();
                Scon.Close();
            }
        }
        

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

    }
    string ok = "";
    private string idmaker()
    {
     string jak=   exname + System.DateTime.Now.ToString();
     return jak;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Page.Session["course"] = course;
        int countz = 100;
        if (RadioButton2.Checked == true)
        {
            Page.Session["user"] = user;

            Page.Session["exname"] = exname;
            Response.Redirect("InsRetake.aspx");
        }
        else if (RadioButton5.Checked == true)
        {
            Panel1.Visible = true;
            Panel3.Visible = false;
            TextBox2.Focus();
        }
        else if (RadioButton3.Checked == true)
        {
            Page.Session["user"] = user;
            Page.Session["editmode"] = "1";
            Page.Session["exname"] = exname;
            Response.Redirect("CreateExam.aspx");
        }
        else if (RadioButton4.Checked == true)
        {
            string newexname = idmaker();
           
            {
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From question_table WHERE exam_code = '" + exname + "' AND ins_id ='" + user + "' ";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        countz++;
                        if (countz == 101)
                        {
                            SqlConnection Scon2;
                            SqlCommand Cmd2; SqlDataReader Reader2;
                            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql2;
                            sql2 = "Insert Into exam_unpub VAlUES('" + exname + System.DateTime.Now.Millisecond.ToString() + "','" + course + "')";
                            Scon2 = new SqlConnection(sConnection2);
                            Scon2.Open();
                            Cmd2 = new SqlCommand(sql2, Scon2);
                            Reader2 = Cmd2.ExecuteReader();
                            Reader2.Close();
                            Scon2.Close();
                        }
                        {
                            SqlConnection Scon2;
                            SqlDataReader Reader2;
                            SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql2;
                            sql2 = "Insert Into question_table VAlUES('" + user + "','" + exname + System.DateTime.Now.Millisecond.ToString() + ":" + countz + "','" + newexname + "','" + Reader["typeEx"].ToString() + "','" + Reader["ques_desc"].ToString() + "','" + Reader["ans_a"].ToString() + "','" + Reader["ans_b"].ToString() + "','" + Reader["ans_c"].ToString() + "','" + Reader["ans_d"].ToString() + "','" + Reader["ans_e"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + Reader["l_outcomes"].ToString() + "','" + null + "','" + null + "','" + Reader["l_o"].ToString() + "','" + Reader["c_o"].ToString() + "','" + Reader["copy_type"].ToString() + "','" + Reader["pt"].ToString() + "','" + Reader["dif"].ToString() + "')";
                            Scon2 = new SqlConnection(sConnection2);
                            Scon2.Open();
                            Cmd2 = new SqlCommand(sql2, Scon2);
                            Reader2 = Cmd2.ExecuteReader();
                        }

                    }
                    Reader.Close();
                    Scon.Close();
                }
                Button3.Text = "Please wait...";
                Button3.Enabled = false;
                Page.Session["user"] = user;
                Page.Session["editmode"] = "2";
                Page.Session["exname"] = newexname;
                Response.Redirect("CreateExam.aspx");
            }

        }
        else if (RadioButton6.Checked == true)
        {
            Panel3.Visible = true;
            Panel1.Visible = false;
            TextBox3.Text = Label15.Text;
            TextBox3.Focus();
        }
        else if (RadioButton1.Checked == true)
        {
            LinkButton1.Visible = true;
            LinkButton1.Focus();
           
        }
        else
        {
            MessageBox("Please select an operation");
        }
    }

    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        //if (RadioButton1.Checked == true)
        //{
        //    TextBox1.Visible = true;
        //    Label2.Visible = true;
        //}

        //else
        //{
        //    TextBox1.Visible = false;
        //    Label2.Visible = false;
        //}
    }string syana = "";
    protected void Button1_Click(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exams WHERE pname = '" + exname + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                syana = (Reader["exname"].ToString());
               
                break;


            }
            Reader.Close();
            Scon.Close();
        }
       try
        {
            {
                SqlConnection Scon22;
                SqlDataReader Reader22;
                SqlCommand Cmd22;
                 string sConnection22 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                string sql22;
                sql22 = "Insert Into exam_results VAlUES('" + exname + ":" + TextBox2.Text + ":" + txtSe.Text + ":" + course + "','" + TextBox2.Text + "','" + exname + "','" + "" + "','" + 0 + "','" + Label15.Text + "','" + txtSe.Text + "','" + course + "','" + "NOT TAKEN" + "','" + 0 + "','" + durat + "')";
                Scon22 = new SqlConnection(sConnection22);
                Scon22.Open();
                Cmd22 = new SqlCommand(sql22, Scon22);
                Reader22 = Cmd22.ExecuteReader();


            }

            string terms = "";
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From term ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {

                    terms = Reader["term"].ToString();
                }
                Reader.Close();
                Scon.Close();
            }
            //{
            //    SqlConnection Scon;
            //    SqlDataReader Reader;
            //    SqlCommand Cmd;
            //    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            //    line = sr.ReadLine();
            //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //    string sql;
            //    sql = "Select * From question_table WHERE exam_code = '" + exname + "'";
            //    Scon = new SqlConnection(sConnection);
            //    Scon.Open();
            //    Cmd = new SqlCommand(sql, Scon);
            //    Reader = Cmd.ExecuteReader();

            //    while (Reader.Read())
            //    {

            //        {
            //            SqlConnection Scon2;
            //            SqlDataReader Reader2;
            //            SqlCommand Cmd2;
            //            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

            //            string sql2;
            //            sql2 = "Insert Into it_anal VAlUES('" + terms + ":" + course + ":" + txtSe.Text + ":" + Reader["ques_id"].ToString() + "','" + "0" + "','" + "0" + "','" + Reader["ques_id"].ToString() + "','" + exname + "')";
            //            Scon2 = new SqlConnection(sConnection2);
            //            Scon2.Open();
            //            Cmd2 = new SqlCommand(sql2, Scon2);
            //            Reader2 = Cmd2.ExecuteReader();


            //        }
            //    }
            //    Reader.Close();
            //    Scon.Close();
            //}
            string newuser = "";
            bool newuserN = true;
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From classlist where course_code = '" + course + "' AND stud_id = '" + TextBox2.Text + "' AND sec = '" + txtSe.Text + "' AND stud_course_id LIKE '%" + terms + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {

                    newuserN = false;
                    
               
                   

                }
                Reader.Close();
                Scon.Close();
            }
            if (newuserN == false)
            {
                Page.Session["message"] = "Student is now valid to take the test.";
                Response.Redirect("InsCreateExam.aspx");
            }
            else if (newuserN == true)
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2;
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                string sql2;
                sql2 = "Insert Into classlist VAlUES('" + TextBox2.Text + ":" + txtSe.Text + ":" + course + ":" + terms + "','" + TextBox2.Text + "','" + user + "','" + txtSe.Text + "','" + course.ToUpper() + "','" + txtNa.Text.Trim().ToUpper() + "')";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();

                Page.Session["message"] = "The student # was not found on the database and has been added and validated to take the test.";
                Response.Redirect("InsCreateExam.aspx");

            }
        }
        catch { Label9.Text = "Failed to add examinee. Please check the student number"; TextBox2.Focus(); }
      
    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE exams Set pname = '" + TextBox3.Text.Trim().ToUpper() + "' Where exname ='" + exname + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();
        }
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE exam_results Set pname = '" + TextBox3.Text.Trim().ToUpper() + "' Where exam_code ='" + exname + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();
        }
        Page.Session["message"] = "Exam successfully renamed.";
        Response.Redirect("InsCreateExam.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //{
        //    SqlConnection Scon;
        //    SqlDataReader Reader;
        //    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
        //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        //    string sql;
        //    sql = "Select pass From user_table WHERE user_na = '" + user + "'";
        //    Scon = new SqlConnection(sConnection);
        //    Scon.Open();
        //    Cmd = new SqlCommand(sql, Scon);
        //    Reader = Cmd.ExecuteReader();
        //    while (Reader.Read())
        //    {

        //        if (Reader["pass"].ToString() == TextBox1.Text)
        //        {
        //            //  Label13.Text = "dsbgdsrg";
        //            ok = "true";
        //            break;
        //        }
        //    }
        //    Reader.Close();
        //    Scon.Close();
        //}
        //if (ok == "true")
        string logUser = "";
        {
            SqlConnection Scon77;
            SqlDataReader Reader77;
            SqlCommand Cmd77; StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr77.ReadLine();
            string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql77;
            sql77 = "Select * From user_table WHERE user_id = '" + user + "' ";
            Scon77 = new SqlConnection(sConnection77);
            Scon77.Open();
            Cmd77 = new SqlCommand(sql77, Scon77);
            Reader77 = Cmd77.ExecuteReader();

            while (Reader77.Read())
            {
                logUser = Reader77["prog"].ToString();

            }
            Reader77.Close();
            Scon77.Close();

        }
        {
            SqlConnection Scon6;
            SqlDataReader Reader6;
            SqlCommand Cmd6; StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr6.ReadLine();
            string path6 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql6;
            sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Deleted examination: " + Label15.Text + "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
            Scon6 = new SqlConnection(sConnection6);
            Scon6.Open();
            Cmd6 = new SqlCommand(sql6, Scon6);
            Reader6 = Cmd6.ExecuteReader();
            Reader6.Close();
            Scon6.Close();
        }
        {


            {
                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM exams where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM question_table where exam_code = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM exam_report where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM exam_reduce where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM stud_perc where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM exam_results where exam_code = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM it_anal where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM ratio where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM answers where exam_code = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM answers where exam_code = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM course_bulk where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = " DELETE FROM exam_chart where exname = '" + exname + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
            }
            int fuler = 0;
            //{
            //    SqlConnection Scon;
            //    SqlDataReader Reader;
            //    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //    string sql;
            //    sql = "Select made From course_bulk WHERE ex_code = '" + exname + "' ";
            //    Scon = new SqlConnection(sConnection);
            //    Scon.Open();
            //    Cmd = new SqlCommand(sql, Scon);
            //    Reader = Cmd.ExecuteReader();

            //    while (Reader.Read())
            //    {
            //        fuler = int.Parse(Reader["made"].ToString());
            //        fuler--;
            //        break;


            //    }
            //    Reader.Close();
            //    Scon.Close();
            //}
            //{
            //    SqlConnection Scon;
            //    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //    string sql;
            //    sql = "UPDATE course_bulk SET made ='" + fuler.ToString() + "' WHERE ex_code = '" + exname + "'";
            //    Scon = new SqlConnection(sConnection);
            //    Scon.Open();
            //    Cmd = new SqlCommand(sql, Scon);
            //    Cmd.ExecuteNonQuery();
            //    Scon.Close();

            //}
            Page.Session["message"] = "Test has been deleted";
            Response.Redirect("InsCreateExam.aspx");

            Panel4.Visible = false;
            Button3.Visible = false;
            TextBox1.Visible = false;
            Label2.Visible = false; Label13.Visible = false;


        }
        //else
        //{
        //    Label2.ForeColor = System.Drawing.Color.Red;
        //    Label2.Text = "       Incorrect password.";

        //    Label2.Visible = true;
        //}
    }
}
