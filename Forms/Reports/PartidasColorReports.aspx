<%@ Page language="c#" Codebehind="PartidasColorReports.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.PartidasColorReports1" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PartidasColorReports</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="PartidasColorReports" method="post" runat="server">
			<CR:CrystalReportViewer id="CRColor" style="Z-INDEX: 101; LEFT: -1px; POSITION: absolute; TOP: 1px" runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer>
		</form>
	</body>
</HTML>
