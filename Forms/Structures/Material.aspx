
<%@ Page language="c#" Codebehind="Material.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Material" %>
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
					window.frames["top"].document.title = "SICAL  - Estructuras - Catálogo de Materiales"
			}	
		</script>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="ShowTitle()">
		<form id="FormMaterial" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<TBODY>
						<tr>
							<td align="left" colSpan="5" bgColor="#003366">
								<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
							</td>
						</tr>
						<tr>
							<td class="contenido" width="20">&nbsp;</td>
							<td class="contenido" colSpan="2">
								<div align="right"><span class="menu1">&nbsp;&nbsp;&nbsp;</span></div>
							</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">
								<span class="titulo">
									<SPAN class="letraAzulBold">Catalogo 
      de Materiales</SPAN>
								</span></td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700">
								<asp:Label id="Label3" runat="server" Text="Es la lista de todos los materiales que se utilizan en el procesos de fabricación de láminas acrílicas en PLASTIGAS" CssClass="standard-text"></asp:Label>&nbsp;</td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700">
								<table cellSpacing="0" cellPadding="0" width="700" border="0">
									<TBODY>
										<tr>
											<td width="20" height="12">&nbsp;</td>
											<TD width="10" height="12"></TD>
											<td height="12"><span class="letraAzulBold"></span></td>
										</tr>
										<tr>
											<td class="contenido" vAlign="top" width="20">
												<TABLE class="tan-border" id="Table1" cellSpacing="0" cellPadding="0" width="200" border="0">
													<TBODY>
														<tr>
															<td><asp:panel id="pnlCodigo" Width="370" Runat="server">
																	<TABLE>
																		<TR>
																			<TD vAlign="middle" width="100">
																				<asp:Label id="lblCodigo" runat="server" CssClass="standard-text" Text="CodigoSAP" Width="100px">Codigo SAP</asp:Label></TD>
																			<TD vAlign="middle">
																				<asp:TextBox id="txtCodigo" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox>
																				<asp:imagebutton id="imgFind" runat="server" CausesValidation="False" ImageUrl="../../images/find.gif"
																					NAME="imgFind" CommandName="Find" AlternateText="Find"></asp:imagebutton><IMG src="images/spacer.gif" width="1">
																				<asp:imagebutton id="imgEdit" runat="server" CausesValidation="false" ImageUrl="../../Images/icon-pencil.gif"
																					NAME="imgEdit" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
																				<asp:imagebutton id="imgSave" runat="server" CausesValidation="False" ImageUrl="../../images/icon-floppy.gif"
																					NAME="imgSave" CommandName="Save" AlternateText="Save"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
																				<asp:imagebutton id="imgDel" Runat="server" CausesValidation="False" ImageUrl="../../images/icon-delete.gif"
																					NAME="imgDel" CommandName="Delete" AlternateText="Delete"></asp:imagebutton>
																				<asp:imagebutton id="imgCancel" runat="server" CausesValidation="False" ImageUrl="../../images/icon-pencil-x.gif"
																					NAME="imgCancel" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
																				<asp:TextBox id="txtDescripcion" runat="server" CssClass="standard-text" Width="0px"></asp:TextBox></TD>
																		</TR>
																	</TABLE>
																</asp:panel>
																<asp:panel id="pnlPlanta" Width="370" Runat="server" Visible="False">
																	<TABLE>
																		<TR>
																			<TD vAlign="middle" width="100">
																				<asp:Label id="lblPlanta" runat="server" CssClass="standard-text" Text="Descripcion" Visible="False">Planta:</asp:Label></TD>
																			<TD>
																				<asp:dropdownlist id="cboPlanta" tabIndex="4" runat="server" CssClass="standard-text" Width="142px"
																					Visible="False"></asp:dropdownlist></TD>
																		</TR>
																	</TABLE>
																</asp:panel>
															</td>
															<td class="contenido" vAlign="top">
																<TABLE class="tan-border" id="Table1" cellSpacing="0" cellPadding="0" width="200" border="0">
																	<TR>
																		<asp:panel id="pnlOperation" Runat="server">
																			<TD>
																				<asp:button id="btnNew" runat="server" CssClass="standard-text" Text="Nuevo" Width="64px" CausesValidation="False"></asp:button></TD>
																			<TD>
																				<asp:button id="btnEdit" runat="server" CssClass="standard-text" Text="Editar" Width="64px"
																					CausesValidation="False"></asp:button></TD>
																			<TD>
																				<asp:button id="btnDelete" runat="server" CssClass="standard-text" Text="Eliminar" Width="64px"
																					CausesValidation="False"></asp:button></TD>
																		</asp:panel></TR>
																</TABLE>
															</td>
														</tr>
														<TR>
															<td height="80"><asp:panel id="pnlNew" Runat="server" Width="371px" Height="82px">
																	<TABLE>
																		<TR>
																			<TD width="100">
																				<asp:Label id="Label5" runat="server" CssClass="standard-text" Text="Descripcion">Estado Material</asp:Label></TD>
																			<TD>
																				<asp:DropDownList id="cboEstMaterial" tabIndex="3" runat="server" CssClass="standard-text" Width="142px"
																					AutoPostBack="True"></asp:DropDownList></TD>
																		</TR>
																		<TR>
																			<TD width="100">
																				<asp:Label id="lblDesc" runat="server" CssClass="standard-text" Text="Descripción"></asp:Label></TD>
																			<TD>
																				<asp:TextBox id="txtDesc" tabIndex="1" runat="server" CssClass="standard-text" Width="250px"></asp:TextBox></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="100">
																				<asp:Label id="Label4" runat="server" CssClass="standard-text" Text="Descripcion">Estado Producto</asp:Label></TD>
																			<TD>
																				<asp:DropDownList id="cboEstPdt" tabIndex="2" runat="server" CssClass="standard-text" Width="142px"></asp:DropDownList></TD>
																		</TR>
																		<TR>
																			<TD width="100">
																				<asp:label id="lblTipoEtiqueta" runat="server" CssClass="standard-text" Text="¿Se prepara en el área de color ?" Width="80px"></asp:label></TD>
																			<TD>
																				<asp:CheckBox id="chkEtiquetaColor" runat="server" CssClass="standard-text"></asp:CheckBox></TD>
																		</TR>
																		<TR>
																			<TD width="100">
																				<asp:label id="Label12" runat="server" CssClass="standard-text" Text=" ¿Se prepara mezclado?" Width="80px"></asp:label></TD>
																			<TD>
																				<asp:CheckBox id="chkMezclado" runat="server" CssClass="standard-text"></asp:CheckBox></TD>
																		</TR>
																	</TABLE>
																</asp:panel></td>
														</TR>
														<tr>
															<td><asp:panel id="pnlFinished" Runat="server" DESIGNTIMEDRAGDROP="54">
																	<TABLE>
																		<TR vAlign="top">
																			<TD width="120">
																				<asp:Label id="Label6" runat="server" CssClass="standard-text" Text="Descripcion">Familia Producto:</asp:Label></TD>
																			<TD>
																				<asp:dropdownlist id="cboFamPdt" tabIndex="4" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="120">
																				<asp:Label id="Label7" runat="server" CssClass="standard-text" Text="Descripcion">Color:</asp:Label></TD>
																			<TD>
																				<asp:dropdownlist id="cboColor" tabIndex="5" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="120" height="17">
																				<asp:Label id="Label8" runat="server" CssClass="standard-text" Text="Descripcion">Medida:</asp:Label></TD>
																			<TD height="17">
																				<asp:dropdownlist id="cboMedida" tabIndex="6" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="120" height="18">
																				<asp:Label id="Label9" runat="server" CssClass="standard-text" Text="Descripcion">Espesor:</asp:Label></TD>
																			<TD height="18">
																				<asp:dropdownlist id="cboEspesor" tabIndex="7" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="120">
																				<asp:Label id="Label10" runat="server" CssClass="standard-text" Text="Descripcion">Mercado:</asp:Label></TD>
																			<TD>
																				<asp:dropdownlist id="cboMercado" tabIndex="8" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="120">
																				<asp:Label id="Label11" runat="server" CssClass="standard-text" Text="Presentación:"></asp:Label></TD>
																			<TD>
																				<asp:dropdownlist id="cboPresentation" tabIndex="9" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD width="120">
																				<asp:label id="lblAcabado" runat="server" CssClass="standard-text" Text="Acabado" Width="70px">Acabado</asp:label></TD>
																			<TD>
																				<asp:dropdownlist id="cboAcabado" tabIndex="10" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD width="120" height="13">
																				<asp:label id="Label1" runat="server" CssClass="standard-text" Text="Acabado" Width="70px">Linea Base</asp:label></TD>
																			<TD height="13">
																				<asp:dropdownlist id="cboLineaBase" tabIndex="10" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD width="120">
																				<asp:label id="Label2" runat="server" CssClass="standard-text" Text="Versión de Aditivos" Width="109px"></asp:label></TD>
																			<TD>
																				<asp:TextBox id="txtVersionAd" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox></TD>
																		</TR>
																		<TR>
																			<TD width="120"></TD>
																			<TD>
																				<asp:CheckBox id="chkSegundas" runat="server" CssClass="standard-text" Text="Manejar Segundas"
																					Width="164px"></asp:CheckBox></TD>
																		</TR>
																	</TABLE>
																</asp:panel></td>
														</tr>
														<tr>
															<td colspan="3">
																<asp:label id="lblErr" runat="server" Width="369px" CssClass="standard-text"></asp:label>
															</td>
														</tr>
													</TBODY></TABLE>
											</td>
										</tr>
									</TBODY></table>
		</form>
		<DIV></DIV>
		</TD></TR></TBODY>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
		</DIV>
	</body>
</HTML>
