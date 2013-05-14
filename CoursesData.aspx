<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="CoursesData.aspx.cs" Inherits="Images_AdUsers" Title="CIT Examination System | Maintenance | Courses" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        ForeColor="Black" Height="19px" Style="font-weight: normal; font-size: small;
        left: 412px; color: black; font-style: italic; font-family: Calibri; position: absolute;
        top: 538px; z-index: 100;" Text="Select user type" Width="82px" Font-Size="Medium" Visible="False"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="ControlLightLight" BorderColor="ActiveCaptionText" BorderWidth="0px"
        CellPadding="0" DataKeyNames="handler_id" DataSourceID="SqlDataSource1" ForeColor="Black"
        GridLines="None" Height="48px" HorizontalAlign="Left" OnRowUpdated="GridView1_RowUpdated"
        Style="font-size: medium; left: 892px; font-family: Calibri; position: absolute;
        top: 512px; z-index: 101;" Width="253px" OnRowDeleted="GridView1_RowDeleted" Visible="False">
        <Columns>
            <asp:CommandField DeleteText="Del" InsertText="Add" ShowDeleteButton="True" ShowEditButton="True"
                UpdateText="OK" />
            <asp:TemplateField HeaderText="user_id" SortExpression="user_id">
                <EditItemTemplate><table style="width: 866px">
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
                                <asp:TextBox ID="TextBox11" runat="server" BorderStyle="None" Font-Size="Small" Text='<%# Bind("course_sec") %>'
                                    Width="105px" MaxLength="3"></asp:TextBox></td>
                    </tr>
                </table>
                </EditItemTemplate>
                <HeaderTemplate>
                    Assigned
                    Course List
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 866px; height: 36px;">
                        <tr>
                            <td colspan="1" style="width: 486px; height: 20px">
                                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="ID:"></asp:Label><asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri"
                                        Font-Size="Medium" Text='<%# Eval("sec_handler") %>'></asp:Label></td>
                            <td colspan="1" style="width: 370px; height: 20px">
                                <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Term:" Font-Italic="True"></asp:Label>
                                <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Medium" Text='<%# Eval("term") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="1" style="width: 486px; height: 21px;">
                                <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Course:"></asp:Label><asp:Label ID="Label5" runat="server" Font-Names="Calibri"
                                        Font-Size="Medium" ForeColor="#00C000" Text='<%# Eval("course_id") %>'></asp:Label><asp:Label
                                                    ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000" Text="("></asp:Label><asp:Label ID="Label10" runat="server" Font-Names="Calibri"
                                                        Font-Size="Medium" ForeColor="#00C000" Text='<%# Eval("course_desc") %>'></asp:Label><asp:Label
                                                            ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#00C000" Text=")"></asp:Label></td>
                            <td colspan="1" style="width: 370px; height: 21px;">
                                <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Medium"
                                    Text="Section:"></asp:Label>
                                <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Medium" Text='<%# Eval("course_sec") %>'></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <PagerStyle BackColor="ControlDarkDark" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Red"
                Height="9px" Text="No assigned records yet." BackColor="Transparent"></asp:Label><br />
            &nbsp;<br />
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="SlateGray" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium"
            HorizontalAlign="Center" CssClass="HeaderStyle" ForeColor="White" />
        <AlternatingRowStyle BackColor="Control" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString30 %>"
        DeleteCommand="DELETE FROM [course] WHERE [handler_id] = @handler_id" InsertCommand="INSERT INTO [course] ([handler_id], [course_id], [course_desc], [course_sec], [sec_handler], [term]) VALUES (@handler_id, @course_id, @course_desc, @course_sec, @sec_handler, @term)"
        SelectCommand="SELECT * FROM [course] ORDER BY [course_id], [term]"
        UpdateCommand="UPDATE [course] SET [course_id] = @course_id, [course_sec] = @course_sec, [term] = @term WHERE [handler_id] = @handler_id">
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
        Style="left: 503px; position: absolute; top: 536px; z-index: 102;" Width="90px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
        <asp:ListItem>FACULTY</asp:ListItem>
        <asp:ListItem>ADMIN</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 417px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 386px; z-index: 103;" Width="336px" Visible="False">
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Small" Height="9px" style="left: -83px; position: absolute; top: 15px" ForeColor="Red" Visible="False"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="153px"
            ImageUrl="~/Images/tabla4.png" Style="left: 199px; position: absolute; top: 46px;
            background-color: transparent" Width="452px" OnClick="ImageButton1_Click" />
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox9"
            ErrorMessage="*" Style="left: 270px; position: absolute; top: 101px" ValidationGroup="ins">*</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2"
            ErrorMessage="*" Style="left: 265px; position: absolute; top: 39px" ValidationGroup="ins">*</asp:RequiredFieldValidator>
        <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: -37px; position: absolute; top: 97px" Text="Assign this section:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox9"
                                    ErrorMessage="*" ValidationGroup="ins" style="left: 184px; position: absolute; top: 38px" Height="8px" Width="6px"></asp:RequiredFieldValidator>
        <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: -78px; color: limegreen;
            position: absolute; top: 31px" Text="Assign course"></asp:Label>
        <asp:Label ID="Label35" runat="server" Font-Size="Small" Style="left: 169px; color: limegreen;
            position: absolute; top: 133px" Text="Course assigned" Visible="False"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: 64px; position: absolute; top: 36px" Text="ID:"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" BackColor="Gainsboro" BorderStyle="None"
                                    Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 90px;
                                    position: absolute; top: 99px" Text='<%# Bind("user_na") %>' ValidationGroup="ins"
                                    Width="167px" MaxLength="3"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="Small" Height="9px"
            Style="left: 90px; position: absolute; top: 58px"></asp:Label>
        <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="Small" Height="12px"
            Style="left: -226px; position: absolute; top: -199px" Width="55px"></asp:Label>
        <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: -34px; position: absolute; top: 74px" Text="Assign this course:"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" Font-Names="Calibri"
        Style="left: 90px; position: absolute; top: 35px" Width="170px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="user_id" DataValueField="user_id" Visible="False">
                                    </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CITConnectionString6 %>"
            SelectCommand="SELECT * FROM [user_table]">
        </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="ins" Text="Assign" ToolTip="ins" ValidationGroup="ins"
                        Width="94px" style="left: 66px; position: absolute; top: 127px" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString32 %>"
            SelectCommand="SELECT [course_id] FROM [course_data]"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString36 %>"
        DeleteCommand="DELETE FROM [course_data] WHERE [course_id] = @course_id&#13;&#10;" InsertCommand="INSERT INTO [course_data] ([course_id], [course_desc]) VALUES (@course_id, @course_desc)"
        SelectCommand="SELECT * FROM [course_data] ORDER BY [course_desc]" UpdateCommand="UPDATE [course_data] SET [course_desc] = @course_desc WHERE [course_id] = @course_id">
        <DeleteParameters>
            <asp:ControlParameter ControlID="GridView2" Name="course_id" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="GridView2" Name="newparameter" PropertyName="SelectedValue" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="GridView2" Name="course_desc" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="GridView2" Name="course_id" PropertyName="SelectedValue"
                Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="course_id" Type="String" />
            <asp:Parameter Name="course_desc" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="104px"
        ImageUrl="~/Images/tabla4.png" Style="z-index: 104; left: 172px; position: absolute;
        top: 99px; background-color: transparent" Width="253px" Visible="False" />
        <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Calibri" Style="left: 506px;
                                    position: absolute; top: 427px; z-index: 105;" Width="170px" DataSourceID="SqlDataSource5" DataTextField="course_desc" DataValueField="course_id" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnDataBound="DropDownList2_DataBound" Visible="False">
                                    <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:CITConnectionString5 %>"
        SelectCommand="SELECT * FROM [course_data]"></asp:SqlDataSource>
    <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 106; left: 204px;
        position: absolute; top: 139px" Width="195px" Visible="False" />
    <asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" OnClick="ImageButton5_Click" Style="z-index: 107;
        left: 305px; position: absolute; top: 160px" Width="119px" Visible="False" />
    <asp:Label ID="Label36" runat="server" AssociatedControlID="ImageButton5" BorderStyle="None"
        Enabled="False" ForeColor="White" Height="9px" Style="font-size: small; z-index: 108;
        left: 339px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 167px"
        Text="Update" Width="33px" Visible="False"></asp:Label>
   
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="390px"
            ImageUrl="~/Images/tabla8.png" Style="left: 175px; position: absolute; top: 209px;
            background-color: transparent; z-index: 109;" Width="732px" />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="0" DataKeyNames="course_id" DataSourceID="SqlDataSource4" ForeColor="#333333"
        GridLines="None" Style="font-size: small; left: 201px; font-family: Calibri;
        position: absolute; top: 277px; z-index: 110;" Width="351px" OnRowDeleted="GridView2_RowDeleted" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="Courses" SortExpression="course_id">
                <EditItemTemplate>
                    <table style="width: 613px">
                        <tr>
                            <td style="width: 185px; height: 21px">
                                &nbsp;<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("course_id") %>' Width="166px"></asp:TextBox></td>
                            <td colspan="2" style="width: 420px; height: 21px">
                                &nbsp;<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("course_desc") %>'
                                    Width="387px"></asp:TextBox></td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <ItemTemplate>
                    <table style="width: 613px">
                        <tr>
                            <td style="width: 185px; height: 21px">
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("course_id") %>'></asp:Label></td>
                            <td colspan="2" style="height: 21px">
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("course_desc") %>'></asp:Label></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="DarkGray" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="Gray" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            No courses yet.
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" CssClass="HeaderStyle" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    &nbsp;
    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="Red"
        Height="9px" Style="left: -104px; position: absolute; top: 5px; z-index: 111;" Visible="False"></asp:Label>
    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Larger" Style="left: 208px;
        color: limegreen; position: absolute; top: 217px; z-index: 112;" Text="Courses:"></asp:Label>
    <asp:Label ID="Label37" runat="server" Font-Names="Calibri" Font-Size="Larger" Style="z-index: 113;
        left: 186px; color: limegreen; position: absolute; top: 101px" Text="Update Courses" Visible="False"></asp:Label>
    <asp:Label ID="Label32" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="Red"
        Height="9px" Style="left: -104px; position: absolute; top: 0px; z-index: 114;" Visible="False"></asp:Label>
    <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"
        Height="9px" Style="left: 325px; position: absolute; top: 219px; z-index: 115;" Text="Course Code:"></asp:Label>
    <asp:Label ID="Label33" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Red"
        Height="9px" Style="left: 325px; position: absolute; top: 269px; z-index: 116;"></asp:Label>
    <asp:Button ID="Button2" runat="server" OnClick="newAdd" Text="Add" ToolTip="ins" ValidationGroup="ahu"
                        Width="94px" style="left: 693px; position: absolute; top: 241px; z-index: 117;" />
    <asp:TextBox ID="TextBox3" runat="server" MaxLength="7" Style="left: 435px; position: absolute;
        top: 218px; z-index: 118;" ValidationGroup="ahu" Width="87px"></asp:TextBox>
    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"
        Height="9px" Style="left: 325px; position: absolute; top: 243px; z-index: 119;" Text="Description:"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" MaxLength="200" Style="left: 435px; position: absolute;
        top: 241px; z-index: 120;" ValidationGroup="ahu" Width="225px"></asp:TextBox>
    <asp:Label ID="Label30" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="Red"
        Height="9px" Style="left: -104px; position: absolute; top: 5px; z-index: 121;" Visible="False"></asp:Label>
    <asp:Label ID="Label31" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="Red"
        Height="9px" Style="left: -104px; position: absolute; top: 0px; z-index: 122;" Visible="False"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
        ErrorMessage="*" SetFocusOnError="True" Style="left: 531px; position: absolute;
        top: 219px; z-index: 123;" ValidationGroup="ahu">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4"
        ErrorMessage="*" SetFocusOnError="True" Style="left: 669px; position: absolute;
        top: 243px; z-index: 124;" ValidationGroup="ahu">*</asp:RequiredFieldValidator>
    <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 173px; position: absolute; top: 615px; background-color: transparent; z-index: 125;"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 374px; position: absolute; top: 630px; z-index: 126;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:Label ID="Label34" runat="server" Font-Names="Calibri" ForeColor="White" Style="font-size: medium;
        left: 44px; position: absolute; top: 632px; z-index: 127;" Text="." Width="25px"></asp:Label>
    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        Height="1px" PageSize="25" Style="font-size: small; z-index: 129; left: 42px;
        font-family: Calibri; position: absolute; top: 382px" Width="445px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle"
            Wrap="True" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" CssClass="HeaderStyle" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Content>

