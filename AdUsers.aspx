<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdUsers.aspx.cs" Inherits="Images_AdUsers" Title="CIT Examination System | Maintenance | Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        ForeColor="Black" Height="19px" Style="font-weight: normal; font-size: medium;
        left: 135px; font-style: italic; font-family: Calibri; position: absolute;
        top: 125px; z-index: 100;" Text="Select user type" Width="130px" Font-Size="Medium" Visible="False"></asp:Label>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
        DeleteCommand="DELETE FROM [user_table] WHERE [user_id] = @user_id" InsertCommand="INSERT INTO [user_table] ([user_id], [user_na], [pass], [type], [bname], [lname], [fname], [emailadd], [gender], [prog]) VALUES (@user_id, @user_na, @pass, @type, @bname, @lname, @fname, @emailadd, @gender, @prog)"
        SelectCommand="SELECT * FROM [user_table] WHERE ([type] = @type) ORDER BY [lname], [fname]"
        UpdateCommand="UPDATE [user_table] SET [user_na] = @user_na, [pass] = @pass, [bname] = @bname, [lname] = @lname, [fname] = @fname  WHERE [user_id] = @user_id">
        <DeleteParameters>
            <asp:Parameter Name="user_id" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="user_na" Type="String" />
            <asp:Parameter Name="pass" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="bname" Type="String" />
            <asp:Parameter Name="lname" Type="String" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="emailadd" Type="String" />
            <asp:Parameter Name="gender" Type="String" />
            <asp:Parameter Name="prog" Type="String" />
            <asp:Parameter Name="user_id" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="user_id" Type="String" />
            <asp:Parameter Name="user_na" Type="String" />
            <asp:Parameter Name="pass" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="bname" Type="String" />
            <asp:Parameter Name="lname" Type="String" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="emailadd" Type="String" />
            <asp:Parameter Name="gender" Type="String" />
            <asp:Parameter Name="prog" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="Faculty" Name="type" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Names="Calibri"
        Style="left: 248px; position: absolute; top: 124px; z-index: 101;" Width="90px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
        <asp:ListItem Selected="True">FACULTY</asp:ListItem>
        <asp:ListItem>ADMIN</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 169px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 689px; z-index: 102;" Width="336px" Visible="False">
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px" style="left: -104px; position: absolute; top: 5px; z-index: 100;" ForeColor="Red" Visible="False"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox9"
                                    ErrorMessage="*" ValidationGroup="ins" style="left: 84px; position: absolute; top: 72px; z-index: 103;" Height="8px" Width="6px"></asp:RequiredFieldValidator>
        <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: -105px; color: limegreen;
            position: absolute; top: 44px; z-index: 104;" Text="Add new user"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2"
                                    ErrorMessage="*" ValidationGroup="ins" style="left: 390px; position: absolute; top: 98px; z-index: 105;">*</asp:RequiredFieldValidator>
        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: -104px; position: absolute; top: 70px; z-index: 106;" Text="ID:"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Style="left: -79px;
                                    position: absolute; top: 71px; z-index: 107;" Text='<%# Bind("user_na") %>' ValidationGroup="ins"
                                    Width="155px"></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="Name:" style="left: -105px; position: absolute; top: 95px; z-index: 108;"></asp:Label>
                                <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Height="9px" Text="Email:" style="left: -106px; position: absolute; top: 172px; z-index: 109;"></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Text='<%# Bind("emailadd") %>'
                                    Width="155px" style="left: -58px; position: absolute; top: 173px; z-index: 110;"></asp:TextBox>
                                <asp:TextBox ID="TextBox6" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Text='<%# Bind("lname") %>'
                                    ValidationGroup="ins" Width="155px" style="left: -58px; position: absolute; top: 96px; z-index: 111;" ToolTip="Last name"></asp:TextBox><asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" Font-Names="Calibri"
        Style="left: 233px; position: absolute; top: 49px; z-index: 112;" Width="90px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="STUDENT">STUDENT</asp:ListItem>
                                        <asp:ListItem>FACULTY</asp:ListItem>
                                        <asp:ListItem>ADMIN</asp:ListItem>
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6"
                                    ErrorMessage="*" ValidationGroup="ins" style="left: 102px; position: absolute; top: 97px; z-index: 113;">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="TextBox7" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Text='<%# Bind("fname") %>'
                                    ValidationGroup="ins" Width="155px" style="left: -58px; position: absolute; top: 120px; z-index: 114;" ToolTip="First name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7"
                                    ErrorMessage="*" ValidationGroup="ins" style="left: 102px; position: absolute; top: 121px; z-index: 115;">*</asp:RequiredFieldValidator>
                    <asp:Button ID="Button1" runat="server" OnClick="ins" Text="Add" ToolTip="ins" ValidationGroup="ins"
                        Width="94px" style="left: 92px; position: absolute; top: 195px; z-index: 116;" />
                                <asp:TextBox ID="TextBox8" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Text='<%# Bind("bname") %>'
                                    Width="155px" style="left: -58px; position: absolute; top: 144px; z-index: 117;" ToolTip="Middle name"></asp:TextBox>
                                <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="Username:" style="left: 157px; position: absolute; top: 73px; z-index: 118;"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Text='<%# Bind("user_na") %>'
                                    ValidationGroup="ins" Width="155px" style="left: 231px; position: absolute; top: 74px; z-index: 119;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="*" ValidationGroup="ins" style="left: 389px; position: absolute; top: 75px; z-index: 120;">*</asp:RequiredFieldValidator>
                                <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="Password:" style="left: 157px; position: absolute; top: 98px; z-index: 121;"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" Text='<%# Bind("pass") %>'
                                    ValidationGroup="ins" Width="155px" style="left: 232px; position: absolute; top: 98px; z-index: 122;"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: 159px; position: absolute; top: 140px; z-index: 123;" Text="Gender:"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: 160px; position: absolute; top: 48px; z-index: 124;" Text="Type:"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Calibri" Style="left: 231px;
                                    position: absolute; top: 137px; z-index: 125;" Width="63px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
                                    Text="Program:" style="left: 158px; position: absolute; top: 168px; z-index: 126;"></asp:Label><asp:DropDownList ID="DropDownList3" runat="server"
                                        Font-Names="Calibri" Style="left: 232px; position: absolute; top: 166px; z-index: 127;" Width="64px">
                                        <asp:ListItem Selected="True" Value="BSIT">BSIT</asp:ListItem>
                                        <asp:ListItem>BSCS</asp:ListItem>
                                        <asp:ListItem>ST</asp:ListItem>
                                        <asp:ListItem>MMA</asp:ListItem>
                                        <asp:ListItem>DAD</asp:ListItem>
                                        <asp:ListItem>BSECE</asp:ListItem>
                                        <asp:ListItem>BSCE</asp:ListItem>
                                        <asp:ListItem>BSCHE</asp:ListItem>
                                        <asp:ListItem>BSIE</asp:ListItem>
                                        <asp:ListItem>BSCOE</asp:ListItem>
                                        <asp:ListItem>BSEE</asp:ListItem>
                                        <asp:ListItem>BSM</asp:ListItem>
                                        <asp:ListItem>BSA</asp:ListItem>
                                        <asp:ListItem>HRM</asp:ListItem>
                                        <asp:ListItem>BST</asp:ListItem>
                                        <asp:ListItem>BSMARE</asp:ListItem>
                                        <asp:ListItem>BSME</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                    </asp:DropDownList>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox9"
            ErrorMessage="ID number error." MaximumValue="2100000000" MinimumValue="200700000"
            SetFocusOnError="True" Style="left: -104px; position: absolute; top: 28px; z-index: 128;" ValidationGroup="ins"></asp:RangeValidator>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="left: 136px;
        position: absolute; top: 94px; z-index: 103;" Text="Add New User..." />
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 143px; position: absolute; top: 619px; background-color: transparent; z-index: 104;"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 344px; position: absolute; top: 641px; z-index: 105;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        left: 291px; position: absolute; top: 653px; z-index: 106;" Text="."></asp:Label>
    &nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="471px"
        ImageUrl="~/Images/tabla8.png" OnClick="ImageButton1_Click" Style="z-index: 107;
        left: 130px; position: absolute; top: 126px; background-color: transparent" Width="748px" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="1" DataKeyNames="user_id" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" Height="48px" HorizontalAlign="Left" OnRowUpdated="GridView1_RowUpdated"
        Style="font-size: medium; left: 159px; font-family: Calibri; position: absolute;
        top: 150px; z-index: 109;" PageSize="7" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField DeleteText="Del" InsertText="Add" ShowDeleteButton="True" ShowEditButton="True"
                UpdateText="OK" />
            <asp:TemplateField HeaderText="user_id" SortExpression="user_id">
                <EditItemTemplate>
                    <table style="width: 610px">
                        <tr>
                            <td colspan="2" style="width: 73px; height: 20px">
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="ID:"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
                                    Text='<%# Bind("user_id") %>'></asp:Label></td>
                            <td style="width: 58px; height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 26px">
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Name:"></asp:Label>
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:TextBox ID="TextBox6" runat="server" BorderStyle="None" Font-Size="Small" ForeColor="ActiveCaptionText"
                                    Text='<%# Bind("lname") %>' BackColor="LightGray"></asp:TextBox>
                                <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Black" Text=","></asp:Label>
                                <asp:TextBox ID="TextBox7" runat="server" BorderStyle="None" Font-Size="Small" ForeColor="ActiveCaptionText"
                                    Text='<%# Bind("fname") %>' BackColor="LightGray"></asp:TextBox>
                                <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Black" Text="("></asp:Label>
                                <asp:TextBox ID="TextBox8" runat="server" BorderStyle="None" Font-Size="Small" ForeColor="ActiveCaptionText"
                                    Text='<%# Bind("bname") %>' Width="103px" BackColor="LightGray"></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Black" Text=")"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 73px; height: 20px">
                                <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Username:"></asp:Label>&nbsp;
                                <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" Font-Size="Small" Text='<%# Bind("user_na") %>' BackColor="LightGray" ForeColor="ActiveCaptionText"></asp:TextBox></td>
                            <td colspan="1" style="height: 20px; width: 58px;">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="width: 73px; height: 20px">
                                <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Password:"></asp:Label>
                                &nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" Font-Size="Small" Text='<%# Bind("pass") %>' BackColor="LightGray" ForeColor="ActiveCaptionText"></asp:TextBox></td>
                            <td colspan="1" style="height: 20px; width: 58px;">
                                &nbsp;</td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <HeaderTemplate>
                    Faculty list
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 620px">
                        <tr>
                            <td style="width: 146px; height: 20px">
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="ID:"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium"
                                    Text='<%# Bind("user_id") %>'></asp:Label></td>
                            <td colspan="2" style="height: 20px">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 21px">
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Name:"></asp:Label><asp:Label ID="Label5" runat="server" Font-Names="Calibri"
                                        Font-Size="Medium" ForeColor="#00C000" Text='<%# Bind("lname") %>'></asp:Label><asp:Label
                                            ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#00C000" Text=","></asp:Label><asp:Label ID="Label8" runat="server" Font-Names="Calibri"
                                                Font-Size="Medium" ForeColor="#00C000" Text='<%# Bind("fname") %>'></asp:Label><asp:Label
                                                    ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000" Text="("></asp:Label><asp:Label ID="Label10" runat="server" Font-Names="Calibri"
                                                        Font-Size="Medium" ForeColor="#00C000" Text='<%# Bind("bname") %>'></asp:Label><asp:Label
                                                            ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000" Text=")"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Red"
                Height="9px" Text="No records yet."></asp:Label><br />
            &nbsp;<br />
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
            HorizontalAlign="Center" CssClass="HeaderStyle" ForeColor="White" BorderColor="Black" />
        <AlternatingRowStyle BackColor="White" />
        <RowStyle BackColor="#E3EAEB" />
        <EditRowStyle BackColor="#7C6F57" />
    </asp:GridView>
</asp:Content>

