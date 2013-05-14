a<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Crystal_Classlist.aspx.cs" Inherits="Classlist_crystal" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Documents and Reports</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            OnInit="CrystalReportViewer1_Init" style="position: absolute" Height="1039px" ReportSourceID="CrystalReportSource1" Width="901px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
        <asp:Button ID="Button1" runat="server" Enabled="False" Style="left: 0px; font-family: Calibri; position: absolute; top: 2px" Text="Exam view" Font-Size="Medium" Height="29px" Width="102px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="left: 106px; font-family: Calibri; position: absolute; top: 2px" Text="Answer key" Font-Size="Medium" Height="29px" Width="110px" />
        <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Calibri" Font-Size="Medium"
            ForeColor="#404040" PostBackUrl="~/InsReports.aspx" Style="left: 714px; position: absolute;
            top: 4px; font-size: small;" Width="198px">Back to Reports & Documents</asp:LinkButton>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="classlist.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
