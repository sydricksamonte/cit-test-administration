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

using System.Text;




public partial class Default2 : System.Web.UI.Page
{


    string type; string line; //string _scriptCloseDialog = "<script>window.close();</script>";
    protected void Page_Load(object sender, EventArgs e)
    {
        Login1.Focus();
       

      //  ClientScript.RegisterStartupScript(GetType(), "_load", _scriptCloseDialog);
        Label2.Visible = false;
    }
    public static void Show(string message)
    {
        //// Cleans the message to allow single quotation marks
        //string cleanMessage = message.Replace("'", "\\'");
        //string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";

        //// Gets the executing web page
        //Page page = HttpContext.Current.CurrentHandler as Page;

        //// Checks if the handler is a Page and that the script isn't allready on the Page
        //if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //{
        //    page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
        //}
    }
    public void conn()
    {
        
    
    }
    
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    {
        //        SqlConnection Scon;
        //        SqlDataReader Reader;
        //        SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
        //        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        //        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        //        // string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        //        string sql;
        //        sql = "Select * From user_table WHERE user_na = '" + Login1.UserName.ToString() + "'";
        //        Scon = new SqlConnection(sConnection);
        //        Scon.Open();
        //        Cmd = new SqlCommand(sql, Scon);
        //        Reader = Cmd.ExecuteReader();
        //        Label1.Text = Login1.UserName.ToString();
        //        while (Reader.Read())
        //        {
        //            type = Reader["type"].ToString();
        //            if (Reader["pass"].ToString() == Login1.Password.ToString())
        //            {

        //                if ((type == "FACULTY") || (type == "ADMIN"))
        //                {
        //                    Page.Session["user"] = Reader["user_id"].ToString();
        //                    Response.Redirect("InsHome.aspx", true);
           

                           
                            
        //                //    Response.Redirect("InsHome.aspx");
        //                    break;
        //                }

                       
        //            }
        //        }
        //        Reader.Close();
        //        Scon.Close();
        //    }
        //    {
        //        SqlConnection Scon2;
        //        SqlDataReader Reader2;
        //        SqlCommand Cmd2;
        //        StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
        //        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        //        string sql2;
        //        sql2 = "Select * From exam_results WHERE d_taken = '" + "NOT TAKEN" + "' AND user_id = '" + Login1.UserName.ToString().Trim() + "'";
        //        Scon2 = new SqlConnection(sConnection2);
        //        Scon2.Open();
        //        Cmd2 = new SqlCommand(sql2, Scon2);
        //        Reader2 = Cmd2.ExecuteReader();
        //        while (Reader2.Read())
        //        {
        //            {
        //                SqlConnection Scon;
        //                SqlDataReader Reader;
        //                SqlCommand Cmd;
        //                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
        //                line = sr.ReadLine();
        //                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
        //                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
        //                string sql;
        //                sql = "Select * From exams WHERE pass = '" + Login1.Password.ToString() + "' AND frameA = '" + "OPEN" + "' OR frameA = '" + "RE-OPEN" + "' AND exname = '" + Reader2["exam_code"].ToString() + "'";
        //                Scon = new SqlConnection(sConnection);
        //                Scon.Open();
        //                Cmd = new SqlCommand(sql, Scon);
        //                Reader = Cmd.ExecuteReader();
        //                Label1.Text = Login1.UserName.ToString();
        //                while (Reader.Read())
        //                {
        //                   // Show("Welcome to CIT Exam System! \n" + System.DateTime.Now.ToShortDateString());
        //                    Page.Session["user"] = Login1.UserName.ToString();
        //                    Page.Session["secret"] = Login1.Password.ToString();
        //                        Response.Redirect("Home.aspx");
        //                        break;
                            
        //                }
        //                Reader.Close();
        //                Scon.Close();
        //            }
              

        //            Reader2.Close();
        //            Scon2.Close();
        //        }
        //       MessageBox( "Log In attempt failed! The password did not match, or no new test/s available at this time.");
        //       // Login1.Visible = true;
        //    }
        //}
        //catch
        //{
        //    MessageBox("Log In attempt failed. The password did not match, or no new test/s available at this time.");
        // //   Login1.Visible = true;
        //}






    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void UserName_TextChanged(object sender, EventArgs e)
    {
        
    }
    string linen = ""; string lineo = "";
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        {
            //StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBNew.txt"); linen = sr3.ReadLine();
            //StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBOld.txt"); lineo = sr4.ReadLine();
            //File.Copy(lineo, lineo);
          

            //SqlConnection Scon2;
            //SqlDataReader Reader2;
            //SqlCommand Cmd2;
            //StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
            //string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //string sql2;
            //sql2 = "Select * From dbSettings WHERE dbData = '" + "db" + "'";
            //Scon2 = new SqlConnection(sConnection2);
            //Scon2.Open();
            //Cmd2 = new SqlCommand(sql2, Scon2);
            //Reader2 = Cmd2.ExecuteReader();
            //while (Reader2.Read())
            //{
            //    if (Reader2["type"].ToString() == "2")
            //    {
                    
            //    }


            //}
            //Reader2.Close();
            //Scon2.Close();
        }
      //  try
        {
            string year1 = "";
            string year2 = "";
            string ter = "";
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                // string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From user_table WHERE user_na = '" + Login1.UserName.ToString() + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                Label1.Text = Login1.UserName.ToString();
                while (Reader.Read())
                {
                    type = Reader["type"].ToString().ToUpper();
                    if (Reader["pass"].ToString() == Login1.Password.ToString())
                    {
                        string logUser = "";
                        {
                            SqlConnection Scon77;
                            SqlDataReader Reader77;
                            SqlCommand Cmd77; StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr77.ReadLine();
                            string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                            string sql77;
                            sql77 = "Select * From user_table WHERE user_na = '" + Login1.UserName.ToString() + "' ";
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
                            sql6 = "Insert into dbLog Values('" + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Millisecond.ToString() + "','" + "The user logged-in" + "','" + logUser + "','" + System.DateTime.Now.ToString() + "')";

                            //       sql = "Insert into classlist Values('" + GridView1.Rows[i].Cells[0].Text.ToUpper() + ":" + DropDownList2.SelectedValue.ToString() + ":" + DropDownList1.SelectedValue.ToString() + ":" + termino + "','" + GridView1.Rows[i].Cells[0].Text.ToUpper() + "','" + user + "','" + DropDownList2.SelectedValue.ToString() + "','" + DropDownList1.SelectedValue.ToString() + "','" + GridView1.Rows[i].Cells[1].Text.ToUpper() + "')";
                            Scon6 = new SqlConnection(sConnection6);
                            Scon6.Open();
                            Cmd6 = new SqlCommand(sql6, Scon6);
                            Reader6 = Cmd6.ExecuteReader();
                            Reader6.Close();
                            Scon6.Close();
                        }
                        if ((type == "FACULTY"))
                        {
                            Page.Session["user"] = Reader["user_id"].ToString();
                            //  MessageBox.Show("Welcome");

                            Response.Redirect("InsHome.aspx", true);




                            //    Response.Redirect("InsHome.aspx");
                            break;
                        }
                        else if (type == "ADMIN")
                        {
                            Page.Session["user"] = Reader["user_id"].ToString();
                            //  MessageBox.Show("Welcome");

                            Response.Redirect("AdHome.aspx", true);




                            //    Response.Redirect("InsHome.aspx");
                            break;
                        }
                        else if (type == "PROGRAM CHAIR")
                        {
                            {
                                SqlConnection Scon2;
                                SqlDataReader Reader2;
                                SqlCommand Cmd2;
                                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr2.ReadLine();
                                string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql2;
                                sql2 = "dELETE FROM term WHERE term LIKE '" + "2%" + "'";

                                Scon2 = new SqlConnection(sConnection2);
                                Scon2.Open();
                                Cmd2 = new SqlCommand(sql2, Scon2);
                                Reader2 = Cmd2.ExecuteReader();

                            }
                            if ((System.DateTime.Now.Month == 1) || (System.DateTime.Now.Month == 2) || (System.DateTime.Now.Month == 3))
                            {
                                ter = "3T";
                                year2 = System.DateTime.Now.Year.ToString();
                                year1 = System.DateTime.Now.AddYears(-1).Year.ToString();
                            }
                            else if ((System.DateTime.Now.Month == 4) || (System.DateTime.Now.Month == 5) )
                            {
                                ter = "4T";
                                year2 = System.DateTime.Now.Year.ToString();
                                year1 = System.DateTime.Now.AddYears(-1).Year.ToString();
                            }
                            else if ((System.DateTime.Now.Month == 6) || (System.DateTime.Now.Month == 7) || (System.DateTime.Now.Month == 8) || (System.DateTime.Now.Month == 9))
                            {
                                ter = "1T";
                                year1 = System.DateTime.Now.Year.ToString();
                                year2 = System.DateTime.Now.AddYears(1).Year.ToString();
                            }
                            else if ((System.DateTime.Now.Month == 10) || (System.DateTime.Now.Month == 11) || (System.DateTime.Now.Month == 12))
                            {
                                ter = "2T";
                                year1 = System.DateTime.Now.Year.ToString();
                                year2 = System.DateTime.Now.AddYears(1).Year.ToString();
                            }
                            string ha= year1 + "-" + year2 + "/" + ter ;
                            MessageBox(ha);
                            {
                                SqlConnection Scon5;
                                SqlDataReader Reader5;
                                SqlCommand Cmd5;
                                StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr5.ReadLine();
                                string path5 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql5;
                                sql5 = "Insert Into term VAlUES('" + year1 + "-" + year2 + "/" + ter + "','" + year1 + "-" + year2 + "/" + ter + "')";

                                Scon5 = new SqlConnection(sConnection5);
                                Scon5.Open();
                                Cmd5 = new SqlCommand(sql5, Scon5);
                                Reader5 = Cmd5.ExecuteReader();


                            }


                            Page.Session["user"] = Reader["user_id"].ToString();
                            //  MessageBox.Show("Welcome");

                            Response.Redirect("AdHome.aspx", true);




                            //    Response.Redirect("InsHome.aspx");
                            break;
                        }


                    }
                }
                Reader.Close();
                Scon.Close();
            }
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From exams WHERE pass = '" + Login1.Password.ToString() + "' AND frameA LIKE '%" + "OPE" + "%'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();
                // Label1.Text = Login1.UserName.ToString();
                while (Reader.Read())
                {
                    SqlConnection Scon2;
                    SqlDataReader Reader2;
                    SqlCommand Cmd2;
                    StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); line = sr2.ReadLine();
                    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql2;
                    sql2 = "Select * From exam_results WHERE take_no <= '" + Reader["frameB"].ToString() + "' AND user_id = '" + Login1.UserName.ToString() + "'";
                    Scon2 = new SqlConnection(sConnection2);
                    Scon2.Open();
                    Cmd2 = new SqlCommand(sql2, Scon2);
                    Reader2 = Cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {

                        Page.Session["user"] = Login1.UserName.ToString(); Page.Session["secret"] = Login1.Password.ToString();
                        Response.Redirect("Home.aspx");
                        break;

                    }
                    Reader2.Close();
                    Scon2.Close();
                }
                Reader.Close();
                Scon.Close();

              //  Label2.Visible = true;
               MessageBox( "Log In attempt failed!.The password did not match,or no new tests available at this time.");
             //   Login1.Visible = true;
            }
        }
        //catch
        //{
        //    Label2.Visible = true;
        //      MessageBox( "Log In attempt failed!.The password did not match,or no new tests available at this time.");
        //    Login1.Visible = true;
            
        //}
       





    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/ExamsStud.aspx', null,'top=1,left=1,center=yes,resizable=no,Width=1024px,Height= 600px,status=no,fullscreen=1,titlebar=no,toolbar=no,menubar=no,location=no,scrollbars=yes');", true);
       
    //    String strscript = "<script language=javascript>window.top.close();</script>";
    //ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strscript);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
}
