<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page language="c#" Codebehind="VariationofWeight.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.Production.VariationofWeight" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VariationofWeight</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-calendario.js") %>"></script>


		<script language="javascript">		

		</script>
		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body>
		<center>
				<table style="BORDER-COLLAPSE: collapse" width="700" align="center">				
					<tr class="sical-menu-row">
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
				</table>
			<form id="VariationofWeight" method="post" runat="server">
				<br>
				<br>
				<p></p>
				<p></p>
				<p></p>
				<p></p>
				<p></p>
				<table>
					<tr>
						<td width="700" height="300" align="center" valign="top">
							<table style="WIDTH: 603px; HEIGHT: 213px" border="0">
								<tr>
									<td colSpan="4"><asp:label id="lblTitle" CssClass="standard-text" Font-Size="Medium" Runat="server" text="Reporte Variaciones de Pesadas"
											Font-Bold="True">Reporte Variaciones de Peso</asp:label></td>
								</tr>
								<tr>
									<td style="WIDTH: 366px"><asp:label id="lblLinea" CssClass="standard-text" Runat="server" text="Linea de Produccion"> Linea de Produccion</asp:label></td>
									<td style="WIDTH: 369px"><asp:label id="lblSeqInit" CssClass="standard-text" Runat="server" text="Secuencia Inicial"></asp:label></td>
									<td style="WIDTH: 306px"><asp:label id="lblPrgInit" CssClass="standard-text" Runat="server" text="Fecha Programa Inicial"></asp:label></td>
									<td></td>
								</tr>
								<tr>
									<td style="WIDTH: 366px"><asp:dropdownlist id="cboLinea" Width="125px" CssClass="Standard-text" Runat="server"></asp:dropdownlist></td>
									<td style="WIDTH: 369px"><asp:textbox id="txtSecInicial" runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox></td>
									<td style="WIDTH: 306px"><asp:textbox id="txtFechaInicial" Width="125px" CssClass="Standard-text" Runat="server" MaxLength="11"></asp:textbox>
										<asp:imagebutton OnClientClick="return GetDate(document.forms[0].elements['txtFechaInicial'].value,'txtFechaInicial');" id="imgPrgInit" Runat="server" ImageUrl="../../../Images/icon-calendar.gif"
											AlternateText="Inicial Date"></asp:imagebutton></td>
									<td></td>
								</tr>
								<TR>
									<TD style="WIDTH: 366px"></TD>
									<TD style="WIDTH: 369px"></TD>
									<TD style="WIDTH: 306px">
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
											ControlToValidate="txtFechaInicial" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator></TD>
									<TD></TD>
								</TR>
								<tr>
									<td style="WIDTH: 366px"><asp:label id="Label1" CssClass="standard-text" Runat="server" text="Codigo SAP"></asp:label></td>
									<td style="WIDTH: 369px"><asp:label id="SeqFin" CssClass="standard-text" Runat="server" text="Secuencia Final"></asp:label></td>
									<td style="WIDTH: 306px"><asp:label id="lblPrgFin" CssClass="standard-text" Runat="server" text="Fecha Programa Final"></asp:label></td>
									<td></td>
								</tr>
								<tr>
									<td style="WIDTH: 366px"><asp:dropdownlist id="cboCodigo" Width="125px" CssClass="standard-text" Runat="server"></asp:dropdownlist></td>
									<td style="WIDTH: 369px"><asp:textbox id="txtSecFinal" runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox></td>
									<td style="WIDTH: 306px"><asp:textbox id="txtFechaFinal" Width="125px" CssClass="Standard-text" Runat="server" MaxLength="11"></asp:textbox>
										<asp:imagebutton OnClientClick="return GetDate(document.forms[0].elements['txtFechaFinal'].value,'txtFechaFinal');" id="Image2" Runat="server" ImageUrl="../../../Images/icon-calendar.gif"
											AlternateText="Inicial Date"></asp:imagebutton></td>
									<td></td>
								</tr>
								<TR>
									<TD style="WIDTH: 366px"></TD>
									<TD style="WIDTH: 369px"></TD>
									<TD style="WIDTH: 306px">
										<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
											ControlToValidate="txtFechaFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator></TD>
									<TD></TD>
								</TR>
								<tr>
									<td align="center" colSpan="4"><asp:button id="btnOk" CssClass="botonesInput" Runat="server" Text="Imprimir"></asp:button>&nbsp;<asp:button id="btnCancel" CssClass="botonesInput" Runat="server" Text="Cancelar"></asp:button>&nbsp;</td>
								</tr>
								<tr>
									<td align="left" colSpan="4"><asp:label id="lblErrMsg" runat="server" Height="20px" ForeColor="Red" Width="658px" CssClass="standard-text"></asp:label>
									</td>
								</tr>
							</table>
							<asp:dropdownlist id="cboSecInicial" style="Z-INDEX: 101; POSITION: absolute; TOP: 297px; LEFT: 213px"
								runat="server" Width="125px" CssClass="standard-text" Visible="False"></asp:dropdownlist>
						</td>
					</tr>
				</table>
			</form>
		</center>
	</body>
</HTML>
