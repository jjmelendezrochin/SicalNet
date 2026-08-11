<%@ Page language="c#" Codebehind="ColorWOReport.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.PartidasColor.ColorWOReport1" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ColorWOReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ColorWOReport" method="post" runat="server">
			<table align="center" width="700">
				<tbody>
					<tr>
						<td align="middle">
						<CR:CrystalReportViewer id="ColorRpt" runat="server" Height="50px" Width="350px"></CR:CrystalReportViewer>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
