<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LineaGrid.ascx.cs" Inherits="UserInterface.Controls.LineaGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
	{
		Button.click()
	}
}
</script>
<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
<P class="contenido" align="left"><asp:datagrid id="dgdLinea" BorderStyle="None" BorderColor="White" DataKeyField="IdLinea" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" runat="server" Width="448px" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Id">
				<HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemLineaId Width="40px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server" CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditLineaId Width="40px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server" CssClass="standard-text">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemLineaDescription Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Description") %>' Runat="server" CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditLineaDescription Width="120" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Description") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
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
		<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
