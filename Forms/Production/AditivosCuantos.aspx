<%@ Page language="c#" Codebehind="AditivosCuantos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.CuantosOllas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CUANTOS OLLAS</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="CuantosOllas" method="post" runat="server">
			<table borderColorDark="activecaption" width="700" align="center">
				<tr>
					<td colspan="3" align="middle"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Fase de Aditivos - Paso 1</asp:Label><hr>
					</td>
				</tr>
				<tr>
					<td colspan="3" align="middle"><asp:Label id="Label1" runat="server" CssClass="standard-text">Indique la cantidad de ollas que desea emplear</asp:Label></td>
				</tr>
				<tr>
					<td colspan="1" align="left"><asp:Label id="Label3" runat="server" CssClass="standard-text"><b>Secuencia</b></asp:Label>
						<asp:Label id="lblSecuencia" runat="server" CssClass="standard-text"></asp:Label></td>
					<td colspan="2" align="left"><asp:Label id="Label4" runat="server" CssClass="standard-text"><b>Descripcion</b></asp:Label>
						<asp:Label id="lblDescripcion" runat="server" CssClass="standard-text"></asp:Label></td>
				</tr>
				<tr>
					<td width="30%" style="HEIGHT: 72px"></td>
					<td width="30%" align="middle" style="HEIGHT: 72px">
						<asp:Label id="Label2" runat="server" CssClass="standard-text">Ollas:   </asp:Label>
						<asp:textbox id="txtCuanto" Runat="server" Width="75px" CssClass="Standard-text" BorderStyle="Groove"></asp:textbox></td>
					<td width="30%" style="HEIGHT: 72px"></td>
				</tr>
				<tr>
					<td></td>
					<td vAlign="bottom" align="right"><asp:button id="cmdAnterior" Runat="server" Text="<- Anterior" CssClass="botonesInput"></asp:button></td>
					<td><asp:button id="btnOk" Runat="server" Text="Siguiente ->" CssClass="botonesInput" Width="80px"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
