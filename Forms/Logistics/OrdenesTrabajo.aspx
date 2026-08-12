<%@ Page language="c#" Codebehind="OrdenesTrabajo.aspx.cs" Inherits="UserInterface.Forms.Logistics.OrdenesTrabajo" AutoEventWireup="false" %>

<%@ Register TagPrefix="uc1" TagName="ConsultProgramGrid" Src="../../Controls/ConsultProgramGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Generar Ordenes Trabajo</title>
		<script language="javascript">
function showWaitControls()
{
	// waitControls.style.display='';
}			

function ShowTitle()
{
	window.frames["top"].document.title = "SICAL  - Logística - Generar Ordenes de Trabajo";
}
		</script>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="ShowTitle();" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<form id="PdtLogForm" method="post" runat="server">
			<table align="center" width="700" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="left" colSpan="5" bgColor="#003366">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="5"><br>
							<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True"> Generar Ordenes de Trabajo</asp:label>
							<hr>
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Seleccione las secuencias para las que desea generar todas las órdenes de trabajo. <br> Recuerde que no se volverán a generar aquellas secuencias que ya tengan sus órdenes de trabajo.</asp:Label>
						</td>
					</tr>
					<tr>
						<td class="contenido" vAlign="top">
							<TABLE align="center">
								<TBODY>
									<TR>
										<TD colspan="3">
											<uc1:ConsultProgramGrid id="ConsultPrgGridControl" runat="server"></uc1:ConsultProgramGrid></TD>
									<TR>
										<TD align="right" colspan="4">
											<DIV id="waitControls" style="DISPLAY: none">
												<TABLE>
													<TR>
														<TD align="center">
															<asp:image id="Image2" runat="server" ImageUrl="../../images/waitImage.gif"></asp:image></TD>
													</TR>
													<TR>
														<TD align="center">
															<asp:label id="Label4" runat="server" CssClass="standard-text"> Este proceso puede demorar varios segundos, debido a que en este momento estamos generando,<br>para cada área, una orden de trabajo de su Programa de Producción.<br>Agradecemos su paciencia.</asp:label></TD>
													</TR>
												</TABLE>
											</DIV>
										</TD>
									</TR>
									<TR>
										<TD align="right">
											<asp:Button id="cmdCreateWO" runat="server" Text="Generar Ordenes de Trabajo" CssClass="botonesInput" Width="165px"></asp:Button></TD>
										<TD align="right">
											<asp:Label id="Label2" runat="server" Width="10px" CssClass="standard-text"></asp:Label></TD>
										<TD align="left">
											<asp:Button id="cmdExit" runat="server" Text="Regresar" CssClass="botonesInput" Width="64px"></asp:Button></TD>
									</TR>
									<TR>
										<TD class="Normal" align="center" colSpan="4">
											<!--<DIV id="waitControls" style="DISPLAY: none">-->
											</DIV>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
