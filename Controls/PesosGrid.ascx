<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PesosGrid.ascx.cs" Inherits="UserInterface.Controls.PesosGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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

<P class="contenido" align="left"><asp:datagrid id="dgdPeso" Width="650px" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
		Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="White" BorderStyle="None" AllowPaging="True" PagerStyle-Mode="NumericPages"
		PagerStyle-HorizontalAlign="Right">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Planta">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemPlanta Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionPlanta") %>' Runat="server" CssClass="standard-text">
					</asp:label>
					<asp:label id=ItemIdPlanta Text='<%# DataBinder.Eval(Container, "DataItem.IdPlanta") %>' Runat="server" Visible="False" CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:Label id=lblPlanta Width="60" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionPlanta") %>' Runat="server" CssClass="standard-text">
					</asp:Label>
					<asp:Label id=lblIdPlanta Width="60" Text='<%# DataBinder.Eval(Container, "DataItem.IdPlanta") %>' Runat="server" Visible="False" CssClass="standard-text">
					</asp:Label><!--<asp:DropDownList id="EditPlanta" Width="100" Runat="server"></asp:DropDownList>-->
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Medida">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemMedida CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionMedida") %>'>
					</asp:label>
					<asp:label id=ItemIdMedida CssClass="standard-text" Visible="False" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdMedida") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:Label id=lblMedida Width="40" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionMedida") %>'>
					</asp:Label>
					<asp:Label id=lblIdMedida Width="40" CssClass="standard-text" Visible="False" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdMedida") %>'>
					</asp:Label><!--<asp:DropDownList ID="EditMedida" Runat="server" Width="100"></asp:DropDownList>-->
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Espesor">
				<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemEspesor CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionEspesor") %>'>
					</asp:label>
					<asp:label id=ItemIdEspesor CssClass="standard-text" Visible="False" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:Label id=lblEspesor Width="30" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionEspesor") %>'>
					</asp:Label>
					<asp:Label id=lblIdEspesor Width="30" CssClass="standard-text" Visible="False" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>'>
					</asp:Label><!--<asp:DropDownList id="EditEspesor" Width="100" Runat="server"></asp:DropDownList>-->
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Revisi&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="20px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemRevision Text='<%# DataBinder.Eval(Container, "DataItem.Revision") %>' Runat="server" CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditRevision Text='<%# DataBinder.Eval(Container, "DataItem.Revision") %>' Runat="server" CssClass="standard-text">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Kilos">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemKilos CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Kilos") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditKilos BorderStyle="Groove" runat="server" Width="80" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Kilos") %>' MaxLength="20">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Tolerancia">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemTolerancia CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Tolerancia") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditTolerancia BorderStyle="Groove" runat="server" Width="40" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Tolerancia") %>' MaxLength="20">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Elaboro">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemElaboro Width="100" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Elaboro") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditElaboro BorderStyle="Groove" runat="server" Width="100" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Elaboro") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Activo">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="40px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:CheckBox id=ItemActivo CssClass="standard-text" Runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Activo") %>' Enabled="False">
					</asp:CheckBox>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:CheckBox id=EditActivo CssClass="standard-text" Runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Activo") %>' Enabled="true">
					</asp:CheckBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
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
	</asp:datagrid></P>
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label>
	<asp:Label id="lblallowedit" runat="server" Visible="False">Label</asp:Label></P>
