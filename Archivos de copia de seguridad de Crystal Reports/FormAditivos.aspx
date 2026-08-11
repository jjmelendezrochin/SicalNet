<%@ Register TagPrefix="uc1" TagName="FormAditivosGrid" Src="../../Controls/FormAditivosGrid.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="FormAditivos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormAditivos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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
	window.frames["top"].document.title = "SICAL  - Estructuras - Formulación de Aditivos"
}
		</script>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<!--onload="if ('<%= Session["errMsg"]%>' != '') alert('<%= Session["errMsg"]%>')"-->
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginheight="0" marginwidth="0">
		<form id="FormAditivosForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" colSpan="3" bgColor="#003366">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
						</td>
					</tr>
					<tr>
						<td width="21" height="11">&nbsp;</td>
						<td width="700" height="11"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="titulo"><SPAN class="letraAzulBold">&nbsp;Catálogo de Formulación de Aditivos</SPAN>
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
							<asp:label id="Label3" runat="server" CssClass="standard-text">En este catalogo se enlistan los componentes de Aditivo necesarios para la fabricación de una lámina de ciertas caracterísitcas</asp:label>&nbsp;</td>
						<td width="20" height="13">&nbsp;</td>
					</tr>
					<TR>
						<TD class="contenido" width="21" height="131"></TD>
						<TD class="contenido" width="700" height="131">
							<TABLE class="tan-border" id="Table1" cellSpacing="12" cellPadding="0" width="700" border="0">
								<TR vAlign="top">
									<TD class="letraAzulBold" colSpan="4" height="13">Seleccione el Color, Espesor, 
										Línea y Planta</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right">
											<asp:label id="lblColor" runat="server" CssClass="standard-text"> Color:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboColor" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="lblEspesor" runat="server" CssClass="standard-text">Espesor:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboEspesor" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD height="22">
										<P align="right">
											<asp:label id="lblLinea" runat="server" CssClass="standard-text">Linea:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right">
											<asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta:</asp:label></P>
									</TD>
									<TD height="22">
										<asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
								</TR>
								<TR vAlign="top">
									<TD>
										<P align="right">&nbsp;</P>
									</TD>
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
											<table>
												<tr>
													<td valign="middle">
														<asp:label id="Label1" runat="server" CssClass="standard-text">Mensaje:</asp:label>
													</td>
													<td>
														<asp:textbox id="txtMensajePiso" runat="server" Width="500px" CssClass="standard-text" Height="100px"
															MaxLength="2000" TextMode="MultiLine"></asp:textbox>
													</td>
													<td valign="middle">
														<asp:imagebutton id="imgSaveMessage" runat="server" ImageUrl="../../images/icon-floppy.gif" CausesValidation="False"
															NAME="imgSave" CommandName="Save" AlternateText="Save"></asp:imagebutton>
													</td>
												</tr>
											</table>
										</TD>
										<TD></TD>
									</TR>
									<TR vAlign="top">
										<TD colSpan="2">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" border="0">
											</TABLE>
											<uc1:formaditivosgrid id="FormAditivosGridControl" runat="server"></uc1:formaditivosgrid></TD>
									</TR>
								</TABLE>
							</DIV>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td>
							<div>
								<TABLE class="tan-border" id="tableNewComponents" cellSpacing="12" cellPadding="0" width="700"
									border="0" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" colSpan="4" height="13">
											<P>Agregue un componente a la formulación&nbsp;de Aditivos</P>
										</TD>
									</TR>
									<TR>
										<TD width="122" height="28"><asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material</asp:label></TD>
										<TD height="28">
											<asp:textbox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="131px" AutoPostBack="True"></asp:textbox>
											<asp:imagebutton id="imgbtnFind" runat="server" Height="23px" ImageUrl="../../Images/Find.gif" DESIGNTIMEDRAGDROP="255"></asp:imagebutton></TD>
										<TD colSpan="2" height="28"><asp:textbox id="txtDescripcion" runat="server" Width="362px" CssClass="standard-text" BorderStyle="None"
												Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="122" height="20"><asp:label id="lblCantidad" runat="server" CssClass="standard-text">Porcentaje de Peso:</asp:label></TD>
										<TD height="20">
											<asp:textbox id="txtdepeso" runat="server" CssClass="standard-text" Width="132px"></asp:textbox></TD>
										<TD height="20" width="122">
											<asp:label id="Label2" runat="server" CssClass="standard-text">Versión:</asp:label></TD>
										<TD height="20">
											<P>
												<asp:textbox id="txtVersion" runat="server" Width="132px" CssClass="standard-text"></asp:textbox></P>
										</TD>
									</TR>
									<TR vAlign="top">
										<TD width="122" colspan="2">
											<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
										<TD width="122">
											<P align="right">
												<asp:button id="AddFormAditivos" runat="server" CssClass="botonesInput" Width="64px" Text="Agregar"
													CausesValidation="False"></asp:button></P>
										</TD>
										<TD></TD>
									</TR>
								</TABLE>
							</div>
						</td>
						<TD>&nbsp;</TD>
					</tr>
					<tr>
						<td></td>
						<td>
							<TABLE class="tan-border" id="ew" width="700" border="0">
								<tr>
									<td align="center">
										<asp:button id="cmdSalir" runat="server" CssClass="botonesInput" Text="Salir" Visible="False"></asp:button>
									</td>
								</tr>
							</TABLE>
						</td>
						<td></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
