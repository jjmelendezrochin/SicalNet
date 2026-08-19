<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FormPVCGrid.ascx.cs" Inherits="UserInterface.Controls.FormPVCGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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

<P class="contenido" align="left">
	<asp:datagrid 
		id="dgdFormPVC" 
		PagerStyle-HorizontalAlign="Right" 
		PagerStyle-Mode="NumericPages"
		AllowPaging="True" 
		BorderStyle="None" 
		BorderColor="White" 
		DataKeyField="IdFamiliaProducto" 
		AllowSorting="True" 
		FontSize="11px"
		Font-Name="Verdana" 
		AutoGenerateColumns="False" 
		CellPadding="2" 
		Font-Names="Verdana" 
		runat="server" 
		CssClass="GridView grid-users">

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
					<asp:label id=ItemDescripcion Width="300px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescMaterial") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Cantidad">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemCantidad BorderStyle="None" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditCantidad Width="100" runat="server" BorderStyle="Groove" Text='<%#DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Unidad">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemUnidad Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.DescUnidad") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=ItemUnidadId Width="73px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdUnidad") %>' CssClass="standard-text" Visible="False">
					</asp:label>
					<asp:DropDownList id="EditUnidad" runat="server" CssClass="standard-text"></asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Linea">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id="Label1" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.DescLinea") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<!--
					<asp:label id="Label2" Width="73px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' CssClass="standard-text" Visible="False">
					</asp:label>
					<asp:DropDownList id="Dropdownlist1" runat="server" CssClass="standard-text"></asp:DropDownList>
					-->
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="40px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="Imagebutton5" runat="server" AlternateText="Edit" NAME="Imagebutton1" CausesValidation="false"
						CommandName="Edit" ImageUrl="../images/icon-pencil.gif"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
						AlternateText="Delete" NAME="Imagebutton2" CausesValidation="False" CommandName="Delete" ImageUrl="../images/icon-delete.gif"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server"
						AlternateText="Update" NAME="Imagebutton3" CausesValidation="False" CommandName="Update" ImageUrl="../images/icon-floppy.gif"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="Imagebutton8" runat="server" AlternateText="Cancel" NAME="Imagebutton4" CausesValidation="False"
						CommandName="Cancel" ImageUrl="../images/icon-pencil-x.gif"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle
		HorizontalAlign="Center"
		Mode="NumericPages"
		CssClass="grid-pager">
		</PagerStyle>
	</asp:datagrid></P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server"></asp:label>
	<asp:Label id="lblallowedit" runat="server" Visible="False">Label</asp:Label></P>
