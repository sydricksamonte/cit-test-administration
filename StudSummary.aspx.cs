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


public partial class Exams : System.Web.UI.Page
{
    string user= "";
    string line; string anals; string exname;
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
            exname = Page.Session["exname"].ToString();
            user = Page.Session["user"].ToString();
             StreamReader sr7 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr7.ReadLine();
                 string sConnection9 = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";

                 SqlDataSource1.ConnectionString = sConnection9;
                 SqlDataSource2.ConnectionString = sConnection9;
                 SqlDataSource3.ConnectionString = sConnection9;
                 SqlDataSource4.ConnectionString = sConnection9;
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd; 
                StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr.ReadLine(); 
                string sConnection = "Data Source="+line+"\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
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
        }
      
    } int rev = -1;
    protected void drpExams_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = drpExams.SelectedIndex;
        change(DropDownList1.SelectedValue.ToString());
    }
    int corA = 0;
    int wroA = 0;
    public void MessageBox(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    } int countera = 0; int counteratama = 0;
    private void change(string val)
    {

        
        {
            listStud.Items.Clear();
            {
                SqlConnection Scon;
                SqlDataReader Reader;
                SqlCommand Cmd;
                StreamReader sr2 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                line = sr2.ReadLine();
                string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                string sql;
                sql = "Select * From answers WHERE user_id = '" + user + "' AND ans <> '" + "noanswerxxx" + "' ORDER BY ques_id ASC";
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
            int j = 0; int tarouu = 0; int taroung = 0;
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
                        sql2 = "Select * From answers WHERE ques_id = '" + Reader["ques_id"].ToString() + "'AND ans <> '" + "noanswerxxx" + "' AND user_id = '" + user + "' ORDER BY ques_id ASC";
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
                                    {
                                        //{
                                        //    SqlConnection Scon66;
                                        //    SqlDataReader Reader66;
                                        //    SqlCommand Cmd66;
                                        //    StreamReader sr66 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                        //    line = sr66.ReadLine();
                                        //    string sConnection66 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=12345667";
                                        //    string sql66;
                                        //    sql66 = "Select * From course_bulk WHERE ques_id ='"+ Reader["ques_id"].ToString()+"' AND user_id ='" + user + "' AND exname  = '" + val + "' AND l_o = '" + Reader2["l_o"].ToString() + "'";
                                        //    Scon66 = new SqlConnection(sConnection66);
                                        //    Scon66.Open();
                                        //    Cmd66 = new SqlCommand(sql66, Scon66);
                                        //    Reader66 = Cmd66.ExecuteReader();

                                        //    while (Reader66.Read())
                                        //    {
                                        //        tarouu = (int.Parse(Reader66["correct"].ToString()));
                                        //        //tarouu++;
                                                
                                        //        SqlConnection Scon5;
                                        //        SqlDataReader Reader5;
                                        //        SqlCommand Cmd5;
                                        //        StreamReader sr5 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                                        //        line = sr5.ReadLine();
                                        //        string path5 = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                                        //        string sConnection5 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                                        //        string sql5;
                                        //        sql5 = "UPDATE course_bulk Set correct = '" + tarouu.ToString() + "' Where user_id ='" + user + "' AND exname  = '" + val + "' AND l_o = '" + Reader2["l_o"].ToString() + "'";
                                        //        Scon5 = new SqlConnection(sConnection5);
                                        //        Scon5.Open();
                                        //        Cmd5 = new SqlCommand(sql5, Scon5);
                                        //        Reader5 = Cmd5.ExecuteReader();
                                        //        Reader5.Close();
                                        //        Scon5.Close();
                                        //    }
                                        //    Reader66.Close();
                                        //    Scon66.Close();
                                        //}

                                    }

                                
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
                            }
                            else
                            {
                                ListBox1.Items.Add("Item #" + (i + 1) + " is incorrect.");
                                wroA++;
                                if (updateItanalW == true)
                                {
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
                                        //wrongt(Reader2["l_o"].ToString());
                                        updateItanalW = false;

                                    }
                                    

                                 
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
            catch {
        }
       

         //   lblAll.Text = ListBox1.Items.Count.ToString();

            try
            {
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "SELECT question_table.ins_id, question_table.ques_id, question_table.exam_code, question_table.typeEx, question_table.ques_desc, question_table.ans_a, question_table.ans_b, question_table.ans_c, question_table.ans_d, question_table.ans_e, question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date, question_table.imgLoc, question_table.l_o, question_table.c_o, question_table.copy_type, question_table.pt, answers.ans FROM answers INNER JOIN question_table ON answers.ques_id = question_table.ques_id AND answers.exam_code = question_table.exam_code WHERE (answers.ans <> '" + "noanswerxxx" + "') AND (answers.user_id = '" + user + "') AND (question_table.exam_code = '" + exname + "')   AND (answers.ans = question_table.ans_a )";

                    //Select * From answers WHERE ans <> '" + "noanswerxxx" + "' AND exam_code ='"+exname+"' AND user_id = '"+user+"'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        counteratama = (int.Parse(Reader6["pt"].ToString())) + counteratama;
                    }
                    Reader6.Close();
                    Scon6.Close();
                }
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "SELECT question_table.ins_id, question_table.ques_id, question_table.exam_code, question_table.typeEx, question_table.ques_desc, question_table.ans_a, question_table.ans_b, question_table.ans_c, question_table.ans_d, question_table.ans_e, question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date, question_table.imgLoc, question_table.l_o, question_table.c_o, question_table.copy_type, question_table.pt, answers.ans FROM answers INNER JOIN question_table ON answers.ques_id = question_table.ques_id AND answers.exam_code = question_table.exam_code WHERE (answers.ans <> '" + "noanswerxxx" + "') AND (answers.user_id = '" + user + "') AND (question_table.exam_code = '" + exname + "')";

                    //Select * From answers WHERE ans <> '" + "noanswerxxx" + "' AND exam_code ='"+exname+"' AND user_id = '"+user+"'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        countera = (int.Parse(Reader6["pt"].ToString())) + countera;
                    }
                    Reader6.Close();
                    Scon6.Close();
                }
                lblAll.Text = countera.ToString();
                lblCorAns.Text = counteratama.ToString();
                double comPerc = double.Parse(counteratama.ToString()) / double.Parse(countera.ToString());
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

                {
                    SqlConnection Scon;
                    SqlCommand Cmd;
                    StreamReader sr = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr.ReadLine();
                    string path = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql;
                    sql = "UPDATE  exam_results SET score ='" + comPerc + "' WHERE user_id = '" + user + "' AND exam_code='" + val + "'";
                    Scon = new SqlConnection(sConnection);
                    Scon.Open();
                    Cmd = new SqlCommand(sql, Scon);
                    Cmd.ExecuteNonQuery();
                    Scon.Close();
                    //lblPerc.Text = val;
                }
                string pnames = "";
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Select * From exam_results WHERE exam_code = '"  +exname + "'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        pnames = (Reader6["pname"].ToString());
                      
                    }
                    Reader6.Close();
                    Scon6.Close();
                }

              //  {
              //      SqlConnection Scon2;
              //      SqlDataReader Reader2;
              //      SqlCommand Cmd2;
              //      StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
              //      line = sr3.ReadLine();
              //      string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
              //      string sql2;
              //      sql2 = "Insert Into exam_chart VAlUES('" + exname + ":i:" + user + "','" + Convert.ToInt32(lblAll.Text) + "','" + "items" + "','" + pnames + "','" + user + "')";
              ////      sql2 = "Insert Into exam_chart VAlUES('" + exname + "','" + counteratama + "','" + "score" + "','" + pnames + "','" + user + "')";
              //      Scon2 = new SqlConnection(sConnection2);
              //      Scon2.Open();
              //      Cmd2 = new SqlCommand(sql2, Scon2);
              //      Reader2 = Cmd2.ExecuteReader();
              //      Reader2.Close();
              //      Scon2.Close();
              //  }
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Insert Into exam_chart VAlUES('" + exname + ":" + user + "','" + exname + "','" + countera + "','" + counteratama + "','" + pnames + "','" + user + "')";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();
                    Reader6.Close();
                    Scon6.Close();
                }

                //{
                //    SqlConnection Scon2;
                //    SqlDataReader Reader2;
                //    SqlCommand Cmd2;
                //    StreamReader sr3 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                //    line = sr3.ReadLine();
                //    string sConnection2 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                //    string sql2;
                //    sql2 = "Insert Into exam_chart VAlUES('" + exname + ":s:" + user + "','" + exname + "','" + counteratama + "','" + "score" + "','" + pnames + "','" + user + "')"; 
                //    Scon2 = new SqlConnection(sConnection2);
                //    Scon2.Open();
                //    Cmd2 = new SqlCommand(sql2, Scon2);
                //    Reader2 = Cmd2.ExecuteReader();
                //    Reader2.Close();
                //    Scon2.Close();
                //}
                decimal ba = 0;
                decimal pa = 0;
                decimal bagsak = 0;
                decimal pasa = 0;
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Select * From exam_results WHERE exam_code ='" + exname + "' AND score  < '" + 60 + "'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        bagsak++;

                    }
                    Reader6.Close();
                    Scon6.Close();
                }
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Select * From exam_results WHERE exam_code ='" + exname + "' AND score  > '" + 59 + "' ";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        pasa++;

                    }
                    Reader6.Close();
                    Scon6.Close();
                }
                double ox = 0;
                decimal ii = 0;

                if (pasa < bagsak)
                {
                    ii = bagsak;
                    do
                    {
                        {
                            ba = bagsak / ii;
                            pa = pasa / ii;

                        }
                        if ((pa.ToString().Contains(".") == false))
                        {
                            if (ba.ToString().Contains(".") == false)
                            {
                                break;
                            }
                        }
                        ii--;
                    } while (ii >= 1);

                }
                else if (pasa > bagsak)
                {
                    ii = pasa;
                    do
                    {
                        {
                            ba = bagsak / ii;
                            pa = pasa / ii;
                        }
                        if ((pa.ToString().Contains(".") == false))
                        {
                            if (ba.ToString().Contains(".") == false)
                            {
                                break;
                            }
                        }
                        ii--;
                    } while (ii >= 1);

                }
                {
                    SqlConnection Scon77;
                    SqlDataReader Reader77;
                    SqlCommand Cmd77;
                    StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr77.ReadLine();
                    string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                    string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql77;
                    sql77 = "UPDATE ratio Set rat = '" + pa.ToString() + ":" + ba.ToString() + "' Where  exname  = '" + exname + "'";
                    Scon77 = new SqlConnection(sConnection77);
                    Scon77.Open();
                    Cmd77 = new SqlCommand(sql77, Scon77);
                    Reader77 = Cmd77.ExecuteReader();
                    Reader77.Close();
                    Scon77.Close();
                    pasa = 0; bagsak = 0;

                }
            }

            catch { }
        }
    }
    private void wrongt(string eto)
    {
        
        {
            SqlConnection Scon664;
            SqlDataReader Reader664;
            SqlCommand Cmd664;
            StreamReader sr664 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
            line = sr664.ReadLine();
            string sConnection664 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=12345667";
            string sql664;
            sql664 = "Select * From course_bulk WHERE user_id ='" + user + "' AND exname  = '" + exname + "' AND l_o = '" + eto+ "'";
            Scon664 = new SqlConnection(sConnection664);
            Scon664.Open();
            Cmd664 = new SqlCommand(sql664, Scon664);
            Reader664 = Cmd664.ExecuteReader();

            while (Reader664.Read())
            {

                //taroung = (int.Parse(Reader66["incor"].ToString()));
                //taroung++;
                //SqlConnection Scon77;
                //SqlDataReader Reader77;
                //SqlCommand Cmd77;
                //StreamReader sr77 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                //line = sr77.ReadLine();
                //string pat77h = Server.HtmlEncode(Request.PhysicalApplicationPath).ToString() + @"CIT exams.mdf";
                //string sConnection77 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                //string sql77;
                //sql77 = "UPDATE course_bulk Set incor = '" + taroung + "' Where user_id ='" + user + "' AND exname  = '" + val + "' AND l_o = '" + Reader2["l_o"].ToString() + "'";
                //Scon77 = new SqlConnection(sConnection77);
                //Scon77.Open();
                //Cmd77 = new SqlCommand(sql77, Scon77);
                //Reader77 = Cmd77.ExecuteReader();
                //Reader77.Close();
                //Scon77.Close();
            }
            Reader664.Close();
            Scon664.Close();
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
     
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
