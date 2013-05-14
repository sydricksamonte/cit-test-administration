<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="InsSettings.aspx.cs" Inherits="Settings" Title="CIT Examination System | Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <asp:Panel ID="Panel1" runat="server" Height="158px" Style="font-size: small; left: 894px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 629px" Width="336px" Visible="False">
        <asp:ImageButton ID="ImageButton6" runat="server" Enabled="False" Height="180px"
            ImageUrl="~/Images/tabla3.png" Style="left: 6px;
            position: absolute; top: -7px; background-color: transparent" Width="380px" />
        <asp:Label ID="Label1" runat="server" Style="left: 53px; position: absolute; top: 61px"
            Text="Last Name"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Italic="True" Style="left: 49px; position: absolute;
            top: 21px" Text="If your name is mispelled, please correct them here."></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Size="Larger" Style="left: 18px; color: limegreen;
            position: absolute; top: -4px" Text="Change Name"></asp:Label>
        <asp:Button ID="Button1" runat="server" Style="left: 163px; font-family: 'Lucida Sans';
            position: absolute; top: 132px" Text="Change" />
        <input id="Text1" style="left: 133px; width: 175px; font-family: 'Lucida Sans'; position: absolute;
            top: 59px" type="text" />
        <asp:Label ID="Label3" runat="server" Style="left: 53px; position: absolute; top: 85px"
            Text="First Name"></asp:Label>
        <asp:Label ID="Label4" runat="server" Style="left: 46px; position: absolute; top: 111px"
            Text="Middle Name"></asp:Label>
        <input id="Text3" style="left: 134px; width: 175px; font-family: 'Lucida Sans'; position: absolute;
            top: 107px" type="text" />
        <input id="Text2" style="left: 134px; width: 175px; font-family: 'Lucida Sans'; position: absolute;
            top: 83px" type="text" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: medium; left: 271px;
        color: #ffffff; font-family: Calibri; position: absolute; top: 224px" Width="336px">
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="209px"
            ImageUrl="~/Images/tabla4.png" Style="left: -95px;
            position: absolute; top: -19px; background-color: transparent" Width="626px" OnClick="ImageButton1_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: -51px; color: limegreen;
            position: absolute; top: 12px" Text="Change Password"></asp:Label>
        <asp:Label ID="Label6" runat="server" Font-Size="Larger" Style="left: 93px; color: white;
            position: absolute; top: 132px; font-size: small;" Text="Password changed." Visible="False" ForeColor="White"></asp:Label>
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="ChangePasswordPushButton" runat="server" OnClick="ChangePasswordPushButton_Click"
            Style="left: 154px; position: absolute; top: 151px" Text="Change Password" ValidationGroup="ChangePassword1" />
        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword"
            Style="left: 57px; position: absolute; top: 48px">Old Password:</asp:Label>
        <asp:TextBox ID="CurrentPassword" runat="server" Style="left: 167px; position: absolute;
            top: 45px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
            ErrorMessage="Password is required." Style="left: 318px; position: absolute;
            top: 46px" ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword"
            Style="left: 49px; position: absolute; top: 75px">New Password:</asp:Label>
        <asp:TextBox ID="NewPassword" runat="server" Style="left: 167px; position: absolute;
            top: 73px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
            ErrorMessage="New Password is required." Style="left: 317px; position: absolute;
            top: 74px" ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
            Style="left: -3px; position: absolute; top: 102px">Confirm New Password:</asp:Label>
        <asp:TextBox ID="ConfirmNewPassword" runat="server" Style="left: 167px; position: absolute;
            top: 102px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
            ErrorMessage="Confirm New Password is required." Style="left: 318px; position: absolute;
            top: 104px" ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
            ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The passwords you entered do not match. Please try again."
            Style="left: 353px; position: absolute; top: 34px" ValidationGroup="ChangePassword1"
            Width="143px"></asp:CompareValidator>
    </asp:Panel>
    &nbsp;
    <asp:Panel ID="Panel3" runat="server" Height="115px" Style="left: 780px; font-family: Calibri;
        position: absolute; top: 439px" Visible="False" Width="344px">
        <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="112px"
            ImageUrl="~/Images/tabla3.png" OnClick="ImageButton2_Click" Style="left: -1px;
            position: absolute; top: -19px" Width="252px" />
        <asp:Label ID="Label14" runat="server" Font-Size="Larger" Style="left: 13px; color: limegreen;
            position: absolute; top: -13px" Text="Maintenance"></asp:Label>
        <asp:Label ID="Label15" runat="server" Font-Italic="True" Style="font-size: small;
            left: 29px; color: white; position: absolute; top: 14px" Text="Update users, exams, courses and current term."
            Width="146px"></asp:Label>
        <asp:Button ID="Button4" runat="server" Style="left: 35px; font-family: 'Lucida Sans';
            position: absolute; top: 56px" Text="Go to maintenance" OnClick="Button4_Click" />
    </asp:Panel>
    &nbsp;
</asp:Content>

