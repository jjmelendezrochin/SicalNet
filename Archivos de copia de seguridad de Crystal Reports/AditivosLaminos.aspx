<%@ Page language="c#" Codebehind="AditivosLaminos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.CuantosDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OllasDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="OllasDetails" method="post" runat="server">
			<table borderColorDark="activecaption" width="700" align="center" height="30%">
				<tr>
					<td colSpan="3" align="center"><asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Fase de Aditivos - Paso 2</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td colSpan="3" align="center"><asp:label id="Label1" runat="server" CssClass="standard-text"> Indique el número de láminas por olla.</asp:label></td>
				</tr>
				<tr>
					<td colSpan="3" align="left"><asp:label id="Label2" runat="server" CssClass="standard-text">
							<b>Secuencia:</b></asp:label><asp:label id="lblSecuencia" runat="server" CssClass="standard-text"></asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="Label4" runat="server" CssClass="standard-text">
							<b>Descripcion:</b></asp:label><asp:label id="lblDescripcion" runat="server" CssClass="standard-text"></asp:label></td>
				</tr>
				<tr>
					<td width="30%"></td>
					<td width="30%" align="right"><asp:label id="Label3" runat="server" CssClass="standard-text">
							<b>Total láminas:</b></asp:label></td>
					<td width="30%"><asp:label id="lblCantidad" CssClass="standard-text" Text="5" Runat="server">5</asp:label></td>
				</tr>
				<tr>
					<td></td>
					<td align="center"><asp:datagrid id="dgdQtyOlla" runat="server" Font-Names="Verdana" AutoGenerateColumns="False"
							Font-Name="Verdana" AllowSorting="True" DataKeyField="NumeroOlla">
							<HeaderStyle CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="No de Ollas">
									<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=itmNoOlla Text='<%# DataBinder.Eval(Container, "DataItem.NumeroOlla") %>' Runat="server" CssClass="Standard-text" Width="80px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Laminas por Olla">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox id=txtLaminas CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>' Width="120px">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Laminas por Olla">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblLaminas CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>' Width="120px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tipo de Olla">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList id="cmbOlla" CssClass="Standard-text" Runat="server" Width="120"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="NumeroOlla">
									<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblCapacidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadOlla") %>' Width="120">
										</asp:label>
										<asp:label id=lblOllaNo CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumeroOlla") %>' Width="120" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sobrante">
									<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemTemplate>
										<asp:TextBox style="Z-INDEX: 0" id=txtSobrante CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sobrante") %>' Width="120px">
										</asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Sobrante">
									<ItemTemplate>
										<asp:Label id=lblSobrante runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Sobrante") %>' Width="99px" Height="18px">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td align="right"><asp:button id="Button1" runat="server" CssClass="botonesInput" Text="<- Anterior" Width="74px"></asp:button></td>
					<td><asp:button id="btnNext" CssClass="botonesInput" Text="Siguiente ->" Runat="server" Width="75px"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
