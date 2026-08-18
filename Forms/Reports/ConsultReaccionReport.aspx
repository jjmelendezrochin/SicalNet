<%@ Page language="c#" Codebehind="ConsultReaccionReport.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ConsultReaccionReport" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultReaccionReport</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultReaccionReport" method="post" runat="server">
			<CR:CRYSTALREPORTVIEWER id="CRViewer" style="Z-INDEX: 101; LEFT: 128px; POSITION: absolute; TOP: 270px"
				runat="server" DisplayGroupTree="False" Height="50px" Width="350px"></CR:CRYSTALREPORTVIEWER>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 115; LEFT: 536px; POSITION: absolute; TOP: 152px"
				runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta" ControlToValidate="txtFechaFinal"
				ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="revInitial" style="Z-INDEX: 114; LEFT: 536px; POSITION: absolute; TOP: 88px"
				runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta" ControlToValidate="txtFechaInicial"
				ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"></asp:RegularExpressionValidator>
			<asp:label id="lblErrMsg" style="Z-INDEX: 113; LEFT: 43px; POSITION: absolute; TOP: 235px"
				runat="server" Height="20px" Width="658px" ForeColor="Red" CssClass="standard-text"></asp:label>
			<asp:label id="lblTitle" style="Z-INDEX: 112; LEFT: 207px; POSITION: absolute; TOP: 14px" runat="server"
				Height="19px" Width="317px" Font-Size="Larger" CssClass="standard-text" Font-Bold="True"
				Font-Names="Arial Narrow"> Reporte Fase de Reaccion</asp:label>
			<asp:label id="lblLinea" style="Z-INDEX: 111; LEFT: 193px; POSITION: absolute; TOP: 65px" runat="server"
				Height="22px" Width="40px" CssClass="standard-text">Linea</asp:label>
			<asp:dropdownlist id="cboLinea" style="Z-INDEX: 102; LEFT: 189px; POSITION: absolute; TOP: 95px" runat="server"
				Width="125px" CssClass="standard-text"></asp:dropdownlist>
			<asp:label id="lblFechaInicial" style="Z-INDEX: 103; LEFT: 375px; POSITION: absolute; TOP: 63px"
				runat="server" Height="22px" Width="154px" CssClass="standard-text">Fecha Programa Inicial</asp:label>
			<asp:textbox id="txtFechaInicial" style="Z-INDEX: 104; LEFT: 375px; POSITION: absolute; TOP: 84px"
				runat="server" Width="121px" CssClass="standard-text" ReadOnly="True" BorderStyle="Groove"
				MaxLength="11"></asp:textbox>
			<asp:imagebutton OnClientClick="return GetDate('txtFechaInicial');" id="imgFInicial" style="Z-INDEX: 105; LEFT: 495px; POSITION: absolute; TOP: 83px"
				runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton>
			<asp:textbox id="txtFechaFinal" style="Z-INDEX: 107; LEFT: 375px; POSITION: absolute; TOP: 151px"
				runat="server" Width="119px" CssClass="standard-text" ReadOnly="True" BorderStyle="Groove"
				MaxLength="11"></asp:textbox>
			<asp:label id="lblFechaFinal" style="Z-INDEX: 106; LEFT: 375px; POSITION: absolute; TOP: 127px"
				runat="server" Height="22px" Width="142px" CssClass="standard-text"> Fecha Programa Final</asp:label>
			<asp:imagebutton OnClientClick="return GetDate('txtFechaFinal');" id="imgFFinal" style="Z-INDEX: 108; LEFT: 493px; POSITION: absolute; TOP: 149px"
				runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton>
			<asp:button id="cmdprint" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 200px"
				CssClass="botonesInput" Text="Imprimir" Runat="server"></asp:button>
			<asp:button id="btnCancelar" style="Z-INDEX: 110; LEFT: 360px; POSITION: absolute; TOP: 200px"
				runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button>
		</form>
	</body>
</HTML>
