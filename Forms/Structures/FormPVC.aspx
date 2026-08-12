<%@ Register TagPrefix="uc1" TagName="FormPVCGrid" Src="../../Controls/FormPVCGrid.ascx" %>
<%@ Page language="c#" Codebehind="FormPVC.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormPVC" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Gu�a de estilo</title>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
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
	window.frames["top"].document.title = "SICAL  - Estructuras - Formulación de PVC"
}
		</script>
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
	    <style type="text/css">
            .auto-style1 {
                FONT-WEIGHT: bold;
                FONT-SIZE: 10px;
                COLOR: #003366;
                FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;
                font-weight: bold;
                height: 13px;
            }
        </style>
	</HEAD>
	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		marginwidth="0" marginheight="0">
		<form id="FormulationofPVC" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="740">
					<tr>
						<td class="contenido" bgColor="#003366" colSpan="3"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td width="700"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="letraAzulBold">Catálogo de Formulaciones de PVC</SPAN>
										</FONT>
									</SPAN>
								</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td height="14" width="21">&nbsp;</td>
						<td height="14" width="700"><asp:label id="Label2" runat="server" CssClass="standard-text">En este módulo podrá definir y modificar las formulaciones de PVC para los distintos tipos de producto.</asp:label></td>
						<td height="13" width="20">&nbsp;</td>
					</tr>
					<TR>
						<TD class="contenido" height="131" width="21"></TD>
						<TD class="contenido" height="131" width="700">
							<TABLE id="Table1" class="tan-border" border="0" cellSpacing="12" cellPadding="0" width="700">
								<TR vAlign="top">
									<TD class="auto-style1" colSpan="4">Indique las características del 
										producto</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right"><asp:label id="lblFproducto" runat="server" CssClass="standard-text">Familia de Producto:</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboIdFamiliaProducto" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">&nbsp;
											<asp:label id="lblEspesor" runat="server" CssClass="standard-text">Espesor:</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboIdEspesor" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right"><asp:label id="lblMedida" runat="server" CssClass="standard-text">Medida:</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboIdMedida" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right"><asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta:</asp:label></P>
									</TD>
									<TD height="22">
										<P><asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></P>
									</TD>
								</TR>
								<TR>
									<TD>
										<P align="right"><asp:label id="lblAcabado" runat="server" CssClass="standard-text">Acabado:</asp:label></P>
									</TD>
									<TD><asp:dropdownlist id="cboIdAcabado" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></TD>
									<TD>
										<P align="right"><asp:label style="Z-INDEX: 0" id="lblLinea" runat="server" CssClass="standard-text">Línea:</asp:label></P>
									</TD>
									<TD><asp:dropdownlist style="Z-INDEX: 0" id="cboLinea" runat="server" CssClass="standard-text" Width="142px"
											AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR vAlign="top">
									<TD></TD>
									<TD></TD>
									<TD>
										<P align="right"><asp:button id="cmdEditForm" runat="server" CssClass="botonesInput" Text="Aceptar"></asp:button></P>
									</TD>
									<TD><asp:button id="cmdCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="contenido" height="131" width="20"></TD>
					</TR>
					<tr>
						<td class="contenido" width="21">&nbsp;</td>
						<td class="contenido" width="700">
							<DIV align="left">
								<TABLE id="tableComponents" class="tan-border" border="0" cellSpacing="12" cellPadding="0"
									width="700" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" height="13" colSpan="2">
											<P>Componentes Actuales de la Formulación</P>
										</TD>
									</TR>
									<TR>
										<TD>
											<P align="left"><asp:label id="Label1" runat="server" CssClass="standard-text">Mensaje:</asp:label><asp:textbox id="txtMensajePiso" runat="server" CssClass="standard-text" Width="585px"></asp:textbox><asp:imagebutton id="imgSaveMessage" runat="server" AlternateText="Save" CommandName="Save" NAME="imgSave"
													CausesValidation="False" ImageUrl="../../images/icon-floppy.gif"></asp:imagebutton></P>
										</TD>
										<TD></TD>
									</TR>
									<TR vAlign="top">
										<TD colSpan="2">
											<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0">
											</TABLE>
											<uc1:formpvcgrid id="currentFormGrid" runat="server"></uc1:formpvcgrid></TD>
									</TR>
								</TABLE>
							</DIV>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td class="contenido" width="21">&nbsp;</td>
						<td class="contenido" width="700">
							<div align="center">
								<TABLE id="tableNewComponents" class="tan-border" border="0" cellSpacing="12" cellPadding="0"
									width="700" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" height="13" colSpan="2">Agregue un componente a la 
											formulación&nbsp;de PVC</TD>
										<TD class="letraAzulBold" height="13"></TD>
										<TD class="letraAzulBold" height="13"></TD>
									</TR>
									<TR>
										<TD height="28" width="122"><asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material</asp:label></TD>
										<TD height="28"><asp:textbox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="131px" AutoPostBack="True"
												MaxLength="18"></asp:textbox><asp:imagebutton id="cmdFindMaterial" runat="server" ImageUrl="../../Images/Find.gif" ToolTip="Si no conoce el Codigo SAP del Material que desea agregar, haga click sobre este bot�n"
												Height="23px"></asp:imagebutton></TD>
										<TD height="28" colSpan="2"><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" Width="362px" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD height="6" width="122"><asp:label id="lblCantidad" runat="server" CssClass="standard-text">Cantidad</asp:label></TD>
										<TD height="6"><asp:textbox id="txtCantidad" runat="server" CssClass="standard-text" Width="131px"></asp:textbox></TD>
										<TD height="6"><asp:label id="lblUnidadMedida" runat="server" CssClass="standard-text">Unidad de Medida</asp:label></TD>
										<TD height="6">
											<P><asp:dropdownlist id="cboUnidad" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist></P>
										</TD>
									</TR>
									<TR vAlign="top">
										<TD width="122" colSpan="2"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
										<TD>
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
						<td>
						<td>
							<TABLE id="ew" class="tan-border" border="0" width="700">
								<tr>
									<td align="center"><asp:button id="cmdSalir" runat="server" CssClass="botonesInput" Text="Salir" Visible="False"></asp:button></td>
								</tr>
							</TABLE>
						</td>
						</TD></tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
