<%@ Page language="c#" Codebehind="ConsultPreseparationWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultPreseparationWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultPreseparationWO1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">	
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultPreseparationWO1" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td colspan="4" align="center"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Fase de Preseparación</asp:Label><hr>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label4" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
						<td style="WIDTH: 196px"><asp:textbox id="txtSecuencia" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label6" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
						<td><asp:textbox id="txtFecha" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label5" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
						<td style="WIDTH: 196px"><asp:textbox id="txtUTEC" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label7" runat="server" CssClass="standard-text">Láminas:</asp:Label></td>
						<td><asp:textbox id="txtCantidad" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<P>&nbsp;</P>
						</td>
						<td style="WIDTH: 196px"></td>
						<td>
							<P>
								<asp:Label id="Label8" runat="server" CssClass="standard-text">Línea:</asp:Label></P>
						</td>
						<td><asp:textbox id="txtLinea" Runat="server" CssClass="Standard-text" BorderStyle="Groove" ReadOnly="True"></asp:textbox></td>
					</tr>
					<TR>
						<TD>
							<P>&nbsp;</P>
						</TD>
						<TD style="WIDTH: 196px"></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<tr>
						<td colspan="4" bgColor="#276187">
							<asp:Label id="Label1" runat="server" ForeColor="White" Font-Bold="True" CssClass="standard-text">Temperatura de Preseparación:</asp:Label>
						</td>
					</tr>
					<TR>
						<TD colSpan="2" bgColor="lightgrey" style="WIDTH: 287px">
							<asp:Label id="Label2" runat="server" CssClass="standard-text">Familia de Producto :</asp:Label><asp:textbox id="txtFamilia" Runat="server" CssClass="Standard-text" BorderStyle="None" Width="230px"
								ReadOnly="True" BackColor="LightGray"></asp:textbox></TD>
						<TD colSpan="2" bgColor="#d3d3d3">
							<asp:Label id="Label9" runat="server" CssClass="standard-text">Temp Sug:</asp:Label>
							<asp:textbox id="txtTemp" Runat="server" CssClass="standard-text" BorderStyle="None" Width="41px"
								BackColor="LightGray"></asp:textbox>
							<asp:Label id="Label10" runat="server" CssClass="standard-text">Temp Real:</asp:Label>
							<asp:TextBox id="txtTempPre" runat="server" Width="45px" MaxLength="6" CssClass="standard-text"></asp:TextBox>
							<asp:Label id="Label3" runat="server" CssClass="standard-text"> grados</asp:Label>
							<asp:RangeValidator id="RangeValidator1" runat="server" Type="Double" ControlToValidate="txtTempPre"
								MinimumValue="0" MaximumValue="99.99" ErrorMessage="Valor inválido en la Temperatura Real">*</asp:RangeValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtTempPre" ErrorMessage="El valor de la Temperatura Real es un dato obligatorio">*</asp:RequiredFieldValidator></TD>
					<tr>
						<td colSpan="4"></td>
					</tr>
					<tr>
						<td colSpan="4"><asp:textbox id="txtPiso" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="700px"
								Height="65px" TextMode="MultiLine" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<TR>
						<TD colSpan="4">
							<table align="center" width="100%">
								<TR height="40">
									<TD vAlign="top" align="center" width="150">
										<asp:button id="btnAgregarMensaje" runat="server" CssClass="botonesInput" Width="103px" Text="Mensaje de Piso"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:Button id="btnLiberar" runat="server" CssClass="botonesInput" Width="80px" Text="Liberar"></asp:Button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnAgregar" CssClass="botonesInput" Width="80px" Runat="server" Text="Aceptar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnCancel" CssClass="botonesInput" Width="80px" Runat="server" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE id="Table1" width="50">
												<TR>
													<TD vAlign="top" align="center" colSpan="3">
														<P align="center">
															<asp:label id="Label16" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
															<asp:image id="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P>
													</TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</table>
							<asp:label id="lblErrorMsg" runat="server" Font-Bold="True" CssClass="standard-text" ForeColor="Red"></asp:label></TD>
					</TR>
				</TBODY>
			</table>
			<BR>
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 101; LEFT: 112px; POSITION: absolute; TOP: 416px"
				runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
			<BR>
		</form>
	</body>
</HTML>
