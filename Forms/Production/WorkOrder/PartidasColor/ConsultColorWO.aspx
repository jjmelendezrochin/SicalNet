<%@ Page language="c#" Codebehind="ConsultColorWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ColorRoom.ConsultColorWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SICAL - Cuarto de Color</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:literal id="ltrRefresh" runat="server"></asp:literal>
		<link rel="stylesheet" type="text/css" href="/SicalNet/Css/sical-menu.css">
		<script type="text/javascript" src="/SicalNet/Scripts/sical-menu.js"></script>
		
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->
		<script language="javascript">		
			function GetDate(CtrlName)        
			{   
				ChildWindow = window.open('..\\..\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}    

			function ShowHide(CtrlName)
			{
				
				var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"))
				var gridtableid = index.concat("_dstLaminas");

												
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
			function ShowHideAll(CtrlName)
			{
				var count=1
				if (document.getElementById(CtrlName).src.indexOf('minusButton')!= -1)
					document.getElementById(CtrlName).src= "../../../../Images/plusButton.JPG"
				else
					document.getElementById(CtrlName).src= "../../../../Images/minusButton.JPG"
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
								document.getElementById(plusid).src= "../../../../Images/minusButton.JPG";
							}
							else
							{
								document.getElementById(gridtableid).style.display = "none";				
								document.getElementById(plusid).src= "../../../../Images/plusButton.JPG";
							}							
						}
						count++
					}
				}				
			}
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Color"
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
		<form id="ConsultColorWO" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" border="0" width="800" align="center">
				<TBODY>
					<tr>
						<td colSpan="6" align="left">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td colSpan="6" align="center"><br>
							<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Ordenes de Trabajo - Fase de Color</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="lblInitial" Runat="server" Text="Fecha Inicial *" CssClass="standard-text">Fecha Inicial</asp:label><asp:label id="Label3" Runat="server" Text="(dd-MMM-yyyy)" CssClass="standard-text" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="lblFinal" Runat="server" Text="Fecha Final" CssClass="standard-text">Fecha Final</asp:label><asp:label id="Label4" Runat="server" Text="(dd-MMM-yyyy)" CssClass="standard-text" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
						<td><asp:label id="Label5" Runat="server" Text="Status" CssClass="standard-text">Status</asp:label></td>
						<td><asp:label id="Label1" Runat="server" Text="Línea de Producción" CssClass="standard-text">Línea de Producción</asp:label></td>
						<td><asp:label id="Label7" Runat="server" Text="Color" CssClass="standard-text">Color</asp:label></td>
						<td><asp:label id="Label21" Runat="server" Text="Aforo" CssClass="standard-text">Aforo</asp:label></td>
					</tr>
					<tr>
						<td><asp:textbox id="txtInitial" Runat="server" CssClass="Standard-text" BorderStyle="Groove" MaxLength="11"></asp:textbox>
							<asp:image id="imgInitial" onmouseup="GetDate('txtInitial');" Runat="server" AlternateText="Inicial Date"
								ImageUrl="../../../../Images/icon-calendar.gif"></asp:image></td>
						<td><asp:textbox id="txtFinal" Runat="server" CssClass="Standard-text" BorderStyle="Groove" MaxLength="11">
						    </asp:textbox><asp:image id="imgFinal" onmouseup="GetDate('txtFinal');" Runat="server" AlternateText="Final Date"
								ImageUrl="../../../../Images/icon-calendar.gif"></asp:image></td>
						<td><asp:dropdownlist id="cboStatus" Runat="server" CssClass="Standard-text" Width="100px"></asp:dropdownlist></td>
						<td><asp:dropdownlist id="cboLinea" Runat="server" CssClass="Standard-text" Width="100px"></asp:dropdownlist></td>
						<td align="left"><asp:dropdownlist id="cboColor" Runat="server" CssClass="Standard-text" Width="100px"></asp:dropdownlist></td>
						<td><asp:textbox id="txtAforo" runat="server" CssClass="Standard-text" BorderStyle="Groove" Width="36px">0</asp:textbox><br>
						</td>
					</tr>
					<TR>
						<TD><asp:regularexpressionvalidator id="revInitial" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtInitial" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:regularexpressionvalidator></TD>
						<TD><asp:regularexpressionvalidator id="revFinal" runat="server" CssClass="standard-text" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtFinal" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:regularexpressionvalidator></TD>
						<TD></TD>
						<TD></TD>
						<TD align="left"></TD>
						<TD><asp:regularexpressionvalidator id="revAforo" runat="server" CssClass="standard-text" ErrorMessage="Ingrese números"
								ControlToValidate="txtAforo" ValidationExpression="^[0-9]$" Display="Dynamic"></asp:regularexpressionvalidator></TD>
					</TR>
					<tr>
						<td colSpan="6">
							<hr>
						</td>
					</tr>
					<tr>
						<td align="center"><asp:button id="btnImprimirEqu" runat="server" Text="Imp. Etiquetas" CssClass="botonesInput"
								Width="98px" Visible="False"></asp:button></td>
						<td align="center"><asp:button id="btnRpt" runat="server" Text="Rep. Formulación" CssClass="botonesInput" Width="124px"
								Visible="False"></asp:button>&nbsp;</td>
						<td align="center"><asp:button id="btnCard" runat="server" Text="Tarj. Formulación" CssClass="botonesInput" Width="124px"
								Visible="False"></asp:button></td>
						<td align="center"><asp:button id="btnLiberado" runat="server" Text="Liberar" CssClass="botonesInput" Visible="False"></asp:button></td>
						<td align="center"><asp:button id="btnAgregar" runat="server" Text="Salvar" CssClass="botonesInput" Visible="False"></asp:button></td>
						<td align="center"><asp:button id="btnSel" Runat="server" Text="Aceptar" CssClass="botonesInput"></asp:button></td>
					</tr>
					<TR>
						<TD style="HEIGHT: 1px" align="center"><asp:button id="btnPreform" runat="server" Text="Preformular" CssClass="botonesInput" Width="98px"
								Visible="False"></asp:button></TD>
						<TD style="HEIGHT: 1px" align="center"><asp:checkbox id="chkSeparate" runat="server" Text="Páginas separadas" CssClass="standard-text"
								Visible="False"></asp:checkbox></TD>
						<TD style="HEIGHT: 1px" align="center"></TD>
						<TD style="HEIGHT: 1px" align="center"></TD>
						<TD style="HEIGHT: 1px" align="center"></TD>
						<TD style="HEIGHT: 1px"></TD>
					</TR>
					<tr>
						<td colSpan="6">
							<hr>
						</td>
					</tr>
					<tr>
						<td colSpan="6" align="center"><asp:datalist id="lstWorkOrder" Runat="server" CssClass="standard-text" Width="700px">
								<HeaderTemplate>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table13" border="1" bgColor="#276187">
										<TR>
											<TD class="grid-header" width="12"><asp:image style="CURSOR: hand" id="imgPlus" onmouseup="ShowHideAll(this.id)" Runat="server"
													ImageUrl="../../../../Images/plusButton.JPG"></asp:image></TD>
											<TD class="grid-header"><asp:checkbox id="Checkbox2" runat="server" Width="20px" OnCheckedChanged="checkAll" AutoPostBack="True"></asp:checkbox></TD>
											<TD class="grid-header" align="left"><B><asp:label id="Label8" Runat="server" Width="25px">P</asp:label></B></TD>
											<TD class="grid-header" align="left"><B><asp:label id="Label13" Runat="server" Width="65px">Fecha</asp:label></B></TD>
											<TD class="grid-header" align="left"><asp:label id="Label14" Runat="server" Width="70px">Secuencia</asp:label></TD>
											<TD class="grid-header" align="left"><asp:label id="Label9" Runat="server" Width="30px">KCT</asp:label></TD>
											<TD class="grid-header" align="left"><asp:label id="Label10" Runat="server" Width="30px">Cant.</asp:label></TD>
											<TD class="grid-header" align="left"><asp:label id="Label15" Runat="server" Width="30px">Med.</asp:label></TD>
											<TD class="grid-header" align="left"><asp:label id="Label11" Runat="server" Width="270px">Descripción</asp:label></FONT></TD>
											<TD class="grid-header" align="left"><asp:label id="Label12" Runat="server" Width="30px">Línea</asp:label></TD>
											<TD class="grid-header" align="left"><asp:label id="Label20" Runat="server" Width="60px">Estado</asp:label></TD>
											<TD class="grid-header" colSpan="3" align="left"><asp:label id="Label16" Runat="server" Width="60px"></asp:label></TD>
										</TR>
									</TABLE>
								</HeaderTemplate>
								<ItemStyle CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<TABLE style="BORDER-COLLAPSE: collapse" border="1">
										<TBODY>
											<TR>
												<TD align="center">
													<asp:image onmouseup="ShowHide(this.id)" id="jsPlus" style="CURSOR: hand" Runat="server" ImageUrl="../../../../Images/minusButton.JPG"
														Visible="False"></asp:image>
													<asp:label id="spacer" CssClass="standard-text" Runat="server" Width="9px"></asp:label>
													<asp:imagebutton id="aspPlus" runat="server" ImageUrl="../../../../Images/plusButton.JPG" Visible="False"
														CommandName="Expand"></asp:imagebutton></TD>
						</td>
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
							<asp:imagebutton id="lnkConsult" runat="server" ImageUrl="../../../../Images/consultar.GIF" CommandName="Consult"></asp:imagebutton></TD>
						<TD align="left">
							<asp:imagebutton id="lnkMensaje" runat="server" ImageUrl="../../../../Images/Email.GIF" CommandName="Mensaje"></asp:imagebutton></TD>
						<TD align="left">
							<asp:image id="ImagenPiso" runat="server" ImageUrl="../../../../Images/new.GIF" Visible='<%#DataBinder.Eval(Container, "DataItem.MensajePiso")==""?false:true%>' AlternateText="Contiene Mensaje de Piso">
							</asp:image></TD>
					</tr>
					<TR>
						<TD colSpan="2"></TD>
						<TD colSpan="11">
							<asp:datalist id="dstLaminas" style="DISPLAY: inline" Visible="False" CssClass="standard-text"
								Runat="server">
								<ItemStyle Font-Size="2pt" Height="0px"></ItemStyle>
								<ItemTemplate>
									<table id="GridTable" runat="server">
										<tr height="0px">
											<td>
												<asp:Label ID="Label2" Text='Vaso ' Runat="server" Font-Bold="True" CssClass="standard-text"></asp:Label>
												<asp:Label ID="lblVaso" Text='<%# DataBinder.Eval(Container, "DataItem.VasoNo") %>' Runat="server" Font-Bold=True CssClass="standard-text" >
												</asp:Label>
												<asp:Label ID="Label6" Text='- LAMINAS:' CssClass="standard-text" Runat="server" Font-Bold="True"></asp:Label>
												<asp:Label ID="lblLaminas" text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>' CssClass="standard-text" Runat="server" Font-Bold=True>
												</asp:Label>
												<asp:Label ID="Label17" Text='    AFORO:' CssClass="standard-text" Runat="server" Font-Bold="True"></asp:Label>
												<asp:Label ID="Label18" text='<%# DataBinder.Eval(Container, "DataItem.Aforo") %>' CssClass="standard-text" Runat="server" Font-Bold=True>
												</asp:Label>
											</td>
										</tr>
										<tr height="0px">
											<td>
												<asp:datagrid id="dgdColorWO" runat="server" Font-Names="Verdana" CellPadding="2" BorderColor="DimGray"
													AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderStyle="None"
													Width="600px">
													<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Material">
															<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblCodigoSAP" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text" Width=60px Runat="server">
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n">
															<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblDescripcion" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text" Width="200px" Runat="server">
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Grupo">
															<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblGrupo" Text='<%# DataBinder.Eval(Container, "DataItem.Grupo") %>' CssClass="standard-text" Width="50px" Runat="server">
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cantidad">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblCantidad" Text='<%# String.Format("{0:f3}",DataBinder.Eval(Container, "DataItem.Cantidad"))%>' CssClass="standard-text" Runat="server">
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Registro">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox id=txtRegistro BorderStyle="Groove" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>' >
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False" HeaderText="Registro">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblRegistro Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>' CssClass="standard-text">
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Lote de Pasta">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox id=txtlotePasta CssClass="Standard-text" Runat="server" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.LotePasta") %>' >
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False" HeaderText="Lote Pasta">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblLotePasta" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotePasta") %>' CssClass="standard-text">
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
				</TBODY>
			</table>
			</ItemTemplate> </asp:datalist></TD></TR>
			<tr>
				<td style="HEIGHT: 15px" colSpan="6" align="right">&nbsp;&nbsp;&nbsp;</td>
			</tr>
			<tr>
				<td></td>
				<td align="center"></td>
				<td align="center"></td>
				<td align="center"></td>
				<td align="center"></td>
				<td></td>
			</tr>
			</TBODY></TABLE></form>
	</body>
</HTML>
