<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdHome.aspx.cs" Inherits="Images_AdUsers" Title="CIT Examination System | Maintenance | Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
        SelectCommand="SELECT * FROM [dbLog] WHERE ([log_date] LIKE '%' + @log_date + '%') ORDER BY [log_date] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="log_date" SessionField="Act" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Names="Calibri"
        Style="left: 248px; position: absolute; top: 124px; z-index: 100;" Width="90px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
        <asp:ListItem Selected="True">FACULTY</asp:ListItem>
        <asp:ListItem>ADMIN</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 169px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 689px; z-index: 101;" Width="336px" Visible="False">
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
    &nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="left: 264px;
        position: absolute; top: 326px; z-index: 102;" Text="Show" />
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 143px; position: absolute; top: 619px; background-color: transparent; z-index: 103;"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 344px; position: absolute; top: 641px; z-index: 104;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        left: 291px; position: absolute; top: 653px; z-index: 105;" Text="."></asp:Label>
    &nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="471px"
        ImageUrl="~/Images/tabla8.png" OnClick="ImageButton1_Click" Style="z-index: 106;
        left: 372px; position: absolute; top: 126px; background-color: transparent" Width="584px" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="1" DataKeyNames="log_id" DataSourceID="SqlDataSource1" ForeColor="#333333"
        GridLines="None" HorizontalAlign="Left" OnRowUpdated="GridView1_RowUpdated"
        Style="font-size: medium; left: 397px; font-family: Calibri; position: absolute;
        top: 142px; z-index: 118;" PageSize="13">
        <Columns>
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
                    Activities
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 526px">
                        <tr>
                            <td style="height: 20px" colspan="3">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                    Text='<%# Eval("log_user") %>'></asp:Label>
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small"
                                    Text='<%# Eval("log_desc") %>'></asp:Label>
                                <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Italic="True" Font-Names="Calibri"
                                    Font-Size="Small" Style="z-index: 100; left: 60px; top: 0px" Text='(at'></asp:Label>
                                <asp:Label ID="Label13" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Small"
                                    Text='<%# Eval("log_date") %>' style="left: 103px; top: 0px" Font-Italic="True"></asp:Label>
                                <asp:Label ID="Label21" runat="server" Font-Bold="False" Font-Italic="True" Font-Names="Calibri"
                                    Font-Size="Small" Text=")"></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" CssClass="HeaderStyle" Font-Size="Small" />
        <EmptyDataTemplate>
            <span style="color: silver; font-family: Segoe UI">No records found.<br />
            </span>
            &nbsp;<br />
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
            HorizontalAlign="Center" CssClass="HeaderStyle" ForeColor="White" BorderColor="Black" />
        <AlternatingRowStyle BackColor="White" />
        <RowStyle BackColor="WhiteSmoke" />
        <EditRowStyle BackColor="#7C6F57" />
        <EmptyDataRowStyle ForeColor="White" />
    </asp:GridView><asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="2" DataSourceID="SqlDataSource3" ForeColor="#333333"
        GridLines="None" HorizontalAlign="Left" OnRowUpdated="GridView1_RowUpdated"
        Style="font-size: medium; left: 398px; font-family: Calibri; position: absolute;
        top: 182px; z-index: 120;" Width="525px" AllowSorting="True" AutoGenerateDeleteButton="True" DataKeyNames="exname" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="Preview">
                <ItemStyle Width="50px" />
            </asp:CommandField>
            <asp:BoundField DataField="pname" HeaderText="Tests" SortExpression="pname" >
                <ItemStyle Width="400px" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" CssClass="HeaderStyle" Font-Size="Small" />
        <EmptyDataTemplate>
            <span style="color: white">No tests found.<br />
            </span>
            &nbsp;<br />
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
            HorizontalAlign="Center" CssClass="HeaderStyle" ForeColor="White" BorderColor="Black" />
        <AlternatingRowStyle BackColor="White" />
        <RowStyle BackColor="WhiteSmoke" />
        <EditRowStyle BackColor="#7C6F57" />
        <EmptyDataRowStyle ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
        SelectCommand="SELECT [pname], [exname] FROM [exams] WHERE ([user_id] = @user_id) ORDER BY [pub_date] DESC" DeleteCommand="DELETE FROM [exams] WHERE [exname] = @exname" InsertCommand="INSERT INTO [exams] ([pname], [exname]) VALUES (@pname, @exname)" UpdateCommand="UPDATE [exams] SET [pname] = @pname WHERE [exname] = @exname">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList4" Name="user_id" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="exname" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="pname" Type="String" />
            <asp:Parameter Name="exname" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="pname" Type="String" />
            <asp:Parameter Name="exname" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="128px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 107; left: 47px; position: absolute;
        top: 123px; background-color: transparent" Width="304px" /><asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="217px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 108; left: 48px; position: absolute;
        top: 258px; background-color: transparent" Width="302px" />
    <asp:TextBox ID="TextBox4" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="z-index: 109;
        left: 149px; position: absolute; top: 222px" Text='<%# Bind("user_na") %>' ToolTip="Clear to view all"
        ValidationGroup="ins" Visible="False" Width="155px"></asp:TextBox>
    &nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="White"
        Style="z-index: 110; left: 67px; position: absolute; top: 172px"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        z-index: 111; left: 64px; position: absolute; top: 136px">Welcome</asp:Label>
    <asp:Label ID="Label24" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        z-index: 112; left: 423px; position: absolute; top: 146px">Select Faculty member</asp:Label>
    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        z-index: 113; left: 106px; position: absolute; top: 229px" Visible="False">Show activities of this user</asp:Label>
    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" ForeColor="LimeGreen" Style="font-size: medium;
        z-index: 114; left: 59px; position: absolute; top: 240px" Visible="False">Activities</asp:Label>
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Calibri" Font-Size="Small"
        ForeColor="Silver" Style="z-index: 115; left: 67px; position: absolute; top: 205px" OnClick="LinkButton1_Click">[Edit]</asp:LinkButton>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999"
        CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
        ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged" Style="z-index: 116; left: 98px; position: absolute;
        top: 275px" Width="200px" OnLoad="Calendar1_Load">
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <WeekendDayStyle BackColor="#FFFFCC" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <OtherMonthDayStyle ForeColor="Gray" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
    </asp:Calendar>
    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource2"
        DataTextField="prog" DataValueField="user_id" Style="z-index: 117; left: 597px;
        position: absolute; top: 144px" Width="311px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
        SelectCommand="SELECT DISTINCT [prog], [user_id] FROM [user_table] WHERE ([type] = @type) ORDER BY [prog]">
        <SelectParameters>
            <asp:Parameter DefaultValue="Faculty" Name="type" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

