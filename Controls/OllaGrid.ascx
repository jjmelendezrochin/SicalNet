<%@ Control Language="c#" AutoEventWireup="false" Codebehind="OllaGrid.ascx.cs" Inherits="UserInterface.Controls.OllaGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD><TITLE>OllaGrid</TITLE>
</HEAD>
	<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		Button.click()
			
}
	</script>
	<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
	<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<table>
		<tr>
			<td style="WIDTH: 76px" width="76"><asp:label id="Label1" Width="70px" runat="server" CssClass="standard-text">Num. Olla</asp:label></td>
			<td><asp:textbox id="txtNumOlla" Width="64px" runat="server" CssClass="standard-text" MaxLength="6"></asp:textbox></td>
			<td width="47" height="19"><asp:label id="Label3" runat="server" CssClass="standard-text">Línea</asp:label></td>
			<td><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="101px"></asp:dropdownlist></td>
			<td><asp:Button id="aceptar" Text="Aceptar" Runat="server" CssClass="botonesInput" Width="64px"
					CausesValidation="False"></asp:Button>
			</td>
		</tr>
		<tr>
			<td colspan="5">
				<asp:datagrid id="dgdOlla" runat="server" Width="448px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
					Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="NumeroOlla" BorderColor="White"
					BorderStyle="None" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right">
					<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="N&#250;mero de Olla">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemNumeroOlla Width="50px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.NumeroOlla") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:label id=EditNumeroOlla Width="50px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.NumeroOlla") %>'>
								</asp:label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Descripci&#243;n">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemDescripcion" CssClass="standard-text" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id="EditDescripcion" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Descripcion") %>' MaxLength="10">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Capacidad m&#225;xima">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemCapacidadMax CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.CapacidadMax") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id=EditCapacidadMax BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.CapacidadMax") %>' MaxLength="10">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Capacidad m&#237;nima">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemCapacidadMin" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.CapacidadMin") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id="EditCapacidadMin" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.CapacidadMin") %>' MaxLength="10">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Planta">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemPlanta" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.DescrPlanta") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="EditPlanta" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text"></asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Linea">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemLinea CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.IdLinea") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList id="EditLinea" CssClass="Standard-text" runat="server" Width="70" BorderStyle="Groove"></asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Editar">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle CssClass="grid-edit-column"></ItemStyle>
							<ItemTemplate>
								<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif" NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server" CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete" AlternateText="Delete"></asp:imagebutton>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:imagebutton onmouseup="ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server" CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update" AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton id="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif" NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
							</EditItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</td>
		</tr>
		<tr>
			<td colspan="5">
				<asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label>
				<INPUT type="hidden" name="ItemDescripcionhtml" id="ItemDescripcionhtml" runat=server>
			</td>
		</tr>
	</table>
</HTML>
