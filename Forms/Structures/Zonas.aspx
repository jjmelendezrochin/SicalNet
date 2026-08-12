<%@ Page language="c#" Codebehind="Zonas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Zonas" %>
<%@ Register TagPrefix="uc1" TagName="Zonas" Src="../../Controls/Zonas.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>

		</script>
		<script language="JavaScript">
			function ConfirmOperation(Button)
			{
				/*if (confirm("Esta seguro que desea insertar esta cuba?")) 
				{
					Button.click();
				}*/
			}
		
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Catálogos - Catálogo de ollas"
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
	<body onkeydown="return (event.keyCode!=13)" onload="ShowTitle()" leftMargin="0" topMargin="0"
		bgColor="#ffffff" text="#000000" marginheight="0" marginwidth="0">
		<form id="OllasForm" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="846" height="443">
					<TBODY>
						<tr>
							<td class="contenido" colSpan="3">
								<div id="sicalMenu"></div>
							</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700"><IMG src="imagenes/ico-bullet.gif" width="7" height="7">&nbsp;
								<span class="titulo">
									<SPAN class="letraAzulBold">Catálogo de Cubas en Area de Post Curado</SPAN>
								</span></td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td width="20">&nbsp;</td>
							<td width="700">&nbsp;</td>
							<td width="20">&nbsp;</td>
						</tr>
						<tr>
							<td height="326" width="20">&nbsp;</td>
							<td height="326" width="700">
								<table border="0" cellSpacing="0" cellPadding="0" width="700">
									<TBODY>
										<tr>
											<td height="12" width="213">&nbsp;</td>
											<TD height="12" width="10"></TD>
											<td height="12"><span class="letraAzulBold"></span></td>
										</tr>
										<tr>
											<td class="contenido" vAlign="top" width="213">
												<TABLE style="Z-INDEX: 0" id="Table1" class="tan-border" border="0" cellSpacing="6" cellPadding="0"
													width="211" height="102">
													<TR>
														<TD class="letraAzulBold" height="1" colSpan="2">Agregar una cuba en fase Post 
															Curado</TD>
													</TR>
													<TR>
														<TD height="7" width="47"><asp:label id="Label4" runat="server" CssClass="standard-text">Línea</asp:label></TD>
														<td height="7"><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" AutoPostBack="True" Width="101px"></asp:dropdownlist></td>
													</TR>
													<TR>
														<TD height="5" width="47"><asp:label id="Label2" runat="server" CssClass="standard-text">Denominación</asp:label></TD>
														<td height="5"><asp:textbox style="Z-INDEX: 0" id="txtDenominacion" runat="server" CssClass="standard-text"
																Width="90px" MaxLength="100"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="El campo denominaci�n es un campo requerido"
																ControlToValidate="txtDenominacion">*</asp:requiredfieldvalidator></td>
													</TR>
													<TR>
														<td align="center"><asp:button id="cmdFProducto" runat="server" CssClass="botonesInput" Width="64px" Text="Agregar"></asp:button></td>
														<TD lign="center"><asp:button id="cmdCancelC" runat="server" CssClass="botonesInput" Width="64px" Text="Cancelar"
																CausesValidation="False"></asp:button></TD>
													</TR>
												</TABLE>
												<asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
											<TD class="contenido" vAlign="top" width="10"></TD>
											<td class="contenido" vAlign="top">
												<P class="contenido" align="left"></P>
												<P class="contenido" align="left">
													<TABLE id="Table3" class="tan-border" border="0" cellSpacing="12" cellPadding="0" width="171"
														height="99">
														<TBODY>
															<TR vAlign="top">
																<TD>
																	<uc1:Zonas id="Zonas1" runat="server"></uc1:Zonas></TD>
															</TR>
														</TBODY></TABLE>
												</P>
											</td>
										</tr>
										<tr>
											<TD colSpan="3"></TD>
										</tr>
										<tr colspan="3">
											<td width="213"></td>
										</tr>
									</TBODY></table>
							</td>
							<td height="5" width="20">&nbsp;</td>
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
		</TD></TR></TBODY>
		<P></P>
		</TR></TBODY></TABLE>
		<P></P>
		</TD></TR></TBODY>
		<DIV></DIV>
		</FORM></TABLE></TD></TR></TBODY>
		<DIV></DIV>
		<DIV></DIV>
		<DIV></DIV>
	</body>
</HTML>
