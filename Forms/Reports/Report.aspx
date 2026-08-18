
<%@ Page language="c#" Codebehind="Report.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.Report" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Report</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->
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
		<script type="text/javascript">document.addEventListener(
				"DOMContentLoaded",
				function () {
					SicalMenu.init("sicalMenu");
				}
			);
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ShowTitle()">
		<center>
			<table style="BORDER-COLLAPSE: collapse" width="700" align="center">
				<TBODY>
					<tr>
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
			</table>
			<form id="Report" method="post" runat="server">
				<asp:button style="Z-INDEX: 131; POSITION: absolute; TOP: 296px; LEFT: 424px" id="cmdReporteInspeccion"
					CssClass="botonesInput" Width="160px" Runat="server" Text="Reporte Pvc Inpección"></asp:button>
				<asp:button style="Z-INDEX: 133; POSITION: absolute; TOP: 296px; LEFT: 760px" id="cmdEtiquetaPvc"
					Text="Etiqueta Pvc" Runat="server" Width="140px" CssClass="botonesInput"></asp:button>
				<asp:button style="Z-INDEX: 132; POSITION: absolute; TOP: 296px; LEFT: 592px" id="cmdReporteCorte"
					Text="Reporte Pvc Corte" Runat="server" Width="140px" CssClass="botonesInput"></asp:button>
				<br>
				<p></p>
				<asp:label style="Z-INDEX: 101; POSITION: absolute; TOP: 80px; LEFT: 528px" id="lblTitle" runat="server"
					Width="317px" Height="19px" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="Larger"
					CssClass="standard-text"> Reporte Fase de</asp:label>
				<asp:datagrid style="Z-INDEX: 130; POSITION: absolute; TOP: 400px; LEFT: 32px" id="DataGrid1"
					runat="server" Width="100%" Height="46px" Font-Names="Verdana" Font-Size="X-Small" BorderWidth="1px"
					BorderColor="#999999" BackColor="White" CellPadding="3" GridLines="Vertical" BorderStyle="None">
					<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
					<ItemStyle BorderWidth="2px" ForeColor="Black" BorderStyle="Solid" BorderColor="Black" BackColor="#EEEEEE"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="2px" ForeColor="White" BorderStyle="Solid"
						BorderColor="Black" BackColor="#000084"></HeaderStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<asp:button style="Z-INDEX: 129; POSITION: absolute; TOP: 256px; LEFT: 520px" id="cmdExportaPvc"
					CssClass="botonesInput" Text="Exportar" Runat="server" Visible="False"></asp:button>
				<asp:ValidationSummary style="Z-INDEX: 128; POSITION: absolute; TOP: 336px; LEFT: 344px" id="vs" runat="server"
					Width="216px" CssClass="standard-text"></asp:ValidationSummary>
				<asp:RegularExpressionValidator style="Z-INDEX: 127; POSITION: absolute; TOP: 216px; LEFT: 984px" id="RegularExpressionValidator3"
					runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
					ControlToValidate="txtLibFinal" ErrorMessage="Fecha incorrecta en liberación final">*</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator style="Z-INDEX: 126; POSITION: absolute; TOP: 144px; LEFT: 984px" id="RegularExpressionValidator2"
					runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
					ControlToValidate="txtLibInicial" ErrorMessage="Fecha incorrecta en liberación inicial">*</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator style="Z-INDEX: 125; POSITION: absolute; TOP: 216px; LEFT: 800px" id="RegularExpressionValidator1"
					runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
					ControlToValidate="txtFechaFinal" ErrorMessage="Fecha incorrecta en programa final">*</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator style="Z-INDEX: 124; POSITION: absolute; TOP: 144px; LEFT: 800px" id="revInitial"
					runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
					ControlToValidate="txtFechaInicial" ErrorMessage="Fecha incorrecta en programa inicial">*</asp:RegularExpressionValidator>
				<asp:textbox style="Z-INDEX: 123; POSITION: absolute; TOP: 216px; LEFT: 504px" id="txtSecFinal"
					runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox>
				<asp:textbox style="Z-INDEX: 122; POSITION: absolute; TOP: 144px; LEFT: 504px" id="txtSecInicial"
					runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox>
				<asp:label style="Z-INDEX: 120; POSITION: absolute; TOP: 128px; LEFT: 504px" id="lblSecInicial"
					runat="server" Width="113px" Height="22px" CssClass="standard-text">Secuencia Inicial</asp:label>
				<TABLE style="Z-INDEX: 119; POSITION: absolute; WIDTH: 181px; HEIGHT: 99px; TOP: 568px; LEFT: 296px"
					id="Table1" border="0" cellSpacing="1" cellPadding="1" width="181">
					<TR>
						<TD style="Z-INDEX: 0; HEIGHT: 19px">
							<asp:dropdownlist id="cboSecInicial" runat="server" Width="125px" CssClass="standard-text" Visible="False"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:dropdownlist id="cboSecFinal" runat="server" Width="908px" CssClass="standard-text" Visible="False"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<asp:label style="Z-INDEX: 103; POSITION: absolute; TOP: 128px; LEFT: 352px" id="lblLinea"
					runat="server" Width="40px" Height="22px" CssClass="standard-text">Linea</asp:label>
				<asp:dropdownlist style="Z-INDEX: 102; POSITION: absolute; TOP: 152px; LEFT: 352px" id="cboLinea"
					runat="server" Width="125px" CssClass="standard-text"></asp:dropdownlist>
				<asp:label style="Z-INDEX: 104; POSITION: absolute; TOP: 128px; LEFT: 656px" id="lblFechaInicial"
					runat="server" Width="154px" Height="22px" CssClass="standard-text">Fecha Programa Inicial</asp:label>
				<asp:textbox style="Z-INDEX: 105; POSITION: absolute; TOP: 144px; LEFT: 656px" id="txtFechaInicial"
					runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox>
				<asp:imagebutton style="Z-INDEX: 106; POSITION: absolute; TOP: 144px; LEFT: 776px" id="imgFInicial"
					OnClientClick="return GetDate('txtFechaInicial');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton>
				<asp:label style="Z-INDEX: 107; POSITION: absolute; TOP: 192px; LEFT: 656px" id="lblFechaFinal"
					runat="server" Width="142px" Height="22px" CssClass="standard-text"> Fecha Programa Final</asp:label>
				<asp:textbox style="Z-INDEX: 108; POSITION: absolute; TOP: 216px; LEFT: 656px" id="txtFechaFinal"
					runat="server" Width="119px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox>
				<asp:imagebutton style="Z-INDEX: 109; POSITION: absolute; TOP: 216px; LEFT: 776px" id="imgFFinal"
					OnClientClick="return GetDate('txtFechaFinal');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton>
				<asp:label style="Z-INDEX: 110; POSITION: absolute; TOP: 128px; LEFT: 840px" id="lblLibInicial"
					runat="server" Width="154px" Height="22px" CssClass="standard-text">Fecha Liberacion Inicial</asp:label>
				<asp:textbox style="Z-INDEX: 111; POSITION: absolute; TOP: 144px; LEFT: 840px" id="txtLibInicial"
					runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox>
				<asp:imagebutton style="Z-INDEX: 112; POSITION: absolute; TOP: 144px; LEFT: 960px" id="imgLInicial"
					OnClientClick="return GetDate('txtLibInicial');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton>
				<asp:label style="Z-INDEX: 113; POSITION: absolute; TOP: 192px; LEFT: 840px" id="lblLibFinal"
					runat="server" Width="154px" Height="22px" CssClass="standard-text">Fecha Liberacion Final</asp:label>
				<asp:textbox style="Z-INDEX: 114; POSITION: absolute; TOP: 216px; LEFT: 840px" id="txtLibFinal"
					runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox>
				<asp:imagebutton style="Z-INDEX: 115; POSITION: absolute; TOP: 216px; LEFT: 960px" id="imgLFinal"
					OnClientClick="return GetDate('txtLibFinal');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton>
				<asp:button style="Z-INDEX: 116; POSITION: absolute; TOP: 256px; LEFT: 616px" id="cmdprint"
					CssClass="botonesInput" Text="Imprimir" Runat="server"></asp:button>
				<asp:label style="Z-INDEX: 117; POSITION: absolute; TOP: 392px; LEFT: 344px" id="lblErrMsg"
					runat="server" Width="658px" Height="20px" CssClass="standard-text" ForeColor="Red"></asp:label>
				<asp:button style="Z-INDEX: 118; POSITION: absolute; TOP: 256px; LEFT: 704px" id="btnCancelar"
					runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button>
				<asp:label style="Z-INDEX: 121; POSITION: absolute; TOP: 192px; LEFT: 504px" id="lblSecFinal"
					runat="server" Width="113px" Height="21px" CssClass="standard-text">Secuencia Final</asp:label>
			</form>
		</center>
	</body>
</HTML>
