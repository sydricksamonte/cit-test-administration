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
using System.Timers;


public partial class ExamRedirect : System.Web.UI.Page
{
    string user = "";
    string line; string exname=""; int redir = 0; int codec = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {

            Response.Redirect("LogIn.aspx");
        }
        else
        {
            exname = Page.Session["exname"].ToString();
            user = Page.Session["user"].ToString();
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
                redir = 1;
                if (redir == 1)
                {
                    Page.Session["user"] = user;
                    Page.Session["exname"] = exname;
                    Response.Redirect("StudSummary.aspx", true);
                }
                else { }
            }
        }


    }
}
