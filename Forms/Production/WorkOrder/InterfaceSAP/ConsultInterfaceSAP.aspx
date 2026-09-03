<%@ Page language="c#" Codebehind="ConsultInterfaceSAP.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.InterfaceSAP.ConsultInterfaceSAP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultInterfaceSAP</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-calendario.js") %>"></script>


		<script language="javascript">		
			function CheckAllDataGridCheckBoxes() 
			{			 
				for(i=0;i<document.forms[0].length;i++)
				{
					if (document.forms[0].elements[i].name.indexOf('chkSelect') != -1)
					{
						if(document.forms[0].elements["lstWorkOrder:_ctl0:chkAllCheck"].checked==true)
						document.forms[0].elements[i].checked=true
						else
						document.forms[0].elements[i].checked=false
					}
				}						
			}			
			function CheckAllDataGridCheckBoxes2() 
			{			 
				for(i=0;i<document.forms[0].length;i++)
				{
					if (document.forms[0].elements[i].name.indexOf('chkEF') != -1)
					{
						if(document.forms[0].elements["lstWorkOrder:_ctl0:chkAllEF"].checked==true)
						document.forms[0].elements[i].checked=true
						else
						document.forms[0].elements[i].checked=false
					}
				}						
			}	
			function getConfirm(Button)
			{			  
			    if((document.forms[0].elements["cboStatus"].value) == '5')
			    {
					if(window.confirm("Estos registros ya han sido envíados en la interfaz, Podría duplicar información ¿Desea Continuar?"))
					{
						document.forms[0].elements[Button].click()
					}
				}
				else
				{
						document.forms[0].elements[Button].click()
				}
			} 	
			
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Ordenes de Trabajo - Fase de Interfase SAP"
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
		<form id="ConsultInterfaceSAP" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" width="700" align="center">
				<TBODY>
					<tr class="sical-menu-row">
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="5"><br>
							<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Ordenes de Trabajo - Fase Interfase SAP</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="lblInitial" Width="148px" CssClass="standard-text" Text="Fecha Inicial *" Runat="server">Fecha Inicial Recepción PT</asp:label><asp:label id="Label3" Width="112px" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server"
								ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="lblFinal" Width="140px" CssClass="standard-text" Text="Fecha Final" Runat="server">Fecha Final Recepción PT</asp:label><asp:label id="Label4" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"
								Width="128px"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="Label5" CssClass="standard-text" Text="Status" Runat="server">Status</asp:label></td>
						<td><asp:label id="Label1" CssClass="standard-text" Text="Línea de Producción" Runat="server">Línea de Producción</asp:label></td>
						<td align="left"></td>
					</tr>
					<tr>
						<td><asp:textbox id="txtInitial" Width="99px" CssClass="Standard-text" Runat="server" BorderStyle="Groove"></asp:textbox>
							<asp:imagebutton OnClientClick="return GetDate(document.forms[0].elements['txtInitial'].value,'txtInitial');" id="imgInitial" Runat="server" ImageUrl="../../../../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:imagebutton></td>
						<td><asp:textbox id="txtFinal" Width="99px" CssClass="Standard-text" Runat="server" BorderStyle="Groove"></asp:textbox>
							<asp:imagebutton OnClientClick="return GetDate(document.forms[0].elements['txtFinal'].value,'txtFinal');" id="imgFinal" Runat="server" ImageUrl="../../../../Images/icon-calendar.gif"
								AlternateText="Final Date"></asp:imagebutton></td>
						<td><asp:dropdownlist id="cboStatus" Width="100px" CssClass="Standard-text" Runat="server"></asp:dropdownlist></td>
						<TD><asp:dropdownlist id="cboLinea" Width="100px" CssClass="Standard-text" Runat="server"></asp:dropdownlist></TD>
						<TD align="left"></TD>
					</tr>
					<TR>
						<TD>
							<asp:RegularExpressionValidator id="revInitial" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtInitial" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:RegularExpressionValidator></TD>
						<TD>
							<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:RegularExpressionValidator></TD>
						<TD></TD>
						<TD></TD>
						<TD align="left"></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label8" Width="150px" CssClass="standard-text" Text="Fecha Inicial *" Runat="server">Hora Inicial Recepción PT</asp:label><asp:label id="Label14" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"
								Width="113px">(HH:MM)</asp:label></TD>
						<TD><asp:label id="Label9" Width="142px" CssClass="standard-text" Text="Fecha Inicial *" Runat="server">Hora Final Recepción PT</asp:label><asp:label id="Label13" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red">(HH:MM)</asp:label></TD>
						<TD>
							<P><asp:label id="Label10" Width="106px" CssClass="standard-text" Text="Fecha Final" Runat="server">Fecha de Interfase</asp:label><asp:label id="Label11" Width="117px" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server"
									ForeColor="Red">* (dd-MMM-aaaa)</asp:label></P>
						</TD>
						<TD></TD>
						<TD align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 177px; HEIGHT: 22px"><asp:textbox id="txtHoraInical" Width="116px" CssClass="Standard-text" Runat="server" BorderStyle="Groove"
								MaxLength="5"></asp:textbox></TD>
						<TD style="WIDTH: 154px; HEIGHT: 22px"><asp:textbox id="txtHoraFinal" Width="116px" CssClass="Standard-text" Runat="server" BorderStyle="Groove"
								MaxLength="5"></asp:textbox></TD>
						<TD style="WIDTH: 166px; HEIGHT: 22px">
							<asp:textbox id="txtFechaInterfaz" Width="99px" CssClass="Standard-text" Runat="server" BorderStyle="Groove"
								MaxLength="11"></asp:textbox>
							<asp:imagebutton OnClientClick="return GetDate(document.forms[0].elements['txtFinal'].value,'txtFinal');" id="Image1" Runat="server" ImageUrl="../../../../Images/icon-calendar.gif"
								AlternateText="Final Date"></asp:imagebutton></TD>
						<TD style="HEIGHT: 22px" align="center"><asp:button id="btnSel" CssClass="botonesInput" Text="Aceptar" Runat="server"></asp:button></TD>
						<TD style="HEIGHT: 22px" align="left"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 177px; HEIGHT: 22px"></TD>
						<TD style="WIDTH: 154px; HEIGHT: 22px"></TD>
						<TD style="WIDTH: 166px; HEIGHT: 22px">
							<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" CssClass="standard-text" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								ControlToValidate="txtFechaInterfaz" ErrorMessage="Fecha incorrecta" Display="Dynamic"></asp:RegularExpressionValidator></TD>
						<TD style="HEIGHT: 22px" align="center"></TD>
						<TD style="HEIGHT: 22px" align="left"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5">
							<HR>
							&nbsp;</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="5"><asp:datalist id="lstWorkOrder" Width="700px" Runat="server">
								<HeaderTemplate>
									<TABLE id="Table12" style="BORDER-COLLAPSE: collapse" bgColor="#276187" border="1">
										<TR>
											<TD class="grid-header" width="12">
												<asp:label id="Label2" Runat="server" Width="13px"></asp:label></TD>
											<TD class="grid-header">
												<asp:CheckBox id="chkAllCheck" onclick="CheckAllDataGridCheckBoxes('chkSelect',this.value)" Runat="server"></asp:CheckBox></TD>
											<TD class="grid-header" align="left"><B>
													<asp:label id="Label6" Runat="server" Width="25px">P</asp:label></B></TD>
											<TD class="grid-header" align="left"><B>
													<asp:label id="Label7" Runat="server" Width="65px">Fecha y Hora de PT</asp:label></B></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label17" Runat="server" Width="70px">Secuencia</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label19" Runat="server" Width="30px">Cant.</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label15" Runat="server" Width="60px">Cant.Real</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label21" Runat="server" Width="30px">Med.</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label18" Runat="server" Width="70px">Orden</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label20" Runat="server" Width="50px">Material</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label22" Runat="server" Width="270px">Descripción</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label23" Runat="server" Width="30px">Línea</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label24" Runat="server" Width="60px">Estado</asp:label></TD>
											<TD class="grid-header" align="center" colSpan="2">
												<table style="border:none">
													<tr>
														<td class="grid-header" align="left">
															<asp:label id="Label12" Runat="server" Width="30px">Entrega Final</asp:label></td>
													</tr>
													<tr>
														<td class="grid-header" align="center">
															<asp:CheckBox id="chkAllEF" onclick="CheckAllDataGridCheckBoxes2()" Runat="server" Checked="True"></asp:CheckBox></td>
											</TD>
										</TR>
									</TABLE>
					</TR>
			</table>
			</HeaderTemplate>
			<ItemStyle CssClass="grid-item"></ItemStyle>
			<ItemTemplate>
				<TABLE style="BORDER-COLLAPSE: collapse" border="1">
					<TR>
						<TD align="middle" height="0px">
							<asp:label id="spacer" CssClass="standard-text" Runat="server" Width="9px"></asp:label></TD>
						<TD align="middle">
							<asp:checkbox id="chkSelect" CssClass="standard-text" Runat="server" Width="20px"></asp:checkbox></TD>
						<TD align="left">
							<asp:label id=ItemPrioridad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' Runat="server" Width="25px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id=ItemFecha CssClass="standard-text" Text='<%# String.Format("{0:dd-MMM-yy HH:mm}",DataBinder.Eval(Container, "DataItem.FechaLiberacion")) %>' Runat="server" Width="65px">
							</asp:label>
						</TD>
						<TD align="left">
							<asp:label id=ItemSecuencia CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Runat="server" Width="70px">
							</asp:label>
							<asp:label id=ItemCodigoSAP CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server" Visible="False">
							</asp:label>
							<asp:label id=ItemIdPlanta CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdPlanta") %>' Runat="server" Visible="False">
							</asp:label></TD>
						<TD align="left">
							<asp:label id=ItemCantidad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server" Width="30px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id="Label16" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>' Runat="server" Width="60px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id=ItemMedida CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.OtraMedida") %>' Runat="server" Width="30px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id="Label25" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.NoOrden") %>' Runat="server" Width="70px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id="Label26" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.codigoSAP") %>' Runat="server" Width="50px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id=ItemDescripcion CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server" Width="270px">
							</asp:label></TD>
						<TD align="left">
							<asp:label id=ItemLineaDesc CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server" Width="30px">
							</asp:label>
							<asp:label id=ItemIdLinea CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server" Visible="False">
							</asp:label></TD>
						<TD align="left">
							<asp:label id=ItemStatusDesc CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' Runat="server" Width="60px">
							</asp:label>
							<asp:label id=ItemIdStatus CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' Runat="server" Visible="False">
							</asp:label></TD>
						<TD align="center">
							<asp:checkbox id="chkEF" CssClass="standard-text" Runat="server" Width="50px" Checked="True"></asp:checkbox>
						</TD>
					</TR>
					<TR height="0px">
						<TD colSpan="10">
							<asp:datagrid id="dgdEnvioPT" style="DISPLAY: none" runat="server" Font-Names="Verdana" BorderStyle="None"
								Width="300px" CellPadding="2" BorderColor="DimGray" AutoGenerateColumns="False" Font-Name="Verdana"
								FontSize="11px" AllowSorting="True">
								<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Numero Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblNoPaquete" Text='<%# DataBinder.Eval(Container, "DataItem.PaqueteNo") %>' CssClass="standard-text" Width=60px Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblPaquete" Text='<%# DataBinder.Eval(Container, "DataItem.Paquete") %>' CssClass="standard-text" Width=160px Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Laminas por Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblLaminas" Text='<%# DataBinder.Eval(Container, "DataItem.Laminas") %>' CssClass="standard-text" Width="60px" Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tarima">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblTarima" Text='<%# DataBinder.Eval(Container, "DataItem.Tarima") %>' CssClass="standard-text" Width="100px" Runat="server">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</ItemTemplate>
			</asp:datalist></TD></TR></TBODY></TABLE><TR>
				<TD style="HEIGHT: 15px" align="right" colSpan="5">&nbsp;&nbsp;&nbsp;</TD>
			</TR>
			<TR>
				<TD></TD>
				<TD align="middle"></TD>
				<TD align="middle"></TD>
				<TD align="middle"></TD>
				<TD align="middle"></TD>
			</TR>
			<TR>
				<td>
					<table cellSpacing="4" width="900">
						<tr>
							<td align="center"><asp:button OnClientClick="return getConfirm(this.id)" id="btnLiberar" CssClass="botonesInput" Text="Liberar"
									Runat="server"></asp:button></td>
						</tr>
					</table>
				</td>
			</TR>
			</TBODY></TABLE></form>
	</body>
</HTML>
