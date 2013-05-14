<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="Default2" Title="Welcome to CIT Examination system" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
function TABLE1_onclick() {

}

function TABLE2_onclick() {

}

// ]]>
</script>

    &nbsp;&nbsp;
     <table style="left: 678px; width: 319px; position: absolute; top: 397px; height: 23px; z-index: 101;" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td colspan="3" style="width: 434px; height: 20px;">
                    &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="False" ForeColor="White" Style="font-size: x-small; color: red; font-style: italic;" Visible="False" meta:resourcekey="Label2Resource1"></asp:Label></td>
            </tr>
        </table> <asp:Panel ID="pnlLog" runat="server" Height="235px" Style="left: 50px;
        font-family: 'Lucida Sans'; position: absolute; top: 125px; background-color: transparent; z-index: 100;" Width="341px" meta:resourcekey="pnlLogResource1">
        &nbsp;
    </asp:Panel>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" meta:resourcekey="Label1Resource1"></asp:Label>&nbsp;&nbsp;
    &nbsp;
    <asp:ImageButton ID="ImageButton7" runat="server" Enabled="False" Height="274px"
        ImageUrl="~/Images/logo power.png" OnClick="ImageButton7_Click" Style="left: 420px;
        position: absolute; top: 36px; z-index: 101;" Width="275px" meta:resourcekey="ImageButton7Resource1" />
    &nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" meta:resourcekey="Button1Resource1" Visible="False" />
    <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Calibri" Font-Size="Medium"
        ForeColor="Black" NavigateUrl="~/ForgotPass.aspx" Style="left: 840px; position: absolute;
        top: 14px; z-index: 102;" Width="109px" Visible="False">Forgot Password</asp:HyperLink>
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="410px"
        ImageUrl="~/Images/guhit90.png" OnClick="ImageButton2_Click" Style="z-index: 103;
        left: 661px; position: absolute; top: 31px; background-color: transparent" Width="1px" />
    <asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="363px"
        ImageUrl="~/Images/tabla890.png" Style="z-index: 104; left: 709px; position: absolute;
        top: 50px; background-color: transparent" Width="226px" />
      
    &nbsp;
                            <asp:ImageButton ID="LoginButton" runat="server" Height="31px" ImageUrl="~/Images/log.png"
                                OnClick="ImageButton1_Click" Style="left: 807px; position: absolute; top: 324px; z-index: 105;"
                                ValidationGroup="Login1" Width="93px" meta:resourcekey="LoginButtonResource1" />
        <asp:Login ID="Login1" runat="server" Font-Size="Smaller" Height="7px" Style="position: absolute; left: 718px; top: 84px; z-index: 106;"
            Width="190px" meta:resourcekey="Login1Resource1">
            <LayoutTemplate>
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse; width: 247px;" id="TABLE2" onclick="return TABLE2_onclick()">
                    <tr>
                        <td style="height: 200px; width: 319px;">
                            &nbsp;
                            <table border="0" cellpadding="0" style="width: 316px; height: 89px">
                                <tr>
                                    <td colspan="2" style="width: 312px; height: 108px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ForeColor="White" meta:resourcekey="UserNameLabelResource1" style="z-index: 100; left: 69px; position: absolute; top: 67px; text-align: center">Username:</asp:Label>
                                        <br />
                                        <asp:TextBox ID="UserName" runat="server" OnTextChanged="UserName_TextChanged" Width="150px" BorderColor="DimGray" BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="Small" MaxLength="20" meta:resourcekey="UserNameResource1" style="z-index: 101; left: 30px; position: absolute; top: 94px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1" meta:resourcekey="UserNameRequiredResource1" style="z-index: 103; left: 184px; position: absolute; top: 94px">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: red; height: 19px; width: 312px;">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="White" meta:resourcekey="PasswordLabelResource1" style="z-index: 100; left: 75px; position: absolute; top: 142px; text-align: center">Password:</asp:Label>&nbsp;<br />
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px" BorderColor="DimGray" BorderStyle="Solid" BorderWidth="1px" Font-Names="Calibri" Font-Size="Small" MaxLength="20" meta:resourcekey="PasswordResource1" style="z-index: 101; left: 30px; position: absolute; top: 170px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1" meta:resourcekey="PasswordRequiredResource1" style="z-index: 103; left: 182px; position: absolute; top: 169px">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 8px; width: 312px;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" meta:resourcekey="FailureTextResource1"></asp:Literal>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" ForeColor="DimGray" Style="z-index: 107; left: 563px; position: absolute; top: 248px" Font-Size="X-Large">CIT</asp:Label>
    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="X-Large" ForeColor="DimGray"
        Style="z-index: 109; left: 326px; position: absolute; top: 275px; text-align: left;">Test Administration System</asp:Label>
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="Black"
        Style="left: 410px; position: absolute; top: 304px">Malayan Colleges Laguna</asp:Label>
    
</asp:Content>

