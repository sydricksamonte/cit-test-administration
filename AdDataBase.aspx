<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdDataBase.aspx.cs" Inherits="Images_AdUsers" Title="CIT Examination System | Maintenance | Term" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp; &nbsp;
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 380px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 111px" Width="336px">
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="208px"
            ImageUrl="~/Images/tabla4.png" Style="left: -153px; position: absolute; top: 27px;
            background-color: transparent" Width="578px" />
        <asp:Panel ID="Panel4" runat="server" Height="2px" Style="left: -117px; position: absolute;
            top: 80px" Width="514px">
            <asp:RadioButton ID="RadioButton3" runat="server" Checked="True" Font-Bold="False"
                ForeColor="MediumSeaGreen" GroupName="tty" Style="font-size: medium; font-family: Calibri"
                Text="Create a back up of database everytime I login" /><br />
            <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="False" ForeColor="MediumSeaGreen"
                GroupName="tty" Style="font-size: medium;
                font-family: Calibri" Text="Create a back up of database everyday" /><br />
            <asp:RadioButton ID="RadioButton4" runat="server" Font-Bold="False" ForeColor="MediumSeaGreen"
                GroupName="tty" Style="font-size: medium; font-family: Calibri" Text="Don't back up." /><br />
            <br />
        </asp:Panel>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: -136px; position: absolute; top: 39px" Text="Database Settings"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server"  Text="Change" ToolTip="ins" ValidationGroup="ins"
                        Width="94px" style="left: 95px; position: absolute; top: 178px" OnClick="Button1_Click1" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString32 %>"
            SelectCommand="SELECT [course_id] FROM [course_data]"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 148px; position: absolute; top: 408px; background-color: transparent"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 349px; position: absolute; top: 430px" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
</asp:Content>

