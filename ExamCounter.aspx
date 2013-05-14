<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamCounter.aspx.cs" Inherits="Exam" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
</head>
<body style="background-color: white">
    <form id="form1" runat="server">
    <div>
       
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    
    </div>
        &nbsp; &nbsp;<br />
        &nbsp;<br />
        &nbsp;&nbsp;
                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" Style="z-index: 103;
                        left: 690px; position: absolute; top: 10px" Text="Time remaining" Width="85px"></asp:Label>
        <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="X-Large" Style="z-index: 101;
            left: 784px; position: absolute; top: 4px" Text="00:00:00" Width="89px"></asp:Label>
        &nbsp; &nbsp;<br />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;<br />
  <script type="text/javascript" src="CountDown.js"></script>

        <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="X-Large" Style="z-index: 101;
            left: 152px; position: absolute; top: 265px" Text="00:00:00" Width="89px"></asp:Label>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/mcl.png" Style="left: 34px;
            position: absolute; top: 11px" />
<script type="text/javascript">
window.onload=WindowLoad;
function WindowLoad(event) 
{   



}
function TABLE1_onclick() 
{

}

</script>

  <script type="text/javascript" src="CountDown2.js"></script>
<script type="text/javascript">
window.onload=WindowLoad;
function WindowLoad(event) 
{   

ActivateCountDown("Label19", <%=Label13.Text%> );

}
function TABLE1_onclick() 
{

}

</script>
    </form>
</body>
</html>
