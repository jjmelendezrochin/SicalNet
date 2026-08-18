<%@ Control Language="c#" AutoEventWireup="false" Codebehind="WorkOrdersGrid.ascx.cs" Inherits="UserInterface.Controls.WorkOrdersGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="D:\jp\SICALNet\UserInterface\styloDESC.CSS" type="text/css" rel="stylesheet">
<P class="contenido" align="left">
	<TABLE width="600" border="0">
		<tr>
			<td>
				<table>
					<tr>
						<td><asp:label id="lblLinea" Runat="server" Text="Linea de produccion" CssClass="standard-text"></asp:label></td>
						<td><asp:label id="lblDate" Runat="server" Text="Fecha del Programma" CssClass="standard-text"></asp:label></td>
					</tr>
					<tr>
						<td><asp:dropdownlist id="ddlIdLinea" Runat="server" CssClass="standard-text" AutoPostBack="True"></asp:dropdownlist></td>
						<td><asp:dropdownlist id="ddlFecha" Runat="server" CssClass="standard-text" AutoPostBack="True"></asp:dropdownlist></td>
					</tr>
				</table>
			</td>
		</tr>
		<TR vAlign="top">
			<TD><asp:datagrid id="dgdWorkOrders" Runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="White" BorderStyle="None">
					<Columns>
						<asp:TemplateColumn HeaderText="KCT">
							<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="20px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblKct" Width="20px" Text='<%# DataBinder.Eval(Container, "DataItem.KCT") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtfKCT" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Corrida">
							<HeaderStyle HorizontalAlign="Center" Width="90px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="130px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblCorrida" Width="90px" Text='<%# DataBinder.Eval(Container, "DataItem.Corrida") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtfCorrida" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Numero Lote">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblLoteinfo" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.NumeroLote") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:DropDownList ID="ddlLote" Runat="server"></asp:DropDownList>
							</FooterTemplate>
							<EditItemTemplate>
								<asp:Label ID="lblLote" Runat=server Text='<%# DataBinder.Eval(Container, "DataItem.NumeroLote") %>'>
								</asp:Label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Secuencia">
							<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblSecuencia1" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtSecuencia" Runat="server"></asp:TextBox>
							</FooterTemplate>
							<EditItemTemplate>
								<asp:Label ID = "lblSecuencia" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Runat="server">
								</asp:Label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="NoOrder">
							<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblNoOrder" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.NoOrden") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtfNoOrder" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="CodigoSAP">
							<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblCodigoSAP" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:DropDownList id="ddlCodigoSAP" Runat="server"></asp:DropDownList>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Cantidad">
							<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblCantidad" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtfCantidad" Runat="server"></asp:TextBox>
							</FooterTemplate>
							<EditItemTemplate>
								<asp:TextBox ID="txtCantidad" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>'>
								</asp:TextBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Descripcion">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblDescripcion" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtDescripcion" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Rendimiento">
							<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblRendimiento" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.Rendimiento") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtRendimiento" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Fetch Embarque">
							<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="60px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblFechaEmbarque" Width="60px" Text='<%# DataBinder.Eval(Container, "DataItem.FechaEmbarque") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtfFetchEmbarque" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Detaile Operacion">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="lblDetails" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.DetalleOperacion") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<FooterTemplate>
								<asp:TextBox ID="txtDetails" Runat="server"></asp:TextBox>
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Select">
							<HeaderStyle HorizontalAlign="Center" Width="25px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle CssClass="grid-edit-column"></ItemStyle>
							<ItemTemplate>
								<asp:imagebutton id="imgSelect" runat="server" AlternateText="Select" CommandName="Select" NAME="imgSelect" ImageUrl="../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/icon-pencil.gif" width="3">
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid></TD>
		</TR>
	</TABLE>
</P>
