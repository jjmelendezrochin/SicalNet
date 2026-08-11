<%@ Page language="c#" Codebehind="ConsultPostCuradoReport.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ConsultPostCuradoReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultPostCuradoReport</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName+ '&txtDate=' + document.forms[0].elements[CtrlName].value , "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultReport" method="post" runat="server">
			<asp:Label id="lblcaption" Runat="server" style="Z-INDEX: 103; LEFT: 227px; POSITION: absolute; TOP: 13px"
				Font-Bold="True" Font-Size="Larger" CssClass="standard-text"> Reporte de Consumos en Fase de Postcurado </asp:Label>
			<asp:RegularExpressionValidator id="RegularExpressionValidator3" style="Z-INDEX: 135; LEFT: 832px; POSITION: absolute; TOP: 168px"
				runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				ControlToValidate="TxtLiberacion2" ErrorMessage="Fecha incorrecta en liberación final">*</asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 134; LEFT: 832px; POSITION: absolute; TOP: 88px"
				runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				ControlToValidate="TxtLiberacion1" ErrorMessage="Fecha incorrecta en liberación inicial">*</asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 133; LEFT: 664px; POSITION: absolute; TOP: 168px"
				runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				ControlToValidate="TxtFechaPrograma2" ErrorMessage="Fecha incorrecta en programa final">*</asp:RegularExpressionValidator>
			<asp:RegularExpressionValidator id="revInitial" style="Z-INDEX: 132; LEFT: 664px; POSITION: absolute; TOP: 88px"
				runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				ControlToValidate="TxtFechaPrograma1" ErrorMessage="Fecha incorrecta en programa inicial">*</asp:RegularExpressionValidator>
			<asp:ValidationSummary id="vs" style="Z-INDEX: 131; LEFT: 24px; POSITION: absolute; TOP: 224px" runat="server"
				Width="216px" CssClass="standard-text"></asp:ValidationSummary>
			<asp:button id="cmdprint" style="Z-INDEX: 120; LEFT: 468px; POSITION: absolute; TOP: 233px"
				Runat="server" Text="Imprimir" CssClass="botonesInput"></asp:button>
			<asp:image onmouseup="GetDate('TxtFechaPrograma2');" id="imgProgrammaFinal" style="Z-INDEX: 119; LEFT: 632px; POSITION: absolute; TOP: 170px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:image onmouseup="GetDate('TxtLiberacion2');" id="imgLieractionFinal" style="Z-INDEX: 117; LEFT: 800px; POSITION: absolute; TOP: 168px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:image onmouseup="GetDate('TxtLiberacion1');" id="imgLieractionInitial" style="Z-INDEX: 116; LEFT: 800px; POSITION: absolute; TOP: 91px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:image onmouseup="GetDate('TxtFechaPrograma1');" id="imgProgrammaInitial" style="Z-INDEX: 115; LEFT: 632px; POSITION: absolute; TOP: 91px"
				Runat="server" ImageUrl="../../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image>
			<asp:Label id="LblSequencia2" style="Z-INDEX: 106; LEFT: 178px; POSITION: absolute; TOP: 139px"
				Runat="server" CssClass="standard-text">Secuencia Final</asp:Label>
			<asp:DropDownList id="CboSequencia2" style="Z-INDEX: 102; LEFT: 178px; POSITION: absolute; TOP: 170px"
				runat="server" Width="151px" Height="33px" CssClass="standard-text"></asp:DropDownList>
			<asp:Label id="LblSecquencia1" style="Z-INDEX: 105; LEFT: 178px; POSITION: absolute; TOP: 60px"
				Runat="server" CssClass="standard-text"> Secuencia Inicial </asp:Label>
			<asp:DropDownList id="CboLinea" style="Z-INDEX: 100; LEFT: 10px; POSITION: absolute; TOP: 91px" runat="server"
				Width="151px" Height="33px" CssClass="standard-text"></asp:DropDownList>
			<asp:DropDownList id="CboSequencia1" style="Z-INDEX: 101; LEFT: 178px; POSITION: absolute; TOP: 91px"
				runat="server" Width="151px" Height="33px" CssClass="standard-text"></asp:DropDownList>
			<asp:Label id="lblLinea" Runat="server" style="Z-INDEX: 104; LEFT: 10px; POSITION: absolute; TOP: 60px"
				CssClass="standard-text"> Linea de Produccion </asp:Label>
			<asp:label id="lblFechaPrograma12" style="Z-INDEX: 107; LEFT: 520px; POSITION: absolute; TOP: 139px"
				runat="server" Width="140px" Height="22px" CssClass="standard-text"> FechaPrograma Final</asp:label>
			<asp:textbox id="TxtFechaPrograma2" style="Z-INDEX: 108; LEFT: 520px; POSITION: absolute; TOP: 170px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:label id="LbFechaPrograma1" style="Z-INDEX: 109; LEFT: 520px; POSITION: absolute; TOP: 60px"
				runat="server" Width="140px" Height="22px" CssClass="standard-text">Fecha Programa inicial</asp:label>
			<asp:textbox id="TxtFechaPrograma1" style="Z-INDEX: 110; LEFT: 520px; POSITION: absolute; TOP: 91px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:label id="LblLiberacion2" style="Z-INDEX: 111; LEFT: 688px; POSITION: absolute; TOP: 139px"
				runat="server" Width="143px" Height="22px" CssClass="standard-text">Fecha Liberacion Final</asp:label>
			<asp:textbox id="TxtLiberacion2" style="Z-INDEX: 112; LEFT: 688px; POSITION: absolute; TOP: 170px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:label id="LblLiberacion1" style="Z-INDEX: 113; LEFT: 688px; POSITION: absolute; TOP: 60px"
				runat="server" Width="152px" Height="22px" CssClass="standard-text">Fecha Liberacion inicial</asp:label>
			<asp:textbox id="TxtLiberacion1" style="Z-INDEX: 114; LEFT: 688px; POSITION: absolute; TOP: 91px"
				runat="server" Width="101px" ReadOnly="True" CssClass="standard-text" MaxLength="11"></asp:textbox>
			<asp:button id="cmdCancelar" style="Z-INDEX: 121; LEFT: 546px; POSITION: absolute; TOP: 233px"
				Runat="server" Text="Cancelar" CssClass="botonesInput"></asp:button>
			<asp:DropDownList id="cboFamilia" style="Z-INDEX: 122; LEFT: 8px; POSITION: absolute; TOP: 168px"
				runat="server" Width="152px" Height="24px" CssClass="standard-text"></asp:DropDownList>
			<asp:Label id="lblFamilia" style="Z-INDEX: 123; LEFT: 16px; POSITION: absolute; TOP: 136px"
				runat="server" Width="144px" Height="8px" CssClass="standard-text">Familia de Producto</asp:Label>
			<asp:DropDownList id="cboEspesor2" style="Z-INDEX: 124; LEFT: 352px; POSITION: absolute; TOP: 168px"
				runat="server" Width="151px" Height="24px" CssClass="standard-text"></asp:DropDownList>
			<asp:DropDownList id="cboEspesor1" style="Z-INDEX: 125; LEFT: 352px; POSITION: absolute; TOP: 88px"
				runat="server" Width="151px" Height="24px" CssClass="standard-text"></asp:DropDownList>
			<asp:Label id="lblEspesor1" style="Z-INDEX: 126; LEFT: 352px; POSITION: absolute; TOP: 56px"
				runat="server" Width="136px" Height="16px" CssClass="standard-text">Espesor Inicial</asp:Label>
			<asp:Label id="lblEspesor2" style="Z-INDEX: 127; LEFT: 352px; POSITION: absolute; TOP: 136px"
				runat="server" Width="152px" Height="16px" CssClass="standard-text">Espesor  Final</asp:Label>
		</form>
	</body>
</HTML>
