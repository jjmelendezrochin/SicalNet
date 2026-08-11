<%@ Page language="c#" Codebehind="VasosDetails.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ColorRoom.VasosDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VasosDetails</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="VasosDetails" method="post" runat="server">
			<table height="30%" borderColorDark="activecaption" width="700" align="center">
				<tr>
					<td colspan="5" align="middle" style="HEIGHT: 38px"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Fase de Color - Paso 2</asp:Label><hr>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
					<td><asp:textbox id="txtSecuencia" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px" BorderStyle="Groove"></asp:textbox></td>
					<td>
						<asp:Label id="Label5" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
					<td><asp:textbox id="txtFecha" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
					<td><asp:textbox id="txtUTEC" Runat="server" ReadOnly="True" CssClass="Standard-text" Width="250px" BorderStyle="Groove"></asp:textbox></td>
					<td>
						<asp:Label id="Label6" runat="server" CssClass="standard-text">Láminas:</asp:Label></td>
					<td><asp:textbox id="txtCantidad" Runat="server" ReadOnly="True" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<TR>
					<TD align="middle" colSpan="5">
						<HR>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="5">
						<asp:Label id="Label1" runat="server" CssClass="standard-text">Indique la cantidad de láminas que desea preparar en cada vaso:</asp:Label></TD>
				</TR>
				<tr>
					<td colspan="5" align="middle"><asp:datagrid id="dgdQtyVaso" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="VasoNo" BorderColor="DimGray" BorderStyle="None" BackColor="LightGray">
							<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Componente">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label CssClass="Standard-text" id="lblGroupNo" Width="80px" Text='<%# DataBinder.Eval(Container, "DataItem.GroupNo") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="No. de Vaso">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=itmNoVaso Width="80px" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.VasoNo") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="L&#225;minas por Vaso">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id=txtLaminas Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>' BorderStyle="Groove" CssClass="Standard-text" Width="120px">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="L&#225;minas por Vaso">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:Label Width="120px" id="lblLaminas" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td style="HEIGHT: 14px"></td>
					<td align="right" style="HEIGHT: 14px" colSpan="2"></td>
					<td style="HEIGHT: 14px"></td>
				</tr>
				<tr>
					<td width="30%"></td>
					<td width="30%" align="right" colSpan="2"><asp:button id="btnBack" Text="<- Anterior" Runat="server" Height="22px" Width="80px" CssClass="botonesInput"></asp:button></td>
					<td width="30%"><asp:button id="btnNext" Text="Siguiente ->" Runat="server" Height="22px" Width="80px" CssClass="botonesInput"></asp:button></td>
				</tr>
				<tr>
					<td></td>
					<td align="right" colSpan="2"></td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
