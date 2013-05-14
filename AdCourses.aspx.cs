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

public partial class Images_AdUsers : System.Web.UI.Page
{
    string user; string term; string line = "";
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
            Label17.Visible = false;
            Label33.Visible = false;

            StreamReader sr44 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr44.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            SqlDataSource1.ConnectionString = sConnection2;
            SqlDataSource2.ConnectionString = sConnection2;
            SqlDataSource3.ConnectionString = sConnection2;
            SqlDataSource4.ConnectionString = sConnection2;
            SqlDataSource5.ConnectionString = sConnection2;
            //    SqlDataSource6.ConnectionString = sConnection2;
            try
            {
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
                            Page.Session["term"]=  Reader["term"].ToString();
                           
                        }
                        Reader.Close();
                        Scon.Close();
                    }
                    GridView2.DataBind();
                }
                {
                  
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select course_desc From course_data WHERE course_id = '" + DropDownList2.Items[0].Value.ToString() + "' ";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Label23.Text = Reader["course_desc"].ToString();

                    }
                    Reader.Close();
                    Scon.Close();

                }
            }
            catch { }

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool allow = true;
        try
        {
            {
                Label userIds = (Label)GridView1.Controls[0].Controls[0].FindControl("Label15");

                DropDownList DropDownList2s = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList1");

                TextBox userId = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox9");
                TextBox userNa = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox1");
                TextBox pass = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox2");
                TextBox bn = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox8");
                TextBox ln = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox6");
                TextBox fn = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox7");
                TextBox email = (TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox3");
                DropDownList gen = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList2");

                {
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";

                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select type From user_table WHERE user_na = '" + userNa.Text + "' ";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        allow = false;
                    }
                    Reader.Close();
                    Scon.Close();

                }
                try
                {
                    if (allow == true)
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Insert Into user_table VAlUES('" + userId.Text.Trim().ToUpper() + "','" + userNa.Text.Trim() + "','" + pass.Text.Trim() + "','" + DropDownList1.SelectedValue.ToString().ToUpper() + "','" + bn.Text.Trim().ToUpper() + "','" + ln.Text.Trim().ToUpper() + "','" + fn.Text.Trim().ToUpper() + "','" + email.Text.Trim().ToUpper() + "','" + gen.SelectedValue.ToString() + "','" + DropDownList2s.SelectedValue.ToString() + "')";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();
                        GridView1.DataBind();
                    }
                    else
                    {
                        userIds.Text = "Username already exists.";
                    }
                }
                catch
                {
                    userIds.Text = "Userid already exists.";
                }
            }
        }
        catch
        {

        }
    }
    protected void ins(object sender, EventArgs e)
    {
        bool allow = true;




        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From term";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                term = Reader["term"].ToString();

            }
            Reader.Close();
            Scon.Close();

        }


        try
        {
            if (TextBox9.Text.Length < 2)
            {
                Label17.Text = "Invalid section";
                Label17.Visible = true;
            }
            else
            {
                int i = 0;
                string strNme = "";
                string strType = "";

                do
                {
                    if (i == 0)
                    {
                        strNme = DropDownList2.SelectedItem.Text.ToString() + " SEATWORK";
                        strType = "SEAT";
                    }
                    if (i == 1)
                    {
                        strNme = DropDownList2.SelectedItem.Text.ToUpper() + " QUIZ";
                        strType = "QUIZ";
                    }
                    if (i == 2)
                    {
                        strNme = DropDownList2.SelectedItem.Text.ToUpper() + " 1ST LONG EXAMINATION";
                        strType = "EXAM_1";
                    }
                    if (i == 3)
                    {
                        strNme = DropDownList2.SelectedItem.Text.ToUpper() + " 2ND LONG EXAMINATION";
                        strType = "EXAM_2";
                    }
                    if (i == 4)
                    {
                        strNme = DropDownList2.SelectedItem.Text.ToUpper() + " 3RD LONG EXAMINATION";
                        strType = "EXAM_3";
                    }
                    if (i == 5)
                    {
                        strNme = DropDownList2.SelectedItem.Text.ToUpper() + " FINAL EXAMINATION";
                        strType = "EXAM_F";
                    }



                    //SqlConnection Scon;
                    //SqlDataReader Reader;
                    //SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    //string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    //string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    //string sql;
                    //sql = "Insert Into course_bulk VAlUES('" + strType + "_" + System.DateTime.Now.ToString().Trim() + System.DateTime.Now.Millisecond.ToString().Trim() + "_" + DropDownList6.Text.Trim() + "_" + term + "','" + strNme + "','" + strType + "','" + DropDownList6.Text.Trim() + "','" + DropDownList2.SelectedValue.ToString() + "','" + "0" + "')";

                    //Scon = new SqlConnection(sConnection);
                    //Scon.Open();
                    //Cmd = new SqlCommand(sql, Scon);
                    //Reader = Cmd.ExecuteReader();

                    i++;


                } while (i <= 5);


                {
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Insert Into course VAlUES('" + DropDownList6.SelectedValue.ToString() + ":" +termino+":"+ DropDownList2.SelectedValue.ToString() + ":" + TextBox9.Text.Trim().ToUpper() + "','" + DropDownList2.SelectedValue.ToString() + "','" + Label23.Text.ToUpper() + "','" + TextBox9.Text.Trim().ToUpper() + "','" + DropDownList6.SelectedValue.ToString() + "','" + term + "')";

                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();
                    GridView1.DataBind();
                    TextBox9.Text = "";
                    Label23.Text = "";
                    DropDownList2.SelectedIndex = -1;
                    DropDownList6.SelectedIndex = -1;
                    Label35.Visible = true;
                    Page.Session["message"] = "Course successfully assigned to faculty member.";
                    Response.Redirect("AdMaintenance.aspx");
                    TextBox9.Focus();
                }


            }
        }

        catch
        {
            MessageBox("A faculty member with the assigned course and section already exists.");
            //  Label17.Visible = true;
        }



    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From user_table WHERE user_id = '" + DropDownList6.SelectedValue.ToString() + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                Label22.Text = Reader["lname"].ToString() + "," + Reader["fname"].ToString() + " (" + Reader["bname"].ToString() + ")";

            }
            Reader.Close();
            Scon.Close();

        }
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select * From course WHERE handler_id = '" + DropDownList6.SelectedValue.ToString() + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                string type = Reader["type"].ToString();

            }
            Reader.Close();
            Scon.Close();

        }
        TextBox9.Focus();
        Label35.Visible = false;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList2.Focus();
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select course_desc From course_data WHERE course_id = '" + DropDownList2.SelectedValue.ToString() + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                Label23.Text = Reader["course_desc"].ToString();

            }
            Reader.Close();
            Scon.Close();

        }
        DropDownList2.Focus();
        //UpdatePanel1.Update();
        //UpdatePanel1.
    }
    protected void newAdd(object sender, EventArgs e)
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
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Insert into term_course Values('" +user+":"+ termino + ":" + TextBox4.Text.Trim().ToUpper() + ":" + TextBox3.Text.Trim().ToUpper() + "','" + TextBox4.Text.Trim().ToUpper() + "','" + TextBox3.Text.Trim().ToUpper() + "','" + DropDownList3.SelectedItem.Text + "','" + termino + "')";

                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                try
                {
                    Reader = Cmd.ExecuteReader();
                    Reader.Close();
                    Scon.Close();
                }
                catch { }
            }
            string course2 = "";
            {
                SqlConnection Scon4;
                SqlDataReader Reader4;
                SqlCommand Cmd4;
                string path4 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr4.ReadLine();
                string sConnection4 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                string sql4;
                sql4 = "Select *  From course_data WHERE course_id LIKE '%" +TextBox4.Text.Trim().ToUpper() + "%'";
                Scon4 = new SqlConnection(sConnection4);
                Scon4.Open();
                Cmd4 = new SqlCommand(sql4, Scon4);
                Reader4 = Cmd4.ExecuteReader();

                while (Reader4.Read())
                {
                    course2 = (Reader4["course_desc"].ToString());
                }
                Reader4.Close();
                Scon4.Close();
            }
         
            {
                SqlConnection Scon2;
                SqlDataReader Reader2;
                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql2;
                sql2 = "Insert Into course VAlUES('" + DropDownList3.SelectedValue.ToString() + ":" + termino + ":" + TextBox4.Text.Trim().ToUpper() + ":" + TextBox3.Text.Trim().ToUpper() + "','" + TextBox4.Text.Trim().ToUpper() + "','" + course2 + "','" + TextBox3.Text.Trim().ToUpper() + "','" + DropDownList3.Text + "','" + termino + "')";

                Scon2 = new SqlConnection(sConnection2);
                Scon2.Open();
                Cmd2 = new SqlCommand(sql2, Scon2);
                try
                {
                    Reader2 = Cmd2.ExecuteReader();
                    Reader2.Close();
                    Scon2.Close();
                }
                catch { }
            }
            MessageBox("The course has been successfully added.");
            GridView2.DataBind();
            //    DropDownList2.DataBind();
            TextBox3.Text = "";
            TextBox4.Text = "";
            //}

        }
        catch
        {
            //Label33.Visible = true;
            MessageBox("A same course ID has been found on the database.");
        }
    }
    protected void DropDownList2_DataBound(object sender, EventArgs e)
    {
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
            string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql;
            sql = "Select course_desc From course_data WHERE course_id = '" + DropDownList2.Text + "' ";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                Label23.Text = Reader["course_desc"].ToString();

            }
            Reader.Close();
            Scon.Close();

        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.DataBind();
    }
    protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        MessageBox("The item has been deleted.");
        DropDownList2.DataBind();
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        DropDownList2.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    string facid = ""; string course2 = "";
    int j = 0; string imLine = ""; DataClassExcel myDataSet = new DataClassExcel(); DataClassExcel myDataSet2 = new DataClassExcel();
    string excelFile = ""; int count = 0; string termino = "";
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile == true)
            {
                {
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//imLoc.txt"); imLine = sr.ReadLine();
                    //Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};dbq=C:\inetpub\wwwroot\CITEXAMSYSTEM\Classlist\201111103496IT130-B51.xls;defaultdir=C:\inetpub\wwwroot\CITEXAMSYSTEM\Classlist;driverid=1046;fil=excel 12.0;filedsn=C:\inetpub\wwwroot\CITEXAMSYSTEM\conExcel.dsn;maxbuffersize=2048;maxscanrows=8;pagetimeout=5;readonly=0;safetransactions=0;threads=3;uid=admin;usercommitsync=Yes
                    excelFile = @FileUpload1.PostedFile.FileName;
                    string neww = Convert.ToString(Directory.GetParent(FileUpload1.PostedFile.FileName));
                    string oxi = imLine + @"\Classlist\" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FileUpload1.FileName;
                    string newww = Convert.ToString(neww + @"\Classlist\" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + FileUpload1.FileName);
                    FileUpload1.SaveAs(oxi);

                    string strConn;
                    strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + oxi + ";" + "Extended Properties=Excel 8.0;";
                    OleDbConnection str;

                    OleDbDataAdapter myCommand = new OleDbDataAdapter("Select  [MALAYAN COLLEGES LAGUNA] AS [Course] ,F2 AS [Section], F9 AS [Instructor]  From [COLLEGE OF INFORMATION TECHNOLO$] WHERE (F7 = 'OPEN') OR (F7 = 'CLOSED') ORDER BY [MALAYAN COLLEGES LAGUNA]  ", strConn);
                    // OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT F1 AS [Student Number],F5 AS [Name] FROM [Class List$] WHERE F5 Like '%" + "(" + "%' AND F1 LIKE '" + "20" + "%'", strConn);
                    // OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Class List$] WHERE F5 Like '%" + "(" + "%'", strConn);
                    OleDbCommand ms;
                    str = new OleDbConnection(strConn);
                    // ms = new OleDbCommand("DELETE FROM [Class List$] WHERE F1 Like '%" + "Y" + "%' ", str);

                    myCommand.Fill(myDataSet, "ExcelInfo");

                    GridView3.DataBind();
                    GridView3.DataSource = myDataSet.Tables["ExcelInfo"].DefaultView;
                    GridView3.DataBind();
                    count = GridView3.Rows.Count;
                }

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
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = " DELETE FROM term_course where term = '" + termino + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    Reader2.Close();
                    Scon2.Close();
                }
                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = " DELETE FROM course where term = '" + termino + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    Reader2.Close();
                    Scon2.Close();
                }
                string logUser = "";
                {
                    SqlConnection Scon77;
                    SqlDataReader Reader77;
                    SqlCommand Cmd77; StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr77.ReadLine();
                    string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql77;
                    sql77 = "Select * From user_table WHERE user_id = '" + user + "' ";
                    Scon77 = new SqlConnection(sConnection77);
                    Scon77.Open();
                    Cmd77 = new SqlCommand(sql77, Scon77);
                    Reader77 = Cmd77.ExecuteReader();

                    while (Reader77.Read())
                    {
                        logUser = Reader77["prog"].ToString();

                    }
                    Reader77.Close();
                    Scon77.Close();

                }
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6; StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr6.ReadLine();
                    string path6 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "Updated faculty course load (Term " +termino+ ")"+"','" + logUser + "','" + System.DateTime.Now.ToString() + "')";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();
                    Reader6.Close();
                    Scon6.Close();
                }
                for (int i = 0; i < count; i++)
                {
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Insert into term_course Values('" +user+":"+ termino + ":" + GridView3.Rows[i].Cells[0].Text.ToUpper() + ":" + GridView3.Rows[i].Cells[1].Text.ToUpper().Replace(" ", "") + "','" + GridView3.Rows[i].Cells[0].Text.ToUpper() + "','" + GridView3.Rows[i].Cells[1].Text.ToUpper() + "','" + GridView3.Rows[i].Cells[2].Text.Trim() + "','" + termino + "')";

                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        try
                        {
                            Reader = Cmd.ExecuteReader();
                            Reader.Close();
                            Scon.Close();
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
                        sql = "Select * From user_table Where prog='"+  GridView3.Rows[i].Cells[2].Text.Trim().ToUpper()+ "'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
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
                                sql4 = "Select *  From course_data WHERE course_id LIKE '%" + GridView3.Rows[i].Cells[0].Text.ToUpper() + "%'";
                                Scon4 = new SqlConnection(sConnection4);
                                Scon4.Open();
                                Cmd4 = new SqlCommand(sql4, Scon4);
                                Reader4 = Cmd4.ExecuteReader();

                                while (Reader4.Read())
                                {
                                   course2=(Reader4["course_desc"].ToString());
                                }
                                Reader4.Close();
                                Scon4.Close();
                            }
                            facid = Reader["user_id"].ToString();
                            {
                                SqlConnection Scon2;
                                SqlDataReader Reader2;
                                SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr2.ReadLine();
                                string path2 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql2;
                                sql2 = "Insert Into course VAlUES('" + facid + ":" + termino + ":" + GridView3.Rows[i].Cells[0].Text.ToUpper() + ":" + GridView3.Rows[i].Cells[1].Text.ToUpper() + "','" +GridView3.Rows[i].Cells[0].Text.ToUpper()+"','"+ course2 + "','" + GridView3.Rows[i].Cells[1].Text.ToUpper() + "','" + facid + "','" + termino + "')";

                                Scon2 = new SqlConnection(sConnection2);
                                Scon2.Open();
                                Cmd2 = new SqlCommand(sql2, Scon2);
                                try
                                {
                                    Reader2 = Cmd2.ExecuteReader();
                                    Reader2.Close();
                                    Scon2.Close();
                                }
                                catch { }
                            }
                        }
                        Reader.Close();
                        Scon.Close();
                    }
                }


                string mes = termino + " faculty courses has been updated";
                GridView2.DataBind();
                MessageBox(mes);
            }
            else
            {

                MessageBox("No file selected");
            }

        }


        catch
        {
            MessageBox("The file is invalid!");
        }


    }
    private void addCourseToFac()
    {

    }
  
    protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        MessageBox("The item has been updated.");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        {
            SqlConnection Scon2;
            SqlDataReader Reader2;
            SqlCommand Cmd2; StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
            string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql2;
            sql2 = " DELETE FROM course where handler_id = '" + GridView2.DataKeys[0].Value.ToString() + "'";
            Scon2 = new SqlConnection(sConnection2);
            Scon2.Open();
            Cmd2 = new SqlCommand(sql2, Scon2);
            Reader2 = Cmd2.ExecuteReader();
            Reader2.Close();
            Scon2.Close();
        }
    }
}
