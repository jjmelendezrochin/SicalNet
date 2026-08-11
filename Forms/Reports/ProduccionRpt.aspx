<%@ Page language="c#" Codebehind="ProduccionRpt.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ProduccionRpt1" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProduccionRpt</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">	
		function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=270,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=yes,resizable=no");
			} 
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Reportes"
			}			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ShowTitle()">
		<form id="ProduccionRpt" method="post" runat="server">
			<br>
			<br>
			<br>
			<p></p>
			<p></p>
			<p></p>
			<table width="860" align="center">
				<tr>
					<td colspan="6" align="center">
						<asp:Label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Reporte de Producción</asp:Label><hr>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label1" runat="server" CssClass="standard-text">Defecto:</asp:Label>
						<asp:DropDownList id="cmbDefecto" runat="server" Width="124px" CssClass="standard-text" Height="26px"></asp:DropDownList>
					</td>
					<td>
						<asp:Label id="Label2" runat="server" CssClass="standard-text">Linea de Produccion:</asp:Label>
						<asp:DropDownList id="cmbLinea" runat="server" Width="125px" CssClass="standard-text" AutoPostBack="true"></asp:DropDownList>
					</td>
					<td>
					</td>
					<td>
						<asp:Label id="Label4" runat="server" CssClass="standard-text">Espesor Inicial</asp:Label>
						<asp:DropDownList id="cmbEspInicial" runat="server" Width="96px" CssClass="standard-text"></asp:DropDownList>
					</td>
					<td>
						<asp:Label id="Label5" runat="server" CssClass="standard-text">Fecha programa Inicial</asp:Label>
						<asp:textbox id="txtFechaInicial" runat="server" Width="126px" CssClass="Standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:textbox>
						<asp:imagebutton id="cmdCalInicial" runat="server" ImageUrl="../../Images/icon-calendar.gif" onmouseup="GetDate('txtFechaInicial');"></asp:imagebutton>
					</td>
					<td>
						<asp:Label id="Label6" runat="server" CssClass="standard-text">Fecha Liberación Inicial</asp:Label>
						<asp:textbox id="txtLibInicial" runat="server" Width="128px" CssClass="Standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:textbox>
						<asp:imagebutton id="Imagebutton1" runat="server" ImageUrl="../../Images/icon-calendar.gif" onmouseup="GetDate('txtLibInicial');"></asp:imagebutton>
					</td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD>
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtFechaInicial" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator></TD>
					<TD>
						<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtLibInicial" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator></TD>
				</TR>
				<tr>
					<td>
						<asp:Label id="Label7" runat="server" CssClass="standard-text">Color:</asp:Label>
						<asp:DropDownList id="cmbColor" runat="server" Width="124px" CssClass="standard-text" Height="26px"></asp:DropDownList>
					</td>
					<td>
						<asp:Label id="Label3" runat="server" CssClass="standard-text">Turno:</asp:Label><br>
						<asp:DropDownList id="cmbTurno" runat="server" Width="124px" CssClass="standard-text" Height="26px"></asp:DropDownList>
					</td>
					<td>
					</td>
					<td>
						<asp:Label id="Label10" runat="server" CssClass="standard-text">Espesor Final:</asp:Label>
						<asp:DropDownList id="cmbEspFinal" runat="server" Width="96px" CssClass="standard-text"></asp:DropDownList>
					</td>
					<td>
						<asp:Label id="Label11" runat="server" CssClass="standard-text">Fecha programa Final:</asp:Label>
						<asp:textbox id="txtFechaFinal" runat="server" Width="126px" CssClass="Standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:textbox>
						<asp:imagebutton id="Imagebutton2" runat="server" ImageUrl="../../Images/icon-calendar.gif" onmouseup="GetDate('txtFechaFinal');"></asp:imagebutton>
					</td>
					<td>
						<asp:Label id="Label12" runat="server" CssClass="standard-text">Fecha Liberación Final:</asp:Label>
						<asp:textbox id="txtLibFinal" runat="server" Width="128px" CssClass="Standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:textbox>
						<asp:imagebutton id="Imagebutton3" runat="server" ImageUrl="../../Images/icon-calendar.gif" onmouseup="GetDate('txtLibFinal');"></asp:imagebutton>
					</td>
				</tr>
				<tr>
					<td align="left">
						<asp:Label id="Label13" runat="server" CssClass="standard-text">Medida:</asp:Label>
						<asp:DropDownList id="cmbMedida" runat="server" Width="124px" CssClass="standard-text" Height="26px"></asp:DropDownList>
					</td>
					<td>
						<asp:Label id="Label8" runat="server" CssClass="standard-text">Familia de Producto:</asp:Label>
						<asp:DropDownList id="cmbFamilia" runat="server" Width="125px" CssClass="standard-text"></asp:DropDownList>
					</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;
						<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtFechaFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator></td>
					<td>
						<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtLibFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator>
					</td>
				</tr>
				<tr>
					<td align="center" colspan="6">
						<asp:button id="cmdImprimir" runat="server" Width="62px" Text="Imprimir" CssClass="botonesInput"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="cmdCancelar" runat="server" Width="62px" Text="Cancelar" CssClass="botonesInput"></asp:button>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
