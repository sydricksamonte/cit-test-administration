<%@ Page Language="C#" MasterPageFile="~/active2.master" AutoEventWireup="true" CodeFile="Grades.aspx.cs" Inherits="Exams" Title="CIT Exam System | My Grades" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
 
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:Panel ID="Panel1" runat="server" Height="1px" Style="font-size: small; left: -8px;
        background-image: url(Images/tabla7.png); color: white; font-family: 'Lucida Sans';
        position: absolute; top: 584px; background-color: transparent; z-index: 100;" Width="1px">
        <asp:Label ID="Label1" runat="server" Style="left: 65px; color: limegreen; position: absolute;
            top: 26px; z-index: 100;" Text="Lastname, Firstname (Middle name),"></asp:Label>
        <asp:Label ID="Label4" runat="server" Style="font-size: small; left: 32px; color: gray;
            font-style: italic; position: absolute; top: 53px; z-index: 101;" Text="Select an item to view score"></asp:Label>
        <asp:Label ID="Hello" runat="server" Style="left: 25px; position: absolute; top: 26px; z-index: 102;"
            Text="Hello"></asp:Label>
        &nbsp; &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString6 %>"
            SelectCommand="SELECT * FROM [answers] WHERE (([exam_code] = @exam_code2) AND ([user_id] = @user_id)) ORDER BY [ques_id]">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="exam_code2" PropertyName="SelectedValue"
                    Type="String" />
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpExams_SelectedIndexChanged"
            Style="font-size: small; left: 118px; font-family: 'Lucida Sans'; position: absolute;
            top: 6px; z-index: 103;" Width="1px" DataSourceID="SqlDataSource4" DataTextField="exam_code" DataValueField="exam_code" Enabled="False" OnDataBound="drpExams_DataBound">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>"
            SelectCommand="SELECT question_table.ins_id, question_table.ques_id, question_table.exam_code, question_table.typeEx, question_table.ques_desc, question_table.ans_a, question_table.ans_b, question_table.ans_c, question_table.ans_d, question_table.ans_e, question_table.ans_f, question_table.ans_g, question_table.ans_h, question_table.ans_i, question_table.ans_j, question_table.l_outcomes, question_table.p_date, question_table.imgLoc, question_table.l_o, question_table.c_o, question_table.copy_type, answers.ans FROM question_table INNER JOIN answers ON question_table.ques_id = answers.ques_id AND question_table.exam_code = answers.exam_code WHERE (question_table.exam_code = @exam_code) AND (answers.ans <> N'noanswerxxx') ORDER BY question_table.ques_desc">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView2" Name="exam_code" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>"
            SelectCommand="SELECT *  FROM exam_results WHERE (user_id = @user_id) AND (d_close = @d_close) ORDER BY d_taken DESC">
            <SelectParameters>
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                <asp:Parameter DefaultValue="TAKEN" Name="d_close" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString8 %>"
            SelectCommand="SELECT [exam_code] FROM [exam_results] WHERE (([user_id] = @user_id) AND ([d_taken] <> @d_taken)) ORDER BY [d_taken] DESC">
            <SelectParameters>
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                <asp:Parameter DefaultValue="NOT TAKEN" Name="d_taken" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp;
        <asp:ListBox ID="listStud" runat="server" Height="17px" Style="left: -306px; position: absolute;
            top: 279px; z-index: 105;" Width="83px" OnLoad="listStud_SelectedIndexChanged" Visible="False"></asp:ListBox>
        <asp:ListBox ID="listCor" runat="server" Height="18px" Style="left: -284px; position: absolute;
            top: 222px; z-index: 106;" Width="73px" OnLoad="listCor_Load" Visible="False"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Panel ID="Panel3" runat="server" Style="left: -15px; position: absolute; top: -4px; z-index: 107;">
        <asp:ListBox ID="ListBox1" runat="server" Height="78px" Style="left: 72px; position: absolute;
            top: 50px; text-align: left; font-size: medium; font-family: Calibri;" Width="67px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <asp:Label ID="lblAll" runat="server" Font-Bold="True" Font-Size="X-Large" Style="left: 102px;
            color: limegreen; position: absolute; top: 74px" Text="00"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Size="Medium" Style="left: 77px; color: limegreen;
            position: absolute; top: 39px" Text="Total Score:" Width="106px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Size="Medium" Style="left: 66px; color: limegreen;
            position: absolute; top: 38px" Text="Status:"></asp:Label>
        <asp:Label ID="lblStat" runat="server" Font-Size="Medium" Style="left: 125px; color: limegreen;
            position: absolute; top: 37px" Text="Passed"></asp:Label>
        <asp:Label ID="lblCorAns" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="X-Large"
            Font-Underline="True" Style="left: 93px; color: limegreen; position: absolute;
            top: 42px" Text="00"></asp:Label>
        <asp:Label ID="lblPerc" runat="server" Font-Bold="True" Font-Size="XX-Large" Style="font-size: 50px;
            left: 81px; position: absolute; top: 69px" Text="00"></asp:Label>
        </asp:Panel>
        <asp:Label ID="Label3" runat="server" Font-Size="Medium" Style="left: 21px; color: limegreen;
            position: absolute; top: 3px; z-index: 108;" Text="Grades"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="25pt" Style="left: 34px;
            color: white; position: absolute; top: 39px; z-index: 109;" Text="No test/s found"></asp:Label>
        <asp:DropDownList ID="drpExams" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="drpExams_SelectedIndexChanged" Style="font-size: small;
            left: 13px; font-family: 'Lucida Sans'; position: absolute; top: 27px; z-index: 110;" Width="127px" DataSourceID="SqlDataSource3" DataTextField="pname" DataValueField="pname" OnDataBound="drpExams_DataBound1" Height="8px">
            </asp:DropDownList>
    </asp:Panel>
     &nbsp;
     <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>"
         SelectCommand="SELECT * FROM [exam_results] WHERE (([d_close] = @d_close) AND ([user_id] = @user_id)) ORDER BY [d_taken] DESC">
         <SelectParameters>
             <asp:Parameter DefaultValue="TAKEN" Name="d_close" Type="String" />
             <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
         </SelectParameters>
     </asp:SqlDataSource>
     <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Calibri" Font-Size="Large"
         ForeColor="#404040" OnClick="LinkButton22_Click" PostBackUrl="~/Home.aspx" Style="z-index: 100;
         left: 166px; position: absolute; top: 85px">Home</asp:LinkButton>
     <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Calibri" Font-Size="Large"
         ForeColor="#404040" OnClick="LinkButton2_Click" Style="z-index: 100; left: 300px;
         position: absolute; top: 85px">My Tests</asp:LinkButton>
     &nbsp; &nbsp;
     &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
     <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="298px" Style="z-index: 101;
         left: -11px; position: absolute; top: 580px" Width="190px">
     </asp:Panel>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Calibri" Font-Size="Large"
         ForeColor="#404040" OnClick="LinkButton4_Click" Style="z-index: 100; left: 941px;
         position: absolute; top: 22px">Sign Out</asp:LinkButton>
     <asp:Label ID="Label29" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
         Style="font-size: medium; z-index: 104; left: 361px; color: gray; position: absolute;
         top: 50px" Text="Malayan Colleges Laguna" Width="178px"></asp:Label>
     <br />
     <asp:Label ID="Label27" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
         Style="font-size: 21px; z-index: 102; left: 118px; position: absolute; top: 44px"
         Text="Test Administration System" Width="239px"></asp:Label>
     <asp:Label ID="Label28" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium"
         Style="font-size: medium; z-index: 104; left: 757px; color: gray; position: absolute;
         top: 24px; text-align: right;" Text="Malayan Colleges Laguna" Width="178px"></asp:Label>
     <asp:LinkButton ID="LinkButton22" runat="server" Font-Names="Calibri" Font-Size="Large"
         ForeColor="Green" PostBackUrl="~/Grades.aspx" Style="z-index: 100; left: 216px;
         position: absolute; top: 85px">My Grades</asp:LinkButton>
   <%--  <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Calibri" Font-Size="Large"
         Font-Underline="True" ForeColor="#404040" OnClick="LinkButton1_Click2" PostBackUrl="~/Grades.aspx"
         Style="z-index: 101; left: 220px; position: absolute; top: 85px">My Grades</asp:LinkButton>--%>
   <%--  <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Calibri" Font-Size="Large"
         ForeColor="#404040" OnClick="LinkButton1_Click1" Style="left: 0px; top: 55px">My Tests</asp:LinkButton><br />--%>
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
         CellPadding="0" DataKeyNames="exam_code,course" DataSourceID="SqlDataSource6" ForeColor="#333333"
         GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" PageSize="5" OnRowCreated="GridView2_RowCreated" SelectedIndex="0" OnDataBound="GridView2_DataBound">
         <RowStyle BackColor="#F7F6F3" Font-Names="Segoe UI" ForeColor="#333333" />
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
             <asp:BoundField DataField="stud_co_se_id" HeaderText="stud_co_se_id" ReadOnly="True"
                 SortExpression="stud_co_se_id" Visible="False" />
             <asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id"
                 Visible="False" />
             <asp:BoundField DataField="exam_code" HeaderText="exam_code" SortExpression="exam_code"
                 Visible="False" />
             <asp:TemplateField HeaderText="Tests" SortExpression="pname">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("pname") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <table style="width: 364px">
                         <tr>
                             <td rowspan="3" style="width: 68px">
                                 <asp:Image ID="Image1" runat="server" Height="55px"
                                     Width="55px" /></td>
                             <td>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("pname") %>'></asp:Label>
                                 <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("exam_code") %>' OnValueChanged="HiddenField2_ValueChanged" /><asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("course") %>' OnValueChanged="HiddenField2_ValueChanged" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label10" runat="server" Font-Size="Small" Text="Score:"></asp:Label>&nbsp;
                                 <asp:Label ID="Label11" runat="server" Font-Size="Small" Text='<%# Eval("score") %>'></asp:Label>
                                 <asp:Label ID="Label12" runat="server" Font-Size="Small" Text="%"></asp:Label>
                                 </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label14" runat="server" Font-Size="Small" Text="Status:"></asp:Label>&nbsp;
                                 <asp:Label ID="Label15" runat="server"></asp:Label></td>
                         </tr>
                     </table>
                 </ItemTemplate>
                 <HeaderStyle Font-Bold="False" Font-Size="Medium" />
             </asp:TemplateField>
         </Columns>
         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         <HeaderStyle BackColor="#5D7B9D" CssClass="HeaderStyle" Font-Bold="False" Font-Names="Segoe UI"
             Font-Size="Medium" ForeColor="White" />
         <EditRowStyle BackColor="#999999" />
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
     </asp:GridView>
     <br />
     <br />
     <br />
     <br />
     &nbsp;&nbsp;
     <table style="z-index: 104; left: 459px; width: 326px; position: absolute; top: 143px;
         height: 267px">
         <tr>
             <td style="width: 3px; height: 292px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0"
            DataKeyNames="ques_id" DataSourceID="SqlDataSource5" ForeColor="#333333" GridLines="None"
            Height="194px" OnDataBound="GridView1_SelectedIndexChanged" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="485px" ShowFooter="True">
            <RowStyle BackColor="#E0E0E0" Font-Names="Segoe UI" />
            <Columns>
                <asp:BoundField DataField="ins_id" HeaderText="ins_id" SortExpression="ins_id" Visible="False" />
                <asp:BoundField DataField="ques_id" HeaderText="ques_id" ReadOnly="True" SortExpression="ques_id"
                    Visible="False" />
                <asp:BoundField DataField="exam_code" HeaderText="exam_code" SortExpression="exam_code"
                    Visible="False" />
                <asp:TemplateField HeaderText="Questions" SortExpression="ques_desc">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ques_desc") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text='<%# Bind("ques_desc") %>'></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ques_id") %>' />
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Your answer is:"></asp:Label>&nbsp;
                        <asp:Label ID="Label18" runat="server" Text='<%# Eval("ans") %>' Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label8" runat="server" ForeColor="Gray"></asp:Label>
                        <asp:Label ID="Label9" runat="server" ForeColor="Gray"></asp:Label>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Item Topic:"></asp:Label>&nbsp;
                        <asp:Label ID="Label20" runat="server"></asp:Label>
                    </ItemTemplate><FooterTemplate>
                        &nbsp;&nbsp;<br />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <span style="font-family: Segoe UI">Select An Exam To View Information.</span>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="HeaderStyle" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
             </td>
         </tr>
         <tr>
             <td style="width: 3px; height: 225px;">
                 &nbsp;<br /><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="0"
            DataKeyNames="ques_id" DataSourceID="SqlDataSource7" ForeColor="#333333" GridLines="None"
            Height="194px" Width="485px" ShowFooter="True" OnDataBound="GridView3_DataBound">
                 <RowStyle BackColor="#EFF3FB" Font-Names="Segoe UI" />
                 <Columns>
                     <asp:BoundField DataField="ins_id" HeaderText="ins_id" SortExpression="ins_id" Visible="False" />
                     <asp:BoundField DataField="ques_id" HeaderText="ques_id" ReadOnly="True" SortExpression="ques_id"
                    Visible="False" />
                     <asp:BoundField DataField="exam_code" HeaderText="exam_code" SortExpression="exam_code"
                    Visible="False" />
                     <asp:TemplateField HeaderText="Topics" SortExpression="ques_desc">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ques_desc") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <FooterTemplate>
                             &nbsp;&nbsp;<br />
                         </FooterTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text='<%# Eval("l_o") %>'></asp:Label>&nbsp;
                             (<asp:Label ID="Label8" runat="server" Font-Bold="False" Text='<%# Eval("correct") %>' ForeColor="ControlDarkDark"></asp:Label><asp:Label ID="Label24" runat="server" Font-Size="Small" Text="/" Font-Bold="False" ForeColor="ControlDarkDark"></asp:Label><asp:Label ID="Label17" runat="server" Font-Bold="False" Text='<%# Eval("t_count") %>' ForeColor="ControlDarkDark"></asp:Label>)
                             <asp:Label ID="Label26" runat="server" Font-Bold="False" ForeColor="ControlDarkDark"></asp:Label>
                             <asp:Label ID="Label30" runat="server" Font-Bold="False" ForeColor="ControlDarkDark"></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <EmptyDataTemplate>
                     <span style="font-family: Segoe UI"></span>
                 </EmptyDataTemplate>
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="HeaderStyle" />
                 <EditRowStyle BackColor="#2461BF" />
                 <AlternatingRowStyle BackColor="White" />
             </asp:GridView>
                 <br />
                 <asp:Label ID="Label23" runat="server" Font-Names="Segoe UI" Text="Topic(s) passed:"></asp:Label>
                 <asp:Label ID="Label21" runat="server" Font-Bold="False" Font-Names="Segoe UI" ForeColor="#004000"></asp:Label><br />
                 <asp:Label ID="Label22" runat="server" Font-Names="Segoe UI" Text="Topic(s) that needs improvement:"></asp:Label>
                 <asp:Label ID="Label19" runat="server" Font-Bold="False" Font-Names="Segoe UI" ForeColor="Maroon"></asp:Label>&nbsp;<br />
                 &nbsp;
                 <asp:Label ID="Label16" runat="server" Font-Names="Segoe UI" Text="Topic(s) perfected:"
                     Visible="False"></asp:Label>
                 <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Names="Segoe UI" ForeColor="#004000"
                     Visible="False"></asp:Label><asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>"
                     SelectCommand="SELECT l_o_id, exname, user_id, ques_id, correct, incor, l_o, t_count FROM course_bulk WHERE (user_id = @user_id) AND (exname = @exname) ORDER BY correct DESC, t_count ASC">
                     <SelectParameters>
                         <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                         <asp:ControlParameter ControlID="GridView2" Name="exname" PropertyName="SelectedValue"
                             Type="String" />
                     </SelectParameters>
                 </asp:SqlDataSource>
             </td>
         </tr>
         <tr>
             <td style="width: 3px; height: 225px">
                 <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                     BestFitPage="False" DisplayGroupTree="False" DisplayToolbar="False" EnableDatabaseLogonPrompt="False"
                     EnableParameterPrompt="False" Height="350px"
                     Width="500px" Visible="False" />
                 <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                     <Report FileName="GradesRep.rpt">
                     </Report>
                 </CR:CrystalReportSource><CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="True"
                     BestFitPage="False" DisplayGroupTree="False" DisplayToolbar="False" EnableDatabaseLogonPrompt="False"
                     EnableParameterPrompt="False" Height="350px"
                     Width="500px" Visible="False" />
             </td>
         </tr>
         <tr>
             <td style="width: 3px;" rowspan="2">
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                 &nbsp; &nbsp;&nbsp;
                 <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Segoe UI" ForeColor="Gray"
                     Style="left: 53px; top: -37px" OnClick="LinkButton1_Click" PostBackUrl="~/Grades.aspx" Width="92px">Back to Top</asp:LinkButton></td>
         </tr>
         <tr>
         </tr>
     </table>
     <br />
</asp:Content>


