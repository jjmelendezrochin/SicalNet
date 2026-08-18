<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FormCintasGrid.ascx.cs" Inherits="UserInterface.Controls.FormCintasGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
</script>
<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
<P class="contenido" align="left"><asp:datagrid id="dgdFormCintas" ItemStyle-Wrap="True" BorderStyle="None" BorderColor="White"
		DataKeyField="IdFamiliaProducto" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2"
		Font-Names="Verdana" runat="server" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right">
		<HeaderStyle Font-Names="Verdana" CssClass="letraAzulBold"></HeaderStyle>
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
			<asp:TemplateColumn HeaderText="Descripcion">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="300px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="300px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemDescripcion Width="300px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionMaterial") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Cantidad">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemCantidad Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditCantidad Width="100" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Unidad">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemUnidad Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.UnidadDesc") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=ItemUnidadId Width="73px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdUnidad") %>' CssClass="standard-text" Visible="False">
					</asp:label>
					<asp:DropDownList id="EditUnidad" runat="server" CssClass="standard-text"></asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="40px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="imgEdit" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
						NAME="imgEdit" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="imgDelete" Runat="server" CausesValidation="False"
						ImageUrl="../images/icon-delete.gif" NAME="imgDelete" CommandName="Delete" AlternateText="Delete"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="imgUpdate" runat="server" CausesValidation="False"
						ImageUrl="../images/icon-floppy.gif" NAME="imgUpdate" CommandName="Update" AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgCancel" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
						NAME="imgCancel" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label>
	<asp:Label id="lblallowedit" runat="server" Visible="False">Label</asp:Label></P>
