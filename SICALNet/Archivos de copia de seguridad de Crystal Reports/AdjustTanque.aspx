<%@ Page Language="c#" CodeBehind="AdjustTanque.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.AdjustTanque" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>AdjustTanque</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <script language="javascript">
        function ConfirmOperation(Button) {
            if (confirm("Do you want the Adjust the Tank")) {
                Button.click()
            }
        }
        function ShowTitle() {
            window.frames["top"].document.title = "SICAL  - Tanques Prepolímero"
        }
    </script>

    <script type="text/javascript">document.addEventListener(
            "DOMContentLoaded",
            function () {
                SicalMenu.init("sicalMenu");
            }
        );
    </script>
</head>
<body ms_positioning="GridLayout" onload="ShowTitle()">
    <form id="AdjustTanque" method="post" runat="server">
        <table align="center">
            <tr>
                <td align="left" colspan="5">
                    <div id="sicalMenu"></div>
                </td>
            </tr>
            <tr>
                <td align="middle" colspan="5">
                    <asp:Label ID="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Tanques de Prepolímero</asp:Label>
                    <hr>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True">Inventario de Tanques y Ocupación</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <p></p>
                    <p class="contenido" align="center">
                        <asp:DataGrid
                            ID="dgdTanque"
                            runat="server"
                            Width="700px"
                            Font-Names="Verdana"
                            CellPadding="2"
                            AutoGenerateColumns="False"
                            FontSize="11px"
                            AllowSorting="True"
                            DataKeyField="IdTanque"
                            BorderColor="DimGray"
                            BorderStyle="None"
                            CssClass="GridView">
                            <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Tanque">
                                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="80px" CssClass="grid-first-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemTanqueDesc" Width="80px" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TanqueDesc") %>'>
                                        </asp:Label>
                                        <asp:Label ID="ItemIdTanque" Width="80px" Visible="False" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTanque") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Prepolimero">
                                    <HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemTipoPMMADesc" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TipoPMMADesc")%>'>
                                        </asp:Label>
                                        <asp:Label ID="ItemTipoPMMAId" Visible="False" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Capacidad">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemCapacidadMax" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadMax")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Contiene">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemTankCantidad" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TankCantidad") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Capacidad Disponible">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemCapacidadDisponible" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadDisponible") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Editar">
                                    <HeaderStyle
                                        HorizontalAlign="Center"
                                        Width="8%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle CssClass="grid-edit-column"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:ImageButton
                                            ID="Imagebutton5"
                                            runat="server"
                                            CausesValidation="false"
                                            ImageUrl="../../images/icon-pencil.gif"
                                            NAME="Imagebutton1"
                                            CommandName="Select"
                                            AlternateText="Editar"
                                            ToolTip="Ajustar tanque"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </p>
                </td>
            </tr>
            <tr>
                <td><font size="2"><b></b></font></td>
            </tr>
            <tr>
                <td>
                    <p class="contenido" align="left">
                        <asp:Label ID="Label2" runat="server" Font-Names="Arial Narrow" Font-Size="14" Visible="False" Font-Bold="True">Ajustes</asp:Label>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <p class="contenido" align="left">
                        <asp:DataGrid ID="dgdAdjustTanque" runat="server" Width="700px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" FontSize="11px" AllowSorting="True" BorderColor="DimGray" BorderStyle="None" Font-Name="Verdana" Visible="False" BackColor="LightGray">
                            <HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Folio Ajuste">
                                    <HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="30px" CssClass="grid-first-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdAjuste" Width="40px" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdAjuste") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdjustFecha" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Fecha") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tanque">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTanqueDesc" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescTanque") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Prepolimero Orginal">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPMMAOrg" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescTipoPMMAOrg") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Cantidad Orginal">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCantOrg" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadOrg") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Prepolimero Final">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPMMAFin" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.DescTipoPMMAFin") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Cantidad Final">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCantFin" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadFin") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </p>
                </td>
            </tr>
            <tr>
                <td><font size="2"><b></b></font></td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Width="700px" Visible="False" CssClass="panel-ajuste-tanque">
                        <table id="Table1" width="700" border="0" cellspacing="0" cellpadding="0" 
                            class="tabla-ajuste-titulo">
                            <thead>
                                <tr>
                                    <td>
                                        <asp:Label
                                            ID="Label3"
                                            runat="server"
                                            CssClass="titulo-ajuste-tanque">
                                            Ajuste de Tanque
                                        </asp:Label>
                                    </td>
                                </tr>
                            </thead>
                        </table>

                        <table id="ReleaseTank" width="700" border="0" cellspacing="0" cellpadding="0" class="tabla-ajuste">

                            <tr>
                                <td class="celda-etiqueta">
                                    <asp:Label
                                        ID="lblTanqueDesc2"
                                        runat="server"
                                        CssClass="etiqueta-ajuste">
                    Tanque Seleccionado:
                                    </asp:Label>
                                </td>

                                <td colspan="3" class="celda-dato-destacado">
                                    <asp:Label
                                        ID="txtTanqueDesc2"
                                        runat="server"
                                        CssClass="dato-destacado">
                                    </asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="celda-etiqueta">
                                    <asp:Label
                                        ID="lblPmmaOrg2"
                                        runat="server"
                                        CssClass="etiqueta-ajuste">
                    Prepolímero Actual
                                    </asp:Label>
                                </td>

                                <td class="celda-dato">
                                    <asp:Label
                                        ID="txtPmmaOrg2"
                                        runat="server"
                                        CssClass="dato-actual">
                                    </asp:Label>
                                </td>

                                <td class="celda-etiqueta">
                                    <asp:Label
                                        ID="lblCantOrg2"
                                        runat="server"
                                        CssClass="etiqueta-ajuste">
                    Cantidad Actual
                                    </asp:Label>
                                </td>

                                <td class="celda-dato">
                                    <asp:Label
                                        ID="txtCantOrg2"
                                        runat="server"
                                        CssClass="dato-actual">
                                    </asp:Label>

                                    <asp:Label
                                        ID="Label4"
                                        runat="server"
                                        CssClass="unidad-ajuste">
                    kg
                                    </asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="celda-etiqueta">
                                    <asp:Label
                                        ID="lblPMMAFin2"
                                        runat="server"
                                        CssClass="etiqueta-ajuste">
                    Nuevo Prepolímero
                                    </asp:Label>
                                </td>

                                <td class="celda-control">
                                    <asp:DropDownList
                                        ID="cmbPMMAFin"
                                        runat="server"
                                        AutoPostBack="false"
                                        CssClass="control-ajuste">
                                    </asp:DropDownList>
                                </td>

                                <td class="celda-etiqueta">
                                    <asp:Label
                                        ID="lblCantFin2"
                                        runat="server"
                                        CssClass="etiqueta-ajuste">
                    Nueva Cantidad
                                    </asp:Label>
                                </td>

                                <td class="celda-control">
                                    <asp:TextBox
                                        ID="txtCantFin2"
                                        runat="server"
                                        CssClass="control-ajuste">
                                    </asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="celda-etiqueta celda-etiqueta-superior">
                                    <asp:Label
                                        ID="lblCassa"
                                        runat="server"
                                        CssClass="etiqueta-ajuste">
                    Causa del ajuste:
                                    </asp:Label>
                                </td>

                                <td colspan="3" class="celda-control">
                                    <asp:TextBox
                                        ID="txtCassa"
                                        runat="server"
                                        TextMode="MultiLine"
                                        CssClass="control-ajuste textarea-ajuste">
                                    </asp:TextBox>
                                </td>
                            </tr>

                        </table>

                        <table id="Table2" width="700" border="0" cellspacing="0" cellpadding="0" class="tabla-ajuste-botones">

                            <tr>
                                <td width="25%"></td>
                                <td width="25%"></td>                                

                                <td align="center" width="25%">
                                    <asp:Button
                                        ID="btnCancelar"
                                        runat="server"
                                        CssClass="botonesInput boton-cancelar"
                                        Text="Cancelar"></asp:Button>
                                </td>

                                <td align="center" width="25%">
                                    <asp:Button
                                        ID="btnAceptar"
                                        runat="server"
                                        CssClass="botonesInput boton-aceptar"
                                        Text="Ajustar"></asp:Button>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4" class="celda-mensaje-error">
                                    <asp:Label
                                        ID="lblErrorMsg"
                                        runat="server"
                                        CssClass="mensaje-error-ajuste">
                                    </asp:Label>
                                </td>
                            </tr>

                        </table>

                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td></td>
                </TD>
            </tr>
        </table>
    </form>
</body>
</html>
