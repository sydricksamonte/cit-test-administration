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

public partial class InsRetake : System.Web.UI.Page
{
    string user; string sec = ""; string choice; string line = ""; string term = ""; string exname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {

            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
            exname = Page.Session["exname"].ToString();
            {
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine(); SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource2.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                SqlDataSource3.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            }
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
                    Page.Session["term"] = term;
                    Label4.Text = term;
                }
                Reader.Close();
                Scon.Close();

            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList6_DataBound(object sender, EventArgs e)
    {
        try
        {
            sec = DropDownList6.Items[0].Value.ToString();
          
        }
        catch { }
    }
    protected void DropDownList2_DataBound(object sender, EventArgs e)
    {
        DropDownList6.DataBind();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    { CheckBox txtNa = GridView2.FooterRow.FindControl("CheckBox1") as CheckBox;

    if (txtNa.Checked == true)
    {
        foreach (GridViewRow row in GridView2.Rows)
        {
            CheckBox txtAE = (CheckBox)row.FindControl("CheckBox2");

            txtAE.Checked = true;

        }
    }
    else
    {
        foreach (GridViewRow row in GridView2.Rows)
        {
            CheckBox txtAE = (CheckBox)row.FindControl("CheckBox2");

            txtAE.Checked = false;

        }
    }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView1_Load(object sender, EventArgs e)
    {

    }
    int counter = 0; string examtime = "";
    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView2.Rows)
        {
            CheckBox txtAE = (CheckBox)row.FindControl("CheckBox2");
            Label txt = (Label)row.FindControl("Label3");
            if (txtAE.Checked == true)
            {
                counter++;
                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr.ReadLine();
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From exams WHERE exname = '" + exname + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        examtime = (Reader["duration"].ToString());
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
                    sql = "UPDATE  exam_results SET d_taken ='" + "(SUBJECTED FOR RETAKE)" + "', d_close ='" + "NOT TAKEN" + "', t_left ='" + examtime + "', take_no ='" + "0" + "' WHERE user_id = '" + txt.Text + "' AND exam_code='" + exname + "' AND d_close <>'" + "NOT TAKEN" + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Cmd.ExecuteNonQuery();
                    Scon.Close();


                }

            }
        }
        Page.Session["user"] = user;
        if (counter == 1)
        {
            Label5.Text = counter.ToString();
            Page.Session["message"] = "Selected student is now able to retake the test.";
            Response.Redirect("InsCreateExam.aspx");
        }
        else if (counter == 0)
        {
            Label5.Text = "You did not select any students.";
        }
        else
        {
          //  Label5.Text = counter.ToString();
            Page.Session["message"] = "Selected students are now able to retake the test.";
            Response.Redirect("InsCreateExam.aspx");
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
       
       
    }
}
