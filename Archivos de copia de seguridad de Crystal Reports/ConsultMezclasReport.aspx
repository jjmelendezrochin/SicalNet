<%@ Page language="c#" Codebehind="ConsultMezclasReport.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ConsultMezclasReport" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultMezclasReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultMezclasReport" method="post" runat="server">
			<CR:CrystalReportViewer id="CRViewer" style="Z-INDEX: 101; LEFT: 27px; POSITION: absolute; TOP: 17px" runat="server"></CR:CrystalReportViewer>
		</form>
	</body>
</HTML>
