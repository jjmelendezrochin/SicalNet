<%@ Page language="c#" Codebehind="DisconnectAccounts.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Administration.DisconnectAccounts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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

function ConfirmOperation(Button)
{
	if (confirm("¿Está seguro que desea desconectar la cuenta del usuario?")) 
	{
		Button.click()
	}
}
//-->

			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Administración - Sesiones activas"
			}	
		</script>
		<link rel="stylesheet" type="text/css" href="/SicalNet/Css/sical-menu.css">
		<script type="text/javascript" src="/SicalNet/Scripts/sical-menu.js"></script>
		<!--<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">-->
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
			<table style="BORDER-COLLAPSE: collapse" height="227" width="800" align="center">
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
						<td align="center" colSpan="4" height="294" vAlign="top"><asp:datagrid id="dgdUsers" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
								Font-Name="Verdana" AllowSorting="True" DataKeyField="IdPerfil" BorderColor="White" BorderStyle="None" AllowPaging="True" PagerStyle-HorizontalAlign="Right"
								PagerStyle-Mode="NumericPages" Width="800px" ShowFooter="True" Font-Size="Small">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Login">
										<HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="20%" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemLogin CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Login") %>' Width="30px" Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Nombre">
										<HeaderStyle HorizontalAlign="Left" Width="35%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="40%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemNombre CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Nombre") %>' Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Planta">
										<HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="10%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="ItemPlanta" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.DescripcionPlanta") %>' Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Turno">
										<HeaderStyle HorizontalAlign="Left" Width="5%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="5%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="ItemTurno" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Turno") %>' Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Perfil">
										<HeaderStyle HorizontalAlign="Left" Width="5%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="5%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="ItemPerfil" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.DescripcionPerfil") %>' Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Area">
										<HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="10%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="ItemArea" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.DescripcionArea") %>' Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Activo">
										<HeaderStyle HorizontalAlign="Center" Width="5%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="itemActivo" runat="server" CssClass="standard-text" Enabled="False" Checked='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Activo") %>'>
											</asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Desconectar">
										<HeaderStyle HorizontalAlign="Center" Width="5%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" CssClass="grid-edit-column"></ItemStyle>
										<ItemTemplate>
											<asp:imagebutton id="Imagebutton1" runat="server" AlternateText="Edit" CommandName="Release" NAME="Imagebutton1"
												ImageUrl="../../images/DELROW.GIF" onmouseup="ConfirmOperation(this);" CausesValidation="false"></asp:imagebutton></asp:imagebutton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" Font-Names="Times New Roman" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
				</TBODY>
			</table>
			</TD></TR></TABLE></form>
	</body>
</HTML>
