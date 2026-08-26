<%@ Page language="c#" Codebehind="MensajePopup.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.MensajePopup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Mensaje de Piso</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

	</HEAD>
	<body>
		<form id="MensajePopup" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="3" align="center"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Agregar Mensaje de Piso</asp:Label><hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="lblSecuencia" runat="server" Width="64px" CssClass="standard-text">Secuencia:</asp:label></td>
					<td colspan="2"><asp:label id="txtSecuencia" runat="server" Width="124px" Font-Bold="True" CssClass="standard-text">Label</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server" Width="78px" CssClass="standard-text">CodigoSAP:</asp:label></td>
					<td colspan="2"><asp:label id="lblCodigosap" runat="server" Width="124px" Font-Bold="True" CssClass="standard-text">Label</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server" CssClass="standard-text">Descripción:</asp:label></td>
					<td colspan="2"><asp:label id="lblDescripcion" runat="server" Width="271px" Font-Bold="True" CssClass="standard-text">Label</asp:label></td>
				</tr>
				<tr>
					<td colspan="3" align="center"><hr>
					</td>
				</tr>
				<TR>
					<TD colSpan="3">
						<asp:label id="Label1" runat="server" CssClass="standard-text">Seleccione las áreas a donde desea enviar el mensaje de Piso:</asp:label></TD>
				</TR>
				<tr>
					<td colspan="3">
						<asp:DataList id="DLArea" runat="server" Width="500px" RepeatColumns="3" BorderWidth="1" RepeatDirection="Horizontal"
							CssClass="grid-item">
							<HeaderTemplate>
								<TABLE id="Table5">
									<TR>
										<TD width="30"></TD>
										<TD align="center" width="400"><B style="COLOR: white">
												<asp:label id="Label3" runat="server" Font-Bold="True" Width="271px" CssClass="standard-text"
													ForeColor="White">Area</asp:label></B></TD>
									</TR>
								</TABLE>
							</HeaderTemplate>
							<ItemStyle Font-Size="2pt" Height="0px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<TABLE>
									<TR>
										<TD align="center">
											<asp:CheckBox id="chkSelect" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
										<TD width="250">
											<asp:Label id=lblArea CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
											</asp:Label>
											<asp:Label id=lblIdArea CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdArea") %>' Runat="server" Visible="False">
											</asp:Label></TD>
									</TR>
								</TABLE>
							</ItemTemplate>
							<HeaderStyle CssClass="grid-header"></HeaderStyle>
						</asp:DataList>
					</td>
				</tr>
				<TR>
					<TD colSpan="3"><asp:label id="Label7" runat="server" Font-Bold="True" CssClass="standard-text">Mensaje de Piso:</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMensaje" runat="server" Height="65px" Width="500px" TextMode="MultiLine"
							BorderStyle="Groove" CssClass="standard-text"></asp:textbox></TD>
				</TR>
				<TR align="right">
					<TD></TD>
					<TD>
						<asp:button id="btnAceptar" runat="server" Text="Enviar" CssClass="botonesInput"></asp:button></TD>
					<TD align="center">
						<asp:button id="btnCancelar" runat="server" Text="Regresar" CssClass="botonesInput"></asp:button></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
