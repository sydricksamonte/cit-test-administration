<%@ Page Language="C#" MasterPageFile="~/active.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <asp:Panel ID="Panel1" runat="server" Height="158px" Style="font-size: small; left: 290px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 280px" Width="336px">
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
    </asp:Panel><asp:Panel ID="Panel3" runat="server" Height="158px" Style="font-size: small; left: 302px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 735px" Width="336px">
        <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="180px"
            ImageUrl="~/Images/tabla3.png" Style="left: -9px;
            position: absolute; top: -9px; background-color: transparent" Width="380px" /><asp:ImageButton ID="ImageButton3" runat="server" Enabled="False" Height="82px"
            ImageUrl="~/Images/tabla3.png" Style="left: 271px;
            position: absolute; top: 31px; background-color: transparent" Width="83px" />
        <asp:Label ID="Label14" runat="server" Style="left: 14px; position: absolute; top: 67px"
            Text="Please beware of the picture you are going to use. Any foul image will be subjected to violation by the premises." Font-Italic="True" Font-Size="Smaller" Height="52px" Width="246px"></asp:Label>
        &nbsp;
        <asp:Label ID="Label16" runat="server" Font-Size="Larger" Style="left: 14px; color: limegreen;
            position: absolute; top: 3px" Text="Change profile picture"></asp:Label>
        <asp:Button ID="Button4" runat="server" Style="left: 147px; font-family: 'Lucida Sans';
            position: absolute; top: 133px" Text="Change" />
        &nbsp; &nbsp; &nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" Style="left: 18px; position: absolute;
            top: 37px" />
    </asp:Panel><asp:Panel ID="Panel4" runat="server" Height="158px" Style="font-size: small; left: 309px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 947px" Width="336px">
        <asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="180px"
            ImageUrl="~/Images/tabla3.png" Style="left: -21px;
            position: absolute; top: -6px; background-color: transparent" Width="380px" />
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="privSet" OnCheckedChanged="RadioButton1_CheckedChanged"
            Style="left: 22px; position: absolute; top: 67px" Text="Only instructors and listed students can see my profile" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="privSet" OnCheckedChanged="RadioButton1_CheckedChanged"
            Style="left: 21px; position: absolute; top: 42px" Text="Let anyone view my profile" />
        <asp:Label ID="Label15" runat="server" Font-Italic="True" Font-Size="Smaller" Height="21px"
            Style="left: 52px; position: absolute; top: 22px" Text="Who can view your profile"
            Width="165px"></asp:Label>
        &nbsp;
        <asp:Label ID="Label17" runat="server" Font-Size="Larger" Style="left: 14px; color: limegreen;
            position: absolute; top: 3px" Text="Privacy Settings"></asp:Label>
        <asp:Button ID="Button5" runat="server" Style="left: 147px; font-family: 'Lucida Sans';
            position: absolute; top: 133px" Text="Change" />
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="privSet" OnCheckedChanged="RadioButton1_CheckedChanged"
            Style="left: 21px; position: absolute; top: 105px" Text="Only instructors can see my profile" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 299px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 485px" Width="336px">
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="209px"
            ImageUrl="~/Images/tabla4.png" Style="left: -124px;
            position: absolute; top: -2px; background-color: transparent" Width="626px" />
        <asp:Label ID="Label11" runat="server" Style="left: -69px; position: absolute; top: 90px"
            Text="Old Password"></asp:Label><input id="Text7" style="left: 44px; width: 139px; font-family: 'Lucida Sans'; position: absolute;
            top: 85px" type="text" />
        <asp:Label ID="Label12" runat="server" Style="left: -73px; position: absolute; top: 113px"
            Text="New Password"></asp:Label>
        <asp:Label ID="Label13" runat="server" Style="left: -75px; position: absolute; top: 137px"
            Text="Confirm Password"></asp:Label>
        <input id="Text8" style="left: 45px; width: 139px; font-family: 'Lucida Sans'; position: absolute;
            top: 133px" type="text" />
        <input id="Text9" style="left: 45px; width: 139px; font-family: 'Lucida Sans'; position: absolute;
            top: 109px" type="text" />
        <asp:Label ID="Label6" runat="server" Style="left: 200px; position: absolute; top: 87px"
            Text="Old email address"></asp:Label>
        <asp:Label ID="Label7" runat="server" Font-Italic="True" Style="left: -68px; position: absolute;
            top: 36px" Text="If you are having trouble with your account, try changing your password or email address" Width="527px"></asp:Label>
        <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: -97px; color: limegreen;
            position: absolute; top: 5px" Text="Account Settings"></asp:Label>
        <asp:Button ID="Button2" runat="server" Style="left: -23px; font-family: 'Lucida Sans';
            position: absolute; top: 169px" Text="Change password" /><asp:Button ID="Button3" runat="server" Style="left: 224px; font-family: 'Lucida Sans';
            position: absolute; top: 168px" Text="Change email address" />
        <input id="Text4" style="left: 331px; width: 139px; font-family: 'Lucida Sans'; position: absolute;
            top: 80px" type="text" />
        <asp:Label ID="Label9" runat="server" Style="left: 199px; position: absolute; top: 110px"
            Text="New email address"></asp:Label>
        <asp:Label ID="Label10" runat="server" Style="left: 201px; position: absolute; top: 134px"
            Text="Confirm new email"></asp:Label>
        <input id="Text5" style="left: 331px; width: 139px; font-family: 'Lucida Sans'; position: absolute;
            top: 129px" type="text" />
        <input id="Text6" style="left: 331px; width: 139px; font-family: 'Lucida Sans'; position: absolute;
            top: 104px" type="text" />
    </asp:Panel>
</asp:Content>

