<%@ Page language="c#" Codebehind="NoOfVasos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ColorRoom.NoOfVasos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NoOfVasos</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="NoOfVasos" method="post" runat="server">
			<table height="30%" borderColorDark="activecaption" width="700" align="center">
				<tr>
					<td colspan="5" align="center"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Fase de Color - Paso 1</asp:Label><hr>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 135px; HEIGHT: 22px">
						<asp:Label id="Label3" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
					<td style="WIDTH: 323px; HEIGHT: 22px"><asp:textbox id="txtSecuencia" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="288px"
							BorderStyle="Groove"></asp:textbox></td>
					<td style="WIDTH: 52px; HEIGHT: 22px">
						<asp:Label id="Label5" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
					<td style="HEIGHT: 22px"><asp:textbox id="txtFecha" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 135px">
						<asp:Label id="Label4" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
					<td style="WIDTH: 323px"><asp:textbox id="txtUTEC" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="313px"
							BorderStyle="Groove"></asp:textbox></td>
					<td style="WIDTH: 52px">
						<asp:Label id="Label6" runat="server" CssClass="standard-text">Láminas:</asp:Label></td>
					<td><asp:textbox id="txtCantidad" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<TR>
					<TD align="center" colSpan="5">
						<HR>
						&nbsp;</TD>
				</TR>
				<tr>
					<td colspan="5" align="center"><asp:Label id="Label1" runat="server" CssClass="standard-text">Indique la cantidad de vasos por componente que desea emplear</asp:Label></td>
				</tr>
				<tr>
					<td width="135" style="WIDTH: 135px"></td>
					<td width="348" align="right" style="WIDTH: 348px" colSpan="2">
						<asp:Label id="Label7" runat="server" CssClass="standard-text">Total de componentes:</asp:Label>
						<asp:Label id="lblGroup" runat="server" CssClass="standard-text" style="Z-INDEX: 0"></asp:Label></td>
					<td width="30%"></td>
				</tr>
				<tr>
					<td width="135" style="WIDTH: 135px"></td>
					<td width="348" align="center" style="WIDTH: 348px" colSpan="2"><asp:datagrid id="dgdNoVaso" runat="server" BorderStyle="None" BorderColor="DimGray" AllowSorting="True"
							FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" BackColor="LightGray">
							<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Componente">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblGroupNo Width="80px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupNo") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Vasos por Componente">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id=txtNoVaso BorderStyle="Groove" Width="120px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoVaso") %>'>
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="No. Vaso">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=lblNoVaso Width="120px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoVaso") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Aforo">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=lblAforo CssClass="Standard-text" Width="120px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Aforo") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Aforo">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id=txtAforo CssClass="Standard-text" BorderStyle="Groove" Width="120px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Aforo") %>' Enabled="False">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
					<td width="30%"></td>
				</tr>
				<tr>
					<td width="135" style="WIDTH: 135px"></td>
					<td width="348" vAlign="bottom" align="right" colSpan="2" style="WIDTH: 348px">
						<asp:button id="btnBack" Runat="server" Height="23px" Width="80px" Text="<- Anterior" CssClass="botonesInput"></asp:button></td>
					<td width="30%"><asp:button id="btnOk" Runat="server" Text="Siguiente ->" Width="80px" Height="23px" CssClass="botonesInput"></asp:button></td>
				</tr>
			</table>
			<br>
			<br>
			<table align="center">
				<tr>
					<td align="center">
						<asp:datalist id="lstWorkOrder" Runat="server" Width="250px">
							<HeaderTemplate>
								<TABLE id="Table5" style="BORDER-COLLAPSE: collapse" bgColor="#276187" border="1">
									<TR>
										<TD class="grid-header" align="middle" width="300"><B>Componentes</B>
										</TD>
									</TR>
								</TABLE>
							</HeaderTemplate>
							<ItemTemplate>
								<TABLE style="BORDER-COLLAPSE: collapse" border="1">
									<TR>
										<TD>
											<asp:Label id="Label2" CssClass="standard-text" Runat="server">
												<b>Componente:</b></asp:Label>
											<asp:Label id=lblComponents CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupNo") %>'>
											</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:datagrid id="dgdComponent" runat="server" Font-Names="Verdana" BorderStyle="None" Width="250px"
												CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True"
												BorderColor="DimGray">
												<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="CodigoSAP">
														<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id="lblCodigoSAP" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Width=60px Runat="server">
															</asp:label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Descripci&#243;n">
														<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id="lblDescripcion" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Width="200px" Runat="server">
															</asp:label>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</asp:datagrid></TD>
									</TR>
								</TABLE>
							</ItemTemplate>
						</asp:datalist>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
