<%@ Page Language="C#" MasterPageFile="~/Instructor.master" AutoEventWireup="true" CodeFile="Classlists.aspx.cs" Inherits="_Default" Title="CIT Examination System | Classlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="185px" Style="left: 218px; position: absolute; top: 393px;
        background-color: transparent; z-index: 100;" Width="540px" ImageUrl="~/Images/tabla5.png" /><asp:ImageButton ID="ImageButton4" runat="server" Enabled="False" Height="187px"
        ImageUrl="~/Images/tabla5.png" Style="left: 224px; position: absolute; top: 165px;
        background-color: transparent; z-index: 101;" Width="540px" />
    <asp:Label ID="Label7" runat="server" ForeColor="White" Style="font-size: small;
        left: 306px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 264px; z-index: 102;"
        Text="Select Section:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Size="Larger" Style="left: 238px; color: limegreen;
        font-family: 'Lucida Sans'; position: absolute; top: 400px; z-index: 103;" Text="Upload Classlist"></asp:Label>
    <asp:Label ID="Label14" runat="server" Font-Size="Larger" Style="left: 235px; color: limegreen;
        font-family: 'Lucida Sans'; position: absolute; top: 168px; z-index: 104;" Text="Show Classlist"></asp:Label>
    <asp:Label ID="lblStudnum" runat="server" ForeColor="White" Style="font-size: small;
        left: 247px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 408px; z-index: 105;"
        Text="Add Classlist from other source (Excel File)" Height="33px" Width="135px" Visible="False"></asp:Label>
    <asp:Label ID="Label11" runat="server" ForeColor="Red" Height="9px" Style="font-size: small;
        left: 395px; font-family: Calibri; position: absolute; top: 383px; z-index: 106;" Text="Choose a file first!"
        Visible="False" Width="352px"></asp:Label>
    <asp:Label ID="Label12" runat="server" ForeColor="Red" Height="9px" Style="font-size: small;
        left: 218px; font-family: Calibri; position: absolute; top: 346px; z-index: 107;" Visible="False"
        Width="352px"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" ForeColor="White" Style="font-size: small;
        left: 308px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 231px; z-index: 108;"
        Text="Select Course"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="lblProg" runat="server" ForeColor="White" Height="21px" Style="font-size: small;
        left: 359px; color: appworkspace; font-style: italic; font-family: 'Lucida Sans';
        position: absolute; top: 455px; z-index: 109;" Text="Supported files is Microsoft Excel 1997-2001"
        Width="286px" Visible="False"></asp:Label>
    <asp:Label ID="Label13" runat="server" ForeColor="White" Height="242px" Style="font-size: small;
        left: 761px; color: buttonface; font-style: italic; font-family: 'Lucida Sans';
        position: absolute; top: 333px; z-index: 110;"
        Visible="False" Width="114px"></asp:Label>
    <asp:Label ID="Label5" runat="server" ForeColor="White" Height="46px" Style="font-size: small;
        left: 248px; color: appworkspace; font-style: italic; font-family: 'Lucida Sans';
        position: absolute; top: 193px; z-index: 111;" Text="Open classlist or create classlist manually."
        Width="354px"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" Style="left: 362px; position: absolute;
        top: 470px; z-index: 112;" />
    <asp:ImageButton ID="ImageButton2" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" Style="left: 231px; position: absolute; top: 511px; z-index: 113;"
        Width="119px" OnClick="ImageButton2_Click" Visible="False" />
    <asp:ImageButton ID="ImageButton3" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" Style="left: 431px; position: absolute; top: 298px; z-index: 114;"
        Width="119px" OnClick="ImageButton3_Click" />
    <asp:Label ID="Label2" runat="server" ForeColor="White" Style="font-size: small;
        left: 265px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 516px; z-index: 115;"
        Text="Preview" BorderStyle="None" Enabled="False" AssociatedControlID="ImageButton2" Visible="False"></asp:Label><asp:ImageButton ID="ImageButton5" runat="server" BorderColor="Transparent" Height="36px"
        ImageUrl="~/Images/button.png" Style="left: 430px; position: absolute; top: 521px; z-index: 116;"
        Width="119px" OnClick="ImageButton5_Click" />
    <asp:Label ID="Label8" runat="server" BorderStyle="None" Enabled="False" ForeColor="White"
        Height="9px" Style="font-size: small; left: 476px; color: white; font-family: 'Lucida Sans';
        position: absolute; top: 527px; z-index: 117;" Text="Save" Width="33px" AssociatedControlID="ImageButton5"></asp:Label>
    &nbsp;
    <asp:Label ID="Label4" runat="server" ForeColor="White" Height="14px" Style="font-size: small;
        left: 461px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 303px; z-index: 118;"
        Text="Proceed" AssociatedControlID="ImageButton3"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="drpCourse" runat="server" DataSourceID="SqlDataSource1" DataTextField="course_id"
        DataValueField="course_id" OnDataBound="drpCourse_DataBound" OnSelectedIndexChanged="drpCourse_SelectedIndexChanged"
        Style="left: 420px; position: absolute; top: 229px; z-index: 119;" Width="169px" AutoPostBack="True">
    </asp:DropDownList>
    <asp:DropDownList ID="drpSec" runat="server" Enabled="False" Style="left: 420px;
        position: absolute; top: 262px; z-index: 120;" Width="169px" OnSelectedIndexChanged="drpSec_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MCLCONN %>"
        SelectCommand="SELECT DISTINCT [course_id] FROM [course] WHERE (([sec_handler] = @sec_handler) AND ([term] = @term))" OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:SessionParameter Name="sec_handler" SessionField="user" Type="String" />
            <asp:SessionParameter Name="term" SessionField="term" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4"
        ForeColor="#333333" GridLines="None" Style="font-size: small; left: -417px; font-family: Calibri;
        position: absolute; top: 260px; z-index: 121;" Height="1px" Width="421px" PageSize="25" >
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
    <asp:Label ID="Label9" runat="server" ForeColor="White" Style="font-size: small;
        left: 317px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 540px; z-index: 122;"
        Text="Select Section:" Visible="False"></asp:Label>
    <asp:Label ID="Label10" runat="server" ForeColor="White" Style="font-size: small;
        left: 318px; color: white; font-family: 'Lucida Sans'; position: absolute; top: 509px; z-index: 123;"
        Text="Select Course" Visible="False"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="course_id"
        DataValueField="course_id" OnDataBound="drpCourse2_DataBound" OnSelectedIndexChanged="drpCourse2_SelectedIndexChanged"
        Style="left: 366px; position: absolute; top: 510px; z-index: 124;" Width="99px" AutoPostBack="True" Visible="False">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False" Style="left: 428px;
        position: absolute; top: 537px; z-index: 125;" Width="98px" Visible="False">
    </asp:DropDownList>
    <asp:Panel ID="Panel1" runat="server" Font-Names="Calibri" Font-Size="Medium" Height="81px"
        Style="z-index: 127; left: 204px; position: absolute; top: 343px" Width="276px" Visible="False">
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Style="z-index: 100;
            left: 10px; position: absolute; top: 8px" Text="The classlist you are trying to upload is "
            Width="544px"></asp:Label>
        <asp:Button ID="Button1" runat="server" Style="z-index: 102; left: 410px; position: absolute;
            top: 71px" Text="Add as" Width="258px" OnClick="Button1_Click" Visible="False" />
    </asp:Panel>
</asp:Content>

