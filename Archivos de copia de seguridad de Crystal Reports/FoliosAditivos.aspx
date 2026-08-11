<%@ Register TagPrefix="uc1" TagName="FoliosAditivosGrid" Src="../../Controls/FoliosAditivosGrid.ascx" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="FoliosAditivos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FoliosAditivos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script language="JavaScript">
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de ollas"
			}
		</script>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowTitle()"
		marginwidth="0" marginheight="0" onkeydown="return (event.keyCode!=13)">
		<form id="OllasForm" method="post" runat="server">
			<div align="center">
				<table height="443" cellSpacing="0" cellPadding="0" width="846" border="0">
					<TBODY>
						<tr>
							<td class="contenido" bgColor="#003366" colSpan="3"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
								<span class="titulo">
									<SPAN class="letraAzulBold">Catálogo de Folios de Aditivos</SPAN>
								</span></td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><asp:label id="Label1" runat="server" CssClass="standard-text">Lista de los Folios de Aditivos.</asp:label>&nbsp;</td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20" height="326">&nbsp;</td>
							<td width="700" height="326">
								<table cellSpacing="0" cellPadding="0" width="700" border="0">
									<TBODY>
										<tr>
											<td width="249" height="12">&nbsp;</td>
											<TD width="10" height="12"></TD>
											<td height="12"><span class="letraAzulBold"></span></td>
										</tr>
										<tr>
											<td class="contenido" vAlign="top" width="249">
												<TABLE class="tan-border" id="Table1" height="255" cellSpacing="6" cellPadding="0" width="236"
													border="0">
													<TR vAlign="top">
														<TD class="letraAzulBold" colSpan="2" height="12">Agregar un folio de Aditivos</TD>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label4" runat="server" CssClass="standard-text">Línea</asp:label></TD>
														<td><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="101px" AutoPostBack="True"></asp:dropdownlist></td>
													</TR>
													<TR>
														<TD width="47"><asp:label id="Label2" runat="server" CssClass="standard-text" Width="70px">Código SAP</asp:label></TD>
														<td><asp:dropdownlist id="cboCodigoSAP" runat="server" CssClass="standard-text" Width="101px" AutoPostBack="True"></asp:dropdownlist><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="cboCodigoSAP" ErrorMessage="El Código SAP es un campo requerido">*</asp:requiredfieldvalidator></td>
													</TR>
													<TR>
														<TD height="19" width="47"><asp:label id="lblMaterial" tabIndex="1" runat="server" CssClass="standard-text">Codigo SAP</asp:label></TD>
														<td><asp:textbox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="128px" AutoPostBack="True"
																MaxLength="10"></asp:textbox></td>
													</TR>
													<TR>
														<td colSpan="2"><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" Width="202px" BorderStyle="None"
																Enabled="False"></asp:textbox></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label5" runat="server" CssClass="standard-text">Folio</asp:label></TD>
														<td><asp:textbox id="txtFolio" runat="server" CssClass="standard-text" Width="128px" MaxLength="30"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtFolio" ErrorMessage="El Folio es un campo requerido">*</asp:requiredfieldvalidator></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" colSpan="2" height="19"><asp:label id="Label6" runat="server" CssClass="standard-text">Observaciones</asp:label></TD>
													</TR>
													<tr>
														<td vAlign="top" colSpan="2" height="59"><asp:textbox id="txtObservaciones" runat="server" CssClass="standard-text" Width="212px" MaxLength="100"
																TextMode="MultiLine" Height="49px"></asp:textbox></td>
													<TR vAlign="top">
														<TD vAlign="middle" align="center" colSpan="2">
															<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
																<TR>
																	<td height="30" width="70"><asp:button id="cmdFProducto" runat="server" CssClass="botonesInput" Width="64px" Text="Agregar"></asp:button></td>
																	<TD height="30" width="70"><asp:button id="cmdCancelC" runat="server" CssClass="botonesInput" Width="64px" Text="Cancelar"
																			CausesValidation="False"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label>
											</td>
											<TD class="contenido" vAlign="top" width="10"></TD>
											<td class="contenido" vAlign="top">
												<P class="contenido" align="left"></P>
												<P class="contenido" align="left">
													<TABLE class="tan-border" id="Table3" height="99" cellSpacing="12" cellPadding="0" width="171"
														border="0">
														<TBODY>
															<TR vAlign="top">
																<TD><uc1:FoliosAditivosGrid id="FoliosAditivosGridControl" runat="server"></uc1:FoliosAditivosGrid></TD>
															</TR>
														</TBODY></TABLE>
												</P>
											</td>
										</tr>
										<tr>
											<TD colSpan="3"></TD>
										</tr>
										<tr colspan="3">
											<td width="249"></td>
										</tr>
									</TBODY></table>
							</td>
							<td width="20" height="5">&nbsp;</td>
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
		</TD></TR></TBODY>
		<P></P>
		</TR></TBODY></TABLE>
		<P></P>
		</TD></TR></TBODY>
		<DIV></DIV>
		</FORM></TABLE></TD></TR></TBODY>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
	</body>
</HTML>
