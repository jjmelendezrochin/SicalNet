<%@ Page language="c#" Codebehind="ConsultCuradoReport.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ConsultCuradoReport" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultCuradoReport</title>
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
		<form id="ConsultReport" method="post" runat="server">
			<center>
				<br>
				<br>
				<br>
				<p></p>
				<p></p>
				<p></p>
				<asp:label id="lblcaption" CssClass="standard-text" style="Z-INDEX: 102; POSITION: absolute; TOP: 56px; LEFT: 488px"
					Font-Size="Larger" Font-Bold="True" Runat="server" Width="520px"> Reporte de Consumos en Fase de </asp:label>
				<asp:RegularExpressionValidator id="RegularExpressionValidator3" style="Z-INDEX: 135; POSITION: absolute; TOP: 216px; LEFT: 1104px"
					runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en liberación final" ControlToValidate="txtLibFinal"
					ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator id="RegularExpressionValidator2" style="Z-INDEX: 134; POSITION: absolute; TOP: 136px; LEFT: 1104px"
					runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en liberación inicial" ControlToValidate="txtLibInicial"
					ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator id="RegularExpressionValidator1" style="Z-INDEX: 133; POSITION: absolute; TOP: 216px; LEFT: 936px"
					runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en programa final" ControlToValidate="txtFechaFinal"
					ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
				<asp:RegularExpressionValidator id="revInitial" style="Z-INDEX: 132; POSITION: absolute; TOP: 136px; LEFT: 936px"
					runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta en programa inicial" ControlToValidate="txtFechaInicial"
					ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">*</asp:RegularExpressionValidator>
				<asp:textbox id="txtSecFinal" style="Z-INDEX: 130; POSITION: absolute; TOP: 216px; LEFT: 464px"
					runat="server" CssClass="standard-text" Width="121px"></asp:textbox>
				<asp:textbox id="txtSecInicial" style="Z-INDEX: 129; POSITION: absolute; TOP: 136px; LEFT: 464px"
					runat="server" CssClass="standard-text" Width="121px"></asp:textbox>
				<asp:button CssClass="botonesInput" id="cmdprint" style="Z-INDEX: 114; POSITION: absolute; TOP: 280px; LEFT: 752px"
					Runat="server" Text="Imprimir"></asp:button>
				<asp:image onmouseup="GetDate('txtFechaFinal');" id="imgProgrammaFinal" style="Z-INDEX: 113; POSITION: absolute; TOP: 216px; LEFT: 912px"
					Runat="server" AlternateText="Inicial Date" ImageUrl="../../Images/icon-calendar.gif"></asp:image>
				<asp:image onmouseup="GetDate('txtLibFinal');" id="imgLieractionFinal" style="Z-INDEX: 112; POSITION: absolute; TOP: 216px; LEFT: 1080px"
					Runat="server" AlternateText="Inicial Date" ImageUrl="../../Images/icon-calendar.gif"></asp:image>
				<asp:image onmouseup="GetDate('txtLibInicial');" id="imgLieractionInitial" style="Z-INDEX: 111; POSITION: absolute; TOP: 136px; LEFT: 1080px"
					Runat="server" AlternateText="Inicial Date" ImageUrl="../../Images/icon-calendar.gif"></asp:image>
				<asp:image onmouseup="GetDate('txtFechaInicial');" id="imgProgrammaInitial" style="Z-INDEX: 110; POSITION: absolute; TOP: 136px; LEFT: 912px"
					Runat="server" AlternateText="Inicial Date" ImageUrl="../../Images/icon-calendar.gif"></asp:image>
				<asp:label CssClass="standard-text" id="LblSequencia2" style="Z-INDEX: 105; POSITION: absolute; TOP: 184px; LEFT: 464px"
					Runat="server">Secuencia Final</asp:label>
				<asp:label CssClass="standard-text" id="LblSecquencia1" style="Z-INDEX: 104; POSITION: absolute; TOP: 104px; LEFT: 464px"
					Runat="server"> Secuencia Inicial </asp:label>
				<asp:dropdownlist id="cboLinea" style="Z-INDEX: 101; POSITION: absolute; TOP: 136px; LEFT: 296px"
					runat="server" Width="151px" Height="33px" CssClass="standard-text"></asp:dropdownlist>
				<asp:label CssClass="standard-text" id="lblLinea" style="Z-INDEX: 103; POSITION: absolute; TOP: 104px; LEFT: 296px"
					Runat="server"> Linea de Producción </asp:label>
				<asp:label CssClass="standard-text" id="lblFechaPrograma12" style="Z-INDEX: 106; POSITION: absolute; TOP: 184px; LEFT: 800px"
					runat="server" Width="140px" Height="22px"> Fecha Programa Final</asp:label>
				<asp:label CssClass="standard-text" id="LbFechaPrograma1" style="Z-INDEX: 107; POSITION: absolute; TOP: 104px; LEFT: 800px"
					runat="server" Width="140px" Height="22px">Fecha Programa Inicial</asp:label>
				<asp:label CssClass="standard-text" id="LblLiberacion2" style="Z-INDEX: 108; POSITION: absolute; TOP: 184px; LEFT: 968px"
					runat="server" Width="143px" Height="22px">Fecha Liberacion Final</asp:label>
				<asp:label CssClass="standard-text" id="LblLiberacion1" style="Z-INDEX: 109; POSITION: absolute; TOP: 104px; LEFT: 968px"
					runat="server" Width="152px" Height="22px">Fecha Liberacion inicial</asp:label>
				<asp:button CssClass="botonesInput" id="cmdCancelar" style="Z-INDEX: 115; POSITION: absolute; TOP: 280px; LEFT: 832px"
					Runat="server" Text="Regresar"></asp:button>
				<asp:dropdownlist id="cboFamilia" style="Z-INDEX: 116; POSITION: absolute; TOP: 216px; LEFT: 288px"
					runat="server" Width="152px" Height="24px" CssClass="standard-text"></asp:dropdownlist>
				<asp:label CssClass="standard-text" id="lblFamilia" style="Z-INDEX: 117; POSITION: absolute; TOP: 184px; LEFT: 296px"
					runat="server" Width="144px" Height="8px">Familia de Producto</asp:label>
				<asp:dropdownlist id="cboEspesor2" style="Z-INDEX: 118; POSITION: absolute; TOP: 216px; LEFT: 632px"
					runat="server" Width="151px" Height="24px" CssClass="standard-text"></asp:dropdownlist>
				<asp:dropdownlist id="cboEspesor1" style="Z-INDEX: 119; POSITION: absolute; TOP: 136px; LEFT: 632px"
					runat="server" Width="151px" Height="24px" CssClass="standard-text"></asp:dropdownlist>
				<asp:label CssClass="standard-text" id="lblEspesor1" style="Z-INDEX: 120; POSITION: absolute; TOP: 104px; LEFT: 632px"
					runat="server" Width="136px" Height="16px">Espesor Inicial</asp:label>
				<asp:label CssClass="standard-text" id="lblEspesor2" style="Z-INDEX: 121; POSITION: absolute; TOP: 184px; LEFT: 632px"
					runat="server" Width="152px" Height="16px">Espesor  Final</asp:label>
				<asp:label CssClass="standard-text" id="lblErrMsg" style="Z-INDEX: 122; POSITION: absolute; TOP: 280px; LEFT: 288px"
					runat="server" Width="358px" ForeColor="Red"></asp:label>
				<asp:dropdownlist id="cboSecInicial" style="Z-INDEX: 123; POSITION: absolute; TOP: 320px; LEFT: 744px"
					runat="server" Width="148px" AutoPostBack="True" Visible="False"></asp:dropdownlist>
				<asp:dropdownlist id="cboSecFinal" style="Z-INDEX: 124; POSITION: absolute; TOP: 368px; LEFT: 744px"
					runat="server" Width="147px" AutoPostBack="True" Visible="False"></asp:dropdownlist>
				<asp:TextBox CssClass="standard-text" id="txtFechaInicial" style="Z-INDEX: 125; POSITION: absolute; TOP: 136px; LEFT: 808px"
					runat="server" Width="103px" MaxLength="11"></asp:TextBox>
				<asp:TextBox CssClass="standard-text" id="txtFechaFinal" style="Z-INDEX: 126; POSITION: absolute; TOP: 208px; LEFT: 808px"
					runat="server" Width="106px" MaxLength="11"></asp:TextBox>
				<asp:TextBox CssClass="standard-text" id="txtLibInicial" style="Z-INDEX: 127; POSITION: absolute; TOP: 136px; LEFT: 968px"
					runat="server" Width="115px" MaxLength="11"></asp:TextBox>
				<asp:TextBox CssClass="standard-text" id="txtLibFinal" style="Z-INDEX: 128; POSITION: absolute; TOP: 208px; LEFT: 968px"
					runat="server" Width="111px" MaxLength="11"></asp:TextBox>
				<asp:ValidationSummary id="vs" style="Z-INDEX: 131; POSITION: absolute; TOP: 312px; LEFT: 296px" runat="server"
					CssClass="standard-text" Width="216px"></asp:ValidationSummary>
			</center>
		</form>
	</body>
</HTML>
