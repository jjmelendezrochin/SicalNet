<%@ Control Language="c#" AutoEventWireup="false" Codebehind="InventarioVidrios.ascx.cs" Inherits="UserInterface.Controls.InventarioVidrios" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Tamaño Vidrios</title>
		<script language="javascript">
            function ConfirmOperation(Button, strOperationType) {
                if (Button._sicalConfirmado) {
                    Button._sicalConfirmado = false;
                    return true;
                }

                SicalAlert.confirmar(
                    "¿Está seguro que desea " +
                    strOperationType +
                    " este registro?",
                    "Confirmar operación",
                    function () {

                        Button._sicalConfirmado = true;
                        Button.click();

                    }
                );

                return false;
            }

function Ruta(idVidrio){
if (confirm("Esta seguro que desea editar este registro?")) {
	var ruta = '../../Forms/Structures/invVidrios.aspx?id='+idVidrio;	
	window.location = ruta;
	}
}
        </script>
		
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table>
			<tr>
				<td align="right"><asp:label style="Z-INDEX: 0" id="Label2" Width="50px" CssClass="standard-text" Runat="server"
						Text="Línea :   ">Línea:</asp:label><asp:dropdownlist style="Z-INDEX: 0" id="cboLinea" Width="90px" CssClass="standard-text" runat="server"
						Height="19px">
						<asp:ListItem Value="-- L&#237;nea --" Selected="True">-- L&#237;nea --</asp:ListItem>
					</asp:dropdownlist></td>
				<td align="right"><asp:label style="Z-INDEX: 0" id="Label1" Width="50px" CssClass="standard-text" Runat="server"
						Text="Línea :   ">Tamaño:</asp:label><asp:dropdownlist style="Z-INDEX: 0" id="cboVidrioTamanio" Width="90px" CssClass="standard-text" runat="server"
						Height="19px">
						<asp:ListItem Value="-- Tama&#241;o --" Selected="True">-- Tama&#241;o --</asp:ListItem>
					</asp:dropdownlist></td>
				<td align="right"><asp:label style="Z-INDEX: 0" id="Label3" Width="50px" CssClass="standard-text" Runat="server"
						Text="Línea :   ">Tipo:</asp:label>&nbsp;
					<asp:dropdownlist style="Z-INDEX: 0" id="cboTipo" Width="90px" CssClass="standard-text" runat="server">
						<asp:ListItem Value="-- Tipo --" Selected="True">-- Tipo --</asp:ListItem>
					</asp:dropdownlist>&nbsp;
				</td>
			</tr>
			<tr>
				<td style="HEIGHT: 39px" align="right"><asp:label style="Z-INDEX: 0" id="Label4" Width="79px" CssClass="standard-text" runat="server"> Espesor:</asp:label><asp:dropdownlist id="cboEspesor" Width="90px" CssClass="standard-text" runat="server"></asp:dropdownlist></td>
				<td style="HEIGHT: 39px" align="right"><asp:label style="Z-INDEX: 0" id="Label6" Width="93px" CssClass="standard-text" runat="server">Clave Interna:</asp:label><asp:textbox style="Z-INDEX: 0" id="txtNumeroVidrio" Width="91px" CssClass="standard-text" runat="server"
						Height="21px"></asp:textbox></td>
				<td style="HEIGHT: 39px" align="right"><asp:label style="Z-INDEX: 0" id="Label5" Width="29px" CssClass="standard-text" runat="server">Lote:</asp:label><asp:textbox style="Z-INDEX: 0" id="txtLote" Width="48px" CssClass="standard-text" runat="server"
						Height="21px"></asp:textbox></td>
			</tr>
			<tr>
				<td style="HEIGHT: 23px" align="right">
					<asp:label style="Z-INDEX: 0" id="Label8" CssClass="standard-text" Width="40px" runat="server">Planta:</asp:label>
					<asp:textbox style="Z-INDEX: 0" id="txtidPlanta" CssClass="standard-text" Width="15px" runat="server"
						Enabled="False"></asp:textbox></td>
				<td style="HEIGHT: 23px" align="center">
					<asp:button style="Z-INDEX: 0" id="cmdMostrarTodos" Text="Mostrar Todos" CssClass="botonesInput"
						Width="84px" runat="server" CausesValidation="False"></asp:button></td>
				<td style="HEIGHT: 23px" align="center"><asp:button id="Button1" CssClass="botonesInput" Text="Buscar" runat="server" CausesValidation="False"></asp:button></td>
			</tr>
			<tr>
				<td colSpan="3"><asp:datagrid id="dgdInventarioVidrios" Width="500px" runat="server" PagerStyle-HorizontalAlign="Right"
						PagerStyle-Mode="NumericPages" DataKeyField="IdVidrio" AllowPaging="True" AllowSorting="True" FontSize="11px"
						Font-Name="Verdana" AutoGenerateColumns="False" Font-Names="Verdana" PageSize="15" OnRowDataBound="dgdInventarioVidrios_RowDataBound">
						<HeaderStyle CssClass="grid-header"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn Visible="False" HeaderText="IdVidrio">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemidVidrio Text='<%#&#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.IdVidrio") %>' Runat="server" CssClass="standard-text" Width="50px">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label id=EditidVidrio Text='<%#&#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.IdVidrio") %>' Runat="server" CssClass="standard-text" Width="50px">
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Cve.Fab.">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemClaveFabricante Width="50px" CssClass="standard-text" Runat="server" Text='<%#&#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.ClaveFabricante") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label style="Z-INDEX: 0" id=EditClaveFabricante Width="50px" CssClass="standard-text" Runat="server" Text='<%#&#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.ClaveFabricante") %>'>
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Cve.Int.">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemNumeroVidrio Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.NumeroVidrio") %>' Runat="server" CssClass="standard-text">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label style="Z-INDEX: 0" id=EditNumeroVidrio Text='<%#&#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.NumeroVidrio") %>' Runat="server" CssClass="standard-text" Width="50px">
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Tama&#241;o">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemMedida CssClass="standard-text" Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Medida") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditMedida BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Medida") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Proveedor">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemProveedor CssClass="standard-text" Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Proveedor") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditProveedor BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Proveedor") &#13;&#13;&#10;%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Linea">
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemLinea CssClass="standard-text" Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Linea") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id=EditLinea BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Linea") &#13;&#13;&#10;%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Calidad">
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemCalidad Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Calidad") %>' Runat="server" CssClass="standard-text">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id=EditCalidad Text='<%#DataBinder.Eval(Container, "DataItem.Calidad") &#13;&#13;&#10;%>' CssClass="Standard-text" Width="70" runat="server" MaxLength="50" BorderStyle="Groove">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Conservacion">
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id="ItemConservacion" Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Conservacion") %>' Runat="server" CssClass="standard-text">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id="EditConservacion" Text='<%#DataBinder.Eval(Container, "DataItem.Conservacion") &#13;&#13;&#10;%>' CssClass="Standard-text" Width="70" runat="server" MaxLength="50" BorderStyle="Groove">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Lote">
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id="Label7" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Lote") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id="Textbox1" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Lote") &#13;&#13;&#10;%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Edici&#243;n">
								<ItemTemplate>
									<a href='../../Forms/Structures/InvVidrios.aspx?id=<%# DataBinder.Eval(Container,"DataItem.idVidrio") %>&NumeroVidrio=<%# DataBinder.Eval(Container,"DataItem.NumeroVidrio") %>'>
										Editar</a>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn Visible="False" HeaderText="Editar">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle CssClass="grid-edit-column"></ItemStyle>
								<ItemTemplate>
									&nbsp;
									<asp:imagebutton id="Imagebutton6" OnClientClick="return ConfirmOperation(this,'eliminar');" Runat="server"
										CausesValidation="False" AlternateText="Delete" CommandName="Delete" NAME="Imagebutton2" ImageUrl="../images/icon-delete.gif"></asp:imagebutton>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:imagebutton id="Imagebutton7" OnClientClick="return ConfirmOperation(this,'actualizar');" runat="server"
										CausesValidation="False" AlternateText="Update" CommandName="Update" NAME="Imagebutton3" ImageUrl="../images/icon-floppy.gif"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
									<asp:imagebutton id="Imagebutton8" runat="server" CausesValidation="False" AlternateText="Cancel"
										CommandName="Cancel" NAME="Imagebutton4" ImageUrl="../images/icon-pencil-x.gif"></asp:imagebutton>
								</EditItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle
							HorizontalAlign="Center"
							Mode="NumericPages"
							CssClass="grid-pager">
						</PagerStyle>
					</asp:datagrid></td>
			</tr>
			<tr>
				<td colSpan="2"><asp:label id="lblErrorMsg" CssClass="standard-text" runat="server"></asp:label><INPUT id="SecuenciaActualhtml" type="hidden" name="SecuenciaActualhtml" runat="server">
					<INPUT id="Cubahtml" type="hidden" name="Cubahtml" runat="server">
				</td>
			</tr>
		</table>
	</body>
</HTML>
