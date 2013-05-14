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
using System.IO;

public partial class InsSelWeekEx : System.Web.UI.Page
{
    string line = ""; string user; string exname; string choice;
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

                Response.Redirect("InsCreateExam.aspx");
            }
            else
            {
                if (Page.Session["choice"] == null)
                {
                    Response.Redirect("InsCreateExam.aspx");

                }
                else
                {
                    exname = Page.Session["exname"].ToString();
                    user = Page.Session["user"].ToString();
                    choice = Page.Session["choice"].ToString();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                  
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine(); SqlDataSource10.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource10.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    SqlDataSource2.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    SqlDataSource10.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
              

                    exname = Page.Session["exname"].ToString();
                    user = Page.Session["user"].ToString();
                    choice = Page.Session["choice"].ToString();
                }


            }
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string adder = "+";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox txtAE = (CheckBox)row.FindControl("CheckBox1");
            Label txtB = (Label)row.FindControl("Label1");
           
            if (txtAE.Checked == true)
            {
                adder = adder + txtB.Text+ "+" ;
            }
            else
            {
            }
        }
        Page.Session["weeks"] = adder;
        Page.Session["user"] = user;
        Page.Session["choice"] = choice;
        //    Page.Session["exname"] = DropDownList1.SelectedValue.ToString();
        Response.Redirect("InsCreateExam_LOchoose.aspx");
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        //try
        //{
        //    DropDownList1.SelectedIndex = 0;
        //    GridView1.DataBind();
        //}
        //catch
        //{
        //    DropDownList1.Items.Clear();
        //    DropDownList1.Items.Add("No course found");
        //    DropDownList1.SelectedIndex = 0;
        //}
    }
    protected void GridView1_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
}
