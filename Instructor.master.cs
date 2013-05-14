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

public partial class Instructor : System.Web.UI.MasterPage
{
    string user; string line = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Session["user"] == null)
        {
        }
        else
        {
            user = Page.Session["user"].ToString();
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
                    Label12.Text = "S.Y. " + Reader["term"].ToString();

                }
                Reader.Close();
                Scon.Close();
            }
            try
            {
               
                if (Page.Session["lang"].ToString() == "EN")
                {
                    Label4.Text = "Home";
                    Label5.Text = "Tests";
                    Label6.Text = "Classlists";
                   // Label7.Text = "Reports";
                    Label8.Text = "Options";
                    Label2.Text = "Test Administration System";
                    Label3.Text = "Malayan Colleges Laguna";
                    string type = "";
                    {
                        SqlConnection Scon6;
                        SqlDataReader Reader6;
                        SqlCommand Cmd6;
                        StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr6.ReadLine();
                        string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql6;
                        sql6 = "Select * From user_table WHERE user_id = '" + user + "'";
                        Scon6 = new SqlConnection(sConnection6);
                        Scon6.Open();
                        Cmd6 = new SqlCommand(sql6, Scon6);
                        Reader6 = Cmd6.ExecuteReader();

                        while (Reader6.Read())
                        {
                            Label9.Text = "Welcome " + ((Reader6["fname"].ToString()) + " " + (Reader6["lname"].ToString()) + " (" + (Reader6["type"].ToString()) + ")");
                            //   wroA = (int.Parse(Reader6["incor"].ToString()));
                            type =  Reader6["type"].ToString();
                           

                        }
                        Reader6.Close();
                        Scon6.Close();
                    }
                    if (type != "Faculty")
                    {
                        Page.Session["user"] = null;
                        Response.Redirect("LogIn.aspx");
                    }

                }
                else if (Page.Session["lang"].ToString() == "JA")
                {
                    Label4.Text = "ホーム";
                    Label5.Text = "四件";
                    Label6.Text = "学生";
                  //  Label7.Text = "リポート";
                    Label8.Text = "書割";
                    Label2.Text = "Test Administration System";
                    Label3.Text = "マラヤン　カレジ　ラグナ";
                    {
                        SqlConnection Scon6;
                        SqlDataReader Reader6;
                        SqlCommand Cmd6;
                        StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr6.ReadLine();
                        string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql6;
                        sql6 = "Select * From user_table WHERE user_id = '" + user + "'";
                        Scon6 = new SqlConnection(sConnection6);
                        Scon6.Open();
                        Cmd6 = new SqlCommand(sql6, Scon6);
                        Reader6 = Cmd6.ExecuteReader();

                        while (Reader6.Read())
                        {
                            string mux = "";
                            if (Reader6["type"].ToString() == "FACULTY")
                            {
                                mux = "せんせい";
                            }
                            else if (Reader6["type"].ToString() == "ADMIN")
                            {
                                mux = "経営";
                            }
                            Label9.Text = "ようこそ" + ((Reader6["fname"].ToString()) + " " + (Reader6["lname"].ToString()) + " (" + mux + ")");
                            //   wroA = (int.Parse(Reader6["incor"].ToString()));
                        }
                        Reader6.Close();
                        Scon6.Close();
                    }


                }
                else if (Page.Session["lang"].ToString() == "ES")
                {
                    Label4.Text = "Home";
                    Label5.Text = "Examen";
                    Label6.Text = "Estudiantes";
                  //  Label7.Text = "Documentos";
                    Label8.Text = "Ajustes";
                    Label2.Text = "Test Administration System";
                    Label3.Text = "Malayan Colleges Laguna";
                    {
                        SqlConnection Scon6;
                        SqlDataReader Reader6;
                        SqlCommand Cmd6;
                        StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                        line = sr6.ReadLine();
                        string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                        string sql6;
                        sql6 = "Select * From user_table WHERE user_id = '" + user + "'";
                        Scon6 = new SqlConnection(sConnection6);
                        Scon6.Open();
                        Cmd6 = new SqlCommand(sql6, Scon6);
                        Reader6 = Cmd6.ExecuteReader();

                        while (Reader6.Read())
                        {
                            string mux = "";
                            if (Reader6["type"].ToString() == "FACULTY")
                            {
                                mux = "Principál";
                            }
                            else if (Reader6["type"].ToString() == "ADMIN")
                            {
                                mux = "Arbol";
                            }
                            Label9.Text = "Bienvenido " + ((Reader6["fname"].ToString()) + " " + (Reader6["lname"].ToString()) + " (" + mux + ")");
                            //   wroA = (int.Parse(Reader6["incor"].ToString()));
                        }
                        Reader6.Close();
                        Scon6.Close();
                    }
                }
            }
            catch
            {
                {
                    SqlConnection Scon6;
                    SqlDataReader Reader6;
                    SqlCommand Cmd6;
                    StreamReader sr6 = new StreamReader(Request.PhysicalApplicationPath.ToString() + "//dBLoc.txt");
                    line = sr6.ReadLine();
                    string sConnection6 = "Data Source=" + line + "\\SQLEXPRESS;Database=CIT;User=sydrick;password=1234567";
                    string sql6;
                    sql6 = "Select * From user_table WHERE user_id = '" + user + "'";
                    Scon6 = new SqlConnection(sConnection6);
                    Scon6.Open();
                    Cmd6 = new SqlCommand(sql6, Scon6);
                    Reader6 = Cmd6.ExecuteReader();

                    while (Reader6.Read())
                    {
                        Label9.Text = "Welcome " + ((Reader6["fname"].ToString()) + " " + (Reader6["lname"].ToString()) + " (" + (Reader6["type"].ToString()) + ")");
                        //   wroA = (int.Parse(Reader6["incor"].ToString()));
                    }
                    Reader6.Close();
                    Scon6.Close();
                }
            }
           

        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Page.Session["user"] = null;
        Response.Redirect("LogIn.aspx");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Page.Session["lang"] = "JA";
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Page.Session["lang"] = "ES";
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Page.Session["lang"] = "EN";
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {

    }
}
