<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdMaintenance.aspx.cs" Inherits="Home" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        Font-Size="Medium" ForeColor="Black" Height="19px" Style="font-weight: normal;
        font-size: small; left: 169px; color: black; font-style: italic; font-family: Calibri;
        position: absolute; top: 135px" Text="Select user type" Visible="False" Width="82px"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="ControlLightLight" BorderColor="ActiveCaptionText" BorderWidth="0px"
        CellPadding="0" DataKeyNames="handler_id" DataSourceID="SqlDataSource1" ForeColor="Black"
        GridLines="None" Height="48px" HorizontalAlign="Left" OnRowDeleted="GridView1_RowDeleted"
        OnRowUpdated="GridView1_RowUpdated" Style="font-size: medium; left: 42px; font-family: Calibri;
        position: absolute; top: 165px" Width="253px" PageSize="8" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:CommandField DeleteText="Del" InsertText="Add" ShowDeleteButton="True" ShowEditButton="True"
                UpdateText="OK" />
            <asp:TemplateField HeaderText="user_id" SortExpression="user_id">
                <EditItemTemplate>
                    <table style="width: 866px">
                        <tr>
                            <td colspan="1" style="width: 140px; height: 20px">
                                <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="ID:"></asp:Label><asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Calibri"
                                        Font-Size="Medium" Text='<%# Eval("sec_handler") %>'></asp:Label></td>
                            <td colspan="1" style="width: 370px; height: 20px">
                                <asp:Label ID="Label25" runat="server" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium"
                                    Height="9px" Text="Term:"></asp:Label>
                                &nbsp;
                                <asp:TextBox ID="TextBox12" runat="server" BorderStyle="None" Font-Size="Small" Text='<%# Bind("term") %>'
                                    Width="105px"></asp:TextBox></td>
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
                    Assigned Course List
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 866px; height: 36px;">
                        <tr>
                            <td colspan="1" style="width: 486px; height: 20px">
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="ID:"></asp:Label><asp:Label
                                    ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
                                    Text='<%# Eval("sec_handler") %>'></asp:Label></td>
                            <td colspan="1" style="width: 370px; height: 20px">
                                <asp:Label ID="Label18" runat="server" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Term:"></asp:Label>
                                <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Medium" Text='<%# Eval("term") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="1" style="width: 486px; height: 21px;">
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="Course:"></asp:Label><asp:Label
                                    ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000"
                                    Text='<%# Eval("course_id") %>'></asp:Label><asp:Label ID="Label9" runat="server"
                                        Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000" Text="("></asp:Label><asp:Label
                                            ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000"
                                            Text='<%# Eval("course_desc") %>'></asp:Label><asp:Label ID="Label11" runat="server"
                                                Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000" Text=")"></asp:Label></td>
                            <td colspan="1" style="width: 370px; height: 21px;">
                                <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="Section:"></asp:Label>
                                <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Medium" Text='<%# Eval("course_sec") %>'></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="ControlDarkDark" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <asp:Label ID="Label15" runat="server" BackColor="Transparent" Font-Names="Calibri"
                Font-Size="Small" ForeColor="Red" Height="9px" Text="No assigned records yet."></asp:Label><br />
            &nbsp;<br />
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="SlateGray" CssClass="HeaderStyle" Font-Bold="False" Font-Names="Calibri"
            Font-Size="Medium" ForeColor="White" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="Control" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString30 %>"
        DeleteCommand="DELETE FROM [course] WHERE [handler_id] = @handler_id" InsertCommand="INSERT INTO [course] ([handler_id], [course_id], [course_desc], [course_sec], [sec_handler], [term]) VALUES (@handler_id, @course_id, @course_desc, @course_sec, @sec_handler, @term)"
        SelectCommand="SELECT * FROM [course] ORDER BY [course_id], [term]" UpdateCommand="UPDATE [course] SET [course_id] = @course_id, [course_sec] = @course_sec, [term] = @term WHERE [handler_id] = @handler_id">
        <DeleteParameters>
            <asp:ControlParameter ControlID="GridView1" Name="handler_id" PropertyName="SelectedValue"
                Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="GridView1" Name="course_id" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="GridView1" Name="course_sec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="GridView1" Name="term" PropertyName="SelectedValue"
                Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="handler_id" Type="String" />
            <asp:Parameter Name="course_id" Type="String" />
            <asp:Parameter Name="course_desc" Type="String" />
            <asp:Parameter Name="course_sec" Type="String" />
            <asp:Parameter Name="sec_handler" Type="String" />
            <asp:Parameter Name="term" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Names="Calibri"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Style="left: 260px;
        position: absolute; top: 133px" Visible="False" Width="90px">
        <asp:ListItem>FACULTY</asp:ListItem>
        <asp:ListItem>ADMIN</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="left: 164px;
        position: absolute; top: 101px" Text="Assign a course to faculty..." Width="188px" />
    <asp:Button ID="Button1" runat="server" OnClick="Button2_Click" Style="left: 356px;
        position: absolute; top: 101px" Text="Add a new course..." Width="145px" />
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 134px; position: absolute; top: 625px; background-color: transparent"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 335px; position: absolute; top: 647px" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        left: 282px; position: absolute; top: 659px" Text="."></asp:Label>
    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Larger" Style="left: 173px;
        color: limegreen; position: absolute; top: 39px"></asp:Label>
</asp:Content>

