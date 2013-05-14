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
using System.IO;
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

        if (rep == "exam")
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql = "SELECT  question_table.ques_id, question_table.ins_id, question_table.ques_desc, question_table.ans_a, question_table.ans_b, question_table.ans_c, question_table.ans_d, question_table.ans_e,  question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date,  question_table.imgLoc, question_table.typeEx, question_table.exam_code, exams.pname, exams.pub_date, exams.user_id, course.sec_handler,  course.course_desc, course.course_sec, course.course_id, course.term FROM course INNER JOIN exams INNER JOIN question_table ON exams.exname = question_table.exam_code ON course.sec_handler = question_table.ins_id WHERE  question_table.ins_id= '" + user + "' and question_table.exam_code = '" + exname + "'   ORDER BY  question_table.ques_desc ASC, question_table.typeEx ASC ";
            // string sql = "SELECT  ins_id, ques_desc, ans_a, ans_b, ans_c, ans_d, ans_e, exam_code FROM question_table WHERE  ins_id= '" + user + "' and exam_code = '" + exname + "'   ORDER BY  ques_desc ASC, typeEx ASC ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                string userss = Reader["course_id"].ToString();
                sql = "SELECT  question_table.ques_id, question_table.ins_id, question_table.ques_desc, question_table.ans_a, question_table.ans_b, question_table.ans_c, question_table.ans_d, question_table.ans_e,  question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date,  question_table.imgLoc, question_table.typeEx, question_table.exam_code, exams.pname, exams.pub_date, exams.user_id, course.sec_handler,  course.course_desc, course.course_sec, course.course_id, course.term FROM course INNER JOIN exams INNER JOIN question_table ON exams.exname = question_table.exam_code ON course.sec_handler = question_table.ins_id WHERE  question_table.ins_id= '" + user + "' and question_table.exam_code = '" + exname + "' AND course.course_id = '" + userss + "'  ORDER BY  question_table.ques_desc ASC, question_table.typeEx ASC ";
                break;

            }
            Reader.Close();
            Scon.Close();


            SqlConnection con = new SqlConnection(sConnection);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            ReportDocument cryRpt = new ReportDocument();
            DataSetExam ds = new DataSetExam();

            adapter.Fill(ds.Tables[0]);

            cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"IdenPart.rpt");
            cryRpt.SetDataSource(ds.Tables[0]);

            CrystalReportViewer1.ReportSource = cryRpt;

            CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.RefreshReport();
        }
    
    }
 
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}
