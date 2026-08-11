<%@ Page language="c#" Codebehind="NumeroPaquete.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.PartidasEnvioPT.NumeroPaquete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>NumeroPaquete</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="..\..\..\..\styloDESC.CSS" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="NumeroPaquete" method="post" runat="server">
			<table borderColorDark="activecaption" width="700" align="center">
				<tr>
					<td align="middle" colSpan="3"><asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Fase de Entrega de Producto Terminado - Paso 1</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td align="middle" colSpan="3"><asp:label id="Label1" runat="server" CssClass="standard-text">Indique la laminas de Paquete que desea emplear</asp:label></td>
				</tr>
				<tr>
					<td align="left" colSpan="1"><asp:label id="Label3" runat="server" CssClass="standard-text"><b>Secuencia:</b></asp:label><asp:label id="lblSecuencia" runat="server" CssClass="standard-text"></asp:label></td>
					<td align="left" colSpan="2"><asp:label id="Label4" runat="server" CssClass="standard-text"><b>Descripcion:</b></asp:label><asp:label id="lblDescripcion" runat="server" CssClass="standard-text"></asp:label></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td><b>
							<asp:label id="Label5" runat="server" CssClass="standard-text">
								<b>Láminas útiles:</b></asp:label></b>
						<asp:label id="lblLaminas" runat="server" CssClass="standard-text"></asp:label></td>
				</tr>
				<tr>
					<td style="HEIGHT: 72px" width="30%"></td>
					<td style="HEIGHT: 72px" align="middle" width="30%"><asp:label id="Label2" runat="server" CssClass="standard-text">Paquetes:   </asp:label><asp:textbox id="txtCuanto" BorderStyle="Groove" CssClass="Standard-text" Width="75px" Runat="server"></asp:textbox></td>
					<td style="HEIGHT: 72px" width="30%"></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="bottom" align="right"><asp:button id="cmdAnterior" CssClass="botonesInput" Runat="server" Text="<- Anterior"></asp:button></td>
					<td><asp:button id="btnOk" CssClass="botonesInput" Width="80px" Runat="server" Text="Siguiente ->"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
