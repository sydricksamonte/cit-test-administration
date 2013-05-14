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

public partial class InsExamScore : System.Web.UI.Page
{
    string user;
    string exname;
    string course;
    string section;
    string line;
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
                user = Page.Session["user"].ToString();
                course = Page.Session["course"].ToString();
                section = Page.Session["section"].ToString();
                exname = Page.Session["exname"].ToString();
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                SqlDataSource1.ConnectionString = sConnection2;

                txtCourse.Text = course;
             
                txtIns.Text = user;
                txtSec.Text = section;


                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr3.ReadLine();
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select pname From exams WHERE user_id = '" + user + "' AND exname ='" +exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        txtEx.Text = Reader["pname"].ToString();
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
                    sql = "Select COUNT(user_id) AS COL From exam_results WHERE exam_code ='" + exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                       Label4.Text = Reader["COL"].ToString();
                      

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
                    sql = "Select COUNT(user_id) AS COL From exam_results WHERE exam_code ='" + exname + "' AND d_close ='" + "TAKEN" + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        Label8.Text = Reader["COL"].ToString();
                     

                    }

                    Reader.Close();
                    Scon.Close(); 
                    double custod = double.Parse(Label8.Text);
                    double denom = double.Parse(Label4.Text);
                    double ans = (custod/denom) * 100;
                    ans = Math.Round(ans, 0);
                    Label15.Text = "(" + ans.ToString() + "%)";
                }
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr3.ReadLine();
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select COUNT(user_id) AS COL From exam_results WHERE exam_code ='" + exname + "' AND d_close ='" + "NOT TAKEN" + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        Label10.Text = Reader["COL"].ToString();


                    }

                    Reader.Close();
                    Scon.Close();
                    double custod = double.Parse(Label10.Text);
                    double denom = double.Parse(Label4.Text);
                    double ans = (custod/denom  ) * 100; ;
                    ans = Math.Round(ans, 0);
                    Label14.Text = "(" + ans.ToString() + "%)";
                }
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr3.ReadLine();
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select COUNT(user_id) AS COL From exam_results WHERE exam_code ='" + exname + "' AND d_close LIKE '%" + "PROGRESS" + "%'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {

                        Label12.Text = Reader["COL"].ToString();
                       

                    }

                    Reader.Close();
                    Scon.Close();
                    double custod  = double.Parse(Label12.Text);
                    double denom = double.Parse(Label4.Text);
                    double ans = (custod/denom  ) * 100; ;
                    ans = Math.Round(ans,0);
                    Label13.Text = "(" + ans.ToString() + "%)";
                }
             //   SELECT exam_results.stud_co_se_id, exam_results.user_id, exam_results.exam_code, exam_results.d_taken, exam_results.score, exam_results.pname, exam_results.section, exam_results.course, classlist.stud_name FROM exam_results INNER JOIN classlist ON exam_results.course = classlist.course_code AND exam_results.section = classlist.sec AND exam_results.user_id = classlist.stud_id WHERE (exam_results.exam_code = @exam_code)  AND (exam_results.section = @section) AND (exam_results.course = @course) ORDER BY classlist.stud_name ASC 
            }
        }
    }
}
