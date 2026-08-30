<%@ Page language="c#" Codebehind="404Page.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.CustomError._404Page" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>404Page</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<script language="javascript">
		<!--
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL - Error en la Aplicación"
		    }
		//-->
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="70%" align="center" border="0">
				<TR>
					<TD class="letraAzulBoldError">Archivo&nbsp;no encontrado&nbsp;- Sical.NET !!!</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<P>El archivo que busca no ha sido encontrado. Notifique a su Administrador.</P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TR>
								<TD class="grid-header">Descripción del Error</TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblExc" runat="server" CssClass="LetraNaranjaBold" Width="100%">Error 404 - Archivo no encontrado</asp:Label></TD>
							</TR>
						</TABLE>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle" align="center">
						<asp:Button id="btnBack" runat="server" CssClass="botonesInput" Text="Regresar"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
