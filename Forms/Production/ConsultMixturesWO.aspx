
<%@ Page language="c#" Codebehind="ConsultMixturesWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultMixturesWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultMixturesWO</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:literal id="ltrRefresh" runat="server"></asp:literal>
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-calendario.js") %>"></script>

		<script language="javascript">		
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Mezclas"
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
	<body onload="ShowTitle();" MS_POSITIONING="GridLayout">
		<form id="ConsultMixturesWO" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" align="center">
				<tr>
					<td colSpan="5" align="left">
						<div id="sicalMenu"></div>
					</td>
				</tr>
				<tr>
					<td colSpan="5" align="center"><br>
						<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Ordenes de Trabajo - Fase de Mezclas</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="lblFechaInicial" runat="server" CssClass="standard-text" text="Fecha Inicial">Fecha Inicial</asp:label><asp:label id="Label3" CssClass="standard-text" Runat="server" ForeColor="Red" Text="(dd-MMM-yyyy)"> * (dd-MMM-aaaa)</asp:label></td>
					<td><asp:label id="lblFechaFinal" runat="server" CssClass="standard-text" text="Fecha Final">Fecha Final</asp:label><asp:label id="Label4" CssClass="standard-text" Runat="server" ForeColor="Red" Text="(dd-MMM-yyyy)"> * (dd-MMM-aaaa)</asp:label></td>
					<TD><asp:label id="lblLinea" runat="server" CssClass="standard-text" Text="Linea">Línea de Producción</asp:label></TD>
					<TD><asp:label id="lblStatus" runat="server" CssClass="standard-text" Text="Estado">Status</asp:label></TD>
					<TD></TD>
				</tr>
				<TR>
					<TD><asp:textbox id="txtFechaInicial" runat="server" CssClass="Standard-text" MaxLength="11" BorderStyle="Groove"
							Width="101px"></asp:textbox><asp:imagebutton id="cmdCalInicial" OnClientClick="return GetDate(document.forms[0].elements['txtFechaInicial'].value,'txtFechaInicial');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton></TD>
					<TD><asp:textbox id="txtFechaFinal" runat="server" CssClass="Standard-text" MaxLength="11" BorderStyle="Groove"
							Width="101px"></asp:textbox><asp:imagebutton id="cmdCalFinal" OnClientClick="return GetDate(document.forms[0].elements['txtFechaFinal'].value,'txtFechaFinal');" runat="server" ImageUrl="../../Images/icon-calendar.gif"></asp:imagebutton></TD>
					<TD><asp:dropdownlist id="cboLinea" runat="server" CssClass="Standard-text"></asp:dropdownlist></TD>
					<TD><asp:dropdownlist id="cboStatus" runat="server" CssClass="Standard-text"></asp:dropdownlist></TD>
					<TD><asp:button id="cmdAceptar" runat="server" CssClass="botonesInput" Text="Aceptar" Width="90px"></asp:button></TD>
				</TR>
				<TR>
					<TD><asp:regularexpressionvalidator id="revInitial" runat="server" CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							ControlToValidate="txtFechaInicial" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
					<TD><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" Display="Dynamic"
							ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							ControlToValidate="txtFechaFinal" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
					<TD align="center"><asp:button id="btnCard" runat="server" CssClass="botonesInput" Text="Etiqueta Identificación"
							Width="200px"></asp:button></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="5">
						<HR>
					</TD>
				</TR>
				<TR>
					<TD colSpan="9" align="center"><asp:datagrid id="dgdWorkOrder" runat="server" Font-Names="Verdana" Width="770px" AutoGenerateColumns="False"
							Font-Name="Verdana" FontSize="11px" AllowSorting="True">
							<HeaderStyle CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<asp:CheckBox id="CheckBox1" runat="server" OnCheckedChanged="checkAll" AutoPostBack="True"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox style="Z-INDEX: 0" id="chkSelect" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
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
										<asp:label id="Label1" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.KCT") %>' Runat="server" Width="30px">
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
										<asp:label id="Label2" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.OtraMedida") %>' Runat="server" Width="30px">
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
										<asp:label id=ItemIdEspesor CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>' Runat="server" Visible="False">
										</asp:label>
										<asp:label id=ItemIdFamiliaProducto CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProducto") %>' Runat="server" Visible="False">
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
										<asp:ImageButton id="ImageButton2" runat="server" ImageUrl="../../Images/consultar.GIF" CommandName="Consult"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:ImageButton CommandName="Agregar" id="ImageButton3" runat="server" ImageUrl="../../Images/Email.GIF"></asp:ImageButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="ImagenPiso" runat="server" ImageUrl="../../Images/new.GIF" Visible='<%#DataBinder.Eval(Container, "DataItem.MensajePiso")==""?false:true%>' AlternateText="Contiene Mensaje de Piso">
										</asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="9"><asp:label id="lblErrorMsg" runat="server" Font-Bold="True" CssClass="standard-text" ForeColor="Red"></asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
