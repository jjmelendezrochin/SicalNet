<%@ Register TagPrefix="uc1" TagName="FormColorGrid" Src="../../Controls/FormColorGrid.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="FormColor.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormColor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
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
	window.frames["top"].document.title = "SICAL  - Estructuras - Formulación de Color"
}
		</script>
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
	    <style type="text/css">
            .auto-style1 {
                height: 11px;
            }
        </style>
	</HEAD>
	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		marginwidth="0" marginheight="0">
		<form id="FormColorForm" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="740">
					<tr>
						<td class="contenido" bgColor="#003366" colSpan="2"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
					</tr>
					<tr>
						<td width="21" class="auto-style1"></td>
						<td width="700" class="auto-style1"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="titulo"><SPAN class="letraAzulBold">&nbsp;Catalogo de formulación de 
      Color</SPAN>
											</SPAN></FONT></SPAN>
								</SPAN>
							</span></td>
						<td width="20" class="auto-style1"></td>
					</tr>
					<tr>
						<td height="14" width="21">&nbsp;</td>
						<td height="14" width="700"><asp:label id="Label2" runat="server" CssClass="standard-text">En este catalogo se formulan los componentes que integran el color</asp:label>&nbsp;</td>
						<td height="13" width="20">&nbsp;</td>
					</tr>
					<TR>
						<TD class="contenido" height="131" width="21"></TD>
						<TD class="contenido" height="131" width="700" align="center"><TABLE id="Table1" class="tan-border" border="0" cellSpacing="12" cellPadding="0" width="700">
								<TR vAlign="top">
									<TD class="letraAzulBold" height="13" colSpan="4">Seleccione el color</TD>
								</TR>
								<TR vAlign="top">
									<TD height="22">
										<P align="right"><asp:label id="lblColor" runat="server" CssClass="standard-text"> Color</asp:label></P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboColor" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
									<TD height="22">
										<P align="right"><asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta</asp:label>&nbsp;
										</P>
									</TD>
									<TD height="22"><asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
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
						<td class="contenido" width="700" align="center">
							<DIV align="left">
								<TABLE id="tableComponents" class="tan-border" border="0" cellSpacing="12" cellPadding="0"
									width="700" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" height="13" colSpan="2">
											<P>Componentes Actuales de la Formulación</P>
										</TD>
									</TR>
									<TR>
										<TD class="letraAzulBold" height="13" colSpan="2">
											<P><Font color="red">No olvide indicar el aforo de color</Font></P>
										</TD>
									</TR>
									<TR>
										<TD vAlign="middle">
											<table>
												<tr>
													<td vAlign="middle"><asp:label id="Label1" runat="server" CssClass="standard-text">Mensaje:</asp:label></td>
													<td><asp:textbox id="txtMensajePiso" runat="server" CssClass="standard-text" Width="500px" Height="100px"
															MaxLength="500" TextMode="MultiLine"></asp:textbox></td>
													<td><asp:imagebutton id="imgSaveMessage" runat="server" ImageUrl="../../images/icon-floppy.gif" CausesValidation="False"
															NAME="imgSave" CommandName="Save" AlternateText="Save"></asp:imagebutton></td>
												</tr>
											</table>
										</TD>
										<TD></TD>
									</TR>
									<TR vAlign="top">
										<TD colSpan="2">
											<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0">
											</TABLE>
											<uc1:formcolorgrid id="FormColorGridControl" runat="server"></uc1:formcolorgrid></TD>
									</TR>
								</TABLE>
							</DIV>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td align="left">
							<div>
								<TABLE id="tableNewComponents" class="tan-border" border="0" cellSpacing="12" cellPadding="0"
									width="700" runat="server" visible="false">
									<TR vAlign="top">
										<TD class="letraAzulBold" height="13" colSpan="4">Agregue un componente a la 
											formulación&nbsp;de Color</TD>
									</TR>
									<TR>
										<TD height="28" width="122"><asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material</asp:label></TD>
										<TD height="28"><asp:textbox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="131px"></asp:textbox><asp:imagebutton id="imgbtnFind" runat="server" Height="23px" ImageUrl="../../Images/Find.gif"></asp:imagebutton></TD>
										<TD height="28" colSpan="2"><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" Width="362px" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD height="6" width="122"><asp:label id="lblCantidad" runat="server" CssClass="standard-text">Porcentaje de Peso:</asp:label></TD>
										<TD height="6"><asp:textbox id="txtPorcentaje" runat="server" CssClass="standard-text" Width="131px"></asp:textbox></TD>
										<TD height="6" width="122"><asp:label id="Label3" runat="server" CssClass="standard-text">Grupo:</asp:label></TD>
										<TD height="6">
											<P><asp:textbox id="txtGrupo" runat="server" CssClass="standard-text" Width="142px">1</asp:textbox></P>
										</TD>
									</TR>
									<TR vAlign="top">
										<TD width="122" colSpan="2"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
										<TD width="122">
											<P align="right"><asp:button id="AddFormColor" runat="server" CssClass="botonesInput" Width="64px" Text="Agregar"
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
						<td></td>
						<td>
							<TABLE id="ew" class="tan-border" border="0" width="700">
								<tr>
									<td align="center"><asp:button id="cmdSalir" runat="server" CssClass="botonesInput" Text="Salir" Visible="False"></asp:button></td>
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
