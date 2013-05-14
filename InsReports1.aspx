<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsReports.aspx.cs" Inherits="Home" Title="CIT Examination System | Reports & Documents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Panel ID="Panel3" runat="server" Height="193px"
        Style="left: 185px; color: white; font-family: ~/DroidSans.ttf, 'Lucida Sans';
        position: absolute; top: 230px" Width="193px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT [pname] FROM [exams] WHERE (([user_id] = @user_id) AND ([exname] LIKE '%' + @exname + '%')) ORDER BY [pub_date] DESC">
            <SelectParameters>
                <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                <asp:ControlParameter ControlID="DropDownList2" Name="exname" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="182px"
            ImageUrl="~/Images/tabla7.png" Style="left: 6px; position: absolute; top: 4px"
            Width="293px" OnClick="ImageButton2_Click" />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
            Height="19px" Style="font-weight: normal; font-size: large; left: 25px; color: white;
            font-family: Calibri; position: absolute; top: 15px" Text="Test documents" Width="128px"></asp:Label>
        <asp:Button ID="Button7" runat="server" Font-Names="Calibri" Font-Size="Small" Height="24px"
            Style="left: 57px; position: absolute; top: 135px" Text="Generat Seatwork/Quiz" Width="192px" Enabled="False" OnClick="Button_Clickn" ToolTip="If you want to generate a test with a single set only, Choose this button." /><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
            CausesValidation="True" DataSourceID="SqlDataSource3" DataTextField="pname"
            DataValueField="pname" Enabled="False" OnDataBound="DropDownList1_DataBound"
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Style="left: 25px;
            position: absolute; top: 46px" Width="262px">
            </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" Font-Names="Calibri" Font-Size="Small" Height="24px"
            Style="left: 57px; position: absolute; top: 79px" Text="Generate Exam (Set A / Single Set)" Width="192px" Enabled="False" OnClick="Button2_Click" ToolTip="If you want to generate a test with only a single set, Choose this." />
        <asp:Button ID="Button5" runat="server" Font-Names="Calibri" Font-Size="Small" Height="24px"
            Style="left: 57px; position: absolute; top: 104px" Text="Generat Exam (Set B)" Width="192px" Enabled="False" OnClick="Button_Click" ToolTip="If you want to generate a test with a single set only, Choose this button." />
    </asp:Panel>
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        Height="19px" Style="font-weight: normal; font-size: large; left: 26px; color: limegreen;
        font-family: Calibri; position: absolute; top: 8px" Text="Reports" Visible="False"
        Width="45px"></asp:Label>
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        Height="19px" Style="font-weight: normal; font-size: large; left: 210px; color: limegreen;
        font-family: Calibri; position: absolute; top: 253px" Text="Reports" Visible="False"
        Width="45px"></asp:Label>
    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        Height="19px" Style="font-weight: normal; font-size: large; left: 85px; color: limegreen;
        font-family: Calibri; position: absolute; top: 278px" Text="Reports" Visible="False"
        Width="45px"></asp:Label>
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
        Height="19px" Style="font-weight: normal; font-size: large; left: 118px; color: limegreen;
        font-family: Calibri; position: absolute; top: 333px" Text="Reports" Visible="False"
        Width="45px"></asp:Label><asp:Panel ID="Panel1" runat="server" Height="298px"
        Style="left: 515px; color: white; font-family: ~/DroidSans.ttf, 'Lucida Sans';
        position: absolute; top: 208px" Width="50px">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT DISTINCT [course_sec] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([course_id] = @course_id))">
                <SelectParameters>
                    <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList7" Name="course_id" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp;
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT DISTINCT [course_id] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([term] = @term)) ORDER BY [course_id]">
                <SelectParameters>
                    <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList2" Name="term" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="261px"
            ImageUrl="~/Images/tabla7.png" Style="left: 1px; position: absolute; top: 25px"
            Width="299px" OnClick="ImageButton2_Click" />
            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
                Height="19px" Style="font-weight: normal; font-size: large; left: 20px; color: white;
                font-family: Calibri; position: absolute; top: 39px" Text="Examination report"
                Width="263px"></asp:Label>
            <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="186px"
            ImageUrl="~/Images/tabla7.png" Style="left: -324px; position: absolute; top: 225px"
            Width="296px" OnClick="ImageButton2_Click" />
            <asp:Label ID="Label15" runat="server" Font-Bold="False" Font-Size="Small" Height="19px"
                Style="font-size: medium; left: 19px; color: limegreen; font-family: Calibri;
                position: absolute; top: 69px" Text="Course:" Width="35px"></asp:Label>
            <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource5"
            DataTextField="course_id" DataValueField="course_id" Style="left: 73px; position: absolute;
            top: 66px" Width="67px" AppendDataBoundItems="True" AutoPostBack="True" OnDataBound="DropDownList2_DataBound" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="Label18" runat="server" Font-Bold="False" Font-Size="Small" Height="19px"
                Style="font-size: small; left: 145px; color: limegreen; font-family: 'Lucida Sans';
                position: absolute; top: 69px" Text="Section:" Width="49px"></asp:Label>
            <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True"
            CausesValidation="True" DataSourceID="SqlDataSource4" DataTextField="course_sec"
            DataValueField="course_sec" OnDataBound="DropDownList6_DataBound" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged"
            Style="left: 204px; position: absolute; top: 66px" Width="63px" Enabled="False">
            </asp:DropDownList>
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
            Height="29px" Style="font-weight: normal; font-size: large; left: -304px; color: white;
            font-family: Calibri; position: absolute; top: 235px" Text="Class document" Width="127px"></asp:Label>
        <asp:Button ID="Button11" runat="server" Font-Names="Calibri" Font-Size="Small" Height="29px"
            Style="left: -255px; position: absolute; top: 353px" Text="Generate Classlist"
            Width="147px" Enabled="False" OnClick="Button1_Click" /><asp:DropDownList ID="DropDownList5" runat="server"
            CausesValidation="True" DataSourceID="SqlDataSource6" DataTextField="pname"
            DataValueField="exname" OnDataBound="DropDownList1_DataBound"
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Style="left: 78px;
            position: absolute; top: 132px" Width="194px">
            </asp:DropDownList>
        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="~/DroidSans.ttf"
            Height="19px" Style="font-weight: normal; font-size: medium; left: 24px; color: limegreen;
            font-family: Calibri; position: absolute; top: 133px" Text="Exams" Width="32px"></asp:Label>
        <asp:Button ID="Button9" runat="server" Font-Names="Calibri" Font-Size="Small" Height="29px"
            Style="left: 82px; position: absolute; top: 98px" Text="Generate Scores"
            Width="147px" Enabled="False" OnClick="Button9Click" />
        <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Size="Small" Height="29px"
            Style="font-size: small; left: -266px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 283px" Text="Course:" Width="44px"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2"
            DataTextField="course_id" DataValueField="course_id" Style="left: -193px; position: absolute;
            top: 281px" Width="96px" AppendDataBoundItems="True" AutoPostBack="True" OnDataBound="DropDownList3_DataBound">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Size="Small" Height="29px"
                Style="font-size: small; left: -267px; color: limegreen; font-family: 'Lucida Sans';
                position: absolute; top: 314px" Text="Section:" Width="57px"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server"
            CausesValidation="True" DataSourceID="SqlDataSource1" DataTextField="course_sec"
            DataValueField="course_sec" OnDataBound="DropDownList4_DataBound" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged"
            Style="left: -192px; position: absolute; top: 310px" Width="95px">
            </asp:DropDownList>
            &nbsp;
        <asp:Button ID="Button12" runat="server" Font-Names="Calibri" Font-Size="Small" Height="33px"
            Style="left: 53px; position: absolute; top: 196px" Text="Generate Item Analysis"
            Width="201px" Enabled="False" OnClick="Button4_Click" /><asp:Button ID="Button13" runat="server" Font-Names="Calibri" Font-Size="Small" Height="29px"
            Style="left: 54px; position: absolute; top: 232px" Text="Generate Item Analysis (Chart)"
            Width="200px" Enabled="False" OnClick="Button8_Click" />
        <asp:Button ID="Button14" runat="server" Font-Names="Calibri" Font-Size="Small" Height="29px"
            Style="left: 82px; position: absolute; top: 161px" Text="Generate Certificate"
            Width="147px" Enabled="False" OnClick="Button3_Click" />
            &nbsp;
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT [exname], [pname] FROM [exams] WHERE (([user_id] = @user_id) AND ([exname] LIKE '%' + @exname + '%')) ORDER BY [pub_date] DESC">
                <SelectParameters>
                    <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList2" Name="exname" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp; &nbsp;
        </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString33 %>"
            SelectCommand="SELECT DISTINCT [course_sec] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([course_id] = @course_id))">
        <SelectParameters>
            <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            <asp:ControlParameter ControlID="DropDownList3" Name="course_id" PropertyName="SelectedValue"
                    Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
            SelectCommand="SELECT DISTINCT [course_id] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([term] = @term)) ORDER BY [course_id]">
        <SelectParameters>
            <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            <asp:ControlParameter ControlID="DropDownList2" Name="term" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Label20" runat="server" Font-Size="Medium" Style="left: 190px; color: limegreen;
        font-family: Calibri; position: absolute; top: 187px">Term</asp:Label>
    
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:RACHELCONN %>"
        SelectCommand="SELECT DISTINCT [term] FROM [course] ORDER BY [term] DESC"></asp:SqlDataSource>
</asp:Content>

