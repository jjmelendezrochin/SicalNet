<%@ Page language="c#" Codebehind="Espesor.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Structures.Espesor" %>
<%@ Register TagPrefix="uc1" TagName="EspesorGrid" Src="../../Controls/EspesorGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		
		<script language="JavaScript">
<!--
			< !--
        function MM_reloadPage(init) {  //reloads the window if Nav4 resized
            if (init == true) with (navigator) {
                if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                    document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
                }
            }
            else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) location.reload();
        }
    MM_reloadPage(true);
    // -->

    function MM_openBrWindow(theURL, winName, features) { //v2.0
        window.open(theURL, winName, features);
    }
    //-->

    function ShowTitle() {
        window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Espesores"
    }
        </script>
		<script type="text/javascript">
            document.addEventListener(
                "DOMContentLoaded",
                function () {
                    SicalMenu.init("sicalMenu");
                }
            );
        </script>
	</HEAD>
	<body onload="ShowTitle()" bgcolor="#ffffff" text="#000000" leftmargin="0" topmargin="0"
		marginwidth="0" marginheight="0">
		<form id="PlantaForm" method="post" runat="server">	
				<table style="border-collapse: collapse; margin-top: 0; padding-top: 0;"; width="1000"; align="center">
					<tbody>
					<tr class="sical-menu-row">
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					</tbody>
				</table>
				<table style="border-collapse: collapse; margin-top: 0; padding-top: 0;"; height="227"; width="1000"; align="center">					
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><img src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
							<span class="titulo">
								<SPAN class="letraAzulBold">Catálogo de Espesores</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Es la lista de los distintos espesores de láminas que se manejan en PLASTIGLAS</asp:Label>&nbsp;</td>
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
										<TABLE  id="Table1" height="99" cellSpacing="12" cellPadding="0" width="171"
											border="0">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">Agregar un Espesor</TD>
											</TR>
											<TR>
												<TD>
													<asp:Label id="Label2" runat="server" CssClass="standard-text">Identificador de espesor </asp:Label>
													<asp:TextBox id="txtIdEspesor" runat="server" CssClass="standard-text" Width="100%" MaxLength="10"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD>
													<asp:Label id="Label3" runat="server" CssClass="standard-text">Espesor en milímetros</asp:Label>
													<asp:TextBox id="txtCentimetros" runat="server" CssClass="standard-text" Width="100%" MaxLength="20"></asp:TextBox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<asp:Label id="Label4" runat="server" CssClass="standard-text">Espesor en pulgadas </asp:Label>
													<asp:TextBox id="txtPulgadas" runat="server" CssClass="standard-text" Width="100%" MaxLength="20"></asp:TextBox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<asp:Label id="Label5" runat="server" CssClass="standard-text">Espesor nominal</asp:Label>
													<asp:TextBox id="txtNominal" runat="server" CssClass="standard-text" Width="100%" MaxLength="20"></asp:TextBox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<asp:Label id="Label6" runat="server" CssClass="standard-text">Otra espesor </asp:Label>
													<asp:TextBox id="txtOtro" runat="server" CssClass="standard-text" Width="100%" MaxLength="20"></asp:TextBox></TD>
											</TR>
											<TR vAlign="top">
												<TD>
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD height="20"  width="40%">
																<asp:button id="cmdAdd" runat="server" Width="80px" CssClass="botonesInput" Text="Agregar" CausesValidation="False"></asp:button></TD>
															<TD height="20" width="20%"></TD>
															<TD height="20" width="40%">
																<asp:button id="cmdCancel" runat="server" Width="80px" CssClass="botonesInput" Text="Cancelar"
																	CausesValidation="False"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<td valign="top" class="contenido">
										<P class="contenido" align="left">
										</P>
										<P class="contenido" align="left">
											<TABLE  id="Table3" height="99" cellSpacing="12" cellPadding="0" width="171"
												border="0">
												<TR vAlign="top">
													<TD style="padding-left:40px;">
														<uc1:EspesorGrid id="dgEspesor" runat="server"></uc1:EspesorGrid>
													</TD>
												</TR>
											</TABLE>
										</P>
										<asp:Label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></td>
								</tr>
							</table>
						</td>
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
			
		</form>
	</body>
</HTML>
