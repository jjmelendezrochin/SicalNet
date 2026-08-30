<%@ Page language="c#" Codebehind="ErrorPage.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.CustomError.ErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorPage</title>
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
	<body onload="ShowTitle()" bgcolor="#ffffff" text="#000000" leftmargin="0" topmargin="0"
		marginwidth="0" marginheight="0">
		<form runat="server">
			<P>&nbsp;</P>
			<TABLE WIDTH="70%" BORDER="0" CELLSPACING="1" CELLPADDING="1" align="center">
				<TR>
					<TD class="letraAzulBoldError">Error - Sical.NET !!!</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<P>Ha ocurrido un error en la aplicación,&nbsp;el cual pudo ser provocado por un 
							error en la captura; por lo cual se sugiere&nbsp;realizar los pasos que a 
							continuación se describen:</P>
						<P>NOTA: En la parte inferior se muestra una descripción del error en color <FONT color="#ff9900">
								naranja</FONT> que se ha generado y que puede ser de ayuda para dar 
							seguimiento al problema.</P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<P>1. Presione el botón de "Regresar" que aparece en la parte inferior de este 
							mensaje.</P>
						<P>2. Revise la información capturada, y repita el proceso que ejecutó.</P>
						<P>3. Si el error persiste, contácte a su Administrador para recibir apoyo.</P>
						<br>
						<P>Gracias !!!</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" align="center">
							<TR>
								<TD class="grid-header">Descripción del Error</TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblExc" runat="server" CssClass="LetraNaranjaBold" Width="100%">Label</asp:Label></TD>
							</TR>
						</TABLE>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="letraAzulBoldTitle" align="center">
						<asp:Button id="btnBack" runat="server" Text="Regresar" CssClass="botonesInput"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
