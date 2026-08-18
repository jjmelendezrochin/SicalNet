<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FamiliaProductosGrid.ascx.cs" Inherits="UserInterface.Controls.FamiliaProductosGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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
<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
<P class="contenido" align="left">
	<asp:datagrid id="dgdFamiliaProductos" Width="550px" runat="server" Font-Names="Verdana" CellPadding="2"
		AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="IdFamiliaProductos"
		BorderColor="White" BorderStyle="None" AllowPaging="True" PagerStyle-HorizontalAlign="Right"
		PagerStyle-Mode="NumericPages" CssClass="GridView grid-header">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Id">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="30px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblIdFamiliadeProductos Width="30px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProductos") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditFamiliadeProductosId Width="30px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProductos") %>' Runat="server">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemDescripcion CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditDescripcion BorderStyle="Groove" runat="server" Width="100px" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Prepol&#237;mero">
				<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemTipoPMMAId CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' Visible="False">
					</asp:label>
					<asp:label id=lblTipoPMMA CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescPrepolimero") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=lblTipoPMMAId CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' Visible="False">
					</asp:label>
					<asp:DropDownList id="cboTipoPMMA" Width="220" runat="server" CssClass="Standard-text"></asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Temp. Preseparaci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id="lblTempPre" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TempPreseparcion") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id="txtTempPre" BorderStyle="Groove" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.TempPreseparcion") %>' CssClass="Standard-text" MaxLength="8">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
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
		<PagerStyle
			HorizontalAlign="Center"
			Mode="NumericPages"
			CssClass="grid-pager">
		</PagerStyle>
	</asp:datagrid></P>
<INPUT id="ItemDescripcionhtml" name="ItemDescripcionhtml" type="hidden" runat="server">
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
