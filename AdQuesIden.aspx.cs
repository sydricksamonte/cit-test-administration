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
           
            {
                if (Page.Session["cou"] == null)
                {
                    Page.Session["cou"] = "-";

                    //GridView1.DataBind();
                }
                else
                {
                    Label4.Text = Page.Session["cou"].ToString();
                    try
                    {
                     //   DropDownList1.Text = Label4.Text;
                    }
                    catch { }
                }
                user = Page.Session["user"].ToString();

                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                SqlDataSource1.ConnectionString = sConnection2;
                SqlDataSource2.ConnectionString = sConnection2; Label6.Text = GridView1.Rows.Count.ToString();

            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Session["cou"] = DropDownList1.SelectedValue.ToString();
        GridView1.DataBind();
        Label6.Text = GridView1.Rows.Count.ToString();
        Label4.Text = DropDownList1.Text;
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        MessageBox("The item has been updated.");
    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        MessageBox("The item has been deleted.");
    }
}
