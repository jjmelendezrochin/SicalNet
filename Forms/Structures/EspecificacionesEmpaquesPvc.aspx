<%@ Page language="c#" Codebehind="EspecificacionesEmpaquesPvc.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.EspecificacionesEmpaquesPvc" %>
<%@ Register TagPrefix="uc1" TagName="EspecificacionesPvcGrid" Src="../../Controls/EspecificacionesPvcGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Gu�a de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
//-->
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Cat�logos - Cat�logo de Medidas"
			}
		</script>
		<link href="../../styloDESC.CSS" rel="stylesheet" type="text/css">
	</HEAD>
	<body onload="ShowTitle()" bgcolor="#ffffff" text="#000000" leftmargin="0" topmargin="0"
		marginwidth="0" marginheight="0">
		<form id="MedidaForm" method="post" runat="server">
			<div align="center">
				<table width="740" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td colspan="2" class="contenido" bgcolor="#003366">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
						</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><img src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catalogo de Especificaciones de empaques PVC y EPDM</SPAN>
							</span>
						</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<asp:Label id="Label2" runat="server" Visible="False" CssClass="standard-text">Lista de especificaciones de empaques</asp:Label>&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<table width="700" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td width="20" height="12">&nbsp;</td>
									<TD width="10" height="12"></TD>
									<td height="12"><span class="letraAzulBold"></span></td>
								</tr>
								<tr>
									<td width="20" class="contenido" vAlign="top">
										<TABLE class="tan-border" id="Table1" height="99" cellSpacing="12" cellPadding="0" width="171"
											border="0">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">Agregar una Medida</TD>
											</TR>
											<TR>
												<TD>
													<asp:Label id="Label1" runat="server" CssClass="standard-text">Código SAP</asp:Label><br>
													<asp:dropdownlist style="Z-INDEX: 0" id="cboCodigoSap" runat="server" CssClass="standard-text" Width="143px"></asp:dropdownlist>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<asp:button style="Z-INDEX: 0" id="cmdConsulta" runat="server" CssClass="botonesInput" Width="64px"
														CausesValidation="False" Text="Consulta"></asp:button>
												</TD>
											</TR>
										</TABLE>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<td valign="top" class="contenido">
										<P class="contenido" align="left">
										</P>
										<P class="contenido" align="left">
											<TABLE class="tan-border" id="Table3" height="99" cellSpacing="12" cellPadding="0" width="171"
												border="0">
												<TR vAlign="top">
													<TD>
														<uc1:EspecificacionesPvcGrid id="dgEspecificaciones" runat="server"></uc1:EspecificacionesPvcGrid>
													</TD>
												</TR>
											</TABLE>
										</P>
									</td>
								</tr>
							</table>
							<asp:Label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></td>
					</tr>
					<tr>
						<td width="20" class="contenido">&nbsp;</td>
						<td width="700" class="contenido">
							<div align="right"></div>
						</td>
						<td width="20" class="contenido">&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td><div align="right"></div>
						</td>
						<td>&nbsp;</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
