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
    string line = ""; string ops = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
          
            user = Page.Session["user"].ToString();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
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
            }
            catch { }
           StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
          
           line = sr2.ReadLine();
            SqlDataSource1.ConnectionString = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

         
        }
       
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "SELECT * FROM user_table WHERE type ='" + "Faculty" + "' ORDER BY lname";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                drpCourse.Items.Add(Reader["prog"].ToString());
           
            }
            Reader.Close();
            Scon.Close();

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
        int muka = 0;
        muka=drpCourse.Text.Length;
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "SELECT * FROM user_table WHERE prog = '" + drpCourse.Text + "'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                Page.Session["fac"] = Reader["user_id"].ToString();
       
            }
            Reader.Close();
            Scon.Close();

        }
        string OKs = "false";
  
        Page.Session["warn"] = OKs;


    
        course = drpCourse.Text;
        Page.Session["user"] = user;


        Response.Redirect("AdFacultyInfo.aspx");
        drpCourse.Items.Clear();
    }
    protected void drpCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
         
           
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
             //   drpSec.Items.Add(Reader["course_sec"].ToString());
               
            }
            Reader.Close();
            Scon.Close();
           
        }
    }
    protected void drpCourse_DataBound(object sender, EventArgs e)
    {
     
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
              
             //   drpSec.Items.Add( Reader["course_sec"].ToString());
            }
            Reader.Close();
            Scon.Close();
        }
   
    }
    int j = 0; string imLine = ""; DataClassExcel myDataSet = new DataClassExcel(); DataClassExcel myDataSet2 = new DataClassExcel();
    private void prevgrid()
    {
        // if (FileUpload1.HasFile == true)
        //  try{
        // try
        {
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//imLoc.txt"); imLine = sr.ReadLine();
            //Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};dbq=C:\inetpub\wwwroot\CITEXAMSYSTEM\Classlist\201111103496IT130-B51.xls;defaultdir=C:\inetpub\wwwroot\CITEXAMSYSTEM\Classlist;driverid=1046;fil=excel 12.0;filedsn=C:\inetpub\wwwroot\CITEXAMSYSTEM\conExcel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid=admin;usercommitsync=Yes
            excelFile = @FileUpload1.PostedFile.FileName;
            string neww = Convert.ToString(Directory.GetParent(FileUpload1.PostedFile.FileName));
            string oxi = imLine + @"\Classlist\" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FileUpload1.FileName;
            string newww = Convert.ToString(neww + @"\Classlist\" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FileUpload1.FileName);
            FileUpload1.SaveAs(oxi);

            string sConnection = "Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + oxi + ";" + "Extended Properties=Excel 8.0;";
          //  string sql = "Select F2 AS[A],F4 AS [B] ,F6 AS [C],F8 AS[D], F10 AS [E], F12 AS [F], F14 AS [G] From [Schedule$] WHERE (F2 NOT EQUAL '" + "" + "') OR (F4 NOT EQUAL '" + "" + "') OR (F6 NOT EQUAL '" + "" + "') OR (F8 NOT EQUAL '" + "" + "') OR (F10 NOT EQUAL '" + "" + "')OR (F12 NOT EQUAL '" + "" + "')OR (F14 NOT EQUAL '" + "" + "')";
            string sql = "Select F2 AS[A],F4 AS [B] ,F6 AS [C],F8 AS[D], F10 AS [E], F12 AS [F], F14 AS [G] From [Schedule$] WHERE (F2 <> '') OR (F4 <> '')  OR (F6 <> '') OR (F8 <> '') OR (F10 <> '') OR (F12 <> '') OR (F14 <> '')   ";
        
            OleDbConnection con = new OleDbConnection(sConnection);
            con.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
            //           DataSet ds = new mydata();

            adapter.Fill(myDataSet.Tables[0]);

            GridView1.DataSource = myDataSet.Tables[0];
            GridView1.DataBind();


        }
        //      catch
        ////      else
        //      {

        //        MessageBox("No file found! Choose an Excel file to continue this operation.");
        //    }

    }
   
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        prevgrid();
    }
    string coursedesc = "";
    private void adddata()
    {
        string termino = ""; string facid = ""; int evener = 0; int y = 0;
         if (FileUpload1.HasFile==true)
         {
             {
                 SqlConnection Scon;
                 SqlDataReader Reader;
                 SqlCommand Cmd;  StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");  line = sr.ReadLine();

                 string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                 string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
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

             //try
             {

                 int count = GridView1.Rows.Count;

                

                
                

                 for (int i = 0; i < count; i++)
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
                     if (i == 0)
                     {
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

                     else if (i == count - 1)
                     {
                     }
                     else
                     {
                         if (evener == 0)
                         {
                             {
                                 SqlConnection Scon;
                                 SqlDataReader Reader;
                                 SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                 string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                 string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                 string sql;
                                 sql = "Select * From user_table WHERE prog =  '" + GridView1.Rows[count - 2].Cells[6].Text + "'";
                                 Scon = new SqlConnection(sConnection);
                                 Scon.Open();
                                 Cmd = new SqlCommand(sql, Scon);
                                 Reader = Cmd.ExecuteReader();

                                 while (Reader.Read())
                                 {
                                     facid = Reader["user_id"].ToString();

                                 }
                                 Reader.Close();
                                 Scon.Close();
                             }
                             MessageBox(GridView1.Rows[count - 2].Cells[6].Text);
                             if (facid == "")
                             {
                                 LinkButton1.Text ="Faculty member "+ GridView1.Rows[count - 2].Cells[6].Text + " was not found on the database. Please click this link to add";
                             }
                             else
                             {
                                 if (y == 0)
                                 {
                                     SqlConnection Scon2;
                                     SqlDataReader Reader2;
                                     SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                                     string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql2;
                                     sql2 = " DELETE FROM course where sec_handler = '" + facid + "'";
                                     Scon2 = new SqlConnection(sConnection2);
                                     Scon2.Open();
                                     Cmd2 = new SqlCommand(sql2, Scon2);
                                     Reader2 = Cmd2.ExecuteReader();
                                     Reader2.Close();
                                     Scon2.Close();
                                     y = 1;
                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[2].Text.ToUpper().Replace("P", "") + "' OR course_id = '" + GridView1.Rows[i].Cells[2].Text.ToUpper().Replace("L", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" +termino+":"+ GridView1.Rows[i].Cells[2].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[2].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[2].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[2].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                    
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[2].Text.Contains("IT")) || (GridView1.Rows[i].Cells[2].Text.Contains("CS")) || (GridView1.Rows[i].Cells[2].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[2].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader(); Reader.Close();
                                                 Scon.Close();
                                             }
                                         }
                                         //else if (GridView1.Rows[i].Cells[4].Text == "")
                                         //{
                                         //}
                                         //else if (GridView1.Rows[i].Cells[6].Text == "")
                                         //{
                                         //}
                                         //else if (GridView1.Rows[i].Cells[8].Text == "")
                                         //{
                                         //}
                                         //else if (GridView1.Rows[i].Cells[10].Text == "")
                                         //{
                                         //}
                                         //else if (GridView1.Rows[i].Cells[12].Text == "")
                                         //{
                                         //}
                                         //else if (GridView1.Rows[i].Cells[14].Text == "")
                                         //{
                                         //}
                                         else
                                         {

                                         }
                                     }
                                     catch { }

                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[3].Text.ToUpper().Replace(" ", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" +termino+":"+ GridView1.Rows[i].Cells[3].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[3].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[3].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[3].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                 
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[3].Text.Contains("IT")) || (GridView1.Rows[i].Cells[3].Text.Contains("CS")) || (GridView1.Rows[i].Cells[3].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[3].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader(); Reader.Close();
                                                 Scon.Close();
                                             }
                                         }

                                     }
                                     catch { }

                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[4].Text.ToUpper().Replace(" ", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" +termino+":"+ GridView1.Rows[i].Cells[4].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[4].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[4].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[4].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                   
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[4].Text.Contains("IT")) || (GridView1.Rows[i].Cells[4].Text.Contains("CS")) || (GridView1.Rows[i].Cells[4].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[4].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader(); Reader.Close();
                                                 Scon.Close();
                                             }
                                         }

                                     }
                                     catch { }

                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[5].Text.ToUpper().Replace(" ", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" +termino+":"+ GridView1.Rows[i].Cells[5].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[5].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[5].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[5].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                    
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[5].Text.Contains("IT")) || (GridView1.Rows[i].Cells[5].Text.Contains("CS")) || (GridView1.Rows[i].Cells[5].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[5].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader(); Reader.Close();
                                                 Scon.Close();
                                             }
                                         }

                                     }
                                     catch { }

                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[6].Text.ToUpper().Replace(" ", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" + termino + ":" + GridView1.Rows[i].Cells[6].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[6].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[6].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[6].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                     
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[6].Text.Contains("IT")) || (GridView1.Rows[i].Cells[6].Text.Contains("CS")) || (GridView1.Rows[i].Cells[6].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[6].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader(); Reader.Close();
                                                 Scon.Close();
                                             }
                                         }

                                     }
                                     catch { }

                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[7].Text.ToUpper().Replace(" ", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" + termino + ":" + GridView1.Rows[i].Cells[7].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[7].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[7].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[7].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                    
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[7].Text.Contains("IT")) || (GridView1.Rows[i].Cells[7].Text.Contains("CS")) || (GridView1.Rows[i].Cells[7].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[7].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader(); Reader.Close();
                                                 Scon.Close();
                                             }
                                         }

                                     }
                                     catch { }

                                 }
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();

                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[8].Text.ToUpper().Replace(" ", "") + "' ";
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
                                 {
                                     SqlConnection Scon;
                                     SqlDataReader Reader;
                                     SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                     string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                     string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                     string sql;
                                     sql = "Insert into course Values('" + facid + ":" + termino + ":" + GridView1.Rows[i].Cells[8].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[8].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[8].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[8].Text.ToUpper().Replace(" ", "") + "','" + facid + "','" + termino + "')";

                                     //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                                   
                                     try
                                     {
                                         if ((GridView1.Rows[i].Cells[8].Text.Contains("IT")) || (GridView1.Rows[i].Cells[8].Text.Contains("CS")) || (GridView1.Rows[i].Cells[8].Text.Contains("CPE")))
                                         {
                                             if (GridView1.Rows[i + 1].Cells[8].Text.Length == 3)
                                             {
                                                 Scon = new SqlConnection(sConnection);
                                                 Scon.Open();
                                                 Cmd = new SqlCommand(sql, Scon);
                                                 Reader = Cmd.ExecuteReader();
                                                 Reader.Close();
                                                 Scon.Close();
                                             }
                                         }

                                     }
                                     catch { }
                                     evener = 1;
                                 }
                             }
                         }
                         else
                         {
                             evener = 0;
                         }
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
             
                 Page.Session["user"] = user;
            

                 Page.Session["fac"] = facid;
                 Page.Session["warn"] = OKs;

                 Response.Redirect("AdFacultyInfo.aspx");

             }
             
             //catch
             //{

             //  //  Label11.Visible = true;
             //   // Label11.Text = "A classlist exist!";
             //  //  MessageBox("A classlist exist!\n Uploading tip: To make a successful classlist upload \nmake sure that the excel file is in the CORRECT MCL FORMAT, e.g. Student number should be found on Row A, followed by Student Name, which should be in Row B. \nIts worksheet name should be named Sheet1");
             ////    MessageBox("a");
             //    MessageBox("File already exist.");
             //}
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
            //if (DropDownList1.Text == "")
            //{
            //    Label11.Visible = true;
            //    Label11.Text = "Please choose the course of the classlist.";
            //}
            //else if (DropDownList2.Text == "")
            //{
            //    Label11.Visible = true;
            //    Label11.Text = "Please choose the section of the classlist.";
            //}
            //else
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
    }
    protected void drpCourse2_DataBound(object sender, EventArgs e)
    {
       
      
       
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
