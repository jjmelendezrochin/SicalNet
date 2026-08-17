<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PresentacionGrid.ascx.cs" Inherits="UserInterface.Controls.PresentacionGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
	{
		Button.click()
	}
}
</script>

<P class="contenido" align="left">
	<asp:datagrid id="dgdPresentacion" BorderStyle="None" BorderColor="White" DataKeyField="IdPresentacion" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" runat="server" Width="600px" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" CssClass="GridView grid-header">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Id">
				<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemPresentacionId Width="60px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdPresentacion") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditPresentacionId Width="60px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdPresentacion") %>' CssClass="standard-text">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemPresentacionDescripcion Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditPresentacionDescripcion Width="120" runat="server" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
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
		<PagerStyle
			HorizontalAlign="Center"
			Mode="NumericPages"
			CssClass="grid-pager">
		</PagerStyle>
	</asp:datagrid></P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
