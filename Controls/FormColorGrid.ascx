<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FormColorGrid.ascx.cs" Inherits="UserInterface.Controls.FormColourGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
	<asp:datagrid id="dgdFormColor" BorderStyle="None" BorderColor="White" DataKeyField="IdColor"
		AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2"
		Font-Names="Verdana" runat="server" Width="650px" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages"
		PagerStyle-HorizontalAlign="Right" CssClass="GridView grid-users">
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
					<asp:label id=ItemPorcentaje CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Porcentage","{0:N6}") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditPorcentaje Width="100" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Porcentage","{0:N6}") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Grupo">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="50px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemGrupo Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Grupo") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditGrupo Width="50" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Grupo") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
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
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" Width="100px" CssClass="grid-header"
					VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
						NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
						CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
						AlternateText="Delete"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server"
						CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update"
						AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
						NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
	</asp:datagrid>
</P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text" style="Z-INDEX: 0"></asp:label>
	<asp:label style="Z-INDEX: 0" id="lblallowedit" runat="server" CssClass="standard-text" Visible="False"></asp:label></P>
<P class="contenido" align="left">&nbsp;</P>
