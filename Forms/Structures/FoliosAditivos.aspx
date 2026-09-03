<%@ Register TagPrefix="uc1" TagName="FoliosAditivosGrid" Src="../../Controls/FoliosAditivosGrid.ascx" %>
<%@ Page language="c#" Codebehind="FoliosAditivos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FoliosAditivos" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="JavaScript">
            function ShowTitle() {
                window.frames["top"].document.title =
                    "SICAL - Catálogos - Catálogo de Folios de Aditivos";
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

	<body text="#000000"
		  bgColor="#ffffff"
		  leftMargin="0"
		  topMargin="0"
		  marginwidth="0"
		  marginheight="0"
		  onload="ShowTitle()"
		  onkeydown="return (event.keyCode!=13)">

		<form id="OllasForm" method="post" runat="server">

			<div align="center">
				<table 
					   cellSpacing="0"
					   cellPadding="0"					   
					   border="0"
					   width="800">

					<TBODY>
						<!-- MENÚ -->
						<tr class="sical-menu-row">
							<td class="contenido">
								<div id="sicalMenu"></div>
							</td>
						</tr>

						<!-- TÍTULO -->
						<tr>
							<td style="padding-left:20px; padding-right:20px;">
								<IMG height="7"
									 src="imagenes/ico-bullet.gif"
									 width="7">&nbsp;

								<span class="titulo">
									<SPAN class="letraAzulBold">
										Catálogo de Folios de Aditivos
									</SPAN>
								</span>
							</td>
						</tr>

						<!-- DESCRIPCIÓN -->
						<tr>
							<td style="padding-left:20px; padding-right:20px;">
								<asp:label id="Label1"
										   runat="server"
										   CssClass="standard-text">
									Lista de los Folios de Aditivos.
								</asp:label>
							</td>
						</tr>

						<!-- CONTENIDO PRINCIPAL -->
						<tr>
							<td height="326"
								style="padding-left:20px; padding-right:20px;">

								<table cellSpacing="0"
									   cellPadding="0"
									   width="100%"
									   border="0"
									   style="width:100%;">

									<TBODY>

										<!-- SEPARACIÓN SUPERIOR -->
										<tr>
											<td width="249" height="12">&nbsp;</td>
											<td width="20" height="12">&nbsp;</td>
											<td height="12">&nbsp;</td>
										</tr>

										<tr>

											<!-- PANEL IZQUIERDO -->
											<td class="contenido"
												vAlign="top"
												width="249">

												<TABLE id="Table1"
													   height="255"
													   cellSpacing="6"
													   cellPadding="0"
													   width="236"
													   border="0">

													<TR vAlign="top">
														<TD class="letraAzulBold"
															colSpan="2"
															height="12">
															Agregar un folio de Aditivos
														</TD>
													</TR>

													<TR vAlign="top">
														<TD width="47" height="19">
															<asp:label id="Label4"
																	   runat="server"
																	   CssClass="standard-text">
																Línea
															</asp:label>
														</TD>

														<td>
															<asp:dropdownlist id="cboLinea"
																			  runat="server"
																			  CssClass="standard-text"
																			  Width="101px"
																			  AutoPostBack="True">
															</asp:dropdownlist>
														</td>
													</TR>

													<TR>
														<TD width="47">
															<asp:label id="Label2"
																	   runat="server"
																	   CssClass="standard-text"
																	   Width="70px">
																Código SAP
															</asp:label>
														</TD>

														<td>
															<asp:dropdownlist id="cboCodigoSAP"
																			  runat="server"
																			  CssClass="standard-text"
																			  Width="101px"
																			  AutoPostBack="True">
															</asp:dropdownlist>

															<asp:requiredfieldvalidator id="Requiredfieldvalidator2"
																						runat="server"
																						ControlToValidate="cboCodigoSAP"
																						ErrorMessage="El Código SAP es un campo requerido">
																*
															</asp:requiredfieldvalidator>
														</td>
													</TR>

													<TR>
														<TD height="19" width="47">
															<asp:label id="lblMaterial"
																	   tabIndex="1"
																	   runat="server"
																	   CssClass="standard-text">
																Codigo SAP
															</asp:label>
														</TD>

														<td>
															<asp:textbox id="txtCodigoSAP"
																		 runat="server"
																		 CssClass="standard-text"
																		 Width="128px"
																		 AutoPostBack="True"
																		 MaxLength="10">
															</asp:textbox>
														</td>
													</TR>

													<TR>
														<td colSpan="2">
															<asp:textbox id="txtDescripcion"
																		 runat="server"
																		 CssClass="standard-text"
																		 Width="100%"
																		 BorderStyle="None"
																		 Enabled="False">
															</asp:textbox>
														</td>
													</TR>

													<TR vAlign="top">
														<TD width="47" height="19">
															<asp:label id="Label5"
																	   runat="server"
																	   CssClass="standard-text">
																Folio
															</asp:label>
														</TD>

														<td>
															<asp:textbox id="txtFolio"
																		 runat="server"
																		 CssClass="standard-text"
																		 Width="128px"
																		 MaxLength="30">
															</asp:textbox>

															<asp:requiredfieldvalidator id="Requiredfieldvalidator1"
																						runat="server"
																						ControlToValidate="txtFolio"
																						ErrorMessage="El Folio es un campo requerido">
																*
															</asp:requiredfieldvalidator>
														</td>
													</TR>

													<TR vAlign="top">
														<TD width="47"
															colSpan="2"
															height="19">
															<asp:label id="Label6"
																	   runat="server"
																	   CssClass="standard-text">
																Observaciones
															</asp:label>
														</TD>
													</TR>

													<TR>
														<td vAlign="top"
															colSpan="2"
															height="59">
															<asp:textbox id="txtObservaciones"
																		 runat="server"
																		 CssClass="standard-text"
																		 Width="100%"
																		 MaxLength="100"
																		 TextMode="MultiLine"
																		 Height="49px">
															</asp:textbox>
														</td>
													</TR>

													<TR vAlign="top">
														<TD vAlign="middle"
															align="center"
															colSpan="2">

															<TABLE id="Table2"
																   cellSpacing="0"
																   cellPadding="0"
																   border="0">

																<TR>
																	<td height="30" width="40%">
																		<asp:button id="cmdFProducto"
																					runat="server"
																					CssClass="botonesInput"
																					Width="80px"
																					Text="Agregar">
																		</asp:button>
																	</td>

																	<td width="20%">
																		&nbsp;
																	</td>

																	<TD height="30" width="40%">
																		<asp:button id="cmdCancelC"
																					runat="server"
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

												<asp:validationsummary id="ValidationSummary1"
																	   runat="server">
												</asp:validationsummary>

												<asp:label id="lblErrorMsg"
														   runat="server"
														   CssClass="standard-text">
												</asp:label>

											</td>

											<!-- SEPARACIÓN ENTRE PANEL Y GRID -->
											<TD class="contenido"
												vAlign="top"
												width="20">
												&nbsp;
											</TD>

											<!-- PANEL DERECHO -->
											<td class="contenido"
												vAlign="top"
												width="100%">

												<TABLE id="Table3"
													   cellSpacing="12"
													   cellPadding="0"
													   width="100%"
													   border="0"
													   style="width:100%;">

													<TBODY>
														<TR vAlign="top">
															<TD width="100%">
																<uc1:FoliosAditivosGrid
																	id="FoliosAditivosGridControl"
																	runat="server">
																</uc1:FoliosAditivosGrid>
															</TD>
														</TR>
													</TBODY>

												</TABLE>

											</td>

										</tr>

									</TBODY>
								</table>

							</td>
						</tr>

						<!-- ESPACIO INFERIOR -->
						<tr>
							<td class="contenido">
								<div align="right"></div>
							</td>
						</tr>

						<tr>
							<td>
								<div align="right"></div>
							</td>
						</tr>

					</TBODY>
				</table>

			</div>

		</form>

	</body>
</HTML>
