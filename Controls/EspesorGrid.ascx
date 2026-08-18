<%@ Control Language="c#" CodeBehind="EspesorGrid.ascx.cs" AutoEventWireup="false" Inherits="UserInterface.Controls.EspesorGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>MedidaGrid</title>
    <link href="../styloDESC.CSS" type="text/css" rel="stylesheet">

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
</head>
<asp:DataGrid ID="dgdEspesor" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
    Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="IdEspesor" BorderColor="White" BorderStyle="None"
    AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" Width="850px"
    CssClass="GridView grid-header">
    <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>

    <Columns>
        <asp:TemplateColumn HeaderText="IdEspesor">
            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

            <ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>

            <ItemTemplate>
                <asp:Label ID="ItemIdEspesor" CssClass="standard-text" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>'>
                </asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:Label ID="EditIdEspesor" CssClass="standard-text" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>'>
                </asp:Label>
            </EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Mil&#237;metros">
            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

            <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>

            <ItemTemplate>
                <asp:Label ID="ItemCentimetros" CssClass="standard-text" runat="server" Width="80px" Text='<%# DataBinder.Eval(Container, "DataItem.Centimetros") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="EditCentimetros" BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="80px" Text='<%# DataBinder.Eval(Container,"DataItem.Centimetros") %>' MaxLength="50"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Pulgadas">
            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

            <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>

            <ItemTemplate>
                <asp:Label ID="ItemPulgadas" CssClass="standard-text" runat="server" Width="70px" Text='<%# DataBinder.Eval(Container,"DataItem.Pulgadas") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="EditPulgadas" BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="70px" Text='<%# DataBinder.Eval(Container,"DataItem.Pulgadas") %>' MaxLength="50"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Nominal">
            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

            <ItemStyle Width="40px" CssClass="grid-item"></ItemStyle>
            <ItemTemplate>
                <asp:Label ID="ItemNominal" CssClass="standard-text" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container,"DataItem.Nominal") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="EditNominal" BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="40px" Text='<%# DataBinder.Eval(Container,"DataItem.Nominal") %>' MaxLength="50"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Otro">
            <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

            <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>

            <ItemTemplate>
                <asp:Label ID="ItemOtro" CssClass="standard-text" runat="server" Width="70px" Text='<%# DataBinder.Eval(Container,"DataItem.Otro") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:TextBox ID="EditOtro" BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.Otro")%>' MaxLength="50"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Editar">
            <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

            <ItemStyle CssClass="grid-edit-column"></ItemStyle>

            <ItemTemplate>
                <asp:ImageButton ID="Imagebutton5" runat="server" AlternateText="Edit" CommandName="Edit" NAME="Imagebutton1" ImageUrl="../images/icon-pencil.gif" CausesValidation="false"></asp:ImageButton><img src="images/spacer.gif" width="3">
                <asp:ImageButton OnClientClick="return ConfirmOperation(this,'eliminar');" ID="Imagebutton6" runat="server" AlternateText="Delete" CommandName="Delete" NAME="Imagebutton2" ImageUrl="../images/icon-delete.gif" CausesValidation="False"></asp:ImageButton>
            </ItemTemplate>

            <EditItemTemplate>
                <asp:ImageButton OnClientClick="return ConfirmOperation(this,'actualizar');" ID="Imagebutton7" runat="server" AlternateText="Update" CommandName="Update" NAME="Imagebutton3" ImageUrl="../images/icon-floppy.gif" CausesValidation="False"></asp:ImageButton><img src="images/spacer.gif" width="3">
                <asp:ImageButton ID="Imagebutton8" runat="server" AlternateText="Cancel" CommandName="Cancel" NAME="Imagebutton4" ImageUrl="../images/icon-pencil-x.gif" CausesValidation="False"></asp:ImageButton>
            </EditItemTemplate>
        </asp:TemplateColumn>
    </Columns>

    <PagerStyle
        HorizontalAlign="Center"
        Mode="NumericPages"
        CssClass="grid-pager"></PagerStyle>
</asp:DataGrid></TD></TR>
			<tr>
                <td colspan="3">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></td>
            </tr>
</TABLE>
</html>
