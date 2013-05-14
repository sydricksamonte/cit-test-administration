<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="_Default" Title="CIT Examination System | Maintenance | Add User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 340px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 113px; z-index: 100;" Width="336px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="261px"
            ImageUrl="~/Images/tabla4.png" Style="left: -131px; position: absolute; top: 24px;
            background-color: transparent; z-index: 100;" Width="578px" OnClick="ImageButton1_Click" />
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Calibri" Font-Size="Small"
            ForeColor="Silver"  PostBackUrl="~/AdPass.aspx" Style="z-index: 103;
            left: 259px; position: absolute; top: 208px" Width="153px">[Change Password]</asp:LinkButton>
        <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: 215px; position: absolute; top: 245px; z-index: 102;" Text="Last Name:" Visible="False"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </asp:Panel>
    <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="Red"
        Height="9px" Style="left: 242px; position: absolute; top: 150px; z-index: 101;" Visible="False"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox8"
        ErrorMessage="*" Height="8px" Style="left: 493px; position: absolute; top: 286px; z-index: 102;"
        ValidationGroup="ins" Width="6px"></asp:RequiredFieldValidator>
    <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: 227px; color: limegreen;
        position: absolute; top: 144px; z-index: 103;" Text="Add new user" Font-Names="Calibri"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2"
        ErrorMessage="*" Style="left: 736px; position: absolute; top: 243px; z-index: 104;" ValidationGroup="ins">*</asp:RequiredFieldValidator>
    &nbsp;
    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"
        Height="9px" Style="z-index: 106; left: 571px; position: absolute; top: 264px"
        Text="Password:" Visible="False"></asp:Label>
    &nbsp;
    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 242px; position: absolute; top: 215px; z-index: 108;" Text="ID:" ForeColor="White" Enabled="False"></asp:Label>
    <asp:TextBox ID="TextBox9" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 279px;
        position: absolute; top: 214px; z-index: 109;" Text='<%# Bind("user_na") %>' ValidationGroup="ins"
        Width="155px" Enabled="False"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 241px; position: absolute; top: 240px; z-index: 110;" Text="Last Name:" ForeColor="White"></asp:Label>
    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 240px; position: absolute; top: 317px; z-index: 111;" Text="Email:" ForeColor="White" Visible="False"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 288px;
        position: absolute; top: 318px; z-index: 112;" Text='<%# Bind("emailadd") %>' Width="155px" Visible="False"></asp:TextBox>
    <asp:TextBox ID="TextBox6" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 336px;
        position: absolute; top: 243px; z-index: 113;" Text='<%# Bind("lname") %>' ToolTip="Last name"
        ValidationGroup="ins" Width="155px"></asp:TextBox>
    <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" Font-Names="Calibri"
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Style="left: 579px;
        position: absolute; top: 194px; z-index: 114;" Width="90px" Visible="False">
        <asp:ListItem>FACULTY</asp:ListItem>
        <asp:ListItem>ADMIN</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6"
        ErrorMessage="*" Style="left: 493px; position: absolute; top: 243px; z-index: 115;" ValidationGroup="ins" Width="9px">*</asp:RequiredFieldValidator>
    <asp:TextBox ID="TextBox7" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 335px;
        position: absolute; top: 267px; z-index: 116;" Text='<%# Bind("fname") %>' ToolTip="First name"
        ValidationGroup="ins" Width="155px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7"
        ErrorMessage="*" Style="left: 492px; position: absolute; top: 267px; z-index: 117;" ValidationGroup="ins">*</asp:RequiredFieldValidator>
    <asp:Button ID="Button1" runat="server" OnClick="ins" Style="left: 450px; position: absolute;
        top: 356px; z-index: 118;" Text="Save" ToolTip="ins" ValidationGroup="ins" Width="94px" /><asp:Button ID="Button2" runat="server" OnClick="insa" Style="left: 451px; position: absolute;
        top: 356px; z-index: 119;" Text="Save" ToolTip="ins" ValidationGroup="ins" Width="94px" UseSubmitBehavior="False" />
    <asp:TextBox ID="TextBox8" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 335px;
        position: absolute; top: 290px; z-index: 120;" Text='<%# Bind("bname") %>' ToolTip="Middle name"
        Width="155px"></asp:TextBox>
    <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 509px; position: absolute; top: 218px; z-index: 121;" Text="Username:" ForeColor="White"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 577px;
        position: absolute; top: 219px; z-index: 122;" Text='<%# Bind("user_na") %>' ValidationGroup="ins"
        Width="155px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
        ErrorMessage="*" Style="left: 735px; position: absolute; top: 220px; z-index: 123;" ValidationGroup="ins">*</asp:RequiredFieldValidator>
    &nbsp; &nbsp;
    <asp:TextBox ID="TextBox2" runat="server" BackColor="Gainsboro" BorderStyle="None"
        Font-Size="Small" ForeColor="ControlText" Height="15px" Style="left: 578px;
        position: absolute; top: 243px; z-index: 126;" Text='<%# Bind("pass") %>' ValidationGroup="ins"
        Width="155px" TextMode="Password" Visible="False"></asp:TextBox>
    <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 515px; position: absolute; top: 285px; z-index: 127;" Text="Gender:" ForeColor="White"></asp:Label>
    <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 512px; position: absolute; top: 193px; z-index: 128;" Text="Type:" ForeColor="White" Visible="False"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Calibri" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
        Style="left: 581px; position: absolute; top: 286px; z-index: 129;" Width="63px">
        <asp:ListItem Selected="True" Value="Male">Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 510px; position: absolute; top: 313px; z-index: 130;" Text="Program:" Visible="False" ForeColor="White"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Calibri" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
        Style="left: 578px; position: absolute; top: 311px; z-index: 131;" Width="64px" Visible="False">
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
        ErrorMessage="ID error." MaximumValue="2100000000" MinimumValue="200700000"
        SetFocusOnError="True" Style="left: 244px; position: absolute; top: 179px; z-index: 132;" ValidationGroup="ins" Font-Names="Calibri"></asp:RangeValidator>
    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 241px; position: absolute; top: 266px; z-index: 133;" Text="First Name:" ForeColor="White"></asp:Label>
    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
        Style="left: 241px; position: absolute; top: 293px; z-index: 134;" Text="Middle Name:" ForeColor="White"></asp:Label>
    <asp:Label ID="Label5" runat="server" Font-Size="Larger" Style="left: 400px; color: limegreen;
        position: absolute; top: 155px; z-index: 135;" Text="User successfully added." Visible="False" Font-Names="Calibri"></asp:Label>
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 133px; position: absolute; top: 419px; background-color: transparent; z-index: 136;"
        Width="726px" />
    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 334px; position: absolute; top: 441px; z-index: 137;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
</asp:Content>

