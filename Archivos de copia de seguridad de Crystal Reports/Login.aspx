<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SICAL - Inicio de Sesión</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="styloDESC.css">
	</HEAD>
	<body class="epi-pageBG" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0"
		marginwidth="0" marginheight="0">
		<form id="WebForm" method="post" runat="server" autocomplete="off">
			<table cellpadding="0" cellspacing="0" width="780" height="100%" align="center">
				<TBODY>
					<tr>
						<td valign="top">
							<table cellpadding="0" cellspacing="0" width="100%" height="100%">
								<TBODY>
									<tr>
										<td height="1">
										</td>
									</tr>
									<tr>
										<td height="1">
										</td>
									</tr>
									<tr>
										<td valign="top" width="100%">
											<div id="logo" style="POSITION: absolute; LEFT: 0px; Z-INDEX: 1; TOP: 0px"><img src="images/login1.jpg" border="0" alt="" width="178" height="116"></div>
											<div id="logo" style="POSITION: absolute; LEFT: 0px; TOP: 0px"><img src="images/loginbg10.jpg" border="0" alt=""></div>
											<div id="main-table" style="POSITION: absolute; LEFT: 50px; Z-INDEX: 100; TOP: 245px">
												<table width="257" height="128" border="0" cellspacing="0" cellpadding="0" background="">
													<tr>
														<td valign="top" width="100%">
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td height="98%">
																		<TABLE id="Table1" cellSpacing="0" cellPadding="3" border="0" align="center" class="backGrisTablaObs">
																			<tr>
																				<td width="10">&nbsp;</td>
																				<TD class="epi-font3" align="center"></TD>
																				<td>&nbsp;</td>
																				<td width="10">&nbsp;</td>
																			</tr>
																			<TR>
																				<td width="10">&nbsp;</td>
																				<TD align="right" class="headTabla">Nombre de usuario:</TD>
																				<TD class="headTabla">
																					<ASP:TEXTBOX id="txtLogin" runat="server" Columns="16" CssClass="letra_negra" MaxLength="20"></ASP:TEXTBOX></TD>
																				<td width="10"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLogin" ErrorMessage="Ingrese Usuario"></asp:RequiredFieldValidator></td>
																			</TR>
																			<TR>
																				<td width="10">&nbsp;</td>
																				<TD align="right" class="headTabla">Contraseña:</TD>
																				<TD class="headTabla">
																					<ASP:TEXTBOX id="txtPassword" runat="server" Columns="16" CssClass="letra_negra" MaxLength="16"
																						TextMode="Password"></ASP:TEXTBOX></TD>
																				<td width="10"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="true" ControlToValidate="txtPassword"
																						ErrorMessage="Ingrese Password"></asp:RequiredFieldValidator></td>
																			</TR>
																			<TR>
																				<td width="10">&nbsp;</td>
																				<TD align="right" class="headTabla">Versión:</TD>
																				<TD class="headTabla">
																					<ASP:TEXTBOX id="txtVersion" runat="server" Columns="16" CssClass="letra_negra" MaxLength="16"
																						Enabled="False"></ASP:TEXTBOX></TD>
																				<td width="10"></td>
																			</TR>
																			<TR>
																				<td width="10">&nbsp;</td>
																				<TD colspan="2" align="center" class="headTabla">
																					<ASP:BUTTON id="cmdSignIn" runat="server" CssClass="botonesInput" Width="80px" Text="Abrir Sesión" OnClick="cmdSignIn_Click1"></ASP:BUTTON></TD>
																				<td width="10">&nbsp;</td>
																			</TR>
																			<tr>
																				<td width="10">&nbsp;</td>
																				<TD>&nbsp;</TD>
																				<td>&nbsp;</td>
																				<td width="10">&nbsp;</td>
																			</tr>
																		</TABLE>
																		<P>&nbsp;</P>
																		<P align="center">
																			<ASP:LABEL id="lblErrorMessage" runat="server" CssClass="standard-text" Visible="False" Font-Bold="True"
																				ForeColor="Black" BackColor="Transparent">err</ASP:LABEL></P>
																		<P align="center" class="letra_negra">&nbsp;</P>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
		</form>
		</DIV>
		<div id="banners" style="POSITION: absolute; LEFT: 644px; Z-INDEX: 100; TOP: 260px">
			<table border="0" bgcolor="#f0f0ee" cellpadding="2" cellspacing="2">
				<tr>
					<td>
						<table cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<table width="314" height="10" border="0" align="center" cellpadding="0" cellspacing="0"
										bgcolor="#f0f0ee">
										<tr>
											<td valign="middle" rowspan="2"><div align="center"><img src="images/spacer.jpg" width="5" height="1"></div>
											</td>
											<td valign="middle" rowspan="2"><img border="0" src="images/img80x80_03.gif" width="80" height="80"></td>
											<td valign="middle" rowspan="2"><img src="images/spacer.gif" width="5" height="1"></td>
											<td><p class="letraAzulInteriorPortlet" align="center"><b><font color="#527594">SICAL.Net</font></b></p>
											</td>
										</tr>
										<tr>
											<td valign="middle" class="letraAzulInteriorPortlet" bgcolor="#f0f0ee"><p align="justify"><font color="black">
														Por favor ingrese su nombre de usuario y password... GRACIAS.</font></p>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<table width="314" height="10" border="0" align="center" cellpadding="0" cellspacing="0"
										bgcolor="#f0f0ee">
										<tr>
											<td valign="middle" rowspan="2"></td>
											<td valign="middle" rowspan="2"></td>
											<td valign="middle" rowspan="2"></td>
											<td valign="middle" bgcolor="#f0f0ee"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellpadding="0" cellspacing="0">
										<tr>
											<td>
												<table width="314" height="10" border="0" align="center" cellpadding="0" cellspacing="0"
													bgcolor="#f0f0ee">
													<tr>
														<td valign="middle" rowspan="2"></td>
														<td valign="middle" rowspan="2"></td>
														<td valign="middle" rowspan="2"></td>
														<td><p class="TituloPopup" align="center"><b></p>
															</B>
														</td>
													</tr>
													<tr>
														<td valign="middle" bgcolor="#f0f0ee"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<DIV></DIV>
					</td>
				</tr>
			</table>
		</div>
		</TD></TR>
		<tr>
			<td valign="bottom" height="1">
			</td>
		</tr>
		</TBODY></TABLE></TD></TR></TBODY></TABLE>
	</body>
</HTML>
