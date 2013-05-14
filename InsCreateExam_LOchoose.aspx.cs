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

public partial class InsCreateExam_LOchoose : System.Web.UI.Page
{
    string user; string newtype = ""; string exname = ""; string sortype = ""; string sql3 = ""; string extype = "";
    string choice; string line = ""; string weeks; string course = ""; int oxana = 0; string define = "";
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
             
                {
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine(); SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567"; SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    SqlDataSource2.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    SqlDataSource10.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    SqlDataSource1.ConnectionString = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    exname = Page.Session["exname"].ToString();
                    user = Page.Session["user"].ToString();
                    course = Page.Session["course"].ToString();
                    try
                    {
                        extype = Page.Session["type"].ToString();
                        define = Page.Session["define"].ToString();
                    }
                    catch { }
                    course = Page.Session["course"].ToString();
                    Label1.Text = weeks;
                }
                
                funcone();
            }
        }
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
       try
        {
            DropDownList1.SelectedIndex = 0;
            GridView1.DataBind();
        }
        catch
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("No course found");
            DropDownList1.SelectedIndex = 0;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_Load(object sender, EventArgs e)
    {
    
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        
      
        foreach (GridViewRow row in GridView1.Rows)
        {
            
            CheckBox txtB = (CheckBox)row.FindControl("CheckBox2");
            HiddenField txtlo = (HiddenField)row.FindControl("HiddenField1");
            HiddenField txtco = (HiddenField)row.FindControl("HiddenField2");
            HiddenField txttopicid = (HiddenField)row.FindControl("HiddenField3");
            Label lbl1 = (Label)row.FindControl("Label7");


            {
                int newcounttopic = 0;
                SqlConnection Scon4;
                SqlDataReader Reader4;
                SqlCommand Cmd4;
                string path4 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr4.ReadLine();
                string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                string sql4;
                sql4 = "Select * From question_table WHERE l_o = '" + txtlo.Value.ToString()  + "'  AND l_outcomes LIKE '" + course + "%' AND copy_type = '" + "databank" + "'";
                Scon4 = new SqlConnection(sConnection4);
                Scon4.Open();
                Cmd4 = new SqlCommand(sql4, Scon4);
                Reader4 = Cmd4.ExecuteReader();

                while (Reader4.Read())
                {
                    newcounttopic++;
                   
                }
                Reader4.Close();
                Scon4.Close();
                lbl1.Text = newcounttopic.ToString();
                if (newcounttopic == 0)
                {
                    txtB.Enabled = false;
                }
                else
                {
                    txtB.Enabled = true;
                }

            }

        } 
   
         
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    public string funcRa()
    {
        string az = System.DateTime.Now.Millisecond.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Hour.ToString();
        return az;
    }
    public string randomPic()
    {
        Random raka = new Random();
        int saga2 = raka.Next(0,9);
        return saga2.ToString();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        if ((txtIDen.Text == "0") && (txtMul.Text == "0") && (txtTF.Text == "0"))
        //  if ((ii == "0") && (jj == "0") && (kk == "0"))
        {
            Label2.Text = "You did not add any questions.";
            //LinkButton1.Text = "No items available for this exam. \nPlease click here to go back.";
            //Button1.Visible = false;
        }
        else
        {

            string SQLadder = "";
            {
                if (ListBox3.Items.Count == 1)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString();
                }
                if (ListBox3.Items.Count == 2)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString();
                }
                if (ListBox3.Items.Count == 3)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString();
                }
                if (ListBox3.Items.Count == 4)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString();
                }
                if (ListBox3.Items.Count == 5)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString();
                }
                if (ListBox3.Items.Count == 6)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString();
                }
                if (ListBox3.Items.Count == 7)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString();
                }
                if (ListBox3.Items.Count == 8)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString();
                }
                if (ListBox3.Items.Count == 9)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString();
                }
                if (ListBox3.Items.Count == 10)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString();
                }
                if (ListBox3.Items.Count == 11)
                {

                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString();

                }
                if (ListBox3.Items.Count == 12)
                {

                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString();

                }
                if (ListBox3.Items.Count == 13)
                {

                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString();

                }
                if (ListBox3.Items.Count == 14)
                {

                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString();

                }
                if (ListBox3.Items.Count == 15)
                {

                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString();

                }
                if (ListBox3.Items.Count == 16)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString();
                }
                if (ListBox3.Items.Count == 17)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString();
                }
                if (ListBox3.Items.Count == 18)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString(); ;
                }
                if (ListBox3.Items.Count == 19)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString();
                }
                if (ListBox3.Items.Count == 20)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString();
                }
                if (ListBox3.Items.Count == 21)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString();
                }
                if (ListBox3.Items.Count == 22)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString();
                }
                if (ListBox3.Items.Count == 23)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString();
                }
                if (ListBox3.Items.Count == 24)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString();
                }
                if (ListBox3.Items.Count == 25)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString();
                }
                if (ListBox3.Items.Count == 26)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString()+"','" + ListBox3.Items[25].Value.ToString();
                }
                if (ListBox3.Items.Count == 27)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString();
                }
                if (ListBox3.Items.Count == 28)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString();
                }
                if (ListBox3.Items.Count == 29)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString();
                }
                if (ListBox3.Items.Count == 30)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString()+"','" + ListBox3.Items[29].Value.ToString(); 
                }
                if (ListBox3.Items.Count == 31)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString()+"','" + ListBox3.Items[29].Value.ToString()+"','" + ListBox3.Items[30].Value.ToString();
                }
                if (ListBox3.Items.Count == 32)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString()  + "','" + ListBox3.Items[31].Value.ToString(); 
                }
                if (ListBox3.Items.Count == 33)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString(); 
                }
                if (ListBox3.Items.Count == 34)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString(); 
                }
                if (ListBox3.Items.Count == 35)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString(); 
                }
                if (ListBox3.Items.Count == 36)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString()+ "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString()+ "','" + ListBox3.Items[35].Value.ToString();
                }
                if (ListBox3.Items.Count == 37)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString()+ "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString()+ "','" + ListBox3.Items[35].Value.ToString()+ "','" + ListBox3.Items[36].Value.ToString();
                }
                if (ListBox3.Items.Count == 38)
                {
                   SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString();
                }
                if (ListBox3.Items.Count == 39)
                {
                        SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString();
                }
                if (ListBox3.Items.Count == 40)
                {
                        SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString();
                }
                if (ListBox3.Items.Count == 41)
                {
                            SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() ;
                }
                if (ListBox3.Items.Count == 42)
                {
                              SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString();
                }
                if (ListBox3.Items.Count == 43)
                {
                            SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() ;
                }
                if (ListBox3.Items.Count == 44)
                {
                  SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() ;
                }
                if (ListBox3.Items.Count == 45)
                {
               SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString();
                }
                if (ListBox3.Items.Count == 46)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() ;
                }
                if (ListBox3.Items.Count == 47)
                {
               SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() ;
                }
                if (ListBox3.Items.Count == 48)
                {
                     SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() ;
                }
                if (ListBox3.Items.Count == 49)
                {
                     SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() + "','" + ListBox3.Items[48].Value.ToString();
                }
                if (ListBox3.Items.Count == 50)
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString()+ "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() + "','" + ListBox3.Items[48].Value.ToString() + "','" + ListBox3.Items[49].Value.ToString();
                }
                if ((ListBox3.Items.Count >= 50) && (ListBox3.Items.Count <= 70))
                {
                    SQLadder = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() + "','" + ListBox3.Items[48].Value.ToString() + "','" + ListBox3.Items[49].Value.ToString();
                }
            }

            TextBox txtQ = new TextBox();
            TextBox txtA = new TextBox();
            TextBox txtBb = new TextBox();
            TextBox txtCc = new TextBox();
            //  TextBox txtD = new TextBox();
            TextBox txtE = new TextBox();
            TextBox txtF = new TextBox();
            TextBox txtG = new TextBox();
            TextBox txtH = new TextBox();
            TextBox txtI = new TextBox();
            TextBox txtJ = new TextBox();
            TextBox txtTy = new TextBox();
            TextBox txtImage = new TextBox();
            TextBox lo = new TextBox();
            TextBox co = new TextBox();
            TextBox copy = new TextBox();
            TextBox week = new TextBox();
            TextBox pt = new TextBox();
            TextBox diff = new TextBox();
            int changeToInt = 0;

            int changeToInt2 = 0;
            int changeToInt3 = 0;

            //   foreach (GridViewRow row in GridView1.Rows)
            {


                //Label txtAE = (Label)row.FindControl("lblLO");
                //Label txtB = (Label)row.FindControl("Label2");
                //HiddenField txtC = (HiddenField)row.FindControl("HiddenField1");
                try
                {
                    // TextBox typo = (TextBox)row.FindControl("TextBox2");

                    changeToInt = int.Parse(txtMul.Text);
                }
                catch { }
                try
                {
                    //   TextBox typo2 = (TextBox)row.FindControl("TextBox2");

                    changeToInt2 = int.Parse(txtTF.Text);
                }
                catch { }
                try
                {
                    //  TextBox typo3 = (TextBox)row.FindControl("TextBox2");
                    changeToInt3 = int.Parse(txtIDen.Text);

                }
                catch { }



                int adder = 0;
                {
                    //     Label1.Text = changeToInt.ToString();
                }
                {
                    int countet = 0;
                    if (changeToInt == 0)
                    {

                    }
                    else
                    {

                       try
                        {

                            //    do
                            {
                                {

                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd;
                                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    if (randomPic() == "0")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ans_a  ASC";
                                    }
                                    else if (randomPic() == "1")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ans_a  DESC";
                                    }
                                    else if (randomPic() == "2")
                                    {
                                        //////////////////////////
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "')AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  DESC";
                                    }

                                    else if (randomPic() == "3")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY exam_code  DESC";

                                    }
                                    else if (randomPic() == "4")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_id  DESC";
                                    }
                                    else if (randomPic() == "5")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "')  AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_id  ASC";
                                    }
                                    else if (randomPic() == "6")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  DESC";
                                    }
                                    else if (randomPic() == "7")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  ASC";
                                    }
                                    else if (randomPic() == "8")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ins_id  ASC";
                                    }
                                    else if (randomPic() == "9")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "MC" + "'AND copy_type = '" + "databank" + "' ORDER BY ins_id  DESC";
                                    }
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql3, Scon);
                                    Reader = Cmd.ExecuteReader();

                                    while (Reader.Read())
                                    {
                                        {
                                            SqlConnection Scon4;
                                            SqlDataReader Reader4;
                                            SqlCommand Cmd4;
                                            string path4 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                            StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                            line = sr4.ReadLine();
                                            string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                                            string sql4;
                                            sql4 = "Select count(ques_id) AS col From question_table WHERE exam_code = '" + exname + "'AND copy_type = '" + "databank" + "'";
                                            Scon4 = new SqlConnection(sConnection4);
                                            Scon4.Open();
                                            Cmd4 = new SqlCommand(sql4, Scon4);
                                            Reader4 = Cmd4.ExecuteReader();

                                            while (Reader4.Read())
                                            {
                                                adder = int.Parse(Reader4["col"].ToString());
                                            }
                                            Reader4.Close();
                                            Scon4.Close();
                                        }

                                        txtQ.Text = (Reader["ques_desc"].ToString());
                                        txtA.Text = (Reader["ans_a"].ToString());
                                        txtBb.Text = (Reader["ans_b"].ToString());
                                        txtCc.Text = (Reader["ans_c"].ToString());
                                        txtD.Text = (Reader["ans_d"].ToString());
                                        txtE.Text = (Reader["ans_e"].ToString());
                                        txtF.Text = (Reader["ans_f"].ToString());
                                        txtG.Text = (Reader["ans_g"].ToString());
                                        txtH.Text = (Reader["ans_h"].ToString());
                                        txtI.Text = (Reader["ans_i"].ToString());
                                        txtJ.Text = (Reader["ans_j"].ToString());
                                        txtTy.Text = (Reader["typeEx"].ToString());
                                        txtImage.Text = (Reader["imgLoc"].ToString());
                                        lo.Text = (Reader["l_o"].ToString());
                                        co.Text = (Reader["c_o"].ToString());
                                        week.Text = (Reader["l_outcomes"].ToString());
                                        pt.Text = (Reader["pt"].ToString());
                                        diff.Text = (Reader["dif"].ToString());
                                        if (txtBb.Text == "")
                                        {
                                            txtBb.Text = null;
                                        }
                                        else if (txtCc.Text == "")
                                        {
                                            txtCc.Text = null;
                                        }
                                        else if (txtD.Text == "")
                                        {
                                            txtD.Text = null;
                                        }
                                        else if (txtE.Text == "")
                                        {
                                            txtE.Text = null;
                                        }
                                        else if (txtF.Text == "")
                                        {
                                            txtF.Text = null;
                                        }
                                        else if (txtG.Text == "")
                                        {
                                            txtG.Text = null;
                                        }
                                        else if (txtH.Text == "")
                                        {
                                            txtH.Text = null;
                                        }
                                        else if (txtI.Text == "")
                                        {
                                            txtI.Text = null;
                                        }
                                        else if (txtJ.Text == "")
                                        {
                                            txtJ.Text = null;
                                        }



                                        SqlConnection Scon2;
                                        SqlCommand Cmd2; SqlDataReader Reader2;
                                        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                        string sql2;
                                        sql2 = "Insert Into question_table VAlUES('" + user + "','" + exname + ": MC :" +funcRa()+ countet + "','" + exname + "','" + txtTy.Text + "','" + txtQ.Text + "','" + txtA.Text + "','" + txtBb.Text + "','" + txtCc.Text + "','" + txtD.Text + "','" + txtE.Text + "','" + txtF.Text + "','" + txtG.Text + "','" + txtH.Text + "','" + txtI.Text + "','" + txtJ.Text + "','" + week.Text + "','" + "" + "','" + txtImage.Text + "','" + lo.Text + "','" + co.Text + "','" + "copycat" + "','" + int.Parse(pt.Text) + "','" + diff.Text + "')";
                                        Scon2 = new SqlConnection(sConnection2);
                                        Scon2.Open();
                                        Cmd2 = new SqlCommand(sql2, Scon2);
                                        Reader2 = Cmd2.ExecuteReader();

                                        countet++;
                                        if (countet >= changeToInt)
                                        {
                                            break;
                                        }

                                    }
                                    Reader.Close();
                                    Scon.Close();
                                }
                            }
                        }
                       catch { }

                        //    } while (countet <= changeToInt);

                    }
                }
                int saga = 0;
                {
                    int countet = 0;
                    if (changeToInt2 == 0)
                    {

                    }
                    else
                    {
                        //    do
                        try
                        {
                            {
                                {
                                   
                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    if (randomPic() == "0")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ans_a  ASC";
                                    }
                                    else if (randomPic() == "1")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ans_a  DESC";
                                    }
                                    else if (randomPic() == "2")
                                    {
                                        //////////////////////////
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "')AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  DESC";
                                    }

                                    else if (randomPic() == "3")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY exam_code  DESC";

                                    }
                                    else if (randomPic() == "4")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_id  DESC";
                                    }
                                    else if (randomPic() == "5")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "')  AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_id  ASC";
                                    }
                                    else if (randomPic() == "6")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  DESC";
                                    }
                                    else if (randomPic() == "7")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  ASC";
                                    }
                                    else if (randomPic() == "8")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ins_id  ASC";
                                    }
                                    else if (randomPic() == "9")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "ToF" + "'AND copy_type = '" + "databank" + "' ORDER BY ins_id  DESC";
                                    }
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql3, Scon);
                                    Reader = Cmd.ExecuteReader();

                                    while (Reader.Read())
                                    {
                                        {
                                            SqlConnection Scon4;
                                            SqlDataReader Reader4;
                                            SqlCommand Cmd4;
                                            StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                            line = sr4.ReadLine();
                                            string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                                            string sql4;
                                            sql4 = "Select count(ques_id) AS col From question_table WHERE exam_code = '" + exname + "'AND copy_type = '" + "databank" + "'";
                                            Scon4 = new SqlConnection(sConnection4);
                                            Scon4.Open();
                                            Cmd4 = new SqlCommand(sql4, Scon4);
                                            Reader4 = Cmd4.ExecuteReader();

                                            while (Reader4.Read())
                                            {
                                                adder = int.Parse(Reader4["col"].ToString());
                                            }
                                            Reader4.Close();
                                            Scon4.Close();
                                        }
                                        pt.Text = (Reader["pt"].ToString());

                                        txtQ.Text = (Reader["ques_desc"].ToString());
                                        txtA.Text = (Reader["ans_a"].ToString());
                                        txtBb.Text = (Reader["ans_b"].ToString());
                                        txtCc.Text = (Reader["ans_c"].ToString());
                                        txtD.Text = (Reader["ans_d"].ToString());
                                        txtE.Text = (Reader["ans_e"].ToString());
                                        txtF.Text = (Reader["ans_f"].ToString());
                                        txtG.Text = (Reader["ans_g"].ToString());
                                        txtH.Text = (Reader["ans_h"].ToString());
                                        txtI.Text = (Reader["ans_i"].ToString());
                                        txtJ.Text = (Reader["ans_j"].ToString());
                                        txtTy.Text = (Reader["typeEx"].ToString());
                                        txtImage.Text = (Reader["imgLoc"].ToString());
                                        lo.Text = (Reader["l_o"].ToString());
                                        co.Text = Reader["c_o"].ToString();
                                        week.Text = (Reader["l_outcomes"].ToString());
                                        pt.Text = (Reader["pt"].ToString());
                                        diff.Text = (Reader["dif"].ToString());
                                        if (txtBb.Text == "")
                                        {
                                            txtBb.Text = null;
                                        }
                                        else if (txtCc.Text == "")
                                        {
                                            txtCc.Text = null;
                                        }
                                        else if (txtD.Text == "")
                                        {
                                            txtD.Text = null;
                                        }
                                        else if (txtE.Text == "")
                                        {
                                            txtE.Text = null;
                                        }
                                        else if (txtF.Text == "")
                                        {
                                            txtF.Text = null;
                                        }
                                        else if (txtG.Text == "")
                                        {
                                            txtG.Text = null;
                                        }
                                        else if (txtH.Text == "")
                                        {
                                            txtH.Text = null;
                                        }
                                        else if (txtI.Text == "")
                                        {
                                            txtI.Text = null;
                                        }
                                        else if (txtJ.Text == "")
                                        {
                                            txtJ.Text = null;
                                        }



                                        SqlConnection Scon2;
                                        SqlCommand Cmd2; SqlDataReader Reader2;
                                        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                        string sql2;
                                        sql2 = "Insert Into question_table VAlUES('" + user + "','" + exname + ": ToF :" + funcRa() +countet+ "','" + exname + "','" + txtTy.Text + "','" + txtQ.Text + "','" + txtA.Text + "','" + txtBb.Text + "','" + txtCc.Text + "','" + txtD.Text + "','" + txtE.Text + "','" + txtF.Text + "','" + txtG.Text + "','" + txtH.Text + "','" + txtI.Text + "','" + txtJ.Text + "','" + week.Text + "','" + "" + "','" + txtImage.Text + "','" + lo.Text + "','" + co.Text + "','" + "copycat" + "','" + int.Parse(pt.Text) + "','" + diff.Text + "')";
                                        Scon2 = new SqlConnection(sConnection2);
                                        Scon2.Open();
                                        Cmd2 = new SqlCommand(sql2, Scon2);
                                      
                                        
                                            Reader2 = Cmd2.ExecuteReader();

                                            countet++;
                                            if (countet >= changeToInt2)
                                            {
                                                break;
                                            }
                                        

                                    }
                                    Reader.Close();
                                    Scon.Close();
                                }
                            }
                        }
                       catch { }

                        //    } while (countet <= changeToInt);

                    }
                }
                {
                    int countet = 0;
                    if (changeToInt3 == 0)
                    {

                    }
                    else
                    {
                        //    do
                        try
                        {
                            {
                                {
                                    SqlConnection Scon;
                                    SqlDataReader Reader;
                                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    if (randomPic() == "0")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ans_a  ASC";
                                    }
                                    else if (randomPic() == "1")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ans_a  DESC";
                                    }
                                    else if (randomPic() == "2")
                                    {
                                        //////////////////////////
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "')AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  DESC";
                                    }

                                    else if (randomPic() == "3")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY exam_code  DESC";

                                    }
                                    else if (randomPic() == "4")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_id  DESC";
                                    }
                                    else if (randomPic() == "5")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "')  AND l_outcomes LIKE '" + course + "%' AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_id  ASC";
                                    }
                                    else if (randomPic() == "6")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  DESC";
                                    }
                                    else if (randomPic() == "7")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ques_desc  ASC";
                                    }
                                    else if (randomPic() == "8")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ins_id  ASC";
                                    }
                                    else if (randomPic() == "9")
                                    {
                                        sql3 = "Select * From question_table WHERE l_o IN ('" + SQLadder + "') AND l_outcomes LIKE '" + course + "%'  AND typeEx = '" + "Iden" + "'AND copy_type = '" + "databank" + "' ORDER BY ins_id  DESC";
                                    }
                                    Scon = new SqlConnection(sConnection);
                                    Scon.Open();
                                    Cmd = new SqlCommand(sql3, Scon);
                                    Reader = Cmd.ExecuteReader();

                                    while (Reader.Read())
                                    {
                                        {
                                            SqlConnection Scon4;
                                            SqlDataReader Reader4;
                                            SqlCommand Cmd4;
                                            StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                            line = sr4.ReadLine();
                                            string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                                            string sql4;
                                            sql4 = "Select count(ques_id) AS col From question_table WHERE exam_code = '" + exname + "'AND copy_type = '" + "databank" + "'";
                                            Scon4 = new SqlConnection(sConnection4);
                                            Scon4.Open();
                                            Cmd4 = new SqlCommand(sql4, Scon4);
                                            Reader4 = Cmd4.ExecuteReader();

                                            while (Reader4.Read())
                                            {
                                                adder++;
                                             //   adder = int.Parse(Reader4["col"].ToString());
                                            }
                                            Reader4.Close();
                                            Scon4.Close();
                                        }
                                        pt.Text = (Reader["pt"].ToString());

                                        txtQ.Text = (Reader["ques_desc"].ToString());
                                        txtA.Text = (Reader["ans_a"].ToString());
                                        txtBb.Text = (Reader["ans_b"].ToString());
                                        txtCc.Text = (Reader["ans_c"].ToString());
                                        txtD.Text = (Reader["ans_d"].ToString());
                                        txtE.Text = (Reader["ans_e"].ToString());
                                        txtF.Text = (Reader["ans_f"].ToString());
                                        txtG.Text = (Reader["ans_g"].ToString());
                                        txtH.Text = (Reader["ans_h"].ToString());
                                        txtI.Text = (Reader["ans_i"].ToString());
                                        txtJ.Text = (Reader["ans_j"].ToString());
                                        txtTy.Text = (Reader["typeEx"].ToString());
                                        txtImage.Text = (Reader["imgLoc"].ToString());
                                        lo.Text = (Reader["l_o"].ToString());
                                       co.Text = (Reader["c_o"].ToString());
                                       week.Text = (Reader["l_outcomes"].ToString());
                                       pt.Text = (Reader["pt"].ToString());
                                       diff.Text = (Reader["dif"].ToString());
                                        if (txtBb.Text == "")
                                        {
                                            txtBb.Text = null;
                                        }
                                        else if (txtCc.Text == "")
                                        {
                                            txtCc.Text = null;
                                        }
                                        else if (txtD.Text == "")
                                        {
                                            txtD.Text = null;
                                        }
                                        else if (txtE.Text == "")
                                        {
                                            txtE.Text = null;
                                        }
                                        else if (txtF.Text == "")
                                        {
                                            txtF.Text = null;
                                        }
                                        else if (txtG.Text == "")
                                        {
                                            txtG.Text = null;
                                        }
                                        else if (txtH.Text == "")
                                        {
                                            txtH.Text = null;
                                        }
                                        else if (txtI.Text == "")
                                        {
                                            txtI.Text = null;
                                        }
                                        else if (txtJ.Text == "")
                                        {
                                            txtJ.Text = null;
                                        }



                                        SqlConnection Scon2;
                                        SqlCommand Cmd2; SqlDataReader Reader2;
                                        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                        string sql2;
                                     //   sql2 = "Insert Into question_table VAlUES('" + user + "','" + exname + ":" + countet + "','" + exname + "','" + txtTy.Text + "','" + txtQ.Text + "','" + txtA.Text + "','" + txtBb.Text + "','" + txtCc.Text + "','" + txtD.Text + "','" + txtE.Text + "','" + txtF.Text + "','" + txtG.Text + "','" + txtH.Text + "','" + txtI.Text + "','" + txtJ.Text + "','" + week.Text + "','" + "" + "','" + txtImage.Text + "','" + lo.Text + "','" + co.Text + "','" + "copycat" + "','" + int.Parse(pt.Text) + "')";
                                        sql2 = "Insert Into question_table VAlUES('" + user + "','" + exname + ": Iden :" +funcRa()+ countet + "','" + exname + "','" + txtTy.Text + "','" + txtQ.Text + "','" + txtA.Text + "','" + txtBb.Text + "','" + txtCc.Text + "','" + txtD.Text + "','" + txtE.Text + "','" + txtF.Text + "','" + txtG.Text + "','" + txtH.Text + "','" + txtI.Text + "','" + txtJ.Text + "','" + week.Text + "','" + "" + "','" + txtImage.Text + "','" + lo.Text + "','" + co.Text + "','" + "copycat" + "','" + int.Parse(pt.Text) + "','" + diff.Text + "')";
                                        Scon2 = new SqlConnection(sConnection2);
                                        Scon2.Open();
                                        Cmd2 = new SqlCommand(sql2, Scon2);
                                        Reader2 = Cmd2.ExecuteReader();

                                        countet++;
                                        if (countet >= changeToInt3)
                                        {
                                            break;
                                        }

                                    }
                                    Reader.Close();
                                    Scon.Close();
                                }
                            }

                        }
                        catch { }
                        //    } while (countet <= changeToInt);

                    }
                }


            }
            int incAdd = 0;
            string updateit = "";
            try
            {
                updateit = exname.Substring(0, 50);
            }
            catch
            {
                updateit = exname.Substring(0, 45);
            }
            //{
            //    SqlConnection Scon4;
            //    SqlDataReader Reader4;
            //    SqlCommand Cmd4;
            //    StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            //    line = sr4.ReadLine();
            //    string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

            //    string sql4;
            //    sql4 = "Select * From course_bulk WHERE    ex_code LIKE '" + updateit + "%' ";
            //    Scon4 = new SqlConnection(sConnection4);
            //    Scon4.Open();
            //    Cmd4 = new SqlCommand(sql4, Scon4);
            //    Reader4 = Cmd4.ExecuteReader();

            //    while (Reader4.Read())
            //    {
            //        incAdd = int.Parse(Reader4["made"].ToString());
            //    }
            //    Reader4.Close();
            //    Scon4.Close();
            //}
            //incAdd++;
            {
                //SqlConnection Scon5;
                //SqlCommand Cmd5;
                //StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                //line = sr5.ReadLine();
                //string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                //string sql5;
                //sql5 = "UPDATE course_bulk SET made ='" + incAdd.ToString() + "' WHERE ex_code LIKE '" + updateit + "%'";
                //Scon5 = new SqlConnection(sConnection5);
                //Scon5.Open();
                //Cmd5 = new SqlCommand(sql5, Scon5);
                //Cmd5.ExecuteNonQuery();
                //Scon5.Close();

                SqlConnection Scon2;
                SqlCommand Cmd2; SqlDataReader Reader2;
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = "Insert Into exam_unpub VAlUES('" + exname + "','" + course  + "')";
                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                Reader2 = Cmd2.ExecuteReader();
                Reader2.Close();
                Scon2.Close();

            }
            Page.Session["weeks"] = SQLadder;
            Page.Session["user"] = user;
            Page.Session["choice"] = choice;
            Page.Session["exname"] = exname;
            Page.Session["choices"] = choice;
            Page.Session["editmode"] = "0";
            Response.Redirect("CreateExam.aspx");
        }
      
    }
    private void funcone()
    {
        try
        {
            DropDownList1.Visible = false;
            Label15.Visible = false;
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox txtAE = (CheckBox)row.FindControl("CheckBox1");
                Label txtB = (Label)row.FindControl("Label1");
                if (txtAE.Checked == true)
                {
                    ListBox3.Items.Add(txtB.Text.Trim());
                }
                int cou = ListBox3.Items.Count;
                int m = 0;


            }
            SqlDataSource1.SelectCommand = "  SELECT *  FROM course_topics WHERE topic_id LIKE '" + course + "%' ORDER BY topic_id";
            
            GridView2.Visible = false;
            GridView1.Visible = true;
        
            bool buttonshow = false;
            {
                SqlConnection Scon4;
                SqlDataReader Reader4;
                SqlCommand Cmd4;
                StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr4.ReadLine();
                string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                string sql4;
                sql4 = SqlDataSource1.SelectCommand;
                Scon4 = new SqlConnection(sConnection4);
                Scon4.Open();
                Cmd4 = new SqlCommand(sql4, Scon4);
                Reader4 = Cmd4.ExecuteReader();

                while (Reader4.Read())
                {
                    buttonshow = true;
                }
                Reader4.Close();
                Scon4.Close();
            }
            if (buttonshow == false)
            {
              //  Button2.Visible = false;
            }
        }
        catch { Label2.Text = "Error."; 
            //Button2.Visible = false;
        }



    }
    protected void Button1_Click2(object sender, EventArgs e)
    {
        int occ = 0;
        foreach (GridViewRow row in GridView2.Rows)
        {
            CheckBox txtAE = (CheckBox)row.FindControl("CheckBox1");
            if (txtAE.Checked == true)
            {
                occ = 1;
            }

        }
        if (occ == 1)
        {
            funcone();
        }
        else
        {
            MessageBox("Please select topic(s)");
        }
        occ = 0;

    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    string ii = "0";
    string jj = "0";
    string kk = "0";
    bool checkRads = false;
    private void functwo()
    {
        ListBox3.Items.Clear();
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox txtAE = (CheckBox)row.FindControl("CheckBox2");
            HiddenField txtB = (HiddenField)row.FindControl("HiddenField1");
            if (txtAE.Checked == true)
            {
                ListBox3.Items.Add(txtB.Value.ToString().Trim());
                checkRads = true;
            }

            int m = 0;
            //ListBox3.SelectedIndex = 0;
            //ListBox3.SelectedIndex = 1;

        }
        if (checkRads == true)
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string SQLadders = "";
            {
                if (ListBox3.Items.Count == 1)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString();
                }
                if (ListBox3.Items.Count == 2)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString();
                }
                if (ListBox3.Items.Count == 3)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString();
                }
                if (ListBox3.Items.Count == 4)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString();
                }
                if (ListBox3.Items.Count == 5)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString();
                }
                if (ListBox3.Items.Count == 6)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString();
                }
                if (ListBox3.Items.Count == 7)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString();
                }
                if (ListBox3.Items.Count == 8)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString();
                }
                if (ListBox3.Items.Count == 9)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString();
                }
                if (ListBox3.Items.Count == 10)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString();
                }
                if (ListBox3.Items.Count == 11)
                {

                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString();

                }
                if (ListBox3.Items.Count == 12)
                {

                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString();

                }
                if (ListBox3.Items.Count == 13)
                {

                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString();

                }
                if (ListBox3.Items.Count == 14)
                {

                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString();

                }
                if (ListBox3.Items.Count == 15)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString();
                }
                if (ListBox3.Items.Count == 16)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString();
                }
                if (ListBox3.Items.Count == 17)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString();
                }
                if (ListBox3.Items.Count == 18)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString(); ;
                }
                if (ListBox3.Items.Count == 19)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString();
                }
                if (ListBox3.Items.Count == 20)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString();
                }
                if (ListBox3.Items.Count == 21)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString();
                }
                if (ListBox3.Items.Count == 22)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString();
                }
                if (ListBox3.Items.Count == 23)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString();
                }
                if (ListBox3.Items.Count == 24)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString();
                }
                if (ListBox3.Items.Count == 25)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString();
                }





                if (ListBox3.Items.Count == 25)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString();
                }
                if (ListBox3.Items.Count == 26)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString();
                }
                if (ListBox3.Items.Count == 27)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString();
                }
                if (ListBox3.Items.Count == 28)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString();
                }
                if (ListBox3.Items.Count == 29)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString();
                }
                if (ListBox3.Items.Count == 30)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString();
                }
                if (ListBox3.Items.Count == 31)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString();
                }
                if (ListBox3.Items.Count == 32)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString();
                }
                if (ListBox3.Items.Count == 33)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString();
                }
                if (ListBox3.Items.Count == 34)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString();
                }
                if (ListBox3.Items.Count == 35)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString();
                }
                if (ListBox3.Items.Count == 36)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString();
                }
                if (ListBox3.Items.Count == 37)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString();
                }
                if (ListBox3.Items.Count == 38)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString();
                }
                if (ListBox3.Items.Count == 39)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString();
                }
                if (ListBox3.Items.Count == 40)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString();
                }
                if (ListBox3.Items.Count == 41)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString();
                }
                if (ListBox3.Items.Count == 42)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString();
                }
                if (ListBox3.Items.Count == 43)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString();
                }
                if (ListBox3.Items.Count == 44)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString();
                }
                if (ListBox3.Items.Count == 45)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString();
                }
                if (ListBox3.Items.Count == 46)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString();
                }
                if (ListBox3.Items.Count == 47)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString();
                }
                if (ListBox3.Items.Count == 48)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString();
                }
                if (ListBox3.Items.Count == 49)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() + "','" + ListBox3.Items[48].Value.ToString();
                }
                if (ListBox3.Items.Count == 50)
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() + "','" + ListBox3.Items[48].Value.ToString() + "','" + ListBox3.Items[49].Value.ToString();
                }
                if ((ListBox3.Items.Count >= 50) && (ListBox3.Items.Count <= 70))
                {
                    SQLadders = ListBox3.Items[0].Value.ToString() + "','" + ListBox3.Items[1].Value.ToString() + "','" + ListBox3.Items[2].Value.ToString() + "','" + ListBox3.Items[3].Value.ToString() + "','" + ListBox3.Items[4].Value.ToString() + "','" + ListBox3.Items[5].Value.ToString() + "','" + ListBox3.Items[6].Value.ToString() + "','" + ListBox3.Items[7].Value.ToString() + "','" + ListBox3.Items[8].Value.ToString() + "','" + ListBox3.Items[9].Value.ToString() + "','" + ListBox3.Items[10].Value.ToString() + "','" + ListBox3.Items[11].Value.ToString() + "','" + ListBox3.Items[12].Value.ToString() + "','" + ListBox3.Items[13].Value.ToString() + "','" + ListBox3.Items[14].Value.ToString() + "','" + ListBox3.Items[15].Value.ToString() + "','" + ListBox3.Items[16].Value.ToString() + "','" + ListBox3.Items[17].Value.ToString() + "','" + ListBox3.Items[18].Value.ToString() + "','" + ListBox3.Items[19].Value.ToString() + "','" + ListBox3.Items[20].Value.ToString() + "','" + ListBox3.Items[21].Value.ToString() + "','" + ListBox3.Items[22].Value.ToString() + "','" + ListBox3.Items[23].Value.ToString() + "','" + ListBox3.Items[24].Value.ToString() + "','" + ListBox3.Items[25].Value.ToString() + "','" + ListBox3.Items[26].Value.ToString() + "','" + ListBox3.Items[27].Value.ToString() + "','" + ListBox3.Items[28].Value.ToString() + "','" + ListBox3.Items[29].Value.ToString() + "','" + ListBox3.Items[30].Value.ToString() + "','" + ListBox3.Items[31].Value.ToString() + "','" + ListBox3.Items[32].Value.ToString() + "','" + ListBox3.Items[33].Value.ToString() + "','" + ListBox3.Items[34].Value.ToString() + "','" + ListBox3.Items[35].Value.ToString() + "','" + ListBox3.Items[36].Value.ToString() + "','" + ListBox3.Items[37].Value.ToString() + "','" + ListBox3.Items[38].Value.ToString() + "','" + ListBox3.Items[39].Value.ToString() + "','" + ListBox3.Items[40].Value.ToString() + "','" + ListBox3.Items[41].Value.ToString() + "','" + ListBox3.Items[42].Value.ToString() + "','" + ListBox3.Items[43].Value.ToString() + "','" + ListBox3.Items[44].Value.ToString() + "','" + ListBox3.Items[45].Value.ToString() + "','" + ListBox3.Items[46].Value.ToString() + "','" + ListBox3.Items[47].Value.ToString() + "','" + ListBox3.Items[48].Value.ToString() + "','" + ListBox3.Items[49].Value.ToString();
                }
            }
            {


                string sql;
                sql = "Select ques_id From question_table WHERE  l_outcomes LIKE '" + course + "%' AND  typeEx = '" + "MC" + "' AND l_o IN ('" + SQLadders + "') AND copy_type = '" + "databank" + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    i++;
                    //     typo.Items.Add(i.ToString());

                }
                if (i == 0)
                {

                    llblMu.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    llblMu.ForeColor = System.Drawing.Color.White;
                }

                llblMu.Text = "Available questions: " + i.ToString();
                ii = i.ToString();
                Reader.Close();
                Scon.Close();
                rMul.MaximumValue = i.ToString();
            }
            {


                string sql;
                sql = "Select ques_id From question_table WHERE l_outcomes LIKE '" + course + "%' AND typeEx = '" + "ToF" + "' AND l_o IN ('" + SQLadders + "') AND copy_type = '" + "databank" + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    j++;
                    //  typo2.Items.Add(j.ToString());

                }
                if (j == 0)
                {
                    lblTF.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblTF.ForeColor = System.Drawing.Color.White;
                }
                rTF.MaximumValue = j.ToString();
                lblTF.Text = "Available questions: " + j.ToString();
                jj = j.ToString();
                Reader.Close();
                Scon.Close();
            }
            {

                string sql;
                sql = "Select ques_id From question_table WHERE l_outcomes LIKE '" + course + "%' AND typeEx = '" + "Iden" + "' AND l_o IN ('" + SQLadders + "') AND copy_type = '" + "databank" + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    k++;


                }
                if (k == 0)
                {

                    lblIden.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblIden.ForeColor = System.Drawing.Color.White;
                }
                //   typo3.Items.Add(k.ToString());

                rIde.MaximumValue = k.ToString();
                lblIden.Text = "Available questions: " + k.ToString();
                kk = k.ToString();
                Reader.Close();
                Scon.Close();
                // Button2.Visible = false;
                GridView1.Visible = false;
                Panel1.Visible = true;

            }
            if ((ii == "0") && (jj == "0") && (kk == "0"))
            {
                // LinkButton1.Text = "No items available for this exam. \nPlease click here to go back.";
                Button1.Visible = false;
                //    MessageBox("No items available. Please select add more topics.");
                // Label5.Text= "No items available. Please select 'add more topics.'";

            }
            else
            {
                LinkButton1.Text = "";
                Button1.Visible = true;
            }

           
        }

        else
        {
            MessageBox("Please check topic(s)");
        }
      
    }
    int j = 0; int k = 0; int i = 0;
    protected void Button1_Click1s(object sender, EventArgs e)
    {
      functwo();
        
    }
    //public void MessageBox(string msg)
    //{
    //    Label lbl = new Label();
    //    lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
    //    Page.Controls.Add(lbl);
    //}
    int incWeek = 0;
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        
        foreach (GridViewRow row in GridView2.Rows)
        {
            incWeek++;
            Label labes = (Label)row.FindControl("Label1");
            CheckBox checks = (CheckBox)row.FindControl("CheckBox1");

            if (exname.Contains("EXAM_1"))
            {
                if ((incWeek>=1)&&(incWeek<=4))
                {
                    checks.Checked = true;
                }
            }
            if (exname.Contains("EXAM_2"))
            {
                if ((incWeek >= 5) && (incWeek <= 8))
                {
                    checks.Checked = true;
                }
            }
            if ((exname.Contains("EXAM_3"))||(exname.Contains("EXAM_4"))||(exname.Contains("EXAM_5")))
            {
                if ((incWeek >= 9) && (incWeek <= 12))
                {
                    checks.Checked = true;
                }
            }
            if (exname.Contains("EXAM_F"))
            {
                if ((incWeek >= 1) && (incWeek <= 12))
                {
                    checks.Checked = true;
                }
            }

        }
        if (define == "1")
        {
            funcone();
       //     Button1_Click2(Button3, e);
            functwo();
            //if ((txtIDen.Text == "0") && (txtMul.Text == "0") && (txtTF.Text == "0"))
            if ((ii == "0") && (jj == "0") && (kk == "0"))
            {
                Label2.Visible = false;
               // LinkButton1.Text = "Course syllabus is not available. Please click here to go back.";
                Button1.Visible = false;
               // LinkButton2.Visible = false;
            }
            else
            {
                LinkButton1.Text = "";
                Button1.Visible = true;
                LinkButton2.Visible = true;
            }
        }
        else
        {
            //if ((ii == "0") && (jj == "0") && (kk == "0"))
            //{
            //    LinkButton1.Text = "No items available for this exam. \nPlease click here to go back.";
            //    Button1.Visible = false;
            //}
            //else
            //{
            //    LinkButton1.Text = "";
            //    Button1.Visible = true;
            //}
        }
       
       
    

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        oxana = 1;
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void GridView2_Unload(object sender, EventArgs e)
    {
      
    }
    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
    
    }
    protected void SqlDataSource10_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Page.Session["define"] = "2";

        GridView1.Visible = true;
    }
}
