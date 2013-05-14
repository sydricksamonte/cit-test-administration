<%@ Page Language="C#" MasterPageFile="~/Maintenance.master" AutoEventWireup="true" CodeFile="Facultylists.aspx.cs" Inherits="_Default" Title="CIT Examination System | Classlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="185px" Style="left: 224px; position: absolute; top: 366px;
        background-color: transparent; z-index: 100;" Width="540px" ImageUrl="~/Images/tabla4.png" /><asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="187px"
        ImageUrl="~/Images/tabla4.png" Style="left: 224px; position: absolute; top: 165px;
        background-color: transparent; z-index: 101;" Width="540px" />
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Size="Larger" Style="left: 238px; color: limegreen;
        font-family: 'Lucida Sans'; position: absolute; top: 386px; z-index: 102;" Text="Upload faculty course load"></asp:Label>
    <asp:Label ID="Label14" runat="server" Font-Size="Larger" Style="left: 242px; color: limegreen;
        font-family: 'Lucida Sans'; position: absolute; top: 176px; z-index: 103;" Text="Faculty course load"></asp:Label>
    <asp:Label ID="lblStudnum" runat="server" ForeColor="White" Style="font-size: small;
        left: 247px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 408px; z-index: 104;"
        Text="Add Classlist from other source (Excel File)" Height="33px" Width="135px" Visible="False"></asp:Label>
    &nbsp; &nbsp;
    &nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" ForeColor="White" Style="font-size: small;
        left: 277px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 214px; z-index: 105;"
        Text="Select a faculty member:"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="lblProg" runat="server" ForeColor="White" Height="21px" Style="font-size: small;
        left: 359px; color: appworkspace; font-style: italic; font-family: 'Lucida Sans';
        position: absolute; top: 455px; z-index: 106;" Text="Supported files is Microsoft Excel 1997-2001"
        Width="286px" Visible="False"></asp:Label>
    <asp:Label ID="Label13" runat="server" ForeColor="White" Height="242px" Style="font-size: small;
        left: 761px; color: buttonface; font-style: italic; font-family: 'Lucida Sans';
        position: absolute; top: 333px; z-index: 107;"
        Visible="False" Width="114px"></asp:Label>
    &nbsp;
    <asp:FileUpload ID="FileUpload1" runat="server" Style="left: 360px; position: absolute;
        top: 452px; z-index: 108;" />
    <asp:ImageButton ID="ImageButton2" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" Style="left: 231px; position: absolute; top: 511px; z-index: 109;"
        Width="119px" OnClick="ImageButton2_Click" Visible="False" />
    <asp:ImageButton ID="ImageButton3" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" Style="left: 431px; position: absolute; top: 298px; z-index: 110;"
        Width="119px" OnClick="ImageButton3_Click" />
    <asp:Label ID="Label2" runat="server" ForeColor="White" Style="font-size: small;
        left: 265px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 516px; z-index: 111;"
        Text="Preview" BorderStyle="None" AssociatedControlID="ImageButton2" Visible="False"></asp:Label><asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" Style="left: 431px; position: absolute; top: 503px; z-index: 112;"
        Width="119px" OnClick="ImageButton5_Click" />
    <asp:Label ID="Label8" runat="server" BorderStyle="None" Enabled="False" ForeColor="White"
        Height="9px" Style="font-size: small; left: 477px; color: white; font-family: 'Lucida Sans';
        position: absolute; top: 509px; z-index: 113;" Text="Save" Width="33px" AssociatedControlID="ImageButton5"></asp:Label>
    &nbsp;
    <asp:Label ID="Label4" runat="server" ForeColor="White" Height="14px" Style="font-size: small;
        left: 461px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 303px; z-index: 114;"
        Text="Open" AssociatedControlID="ImageButton3"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="drpCourse" runat="server" DataTextField="fname"
        DataValueField="user_id" OnDataBound="drpCourse_DataBound" OnSelectedIndexChanged="drpCourse_SelectedIndexChanged"
        Style="left: 336px; position: absolute; top: 253px; z-index: 115;" Width="322px">
    </asp:DropDownList>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:JOELCONN %>"
        SelectCommand="SELECT fname, lname, bname, user_id FROM user_table WHERE (type = @type)" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter DefaultValue="Faculty" Name="type" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:ImageButton ID="ImageButton6" runat="server" Enabled="False" Height="2px" ImageUrl="~/Images/guhit.png"
        Style="z-index: 116; left: 144px; position: absolute; top: 575px; background-color: transparent"
        Width="726px" />
    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Style="font-size: medium;
        z-index: 117; left: 287px; position: absolute; top: 585px" Text="All Rights Reserved. © 2011 Malayan Colleges Laguna"></asp:Label>
    <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Style="font-size: medium;
        z-index: 118; left: -387px; position: absolute; top: 595px" Text="."></asp:Label>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4"
        ForeColor="#333333" GridLines="None" Style="font-size: small; left: -659px; font-family: Calibri;
        position: absolute; top: 18px; z-index: 119;" Height="1px" Width="659px" PageSize="25" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle"
            Wrap="True" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" CssClass="HeaderStyle" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="sss1TableAdapters.DataTable1TableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="sss1TableAdapters.DataTable1TableAdapter"></asp:ObjectDataSource>
    <asp:LinkButton ID="LinkButton1" runat="server" Font-Italic="True" Font-Names="Calibri"
        Font-Size="Medium" ForeColor="Red" Style="z-index: 121; left: 137px; position: absolute;
        top: 122px"></asp:LinkButton>
    &nbsp;
    &nbsp;&nbsp;
</asp:Content>

