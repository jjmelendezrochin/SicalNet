<%@ Register TagPrefix="uc1" TagName="PlantGrid" Src="../../Controls/PlantGrid.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AnillosGrid" Src="../../Controls/AnillosGrid.ascx" %>
<%@ Page language="c#" Codebehind="Anillos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Anillos" %>

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
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Plantas"
			}
		</script>
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
	</HEAD>
	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		marginheight="0" marginwidth="0">
		<form id="PlantaForm" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="740">
					<tr>
						<td class="contenido" bgColor="#003366" colSpan="2"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><IMG src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catalogo de Anillos</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><asp:label id="Label1" runat="server" CssClass="standard-text"> Es la lista de los Códigos Sap y su diametro por línea</asp:label>&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td height="414" width="20">&nbsp;</td>
						<td height="414" width="700">
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
												<TD class="letraAzulBold" height="13">Agregue un Anillo</TD>
											</TR>
											<TR>
												<TD>
													<P><asp:label id="Label2" runat="server" CssClass="standard-text"> Código Sap</asp:label><br>
														<asp:textbox style="Z-INDEX: 0" id="txtCodigoSap" runat="server" CssClass="standard-text" Width="142px"
															BackColor="#FFC0C0"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD>
													<P><asp:label id="Label3" runat="server" CssClass="standard-text">Línea I</asp:label><br>
														<asp:textbox id="txtLI" runat="server" CssClass="standard-text" Width="142px"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD>
													<P><asp:label id="Label4" runat="server" CssClass="standard-text"> Línea II</asp:label><br>
														<asp:textbox id="txtLII" runat="server" CssClass="standard-text" Width="142px"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD>
													<P><asp:label id="Label5" runat="server" CssClass="standard-text">Línea III</asp:label><br>
														<asp:textbox id="txtLIII" runat="server" CssClass="standard-text" Width="142px"></asp:textbox></P>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<TD height="20"><asp:button id="cmdAgregar" runat="server" CssClass="botonesInput" Width="64px" CausesValidation="False"
																	Text="Agregar"></asp:button><asp:button style="Z-INDEX: 0" id="cmdConsultar" runat="server" CssClass="botonesInput" Width="64px"
																	CausesValidation="False" Text="Consultar"></asp:button>
																<asp:button style="Z-INDEX: 0" id="cmdTodos" runat="server" CssClass="botonesInput" Width="64px"
																	Text="Todos" CausesValidation="False"></asp:button></TD>
															<TD height="20"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<P><asp:validationsummary style="Z-INDEX: 0" id="ValidationSummary1" runat="server"></asp:validationsummary></P>
										<P><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<td class="contenido" vAlign="top">
										<P class="contenido" align="left"></P>
										<P class="contenido" align="left">
											<TABLE id="Table3" class="tan-border" border="0" cellSpacing="12" cellPadding="0" width="171"
												height="99">
												<TR vAlign="top">
													<TD><uc1:anillosgrid id="AnillosGridControl" runat="server"></uc1:anillosgrid></TD>
												</TR>
											</TABLE>
										</P>
									</td>
								</tr>
							</table>
						</td>
						<td height="414" width="20">&nbsp;</td>
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
