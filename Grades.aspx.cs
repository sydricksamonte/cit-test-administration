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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;


public partial class Exams : System.Web.UI.Page
{
    string user= ""; string term="";
    string line; string anals; string cous = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.Session["user"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        else
        {
            if (Page.Session["anal"] == null)
            {
                anals = "no";
            }
            else
            {
                anals = Page.Session["anal"].ToString();
            }

            user = Page.Session["user"].ToString();
            StreamReader sr7 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr7.ReadLine();
            string sConnection9 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

            SqlDataSource1.ConnectionString = sConnection9;
            SqlDataSource2.ConnectionString = sConnection9;
            SqlDataSource3.ConnectionString = sConnection9;
            SqlDataSource4.ConnectionString = sConnection9;
            SqlDataSource5.ConnectionString = sConnection9;
            SqlDataSource6.ConnectionString = sConnection9;
            SqlDataSource7.ConnectionString = sConnection9;
     
            SqlDataSource5.SelectCommand = "SELECT        question_table.ques_id, question_table.exam_code, question_table.typeEx, question_table.ques_desc, question_table.ans_a, question_table.ans_b,  question_table.ans_c, question_table.ans_d, question_table.ans_e, question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date, question_table.imgLoc, question_table.l_o, question_table.c_o, question_table.copy_type,  answers.ans, question_table.ins_id FROM  question_table INNER JOIN answers ON question_table.ques_id = answers.ques_id AND question_table.exam_code = answers.exam_code WHERE (question_table.exam_code = @exam_code) AND (answers.ans <> N'noanswerxxx') AND (answers.user_id = '" + user + "') ORDER BY question_table.ques_desc";
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From classlist WHERE stud_id = '" + user + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    Label1.Text = Reader["stud_name"].ToString();
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
                sql = "Select * From term ";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                   Label28.Text = "S.Y. " + Reader["term"].ToString();

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



        }
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql = "SELECT   * FROM  exam_chart WHERE exname LIKE'" + "EXAM" + "%' AND userss ='" + user + "' AND scoreid LIKE '%" + term + "%'";
            //   string sql = "SELECT * FROM exam_results WHERE course = '" + cous + "' AND user_id = '" + user + "' AND d_close = '" + "TAKEN" + "' AND exam_code LIKE '" + "EXAM" + "%'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);
            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                CrystalReportViewer1.Visible = true;

            }
            Reader.Close();
            Scon.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, Scon);
            ReportDocument cryRpt = new ReportDocument();
            DataScoreChart ds = new DataScoreChart();

            adapter.Fill(ds.Tables[0]);

            cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"GradesRep.rpt");
            cryRpt.SetDataSource(ds.Tables[0]);

            CrystalReportViewer1.ReportSource = cryRpt;

            CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.RefreshReport();

        }
        {
            SqlConnection Scon;
            SqlDataReader Reader;
            SqlCommand Cmd;
            StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr.ReadLine();
            string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            string sql = "SELECT   * FROM    exam_chart WHERE exname LIKE'" + "QUIZ" + "%' AND userss ='" + user + "'AND scoreid LIKE '%" + term + "%'";
            Scon = new SqlConnection(sConnection);
            Scon.Open();
            Cmd = new SqlCommand(sql, Scon);

            Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                CrystalReportViewer2.Visible = true;

            }
            Reader.Close();
            Scon.Close();


            SqlDataAdapter adapter = new SqlDataAdapter(sql, Scon);
            ReportDocument cryRpt = new ReportDocument();
            DataScoreChart ds = new DataScoreChart();

            adapter.Fill(ds.Tables[0]);

            cryRpt.Load(Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"QuizRep.rpt");
            cryRpt.SetDataSource(ds.Tables[0]);

            CrystalReportViewer2.ReportSource = cryRpt;

            CrystalReportViewer2.RefreshReport();
            CrystalReportViewer2.RefreshReport();


        }
      
    } int rev = -1;
    protected void drpExams_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = drpExams.SelectedIndex;
        change(DropDownList1.SelectedValue.ToString());
    }
    int corA = 0;
    int wroA = 0;
    private void change(string val)
    {

        //try
        //{
        //    DropDownList1.SelectedIndex = drpExams.SelectedIndex;
        //}
        //catch
        {
            listStud.Items.Clear();
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; 
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From answers WHERE user_id = '" + user + "' ORDER BY ques_id ASC";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    listStud.Items.Add(Reader["ans"].ToString());

                }
                Reader.Close();
                Scon.Close();
            }
            listCor.Items.Clear();
            int i = 0;
            int j = 0;
            bool updateItanalC = true;
            bool updateItanalW = true;
         
            try
            {
                
               
                {
                    j = 0;
                    i = 0;
                    ListBox1.Items.Clear();
                    SqlConnection Scon;
                    SqlDataReader Reader;
                    SqlCommand Cmd;
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "Select * From question_table WHERE exam_code = '" + val + "' ORDER BY ques_id ASC";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Reader = Cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        SqlConnection Scon2;
                        SqlDataReader Reader2;
                        SqlCommand Cmd2;
                        StreamReader sr4 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr4.ReadLine();
                        string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql2;
                        sql2 = "Select ans From answers WHERE ques_id = '" + Reader["ques_id"].ToString() + "' AND user_id = '" + user + "' ORDER BY ques_id ASC";
                        Scon2 = new SqlConnection(sConnection2);
                        Scon2.Open();
                        Cmd2 = new SqlCommand(sql2, Scon2);
                        Reader2 = Cmd2.ExecuteReader();

                        while (Reader2.Read())
                        {
                            {
                                SqlConnection Scon6;
                                SqlDataReader Reader6;
                                SqlCommand Cmd6;
                                StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                line = sr6.ReadLine();
                                string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                string sql6;
                                sql6 = "Select * From it_anal WHERE ques_id_id LIKE '" + "%" + Reader["ques_id"].ToString() + "'";
                                Scon6 = new SqlConnection(sConnection6);
                                Scon6.Open();
                                Cmd6 = new SqlCommand(sql6, Scon6);
                                Reader6 = Cmd6.ExecuteReader();

                                while (Reader6.Read())
                                {
                                    corA = (int.Parse(Reader6["cor"].ToString()));
                                    wroA = (int.Parse(Reader6["incor"].ToString()));
                                }
                                Reader6.Close();
                                Scon6.Close();
                            }

                            if ((Reader["ans_a"].ToString().Trim().ToUpper()) == (Reader2["ans"].ToString().Trim().ToUpper()))
                            {
                                ListBox1.Items.Add("Item #" + (i + 1) + " is correct.");
                                j++;

                                corA++;
                                if (updateItanalC == true)
                                {
                                    SqlConnection Scon5;
                                    SqlCommand Cmd5;
                                    StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr5.ReadLine();
                                    string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql5;
                                    sql5 = "UPDATE it_anal SET cor ='" + corA.ToString() + "' WHERE ques_id_id LIKE '" + "%" + Reader["ques_id"].ToString() + "'";
                                    Scon5 = new SqlConnection(sConnection5);
                                    Scon5.Open();
                                    Cmd5 = new SqlCommand(sql5, Scon5);
                                    //    Cmd5.ExecuteNonQuery();
                                    Scon5.Close();
                                    updateItanalC = false;

                                }
                            }
                            else
                            {
                                ListBox1.Items.Add("Item #" + (i + 1) + " is incorrect.");
                                wroA++;
                                if (updateItanalW == true)
                                {
                                    SqlConnection Scon5;
                                    SqlCommand Cmd5;
                                    StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                    line = sr5.ReadLine();
                                    string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                    string sql5;
                                    sql5 = "UPDATE it_anal SET incor ='" + wroA.ToString() + "' WHERE ques_id_id LIKE '" + "%" + Reader["ques_id"].ToString() + "'";
                                    Scon5 = new SqlConnection(sConnection5);
                                    Scon5.Open();
                                    Cmd5 = new SqlCommand(sql5, Scon5);
                                    //     Cmd5.ExecuteNonQuery();
                                    Scon5.Close();
                                    updateItanalW = false;

                                }
                            }
                            rev++;
                            lblCorAns.Text = j.ToString();
                            i++;
                        }
                        Reader2.Close();
                        Scon2.Close();
                    }


                    Reader.Close();
                    Scon.Close();
                }


            }
            catch { }
            //{
            //    SqlConnection Scon;
            //    SqlCommand Cmd; 
            //    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt"); 
            //    line = sr.ReadLine();
            //    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
            //    string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
            //    string sql;
            //    sql = "UPDATE  exam_results SET score ='" + j + "' WHERE user_id = '" + user + "' AND exam_code='" + val + "'";
            //    Scon = new SqlConnection(sConnection);
            //    Scon.Open();
            //    Cmd = new SqlCommand(sql, Scon);
            //    Cmd.ExecuteNonQuery();
            //    Scon.Close();
            //}

            lblAll.Text = ListBox1.Items.Count.ToString();

            try
            {
                double comPerc = double.Parse(j.ToString()) / double.Parse(ListBox1.Items.Count.ToString());
                comPerc = Math.Floor(comPerc * 100);
                lblPerc.Text = comPerc.ToString() + "%";

                if (int.Parse(comPerc.ToString()) <= 59)
                {

                    lblStat.Text = "Failed"; lblStat.ForeColor = System.Drawing.Color.Red;

                }
                else
                {

                    lblStat.Text = "Passed"; lblStat.ForeColor = System.Drawing.Color.LimeGreen;

                }

            }
            catch { lblPerc.Visible = false; lblStat.Visible = false; ListBox1.Visible = false; lblCorAns.Visible = false; lblAll.Visible = false; Label5.Visible = false; Label6.Visible = false; Label3.Text = "No activities yet"; }
        }
    }
    protected void drpExams_Load(object sender, EventArgs e)
    {
        //drpExams.SelectedIndex = 0;
        //DropDownList1.SelectedIndex = 0;
       
       
       

    }
    protected void listCor_Load(object sender, EventArgs e)
    {
    }
    protected void listStud_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void drpExams_Unload(object sender, EventArgs e)
    {

    }
    protected void drpExams_DataBound(object sender, EventArgs e)
    {
        try
        {
            change(DropDownList1.Items[0].Value.ToString());
            Panel3.Visible = true;
        }
        catch
        {
            drpExams.Items.Clear();
            drpExams.Items.Add("NO TESTS FOUND");
            drpExams.Items[0].Value.ToString();
            Panel3.Visible = false;

        }
    }
    protected void drpExams_DataBound1(object sender, EventArgs e)
    {
        if (drpExams.Items.Count == 0)
        {
            DropDownList1.Visible = false;
            ListBox1.Visible = false;
            Label2.Visible = true;
            Label5.Visible = false;
            lblCorAns.Visible = false;
            lblAll.Visible = false;
            lblStat.Visible = false;
            lblPerc.Visible = false;
            Label6.Visible = false; Label4.Visible = false;
            drpExams.Visible = false;
        }
        else
        {
            DropDownList1.Visible = true;
            lblCorAns.Visible = true;
            Label5.Visible = true;
            Label2.Visible = false;
            ListBox1.Visible = true;
            lblCorAns.Visible = true;
            lblAll.Visible = true;
            lblStat.Visible = true;
            lblPerc.Visible = true;
            Label6.Visible = true; drpExams.Visible =true;
            Label4.Visible = true;
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
        
    }
    int juks = 0;
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


        foreach (GridViewRow row in GridView1.Rows)
        {

            Label txtA = (Label)row.FindControl("Label8");
            Label txtD = (Label)row.FindControl("Label18");
            if (txtD.Text == "")
            {
                txtD.Text = "(Not answered)";
            }
            Label txtB = (Label)row.FindControl("Label9");
            Label txtC = (Label)row.FindControl("Label20");
            HiddenField hf1 = (HiddenField)row.FindControl("HiddenField1");
            {
                SqlConnection Scon6;
                SqlDataReader Reader6;
                SqlCommand Cmd6;
                StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr6.ReadLine();
                string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql6;
                sql6 = "Select * From question_table WHERE ques_id = '" + hf1.Value.ToString() + "'";
                Scon6 = new SqlConnection(sConnection6);
                Scon6.Open();
                Cmd6 = new SqlCommand(sql6, Scon6);
                Reader6 = Cmd6.ExecuteReader();

                while (Reader6.Read())
                {
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;
                        StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr2.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Select * From answers WHERE ans = '" + Reader6["ans_a"].ToString() + "%' AND user_id = '" + user + "' AND ans <> '" + "noanswerxxx" + "'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();

                        while (Reader.Read())
                        {
                            //     txtC.Text = Reader["l_o"].ToString();
                            juks++;
                            //if (juks == 1)
                            //{
                            //    Label18.Text = Reader["topic_desc"].ToString();
                            //}
                            //else if (juks == 5)
                            //{
                            //    Label19.Text = Reader["topic_desc"].ToString();
                            //}
                        }
                        Reader.Close();
                        Scon.Close();
                    }
                    {
                        SqlConnection Scon;
                        SqlDataReader Reader;
                        SqlCommand Cmd;
                        StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr2.ReadLine();
                        string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Select * From answers WHERE user_id = '" + user + "' AND exam_code = '" + GridView2.SelectedDataKey[0].ToString() + "' AND ques_id = '" + Reader6["ques_id"].ToString() + "'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();

                        while (Reader.Read())
                        {
                            txtC.Text = Reader["l_o"].ToString();
                            // txtB.Text = Reader6["ans_a"].ToString() + Reader["ans"].ToString();
                            if (Reader6["ans_a"].ToString() == Reader["ans"].ToString())
                            {
                                txtA.Text = " (Correct)";
                                //if (txtC.Text == "none")
                                //{
                                //  Label18.Text = Reader["l_o"].ToString();
                                //}
                                //else if (txtC.Text == Label18.Text)
                                //{
                                //    Label18.Text = txtC.Text;
                                //}

                            }
                            else if (Reader6["ans_a"].ToString() != Reader["ans"].ToString())
                            {

                                txtA.Text = " (Wrong)";

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
                        string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql;
                        sql = "Select * From exam_results WHERE exam_code  = '" + GridView2.SelectedDataKey[0].ToString() + "'";
                        Scon = new SqlConnection(sConnection);
                        Scon.Open();
                        Cmd = new SqlCommand(sql, Scon);
                        Reader = Cmd.ExecuteReader();

                        while (Reader.Read())
                        {
                            cous = Reader["course"].ToString();

                        }
                        Reader.Close();
                        Scon.Close();
                    }

                }
                Reader6.Close();
                Scon6.Close();
            }
        }



    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Page.Session["qut"] = GridView2.SelectedDataKey[0].ToString();
        }
        catch { }
    }
    int movers = 0;
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
        foreach (GridViewRow row in GridView2.Rows)
        {

            Image txtC = (Image)row.FindControl("Image1");
           // Label txtD = (Label)row.FindControl("Label13");
            Label txtE = (Label)row.FindControl("Label11");
            Label txtF = (Label)row.FindControl("Label15");

            HiddenField txtAE = (HiddenField)row.FindControl("HiddenField2");


            
           
            if (txtAE.Value.ToString().Contains("EXAM"))
            {
                txtC.ImageUrl = "~/Images/type_exam.png";
            }
            if (txtAE.Value.ToString().Contains("SEAT"))
            {
                txtC.ImageUrl = "~/Images/t_seatwork.png";
            }
            if (txtAE.Value.ToString().Contains("EXAM_F"))
            {
                txtC.ImageUrl = "~/Images/t_f.png";
            }
            if (txtAE.Value.ToString().Contains("QUIZ"))
            {
                txtC.ImageUrl = "~/Images/type_quiz.png";
            }

            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select count (exam_code)  AS COLL From answers WHERE user_id = '" + user + "' AND exam_code = '" + txtAE.Value.ToString() + "'";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                  //  movers++; // txtB.Text = Reader6["ans_a"].ToString() + Reader["ans"].ToString();
                  //  txtD.Text = Reader["COLL"].ToString();
                    try
                    {
                        //double comPerc = double.Parse(txtE.Text) / double.Parse(txtD.Text);
                        //comPerc = Math.Floor(comPerc * 100);
                       // txtF.Text = comPerc.ToString() + "%";

                        if (int.Parse(txtE.Text) <= 59)
                        {

                            txtF.Text = "Failed";

                        }
                        else
                        {

                            txtF.Text ="Passed";

                        }

                    }
                    catch
                    {
                    }


                }
                Reader.Close();
                Scon.Close();

            }
         
        }
    }
    protected void HiddenField2_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        GridView2_SelectedIndexChanged(GridView2, e);
    }
    protected void GridView3_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView3.Rows)
        {
            try
            {
                Label txtA = (Label)row.FindControl("Label8");
                Label txtB = (Label)row.FindControl("Label17");


                Label txtE = (Label)row.FindControl("Label30");

                double mul = double.Parse(txtA.Text);
                double div = double.Parse(txtB.Text);

                double percentage = 0;
                percentage = ((mul / div) * 100);
                percentage = Math.Round(percentage, 0);
                txtE.Text ="-- "+ percentage.ToString() + "%";
            }
            catch { }
        }
        try
        {
            {
                string bag = "None";
                string pass = "None";
                string per = "None";
                int mover1 = 0;
                int mover2 = 0;
                int mover3 = 0;
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select l_o_id, exname, user_id, ques_id, correct, incor, l_o, t_count FROM course_bulk  WHERE exname = '" + GridView2.SelectedDataKey[0].ToString() + "' AND user_id = '" + user + "' ORDER BY correct DESC, t_count ASC";
                Scon = new SqlConnection(sConnection);
                Scon.Open();
                Cmd = new SqlCommand(sql, Scon);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    if (int.Parse(Reader["incor"].ToString()) >= int.Parse(Reader["correct"].ToString()))
                    {
                        mover1++;

                        if (mover1 > 1)
                        {
                            bag = Reader["l_o"].ToString() + ", " + bag;
                        }
                        else
                        {
                            bag = Reader["l_o"].ToString();
                        }

                    }
                    else if (int.Parse(Reader["incor"].ToString()) < int.Parse(Reader["correct"].ToString()))
                    {
                        mover2++;

                        if (mover2 > 1)
                        {
                            pass = Reader["l_o"].ToString() + ", " + pass;
                        }
                        else
                        {
                            pass = Reader["l_o"].ToString();
                        }
                    }
                    else if (int.Parse(Reader["t_count"].ToString()) == int.Parse(Reader["correct"].ToString()))
                    {
                        mover3++;

                        if (mover3 > 1)
                        {
                            per = Reader["l_o"].ToString() + ", " + per;
                        }
                        else
                        {
                            per = Reader["l_o"].ToString();
                        }
                    }
                }
                Reader.Close();
                Scon.Close();

                Label19.Text = bag;
                Label21.Text = pass;
                Label25.Text = per;
            }
        }
        catch { }
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       
    }
    protected void LinkButton22_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "op", "window.open ('" + Request.ApplicationPath + "/ExamsStud.aspx', null,'top=1,left=1,center=yes,fullscreen=1,resizable=no,Width=1024px,Height= 600px,status=no,titlebar=no;toolbar=no,menubar=no,location=no,scrollbars=yes');", true);

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Page.Session["user"] = null;
        Response.Redirect("LogIn.aspx");
    }
}
