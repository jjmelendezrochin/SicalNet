<%@ Page language="c#" Codebehind="ConsultPVCWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.ConsultPVCWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultPVCWO1</title>
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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultPVCWO1" method="post" runat="server">
			<table align="center">
				<TR>
					<TD align="center" colSpan="4" height="40"><asp:label id="lblTitle" runat="server" Font-Bold="True" Font-Size="14" Font-Names="Arial Narrow">Ordenes de Trabajo - Fase de PVC</asp:label>
						<HR>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="lblSecuencia" runat="server" CssClass="standard-text"> Secuencia:</asp:label></TD>
					<TD><asp:textbox id="txtSecuencia" runat="server" Width="250px" ReadOnly="True" BorderStyle="Groove"
							CssClass="Standard-text"></asp:textbox></TD>
					<TD><asp:label id="lblFecha1" runat="server" CssClass="standard-text">Fecha:</asp:label></TD>
					<TD><asp:textbox id="txtFecha1" runat="server" Width="119px" ReadOnly="True" BorderStyle="Groove"
							CssClass="Standard-text"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblUTEC" runat="server" CssClass="standard-text">UTEC:</asp:label></TD>
					<TD><asp:textbox id="txtUTEC" runat="server" Width="250px" ReadOnly="True" BorderStyle="Groove" CssClass="Standard-text"></asp:textbox></TD>
					<TD><asp:label id="lblCantidad" runat="server" CssClass="standard-text">Láminas:</asp:label></TD>
					<TD><asp:textbox id="txtCantidad" runat="server" Width="119px" ReadOnly="True" BorderStyle="Groove"
							CssClass="Standard-text"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:datagrid id="dgdPartidasPVC" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
							BackColor="LightGray" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False"
							BorderColor="DimGray" CellPadding="2">
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
									<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="250px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemMaterialDesc CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaterialDesc") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Cantidad">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemMCantidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Cantidad Real">
									<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemMCantidadReal CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Cantidad Real">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id=txtCantidadReal runat="server" CssClass="standard-text" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Folio Compuesto">
									<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="lblFolioCompuesto" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FolioCompuesto") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Folio Compuesto">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id="txtFolioCompuesto" runat="server" CssClass="standard-text" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.FolioCompuesto") %>' MaxLength=15 >
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				<TR>
				<TR>
					<TD vAlign="bottom" colSpan="4" height="40"><asp:label id="lblMensaje" Font-Bold="True" Runat="server" CssClass="standard-text">Mensaje de Piso:</asp:label></TD>
				<TR>
					<TD style="HEIGHT: 65px" colSpan="4"><asp:textbox id="txtPiso" runat="server" Width="700px" Height="66px" ReadOnly="True" BorderStyle="Groove"
							TextMode="MultiLine" CssClass="standard-text"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<table align="center" width="100%">
							<TR height="40">
								<TD align="center" width="150" vAlign="top">
									<asp:button id="cmdMensaje" runat="server" CssClass="botonesInput" Width="190px" Text="Mensaje de Piso"></asp:button></TD>
								<TD align="center" width="140" vAlign="top">
									<asp:button id="cmdLiberar" runat="server" CssClass="botonesInput" Width="80px" Text="Liberar"></asp:button></TD>
								<TD align="center" width="140" vAlign="top">
									<asp:button id="btnAgregar" runat="server" CssClass="botonesInput" Width="80px" Text="Aceptar"></asp:button></TD>
								<TD align="center" width="140" vAlign="top">
									<asp:button id="cmdCancelar" runat="server" CssClass="botonesInput" Width="80px" Text="Regresar"></asp:button></TD>
								<TD align="center" width="100" vAlign="top">
									<DIV id="waitControls" style="DISPLAY: none">
										<TABLE id="Table1" width="50">
											<TR>
												<TD vAlign="top" align="center" colSpan="3">
													<P align="center">
														<asp:label id="Label7" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
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
				<TR>
					<TD colSpan="4">
						<asp:Label id="lblErrorMsg" runat="server" Font-Bold="True" ForeColor="Red" CssClass="standard-text"></asp:Label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
