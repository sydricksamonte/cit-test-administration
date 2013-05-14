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
        {
            exname = Page.Session["exname"].ToString();
            user = Page.Session["user"].ToString();

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
              
                break;


            }


            Reader.Close();
            Scon.Close();


        }

      
    }

   
}
