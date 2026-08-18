<%@ Page Language="c#" CodeBehind="UsersList.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Administration.UsersList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Lista de usuario</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />
    
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>">


    <script language="JavaScript">
			<!--
    function MM_reloadPage(init) {  //reloads the window if Nav4 resized
        if (init == true) with (navigator) {
            if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
            }
        }
        else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) location.reload();
    }
    MM_reloadPage(true);
    // -->

    function MM_openBrWindow(theURL, winName, features) { //v2.0
        window.open(theURL, winName, features);
    }

    function ConfirmOperation(Button) {
        if (confirm("¿Está seguro que desea liberar la cuenta del usuario?")) {
            Button.click()
        }
    }
    //-->

    function ShowTitle() {
        window.frames["top"].document.title = "SICAL  - Administración - Catálogo Usuarios"
    }
    </script>

    <script type="text/javascript">
        document.addEventListener(
            "DOMContentLoaded",
            function () {
                SicalMenu.init("sicalMenu");
            }
        );
    </script>

</head>
<body onload="ShowTitle()">
    <form id="ConsultColorWO" method="post" runat="server">
        <table style="border-collapse: collapse" height="227" width="800" align="center">
            <tbody>
                <tr>
                    <td align="left" colspan="4">
                        <div id="sicalMenu"></div>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" height="85">
                        <br>
                        <asp:Label ID="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Catálogo de Usuarios</asp:Label>
                        <hr>
                    </td>
                </tr>
                <tr>
                    <td width="50%">
                        <asp:Label ID="Label1" runat="server" CssClass="standard-text"> Para agregar un usuario presione el botón "Nuevo"</asp:Label></td>
                    <td width="10%">
                        <p align="center">
                            <asp:Button ID="btnNuevo" runat="server" CssClass="botonesInput" Text="Nuevo..." OnClick="btnNuevo_Click1"></asp:Button></p>
                    </td>
                    <td width="20%"></td>
                    <td width="20%"></td>
                </tr>
                <tr>
                    <td width="50%">
                        <asp:Label ID="Label2" runat="server" CssClass="standard-text">Para modificar un usuario, búsquelo y presione el icono Editar (lápiz)</asp:Label></td>
                    <td width="10%">
                        <p align="center">
                            <asp:Button ID="btnBuscar" runat="server" CssClass="botonesInput" Text="Buscar"></asp:Button></p>
                    </td>
                    <td width="20%">
                        <p align="center">
                            <asp:TextBox ID="txtCriterio" runat="server" CssClass="standard-text" Width="150px"></asp:TextBox></p>
                    </td>
                    <td width="20%">
                        <p align="center">
                            <asp:DropDownList ID="cboCriterio" runat="server" CssClass="standard-text" Width="150px">
                                <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
                                <asp:ListItem Value="Login">Login</asp:ListItem>
                                <asp:ListItem Value="IdPlanta">Planta</asp:ListItem>
                                <asp:ListItem Value="Turno">Turno</asp:ListItem>
                                <asp:ListItem Value="IdPerfil">Perfil</asp:ListItem>
                                <asp:ListItem Value="IdArea">Area</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td width="20%" colspan="4">
                        <hr>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" height="294" valign="top">
                        <asp:DataGrid
                            ID="dgdUsers"
                            runat="server"
                            Font-Names="Verdana"
                            CellPadding="2"
                            AutoGenerateColumns="False"
                            Font-Name="Verdana"
                            AllowSorting="True"
                            DataKeyField="IdPerfil"
                            BorderColor="White"
                            BorderStyle="None"
                            AllowPaging="True"
                            PagerStyle-HorizontalAlign="Right"
                            PagerStyle-Mode="NumericPages"
                            Width="80%"
                            ShowFooter="True"
                            Font-Size="Small"
                            CssClass="GridView grid-users">

                            <HeaderStyle
                                Font-Bold="True"
                                CssClass="grid-header"></HeaderStyle>

                            <Columns>

                                <asp:TemplateColumn HeaderText="Login">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="16%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        Width="16%"
                                        CssClass="grid-first-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemLogin"
                                            CssClass="standard-text login-cell"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.Login") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Nombre">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="20%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        Width="20%"
                                        CssClass="grid-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemNombre"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Planta">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="12%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        Width="12%"
                                        CssClass="grid-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemPlanta"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionPlanta") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Turno">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="6%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        Width="6%"
                                        CssClass="grid-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemTurno"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.Turno") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Perfil">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="18%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        Width="18%"
                                        CssClass="grid-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemPerfil"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionPerfil") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Area">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="14%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        Width="14%"
                                        CssClass="grid-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemArea"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionArea") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Activo">
                                    <HeaderStyle
                                        HorizontalAlign="Center"
                                        Width="4%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        HorizontalAlign="Center"
                                        Width="4%"
                                        CssClass="grid-item"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:CheckBox
                                            ID="itemActivo"
                                            runat="server"
                                            CssClass="standard-text"
                                            Enabled="False"
                                            Checked='<%# DataBinder.Eval(Container, "DataItem.Activo") %>'></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Editar">
                                    <HeaderStyle
                                        HorizontalAlign="Center"
                                        Width="5%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        HorizontalAlign="Center"
                                        Width="5%"
                                        CssClass="grid-edit-column"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:ImageButton
                                            ID="Imagebutton5"
                                            runat="server"
                                            AlternateText="Editar"
                                            CommandName="Edit"
                                            NAME="Imagebutton1"
                                            ImageUrl="../../images/icon-pencil.gif"
                                            CausesValidation="false"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Liberar">
                                    <HeaderStyle
                                        HorizontalAlign="Center"
                                        Width="5%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle"></HeaderStyle>

                                    <ItemStyle
                                        HorizontalAlign="Center"
                                        Width="5%"
                                        CssClass="grid-edit-column"></ItemStyle>

                                    <ItemTemplate>
                                        <asp:ImageButton
                                            ID="Imagebutton1"
                                            runat="server"
                                            AlternateText="Liberar"
                                            CommandName="Release"
                                            NAME="Imagebutton1"
                                            ImageUrl="../../images/DELROW.GIF"
                                            OnClientClick="return ConfirmOperation(this);"
                                            CausesValidation="false"></asp:ImageButton>
                                    </ItemTemplate>
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
            </tbody>
        </table>
    </form>
</body>
</html>
