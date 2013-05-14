<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsFacultyInfo.aspx.cs" Inherits="Home" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
        SelectCommand="SELECT * FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([term] = @term))" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            <asp:SessionParameter Name="term" SessionField="term" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Larger" Style="left: 173px;
        color: limegreen; position: absolute; top: 39px; z-index: 103;"></asp:Label>
    &nbsp;
    <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="128px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 105; left: 159px; position: absolute;
        top: 374px; background-color: transparent" Width="304px" Visible="False" />
    <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 106; left: 199px;
        position: absolute; top: 427px" Visible="False" />
    <asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" OnClick="ImageButton5_Click" Style="z-index: 107;
        left: 250px; position: absolute; top: 461px" Width="119px" Visible="False" />
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
        left: 281px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 467px"
        Text="Update" Width="33px" Visible="False"></asp:Label>
    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000"
        Style="z-index: 110; left: 182px; position: absolute; top: 397px" Visible="False">Update classes</asp:Label>
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="470px"
        ImageUrl="~/Images/tabla7.png" Style="z-index: 111; left: 299px; position: absolute;
        top: 173px; background-color: transparent" Width="393px" />
    <asp:GridView ID="GridView11" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="ControlLightLight" BorderColor="ActiveCaptionText" BorderWidth="0px"
        CellPadding="0" DataKeyNames="handler_id" DataSourceID="SqlDataSource1" ForeColor="Black"
        GridLines="None" Height="48px" HorizontalAlign="Left" OnRowDeleted="GridView1_RowDeleted"
        OnRowUpdated="GridView1_RowUpdated" Style="font-size: medium; left: 315px; font-family: Calibri;
        position: absolute; top: 186px; z-index: 112;" Width="253px" PageSize="7" OnRowDeleting="GridView1_RowDeleting">
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
    &nbsp; &nbsp;&nbsp;
</asp:Content>

