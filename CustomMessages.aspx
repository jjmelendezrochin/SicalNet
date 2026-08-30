<%@ Page language="c#" Codebehind="CustomMessages.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.CustomMessages" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
		<script language="javascript">
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL - Error en la Aplicación";
		    }
		    
   			function ShowInfo()
			{
				var elem;
				elem=document.getElementById("divInformation");
				elem.style.visibility="visible";
		    }

		</script>
		<LINK href="styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowTitle()"
		marginheight="0" marginwidth="0">
		<form id="Form1" runat="server">
			<P>&nbsp;</P>
			<TABLE cellSpacing="1" cellPadding="1" width="70%" align="center" border="0">
				<TR>
					<TD class="letraAzulBoldError"><FONT face="Verdana" size="2">Sical.NET - Herramienta de 
							control de excepciones</FONT></TD>
				</TR>
				<TR>
					<TD><FONT face="Verdana" size="1">&nbsp;</FONT></TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<P><FONT face="Verdana" size="2"> Ha ocurrido una excepción&nbsp;&nbsp;en la 
								aplicación,&nbsp;el cual pudo ser provocado por un error en la captura.Se 
								sugiere&nbsp;realizar los pasos que a continuación se describen:</FONT></P>
						<P><FONT face="Verdana" size="2"></FONT>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<P><FONT face="Verdana" size="2">1. Presione el botón de "Regresar" hasta que haya 
								leido las todas las instrucciones.</FONT></P>
						<P><FONT face="Verdana" size="2">2. Una vez en la pantalla anterior, revise la 
								información capturada, y repita el proceso que ejecutó.</FONT></P>
						<P><FONT face="Verdana" size="2">3. Si el error persiste, contácte a su Administrador 
								para recibir apoyo.</FONT></P>
						<br>
						<P><FONT face="Verdana" size="2">Gracias !!!</FONT></P>
						<P align="center">
							<asp:Button id="btnBack" runat="server" CssClass="botonesInput" Text="Regresar"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
					<input type="button" value="Pulse aquí para ver información técnica" class="botonesInput" style="width:250px" onclick="ShowInfo()">
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						&nbsp;
						<div id="divInformation" style="visibility:hidden">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" align="center">
							<TR>
								<TD class="grid-header">
									<asp:Label id="lblerror" runat="server" Font-Size="9pt" Font-Names="Verdana" ></asp:Label></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						</div>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle" align="center"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
