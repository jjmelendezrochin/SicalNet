<%@ Page language="c#" Codebehind="ConsultSeparacionWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultSeparacionWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language=javascript>	
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="WebForm1" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td colspan="4" align="center"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Fase de Separación</asp:Label><hr>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label6" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
						<td><asp:textbox id="txtSecuencia" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
						<td><asp:textbox id="txtFecha" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label5" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
						<td><asp:textbox id="txtUTEC" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label2" runat="server" CssClass="standard-text">Láminas:</asp:Label></td>
						<td><asp:textbox id="txtCantidad" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<P>
								<asp:Label id="Label4" runat="server" CssClass="standard-text">Familia Producto:</asp:Label></P>
						</td>
						<td><asp:textbox id="txtFamilia" Runat="server" CssClass="Standard-text" BorderStyle="Groove" Width="249px"
								ReadOnly="True"></asp:textbox></td>
						<td>
							<P>
								<asp:Label id="Label3" runat="server" CssClass="standard-text">Línea:</asp:Label></P>
						</td>
						<td><asp:textbox id="txtLinea" Runat="server" CssClass="Standard-text" BorderStyle="Groove" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td colspan="4">
							<div>
							</div>
						</td>
					</tr>
					<tr>
						<td colSpan="4" style="HEIGHT: 21px">
							<asp:Label id="Label7" runat="server" CssClass="standard-text">Mensaje de Piso:</asp:Label></td>
					</tr>
					<tr>
						<td colSpan="4"><asp:textbox id="txtPiso" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="700px"
								Height="65px" TextMode="MultiLine" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<TR>
						<TD colSpan="4">
							<TABLE width="100%" align="center">
								<TR height="40">
									<TD vAlign="top" align="center" width="150">
										<asp:button id="cmdAgregar" CssClass="botonesInput" Width="102px" Runat="server" Text="Mensaje de piso"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="cmdLiberar" CssClass="botonesInput" Width="80px" Runat="server" Text="Liberar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnAgregar" CssClass="botonesInput" Width="80px" Runat="server" Text="Aceptar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnCancelar" CssClass="botonesInput" Width="80px" Runat="server" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<DIV id="waitControls" style="DISPLAY: none">
										<TABLE id="Table1" width="50">
											<TR>
												<TD vAlign="top" align="center" colSpan="3">
													<P align="center">
														<asp:label id="Label8" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
														<asp:image id="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P>
												</TD>
											</TR>
										</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
