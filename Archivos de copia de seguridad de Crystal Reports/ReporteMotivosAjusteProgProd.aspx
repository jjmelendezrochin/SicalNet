<%@ Page language="c#" Codebehind="ReporteMotivosAjusteProgProd.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ReporteMotivosAjusteProgProd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReporteMotivosAjusteProgProd</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=270,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=yes,resizable=no");
			}    
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Ajustes Reporte Programa de Producción"
			}			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label style="Z-INDEX: 100; POSITION: absolute; TOP: 24px; LEFT: 256px" id="lblTitle" runat="server"
				Width="400px" Height="19px" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="Larger"
				CssClass="standard-text"> Reporte Fase de Ajustes al programa de Producción</asp:label>
			<asp:datagrid style="Z-INDEX: 130; POSITION: absolute; TOP: 264px; LEFT: 32px" id="DataGrid1"
				runat="server" Width="100%" Height="46px" Font-Names="Verdana" Font-Size="X-Small" BorderStyle="None"
				BorderWidth="1px" BorderColor="#999999" BackColor="White" CellPadding="3" GridLines="Vertical">
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle BorderWidth="2px" ForeColor="Black" BorderStyle="Solid" BorderColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="2px" ForeColor="White" BorderStyle="Solid"
					BorderColor="Black" BackColor="#000084"></HeaderStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:button style="Z-INDEX: 129; POSITION: absolute; TOP: 160px; LEFT: 736px" id="cmdExportaPvc"
				CssClass="botonesInput" Runat="server" Text="Exportar"></asp:button><asp:label style="Z-INDEX: 118; POSITION: absolute; TOP: 208px; LEFT: 280px" id="lblErrMsg"
				runat="server" Width="658px" Height="20px" CssClass="standard-text" ForeColor="Red"></asp:label><asp:button style="Z-INDEX: 117; POSITION: absolute; TOP: 160px; LEFT: 656px" id="cmdReporte"
				runat="server" CssClass="botonesInput" Text="Reporte"></asp:button><asp:button style="Z-INDEX: 115; POSITION: absolute; TOP: 160px; LEFT: 816px" id="btnCancelar"
				runat="server" CssClass="botonesInput" Text="Cancelar"></asp:button><asp:dropdownlist style="Z-INDEX: 114; POSITION: absolute; TOP: 96px; LEFT: 656px" id="cboCausa" runat="server"
				Width="224px" CssClass="standard-text"></asp:dropdownlist><asp:label style="Z-INDEX: 113; POSITION: absolute; TOP: 72px; LEFT: 656px" id="Label2" runat="server"
				Width="40px" Height="22px" CssClass="standard-text">Causa</asp:label><asp:regularexpressionvalidator style="Z-INDEX: 112; POSITION: absolute; TOP: 192px; LEFT: 616px" id="RegularExpressionValidator1"
				runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				ControlToValidate="txtFechaFinal" ErrorMessage="Fecha incorrecta en programa final">*</asp:regularexpressionvalidator><asp:regularexpressionvalidator style="Z-INDEX: 111; POSITION: absolute; TOP: 192px; LEFT: 400px" id="revInitial"
				runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				ControlToValidate="txtFechaInicial" ErrorMessage="Fecha incorrecta en programa inicial">*</asp:regularexpressionvalidator><asp:label style="Z-INDEX: 103; POSITION: absolute; TOP: 144px; LEFT: 272px" id="lblFechaInicial"
				runat="server" Width="154px" Height="22px" CssClass="standard-text">Fecha Programa Inicial</asp:label><asp:textbox style="Z-INDEX: 104; POSITION: absolute; TOP: 168px; LEFT: 272px" id="txtFechaInicial"
				runat="server" Width="121px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox><asp:imagebutton style="Z-INDEX: 106; POSITION: absolute; TOP: 168px; LEFT: 392px" id="imgFInicial"
				onmouseup="GetDate('txtFechaInicial');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton><asp:label style="Z-INDEX: 108; POSITION: absolute; TOP: 144px; LEFT: 472px" id="lblFechaFinal"
				runat="server" Width="142px" Height="22px" CssClass="standard-text"> Fecha Programa Final</asp:label><asp:textbox style="Z-INDEX: 109; POSITION: absolute; TOP: 168px; LEFT: 472px" id="txtFechaFinal"
				runat="server" Width="119px" CssClass="standard-text" BorderStyle="Groove"></asp:textbox><asp:imagebutton style="Z-INDEX: 110; POSITION: absolute; TOP: 168px; LEFT: 592px" id="imgFFinal"
				onmouseup="GetDate('txtFechaFinal');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton><asp:label style="Z-INDEX: 107; POSITION: absolute; TOP: 72px; LEFT: 272px" id="Label1" runat="server"
				Width="40px" Height="22px" CssClass="standard-text">Planta</asp:label><asp:dropdownlist style="Z-INDEX: 102; POSITION: absolute; TOP: 96px; LEFT: 272px" id="cboPlanta"
				runat="server" Width="125px" CssClass="standard-text"></asp:dropdownlist><asp:label style="Z-INDEX: 105; POSITION: absolute; TOP: 72px; LEFT: 472px" id="lblLinea" runat="server"
				Width="40px" Height="22px" CssClass="standard-text">Linea</asp:label><asp:dropdownlist style="Z-INDEX: 101; POSITION: absolute; TOP: 96px; LEFT: 472px" id="cboLinea" runat="server"
				Width="125px" CssClass="standard-text"></asp:dropdownlist></form>
	</body>
</HTML>
