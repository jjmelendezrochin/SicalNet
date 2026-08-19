<%@ Page Language="c#" CodeBehind="ConsultReactionWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultReactionWO1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <script language="javascript">	
        function showWaitControls() {
            waitControls.style.display = '';
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
<body>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <form id="ConsultReactionWO1" method="post" runat="server">
        <table align="center" width="100">
            <tr>
                <td align="left" colspan="5">
                    <div id="sicalMenu"></div>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="5">
                    <asp:Label ID="Label1" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Fase de Reacción</asp:Label>
                    <hr>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="standard-text">Orden de Trabajo del día:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtFecha" Font-Bold="True" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True"
                        runat="server"></asp:TextBox></td>
                <td align="center"></td>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="standard-text">Línea de Producción:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtLinea" Font-Bold="True" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True"
                        runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="5">
                    <p></p>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" CssClass="standard-text">Inventario Actual de Prepolímero</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <p></p>
                    <p class="contenido" align="center">
                        <asp:DataGrid
                            ID="dgdTanque"
                            runat="server"
                            Font-Names="Verdana"
                            BorderStyle="None"
                            BackColor="LightGray"
                            BorderColor="DimGray"
                            DataKeyField="IdTanque"
                            AllowSorting="True"
                            FontSize="11px"
                            AutoGenerateColumns="False"
                            CellPadding="2"
                            Width="100%"
                            CssClass="GridView grid-header">

                            <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Tanque">
                                    <HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemTanqueDesc" runat="server" CssClass="standard-text" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.TanqueDesc") %>'>
                                        </asp:Label>
                                        <asp:Label ID="ItemIdTanque" runat="server" CssClass="standard-text" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.IdTanque") %>' Visible="False">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Prepolimero">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemTipoPMMAId" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA")%>' Visible="False">
                                        </asp:Label>
                                        <asp:Label ID="ItemTipoPMMADesc" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TipoPMMADesc")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Capacidad">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemCapacidadMax" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadMax")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Contiene">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemTankCantidad" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.TankCantidad") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Capacidad Disponible">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemCapacidadDisponible" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadDisponible") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </p>
                </td>
            </tr>
            <tr>
                <td colspan="5"><font size="2"><b></b></font></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" CssClass="standard-text">Prepolímero por preparar:</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <p></p>
                    <p class="contenido" align="center">
                        <asp:DataGrid
                            ID="dgdReaccion"
                            runat="server"
                            Font-Names="Verdana"
                            BorderStyle="None"
                            BackColor="LightGray"
                            BorderColor="DimGray"
                            AllowSorting="True"
                            FontSize="11px"
                            AutoGenerateColumns="False"
                            CellPadding="2"
                            Width="100%"
                            CssClass="GridView grid-header">

                            <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Material">
                                    <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="60px" CssClass="grid-first-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemCodigoSAP" runat="server" CssClass="standard-text" Width="60px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
                                        </asp:Label>
                                        <asp:Label ID="ItemIdOrdenTrabajo" runat="server" CssClass="standard-text" Width="60px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdOrdenTrabajo") %>' Visible="False">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tipo de Prepol&#237;mero">
                                    <HeaderStyle Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="300px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemDescPMMA" runat="server" CssClass="standard-text" Width="200" Text='<%# DataBinder.Eval(Container, "DataItem.DescPMMA")%>'>
                                        </asp:Label>
                                        <asp:Label ID="ItemIdTipoPMMA" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' Visible="False">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Cantidad (Kilos)">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="ItemCantidad" runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSpacer" Font-Bold="True" runat="server" CssClass="standard-text"></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="5">
                    <p></p>
                    <asp:Label ID="Label5" Font-Bold="True" runat="server" CssClass="standard-text">Seleccione el Tipo de PMMA, el tanque y la cantidad que desea preparar, después presione el botón "Liberar Reactada".</asp:Label></td>
                <p></p>
            </tr>
            <tr>
                <td colspan="5">
                    <p></p>
                    <table class="tabla-ajuste-titulo"
       width="100%"
       border="0"
       cellspacing="0"
       cellpadding="0">

    <thead>
        <tr>
            <td colspan="4">
                <asp:Label
                    ID="Label9"
                    runat="server"
                    CssClass="titulo-ajuste-tanque">
                    Liberar Reactada
                </asp:Label>
            </td>
        </tr>
    </thead>

    <tbody>

        <tr>

            <td class="celda-etiqueta">
                <asp:Label
                    ID="lblTipoPrep"
                    runat="server"
                    CssClass="etiqueta-ajuste">
                    Tipo Prepolímero:
                </asp:Label>
            </td>

            <td class="celda-dato-destacado">
                <asp:DropDownList
                    ID="cmbTipoPMMA"
                    runat="server"
                    CssClass="control-ajuste">
                </asp:DropDownList>
            </td>

            <td class="celda-etiqueta">
                <asp:Label
                    ID="Label4"
                    runat="server"
                    CssClass="etiqueta-ajuste">
                    Tanque:
                </asp:Label>
            </td>

            <td class="celda-control">
                <asp:DropDownList
                    ID="cmbTanque"
                    runat="server"
                    CssClass="control-ajuste">
                </asp:DropDownList>
            </td>

        </tr>


        <tr>

            <td class="celda-etiqueta"></td>

            <td class="celda-control"></td>

            <td class="celda-etiqueta">
                <asp:Label
                    ID="lblKg"
                    runat="server"
                    CssClass="etiqueta-ajuste">
                    Cantidad (Kilos):
                </asp:Label>
            </td>

            <td class="celda-control">
                <asp:TextBox
                    ID="txtKg"
                    runat="server"
                    CssClass="control-ajuste">
                </asp:TextBox>
            </td>

        </tr>

    </tbody>

</table>
                </td>
                <tr>
                    <td align="center" width="140"></td>
                    <td align="center" valign="top">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="botonesInput" Text="Liberar Reactada"
                            Width="180px"></asp:Button>
                    </td>
                    <td align="center" width="150"></td>
                    <td align="center" valign="top" width="140">
                        <asp:Button ID="btnCancelar" runat="server" CssClass="botonesInput" Text="Regresar"></asp:Button></td>
                    <td align="center" valign="top" width="100">
                        <div id="waitControls" style="display: none">
                            <table id="Table1" width="50">
                                <tr>
                                    <td valign="top" align="center" colspan="3">
                                        <p align="center">
                                            <asp:Label ID="Label8" runat="server" CssClass="standard-text">Procesando...</asp:Label><br>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:Image>
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="lblErrorMsg" Font-Bold="True" runat="server" ForeColor="Red" CssClass="standard-text"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
