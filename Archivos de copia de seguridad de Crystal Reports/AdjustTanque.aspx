<%@ Page language="c#" Codebehind="AdjustTanque.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.AdjustTanque" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdjustTanque</title>
		<script language="javascript">
function ConfirmOperation(Button)
{
	if (confirm("Do you want the Adjust the Tank")) 
	{
		Button.click()
	}
}
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Tanques Prepolímero"
			}
		</script>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="..\..\styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ShowTitle()">
		<form id="AdjustTanque" method="post" runat="server">
			<table align="center">
				<tr>
					<td align="left" colSpan="5" bgColor="#003366">
						<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
					</td>
				</tr>
				<tr>
					<td align="middle" colSpan="5"><asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Tanques de Prepolímero</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label1" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True">Inventario de Tanques y Ocupación</asp:label>
					</td>
				</tr>
				<tr>
					<td>
						<P class="contenido" align="left"><asp:datagrid id="dgdTanque" runat="server" Width="700px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" FontSize="11px" AllowSorting="True" DataKeyField="IdTanque" BorderColor="DimGray" BorderStyle="None" Font-Name="Verdana" BackColor="LightGray">
								<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Tanque">
										<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="80px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemTanqueDesc Width="80px" Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TanqueDesc") %>'>
											</asp:label>
											<asp:label id=ItemIdTanque Width="80px" Visible="False" Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTanque") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Prepolimero">
										<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemTipoPMMADesc Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TipoPMMADesc")%>'>
											</asp:label>
											<asp:label id=ItemTipoPMMAId Visible="False" Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA")%>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Capacidad">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemCapacidadMax Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadMax")%>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Contiene">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemTankCantidad Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TankCantidad") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Capacidad Disponible">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemCapacidadDisponible Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadDisponible") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Ajustar" CommandName="Select">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle CssClass="grid-edit-column"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
							</asp:datagrid></P>
					</td>
				</tr>
				<tr>
					<td><font size="2"><b></b></font></td>
				</tr>
				<tr>
					<td>
						<P class="contenido" align="left">
							<asp:label id="Label2" runat="server" Font-Names="Arial Narrow" Font-Size="14" Visible="False" Font-Bold="True">Ajustes</asp:label></P>
					</td>
				</tr>
				<tr>
					<td>
						<P class="contenido" align="left"><asp:datagrid id="dgdAdjustTanque" runat="server" Width="700px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" FontSize="11px" AllowSorting="True" BorderColor="DimGray" BorderStyle="None" Font-Name="Verdana" Visible="False" BackColor="LightGray">
								<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Folio Ajuste">
										<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="30px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblIdAjuste Width="40px" Runat="server" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdAjuste") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Fecha">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblAdjustFecha Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Fecha") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tanque">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblTanqueDesc Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescTanque") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Prepolimero Orginal">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblPMMAOrg Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescTipoPMMAOrg") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Cantidad Orginal">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblCantOrg Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadOrg") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Prepolimero Final">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblPMMAFin Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescTipoPMMAFin") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Cantidad Final">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblCantFin Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadFin") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></P>
					</td>
				</tr>
				<tr>
					<td><font size="2"><b></b></font></td>
				</tr>
				<TR>
					<TD>
						<asp:Panel id="Panel1" runat="server" Width="700px" Visible="False">
							<TABLE id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="dimgray" width="700" border="1">
								<TR>
									<TD bgColor="#276187">
										<asp:label id="Label3" Font-Bold="True" ForeColor="White" Runat="server">Ajuste de Tanque</asp:label></TD>
								</TR>
							</TABLE>
							<TABLE id="ReleaseTank" style="BORDER-COLLAPSE: collapse" borderColor="dimgray" cellSpacing="1" cellPadding="1" width="700" bgColor="lightgrey" border="1">
								<TR>
									<TD>
										<asp:label id="lblTanqueDesc2" Runat="server" CssClass="standard-text">Tanque Seleccionado:</asp:label></TD>
									<TD colSpan="3">
										<asp:label id="txtTanqueDesc2" Font-Bold="True" Runat="server" CssClass="standard-text"></asp:label></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="lblPmmaOrg2" Runat="server" CssClass="standard-text">
										Prepolímero Actual</asp:label></TD>
									<TD>
										<asp:label id="txtPmmaOrg2" Font-Bold="True" Runat="server" CssClass="standard-text"></asp:label></TD>
									<TD>
										<asp:label id="lblCantOrg2" Runat="server" CssClass="standard-text">
										Cantidad Actual</asp:label></TD>
									<TD>
										<asp:label id="txtCantOrg2" Font-Bold="True" Runat="server" CssClass="standard-text"></asp:label>
										<asp:label id="Label4" Font-Bold="True" Runat="server" CssClass="standard-text">kilos</asp:label></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="lblPMMAFin2" Runat="server" CssClass="standard-text">
										Nuevo Prepolímero</asp:label></TD>
									<TD>
										<asp:dropdownlist id="cmbPMMAFin" Width="206px" Runat="server" CssClass="standard-text" AutoPostBack="false"></asp:dropdownlist></TD>
									<TD>
										<asp:label id="lblCantFin2" Runat="server" CssClass="standard-text">
										Nueva Cantidad</asp:label></TD>
									<TD>
										<asp:TextBox id="txtCantFin2" runat="server" BorderStyle="Groove" Width="201px" CssClass="standard-text"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="lblCassa" Runat="server" CssClass="standard-text">
										Causa del ajuste:</asp:label></TD>
									<TD colSpan="3">
										<asp:TextBox id="txtCassa" runat="server" BorderStyle="Groove" Width="534px" CssClass="standard-text" Height="48px" TextMode="MultiLine"></asp:TextBox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table2" width="700">
								<TR>
									<TD width="25%"></TD>
									<TD width="25%"></TD>
									<TD align="middle" width="25%"></TD>
									<TD align="middle" width="25%"></TD>
								</TR>
								<TR>
									<TD width="25%"></TD>
									<TD width="25%"></TD>
									<TD align="middle" width="25%">
										<asp:Button id="btnAceptar" runat="server" CssClass="botonesInput" Text="Ajustar"></asp:Button></TD>
									<TD align="middle" width="25%">
										<asp:Button id="btnCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:Button></TD>
								</TR>
								<TR>
									<TD colSpan="4">
										<asp:label id="lblErrorMsg" Font-Bold="True" ForeColor="Red" Runat="server" CssClass="Standard-text"></asp:label></TD>
								</TR>
							</TABLE>
						</asp:Panel></TD>
				</TR>
				<tr>
					<td>
					</td>
					</TD>
				</tr>
				<TR>
				</TR>
				<tr>
				</tr>
			</table>
		</form>
	</body>
</HTML>
