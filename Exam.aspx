<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Exam" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Finalize" style="left: 92px; position: absolute; top: 34px; z-index: 100;" Width="53px" Visible="False" />
        &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SYARACONN %>" OnSelecting="SqlDataSource1_Selecting" DeleteCommand="DELETE FROM ratio WHERE (exname = N'qwertyuiop09876543211qaz2ws3ed4rfv5tgb6yhn')">
        </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label17" runat="server" Text="Label" ForeColor="White"></asp:Label>&nbsp;&nbsp;
        &nbsp;
        
      
 
      
        <asp:HiddenField ID="hdType" runat="server" Visible="False" />
        &nbsp;
        <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
    
    </div>
        <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
        <br />
        <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;
        <br />
        <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>&nbsp;<br />
        <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="X-Large" Text="00:00:00" style="left: -18px; position: absolute; top: 8px; z-index: 102;" Width="89px" Visible="False"></asp:Label>
        <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="X-Large" Style="z-index: 102;
            left: -18px; position: absolute; top: 8px" Text="00:00:00" Visible="False" Width="89px"></asp:Label>
        &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" Visible="False" />
        <table style="z-index: 104; left: 4px; width: 314px; position: absolute; top: 1px">
            <tr>
                <td style="width: 140px; height: 61px">
                    <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="Small" Style="z-index: 103;
                        left: 701px; position: absolute; top: 41px" Text="Time remaining" Width="85px" Visible="False"></asp:Label>
                    &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="X-Large" Style="z-index: 101;
            left: 772px; position: absolute; top: 31px" Text="00:00:00" Width="89px" Visible="False"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                    &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label18" runat="server" Font-Italic="True" Font-Names="Calibri" Font-Size="Medium"
            ForeColor="Red" Text="This page is for viewing purposes only. Time function has been disabled."
            Visible="False" Width="475px"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/InsCreateExam.aspx"
            Style="font-size: medium; left: 170px; color: black; font-family: Calibri;
            top: 35px;" Visible="False">Go back to Tests</asp:LinkButton>
                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Time remaining"
                        Width="85px" Visible="False"></asp:Label><asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="X-Large" Text="00:00:00" Width="89px" Visible="False"></asp:Label><asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Width="873px" AutoGenerateColumns="False" OnRowCreated="GridView1_RowCreated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ques_id" AllowPaging="True" OnUnload="GridView1_Unload" OnDataBound="GridView1_DataBound" OnDataBinding="GridView1_DataBinding" OnInit="GridView1_Init" OnLoad="GridView1_Load" OnPageIndexChanged="GridView1_PageIndexChanged1" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="ques_id" SortExpression="ques_id">
                    <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ques_id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <?xml namespace="" ns="urn:schemas-microsoft-com:vml" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <?xml namespace="" prefix="v" ?>
                        <v:shapetype id="Shapetype1" coordsize="21600,21600" filled="f" o:preferrelative="t"
                            o:spt="75" path="m@4@5l@4@11@9@11@9@5xe" stroked="f">&nbsp;<BR /><BR /><BR /><BR /><BR /><asp:Label style="LEFT: 64px; TEXT-TRANSFORM: none; POSITION: absolute; TOP: 51px; TEXT-ALIGN: center" id="Label2" runat="server" Width="752px" Text="SAMPLE EXAMINATION" ForeColor="Black" Font-Size="X-Large" Font-Names="Berlin Sans FB Demi" Height="49px" __designer:wfdid="w94"></asp:Label><BR /><v:stroke joinstyle="miter"></v:stroke><v:formulas><v:f eqn="if lineDrawn pixelLineWidth 0"></v:f><v:f eqn="sum @0 1 0"></v:f><v:f eqn="sum 0 0 @1"></v:f><v:f eqn="prod @2 1 2"></v:f><v:f eqn="prod @3 21600 pixelWidth"></v:f><v:f eqn="prod @3 21600 pixelHeight"></v:f><v:f eqn="sum @0 0 1"></v:f><v:f eqn="prod @6 1 2"></v:f><v:f eqn="prod @7 21600 pixelWidth"></v:f><v:f eqn="sum @8 21600 0"></v:f><v:f eqn="prod @7 21600 pixelHeight"></v:f><v:f eqn="sum @10 21600 0"></v:f></v:formulas><v:path o:extrusionok="f" gradientshapeok="t" o:connecttype="rect"></v:path><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:lock v:ext="edit" aspectratio="t"><TABLE style="LEFT: 67px; WIDTH: 743px; POSITION: absolute; TOP: 133px; HEIGHT: 6px" id="TABLE1" onclick="return TABLE1_onclick()"><TBODY><TR><TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 166px; BORDER-BOTTOM: black 1px solid; HEIGHT: 21px"><asp:Label style="FONT-WEIGHT: normal; FONT-SIZE: 12pt; LEFT: 46px; FONT-FAMILY: 'Arial Rounded MT Bold'; POSITION: static; TOP: 210px; TEXT-ALIGN: center" id="lblCourse" runat="server" Width="142px" Text="CS199L" ForeColor="Black" __designer:wfdid="w95"></asp:Label>&nbsp;&nbsp;&nbsp; </TD><TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 150px; BORDER-BOTTOM: black 1px solid; HEIGHT: 21px"><asp:Label style="FONT-WEIGHT: normal; FONT-SIZE: 12pt; LEFT: 46px; FONT-FAMILY: 'Arial Rounded MT Bold'; POSITION: static; TOP: 210px; TEXT-ALIGN: center" id="lblTitle" runat="server" Width="441px" Text="CAPSTONE PROJECT" ForeColor="Black" __designer:wfdid="w96"></asp:Label></TD><TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 110px; BORDER-BOTTOM: black 1px solid; HEIGHT: 21px"><asp:Label style="FONT-WEIGHT: normal; FONT-SIZE: 12pt; LEFT: 46px; FONT-FAMILY: 'Arial Rounded MT Bold'; POSITION: static; TOP: 210px; TEXT-ALIGN: center" id="lblTerm" runat="server" Width="91px" Text="B52" ForeColor="Black" __designer:wfdid="w97"></asp:Label></TD></TR><TR><TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 166px; BORDER-BOTTOM: black 1px solid; HEIGHT: 18px; BACKGROUND-COLOR: activeborder"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; LEFT: 46px; FONT-FAMILY: 'Arial Narrow'; POSITION: static; TOP: 210px; TEXT-ALIGN: center" id="Label4" runat="server" Width="142px" Text="COURSE CODE" ForeColor="Black" Font-Size="Small" Font-Names="Arial Narrow" __designer:wfdid="w98"></asp:Label></TD><TD style="BORDER-RIGHT: background 1px solid; BORDER-TOP: background 1px solid; BORDER-LEFT: background 1px solid; WIDTH: 150px; BORDER-BOTTOM: background 1px solid; HEIGHT: 18px; BACKGROUND-COLOR: activeborder"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; LEFT: 46px; FONT-FAMILY: 'Arial Narrow'; POSITION: static; TOP: 210px; TEXT-ALIGN: center" id="Label5" runat="server" Width="441px" Text="COURSE TITLE" ForeColor="Black" Font-Size="Small" Font-Names="Arial Narrow" __designer:wfdid="w99" Font-Overline="False"></asp:Label></TD><TD style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; HEIGHT: 18px; BACKGROUND-COLOR: activeborder"><asp:Label style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; LEFT: 46px; FONT-FAMILY: 'Arial Narrow'; POSITION: static; TOP: 210px; TEXT-ALIGN: center" id="Label3" runat="server" Width="93px" Text="Section" ForeColor="Black" Font-Size="Small" Font-Names="Arial Narrow" __designer:wfdid="w100"></asp:Label>&nbsp;&nbsp;&nbsp; </TD></TR></TBODY></TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR /><BR />&nbsp;<asp:Label style="FONT-WEIGHT: normal; FONT-SIZE: large; LEFT: 240px; COLOR: #006699; FONT-FAMILY: Calibri; POSITION: absolute; TOP: 198px; TEXT-ALIGN: center" id="lblName" runat="server" Width="439px" Text="LASTNAME, FIRSTNAME (MIDDLENAME)" ForeColor="Black" Font-Bold="True" __designer:wfdid="w101"></asp:Label>&nbsp;<asp:ImageButton style="LEFT: 70px; POSITION: absolute; TOP: 230px; BACKGROUND-COLOR: transparent" id="ImageButton3" __designer:dtid="844433520066576" runat="server" Width="726px" Height="2px" Enabled="False" __designer:wfdid="w102" ImageUrl="~/Images/guhit.png"></asp:ImageButton><BR /><BR /><BR /></o:lock></v:shapetype>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="font-size: small; width: 895px; font-family: Calibri; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; background-color: #ffffff;">
                            <tr>
                                <td colspan="1" style="width: 279px; height: 19px">
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Eval("l_o") %>' Width="30px" style="vertical-align: top; letter-spacing: normal; text-align: left"></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Height="20px"
                                        Style="vertical-align: text-top; letter-spacing: normal" Text='<%# Bind("pt") %>'
                                        Width="11px"></asp:Label><asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="Small"
                                            Height="19px" Style="vertical-align: text-top; letter-spacing: normal" Text="pt(s)"
                                            Width="26px"></asp:Label></td>
                                <td colspan="2" style="width: 502px; height: 19px">
                                   <%# Container.DataItemIndex + 1 %>.<asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Medium" Text='<%# Bind("ques_desc") %>' Height="19px" Width="757px" style="vertical-align: text-top; letter-spacing: normal"></asp:Label>
                                </td>
                                <td colspan="1" style="height: 19px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 279px">
                                    </td>
                                <td colspan="1">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" Height="195px" Visible="False"
                                        Width="291px" />
                                    <asp:HiddenField ID="qid" runat="server" OnValueChanged="StudAns_ValueChanged" Value='<%# Eval("ques_id") %>' />
                                    <asp:HiddenField ID="Cor" runat="server" Value='<%# Eval("ans_a") %>' />
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("imgLoc") %>' />
                                    <asp:HiddenField ID="StudAns" runat="server" OnValueChanged="StudAns_ValueChanged" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 279px; height: 22px">
                                    </td>
                                <td style="width: 382px; height: 22px">
                                    <asp:Label ID="lblqid" runat="server" Font-Bold="False" Font-Size="Medium" OnDataBinding="lblqid_DataBinding"
                                        Text='<%# Bind("ques_id") %>' Visible="False"></asp:Label>
                                    <asp:RadioButton ID="AA" runat="server" GroupName="sel" AutoPostBack="True" OnCheckedChanged="txtA_CheckedChanged" Visible="False" />
                                    <table style="width: 429px">
                                        <tr>
                                            <td style="height: 22px; width: 785px;">
                                                <asp:RadioButton ID="txtA" runat="server" GroupName="sel" OnCheckedChanged="txtA_CheckedChanged" Font-Size="Small" Width="845px" />
                                                <asp:TextBox ID="TextBox2" runat="server" BackColor="#E0E0E0"
                                                    BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" OnTextChanged="TextBox2_TextChanged"
                                                    Style="background-color: silver" Visible="False" Width="301px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 785px">
                                    <asp:RadioButton ID="txtB" runat="server" GroupName="sel" OnCheckedChanged="txtB_CheckedChanged" Width="845px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px; width: 785px;">
                                    <asp:RadioButton ID="txtC" runat="server" GroupName="sel" OnCheckedChanged="txtC_CheckedChanged" Width="845px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 785px">
                                    <asp:RadioButton ID="txtD" runat="server" GroupName="sel" OnCheckedChanged="txtD_CheckedChanged" Width="846px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px; width: 785px;">
                                    <asp:RadioButton ID="txtE" runat="server" GroupName="sel" OnCheckedChanged="txtE_CheckedChanged" Width="844px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 785px">
                                    <asp:RadioButton ID="txtF" runat="server" GroupName="sel" OnCheckedChanged="txtF_CheckedChanged" Width="61px" />
                                    <asp:RadioButton ID="txtG" runat="server" GroupName="sel" OnCheckedChanged="txtG_CheckedChanged" Width="63px" />
                                    <asp:RadioButton ID="txtH" runat="server" GroupName="sel" OnCheckedChanged="txtH_CheckedChanged" Width="63px" />
                                    <asp:RadioButton ID="txtI" runat="server" GroupName="sel" OnCheckedChanged="txtI_CheckedChanged" Width="59px" />
                                    <asp:RadioButton ID="txtJ" runat="server" GroupName="sel" OnCheckedChanged="txtJ_CheckedChanged" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ControlStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <span style="font-family: Segoe UI Symbol">
                ERROR. PLEASE CONTACT THE ADMINISTRATOR
                    <asp:Button ID="Button4" runat="server" PostBackUrl="~/Exam.aspx" Text="Refresh"
                        Width="87px" /></span>
            </EmptyDataTemplate>
            <RowStyle BorderColor="White" BackColor="White" ForeColor="#333333" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#404040" Font-Names="Calibri" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="Black" />
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 140px; height: 21px; display: block;">
        <asp:Button ID="Button3" runat="server" OnClick="new" Text="Finalize" Width="60px" OnCommand="Button3_Command" OnDisposed="Button3_Disposed" Visible="False" />
        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Red" OnClick="Button1_Click12"
            Style="font-size: medium; color: red; font-family: Calibri;" Width="390px">Are you sure that you want to finalize? Please click this link</asp:LinkButton>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>
  <script type="text/javascript" src="CountDown.js"></script>
<script type="text/javascript">
window.onload=WindowLoad;
function WindowLoad(event) 
{   



}
function TABLE1_onclick() 
{

}

</script>

<%--  <script type="text/javascript" src="CountDown2.js"></script>
<script type="text/javascript">
window.onload=WindowLoad;
function WindowLoad(event) 
{   

ActivateCountDown("Label15", <%=Label13.Text%> );
ActivateCountDown("Label19", <%=Label12.Text%> );
ActivateCountDown("Label15", <%=Label13.Text%> );
}
function TABLE1_onclick() 
{

}

</script>--%>
    </form>
</body>
</html>
