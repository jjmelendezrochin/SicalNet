<%@ Page language="c#" Codebehind="ConsultMessage.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultMessage" %>
<%@ Register TagPrefix="uc1" TagName="ConsultProgramGrid" Src="../../Controls/ConsultProgramGrid.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Bitácora de piso</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
		ms_positioning="GridLayout">
		<TABLE height="6" cellSpacing="0" cellPadding="0" width="9" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD height="6" width="1"></TD>
				<TD width="8">
					<TABLE align="center" height="5" width="7">
						<TR vAlign="top">
							<TD>
								<form id="PdtLogForm" method="post" runat="server">
									<table align="center" height="287" width="484">
										<tr>
											<td colspan="4" align="center"><asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Bitácora de Piso</asp:Label><hr>
											</td>
										</tr>
										<TR vAlign="top">
											<TD>
												<asp:Label id="lblSecuencia" runat="server" Width="70px" Height="16px" Font-Bold="True">Secuencia:</asp:Label></TD>
											<TD>
												<asp:Label id="lblSecuecniaNo" runat="server" Width="200px" Height="17px"></asp:Label></TD>
											<TD>
												<asp:Label id="Label2" runat="server" Font-Bold="True" Height="16px" Width="50px">Fecha</asp:Label></TD>
											<TD>
												<asp:Label id="lblFecha" runat="server" Height="17px" Width="100px">Label</asp:Label></TD>
										</TR>
										<TR>
											<TD height="28">
												<asp:Label id="Label3" runat="server" Font-Bold="True" Height="16px" Width="70px">Descripción:</asp:Label></TD>
											<TD>
												<asp:Label id="lblDescripcion" runat="server" Height="17px" Width="200px"></asp:Label></TD>
											<TD>
												<asp:Label id="Label4" runat="server" Font-Bold="True" Height="16px" Width="50px">Láminas:</asp:Label></TD>
											<TD>
												<asp:Label id="lblLaminas" runat="server" Height="17px" Width="100px"></asp:Label></TD>
										</TR>
										<TR>
											<TD height="28" colSpan="4">
												<HR>
											</TD>
										</TR>
										<TR vAlign="top">
											<TD height="20">
												<asp:Label id="lblBitaCora" runat="server" Width="70px" Height="9px" Font-Bold="True">Mensajes Anteriores:</asp:Label></TD>
											<TD colspan="3">
												<asp:TextBox id="txtOldMessages" runat="server" Height="69px" Width="430px" TextMode="MultiLine"
													BorderStyle="Groove" CssClass="standard-text" ReadOnly="True"></asp:TextBox></TD>
										</TR>
										<TR vAlign="top">
											<TD height="77">
												<asp:Label id="Label1" runat="server" Font-Bold="True" Height="9px" Width="70px">Nuevo Mensaje:</asp:Label></TD>
											<TD colspan="3">
												<asp:TextBox id="txtNewMessage" runat="server" Width="430px" TextMode="MultiLine" Height="69px"
													BorderStyle="Groove" CssClass="standard-text" MaxLength="200"></asp:TextBox></TD>
										</TR>
										<TR vAlign="top">
											<TD></TD>
											<TD align="right"></TD>
											<TD align="right">
												<asp:Button id="btnAgregar" runat="server" Text="Agregar" Width="89px" Height="23px" CssClass="botonesInput"></asp:Button></TD>
											<TD align="left">
												<asp:Button id="Cancelar" runat="server" Text="Regresar" Width="83px" Height="22px" CssClass="botonesInput"></asp:Button></TD>
										</TR>
										&nbsp;</table>
								</form>
							</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
