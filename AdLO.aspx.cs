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
using System.Data.OleDb;

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
                SqlDataSource2.ConnectionString = sConnection2;
                SqlDataSource3.ConnectionString = sConnection2;
                Label6.Text = GridView1.Rows.Count.ToString();

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
    protected void LinkButton3_Click(object sender, EventArgs e)
    {

    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        MessageBox("The item has been updated.");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton4.Focus();
        LinkButton4.Text = "Are you sure you want to delete this? Pls click this link to continue.";
        LinkButton4.Visible = true;
        
       

    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        LinkButton5.Focus();
        LinkButton5.Text = "Are you sure you want to upload new syllabus? If you update the syllabus, databank items from the current syllabus will be deleted. Pls click this link to continue.";
        LinkButton5.Visible = true;
        if (FileUpload1.HasFile == true)
        {
            prevgrid();
        }
        else
        {
            MessageBox("Please select a valid file.");
        }
    }
    string imLine = ""; 
    DataClassExcel myDataSet = new DataClassExcel(); 
    DataClassExcel myDataSet2 = new DataClassExcel(); 
    string excelFile = "";

    private void prevgrid()
    {
        if (FileUpload1.HasFile == true)
        {
          try
            {
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//imLoc.txt"); imLine = sr.ReadLine();
                //Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};dbq=C:\inetpub\wwwroot\CITEXAMSYSTEM\Classlist\201111103496IT130-B51.xls;defaultdir=C:\inetpub\wwwroot\CITEXAMSYSTEM\Classlist;driverid=1046;fil=excel 12.0;filedsn=C:\inetpub\wwwroot\CITEXAMSYSTEM\conExcel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid=admin;usercommitsync=Yes
                excelFile = @FileUpload1.PostedFile.FileName;
                string neww = Convert.ToString(Directory.GetParent(FileUpload1.PostedFile.FileName));
                string oxi = imLine + @"\Classlist\" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FileUpload1.FileName;
                string newww = Convert.ToString(neww + @"\Classlist\" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FileUpload1.FileName);
                FileUpload1.SaveAs(oxi);

                string sConnection = "Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + oxi + ";" + "Extended Properties=Excel 8.0;";
                string sql = "Select * From [Sheet1$] WHERE (F2 LIKE '%20%') OR (F2 LIKE 'L%')  ";
                OleDbConnection con = new OleDbConnection(sConnection);
                con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                //           DataSet ds = new mydata();

                adapter.Fill(myDataSet.Tables[0]);

                GridView2.DataSource = myDataSet.Tables[0];
                GridView2.DataBind();

              
            }
            catch
            {


                MessageBox("File is invalid. Please choose a valid class list Excel file to continue this operation.");
            }

        }
        else
        {
            MessageBox("Please select a valid Excel file.");
        }
    }
    private void adddata()
    {

        string termino = "";
       // if (FileUpload1.HasFile == true)
        {
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From term ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    termino = Reader["term"].ToString();

                }
                Reader.Close();
                Scon.Close();
            }


            {
                try
                {

                    {

                        SqlConnection Scon;

                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;

                        sql = "DELETE FROM course_topics WHERE week LIKE '" + GridView2.Rows[0].Cells[2].Text +  "%' ";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Cmd.ExecuteNonQuery();
                        Scon.Close();

                    }
                    {

                        SqlConnection Scon;

                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;

                        sql = "DELETE FROM question_table WHERE l_outcomes LIKE '" + GridView2.Rows[0].Cells[2].Text + "%' AND copy_type ='" + "databank" + "'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Cmd.ExecuteNonQuery();
                        Scon.Close();

                    }
                    for (int jjj = 0; jjj < GridView2.Rows.Count; jjj++)
                    {
                        if (GridView2.Rows[jjj].Cells[2].Text.Contains("WEEK"))
                        {
                            //{
                            //    //string ak = GridView2.Rows[jjj].Cells[2].Text.ToUpper();
                            //    //MessageBox(ak);
                            //    SqlConnection Scon;
                            //    SqlDataReader Reader;
                            //    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            //    string sql;
                            //    sql = "Insert into learnObjectives Values('" + GridView2.Rows[0].Cells[2].Text.ToUpper() + "-" + GridView2.Rows[jjj].Cells[2].Text.ToUpper() + "','" + GridView2.Rows[0].Cells[2].Text.ToUpper() + "','" + GridView2.Rows[jjj].Cells[3].Text.ToUpper() + "')";
                            //    Scon = new SqlConnection(sConnection);
                            //    Scon.Open();
                            //    Cmd = new SqlCommand(sql, Scon);
                            //    Reader = Cmd.ExecuteReader();
                            //    Reader.Close();
                            //    Scon.Close();
                            //}
                        }
                        else if (GridView2.Rows[jjj].Cells[3].Text.Contains("LO"))
                        {
                           
                            {

                                SqlConnection Scon;
                                SqlDataReader Reader;
                                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql;
                                sql = "Insert into course_topics Values('" + GridView2.Rows[0].Cells[2].Text.ToUpper() + ":" + GridView2.Rows[jjj].Cells[3].Text.ToUpper() + ":" + System.DateTime.Now.Millisecond.ToString().Substring(0,3)+ "','" + GridView2.Rows[jjj].Cells[2].Text.ToUpper() + "','" + GridView2.Rows[jjj].Cells[3].Text.ToUpper() + "','"+GridView2.Rows[0].Cells[2].Text.ToUpper() + "-" + GridView2.Rows[jjj].Cells[5].Text.ToUpper() +"','"+GridView2.Rows[jjj].Cells[4].Text.ToUpper()+"')";
                               
                                Scon = new SqlConnection(sConnection);
                                Scon.Open();
                                Cmd = new SqlCommand(sql, Scon);
                                Reader = Cmd.ExecuteReader();
                                Reader.Close();
                                Scon.Close();
                            }
                        }
                    }
                    string mes = "The course syllabus of the course (" + GridView2.Rows[0].Cells[2].Text + ") was successfully updated.";
                    MessageBox(mes);
                    GridView1.DataBind();
                }
                catch
                {
                    MessageBox("Error uploading file. Please select a valid Excel file.");
                }
            }


        }
    
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
    //    string hopya = GridView1.SelectedValue.ToString();
    //MessageBox(hopya);
        {
            SqlConnection Scon2;
            SqlDataReader Reader2;
            SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql2;
            sql2 = " DELETE FROM course_topics where  topic_id ='" + GridView1.SelectedValue.ToString() + "'";
            Scon2 = new SqlConnection(sConnection2);
            Scon2.Open();
            Cmd2 = new SqlCommand(sql2, Scon2);
            Reader2 = Cmd2.ExecuteReader();
        }
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "SELECT        course_topics.l_o, course_topics.week, course_topics.c_o, question_table.l_outcomes, question_table.l_o AS Expr1, question_table.c_o AS Expr2 FROM  question_table INNER JOIN course_topics ON question_table.l_outcomes = course_topics.week AND question_table.l_o = course_topics.l_o AND question_table.c_o = course_topics.c_o WHERE topic_id ='" + GridView1.SelectedValue.ToString() + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = " DELETE FROM question_table where l_outcomes = '" + Reader["week"].ToString() + "' AND  question_table.l_o ='" + Reader["l_o"].ToString() + "' AND question_table.c_o = '" + Reader["c_o"].ToString() + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                }


            }
            Reader.Close();
            Scon.Close();
        }

        MessageBox("Item(s) was successfully deleted");
        LinkButton4.Visible = false;
        GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LinkButton4.Focus();
        LinkButton4.Text = "Are you sure you want to delete this? All questions tagged on this topic will also be deleted. Pls click this link to continue.";
        LinkButton4.Visible = true;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        adddata();
        LinkButton5.Visible = false;
    }
}
