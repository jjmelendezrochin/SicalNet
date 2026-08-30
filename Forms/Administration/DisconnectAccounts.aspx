<%@ Page language="c#" Codebehind="DisconnectAccounts.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Administration.DisconnectAccounts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">

		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
        <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		
		<script language="JavaScript">
            <!--
            <!--
            function MM_reloadPage(init) {  //reloads the window if Nav4 resized
              if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
                document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
              else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
            }
            MM_reloadPage(true);
            // -->

            function MM_openBrWindow(theURL,winName,features) { //v2.0
              window.open(theURL,winName,features);
            }            

            var liberarConfirmado = false;

            function ConfirmOperation(Button) {
                if (liberarConfirmado) {
                    liberarConfirmado = false;
                    return true;
                }

                SicalAlert.confirmar(
                    "¿Está seguro que desea desconectar la cuenta del usuario?",
                    "Confirmar liberación",
                    function () {
                        liberarConfirmado = true;
                        Button.click();
                    }
                );

                return false;
            }

            //-->

			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Administración - Sesiones activas"
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
	</HEAD>
	<body onload="ShowTitle()">
		<form id="ConsultColorWO" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" height="227" width="80%" align="center">
				<TBODY>
					<tr>
						<td align="left" colSpan="4">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="4" height="85"><br>
							<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Administrador de Cuentas de Sesión</asp:label>
							<hr>
						</td>
					</tr>
					<TR>
						<TD width="50%"><asp:label id="Label2" runat="server" CssClass="standard-text" Font-Size="13px" Font-Bold="True"> Cuentas actualmente conectadas al sistema</asp:label></TD>
						<TD width="10%">
							<P align="center"><asp:button id="btnBuscar" runat="server" CssClass="botonesInput" Text="Buscar" Visible="False"></asp:button></P>
						</TD>
						<TD width="20%">
							<P align="center"><asp:textbox id="txtCriterio" runat="server" CssClass="standard-text" Width="150px" Visible="False"></asp:textbox></P>
						</TD>
						<TD width="20%">
							<P align="center"><asp:dropdownlist id="cboCriterio" runat="server" CssClass="standard-text" Width="150px" Visible="False">
									<asp:ListItem Value="Nombre">Nombre</asp:ListItem>
									<asp:ListItem Value="Login">Login</asp:ListItem>
									<asp:ListItem Value="IdPlanta">Planta</asp:ListItem>
									<asp:ListItem Value="Turno">Turno</asp:ListItem>
									<asp:ListItem Value="IdPerfil">Perfil</asp:ListItem>
									<asp:ListItem Value="IdArea">Area</asp:ListItem>
								</asp:dropdownlist></P>
						</TD>
					</TR>
					<tr>
						<td width="20%" colSpan="4">
							<hr>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="4" vAlign="top">
							<asp:datagrid id="dgdUsers" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
								Font-Name="Verdana" AllowSorting="True" DataKeyField="IdPerfil" BorderColor="White" BorderStyle="None" AllowPaging="True" PagerStyle-HorizontalAlign="Right"
								PagerStyle-Mode="NumericPages" Width="80%" ShowFooter="True" Font-Size="Small"
								CssClass="GridView">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
                                <asp:TemplateColumn HeaderText="Login">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="16%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        Width="16%"
                                        CssClass="grid-first-item">
                                    </ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemLogin"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.Login") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Nombre">
                                    <HeaderStyle
                                        HorizontalAlign="Left"
                                        Width="28%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        Width="28%"
                                        CssClass="grid-item">
                                    </ItemStyle>

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
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        Width="12%"
                                        CssClass="grid-item">
                                    </ItemStyle>

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
                                        Width="10%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        Width="10%"
                                        CssClass="grid-item">
                                    </ItemStyle>

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
                                        Width="14%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        Width="14%"
                                        CssClass="grid-item">
                                    </ItemStyle>

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
                                        Width="12%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        Width="12%"
                                        CssClass="grid-item">
                                    </ItemStyle>

                                    <ItemTemplate>
                                        <asp:Label
                                            ID="ItemArea"
                                            CssClass="standard-text"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.DescripcionArea") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn
                                    Visible="False"
                                    HeaderText="Activo">

                                    <HeaderStyle
                                        HorizontalAlign="Center"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        HorizontalAlign="Center"
                                        CssClass="grid-item">
                                    </ItemStyle>

                                    <ItemTemplate>
                                        <asp:CheckBox
                                            ID="itemActivo"
                                            runat="server"
                                            CssClass="standard-text"
                                            Enabled="False"
                                            Checked='<%# DataBinder.Eval(Container, "DataItem.Activo") %>'>
                                        </asp:CheckBox>
                                    </ItemTemplate>

                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Desconectar">

                                    <HeaderStyle
                                        HorizontalAlign="Center"
                                        Width="8%"
                                        CssClass="grid-header"
                                        VerticalAlign="Middle">
                                    </HeaderStyle>

                                    <ItemStyle
                                        HorizontalAlign="Center"
                                        Width="8%"
                                        CssClass="grid-edit-column">
                                    </ItemStyle>

                                    <ItemTemplate>
                                        <asp:ImageButton
                                            ID="Imagebutton1"
                                            runat="server"
                                            AlternateText="Desconectar"
                                            CommandName="Release"
                                            ImageUrl="../../images/DELROW.GIF"
                                            OnClientClick="return ConfirmOperation(this);"
                                            CausesValidation="false">
                                        </asp:ImageButton>
                                    </ItemTemplate>

                                </asp:TemplateColumn>

                            </Columns>
								<PagerStyle Font-Size="X-Small" 
                                    HorizontalAlign="Center"
									Mode="NumericPages"
									CssClass="grid-pager">
								</PagerStyle>
							</asp:datagrid></td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>