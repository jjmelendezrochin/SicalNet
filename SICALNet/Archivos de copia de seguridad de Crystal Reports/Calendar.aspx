<%@ Page language="c#" Codebehind="Calendar.aspx.cs" AutoEventWireup="false" Inherits="WebApplication1.Calendar" %>
<HTML>
	<HEAD>
		<script language="javascript">
		<!--
			function ReturnDate()        
			{   				
				window.opener.document.forms[0].elements["<%= Request.QueryString["CtrlName"] %>"].value = "<%= strSelectedDate %>";
				window.close();        
			}        
			
			function Close()        
			{            
				window.close();        
			}
			
		//-->
		</script>
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
	</HEAD>
	<body>
		<form id="Form1" runat="server">
			<table>
				<tbody>
					<tr>
						<td align="center"><asp:label id="lblMes" runat="server" CssClass="standard-text">Mes:</asp:label><asp:dropdownlist id="ddlMonth" runat="server" CssClass="Standard-text" AutoPostBack="True" OnSelectedIndexChanged="ddl_SelectedIndexChanged"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;
							<asp:label id="lblAnio" runat="server" CssClass="standard-text">Año:</asp:label><asp:dropdownlist id="ddlYear" runat="server" CssClass="Standard-text" AutoPostBack="True" OnSelectedIndexChanged="ddl_SelectedIndexChanged"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td align="center"><asp:calendar id="cdrControl" runat="server" CellPadding="1" OnSelectionChanged="myCalendar_SelectionChanged"
								BorderColor="#3366CC" Font-Names="Verdana" Font-Size="8pt" Height="200px" ForeColor="#003399" DayNameFormat="FirstLetter"
								Width="220px" BackColor="White" BorderWidth="1px">
								<TodayDayStyle ForeColor="White" BackColor="#99CCCC"></TodayDayStyle>
								<SelectorStyle ForeColor="#336666" BackColor="#99CCCC"></SelectorStyle>
								<NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
								<DayHeaderStyle Height="1px" ForeColor="#336666" BackColor="#99CCCC"></DayHeaderStyle>
								<SelectedDayStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedDayStyle>
								<TitleStyle Font-Size="10pt" Font-Bold="True" Height="25px" BorderWidth="1px" ForeColor="#CCCCFF"
									BorderStyle="Solid" BorderColor="#3366CC" BackColor="#003399"></TitleStyle>
								<WeekendDayStyle BackColor="#CCCCFF"></WeekendDayStyle>
								<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
							</asp:calendar></td>
					</tr>
					<tr>
						<td align="center"><asp:button id="btnReturnDate" CssClass="botonesInput" Text="Seleccionar" Runat="server"></asp:button>&nbsp;<asp:button id="btnCloseWindow" CssClass="botonesInput" Text="Cerrar" Runat="server"></asp:button>
						</td>
					</tr>
				</tbody></table>
		</form>
	</body>
</HTML>
