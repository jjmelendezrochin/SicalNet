<%@ Page language="c#" Codebehind="FoliosColor.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FoliosColor" %>
<%@ Register TagPrefix="uc1" TagName="FolioColorGrid" Src="../../Controls/FoliosColorGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="JavaScript">
            function ShowTitle() {
                window.frames["top"].document.title = "SICAL - Catálogos - Catálogo de Folios de Color";
            }
		</script>

		<script type="text/javascript">
            document.addEventListener(
                "DOMContentLoaded",
                function () {
                    SicalMenu.init("sicalMenu");
                }
            );
		</script>
	</HEAD>

	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		onkeydown="return (event.keyCode!=13)" marginheight="0" marginwidth="0">

		<form id="OllasForm" method="post" runat="server">
			<div align="center">

				<table border="0" cellSpacing="0" cellPadding="0" width="100%" height="443">
					<TBODY>

						<tr>
							<td class="contenido" colSpan="3">
								<div id="sicalMenu"></div>
							</td>
						</tr>

						<tr>
							<td width="20">&nbsp;</td>
							<td>
								<IMG src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
								<span class="titulo">
									<SPAN class="letraAzulBold">Catálogo de Folios de Color</SPAN>
								</span>
							</td>
							<td width="20">&nbsp;</td>
						</tr>

						<tr>
							<td width="20">&nbsp;</td>
							<td>
								<asp:label id="Label1" runat="server" CssClass="standard-text">
									Lista de los Folios de Color.
								</asp:label>&nbsp;
							</td>
							<td width="20">&nbsp;</td>
						</tr>

						<tr>
							<td height="326" width="20">&nbsp;</td>

							<td height="326">

								<table border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TBODY>

										<tr>
											<td height="12" width="249">&nbsp;</td>
											<TD height="12" width="20"></TD>
											<td height="12">
												<span class="letraAzulBold"></span>
											</td>
										</tr>

										<tr>

											<!-- PANEL IZQUIERDO -->
											<td class="contenido" vAlign="top" width="249" height="367">

												<TABLE id="Table1" class="tan-border" border="0"
													cellSpacing="6" cellPadding="0" width="236" height="255">

													<TR vAlign="top">
														<TD class="letraAzulBold" height="12" colSpan="2">
															Agregar un folio de Color
														</TD>
													</TR>

													<TR vAlign="top">
														<TD height="19" width="47">
															<asp:label id="Label4" runat="server"
																CssClass="standard-text">Línea</asp:label>
														</TD>
														<td>
															<asp:dropdownlist id="cboLinea" runat="server"
																CssClass="standard-text"
																AutoPostBack="True"
																Width="101px">
															</asp:dropdownlist>
														</td>
													</TR>
													<TR>
														<TD width="47">
															<asp:label id="Label2" runat="server"
																CssClass="standard-text"
																Width="70px">Código SAP</asp:label>
														</TD>
														<td>
															<asp:dropdownlist id="cboCodigoSAP" runat="server"
																CssClass="standard-text"
																Width="101px"
																AutoPostBack="True">
															</asp:dropdownlist>

															<asp:requiredfieldvalidator id="Requiredfieldvalidator2"
																runat="server"
																ErrorMessage="El Código SAP es un campo requerido"
																ControlToValidate="cboCodigoSAP">*</asp:requiredfieldvalidator>
														</td>
													</TR>

													<TR>
														<TD height="19" width="47">
															<asp:label id="lblMaterial" tabIndex="1"
																runat="server"
																CssClass="standard-text">Codigo SAP</asp:label>
														</TD>
														<td>
															<asp:textbox id="txtCodigoSAP" runat="server"
																CssClass="standard-text"
																Width="128px"
																AutoPostBack="True"
																MaxLength="10">
															</asp:textbox>
														</td>
													</TR>

													<TR>
														<td colSpan="2">
															<asp:textbox id="txtDescripcion" runat="server"
																CssClass="standard-text"
																Width="100%"
																BorderStyle="None"
																Enabled="False">
															</asp:textbox>
														</td>
													</TR>
													<TR>
														<TD height="19" width="47">
															<asp:label id="Label5" runat="server"
																CssClass="standard-text">Folio</asp:label>
														</TD>
														<td>
															<asp:textbox id="txtFolio" runat="server"
																CssClass="standard-text"
																Width="128px"
																MaxLength="10">
															</asp:textbox>

															<asp:requiredfieldvalidator id="Requiredfieldvalidator1"
																runat="server"
																ErrorMessage="El Folio es un campo requerido"
																ControlToValidate="txtFolio">*</asp:requiredfieldvalidator>
														</td>
													</TR>

													<TR vAlign="top">
														<TD height="19" width="47" colSpan="2">
															<asp:label id="Label6" runat="server"
																CssClass="standard-text">Observaciones</asp:label>
														</TD>
													</TR>

													<TR>
														<td height="59" vAlign="top" colSpan="2">
															<asp:textbox id="txtObservaciones" runat="server"
																CssClass="standard-text"
																Width="100%"
																MaxLength="100"
																Height="49px"
																TextMode="MultiLine">
															</asp:textbox>
														</td>
													</TR>

													<TR vAlign="top">
														<TD vAlign="middle" colSpan="2" align="center">

															<TABLE id="Table2" border="0"
																cellSpacing="0" cellPadding="0">
																<TR>
																	<td height="30" width="40%">
																		<asp:button id="cmdFProducto" runat="server"
																			CssClass="botonesInput"
																			Width="80px"
																			Text="Agregar">
																		</asp:button>
																	</td>

																	<td width="20%"></td>
																	<TD height="30" width="40%">
																		<asp:button id="cmdCancelC" runat="server"
																			CssClass="botonesInput"
																			Width="80px"
																			Text="Cancelar"
																			CausesValidation="False">
																		</asp:button>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>

												</TABLE>

												<asp:validationsummary id="ValidationSummary1" runat="server">
												</asp:validationsummary>

												<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text">
												</asp:label>

											</td>

											<!-- SEPARACIÓN ENTRE PANELES -->
											<TD class="contenido" vAlign="top" width="20" height="367">
												&nbsp;
											</TD>

											<!-- PANEL DERECHO: OCUPA TODO EL ESPACIO DISPONIBLE -->
											<td class="contenido" vAlign="top" width="100%" height="367">

												<TABLE id="Table3" class="tan-border"
													border="0"
													cellSpacing="12"
													cellPadding="0"
													width="100%">
													<TBODY>
														<TR vAlign="top">
															<TD width="100%">
																<uc1:foliocolorgrid
																	id="FoliosColorGridControl"
																	runat="server">
																</uc1:foliocolorgrid>
															</TD>
														</TR>
													</TBODY>
												</TABLE>

											</td>

										</tr>

										<tr>
											<TD colSpan="3"></TD>
										</tr>

										<tr>
											<td width="249"></td>
											<td width="20"></td>
											<td></td>
										</tr>

									</TBODY>
								</table>

							</td>

							<td height="5" width="20">&nbsp;</td>
						</tr>

						<tr>
							<td class="contenido" width="20">&nbsp;</td>
							<td class="contenido">
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

					</TBODY>
				</table>

			</div>
		</form>

	</body>
</HTML>
