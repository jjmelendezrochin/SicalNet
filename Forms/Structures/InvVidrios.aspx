<%@ Register TagPrefix="uc1" TagName="InventarioVidrios" Src="../../Controls/InventarioVidrios.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TarjetaVidriosHistorial" Src="../../Controls/TarjetaVidriosHistorial.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TarjetaVidriosPlanimetria" Src="../../Controls/TarjetaVidriosPlanimetria.ascx" %>
<%@ Page language="c#" Codebehind="InvVidrios.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.InvVidrios" %>
<%@ Register TagPrefix="uc1" TagName="TarjetaVidrioPlanimetriaEditar" Src="../../Controls/TarjetaVidrioPlanimetriaEditar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TarjetaVidrioEspesorEditar" Src="../../Controls/TarjetaVidrioEspesorEditar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TarjetaVidriosEspesor" Src="../../Controls/TarjetaVidriosEspesor.ascx" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		

		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		
		<script language="JavaScript">
			<!--
			function GetDate(CtrlName)        
			{   
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			} 
			
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
		marginwidth="0" marginheight="0">
		<form id="MedidaForm" method="post" runat="server">
			<DIV align="center">
				<table style="border-collapse: collapse; margin-top: 0; padding-top: 0;"; width="1000"; align="center">
					<tbody>
                        <tr class="sical-menu-row">
                            <td align="left" colspan="4" style="padding: 0; margin: 0; vertical-align: top;">
                                <div id="sicalMenu"></div>
                            </td>
                        </tr>
					</tbody>
				</table>
				<table border="0" cellSpacing="0" cellPadding="0" width="80%">					
                    <tr>
                        <td width="20">&nbsp;</td>
                        <td width="700">
                            <img src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
							<span class="titulo">
                                <span class="letraAzulBold">Inventario de Vidrios</span>
                            </span></td>
                        <td width="20">&nbsp;</td>
                    </tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="80%">
							<table id="Table0" border="0" cellSpacing="0" cellPadding="0" width="700">
								<tr>
									<td height="12" width="322">&nbsp;</td>
									<TD height="12" width="10"></TD>
									<td height="12"><span class="letraAzulBold"></span></td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="40%">
										<TABLE id="Table1" border="0" cellSpacing="12" cellPadding="0" width="225">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13" colSpan="2">Inventario de Vidrios</TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label id="Label1" runat="server" CssClass="standard-text">Identificador:</asp:label></TD>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="standard-text">Fecha Capa:</asp:label></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox id="txtIdVidrio" runat="server" CssClass="standard-text" Height="21px" Enabled="False"
														Width="24px"></asp:textbox></TD>
												<TD><asp:textbox style="Z-INDEX: 0" id="txtFechaCapa" runat="server" CssClass="standard-text" Width="100px"></asp:textbox><asp:image style="Z-INDEX: 0" id="Image1" onmouseup="GetDate('txtFechaCapa');" ImageUrl="../../Images/icon-calendar.gif"
														AlternateText="Inicial Date" Runat="server"></asp:image><asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator5" runat="server" ControlToValidate="txtFechaCapa"
														ErrorMessage="Fecha de Capa es un campo requerido">*</asp:requiredfieldvalidator></TD>
											<TR>
												<TD width="50%"><asp:label id="Label4" runat="server" CssClass="standard-text">Clave Fabricante:</asp:label></TD>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="standard-text" Width="122px">Fecha Inicio de Uso:</asp:label></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox id="txtClaveFabricante" runat="server" CssClass="standard-text" Height="21px" Width="100px"></asp:textbox><asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator3" runat="server" ControlToValidate="txtClaveFabricante"
														ErrorMessage="Fabricante es un campo requerido">*</asp:requiredfieldvalidator></TD>
												<TD><asp:textbox style="Z-INDEX: 0" id="txtFechaInicio" runat="server" CssClass="standard-text" Width="100px"></asp:textbox><asp:image style="Z-INDEX: 0" id="imgFrom" onmouseup="GetDate('txtFechaInicio');" ImageUrl="../../Images/icon-calendar.gif"
														AlternateText="Inicial Date" Runat="server"></asp:image><asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtFechaInicio"
														ErrorMessage="Fecha de Inicio es un campo requerido">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label id="Label6" runat="server" CssClass="standard-text">Clave Interna:</asp:label></TD>
												<TD width="50%"></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox id="txtNumeroVidrio" runat="server" CssClass="standard-text" Width="120px" MaxLength="12"></asp:textbox><asp:requiredfieldvalidator style="Z-INDEX: 0" id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtNumeroVidrio"
														ErrorMessage="Clave interna es un campo requerido">*</asp:requiredfieldvalidator></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label id="Label8" runat="server" CssClass="standard-text">Tama&ntilde;o:</asp:label></TD>
												<TD width="50%"><asp:label id="Label9" runat="server" CssClass="standard-text" Width="140px">Clasificaci&oacute;n Calidad:</asp:label></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:dropdownlist id="cboVidrioTamanio" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Tama&#241;o --" Selected="True">-- Tama&#241;o --</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD><asp:dropdownlist id="cboClasificacionCalidad" runat="server" CssClass="standard-text">
														<asp:ListItem Selected="True">-- Clasificación --</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label id="Label10" runat="server" CssClass="standard-text">Proveedor:</asp:label></TD>
												<TD width="50%"><asp:label id="Label11" runat="server" CssClass="standard-text">Tipo:</asp:label></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:dropdownlist id="cboProveedor" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Proveedor --" Selected="True">-- Proveedor --</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD><asp:dropdownlist id="cboTipo" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Tipo --" Selected="True">-- Tipo --</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label id="Label12" runat="server" CssClass="standard-text">Línea:</asp:label></TD>
												<TD width="50%"><asp:label id="Label13" runat="server" CssClass="standard-text">Lote:</asp:label></TD>
											</TR>
											<TR>
												<TD height="27" width="116"><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text">
														<asp:ListItem Selected="True">-- Linea --</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD height="27"><asp:textbox id="txtLote" runat="server" CssClass="standard-text" Width="90px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label15" runat="server" CssClass="standard-text" Width="179px">Clasificación Conservación:</asp:label></TD>
												<TD width="50%">
													<P><asp:label style="Z-INDEX: 0" id="Label16" runat="server" CssClass="standard-text" Width="56px">Espesor:</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD width="50%"><asp:dropdownlist style="Z-INDEX: 0" id="cboClasificacionConservacion" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Linea --" Selected="True">-- Clasificación --</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD><asp:dropdownlist style="Z-INDEX: 0" id="cboEspesor" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Espesor --" Selected="True">-- Espesor --</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="standard-text" Width="179px">Costo de factura en dólares:</asp:label></TD>
												<TD width="50%">
													<P><asp:label style="Z-INDEX: 0" id="Label17" runat="server" CssClass="standard-text" Width="152px">Costo de factura en pesos:</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox id="txtCostoDolares" runat="server" CssClass="standard-text" Width="56px"></asp:textbox></TD>
												<TD><asp:textbox id="txtCostoPesos" runat="server" CssClass="standard-text" Width="58px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" CssClass="standard-text" Width="179px">Fecha Rotura:</asp:label></TD>
												<TD width="50%">
													<P>&nbsp;</P>
												</TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtFechaRotura" runat="server" CssClass="standard-text" Width="100px"></asp:textbox><asp:image style="Z-INDEX: 0" id="Image4" onmouseup="GetDate('txtFechaRotura');" ImageUrl="../../Images/icon-calendar.gif"
														AlternateText="Inicial Date" Runat="server"></asp:image></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label14" runat="server" CssClass="standard-text" Width="179px">Fecha Amortización:</asp:label></TD>
												<TD width="50%">
													<P><asp:label style="Z-INDEX: 0" id="Label18" runat="server" CssClass="standard-text" Width="152px">Causa:</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtFechaAmortizacion" runat="server" CssClass="standard-text"
														Width="100px"></asp:textbox><asp:image style="Z-INDEX: 0" id="Image2" onmouseup="GetDate('txtFechaAmortizacion');" ImageUrl="../../Images/icon-calendar.gif"
														AlternateText="Inicial Date" Runat="server"></asp:image></TD>
												<TD><asp:dropdownlist style="Z-INDEX: 0" id="cboCausaAmortizacion" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Tipo --" Selected="True">-- Causa --</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD width="50%"><asp:label style="Z-INDEX: 0" id="Label19" runat="server" CssClass="standard-text" Width="179px">Fecha Daño:</asp:label></TD>
												<TD width="50%">
													<P><asp:label style="Z-INDEX: 0" id="Label20" runat="server" CssClass="standard-text" Width="152px">Causa:</asp:label></P>
												</TD>
											</TR>
											<TR>
												<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtFechaDanio" runat="server" CssClass="standard-text" Width="100px"></asp:textbox><asp:image style="Z-INDEX: 0" id="Image3" onmouseup="GetDate('txtFechaDanio');" ImageUrl="../../Images/icon-calendar.gif"
														AlternateText="Inicial Date" Runat="server"></asp:image></TD>
												<TD><asp:dropdownlist style="Z-INDEX: 0" id="cboCausaDanio" runat="server" CssClass="standard-text">
														<asp:ListItem Value="-- Tipo --" Selected="True">-- Causa --</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<!-- **************************************************************************** -->
											<TR vAlign="top">
												<TD colSpan="2">
													<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD height="20" align="center">
																<asp:button id="cmdAdd" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar"></asp:button>
																<asp:button style="Z-INDEX: 0" id="cmdEditar" runat="server" CssClass="botonesInput" Width="80px"
																	Text="Guardar"></asp:button></TD>
															<TD height="20" align="center">
																<asp:button id="cmdCancel" runat="server" CssClass="botonesInput" Width="80px" Text="Cancelar"
																	CausesValidation="False"></asp:button></TD>
														</TR>
														<tr>
															<td colSpan="2">
																<P><asp:validationsummary style="Z-INDEX: 0" id="ValidationSummary1" runat="server" Height="26px" Width="340px"
																		Font-Size="Smaller"></asp:validationsummary></P>
																<P><asp:label style="Z-INDEX: 0" id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
															</td>
														</tr>
													</TABLE>
													<P><asp:regularexpressionvalidator style="Z-INDEX: 0" id="RegularExpressionValidator2" runat="server" Width="328px"
															ControlToValidate="txtNumeroVidrio" ErrorMessage="Clave Interna debe ser numérica" Font-Size="Smaller" ValidationExpression="[0-9]*"></asp:regularexpressionvalidator><asp:regularexpressionvalidator style="Z-INDEX: 0" id="RegularExpressionValidator1" runat="server" Width="304px"
															ControlToValidate="txtLote" ErrorMessage="Lote debe ser numérico" Font-Size="Smaller" ValidationExpression="[0-9]*"></asp:regularexpressionvalidator></P>
												</TD>
											</TR>
										</TABLE>
									</td>
									<td class="contenido" vAlign="top" width="50%">
										<TABLE id="Table3" width="90%" height="100%">
											<TR vAlign="top">
												<TD><uc1:inventariovidrios id="InventarioVidrios1" runat="server"></uc1:inventariovidrios></TD>
											</TR>
											<TR>
												<TD>
													<TABLE id="Table4" width="100%" height="100%">
														<TR>
															<TD align="left"><asp:label style="Z-INDEX: 0" id="lblTarjeta" runat="server" CssClass="standard-text" Font-Size="X-Small"
																	Font-Bold="True">Tarjeta de Identificación de Vidrios</asp:label></TD>
														</TR>
														<TR>
															<TD align="left"><uc1:tarjetavidrioshistorial id="TarjetaVidriosHistorial1" runat="server"></uc1:tarjetavidrioshistorial></TD>
														</TR>
														<TR>
															<TD align="left">
																<P><uc1:tarjetavidriosplanimetria id="TarjetaVidriosPlanimetria1" runat="server"></uc1:tarjetavidriosplanimetria><uc1:tarjetavidriosespesor style="Z-INDEX: 0" id="TarjetaVidriosEspesor1" runat="server"></uc1:tarjetavidriosespesor><uc1:tarjetavidrioplanimetriaeditar style="Z-INDEX: 0" id="TarjetaVidrioPlanimetriaEditar1" runat="server"></uc1:tarjetavidrioplanimetriaeditar><uc1:tarjetavidrioespesoreditar id="TarjetaVidrioEspesorEditar1" runat="server"></uc1:tarjetavidrioespesoreditar></P>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
							<P><asp:dropdownlist style="Z-INDEX: 0" id="cboPlanta" runat="server" CssClass="standard-text" Width="48px"
									Visible="False">
									<asp:ListItem Value="-- Planta --" Selected="True">-- Planta --</asp:ListItem>
								</asp:dropdownlist><asp:label style="Z-INDEX: 0" id="Label21" runat="server" CssClass="standard-text" Visible="False">Planta:</asp:label></P>
						</td>
					</tr>
				</table>
			</DIV>
			
			<DIV align="center">
				<table style="Z-INDEX: 0" width="730" height="82">
					<TR>
						<td colSpan="5" align="center"><span class="letraAzulBold">Reportes</span></td>
					</TR>
					<TR>
						<td height="24" width="140" colspan="2">
							<asp:label style="Z-INDEX: 0" id="Label22" runat="server" CssClass="standard-text" Width="21px">Linea:</asp:label><br>
							<asp:dropdownlist style="Z-INDEX: 0" id="cboLineaReporte" runat="server" CssClass="standard-text"
								Width="285px">
								<asp:ListItem Value="-- Linea --" Selected="True">-- Linea --</asp:ListItem>
							</asp:dropdownlist></td>
						<td height="24">
							<asp:label style="Z-INDEX: 0" id="lblFechaInicial" runat="server" CssClass="standard-text"
								Width="71px" Height="15px">Fecha Inicial</asp:label>
							<asp:textbox style="Z-INDEX: 0" id="txtFechaInicial" runat="server" CssClass="standard-text"
								Width="121px" BorderStyle="Groove"></asp:textbox>
							<asp:imagebutton style="Z-INDEX: 0" id="imgFInicial" onmouseup="GetDate('txtFechaInicial');" runat="server"
								ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton></td>
						<TD height="24">
							<asp:label style="Z-INDEX: 0" id="Label23" runat="server" CssClass="standard-text" Width="72px"
								Height="13px">Fecha Final</asp:label>
							<asp:textbox style="Z-INDEX: 0" id="txtFechaFinal" runat="server" CssClass="standard-text" Width="121px"
								BorderStyle="Groove"></asp:textbox>
							<asp:imagebutton style="Z-INDEX: 0" id="imgFFinal" onmouseup="GetDate('txtFechaFinal');" runat="server"
								ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton></TD>
						<TD height="24">
							<asp:label style="Z-INDEX: 0" id="Label24" runat="server" CssClass="standard-text" Width="104px">Clasificación:</asp:label><br>
							<asp:dropdownlist style="Z-INDEX: 0" id="cboClasificacionReporte" runat="server" CssClass="standard-text"
								Width="108px">
								<asp:ListItem Value="-- Clasificaci&#243;n --" Selected="True">-- Clasificaci&#243;n --</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<td width="140">
							<P align="center"><asp:button style="Z-INDEX: 0" id="cmdReporteGlobal" runat="server" CssClass="botonesInput"
									Width="130px" Text="Reporte Global" CausesValidation="False"></asp:button></P>
						</td>
						<td width="156" align="center">
							<asp:button style="Z-INDEX: 0" id="cmdReporteUsoxLinea" runat="server" CssClass="botonesInput"
								Width="150px" Text="Reporte Uso x Línea" CausesValidation="False"></asp:button></td>
						<td align="center" colspan="3">
							<asp:button style="Z-INDEX: 0" id="cmdReporteRDA" runat="server" CssClass="botonesInput" 
								Width="250px"
								Text="Reporte Rotos, Dañados y Amortizados" CausesValidation="False"></asp:button></td>
					</TR>
				</table>
			</DIV>
		</form>
	</body>
</HTML>
