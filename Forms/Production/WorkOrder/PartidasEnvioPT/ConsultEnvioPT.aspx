<%@ Page language="c#" Codebehind="ConsultEnvioPT.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.PartidasEnvioPT.ConsultEnvioPT" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../../../Controls/mainMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultEnvioPT</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:Literal id="ltrRefresh" runat="server"></asp:Literal>
		<LINK href="..\..\..\..\styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{   
				ChildWindow = window.open('..\\..\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			} 
			function ShowHide(CtrlName)
			{
				var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"))

				var gridtableid = index.concat("_dgdEnvioPT");
				if (document.getElementById(gridtableid).style.display != "inline")
				{
					document.getElementById(gridtableid).style.display = "inline";				
					document.getElementById(CtrlName).src= "../../../../Images/minusButton.JPG";
				}
				else
				{
					document.getElementById(gridtableid).style.display = "none";				
					document.getElementById(CtrlName).src= "../../../../Images/plusButton.JPG";
				}				
			}   
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Entrega de Producto Terminado"
			}			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ShowTitle()">
		<form id="ConsultEnvioPT" method="post" runat="server">
			<table width="700" align="center" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="left" colSpan="5" bgColor="#003366">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="5"><br>
							<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Ordenes de Trabajo - Fase de Entrega de Producto Terminado</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="lblInitial" Runat="server" Text="Fecha Inicial *" CssClass="standard-text">Fecha Inicial</asp:label><asp:label id="Label3" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red" CssClass="standard-text"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="lblFinal" Runat="server" Text="Fecha Final" CssClass="standard-text">Fecha Final</asp:label><asp:label id="Label4" Runat="server" Text="(dd-MMM-yyyy)" ForeColor="Red" CssClass="standard-text"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="Label5" Runat="server" Text="Status" CssClass="standard-text">Status</asp:label></td>
						<td><asp:label id="Label1" Runat="server" Text="Línea de Producción" CssClass="standard-text">Línea de Producción</asp:label></td>
						<td align="left"></td>
					</tr>
					<tr>
						<td><asp:textbox id="txtInitial" Runat="server" BorderStyle="Groove" CssClass="Standard-text" MaxLength="11"></asp:textbox><asp:image onmouseup="GetDate('txtInitial');" id="imgInitial" Runat="server" AlternateText="Inicial Date"
								ImageUrl="../../../../Images/icon-calendar.gif"></asp:image></td>
						<td><asp:textbox id="txtFinal" Runat="server" BorderStyle="Groove" CssClass="Standard-text" MaxLength="11"></asp:textbox><asp:image onmouseup="GetDate('txtFinal');" id="imgFinal" Runat="server" AlternateText="Final Date"
								ImageUrl="../../../../Images/icon-calendar.gif"></asp:image></td>
						<td><asp:dropdownlist id="cboStatus" Runat="server" CssClass="Standard-text" Width="100px"></asp:dropdownlist></td>
						<td><asp:dropdownlist id="cboLinea" Runat="server" CssClass="Standard-text" Width="100px"></asp:dropdownlist></td>
						<td align="left">
							<asp:button id="btnSel" Text="Aceptar" Runat="server" CssClass="botonesInput"></asp:button></td>
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
					<tr>
						<td align="center" colspan="5">
							<HR>
							&nbsp;</td>
					</tr>
					<tr>
						<td colSpan="5" align="center"><asp:datalist id="lstWorkOrder" Runat="server" Width="700px">
								<HeaderTemplate>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table12" border="1" bgColor="#276187">
										<TR>
											<TD class="grid-header" width="12">
												<asp:label id="Label2" Runat="server" Width="13px"></asp:label></TD>
											<TD class="grid-header">
												<asp:CheckBox id="chkAllCheck" Runat="server" OnCheckedChanged="checkAll" AutoPostBack="True"></asp:CheckBox></TD>
											<TD class="grid-header" align="left"><B>
													<asp:label id="Label6" Runat="server" Width="25px">P</asp:label></B></TD>
											<TD class="grid-header" align="left"><B>
													<asp:label id="Label7" Runat="server" Width="65px">Fecha</asp:label></B></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label17" Runat="server" Width="70px">Secuencia</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label18" Runat="server" Width="30px">KCT</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label19" Runat="server" Width="30px">Cant.</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label21" Runat="server" Width="30px">Med.</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label22" Runat="server" Width="270px">Descripción</asp:label></FONT></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label23" Runat="server" Width="30px">Línea</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label24" Runat="server" Width="60px">Estado</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:button style="Z-INDEX: 0" id="btnImpresion" runat="server" Text="Etiqueta" CssClass="botonesInput"
													Width="50px" Visible="True" OnClick="btnImpresion_click"></asp:button></TD>
										</TR>
									</TABLE>
								</HeaderTemplate>
								<ItemStyle CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<TABLE style="BORDER-COLLAPSE: collapse" border="1">
										<TR>
											<TD align="middle" height="0px">
												<asp:image onmouseup="ShowHide(this.id)" id="Plus" style="CURSOR: hand" Runat="server" ImageUrl="../../../../Images/plusButton.JPG"
													Visible="False"></asp:image>
												<asp:label id="spacer" CssClass="standard-text" Runat="server" Width="9px"></asp:label></TD>
											<TD align="middle">
												<asp:checkbox id="chkSelect" CssClass="standard-text" Runat="server" Width="20px"></asp:checkbox></TD>
											<TD align="left">
												<asp:label id=ItemPrioridad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' Runat="server" Width="25px">
												</asp:label></TD>
											<TD align="left">
												<asp:label id=ItemFecha CssClass="standard-text" Text='<%# String.Format("{0:dd-MMM-yy}",DataBinder.Eval(Container, "DataItem.Fecha")) %>' Runat="server" Width="65px">
												</asp:label>
												<asp:label id=ItemFechaMod CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.FechaMod") %>' Runat="server" Visible="False">
												</asp:label></TD>
											<TD align="left">
												<asp:label id=ItemSecuencia CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Runat="server" Width="70px">
												</asp:label>
												<asp:label id=ItemCodigoSAP CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server" Visible="False">
												</asp:label>
												<asp:label id=ItemIdPlanta CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdPlanta") %>' Runat="server" Visible="False">
												</asp:label></TD>
											<TD align="left">
												<asp:label id=ItemKCT CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.KCT") %>' Runat="server" Width="30px">
												</asp:label></TD>
											<TD align="left">
												<asp:label id=ItemCantidad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server" Width="30px">
												</asp:label></TD>
											<TD align="left">
												<asp:label id=ItemMedida CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.OtraMedida") %>' Runat="server" Width="30px">
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
											<TD align="left">
												<asp:ImageButton id="lnkConsult" runat="server" ImageUrl="../../../../Images/consultar.GIF" CommandName="Consult"></asp:ImageButton></TD>
											<TD align="left">
												<asp:ImageButton id="lnkMensaje" runat="server" ImageUrl="../../../../Images/Email.GIF" CommandName="Mensaje"></asp:ImageButton></TD>
											<TD align="center" width="20px">
												<asp:Image id="ImagenPiso" runat="server" ImageUrl="../../../../Images/new.GIF" Visible='<%#DataBinder.Eval(Container, "DataItem.MensajePiso")==""?false:true%>' AlternateText="Contiene Mensaje de Piso">
												</asp:Image>
										</TR>
										<TR height="0px">
											<TD colSpan="10">
												<asp:datagrid id="dgdEnvioPT" style="DISPLAY: none" runat="server" Font-Names="Verdana" BorderStyle="None"
													Width="300px" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False"
													BorderColor="DimGray" CellPadding="2">
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
							</asp:datalist></td>
					</tr>
				</TBODY>
			</table>
			<tr>
				<td style="HEIGHT: 15px" align="right" colSpan="5">&nbsp;&nbsp;&nbsp;</td>
			</tr>
			<tr>
				<td></td>
				<td align="middle"></td>
				<td align="middle"></td>
				<td align="middle"></td>
				<td align="middle"></td>
			</tr>
			</TBODY></TABLE>
		</form>
	</body>
</HTML>
