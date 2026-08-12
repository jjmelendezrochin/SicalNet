
<%@ Page language="c#" Codebehind="FamiliaProductos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FamilioProductosaForm" %>
<%@ Register TagPrefix="uc1" TagName="FamiliaProductosGrid" Src="../../Controls/FamiliaProductosGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
		<link rel="Stylesheet" type="text/css" href="/SicalNet/Css/sical-menu.css" />
		<script type="text/javascript" src="/SicalNet/Scripts/sical-menu.js"></script>

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
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->

		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		marginwidth="0" marginheight="0">
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
								<SPAN class="letraAzulBold">Catálogo de Familias de Productos</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><asp:label id="Label1" runat="server" CssClass="standard-text">Es la lista de las distintas Familias de Productos de PLASTIGLAS en donde se producen laminas.</asp:label>&nbsp;</td>
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
										<TABLE id="Table1" class="tan-border" border="0" cellSpacing="12" cellPadding="0" width="171"
											height="99">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">Agregar una Familia de Productos</TD>
											</TR>
											<TR>
												<TD><asp:label id="Label2" runat="server" CssClass="standard-text">Descripción</asp:label><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" MaxLength="50" Width="142px"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD height="22">
													<P><asp:label id="Label3" runat="server" CssClass="standard-text">Tipo de PMMA (Prepolimero)</asp:label><asp:dropdownlist id="cbotipodePMMA" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></P>
												</TD>
											</TR>
											<TR>
												<TD height="22"><asp:label id="Label4" runat="server" CssClass="standard-text">Temp. Preseparación</asp:label><asp:textbox id="txtTempPre" runat="server" CssClass="standard-text" MaxLength="5" Width="142px"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<td height="20"><asp:button id="cmdFProducto" runat="server" CssClass="botonesInput" Width="64px" CausesValidation="False"
																	Text="Agregar"></asp:button></td>
															<TD height="20"><asp:button id="cmdCancelC" runat="server" CssClass="botonesInput" Width="64px" CausesValidation="False"
																	Text="Cancelar"></asp:button></TD>
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
											<TABLE id="Table3" class="tan-border" border="0" cellSpacing="12" cellPadding="0" width="171"
												height="99">
												<TR vAlign="top">
													<TD><uc1:familiaproductosgrid id="FamiliaProductosGridControl" runat="server"></uc1:familiaproductosgrid></TD>
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
