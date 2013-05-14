<%@ Page Language="C#" MasterPageFile="~/blank_dual.master" AutoEventWireup="true" CodeFile="ExamsStud.aspx.cs" Inherits="_Default" Title="CIT Exam System | Take Exam" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CIT examsConnectionString22 %>"
        SelectCommand="SELECT * FROM [exam_results] WHERE (([user_id] = @user_id) AND ([section] = @section) AND ([course] = @course) AND ([d_taken] = @d_taken))" ProviderName="<%$ ConnectionStrings:CIT examsConnectionString22.ProviderName %>">
        <SelectParameters>
            <asp:SessionParameter Name="user_id" SessionField="user" Type="String" />
            <asp:SessionParameter Name="section" SessionField="section" Type="String" />
            <asp:SessionParameter Name="course" SessionField="course" Type="String" />
            <asp:Parameter DefaultValue="NOT TAKEN" Name="d_taken" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Images/tabla9.png" Height="269px"
        Style="left: 392px; position: absolute; top: 0px" Width="270px" BackColor="Transparent">
        &nbsp; &nbsp;
        <asp:Panel ID="Panel2" runat="server" Height="72px" Style="left: 14px; position: absolute;
            top: 173px" Width="237px">
            <asp:Label ID="Label4" runat="server" Font-Size="Small" Style="font-size: medium;
                left: 31px; font-family: Calibri; position: absolute; top: 12px" Text="Item/s available for retake:"></asp:Label>
            <asp:Button ID="Button1" runat="server" Style="left: 168px; font-family: Calibri;
        position: absolute; top: 35px" Text="Take now" OnClick="Button77_Click" Height="24px" Width="66px" />
            <asp:DropDownList ID="DropDownList2" runat="server"
        Style="left: 15px; position: absolute; top: 34px" Width="150px" OnDataBound="DropDownList1_DataBound" OnLoad="DropDownList1_Load" OnPreRender="DropDownList1_PreRender" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Names="Calibri" Font-Size="Medium">
            </asp:DropDownList>
        </asp:Panel>
        <asp:Label ID="Label1" runat="server" Font-Size="Small" Style="font-size: medium;
            left: 46px; font-family: Calibri; position: absolute; top: 157px" Text="No exam(s) found."
            Visible="False"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Height="97px" Style="left: 390px; position: absolute;
        top: 9px" Visible="False" Width="246px">
        <asp:Button ID="Button2" runat="server" Style="left: 73px; font-family: Calibri;
        position: absolute; top: 120px" Text="Take now" OnClick="Button1_Click" Height="29px" Width="119px" />
    <asp:Label ID="Label2" runat="server" ForeColor="Red" Style="font-size: small; left: 72px;
        color: red; font-family: Calibri; position: absolute; top: 36px" Text="Please select an item!"
        Visible="False"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server"
        Style="left: 29px; position: absolute; top: 90px" Width="213px" OnDataBound="DropDownList1_DataBound" OnLoad="DropDownList1_Load" OnPreRender="DropDownList1_PreRender" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Names="Calibri" Font-Size="Medium">
        </asp:DropDownList>
        <asp:Label ID="Label5" runat="server" Font-Size="Small" Style="font-size: medium;
            left: 59px; font-family: Calibri; position: absolute; top: 61px" Text="Select an item to start"></asp:Label>
        <asp:ImageButton ID="ImageButton2s" runat="server" BackColor="Transparent" Enabled="False"
            Height="279px" ImageAlign="Left" ImageUrl="~/Images/logo_new.png" PostBackUrl="~/InsHome.aspx"
            Style="left: -230px; position: absolute; top: -69px" Width="200px" />
    </asp:Panel>
   
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" ForeColor="DarkGreen" Text="."></asp:Label>
</asp:Content>

