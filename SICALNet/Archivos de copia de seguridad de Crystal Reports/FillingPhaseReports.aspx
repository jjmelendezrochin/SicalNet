<%@ Page language="c#" Codebehind="FillingPhaseReports.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.FillingPhaseReports" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FillingPhaseReports</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="AdditivesPhaseReports" method="post" runat="server">
			<asp:button id="cmdprint" style="Z-INDEX: 120; LEFT: 468px; POSITION: absolute; TOP: 233px"
				Runat="server" Text="Imprimir" CssClass="botonesInput"></asp:button>
			<asp:RegularExpressionValidator id="RegularExpressionValidator3" style="Z-INDEX: 135; LEFT: 648px; POSITION: absolute; TOP: 168px"
				runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en liberación final" ControlToValidate="TxtLieracion2"
				ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 134; LEFT: 648px; POSITION: absolute; TOP: 88px"
				runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en liberación inicial" ControlToValidate="TxtLieracion1"
				ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 133; LEFT: 480px; POSITION: absolute; TOP: 168px"
				runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en programa final" ControlToValidate="TxtPrograma2"
				ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="revInitial" style="Z-INDEX: 132; LEFT: 480px; POSITION: absolute; TOP: 88px"
				runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en programa inicial" ControlToValidate="TxtPrograma1"
				ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
			<asp:ValidationSummary id="vs" style="Z-INDEX: 131; LEFT: 24px; POSITION: absolute; TOP: 208px" runat="server"
				Width="216px" CssClass="standard-text"></asp:ValidationSummary>
			<asp:Label id="lblcaption" style="Z-INDEX: 122; LEFT: 194px; POSITION: absolute; TOP: 21px"
				Runat="server" Font-Bold="True" Font-Size="Larger" CssClass="standard-text"> Reporte Fase de Llenado</asp:Label>
			<asp:image OnClientClick="return GetDate('TxtPrograma2');" id="imgProgrammaFinal" style="Z-INDEX: 119; LEFT: 456px; POSITION: absolute; TOP: 170px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:image OnClientClick="return GetDate('TxtLieracion2');" id="imgLieractionFinal" style="Z-INDEX: 118; LEFT: 624px; POSITION: absolute; TOP: 168px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:image OnClientClick="return GetDate('TxtLieracion1');" id="imgLieractionInitial" style="Z-INDEX: 117; LEFT: 624px; POSITION: absolute; TOP: 91px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:image OnClientClick="return GetDate('TxtPrograma1');" id="imgProgrammaInitial" style="Z-INDEX: 116; LEFT: 456px; POSITION: absolute; TOP: 91px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:Label id="LblSequencia2" style="Z-INDEX: 107; LEFT: 178px; POSITION: absolute; TOP: 139px"
				Runat="server" CssClass="standard-text">Secuencia Final</asp:Label>
			<asp:DropDownList id="CboSequencia2" style="Z-INDEX: 103; LEFT: 178px; POSITION: absolute; TOP: 170px"
				runat="server" Height="33px" Width="151px" CssClass="standard-text"></asp:DropDownList>
			<asp:Label id="LblSecquencia1" style="Z-INDEX: 106; LEFT: 178px; POSITION: absolute; TOP: 60px"
				Runat="server" CssClass="standard-text"> Secuencia Inicial </asp:Label>
			<asp:DropDownList id="CboLinea" style="Z-INDEX: 101; LEFT: 10px; POSITION: absolute; TOP: 91px" runat="server"
				Height="33px" Width="151px" CssClass="standard-text"></asp:DropDownList>
			<asp:DropDownList id="CboSequencia1" style="Z-INDEX: 102; LEFT: 178px; POSITION: absolute; TOP: 91px"
				runat="server" Height="33px" Width="151px" CssClass="standard-text"></asp:DropDownList>
			<asp:Label id="lblLinea" style="Z-INDEX: 105; LEFT: 10px; POSITION: absolute; TOP: 60px" Runat="server"
				CssClass="standard-text"> Línea de Producción </asp:Label>
			<asp:label id="lblFechaPrograma2" style="Z-INDEX: 108; LEFT: 350px; POSITION: absolute; TOP: 139px"
				runat="server" Height="22px" Width="140px" CssClass="standard-text">Fecha Programa Final</asp:label>
			<asp:textbox id="TxtPrograma2" style="Z-INDEX: 109; LEFT: 350px; POSITION: absolute; TOP: 170px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:label id="LblFechaPrograma1" style="Z-INDEX: 110; LEFT: 350px; POSITION: absolute; TOP: 60px"
				runat="server" Height="22px" Width="140px" CssClass="standard-text">Fecha Programa Inicial</asp:label>
			<asp:textbox id="TxtPrograma1" style="Z-INDEX: 111; LEFT: 350px; POSITION: absolute; TOP: 91px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:label id="LblLiberacion2" style="Z-INDEX: 112; LEFT: 516px; POSITION: absolute; TOP: 139px"
				runat="server" Height="22px" Width="143px" CssClass="standard-text">Fecha Liberación Final</asp:label>
			<asp:textbox id="TxtLieracion2" style="Z-INDEX: 113; LEFT: 516px; POSITION: absolute; TOP: 170px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:label id="LblLiberacion1" style="Z-INDEX: 114; LEFT: 516px; POSITION: absolute; TOP: 60px"
				runat="server" Height="22px" Width="140px" CssClass="standard-text">Fecha Liberación Inicial</asp:label>
			<asp:textbox id="TxtLieracion1" style="Z-INDEX: 115; LEFT: 516px; POSITION: absolute; TOP: 91px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:button id="cmdCancelar" style="Z-INDEX: 121; LEFT: 546px; POSITION: absolute; TOP: 233px"
				Runat="server" Text="Cancelar" CssClass="botonesInput"></asp:button></FORM>
	</body>
</HTML>
