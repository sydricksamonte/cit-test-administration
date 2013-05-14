<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdLO.aspx.cs" Inherits="InsExamScore" %>

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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
            SelectCommand="SELECT DISTINCT * FROM [course_data] ORDER BY [course_desc]"></asp:SqlDataSource>
        &nbsp;<br />
        &nbsp;<br />
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Calibri" ForeColor="LimeGreen"
            PostBackUrl="~/AdHome.aspx" Style="z-index: 101; left: 18px; position: absolute;
            top: 81px">Home></asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Calibri" ForeColor="LimeGreen"
            PostBackUrl="~/AdExams.aspx" Style="z-index: 102; left: 76px; position: absolute;
            top: 81px">Exams></asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Calibri" ForeColor="LimeGreen"
            OnClick="LinkButton3_Click" PostBackUrl="~/AdLO.aspx" Style="z-index: 103; left: 140px;
            position: absolute; top: 81px">Topics></asp:LinkButton>
        &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
        <asp:Panel ID="Panel1" runat="server" BackColor="DarkGray" Height="118px" Style="z-index: 104;
            left: 409px; position: absolute; top: 4px" Width="513px">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
            DataTextField="course_desc" DataValueField="course_id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
            Style="z-index: 101; left: 85px; position: absolute; top: 36px" Width="406px">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 102;
            left: 21px; position: absolute; top: 37px" Text="Course:"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 103;
            left: 21px; position: absolute; top: 64px" Text="Course code:"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
            Style="z-index: 104; left: 154px; position: absolute; top: 64px" Text="ALL"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 105;
            left: 21px; position: absolute; top: 90px" Text="Total topics count:"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
            Style="z-index: 106; left: 154px; position: absolute; top: 89px"></asp:Label>
            <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Large" Style="z-index: 102;
                left: 11px; position: absolute; top: 4px" Text="Courses Overview"></asp:Label>
        </asp:Panel>
        <br />
        &nbsp; &nbsp;
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            Style="z-index: 109; left: -81px; position: absolute; top: 475px; font-size: 1pt;" Width="59px">
            <RowStyle BackColor="#EFF3FB" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="Button3" runat="server" Height="25px" PostBackUrl="~/CoursesData.aspx"
            Style="z-index: 110; left: 770px; position: absolute; top: 7px" Text="Show courses"
            Width="129px" />
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Segoe UI" Font-Size="Small"
            ForeColor="Red" Height="38px" OnClick="LinkButton4_Click" Style="left: 302px;
            position: absolute; top: 180px; z-index: 111;" Visible="False" Width="527px"></asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" Font-Names="Segoe UI" Font-Size="Small"
            ForeColor="Red" Height="38px" OnClick="LinkButton5_Click" Style="z-index: 112;
            left: 302px; position: absolute; top: 180px" Visible="False" Width="527px"></asp:LinkButton>
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" BackColor="Gray" Height="104px" Style="z-index: 114;
            left: 8px; position: absolute; top: 124px" Width="242px">
        <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 105; left: 23px;
            position: absolute; top: 36px" Width="206px" />
        <asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
            ImageUrl="~/Images/button.png" OnClick="ImageButton5_Click" Style="z-index: 106;
            left: 76px; position: absolute; top: 61px" Width="119px" />
        <asp:Label ID="Label8" runat="server" AssociatedControlID="ImageButton5" BorderStyle="None"
            Enabled="False" ForeColor="White" Height="9px" Style="font-size: small; z-index: 107;
            left: 110px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 65px"
            Text="Upload" Width="33px"></asp:Label>
        <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Medium" Style="z-index: 108;
            left: 13px; position: absolute; top: 9px" Text="Upload Course Syllabus"></asp:Label>
        </asp:Panel>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="Silver" BorderStyle="None" BorderWidth="1px" CellPadding="0"
            DataSourceID="SqlDataSource3" Height="94px" PageSize="30" Style="font-size: medium;
            left: 10px; color: black; font-family: Calibri; position: static; top: 85px"
            Width="923px" AllowSorting="True" AutoGenerateEditButton="True" DataKeyNames="topic_id" OnRowUpdated="GridView1_RowUpdated">
            <RowStyle BackColor="White" ForeColor="Black" Font-Size="Small" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select"
                            OnClick="LinkButton2_Click" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            Font-Names="Segoe UI" ForeColor="Red" OnClick="LinkButton1_Click" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="topic_desc" HeaderText="Topic" SortExpression="topic_desc">
                    <ItemStyle Width="700px" />
                </asp:BoundField>
                <asp:BoundField DataField="l_o" HeaderText="LO" SortExpression="l_o">
                    <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="topic_id" HeaderText="topic_id" ReadOnly="True" SortExpression="topic_id"
                    Visible="False" />
                <asp:BoundField DataField="c_o" HeaderText="CO" SortExpression="c_o">
                    <ItemStyle Width="50px" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            DeleteCommand="DELETE FROM [course_topics] WHERE [topic_id] = @topic_id" InsertCommand="INSERT INTO [course_topics] ([topic_desc], [l_o], [c_o], [topic_id]) VALUES (@topic_desc, @l_o, @c_o, @topic_id)"
            SelectCommand="SELECT [topic_desc], [l_o], [c_o], [topic_id] FROM [course_topics] WHERE ([topic_id] LIKE '%' + @topic_id + '%') ORDER BY [l_o]"
            UpdateCommand="UPDATE [course_topics] SET [topic_desc] = @topic_desc, [l_o] = @l_o, [c_o] = @c_o WHERE [topic_id] = @topic_id">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label4" Name="topic_id" PropertyName="Text" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="topic_id" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="topic_desc" Type="String" />
                <asp:Parameter Name="l_o" Type="String" />
                <asp:Parameter Name="c_o" Type="String" />
                <asp:Parameter Name="topic_id" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="topic_desc" Type="String" />
                <asp:Parameter Name="l_o" Type="String" />
                <asp:Parameter Name="c_o" Type="String" />
                <asp:Parameter Name="topic_id" Type="String" />
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
        &nbsp; &nbsp; &nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
