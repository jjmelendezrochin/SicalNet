<%@ Page language="c#" Codebehind="EnvioPTFinal.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.PartidasEnvioPT.EnvioPTFinal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EnvioPTFinal</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language=javascript>	
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
			function getConfirm(Button)
			{
				if(window.confirm("¿Estás seguro que deseas liberar esta secuencia?"))
				{
				document.forms[0].elements[Button].click()
				}
			} 
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="EnvioPTFinal" method="post" runat="server">
			<table width="700" align="center">
				<tbody>
					<tr>
						<td align="center" colSpan="4"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Fase de Entrega de Producto Terminado - Paso 2</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
						<td><asp:textbox id="txtSecuencia" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label3" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
						<td><asp:textbox id="txtFecha" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label2" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
						<td><asp:textbox id="txtUTEC" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:Label id="Label4" runat="server" CssClass="standard-text">Láminas:</asp:Label></td>
						<td><asp:textbox id="txtCantidad" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr width="50px">
						<td>
							<P>&nbsp;</P>
						</td>
						<td colspan="2" align="left"></td>
						<td></td>
					</tr>
					<tr>
						<td colspan="4" align="center">
							<asp:datagrid id="dgdEnvioPT" runat="server" Font-Names="Verdana" CellPadding="2" BorderColor="DimGray"
								AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderStyle="None"
								Width="500px" BackColor="LightGray">
								<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Numero Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblNoPaquete Width="60px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PaqueteNo") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox id=txtPaquete BorderStyle="Groove" Width="160px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Paquete") %>'>
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblPaquete Width="160px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Paquete") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Laminas por Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox id=txtLaminas BorderStyle="Groove" Width="60px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Laminas") %>'>
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Laminas por Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblLaminas Width="60px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Laminas") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tarima">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox id=txtTarima BorderStyle="Groove" Width="160px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Tarima") %>'>
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Tarima">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblTarima Width="160px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Tarima") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
					<TR>
						<TD align="left" colSpan="4">
							<asp:Label id="Label5" runat="server" CssClass="standard-text">Mensajes de Piso:</asp:Label></TD>
					</TR>
					<TR>
						<TD align="left" colSpan="4">
							<asp:textbox id="txtMensajePiso" CssClass="Standard-text" BorderStyle="Groove" Width="700px"
								ReadOnly="True" Runat="server" Height="74px" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left" colSpan="4">
							<table width="100%" align="center">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center" width="120">
											<asp:button id="cmdMsgPiso" CssClass="botonesInput" Width="100px" Runat="server" Text="Mensaje de Piso"></asp:button></TD>
										<TD vAlign="top" align="center" width="120">
											<asp:button id="btnBack" CssClass="botonesInput" Width="80px" Runat="server" Text="<-Anterior"></asp:button></TD>
										<TD vAlign="top" align="center" width="120">
											<asp:button id="btnLiberar" CssClass="botonesInput" Width="80px" Runat="server" Text="Liberar"></asp:button></TD>
										<TD vAlign="top" align="center" width="120">
											<asp:button id="btnAgregar" CssClass="botonesInput" Width="80px" Runat="server" Text="Aceptar"></asp:button></TD>
										<TD vAlign="top" align="center" width="120">
											<asp:button id="btnCancelar" CssClass="botonesInput" Width="80px" Runat="server" Text="Regresar"></asp:button></TD>
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
						</TD>
					</TR>
				</tbody>
			</table>
			</TD></TR></TBODY></TABLE>
		</form>
	</body>
</HTML>
