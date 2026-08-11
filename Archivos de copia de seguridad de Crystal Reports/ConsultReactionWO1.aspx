<%@ Page language="c#" Codebehind="ConsultReactionWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultReactionWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultReactionWO1</title><LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">	
		function showWaitControls()
		{
			waitControls.style.display='';
		}		
		</script>
	</HEAD>
	<BODY>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<form id="ConsultReactionWO1" method="post" runat="server">
			<table align="center" width="100">
				<tr>
					<td align="center" colSpan="5"><asp:label id="Label1" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Fase de Reacción</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label6" runat="server" CssClass="standard-text">Orden de Trabajo del día:</asp:label></td>
					<td><asp:textbox id="txtFecha" Font-Bold="True" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True"
							Runat="server"></asp:textbox></td>
					<TD align="center"></TD>
					<td>
						<asp:label id="Label7" runat="server" CssClass="standard-text">Línea de Producción:</asp:label></td>
					<td><asp:textbox id="txtLinea" Font-Bold="True" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True"
							Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="5"><asp:label id="Label2" runat="server" Font-Bold="True" CssClass="standard-text">Inventario Actual de Prepolímero</asp:label></td>
				</tr>
				<tr>
					<td colSpan="5">
						<P class="contenido" align="left"><asp:datagrid id="dgdTanque" runat="server" Font-Names="Verdana" BorderStyle="None" BackColor="LightGray"
								BorderColor="DimGray" DataKeyField="IdTanque" AllowSorting="True" FontSize="11px" AutoGenerateColumns="False" CellPadding="2"
								Width="100%" Font-Name="Verdana">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Tanque">
										<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemTanqueDesc Runat="server" CssClass="standard-text" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.TanqueDesc") %>'>
											</asp:label>
											<asp:label id=ItemIdTanque Runat="server" CssClass="standard-text" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.IdTanque") %>' Visible="False">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Prepolimero">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemTipoPMMAId Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA")%>' Visible="False">
											</asp:label>
											<asp:label id=ItemTipoPMMADesc Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TipoPMMADesc")%>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Capacidad">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemCapacidadMax Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadMax")%>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Contiene">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemTankCantidad Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TankCantidad") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Capacidad Disponible">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemCapacidadDisponible Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadDisponible") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></P>
					</td>
				</tr>
				<tr>
					<td colSpan="5"><font size="2"><b></b></font></td>
				</tr>
				<TR>
					<TD colSpan="5"><asp:label id="Label3" runat="server" Font-Bold="True" CssClass="standard-text">Prepolímero por preparar:</asp:label></TD>
				</TR>
				<tr>
					<td colSpan="5">
						<P class="contenido" align="left"><asp:datagrid id="dgdReaccion" runat="server" Font-Names="Verdana" BorderStyle="None" BackColor="LightGray"
								BorderColor="DimGray" AllowSorting="True" FontSize="11px" AutoGenerateColumns="False" CellPadding="2" Width="100%" Font-Name="Verdana">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Material">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemCodigoSAP Runat="server" CssClass="standard-text" Width="60px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
											</asp:label>
											<asp:label id=ItemIdOrdenTrabajo Runat="server" CssClass="standard-text" Width="60px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdOrdenTrabajo") %>' Visible="False">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tipo de Prepol&#237;mero">
										<HeaderStyle Width="300px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="300px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemDescPMMA Runat="server" CssClass="standard-text" Width="200" Text='<%# DataBinder.Eval(Container, "DataItem.DescPMMA")%>'>
											</asp:label>
											<asp:label id=ItemIdTipoPMMA Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' Visible="False">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Cantidad (Kilos)">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemCantidad Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></P>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="lblSpacer" Font-Bold="True" Runat="server" CssClass="standard-text"></asp:label></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<TR>
					<TD colSpan="5">
						<asp:label id="Label5" Font-Bold="True" Runat="server" CssClass="standard-text">Seleccione el Tipo de PMMA, el tanque y la cantidad que desea preparar, después presione el botón "Liberar Reactada".</asp:label></TD>
				</TR>
				<TR>
					<td colSpan="5">
						<table style="BORDER-COLLAPSE: collapse" borderColor="dimgray" width="100%" border="1">
							<tr>
								<TD bgColor="#276187" colSpan="5"></TD>
							</tr>
							<TR>
								<TD bgColor="#d3d3d3"><asp:label id="lblTipoPrep" Runat="server" CssClass="standard-text">Tipo Prepolímero:</asp:label></TD>
								<TD bgColor="#d3d3d3"><asp:dropdownlist id="cmbTipoPMMA" runat="server" CssClass="standard-text"></asp:dropdownlist></TD>
								<TD bgColor="#d3d3d3"><asp:label id="Label4" Runat="server" CssClass="standard-text">Tanque:</asp:label></TD>
								<TD bgColor="lightgrey"><asp:dropdownlist id="cmbTanque" runat="server" CssClass="standard-text"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD bgColor="#d3d3d3"></TD>
								<td bgColor="#d3d3d3"></td>
								<td bgColor="#d3d3d3"><asp:label id="lblKg" Runat="server" CssClass="standard-text">Cantidad (Kilos):</asp:label></td>
								<td bgColor="#d3d3d3"><asp:textbox id="txtKg" BorderStyle="Groove" CssClass="standard-text" Runat="server"></asp:textbox></td>
							</TR>
						</table>
					</td>
				<tr>
					<TD align="center" width="140"></TD>
					<TD align="center" width="150"></TD>
					<TD align="center" vAlign="top"><asp:button id="btnAceptar" runat="server" CssClass="botonesInput" Text="Liberar Reactada" Width="105px"></asp:button></TD>
					<TD align="center" vAlign="top" width="140"><asp:button id="btnCancelar" runat="server" CssClass="botonesInput" Text="Regresar"></asp:button></TD>
					<TD align="center" vAlign="top" width="100">
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
				</tr>
				<tr>
					<td colSpan="5"><asp:label id="lblErrorMsg" Font-Bold="True" Runat="server" ForeColor="Red" CssClass="standard-text"></asp:label></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
