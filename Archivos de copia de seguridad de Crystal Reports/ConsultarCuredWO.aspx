<%@ Page language="c#" Codebehind="ConsultarCuredWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.CuredWO.ConsultarCuredWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarCuredWO</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="JavaScript">
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
		<form id="ConsultarCuredWO" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td align="center" colSpan="4"><asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Fase de Curado</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="Label1" runat="server" CssClass="standard-text"> Secuencia:</asp:label></td>
						<td><asp:label id="lblSecuencia" runat="server" CssClass="standard-text"></asp:label></td>
						<td><asp:label id="Label6" runat="server" CssClass="standard-text">Fecha:</asp:label></td>
						<td><asp:label id="lblFecha" runat="server" CssClass="standard-text"></asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label5" runat="server" CssClass="standard-text">UTEC:</asp:label></td>
						<td><asp:label id="lblUTEC" runat="server" CssClass="standard-text"></asp:label></td>
						<td><asp:label id="Label9" runat="server" CssClass="standard-text">Láminas:</asp:label></td>
						<td><asp:label id="lblCandidad" runat="server" CssClass="standard-text"></asp:label></td>
					</tr>
					<tr>
						<td><asp:label id="Label13" runat="server" CssClass="standard-text">Familia</asp:label></td>
						<td><asp:label id="lblFamilia" runat="server" CssClass="standard-text"></asp:label></td>
						<td>
							<asp:label id="lblTiempreal" runat="server" CssClass="standard-text" Visible="False">Láminas:</asp:label></td>
						<td></td>
					</tr>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD bgColor="#276187" colSpan="4"><asp:label id="Label8" runat="server" Font-Bold="True" CssClass="standard-text" Height="16px"
								ForeColor="White">Seleccione la cuba de acuerdo a la siguiente información:</asp:label></TD>
					</TR>
					<TR>
						<TD bgColor="lightgrey"><asp:label id="Label2" runat="server" CssClass="standard-text">Tiempo de Curado</asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="lblTiemp" runat="server" Font-Bold="True" CssClass="standard-text"></asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="Label4" runat="server" CssClass="standard-text">Temperatura de Curado:</asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="lblTemparaturo" runat="server" Font-Bold="True" CssClass="standard-text"></asp:label></TD>
					</TR>
					<tr>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:label id="Label3" runat="server" CssClass="standard-text">Seleccionar Cuba</asp:label></td>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:dropdownlist id="cboSel" runat="server" CssClass="standard-text"></asp:dropdownlist></td>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:label id="Label7" runat="server" CssClass="standard-text">Temperatura de la Cuba</asp:label></td>
						<td style="HEIGHT: 13px" bgColor="#d3d3d3"><asp:textbox id="txtTempCuba" runat="server" CssClass="standard-text" BorderStyle="Groove" Width="36px"></asp:textbox><asp:label id="Label10" runat="server" CssClass="standard-text">grados</asp:label></td>
					</tr>
					<TR>
						<TD bgColor="#d3d3d3"><asp:label id="Label11" runat="server" CssClass="standard-text">Numero de Casette</asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:textbox id="txtNumero" runat="server" CssClass="standard-text" BorderStyle="Groove" Width="81px"></asp:textbox>
							<INPUT id="tt" type="text" name="tt" style="WIDTH: 1px; HEIGHT: 1px" size="1" value="10000"
								runat="server">
						</TD>
						<TD bgColor="#d3d3d3"><asp:label id="Label12" runat="server" CssClass="standard-text">Percentage Curing Completed:</asp:label></TD>
						<TD bgColor="#d3d3d3"><asp:label id="lblPorcentage" runat="server" CssClass="standard-text">0</asp:label><asp:label id="lblPer" runat="server" CssClass="standard-text">%</asp:label></TD>
					</TR>
					<TR>
						<TD bgColor="#d3d3d3" colspan="4">
							<asp:CheckBox id="CheckBox1" runat="server" CssClass="standard-text"></asp:CheckBox></TD>
					</TR>
					<tr>
						<td colSpan="4"><asp:panel id="pnlCured" Width="700px" Runat="server"></asp:panel></td>
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
						<td colSpan="4"><asp:textbox id="txtPiso" runat="server" Height="70px" BorderStyle="Groove" Width="700px" TextMode="MultiLine"
								CssClass="standard-text" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td align="left" colSpan="4">
							<asp:TextBox id="txtHidden" runat="server" Width="1px"></asp:TextBox></td>
					</tr>
					<TR>
						<TD align="right" colSpan="4">
							<table width="100%" align="center">
								<TR height="40">
									<TD vAlign="top" align="center" width="120">
										<asp:button id="btnAgregar" runat="server" CssClass="botonesInput" Width="120px" Text="Mensaje de Piso"></asp:button></TD>
									<TD vAlign="top" align="center" width="120">
										<asp:button id="btnTemperature" runat="server" CssClass="botonesInput" Width="142px" Text="Actualizar Temperatura"
											Enabled="False"></asp:button></TD>
									<TD vAlign="top" align="center" width="120">
										<asp:button id="btnLiberar" runat="server" CssClass="botonesInput" Width="80px" Text="Liberar"></asp:button></TD>
									<TD vAlign="top" align="center" width="120">
										<asp:button id="btnComienzo" runat="server" CssClass="botonesInput" Width="120px" Text="Comenzar Curado"></asp:button></TD>
									<TD vAlign="top" align="center" width="120">
										<asp:button id="btnCancel" runat="server" CssClass="botonesInput" Width="80px" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE id="Table1" width="50">
												<TR>
													<TD vAlign="top" align="center" colSpan="3">
														<P align="center">
															<asp:label id="Label14" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
															<asp:image id="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P>
													</TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</table>
						</TD>
					</TR>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
