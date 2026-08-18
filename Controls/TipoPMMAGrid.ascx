<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="TipoPMMAGrid.ascx.cs" Inherits="UserInterface.Controls.TipoPMMAGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
    function ConfirmOperation(Button, strOperationType) {
        if (confirm("Esta seguro que desea " + strOperationType + " este registro?")) {
            Button.click()
        }
    }
</script>

<p class="contenido" align="left">
    <asp:DataGrid ID="dgdTipoPMMA" BorderStyle="None" BorderColor="White" DataKeyField="IdTipoPMMA" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" runat="server" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" Width="600px" CssClass="GridView grid-header">
        <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>

        <Columns>
            <asp:TemplateColumn HeaderText="Id">
                <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                <ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>

                <ItemTemplate>
                    <asp:Label ID="ItemIdTipoPMMA" Width="40px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' CssClass="standard-text">
                    </asp:Label>

                </ItemTemplate>

                <EditItemTemplate>
                    <asp:Label ID="EditIdTipoPMMA" Width="40px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' CssClass="standard-text">
                    </asp:Label>

                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>

                <ItemTemplate>
                    <asp:Label ID="ItemCodigoSAP" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text">
                    </asp:Label>

                </ItemTemplate>

                <EditItemTemplate>
                    <asp:TextBox ID="EditCodigoSAP" Width="100" runat="server" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="Standard-text" MaxLength="18">
                    </asp:TextBox>

                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Descripci&#243;n">
                <HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                <ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>

                <ItemTemplate>
                    <asp:Label ID="ItemDescripcion" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionMaterial") %>' runat="server">
                    </asp:Label>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:Label ID="EditDescripcion" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionMaterial") %>' runat="server">
                    </asp:Label>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Editar">
                <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                <ItemStyle CssClass="grid-edit-column"></ItemStyle>

                <ItemTemplate>
                    <asp:ImageButton ID="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif" NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:ImageButton><img src="images/spacer.gif" width="3">
                    <asp:ImageButton onmouseup="ConfirmOperation(this,'eliminar');" ID="Imagebutton6" runat="server" CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete" AlternateText="Delete"></asp:ImageButton>

                </ItemTemplate>

                <EditItemTemplate>
                    <asp:ImageButton onmouseup="ConfirmOperation(this,'actualizar');" ID="Imagebutton7" runat="server" CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update" AlternateText="Update"></asp:ImageButton><img src="images/spacer.gif" width="3">
                    <asp:ImageButton ID="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif" NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:ImageButton>

                </EditItemTemplate>
            </asp:TemplateColumn>
        </Columns>

        <PagerStyle
			HorizontalAlign="Center"
			Mode="NumericPages"
			CssClass="grid-pager">
		</PagerStyle>

    </asp:DataGrid>
</p>
<p class="contenido" align="left">
    <asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label>
    <input type="hidden" id="CodigoSAPhtml" name="CodigoSAPhtml" runat="server">
</p>
