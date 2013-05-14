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
    string user = ""; string exname = ""; string term = "";
    string dater;
    string moki = ""; string line = ""; string secret = ""; DateTime d1;
    DateTime d2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {

            Response.Redirect("LogIn.aspx");
        }
        else
        {

            //if (Page.Session["exname"] == null)
            //{


            //}
            //else
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
                 
                }
                Reader.Close();
                Scon.Close();

            }
            {

                //exname = Page.Session["exname"].ToString();
                secret = Page.Session["secret"].ToString();
                user = Page.Session["user"].ToString();
                Panel3.Visible = false;
                int i = 0;
                string  x = "";
                {

                    SqlConnection Scon9;
                    SqlDataReader Reader9;
                    SqlCommand Cmd9; StreamReader sr9 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                    line = sr9.ReadLine();
                    string sConnection9 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                    string sql9;
                    sql9 = "Select * From exams WHERE frameA LIKE '%" + "P" + "%' AND pass = '"+secret+"'";
                    Scon9 = new SqlConnection(sConnection9);
                    Scon9.Open();
                    Cmd9 = new SqlCommand(sql9, Scon9);
                    Reader9 = Cmd9.ExecuteReader();
                    while (Reader9.Read())
                    {
                        x = Reader9["frameB"].ToString();

                        {
                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "SELECT  exam_results.* , exam_period.period1,exam_period.period2 FROM  exam_period INNER JOIN  exam_results ON exam_period.exname = exam_results.exam_code  WHERE take_no <= '" + Convert.ToInt32(x) + "' AND user_id = '" + user + "' AND exam_code = '" + Reader9["exname"].ToString() + "'AND exam_code LIKE '%" +term + "%'  AND  d_close LIKE '%" + "O" + "%'";
                        //    "Select * From exam_results
                            //     sql = "Select * From exam_results WHERE take_no <= '" + Convert.ToInt32(OpenNo) + "' and  user_id = '" + user + "'";

                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();

                            while (Reader.Read())
                            {
                                if ((System.DateTime.Now > (Convert.ToDateTime(Reader["period1"].ToString()))) && ((System.DateTime.Now < (Convert.ToDateTime(Reader["period2"].ToString())))))
                                {
                                    DropDownList1.Items.Add(Reader["pname"].ToString());

                                    Panel3.Visible = true;
                                }
                                //i++;
                                //SqlConnection Scon2;
                                //SqlDataReader Reader2;
                                //SqlCommand Cmd2;


                                //StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                                //line = sr2.ReadLine();

                                //string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                                //string sql2;
                                //sql2 = "Select * From exams WHERE exname = '" + Reader["exam_code"].ToString() + "' AND  frameA = '" + "OPEN" + "'OR  frameA = '" + "RE-OPEN" + "'";
                                //Scon2 = new SqlConnection(sConnection2);
                                //Scon2.Open();
                                //Cmd2 = new SqlCommand(sql2, Scon2);
                                //Reader2 = Cmd2.ExecuteReader();
                                //while (Reader2.Read())
                                //{
                                //    DropDownList1.Items.Add(Reader2["pname"].ToString());
                                //    Panel3.Visible = true;

                                //}
                                //Reader2.Close();
                                //Scon2.Close();
                            }
                            Reader.Close();
                            Scon.Close();


                        }
                    }
                    Reader9.Close();
                    Scon9.Close();
                }
               
                //   Label1.Text = i.ToString();
                //   DropDownList1.Items.Clear();


                //try
                //{
                //    DropDownList1.SelectedIndex = 1;

                //}
                //catch
                //{
                //    //     DropDownList1.Items.Clear();
                //    DropDownList1.Items.Add("NO AVAILABLE EXAM");
                //    DropDownList1.SelectedIndex = 0;
                //}





            }
        }
        Panel2.Visible = false;
        {
            {
                string OpenNo = "0"; string tak = "";
               
                {

                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                    line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                    string sql2;
                    sql2 = "Select * From exams WHERE frameA = '" + "RE-OPEN" + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        OpenNo = Reader2["frameB"].ToString();
                        tak = Reader2["exname"].ToString();


                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                        line = sr66.ReadLine();
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Select DISTINCT pname AS COL From exam_results WHERE exam_code = '"+tak+"' and d_close = '"+"TAKEN"+"' and take_no <= '" + Convert.ToInt32(OpenNo) + "' and  user_id = '" + user + "'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();


                        while (Reader.Read())
                        {
                            //if (Reader["d_close"].ToString().Contains("PROGRESS"))
                            //{
                            //}
                            //else if (Reader["d_close"].ToString()==("NOT TAKEN"))
                            //{
                            //}
                            //else
                            {
                                Panel2.Visible = true;
                                DropDownList2.Items.Add(Reader["COL"].ToString());
                            }

                        }


                        Reader.Close();
                        Scon.Close();



                    }
                    Reader2.Close();
                    Scon2.Close();


                }
            }
        }
        if ((Panel2.Visible == false) && (Panel3.Visible == false))
        {
            Label1.Visible = true;
        }
        else
        {
            Label1.Visible = false;
        }

    }
    string lastN = ""; string hoku="";
    protected void Button1_Click(object sender, EventArgs e)
    {
      
        exname = DropDownList1.SelectedValue.ToString();
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; 
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exams WHERE pname = '" + exname + "'";
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

        }

      
        if ((exname.ToString()==""))
        {
            Label2.Visible = true;
        }
        else
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
                sql = "Select * From classlist WHERE stud_id = '" + user + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    lastN = Reader["stud_name"].ToString();
                    break;
                }

                Reader.Close();
                Scon.Close();

            }
            Label2.Visible = false;
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;


            string dtk = "";

            {

                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                line = sr66.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exam_results WHERE user_id = '" + user + "' and exam_code ='" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();


                while (Reader.Read())
                {

                    dtk = Reader["d_close"].ToString();
                    break;
                }


                Reader.Close();
                Scon.Close();


            }
            if (dtk == "NOT TAKEN")
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "UPDATE answers Set ans = '" + "" + "' Where user_id ='" + user + "' AND exam_code  = '" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
            }
            {

                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                line = sr2.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                string sql2;
                sql2 = "Select * From exams WHERE exname = '" + exname + "' AND  frameA = '" + "RE-OPEN" + "'";
                Scon2 = new SqlConnection(sConnection);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
                while (Reader2.Read())
                {
                    dtk = Reader2["frameA"].ToString();
                    break;

                }
                Reader2.Close();
                Scon2.Close();


            }
           
            if ((dtk == "NOT TAKEN") || (dtk == "RE-OPEN")||((dtk.Contains("PROGRESS")) ))
            {
              
                int redir = 0;
                {
                    {
                        {

                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd;
                            StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr2.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Select * From answers WHERE exam_code ='" + exname + "' AND  user_id = '" + user + "'  AND ans <> '" + "noanswerxxx" + "'";
                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();

                            while (Reader.Read())
                            {
                                hoku = Reader["ques_id"].ToString() + "','" + hoku + "','";
                            }

                            Reader.Close();
                            Scon.Close();
                            //Page.Session["hoku"] = hoku;
                        }
                       
                        redir = 1;
                        if (redir == 1)
                        {
                            if (System.DateTime.Now.Millisecond.ToString().EndsWith("1"))
                            {
                                Page.Session["extype"] = "ExamB"; Response.Redirect("Take.aspx"); 
                          
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("2"))
                            {
                                Page.Session["extype"] = "ExamC"; Response.Redirect("Take.aspx"); 
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("3"))
                            {
                                Page.Session["extype"] = "ExamD"; Response.Redirect("Take.aspx"); 
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("4"))
                            {
                                Page.Session["extype"] = "ExamE"; Response.Redirect("Take.aspx"); 
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("5"))
                            {
                                Page.Session["extype"] = "ExamF"; Response.Redirect("Take.aspx");
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("6"))
                            {
                                Page.Session["extype"] = "ExamG"; Response.Redirect("Take.aspx");
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("7"))
                            {
                                Page.Session["extype"] = "ExamH"; Response.Redirect("Take.aspx");
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("8"))
                            {
                                Page.Session["extype"] = "ExamI"; Response.Redirect("Take.aspx");
                            }
                            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("9"))
                            {
                                Page.Session["extype"] = "ExamJ"; Response.Redirect("Take.aspx");
                            }
                            else
                            {
                                Page.Session["extype"] = "ExamA";
                                Response.Redirect("Take.aspx"); 
                            }
                            
                        }
                        else { }
                    }
                  
                  

                }
            }
            else
            {
                Response.Redirect("Oops.aspx");
            }
          

        }

       
    }
    protected void DropDownList1_Load(object sender, EventArgs e)
    {
       // DropDownList1.Items.Clear();
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      exname = DropDownList1.SelectedValue.ToString();
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList1_PreRender(object sender, EventArgs e)
    {
      
    }

    protected void Button77_Click(object sender, EventArgs e)
    {
        string lastN = "";
        exname = DropDownList2.SelectedValue.ToString();
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exams WHERE pname = '" + exname + "'";
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

        }
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
                sql = "Select * From user_table WHERE user_id = '" + user + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    lastN = Reader["lname"].ToString();

                }

                Reader.Close();
                Scon.Close();

            }
            int frameB = 0;
            string durat = "";
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exams WHERE exname  = '" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    //frameB = Reader["frameB"].ToString();
                    durat = Reader["duration"].ToString();

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
                sql = "Select frameB From exams WHERE user_id = '" + user + "' AND pname='" + DropDownList2.SelectedValue.ToString() + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    frameB = int.Parse(Reader["frameB"].ToString());
                    frameB++;
                    break;
                }

                Reader.Close();
                Scon.Close();
            } string jj = "";
            {

                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                line = sr66.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exam_results WHERE user_id = '" + user + "' and exam_code ='" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();


                while (Reader.Read())
                {

                    jj = Reader["d_close"].ToString();
                    break;
                }


                Reader.Close();
                Scon.Close();


            }
            if ((jj == "TAKEN"))
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "UPDATE answers Set ans = '" + "" + "' Where user_id ='" + user + "' AND exam_code  = '" + exname + "'";
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

                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "UPDATE exam_results Set t_left = '" + durat + "',d_close = '" + "IN PROGRESS AS OF" + "' Where user_id ='" + user + "' AND exam_code  = '" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
            }
            string kk = "";
            {

                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                line = sr66.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exams WHERE user_id = '" + user + "' and exname ='" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();


                while (Reader.Read())
                {

                    kk = Reader["duration"].ToString();
                    break;
                }


                Reader.Close();
                Scon.Close();


            } 
            Label2.Visible = false;
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            if (System.DateTime.Now.Millisecond.ToString().EndsWith("1"))
            {
                Page.Session["extype"] = "ExamB"; Response.Redirect("Take.aspx");

            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("2"))
            {
                Page.Session["extype"] = "ExamC"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("3"))
            {
                Page.Session["extype"] = "ExamD"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("4"))
            {
                Page.Session["extype"] = "ExamE"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("5"))
            {
                Page.Session["extype"] = "ExamF"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("6"))
            {
                Page.Session["extype"] = "ExamG"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("7"))
            {
                Page.Session["extype"] = "ExamH"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("8"))
            {
                Page.Session["extype"] = "ExamI"; Response.Redirect("Take.aspx");
            }
            else if (System.DateTime.Now.Millisecond.ToString().EndsWith("9"))
            {
                Page.Session["extype"] = "ExamJ"; Response.Redirect("Take.aspx");
            }
            else
            {
                Page.Session["extype"] = "ExamA";
                Response.Redirect("Take.aspx");
            }

        }

    }
}
