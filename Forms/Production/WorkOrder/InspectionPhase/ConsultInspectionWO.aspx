<%@ Page language="c#" Codebehind="ConsultInspectionWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.InspectionPhase.ConsultInspectionWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultInspectionWorkOrders</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:Literal id="ltrRefresh" runat="server"></asp:Literal>
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\..\\..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}  
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Inspección"
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
		<form id="ConsultInspectionWO" method="post" runat="server">
			<table align="center" style="BORDER-COLLAPSE: collapse" id="Table1">
				<tr>
					<td align="left" colSpan="5">
						<div id="sicalMenu"></div>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="5"><br>
						<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Ordenes de Trabajo - Fase de Inspección</asp:label><hr>
					</td>
				</tr>
				<tr>
					<td><asp:Label id="Label1" runat="server" CssClass="standard-text">Fecha Inicial</asp:Label>
						<asp:label id="Label3" CssClass="standard-text" Text="(dd-MMM-yyyy)" ForeColor="Red" Runat="server"> * (dd-MMM-aaaa)</asp:label></td>
					<td><asp:Label id="Label2" runat="server" CssClass="standard-text">Fecha Final</asp:Label>
						<asp:label id="Label4" CssClass="standard-text" Text="(dd-MMM-yyyy)" ForeColor="Red" Runat="server"> * (dd-MMM-aaaa)</asp:label></td>
					<td><asp:label id="lblLinea" runat="server" Width="50px" CssClass="standard-text">Linea</asp:label></td>
					<td><asp:label id="lblStatus" runat="server" Width="50px" CssClass="standard-text">Estado</asp:label></td>
				</tr>
				<tr>
					<td>
						<asp:TextBox id="txtFechaInicial" runat="server" Width="100px" CssClass="standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:TextBox>
						<asp:ImageButton id="ImgFechaInicial" runat="server" OnClientClick="return GetDate('txtFechaInicial');" ImageUrl="../../../../Images/icon-calendar.gif"></asp:ImageButton>
					</td>
					<td>
						<asp:TextBox id="txtFechaFinal" runat="server" Width="100px" CssClass="standard-text" BorderStyle="Groove"
							MaxLength="11"></asp:TextBox>
						<asp:ImageButton id="ImgFechaFinal" runat="server" OnClientClick="return GetDate('txtFechaFinal');" ImageUrl="../../../../Images/icon-calendar.gif"></asp:ImageButton>
					</td>
					<td><asp:dropdownlist id="cboLinea" runat="server" Width="125px" CssClass="standard-text"></asp:dropdownlist></td>
					<td><asp:dropdownlist id="cboStatus" runat="server" Width="125px" CssClass="standard-text"></asp:dropdownlist></td>
					<td><asp:button id="cmdAceptar" runat="server" Width="80px" Text="Aceptar" CssClass="botonesInput"></asp:button></td>
				</tr>
				<TR>
					<TD>
						<asp:RegularExpressionValidator id="revInitial" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtFechaInicial" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD>
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
							ControlToValidate="txtFechaFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							Display="Dynamic"></asp:RegularExpressionValidator></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5">
						<HR>
						&nbsp;</TD>
				</TR>
				<tr>
					<td colspan="5" align="center">
						<asp:datagrid id="dgdInspectionWO" runat="server" Font-Names="Verdana" Width="770px" BorderColor="White"
							CellPadding="2" BorderStyle="None" AllowSorting="True" FontSize="11px" Font-Name="Verdana"
							AutoGenerateColumns="False">
							<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="P">
									<HeaderStyle HorizontalAlign="Center" Width="25px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="25px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemPrioridad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' Runat="server" Width="25px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Fecha">
									<HeaderStyle HorizontalAlign="Center" Width="85px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="85px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemFecha CssClass="standard-text" Text='<%# String.Format("{0:dd-MMM-yyyy}",DataBinder.Eval(Container, "DataItem.Fecha")) %>' Runat="server">
										</asp:label>
										<asp:label id=ItemFechaMod CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.FechaMod") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Secuencia">
									<HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemSecuencia CssClass="standard-text" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemCodigoSAP CssClass="standard-text" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="KCT">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="ItemKCT" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.KCT") %>' Runat="server" Width="30px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lote">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="ItemLote" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Lote") %>' Runat="server" Width="30px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Cant.">
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemCantidad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Med.">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="ItemMedida" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.OtraMedida") %>' Runat="server" Width="30px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descripci&#243;n">
									<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="250px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemDescripcion CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemIdMedida CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdMedida") %>' Runat="server" Visible="False">
										</asp:label>
										<asp:label id=ItemEspesor Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>' CssClass="standard-text" Visible="False">
										</asp:label>
										<asp:label id=ItemIdFamiliaProducto Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProducto") %>' CssClass="standard-text" Visible="False">
										</asp:label>
										<asp:label id=ItemDescFamiliaProducto Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescFamiliaProducto") %>' CssClass="standard-text" Visible="False">
										</asp:label>
										<asp:label id=ItemIdPresentacion Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdPresentacion") %>' CssClass="standard-text" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="L&#237;nea">
									<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemLineaDesc CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemIdLinea CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server" Visible="False">
										</asp:label>
										<asp:label id=ItemIdPlanta Text='<%# DataBinder.Eval(Container, "DataItem.IdPlanta") %>' CssClass="standard-text" Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Estado">
									<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemStatusDesc CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemIdStatus CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton CommandName="Consult" id="ImageButton2" runat="server" ImageUrl="../../../../Images/consultar.GIF"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton CommandName="Agregar" id="ImageButton3" runat="server" ImageUrl="../../../../Images/Email.GIF"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="ImagenPiso" runat="server" ImageUrl="../../../../Images/new.GIF" Visible='<%#DataBinder.Eval(Container, "DataItem.MensajePiso")==""?false:true%>' AlternateText="Contiene Mensaje de Piso">
										</asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
				<tr>
					<td colspan="5">
						<asp:label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" CssClass="standard-text"></asp:label>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
