<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdExams.aspx.cs" Inherits="Images_AdUsers" Title="CIT Examination System | Maintenance | Tests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        ForeColor="Black" Height="19px" Style="font-weight: normal;
        left: 137px; font-style: italic; font-family: Calibri; position: absolute;
        top: 114px; z-index: 100;" Text="Select user type" Width="113px" Font-Size="Medium" Visible="False"></asp:Label>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
        SelectCommand="SELECT [exname], [pub_date], [pname], [user_id] FROM [exams] WHERE (([pname] LIKE '%' + @pname + '%') AND ([exname] LIKE '%' + @exname + '%')) ORDER BY [pub_date] DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" DefaultValue=" " Name="pname" PropertyName="Text"
                Type="String" />
            <asp:SessionParameter Name="exname" SessionField="term" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Names="Calibri"
        Style="left: 258px; position: absolute; top: 115px; z-index: 101;" Width="90px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
        <asp:ListItem>SEAT</asp:ListItem>
        <asp:ListItem>QUIZ</asp:ListItem>
        <asp:ListItem>EXAM</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 144px; position: absolute; top: 616px; background-color: transparent; z-index: 102;"
        Width="726px" />
    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 345px; position: absolute; top: 638px; z-index: 103;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        left: 310px; position: absolute; top: 650px; z-index: 104;" Text="."></asp:Label>
    &nbsp; &nbsp;
    <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="128px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 105; left: 10px; position: absolute;
        top: 265px; background-color: transparent" Width="304px" /><asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="128px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 106; left: 11px; position: absolute;
        top: 126px; background-color: transparent" Width="304px" />
    <asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Calibri" ForeColor="Control"
        Height="11px" PostBackUrl="~/AdQuesMultipleChoice.aspx" Style="z-index: 107;
        left: 43px; position: absolute; top: 278px" Width="212px">Show Multiple Choice Questions</asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Calibri" ForeColor="Control"
        Height="11px" Style="z-index: 108; left: 43px; position: absolute; top: 304px"
        Width="195px" PostBackUrl="~/AdQuesToF.aspx">Show True or False Questions</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Calibri" ForeColor="Control"
        Height="11px" Style="z-index: 109; left: 43px; position: absolute; top: 330px"
        Width="198px" PostBackUrl="~/AdQuesIden.aspx" OnClick="LinkButton2_Click">Show Identification Questions</asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Calibri" ForeColor="Control"
        Height="11px" PostBackUrl="~/AdLO.aspx" Style="z-index: 116; left: 43px; position: absolute;
        top: 356px" Width="87px">Show Topics</asp:LinkButton>
    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 111; left: 37px; position: absolute;
        top: 182px" Width="177px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Style="z-index: 112;
        left: 223px; position: absolute; top: 181px" Text="Search" />
    <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"
        Style="z-index: 113; left: 38px; position: absolute; top: 146px" Text="Search Test"></asp:Label>
    <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="471px"
        ImageUrl="~/Images/tabla8.png" OnClick="ImageButton1_Click" Style="z-index: 114;
        left: 330px; position: absolute; top: 131px; background-color: transparent" Width="584px" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="ControlLightLight" BorderColor="ActiveCaptionText" BorderWidth="0px"
        CellPadding="0" DataKeyNames="exname" DataSourceID="SqlDataSource1" ForeColor="Black"
        GridLines="None" HorizontalAlign="Left" OnRowUpdated="GridView1_RowUpdated"
        Style="font-size: medium; left: 339px; font-family: Calibri; position: absolute;
        top: 140px; z-index: 115;" Width="1px" OnRowDeleted="GridView1_RowDeleted" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="9">
        <Columns>
            <asp:CommandField SelectText="Delete" ShowSelectButton="True" />
            <asp:TemplateField HeaderText="user_id" SortExpression="user_id">
                <EditItemTemplate>
                    &nbsp;
                </EditItemTemplate>
                <HeaderTemplate>
                    Test list
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 521px">
                        <tr>
                            <td colspan="2" style="height: 20px; width: 592px;">
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small"
                                    Text="Exam name:"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Font-Names="Calibri"
                                        Font-Size="Small" ForeColor="#00C000" Text='<%# Eval("pname") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 592px">
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small"
                                    Text="Created by:"></asp:Label>&nbsp;
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                    Text='<%# Bind("user_id") %>'></asp:Label>
                                <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small"
                                    Text="Publish date:" Font-Italic="True" style="text-align: right"></asp:Label>
                                <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" Text='<%# Eval("pub_date") %>' Font-Italic="True" style="text-align: right"></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="ControlDarkDark" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            No records found
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="SlateGray" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium"
            HorizontalAlign="Center" CssClass="HeaderStyle" ForeColor="White" />
        <AlternatingRowStyle BackColor="Control" />
        <EmptyDataRowStyle BackColor="Transparent" BorderColor="Transparent" />
    </asp:GridView>
</asp:Content>

