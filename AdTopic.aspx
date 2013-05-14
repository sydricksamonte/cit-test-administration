<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdTopic.aspx.cs" Inherits="InsExamScore" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CIT Exam System | Databank</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Style="font-family: Calibri;
            position: absolute; top: 6px; z-index: 100; left: 8px;" Text="Topics" Font-Size="X-Large"></asp:Label>
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
            DataTextField="course_desc" DataValueField="course_id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
            Style="z-index: 101; left: 413px; position: absolute; top: 72px" Width="288px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
            SelectCommand="SELECT DISTINCT * FROM [course_data] ORDER BY [course_desc]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 102;
            left: 338px; position: absolute; top: 69px" Text="Course:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 103;
            left: 338px; position: absolute; top: 104px" Text="Course code:"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
            Style="z-index: 104; left: 453px; position: absolute; top: 104px" Text="ALL"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 105;
            left: 565px; position: absolute; top: 104px" Text="Total topics count:"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
            Style="z-index: 106; left: 762px; position: absolute; top: 105px"></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Calibri" ForeColor="LimeGreen"
            PostBackUrl="~/AdHome.aspx" Style="z-index: 107; left: 9px; position: absolute;
            top: 69px">Home></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Calibri" ForeColor="LimeGreen"
            Style="z-index: 108; left: 72px; position: absolute; top: 69px" PostBackUrl="~/AdTopic.aspx">Topics></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Calibri" ForeColor="LimeGreen"
            PostBackUrl="~/AdLO.aspx" Style="z-index: 109; left: 138px; position: absolute;
            top: 69px">Subtopics></asp:LinkButton>
        &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<br />
        <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 110; left: 16px;
            position: absolute; top: 132px" />
        <asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
            ImageUrl="~/Images/button.png" OnClick="ImageButton5_Click" Style="z-index: 111;
            left: 46px; position: absolute; top: 160px" Width="119px" />
        <asp:Label ID="Label8" runat="server" AssociatedControlID="ImageButton5" BorderStyle="None"
            Enabled="False" ForeColor="White" Height="9px" Style="font-size: small; z-index: 112;
            left: 83px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 164px"
            Text="Save" Width="33px"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 113;
            left: 37px; position: absolute; top: 105px" Text="Upload Course Syllabus"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="Silver" BorderStyle="None" BorderWidth="1px" CellPadding="0"
            DataSourceID="SqlDataSource3" Height="94px" PageSize="30" Style="font-size: medium;
            left: 10px; color: black; font-family: Calibri; position: static; top: 85px"
            Width="923px" AllowSorting="True" AutoGenerateEditButton="True" DataKeyNames="lo_id" OnRowUpdated="GridView1_RowUpdated">
            <RowStyle BackColor="White" ForeColor="Black" Font-Size="Small" />
            <Columns>
                <asp:BoundField DataField="lo_id" HeaderText="Week" ReadOnly="True" SortExpression="lo_id">
                    <ItemStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="l_desc" HeaderText="Description" SortExpression="l_desc">
                    <ItemStyle Width="700px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="Gray" CssClass="HeaderStyle" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="LightGray" ForeColor="Black" />
            <EmptyDataTemplate>
                No data found.
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
            DeleteCommand="DELETE FROM [learnObjectives] WHERE [lo_id] = @lo_id" InsertCommand="INSERT INTO [learnObjectives] ([lo_id], [l_desc]) VALUES (@lo_id, @l_desc)"
            SelectCommand="SELECT [lo_id], [l_desc] FROM [learnObjectives] WHERE ([course] LIKE '%' + @course + '%') ORDER BY [lo_id]"
            UpdateCommand="UPDATE [learnObjectives] SET [l_desc] = @l_desc WHERE [lo_id] = @lo_id">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label4" Name="course" PropertyName="Text" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="lo_id" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="l_desc" Type="String" />
                <asp:Parameter Name="lo_id" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="lo_id" Type="String" />
                <asp:Parameter Name="l_desc" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
            SelectCommand="SELECT ques_desc, ans_a, ans_b, ans_c, ans_d, ans_e, ques_id, l_o, c_o FROM question_table WHERE (typeEx = @typeEx) AND (copy_type = @copy_type) AND (l_outcomes LIKE '%' + @l_outcomes + '%')" DeleteCommand="DELETE FROM [question_table] WHERE [ques_id] = @ques_id" InsertCommand="INSERT INTO [question_table] ([ques_desc], [ans_a], [ans_b], [ans_c], [ans_d], [ans_e], [ques_id], [l_o], [c_o]) VALUES (@ques_desc, @ans_a, @ans_b, @ans_c, @ans_d, @ans_e, @ques_id, @l_o, @c_o)" UpdateCommand="UPDATE [question_table] SET [ques_desc] = @ques_desc, [ans_a] = @ans_a, [ans_b] = @ans_b, [ans_c] = @ans_c, [ans_d] = @ans_d, [ans_e] = @ans_e, [l_o] = @l_o, [c_o] = @c_o WHERE [ques_id] = @ques_id">
            <SelectParameters>
                <asp:Parameter DefaultValue="Iden" Name="typeEx" Type="String" />
                <asp:Parameter DefaultValue="databank" Name="copy_type" Type="String" />
                <asp:SessionParameter DefaultValue="-" Name="l_outcomes" SessionField="cou" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="ques_id" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ques_desc" Type="String" />
                <asp:Parameter Name="ans_a" Type="String" />
                <asp:Parameter Name="ans_b" Type="String" />
                <asp:Parameter Name="ans_c" Type="String" />
                <asp:Parameter Name="ans_d" Type="String" />
                <asp:Parameter Name="ans_e" Type="String" />
                <asp:Parameter Name="l_o" Type="String" />
                <asp:Parameter Name="c_o" Type="String" />
                <asp:Parameter Name="ques_id" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ques_desc" Type="String" />
                <asp:Parameter Name="ans_a" Type="String" />
                <asp:Parameter Name="ans_b" Type="String" />
                <asp:Parameter Name="ans_c" Type="String" />
                <asp:Parameter Name="ans_d" Type="String" />
                <asp:Parameter Name="ans_e" Type="String" />
                <asp:Parameter Name="ques_id" Type="String" />
                <asp:Parameter Name="l_o" Type="String" />
                <asp:Parameter Name="c_o" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            Style="font-size: 1pt; z-index: 115; left: -51px; position: absolute; top: 152px">
            <RowStyle BackColor="#EFF3FB" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
