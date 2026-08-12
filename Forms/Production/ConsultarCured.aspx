<%@ Page language="c#" Codebehind="ConsultarCured.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultarCured" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarCured</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<asp:Literal id="ltrRefresh" runat="server"></asp:Literal>
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			} 
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Curado"
			}
			   
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ShowTitle()">
		<form id="ConsultarCured" method="post" runat="server">
			<table align="center" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="left" colSpan="5" bgColor="#003366">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
						</td>
					</tr>
					<tr align="center">
						<td colSpan="5"><br>
							<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True">Ordenes de Trabajo - Fase de Curado</asp:label>
							<hr>
						</td>
					</tr>
					<tr align="center">
						<td align="left"><asp:label id="lblInitial" Text="Fecha" Runat="server" CssClass="standard-text">Fecha Inicial</asp:label>
							<asp:label id="Label3" CssClass="standard-text" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td align="left"><asp:label id="lblFinal" Text="Fecha" Runat="server" CssClass="standard-text">Fecha Final</asp:label>
							<asp:label id="Label2" CssClass="standard-text" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td align="left"><asp:label id="Label1" Text="Linea de Produccion" Runat="server" CssClass="standard-text">Linea de Produccion</asp:label></td>
						<td align="left"><asp:label id="Status" Text="Status" Runat="server" CssClass="standard-text">Status</asp:label></td>
					<tr align="center">
						<td align="left"><asp:textbox id="txtFecha" Runat="server" CssClass="Standard-text" BorderStyle="Groove" MaxLength="11"></asp:textbox><asp:image onmouseup="GetDate('txtFecha');" id="imgInitial" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:image></td>
						<td align="left"><asp:textbox id="txtFechaFinal" Runat="server" CssClass="Standard-text" BorderStyle="Groove"
								MaxLength="11"></asp:textbox><asp:image onmouseup="GetDate('txtFechaFinal');" id="imgFinal" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:image></td>
						<td align="left"><asp:dropdownlist id="cboLinea" Runat="server" CssClass="Standard-text"></asp:dropdownlist></td>
						<td align="left"><asp:dropdownlist id="cboStatus" Runat="server" CssClass="Standard-text"></asp:dropdownlist></td>
						<td><asp:button id="cmdAceptar" Text="Aceptar" Runat="server" CssClass="botonesInput"></asp:button>&nbsp;</td>
					</tr>
					<TR>
						<TD align="left">
							<asp:RegularExpressionValidator id="revInitial" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtFecha" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:RegularExpressionValidator></TD>
						<TD align="left">
							<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtFechaFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:RegularExpressionValidator></TD>
						<TD align="left"></TD>
						<TD align="left"></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5">
							<HR>
							&nbsp;</TD>
					</TR>
					<tr align="center">
						<td colspan="5" align="center">
							<asp:datagrid id="dgdWorkOrder" runat="server" Width="770px" BorderStyle="None" BorderColor="White"
								AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" Font-Name="Verdana" Font-Names="Verdana"
								FontSize="11px">
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
											<asp:label id=ItemFamiliaProducto Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProducto") %>' CssClass="standard-text" Visible="False">
											</asp:label>
											<asp:label id=ItemDescFamilia Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescFamiliaProducto") %>' CssClass="standard-text" Visible="False">
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
											<asp:ImageButton CommandName="Consult" id="ImageButton2" runat="server" ImageUrl="../../Images/consultar.GIF"></asp:ImageButton>
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
							</asp:datagrid>
						</td>
					</tr>
					<tr>
						<td colspan="5">
							<asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" CssClass="standard-text"></asp:Label>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
