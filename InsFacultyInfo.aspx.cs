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

public partial class Home : System.Web.UI.Page
{
    string excelFile = "";
    string user; string term; string line = ""; string fac = "";
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            user = Page.Session["user"].ToString();
            checkUser();
         //   fac = Page.Session["fac"].ToString();
            try
            {
                if (Page.Session["message"].ToString() != "")
                {
                    MessageBox(Page.Session["message"].ToString());
                }
                else
                { }

                Page.Session["message"] = "";
              

            }
            catch { }

            StreamReader sr44 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr44.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource1.ConnectionString = sConnection2;

            //    SqlDataSource6.ConnectionString = sConnection2;
            {
                //string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

                //SqlConnection Scon;
                //SqlDataReader Reader;
                //SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                //string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                //string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                //string sql;
                //sql = "Select * From user_table WHERE user_id = '" + fac + "' ";
                //Scon = new SqlConnection(sConnection);
                //Scon.Open();
                //Cmd = new SqlCommand(sql, Scon);
                //Reader = Cmd.ExecuteReader();

                //while (Reader.Read())
                //{
                //    Label8.Text = ((Reader["fname"].ToString()) + " " + (Reader["lname"].ToString()) + " (" + (Reader["bname"].ToString()) + ")");
                //    Label9.Text = Reader["user_id"].ToString();
                //}
                //Reader.Close();
                //Scon.Close();

            }
            //{
            //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            //    SqlConnection Scon;
            //    SqlDataReader Reader;
            //    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            //    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //    string sql;
            //    sql = "Select * From course WHERE user_id = '" + fac + "' ";
            //    Scon = new SqlConnection(sConnection);
            //    Scon.Open();
            //    Cmd = new SqlCommand(sql, Scon);
            //    Reader = Cmd.ExecuteReader();

            //    while (Reader.Read())
            //    {
            //        Label8.Text = ((Reader["fname"].ToString()) + " " + (Reader["lname"].ToString()) + " (" + (Reader["type"].ToString()) + ")");
            //        Label9.Text = Reader["user_id"].ToString();
            //    }
            //    Reader.Close();
            //    Scon.Close();

            //}
        }
    
    }
    public void checkUser()
    {
        {
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
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
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
       
    }
    protected void ins(object sender, EventArgs e)
    {
      
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        {
            //SqlConnection Scon2;
            //SqlDataReader Reader2;
            //SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
            //string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //string sql2;
            //sql2 = " DELETE FROM course_bulk where course = '" + exname + "'";
            //Scon2 = new SqlConnection(sConnection2);
            //Scon2.Open();
            //Cmd2 = new SqlCommand(sql2, Scon2);
            //Reader2 = Cmd2.ExecuteReader();
        }
        Label14.Text = "Assigned course to faculty has been deleted."; 
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
   //     Response.Redirect("AdCourses.aspx");
       
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
     
    }
    int j = 0; string imLine = ""; DataClassExcel myDataSet = new DataClassExcel(); DataClassExcel myDataSet2 = new DataClassExcel();
    private void prevgrid()
    {
        // if (FileUpload1.HasFile == true)
        try
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
            mars = 1;

        }
        catch
        //      else
        {

            MessageBox("No file found or file is invalid! Choose a valid Faculty class schedule file to continue this operation.");
        }

    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        if (FileUpload1.HasFile == true)
        {
            prevgrid();
       
            {
                adddata();
                GridView11.DataBind();
            }
        }
        else
        {
            adddata();
        }
    }
    string coursedesc = ""; int mars = 0;
    private void adddata()
    {
        string termino = ""; string users = ""; int evener = 0;
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

            try
            {

                int count = GridView1.Rows.Count;

                //{
                //    SqlConnection Scon2;
                //    SqlDataReader Reader2;
                //    SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                //    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                //    string sql2;
                //    sql2 = " DELETE FROM course where sec_handler = '" + user +  "'";
                //    Scon2 = new SqlConnection(sConnection2);
                //    Scon2.Open();
                //    Cmd2 = new SqlCommand(sql2, Scon2);
                //    Reader2 = Cmd2.ExecuteReader();
                //    Reader2.Close();
                //    Scon2.Close();
                //}


                int x = 0; int y = 0;

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
                                sql = "Select * From user_table WHERE lname LIKE '" + GridView1.Rows[count - 2].Cells[6].Text.Substring(0, 5) + "%'";
                                Scon = new SqlConnection(sConnection);
                                Scon.Open();
                                Cmd = new SqlCommand(sql, Scon);
                                Reader = Cmd.ExecuteReader();

                                while (Reader.Read())
                                {
                                    users = Reader["user_id"].ToString();
                             
                                }
                                Reader.Close();
                                Scon.Close();
                            }
                            if (user != users)
                            {
                                if (x == 0)
                                {
                                    MessageBox("The file you are trying to add is not your schedule. ");
                                    x = 1;
                                }
                            }
                            else
                            {
                                if (y ==0)
                                {
                                    SqlConnection Scon2;
                                    SqlDataReader Reader2;
                                    SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql2;
                                    sql2 = " DELETE FROM course where sec_handler = '" + user + "'";
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
                                    sql = "Select * From course_data WHERE course_id = '" + GridView1.Rows[i].Cells[2].Text.ToUpper().Replace(" ", "") + "' ";
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
                                    sql = "Insert into course Values('" + user + ":" +termino+":"+ GridView1.Rows[i].Cells[2].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[2].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[2].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[2].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                    sql = "Insert into course Values('" + user + ":" + termino + ":" + GridView1.Rows[i].Cells[3].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[3].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[3].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[3].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                    sql = "Insert into course Values('" + user + ":" + termino + ":" + GridView1.Rows[i].Cells[4].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[4].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[4].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[4].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                    sql = "Insert into course Values('" + user + ":" + termino + ":" + GridView1.Rows[i].Cells[5].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[5].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[5].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[5].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                    sql = "Insert into course Values('" + user + ":" + termino + ":" + GridView1.Rows[i].Cells[6].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[6].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[6].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[6].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                    sql = "Insert into course Values('" + user + ":" + termino + ":" + GridView1.Rows[i].Cells[7].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[7].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[7].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[7].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                    sql = "Insert into course Values('" + user + ":" + termino + ":" + GridView1.Rows[i].Cells[8].Text.ToUpper() + ":" + GridView1.Rows[i + 1].Cells[8].Text.ToUpper().Replace(" ", "") + "','" + GridView1.Rows[i].Cells[8].Text.ToUpper().Replace(" ", "") + "','" + coursedesc + "','" + GridView1.Rows[i + 1].Cells[8].Text.ToUpper().Replace(" ", "") + "','" + user + "','" + termino + "')";

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
                                if (mars == 1)
                                {
                                    string logUser = "";
                                    {
                                        SqlConnection Scon;
                                        SqlDataReader Reader;
                                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                                        string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                        string sql;
                                        sql = "Select * From user_table WHERE user_id = '" + user + "' ";
                                        Scon = new SqlConnection(sConnection);
                                        Scon.Open();
                                        Cmd = new SqlCommand(sql, Scon);
                                        Reader = Cmd.ExecuteReader();

                                        while (Reader.Read())
                                        {
                                            logUser = Reader["prog"].ToString();

                                        }
                                        Reader.Close();
                                        Scon.Close();

                                    }
                                    {
                                        SqlConnection Scon6;
                                        SqlDataReader Reader6;
                                        SqlCommand Cmd6; StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr6.ReadLine();
                                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                        string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                        string sql6;
                                        sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Updated faculty member ["+user+"] class file" + "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
                                        Scon6 = new SqlConnection(sConnection6);
                                        Scon6.Open();
                                        Cmd6 = new SqlCommand(sql6, Scon6);
                                        Reader6 = Cmd6.ExecuteReader();
                                        Reader6.Close();
                                        Scon6.Close();
                                      
                                    }
                                    MessageBox("Update was successful!");
                                    mars = 2;
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
                Page.Session["warn"] = OKs;
        
            }

            catch
            {

            }
        }
        else
        {
          
            MessageBox("No file selected");

        }
    }
   
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
