<%@ Register TagPrefix="uc1" TagName="FormTemparaturaGrid" Src="../../Controls/FormTemparaturaGrid.ascx" %>
<%@ Page language="c#" Codebehind="FormTemperatura.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormTemperatura" %>

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
	window.frames["top"].document.title = "SICAL  - Estructuras - Formulación de Temperatura"
}
		</script>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<!--onload="if ('<%= Session["errMsg"]%>' != '') alert('<%= Session["errMsg"]%>')"-->
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="FrmTemp" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<TBODY>
						<tr>
							<td class="contenido" colSpan="3" bgcolor="#003366">
								<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
							</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
								<span class="titulo">
									<SPAN class="letraAzulBold">Formulación de&nbsp;Temperatura</SPAN>
								</span></td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700">&nbsp;
								<asp:Label id="Label1" runat="server" CssClass="standard-text">Es la lista de las distintas plantas de Plastiglas en donde se producen laminas. Actualmente San Luis Potosí y Ocoyoacan</asp:Label></td>
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
												<TABLE class="tan-border" id="tableNewComponents" runat="server" height="99" cellSpacing="12" cellPadding="0" width="171" border="0">
													<TBODY>
														<TR vAlign="top">
															<TD class="letraAzulBold" height="13"></TD>
														</TR>
														<TR>
															<TD>
																<asp:Label id="Label2" runat="server" CssClass="standard-text">Familia de producto:</asp:Label><br>
																<asp:dropdownlist id="cboFamPdt" runat="server" Width="142px" CssClass="standard-text"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD>
																<asp:Label id="Label3" runat="server" CssClass="standard-text">Espesor:</asp:Label><br>
																<asp:dropdownlist id="cboEspesor" runat="server" Width="142px" CssClass="standard-text"></asp:dropdownlist></TD>
														</TR>
														<TR vAlign="top">
															<TD>
																<asp:Label id="Label4" runat="server" CssClass="standard-text">Linea:</asp:Label><br>
																<asp:dropdownlist id="cboLinea" runat="server" Width="142px" CssClass="standard-text"></asp:dropdownlist></TD>
														</TR>
														<TR vAlign="top">
															<TD>
																<asp:Label id="Label5" runat="server" CssClass="standard-text">Tiempo de Curado:</asp:Label><br>
																<asp:textbox id="txtTimeC" runat="server" Width="142px" CssClass="standard-text"></asp:textbox></TD>
														</TR>
														<TR vAlign="top">
															<TD>
																<asp:Label id="Label6" runat="server" CssClass="standard-text">Temperatura de Curado:</asp:Label><br>
																<asp:textbox id="txtTempC" runat="server" Width="142px" CssClass="standard-text"></asp:textbox></TD>
														</TR>
														<TR vAlign="top">
															<TD>
																<asp:Label id="Label7" runat="server" CssClass="standard-text">Tiempo de Post Curado:</asp:Label><br>
																<asp:textbox id="txtTimePC" runat="server" Width="142px" CssClass="standard-text"></asp:textbox></TD>
														</TR>
														<TR vAlign="top">
															<TD>
																<asp:Label id="Label8" runat="server" CssClass="standard-text">Temperatura de Post Curado:</asp:Label><br>
																<asp:textbox id="txtTempPc" runat="server" Width="142px" CssClass="standard-text"></asp:textbox></TD>
														</TR>
														<TR vAlign="top">
															<TD>
																<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD height="20"><asp:button id="AddFrmTemp" runat="server" Width="64px" CssClass="botonesInput" CausesValidation="False" Text="Agregar"></asp:button></TD>
																		<TD height="20"><asp:button id="cmdCancelC" runat="server" Width="64px" CssClass="botonesInput" CausesValidation="False" Text="Cancelar"></asp:button></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TBODY></TABLE>
											</td>
											<TD class="contenido" vAlign="top" width="10"></TD>
											<td class="contenido" vAlign="top">
												<P class="contenido" align="left"></P>
												<P class="contenido" align="left">
													<TABLE class="tan-border" id="Table3" height="99" cellSpacing="12" cellPadding="0" width="171" border="0">
														<TR vAlign="top">
															<TD><uc1:formtemparaturagrid id="FrmTempGridControl" runat="server"></uc1:formtemparaturagrid></TD>
														</TR>
													</TABLE>
												</P>
											</td>
										</tr>
									</TBODY></table>
							</td>
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
					</TBODY></table>
			</div>
		</form>
	</body>
</HTML>
