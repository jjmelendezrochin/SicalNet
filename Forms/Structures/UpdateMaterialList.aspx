<%@ Page language="c#" Codebehind="UpdateMaterialList.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.UpdateMaterialList" %>
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
function showWaitControls()
{
	waitControls.style.display='';
}			

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
	window.frames["top"].document.title = "SICAL  - Estructuras - Actualizar Lista de Materiales en SAP" 
}
		</script>

		<script type="text/javascript">document.addEventListener(
                "DOMContentLoaded",
                function () {
                    SicalMenu.init("sicalMenu");
                }
            );
        </script>
		
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginwidth="0" marginheight="0">
		<form id="UpdateMaterialList" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr class="sical-menu-row">
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td width="700"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="letraAzulBold">Actualizar Lista de Materiales en SAP</SPAN>
										</FONT>
									</SPAN>
								</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="21" height="14">&nbsp;</td>
						<td width="700" height="14">
							<asp:label id="Label3" runat="server" CssClass="standard-text">Este módulo genera la lista de insumos del producto o productos solicitados</asp:label></td>
						<td width="20" height="13">&nbsp;</td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td>
							<div align="left">
								<TABLE class="tan-border" id="tableNewComponents" cellSpacing="12" cellPadding="0" width="704"
									border="0" runat="server">
									<TR vAlign="top">
										<TD class="letraAzulBold" colSpan="2" height="14">Indique el material que desea 
											actualizar.</TD>
										<TD class="letraAzulBold" height="14"></TD>
										<TD class="letraAzulBold" height="14"></TD>
									</TR>
									<TR>
										<TD width="122" height="28">
											<P align="right"><asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta:</asp:label></P>
										</TD>
										<TD height="28" colspan="2"><asp:dropdownlist id="cboPlanta" tabIndex="5" runat="server" CssClass="standard-text" Width="147px"></asp:dropdownlist><asp:label id="Label1" runat="server" CssClass="standard-text">*Seleccione la planta cuyos datos desea actualizar</asp:label></TD>
									</TR>
									<TR>
										<TD width="122" height="28">
											<P align="right"><asp:label id="lblMaterial" runat="server" CssClass="standard-text">Material:</asp:label></P>
										</TD>
										<TD height="28"><asp:textbox id="txtCodigoSAP" tabIndex="1" runat="server" MaxLength="18" AutoPostBack="True"
												CssClass="standard-text" Width="131px"></asp:textbox><asp:imagebutton id="cmdFindMaterial" runat="server" ToolTip="Si no conoce el Codigo SAP del Material que desea agregar, haga click sobre este botón"
												Height="23px" ImageUrl="../../Images/Find.gif"></asp:imagebutton></TD>
										<TD colSpan="2" height="28"><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" Width="362px" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR vAlign="top">
										<TD width="122">
											<P align="right"><asp:button id="cmdAdd" tabIndex="2" runat="server" CssClass="botonesInput" Text="Agregar"></asp:button></P>
										</TD>
										<td>
											<P align="left"><asp:button id="btnCancelar" tabIndex="3" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button></P>
										</td>
										<TD colSpan="2">
											<P align="left"><asp:textbox id="txtHidden" runat="server" Width="0px"></asp:textbox><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
										</TD>
									</TR>
								</TABLE>
							</div>
						</td>
						<td>&nbsp;</td>
					</tr>
					<TR>
						<TD></TD>
						<TD>
							<TABLE class="tan-border" id="tableMaterials" cellSpacing="12" cellPadding="0" width="700"
								border="0" runat="server" visible="False">
								<TR vAlign="top">
									<TD align="center"><asp:button id="btnActualizar" accessKey="A" tabIndex="4" runat="server" CssClass="botonesInput"
											ToolTip="Press Alt+A to get Focus" Text="Actualizar"></asp:button></TD>
									<TD align="left" colSpan="2"></TD>
								</TR>
								<TR>
									<TD align="right" height="19">
										<P align="center"><asp:button id="btnInterface" accessKey="E" tabIndex="6" runat="server" CssClass="botonesInput"
												Width="91px" Text="Interface Excel"></asp:button></P>
									</TD>
									<TD align="left" height="19"><asp:button id="btnCSV" accessKey="C" tabIndex="7" runat="server" CssClass="botonesInput" Text="Interface CSV"
											Width="97px"></asp:button></TD>
									<TD align="center" height="19"></TD>
								</TR>
								<TR>
									<TD class="Normal" align="left" colSpan="4">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE>
												<TR>
													<TD><asp:image id="Image2" runat="server" ImageUrl="../../images/waitImage.gif"></asp:image></TD>
													<TD><asp:label id="Label2" runat="server" CssClass="standard-text"> Este proceso puede demorar varios segundos, debido a que en este momento estamos calculando la lista de cada uno de los Materiales seleccionados. Agradecemos su paciencia.</asp:label></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
								<TR vAlign="top">
									<TD colSpan="4" height="28"><asp:datagrid id="dgdMaterial" Width="500px" BorderStyle="None" Runat="server" Font-Names="Verdana"
											CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="White">
											<Columns>
												<asp:TemplateColumn HeaderText="CodigoSAP">
													<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblCodigoSAP Width="60px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Descripcion">
													<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="250px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblDesc Width="250px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Estado Material">
													<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblEstadoMaterialDesc Width="100px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.EstadoMaterialDesc") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Estado Producto">
													<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblEstadoProductoDesc Width="100px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.EstadoProductoDesc") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Linea Base">
													<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblLineaDesc Width="70px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.LineaDesc") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Quitar">
													<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle CssClass="grid-item"></ItemStyle>
													<ItemTemplate>
														<asp:imagebutton id="imgSelect" runat="server" ImageUrl="../../images/icon-delete.gif" AlternateText="Delete"
															CommandName="Delete" NAME="imgSelect" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD colSpan="4" height="28"><asp:datagrid id="dgdResults" runat="server" Width="675px" BorderStyle="None" CellPadding="4"
											BorderColor="#CC9966" BackColor="White" BorderWidth="1px" ForeColor="Aqua" CssClass="standard-text">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="DarkOrange"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
						<TD height="221"></TD>
					</TR>
					<TR>
						<TD width="21"></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</table>
			</div>
		</form>
	</body>
</HTML>
