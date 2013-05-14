<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPass.aspx.cs" Inherits="_Default" Title="CIT Examination System | Forgot Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 322px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 317px" Width="336px">
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="209px"
            ImageUrl="~/Images/tabla4.png" Style="left: -119px; position: absolute; top: -186px;
            background-color: transparent" Width="626px" />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Font-Italic="True" Style="left: -59px; position: absolute;
            top: -136px" Text="To redeem your lost password, please fill up the following:"
            Width="527px"></asp:Label>
        <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: -88px; color: limegreen;
            position: absolute; top: -167px" Text="Forgot Password"></asp:Label>
        <asp:Button ID="Button3" runat="server" Style="left: 50px; font-family: 'Lucida Sans';
            position: absolute; top: -46px" Text="Send my password to my email address" OnClick="Button3_Click" TabIndex="1" />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Calibri" Font-Size="Medium"
            ForeColor="Black" NavigateUrl="~/ForgotPass.aspx" Style="left: 840px; position: absolute;
            top: 14px" Width="109px">Forgot Password</asp:HyperLink>
        &nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Style="left: 7px; position: absolute; top: -89px"
            Text="Email address"></asp:Label>
        &nbsp;&nbsp;
        <input id="Text6" style="left: 142px; width: 258px; font-family: 'Lucida Sans'; position: absolute;
            top: -91px" type="text" tabindex="0" />
    </asp:Panel>
    <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Calibri" Font-Size="Medium"
        ForeColor="Black" NavigateUrl="~/LogIn.aspx" Style="left: 840px; position: absolute;
        top: 14px" Width="109px">Back to home</asp:HyperLink>
</asp:Content>

