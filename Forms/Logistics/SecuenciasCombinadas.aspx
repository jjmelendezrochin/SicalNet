<%@ Page language="c#" Codebehind="SecuenciasCombinadas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Logistics.SecuenciasCombinadas" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SecuenciasCombinadas</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		
		<script language="JavaScript">  
			function GetDate(CtrlName)        
			{   
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}    

			function ShowTitle()
			{
				window.frames["top"].document.title = "SICAL  - Logística - Secuencias Combinadas"
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
		<form id="SecuenciasCombinadas" method="post" runat="server">
			<table width="700" align="center" style="BORDER-COLLAPSE: collapse">
				<tr>
					<td align="left" colSpan="5">
						<div id="sicalMenu"></div>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="4"><br>
						<asp:label id="lblTitle" runat="server" Font-Bold="True" Font-Size="14" Font-Names="Arial Narrow"> Secuencias Combinadas</asp:label>						
					</td>
				</tr>
			</table>
			<br />			
			<table width="700" align="center" style="BORDER-COLLAPSE: collapse">
				<tr>
					<td align="center" colSpan="4"></td>
				</tr>
				<tr>					
					<td style="HEIGHT: 2px"><asp:label id="lblInitial" Text="Fecha" Runat="server" CssClass="standard-text">Fecha Inicial</asp:label>
						<asp:label id="Label3" CssClass="standard-text" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
					<td style="HEIGHT: 2px"><asp:label id="lblFinal" Text="Fecha" Runat="server" CssClass="standard-text">Fecha Final</asp:label>
						<asp:label id="Label2" CssClass="standard-text" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
					<td><asp:label id="Label1" Text="Fecha" Runat="server" CssClass="standard-text">Línea Producción</asp:label></td>
					<td></td>
				<tr>
					<td style="HEIGHT: 2px"><asp:textbox id="txtFecha" Runat="server" Width="100px" CssClass="Standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:textbox>
						<asp:imagebutton OnClientClick="return GetDate('txtFecha');" id="imgInitial" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
							AlternateText="Inicial Date"></asp:imagebutton></td>
					<td style="HEIGHT: 2px"><asp:textbox id="txtFechaFinal" Runat="server" Width="100px" CssClass="Standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:textbox>
						<asp:imagebutton OnClientClick="return GetDate('txtFechaFinal');" id="imgFinal" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
							AlternateText="Inicial Date"></asp:imagebutton></td>
					<TD style="HEIGHT: 2px"><asp:dropdownlist id="cboLinea" Runat="server" CssClass="standard-text"></asp:dropdownlist></TD>
					<td style="HEIGHT: 2px"><asp:button id="cmdConsultar" runat="server" Text="Consultar" CssClass="botonesInput" OnClick="cmdConsultar_Click1"></asp:button></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 2px">
						<asp:RegularExpressionValidator id="revInitial" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtFecha" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD style="HEIGHT: 2px">
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtFechaFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="HEIGHT: 2px"></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD colSpan="4" style="HEIGHT: 206px" align="center"><asp:datalist id="lstProgram" runat="server">
							<HeaderTemplate>
								<TABLE id="tableFrame" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="1"
									cellPadding="1" border="1">
									<TR>
										<TD>
											<TABLE id="Table14" style="BORDER-COLLAPSE: collapse" borderColor="white" cellSpacing="1"
												cellPadding="1" bgColor="#276187" border="1">
												<TR>
													<TD>
														<asp:CheckBox id="chkSelectAll" runat="server" CssClass="standard-text" Width="20px" OnCheckedChanged="CheckAll"
															AutoPostBack="True" ForeColor="White"></asp:CheckBox></TD>
													<TD>
														<asp:Label id="P" runat="server" CssClass="standard-text" Width="23px" ForeColor="White">P</asp:Label></TD>
													<TD>
														<asp:Label id="Fecha" runat="server" CssClass="standard-text" Width="60px" ForeColor="White">Fecha</asp:Label></TD>
													<TD>
														<asp:Label id="Línea" runat="server" CssClass="standard-text" Width="30px" ForeColor="White">Línea</asp:Label></TD>
													<TD>
														<asp:Label id="Secuencia" runat="server" CssClass="standard-text" Width="70px" ForeColor="White">Secuencia</asp:Label></TD>
													<TD>
														<asp:Label id="Lote" runat="server" CssClass="standard-text" Width="25px" ForeColor="White">Lote</asp:Label></TD>
													<TD>
														<asp:Label id="Cantidad" runat="server" CssClass="standard-text" Width="30px" ForeColor="White">Cant.</asp:Label></TD>
													<TD>
														<asp:Label id="Material" runat="server" CssClass="standard-text" Width="60px" ForeColor="White">Material</asp:Label></TD>
													<TD>
														<asp:Label id="Descripción" runat="server" CssClass="standard-text" Width="230px" ForeColor="White">Descripción</asp:Label></TD>
													<TD>
														<asp:Label id="Status" runat="server" CssClass="standard-text" Width="60px" ForeColor="White">Status</asp:Label></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</HeaderTemplate>
							<ItemTemplate>
								<TABLE id="tableDance" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="1"
									cellPadding="1" border="1">
									<TR>
										<TD>
											<TABLE id="Table8" style="BORDER-COLLAPSE: collapse" 
												borderColor="white" 
												cellSpacing="1"
												cellPadding="1" 												
												border="1"
												CssClass="GridView grid-header">
												<TR>
													<TD>
														<asp:CheckBox id="chkSelected" runat="server" CssClass="standard-text" Width="20px" ForeColor="White"></asp:CheckBox></TD>
													<TD>
														<asp:Label id=lblPrioridad runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' CssClass="standard-text" Width="23px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblFecha runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Fecha") %>' CssClass="standard-text" Width="60px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblLinea runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' CssClass="standard-text" Width="30px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblSecuencia runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' CssClass="standard-text" Width="70px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblLote runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumeroLote") %>' CssClass="standard-text" Width="25px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblCantidad runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="standard-text" Width="30px">
														</asp:Label></TD>
													<TD align="right">
														<asp:Label id=lblMaterial runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text" Width="60px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblDescripcion runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaterialDesc") %>' CssClass="standard-text" Width="230px">
														</asp:Label></TD>
													<TD>
														<asp:Label id=lblStatus runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' CssClass="standard-text" Width="60px" Visible="False">
														</asp:Label>
														<asp:Label id=lblStatusDesc runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' CssClass="standard-text" Width="60px">
														</asp:Label></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</ItemTemplate>
						</asp:datalist></TD>
				</TR>
				<TR>					
					<td colspan="4" align="center">
						<asp:Button id="cmdCombinar" runat="server" CssClass="botonesInput" Text="Combina Secuencias"
							Width="180px" Visible="False" DESIGNTIMEDRAGDROP="99"></asp:Button>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
