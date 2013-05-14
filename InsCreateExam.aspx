<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsCreateExam.aspx.cs" Inherits="CreateExam" Title="CIT Examination System | Tests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel3" runat="server" BackImageUrl="~/Images/tabla4.png" Height="210px"
        Style="left: 203px; color: white; font-family: ~/DroidSans.ttf, 'Lucida Sans';
        position: absolute; top: 432px" Width="618px">
        &nbsp;
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
            Height="25px" Style="left: 13px; font-family: 'Segoe UI';
            position: absolute; top: 10px" Text="Create New Exam" Width="149px" Font-Size="Medium" ForeColor="SeaGreen"></asp:Label>
        &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Font-Bold="True"
            Font-Size="Small" Height="19px" Style="font-size: small; left: 181px; color: limegreen;
            font-family: 'Lucida Sans'; position: absolute; top: 46px" Text="Exam Type"
            Width="334px"></asp:Label>
        <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: 181px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 24px" Text="Select course" Width="110px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Names="~/DroidSans.ttf" Height="19px"
            Style="font-size: small; left: -103px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 296px" Text="Draft name:" Width="128px" Visible="False"></asp:Label>
        &nbsp;
        <asp:Label ID="Label3" runat="server" Font-Names="~/DroidSans.ttf" Height="36px"
            Style="font-size: small; left: 397px; color: red; font-family: 'Lucida Sans'; position: absolute;
            top: 152px" Visible="False"
            Width="198px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Style="left: -16px; position: absolute;
            top: 296px" Width="310px" Visible="False" OnTextChanged="TextBox1_TextChanged1"></asp:TextBox>
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="new" OnCheckedChanged="RadioButton1_CheckedChanged"
            Style="font-size: small; left: 251px; color: white; font-family: Calibri; position: absolute;
            top: 121px" Text="Add questions (databank)" Checked="True" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="new" OnCheckedChanged="RadioButton2_CheckedChanged"
            Style="font-size: small; left: 252px; color: white; font-family: Calibri; position: absolute;
            top: 100px" Text="Create questions" />
        <asp:Label ID="Label4" runat="server" ForeColor="White" Style="font-size: small;
            left: 442px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 406px"
            Text="Upload" Visible="False"></asp:Label>
        <asp:ImageButton ID="ImageButton4" runat="server" BorderColor="Transparent"
            Height="36px" ImageUrl="~/Images/button.png" OnClick="ImageButton4_Click" Style="left: 266px;
            position: absolute; top: 155px" Width="119px" />
        <asp:Panel ID="Panel1" runat="server" Height="66px" Style="left: 398px; position: absolute;
            top: 86px" Width="132px" Visible="False">
            <asp:CheckBox ID="CheckBox1" runat="server" Style="font-size: medium; font-family: Calibri"
                Text="True or False" OnCheckedChanged="CheckBox1_CheckedChanged" /><br />
            <asp:CheckBox ID="CheckBox2" runat="server" Style="font-size: medium; font-family: Calibri"
                Text="Multiple Choice" OnCheckedChanged="CheckBox2_CheckedChanged" /><br />
            <asp:CheckBox ID="CheckBox3" runat="server" Style="font-size: medium; font-family: Calibri"
                Text="Identification" OnCheckedChanged="CheckBox3_CheckedChanged" /></asp:Panel><asp:Panel ID="Panel4" runat="server" Height="65px" Style="left: 291px; position: absolute;
            top: 66px" Width="97px" Visible="False">
                    <asp:RadioButton ID="RadioButton3" runat="server" Font-Bold="True"
                        ForeColor="MediumSeaGreen" GroupName="tty" OnCheckedChanged="RadioButton3_CheckedChanged"
                        Style="font-size: medium; font-family: Calibri" Text="Exam" Checked="True" /><br />
                    <asp:RadioButton ID="RadioButton4" runat="server" Font-Bold="True"
                        ForeColor="MediumSeaGreen" GroupName="tty" OnCheckedChanged="RadioButton4_CheckedChanged"
                        Style="font-size: medium; font-family: Calibri" Text="Quiz" /><br />
                    </asp:Panel>
        <asp:DropDownList ID="drpExtype" runat="server" Font-Names="Calibri" Style="left: 91px;
            position: absolute; top: 71px" Width="471px" OnSelectedIndexChanged="drpExtype_SelectedIndexChanged1" DataTextField="ex_name" DataValueField="ex_code" OnDataBinding="drpExtype_DataBinding" OnDataBound="drpExtype_DataBound">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="Data Source=SYARA\SQLEXPRESS;Initial Catalog=CIT;Integrated Security=True"
            SelectCommand="SELECT * FROM [course_bulk] WHERE (([co_owner] = @co_owner) AND ([course] = @course) AND ([ex_code] LIKE '%' + @ex_code + '%')) ORDER BY [ex_name]" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:SessionParameter Name="co_owner" SessionField="user" Type="String" />
                <asp:ControlParameter ControlID="DropDownList3" Name="course" PropertyName="SelectedValue"
                    Type="String" />
                <asp:SessionParameter Name="ex_code" SessionField="term" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;
        <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Calibri" Style="left: 293px;
            position: absolute; top: 23px" Width="153px" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="course_id" DataValueField="course_id" OnDataBound="DropDownList3_SelectedIndexChanged" OnLoad="DropDownList3_Load" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
            SelectCommand="SELECT DISTINCT [course_id] FROM [course] WHERE (([term] = @term) AND ([sec_handler] = @sec_handler))">
            <SelectParameters>
                <asp:SessionParameter Name="term" SessionField="term" Type="String" />
                <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    &nbsp;
    <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/Images/tabla3.png" Height="183px"
        Style="left: 338px; color: white; font-family: ~/DroidSans.ttf, 'Lucida Sans';
        position: absolute; top: 671px" Width="385px">
        &nbsp;
        <asp:Label ID="Label7" runat="server" Font-Names="~/DroidSans.ttf" Height="19px"
            Style="font-size: small; left: 36px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 49px" Text="Examination name:" Width="128px"></asp:Label>
        &nbsp; &nbsp;
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
            Height="19px" Style="font-size: medium; left: 18px; font-family: 'Lucida Sans';
            position: absolute; top: 9px" Text="Unpublished Exams" Width="175px" ForeColor="SeaGreen"></asp:Label>
        &nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Style="left: 153px; font-family: 'Lucida Sans';
            position: absolute; top: 141px" Text="Open" Width="78px" OnClick="Button1_Click" />
        <asp:DropDownList ID="DropDownList1" runat="server" Style="left: 27px; font-family: 'Lucida Sans';
            position: absolute; top: 84px" Width="319px" DataSourceID="SqlDataSource1" DataTextField="exam_code" DataValueField="exam_code" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>"
            SelectCommand="SELECT DISTINCT exam_code FROM question_table WHERE (ins_id = @ins_id) AND (exam_code LIKE '%' + @exam_code + '%') AND (p_date = @syd)">
            <SelectParameters>
                <asp:SessionParameter Name="ins_id" SessionField="user" Type="String" />
                <asp:SessionParameter Name="exam_code" SessionField="term" Type="String" />
                <asp:Parameter DefaultValue=" " Name="syd" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
    &nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Label ID="Label10" runat="server" ForeColor="White" Style="font-size: small;
        left: 506px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 592px"
        Text="Create" AssociatedControlID="ImageButton4" EnableTheming="False"></asp:Label>
    <asp:Panel ID="Panel5" runat="server" BackImageUrl="~/Images/tabla4.png" Height="210px"
        Style="left: 198px; position: absolute; top: 196px" Width="620px">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="86px" Style="left: 73px; position: absolute; top: 41px"
            Width="90px" PostBackUrl="~/InsEditExam.aspx" ImageUrl="~/Images/tabla4.png" Enabled="False" OnClick="ImageButton1_Click1" Visible="False" />
        <asp:Label ID="txtStatus" runat="server" Font-Size="Medium" Style="left: 189px; color: limegreen;
            font-family: Calibri; position: absolute; top: 69px">Select Test</asp:Label>
        <asp:Label ID="Label20" runat="server" Font-Size="Medium" Style="left: 459px; color: limegreen;
            font-family: Calibri; position: absolute; top: 11px">Term</asp:Label>
        <asp:Label ID="Label15" runat="server" Font-Size="Larger" Style="left: 26px; color: limegreen;
            font-family: Calibri; position: absolute; top: 184px" Visible="False">Select Test</asp:Label>
        <asp:Label ID="Label19" runat="server" Font-Bold="False" Font-Size="Larger" Style="left: 4px;
            color: limegreen; font-family: Calibri; position: absolute; top: -48px; font-style: italic;" OnLoad="Label19_Load"></asp:Label>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Style="left: 334px;
            position: absolute; top: 85px" Text="Close now" Visible="False" Width="101px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Style="left: 335px;
            position: absolute; top: 117px" Text="Open" Visible="False" Width="101px" />
        <asp:Button ID="btnPrev" runat="server" Style="left: 65px; position: absolute; top: 155px"
            Text="Preview" Visible="False" Width="104px" OnClick="btnPrev_Click" Font-Names="Calibri" />
        &nbsp;
        <asp:Label ID="lblCreated" runat="server" ForeColor="White" Style="left: 288px; color: white;
            font-style: italic; font-family: Calibri; position: absolute; top: 136px">--</asp:Label>
        <asp:Label ID="lblDura" runat="server" ForeColor="White" Style="left: 355px; color: white;
            font-style: italic; font-family: Calibri; position: absolute; top: 163px">--:--</asp:Label>
        <asp:Label ID="Label5" runat="server" ForeColor="White" Style="left: 192px; color: appworkspace;
            font-family: Calibri; position: absolute; top: 163px" Text="Test duration: (HH:MM)"></asp:Label>
        <asp:Label ID="Label16" runat="server" ForeColor="White" Style="left: 486px; color: appworkspace;
            font-family: Calibri; position: absolute; top: 88px" Text="Student Access Password:" Width="114px" Visible="False"></asp:Label>
        <asp:Label ID="Label17" runat="server" ForeColor="LimeGreen" Style="font-size: small;
            left: 492px; font-family: Calibri; position: absolute; top: 182px" Text="Password Changed"
            Visible="False"></asp:Label>
        <asp:Label ID="Label11" runat="server" ForeColor="White" Style="left: 192px; color: appworkspace;
            font-family: Calibri; position: absolute; top: 136px" Text="Date created:"></asp:Label>
        <asp:Label ID="Label12" runat="server" ForeColor="White" Style="left: 246px; color: white;
            font-style: italic; font-family: Calibri; position: absolute; top: 109px" Text="----"></asp:Label>
        <asp:Label ID="Label13" runat="server" ForeColor="White" Style="left: 193px; color: appworkspace;
            font-family: Calibri; position: absolute; top: 109px" Text="Status:"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Segoe UI"
            Height="19px" Style="left: 18px; font-family: 'Segoe UI';
            position: absolute; top: 9px" Text="Published Exams" Width="138px" ForeColor="SeaGreen"></asp:Label>
        &nbsp;
        <asp:Panel ID="Panel6" runat="server" Style="position: absolute">
            &nbsp;&nbsp;
        </asp:Panel>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT * FROM [exams] WHERE (([user_id] = @user_id) AND ([exname] LIKE '%' + @exname + '%')) ORDER BY [pname]">
            <SelectParameters>
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                <asp:ControlParameter ControlID="DropDownList5" Name="exname" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:ImageButton ID="ImageButton2" runat="server" BorderColor="Transparent"
            Height="36px" ImageUrl="~/Images/button.png" OnClick="ImageButton2_Click1" Style="left: 411px;
            position: absolute; top: 37px" Width="119px" />
        <asp:Label ID="Label14" runat="server" ForeColor="White" Style="font-size: small;
            left: 435px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 42px"
            Text="Show Info" AssociatedControlID="ImageButton2"></asp:Label><asp:Button ID="Button4" runat="server" Style="left: 64px; position: absolute; top: 134px"
            Text="Show Status" Visible="False" Width="106px" OnClick="btnSatt_Click" Font-Names="Calibri" /><asp:Button ID="Button5" runat="server" Style="left: 275px; position: absolute; top: 182px"
            Text="Show " Visible="False" Width="101px" OnClick="btnSatt_Click" />
        <asp:TextBox ID="TextBox12" runat="server" Style="left: 486px; position: absolute;
            top: 130px" ValidationGroup="pass" Width="93px" Visible="False"></asp:TextBox>
        <asp:Button ID="Button51" runat="server" Enabled="False" OnClick="Button5_Click" Style="left: 513px;
            position: absolute; top: 157px" Text="Change" ValidationGroup="pass" Visible="False" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox12"
            ErrorMessage="*" Style="left: 589px; position: absolute; top: 131px" ValidationGroup="pass" Visible="False"></asp:RequiredFieldValidator>
        <asp:Button ID="Button6" runat="server" Font-Names="Calibri" Style="font-size: small;
            left: 65px; position: absolute; top: 176px" Text="More options" Visible="False" Width="104px" OnClick="Button6_Click" />
        <asp:DropDownList ID="DropDownList4" runat="server" Font-Names="Calibri" Style="left: 379px;
            position: absolute; top: 38px" Width="19px" OnSelectedIndexChanged="drpExtype_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2"
            DataTextField="pname" DataValueField="exname" OnDataBound="DropDownList2_DataBound"
            OnLoad="DropDownList2_Load" Style="left: 187px; position: absolute; top: 38px"
            Width="211px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList><asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource5"
            DataTextField="term" DataValueField="term" OnDataBound="DropDownList5_DataBound" Style="left: 497px; position: absolute; top: 11px"
            Width="107px" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT DISTINCT [term] FROM [course] ORDER BY [term] DESC"></asp:SqlDataSource>
    </asp:Panel>
    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Button" Visible="False" />
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Classlist/2011102624686IT130-B51a.xls"
        Style="font-size: small; left: 216px; color: white; font-family: Calibri; position: absolute;
        top: 600px" Visible="False">Download Tests Manager</asp:LinkButton>
</asp:Content>

