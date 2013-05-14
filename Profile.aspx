<%@ Page Language="C#" MasterPageFile="~/active.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="_Default" Title="Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp;
    <asp:Label ID="Label1" runat="server" Style="left: 224px; color: buttonface; font-family: 'Lucida Sans';
        position: absolute; top: 499px" Text="Courses currently registered:"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" Font-Size="X-Small"
        ForeColor="Black" GridLines="Vertical" Style="left: 243px; font-family: 'Lucida Sans';
        position: absolute; top: 547px" Width="490px">
        <Columns>
            <asp:TemplateField HeaderText="Course">
                <FooterStyle Width="150px" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weighted Average">
                <ItemStyle Width="50px" />
            </asp:TemplateField>
            <asp:HyperLinkField>
                <ItemStyle Width="100px" />
            </asp:HyperLinkField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#CCCCCC" />
    </asp:GridView>
    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" Height="187px"
        ImageUrl="~/Images/tabla5.png" Style="left: 208px; position: absolute; top: 259px;
        background-color: transparent" Width="540px" />
    <asp:Image ID="Image1" runat="server" Height="125px" Style="left: 235px; position: absolute;
        top: 286px" Width="125px" ImageUrl="~/Images/tabla4.png" />
    <asp:Label ID="lblStudname" runat="server" Style="left: 387px; color: limegreen; font-family: 'Lucida Sans';
        position: absolute; top: 290px" Text="Surname, Firstname (Middlename)" Font-Size="Larger"></asp:Label>
    <asp:Label ID="lblStudnum" runat="server" Style="left: 388px; color: white; font-family: 'Lucida Sans';
        position: absolute; top: 322px" Text="2007100000" ForeColor="White"></asp:Label>
    <asp:Label ID="lblProg" runat="server" Style="left: 388px; color: appworkspace; font-family: 'Lucida Sans';
        position: absolute; top: 351px" Text="BSIT" ForeColor="White"></asp:Label>
</asp:Content>

