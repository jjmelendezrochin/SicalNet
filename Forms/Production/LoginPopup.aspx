<%@ Page language="c#" Codebehind="LoginPopup.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.LoginPopup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoginPopup</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="LoginPopup" method="post" runat="server">
			<table align="center">
				<tr>
					<td align="middle"><asp:label id="lblMsg" runat="server" Width="222px" CssClass="standard-text"></asp:label></td>
				</tr>
			</table>
			<TABLE class="backGrisTablaObs" id="Table1" cellSpacing="0" cellPadding="3" align="center" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<TD class="epi-font3" align="middle" colSpan="2">Login</TD>
					<td>&nbsp;</td>
					<td width="10">&nbsp;</td>
				</tr>
				<TR>
					<td width="10">&nbsp;</td>
					<TD class="headTabla" align="right">Nombre:</TD>
					<TD class="headTabla"><ASP:TEXTBOX id="txtLogin" runat="server" CssClass="letra_negra" MaxLength="20" Columns="16"></ASP:TEXTBOX></TD>
					<td width="10">&nbsp;</td>
				</TR>
				<TR>
					<td width="10">&nbsp;</td>
					<TD class="headTabla" align="right">Contraseña:</TD>
					<TD class="headTabla"><ASP:TEXTBOX id="txtPassword" runat="server" CssClass="letra_negra" MaxLength="16" Columns="16" TextMode="Password"></ASP:TEXTBOX></TD>
					<td width="10">&nbsp;</td>
				</TR>
				<TR>
					<td width="10">&nbsp;</td>
					<TD class="headTabla" align="middle" colSpan="2"><ASP:BUTTON id="cmdSignIn" runat="server" Width="80px" CssClass="botonesInput" Text="Abrir Sesión"></ASP:BUTTON></TD>
					<td width="10">&nbsp;</td>
				</TR>
				<tr>
					<td width="10">&nbsp;</td>
					<TD>&nbsp;</TD>
					<td>&nbsp;</td>
					<td width="10">&nbsp;</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
