
<%@ Page language="c#" Codebehind="FormPresentacion.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormPresentacion" %>
<%@ Register TagPrefix="uc1" TagName="FormPresentacionGrid" Src="../../Controls/FormPresentacionGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
	window.frames["top"].document.title = "SICAL  - Estructuras - Formulaciones de Presentaciones"
}
		</script>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginheight="0" marginwidth="0">
		<form id="FormPresentaciones" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" colSpan="2" bgcolor="#003366">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
						</td>
					</tr>
					<tr>
						<td width="21" height="11">&nbsp;</td>
						<td width="700" height="11"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="letraAzulBold">Catalogo de Formulaciones de Presentaciones</SPAN>
										</FONT>
									</SPAN>
								</SPAN>
							</span></td>
						<td width="20" height="11">&nbsp;</td>
					</tr>
					<tr>
						<td width="21" height="14">&nbsp;</td>
						<td width="700" height="14">
							<asp:label id="Label2" runat="server" CssClass="standard-text">En este módulo podrá definir y modificar las formulaciones de Presentaciones para los distintos tipos de producto.</asp:label></td>
						<td width="20" height="13">&nbsp;</td>
					</tr>
					<TR>
						<TD class="contenido" width="21" height="131"></TD>
						<TD class="contenido" width="700" height="131">
							<TABLE class="tan-border" id="Table1" cellSpacing="12" cellPadding="0" width="700" border="0">
								<TR vAlign="top">
									<TD class="letraAzulBold" colSpan="4" height="13">Indique las características del 
										producto</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right">
											<asp:label id="lblPresentacion" runat="server" CssClass="standard-text"> Presentacion:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboIdPresentacion" runat="server" Width="143px" CssClass="standard-text"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">&nbsp;
											<asp:label id="lblMedida" runat="server" CssClass="standard-text">Medida</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboIdMedida" runat="server" Width="143px" CssClass="standard-text"></asp:dropdownlist></TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right">
											<asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboIdPlanta" runat="server" Width="143px" CssClass="standard-text"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">&nbsp;</P>
									</TD>
									<TD height="22">
										<P>&nbsp;</P>
									</TD>
								</TR>
								<TR vAlign="top">
									<TD></TD>
									<TD></TD>
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
								<TABLE class="tan-border" id="tableComponents" cellSpacing="12" cellPadding="0" width="700"
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
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" border="0">
											</TABLE>
											<uc1:FormPresentacionGrid id="gridFormPresentacion" runat="server"></uc1:FormPresentacionGrid></TD>
									</TR>
								</TABLE>
							</DIV>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td>
							<div align="left">
								<TABLE class="tan-border" id="tableNewComponents" cellSpacing="12" cellPadding="0" width="700"
									border="0" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" colSpan="4" height="13">Agregue un componente a la 
											formulación&nbsp;de Presentaciones</TD>
									</TR>
									<TR>
										<TD width="122" height="28"><asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material</asp:label></TD>
										<TD height="28"><asp:textbox id="txtCodigoSAP" runat="server" Width="131px" CssClass="standard-text" AutoPostBack="True"
												MaxLength="18"></asp:textbox><asp:imagebutton id="cmdFindMaterial" runat="server" ImageUrl="../../Images/Find.gif" Height="23px"
												ToolTip="Si no conoce el Codigo SAP del Material que desea agregar, haga click sobre este botón"></asp:imagebutton></TD>
										<TD colSpan="2" height="28"><asp:textbox id="txtDescripcion" runat="server" Width="362px" CssClass="standard-text" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="122" height="6"><asp:label id="lblCantidad" runat="server" CssClass="standard-text">Cantidad</asp:label></TD>
										<TD height="6"><asp:textbox id="txtCantidad" runat="server" Width="131px" CssClass="standard-text"></asp:textbox></TD>
										<TD height="6" width="122"><asp:label id="lblUnidadMedida" runat="server" CssClass="standard-text">Unidad de Medida</asp:label></TD>
										<TD height="6">
											<P><asp:dropdownlist id="cboUnidad" runat="server" Width="143px" CssClass="standard-text"></asp:dropdownlist></P>
										</TD>
									</TR>
									<TR vAlign="top">
										<TD width="122" colspan="2">
											<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
										<TD width="122">
											<P align="right"><asp:button id="cmdAdd" runat="server" CssClass="botonesInput" Text="Agregar"></asp:button></P>
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
							<TABLE class="tan-border" id="ew" width="700" border="0">
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
