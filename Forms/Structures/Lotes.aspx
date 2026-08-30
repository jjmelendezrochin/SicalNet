<%@ Page language="c#" Codebehind="Lotes.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Lotes" %>
<%@ Register TagPrefix="uc1" TagName="LotesGrid" Src="../../Controls/LotesGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="JavaScript">
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Lotes"
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
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowTitle()" marginwidth="0" marginheight="0">
		<form id="LotesForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catálogo de Lotes</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><asp:label id="Label1" runat="server" CssClass="standard-text">Es la lista de los lotes de PLASTIGLAS.</asp:label>&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20" height="326">&nbsp;</td>
						<td width="700" height="326">
							<table cellSpacing="0" cellPadding="0" width="700" border="0">
								<tr>
									<td width="192" height="12">&nbsp;</td>
									<TD width="10" height="12"></TD>
									<td height="12"><span class="letraAzulBold"></span></td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="192">
										<TABLE  id="Table1" height="99" cellSpacing="12" cellPadding="0" width="171" border="0">
											<TR vAlign="top">
												<TD class="letraAzulBold" colSpan="2" height="13">Agregar un lote</TD>
											</TR>
											<TR>
												<TD width="47"><asp:label id="Label2" runat="server" CssClass="standard-text" Width="51px">No Lote</asp:label></TD>
												<td><asp:textbox id="txtNoLote" runat="server" CssClass="standard-text" Width="100%" MaxLength="6"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidatorNoLote" runat="server" ControlToValidate="txtNoLote" ErrorMessage="El número de Lote es un campo requerido">*</asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidatorNoLote" runat="server" ControlToValidate="txtNoLote" ErrorMessage="RangeValidator" MaximumValue="999999" MinimumValue="1" Type="Integer">*</asp:rangevalidator></td>
											</TR>
											<TR vAlign="top">
												<TD width="47" height="19"><asp:label id="Label3" runat="server" CssClass="standard-text">Línea</asp:label></TD>
												<td><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="100%"></asp:dropdownlist></td>
											</TR>
											<TR>
												<TD width="47" height="22"><asp:label id="Label4" runat="server" CssClass="standard-text" Width="53px">Piezas</asp:label></TD>
												<td><asp:textbox id="txtPiezas" runat="server" CssClass="standard-text" Width="100%" MaxLength="6"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidatorPiezas" runat="server" ControlToValidate="txtPiezas" ErrorMessage="El número de Piezas es un campo requerido">*</asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidatorPiezas" runat="server" ControlToValidate="txtPiezas" ErrorMessage="RangeValidator" MaximumValue="999999" MinimumValue="1" Type="Integer">*</asp:rangevalidator></td>
											</TR>
											<TR>
												<TD align="middle" colSpan="2"><asp:checkbox id="chkActivo" runat="server" CssClass="standard-text" Text="Activo"></asp:checkbox></TD>
											</TR>
											<TR vAlign="top">
												<TD vAlign="center" align="middle" colSpan="2">
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<td height="20" width="40%"><asp:button id="cmdFProducto" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar" OnClick="cmdFProducto_Click1"></asp:button></td>
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
											<TABLE  id="Table3" height="99" cellSpacing="12" cellPadding="0" width="300px" border="0">
												<TR vAlign="top">
													<TD style="padding-left:40px;">
														<uc1:lotesgrid id="LotesGridControl" runat="server"></uc1:lotesgrid>
													</TD>
												</TR>
											</TABLE>
										</P>
									</td>
								</tr>
								<tr>
									<TD colSpan="3"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary></TD>
								</tr>
								<tr colspan="3">
									<td><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
								</tr>
							</table>
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
				</table>
			</div>
		</form>
	</body>
</HTML>
