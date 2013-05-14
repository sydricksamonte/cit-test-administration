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

public partial class _Default : System.Web.UI.Page
{
    string naming = "";
    string user = ""; string exname = ""; string line = ""; int quiznexer = 0; int quiznexer2 = 0; string editmode = "0"; string course = "";
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
                naming = Page.Session["naming"].ToString();
            }
            catch { }
            if (Page.Session["exname"] == null)
            {
                Response.Redirect("InsCreateExam");

            }
            else
            {
                if (System.DateTime.Now.ToString().Contains("AM"))
                {
                    DropDownList9.SelectedValue = "AM";
                    DropDownList7.SelectedValue = "PM";

                }
                else
                {
                    DropDownList9.SelectedValue = "PM";
                    DropDownList7.SelectedValue = "AM";
                }
                {
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr.ReadLine();
                    SqlDataSource2.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                }
                exname = Page.Session["exname"].ToString();
                course = Page.Session["course"].ToString();
                user = Page.Session["user"].ToString();
                try
                {
                    editmode = Page.Session["editmode"].ToString();
                }
                catch { }

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
            string subcode = "";
            try
            {
                TextBox7.Text = exname.Substring(0, 50);
            }
            catch
            {
                TextBox7.Text = exname.Substring(0, 48);
            }

            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select  exname  COUNT From exams WHERE exname LIKE '" + "SEAT" + "%' and user_id = '" + user + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    quiznexer++;
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
                sql = "Select  exname   From exams WHERE exname LIKE '" + "QUIZ" + "%' and user_id = '" + user + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    quiznexer2++;
                    //Label16.Text = (Reader["exname"].ToString());
                    //quiznexer2 = Convert.ToInt32(Reader["exx"].ToString());
                    // Label16.Text = quiznexer2.ToString();
                }
                Reader.Close();
                Scon.Close();

            }
            if (naming == "1")
            {
                TextBox9.Text = System.DateTime.Now.ToShortTimeString().Replace("AM", "").Replace("PM", "").Trim();
                TextBox11.Text = System.DateTime.Now.AddHours(2).ToShortTimeString().Replace("AM", "").Replace("PM", "").Trim();
                TextBox10.Text = System.DateTime.Now.ToShortDateString();
                TextBox13.Text = System.DateTime.Now.AddDays(1).ToShortDateString();
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From course_data WHERE course_id = '" + course + "' ";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        if (exname.Contains("QUIZ"))
                        {
                            if (editmode == "2")
                            {
                                //    quiznexer2 = int.Parse(Reader["made"].ToString());
                                quiznexer2++;
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " #" + quiznexer2 + " (" + System.DateTime.Now.ToShortDateString() + ")";
                            }
                            else
                            {
                                //    quiznexer = int.Parse(Reader["made"].ToString());
                                quiznexer2++;
                                TextBox3.Text = Reader["course_desc"].ToString() + " QUIZ# " + quiznexer2;
                            }
                        }
                        else if (exname.Contains("SEAT"))
                        {
                            if (editmode == "2")
                            {
                                //   quiznexer = int.Parse(Reader["made"].ToString());
                                quiznexer++;
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " #" + quiznexer + " (" + System.DateTime.Now.ToShortDateString() + ")";
                            }
                            else
                            {
                                //quiznexer = int.Parse(Reader["made"].ToString());
                                quiznexer++;
                                TextBox3.Text = Reader["course_desc"].ToString() + " SEATWORK# " + quiznexer;
                            }

                        }
                        else if (exname.Contains("EXAM_1"))
                        {
                            if (editmode == "2")
                            {
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " 1ST LONG EXAMINATION" + " (" + System.DateTime.Now.ToShortDateString() + ")";

                            }
                            else
                            {
                                TextBox3.Text = Reader["course_desc"].ToString() + " 1ST LONG EXAMINATION";

                            }
                        }
                        else if (exname.Contains("EXAM_2"))
                        {
                            if (editmode == "2")
                            {
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " 2ND LONG EXAMINATION" + " (" + System.DateTime.Now.ToShortDateString() + ")";

                            }
                            else
                            {
                                TextBox3.Text = Reader["course_desc"].ToString() + " 2ND LONG EXAMINATION";

                            }
                        }
                        else if (exname.Contains("EXAM_3"))
                        {
                            if (editmode == "2")
                            {
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " 3RD LONG EXAMINATION" + " (" + System.DateTime.Now.ToShortDateString() + ")";

                            }
                            else
                            {
                                TextBox3.Text = Reader["course_desc"].ToString() + " 3RD LONG EXAMINATION";

                            }
                        }
                        else if (exname.Contains("EXAM_4"))
                        {
                            if (editmode == "2")
                            {
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " 4TH LONG EXAMINATION" + " (" + System.DateTime.Now.ToShortDateString() + ")";

                            }
                            else
                            {
                                TextBox3.Text = Reader["course_desc"].ToString() + " 4TH LONG EXAMINATION";

                            }
                        }
                        else if (exname.Contains("EXAM_5"))
                        {
                            if (editmode == "2")
                            {
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " 5TH LONG EXAMINATION" + " (" + System.DateTime.Now.ToShortDateString() + ")";

                            }
                            else
                            {
                                TextBox3.Text = Reader["course_desc"].ToString() + " 5TH LONG EXAMINATION";

                            }
                        }
                        else if (exname.Contains("EXAM_F"))
                        {
                            if (editmode == "2")
                            {
                                TextBox3.Text = "MODIFIED " + Reader["course_desc"].ToString() + " FINAL EXAMINATION" + " (" + System.DateTime.Now.ToShortDateString() + ")";

                            }
                            else
                            {
                                TextBox3.Text = Reader["course_desc"].ToString() + " FINAL EXAMINATION";

                            }
                        }

                    }
                    Reader.Close();
                    Scon.Close();

                }
            }
        }
        naming = "2";
        Page.Session["naming"] = "2";
        allow = "CLOSE";
        Button1.Enabled = true;
    }
    DateTime dt = new DateTime();
    DateTime p1;
    DateTime p2;
    string dateA;
    string pname = "";
    bool wronged = false;
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.Session["naming"] = "2";
       
         if (naming == "2")
        {
            
            pname = TextBox3.Text;
            Label9.Text = pname;
        }
        try
        {
          p1=  Convert.ToDateTime(TextBox10.Text + " " + TextBox9.Text + DropDownList9.Text);
          p2= Convert.ToDateTime(TextBox13.Text + " " + TextBox11.Text + DropDownList9.Text);
        }
        catch { wronged=true;}
        try
        {
            Label8.Visible = true;
            TextBox4.Text = System.DateTime.Now.ToString();
            TextBox2.Text = dt.ToString();
        }
        catch
        {
            Label8.Visible = true;
        }
        if (TextBox3.Text.Length <= 7)
        {
            Label1.Text = "Please enter a more meaningful name.";
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Visible = true;
            TextBox3.Focus();
          
        }
        else if (wronged==true)
        {
            MessageBox(Label22.Text);
            Page.Session["naming"] = "1";
            naming = "1";
          //  Label22.Visible = true;

        }
      
        else if (TextBox6.Text == "")
        {
            Label1.Text = "Please enter duration ";
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Visible = true;
            DropDownList4.Focus();

        }
        else if ((TextBox8.Text.Contains("a")) || (TextBox8.Text.Contains("d")) || (TextBox8.Text.Contains("q")) || (TextBox8.Text.Contains("x")) || (TextBox8.Text.Contains("r")) || (TextBox8.Text.Contains("v")) || (TextBox8.Text.Contains("f")) || (TextBox8.Text.Contains("r")) || (TextBox8.Text.Contains("h")) || (TextBox8.Text.Contains("j")) || (TextBox8.Text.Contains("n")) || (TextBox8.Text.Contains("m")) || (TextBox8.Text.Contains("i")) || (TextBox8.Text.Contains("o")))
        {
            Label1.Text = "Error in item reduction.";
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Visible = true;
            DropDownList4.Focus();

        }
        else if (DropDownList6.SelectedIndex==-1)
        {
            Label1.Text = "Please choose a section";
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Visible = true;
            DropDownList6.Focus();

        }
        else
        {
            //try
            {
                Button1.Enabled = false;

                if (RadioButton1.Checked == true)
                {
                    allow = "CLOSE";
                }
                if (RadioButton2.Checked == true)
                {
                    allow = "OPEN";

                } Button1.Enabled = false;

                {

                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "DELETE FROM exam_results WHERE exam_code = '" + exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                    Scon.Close();
                    Reader.Close();
                }
                string logUser = ""; 
                {
                    SqlConnection Scon77;
                    SqlDataReader Reader77;
                    SqlCommand Cmd77; StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr77.ReadLine();
                    string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql77;
                    sql77 = "Select * From user_table WHERE user_id = '" + user+ "' ";
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
                    sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Published exam "+pname+ "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
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
                    sql = "Select * From classlist WHERE sec = '" + DropDownList6.SelectedValue.ToString() + "' AND  prof_id = '" + user + "' AND  course_code = '" + DropDownList5.SelectedValue.ToString() + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        SqlConnection Scon2;
                        SqlDataReader Reader2;
                        SqlCommand Cmd2;
                        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                        string sql2;
                        sql2 = "Insert Into exam_results VAlUES('" + exname + ":" + Reader["stud_id"].ToString() + ":" + Label15.Text + ":" + Label14.Text + "','" + Reader["stud_id"].ToString() + "','" + exname + "','" + "" + "','" + 0 + "','" + pname.ToUpper() + "','" + Label15.Text + "','" + Label14.Text + "','" + "NOT TAKEN" + "','" + 0 + "','" + TextBox6.Text.Trim() + ":0000" + "')";
                        Scon2 = new SqlConnection(sConnection2);
                        Scon2.Open();
                        Cmd2 = new SqlCommand(sql2, Scon2);
                        Reader2 = Cmd2.ExecuteReader();
                        Reader2.Close();
                        Scon2.Close();


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
                    sql = "Insert Into exams VAlUES('" + exname + "','" + TextBox4.Text + "','" + user + "','" + TextBox6.Text + ":0000" + "','" + pname.ToUpper() + "','" + allow + "','" + 0 + "','" + TextBox12.Text.Trim() + "')";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
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
                    sql = "Insert Into exam_period VAlUES('" + exname + "','" + p1 + "','" + p2 + "')";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
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
                    sql = "Insert Into [ratio] VAlUES('" + exname + "','" + "NA" + "')";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                    Reader.Close();
                    Scon.Close();
                }
                {
                    SqlConnection Scon;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "UPDATE  question_table SET p_date ='" + System.DateTime.Now.ToShortDateString() + "' WHERE ins_id = '" + user + "' AND exam_code='" + exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Cmd.ExecuteNonQuery();

                    Scon.Close();

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
                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr3.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Insert Into exam_reduce VAlUES('" + exname + "','" + TextBox8.Text.Trim() + "')";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    Reader2.Close();
                    Scon2.Close();

                }
                int classcount = 0;
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From classlist WHERE course_code = '" + Label14.Text + "' AND sec = '" + Label15.Text + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                  
                    while (Reader.Read())
                    {

                        classcount++;
                    }
                    Reader.Close();
                    Scon.Close();
                }

                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Select * From question_table WHERE exam_code = '" + exname + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                      //  ques = Reader2["ques_desc"].ToString();
                      //  ans = Reader2["ans_a"].ToString();
                        {

                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Insert Into [stud_perc] VAlUES('" + exname + "','" + Reader2["ques_id"].ToString() + "','" + 0 + "','" + classcount + "','" + 0 + "','" + Label14.Text + "','" + Label15.Text +"')";
                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();
                            Reader.Close();
                            Scon.Close();
                        }
                    }
                    Reader2.Close();
                    Scon2.Close();
                }
                {
                    Random rn = new Random();
                    int rnVal=0;
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Select * From question_table WHERE exam_code = '" + exname + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() != "") && (Reader2["ans_d"].ToString() != "") && (Reader2["ans_e"].ToString() != ""))
                        {
                            rnVal = rn.Next(1, 6);
                            {

                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 4)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {

                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 4)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() != "") && (Reader2["ans_d"].ToString() != "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            rnVal = rn.Next(1, 5);
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() != "") && (Reader2["ans_d"].ToString() == "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            rnVal = rn.Next(1, 4);
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() == "") && (Reader2["ans_d"].ToString() == "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            rnVal = rn.Next(1, 3);
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() == "") && (Reader2["ans_c"].ToString() == "") && (Reader2["ans_d"].ToString() == "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            {

                                SqlConnection Scon;
                                SqlDataReader Reader;
                                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql;
                                sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A"+"','" + "_____________________" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                Scon = new SqlConnection(sConnection);
                                Scon.Open();
                                Cmd = new SqlCommand(sql, Scon);
                                Reader = Cmd.ExecuteReader();
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
                                sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B"+"','" + "_____________________" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                Scon = new SqlConnection(sConnection);
                                Scon.Open();
                                Cmd = new SqlCommand(sql, Scon);
                                Reader = Cmd.ExecuteReader();
                                Reader.Close();
                                Scon.Close();
                            }
                        }

                        //  ques = Reader2["ques_desc"].ToString();
                        //  ans = Reader2["ans_a"].ToString();
                        
                    }
                    Reader2.Close();
                    Scon2.Close();
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
                    sql = "Select * From question_table WHERE exam_code = '" + exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        {
                            SqlConnection Scon2;
                            SqlDataReader Reader2;
                            SqlCommand Cmd2;
                            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                            string sql2;
                            sql2 = "Insert Into it_anal VAlUES('" + terms + ":" + DropDownList5.Text + ":" + DropDownList6.Text + ":" + Reader["ques_id"].ToString() + "','" + "0" + "','" + "0" + "','" + Reader["ques_id"].ToString() + "','" + exname + "')";
                            Scon2 = new SqlConnection(sConnection2);
                            Scon2.Open();
                            Cmd2 = new SqlCommand(sql2, Scon2);
                            try
                            {
                                Reader2 = Cmd2.ExecuteReader();
                                Reader2.Close();
                                Scon2.Close();
                            }
                            catch { }

                        }
                    }
                    Reader.Close();
                    Scon.Close();
                }
                Page.Session["user"] = user;
                Page.Session["message"] = "Published successfully.";
                Response.Redirect("InsCreateExam.aspx");

                Button1.Enabled = false;
                Label1.Text = "Published successfully.";
                Label1.ForeColor = System.Drawing.Color.LimeGreen;
                Label1.Visible = true;
            }
            //catch
            //{
            //    Label1.Text = "An error has ocurred.";
            //    Label1.ForeColor = System.Drawing.Color.Red;
            //    Label1.Visible = true;
            //    Button1.Enabled = true;

              
             
            //}
        }
    }
    DateTime datess;

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label8.Visible = false;

         //   dateA = Convert.ToDateTime(CalendarPopup1.SelectedDate).ToShortDateString();
        //    string hourA = MaskedTextBox1.Text + " " + DropDownList2.SelectedValue.ToString();
       //     dt = Convert.ToDateTime(dateA + " " + hourA);

     //       dt = Convert.ToDateTime(dateA + " " + hourA);
          
        }
        catch
        {
            Label8.Visible = true;
        }
        if (DropDownList1.SelectedIndex == 0)
        {
        //    CalendarPopup2.Enabled = true;
            DropDownList3.Enabled = true;
        //    MaskedTextBox3.Enabled = true;
            
        }
        if (DropDownList1.SelectedIndex ==1)
        {
         //   CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
       //     MaskedTextBox3.Enabled = false;
            datess = dt.AddHours(1);
            string timeVal= datess.ToShortTimeString();
            timeVal= timeVal.Remove(5);
        //    MaskedTextBox3.Text = timeVal;
       //     CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);
         
            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
        if (DropDownList1.SelectedIndex == 2)
        {
          //  CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
     //       MaskedTextBox3.Enabled = false;
            datess = dt.AddHours(2);
            string timeVal = datess.ToShortTimeString();
            timeVal = timeVal.Remove(5);
       //     MaskedTextBox3.Text = timeVal;
            //CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);

            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
        if (DropDownList1.SelectedIndex == 3)
        {
          //  CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
      //      MaskedTextBox3.Enabled = false;
            datess = dt.AddHours(5);
            string timeVal = datess.ToShortTimeString();
            timeVal = timeVal.Remove(5);
     //       MaskedTextBox3.Text = timeVal;
       //     CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);

            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
        if (DropDownList1.SelectedIndex == 4)
        {
         //   CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
       //     MaskedTextBox3.Enabled = false;
            datess = dt.AddDays(1);
            string timeVal = datess.ToShortTimeString();
            timeVal = timeVal.Remove(5);
        //    MaskedTextBox3.Text = timeVal;
         //   CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);

            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
        if (DropDownList1.SelectedIndex == 5)
        {
         //   CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
        //    MaskedTextBox3.Enabled = false;
            datess = dt.AddDays(2);
            string timeVal = datess.ToShortTimeString();
            timeVal = timeVal.Remove(5);
        //    MaskedTextBox3.Text = timeVal;
          //  CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);

            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
        if (DropDownList1.SelectedIndex == 6)
        {
        //    CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
          //  MaskedTextBox3.Enabled = false;
            datess = dt.AddDays(5);
            string timeVal = datess.ToShortTimeString();
            timeVal = timeVal.Remove(5);
       //     MaskedTextBox3.Text = timeVal;
          //  CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);

            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
        if (DropDownList1.SelectedIndex == 7)
        {
         //   CalendarPopup2.Enabled = false;
            DropDownList3.Enabled = false;
        //    MaskedTextBox3.Enabled = false;
            datess = dt.AddDays(7);
            string timeVal = datess.ToShortTimeString();
            timeVal = timeVal.Remove(5);
       //     MaskedTextBox3.Text = timeVal;
        //    CalendarPopup2.SelectedDate = datess.Date;
            string timeAM = datess.ToShortTimeString();
            timeAM = timeAM.Substring(6);

            if (timeAM == "AM")
            {
                DropDownList3.SelectedIndex = 0;
            }
            else if (timeAM == "PM")
            {
                DropDownList3.SelectedIndex = 1;
            }
        }
     //   string dateB = Convert.ToDateTime(CalendarPopup2.SelectedDate).ToShortDateString();
   //     string hourB = MaskedTextBox3.Text + " " + DropDownList3.SelectedValue.ToString();
    //    TextBox1.Text = Convert.ToDateTime(dateB + " " + hourB).ToString();
     
        //TextBox1.Text = datess.ToString();
        TextBox2.Text = dt.ToString();
    }
    protected void MaskedTextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CalendarPopup1_DateChanged(object sender, EventArgs e)
    {
        {
        //    CalendarPopup2.LowerBoundDate = CalendarPopup1.SelectedDate;
            string vv = System.DateTime.Now.ToShortTimeString();
            vv = vv.Remove(5);

       //     MaskedTextBox1.Text = vv;
            string times = System.DateTime.Now.ToShortTimeString();
            times = times.Substring(6);

            if (times == "AM")
            {
                DropDownList2.SelectedIndex = 0;
            }
            else if (times == "PM")
            {
                DropDownList2.SelectedIndex = 1;
            }
        }
        {
            try
            {
                Label8.Visible = false;

            //    dateA = Convert.ToDateTime(CalendarPopup1.SelectedDate).ToShortDateString();
         //       string hourA = MaskedTextBox1.Text + " " + DropDownList2.SelectedValue.ToString();
         //       dt = Convert.ToDateTime(dateA + " " + hourA);

          //      dt = Convert.ToDateTime(dateA + " " + hourA);

            }
            catch
            {
                Label8.Visible = true;
            }
            if (DropDownList1.SelectedIndex == 0)
            {
           //     CalendarPopup2.Enabled = true;
                DropDownList3.Enabled = true;
         //       MaskedTextBox3.Enabled = true;

            }
            if (DropDownList1.SelectedIndex == 1)
            {
          //      CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
          //      MaskedTextBox3.Enabled = false;
                datess = dt.AddHours(1);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
          //      MaskedTextBox3.Text = timeVal;
          //      CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
            if (DropDownList1.SelectedIndex == 2)
            {
        //        CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
           //     MaskedTextBox3.Enabled = false;
                datess = dt.AddHours(2);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
          //      MaskedTextBox3.Text = timeVal;
           //     CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
            if (DropDownList1.SelectedIndex == 3)
            {
            //    CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
          //      MaskedTextBox3.Enabled = false;
                datess = dt.AddHours(5);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
         //       MaskedTextBox3.Text = timeVal;
        //        CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
            if (DropDownList1.SelectedIndex == 4)
            {
           //     CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
       //         MaskedTextBox3.Enabled = false;
                datess = dt.AddDays(1);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
         //       MaskedTextBox3.Text = timeVal;
          //      CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
            if (DropDownList1.SelectedIndex == 5)
            {
         //       CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
           //     MaskedTextBox3.Enabled = false;
                datess = dt.AddDays(2);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
           //     MaskedTextBox3.Text = timeVal;
           //     CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
            if (DropDownList1.SelectedIndex == 6)
            {
           //     CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
         //       MaskedTextBox3.Enabled = false;
                datess = dt.AddDays(5);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
       //         MaskedTextBox3.Text = timeVal;
          //      CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
            if (DropDownList1.SelectedIndex == 7)
            {
           //     CalendarPopup2.Enabled = false;
                DropDownList3.Enabled = false;
         //       MaskedTextBox3.Enabled = false;
                datess = dt.AddDays(7);
                string timeVal = datess.ToShortTimeString();
                timeVal = timeVal.Remove(5);
           //     MaskedTextBox3.Text = timeVal;
           //     CalendarPopup2.SelectedDate = datess.Date;
                string timeAM = datess.ToShortTimeString();
                timeAM = timeAM.Substring(6);

                if (timeAM == "AM")
                {
                    DropDownList3.SelectedIndex = 0;
                }
                else if (timeAM == "PM")
                {
                    DropDownList3.SelectedIndex = 1;
                }
            }
         //   string dateB = Convert.ToDateTime(CalendarPopup2.SelectedDate).ToShortDateString();
      //      string hourB = MaskedTextBox3.Text + " " + DropDownList3.SelectedValue.ToString();
        //    TextBox1.Text = Convert.ToDateTime(dateB + " " + hourB).ToString();

            //TextBox1.Text = datess.ToString();
            TextBox2.Text = dt.ToString();
        }
    
    }
    protected void changeDur(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedIndex == 0)
        {
            TextBox6.Enabled = true;
            TextBox6.Text = "00:30";
        }
        else if (DropDownList4.SelectedIndex == 1)
        {
            TextBox6.Enabled = false;
            TextBox6.Text = "00:30";
        }
        else if (DropDownList4.SelectedIndex == 2)
        {
            TextBox6.Enabled = false;
            TextBox6.Text = "01:00";
        }
        else if (DropDownList4.SelectedIndex == 3)
        {
            TextBox6.Enabled = false;
            TextBox6.Text = "01:30";
        }
        else if (DropDownList4.SelectedIndex == 4)
        {
            TextBox6.Enabled = false;
            TextBox6.Text = "02:00";
        }
        else if (DropDownList4.SelectedIndex == 5)
        {
            TextBox6.Enabled = false;
            TextBox6.Text = "04:00";
        }
        else if (DropDownList4.SelectedIndex == 6)
        {
            TextBox6.Enabled = false;
            TextBox6.Text = "05:00";
        }
    }
    bool nivea = false;
    protected void DropDownList6_DataBound(object sender, EventArgs e)
    {
        try
        {
            DropDownList6.SelectedIndex = 0;
            Label15.Text = DropDownList6.SelectedValue.ToString();
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From classlist where prof_id ='" + user + "' AND sec = '" + DropDownList6.SelectedValue.ToString() + "' and course_code ='" + DropDownList5.SelectedValue.ToString() + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {

                    nivea = true;
                }
                Reader.Close();
                Scon.Close();
            }
        }
        catch { }
        if (nivea == false)
        {
            
            Panel3.Visible = false;
            Label3.Visible = true;
            Panel4.Visible = true;
            DropDownList6.Visible = false;
            DropDownList5.Visible = false;
            Label12.Visible = false;
            Button1.Enabled = false;
            Label16.Visible = false;
            TextBox12.Visible = false;
            RequiredFieldValidator1.Visible = false;
            RadioButton2.Visible = false;
            RadioButton1.Visible = false;
            Label9.Visible = false;
            DropDownList4.Visible = false;
            TextBox6.Visible = false;
            RadioButton3.Focus();
        }
        else
        {
            Panel3.Visible = true;
            Label3.Visible = false;
            Panel4.Visible = false;
            DropDownList6.Visible = true;
            Label12.Visible = true;
            DropDownList5.Visible = true;
            Button1.Enabled = true;
            Label16.Visible = true;
            TextBox12.Visible = true;
            RequiredFieldValidator1.Visible = true;
            RadioButton2.Visible = true;
            RadioButton1.Visible = true;
            Label9.Visible = true;
            DropDownList4.Visible = true;
            TextBox6.Visible = true;
        }


    }
    protected void DropDownList5_DataBound(object sender, EventArgs e)
    {
        DropDownList5.SelectedIndex = 0;
        Label14.Text = DropDownList5.SelectedValue.ToString();
        DropDownList6.DataBind();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList6.AppendDataBoundItems = false;
        Label14.Text = DropDownList5.SelectedValue.ToString();
    }
    string allow = "";
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        allow = "OPEN";
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        allow = "CLOSE";
        
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (RadioButton5.Checked == true)
        {
            Response.Redirect("InsCreateExam.aspx");

        }

        if (RadioButton3.Checked == true)
        {
            try
            {
                Page.Session["editmode"] = editmode;
            }
            catch { }
            Page.Session["exname"] = exname;
           Page.Session["course"]=course;
           Page.Session["section"] = DropDownList6.Text;
            Page.Session["user"] = user;
            Page.Session["operation"] = "1";
            Response.Redirect("Classlists.aspx");
          
        }
        int redirector = 0;
        if (RadioButton4.Checked == true)
        {
          
            {
                {
                    SqlConnection Scon;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "UPDATE  question_table SET p_date ='" + System.DateTime.Now.ToShortDateString() + "' WHERE ins_id = '" + user + "' AND exam_code='" + exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Cmd.ExecuteNonQuery();
                    Scon.Close();
                   
                }
                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                    string sql2;
                    sql2 = "Insert Into exam_results VAlUES('" + exname + ":" +"REP" + ":" + Label15.Text + ":" + Label14.Text + "','" + "REPIDONLY12343212345678765" + "','" + exname + "','" + "" + "','" + 0 + "','" + TextBox3.Text.ToUpper() + "','" + Label15.Text + "','" + Label14.Text + "','" + "NOT TAKEN" + "','" + 0 + "','" + TextBox6.Text.Trim() + ":0000" + "')";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    Reader2.Close();
                    Scon2.Close();
                }
                {
                    Random rn = new Random();
                    int rnVal = 0;
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Select * From question_table WHERE exam_code = '" + exname + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() != "") && (Reader2["ans_d"].ToString() != "") && (Reader2["ans_e"].ToString() != ""))
                        {
                            rnVal = rn.Next(1, 6);
                            {

                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 4)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {

                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 4)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_e"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() != "") && (Reader2["ans_d"].ToString() != "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            rnVal = rn.Next(1, 5);
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 3)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_d"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() != "") && (Reader2["ans_d"].ToString() == "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            rnVal = rn.Next(1, 4);
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else if (rnVal == 2)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_c"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_c"].ToString() + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() != "") && (Reader2["ans_c"].ToString() == "") && (Reader2["ans_d"].ToString() == "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            rnVal = rn.Next(1, 3);
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                            {
                                if (rnVal == 1)
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_b"].ToString() + "','" + Reader2["ans_a"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                                else
                                {


                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql;
                                    sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ans_b"].ToString() + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql, Scon);
                                    Reader = Cmd.ExecuteReader();
                                    Reader.Close();
                                    Scon.Close();

                                }
                            }
                        }
                        else if ((Reader2["ans_a"].ToString() != "") && (Reader2["ans_b"].ToString() == "") && (Reader2["ans_c"].ToString() == "") && (Reader2["ans_d"].ToString() == "") && (Reader2["ans_e"].ToString() == ""))
                        {
                            {

                                SqlConnection Scon;
                                SqlDataReader Reader;
                                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql;
                                sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "A" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "A" + "','" + "_____________________" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                Scon = new SqlConnection(sConnection);
                                Scon.Open();
                                Cmd = new SqlCommand(sql, Scon);
                                Reader = Cmd.ExecuteReader();
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
                                sql = "Insert Into [exam_report] VAlUES('" + user + "','" + exname + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "B" + "','" + Reader2["typeEx"].ToString() + "','" + Reader2["ques_id"].ToString() + "B" + "','" + "_____________________" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + Reader2["ans_a"].ToString() + "','" + Reader2["ques_desc"].ToString() + "','" + Reader2["l_o"].ToString() + "','" + Reader2["c_o"].ToString() + "','" + Reader2["pt"].ToString() + "')";
                                Scon = new SqlConnection(sConnection);
                                Scon.Open();
                                Cmd = new SqlCommand(sql, Scon);
                                Reader = Cmd.ExecuteReader();
                                Reader.Close();
                                Scon.Close();
                            }
                        }

                        //  ques = Reader2["ques_desc"].ToString();
                        //  ans = Reader2["ans_a"].ToString();

                    }
                    Reader2.Close();
                    Scon2.Close();
                }
                {

                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Insert Into exams VAlUES('" + exname + "','" + System.DateTime.Now.ToString() + "','" + user + "','" + "00:00:0000" + "','" + TextBox3.Text.Trim().ToUpper() + "','" + "PRINT 0NLY" + "','" + 0 + "','" + "NOTFORETEST" + "')";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                }
              
                {
                    Page.Session["message"] = "Printout has been created.";
                    redirector = 1;
                }
                if (redirector == 1)
                {
                    Response.Redirect("InsReports.aspx");
                }

            }
        }

    }
}
