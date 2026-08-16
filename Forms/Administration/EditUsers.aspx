<%@ Page language="c#" Codebehind="EditUsers.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Administration.EditUsers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>">

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

function CheckUnCheckAll(CtrlName)
{
	alert (CtrlName);
	alert (CtrlName.indexOf('checkAll'));   
}
//-->
		</script>
		
		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body>
		<form id="ConsultColorWO" method="post" runat="server">
			<table width="800" align="center" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="left" colSpan="4">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td align="middle" colSpan="4"><br>
							<asp:label id="lblTitle" runat="server" Font-Size="14pt" Font-Bold="True" Font-Names="Arial Narrow"> Módulo de Usuarios</asp:label>
							<hr>
						</td>
					</tr>
					<TR>
						<TD colspan="4">
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Para agregar un prefil presione el botón NUEVO, para modificar uno perfil, seleccione el perfil deseado.</asp:Label></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label2" runat="server" CssClass="standard-text">Login:</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtLogin" runat="server" CssClass="standard-text" BorderStyle="Groove" Width="200px"></asp:TextBox></TD>
						<TD>
							<P align="left">
								<asp:Label id="Label3" runat="server" CssClass="standard-text">Nombre:</asp:Label></P>
						</TD>
						<TD>
							<P align="left">
								<asp:TextBox id="txtNombre" runat="server" CssClass="standard-text" Width="200px" BorderStyle="Groove"></asp:TextBox></P>
						</TD>
					</TR>
					<TR>
						<TD height="20">
							<asp:Label id="Label4" runat="server" CssClass="standard-text">Planta:</asp:Label></TD>
						<TD height="20">
							<asp:DropDownList id="cboPlanta" runat="server" CssClass="standard-text" Width="200px"></asp:DropDownList></TD>
						<TD height="20">
							<asp:Label id="Label5" runat="server" CssClass="standard-text">Area:</asp:Label></TD>
						<TD height="20">
							<P align="left">
								<asp:DropDownList id="cboArea" runat="server" CssClass="standard-text" Width="200px"></asp:DropDownList></P>
						</TD>
					</TR>
					<TR>
						<TD height="22">
							<asp:Label id="Label6" runat="server" CssClass="standard-text">Perfil:</asp:Label></TD>
						<TD height="22">
							<asp:DropDownList id="cboPerfil" runat="server" CssClass="standard-text" Width="200px"></asp:DropDownList></TD>
						<TD height="22">
							<asp:Label id="Label7" runat="server" CssClass="standard-text">Turno:</asp:Label></TD>
						<TD height="22">
							<asp:TextBox id="txtTurno" runat="server" CssClass="standard-text" Width="200px" BorderStyle="Groove"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD>
							<asp:Label id="Label8" runat="server" CssClass="standard-text">Activo:</asp:Label></TD>
						<TD>
							<asp:CheckBox id="chkActivo" runat="server" CssClass="standard-text"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD>
							<P align="center">&nbsp;</P>
						</TD>
						<TD>
							<P align="left">&nbsp;</P>
						</TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD>
							<P align="center">
								<asp:Button id="btnSalvar" runat="server" CssClass="botonesInput" Text="Salvar"></asp:Button></P>
						</TD>
						<TD>
							<P align="left">
								<asp:Button id="btnCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:Button></P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="4"></TD>
					</TR>
					<TR>
						<td colSpan="4">
							<P><hr>
							<P></P>
						</td>
					</TR>
				</TBODY>
			</table>			
		</form>
	</body>
</HTML>
