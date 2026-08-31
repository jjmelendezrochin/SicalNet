<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AnillosGrid.ascx.cs" Inherits="UserInterface.Controls.AnillosGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
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
	<asp:datagrid id="dgdAnillos" Width="500px" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages"
		AllowPaging="True" runat="server" Font-Names="Verdana" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True"
		DataKeyField="IdAnillo" 
		CssClass="GridView grid-header">
		<HeaderStyle CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Id">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemAnilloId Width="40px" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdAnillo") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditAnilloId Width="40px" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdAnillo") %>' Runat="server">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="C&#243;digo Sap">
				<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemCodigoSap CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.CodigoSap") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label style="Z-INDEX: 0" id=ItemCodigoSap1 CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.CodigoSap") %>' Runat="server">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemDescripcion CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label style="Z-INDEX: 0" id=ItemDescripcion1 CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="L&#237;nea I">
				<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemLI CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.LI") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditLineaI runat="server" Width="120" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.LI") %>' MaxLength="10" BorderStyle="Groove">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="L&#237;nea II">
				<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="12px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemLII CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.LII") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditLineaII runat="server" Width="120" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.LII") %>' MaxLength="10" BorderStyle="Groove">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="L&#237;nea III">
				<HeaderStyle HorizontalAlign="Center" Width="120px" VerticalAlign="Middle"></HeaderStyle>
				<ItemTemplate>
					<asp:label style="Z-INDEX: 0" id=ItemLIII CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.LIII") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox style="Z-INDEX: 0" id=EditLineaIII runat="server" Width="120" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.LIII") %>' MaxLength="10" BorderStyle="Groove">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="Imagebutton5" runat="server" AlternateText="Edit" CommandName="Edit" NAME="Imagebutton1"
						ImageUrl="../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="Imagebutton6" OnClientClick="return ConfirmOperation(this,'eliminar');" Runat="server"
						AlternateText="Delete" CommandName="Delete" NAME="Imagebutton2" ImageUrl="../images/icon-delete.gif"
						CausesValidation="False"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton id="Imagebutton7" OnClientClick="return ConfirmOperation(this,'actualizar');" runat="server"
						AlternateText="Update" CommandName="Update" NAME="Imagebutton3" ImageUrl="../images/icon-floppy.gif"
						CausesValidation="False"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="Imagebutton8" runat="server" AlternateText="Cancel" CommandName="Cancel" NAME="Imagebutton4"
						ImageUrl="../images/icon-pencil-x.gif" CausesValidation="False"></asp:imagebutton>
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
