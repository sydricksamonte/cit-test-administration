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
using System.Timers;


public partial class Exam : System.Web.UI.Page
{
    string user = ""; string exname = "";
    string names = "";
    int countLoad = 0;
    int countDone = 0;
    bool loaded = false;
    int answerLoader = 0; string line = ""; bool adder = false; string extype = ""; string hoku = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            int mm = 0;
            if (Page.Session["exname"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            else
            {
                exname = Page.Session["exname"].ToString();
                user = Page.Session["user"].ToString();

                try
                {
                    Label18.Visible = false; LinkButton1.Visible = false;

                    extype = Page.Session["extype"].ToString();
                    SqlDataSource1.SelectCommand = "SELECT question_table.ins_id, question_table.ques_id, question_table.exam_code, question_table.typeEx, question_table.ques_desc, question_table.ans_a, question_table.ans_b, question_table.ans_c, question_table.ans_d, question_table.ans_e, question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date, question_table.imgLoc, question_table.l_o, question_table.c_o, question_table.copy_type, question_table.pt, answers.ans FROM answers INNER JOIN question_table ON answers.ques_id = question_table.ques_id AND answers.exam_code = question_table.exam_code WHERE (answers.ans <> '" + "noanswerxxx" + "') AND (answers.user_id = '" + user + "') AND (question_table.exam_code = '" + exname + "')  ";
                    if (extype == "Fac")
                    {
                        Label18.Visible = true; Button3.Visible = false; GridView1.AllowPaging = false;
                        SqlDataSource1.SelectCommand = "SELECT * FROM question_table WHERE exam_code = '" + exname + "'";

                    }
                }
                catch
                {

                }
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                LinkButton2.Visible = false;
                Button3.Enabled = true;
                SqlDataSource1.ConnectionString = sConnection2;



                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Select * From answers WHERE  exam_code='" + exname + "' AND user_id ='" + user + "' AND ans <> '" + "noanswerxxx" + "'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        if (Reader6["ans"].ToString() != "noanswerxxx")
                        {
                            hoku = Reader6["ques_id"].ToString() + "','" + hoku + "','";
                            //   mm++;
                        }
                    }

                    Reader6.Close();
                    Scon6.Close();

                } //Label1.Text = mm.ToString();
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr2.ReadLine();
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
                        names = (Reader["stud_name"].ToString().ToUpper());

                    }

                    Reader.Close();
                    Scon.Close();

                }
                {

                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                    line = sr66.ReadLine();
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select t_left From exam_results WHERE exam_code = '" + exname + "' AND user_id ='" + user + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {

                        string strTime = Reader["t_left"].ToString();

                        string hour = strTime.Substring(0, 2);
                        string min = strTime.Substring(3, 2);
                        string secss = strTime.Substring(6);

                        int overall = 0;

                        int secc = int.Parse(secss);
                        int minn = int.Parse(min);
                        overall = minn * 60;
                        int hourr = int.Parse(hour);
                        overall = overall + (hourr * 60 * 60);
                        overall = overall + secc;

                        // Label13.Text = overall.ToString();
                        Label13.Text = overall.ToString();
                        Label12.Text = overall.ToString();
                        HiddenField2.Value = overall.ToString();
                        break;


                    }


                    Reader.Close();
                    Scon.Close();


                }



                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr3.ReadLine();
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From exam_results WHERE user_id = '" + user + "' AND exam_code ='" + exname + "' AND d_close ='" + "NOT TAKEN" + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        answerLoader = 1;


                    }

                    Reader.Close();
                    Scon.Close();
                }


                if (answerLoader == 1)
                {
                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/ExamsStud.aspx', null,'top=1,left=1,center=yes,resizable=no,Width=1024px,Height= 700px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

                    DateTakenWriter();

                }
            }

        }
       
     
      string ba = GridView1.PageIndex.ToString()+":"+ GridView1.PageCount.ToString();

     //   MessageBox(ba);
        ////"SELECT * FROM question_table WHERE exam_code = '" + exname + "' AND ques_id IN ('" + hoku + "' )";


    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    public void writeInfo()
    {
        
        Label txtCourse = GridView1.HeaderRow.FindControl("lblCourse") as Label;
        Label txtDesc = GridView1.HeaderRow.FindControl("lblTitle") as Label;
        Label txtterm = GridView1.HeaderRow.FindControl("lblTerm") as Label;
        Label txtName = GridView1.HeaderRow.FindControl("lblName") as Label;
        Label txtCC = GridView1.HeaderRow.FindControl("Label2") as Label;
        txtName.Text = names;
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
             string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exams WHERE exname = '" + exname + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                txtCC.Text = (Reader["pname"].ToString().ToUpper());
            }

            Reader.Close();
            Scon.Close();
        }
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; 
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
            line = sr.ReadLine();
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From exam_results WHERE exam_code = '" + exname + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2;
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = "Select * From course WHERE course_id = '" + Reader["course"].ToString().ToUpper() + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();

                while (Reader2.Read())
                {
                   txtDesc.Text = (Reader2["course_desc"].ToString().ToUpper());
                   // txtterm.Text = (Reader2["section"].ToString().ToUpper());
                    break;
                }

                Reader2.Close();
                Scon2.Close();

                txtCourse.Text = (Reader["course"].ToString().ToUpper());
                txtterm.Text = (Reader["section"].ToString().ToUpper());
            }

            Reader.Close();
            Scon.Close();
        }
    }
    string usType = "STUDENT"; string etona = "";

    public void DateTakenWriter()
    {
       
        int countItems = -1;
        string des = "";
        {

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; 
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  
            line = sr.ReadLine();
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From user_table WHERE user_id = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
               usType  = Reader["type"].ToString();
            }
            Reader.Close();
            Scon.Close();
        }
        if ((usType == "FACULTY") || (usType == "ADMIN"))
        {
            Button1.Visible = false;
            SqlDataSource1.SelectCommand = "SELECT * FROM question_table WHERE exam_code = '" + exname + "'";
          
            //"SELECT * FROM question_table WHERE exam_code = '" + exname + "' AND ques_id IN ('" + hoku + "' )";
            
        }
        else
        {
            int movred = 1;
            string reducer = "";
            {

                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                //  string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exam_reduce WHERE exname = '" + exname + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    reducer = Reader["count"].ToString();
                }
                Reader.Close();
                Scon.Close();
            }
            {

                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                //  string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exams WHERE exname = '" + exname + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    des = Reader["pname"].ToString();
                }
                Reader.Close();
                Scon.Close();
            }

            int i = 0;
           
            {

                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                if (reducer == "0")
                {
                    if (extype == "ExamB")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ans_a ASC";
                    }
                    else if (extype == "ExamC")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ques_desc DESC";
                    }
                    else if (extype == "ExamD")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ans_a DESC";
                    }
                    else if (extype == "ExamE")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ques_desc ASC";
                    }
                    else if (extype == "ExamF")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx ASC, ques_desc ASC";
                    }
                    else if (extype == "ExamG")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC, typeEx ASC, ans_a DESC";
                    }
                    else if (extype == "ExamH")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC, typeEx ASC, ans_a ASC";
                    }

                    else if (extype == "ExamI")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC,typeEx ASC, ques_desc DESC";
                    }
                    else if (extype == "ExamJ")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC,typeEx DESC, ques_desc ASC";
                    }
                    else
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ques_id DESC";
                    }
                }
                else
                {
                    if (extype == "ExamB")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ans_a ASC";
                    }
                    else if (extype == "ExamC")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ques_desc DESC";
                    }
                    else if (extype == "ExamD")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ans_a DESC";
                    }
                    else if (extype == "ExamE")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ques_desc ASC";
                    }
                    else if (extype == "ExamF")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx ASC, ques_desc ASC";
                    }
                    else if (extype == "ExamG")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC, typeEx ASC, ans_a DESC";
                    }
                    else if (extype == "ExamH")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC, typeEx ASC, ans_a ASC";
                    }

                    else if (extype == "ExamI")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC,typeEx ASC, ques_desc DESC";
                    }
                    else if (extype == "ExamJ")
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY  dif ASC,typeEx DESC, ques_desc ASC";
                    }
                    else
                    {
                        sql = " Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY dif ASC, typeEx DESC, ques_id DESC";
                    }

                }
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    {
                        SqlConnection Scon22;
                        SqlDataReader Reader22;
                        SqlCommand Cmd22;
                        StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr3.ReadLine();
                        string sConnection22 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql22;
                        sql22 = "Select * From exam_results WHERE user_id = '" + user + "' AND exam_code ='" + exname + "'AND d_close = '" + "NOT TAKEN" + "' AND d_taken NOT LIKE '" + "(" + "%' ";
                        Scon22 = new SqlConnection(sConnection22);
                        Scon22.Open();
                        Cmd22 = new SqlCommand(sql22, Scon22);
                        Reader22 = Cmd22.ExecuteReader();

                        while (Reader22.Read())
                        {
                            adder = true;
                        }

                        Reader22.Close();
                        Scon22.Close();
                    }

                    if (adder == true)
                    {

                        {
                            SqlConnection Scon2;
                            SqlDataReader Reader2;
                            SqlCommand Cmd2;
                            StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr3.ReadLine();
                            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql2;
                            sql2 = "Select * From course_topics WHERE week LIKE '" + Reader["l_outcomes"].ToString().Substring(0, 5) + "%' AND l_o ='" + Reader["l_o"].ToString() + "' ";
                            Scon2 = new SqlConnection(sConnection2);
                            Scon2.Open();
                            Cmd2 = new SqlCommand(sql2, Scon2);
                            Reader2 = Cmd2.ExecuteReader();

                            while (Reader2.Read())
                            {

                                etona = Reader2["topic_desc"].ToString();
                            }

                            Reader2.Close();
                            Scon2.Close();
                        }
                        try
                        {
                            if ((movred <= int.Parse(reducer)) || (reducer == "0"))
                            {
                                SqlConnection Scon2;
                                SqlDataReader Reader2;
                                SqlCommand Cmd2;
                                StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr3.ReadLine();
                                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql2;
                                sql2 = "Insert Into course_bulk VAlUES('" + exname + ":" + user + ":" + Reader["l_o"].ToString() + "','" + exname + "','" + user + "','" + Reader["ques_id"].ToString() + "','" + 0 + "','" + 0 + "','" + etona + "','" + 1 + "')";
                                Scon2 = new SqlConnection(sConnection2);
                                Scon2.Open();
                                Cmd2 = new SqlCommand(sql2, Scon2);
                                Reader2 = Cmd2.ExecuteReader();
                                Reader2.Close();
                                Scon2.Close();
                            }

                        }
                        catch { }

                        {
                            SqlConnection Scon2;
                            SqlDataReader Reader2;
                            SqlCommand Cmd2;
                            StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr3.ReadLine();
                            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql2;
                            if ((movred <= int.Parse(reducer)) || (reducer == "0"))
                            {
                                sql2 = "Insert Into answers VAlUES('" + user + "','" + exname + "','" + Reader["ques_id"].ToString() + "','" + null + "','" + etona + "')";
                            }
                            else
                            {
                                sql2 = "Insert Into answers VAlUES('" + user + "','" + exname + "','" + Reader["ques_id"].ToString() + "','" + "noanswerxxx" + "','" + etona + "')";
                            }

                            Scon2 = new SqlConnection(sConnection2);
                            Scon2.Open();
                            Cmd2 = new SqlCommand(sql2, Scon2);
                            Reader2 = Cmd2.ExecuteReader();
                            Reader2.Close();
                            Scon2.Close();
                            i++;
                        }
                    }
                    movred++;

                }
                Reader.Close();
                Scon.Close();
            }
            {
                SqlConnection Scon;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "UPDATE  exam_results SET d_taken ='" + System.DateTime.Now.ToString() + "',d_close ='" + "IN PROGRESS AS OF" + "' WHERE user_id = '" + user + "' AND exam_code='" + exname + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Cmd.ExecuteNonQuery();
                Scon.Close();
            }
        }


    }
    int correctCounter = 0;
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void lblqid_DataBinding(object sender, EventArgs e)
    {
      
    }
    int counter = -3;
    int items=10;
    Random rn = new Random();
    int ins = 0;
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
       


        if (Page.Session["exname"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {

            if (loaded == false)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    items = 10;
                    CheckBox txtA = (CheckBox)row.FindControl("txtA");
                    TextBox txtAns = (TextBox)row.FindControl("TextBox2");
                    CheckBox txtB = (CheckBox)row.FindControl("txtB");
                    CheckBox txtC = (CheckBox)row.FindControl("txtC");
                    CheckBox txtD = (CheckBox)row.FindControl("txtD");
                    CheckBox txtE = (CheckBox)row.FindControl("txtE");
                    CheckBox txtF = (CheckBox)row.FindControl("txtF");
                    CheckBox txtG = (CheckBox)row.FindControl("txtG");
                    CheckBox txtH = (CheckBox)row.FindControl("txtH");
                    CheckBox txtI = (CheckBox)row.FindControl("txtI");
                    CheckBox txtJ = (CheckBox)row.FindControl("txtJ");
                    CheckBox txtAA = (CheckBox)row.FindControl("AA");
                    Label lblqid = (Label)row.FindControl("Label6");
                    Label NUMER = (Label)row.FindControl("Label1");
                    HiddenField corAns = (HiddenField)row.FindControl("Cor");
                    HiddenField studAnsId = (HiddenField)row.FindControl("qid");
                    HiddenField Hidden = (HiddenField)row.FindControl("HiddenField1");
                    ImageButton Ima = (ImageButton)row.FindControl("ImageButton2");
                    writeInfo();
                    {
                        if (Hidden.Value.ToString() == "")
                        {
                            Ima.Visible = false;
                            Ima.ImageUrl = "";
                        }
                        else
                        {
                            Ima.Visible = true;
                            Ima.ImageUrl = Hidden.Value.ToString();

                        }


                        Label11.Text = corAns.Value.ToString();


                        counter = counter + 1;
                     //   NUMER.Text = counter.ToString() + ".";
                        {
                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd;
                            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Select * From question_table WHERE ques_desc = '" + lblqid.Text + "'";
                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();

                            while (Reader.Read())
                            {

                                Label8.Text = countLoad.ToString();
                                countLoad++;

                                // txtA.Text = Reader["ans_a"].ToString();


                                //   txtB.Text = Reader["ans_b"].ToString();

                                if ((Reader["ans_b"].ToString() == "") || (Reader["ans_b"] == null))
                                {
                                    items = items - 1;

                                    txtAns.Visible = true;
                                    txtA.Visible = false;
                                    txtB.Visible = false;
                                    txtC.Visible = false;
                                    txtD.Visible = false;
                                    txtE.Visible = false;
                                    txtF.Visible = false;
                                    txtG.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_c"].ToString() == "") || (Reader["ans_c"] == null))
                                {
                                    items = items - 1;
                                    //  txtAns.Visible = false;
                                    txtC.Visible = false;
                                    txtD.Visible = false;
                                    txtE.Visible = false;
                                    txtF.Visible = false;
                                    txtG.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }

                                if ((Reader["ans_d"].ToString() == "") || (Reader["ans_d"] == null))
                                {
                                    items = items - 1;// txtAns.Visible = false;
                                    txtD.Visible = false;
                                    txtE.Visible = false;
                                    txtF.Visible = false;
                                    txtG.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_e"].ToString() == "") || (Reader["ans_e"] == null))
                                {
                                    items = items - 1;// txtAns.Visible = false;
                                    txtE.Visible = false;
                                    txtF.Visible = false;
                                    txtG.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_f"].ToString() == "") || (Reader["ans_f"] == null))
                                {
                                    items = items - 1;// txtAns.Visible = false;
                                    txtF.Visible = false;
                                    txtG.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_g"].ToString() == "") || (Reader["ans_g"] == null))
                                {
                                    items = items - 1; //txtAns.Visible = false;
                                    txtG.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_h"].ToString() == "") || (Reader["ans_h"] == null))
                                {
                                    items = items - 1;// txtAns.Visible = false;
                                    txtH.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_i"].ToString() == "") || (Reader["ans_i"] == null))
                                {
                                    items = items - 1;// txtAns.Visible = false;
                                    txtJ.Visible = false;
                                    txtI.Visible = false;
                                }
                                if ((Reader["ans_j"].ToString() == "") || (Reader["ans_j"] == null))
                                {
                                    items = items - 1;// txtAns.Visible = false;
                                    txtJ.Visible = false;
                                }



                                int rand = rn.Next(1, items + 1);

                                Label10.Text = rand.ToString();
                                if (items == 1)
                                {
                                    if ((rand.ToString()) == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();

                                    }
                                    txtA.Visible = false;


                                }
                                else if (items == 2)
                                {
                                    if ((rand.ToString()) == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_b"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                    }
                                }
                                else if (items == 3)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_b"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_c"].ToString();
                                    }
                                }
                                else if (items == 4)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_b"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_c"].ToString();
                                        txtC.Text = Reader["ans_a"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_c"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_a"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                    }
                                }
                                else if (items == 5)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_e"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_a"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_c"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_e"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_a"].ToString();
                                    }
                                    else if (rand.ToString() == "5")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_e"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_a"].ToString();
                                    }
                                }
                                else if (items == 6)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_f"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_b"].ToString();
                                        txtF.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_a"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_c"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_c"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_b"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                    }
                                    else if (rand.ToString() == "5")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_e"].ToString();
                                        txtE.Text = Reader["ans_f"].ToString();
                                        txtF.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "6")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_e"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_b"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                    }
                                }
                                else if (items == 7)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_f"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_g"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_b"].ToString();
                                        txtF.Text = Reader["ans_e"].ToString();
                                        txtG.Text = Reader["ans_d"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_e"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_c"].ToString();
                                        txtC.Text = Reader["ans_e"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_f"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                    }
                                    else if (rand.ToString() == "5")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_e"].ToString();
                                        txtE.Text = Reader["ans_f"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "6")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_g"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_b"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "7")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_e"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                    }
                                }
                                else if (items == 8)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_f"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_g"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_h"].ToString();
                                        txtF.Text = Reader["ans_e"].ToString();
                                        txtG.Text = Reader["ans_d"].ToString();
                                        txtH.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_h"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_c"].ToString();
                                        txtC.Text = Reader["ans_e"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_f"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                    }
                                    else if (rand.ToString() == "5")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_e"].ToString();
                                        txtE.Text = Reader["ans_h"].ToString();
                                        txtF.Text = Reader["ans_f"].ToString();
                                        txtG.Text = Reader["ans_b"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                    }
                                    else if (rand.ToString() == "6")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_g"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_b"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_e"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                    }
                                    else if (rand.ToString() == "7")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_h"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                        txtH.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "8")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_e"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_h"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                    }
                                }
                                else if (items == 9)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_f"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                        txtI.Text = Reader["ans_i"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_g"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_h"].ToString();
                                        txtF.Text = Reader["ans_e"].ToString();
                                        txtG.Text = Reader["ans_d"].ToString();
                                        txtH.Text = Reader["ans_b"].ToString();
                                        txtI.Text = Reader["ans_i"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_h"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_i"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_e"].ToString();
                                        txtI.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_c"].ToString();
                                        txtC.Text = Reader["ans_e"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_f"].ToString();
                                        txtF.Text = Reader["ans_i"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                        txtI.Text = Reader["ans_a"].ToString();
                                    }
                                    else if (rand.ToString() == "5")
                                    {
                                        txtA.Text = Reader["ans_i"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_e"].ToString();
                                        txtE.Text = Reader["ans_h"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_b"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                        txtI.Text = Reader["ans_d"].ToString();
                                    }
                                    else if (rand.ToString() == "6")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_g"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_i"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_e"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                        txtI.Text = Reader["ans_b"].ToString();
                                    }
                                    else if (rand.ToString() == "7")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_h"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                        txtH.Text = Reader["ans_e"].ToString();
                                        txtI.Text = Reader["ans_i"].ToString();
                                    }
                                    else if (rand.ToString() == "8")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_e"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_i"].ToString();
                                        txtF.Text = Reader["ans_h"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                        txtI.Text = Reader["ans_c"].ToString();
                                    }
                                    else if (rand.ToString() == "9")
                                    {
                                        txtA.Text = Reader["ans_e"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_i"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_h"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                        txtI.Text = Reader["ans_c"].ToString();
                                    }
                                }
                                else if (items == 10)
                                {
                                    if (rand.ToString() == "1")
                                    {
                                        txtA.Text = Reader["ans_a"].ToString();
                                        txtB.Text = Reader["ans_b"].ToString();
                                        txtC.Text = Reader["ans_c"].ToString();
                                        txtD.Text = Reader["ans_d"].ToString();
                                        txtE.Text = Reader["ans_e"].ToString();
                                        txtF.Text = Reader["ans_f"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                        txtI.Text = Reader["ans_i"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }
                                    else if (rand.ToString() == "2")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_j"].ToString();
                                        txtC.Text = Reader["ans_g"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_h"].ToString();
                                        txtF.Text = Reader["ans_e"].ToString();
                                        txtG.Text = Reader["ans_d"].ToString();
                                        txtH.Text = Reader["ans_b"].ToString();
                                        txtI.Text = Reader["ans_i"].ToString();
                                        txtJ.Text = Reader["ans_a"].ToString();
                                    }
                                    else if (rand.ToString() == "3")
                                    {
                                        txtA.Text = Reader["ans_h"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_i"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_j"].ToString();
                                        txtI.Text = Reader["ans_b"].ToString();
                                        txtJ.Text = Reader["ans_e"].ToString();
                                    }
                                    else if (rand.ToString() == "4")
                                    {
                                        txtA.Text = Reader["ans_d"].ToString();
                                        txtB.Text = Reader["ans_c"].ToString();
                                        txtC.Text = Reader["ans_e"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_f"].ToString();
                                        txtF.Text = Reader["ans_i"].ToString();
                                        txtG.Text = Reader["ans_g"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                        txtI.Text = Reader["ans_a"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }
                                    else if (rand.ToString() == "5")
                                    {
                                        txtA.Text = Reader["ans_i"].ToString();
                                        txtB.Text = Reader["ans_a"].ToString();
                                        txtC.Text = Reader["ans_j"].ToString();
                                        txtD.Text = Reader["ans_e"].ToString();
                                        txtE.Text = Reader["ans_h"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_b"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                        txtI.Text = Reader["ans_d"].ToString();
                                        txtJ.Text = Reader["ans_c"].ToString();
                                    }
                                    else if (rand.ToString() == "6")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_g"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_c"].ToString();
                                        txtE.Text = Reader["ans_i"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_e"].ToString();
                                        txtH.Text = Reader["ans_h"].ToString();
                                        txtI.Text = Reader["ans_b"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }
                                    else if (rand.ToString() == "7")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_h"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_g"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                        txtH.Text = Reader["ans_e"].ToString();
                                        txtI.Text = Reader["ans_i"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }
                                    else if (rand.ToString() == "8")
                                    {
                                        txtA.Text = Reader["ans_f"].ToString();
                                        txtB.Text = Reader["ans_e"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_i"].ToString();
                                        txtF.Text = Reader["ans_h"].ToString();
                                        txtG.Text = Reader["ans_a"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                        txtI.Text = Reader["ans_c"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }
                                    else if (rand.ToString() == "9")
                                    {
                                        txtA.Text = Reader["ans_e"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_b"].ToString();
                                        txtE.Text = Reader["ans_i"].ToString();
                                        txtF.Text = Reader["ans_a"].ToString();
                                        txtG.Text = Reader["ans_h"].ToString();
                                        txtH.Text = Reader["ans_g"].ToString();
                                        txtI.Text = Reader["ans_c"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }
                                    else if (rand.ToString() == "10")
                                    {
                                        txtA.Text = Reader["ans_e"].ToString();
                                        txtB.Text = Reader["ans_f"].ToString();
                                        txtC.Text = Reader["ans_d"].ToString();
                                        txtD.Text = Reader["ans_g"].ToString();
                                        txtE.Text = Reader["ans_c"].ToString();
                                        txtF.Text = Reader["ans_h"].ToString();
                                        txtG.Text = Reader["ans_b"].ToString();
                                        txtH.Text = Reader["ans_i"].ToString();
                                        txtI.Text = Reader["ans_a"].ToString();
                                        txtJ.Text = Reader["ans_j"].ToString();
                                    }

                                }
                                else
                                {
                                    items = 10;
                                }

                                {
                                    SqlConnection Scon2;
                                    SqlDataReader Reader2;
                                    SqlCommand Cmd2;
                                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr4.ReadLine();

                                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql2;
                                    sql2 = "Select ans From answers WHERE ques_id = '" + studAnsId.Value.ToString() + "' and user_id ='" + user + "'and exam_code ='" + exname + "'";
                                    Scon2 = new SqlConnection(sConnection2);
                                    Scon2.Open();
                                    Cmd2 = new SqlCommand(sql2, Scon2);
                                    Reader2 = Cmd2.ExecuteReader();

                                    while (Reader2.Read())
                                    {

                                        string corr = Reader2["ans"].ToString();
                                        Label9.Text = txtA.Text + "cccaccc";
                                        Label8.Text = corr + "cccccc";
                                        if (txtAns.Visible == true)
                                        {
                                            txtAns.Text = corr;
                                            txtA.Checked = false;
                                            txtB.Checked = false;
                                            txtC.Checked = false;
                                            txtD.Checked = false;
                                            txtE.Checked = false;
                                            txtF.Checked = false;
                                            txtG.Checked = false;
                                            txtH.Checked = false;
                                            txtI.Checked = false;
                                            txtJ.Checked = false;
                                        }
                                        else
                                        {
                                            if (corr == txtA.Text)
                                            {
                                                txtA.Checked = true;
                                                txtB.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                            }
                                            else if (corr == txtB.Text)
                                            {
                                                txtB.Checked = true;
                                                txtA.Checked = false;

                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                            }
                                            else if (corr == txtC.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtC.Checked = true;


                                            }
                                            else if (corr == txtD.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtD.Checked = true;
                                            }
                                            else if (corr == txtE.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtE.Checked = true;
                                            }
                                            else if (corr == txtF.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtF.Checked = true;
                                            }
                                            else if (corr == txtG.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtG.Checked = true;
                                            }
                                            else if (corr == txtH.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtH.Checked = true;
                                            }
                                            else if (corr == txtI.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtI.Checked = true;
                                            }
                                            else if (corr == txtJ.Text)
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtJ.Checked = true;
                                            }
                                            else
                                            {
                                                txtB.Checked = false;
                                                txtA.Checked = false;
                                                txtC.Checked = false;
                                                txtD.Checked = false;
                                                txtE.Checked = false;
                                                txtF.Checked = false;
                                                txtG.Checked = false;
                                                txtH.Checked = false;
                                                txtI.Checked = false;
                                                txtJ.Checked = false;
                                                txtAA.Checked = true;


                                            }
                                        }


                                    }
                                    Reader2.Close();
                                    Scon2.Close();
                                }
                                break;

                            }
                            Reader.Close();
                            Scon.Close();
                        }
                    }
                }

            }
        }
        if (exname.Contains("EXAM_F"))
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                HiddenField txtA = (HiddenField)row.FindControl("qid");
                Label txtB = (Label)row.FindControl("Label16");

                {
                    SqlConnection Scon22;
                    SqlDataReader Reader22;
                    SqlCommand Cmd22;
                    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr3.ReadLine();
                    string sConnection22 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql22;
                    sql22 = "Select * From question_table WHERE   ques_id ='" + txtA.Value.ToString() + "'";
                    Scon22 = new SqlConnection(sConnection22);
                    Scon22.Open();
                    Cmd22 = new SqlCommand(sql22, Scon22);
                    Reader22 = Cmd22.ExecuteReader();

                    while (Reader22.Read())
                    {
                        txtB.Text = Reader22["c_o"].ToString();
                    }

                    Reader22.Close();
                    Scon22.Close();
                }


            }
        }
        if (ins < 3)
        {
           // GridView1.
       //   GridView1.a
            //   SqlDataSource1.SelectCommand = "SELECT * FROM [ratio] WHERE exname ='" + "q1qqqq3wertt4tyu44i454545resdfgdfd 55ii36io7p" + "'";
        }
        ins++;
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_Unload(object sender, EventArgs e)
    {
        loaded = true;
    }
    protected void StudAns_ValueChanged(object sender, EventArgs e)
    {
         foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox txtAns = (TextBox)row.FindControl("TextBox2");
            CheckBox txtA = (CheckBox)row.FindControl("txtA");
            CheckBox txtB = (CheckBox)row.FindControl("txtB");
            CheckBox txtC = (CheckBox)row.FindControl("txtC");
            CheckBox txtD = (CheckBox)row.FindControl("txtD");
            CheckBox txtE = (CheckBox)row.FindControl("txtE");
            CheckBox txtF = (CheckBox)row.FindControl("txtF");
            CheckBox txtG = (CheckBox)row.FindControl("txtG");
            CheckBox txtH = (CheckBox)row.FindControl("txtH");
            CheckBox txtI = (CheckBox)row.FindControl("txtI");
            CheckBox txtJ = (CheckBox)row.FindControl("txtJ");
            Label lblqid = (Label)row.FindControl("Label6");
  
            HiddenField corAns = (HiddenField)row.FindControl("Cor");
            HiddenField studAns = (HiddenField)row.FindControl("StudAns");

            if (txtAns.Visible == true)
            {
                studAns.Value = txtAns.Text;
            }
            if (txtA.Checked == true)
            {
               studAns.Value = txtA.Text;
            }
            else if (txtB.Checked == true)
            {
                studAns.Value = txtB.Text;
            }
            else if (txtC.Checked == true)
            {
                studAns.Value = txtC.Text;
            }
            else if (txtD.Checked == true)
            {
                studAns.Value = txtD.Text;
            }
            else if (txtE.Checked == true)
            {
                studAns.Value = txtE.Text;
            }
            else if (txtF.Checked == true)
            {
                studAns.Value = txtF.Text;
            }
            else if (txtG.Checked == true)
            {
                studAns.Value = txtG.Text;
            }
            else if (txtH.Checked == true)
            {
                studAns.Value = txtH.Text;
            }
            else if (txtI.Checked == true)
            {
                studAns.Value = txtI.Text;
            }
            else if (txtJ.Checked == true)
            {
                studAns.Value = txtJ.Text;
            }
            if (studAns.Value.ToString().ToUpper().Trim() == corAns.Value.ToString().ToUpper().Trim())
            {
                correctCounter++;

            }
            else
            {
                correctCounter--;
            }
            
                Label10.Text = correctCounter.ToString();
        }
    }
    public void changer()
    {
        
        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox txtAns = (TextBox)row.FindControl("TextBox2");
            CheckBox txtA = (CheckBox)row.FindControl("txtA");
            CheckBox txtB = (CheckBox)row.FindControl("txtB");
            CheckBox txtC = (CheckBox)row.FindControl("txtC");
            CheckBox txtD = (CheckBox)row.FindControl("txtD");
            CheckBox txtE = (CheckBox)row.FindControl("txtE");
            CheckBox txtF = (CheckBox)row.FindControl("txtF");
            CheckBox txtG = (CheckBox)row.FindControl("txtG");
            CheckBox txtH = (CheckBox)row.FindControl("txtH");
            CheckBox txtI = (CheckBox)row.FindControl("txtI");
            CheckBox txtJ = (CheckBox)row.FindControl("txtJ");
            Label lblqid = (Label)row.FindControl("Label6");

            HiddenField corAns = (HiddenField)row.FindControl("Cor");
            HiddenField studAns = (HiddenField)row.FindControl("StudAns");
            HiddenField q_id = (HiddenField)row.FindControl("qid");
            //try{
            if (txtAns.Visible == true)
            {
                studAns.Value = txtAns.Text;
                txtAns.Focus();
            }
            else
            {

                if (txtA.Checked == true)
                {
                    txtA.Focus();
                    studAns.Value = txtA.Text;
                }
                else if (txtB.Checked == true)
                {
                    txtB.Focus();
                    studAns.Value = txtB.Text;
                }
                else if (txtC.Checked == true)
                {
                    txtC.Focus();
                    studAns.Value = txtC.Text;
                }
                else if (txtD.Checked == true)
                {
                    txtD.Focus();
                    studAns.Value = txtD.Text;
                }
                else if (txtE.Checked == true)
                {
                    txtE.Focus();
                    studAns.Value = txtE.Text;
                }

                else
                {
                    studAns.Value = "";
                }
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
                sql = "UPDATE answers Set ans = '" + studAns.Value.ToString() + "' Where user_id ='" + user + "' AND exam_code  = '" + exname + "' AND ques_id ='" + q_id.Value.ToString().Trim().ToUpper() + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                Reader.Close();
                Scon.Close();
            }
            
            //if (studAns.Value.ToString().ToUpper().Trim() == corAns.Value.ToString().ToUpper().Trim())
            //{
            //    correctCounter+=1;

            //}
            //else
            //{
            //    correctCounter-=1;
            //}

            //Label10.Text = correctCounter.ToString();
        }
        {
            string ddd = "";
            string strTimes = "";
            double overs = 0;
            string tot = "";
            TimeSpan datess;
            TimeSpan diffs;
            {
                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2;
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr4.ReadLine();

                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = "Select d_taken From exam_results WHERE exam_code= '" + exname + "' and user_id ='" + user + "'";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();

                while (Reader2.Read())
                {

                     ddd = Reader2["d_taken"].ToString();
                     break;
                }

                Reader2.Close();
                Scon2.Close();
            }
            {

                SqlConnection Scon5;
                SqlDataReader Reader5;
                SqlCommand Cmd5; StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");

                line = sr66.ReadLine();
                string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql5;
                sql5 = "Select t_left From exam_results WHERE exam_code = '" + exname + "' AND user_id ='" + user + "'";
                Scon5 = new SqlConnection(sConnection5);
                Scon5.Open();
                Cmd5 = new SqlCommand(sql5, Scon5);
                Reader5 = Cmd5.ExecuteReader();


                while (Reader5.Read())
                {

                     strTimes = Reader5["t_left"].ToString();

                     string hour = strTimes.Substring(0, 2);
                     string min = strTimes.Substring(3, 2);
                     string secss = strTimes.Substring(6);
                     //try
                     //{
                     //    secss = strTimes.Substring(6, 1);
                     //}
                     //catch
                     //{
                     //    try
                     //    {
                     //        secss = strTimes.Substring(6, 2);
                     //    }
                     //    catch
                     //    {
                     //        try
                     //        {
                     //            secss = strTimes.Substring(6, 4);
                     //        }
                     //        catch
                     //        {
                     //            try
                     //            {
                     //                secss = strTimes.Substring(6, 5);
                     //            }
                     //            catch
                     //            {
                     //                secss = strTimes.Substring(6, 3);
                     //            }

                     //        }
                     //    }
                     //}
                         
                    
                    
                     
                     tot = hour + ":" + min + ":" + secss;
                    int secc = int.Parse(secss);
                    int minn = int.Parse(min);
                    overs = minn * 60;
                    int hourr = int.Parse(hour);
                    overs = overs + (hourr * 60 * 60);
                    overs = overs + secc;
               
                    break;
                }


                Reader5.Close();
                Scon5.Close();


            }


            datess = System.DateTime.Now - Convert.ToDateTime(ddd);
            string d1 = datess.Hours.ToString();
            string d2 = datess.Minutes.ToString();
            string d3 = datess.Seconds.ToString();
            string d4 = datess.ToString();

         //   diffs =Convert.ToDateTime(tot) -  Convert.ToDateTime(datess);
            double newdt = datess.Seconds;
            double nl = 0;
           nl =  overs - newdt;
           nl = Math.Round(nl, 0);
           string newie = "00:00:" + nl.ToString();
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();

            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "UPDATE exam_results Set t_left = '" + newie + "' Where user_id ='" + user + "' AND exam_code  = '" + exname + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();
        }
    }
    protected void txtA_CheckedChanged(object sender, EventArgs e)
    {
      
    }
    protected void txtB_CheckedChanged(object sender, EventArgs e)
    {
   //     changer();
    }
    protected void txtC_CheckedChanged(object sender, EventArgs e)
    {
     //   changer();
    }
    protected void txtD_CheckedChanged(object sender, EventArgs e)
    {
    //    changer();
    }
    protected void txtE_CheckedChanged(object sender, EventArgs e)
    {
     //   changer();
    }
    protected void txtF_CheckedChanged(object sender, EventArgs e)
    {
    //    changer();
    }
    protected void txtG_CheckedChanged(object sender, EventArgs e)
    {
     //   changer();
    }
    protected void txtH_CheckedChanged(object sender, EventArgs e)
    {
   //     changer();
    }
    protected void txtI_CheckedChanged(object sender, EventArgs e)
    {
     //   changer();
    }
    protected void txtJ_CheckedChanged(object sender, EventArgs e)
    {
     //   changer();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (GridView1.PageIndex + 1 == GridView1.PageCount)
        {
            if (extype == "Fac")
            {


            }
            else
            {
                Button3.Visible = true;
            }
        }
        else
        {
            Button3.Visible = false;
        }
        
     
    }
   // protected System.Timers.Timer _timer;
    protected void GridView1_Init(object sender, EventArgs e)
    {
        //// initialize the time control      
        //_timer = new System.Timers.Timer(50);     
        //// subscribe to the Elapsed event       
        //_timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        ////Label13.Text = 

    }
  //  int or = 0;
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {            // Do whatever you want to do on each tick of the timer
    //    or = or + 1;
       // Label13.Text = 

    }
    protected void GridView1_Load(object sender, EventArgs e)
    {
     //   _timer.Start();
    }
    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
       
        Label11.Text = exname;

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Button3.Visible = false;
        changer();
        
   
        Page.Session["user"] = user;
        Page.Session["exname"] = exname;
        Button1.Visible = false;
      
        Response.Redirect("Grades.aspx");
        Button3.Visible = false;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
 
        changer();
        //foreach (GridViewRow row in GridView1.Rows)
        //{

        //    CheckBox txtA = (CheckBox)row.FindControl("txtA");
        //    CheckBox txtB = (CheckBox)row.FindControl("txtB");
        //    CheckBox txtC = (CheckBox)row.FindControl("txtC");
        //    CheckBox txtD = (CheckBox)row.FindControl("txtD");
        //    CheckBox txtE = (CheckBox)row.FindControl("txtE");
        //    CheckBox txtF = (CheckBox)row.FindControl("txtF");
        //    CheckBox txtG = (CheckBox)row.FindControl("txtG");
        //    CheckBox txtH = (CheckBox)row.FindControl("txtH");
        //    CheckBox txtI = (CheckBox)row.FindControl("txtI");
        //    CheckBox txtJ = (CheckBox)row.FindControl("txtJ");
        //    CheckBox txtS = (CheckBox)row.FindControl("AA");
        //    Label lblqid = (Label)row.FindControl("Label6");
        //    Label NUMER = (Label)row.FindControl("Label1");
        //    HiddenField corAns = (HiddenField)row.FindControl("Cor");
        //    HiddenField studAnsId = (HiddenField)row.FindControl("qid");
        //    {
        //        {
        //            SqlConnection Scon;
        //            SqlDataReader Reader;
        //            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
        //            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        //            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        //            string sql;
        //            sql = "Select * From answers WHERE ques_id = '" + studAnsId.Value.ToString() + "' and user_id ='" + user + "' and exam_code ='" + exname + "'";
        //            Scon = new SqlConnection(sConnection);
        //            Scon.Open();
        //            Cmd = new SqlCommand(sql, Scon);
        //            Reader = Cmd.ExecuteReader();

        //            // ListBox1.Items.Clear();
        //            while (Reader.Read())
        //            {

        //                corr = Reader["ans"].ToString();
        //                ListBox1.Items.Add("1");
        //                if (corr == txtA.Text)
        //                {
        //                    txtS.Checked = true;
        //                }
        //                else if (txtB.Text == corr)
        //                {
        //                    txtB.Checked = true;
        //                }
        //                else if (txtC.Text == corr)
        //                {
        //                    txtC.Checked = true;
        //                }
        //                else if (txtD.Text == corr)
        //                {
        //                    txtD.Checked = true;
        //                }
        //                else if (txtE.Text == corr)
        //                {
        //                    txtE.Checked = true;
        //                }
        //                else if (txtF.Text == corr)
        //                {
        //                    txtF.Checked = true;
        //                }
        //                else if (txtG.Text == corr)
        //                {
        //                    txtG.Checked = true;
        //                }
        //                else if (txtH.Text == corr)
        //                {
        //                    txtH.Checked = true;
        //                }
        //                else if (txtI.Text == corr)
        //                {
        //                    txtI.Checked = true;
        //                }
        //                else if (txtJ.Text == corr)
        //                {
        //                    txtJ.Checked = true;
        //                }

        //                else
        //                {
        //                    txtS.Checked = true;
        //                }

        //                break;
        //            }
        //            Reader.Close();
        //            Scon.Close();

        //        }
        //    }

        //}

    }
    //string corr;
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
      
      
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        writeInfo();
        
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        changer();
    }
    int ticker = 0;
    protected void Timer1_Tick(object sender, EventArgs e)
    {
      
   //     ticker++;
        Label13.Text = DateTime.Now.ToString("hh:mm:ss");
    }
    int corA = 0;
    int wroA = 0;
    protected void Button1_Click12(object sender, EventArgs e)
    {
        Button3.Visible = false;
        changer();




        //     try
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
                sql = "Select * From question_table WHERE exam_code = '" + exname + "' ORDER BY ques_id ASC";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr4.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Select ans From answers WHERE ques_id = '" + Reader["ques_id"].ToString() + "' AND user_id = '" + user + "' ORDER BY ques_id ASC";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();

                    while (Reader2.Read())
                    {
                        {
                            SqlConnection Scon6;
                            SqlDataReader Reader6;
                            SqlCommand Cmd6;
                            StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr6.ReadLine();
                            string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql6;
                            sql6 = "Select * From it_anal WHERE ques_id_id LIKE '" + "%" + Reader["ques_id"].ToString() + "'";
                            Scon6 = new SqlConnection(sConnection6);
                            Scon6.Open();
                            Cmd6 = new SqlCommand(sql6, Scon6);
                            Reader6 = Cmd6.ExecuteReader();

                            while (Reader6.Read())
                            {
                                corA = (int.Parse(Reader6["cor"].ToString()));
                                wroA = (int.Parse(Reader6["incor"].ToString()));
                            }
                            Reader6.Close();
                            Scon6.Close();
                        }

                        if ((Reader["ans_a"].ToString().Trim().ToUpper()) == (Reader2["ans"].ToString().Trim().ToUpper()))
                        {


                            corA++;
                            {
                                SqlConnection Scon5;
                                SqlCommand Cmd5;
                                StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr5.ReadLine();
                                string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql5;
                                sql5 = "UPDATE it_anal SET cor ='" + corA.ToString() + "' WHERE ques_id_id LIKE '" + "%" + Reader["ques_id"].ToString() + "'";
                                Scon5 = new SqlConnection(sConnection5);
                                Scon5.Open();
                                Cmd5 = new SqlCommand(sql5, Scon5);
                                Cmd5.ExecuteNonQuery();
                                Scon5.Close();

                            }
                        }
                        else
                        {
                            wroA++;
                            {
                                SqlConnection Scon5;
                                SqlCommand Cmd5;
                                StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr5.ReadLine();
                                string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql5;
                                sql5 = "UPDATE it_anal SET incor ='" + wroA.ToString() + "' WHERE ques_id_id LIKE '" + "%" + Reader["ques_id"].ToString() + "'";
                                Scon5 = new SqlConnection(sConnection5);
                                Scon5.Open();
                                Cmd5 = new SqlCommand(sql5, Scon5);
                                Cmd5.ExecuteNonQuery();
                                Scon5.Close();
                                Label17.Text = wroA.ToString();
                            }
                        }


                    }
                    Reader2.Close();
                    Scon2.Close();
                }


                Reader.Close();
                Scon.Close();
            }


        }
        ////////////////
        int taroung = 0;
        {
            SqlConnection Scon6;
            SqlDataReader Reader6;
            SqlCommand Cmd6;
            StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr6.ReadLine();
            string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql6;
            sql6 = "Select * From answers WHERE  exam_code='"+exname+"' AND user_id ='" + user + "' AND ans <> '" + "noanswerxxx" + "'";
            Scon6 = new SqlConnection(sConnection6);
            Scon6.Open();
            Cmd6 = new SqlCommand(sql6, Scon6);
            Reader6 = Cmd6.ExecuteReader();

            while (Reader6.Read())
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
                    sql = "Select * From question_table WHERE exam_code = '" + exname + "' AND ques_id = '" + Reader6["ques_id"].ToString() + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        if ((Reader6["ans"].ToString() == (Reader["ans_a"].ToString())))
                        {
                            {
                                SqlConnection Scon664;
                                SqlDataReader Reader664;
                                SqlCommand Cmd664;
                                StreamReader sr664 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr664.ReadLine();
                                string sConnection664 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql664;
                                sql664 = "Select * From course_bulk WHERE user_id ='" + user + "' AND exname  = '" + exname + "' AND l_o = '" + Reader6["l_o"].ToString() + "'";
                                Scon664 = new SqlConnection(sConnection664);
                                Scon664.Open();
                                Cmd664 = new SqlCommand(sql664, Scon664);
                                Reader664 = Cmd664.ExecuteReader();

                                while (Reader664.Read())
                                {
                                    taroung = (int.Parse(Reader664["correct"].ToString()));
                                    if (Reader["dif"].ToString() == "Easy")
                                    {
                                        taroung = taroung + 1;
                                    }
                                    else if (Reader["dif"].ToString() == "Average")
                                    {
                                        taroung = taroung + 2;
                                    }
                                    else
                                    {
                                        taroung = taroung + 3;
                                    }
                                    int utu = (taroung + (int.Parse(Reader664["incor"].ToString())));

                                    SqlConnection Scon77;
                                    SqlDataReader Reader77;
                                    SqlCommand Cmd77;
                                    StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr77.ReadLine();
                                    string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql77;
                                    sql77 = "UPDATE course_bulk Set correct = '" + taroung + "',t_count = '" + utu + "' Where user_id ='" + user + "' AND exname  = '" + exname + "' AND l_o = '" + Reader6["l_o"].ToString() + "'";
                                    Scon77 = new SqlConnection(sConnection77);
                                    Scon77.Open();
                                    Cmd77 = new SqlCommand(sql77, Scon77);
                                    Reader77 = Cmd77.ExecuteReader();
                                    Reader77.Close();
                                    Scon77.Close();
                                    taroung = 0;
                                }
                                Reader664.Close();
                                Scon664.Close();
                            }
                        }
                        else
                        {
                            {
                                SqlConnection Scon664;
                                SqlDataReader Reader664;
                                SqlCommand Cmd664;
                                StreamReader sr664 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr664.ReadLine();
                                string sConnection664 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql664;
                                sql664 = "Select * From course_bulk WHERE user_id ='" + user + "' AND exname  = '" + exname + "' AND l_o = '" + Reader6["l_o"].ToString() + "'";
                                Scon664 = new SqlConnection(sConnection664);
                                Scon664.Open();
                                Cmd664 = new SqlCommand(sql664, Scon664);
                                Reader664 = Cmd664.ExecuteReader();

                                while (Reader664.Read())
                                {

                                    taroung = (int.Parse(Reader664["incor"].ToString()));
                                    if (Reader["dif"].ToString() == "Easy")
                                    {
                                        taroung = taroung + 1;
                                    }
                                    else if (Reader["dif"].ToString() == "Average")
                                    {
                                        taroung = taroung + 2;
                                    }
                                    else
                                    {
                                        taroung = taroung + 3;
                                    }
                                    int utu = (int.Parse(Reader664["correct"].ToString())) + (taroung);

                                    SqlConnection Scon77;
                                    SqlDataReader Reader77;
                                    SqlCommand Cmd77;
                                    StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr77.ReadLine();
                                    string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql77;
                                    sql77 = "UPDATE course_bulk Set incor = '" + taroung + "',t_count = '" + utu + "' Where user_id ='" + user + "' AND exname  = '" + exname + "' AND l_o = '" + Reader6["l_o"].ToString() + "'";
                                    Scon77 = new SqlConnection(sConnection77);
                                    Scon77.Open();
                                    Cmd77 = new SqlCommand(sql77, Scon77);
                                    Reader77 = Cmd77.ExecuteReader();
                                    Reader77.Close();
                                    Scon77.Close();
                                    taroung = 0;
                                }
                                Reader664.Close();
                                Scon664.Close();
                            }
                        }
                    }
                    Reader.Close();
                    Scon.Close();
                }

            }
            Reader6.Close();
            Scon6.Close();
        }
    



        ////////////////
        //  catch { }
        Button3.Visible = false;
        //   Panel1.Visible = true;


        Button3.Visible = false;
        string anals = "ok";
        Page.Session["anal"] = anals;
        int redir = 0;


        int codec = 0;
        int taroung2 = 0;
        int totalCOr = 0;
        decimal ratrat = 0;

        {
            SqlConnection Scon2;
            SqlDataReader Reader2;
            SqlCommand Cmd2;
            StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql2;
            sql2 = "Select * From answers WHERE exam_code = '" + exname + "' AND user_id = '" +user +"' ";
            Scon2 = new SqlConnection(sConnection2);
            Scon2.Open();
            Cmd2 = new SqlCommand(sql2, Scon2);
            Reader2 = Cmd2.ExecuteReader();
            while (Reader2.Read())
            {
                {
                    SqlConnection Scon664;
                    SqlDataReader Reader664;
                    SqlCommand Cmd664;
                    StreamReader sr664 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr664.ReadLine();
                    string sConnection664 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql664;
                    sql664 = "Select * From stud_perc WHERE ques_id ='" + Reader2["ques_id"].ToString() + "' AND exname  = '" + exname + "'";
                    Scon664 = new SqlConnection(sConnection664);
                    Scon664.Open();
                    Cmd664 = new SqlCommand(sql664, Scon664);
                    Reader664 = Cmd664.ExecuteReader();

                    while (Reader664.Read())
                    {
                        taroung2 = (int.Parse(Reader664["all_stud"].ToString()));
                        totalCOr = (int.Parse(Reader664["cor_stud"].ToString()));
                        if (Reader2["ans"].ToString() == "noanswerxxx")
                        {
                            taroung2--;
                            {
                                SqlConnection Scon77;
                                SqlDataReader Reader77;
                                SqlCommand Cmd77;
                                StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr77.ReadLine();
                                string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql77;
                                sql77 = "UPDATE stud_perc Set all_stud = '" + taroung2 + "' Where exname ='" + exname + "' AND ques_id  = '" + Reader2["ques_id"].ToString() + "'";
                                Scon77 = new SqlConnection(sConnection77);
                                Scon77.Open();
                                Cmd77 = new SqlCommand(sql77, Scon77);
                                Reader77 = Cmd77.ExecuteReader();
                                Reader77.Close();
                                Scon77.Close();
                            }
                        }
                        {
                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd;
                            StreamReader sr22 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr22.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Select * From question_table WHERE exam_code = '" + exname + "' AND ques_id = '" + Reader2["ques_id"].ToString() + "'";
                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Reader = Cmd.ExecuteReader();
                            while (Reader.Read())
                            {
                                if (Reader2["ans"].ToString() == Reader["ans_a"].ToString())
                                {
                                    totalCOr++;
                                }
                              //  totalCOr = 7;
                                ratrat = (Convert.ToDecimal(totalCOr) / Convert.ToDecimal(taroung2)) * 100;
                                {
                                    SqlConnection Scon77;
                                    SqlDataReader Reader77;
                                    SqlCommand Cmd77;
                                    StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr77.ReadLine();
                                    string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql77;
                                    sql77 = "UPDATE stud_perc Set cor_stud = '" + totalCOr + "' ,perc = '" + ratrat + "' Where exname ='" + exname + "' AND ques_id  = '" + Reader["ques_id"].ToString() + "'";
                                    Scon77 = new SqlConnection(sConnection77);
                                    Scon77.Open();
                                    Cmd77 = new SqlCommand(sql77, Scon77);
                                    Reader77 = Cmd77.ExecuteReader();
                                    Reader77.Close();
                                    Scon77.Close();
                                }

                            }
                            Reader.Close();
                            Scon.Close();
                        }
                    }
                    Reader664.Close();
                    Scon664.Close();
                }
            }

            
                
            Reader2.Close();
            Scon2.Close();
        }
        {
            {
                SqlConnection Scon6;
                SqlDataReader Reader6;
                SqlCommand Cmd6;
                StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr6.ReadLine();
                string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql6;
                sql6 = "Select * From exam_results WHERE user_id = '" + user + "' AND exam_code ='" + exname + "'";
                Scon6 = new SqlConnection(sConnection6);
                Scon6.Open();
                Cmd6 = new SqlCommand(sql6, Scon6);
                Reader6 = Cmd6.ExecuteReader();

                while (Reader6.Read())
                {
                    codec = (int.Parse(Reader6["take_no"].ToString()));
                    codec++;
                    break;
                }
                Reader6.Close();
                Scon6.Close();
            }

            {
                SqlConnection Scon;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "UPDATE  exam_results SET d_taken ='" + System.DateTime.Now.ToString() + "', d_close ='" + "TAKEN" + "', take_no ='" + codec.ToString() + "' WHERE user_id = '" + user + "' AND exam_code='" + exname + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Cmd.ExecuteNonQuery();
                Scon.Close();

            }

            {
                //SqlConnection Scon77;
                //SqlDataReader Reader77;
                //SqlCommand Cmd77;
                //StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                //line = sr77.ReadLine();
                //string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                //string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                //string sql77;
                //sql77 = "UPDATE ratio Set rat = '" + pa.ToString() + ":" + ba.ToString() + "' Where  exname  = '" + exname + "'";
                //Scon77 = new SqlConnection(sConnection77);
                //Scon77.Open();
                //Cmd77 = new SqlCommand(sql77, Scon77);
                //Reader77 = Cmd77.ExecuteReader();
                //Reader77.Close();
                //Scon77.Close();


                redir = 1;
                if (redir == 1)
                {
                    codec = 0;
                    rdir();
                }
                else { }
            }




        }

    }
    public void rdir()
    {
        Page.Session["user"] = user;
        Page.Session["exname"] = exname;
        //Response.Redirect("StudSummary.aspx",true);
      //  Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.close ('" + Request.ApplicationPath + "/Exam.aspx', null,'top=1,left=1,center=yes,fullscreen=1,resizable=no,Width=1024px,Height= 600px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

        Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/StudSummary.aspx', null,'top=1,left=1,center=yes,fullscreen=1,resizable=no,Width=1024px,Height= 600px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

       

       
    }
    protected void Button3_Command(object sender, CommandEventArgs e)
    {
      
  
    }
    protected void Button3_Disposed(object sender, EventArgs e)
    {
        
    }
    int cox = 0;
    protected void Button4_Click(object sender, EventArgs e)
    {
     
      
    }
    protected void k(object sender, EventArgs e)
    {
        
    }
    protected void @new(object sender, EventArgs e)
    {
        LinkButton2.Visible = true;
        Button3.Enabled = false;
        LinkButton2.Focus();
    }
    protected void GridView1_PageIndexChanged1(object sender, EventArgs e)
    {
        //if (GridView1.PageIndex == GridView1.PageCount)
        //{
        //    Button3.Visible = true;
        //}
    }
}
