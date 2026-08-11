<%@ Page language="c#" Codebehind="FrmColorConsumption.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.FrmColorConsumption" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FrmColorConsumption</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="FrmColorConsumption" method="post" runat="server">
			<CR:CrystalReportViewer id="CRCConsumption" style="Z-INDEX: 101; LEFT: 9px; POSITION: absolute; TOP: 11px" runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer>
		</form>
	</body>
</HTML>
