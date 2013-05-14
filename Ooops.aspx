<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ooops.aspx.cs" Inherits="Ooops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OOoops!</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" BorderColor="#404040" Font-Bold="True" Font-Names="Calibri"
            Font-Size="XX-Large" ForeColor="DimGray" Style="z-index: 100; left: 495px; position: absolute;
            top: 227px" Text="Sorry!"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
            ForeColor="Gray" Style="z-index: 101; left: 369px; position: absolute; top: 291px"
            Text="The server could not connect to the internet"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Calibri" Font-Size="Large"
            ForeColor="Gray" Style="z-index: 103; left: 454px; position: absolute; top: 337px"
            Text="Please try again later."></asp:Label>
    
    </div>
    </form>
</body>
</html>
