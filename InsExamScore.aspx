<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsExamScore.aspx.cs" Inherits="InsExamScore" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CIT Exam System | Scores</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Style="font-size: medium; font-family: Calibri;
            position: absolute; top: 0px" Text="Examination Name:"></asp:Label>
        <asp:Label ID="txtEx" runat="server" Style="font-weight: bold; font-size: medium;
            left: 148px; font-family: Calibri; position: absolute; top: 0px" Text="Examination Name:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Style="font-size: medium; left: 11px; font-family: Calibri;
            position: absolute; top: 58px" Text="Course:"></asp:Label>
        <asp:Label ID="txtCourse" runat="server" Style="font-weight: bold; font-size: medium;
            left: 145px; font-family: Calibri; position: absolute; top: 58px"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" Height="16px" NavigateUrl="~/InsCreateExam.aspx"
            Style="font-size: medium; left: 864px; font-family: Calibri; position: absolute;
            top: 100px" Width="34px">Back</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" Height="16px" NavigateUrl="~/InsExamScore.aspx"
            Style="font-size: medium; left: 810px; font-family: Calibri; position: absolute;
            top: 100px" Width="34px">Refresh</asp:HyperLink>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="Silver" BorderStyle="None" BorderWidth="1px" CellPadding="0" DataKeyNames="stud_co_se_id"
            DataSourceID="SqlDataSource1" Height="94px" PageSize="30" Style="font-size: medium;
            left: 10px; color: black; font-family: Calibri; position: static; top: 85px"
            Width="895px">
            <RowStyle BackColor="White" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="stud_name" HeaderText="Student" SortExpression="stud_name">
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="d_taken" HeaderText="Time started" SortExpression="d_taken">
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="score" HeaderText="Score" SortExpression="score">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="Gray" CssClass="HeaderStyle" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="LightGray" ForeColor="Black" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Style="font-size: medium; font-family: Calibri"
            Text="Total Examinee:"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Style="font-size: large; font-family: Calibri;
            position: static"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <asp:Label ID="Label6" runat="server" Style="font-size: medium; font-family: Calibri"
            Text="Finished:"></asp:Label>
        &nbsp;
        <asp:Label ID="Label8" runat="server" Style="font-weight: bold; font-size: large;
            color: #006600; font-family: Calibri; position: static"></asp:Label>
        <asp:Label ID="Label15" runat="server" Style="font-weight: bold; font-size: large;
            color: #006600; font-family: Calibri; position: static"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label11" runat="server"
            Style="font-size: medium; font-family: Calibri" Text="Taking:"></asp:Label>
        &nbsp;
        <asp:Label ID="Label12" runat="server" Style="font-size: large; color: #ff9900; font-family: Calibri;
            position: static"></asp:Label>
        <asp:Label ID="Label13" runat="server" Style="font-size: large; color: #ff9900; font-family: Calibri;
            position: static"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;
        <asp:Label ID="Label9" runat="server" Style="font-size: medium; font-family: Calibri"
            Text="Not present:"></asp:Label>
        &nbsp;
        <asp:Label ID="Label10" runat="server" Style="font-size: large; color: #ff0000; font-family: Calibri;
            position: static"></asp:Label>
        <asp:Label ID="Label14" runat="server" Style="font-size: large; color: #ff0000; font-family: Calibri;
            position: static"></asp:Label><br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString37 %>"
            SelectCommand="SELECT exam_results.stud_co_se_id, exam_results.user_id, exam_results.exam_code, exam_results.d_taken, exam_results.score, exam_results.pname, exam_results.section, exam_results.course, classlist.stud_name FROM exam_results INNER JOIN classlist ON exam_results.course = classlist.course_code AND exam_results.section = classlist.sec AND exam_results.user_id = classlist.stud_id WHERE (exam_results.exam_code = @exam_code)  AND (exam_results.section = @section) AND (exam_results.course = @course) ORDER BY classlist.stud_name ASC ">
            <SelectParameters>
                <asp:SessionParameter Name="exam_code" SessionField="exname" />
                <asp:SessionParameter Name="section" SessionField="section" />
                <asp:SessionParameter Name="course" SessionField="course" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;
        <asp:Label ID="Label5" runat="server" Style="font-size: medium; left: 401px; font-family: Calibri;
            position: absolute; top: 59px" Text="Section:"></asp:Label>
        <asp:Label ID="txtSec" runat="server" Style="font-weight: bold; font-size: medium;
            left: 468px; font-family: Calibri; position: absolute; top: 59px"></asp:Label>
        <asp:Label ID="Label7" runat="server" Style="font-size: medium; left: 10px; font-family: Calibri;
            position: absolute; top: 28px" Text="Instructor:"></asp:Label>
        <asp:Label ID="txtIns" runat="server" Style="font-weight: bold; font-size: medium;
            left: 147px; font-family: Calibri; position: absolute; top: 27px"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
