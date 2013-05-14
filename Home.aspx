<%@ Page Language="C#" MasterPageFile="~/active.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" Title="CIT Exam System | Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label1" runat="server" Height="19px" Text="Label" Visible="False"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0"
        DataKeyNames="stud_co_se_id" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" Style="font-size: medium; left: 205px; font-family: Calibri;
        position: absolute; top: 152px" Width="418px" OnRowCreated="GridView1_RowCreated" Height="171px" AllowPaging="True" PageSize="5" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <RowStyle BackColor="LightGray" />
        <Columns>
            <asp:TemplateField HeaderText="My Tests" SortExpression="stud_co_se_id">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("stud_co_se_id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("exam_code") %>' Visible="False"></asp:Label><table
                        style="width: 608px">
                        <tr>
                            <td rowspan="3" style="width: 72px">
                                <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="72px"
                                    Width="72px" /></td>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" Height="15px" Style="color: black" Text='<%# Bind("pname") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 326px; height: 21px">
                                <asp:Label ID="Label3" runat="server" Height="15px" Style="font-size: small; font-style: normal"
                                    Text='<%# Eval("course") %>'></asp:Label>
                                <asp:Label ID="Label5" runat="server" Height="15px" Style="font-size: small; font-style: normal"
                                    Text="-"></asp:Label>
                                <asp:Label ID="Label6" runat="server" Height="15px" Style="font-size: small; font-style: normal"
                                    Text='<%# Eval("section") %>'></asp:Label></td>
                            <td style="width: 153px; height: 21px">
                                <asp:HyperLink ID="HyperLink2" runat="server" Style="font-size: small" Visible="False">Your score:</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink3" runat="server" Style="font-size: small" Text='<%# Eval("score") %>' Visible="False"></asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td style="width: 326px; height: 26px;">
                                <asp:Label ID="Label7" runat="server" Height="15px" Style="font-size: small" Text='Status: '></asp:Label>
                                <asp:Label ID="Label4" runat="server" Height="15px" Style="font-size: small" Text='<%# Eval("d_close") %>'></asp:Label>
                                <asp:Label ID="Label9" runat="server" Height="15px" Style="font-size: small" Text='<%# Eval("d_taken") %>'></asp:Label>&nbsp;
                            </td>
                            <td style="width: 153px; height: 26px;">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Open" Width="74px" Visible="False" /></td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("exam_code") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" CssClass="HeaderStyle" BorderStyle="None" Height="5px" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate>
            &nbsp;<asp:Label ID="Label12" runat="server" Style="font-size: medium; left: 41px;
                font-family: Calibri; position: static; top: 48px" Text="No materials found. Please contact your proctor or the administrator."
                Width="220px"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SYARA\SQLEXPRESS;Initial Catalog=CIT;Integrated Security=True"
        SelectCommand="SELECT exam_results.stud_co_se_id, exam_results.user_id, exam_results.exam_code, exam_results.d_taken, exam_results.score, exam_results.pname, exam_results.section, exam_results.course, exam_results.d_close, exam_results.take_no, exam_results.t_left, exams.pub_date FROM exam_results INNER JOIN exams ON exam_results.pname = exams.pname AND exam_results.exam_code = exams.exname WHERE (exam_results.user_id = @user_id) ORDER BY exam_results.d_taken, exams.pub_date" ProviderName="System.Data.SqlClient">
        <SelectParameters>
            <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label10" runat="server" Style="font-size: medium; left: 126px; font-family: Calibri;
        position: absolute; top: 123px"></asp:Label>
    <asp:Label ID="Label11" runat="server" ForeColor="DimGray" Style="font-size: small;
        left: 127px; font-family: Calibri; position: absolute; top: 147px"></asp:Label>
</asp:Content>

