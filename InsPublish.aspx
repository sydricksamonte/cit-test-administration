<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsPublish.aspx.cs" Inherits="_Default" Title="Publish project" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel3" runat="server" BackImageUrl="~/Images/l_tabla1.png" Height="598px"
        Style="left: 148px; color: white; font-family: ~/DroidSans.ttf, 'Lucida Sans';
        position: absolute; top: 211px" Width="710px">
        &nbsp;
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Calibri"
            Height="19px" Style="font-size: large; left: 22px; color: limegreen;
            position: absolute; top: 4px; z-index: 100;" Text="Publish" Width="145px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="Small" Height="24px"
            Style="font-size: medium; left: 149px; color: limegreen; font-family: Calibri;
            position: absolute; top: 32px; z-index: 101;" Text="Please enter the time duration HH:MM : " Width="150px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="Medium" Height="19px"
            Style="left: 46px; color: limegreen;
            position: absolute; top: 415px; z-index: 102;" Text="Publish name:*" Width="124px" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium"
            Height="19px" Style="z-index: 103; left: 47px; color: limegreen; position: absolute;
            top: 354px" Text="Limit exam items to:" Width="138px"></asp:Label>
        &nbsp;
        <asp:Label ID="Label12" runat="server" Font-Bold="False" Font-Size="Medium" Height="19px"
            Style="left: 46px; color: limegreen;
            position: absolute; top: 386px; z-index: 105;" Text="Select Section:" Width="124px" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label26" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium"
            Height="19px" Style="z-index: 105; left: 19px; color: limegreen; position: absolute;
            top: 563px" Text="* Required Fields" Width="124px"></asp:Label>
        <asp:Label ID="Label16" runat="server" Font-Bold="False" Font-Size="Medium" Height="19px"
            Style="left: 441px; color: limegreen;
            position: absolute; top: 383px; z-index: 106;" Text="Access Password:*" Width="124px" Font-Names="Calibri"></asp:Label>
        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: -255px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 262px; z-index: 107;" Text="Select Section:" Width="124px"></asp:Label>
        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: 22px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 60px; z-index: 108;" Text="Select Course:" Width="124px" Visible="False"></asp:Label>
        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: -249px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 300px; z-index: 109;" Text="Select Course:" Width="124px"></asp:Label>
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CITConnectionString8 %>"
            SelectCommand="SELECT DISTINCT  [course_sec] FROM [course] WHERE (([course_id] = @course_id) AND ([sec_handler] = @sec_handler))">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList5" Name="course_id" PropertyName="Text"
                    Type="String" />
                <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:TextBox ID="TextBox6" runat="server" Style="left: 434px; position: absolute;
            top: 37px; z-index: 110;" Width="48px" OnTextChanged="TextBox6_TextChanged" Enabled="False">01:00</asp:TextBox>
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: 200px; color: red; font-family: 'Lucida Sans'; position: absolute;
            top: -5px; z-index: 111;" Text="Invalid time frame. Please check the time format and duration."
            Visible="False" Width="441px"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="Large" Height="36px"
            Style="left: 21px; font-family: Calibri;
            position: absolute; top: -35px; z-index: 112;" Text="Please enter a more meaningful name." Visible="False"
            Width="289px" ForeColor="Red"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: 26px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 74px; z-index: 113;" Text="Time Frame:" Width="92px" Visible="False"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: x-small; left: 34px; color: silver; font-style: italic; font-family: 'Lucida Sans';
            position: absolute; top: 96px; z-index: 114;" Text="From:" Width="46px" Visible="False"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Style="left: -130px; position: absolute;
            top: 150px; z-index: 115;" ToolTip="Enter minute here" Width="136px" Visible="False"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: small; left: 27px; color: limegreen; font-family: 'Lucida Sans';
            position: absolute; top: 47px; z-index: 116;" Text="Course:" Width="63px" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Style="left: -11px; position: absolute;
            top: 271px; z-index: 117;" ToolTip="Enter minute here" Width="235px" Visible="False"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" SkinID="maji desu ka ska" Style="left: 73px;
            position: absolute; top: 305px; z-index: 118;" ToolTip="Enter minute here" Visible="False" Width="42px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Style="left: -9px; position: absolute;
            top: 322px; z-index: 119;" ToolTip="Enter minute here" Visible="False" Width="42px"></asp:TextBox>
        &nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox6"
            ErrorMessage="Invalid duration, please follow this format HH:MM" SetFocusOnError="True"
            Style="font-size: small; left: 206px; font-family: 'Lucida Sans'; position: absolute;
            top: 13px; z-index: 120;" ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"></asp:RegularExpressionValidator>
        &nbsp; &nbsp;
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" Height="19px"
            Style="font-size: x-small; left: 253px; color: silver; font-style: italic; font-family: 'Lucida Sans';
            position: absolute; top: 67px; z-index: 121;" Text="To:" Width="46px" Visible="False"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Style="font-size: small; left: 321px;
            font-family: 'Lucida Sans'; position: absolute; top: 58px; z-index: 122;" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
            <asp:ListItem>Custom period</asp:ListItem>
            <asp:ListItem>1 Hour from the time entered</asp:ListItem>
            <asp:ListItem>2 Hours from the time entered</asp:ListItem>
            <asp:ListItem Selected="True">5 Hours from  the time entered</asp:ListItem>
            <asp:ListItem>1 Day from the time entered</asp:ListItem>
            <asp:ListItem>2 Days from the time entered</asp:ListItem>
            <asp:ListItem>5 Days from the time entered</asp:ListItem>
            <asp:ListItem Value="1 Week from the time entered">1 Week from the time entered</asp:ListItem>
        </asp:DropDownList><asp:DropDownList ID="DropDownList4" runat="server" Style="font-size: small; left: 304px;
            font-family: 'Lucida Sans'; position: absolute; top: 38px; z-index: 123;" AutoPostBack="True" OnSelectedIndexChanged="changeDur" Width="121px">
            <asp:ListItem>Custom period</asp:ListItem>
            <asp:ListItem>30 Minutes</asp:ListItem>
            <asp:ListItem Selected="True">1 Hour</asp:ListItem>
            <asp:ListItem>1.5 Hours</asp:ListItem>
            <asp:ListItem>2 Hours</asp:ListItem>
            <asp:ListItem>4 Hours</asp:ListItem>
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
            <asp:ListItem>AM</asp:ListItem>
            <asp:ListItem>PM</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2"
            DataTextField="course" DataValueField="course" OnDataBound="DropDownList5_DataBound"
            Style="left: 241px; position: absolute; top: 385px; z-index: 124;" Width="31px" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="SqlDataSource1"
            DataTextField="course_sec" DataValueField="course_sec" OnDataBound="DropDownList6_DataBound"
            Style="left: 151px; position: absolute; top: 385px; z-index: 125;" Width="121px" CausesValidation="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        &nbsp;&nbsp;
        <asp:DropDownList
            ID="DropDownList3" runat="server" Enabled="False" Visible="False" style="left: -68px; position: absolute; top: -95px; z-index: 127;">
            <asp:ListItem>AM</asp:ListItem>
            <asp:ListItem>PM</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Publish" style="left: 285px; position: absolute; top: 475px; z-index: 128;" Width="118px" ValidationGroup="ss" />
        &nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="aa" OnCheckedChanged="RadioButton1_CheckedChanged"
            Style="font-size: small; left: -184px; position: absolute; top: 153px; z-index: 129;" Text="M" Font-Names="Calibri" Font-Size="Small" Width="19px" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="aa" OnCheckedChanged="RadioButton2_CheckedChanged"
            Style="font-size: small; left: -182px; position: absolute; top: 124px; z-index: 130;" Text="Al" Font-Names="Calibri" Font-Size="Small" Checked="True" Width="18px" />
        <asp:TextBox ID="TextBox12" runat="server" Style="left: 560px; position: absolute;
            top: 382px; z-index: 131;" TextMode="Password" ValidationGroup="ss" Width="93px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3"
            ErrorMessage="*" Style="left: 661px; position: absolute; top: 413px; z-index: 132;" ValidationGroup="ss"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TextBox8" runat="server" Style="z-index: 133; left: 187px; position: absolute;
            top: 353px" Width="32px" MaxLength="2">0</asp:TextBox>
        <asp:Label ID="Label17" runat="server" Font-Bold="False" Font-Italic="True" Font-Names="Calibri"
            Font-Size="Small" Height="19px" Style="z-index: 134; left: 120px; color: limegreen;
            position: absolute; top: 327px" Text='Note: "0" for default' Width="121px"></asp:Label>
        &nbsp;
        <asp:Panel ID="Panel1" runat="server" Height="143px" Style="left: 84px; color: gray;
            font-family: 'Segoe UI'; position: absolute; top: 89px" Width="228px">
            <asp:Label ID="Label18" runat="server" Style="z-index: 100; left: 9px; position: absolute;
                top: 0px" Text="Access period"></asp:Label>
            <asp:Label ID="Label19" runat="server" Style="font-size: small; z-index: 101; left: 16px;
                position: absolute; top: 27px" Text="From:*"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox9" runat="server" MaxLength="5" Style="z-index: 104; left: 69px;
                position: absolute; top: 76px" ValidationGroup="ss" Width="49px"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="DropDownList9" runat="server" Style="z-index: 105; left: 127px;
                position: absolute; top: 77px">
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox9"
                ErrorMessage="Invalid Time" SetFocusOnError="True" Style="z-index: 107; left: 174px;
                position: absolute; top: 82px" ValidationExpression="\d{1,2}:\d{1,2}" ValidationGroup="ss"></asp:RegularExpressionValidator>
            <asp:Label ID="Label20" runat="server" Font-Italic="True" Style="font-size: small;
                z-index: 101; left: 73px; position: absolute; top: 51px" Text="MM/DD/YYYY"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server" MaxLength="10" Style="z-index: 104; left: 56px;
                position: absolute; top: 26px" ValidationGroup="ss" Width="107px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox10"
                ErrorMessage="Invalid Date" SetFocusOnError="True" Style="z-index: 107; left: 173px;
                position: absolute; top: 26px" ValidationExpression="\d{1,2}/\d{1,2}/\d{4}" ValidationGroup="ss"></asp:RegularExpressionValidator>
            <asp:Label ID="Label21" runat="server" Font-Italic="True" Style="font-size: small;
                z-index: 101; left: 71px; position: absolute; top: 101px" Text="e.g. 12:00"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox12"
                ErrorMessage="*" Style="z-index: 132; left: 577px; position: absolute; top: 290px"
                ValidationGroup="ss"></asp:RequiredFieldValidator>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="143px" Style="left: 329px; color: gray;
            font-family: 'Segoe UI'; position: absolute; top: 91px" Width="228px">
            &nbsp;
            <asp:Label ID="Label23" runat="server" Style="font-size: small; z-index: 101; left: 16px;
                position: absolute; top: 27px" Text="To:*"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="TextBox11" runat="server" MaxLength="5" Style="z-index: 104; left: 69px;
                position: absolute; top: 76px" ValidationGroup="ss" Width="49px"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="DropDownList7" runat="server" Style="z-index: 105; left: 127px;
                position: absolute; top: 77px">
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox11"
                ErrorMessage="Invalid Time" SetFocusOnError="True" Style="z-index: 107; left: 174px;
                position: absolute; top: 82px" ValidationExpression="\d{1,2}:\d{1,2}" ValidationGroup="ss"></asp:RegularExpressionValidator>
            <asp:Label ID="Label24" runat="server" Font-Italic="True" Style="font-size: small;
                z-index: 101; left: 73px; position: absolute; top: 51px" Text="MM/DD/YYYY"></asp:Label>
            <asp:TextBox ID="TextBox13" runat="server" MaxLength="10" Style="z-index: 104; left: 56px;
                position: absolute; top: 26px" ValidationGroup="ss" Width="107px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox13"
                ErrorMessage="Invalid Date" SetFocusOnError="True" Style="z-index: 107; left: 181px;
                position: absolute; top: 26px" ValidationExpression="\d{1,2}/\d{1,2}/\d{4}" ValidationGroup="ss"></asp:RegularExpressionValidator>
            <asp:Label ID="Label25" runat="server" Font-Italic="True" Style="font-size: small;
                z-index: 101; left: 71px; position: absolute; top: 101px" Text="e.g. 12:00"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox12"
                ErrorMessage="*" Style="z-index: 132; left: 668px; position: absolute; top: 444px"
                ValidationGroup="ss"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox12"
                ErrorMessage="*" Style="z-index: 132; left: 669px; position: absolute; top: 447px"
                ValidationGroup="ss"></asp:RequiredFieldValidator>
        </asp:Panel>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox11"
            ErrorMessage="*" Style="z-index: 132; left: 504px; position: absolute; top: 163px"
            ValidationGroup="ss"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox9"
            ErrorMessage="*" Style="z-index: 132; left: 263px; position: absolute; top: 161px"
            ValidationGroup="ss"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox10"
            ErrorMessage="*" Style="z-index: 132; left: 257px; position: absolute; top: 109px"
            ValidationGroup="ss"></asp:RequiredFieldValidator>
        <asp:Label ID="Label22" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="Red"
            Height="36px" Style="z-index: 112; left: 237px; font-family: Calibri; position: absolute;
            top: 234px" Text="Error found on period" Visible="False" Width="163px"></asp:Label>
        &nbsp;&nbsp;
    </asp:Panel>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
            SelectCommand="SELECT DISTINCT [course] FROM [exam_unpub] WHERE ([exname] LIKE '%' + @exname + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox7" Name="exname" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    &nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox13"
        ErrorMessage="*" Style="z-index: 132; left: 647px; position: absolute; top: 327px"
        ValidationGroup="ss"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox6"
        ErrorMessage="Invalid duration, please follow this format HH:MM" SetFocusOnError="True"
        Style="font-size: small; z-index: 120; left: 206px; font-family: 'Lucida Sans';
        position: absolute; top: 12px" ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"></asp:RegularExpressionValidator>
        <asp:Panel ID="Panel4" runat="server" Height="498px" Style="left: 218px; position: absolute;
            top: 246px; z-index: 126;" Visible="False" Width="597px" BackColor="WindowFrame">
            &nbsp; &nbsp; &nbsp;
            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium"
            Height="21px" Style="color: red;" Text="No classlist found on your account. Please choose an operation to publish this test:"
            Visible="False" Width="559px"></asp:Label><br />
            <br />
            <asp:RadioButton ID="RadioButton3" runat="server" Checked="True" Font-Bold="False"
                ForeColor="White" GroupName="tty"
                Style="font-size: medium; font-family: Calibri; left: 219px; position: absolute; top: 38px;" Text="Add a classlist" /><br />
            <asp:RadioButton ID="RadioButton4" runat="server" Font-Bold="False" ForeColor="White"
                GroupName="tty" Style="font-size: medium;
                font-family: Calibri; left: 220px; position: absolute; top: 63px;" Text="Print only" /><br />
            <asp:RadioButton ID="RadioButton5" runat="server" Font-Bold="False" ForeColor="White"
                GroupName="tty" Style="font-size: medium;
                font-family: Calibri; left: 219px; position: absolute; top: 89px;" Text="Publish later" /><br />
            &nbsp;<br />
            <asp:Button ID="Button2" runat="server" Style="left: 220px; position: absolute; top: 114px"
                Text="Go" Width="102px" OnClick="Button2_Click" /><br />
        </asp:Panel>
    &nbsp;
    <asp:TextBox ID="TextBox7" runat="server" Style="left: 668px; position: absolute;
        top: 624px" Width="9px"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Style="left: 300px; position: absolute;
            top: 624px" Width="502px"></asp:TextBox>
</asp:Content>

