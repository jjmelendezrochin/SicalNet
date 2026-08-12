
<%@ Page language="c#" Codebehind="ConsultReactionWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultReactionWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SICAL - Cuarto de Reacción</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}    
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Reacción"
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
	<body onload="ShowTitle()" MS_POSITIONING="GridLayout">
		<form id="ConsultReactionWO" method="post" runat="server">
			<table align="center" width="700" height="0" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td colSpan="5" align="center"><br>
							<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Ordenes de Trabajo - Fase de Reacción</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td style="HEIGHT: 21px"><asp:label id="lblInitial" CssClass="Standard-text" Runat="server" Text="Fecha">Fecha Inicial</asp:label><asp:label id="Label2" CssClass="standard-text" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td style="HEIGHT: 21px"><asp:label id="lblFinal" CssClass="Standard-text" Runat="server" Text="Fecha">Fecha Final</asp:label><asp:label id="Label3" CssClass="standard-text" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td style="HEIGHT: 21px"><asp:label id="Label1" CssClass="Standard-text" Runat="server" Text="Linea de Produccion">Linea de Produccion</asp:label></td>
						<td style="HEIGHT: 21px"><asp:label id="Status" CssClass="Standard-text" Runat="server" Text="Status">Status</asp:label></td>
					</tr>
					<tr>
						<td><asp:textbox id="txtFechaInicial" CssClass="Standard-text" Runat="server" MaxLength="11" BorderStyle="Groove"
								Width="100px"></asp:textbox><asp:image id="imgInitial" onmouseup="GetDate('txtFechaInicial');" Runat="server" AlternateText="Inicial Date"
								ImageUrl="../../Images/icon-calendar.gif"></asp:image></td>
						<td><asp:textbox id="txtFechaFinal" CssClass="Standard-text" Runat="server" MaxLength="11" BorderStyle="Groove"
								Width="100px"></asp:textbox><asp:image id="imgFinal" onmouseup="GetDate('txtFechaFinal');" Runat="server" AlternateText="Inicial Date"
								ImageUrl="../../Images/icon-calendar.gif"></asp:image></td>
						<td><asp:dropdownlist id="cboLinea" CssClass="Standard-text" Runat="server"></asp:dropdownlist></td>
						<td><asp:dropdownlist id="cboStatus" CssClass="Standard-text" Runat="server"></asp:dropdownlist></td>
						<td><asp:button id="cmdGo" CssClass="botonesInput" Runat="server" Text="Aceptar"></asp:button></td>
					</tr>
					<TR>
						<TD><asp:regularexpressionvalidator id="revInitial" runat="server" CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								ControlToValidate="txtFechaInicial" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
						<TD><asp:regularexpressionvalidator id="revFinal" runat="server" CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								ControlToValidate="txtFechaFinal" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<tr>
						<td colSpan="5"><asp:datagrid id="dgdOTReaccion" runat="server" Font-Names="Verdana" BorderStyle="None" Width="700px"
								BorderColor="White" DataKeyField="IdOrdenTrabajo" AllowSorting="True" FontSize="11px" Font-Name="Verdana"
								AutoGenerateColumns="False" CellPadding="2">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Fecha">
										<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="80px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemFecha Runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",DataBinder.Eval(Container, "DataItem.Fecha")) %>' CssClass="Standard-text">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Id">
										<HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="10px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemIdOrdenTrabajo Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdOrdenTrabajo") %>' CssClass="Standard-text" Width="40px">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="L&#237;nea">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="70px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemLineaDesc Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LineaDesc") %>' CssClass="Standard-text">
											</asp:label>
											<asp:label id=ItemIdLinea Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' CssClass="Standard-text" Visible="False">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Estado">
										<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=ItemStatusDesc Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' CssClass="Standard-text">
											</asp:label>
											<asp:label id=ItemIdStatus Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' CssClass="Standard-text" Visible="False">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Consultar" HeaderText="Consultar" CommandName="Select">
										<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle CssClass="grid-item"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
