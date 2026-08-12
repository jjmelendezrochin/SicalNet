
<%@ Page language="c#" Codebehind="ConsultAditivosWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.PartidasAditivos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SICAL - Cuarto de Aditivos</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:literal id="ltrRefresh" runat="server"></asp:literal><LINK rel="stylesheet" type="text/css" href="..\..\styloDESC.CSS">
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}
			function ShowHide(CtrlName)
			{
				var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"))

				var gridtableid = index.concat("_dstLaminas");
				if (document.getElementById(gridtableid).style.display != "inline")
				{
					document.getElementById(gridtableid).style.display = "inline";				
					document.getElementById(CtrlName).src= "../../Images/minusButton.JPG";
				}
				else
				{
					document.getElementById(gridtableid).style.display = "none";				
					document.getElementById(CtrlName).src= "../../Images/plusButton.JPG";
				}				
			}
			function ShowHideAll(CtrlName)
			{
				var count=1
				if (document.getElementById(CtrlName).src.indexOf('minusButton')!= -1)
					document.getElementById(CtrlName).src= "../../Images/plusButton.JPG"
				else
					document.getElementById(CtrlName).src= "../../Images/minusButton.JPG"
				for(i=0;i<document.forms[0].length;i++)
				{
					if (document.forms[0].elements[i].name.indexOf('chkSelect') != -1)
					{
						var index="lstWorkOrder__ctl"
						var gridtableid=index.concat(count,"_dstLaminas")
						var plusid=index.concat(count,"_Plus")
						if(document.getElementById(plusid))
						{
							if (document.getElementById(gridtableid).style.display != "inline")
							{
								document.getElementById(gridtableid).style.display = "inline";				
								document.getElementById(plusid).src= "../../Images/minusButton.JPG";
							}
							else
							{
								document.getElementById(gridtableid).style.display = "none";				
								document.getElementById(plusid).src= "../../Images/plusButton.JPG";
							}							
						}
						count++
					}
				}				
			}
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Aditivos"
			}
		</script>
	</HEAD>
	<body onload="ShowTitle()" MS_POSITIONING="GridLayout">
		<form id="ConsultAditivosWO" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" align="center">
				<TBODY>
					<tr>
						<td bgColor="#003366" colSpan="5" align="left"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
					</tr>
					<tr>
						<td colSpan="5" align="center"><br>
							<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Ordenes de Trabajo - Fase de Aditivos</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="lblInitial" CssClass="standard-text" Text="Fecha" Runat="server">Fecha Inicial</asp:label><asp:label id="Label3" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="lblFinal" CssClass="standard-text" Text="Fecha" Runat="server">Fecha Final</asp:label><asp:label id="Label4" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="Label1" CssClass="standard-text" Text="Linea de Produccion" Runat="server">Linea de Produccion</asp:label></td>
						<td><asp:label id="Status" CssClass="standard-text" Text="Status" Runat="server">Status</asp:label></td>
						<td><asp:label id="Label2" CssClass="standard-text" Text="Fecha" Runat="server">Olla formulación en 1 paso:</asp:label></td>
					<tr>
						<td><asp:textbox id="txtFecha" CssClass="Standard-text" Runat="server" MaxLength="11" Width="86px"
								BorderStyle="Groove"></asp:textbox><asp:image id="imgInitial" onmouseup="GetDate('txtFecha');" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:image></td>
						<td><asp:textbox id="txtFechaFinal" CssClass="Standard-text" Runat="server" MaxLength="11" Width="86px"
								BorderStyle="Groove"></asp:textbox><asp:image id="imgFinal" onmouseup="GetDate('txtFechaFinal');" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:image></td>
						<td><asp:dropdownlist id="cboLinea" CssClass="Standard-text" Runat="server"></asp:dropdownlist></td>
						<td><asp:dropdownlist id="cboStatus" CssClass="Standard-text" Runat="server"></asp:dropdownlist></td>
						<td><asp:dropdownlist id="CmbOlla" runat="server" CssClass="Standard-text" Width="85px"></asp:dropdownlist></td>
					</tr>
					<TR>
						<TD><asp:regularexpressionvalidator id="revInitial" runat="server" CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								ControlToValidate="txtFecha" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
						<TD><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" Display="Dynamic"
								ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								ControlToValidate="txtFechaFinal" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 37px" colSpan="5" align="center">
							<hr>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 23px" align="center"><asp:button id="btnImprimirEqu" runat="server" CssClass="botonesInput" Text="Imp. Etiquetas"
								Width="98px"></asp:button><asp:button id="btnImprimirSLPC" runat="server" CssClass="botonesInput" Text="Imp. Etiquetas Color"
								Width="98px"></asp:button></td>
						<td style="HEIGHT: 23px" vAlign="middle" align="center"><asp:button id="btnRpt" CssClass="botonesInput" Text="Rep. Formulación" Runat="server" Width="104px"></asp:button>&nbsp;</td>
						<td style="HEIGHT: 23px" align="center"><asp:button id="btnCard" runat="server" CssClass="botonesInput" Text="Tarj. Form." Width="107px"></asp:button></td>
						<td style="HEIGHT: 23px" align="center"><asp:button id="btnLiberar" runat="server" CssClass="botonesInput" Text="Liberar"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnAgregar" runat="server" CssClass="botonesInput" Text="Salvar"></asp:button></td>
						<TD align="center"><asp:button id="btnSel" CssClass="botonesInput" Text="Aceptar" Runat="server"></asp:button></TD>
					</tr>
					<TR>
						<TD align="center"><asp:button id="btnPreform" runat="server" CssClass="botonesInput" Text="Preformular" Width="98px"></asp:button></TD>
						<TD vAlign="middle" align="center"><asp:checkbox id="chkSeparate" runat="server" CssClass="standard-text" Text="Páginas separadas"></asp:checkbox>&nbsp;</TD>
						<TD align="center"><asp:button id="btnDust" runat="server" CssClass="botonesInput" Text="Rep. Aditivos" Width="108px"></asp:button></TD>
						<TD align="center"></TD>
						<TD align="center"></TD>
					</TR>
					<TR>
						<TD colSpan="5" align="center">
							<hr>
						</TD>
					</TR>
					<TR>
						<TD colSpan="5" align="center"><asp:datalist id="lstWorkOrder" Runat="server" Width="700px">
								<HeaderTemplate>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table13" border="1" bgColor="#276187">
										<TR>
											<TD class="grid-header" width="12">
												<asp:image style="CURSOR: hand" id="imgPlus" onmouseup="ShowHideAll(this.id)" Runat="server"
													ImageUrl="../../Images/plusButton.JPG"></asp:image>
												<asp:label id="sp" Runat="server" Width="13px"></asp:label></TD>
											<TD class="grid-header">
												<asp:checkbox id="Checkbox2" runat="server" Width="20px" OnCheckedChanged="CheckAll" AutoPostBack="True"></asp:checkbox></TD>
											<TD class="grid-header" align="left"><B>
													<asp:label id="Label8" Runat="server" Width="25px">P</asp:label></B></TD>
											<TD class="grid-header" align="left"><B>
													<asp:label id="Label13" Runat="server" Width="65px">Fecha</asp:label></B></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label14" Runat="server" Width="70px">Secuencia</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label9" Runat="server" Width="30px">KCT</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label5" Runat="server" Width="30px">Lote</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label10" Runat="server" Width="30px">Cant.</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label15" Runat="server" Width="30px">Med.</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label11" Runat="server" Width="270px">Descripción</asp:label></FONT></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label12" Runat="server" Width="30px">Línea</asp:label></TD>
											<TD class="grid-header" align="left">
												<asp:label id="Label20" Runat="server" Width="60px">Estado</asp:label></TD>
											<TD class="grid-header" colSpan="3" align="left">
												<asp:label id="Label16" Runat="server" Width="60px"></asp:label></TD>
										</TR>
									</TABLE>
								</HeaderTemplate>
								<ItemStyle CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<TABLE style="BORDER-COLLAPSE: collapse" border="1">
										<TR>
											<TD align="center">
												<asp:image style="CURSOR: hand" id="jsPlus" onmouseup="ShowHide(this.id)" Runat="server" ImageUrl="../../Images/minusButton.JPG"
													Visible="False"></asp:image>
												<asp:label id="spacer" CssClass="standard-text" Runat="server" Width="9px"></asp:label>
												<asp:ImageButton id="aspPlus" runat="server" ImageUrl="../../Images/plusButton.JPG" Visible="False"
													CommandName="Expand"></asp:ImageButton></TD>
											<TD align="center">
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
												<asp:label id="ItemLote" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Lote") %>' Runat="server" Width="30px">
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
												<asp:ImageButton id="lnkConsult" runat="server" ImageUrl="../../Images/consultar.GIF" CommandName="Consult"></asp:ImageButton></TD>
											<TD align="left">
												<asp:ImageButton id="lnkMensaje" runat="server" ImageUrl="../../Images/Email.GIF" CommandName="Mensaje"></asp:ImageButton></TD>
											<TD align="left">
												<asp:Image id=ImagenPiso runat="server" ImageUrl="../../Images/new.GIF" AlternateText="Contiene Mensaje de Piso" Visible='<%#DataBinder.Eval(Container, "DataItem.MensajePiso")==""?false:true %>'>
												</asp:Image></TD>
										</TR>
										<TR>
											<TD colSpan="2"></TD>
											<TD colSpan="11">
												<asp:datalist style="DISPLAY: inline" id="dstLaminas" Runat="server" Visible="False">
													<ItemStyle CssClass="grid-first-item" Height="0px" Font-Size="2"></ItemStyle>
													<ItemTemplate>
														<table id="GridTable" runat="server" height="0px">
															<tr>
																<td>
																	<asp:Label ID="Label2" Text='Olla ' CssClass="standard-text" Runat="server" Font-Bold="True"></asp:Label>
																	<asp:Label ID="lblVaso" Text='<%# DataBinder.Eval(Container, "DataItem.NumeroOlla") %>' CssClass="standard-text" Runat="server" Font-Bold=True>
																	</asp:Label>
																	<asp:Label ID="Label3" Text='- LAMINAS:' CssClass="standard-text" Runat="server" Font-Bold="True"></asp:Label>
																	<asp:Label ID="lblLaminas" text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>' CssClass="standard-text" Runat="server" Font-Bold=True>
																	</asp:Label>
																</td>
															</tr>
															<tr>
																<td>
																	<asp:datagrid id="dgdAditivos" runat="server" Width="600px" Font-Names="Verdana" CellPadding="2"
																		BorderColor="DimGray" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True"
																		BorderStyle="None">
																		<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn HeaderText="Material">
																				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id=AditivosCodigoSAP Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="Descripci&#243;n">
																				<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="AditivosDescripcion" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text" Runat="server">
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="% peso">
																				<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="lblPorPeso" Text='<%# DataBinder.Eval(Container, "DataItem.PorcentajePeso") %>' CssClass="standard-text" Runat="server">
																					</asp:label><font class="standard-text">%</font>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="Cantidad">
																				<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="AditivosCantidad" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server">
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="Cantidad Real">
																				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:TextBox id=txtCantidadReal CssClass="Standard-Text" Runat="server" Width="100px" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
																					</asp:TextBox>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn Visible="False" HeaderText="Cantidad Real">
																				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label ID="lblCantidadReal" CssClass="standard-text" Runat=server Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="Folio">
																				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:TextBox id=txtFolio BorderStyle="Groove" CssClass="Standard-Text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LoteReferencia") %>'>
																					</asp:TextBox>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn Visible="False" HeaderText="Folio">
																				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id=lblFolio Width="100px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LoteReferencia") %>'>
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn Visible="False" HeaderText="Capacidad Olla">
																				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="lblCapacidadOlla" Width="100px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CapacidadOlla") %>'>
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid>
																</td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:datalist></TD>
										</TR>
									</TABLE>
								</ItemTemplate>
							</asp:datalist></TD>
					</TR>
					<TR>
						<TD align="center">&nbsp;&nbsp;
						</TD>
						<TD align="center"></TD>
						<TD align="center"></TD>
						<TD align="center"></TD>
						<TD align="center"></TD>
					</TR>
				</TBODY>
			</table>
			&nbsp;
		</form>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
