using System;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient; 
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

public partial class Classlist_crystal : System.Web.UI.Page
{
    string line;
    string user = "";
    string course = "";
    string sec = "";
    string rep = "";
    string exname = "";
    string term = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {

            Response.Redirect("LogIn.aspx");
        }
        else
        {
            
            if (Page.Session["exname"] == null)
            {
                Response.Redirect("InsCreateExam");

            }
            else
            {
                if ((Page.Session["rep"] == null) || (Page.Session["exname"] == null) || (Page.Session["section"] == null))
                {
                    Response.Redirect("InsReports");

                }
                else
                {
                    
                    term = Page.Session["term"].ToString();

                    course = Page.Session["course"].ToString();
                    sec = Page.Session["section"].ToString();
                    exname = Page.Session["exname"].ToString();
                    rep = Page.Session["rep"].ToString();
                    user = Page.Session["user"].ToString();

                    if ((rep == "examan") || (rep == "exam_a") || (rep == "exam_b"))
                    {
                        Button1.Visible = true;
                        Button2.Visible = true;
                    }
                    else
                    {
                        Button1.Visible = false;
                        Button2.Visible = false;
                    }
                    ///////////
                    if (rep == "grades")
                    {

                        {

                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Select * From term";
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

                            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr.ReadLine();
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql = "SELECT exam_results.user_id, exam_results.exam_code, exam_results.d_taken, exam_results.score, exam_results.pname, exam_results.section, exam_results.course, classlist.stud_name, course.term, course.course_desc, ratio.rat FROM exam_results INNER JOIN classlist ON exam_results.course = classlist.course_code AND exam_results.section = classlist.sec AND exam_results.user_id = classlist.stud_id INNER JOIN course ON classlist.sec = course.course_sec AND exam_results.section = course.course_sec AND exam_results.course = course.course_id AND classlist.prof_id = course.sec_handler INNER JOIN ratio ON exam_results.exam_code = ratio.exname   where course.term = '" + term + "' and  exam_results.course ='" + course + "' and exam_results.section ='" + sec + "' ORDER BY    exam_results.exam_code ASC, exam_results.score DESC, classlist.stud_name ASC ";
                            SqlConnection con = new SqlConnection(sConnection);
                            con.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                            ReportDocument cryRpt = new ReportDocument();
                            DataSetClass ds = new DataSetClass();

                            adapter.Fill(ds.Tables[0]);

                            cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"Grades.rpt");
                            cryRpt.SetDataSource(ds.Tables[0]);

                            CrystalReportViewer1.ReportSource = cryRpt;

                            CrystalReportViewer1.RefreshReport();
                            CrystalReportViewer1.RefreshReport();
                        }
                    }
                    if (rep == "class")
                    {
                        
                        {

                            SqlConnection Scon;
                            SqlDataReader Reader;
                            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;
                            sql = "Select * From term";
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

                            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                            line = sr.ReadLine();
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql = "Select * From classlist where stud_course_id LIKE '"+"%"+term+"' and  course_code ='" + course + "' and sec ='" + sec + "' ORDER BY stud_name ASC  ";
                            SqlConnection con = new SqlConnection(sConnection);
                            con.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                            ReportDocument cryRpt = new ReportDocument();
                            DataSetClass ds = new DataSetClass();

                            adapter.Fill(ds.Tables[0]);

                            cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"classlist.rpt");
                            cryRpt.SetDataSource(ds.Tables[0]);

                            CrystalReportViewer1.ReportSource = cryRpt;

                            CrystalReportViewer1.RefreshReport();
                            CrystalReportViewer1.RefreshReport();
                        }
                    }
                        if (rep == "itfull")
                    {
                        SqlConnection Scon;
                
                        SqlCommand Cmd;
                        StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  
                        line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                     // string sql = "SELECT        classlist.stud_name, question_table.ques_desc, question_table.ans_a, answers.ans, classlist.stud_id, classlist.prof_id, classlist.course_code, classlist.sec,   exam_results.score, exam_results.pname, exam_results.d_taken FROM   classlist INNER JOIN  answers ON classlist.stud_id = answers.user_id INNER JOIN question_table ON classlist.prof_id = question_table.ins_id INNER JOIN exam_results ON classlist.stud_id = exam_results.user_id AND question_table.exam_code = exam_results.exam_code AND  answers.exam_code = exam_results.exam_code AND classlist.course_code = exam_results.course AND classlist.sec = exam_results.section AND answers.user_id = exam_results.user_id WHERE  question_table.exam_code='"+exname+"'ORDER BY classlist.stud_name    ";
                        string sql = "SELECT        classlist.stud_name, question_table.ques_desc, question_table.ans_a, answers.ans, classlist.stud_id, classlist.prof_id, classlist.course_code, classlist.sec, exam_results.score, exam_results.pname, exam_results.d_taken, question_table.l_o FROM classlist INNER JOIN answers ON classlist.stud_id = answers.user_id INNER JOIN question_table ON classlist.prof_id = question_table.ins_id AND answers.exam_code = question_table.exam_code AND  answers.ques_id = question_table.ques_id INNER JOIN  exam_results ON classlist.stud_id = exam_results.user_id AND question_table.exam_code = exam_results.exam_code AND answers.exam_code = exam_results.exam_code AND classlist.course_code = exam_results.course AND classlist.sec = exam_results.section AND  answers.user_id = exam_results.user_id WHERE  question_table.exam_code='" + exname + "'ORDER BY exam_results.score DESC ,classlist.stud_name    "; 
                            Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                       
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, Scon);
                        ReportDocument cryRpt = new ReportDocument();
                        ItemAnalFull ds = new ItemAnalFull();

                        adapter.Fill(ds.Tables[0]);

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"ItemAnalFull.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
                        CrystalReportViewer1.RefreshReport();
                    } 
                    if (rep == "not")
                    {
                        SqlConnection Scon;
                    
                        SqlCommand Cmd;
                        StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  
                        line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql = "SELECT exam_results.score, exam_results.d_taken, exam_results.pname, exam_results.course, exam_results.section, exam_results.user_id, classlist.stud_name, classlist.stud_id FROM classlist INNER JOIN exam_results ON classlist.stud_id = exam_results.user_id AND classlist.course_code = exam_results.course   WHERE  exam_results.course = '" + course + "' and exam_results.section = '" + sec + "' AND classlist.prof_id = '" + user + "' AND exam_results.exam_code = '" + exname + "' AND  exam_results.d_taken != '" + "NOT TAKEN" + "'";
                     
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                       
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, Scon);
                        ReportDocument cryRpt = new ReportDocument();
                        DataSetNoticeStud ds = new DataSetNoticeStud();

                        adapter.Fill(ds.Tables[0]);

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"NoteExam.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
                        
                    }
                    if (rep == "anal")
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; 
                        StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
                        line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; 
                        string sql = "SELECT  question_table.ques_desc, exams.pname, it_anal.ques_id_id, it_anal.cor, it_anal.incor, it_anal.ques_id, it_anal.exname FROM   it_anal INNER JOIN   question_table ON it_anal.ques_id = question_table.ques_id AND it_anal.exname = question_table.exam_code INNER JOIN  exams ON it_anal.exname = exams.exname WHERE question_table.exam_code = '" + exname + "' ORDER BY cor DESC";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
         
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, Scon);
                        ReportDocument cryRpt = new ReportDocument();                 
                        ItAnalVer2 ds = new ItAnalVer2();
                        adapter.Fill(ds.Tables[0]);
                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"ItemAnalysis.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);
                        CrystalReportViewer1.ReportSource = cryRpt;
                        CrystalReportViewer1.RefreshReport();
                        
                    }
                    if (rep == "exam_a")
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; 
                        StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql = "SELECT     exam_report.ques_desc,   exam_report.ins_id, exam_report.exname, exam_report.pname, exam_report.exset, exam_report.extype, exam_report.ques_id, exam_report.c0,  exam_report.c1, exam_report.c2, exam_report.c3, exam_report.c4, exam_report.ans, exam_report.lo, exam_report.co, exam_report.pt, course.course_desc,  course.course_sec, course.course_id, course.sec_handler, course.term FROM            exam_report INNER JOIN  course ON exam_report.ins_id = course.sec_handler WHERE exname = '" + exname + "' AND exset = '" + "A" + "' AND sec_handler = '" + user + "' and course_id = '" + course + "' AND course_sec = '" + sec + "' AND term ='"+term+"'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                        
                        }
                        Reader.Close();
                        Scon.Close();


                        SqlConnection con = new SqlConnection(sConnection);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        ReportDocument cryRpt = new ReportDocument();
                        DataReportExam ds = new DataReportExam();

                        adapter.Fill(ds.Tables[0]);

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"Exams_A.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
                        
                    }
                    if (rep == "examan")
                    {
                        string adaptit = "";
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;
                        StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql = "SELECT     exam_report.ques_desc,   exam_report.ins_id, exam_report.exname, exam_report.pname, exam_report.exset, exam_report.extype, exam_report.ques_id, exam_report.c0,  exam_report.c1, exam_report.c2, exam_report.c3, exam_report.c4, exam_report.ans, exam_report.lo, exam_report.co, exam_report.pt, course.course_desc,  course.course_sec, course.course_id, course.sec_handler, course.term FROM            exam_report INNER JOIN  course ON exam_report.ins_id = course.sec_handler WHERE exname = '" + exname + "' AND exset = '" + "A" + "' AND sec_handler = '" + user + "' and course_id = '" + course + "'  AND course_sec = '" + sec + "' AND term ='" + term + "'";
                     
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                          

                        }

                        SqlConnection con = new SqlConnection(sConnection);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        ReportDocument cryRpt = new ReportDocument();
                        DataReportExam ds = new DataReportExam();

                        adapter.Fill(ds.Tables[0]);

                    

                    cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"Exams_B.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
                       
                    }
                    if (rep == "exam_b")
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql = "SELECT     exam_report.ques_desc,   exam_report.ins_id, exam_report.exname, exam_report.pname, exam_report.exset, exam_report.extype, exam_report.ques_id, exam_report.c0,  exam_report.c1, exam_report.c2, exam_report.c3, exam_report.c4, exam_report.ans, exam_report.lo, exam_report.co, exam_report.pt, course.course_desc,  course.course_sec, course.course_id, course.sec_handler, course.term FROM            exam_report INNER JOIN  course ON exam_report.ins_id = course.sec_handler WHERE exname = '" + exname + "' AND exset = '" + "B" + "' AND sec_handler = '" + user + "'and course_id = '" + course + "' AND course_sec = '"+sec+"'AND term ='"+term+"' ORDER BY extype DESC, ans DESC";
                        // string sql = "SELECT  ins_id, ques_desc, ans_a, ans_b, ans_c, ans_d, ans_e, exam_code FROM question_table WHERE  ins_id= '" + user + "' and exam_code = '" + exname + "'   ORDER BY  ques_desc ASC, typeEx ASC ";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                     
                        }
                        Reader.Close();
                        Scon.Close();


                        SqlConnection con = new SqlConnection(sConnection);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        ReportDocument cryRpt = new ReportDocument();
                        DataReportExam ds = new DataReportExam();

                        adapter.Fill(ds.Tables[0]);

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"Exams_A.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
                    }
                }



            }
        }
    }
 
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (rep == "exam_a")
        {
            Page.Session["term"] = term;
            Page.Session["rep"] = "exam_a";
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Answers.aspx");
        }
        if (rep == "exam_b")
        {
            Page.Session["term"] = term;
            Page.Session["rep"] = "exam_b";
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Answers.aspx");
        }
        if (rep == "examan")
        {
         
            Page.Session["term"] = term;
            Page.Session["rep"] = "examan";
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Answers.aspx");
        }
               
    }
}
