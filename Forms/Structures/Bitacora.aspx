<%@ Page language="c#" Codebehind="Bitacora.aspx.cs" AutoEventWireup="false" ValidateRequest="True" Inherits="BitacoraExportacion1.Bitacora" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Bitácora de Exportación</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Bitacora" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0" width="100%">
				<TR>
					<td vAlign="top" align="center">&nbsp;
					</td>
				</TR>
			</table>
			<table cellSpacing="0" cellPadding="0" border="0" width="100%" height="100%">
				<TR>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" border="0" class="tan-border" width="700">
							<TR>
								<td>&nbsp;</td>
							</TR>
							<TR>
								<td align="center"><asp:label id="lblTitulo" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Bitacora de Eventos</asp:label></td>
							</TR>
							<TR>
								<td align="right">
									<DIV align="right">
										<asp:linkbutton id="linkbitacora" runat="server" CausesValidation="False">Regresar</asp:linkbutton></DIV>
								</td>
							</TR>
							<TR>
								<td align="center">
									<asp:radiobutton id="rdbSicalnet" runat="server" CssClass="standard-text" GroupName="1" AutoPostBack="True"
										Text="Bitácora SicalNet"></asp:radiobutton>
									<asp:radiobutton id="rdbDatasul" runat="server" CssClass="standard-text" GroupName="1" AutoPostBack="True"
										Text="Bitácora ERP" Width="112px"></asp:radiobutton></td>
							</TR>
							<TR>
								<td></td>
							</TR>
							<TR>
								<td>
									<P align="center">
										<asp:label id="lblError" runat="server" CssClass="standard-text" Height="6px" BorderColor="Red"
											BackColor="White" ForeColor="Red"></asp:label>
										<asp:datagrid id="dgdVerBitacora" runat="server" Font-Names="Verdana" Width="688px" BorderColor="Black"
											AllowPaging="True" HorizontalAlign="Center" AllowSorting="True" font-size="11px" Font-Name="Verdana"
											AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateColumn HeaderText="Consultar">
													<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<FOOTERSTYLE HorizontalAlign="Right"></FOOTERSTYLE>
														<asp:Button id="Button1" runat="server" CssClass="standard-text" Text="Consulta" Width="100px"
															CommandName="Consulta" Visible="true"></asp:Button><BR>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Fecha de Bitacora">
													<HeaderStyle HorizontalAlign="Center" Width="140px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=Label1 Width="150px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.FechaValue") %>' Runat="server" Visible="true" CssClass="standard-text">
														</asp:label>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Right"></FooterStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Archivo">
													<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="50px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=Label2 Width="130px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.NombreValue") %>' Runat="server" Visible="true" CssClass="standard-text">
														</asp:label><br>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False">
													<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<HeaderTemplate>
														Tamaño
													</HeaderTemplate>
													<ItemTemplate>
														<asp:Label id=Label4 CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TamañoValue") %>' Width="150px" Visible="true" Runat="server">
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></P>
								</td>
							</TR>
							<TR>
								<td></td>
							</TR>
							<TR>
								<td>
									<P align="center">
										<asp:textbox id="txtDespliega" runat="server" CssClass="standard-text" Width="680px" Height="331px"
											ReadOnly="True" TextMode="MultiLine"></asp:textbox></P>
								</td>
							</TR>
						</table>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
