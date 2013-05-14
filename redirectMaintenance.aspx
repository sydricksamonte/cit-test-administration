<%@ Page Language="C#" AutoEventWireup="true" CodeFile="redirectMaintenance.aspx.cs" Inherits="redirectMaintenance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Style="font-size: x-large; font-family: Calibri"
            Text="Access denied. This is a restricted page."></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go back to home page"
            Width="142px" /></div>
    </form>
</body>
</html>
