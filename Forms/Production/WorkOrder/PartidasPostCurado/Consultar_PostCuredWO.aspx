<%@ Page language="c#" Codebehind="Consultar_PostCuredWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.Work_Order.Post_Cured.Consultar_PostCuredWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Consultar_PostCuredWO</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="javascript">	
		function showWaitControls()
		{
			waitControls.style.display='';
		}		
		var chrono;
		function reload_page() {
			//alert('actualizando pagina');
			self.location.reload(true);
		}
		function auto_refresh() {
			chrono=setInterval('reload_page()',30000);
			document.ConsultarCuredWO.tt.value = chrono;
			//alert(chrono);
		}	
		function stop_refresh() {
		    clearInterval(chrono);
			//alert('Auto refresh stopped');
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload='auto_refresh()'>
		<form id="Consultar_PostCuredWO" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td align="center" colSpan="4"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Fase de Post-Curado</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="Label6" runat="server" CssClass="standard-text"> Secuencia:</asp:label></td>
						<td><asp:label id="lblSecuencia" runat="server" CssClass="standard-text"></asp:label></td>
						<td><asp:label id="Label10" runat="server" CssClass="standard-text">Fecha:</asp:label></td>
						<td><asp:label id="lblFecha" runat="server" CssClass="standard-text"></asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label14" runat="server" CssClass="standard-text">UTEC:</asp:label></td>
						<td><asp:label id="lblUTEC" runat="server" CssClass="standard-text"></asp:label></td>
						<td><asp:label id="Label16" runat="server" CssClass="standard-text">Láminas:</asp:label></td>
						<td><asp:label id="lblCantidad" runat="server" CssClass="standard-text"></asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label19" runat="server" CssClass="standard-text">Familia</asp:label></td>
						<td><asp:label id="lblFamiliaProd" runat="server" CssClass="standard-text"></asp:label></td>
						<td>
							<asp:label id="lblTiempoPostreal" runat="server" CssClass="standard-text" Visible="False">Láminas:</asp:label></td>
						<td></td>
					</tr>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD bgColor="#276187" colSpan="4"><asp:label id="Label21" runat="server" Font-Bold="True" ForeColor="White" Height="16px" CssClass="standard-text">Seleccione la cuba de acuerdo a la siguiente información:</asp:label></TD>
					</TR>
					<TR>
						<TD bgColor="lightgrey"><asp:label id="Label22" runat="server" CssClass="standard-text">Tiempo de Post-Curado</asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="lblTiempoPost" runat="server" Font-Bold="True" CssClass="standard-text"></asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="Label23" runat="server" CssClass="standard-text">Temperatura de Post-Curado:</asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="lblTempPost" runat="server" Font-Bold="True" CssClass="standard-text"></asp:label></TD>
					</TR>
					<tr>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:label id="Label25" runat="server" CssClass="standard-text">Seleccionar Zona</asp:label></td>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:dropdownlist id="cboZonas" runat="server" CssClass="standard-text"></asp:dropdownlist></td>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:label id="Label26" runat="server" CssClass="standard-text">Temperatura de la Zona</asp:label></td>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:textbox id="txtTempZona" runat="server" CssClass="standard-text" Width="36px" BorderStyle="Groove"></asp:textbox><asp:label id="Label27" runat="server" CssClass="standard-text">grados</asp:label></td>
					</tr>
					<TR>
						<TD bgColor="#d3d3d3"><asp:label id="Label28" runat="server" CssClass="standard-text">Numero de Casette</asp:label></TD>
						<TD bgColor="#d3d3d3" colSpan="3"><asp:textbox id="txtKCT" runat="server" CssClass="standard-text" Width="81px" BorderStyle="Groove"></asp:textbox></TD>
					</TR>
					<tr>
						<td colSpan="4"><asp:panel id="pnlPostCured" Width="700px" Runat="server"></asp:panel></td>
					</tr>
					<tr>
						<td></td>
						<td></td>
						<td></td>
						<td></td>
					</tr>
					<TR>
						<td></td>
						<td colSpan="3"></td>
					</TR>
					<tr>
						<td colSpan="4"><asp:textbox id="txtPiso" runat="server" Height="70px" Width="100%" BorderStyle="Groove" TextMode="MultiLine"
								CssClass="standard-text" ReadOnly="True"></asp:textbox></td>
					</tr>
					<TR>
						<TD align="right" colSpan="4"></TD>
					</TR>
					<tr>
						<td align="right" colSpan="4">
							<TABLE width="700" align="center">
								<TR height="40">
									<TD vAlign="top" align="center" width="120">
										<asp:button id="cmdMensajePiso" runat="server" CssClass="botonesInput" Width="200px" DESIGNTIMEDRAGDROP="899"
											Text="Mensaje de Piso"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnTemperature" runat="server" CssClass="botonesInput" Width="200px" Text="Actualizar Temperatura"
											Enabled="False"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<asp:button id="cmdLiberar" runat="server" CssClass="botonesInput" Width="100px" Text="Liberar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnComienzo" runat="server" CssClass="botonesInput" Width="200px" Text="Comenzar Post-Curado"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<asp:button id="cmdCancelar" runat="server" CssClass="botonesInput" Width="80px" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE id="Table1" width="50">
												<TR>
													<TD vAlign="top" align="center" colSpan="3">
														<P align="center">
															<asp:label id="Label8" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
															<asp:image id="Image1" runat="server" ImageUrl="../../../../Images/waitImage.gif"></asp:image></P>
													</TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
