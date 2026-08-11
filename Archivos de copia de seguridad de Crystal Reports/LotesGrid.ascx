<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LotesGrid.ascx.cs" Inherits="UserInterface.Controls.LotesGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>LoteGrid</TITLE>
	</HEAD>
	<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		Button.click()
			
}
	</script>
	<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
	<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<table>
		<tr>
			<td width="47"><asp:label id="Label2" runat="server" CssClass="standard-text" Width="51px">No Lote</asp:label></td>
			<td><asp:textbox id="txtNoLote" runat="server" CssClass="standard-text" Width="48px" MaxLength="6"></asp:textbox></td>
			<td width="47" height="19"><asp:label id="Label3" runat="server" CssClass="standard-text">Línea</asp:label></td>
			<td><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="101px"></asp:dropdownlist></td>
			<td><asp:Button id="aceptar" Text="Aceptar" Runat="server" CssClass="botonesInput" Width="64px"
					CausesValidation="False"></asp:Button>
			</td>
		</tr>
		<tr>
			<td colspan="5">
				<asp:datagrid id="dgdLote" runat="server" Width="448px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
					Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="NumeroLote" BorderColor="White"
					BorderStyle="None" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right">
					<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Número de Lote">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemNumeroLote Width="50px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.NumeroLote") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:label id=EditNumeroLote Width="50px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.NumeroLote") %>'>
								</asp:label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Línea">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemLinea CssClass="standard-text" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:label id="EditLinea" CssClass="standard-text" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server">
								</asp:label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Piezas">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemPiezas CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Piezas") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id=EditPiezas BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Piezas") %>' MaxLength="50">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Activo">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemActivo CssClass="standard-text" Runat="server" Text='<%# (bool)DataBinder.Eval(Container,"DataItem.Activo")?"SI":"NO"%>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:CheckBox id="EditActivo" runat="server" CssClass="standard-text" Text="Activo" Checked='<%# (bool)DataBinder.Eval(Container,"DataItem.Activo")?true:false%>' >
								</asp:CheckBox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Editar">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle CssClass="grid-edit-column"></ItemStyle>
							<ItemTemplate>
								<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
									NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
									CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
									AlternateText="Delete"></asp:imagebutton>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:imagebutton onmouseup="ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server"
									CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update"
									AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton id="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
									NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
							</EditItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</td>
		</tr>
		<tr>
			<td colspan="5">
				<asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label>
			</td>
		</tr>
	</table>
</HTML>
