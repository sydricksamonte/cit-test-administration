<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="AdTerm.aspx.cs" Inherits="Images_AdUsers" Title="CIT Examination System | Maintenance | Term" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp; &nbsp;
    <asp:Panel ID="Panel2" runat="server" Height="158px" Style="font-size: small; left: 380px;
        color: #ffffff; font-family: 'Lucida Sans'; position: absolute; top: 111px; z-index: 100;" Width="336px">
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox9"
            ErrorMessage="The school year is invalid!" SetFocusOnError="True" Style="z-index: 100;
            left: 0px; position: absolute; top: 0px" ValidationExpression="\d{4}" ValidationGroup="ins"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="The school year is invalid!" SetFocusOnError="True" Style="z-index: 114;
            left: 0px; position: absolute; top: 0px" ValidationExpression="\d{4}" ValidationGroup="ins"></asp:RegularExpressionValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px" style="left: -294px; position: absolute; top: 72px; z-index: 102;" ForeColor="Red" Visible="False"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="208px"
            ImageUrl="~/Images/tabla4.png" Style="left: -153px; position: absolute; top: 27px;
            background-color: transparent; z-index: 103;" Width="578px" ValidationGroup="aa" />
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox9"
            ErrorMessage="*" Style="left: 63px; position: absolute; top: 81px; z-index: 104;" ValidationGroup="ins">*</asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
            ErrorMessage="*" Style="left: 135px; position: absolute; top: 80px; z-index: 105;" ValidationGroup="ins">*</asp:RequiredFieldValidator>
        &nbsp;
        <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: 74px; position: absolute; top: 121px; z-index: 106;" Text="School Year"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: -136px; position: absolute; top: 37px; z-index: 107;" Text="Current Term:"></asp:Label>
        &nbsp;
        <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="9px"
            Style="left: 170px; position: absolute; top: 121px; z-index: 108;" Text="/ Term"></asp:Label>
        &nbsp;
        <asp:Label ID="Label8" runat="server" Font-Size="Larger" Style="left: 79px; color: limegreen;
            position: absolute; top: 60px; z-index: 109;" Text="Change Term"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Size="Larger" Style="font-size: medium;
            left: -39px; color: limegreen; font-family: Calibri; position: absolute; top: 38px; z-index: 110;"
            Text="2011-2012 1/T"></asp:Label>
        &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox9" runat="server" BackColor="Gainsboro" BorderStyle="None"
            Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" MaxLength="4" Style="left: 32px;
            position: absolute; top: 96px; z-index: 111;" Text='<%# Bind("user_na") %>' ValidationGroup="ins"
            Width="72px" OnTextChanged="TextBox9_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server" BackColor="Gainsboro" BorderStyle="None"
            Font-Size="Small" ForeColor="ActiveCaptionText" Height="15px" MaxLength="4" Style="left: 109px;
            position: absolute; top: 96px; z-index: 112;" Text='<%# Bind("user_na") %>' ValidationGroup="ins"
            Width="72px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="ins" Text="Change" ToolTip="ins" ValidationGroup="ins"
                        Width="94px" style="left: 95px; position: absolute; top: 178px; z-index: 113;" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString32 %>"
            SelectCommand="SELECT [course_id] FROM [course_data]"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>
    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="left: 148px; position: absolute; top: 408px; background-color: transparent; z-index: 101;"
        Width="726px" />
    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Style="font-size: medium;
        left: 349px; position: absolute; top: 430px; z-index: 102;" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 104; left: 566px;
        position: absolute; top: 204px">
        <asp:ListItem>1T</asp:ListItem>
        <asp:ListItem>2T</asp:ListItem>
        <asp:ListItem>3T</asp:ListItem>
        <asp:ListItem>4T</asp:ListItem>
    </asp:DropDownList>
</asp:Content>

