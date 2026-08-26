
<%@ Page language="c#" Codebehind="UnLiberer.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.UnLiberer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>UnLiberer</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

	  <script language="JavaScript">  
			function ShowTitle()
		{
			window.frames["top"].document.title = "SICAL  - Logística - Reactivar Secuencia"
		}
		</script>
	    <script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
	    </script>
	    <style type="text/css">
            .auto-style1 {
                height: 65px;
            }
        </style>
	  </HEAD>
	<body onload="ShowTitle()" MS_POSITIONING="GridLayout">
		<form id="UnLiberer" method="post" runat="server">
			<table align="center" style="BORDER-COLLAPSE: collapse" class="auto-style1">
				<tr>
					<td align="left" colSpan="5">
						<div id="sicalMenu"></div>
					</td>
				</tr>
				<tr>
					<td align="center" colspan="2"><br />
						<asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">
							Reactivar secuencia
						</asp:Label>
					</td>
				</tr>
			</table>
			<br />			
			<table width="700" align="center" style="BORDER-COLLAPSE: collapse">
				<TR>
					<TD colspan="2">
						<asp:label id="Label2" runat="server" Width="700px" CssClass="standard-text">Proporcione el número de secuencia que desea reactivar, y posteriormente seleccione las áreas en donde desea que sea reactivada la secuencia proporcionada.</asp:label></TD>
				</TR>
				<tr>
					<TD colspan="2"></TD>
				</tr>
				<tr>
					<td align="right"><asp:label id="Label1" runat="server" CssClass="standard-text">Secuencia:</asp:label></td>
					<td><asp:textbox id="txtSecuencia" runat="server" CssClass="standard-text" Width="300px" BorderStyle="Groove"></asp:textbox><asp:button id="btnUnLiberer" runat="server" Text="Reactivar" CssClass="botonesInput"></asp:button></td>
				</tr>
				<tr>
					<TD colspan="2"></TD>
				</tr>
				<tr>
					<td colspan="2">
						<asp:datalist id="DLArea" runat="server" Width="700px" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="grid-item">
							<HeaderTemplate>
								<TABLE>
									<TR>
										<TD></TD>
										<TD><B class="standard-text" style="COLOR: white">Area</B></TD>
									</TR>
								</TABLE>
							</HeaderTemplate>
							<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<TABLE>
									<TR>
										<TD align="middle">
											<asp:CheckBox id="chkSelect" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
										<TD>
											<asp:Label id=lblArea Width="200px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
											</asp:Label>
											<asp:Label id=lblIdArea CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdArea") %>' Runat="server" Visible="False">
											</asp:Label></TD>
									</TR>
								</TABLE>
							</ItemTemplate>
							<HeaderStyle CssClass="grid-header"></HeaderStyle>
						</asp:datalist>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
