<%@ Page Language="C#" AutoEventWireup="true" CodeFile="creator.aspx.cs" Inherits="creator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" EditIndex="1"
            ForeColor="Black" GridLines="Vertical" Height="420px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            PageSize="40" Style="left: 86px; position: absolute; top: 216px" Width="774px">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemStyle Width="5px" />
                    <ItemTemplate>
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Correct" />
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
