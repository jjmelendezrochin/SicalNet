<%@ Page language="c#" Codebehind="SecuenciasCombinadas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.SecuenciasCombinadas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SecuenciasCombinadas</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="SecuenciasCombinadas" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td colspan="3" align="middle"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Secuencias combinadas.</asp:Label>
						</td>
					</tr>
					<tr>
						<td colspan="2" bgColor="#276187">
							<asp:Label id="Label2" runat="server" Font-Bold="True" ForeColor="White">Favor de verificar el mensaje:</asp:Label></td>
					</tr>
					<tr>
						<td colspan="2" align=center><asp:Label id="Label1" runat="server" Width="700px">Label</asp:Label></td>
					</tr>
					<tr>
						<td align="middle"><asp:Button id="btnBack" runat="server" Text="<- Regresar" Width="86px" CssClass="botonesInput"></asp:Button></td>
						<td align="middle"><asp:Button id="btnNext" runat="server" Text="Continuar ->" Width="89px" CssClass="botonesInput"></asp:Button></td>
					</tr>
		</form>
		</TBODY></TABLE>
	</body>
</HTML>
