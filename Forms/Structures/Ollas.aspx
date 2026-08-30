<%@ Page language="c#" Codebehind="Ollas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Ollas" %>
<%@ Register TagPrefix="uc1" TagName="OllaGrid" Src="../../Controls/OllaGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

	  </script>
		<script language="JavaScript">
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de ollas"
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
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowTitle()" marginheight="0" marginwidth="0">
		<form id="OllasForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<TBODY>
						<tr>
							<td class="contenido" colSpan="3">
								<div id="sicalMenu"></div>
							</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
								<span class="titulo">
									<SPAN class="letraAzulBold">Catálogo de Ollas</SPAN>
								</span></td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><asp:label id="Label1" runat="server" CssClass="standard-text">Es la lista de los ollas de PLASTIGLAS.</asp:label>&nbsp;</td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20" height="326">&nbsp;</td>
							<td width="700" height="326">
								<table cellSpacing="0" cellPadding="0" width="700" border="0">
									<TBODY>
										<tr>
											<td width="192" height="12">&nbsp;</td>
											<TD width="10" height="12"></TD>
											<td height="12"><span class="letraAzulBold"></span></td>
										</tr>
										<tr>
											<td class="contenido" vAlign="top" width="192">
												<TABLE  id="Table1" cellSpacing="6" cellPadding="0" width="171" border="0">
													<TR vAlign="top">
														<TD class="letraAzulBold" colSpan="2" height="12">Agregar una olla</TD>
													</TR>
													<TR>
														<TD width="47"><asp:label id="Label2" runat="server" CssClass="standard-text" Width="51px">No Olla</asp:label></TD>
														<td><asp:textbox id="txtNoOlla" runat="server" CssClass="standard-text" Width="100%" MaxLength="6"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidatorNoLote" runat="server" ErrorMessage="El número de Olla es un campo requerido" ControlToValidate="txtNoOlla">*</asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidatorNoLote" runat="server" ErrorMessage="El número de olla debe ser un número" ControlToValidate="txtNoOlla" Type="Integer" MinimumValue="1" MaximumValue="999999">*</asp:rangevalidator></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label5" runat="server" CssClass="standard-text">Descripción</asp:label></TD>
														<td><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" Width="100%" MaxLength="10"></asp:textbox>
															<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="La descripción de la Olla es un campo requerido" ControlToValidate="txtDescripcion">*</asp:requiredfieldvalidator></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label6" runat="server" CssClass="standard-text">Capacidad máxima</asp:label></TD>
														<td vAlign="top"><asp:textbox id="txtCapacidadMax" runat="server" CssClass="standard-text" Width="100%" MaxLength="11"></asp:textbox>
															<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="La capacidad máxima  de la Olla es un campo requerido" ControlToValidate="txtCapacidadMax">*</asp:requiredfieldvalidator>
															<asp:rangevalidator id="Rangevalidator2" runat="server" ErrorMessage="La capacidad m�xima debe ser un número en el rango de (0-999999)" ControlToValidate="txtCapacidadMax" Type="Double" MinimumValue="1" MaximumValue="999999">*</asp:rangevalidator></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label7" runat="server" CssClass="standard-text" Width="29px">Capacidad mínima</asp:label></TD>
														<td valign="middle"><asp:textbox id="txtCapacidadMin" runat="server" CssClass="standard-text" Width="100%" MaxLength="11"></asp:textbox>
															<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="La capacidad máxima de la Olla es un campo requerido" ControlToValidate="txtCapacidadMin">*</asp:requiredfieldvalidator>
															<asp:rangevalidator id="Rangevalidator3" runat="server" ErrorMessage="La capacidad máxima debe ser un número en el rango de (0-999999)" ControlToValidate="txtCapacidadMin" Type="Double" MinimumValue="1" MaximumValue="999999">*</asp:rangevalidator></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label3" runat="server" CssClass="standard-text">Planta</asp:label></TD>
														<td><asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="100%"></asp:dropdownlist></td>
													</TR>
													<TR vAlign="top">
														<TD width="47" height="19"><asp:label id="Label4" runat="server" CssClass="standard-text">Línea</asp:label></TD>
														<td><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="100%"></asp:dropdownlist></td>
													</TR>
													<TR vAlign="top">
														<TD vAlign="middle" align="center" colSpan="2">
															<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
																<TR>
																	<td height="20" width="40%"><asp:button id="cmdFProducto" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar"></asp:button></td>
																	<TD height="20" width="20%"></TD>
																	<TD height="20" width="40%"><asp:button id="cmdCancelC" runat="server" CssClass="botonesInput" Width="80px" Text="Cancelar" CausesValidation="False"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</td>
											<TD class="contenido" vAlign="top" width="10"></TD>
											<td class="contenido" vAlign="top">
												<P class="contenido" align="left"></P>
												<P class="contenido" align="left">
													<TABLE  id="Table3" height="99" cellSpacing="12" cellPadding="0" width="1000px" border="0">
														<TBODY>
															<TR vAlign="top">
																<TD style="padding-left:40px;">
																	<uc1:ollagrid id="OllasGridControl" runat="server"></uc1:ollagrid>
																</TD>
															</TR>
														</TBODY></TABLE>
												</P>
											</td>
										</tr>
										<tr>
											<TD colSpan="3"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary></TD>
										</tr>
										<tr colspan="3">
											<td><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
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
		</form></TD></TR></TBODY>
		<P></P></TR></TBODY></TABLE>
		<P></P></TD></TR></TBODY>
		<DIV></DIV></FORM></TABLE></TD></TR></TBODY>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
	</body>
</HTML>