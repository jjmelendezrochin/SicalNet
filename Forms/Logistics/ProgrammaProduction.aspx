<%@ Page language="c#" Codebehind="ProgrammaProduction.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ProgrammaProduction" %>
<%@ Register TagPrefix="uc1" TagName="ProgrammaGrid" Src="../../Controls/ProgrammaGrid.ascx" %>
<HEAD>
		<title>LoadProduccionPrograma</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-calendario.js") %>"></script>

		<script language="javascript">	
					function ShowTitle()
					{
							window.frames["top"].document.title = "SICAL  - Programa de Producción"
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

<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
	onload="ShowTitle()">
	<form id="ProductionProgram" method="post" runat="server">
		<table align="center" width="700" style="BORDER-COLLAPSE: collapse">
			<TBODY>
				<tr>
					<td align="left" colSpan="5">
						<div id="sicalMenu"></div>
					</td>
				</tr>
				<tr>
					<td colspan="3" align="center"><br>
						<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True"> Consultar  Programa de Producción</asp:label>
					</td>
				</tr>
			</TBODY>
		</table>
		<br />
		<table align="center" width="700" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
					<td>
						<asp:Label id="Label1" runat="server" CssClass="standard-text"> Seleccione la línea de producción y Fecha del Programa de Producción que desea consultar</asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="3" width="700" align="center">
						<uc1:ProgrammaGrid id="grdProgram" runat="server"></uc1:ProgrammaGrid>
					</td>
				</tr>
			</TBODY>
		</table>
	</form>
</body>
