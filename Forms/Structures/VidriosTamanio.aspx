<%@ Register TagPrefix="uc1" TagName="VidriosTamanio" Src="../../Controls/VidriosTamanio.ascx" %>
<%@ Page language="c#" Codebehind="VidriosTamanio.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.VidriosTamanio" %>
<%@ Register TagPrefix="uc1" TagName="MedidaGrid" Src="../../Controls/MedidaGrid.ascx" %>

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
				window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Tamaño de Vidrios"
		}

        function ConfirmarInsertarMedidaVidrio(button) {

            SicalAlert.confirmar(
                "¿Está seguro que desea insertar esta medida de vidrio?",
                "Confirmar inserción",
                function () {

                    button.onclick = null;
                    button.click();
                }
            );

            return false;
        }

        </script>
		

		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body onload="ShowTitle()" leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000"
		marginheight="0" marginwidth="0">
		<form id="MedidaForm" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="740">
					<tr>
						<td class="contenido" colSpan="2">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><IMG src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catalogo de Tamaños de Vidrios</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><asp:label id="Label2" runat="server" CssClass="standard-text" Visible="False"> Es el cat�logo de medidas de Vidrios usado en PLASTIGLAS.</asp:label>&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<table border="0" cellSpacing="0" cellPadding="0" width="700">
								<tr>
									<td height="12" width="20">&nbsp;</td>
									<TD height="12" width="10"></TD>
									<td height="12"><span class="letraAzulBold"></span></td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="20">
										<TABLE id="Table1"  border="0" cellSpacing="12" cellPadding="0" width="171"
											height="99">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">Agregar una Medida de Vidrio</TD>
											</TR>
											<TR>
												<TD><asp:label id="Label1" runat="server" CssClass="standard-text">Id tamanio:</asp:label><br>
													<asp:textbox id="txtIdTamanio" runat="server" CssClass="standard-text" Visible="False" Enabled="False"
														Width="142px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label3" runat="server" CssClass="standard-text"> Medida: </asp:label><br>
													<asp:textbox id="txtMedida" runat="server" CssClass="standard-text" Enabled="False" Width="100%"
														MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD height="32"><asp:label id="Label4" runat="server" CssClass="standard-text"> Medida Vidrio: </asp:label><br>
													<asp:textbox id="txtMedidaVidrio" runat="server" CssClass="standard-text" Enabled="False" Width="100%"
														MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD><asp:label id="Label6" runat="server" CssClass="standard-text" style="Z-INDEX: 0">Largo Normal: </asp:label><br>
													<asp:textbox id="txtLargoNormal" runat="server" CssClass="standard-text" Width="100%" MaxLength="20"
														style="Z-INDEX: 0"></asp:textbox>
													<asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator5" runat="server" ControlToValidate="txtLargoNormal"
														ErrorMessage="Largo Normal es un campo requerido">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR vAlign="top">
												<TD><asp:label id="Label5" runat="server" CssClass="standard-text" style="Z-INDEX: 0">Ancho Normal: </asp:label><br>
													<asp:textbox id="txtAnchoNormal" runat="server" CssClass="standard-text" Width="100%" MaxLength="20"
														style="Z-INDEX: 0"></asp:textbox>
													<asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtAnchoNormal"
														ErrorMessage="Ancho Normal es un campo requerido">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR vAlign="top">
												<TD><asp:label id="Label8" runat="server" CssClass="standard-text" style="Z-INDEX: 0">Largo Vidrio: </asp:label><br>
													<asp:textbox style="Z-INDEX: 0" id="txtLargoVidrio" runat="server" CssClass="standard-text" Width="100%"
														MaxLength="20"></asp:textbox>
													<asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtLargoVidrio"
														ErrorMessage="Largo Vidrio es un campo requerido">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR vAlign="top">
												<TD><asp:label id="Label7" runat="server" CssClass="standard-text" style="Z-INDEX: 0">Ancho Vidrio:</asp:label><br>
													<asp:textbox style="Z-INDEX: 0" id="txtAnchoVidrio" runat="server" CssClass="standard-text" 
														Width="100%"
														MaxLength="20"></asp:textbox>
													<asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator3" runat="server" ControlToValidate="txtAnchoVidrio"
														ErrorMessage="Ancho Vidrio es un campo requerido">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR vAlign="top">
												<TD><asp:label id="Label9" runat="server" CssClass="standard-text"> Espesor:</asp:label><br>
													<asp:textbox style="Z-INDEX: 0" id="txtEspesor" runat="server" CssClass="standard-text" Width="100%"
														MaxLength="20"></asp:textbox>
													<asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtEspesor"
														ErrorMessage="Espesor es un campo requerido">*</asp:requiredfieldvalidator>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD><asp:label id="Label10" runat="server" CssClass="standard-text"> Grosor:</asp:label><br>
													<asp:textbox style="Z-INDEX: 0" id="txtGrosor" runat="server" CssClass="standard-text" Width="100%"
														MaxLength="2"></asp:textbox>
													<asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator6" runat="server" ControlToValidate="txtGrosor"
														ErrorMessage="Grosor es un campo requerido">*</asp:requiredfieldvalidator>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
														<TR>
															<TD width="40%">
																<asp:button id="cmdAdd" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar" OnClick="cmdAdd_Click1"></asp:button>
															</TD>
															<TD width="20%"></TD>
															<TD width="40%">
																<asp:button id="cmdCancel" runat="server" CssClass="botonesInput" Width="80px" CausesValidation="False"
																	Text="Cancelar"></asp:button>
															</TD>
														</TR>
														<tr>
															<td colspan="2">&nbsp;
																<asp:validationsummary style="Z-INDEX: 0" id="ValidationSummary1" runat="server" Width="153px" Font-Size="Smaller"
																	Height="32px"></asp:validationsummary></td>
														</tr>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<td class="contenido" vAlign="top">
										<P class="contenido" align="left"></P>
										<P class="contenido" align="left">
											<TABLE id="Table3"  border="0" cellSpacing="12" cellPadding="0" width="1000px"
												height="99">
												<TR vAlign="top">
													<TD style="padding-left:40px;">
														<uc1:vidriostamanio id="VidriosTamanio1" runat="server"></uc1:vidriostamanio>
													</TD>
												</TR>
											</TABLE>
										</P>
									</td>
								</tr>
							</table>
							<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
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
