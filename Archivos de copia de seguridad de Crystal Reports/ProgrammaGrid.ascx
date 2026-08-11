<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ProgrammaGrid.ascx.cs" Inherits="UserInterface.Controls.ProgrammaGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
<meta name="vs_defaultClientScript" content="JavaScript">
<script language="javascript">
	
function GetDate()        
{   
   var txtFechaValue = document.forms[0].elements['grdProgram_txtFecha'].value;
	ChildWindow = window.open('../Production/Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=grdProgram_txtFecha' + '&txtDate=' + txtFechaValue, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
}

function OperacionBorrar(Button,strOperationType){
	Button.click();
}

function ConfirmOperation(Button,strOperationType)
{	
	if (confirm("¿Está seguro que desea " +strOperationType+ " esta secuencia?")) 
	{
		Button.click();
	}
}

function ShowHide(CtrlName)
{
	var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"))
	var gridtableid = index.concat("_SequenceDetails");
	if (document.getElementById(gridtableid).style.display != "inline") 
	{
		document.getElementById(gridtableid).style.display = "inline";				
		document.getElementById(CtrlName).src= "../../images/minusButton.jpg";
	}
	else
	{
		document.getElementById(gridtableid).style.display = "none";				
		document.getElementById(CtrlName).src="../../images/plusButton.jpg";
	}				
}
</script>
<TABLE id="Table1" border="0">
	<TBODY>
		<TR vAlign="top">
			<TD colSpan="3" align="center">
				<TABLE style="HEIGHT: 40px; WIDTH: 521px" id="Table2">
					<TR>
						<TD><asp:label id="lblLinea" CssClass="standard-text" Text="Linea de produccion" Runat="server">Linea de producción</asp:label></TD>
						<TD><asp:label id="IdLote" CssClass="standard-text" Text="Número de Lote" Runat="server">Número de Lote</asp:label></TD>
						<TD><asp:label id="lblDate" CssClass="standard-text" Text="Fecha del Programma" Runat="server">Fecha del Programa</asp:label><asp:label id="Label3" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></TD>
					</TR>
					<TR>
						<TD><asp:dropdownlist id="ddlIdLinea" CssClass="standard-text" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlLote" CssClass="standard-text" Runat="server"></asp:dropdownlist></TD>
						<TD colSpan="2">
							<center><asp:textbox id="txtFecha" CssClass="Standard-text" Runat="server" BorderStyle="Groove" Width="77px"
									MaxLength="11"></asp:textbox><asp:image id="imgInitial" onmouseup="GetDate();" Runat="server" ImageUrl="../Images/icon-calendar.gif"
									AlternateText="Inicial Date"></asp:image><asp:regularexpressionvalidator id="revFecha" CssClass="standard-text" runat="server" ErrorMessage="Fecha incorrecta"
									ControlToValidate="txtFecha" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
									Display="Dynamic"></asp:regularexpressionvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="btnSel" CssClass="botonesInput" Text="Aceptar" Runat="server"></asp:button></center>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD colSpan="3"><asp:datalist id="lstProgram" runat="server">
					<HeaderTemplate>
						<table style="BORDER-COLLAPSE: collapse" id="Table7" border="1" cellSpacing="1" borderColor="#000000"
							cellPadding="1">
							<TR>
								<TD>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table9" border="1" cellSpacing="1" borderColor="white"
										cellPadding="1" bgColor="#276187">
										<TR>
											<TD width="38" colSpan="2">&nbsp;</TD>
											<TD><asp:label id="Label5" CssClass="standard-text" ForeColor="White" Width="20px" runat="server">P</asp:label></TD>
											<TD><asp:label id="Label8" CssClass="standard-text" ForeColor="White" Width="60px" runat="server">Fecha</asp:label></TD>
											<TD><asp:label id="Label9" CssClass="standard-text" ForeColor="White" Width="25px" runat="server">KCT</asp:label></TD>
											<TD><asp:label id="Label10" CssClass="standard-text" ForeColor="White" Width="35px" runat="server">Línea</asp:label></TD>
											<TD><asp:label id="Label12" CssClass="standard-text" ForeColor="White" Width="60px" runat="server">Secuencia</asp:label></TD>
											<TD><asp:label id="Label13" CssClass="standard-text" ForeColor="White" Width="40px" runat="server">Corrida</asp:label></TD>
											<TD><asp:label id="Label15" CssClass="standard-text" ForeColor="White" Width="35px" runat="server">Lote</asp:label></TD>
											<TD><asp:label id="Label24" CssClass="standard-text" ForeColor="White" Width="30px" runat="server">Cant.</asp:label></TD>
											<TD><asp:label id="Label25" CssClass="standard-text" ForeColor="White" Width="45px" runat="server">Material</asp:label></TD>
											<TD><asp:label id="Label26" CssClass="standard-text" ForeColor="White" Width="235px" runat="server">Descripción</asp:label></TD>
											<TD><asp:label id="Label27" CssClass="standard-text" ForeColor="White" Width="60px" runat="server">Área actual</asp:label></TD>
											<TD><asp:label id="Label28" CssClass="standard-text" ForeColor="White" Width="40px" runat="server">Editar</asp:label></TD>
											<TD><asp:label id="Label40" CssClass="standard-text" ForeColor="White" Width="13px" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</HeaderTemplate>
					<FooterTemplate>
						<TABLE style="BORDER-COLLAPSE: collapse" id="Table12" border="1" cellSpacing="1" borderColor="#000000"
							cellPadding="1">
							<TR>
								<TD>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table13" border="1" cellSpacing="1" borderColor="white"
										cellPadding="1" bgColor="#dedfde">
										<TR>
											<TD><asp:imagebutton id="Imagebutton3" Width="9px" runat="server"></asp:imagebutton></TD>
											<TD><asp:textbox id="txtPrioridad" CssClass="standard-text" BorderStyle="Groove" Width="20px" MaxLength="3"
													runat="server" ToolTip="Proporcione la prioridad de fabricación de la secuencia"></asp:textbox></TD>
											<TD><asp:label id=lblNewFecha CssClass="standard-text" Width="60px" runat="server" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>'></asp:label></TD>
											<TD><asp:label id=lkct CssClass="standard-text" Width="25px" runat="server" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>'></asp:label></TD>
											<TD><asp:label id="lblNewLine" CssClass="standard-text" Width="35px" runat="server"></asp:label></TD>
											<TD><asp:label id=lblNewSequence CssClass="standard-text" ForeColor="Crimson" Width="60px" runat="server" Font-Bold="True" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>'></asp:label></TD>
											<TD><asp:textbox id="txtCorrida" CssClass="standard-text" BorderStyle="Groove" Width="40px" MaxLength="5"
													runat="server"></asp:textbox></TD>
											<TD><asp:dropdownlist id="cboLote" CssClass="standard-text" Width="47px" runat="server"></asp:dropdownlist></TD>
											<TD align="right"><asp:textbox id="txtCantidad" CssClass="standard-text" BorderStyle="Groove" Width="30px" MaxLength="5"
													runat="server"></asp:textbox></TD>
											<TD><asp:textbox id="txtCodigoSAP" CssClass="standard-text" BorderStyle="Groove" Width="45px" MaxLength="18"
													runat="server" OnTextChanged="CodigoSAPChanged" AutoPostBack="True"></asp:textbox></TD>
											<TD><asp:label id="lblNewDescription" CssClass="standard-text" Width="235px" runat="server"></asp:label></TD>
											<TD><asp:label id=lblNewStatus CssClass="standard-text" Width="60px" runat="server" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>'></asp:label></TD>
											<TD>
												<table id="Table14" border="0" width="40">
													<TBODY>
														<tr>
															<td><asp:imagebutton id="Imagebutton4" onmouseup="ConfirmOperation(this,'agregar');" ImageUrl="../images/icon-floppy.gif"
																	runat="server" CommandName="Save"></asp:imagebutton><asp:imagebutton id="Imagebutton5" ImageUrl="../images/icon-pencil-x.gif" runat="server" CommandName="CancelNew"></asp:imagebutton></td>
														</tr>
													</TBODY>
												</table>
											</TD>
											<TD><asp:label id="Label58" CssClass="standard-text" Width="20px" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table15" border="0" cellSpacing="1" cellPadding="1" runat="server">
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>
												<TABLE style="BORDER-COLLAPSE: collapse" id="Table16" border="1" cellSpacing="1" borderColor="black"
													cellPadding="1">
													<TR>
														<TD bgColor="#dedfde"><asp:label id="Label59" CssClass="standard-text" Width="40px" runat="server">Orden</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label60" CssClass="standard-text" Width="70px" runat="server">Pedido</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label61" CssClass="standard-text" Width="70px" runat="server">Lote Insp</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label62" CssClass="standard-text" Width="40px" runat="server">Rendimiento</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label63" CssClass="standard-text" Width="150px" runat="server">Cliente</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label64" CssClass="standard-text" Width="100px" runat="server">Fecha Embarque</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label65" CssClass="standard-text" Width="150px" runat="server">Status</asp:label></TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtOrden" CssClass="standard-text" BorderStyle="Groove" Width="40px" MaxLength="50"
																runat="server"></asp:textbox></TD>
														<TD><asp:textbox id="txtPedido" CssClass="standard-text" BorderStyle="Groove" Width="70px" MaxLength="10"
																runat="server"></asp:textbox></TD>
														<TD align="left"><asp:textbox id="txtLoteInsp" CssClass="standard-text" BorderStyle="Groove" Width="70px" MaxLength="50"
																runat="server"></asp:textbox></TD>
														<TD align="left"><asp:textbox id="txtRendimiento" CssClass="standard-text" BorderStyle="Groove" Width="40px" MaxLength="3"
																runat="server"></asp:textbox></TD>
														<TD><asp:textbox id="txtCliente" CssClass="standard-text" BorderStyle="Groove" Width="150px" MaxLength="10"
																runat="server"></asp:textbox></TD>
														<TD><asp:textbox id="txtFechaEmb" CssClass="standard-text" BorderStyle="Groove" Width="100px" MaxLength="20"
																runat="server"></asp:textbox></TD>
														<TD><asp:label id=lblNewArea CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdArea") %>' Width="150px" runat="server" Visible="False"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>
												<TABLE style="BORDER-COLLAPSE: collapse" id="Table17" border="1" cellSpacing="1" borderColor="black"
													cellPadding="1">
													<TR>
														<TD bgColor="#dedfde"><asp:label id="Label67" CssClass="standard-text" Width="100px" runat="server">Tipo Molde</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label68" CssClass="standard-text" Width="200px" runat="server">Detalle Operación</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label69" CssClass="standard-text" Width="200px" runat="server">Comentarios</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label70" CssClass="standard-text" Width="200px" runat="server">Bitácora de Piso</asp:label></TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtTipoMolde" CssClass="standard-text" BorderStyle="Groove" Width="100px" MaxLength="3"
																runat="server"></asp:textbox></TD>
														<TD><asp:textbox id="txtDetalleOp" CssClass="standard-text" BorderStyle="Groove" Width="200px" MaxLength="200"
																runat="server"></asp:textbox></TD>
														<TD align="left"><asp:textbox id="txtComentarios" CssClass="standard-text" BorderStyle="Groove" Width="200px"
																MaxLength="25" runat="server"></asp:textbox></TD>
														<TD align="left"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</FooterTemplate>
					<ItemTemplate>
						<TABLE style="BORDER-COLLAPSE: collapse" id="Table8" border="1" cellSpacing="1" borderColor="#000000"
							cellPadding="1">
							<TR>
								<TD>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table11" border="1" cellSpacing="1" borderColor="white"
										cellPadding="1">
										<TR>
											<td><input id="chkBorrar" type="checkbox" runat="server">
											</td>
											<TD><asp:image id="Imagebutton2" onmouseup="ShowHide(this.id)" ImageUrl="../images/plusButton.jpg"
													runat="server"></asp:image></TD>
											<TD><asp:label id=lblPrioridad Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' CssClass="standard-text" Width="20px" runat="server"></asp:label><asp:textbox id="txtPriority" CssClass="standard-text" MaxLength="3" Width="25px" runat="server"
													Visible="False"></asp:textbox></TD>
											<TD><asp:label id=lblFecha Text='<%# DataBinder.Eval(Container, "DataItem.Fecha") %>' CssClass="standard-text" Width="60px" runat="server">
												</asp:label><asp:label id=ItemFechaMod Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FechaMod") %>' CssClass="standard-text" Visible="false">
												</asp:label></TD>
											<TD><asp:label id=Label6 Text='<%# DataBinder.Eval(Container, "DataItem.KCT") %>' CssClass="standard-text" Width="25px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label7 Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' CssClass="standard-text" Width="35px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=lblSecuencia Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' CssClass="standard-text" Width="60px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label11 Text='<%# DataBinder.Eval(Container, "DataItem.Corrida") %>' CssClass="standard-text" Width="40px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=lblLote Text='<%# DataBinder.Eval(Container, "DataItem.NumeroLote") %>' CssClass="standard-text" Width="35px" runat="server">
												</asp:label></TD>
											<TD align="right"><asp:label id=lblCantidad Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="standard-text" Width="30px" runat="server"></asp:label><asp:textbox id="txtQuantity" CssClass="standard-text" Width="30px" runat="server" Visible="False"></asp:textbox></TD>
											<TD><asp:label id=Label14 Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text" Width="45px" runat="server"></asp:label></TD>
											<TD><asp:label id=lblMaterialDesc Text='<%# DataBinder.Eval(Container, "DataItem.MaterialDesc") %>' CssClass="standard-text" Width="235px" runat="server"></asp:label></TD>
											<TD>
												<!--
												<asp:label id=Label16 Text='<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' CssClass="standard-text" Width="60px" runat="server" Visible="true">
												</asp:label>
											-->
												<asp:label id=Label17 Text='<%# DataBinder.Eval(Container, "DataItem.AreaDesc") %>' CssClass="standard-text" Width="60px" runat="server">
												</asp:label>
											</TD>
											<TD>
												<table id="buttonsTable" border="0" width="40">
													<TBODY>
														<tr>
															<td><asp:imagebutton id="cmdEdit" ImageUrl="../images/icon-pencil.gif" runat="server" CommandName="Edit"></asp:imagebutton><asp:imagebutton id="cmdDelete" onmouseup="OperacionBorrar(this,'eliminar');" ImageUrl="../images/icon-delete.gif"
																	runat="server" CommandName="Delete"></asp:imagebutton><asp:imagebutton id="cmdUpdate" onmouseup="ConfirmOperation(this,'actualizar');" ImageUrl="../images/icon-floppy.gif"
																	runat="server" Visible="False" CommandName="Update"></asp:imagebutton><asp:imagebutton id="cmdCancel" ImageUrl="../images/icon-pencil-x.gif" runat="server" Visible="False"
																	CommandName="Cancel"></asp:imagebutton></td>
											</TD>
										</TR>
									</TABLE>
								<TD><asp:image id=Image1 AlternateText="Consulte la bitácora de esta secuencia" ImageUrl="../images/New.gif" runat="server" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length>0 %>'>
									</asp:image><asp:label id=Label43 CssClass="standard-text" ForeColor="White" Width="13px" runat="server" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>'>
									</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE style="DISPLAY: none" id="SequenceDetails" border="0" cellSpacing="1" cellPadding="1"
							runat="server">
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<TABLE style="BORDER-COLLAPSE: collapse" border="1" cellSpacing="1" borderColor="black"
										cellPadding="1">
										<TR>
											<TD bgColor="#dedfde"><asp:label id="Label18" CssClass="standard-text" Width="40px" runat="server">Orden</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label19" CssClass="standard-text" Width="70px" runat="server">Pedido</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label20" CssClass="standard-text" Width="70px" runat="server">Lote Insp</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label21" CssClass="standard-text" Width="40px" runat="server">Rendimiento</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label22" CssClass="standard-text" Width="150px" runat="server">Cliente</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label23" CssClass="standard-text" Width="100px" runat="server">Fecha Emb</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label33" CssClass="standard-text" Width="150px" runat="server">Area actual</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id=Label35 Text='<%# DataBinder.Eval(Container, "DataItem.NoOrden") %>' CssClass="standard-text" Width="40px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label36 Text='<%# DataBinder.Eval(Container, "DataItem.Pedido") %>' CssClass="standard-text" Width="70px" runat="server">
												</asp:label></TD>
											<TD align="left"><asp:label id=Label37 Text='<%# DataBinder.Eval(Container, "DataItem.LoteInspeccion") %>' CssClass="standard-text" Width="70px" runat="server">
												</asp:label></TD>
											<TD align="right"><asp:label id=Label86 Text='<%# DataBinder.Eval(Container, "DataItem.Rendimiento") %>' CssClass="standard-text" Width="40px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label87 Text='<%# DataBinder.Eval(Container, "DataItem.Cliente") %>' CssClass="standard-text" Width="150px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label88 Text='<%# DataBinder.Eval(Container, "DataItem.FechaEmbarque") %>' CssClass="standard-text" Width="100px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label89 Text='<%# DataBinder.Eval(Container, "DataItem.IdArea") %>' CssClass="standard-text" Width="150px" runat="server" Visible="False">
												</asp:label><asp:label id=Label90 Text='<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' CssClass="standard-text" Width="150px" runat="server">
												</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<TABLE style="BORDER-COLLAPSE: collapse" id="Table19" border="1" cellSpacing="1" borderColor="black"
										cellPadding="1">
										<TR>
											<TD bgColor="#dedfde"><asp:label id="Label91" CssClass="standard-text" Width="100px" runat="server">Tipo Molde</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label92" CssClass="standard-text" Width="200px" runat="server">Detalle Operación</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label93" CssClass="standard-text" Width="200px" runat="server">Comentarios</asp:label></TD>
											<TD bgColor="#dedfde"><asp:label id="Label94" CssClass="standard-text" Width="200px" runat="server">Bitácora de Piso</asp:label></TD>
										</TR>
										<TR>
											<TD><asp:label id=Label95 Text='<%# DataBinder.Eval(Container, "DataItem.TipoMolde") %>' CssClass="standard-text" Width="100px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label96 Text='<%# DataBinder.Eval(Container, "DataItem.DetalleOperacion") %>' CssClass="standard-text" Width="200px" runat="server">
												</asp:label></TD>
											<TD align="left"><asp:label id=Label97 Text='<%# DataBinder.Eval(Container, "DataItem.Comentarios") %>' CssClass="standard-text" Width="200px" runat="server">
												</asp:label></TD>
											<TD align="left"><asp:label id=Label98 Text='<%# DataBinder.Eval(Container, "DataItem.Bitacora") %>' CssClass="standard-text" Width="200px" runat="server">
												</asp:label><BR>
												<asp:linkbutton id="Linkbutton2" runat="server" CommandName="AddMessage">Agregar mensaje a la bitácora...</asp:linkbutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE></TD>
		</TR>
	</TBODY>
</TABLE>
</ItemTemplate> </asp:datalist></TD></TR>
<TR>
	<TD colSpan="3" align="center">
		<TABLE id="Table18" border="0" cellSpacing="1" cellPadding="1" width="50">
			<TR>
				<TD><asp:button id="cmdAdd" CssClass="botonesInput" Text="Agregar Secuencia" Width="130px" runat="server"></asp:button></TD>
				<TD><asp:button id="btnCancelarSecuencias" CssClass="botonesInput" Text="Borrar Secuencia(s)" Width="130px"
						runat="server"></asp:button></TD>
				<TD><asp:button id="cmdprint" CssClass="botonesInput" Text="Imprimir" Runat="server"></asp:button></TD>
				<TD><asp:button id="cmdCancelar" CssClass="botonesInput" Text="Cancelar" Runat="server"></asp:button></TD>
			</TR>
		</TABLE>
	</TD>
</TR>
</TD>
<TR>
	<TD colSpan="3"><asp:label id="lblmsg" CssClass="standard-text" ForeColor="Red" runat="server" Font-Bold="True"></asp:label></TD>
</TR>
</TBODY></TABLE>
<P></P>
