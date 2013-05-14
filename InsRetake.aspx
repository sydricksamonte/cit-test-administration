<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsRetake.aspx.cs" Inherits="InsRetake" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" BackColor="Transparent"
        Height="798px" Style="left: 189px; position: absolute; top: 236px" Width="673px">
        &nbsp;
        <asp:Label ID="Label15" runat="server" Font-Bold="True" Height="19px" Style="font-weight: normal;
            font-size: medium; left: 21px; color: limegreen; font-family: Calibri; position: absolute;
            top: -51px" Text="Select a course:" Width="108px"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="19px" Style="font-weight: normal;
            font-size: medium; left: 263px; color: limegreen; font-family: Calibri; position: absolute;
            top: -48px" Text="Select section:" Width="108px"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Height="19px" Style="font-weight: normal;
            font-size: medium; left: 22px; color: red; font-family: Calibri; position: absolute;
            top: -84px" Width="537px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
   
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString33 %>"
            SelectCommand="SELECT DISTINCT [course_sec] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([course_id] = @course_id))">
            <SelectParameters>
                <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="course_id" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
            DataSourceID="SqlDataSource2" DataTextField="course_id" DataValueField="course_id"
            OnDataBound="DropDownList2_DataBound" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
            Style="left: 135px; position: absolute; top: -50px" Width="124px">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" CausesValidation="True"
            DataSourceID="SqlDataSource1" DataTextField="course_sec" DataValueField="course_sec" OnDataBound="DropDownList6_DataBound" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged"
            Style="left: 378px; position: absolute; top: -49px" Width="123px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString35 %>"
            SelectCommand="SELECT DISTINCT [course_id] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([term] = @term)) ORDER BY [course_id]">
            <SelectParameters>
                <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
                <asp:ControlParameter ControlID="Label4" Name="term" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="0"
            DataKeyNames="stud_id" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None"
            Height="97px" OnDataBound="GridView2_DataBound" OnLoad="GridView1_Load" PageSize="9"
            ShowFooter="True" Style="font-size: small; left: 24px; font-family: Calibri;
            position: absolute; top: -21px" Width="537px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="Choose student/s you want to provide a retake." SortExpression="topic_id">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("topic_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"
                            Text="Select All" AutoPostBack="True" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Process Exam Retake" Width="198px" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <table style="width: 623px">
                            <tr>
                                <td colspan="1" style="width: 132px; height: 20px">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("stud_id") %>'></asp:Label></td>
                                <td colspan="5" style="width: 589px; height: 20px">
                                    &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("stud_name") %>' /></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="DarkSeaGreen" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium"
                    ForeColor="White" Text="No students found on this section."></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Classlists.aspx" Text="Create a classlist" />
                <asp:Button ID="Button2" runat="server" PostBackUrl="~/InsCreateExam.aspx" Text="Return to Exams" />
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="SeaGreen" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="Snow" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString45 %>"
            SelectCommand="SELECT * FROM [classlist] WHERE (([prof_id] = @prof_id) AND ([course_code] = @course_code) AND ([sec] = @sec)) ORDER BY [stud_name]">
            <SelectParameters>
                <asp:SessionParameter Name="prof_id" SessionField="user" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="course_code" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownList6" Name="sec" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        Height="19px" Style="font-weight: normal; font-size: large; left: 26px; color: limegreen;
        font-family: Calibri; position: absolute; top: 8px" Text="Reports" Visible="False"
        Width="45px"></asp:Label>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" Visible="False" />
</asp:Content>

