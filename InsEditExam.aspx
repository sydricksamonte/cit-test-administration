<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsEditExam.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel5" runat="server" BackImageUrl="~/Images/l_tabla1.png" Height="300px"
        Style="left: 153px; position: absolute; top: 215px; z-index: 100;" Width="710px">
        &nbsp;&nbsp;
        <asp:Label ID="Label15" runat="server" Font-Size="Larger" Style="left: 73px; color: limegreen;
            font-family: Calibri; position: absolute; top: 45px">Select Test</asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Size="Small" Style="left: 136px; color: appworkspace;
            font-family: Calibri; position: absolute; top: 146px" Visible="False">Please enter your password:</asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Style="left: 273px; position: absolute; top: 240px"
            Text="Start Operation" Width="133px" Font-Names="Calibri" Height="31px" OnClick="Button3_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label13" runat="server" ForeColor="White" Style="left: 76px; color: appworkspace;
            font-family: Calibri; position: absolute; top: 87px" Text="This test is already published. Before you proceed, please select an operation  you want to happen:" Height="19px" Width="544px" Font-Size="10pt" Visible="False"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="~/DroidSans.ttf"
            Height="19px" Style="font-size: large; left: 18px; color: limegreen; font-family: Calibri;
            position: absolute; top: 9px" Text="More operations" Width="350px"></asp:Label>
        &nbsp;
        <asp:Panel ID="Panel6" runat="server" Style="position: absolute">
            &nbsp;&nbsp;
        </asp:Panel>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Panel ID="Panel4" runat="server" Height="2px" Style="left: 91px; position: absolute;
            top: 114px" Width="514px">
            <asp:RadioButton ID="RadioButton3" runat="server" Font-Bold="False"
                ForeColor="MediumSeaGreen" GroupName="tty"
                Style="font-size: medium; font-family: Calibri" Text="Edit exam" />
            <br />
            <asp:RadioButton ID="RadioButton4" runat="server" Font-Bold="False" ForeColor="MediumSeaGreen"
                GroupName="tty" Style="font-size: medium;
                font-family: Calibri" Text="Edit exam & save it as a new file" /><br />
            <asp:RadioButton ID="RadioButton6" runat="server" Font-Bold="False" ForeColor="MediumSeaGreen"
                GroupName="tty" OnCheckedChanged="RadioButton1_CheckedChanged" Style="font-size: medium;
                font-family: Calibri" Text="Rename exam" /><br /><asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="False" ForeColor="MediumSeaGreen"
                GroupName="tty" OnCheckedChanged="RadioButton1_CheckedChanged" Style="font-size: medium;
                font-family: Calibri" Text="Delete exam" /><br />
            <asp:RadioButton ID="RadioButton5" runat="server" Font-Bold="False"
                ForeColor="MediumSeaGreen" GroupName="tty"
                Style="font-size: medium; font-family: Calibri" Text="Add student to take exam" /><br />
            <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="False" ForeColor="MediumSeaGreen"
                GroupName="tty" Style="font-size: medium;
                font-family: Calibri" Text="Retake exam/ quiz/ seatwork" /></asp:Panel>
        <asp:TextBox ID="TextBox1" runat="server" Font-Names="Calibri" Font-Size="Small"
            MaxLength="50" Style="left: 418px; position: absolute; top: 28px" TextMode="Password"
            Visible="False"></asp:TextBox>
    </asp:Panel><asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Images/tabla4.png" Height="210px"
        Style="left: 198px; position: absolute; top: 547px; z-index: 101;" Width="626px" Visible="False">
        &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Size="Larger" Style="left: 20px; color: limegreen;
            font-family: Calibri; position: absolute; top: 8px">Manual Addition</asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Size="Small" Style="font-size: medium;
            left: 99px; color: appworkspace; font-family: Calibri; position: absolute; top: 91px">Student Number:</asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Style="left: 234px; position: absolute; top: 159px"
            Text="Add Student" Width="133px" Font-Names="Calibri" Height="31px" OnClick="Button1_Click" ValidationGroup="AA" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label5" runat="server" Font-Size="10pt" ForeColor="White" Height="19px"
            Style="left: 97px; color: appworkspace; font-family: Calibri; position: absolute;
            top: 65px" Text="In order to let a student take a test. Please enter the following information:"
            Width="426px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Names="~/DroidSans.ttf"
            Height="19px" Style="font-size: large; left: 47px; color: limegreen; font-family: Calibri;
            position: absolute; top: 36px" Text="Enter student information" Width="350px"></asp:Label>
        &nbsp;
        <asp:Panel ID="Panel2" runat="server" Style="position: absolute">
            &nbsp;&nbsp;
        </asp:Panel>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Font-Names="Calibri" Font-Size="Small"
            MaxLength="10" Style="left: 221px; position: absolute; top: 91px" ValidationGroup="AA"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Font-Size="Small" Style="font-size: medium;
            left: 100px; color: appworkspace; font-family: Calibri; position: absolute; top: 119px">Student Name:</asp:Label>
        <asp:TextBox ID="txtNa" runat="server" Font-Names="Calibri" Font-Size="Small" MaxLength="50"
            Style="left: 221px; position: absolute; top: 118px" Width="273px"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Font-Size="Small" Style="font-size: medium;
            left: 397px; color: appworkspace; font-family: Calibri; position: absolute; top: 92px">Section:</asp:Label>
        <asp:TextBox ID="txtSe" runat="server" Font-Names="Calibri" Font-Size="Small" MaxLength="3"
            Style="left: 451px; position: absolute; top: 90px" Width="43px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
            ErrorMessage="!" SetFocusOnError="True" Style="left: 383px; position: absolute;
            top: 92px" ValidationGroup="AA"></asp:RequiredFieldValidator>
        <asp:Label ID="Label9" runat="server" Style="font-size: medium; left: 20px; color: red;
            font-family: Calibri; position: absolute; top: -18px"></asp:Label>
    </asp:Panel><asp:Panel ID="Panel3" runat="server" BackImageUrl="~/Images/tabla4.png" Height="210px"
        Style="left: 195px; position: absolute; top: 544px; z-index: 102;" Width="626px" Visible="False">
        &nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Font-Size="Larger" Style="left: 32px; color: limegreen;
            font-family: Calibri; position: absolute; top: 38px">Rename</asp:Label>
        <asp:Label ID="Label11" runat="server" Font-Size="Small" Style="font-size: medium;
            left: 75px; color: appworkspace; font-family: Calibri; position: absolute; top: 81px">Examination Name:</asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Style="left: 252px; position: absolute; top: 131px"
            Text="Save" Width="133px" Font-Names="Calibri" Height="31px" OnClick="Button2_Click" ValidationGroup="AA" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Panel ID="Panel7" runat="server" Style="position: absolute">
            &nbsp;&nbsp;
        </asp:Panel>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Font-Names="Calibri" Font-Size="Small"
            MaxLength="100" Style="left: 197px; position: absolute; top: 81px" ValidationGroup="AA"
            Width="324px"></asp:TextBox>
        &nbsp; &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
            ErrorMessage="!" SetFocusOnError="True" Style="left: 521px; position: absolute;
            top: 82px" ValidationGroup="AA" Width="1px"></asp:RequiredFieldValidator>
        <asp:Label ID="Label18" runat="server" Style="font-size: medium; left: 20px; color: red;
            font-family: Calibri; position: absolute; top: -18px"></asp:Label>
    </asp:Panel>
    &nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="font-size: medium;
        z-index: 105; left: 244px; color: red; font-family: 'Segoe UI'; position: absolute;
        top: 179px" Visible="False">Are you sure you want to delete this exam? Please click this link to proceed.</asp:LinkButton>
</asp:Content>

