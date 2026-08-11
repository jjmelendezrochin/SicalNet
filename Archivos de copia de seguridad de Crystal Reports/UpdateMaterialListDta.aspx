<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="UpdateMaterialListDta.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.UpdateMaterialListDta" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowTitle()"
		marginheight="0" marginwidth="0">
		<form id="UpdateMaterialList" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="0" width="740" border="0">
					<tr>
						<td class="contenido" bgColor="#003366" colSpan="3"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
					</tr>
					<tr>
						<td width="21">&nbsp;</td>
						<td width="700"><span class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="letraAzulBold">Actualizar Lista de Materiales en&nbsp;ERP</SPAN>
										</FONT>
									</SPAN>
								</SPAN>
							</span></td>
						<td width="20">&nbsp;</td>
					</tr>
					<tr>
						<td width="21" height="14">&nbsp;</td>
						<td width="700" height="14"><asp:label id="Label3" runat="server" CssClass="standard-text">Este módulo genera la lista de insumos del producto o productos seleccionados</asp:label></td>
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
										<TD align="right"><asp:linkbutton id="linkbitacora" runat="server" CausesValidation="False">Ver Bitacoras SicalNet/ERP</asp:linkbutton></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="left" colSpan="4">
											<TABLE id="Table1" cellSpacing="7" cellPadding="1" width="100%" border="0">
												<TR>
													<TD align="right"><asp:label id="lblPlanta" runat="server" CssClass="standard-text">Planta:</asp:label></TD>
													<TD align="left"><asp:dropdownlist id="cboPlanta" tabIndex="5" runat="server" CssClass="standard-text" Width="147px"></asp:dropdownlist></TD>
													<TD align="left"><asp:label id="Label1" runat="server" CssClass="standard-text">*Seleccione la planta cuyos datos desea actualizar</asp:label></TD>
												</TR>
												<TR>
													<TD align="right" width="80"><asp:label id="lblsel" runat="server" CssClass="standard-text">Selección de <br> Materiales:</asp:label></TD>
													<TD align="left" colSpan="2"><asp:radiobuttonlist id="rdoseleccion" runat="server" CssClass="standard-text" AutoPostBack="True" RepeatDirection="Horizontal"
															Width="568px">
															<asp:ListItem Value="1">Por Material</asp:ListItem>
															<asp:ListItem Value="2">Por Familia</asp:ListItem>
															<asp:ListItem Value="3">Por Color</asp:ListItem>
															<asp:ListItem Value="4">Por Tama&#241;o</asp:ListItem>
															<asp:ListItem Value="5">Por Espesor</asp:ListItem>
														</asp:radiobuttonlist><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="standard-text" ErrorMessage="Seleccione el tipo de busqueda del material"
															ControlToValidate="rdoseleccion"></asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD align="right"><asp:label id="lblMaterial" runat="server" CssClass="standard-text" Visible="False">Material:</asp:label></TD>
													<TD><asp:textbox id="txtCodigoSAP" tabIndex="1" runat="server" CssClass="standard-text" Width="131px"
															AutoPostBack="True" Visible="False" MaxLength="18"></asp:textbox><asp:button id="btnBuscar" tabIndex="2" runat="server" CssClass="botonesInput" Visible="False"
															Text="Buscar"></asp:button><asp:imagebutton id="cmdFindMaterialN" runat="server" CausesValidation="False" Visible="False" ToolTip="Busqueda Avanzada"
															ImageUrl="../../Images/Find.gif"></asp:imagebutton><asp:requiredfieldvalidator id="rfvCodigoSap" runat="server" CssClass="standard-text" ErrorMessage="Ingrese el codigo del material"
															ControlToValidate="txtCodigoSAP" Display="Dynamic"></asp:requiredfieldvalidator></TD>
													<TD><asp:textbox id="txtDescripcion" runat="server" CssClass="standard-text" Width="300px" Visible="False"
															BorderStyle="None"></asp:textbox></TD>
												</TR>
												<TR>
													<TD align="right"><asp:label id="lblFamilia" runat="server" CssClass="standard-text" Visible="False">Familia:</asp:label></TD>
													<TD colSpan="2"><asp:dropdownlist id="cbofamilia" tabIndex="5" runat="server" CssClass="standard-text" Width="170px"
															Visible="False"></asp:dropdownlist><asp:comparevalidator id="cvfamilia" runat="server" CssClass="standard-text" ErrorMessage="Seleccione la Familia a exportar"
															ControlToValidate="cbofamilia" ValueToCompare="-1" Operator="NotEqual"></asp:comparevalidator></TD>
												</TR>
												<TR>
													<TD align="right"><asp:label id="lblColor" runat="server" CssClass="standard-text" Visible="False">Color:</asp:label></TD>
													<TD colSpan="2"><asp:dropdownlist id="cbocolor" tabIndex="5" runat="server" CssClass="standard-text" Width="170px"
															Visible="False"></asp:dropdownlist><asp:comparevalidator id="cvcolor" runat="server" CssClass="standard-text" ErrorMessage="Seleccione el color a exportar"
															ControlToValidate="cbocolor" ValueToCompare="-1" Operator="NotEqual"></asp:comparevalidator></TD>
												</TR>
												<TR>
													<TD align="right"><asp:label id="lblTamanio" runat="server" CssClass="standard-text" Visible="False">Tamaño:</asp:label></TD>
													<TD colSpan="2"><asp:dropdownlist id="cbotamanio" tabIndex="5" runat="server" CssClass="standard-text" Width="170px"
															Visible="False"></asp:dropdownlist><asp:comparevalidator id="cvtamanio" runat="server" CssClass="standard-text" ErrorMessage="Seleccione el tamaño a exportar"
															ControlToValidate="cbotamanio" ValueToCompare="-1" Operator="NotEqual"></asp:comparevalidator></TD>
												</TR>
												<TR>
													<TD align="right"><asp:label id="lblEspesor" runat="server" CssClass="standard-text" Visible="False">Espesor:</asp:label></TD>
													<TD colSpan="2"><asp:dropdownlist id="cboespesor" tabIndex="5" runat="server" CssClass="standard-text" Width="170px"
															Visible="False"></asp:dropdownlist><asp:comparevalidator id="cvespesor" runat="server" CssClass="standard-text" ErrorMessage="Seleccione el espesor a exportar"
															ControlToValidate="cboespesor" ValueToCompare="-1" Operator="NotEqual"></asp:comparevalidator></TD>
												</TR>
											</TABLE>
									<TR vAlign="top">
										<TD align="center" colSpan="3"><asp:button id="cmdAdd" tabIndex="2" runat="server" CssClass="botonesInput" Visible="False"
												Text="Agregar"></asp:button><asp:button id="btnCancelar" tabIndex="3" runat="server" CssClass="botonesInput" CausesValidation="False"
												Visible="False" Text="Cancelar"></asp:button><asp:textbox id="txtHidden" runat="server" Width="0px"></asp:textbox></TD>
									</TR>
									<TR>
										<td align="right" colSpan="3"><asp:button id="btnclean" tabIndex="3" runat="server" CssClass="botonesInput" CausesValidation="False"
												Width="130px" Text="Reiniciar Exportación"></asp:button></td>
									</TR>
									<TR vAlign="top">
										<td align="center" colSpan="3"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
									</TR>
								</TABLE>
							</div>
						</td>
						<TD>&nbsp;</TD>
					</tr>
					<TR>
						<TD></TD>
						<TD>
							<TABLE class="tan-border" id="tableMaterials" cellSpacing="12" cellPadding="0" width="700"
								border="0" runat="server" visible="False">
								<TR vAlign="top">
									<TD align="center" colSpan="4"><asp:button id="btnActualizar" accessKey="A" tabIndex="4" runat="server" CssClass="botonesInput"
											CausesValidation="False" Width="120px" Text="Exportación Previa" ToolTip="Press Alt+A to get Focus"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4" height="19"><asp:button id="btnInterface" accessKey="E" tabIndex="6" runat="server" CssClass="botonesInput"
											Width="91px" Visible="False" Text="Interface Excel"></asp:button><asp:button id="btnCSV" accessKey="C" tabIndex="7" runat="server" CssClass="botonesInput" CausesValidation="False"
											Width="120px" Text="Interface ERP"></asp:button></TD>
								</TR>
								<TR>
									<TD class="Normal" align="left" colSpan="4">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE>
												<TR>
													<TD><asp:image id="Image2" runat="server" ImageUrl="../../images/waitImage.gif"></asp:image></TD>
													<TD><asp:label id="Label2" runat="server" CssClass="standard-text"> Este proceso puede demorar varios segundos, debido a que en este momento estamos calculando la lista de cada uno de los materiales seleccionados.</asp:label></TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
								<TR vAlign="top">
									<TD colSpan="4" height="28"><asp:datagrid id="dgdMaterial" Width="500px" BorderStyle="None" BorderColor="White" AllowSorting="True"
											FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" Runat="server">
											<Columns>
												<asp:TemplateColumn HeaderText="CodigoSAP">
													<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblCodigoSAP Width="60px" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Descripcion">
													<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="250px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblDesc Width="250px" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Estado Material">
													<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblEstadoMaterialDesc Width="100px" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.EstadoMaterialDesc") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Estado Producto">
													<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblEstadoProductoDesc Width="100px" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.EstadoProductoDesc") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Linea Base">
													<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id=lblLineaDesc CssClass="standard-text" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.LineaDesc") %>' Runat="server">
														</asp:label>
														<asp:label id=lblLineaN CssClass="standard-text" Width="70px" Visible="False" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdLineaBase") %>' Runat="server">
														</asp:label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Planta">
													<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id="lblidPlanta" Width="70px" CssClass="standard-text" Text='&nbsp;<%# GetplantName(System.Convert.ToInt32(DataBinder.Eval(Container, "DataItem.IdPlanta"))) %>' Runat="server">
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
									<TD colSpan="4" height="28">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="675" border="0">
											<TR>
												<TD><SPAN class="titulo"><SPAN class="letraAzulBold"><SPAN class="titulo"><FONT color="#000000"><SPAN class="letraAzulBold"><asp:label id="lblresultexp" runat="server" Visible="False">Resultado de la exportación previa</asp:label>
																	</SPAN></FONT></SPAN>
														</SPAN>
													</SPAN></TD>
											</TR>
											<TR>
												<TD><asp:datagrid id="dgdResults" runat="server" CssClass="standard-text" Width="675px" BorderStyle="None"
														BorderColor="#CC9966" CellPadding="4" ShowHeader="False" ForeColor="Aqua" BorderWidth="1px"
														BackColor="White">
														<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
														<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
														<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="DarkOrange"></HeaderStyle>
														<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
										</TABLE>
									</TD>
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
