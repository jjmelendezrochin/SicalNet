<%@ Page language="c#" Codebehind="Profiles.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Administration.Profiles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>

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

function ConfirmOperation(Button,strOperationType)
{
	if (confirm("¿Está seguro que desea "+strOperationType+" este perfil?")) 
	{
		Button.click()
	}
}
//-->
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Administración - Catálogo de Perfiles"
			}	
		</script>
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->

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
			<table width="800" align="center" style="BORDER-COLLAPSE: collapse" height="227">
				<TBODY>
					<tr>
						<td align="left" colSpan="4">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="4" height="80"><br>
							<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Catálogo de Perfiles</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td colSpan="2" width="80%">
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Para agregar un prefil presione el botón NUEVO, para modificar uno perfil, seleccione el perfil deseado.</asp:Label></td>
						<td colSpan="2" width="20%"><asp:Button id="Button1" runat="server" CssClass="botonesInput" Text="Nuevo..."></asp:Button></td>
					</tr>
					<tr>
						<td colSpan="4" width="20%"><hr>
						</td>
					</tr>
					<tr>
						<td colSpan="4" align="center">
							<asp:datagrid 
								id="dgdPerfiles" 
								runat="server" 
								PagerStyle-Mode="NumericPages" 
								PagerStyle-HorizontalAlign="Right"
								PageSize="10" 
								AllowPaging="True" 
								BorderStyle="None" 
								BorderColor="White" 
								DataKeyField="IdPerfil"
								AllowSorting="True" 
								FontSize="11px" 
								Font-Name="Verdana" 
								AutoGenerateColumns="False" 
								CellPadding="2"
								Font-Names="Verdana" 
								CssClass="GridView">

								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Id">
										<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="15%" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemIdPerfil Width="30px" Runat="server" Text='<%#  DataBinder.Eval(Container, "DataItem.IdPerfil") %>' CssClass="standard-text">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Descripci&#243;n">
										<HeaderStyle HorizontalAlign="Center" Width="70%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60%" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemDescripcion Runat="server" Text='<%#  DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Editar">
										<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle CssClass="grid-edit-column"></ItemStyle>
										<ItemTemplate>
											<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../../images/icon-pencil.gif"
												NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
											<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
												CausesValidation="False" ImageUrl="../../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
												AlternateText="Delete"></asp:imagebutton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle
									HorizontalAlign="Center"
									Mode="NumericPages"
									CssClass="grid-pager">
								</PagerStyle>
							</asp:datagrid>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
