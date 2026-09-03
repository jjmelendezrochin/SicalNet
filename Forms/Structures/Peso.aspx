
<%@ Page language="c#" Codebehind="Peso.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Peso" %>
<%@ Register TagPrefix="uc1" TagName="PesosGrid" Src="../../Controls/PesosGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:o>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="JavaScript">
<!--
<!--
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);
// -->

function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
//-->
function ShowTitle()
{
	window.frames["top"].document.title = "SICAL  - Estructuras - Catálogo de Pesos"
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
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowTitle()"
		marginheight="0" marginwidth="0">
		<form id="PesoForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr class="sical-menu-row">
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="21" height="11">&nbsp;&nbsp;</td>
						<td width="700" height="11"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catálogo de Pesos</SPAN>
							</span></td>
						<td width="20" height="11">&nbsp;</td>
					</tr>
					<tr>
						<td height="12">&nbsp;</td>
						<td width="700" height="12">
							<P class="MsoNormal"><asp:label id="Label1" runat="server" CssClass="standard-text" EnableViewState="False">En este catálogo se administran los pesos para cada lámina según sus características </asp:label></P>
						</td>
						<td width="20" height="12">&nbsp;</td>
					</tr>
					<TR>
						<TD height="12"></TD>
						<TD width="700" height="12">
							<TABLE  id="Table4" cellSpacing="12" cellPadding="0" width="700" border="0">
								<TR vAlign="top">
									<TD class="letraAzulBold" colSpan="4" height="13">Seleccione el color</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right"><asp:label id="lblMedida" runat="server" CssClass="standard-text" EnableViewState="False">Medida</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboMedidaFiltro" runat="server" CssClass="standard-text">
											<asp:ListItem Selected="True">-- Seleccione una Medida --</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD height="22">
										<P align="right"><asp:label id="lblEspesor" runat="server" CssClass="standard-text" EnableViewState="False">Espesor</asp:label>&nbsp;
										</P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboEspesorFiltro" runat="server" CssClass="standard-text">
											<asp:ListItem Value="-- Seleccione un Espesor --" Selected="True">-- Seleccione un Espesor --</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD height="22">
										<P align="right"><asp:label id="lblPlanta" runat="server" CssClass="standard-text" EnableViewState="False">Planta</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboPlantaFiltro" runat="server" CssClass="standard-text" Height="19px">
											<asp:ListItem Selected="True">-- Seleccione una Planta --</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="lblRevision" runat="server" CssClass="standard-text" EnableViewState="False">Versión</asp:label></P>
									</TD>
									<TD height="22">
										<asp:textbox id="txtRevisionFiltro" runat="server" CssClass="standard-text" Width="179px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR vAlign="top">									
									<TD>
										<P align="right"><asp:button id="cmdBuscar" runat="server" CssClass="botonesInput" Text="Aceptar"></asp:button></P>
									</TD>									
									<TD></TD>
									<TD><asp:button id="cmdCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="20" height="12"></TD>
					</TR>
					<TR>
						<TD height="12"></TD>
						<TD width="700" height="12">
							<TABLE  id="tableComponents" cellSpacing="12" cellPadding="0" width="700"
								border="0" runat="server" visible="false">
								<TR vAlign="top">
									<TD class="letraAzulBold" colSpan="2" height="13">
										<P>Pesos Actuales</P>
									</TD>
								</TR>
								<TR vAlign="top">
									<TD colSpan="2">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" border="0">
										</TABLE>
										<uc1:pesosgrid id="PesosGridControl" runat="server"></uc1:pesosgrid></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="20" height="12"></TD>
					</TR>
					<TR>
						<TD height="12"></TD>
						<TD width="700" height="12">
							<TABLE  id="tableNewComponents" cellSpacing="12" cellPadding="0" width="700"
								border="0" runat="server">
								<TR vAlign="top">
									<TD class="letraAzulBold" colSpan="4" height="13">Agregar un Peso</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right">
											<asp:label id="Label13" runat="server" CssClass="standard-text" EnableViewState="False">Medida</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboMedida" runat="server" CssClass="standard-text" Width="171px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="Label12" runat="server" CssClass="standard-text" EnableViewState="False">Espesor</asp:label>&nbsp;
										</P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboEspesor" runat="server" CssClass="standard-text" Width="171px" Height="19px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD height="22">
										<P align="right">
											<asp:label id="Label11" runat="server" CssClass="standard-text" EnableViewState="False">Planta</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="171px" Height="19px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right"><asp:label id="Label5" runat="server" CssClass="standard-text">Versión :</asp:label></P>
									</TD>
									<TD height="22"><asp:textbox id="txtRevision" runat="server" CssClass="standard-text" Width="179px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD height="22">
										<P align="right">
											<asp:label id="Label6" runat="server" CssClass="standard-text">Cantidad en Kilos:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:textbox id="txtKilos" runat="server" CssClass="standard-text" Width="179px" MaxLength="10"></asp:textbox></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="Label7" runat="server" CssClass="standard-text">Tolerancia en gr.:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:textbox id="txtTolerancia" runat="server" CssClass="standard-text" Width="179px" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD height="22">
										<P align="right">
											<asp:label id="Label8" runat="server" CssClass="standard-text">Elaboro:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:textbox id="txtElaboro" runat="server" CssClass="standard-text" Width="179px" MaxLength="50"></asp:textbox></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="Label9" runat="server" CssClass="standard-text">Activo: </asp:label></P>
									</TD>
									<TD height="22">
										<asp:checkbox id="chkActivo" runat="server" CssClass="standard-text" Width="97px" Text="OK"></asp:checkbox></TD>
								</TR>
								<TR vAlign="top">
									<TD>
										<P align="right">
											<asp:button id="AddPeso" runat="server" CssClass="botonesInput" Width="85px" Text="Agregar"
												CausesValidation="False"></asp:button></P>
									</TD>
									<TD>
										<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label>
									</TD>									
									<TD>
										<asp:button id="cmdCancelC" runat="server" CssClass="botonesInput" Width="85px" Text="Cancelar"
											CausesValidation="False"></asp:button></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="20" height="12"></TD>
					</TR>
				</table>
			</div>
		</form>
	</body>
</HTML>
