<%@ Register TagPrefix="uc1" TagName="ListMaterialGrid" Src="../../Controls/ListofMaterialGrid.ascx" %>
<%@ Page language="c#" Codebehind="ListOfMaterial.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.ListOfMaterial" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<link rel="Stylesheet" type="text/css" href="/SicalNet/Css/sical-menu.css" />
		<script type="text/javascript" src="/SicalNet/Scripts/sical-menu.js"></script>
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
function ShowTitle()
{
	window.frames["top"].document.title = "SICAL  - Estructuras - Lista de Materiales"
}

//-->
		</script>
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->
		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
		<!--onload="if ('<%= Session["errMsg"]%>' != '') alert('<%= Session["errMsg"]%>')"-->
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginheight="0" marginwidth="0">
		<form id="ListMat" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" border="0">
					<TBODY>
						<tr>
							<td class="contenido" colSpan="3">
								<div id="sicalMenu"></div>
							</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><IMG height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
								<span class="titulo">
									<SPAN class="letraAzulBold">Lista de Materiales</SPAN>
								</span></td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700">
								<asp:Label id="Label6" runat="server" CssClass="standard-text">Es una lista en donde se establecen las Formulaciones de Color con las que se preparan los Productos Terminado.</asp:Label>
								&nbsp;&nbsp;&nbsp;</td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700">
								<table cellSpacing="0" cellPadding="0" width="700" border="0">
									<TBODY>
										<tr>
											<td width="20" height="12">&nbsp;
												<TABLE class="tan-border" id="Table1" cellSpacing="12" cellPadding="0" width="700" border="0">
													<TR vAlign="top">
														<TD colspan="4" class="letraAzulBold" width="256" height="12">Lista de Materiales</TD>
													</TR>
													<TR>
														<TD width="105" height="5">
															<P align="right">
																<asp:Label id="Label1" runat="server" CssClass="standard-text">Código del Material:</asp:Label></P>
														</TD>
														<TD colspan="3" height="5">
															<asp:TextBox id="txtCodigoSAP" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox>
															<asp:imagebutton id="imgbtnFind" runat="server" Height="23px" ImageUrl="../../Images/Find.gif"></asp:imagebutton>
															<asp:TextBox id="txtDescripcion" CssClass="standard-text" Width="218px" ReadOnly="True" Runat="server"
																BorderStyle="None"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD width="105" height="28">
															<P align="right">
																<asp:Label id="Label2" runat="server" CssClass="standard-text">Código de la Formulación de Color:</asp:Label></P>
														</TD>
														<TD colspan="3" height="28">
															<asp:TextBox id="txtCodigoSAPHijo" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox>
															<asp:imagebutton id="imgbtnFind1" runat="server" Height="23px" ImageUrl="../../Images/Find.gif"></asp:imagebutton>
															<asp:TextBox id="txtDescripcionHijo" CssClass="standard-text" Width="217px" ReadOnly="True" Runat="server"
																BorderStyle="None"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD width="105" height="6">
															<P align="right">
																<asp:Label id="Label3" runat="server" CssClass="standard-text">Cantidad :</asp:Label></P>
														</TD>
														<TD height="6" width="139" colspan="3">
															<asp:TextBox id="txtCantidad" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox></TD>
													</TR>
													<TR vAlign="top">
														<TD width="105" height="11">
															<P align="right">
																<asp:Label id="Label4" runat="server" CssClass="standard-text">Unidad:</asp:Label></P>
														</TD>
														<TD height="11" width="139">
															<asp:dropdownlist id="cboUnidad" runat="server" CssClass="standard-text" Width="142px"></asp:dropdownlist></TD>
														<TD height="11">
															<P align="right">
																&nbsp;
																<asp:Label id="Label5" runat="server" CssClass="standard-text">Planta:</asp:Label></P>
														</TD>
														<TD height="11">
															<asp:dropdownlist id="cboPlanta" runat="server" CssClass="standard-text" Width="142px" AutoPostBack="True"></asp:dropdownlist></TD>
													</TR>
													<TR vAlign="top">
														<TD width="105">
															<P align="right">
																<asp:button id="AddLstMat" runat="server" CssClass="botonesInput" Width="64px" Text="Agregar"
																	CausesValidation="False"></asp:button></P>
														</TD>
														<TD width="139">
															<asp:button id="cmdCancelC" runat="server" CssClass="botonesInput" Width="64px" Text="Cancelar"
																CausesValidation="False"></asp:button></TD>
														<TD colspan="2">
															<asp:Label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></TD>
													</TR>
												</TABLE>
											</td>
											<TD width="20" height="12"></TD>
										</tr>
										<TR>
											<TD class="contenido" vAlign="top" width="20"></TD>
											<TD class="contenido" vAlign="top" width="20"></TD>
										</TR>
										<tr>
											<td class="contenido" vAlign="top" width="20">
												<P class="contenido" align="left">
													<TABLE class="tan-border" id="Table3" cellSpacing="12" cellPadding="0" width="700" border="0">
														<TR vAlign="top">
															<TD>
																<uc1:ListMaterialGrid id="LstMatGrid" runat="server"></uc1:ListMaterialGrid></TD>
														</TR>
													</TABLE>
												</P>
											</td>
											<TD class="contenido" vAlign="top" width="20"></TD>
										</tr>
									</TBODY></table>
							</td>
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
					</TBODY></table>
			</div>
		</form>
	</body>
</HTML>
