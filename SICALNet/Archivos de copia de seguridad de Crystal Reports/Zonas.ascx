<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="Zonas.ascx.cs" Inherits="UserInterface.Controls.ZonasGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Zonas</title>

    <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

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
<body>
    <table width="100%">
        <tr>
            <td align="left" colspan="2">
                <asp:Label ID="Label1" Text="Línea :   " runat="server" CssClass="standard-text" Width="50px"></asp:Label>&nbsp;&nbsp;
				<asp:DropDownList ID="cboLinea" CssClass="standard-text" Width="122px" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" Text="Aceptar" CssClass="botonesInput" runat="server" CausesValidation="False"></asp:Button>
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataGrid ID="dgdZonas" Width="100%" runat="server" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages"
                    AllowPaging="True" BorderStyle="None" BorderColor="White" AllowSorting="True" FontSize="11px" Font-Name="Verdana"
                    AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" CssClass="GridView grid-header">
                    <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Zona">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemZona" Width="50px" CssClass="standard-text" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Zona") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Linea">
                            <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="EditLinea" CssClass="standard-text" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IdLinea") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="SecuenciaActual">
                            <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemSecuenciaActual" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.SecuenciaActual") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Denominación">
                            <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="ItemDenominacion" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Denominacion") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="EditDenominacion" BorderStyle="Groove" Width="200" Height="50" TextMode="MultiLine" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Denominacion") %>' MaxLength="100">
                                </asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Editar">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle Width="100px" CssClass="grid-edit-column"></ItemStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
                                    NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:ImageButton><img src="images/spacer.gif" width="3">
                                <asp:ImageButton OnClientClick="return ConfirmOperation(this,'eliminar');" ID="Imagebutton6" runat="server"
                                    CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
                                    AlternateText="Delete"></asp:ImageButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton OnClientClick="return ConfirmOperation(this,'actualizar');" ID="Imagebutton7" runat="server"
                                    CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update"
                                    AlternateText="Update"></asp:ImageButton><img src="images/spacer.gif" width="3">
                                <asp:ImageButton ID="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
                                    NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:ImageButton>
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
            <td colspan="2">
                <asp:Label ID="lblErrorMsg" CssClass="standard-text" runat="server"></asp:Label><input id="SecuenciaActualhtml" type="hidden" name="SecuenciaActualhtml" runat="server">
                <input type="hidden" id="Zonahtml" name="Zonahtml" runat="server">
            </td>
        </tr>
    </table>
</body>
</html>
