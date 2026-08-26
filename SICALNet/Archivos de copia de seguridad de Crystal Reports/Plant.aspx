<%@ Page language="c#" Codebehind="Plant.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.PlantaForm" %>
<%@ Register TagPrefix="uc1" TagName="PlantGrid" Src="../../Controls/PlantGrid.ascx" %>
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
				window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de Plantas"
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
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="PlantaForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" colSpan="2">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
							<span class="titulo">
								<span class="letraAzulBold">Catalogo de Plantas</span>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<asp:label id="Label1" runat="server" CssClass="standard-text">Es la lista de las distintas plantas industriales de PLASTIGLAS en donde se producen láminas.</asp:label>&nbsp;</td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="20">&nbsp;</td>
						<td width="700">
							<table cellSpacing="0" cellPadding="0" width="700" border="0">
								<tr>
									<td width="20" height="12">&nbsp;</td>
									<TD width="10" height="12"></TD>
									<td height="12">
										<span class="letraAzulBold"></span>
									</td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="20">
										<TABLE id="Table1" height="99" cellSpacing="12" cellPadding="0" width="171" border="0">
											<TR vAlign="top">
												<TD class="letraAzulBold" height="13">Agregue un Planta</TD>
											</TR>
											<TR>
												<TD>
													<P>
														<asp:label id="Label2" runat="server" CssClass="standard-text">Nombre de la Planta:</asp:label><br>
														<asp:textbox id="txtDescription" runat="server" Width="100%" CssClass="standard-text"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD>
													<P>
														<asp:label id="Label3" runat="server" CssClass="standard-text">Denominación SAP:</asp:label><br>
														<asp:textbox id="txtDenomSAP" runat="server" Width="100%" CssClass="standard-text"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD>
													<P>&nbsp;
														<asp:label id="Label4" runat="server" CssClass="standard-text">Porcentaje de merma:</asp:label><br>
														<asp:textbox id="txtMerma" runat="server" CssClass="standard-text" Width="100%">0</asp:textbox></P>
												</TD>
											</TR>
              <TR>
                <TD>
<asp:label id=Label5 runat="server" CssClass="standard-text">% Rendimiento Color:</asp:label>
<asp:textbox id=txtRendimientoColor runat="server" CssClass="standard-text" Width="100%">0</asp:textbox></TD></TR>
											<TR vAlign="top">
												<TD>
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD height="20" width="40%">
																<asp:button id="AddPlant" runat="server" Width="80px" CssClass="botonesInput" CausesValidation="False" Text="Agregar"></asp:button>
															</TD>
															<td width="20%"></td>
															<TD height="20" width="40%">
																<asp:button id="cmdCancelC" runat="server" Width="80px" CssClass="botonesInput" CausesValidation="False" Text="Cancelar"></asp:button>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
									<TD class="contenido" vAlign="top" width="10"></TD>
									<td class="contenido" vAlign="top">
										<P class="contenido" align="left"></P>
										<P class="contenido" align="left">
											<TABLE id="Table3" height="99" cellSpacing="12" cellPadding="0" width="171" border="0">
												<TR vAlign="top">
													<TD style="padding-left:40px;">
														<uc1:plantgrid id="plantGridControl" runat="server"></uc1:plantgrid>
													</TD>
												</TR>
											</TABLE>
										</P>
									</td>
								</tr>
							</table>
							<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td class="contenido" width="20">&nbsp;</td>
						<td class="contenido" width="700">
							<div align="right"></div>
						</td>
						<td class="contenido" width="20">&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td>
							<div align="right"></div>
						</td>
						<td>&nbsp;</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>