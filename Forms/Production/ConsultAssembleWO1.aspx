<%@ Page language="c#" Codebehind="ConsultAssembleWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultAssembleWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultAssembleWO1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="javascript">
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultAssembleWO1" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td colspan="4" align="center"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Fase de Armado</asp:Label><hr>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
						<td><asp:textbox id="txtSecuencia" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label4" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
						<td><asp:textbox id="txtFecha1" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label2" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
						<td><asp:textbox id="txtUTEC" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label5" runat="server" CssClass="standard-text">Láminas</asp:Label></td>
						<td><asp:textbox id="txtCantidad" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<P>
								<asp:Label id="Label3" runat="server" CssClass="standard-text">Familia Producto:</asp:Label></P>
						</td>
						<td><asp:textbox id="txtDescFamiliaProducto" Runat="server" CssClass="Standard-text" BorderStyle="Groove"
								Width="249px"></asp:textbox></td>
					</tr>
					<tr>
						<td colspan="4">&nbsp;
							<div>
								<asp:datagrid id="dgdFormPVC" runat="server" BorderStyle="None" BorderColor="DimGray" Width="700px"
									AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" Font-Names="Verdana"
									CellPadding="2" BackColor="LightGray">
									<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
									<Columns>
										<asp:TemplateColumn HeaderText="Material">
											<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
											<ItemTemplate>
												<asp:label id=ItemCodigoSAP CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
												</asp:label>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Descripci&#243;n">
											<HeaderStyle HorizontalAlign="Center" Width="500px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Width="500px" CssClass="grid-item"></ItemStyle>
											<ItemTemplate>
												<asp:label id=ItemMaterialDesc CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescMaterial") %>'>
												</asp:label>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Cantidad">
											<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
											<ItemStyle Width="70px" CssClass="grid-item"></ItemStyle>
											<ItemTemplate>
												<asp:label id=ItemMCantidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>'>
												</asp:label>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid>
							</div>
						</td>
					</tr>
					<tr>
						<td colSpan="4">
							<asp:Label id="Label6" runat="server" CssClass="standard-text">Mensaje de Piso</asp:Label></td>
					</tr>
					<tr>
						<td colSpan="4" style="HEIGHT: 71px"><asp:textbox id="txtPiso" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="700px"
								Height="65px" TextMode="MultiLine" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<TR>
						<TD colSpan="4">
							<table align="center" width="100%">
								<TR height="40">
									<TD vAlign="top" align="center" width="150">
										<asp:button id="btnAgregarMensaje" runat="server" CssClass="botonesInput" Width="200px" Text="Mensaje de piso"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:Button id="btnLiberar" runat="server" CssClass="botonesInput" Width="80px" Text="Liberar"></asp:Button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnAgregar" CssClass="botonesInput" Width="80px" Runat="server" Text="Aceptar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnCancel" CssClass="botonesInput" Width="90px" Runat="server" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE id="Table1" width="100">
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
						</TD>
					</TR>
				</TBODY>
			</table>
			<DIV></DIV>
		</form>
	</body>
</HTML>
