<%@ Page language="c#" Codebehind="Aforo.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Aforo" %>
<%@ Register TagPrefix="uc1" TagName="AnillosGrid" Src="../../Controls/AnillosGrid.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AforoGrid" Src="../../Controls/AforoGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
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
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Familia de Producto"
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
	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		marginheight="0" marginwidth="0">
		<form id="FamiliaProductoForm" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="740">
					<tr>
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><IMG src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catálogo de Aforo</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><asp:label id="Label1" runat="server" CssClass="standard-text" Width="680px"> Catalogo de Aforo usado en la fase de Color</asp:label>&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<table border="0" cellSpacing="0" cellPadding="0" width="700">
								<tr>
									<td height="12" width="20">&nbsp;</td>
									<TD height="12" width="10"></TD>
									<td height="12"><span class="letraAzulBold"></span></td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="20">
										<TABLE id="Table1"  border="0" cellSpacing="12" cellPadding="0" width="171"
											height="272">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">
													<P>Agregar un valor de aforo</P>
												</TD>
											</TR>
											<TR>
												<TD><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="standard-text">Color</asp:label><BR>
													<asp:dropdownlist style="Z-INDEX: 0" id="cboColor" runat="server" CssClass="standard-text" Width="100%">
													</asp:dropdownlist>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD height="22"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="standard-text">Componente</asp:label><br>
													<asp:textbox style="Z-INDEX: 0" id="txtComponente" runat="server" CssClass="standard-text" Width="100%"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD height="22"><asp:label id="Label4" runat="server" CssClass="standard-text">Aforo</asp:label><br>
													<asp:textbox id="txtAforo" runat="server" CssClass="standard-text" Width="100%" MaxLength="5"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<TABLE style="Z-INDEX: 0" id="Table2" border="0" cellSpacing="0" cellPadding="0">
														<tr>
															<td colSpan="3" heidth="20px"><p></p>
															</td>
														</tr>
														<TR>
															<TD width="40%">
																<asp:button id="cmdAgregarAforo" runat="server" CssClass="botonesInput" Width="80px" CausesValidation="False"
																	Text="Agregar"></asp:button></TD>
															<td width="20%"></td>
															<TD width="40%">
																<asp:button id="cmdCancelAforo" runat="server" CssClass="botonesInput" Width="80px" CausesValidation="False"
																	Text="Cancelar"></asp:button>
															</TD>
														</TR>
														<tr>
															<td colSpan="3" heidth="20px"><p></p>
															</td>
														</tr>
														<TR>
															<TD width="40%" align="center"><asp:button style="Z-INDEX: 0" id="cmdConsulta" runat="server" CssClass="botonesInput" Width="80px"
																	CausesValidation="False" Text="Consulta"></asp:button></TD>
															<td width="20%"></td>
															<TD width="40%" align="center"><asp:button style="Z-INDEX: 0" id="cmdMostrarTodos" runat="server" CssClass="botonesInput" Width="80px"
																	CausesValidation="False" Text="Todos"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<TD class="contenido" vAlign="top">
										<P class="contenido" align="left"></P>
										<P class="contenido" align="left">
											<TABLE id="Table3"  border="0" cellSpacing="12" cellPadding="0" width="171"
												height="99">
												<TR vAlign="top">
													<TD style="padding-left:40px;">
														<uc1:aforogrid id="AforoGrid" runat="server"></uc1:aforogrid>
													</TD>
												</TR>
											</TABLE>
										</P>
									</TD>
								</tr>
							</table>
							<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text" ForeColor="Red"></asp:label></td>
						<TD width="20">&nbsp;</TD>
					</tr>
					<TR>
						<TD class="contenido" width="20">&nbsp;</TD>
						<TD class="contenido" width="700">
							<DIV align="right"></DIV>
						</TD>
						<TD class="contenido" width="20">&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD>
							<DIV align="right"></DIV>
						</TD>
						<TD>&nbsp;</TD>
					</TR>
				</table>
			</div>
		</form>
	</body>
</HTML>
