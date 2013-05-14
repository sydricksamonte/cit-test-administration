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
                    if (rep == "exam_a")
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;
                        StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                        string sql = "SELECT     exam_report.ques_desc,   exam_report.ins_id, exam_report.exname, exam_report.pname, exam_report.exset, exam_report.extype, exam_report.ques_id, exam_report.c0,  exam_report.c1, exam_report.c2, exam_report.c3, exam_report.c4, exam_report.ans, exam_report.lo, exam_report.co, exam_report.pt, course.course_desc,  course.course_sec, course.course_id, course.sec_handler, course.term FROM            exam_report INNER JOIN  course ON exam_report.ins_id = course.sec_handler WHERE exname = '" + exname + "' AND exset = '" + "A" + "' AND sec_handler = '" + user + "' and course_id = '" + course + "' AND course_sec = '" + sec + "' AND term ='" + term + "'";
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

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"AnswerKey.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
                        CrystalReportViewer1.RefreshReport();
                    }
                    if (rep == "exam_b")
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql = "SELECT     exam_report.ques_desc,   exam_report.ins_id, exam_report.exname, exam_report.pname, exam_report.exset, exam_report.extype, exam_report.ques_id, exam_report.c0,  exam_report.c1, exam_report.c2, exam_report.c3, exam_report.c4, exam_report.ans, exam_report.lo, exam_report.co, exam_report.pt, course.course_desc,  course.course_sec, course.course_id, course.sec_handler, course.term FROM            exam_report INNER JOIN  course ON exam_report.ins_id = course.sec_handler WHERE exname = '" + exname + "' AND exset = '" + "B" + "' AND sec_handler = '" + user + "'and course_id = '" + course + "' AND course_sec = '" + sec + "'AND term ='" + term + "' ORDER BY extype DESC, ans DESC";
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

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"AnswerKey.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
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
                        Reader.Close();
                        Scon.Close();



                        SqlConnection con = new SqlConnection(sConnection);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        ReportDocument cryRpt = new ReportDocument();
                        DataReportExam ds = new DataReportExam();

                        adapter.Fill(ds.Tables[0]);

                        cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"AnswerKey.rpt");
                        cryRpt.SetDataSource(ds.Tables[0]);

                        CrystalReportViewer1.ReportSource = cryRpt;

                        CrystalReportViewer1.RefreshReport();
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
      
               
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rep == "exam_a")
        {
            Page.Session["term"] = term;
            Page.Session["rep"] = "exam_a";
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
        if (rep == "exam_b")
        {
            Page.Session["term"] = term;
            Page.Session["rep"] = "exam_b";
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
        if (rep == "examan")
        {

            Page.Session["term"] = term;
            Page.Session["rep"] = "examan";
            Page.Session["user"] = user;
            Page.Session["exname"] = exname;
            Page.Session["course"] = course;
            Page.Session["section"] = sec;
            Response.Redirect("Crystal_Classlist.aspx");
        }
    }
}
