<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="OllaGrid.ascx.cs" Inherits="UserInterface.Controls.OllaGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>OllaGrid</title>

    <script type="text/javascript" language="javascript">
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
    <link href="../styloDESC.CSS" type="text/css" rel="stylesheet">
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body>
    <table width="100%">
        <tr>
            <td width="30%" colspan="2">
                <asp:Label ID="Label1" Width="70px" runat="server" CssClass="standard-text">Num. Olla</asp:Label>
                <asp:TextBox ID="txtNumOlla" Width="80px" runat="server" CssClass="standard-text" MaxLength="6"></asp:TextBox>
            </td>
            <td width="70%" colspan="3">
                <asp:Label ID="Label3" runat="server" CssClass="standard-text">Línea</asp:Label>
                <asp:DropDownList ID="cboLinea" runat="server" CssClass="standard-text" Width="101px"></asp:DropDownList>
                <asp:Button ID="aceptar" Text="Aceptar" runat="server" CssClass="botonesInput" Width="80px"
                    CausesValidation="False"></asp:Button>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:DataGrid ID="dgdOlla" runat="server" Width="100%" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
                    Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="NumeroOlla" BorderColor="White"
                    BorderStyle="None" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"  CssClass="GridView grid-header">
                    <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="N&#250;mero de Olla">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemNumeroOlla" Width="50px" CssClass="standard-text" runat="server" Text='&nbsp;<%#DataBinder.Eval(Container, "DataItem.NumeroOlla") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="EditNumeroOlla" Width="50px" CssClass="standard-text" runat="server" Text='&nbsp;<%#DataBinder.Eval(Container, "DataItem.NumeroOlla") %>'>
                                </asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Descripci&#243;n">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemDescripcion" CssClass="standard-text" Text='&nbsp;<%#DataBinder.Eval(Container, "DataItem.Descripcion") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="EditDescripcion" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container,"DataItem.Descripcion") %>' MaxLength="10">
                                </asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Capacidad m&#225;xima">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemCapacidadMax" CssClass="standard-text" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.CapacidadMax") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="EditCapacidadMax" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container,"DataItem.CapacidadMax") %>' MaxLength="10">
                                </asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Capacidad m&#237;nima">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemCapacidadMin" CssClass="standard-text" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.CapacidadMin") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="EditCapacidadMin" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%#DataBinder.Eval(Container,"DataItem.CapacidadMin") %>' MaxLength="10">
                                </asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Planta">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemPlanta" CssClass="standard-text" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.DescrPlanta") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="EditPlanta" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Linea">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemLinea" CssClass="standard-text" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.IdLinea") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="EditLinea" CssClass="Standard-text" runat="server" Width="70" BorderStyle="Groove"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Editar">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle CssClass="grid-edit-column"></ItemStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif" NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:ImageButton><img src="images/spacer.gif" width="3">
                                <asp:ImageButton OnClientClick="return ConfirmOperation(this,'eliminar');" ID="Imagebutton6" runat="server" CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete" AlternateText="Delete"></asp:ImageButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton OnClientClick="return ConfirmOperation(this,'actualizar');" ID="Imagebutton7" runat="server" CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update" AlternateText="Update"></asp:ImageButton><img src="images/spacer.gif" width="3">
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
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label>
                <input type="hidden" name="ItemDescripcionhtml" id="ItemDescripcionhtml" runat="server">
            </td>
        </tr>
    </table>
</body>
</html>
