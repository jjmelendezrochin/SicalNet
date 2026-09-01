<%@ Page Language="c#" CodeBehind="Bitacora.aspx.cs" AutoEventWireup="false" ValidateRequest="True" Inherits="BitacoraExportacion1.Bitacora" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Bitácora de Exportación</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <script type="text/javascript">document.addEventListener(
            "DOMContentLoaded",
            function () {
                SicalMenu.init("sicalMenu");
            }
        );
    </script>

</head>
<body ms_positioning="GridLayout">
    <form id="Bitacora" method="post" runat="server">
        <div align="center">
            <table cellspacing="0" cellpadding="0" border="0" width="740">
                <tr>
                    <td valign="top" align="center">
                        <div id="sicalMenu"></div>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" border="0" width="100%" height="100%">
                <tr>
                    <td valign="top" align="center">
                        <table cellspacing="0" cellpadding="0" border="0" width="700">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblTitulo" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Bitacora de Eventos</asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <div align="right">
                                        <asp:LinkButton ID="linkbitacora" runat="server" CausesValidation="False">Regresar</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButton ID="rdbSicalnet" runat="server" CssClass="standard-text" GroupName="1" AutoPostBack="True"
                                        Text="Bitácora SicalNet"></asp:RadioButton>
                                    <asp:RadioButton ID="rdbDatasul" runat="server" CssClass="standard-text" GroupName="1" AutoPostBack="True"
                                        Text="Bitácora ERP" Width="112px"></asp:RadioButton></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="center">
                                        <asp:Label ID="lblError" runat="server" CssClass="standard-text" Height="6px" BorderColor="Red"
                                            BackColor="White" ForeColor="Red"></asp:Label>
                                        <asp:DataGrid ID="dgdVerBitacora" runat="server" Font-Names="Verdana" Width="688px" BorderColor="Black"
                                            AllowPaging="True" HorizontalAlign="Center" AllowSorting="True" Font-Size="11px" Font-Name="Verdana"
                                            AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="Consultar">
                                                    <HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
                                                    <ItemTemplate>
                                                        <footerstyle horizontalalign="Right"></footerstyle>
                                                        <asp:Button ID="Button1" runat="server" CssClass="standard-text" Text="Consulta" Width="100px"
                                                            CommandName="Consulta" Visible="true"></asp:Button><br>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Fecha de Bitacora">
                                                    <HeaderStyle HorizontalAlign="Center" Width="140px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" Width="150px" Text='<%#DataBinder.Eval(Container, "DataItem.FechaValue") %>' runat="server" Visible="true" CssClass="standard-text">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="Archivo">
                                                    <HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle Width="50px" CssClass="grid-first-item"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" Width="130px" Text='<%#DataBinder.Eval(Container, "DataItem.NombreValue") %>' runat="server" Visible="true" CssClass="standard-text">
                                                        </asp:Label><br>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Left"></FooterStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn Visible="False">
                                                    <HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                                                    <HeaderTemplate>
                                                        Tamaño
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.TamañoValue") %>' Width="150px" Visible="true" runat="server">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" Mode="NumericPages"></PagerStyle>
                                        </asp:DataGrid>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="center">
                                        <asp:TextBox ID="txtDespliega" runat="server" CssClass="standard-text" Width="680px" Height="331px"
                                            ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
