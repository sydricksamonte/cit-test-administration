<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsCreateExam_LOchoose.aspx.cs" Inherits="InsCreateExam_LOchoose" Title="CIT Examination System | Create Exam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    &nbsp;
    <asp:Panel ID="Panel2" runat="server" Height="423px"
        Style="left: 171px; position: absolute; top: 213px; z-index: 100;" Width="673px" BackColor="Transparent">
        &nbsp;
        <asp:Label ID="Label15" runat="server" Font-Bold="True" Height="19px" Style="font-size: medium;
            left: 297px; color: limegreen; font-family: Calibri; position: absolute;
            top: 10px; font-weight: normal; z-index: 100;" Text="Select a course:" Width="108px" Visible="False"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="19px" Style="font-size: medium;
            left: -61px; color: limegreen; font-family: Calibri; position: absolute;
            top: -70px; font-weight: bold; font-variant: normal; z-index: 101;" Text="Please indicate the course of this test:" Width="405px"></asp:Label>
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CITConnectionString3 %>" OnSelected="SqlDataSource1_Selected">
        </asp:SqlDataSource>
        <asp:TextBox ID="txtD" runat="server" Visible="False"></asp:TextBox>
        &nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" BackColor="ButtonHighlight"
            DataSourceID="SqlDataSource2" DataTextField="course_id" DataValueField="course_id"
            ForeColor="Black" OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
            Style="font-size: small; left: -171px; font-family: Calibri; position: absolute;
            top: 564px; z-index: 102;" Width="1px">
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
        SelectCommand="SELECT * FROM [learnObjectives] WHERE ([course] = @course) ORDER BY [lo_id]" OnSelected="SqlDataSource10_Selected">
        <SelectParameters>
            <asp:SessionParameter Name="course" SessionField="course" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString16 %>"
            SelectCommand="SELECT DISTINCT [course_id] FROM [course] WHERE ([sec_handler] = @sec_handler) ORDER BY [course_id]">
            <SelectParameters>
                <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" Style="font-size: medium; left: -19px;
            color: red; font-family: Calibri; position: absolute; top: -57px; z-index: 106;" PostBackUrl="~/InsCreateExam.aspx"></asp:LinkButton>
        <asp:Panel ID="Panel1" runat="server" Height="196px" Style="left: 109px; position: absolute;
            top: 61px; z-index: 105;" Visible="False" Width="489px">
            <asp:ImageButton ID="ImageButton1" runat="server" BackColor="Transparent" Enabled="False"
                Height="217px" ImageUrl="~/Images/tabla6.png" OnClick="ImageButton1_Click" Style="left: 6px;
                position: absolute; top: -14px" Width="492px" />
            <asp:Label ID="Label6" runat="server" Font-Size="Medium" ForeColor="White" Style="left: 26px;
                font-family: Calibri; position: absolute; top: 29px" Text="Multiple Choice questions"
                Width="189px"></asp:Label>
            &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Style="left: 337px; position: absolute;
            top: 116px" Text="Proceed to Next Step" Height="41px" OnClick="Button1_Click1" Width="141px" ValidationGroup="aa" />
            <asp:Label ID="Label11" runat="server" Font-Size="Large" ForeColor="White" Style="left: 22px;
                font-family: Calibri; position: absolute; top: -4px" Text="Enter number of items to be added:"
                Width="280px" Font-Bold="True"></asp:Label>
            <asp:Label ID="llblMu" runat="server" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium"
                ForeColor="White" Style="left: 27px; position: absolute; top: 50px"></asp:Label>
            <asp:Label ID="Label10" runat="server" Font-Size="Medium" ForeColor="White" Style="left: 27px;
                font-family: Calibri; position: absolute; top: 99px" Text="True or False questions"
                Width="190px"></asp:Label>
            <asp:Label ID="Label12" runat="server" Font-Size="Small" ForeColor="Silver" Style="left: 27px;
                font-family: Calibri; position: absolute; top: 75px" Text="No of items"
                Width="134px"></asp:Label>
            <asp:Label ID="Label13" runat="server" Font-Size="Small" ForeColor="Silver" Style="left: 26px;
                font-family: Calibri; position: absolute; top: 155px" Text="No of items"
                Width="134px"></asp:Label>
            <asp:Label ID="Label14" runat="server" Font-Size="Small" ForeColor="Silver" Style="left: 289px;
                font-family: Calibri; position: absolute; top: 74px" Text="No of items "
                Width="134px"></asp:Label>
            <asp:Label ID="Label9" runat="server" Font-Size="Medium" ForeColor="White" Style="left: 289px;
                font-family: Calibri; position: absolute; top: 31px" Text="Identification Questions"
                Width="174px"></asp:Label>
            <asp:TextBox ID="txtIDen" runat="server" MaxLength="2" Style="left: 425px; position: absolute;
                top: 71px" Width="23px">0</asp:TextBox>
            <asp:TextBox ID="txtTF" runat="server" MaxLength="2" Style="left: 164px; position: absolute;
                top: 153px" Width="23px">0</asp:TextBox>
            <asp:Label ID="lblTF" runat="server" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium"
                ForeColor="White" Style="left: 27px; position: absolute; top: 126px"></asp:Label>
            <asp:Label ID="lblIden" runat="server" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium"
                ForeColor="White" Style="left: 289px; position: absolute; top: 52px"></asp:Label>
            <asp:TextBox ID="txtMul" runat="server" MaxLength="2" Style="left: 163px; position: absolute;
                top: 71px" Width="23px">0</asp:TextBox>
            <asp:RangeValidator ID="rMul" runat="server" ControlToValidate="txtMul" CultureInvariantValues="True"
                ErrorMessage="Error Value" Font-Names="Calibri" Font-Size="Small"
                MinimumValue="0" SetFocusOnError="True" Style="left: 191px; position: absolute;
                top: 71px" Type="Integer" ValidationGroup="aa"></asp:RangeValidator>
            <asp:RangeValidator ID="rTF" runat="server" ControlToValidate="txtTF" CultureInvariantValues="True"
                ErrorMessage="Error Value" Font-Names="Calibri" Font-Size="Small"
                MinimumValue="0" SetFocusOnError="True" Style="left: 193px; position: absolute;
                top: 152px" Type="Integer" ValidationGroup="aa"></asp:RangeValidator>
            <asp:RangeValidator ID="rIde" runat="server" ControlToValidate="txtIDen" CultureInvariantValues="True"
                ErrorMessage="Error" Font-Names="Calibri" Font-Size="Small"
                MinimumValue="0" SetFocusOnError="True" Style="left: 453px; position: absolute;
                top: 70px" Type="Integer" ValidationGroup="aa"></asp:RangeValidator>
    <asp:ListBox ID="ListBox3" runat="server" style="left: -290px; position: absolute; top: 533px" AutoPostBack="True" Enabled="False" ForeColor="White" Height="24px" SelectionMode="Multiple" Width="30px"></asp:ListBox>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click" Style="font-size: medium;
                left: 345px; color: gray; font-family: Calibri; position: absolute; top: 163px" PostBackUrl="~/InsCreateExam_LOchoose.aspx">Add more topic/s</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    &nbsp;
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
        CellPadding="0" DataKeyNames="lo_id" ForeColor="#333333"
        GridLines="None" Height="97px" OnDataBound="GridView2_DataBound" OnLoad="GridView1_Load"
        PageSize="12" Style="font-size: small; left: 823px; font-family: Calibri; position: absolute;
        top: 207px; z-index: 101;" Width="537px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnUnload="GridView2_Unload" ShowFooter="True" Visible="False">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:TemplateField HeaderText="Select which weekly topic/s to add" SortExpression="topic_id">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("topic_id") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <table style="width: 658px">
                        <tr>
                            <td style="width: 153px; height: 20px">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("lo_id") %>'></asp:Label></td>
                            <td colspan="4" style="height: 20px">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("l_desc") %>' OnCheckedChanged="CheckBox1_CheckedChanged" /></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <FooterTemplate>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" Height="24px" OnClick="Button1_Click2" Style="text-align: center;" Text="Proceed to Next Step" Width="203px" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="DarkSeaGreen" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            &nbsp;
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="SeaGreen" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="Snow" />
    </asp:GridView>
    &nbsp;&nbsp;<br />
         <asp:Label ID="Label2" runat="server" Height="1px" Style="font-size: medium; left: 152px;
        color: red; font-family: Calibri; position: absolute; top: 158px; z-index: 103;"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Style="z-index: 105; left: -11px; position: absolute;
        top: 240px" Text="0"></asp:Label>
    <asp:Label ID="Label5" runat="server" Height="1px" Style="font-size: medium; z-index: 103;
        left: 154px; color: red; font-family: Calibri; position: absolute; top: 163px"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            CellPadding="0" DataKeyNames="week" DataSourceID="SqlDataSource1" ForeColor="#333333"
            GridLines="None" Height="97px" PageSize="12" Style="font-size: small; left: 206px;
            font-family: Calibri; position: absolute; top: 183px; z-index: 103;" Width="404px" OnLoad="GridView1_Load" OnDataBound="GridView1_DataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="Select which topic/s to add" SortExpression="lo_id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("lo_id") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Choose topics"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 604px">
                            <tr>
                                <td style="width: 478px; height: 20px" colspan="2">
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("topic_desc") %>' />
                                    &nbsp;-- &nbsp;<asp:Label ID="Label8" runat="server" Text="("></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                    <asp:Label ID="Label16" runat="server" Text="item(s) available)"></asp:Label>&nbsp;
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("l_o") %>' />
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("c_o") %>' />
                                    <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("topic_id") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <FooterTemplate>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="24px" OnClick="Button1_Click1s" Text="Proceed to Next Step" Width="191px" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="DarkSeaGreen" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Style="left: 5px; color: white; font-style: italic; font-family: Calibri; position: static;
                    top: 56px" Text='No selection was made. ' Width="603px" Font-Italic="True" Font-Size="Medium"></asp:Label>
                <asp:Button ID="Button4" runat="server" Font-Names="Calibri" Font-Size="Medium" PostBackUrl="~/InsCreateExam.aspx"
                    Text="Go back to Exams" />
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="SeaGreen" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="Snow" />
        </asp:GridView>
  <%--  <script type="text/javascript">
function show_confirm()
{
var r=confirm("You are trying to add/remove an exam topic from its original line up. \nDo you want to proceed?");
if (r==true)
 {
Response.Redirect("InsCreateExam_LOchoose.aspx");
}
else
  {
  
  }
}
</script>--%>
<%--<form>
<input type="button" value="Click me!" onclick="show_confirm()" Style="left: 673px;
        position: absolute; top: 295px" Width="141px" />
   
</form>--%>

</asp:Content>

