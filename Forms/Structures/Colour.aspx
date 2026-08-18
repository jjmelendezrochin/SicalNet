<%@ Register TagPrefix="uc1" TagName="ColourGrid" Src="../../Controls/ColourGrid.ascx" %>
<%@ Page language="c#" Codebehind="Colour.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.ColourForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
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
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Colores"
			}
		
		</script>
		

		<!--onload="if ('<%= Session["errMsg"]%>' != '') alert('<%= Session["errMsg"]%>')"-->

		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginheight="0" marginwidth="0">
		<form id="ColourForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" colSpan="2">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><IMG height="7" src="/SicalNEt/images/icon-pencil.gif" width="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catálogo de colores</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">&nbsp;
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Es la lista de todos los colores que se manejan para las laminas de acrílico en PLASTIGLAS</asp:Label></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<table cellSpacing="0" cellPadding="0" width="700" border="0">
								<tr>
									<td width="20" height="12">&nbsp;</td>
									<TD width="10" height="12"></TD>
									<td height="12"><span class="letraAzulBold"></span></td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="20">
										<TABLE  id="Table1" height="99" cellSpacing="12" cellPadding="0" width="171"
											border="0">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">Agregar color</TD>
											</TR>
											<TR>
												<TD>
													<asp:Label id="Label2" runat="server" CssClass="standard-text">Identificador de color</asp:Label>
													<asp:textbox id="txtColourId" runat="server" Width="100%" CssClass="standard-text" MaxLength="10"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>
													<asp:Label id="Label3" runat="server" CssClass="standard-text">Descripción del color </asp:Label>
													<asp:textbox id="txtDescripcion" runat="server" Width="100%" CssClass="standard-text" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<asp:Label id="Label4" runat="server" CssClass="standard-text">Identificador de Exportación </asp:Label>
													<asp:textbox id="txtIdExportacion" runat="server" Width="100%" CssClass="standard-text" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<asp:Label id="Label5" runat="server" CssClass="standard-text">Espesor Base (Cent.) </asp:Label>
													<asp:dropdownlist id="cboIdEspesor" runat="server" Width="100%" CssClass="standard-text"></asp:dropdownlist></TD>
											</TR>
											<TR vAlign="top" align="center">
												<td><asp:checkbox id="chkTransparente" runat="server" Text="Transparente" CssClass="standard-text"></asp:checkbox></td>
											</TR>
											<TR vAlign="top">
												<TD>
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD height="20" width="40%">
																<asp:button id="AddColour" runat="server" Width="80px" CssClass="botonesInput" Text="Agregar"
																	CausesValidation="False"></asp:button></TD>
															<TD height="20" width="20%"></TD>
															<TD height="20" width="40%">
																<asp:button id="cmdCancelC" runat="server" Width="80px" CssClass="botonesInput" Text="Cancelar"
																	CausesValidation="False"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<td class="contenido" vAlign="top">
										<P class="contenido" align="left"></P>
										<P class="contenido" align="left">
											<TABLE id="Table3" height="99" cellSpacing="12" cellPadding="0" width="250px"
												border="0">
												<TR vAlign="top">
													<TD><uc1:colourgrid id="ColourGridControl" runat="server"></uc1:colourgrid></TD>
												</TR>
											</TABLE>
										</P>
									</td>
								</tr>
							</table>
							<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td class="contenido" width="20">&nbsp;</td>
						<td class="contenido" width="700">
							<div align="right"></div>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td>
							<div align="right"></div>
						</td>
						<td>&nbsp;</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
