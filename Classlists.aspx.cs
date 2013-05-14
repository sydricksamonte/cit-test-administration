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
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    string user;
    string excelFile = "";

    string sec;
    string course;
    string line = ""; string ops = ""; string termNow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            Panel1.Visible = false;
            Label11.Visible = false;
            user = Page.Session["user"].ToString();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
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
                   Button1.Text = "Add this classlist as S.Y. " + Reader["term"].ToString();
                   termNow = Reader["term"].ToString();
                }
                Reader.Close();
                Scon.Close();
            }
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select type From user_table WHERE user_id = '" + user + "' ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    string type = Reader["type"].ToString();
                    if (type == "STUDENT")
                    {
                        Response.Redirect("LogIn.aspx");
                        break;
                    }
                }
                Reader.Close();
                Scon.Close();

            }
            try
            {
                //Page.Session["exname"] = exname;

                Page.Session["user"] = user;
                ops = Page.Session["operation"].ToString();
                FileUpload1.Focus();    
            }
            catch { }
           StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
          
           line = sr2.ReadLine();
            SqlDataSource1.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

         
        }
       
    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string OKs = "false";
  
        Page.Session["warn"] = OKs;


        sec = drpSec.Text;
        course = drpCourse.Text;
        Page.Session["user"] = user;
        Page.Session["section"] = sec;
        
         Page.Session["course"] = course;

        Response.Redirect("ClasslistEditor.aspx");
    }
    protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            drpSec.Items.Clear();
           
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From course WHERE course_id = '" +  drpCourse.SelectedValue.ToString()+"' AND sec_handler = '" +  user+ "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                drpSec.Items.Add(Reader["course_sec"].ToString());
               
            }
            Reader.Close();
            Scon.Close();
            drpSec.Focus();
        }
    }
    protected void drpCourse_DataBound(object sender, EventArgs e)
    {
        drpSec.Enabled = true;
        
        {

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From course WHERE course_id = '" + drpCourse.Text + "' AND sec_handler = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
              
                drpSec.Items.Add( Reader["course_sec"].ToString());
            }
            Reader.Close();
            Scon.Close();
        }
        if (drpSec.Text == "")
        {
            ImageButton3.Enabled = false;
        }
        else
        {
            ImageButton3.Enabled = true;
        }
    }
    int j = 0; string imLine = ""; DataClassExcel myDataSet = new DataClassExcel(); DataClassExcel myDataSet2 = new DataClassExcel();
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
                string sql = "Select F1 AS[A],F2 AS [B] ,F4 AS [C],F5 AS[D] From [Sheet1$] WHERE (F4 LIKE '%(%') OR (F6 LIKE '%20%') ";
                OleDbConnection con = new OleDbConnection(sConnection);
                con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                //           DataSet ds = new mydata();

                adapter.Fill(myDataSet.Tables[0]);

                GridView1.DataSource = myDataSet.Tables[0];
                GridView1.DataBind();


            }
            catch
            {
                Label11.Visible = true;
              
                MessageBox("File is invalid. Please choose a valid class list Excel file to continue this operation.");
            }

        }
        else
        {
            MessageBox("Please select a class list Excel file.");
        }
    }
   
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        prevgrid();
    }
    string coursedesc = "";
    private void adddata()
    {
       
         string termino = "";
         if (FileUpload1.HasFile == true)
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
             string heiti = "";
             string seccon = "";
             {
                 SqlConnection Scon;
                 SqlDataReader Reader;
                 SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                 string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                 string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                 string sql;
                 sql = "Select * From course WHERE term = '" + termino + "' and sec_handler = '" + user + "' ";
                 Scon = new SqlConnection(sConnection);
                 Scon.Open();
                 Cmd = new SqlCommand(sql, Scon);
                 Reader = Cmd.ExecuteReader();

                 while (Reader.Read())
                 {
                     heiti = Reader["course_id"].ToString()+" "+heiti;
                    // seccon = Reader["course_sec"].ToString() + " " + seccon;
                 }
                 Reader.Close();
                 Scon.Close();
             }
             {
                 SqlConnection Scon;
                 SqlDataReader Reader;
                 SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                 string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                 string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                 string sql;
                 sql = "Select * From course WHERE term = '"+termino+"' and sec_handler = '" + user + "' and  course_id = '" + GridView1.Rows[0].Cells[4].Text + "'";
                 Scon = new SqlConnection(sConnection);
                 Scon.Open();
                 Cmd = new SqlCommand(sql, Scon);
                 Reader = Cmd.ExecuteReader();

                 while (Reader.Read())
                 {
                   
                     seccon = Reader["course_sec"].ToString() + " " + seccon;
                 }
                 Reader.Close();
                 Scon.Close();
             }
             {
                 try
                 {
                     //if (GridView1.Rows[0].Cells[3].Text.Contains("4"))
                     //{
                     //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/4T";
                     //}
                     //else if (GridView1.Rows[0].Cells[3].Text.Contains("3"))
                     //{
                     //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/3T";
                     //}
                     //else if (GridView1.Rows[0].Cells[3].Text.Contains("2"))
                     //{
                     //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/2T";
                     //}
                     //else if (GridView1.Rows[0].Cells[3].Text.Contains("1"))
                     //{
                     //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/1T";
                     //}
                 }
                 catch
                 {
                 //   ("Error uploading file. Please select a valid Excel file.");
                 }
             }
             //string uge = GridView1.Rows[0].Cells[5].Text.Trim() + " ..." + heiti;
             //MessageBox(uge);
            // MessageBox(seccon);
             if ((heiti.Contains(GridView1.Rows[0].Cells[4].Text.Trim()))==false)
             {
                 {
                     SqlConnection Scon;
                     SqlDataReader Reader;
                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                     string sql;
                     sql = "Select * From course WHERE sec_handler = '" + user + "' ";
                     Scon = new SqlConnection(sConnection);
                     Scon.Open();
                     Cmd = new SqlCommand(sql, Scon);
                     Reader = Cmd.ExecuteReader();

                     while (Reader.Read())
                     {
                         coursedesc = Reader["course_id"].ToString();

                     }
                     Reader.Close();
                     Scon.Close();
                 }
                // Panel1.Visible = true;
                 string hala = "The course of the class list is not on your current course load";
                 MessageBox(hala);
             }
             else if (((seccon.Contains(GridView1.Rows[0].Cells[5].Text.Trim())) == false) && (heiti.Contains(GridView1.Rows[0].Cells[4].Text.Trim()) == true))
             {
                 string hala = "The section of the class list is not on your current course load";
                 MessageBox(hala);
             }
             else
             {

                 if (termino == termNow)
                 {
                     try
                     {

                         int count = GridView1.Rows.Count;



                         {
                             SqlConnection Scon;
                             SqlDataReader Reader;
                             SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                             string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                             string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                             string sql;
                             sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "' ";
                             Scon = new SqlConnection(sConnection);
                             Scon.Open();
                             Cmd = new SqlCommand(sql, Scon);
                             Reader = Cmd.ExecuteReader();

                             while (Reader.Read())
                             {
                                 coursedesc = Reader["course_desc"].ToString();

                             }
                             Reader.Close();
                             Scon.Close();
                         }

                         for (int i = 0; i < count; i++)
                         {
                             {
                                 //if (GridView1.Rows[0].Cells[3].Text.Contains("4"))
                                 //{
                                 //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/4T";
                                 //}
                                 //else if (GridView1.Rows[0].Cells[3].Text.Contains("3"))
                                 //{
                                 //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/3T";
                                 //}
                                 //else if (GridView1.Rows[0].Cells[3].Text.Contains("2"))
                                 //{
                                 //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/2T";
                                 //}
                                 //else if (GridView1.Rows[0].Cells[3].Text.Contains("1"))
                                 //{
                                 //    termino = GridView1.Rows[0].Cells[2].Text.Substring(0, 4) + "-" + GridView1.Rows[0].Cells[2].Text.Substring(4) + "/1T";
                                 //}
                             }

                             if (i == 0)
                             {
                                 {

                                     SqlConnection Scon;

                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;

                                     sql = "DELETE FROM classlist WHERE prof_id = '" + user + "' AND course_code = '" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "' AND sec = '" + GridView1.Rows[0].Cells[5].Text + "'";
                                     Scon = new SqlConnection(sConnection);
                                     Scon.Open();
                                     Cmd = new SqlCommand(sql, Scon);
                                     Cmd.ExecuteNonQuery();
                                     Scon.Close();
                                     //string maga = "Classlist "+ course+" with section "+sec+" has been found on the database and has been updated.";
                                     //MessageBox(maga);
                                 }

                                 //SqlConnection Scon;
                                 //SqlDataReader Reader;
                                 //SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                 //string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                 //string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                 //string sql;
                                 //sql = "Insert into course Values('" + user + ":" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + ":" + GridView1.Rows[0].Cells[5].Text + "','" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[0].Cells[5].Text + "','" + user + "','" + termino + "')";

                                 ////       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                 //Scon = new SqlConnection(sConnection);
                                 //Scon.Open();
                                 //Cmd = new SqlCommand(sql, Scon);
                                 //Reader = Cmd.ExecuteReader();
                             }
                             else
                             {

                                 SqlConnection Scon;
                                 SqlDataReader Reader;
                                 SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                 string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                 string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                 string sql;
                                 sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[2].Text.ToUpper() + ":" + GridView1.Rows[0].Cells[5].Text.ToUpper() + ":" + GridView1.Rows[0].Cells[4].Text.ToUpper().Replace(" ", "") + ":" + termino + "','" + GridView1.Rows[i].Cells[2].Text.ToUpper() + "','" + user + "','" + GridView1.Rows[0].Cells[5].Text + "','" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "','" + GridView1.Rows[i].Cells[4].Text.ToUpper() + "')";

                                 //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                 Scon = new SqlConnection(sConnection);
                                 Scon.Open();
                                 Cmd = new SqlCommand(sql, Scon);
                                 Reader = Cmd.ExecuteReader();
                                 Reader.Close();
                                 Scon.Close();
                             }

                             try
                             {
                                 if (GridView1.Rows[i + 1].Cells[0].Text == "")
                                 {
                                     break;
                                 }
                             }
                             catch { }
                         }
                         string OKs = "true";
                         sec = DropDownList2.Text;
                         course = DropDownList1.Text;
                         Page.Session["user"] = user;
                         Page.Session["section"] = GridView1.Rows[0].Cells[5].Text;

                         Page.Session["course"] = GridView1.Rows[0].Cells[4].Text.Replace(" ", "");
                         Page.Session["warn"] = OKs;
                         Response.Redirect("ClasslistEditor.aspx");

                     }
                     catch
                     {

                         //  Label11.Visible = true;
                         // Label11.Text = "A classlist exist!";
                         //  MessageBox("A classlist exist!\n Uploading tip: To make a successful classlist upload \nmake sure that the excel file is in the CORRECT MCL FORMAT, e.g. Student number should be found on Row A, followed by Student Name, which should be in Row B. \nIts worksheet name should be named Sheet1");
                         //    MessageBox("a");
                         //  MessageBox("File already exist.");
                     }
                 }

                 else
                 {
                     Label3.Text = "The classlist you are trying to upload is in the term " + termino + " which is not the current term";
                     Panel1.Visible = true;
                     //  Button1.Visible = true;
                     Panel1.Focus();
                 }
             }
         }


         else
         {
             //    Label11.Visible = true;
             MessageBox("No file selected");

         }
    }
   

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUpload1.HasFile == true)
        {
            
            prevgrid();
          
            {
                adddata();
            }
        }
        else
        {
            adddata();
        }
    

    }
    protected void drpSec_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drpCourse2_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
         
            DropDownList2.Items.Clear();
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From course WHERE course_id = '" + drpCourse.SelectedValue.ToString() + "' AND sec_handler = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
              
                DropDownList2.Items.Add(Reader["course_sec"].ToString());
            }
            Reader.Close();
            Scon.Close();
            DropDownList2.Focus();
        }
    }
    protected void drpCourse2_DataBound(object sender, EventArgs e)
    {
       
        DropDownList2.Enabled = true;
        {

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From course WHERE course_id = '" + drpCourse.Text + "' AND sec_handler = '" + user + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                DropDownList2.Items.Add(Reader["course_sec"].ToString());
               
            }
            Reader.Close();
            Scon.Close();
        }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        prevgrid();
        {
            try
            {

                int count = GridView1.Rows.Count;
                string termino = "";


                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "' ";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        coursedesc = Reader["course_desc"].ToString();

                    }
                    Reader.Close();
                    Scon.Close();
                }

                for (int i = 0; i < count; i++)
                {
                    termino = termNow;
                    if (i == 0)
                    {
                        {

                            SqlConnection Scon;

                            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql;

                            sql = "DELETE FROM classlist WHERE prof_id = '" + user + "' AND course_code = '" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "' AND sec = '" + GridView1.Rows[0].Cells[5].Text + "'";
                            Scon = new SqlConnection(sConnection);
                            Scon.Open();
                            Cmd = new SqlCommand(sql, Scon);
                            Cmd.ExecuteNonQuery();
                            Scon.Close();
                            //string maga = "Classlist "+ course+" with section "+sec+" has been found on the database and has been updated.";
                            //MessageBox(maga);
                        }

                        //SqlConnection Scon;
                        //SqlDataReader Reader;
                        //SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        //string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        //string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        //string sql;
                        //sql = "Insert into course Values('" + user + ":" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + ":" + GridView1.Rows[0].Cells[5].Text + "','" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[0].Cells[5].Text + "','" + user + "','" + termino + "')";

                        ////       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                        //Scon = new SqlConnection(sConnection);
                        //Scon.Open();
                        //Cmd = new SqlCommand(sql, Scon);
                        //Reader = Cmd.ExecuteReader();
                    }
                    else
                    {

                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[2].Text.ToUpper() + ":" + GridView1.Rows[0].Cells[5].Text.ToUpper() + ":" + GridView1.Rows[0].Cells[4].Text.ToUpper().Replace(" ", "") + ":" + termino + "','" + GridView1.Rows[i].Cells[2].Text.ToUpper() + "','" + user + "','" + GridView1.Rows[0].Cells[5].Text + "','" + GridView1.Rows[0].Cells[4].Text.Replace(" ", "") + "','" + GridView1.Rows[i].Cells[4].Text.ToUpper() + "')";

                        //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();
                        Reader.Close();
                        Scon.Close();
                    }

                    try
                    {
                        if (GridView1.Rows[i + 1].Cells[0].Text == "")
                        {
                            break;
                        }
                    }
                    catch { }
                }
                string OKs = "true";
                sec = DropDownList2.Text;
                course = DropDownList1.Text;
                Page.Session["user"] = user;
                Page.Session["section"] = GridView1.Rows[0].Cells[5].Text;

                Page.Session["course"] = GridView1.Rows[0].Cells[4].Text.Replace(" ", "");
                Page.Session["warn"] = OKs;
                Response.Redirect("ClasslistEditor.aspx");

            }
            catch
            {

                //  Label11.Visible = true;
                // Label11.Text = "A classlist exist!";
                //  MessageBox("A classlist exist!\n Uploading tip: To make a successful classlist upload \nmake sure that the excel file is in the CORRECT MCL FORMAT, e.g. Student number should be found on Row A, followed by Student Name, which should be in Row B. \nIts worksheet name should be named Sheet1");
                //    MessageBox("a");
                MessageBox("File already exist.");
            }
        }
    }
}
