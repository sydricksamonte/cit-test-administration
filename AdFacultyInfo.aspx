<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdFacultyInfo.aspx.cs" Inherits="Home" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
        SelectCommand="SELECT * FROM [course] WHERE ([sec_handler] = @sec_handler) AND  ([term] = @term)" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:SessionParameter Name="sec_handler" SessionField="fac" Type="String" />
            <asp:SessionParameter Name="term" SessionField="term" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp; &nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 134px; position: absolute; top: 625px; background-color: transparent; z-index: 100;"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 335px; position: absolute; top: 647px; z-index: 101;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    &nbsp;
    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        left: 282px; position: absolute; top: 659px; z-index: 102;" Text="."></asp:Label>
    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Larger" Style="left: 173px;
        color: limegreen; position: absolute; top: 39px; z-index: 103;"></asp:Label>
    <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="128px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 104; left: 121px; position: absolute;
        top: 102px; background-color: transparent" Width="304px" />
    <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="128px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 105; left: 122px; position: absolute;
        top: 235px; background-color: transparent" Width="304px" />
    <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 106; left: 156px;
        position: absolute; top: 280px" />
    <asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" OnClick="ImageButton5_Click" Style="z-index: 107;
        left: 207px; position: absolute; top: 314px" Width="119px" />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
        OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT fname, lname, bname, user_id FROM user_table WHERE (type = @type)">
        <SelectParameters>
            <asp:Parameter DefaultValue="Faculty" Name="type" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        Height="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="25"
        Style="font-size: small; z-index: 115; left: -634px; font-family: Calibri; position: absolute;
        top: 265px" Width="642px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle"
            Wrap="True" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" CssClass="HeaderStyle" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:Label ID="Label11" runat="server" AssociatedControlID="ImageButton5" BorderStyle="None"
        Enabled="False" ForeColor="White" Height="9px" Style="font-size: small; z-index: 109;
        left: 238px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 320px"
        Text="Update" Width="33px"></asp:Label>
    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000"
        Style="z-index: 110; left: 139px; position: absolute; top: 250px">Update classes</asp:Label>
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="421px"
        ImageUrl="~/Images/tabla7.png" Style="z-index: 111; left: 448px; position: absolute;
        top: 104px; background-color: transparent" Width="392px" />
    <asp:GridView ID="GridView11" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="ControlLightLight" BorderColor="ActiveCaptionText" BorderWidth="0px"
        CellPadding="0" DataKeyNames="handler_id" DataSourceID="SqlDataSource1" ForeColor="Black"
        GridLines="None" Height="48px" HorizontalAlign="Left" OnRowDeleted="GridView1_RowDeleted"
        OnRowUpdated="GridView1_RowUpdated" Style="font-size: medium; left: 463px; font-family: Calibri;
        position: absolute; top: 111px; z-index: 112;" Width="253px" PageSize="7" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="user_id" SortExpression="user_id">
                <EditItemTemplate>
                    <table style="width: 866px">
                        <tr>
                            <td colspan="1" style="width: 140px; height: 20px">
                                <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="ID:"></asp:Label><asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Calibri"
                                        Font-Size="Medium" Text='<%# Eval("sec_handler") %>'></asp:Label></td>
                            <td colspan="1" style="width: 370px; height: 20px">
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" style="width: 140px">
                                <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="Course:"></asp:Label>
                                <asp:TextBox ID="TextBox10" runat="server" BorderStyle="None" Font-Size="Small" MaxLength="8"
                                    Text='<%# Bind("course_id") %>' Width="85px"></asp:TextBox></td>
                            <td colspan="1" style="width: 370px">
                                <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="Section:"></asp:Label>
                                <asp:TextBox ID="TextBox11" runat="server" BorderStyle="None" Font-Size="Small" MaxLength="3"
                                    Text='<%# Bind("course_sec") %>' Width="105px"></asp:TextBox></td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <HeaderTemplate>
                    Faculty Classes&nbsp;
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 359px; height: 36px;">
                        <tr>
                            <td colspan="2" style="width: 728px; height: 20px">
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="Course: "></asp:Label><asp:Label
                                    ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
                                    Text='<%# Eval("course_id") %>'></asp:Label>&nbsp;
                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Calibri"
                                    Font-Size="Medium" Text="("></asp:Label>
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Calibri"
                                    Font-Size="Medium" Text='<%# Eval("course_desc") %>'></asp:Label>
                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Calibri"
                                    Font-Size="Medium" Text=")"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 728px; height: 21px">
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="Section: "></asp:Label><asp:Label
                                    ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000"
                                    Text='<%# Eval("course_sec") %>'></asp:Label>&nbsp;</td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="ControlDarkDark" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <asp:Label ID="Label15" runat="server" BackColor="Transparent" Font-Names="Calibri"
                Font-Size="Small" ForeColor="Red" Height="9px" Text="No assigned class."></asp:Label><br />
            &nbsp;<br />
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="SlateGray" CssClass="HeaderStyle" Font-Bold="False" Font-Names="Calibri"
            Font-Size="Medium" ForeColor="White" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="Control" />
    </asp:GridView>
    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="White"
        Style="z-index: 113; left: 137px; position: absolute; top: 148px"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        z-index: 114; left: 137px; position: absolute; top: 122px">Faculty</asp:Label>
</asp:Content>

