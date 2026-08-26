
<%@ Page language="c#" Codebehind="RastreabilidadRpt.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.RastreabilidadRpt1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RastreabilidadRpt</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="javascript">		
				function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Reportes"
			}	
		</script>
		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ShowTitle()">
		<center>
			<table style="BORDER-COLLAPSE: collapse" width="700" align="center">
				<TBODY>
					<tr>
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
			</table>
			<form id="RastreabilidadRpt" method="post" runat="server">				
				<asp:TextBox id="txtSecuencia" style="Z-INDEX: 100; POSITION: absolute; TOP: 144px; LEFT: 592px"
					runat="server" Width="150px" Height="26px" CssClass="Standard-text" BorderStyle="Groove"></asp:TextBox>
				<asp:Label id="Label2" style="Z-INDEX: 105; POSITION: absolute; TOP: 72px; LEFT: 544px" runat="server"
					Width="269px" Height="13px" CssClass="Standard-text" Font-Bold="True" Font-Size="Medium">Reporte de Rastreabilidad</asp:Label>
				<asp:Button id="btnImprimir" style="Z-INDEX: 101; POSITION: absolute; TOP: 192px; LEFT: 584px"
					runat="server" Width="83px" Height="21px" Text="Imprimir" CssClass="botonesInput"></asp:Button>
				<asp:Button id="btnCancelar" style="Z-INDEX: 102; POSITION: absolute; TOP: 192px; LEFT: 696px"
					runat="server" Width="83px" Height="21px" Text="Cancelar" CssClass="botonesInput"></asp:Button>
				<asp:Label id="Label1" style="Z-INDEX: 104; POSITION: absolute; TOP: 128px; LEFT: 592px" runat="server"
					Width="57px" Height="13px" CssClass="Standard-text">Secuencia:</asp:Label>
			</form>
		</center>
		</TABLE>
	</body>
</HTML>
