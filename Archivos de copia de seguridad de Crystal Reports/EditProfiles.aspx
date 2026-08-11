<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="EditProfiles.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Administration.EditProfiles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function CheckUnCheckAll(CtrlName)
{
	alert (CtrlName);
	alert (CtrlName.indexOf('checkAll'));   
}
//-->
		</script>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="ConsultColorWO" method="post" runat="server">
			<table width="800" align="center" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="center" colSpan="4" height="80"><br>
							<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Catálogo de Perfiles</asp:label>
							<hr>
						</td>
					</tr>
					<TR>
						<TD height="20" colspan="4">
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Para agregar un prefil presione el botón NUEVO, para modificar uno perfil, seleccione el perfil deseado.</asp:Label></TD>
					</TR>
					<TR>
						<TD height="16">
							<asp:Label id="Label2" runat="server" CssClass="standard-text">Nombre:</asp:Label></TD>
						<TD width="49" height="16">
							<asp:TextBox id="txtProfileName" runat="server" CssClass="standard-text" BorderStyle="Groove"
								Width="400px"></asp:TextBox></TD>
						<TD height="16">
							<P align="center"><asp:Button id="btnSalvar" runat="server" CssClass="botonesInput" Text="Salvar"></asp:Button></P>
						</TD>
						<TD height="16">
							<P align="center">
								<asp:Button id="btnCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:Button></P>
						</TD>
					</TR>
					<tr>
						<td colSpan="2" width="265" height="20">
							<asp:Label id="txtProfileId" runat="server" CssClass="standard-text" Visible="False"></asp:Label></td>
						<td colSpan="2" height="20"></td>
					</tr>
					<tr>
						<td colSpan="4" width="20%"><hr>
						</td>
					</tr>
					<TR>
						<TD width="20%" colSpan="4">
							<TABLE style="BORDER-COLLAPSE: collapse" align="center">
								<TR>
									<TD align="center" height="102">
										<asp:datalist id="lstAdminModules" runat="server" CssClass="grid-item" RepeatColumns="4" RepeatDirection="Horizontal">
											<HeaderTemplate>
												<TABLE>
													<TR>
														<TD>
															<asp:CheckBox id="checkAll" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
														<TD><B class="standard-text" style="COLOR: white">Módulo de Administración</B></TD>
													</TR>
												</TABLE>
											</HeaderTemplate>
											<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
											<ItemTemplate>
												<TABLE>
													<TR>
														<TD align="center">
															<asp:CheckBox id="chkSelect" CssClass="standard-text" Width="30px" Runat="server"></asp:CheckBox></TD>
														<TD>
															<asp:Label id=lblModulo CssClass="standard-text" Width="140px" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
															</asp:Label>
															<asp:Label id=lblIdModulo CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdModulo") %>' Visible="False" Runat="server">
															</asp:Label></TD>
													</TR>
												</TABLE>
											</ItemTemplate>
											<HeaderStyle CssClass="grid-header"></HeaderStyle>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Label id="Label3" runat="server" CssClass="standard-text" Width="50px" Visible="False"
											Height="15px"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:datalist id="lstLogisticsModules" runat="server" CssClass="grid-item" RepeatColumns="4" RepeatDirection="Horizontal">
											<HeaderTemplate>
												<TABLE>
													<TR>
														<TD>
															<asp:CheckBox id="Checkbox4" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
														<TD><B class="standard-text" style="COLOR: white">Módulo de Logística</B></TD>
													</TR>
												</TABLE>
											</HeaderTemplate>
											<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
											<ItemTemplate>
												<TABLE>
													<TR>
														<TD align="middle">
															<asp:CheckBox id="chkSelect" CssClass="standard-text" Width="30px" Runat="server"></asp:CheckBox></TD>
														<TD>
															<asp:Label id=lblModulo CssClass="standard-text" Width="140px" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
															</asp:Label>
															<asp:Label id=lblIdModulo CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdModulo") %>' Visible="False" Runat="server">
															</asp:Label></TD>
													</TR>
												</TABLE>
											</ItemTemplate>
											<HeaderStyle CssClass="grid-header"></HeaderStyle>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Label id="Label5" runat="server" CssClass="standard-text" Width="50px" Visible="False"
											Height="15px"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:datalist id="lstStructModules" runat="server" CssClass="grid-item" RepeatColumns="4" RepeatDirection="Horizontal">
											<HeaderTemplate>
												<TABLE>
													<TR>
														<TD>
															<asp:CheckBox id="Checkbox3" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
														<TD><B class="standard-text" style="COLOR: white">Módulo de Estructuras</B></TD>
													</TR>
												</TABLE>
											</HeaderTemplate>
											<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
											<ItemTemplate>
												<TABLE>
													<TR>
														<TD align="center">
															<asp:CheckBox id="chkSelect" CssClass="standard-text" Width="30px" Runat="server"></asp:CheckBox></TD>
														<TD>
															<asp:Label id=lblModulo CssClass="standard-text" Width="140px" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
															</asp:Label>
															<asp:Label id=lblIdModulo CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdModulo") %>' Visible="False" Runat="server">
															</asp:Label></TD>
													</TR>
													<TR>
														<TD>
														</TD>
														<TD>
															<asp:CheckBox id="CheckReadOnly" Text="Solo Lectura" CssClass="standard-text" Runat="server" Visible='<%# ViewReadOnly(DataBinder.Eval(Container,"DataItem.IdModulo").ToString()) %>'>
															</asp:CheckBox>
														</TD>
													</TR>
												</TABLE>
											</ItemTemplate>
											<HeaderStyle CssClass="grid-header"></HeaderStyle>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Label id="Label6" runat="server" CssClass="standard-text" Width="50px" Visible="False"
											Height="15px"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:datalist id="lstCatalogModules" runat="server" CssClass="grid-item" RepeatColumns="4" RepeatDirection="Horizontal">
											<HeaderTemplate>
												<TABLE>
													<TR>
														<TD>
															<asp:CheckBox id="Checkbox2" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
														<TD><B class="standard-text" style="COLOR: white">Módulo de Catálogos</B></TD>
													</TR>
												</TABLE>
											</HeaderTemplate>
											<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
											<ItemTemplate>
												<TABLE>
													<TR>
														<TD align="middle">
															<asp:CheckBox id="chkSelect" CssClass="standard-text" Width="30px" Runat="server"></asp:CheckBox></TD>
														<TD>
															<asp:Label id=lblModulo CssClass="standard-text" Width="140px" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
															</asp:Label>
															<asp:Label id=lblIdModulo CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdModulo") %>' Runat="server" Visible="False">
															</asp:Label></TD>
													</TR>
												</TABLE>
											</ItemTemplate>
											<HeaderStyle CssClass="grid-header"></HeaderStyle>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Label id="Label4" runat="server" CssClass="standard-text" Width="50px" Visible="False"
											Height="15px"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:datalist id="lstProductionModules" runat="server" CssClass="grid-item" RepeatColumns="4"
											RepeatDirection="Horizontal">
											<HeaderTemplate>
												<TABLE>
													<TR>
														<TD>
															<asp:CheckBox id="Checkbox1" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
														<TD><B class="standard-text" style="COLOR: white">Módulo de Producción</B></TD>
													</TR>
												</TABLE>
											</HeaderTemplate>
											<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
											<ItemTemplate>
												<TABLE>
													<TR>
														<TD align="middle">
															<asp:CheckBox id="chkSelect" CssClass="standard-text" Width="30px" Runat="server"></asp:CheckBox></TD>
														<TD>
															<asp:Label id=lblModulo CssClass="standard-text" Width="140px" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
															</asp:Label>
															<asp:Label id=lblIdModulo CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdModulo") %>' Runat="server" Visible="False">
															</asp:Label></TD>
													</TR>
												</TABLE>
											</ItemTemplate>
											<HeaderStyle CssClass="grid-header"></HeaderStyle>
										</asp:datalist></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Label id="Label7" runat="server" CssClass="standard-text" Width="50px" Visible="False"
											Height="15px"></asp:Label></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:datalist id="lstReportModules" runat="server" CssClass="grid-item" RepeatColumns="4" RepeatDirection="Horizontal">
											<HeaderTemplate>
												<TABLE>
													<TR>
														<TD>
															<asp:CheckBox id="chkAll" CssClass="standard-text" Runat="server"></asp:CheckBox></TD>
														<TD><B class="standard-text" style="COLOR: white">Módulo de Reportes</B></TD>
													</TR>
												</TABLE>
											</HeaderTemplate>
											<ItemStyle Font-Size="2pt" CssClass="grid-first-item"></ItemStyle>
											<ItemTemplate>
												<TABLE>
													<TR>
														<TD align="middle">
															<asp:CheckBox id="chkSelect" CssClass="standard-text" Width="30px" Runat="server"></asp:CheckBox></TD>
														<TD>
															<asp:Label id=lblModulo CssClass="standard-text" Width="140px" Text='<%# DataBinder.Eval(Container,"DataItem.Descripcion")%>' Runat="server">
															</asp:Label>
															<asp:Label id=lblIdModulo CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.IdModulo") %>' Runat="server" Visible="False">
															</asp:Label></TD>
													</TR>
												</TABLE>
											</ItemTemplate>
											<HeaderStyle CssClass="grid-header"></HeaderStyle>
										</asp:datalist></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</table>
			</TD></TR></TABLE>
		</form>
	</body>
</HTML>
