<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsHome.aspx.cs" Inherits="Home" Title="CIT Examination System | Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="White" BorderColor="Black" BorderWidth="1px" CellPadding="0"
        DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None"
        Style="font-size: medium; left: 167px; font-family: Calibri; position: absolute;
        top: 225px" Width="686px" DataKeyNames="exname" OnRowCreated="GridView1_RowCreated" OnDataBound="GridView1_DataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <RowStyle BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px" BackColor="White" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="72px" ImageUrl="~/Images/type_exam.png"
                                    Width="72px" OnClick="ImageButton1_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="My Tests" SortExpression="exname">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("exname") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <table style="width: 608px">
                        <tr>
                            <td colspan="2" style="height: 21px">
                                <asp:Label ID="Label2" runat="server" Height="15px" Style="color: #00cc00" Text='<%# Bind("pname") %>'></asp:Label><asp:HiddenField
                                    ID="HiddenField1" runat="server" Value='<%# Eval("exname") %>' />
                                <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("exname") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 21px">
                                <asp:Label ID="Label3" runat="server" Height="15px" Style="font-size: small; font-style: normal"></asp:Label>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 326px; height: 21px;">
                                <asp:Label ID="Label5" runat="server" Height="15px" Style="font-size: small; font-style: normal">Date created:</asp:Label>
                                <asp:Label ID="Label4" runat="server" Height="15px" Style="font-size: small" Text='<%# Bind("pub_date") %>'></asp:Label></td>
                            <td style="width: 153px; height: 21px;">
                                </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ControlStyle BackColor="White" />
            </asp:TemplateField>
            <asp:CommandField ButtonType="Image" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" CssClass="HeaderStyle" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
        <EmptyDataTemplate>
            No test/s found.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
        SelectCommand="SELECT * FROM [exams] WHERE (([user_id] = @user_id) AND ([exname] LIKE '%' + @exname + '%')) ORDER BY [pub_date] DESC" ProviderName="<%$ ConnectionStrings:CIT examsConnectionString22.ProviderName %>">
        <SelectParameters>
            <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
            <asp:SessionParameter Name="exname" SessionField="term" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Label3" runat="server" Height="15px" Style="font-size: small; font-style: italic"
        Text='<%# Bind("frameA") %>'></asp:Label>
</asp:Content>

