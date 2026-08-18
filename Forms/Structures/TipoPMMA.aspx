<%@ Page language="c#" Codebehind="TipoPMMA.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.TipoPMMAForm" %>
<%@ Register TagPrefix="uc1" TagName="TipoPMMAGrid" Src="../../Controls/TipoPMMAGrid.ascx" %>
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
					window.frames["top"].document.title = "SICAL  - Cat�logos - Cat�logo de Tipos de prepolimeros"
			}
		</script>
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->

		<script type="text/javascript">document.addEventListener(
			  "DOMContentLoaded",
			  function () {
				  SicalMenu.init("sicalMenu");
			  }
		  );
		</script>
  </HEAD>
	<body onload="ShowTitle()" bgcolor="#ffffff" text="#000000" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="TipoPMMAForm" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" colSpan="2">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="21" height="11">&nbsp;</td>

						<td width="700" height="31"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="titulo"><SPAN class="letraAzulBold">&nbsp;<SPAN class="titulo"><SPAN class="letraAzulBold">Catálogo de Tipos de prepolimeros 
      (PMMA)</SPAN>
													</SPAN></SPAN>
											</SPAN>
										</FONT>
									</SPAN>
								</SPAN>
							</span></td>
						<td width="20" height="11">&nbsp;</td>
					</tr>
					<tr>
						<td width="21" height="13">&nbsp;</td>
						<td width="700" height="13">
							<asp:label id="Label1" runat="server" CssClass="standard-text">Es la lista de los diferentes Materiales que son Prepolimeros (PMMA)</asp:label>
							&nbsp;</td>
						<td width="20" height="13">&nbsp;</td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td align=middle>
							<div align="center">
								<TABLE  id="tableNewComponents" cellSpacing="12" cellPadding="0" width="700" border="0" runat="server">
									<TR vAlign="top">
										<TD class="letraAzulBold" colSpan="4" height="13">
											<p></p>
											<P>Agregue el Codigo SAP de Material que desea marcar como un tipo de Prepolímero</P>
										</TD>
									</TR>
									<TR>
										<TD width="122" height="28">
											<asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material</asp:label></TD>
										<TD height="28" width="162">
											<asp:textbox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="131px" AutoPostBack="True"></asp:textbox>
											<asp:imagebutton id="cmdFindMaterial" runat="server" Height="23px" ImageUrl="../../Images/Find.gif" DESIGNTIMEDRAGDROP="255"></asp:imagebutton></TD>
										<TD colSpan="2" height="28">
											<asp:textbox id="txtDescripcion" runat="server" Width="362px" CssClass="standard-text" BorderStyle="None" Enabled="False"></asp:textbox>
										</TD>
									</TR>
									<TR vAlign="top">
										<TD width="122">
											<P align="right">
												<asp:button id="AddTipoPMMA" runat="server" Width="80px" CssClass="botonesInput" CausesValidation="False" Text="Agregar"></asp:button></P>
										</TD>
										<TD width="122"></TD>
										<TD width="162">
											<P align="left">
												<asp:button id="cmdCancelC" runat="server" Width="80px" CssClass="botonesInput" CausesValidation="False" Text="Cancelar"></asp:button></P>
										</TD>
										<TD>
											<P align="left">
												<asp:Label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></P>
										</TD>
									</TR>
								</TABLE>
							</div>
						</td>
						<TD align=middle>&nbsp;</TD>
					</tr>
  <TR>
    <TD width=21></TD>
    <TD align=middle>
      <TABLE id=Table3 cellSpacing=12 cellPadding=0 width=700 border=0 style="align-content:center">
        <TR vAlign=top>
          <TD style="padding-left:40px;">
			<uc1:TipoPMMAGrid id=TipoPMMAGridControl runat="server"></uc1:TipoPMMAGrid>
          </TD>
        </TR>
      </TABLE>
    </TD>
    <TD align=middle></TD></TR>
				</table>
			</div>
			<div align="center">
				<table width="740" border="0" cellspacing="0" cellpadding="0">
				</table>
			</div>
		</form>
	</body>
</HTML>
