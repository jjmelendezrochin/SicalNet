<%@ Register TagPrefix="uc1" TagName="FormCintasGrid" Src="../../Controls/FormCintasGrid.ascx" %>

<%@ Page language="c#" Codebehind="FormCintas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormCintas" %>
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
			window.frames["top"].document.title = "SICAL  - Estructuras - Formulación de Cintas"
		}
		</script>
		
		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
		<!--onload="if ('<%= Session["errMsg"]%>' != '') alert('<%= Session["errMsg"]%>')"-->
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginheight="0" marginwidth="0">
		<form id="FormCintasForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr class="sical-menu-row">
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="21" height="11">&nbsp;</td>
						<td width="700" height="11"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="titulo"><SPAN class="letraAzulBold">&nbsp;Catálogo de formulación de Cintas</SPAN>
											</SPAN>
										</FONT>
									</SPAN>
								</SPAN>
							</span></td>
						<td width="20" height="11">&nbsp;</td>
					</tr>
					<tr>
						<td width="21" height="14">&nbsp;</td>
						<td width="700" height="14">
							<asp:label id="Label2" runat="server" CssClass="standard-text">En este catalogo se indican los tipos de cintas empleados por los productos según sus características</asp:label>&nbsp;</td>
						<td width="20" height="13">&nbsp;</td>
					</tr>
					<TR>
						<TD class="contenido" width="21" height="131"></TD>
						<TD class="contenido" width="700" height="131">
							<TABLE  id="Table1" cellSpacing="12" cellPadding="0" width="700" border="0">
								<TR vAlign="top">
									<TD class="letraAzulBold" colSpan="4" height="13">
										<P>Seleccione el las caracterísiticas de la lámina:</P>
									</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right">
											<asp:label id="lblFamProd" runat="server" CssClass="standard-text"> Familia de Producto</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboFamPdt" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="lblMedida" runat="server" CssClass="standard-text">Medida</asp:label>&nbsp;
										</P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboMedida" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
								</TR>
								<TR vAlign="top">
									<TD>
										<P align="right">
											<asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta</asp:label></P>
									</TD>
									<TD>
										<asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
									<TD>
										<P align="right">
											<asp:button id="cmdEditForm" runat="server" CssClass="botonesInput" Text="Aceptar"></asp:button></P>
									</TD>
									<TD>
										<asp:button id="cmdCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="contenido" width="20" height="131"></TD>
					</TR>
					<tr>
						<td class="contenido" width="21">&nbsp;</td>
						<td class="contenido" width="700">
							<DIV align="left">
								<TABLE  id="tableComponents" cellSpacing="12" cellPadding="0" width="700"
									border="0" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" colSpan="2" height="13">
											<P>Componentes Actuales de la Formulación</P>
										</TD>
									</TR>
									<TR>
										<TD>
											<P align="left"><asp:label id="Label1" runat="server" CssClass="standard-text">Mensaje:</asp:label><asp:textbox id="txtMensajePiso" runat="server" Width="585px" CssClass="standard-text"></asp:textbox><asp:imagebutton id="imgSaveMessage" runat="server" ImageUrl="../../images/icon-floppy.gif" CausesValidation="False"
													NAME="imgSave" CommandName="Save" AlternateText="Save"></asp:imagebutton></P>
										</TD>
										<TD></TD>
									</TR>
									<TR vAlign="top">
										<TD colSpan="2">											
											<uc1:formcintasgrid id="FormCintasGridControl" runat="server"></uc1:formcintasgrid>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td>
							<div align="left">
								<TABLE  id="tableNewComponents" cellSpacing="12" cellPadding="0" width="700"
									border="0" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" colSpan="4" height="13">Agregue un componente a la 
											formulación&nbsp;de cintas</TD>
									</TR>
									<TR>
										<TD width="122" height="28"><asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material:</asp:label></TD>
										<TD height="28">
											<asp:textbox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="131px" AutoPostBack="True"></asp:textbox>
											<asp:imagebutton id="imgbtnFind" runat="server" ImageUrl="../../Images/Find.gif" Height="23px"></asp:imagebutton></TD>
										<TD colSpan="2" height="28"><asp:textbox id="txtDescripcion" runat="server" Width="362px" CssClass="standard-text" BorderStyle="None"
												Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="122" height="6"><asp:label id="lblCantidad" runat="server" CssClass="standard-text"> Cantidad:</asp:label></TD>
										<TD height="6">
											<asp:textbox id="txtCantidad" runat="server" CssClass="standard-text" Width="131px"></asp:textbox></TD>
										<TD height="6" width="122">
											<asp:label id="Label3" runat="server" CssClass="standard-text">Unidad de Medida:</asp:label></TD>
										<TD height="6">
											<P>
												<asp:dropdownlist id="cboUnidad" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></P>
										</TD>
									</TR>
									<TR vAlign="top">
										<TD width="122" colspan="2">
											<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
										<TD width="122">
											<P align="right">
												<asp:button id="AddFormCintas" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar"
													CausesValidation="False"></asp:button></P>
										</TD>
										<TD></TD>
									</TR>
								</TABLE>
							</div>
						</td>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td colspan="1">
						<td>
							<TABLE  id="ew" width="700" border="0">
								<tr>
									<td align="center">
										<asp:button id="cmdSalir" runat="server" CssClass="botonesInput" Text="Salir" Visible="False"></asp:button>
									</td>
								</tr>
							</TABLE>
						</td>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
