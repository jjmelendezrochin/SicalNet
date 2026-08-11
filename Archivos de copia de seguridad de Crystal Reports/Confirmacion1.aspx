<%@ Register TagPrefix="uc1" TagName="ConsultProgramGrid" Src="../../Controls/ConsultProgramGrid.ascx" %>
<%@ Page language="c#" Codebehind="Confirmacion1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.Confirmacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Confirmación de Ajustes al Programa de Producción</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
	</HEAD>
	<body leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000" marginwidth="0" marginheight="0"
		ms_positioning="GridLayout">
		<TABLE border="0" cellSpacing="0" cellPadding="0" width="630" height="369" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD height="24" width="1">
					<br>
				</TD>
				<TD width="629"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="345"></TD>
				<TD>
					<TABLE border="0" width="628" align="center" height="344">
						<tr>
							<td height="22" width="13"></td>
							<td height="22" vAlign="middle">
								<h3 align="center">Confirmación de Acciones en Programa de Producción</h3>
							</td>
						</tr>
						<TR vAlign="top">
							<TD width="13"></TD>
							<td>
								<form id="PdtLogForm" method="post" runat="server">
									<table id="tabla_interior" width="70%" align="center" height="60%">
										<TR>
										</TR>
										<TR vAlign="top">
											<TD width="199"><asp:label id="lblSecuencia" runat="server" Font-Bold="True" Height="16px" Width="136px">Secuencia(s):</asp:label></TD>
											<TD colSpan="3"><asp:label id="lblSecueciaNo" runat="server" Height="17px" Width="200px"></asp:label></TD>
										</TR>
										<TR vAlign="top">
											<TD width="199"><asp:label id="Label2" runat="server" Font-Bold="True" Height="16px" Width="136px">Fecha:</asp:label></TD>
											<TD colSpan="3"><asp:label id="lblFecha" runat="server" Height="17px" Width="104px"></asp:label></TD>
										</TR>
										<TR vAlign="top">
											<TD width="199"><asp:label id="Label4" runat="server" Font-Bold="True" Height="16px" Width="136px">Linea:</asp:label></TD>
											<TD colSpan="3"><asp:label id="lblLinea" runat="server" Height="17px" Width="112px"></asp:label><asp:label id="lblOperacion" runat="server" Height="17px" Width="104px" Visible="False"></asp:label></TD>
										</TR>
										<TR vAlign="top">
											<TD width="199"><asp:label id="Label5" runat="server" Font-Bold="True" Height="16px" Width="136px">Operación:</asp:label></TD>
											<TD colSpan="3"><asp:label id="lblMensajeOperacion" runat="server" Height="17px" Width="296px"></asp:label></TD>
										</TR>
										<TR vAlign="top">
											<TD width="199"><asp:label id="Label6" runat="server" Font-Bold="True" Height="16px" Width="136px">Valores:</asp:label></TD>
											<TD colSpan="3"><asp:label id="lblValores" runat="server" Height="17px" Width="296px"></asp:label></TD>
										</TR>
										<TR>
											<TD height="28" colSpan="4">
												<HR>
												&nbsp;
											</TD>
										</TR>
										<TR vAlign="top">
											<TD height="34" width="199"><asp:label id="Label3" runat="server" Font-Bold="True" Height="9px" Width="136px">Catálogo de Motivo</asp:label>
												<asp:comparevalidator id="Comparevalidator1" runat="server" Font-Bold="True" CssClass="standard-text"
													ValueToCompare="0" Operator="NotEqual" ErrorMessage="* Dato Requerido" ControlToValidate="cboMotivo"></asp:comparevalidator></TD>
											<TD height="34" colSpan="3"><asp:dropdownlist id="cboMotivo" tabIndex="5" runat="server" Width="288px" CssClass="standard-text"></asp:dropdownlist></TD>
										</TR>
										<TR vAlign="top">
											<TD height="20" width="199"><asp:label id="lblBitaCora" runat="server" Font-Bold="True" Height="9px" Width="128px">Nombre Completo</asp:label><asp:label id="lblRequiereNombre" runat="server" Font-Bold="True" Height="9px" Width="128px"
													Visible="False" ForeColor="Red" CssClass="standard-text">* Dato Requerido</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txtOldMessages" runat="server" Height="30px" Width="296px" CssClass="standard-text"
													TextMode="MultiLine" BorderStyle="Groove"></asp:textbox></TD>
										</TR>
										<TR vAlign="top">
											<TD height="28" width="199"><asp:label id="Label1" runat="server" Font-Bold="True" Height="9px" Width="161px">Comentario del Ajuste</asp:label><asp:label id="lblRequiereMotivo" runat="server" Font-Bold="True" Height="9px" Width="128px"
													Visible="False" ForeColor="Red" CssClass="standard-text">* Dato Requerido</asp:label></TD>
											<TD height="28" colSpan="3"><asp:textbox id="txtNewMessage" runat="server" Height="69px" Width="296px" CssClass="standard-text"
													TextMode="MultiLine" BorderStyle="Groove" MaxLength="200"></asp:textbox></TD>
										</TR>
										<TR vAlign="top">
											<TD width="199" height="25"></TD>
											<TD width="239" align="right" height="25"></TD>
											<TD align="right" height="25"><asp:button id="btnAgregar" runat="server" Height="23px" Width="89px" CssClass="botonesInput"
													Text="Aceptar"></asp:button></TD>
											<TD align="left" height="25"><asp:button id="Cancelar" runat="server" Height="22px" Width="83px" CssClass="botonesInput"
													Text="Regresar"></asp:button></TD>
										</TR>
										<tr>
											<td colSpan="4"><asp:label id="lblmsg" runat="server" Font-Bold="True" Height="9px" Width="608px" Visible="False"
													ForeColor="Red" CssClass="standard-text"></asp:label></td>
										</tr>
									</table>
								</form>
							</td>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
