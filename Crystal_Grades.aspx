a<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Crystal_Grades.aspx.cs" Inherits="Classlist_crystal" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
            OnInit="CrystalReportViewer1_Init" style="position: absolute" Height="1039px" ReportSourceID="CrystalReportSource2" Width="901px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
        <asp:Button ID="Button1" runat="server" Text="Identification Part" />
        <asp:Button ID="Button2" runat="server" Text="True or False Part" />
        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
            <Report FileName="Grades.rpt">
            </Report>
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Grades.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
