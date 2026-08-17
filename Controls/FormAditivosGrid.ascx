<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FormAditivosGrid.ascx.cs" Inherits="UserInterface.Controls.FormAditivosGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
<P class="contenido" align="left"><asp:datagrid id="dgdFormAditivos" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages"
		PageSize="10" AllowPaging="True" Width="650px" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
		Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="White" BorderStyle="None" ItemStyle-Wrap="True" OnItemDataBound="dgdFormAditivos_OnItemDataBound">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Material">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="120px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemCodigoSAP Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditCodigoSAP Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="300px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="300px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemDescripcion Width="300px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionMaterial") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Porcentaje">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemPorcentaje Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PorcentajePeso") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditPorcentaje BorderStyle="Groove" runat="server" Width="100" Text='<%# DataBinder.Eval(Container, "DataItem.PorcentajePeso") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Versi&#243;n">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemVersion Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Version") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditVersion Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Version") %>' CssClass="standard-text">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Activo">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="40px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:CheckBox id=ItemActivo Runat="server" CssClass="standard-text" Enabled="False" Checked='<%# DataBinder.Eval(Container, "DataItem.Activo") %>'>
					</asp:CheckBox>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:CheckBox id=EditActivo Runat="server" CssClass="standard-text" Enabled="true" Checked='<%# DataBinder.Eval(Container, "DataItem.Activo") %>'>
					</asp:CheckBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn Visible="False" HeaderText="Familia">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="40px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="lblidFamiliaprodText" runat="server" Text='' CssClass="standard-text"></asp:Label>
					<asp:Label id="lblidFamiliaprod" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProductoNoBase") %>'>
					</asp:Label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:Label id="lblidFamiliaprodedit" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProductoNoBase") %>'>
					</asp:Label>
					<asp:dropdownlist id="cboFamPdt" tabIndex="4" runat="server" Width="142px" CssClass="standard-text"></asp:dropdownlist>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="imgEdit" runat="server" AlternateText="Edit" CommandName="Edit" NAME="imgEdit"
						ImageUrl="../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgDelete" onmouseup="ConfirmOperation(this,'eliminar');" AlternateText="Delete"
						CommandName="Delete" NAME="imgDelete" ImageUrl="../images/icon-delete.gif" CausesValidation="False"
						Runat="server"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton id="imgUpdate" onmouseup="ConfirmOperation(this,'actualizar');" runat="server" AlternateText="Update"
						CommandName="Update" NAME="imgUpdate" ImageUrl="../images/icon-floppy.gif" CausesValidation="False"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgCancel" runat="server" AlternateText="Cancel" CommandName="Cancel" NAME="imgCancel"
						ImageUrl="../images/icon-pencil-x.gif" CausesValidation="False"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
