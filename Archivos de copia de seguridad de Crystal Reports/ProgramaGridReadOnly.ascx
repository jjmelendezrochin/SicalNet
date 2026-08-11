<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ProgramaGridReadOnly.ascx.cs" Inherits="UserInterface.Controls.ProgramaGridReadOnly" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<meta content="JavaScript" name="vs_defaultClientScript">
<script language="javascript">

function funcionEnCuestion(obj) {
    do {
        obj=obj.parentNode;
    } while(obj.tagName!="FORM");
    alert(obj.name);
    return false;
}

function GetDate()        
{            
   var nombreforma = funcionEnCuestion(this);
   alert(nombreforma);
   //alert(document.forms[0].elements['grdProgram_txtFecha'].value);
   var txtFechaValue = document.forms[0].elements['grdProgram_txtFecha'].value;
   alert(document.forms[0].name);
	ChildWindow = window.open('../Production/Calendar.aspx?FormName=' + nombreforma + '&CtrlName=grdProgram_txtFecha' + '&txtDate=' + txtFechaValue, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
}


function ConfirmOperation(Button,strOperationType)
{
	if (confirm("¿Está seguro que desea " +strOperationType+ " esta secuencia?")) 
	{
		Button.click()
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
<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
<TABLE id="Table1" border="0">
	<TBODY>
		<TR vAlign="top">
			<TD align="center" colSpan="3">
				<TABLE id="Table2">
					<TR>
						<TD><asp:label id="lblLinea" CssClass="standard-text" Text="Linea de produccion" Runat="server">Linea de producción</asp:label></TD>
						<TD><asp:label id="IdLote" CssClass="standard-text" Text="Número de Lote" Runat="server">Número de Lote</asp:label></TD>
						<TD><asp:label id="lblDate" CssClass="standard-text" Text="Fecha del Programma" Runat="server">Fecha del Programa</asp:label>
							<asp:label id="Label3" Runat="server" Text="(dd-MMM-yyyy)" CssClass="standard-text" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></TD>
					</TR>
					<TR>
						<TD><asp:dropdownlist id="ddlIdLinea" CssClass="standard-text" Runat="server"></asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlLote" CssClass="standard-text" Runat="server"></asp:dropdownlist></TD>
						<TD colspan="2"><asp:textbox id="txtFecha" CssClass="Standard-text" Runat="server" BorderStyle="Groove" Width="77px"
								MaxLength="11"></asp:textbox><asp:image onmouseup="GetDate();" id="imgInitial" Runat="server" ImageUrl="../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:image><br>
							<asp:RegularExpressionValidator id="revFecha" CssClass="standard-text" runat="server" ErrorMessage="Fecha incorrecta"
								ControlToValidate="txtFecha" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
								Display="Dynamic"></asp:RegularExpressionValidator>
							<asp:button id="btnSel" CssClass="botonesInput" Text="Aceptar" Runat="server"></asp:button></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD colSpan="3"><asp:datalist id="lstProgram" runat="server">
					<HeaderTemplate>
						<table id="Table7" cellSpacing="1" cellPadding="1" border="1" style="BORDER-COLLAPSE: collapse"
							borderColor="#000000">
							<TR>
								<TD>
									<TABLE id="Table9" style="BORDER-COLLAPSE: collapse" borderColor="white" cellSpacing="1"
										cellPadding="1" bgColor="#276187" border="1">
										<TR>
											<TD><asp:label id="Label4" runat="server" Width="10px" ForeColor="White" CssClass="standard-text"></asp:label></TD>
											<TD><asp:label id="Label5" runat="server" Width="20px" ForeColor="White" CssClass="standard-text">P</asp:label></TD>
											<TD><asp:label id="Label8" runat="server" Width="60px" ForeColor="White" CssClass="standard-text">Fecha</asp:label></TD>
											<TD><asp:label id="Label9" runat="server" Width="25px" ForeColor="White" CssClass="standard-text">KCT</asp:label></TD>
											<TD><asp:label id="Label10" runat="server" Width="35px" ForeColor="White" CssClass="standard-text">Línea</asp:label></TD>
											<TD><asp:label id="Label12" runat="server" Width="60px" ForeColor="White" CssClass="standard-text">Secuencia</asp:label></TD>
											<TD><asp:label id="Label13" runat="server" Width="40px" ForeColor="White" CssClass="standard-text">Corrida</asp:label></TD>
											<TD><asp:label id="Label15" runat="server" Width="35px" ForeColor="White" CssClass="standard-text">Lote</asp:label></TD>
											<TD><asp:label id="Label24" runat="server" Width="30px" ForeColor="White" CssClass="standard-text">Cant.</asp:label></TD>
											<TD><asp:label id="Label25" runat="server" Width="45px" ForeColor="White" CssClass="standard-text">Material</asp:label></TD>
											<TD><asp:label id="Label26" runat="server" Width="235px" ForeColor="White" CssClass="standard-text">Descripción</asp:label></TD>
											<TD><asp:label id="Label27" runat="server" Width="60px" ForeColor="White" CssClass="standard-text">Área Actual</asp:label></TD>
											<TD><asp:label id="Label28" runat="server" Width="40px" ForeColor="White" CssClass="standard-text"></asp:label></TD>
											<TD><asp:label id="Label40" runat="server" Width="13px" ForeColor="White" CssClass="standard-text"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</HeaderTemplate>
					<FooterTemplate>
						<TABLE id="Table12" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="1"
							cellPadding="1" border="1">
							<TR>
								<TD>
									<TABLE id="Table13" style="BORDER-COLLAPSE: collapse" borderColor="white" cellSpacing="1"
										cellPadding="1" bgColor="#dedfde" border="1">
										<TR>
											<TD><asp:imagebutton id="Imagebutton3" runat="server" Width="9px"></asp:imagebutton></TD>
											<TD><asp:textbox id="txtPrioridad" CssClass="standard-text" runat="server" Width="20px" ToolTip="Proporcione la prioridad de fabricación de la secuencia"
													MaxLength="3" BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:label id=lblNewFecha runat="server" Width="60px" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>' CssClass="standard-text"></asp:label></TD>
											<TD><asp:label id=lkct runat="server" Width="25px" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>' CssClass="standard-text"></asp:label></TD>
											<TD><asp:label id="lblNewLine" runat="server" Width="35px" CssClass="standard-text"></asp:label></TD>
											<TD><asp:label id=lblNewSequence runat="server" Width="60px" ForeColor="Crimson" Font-Bold="True" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>' CssClass="standard-text"></asp:label></TD>
											<TD><asp:textbox id="txtCorrida" CssClass="standard-text" runat="server" Width="40px" MaxLength="5"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:dropdownlist id="cboLote" CssClass="standard-text" runat="server" Width="35px"></asp:dropdownlist></TD>
											<TD align="right"><asp:textbox id="txtCantidad" CssClass="standard-text" runat="server" Width="30px" MaxLength="5"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:textbox id="txtCodigoSAP" CssClass="standard-text" runat="server" Width="45px" MaxLength="18"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD><asp:label id="lblNewDescription" runat="server" Width="235px" CssClass="standard-text"></asp:label></TD>
											<TD><asp:label id=lblNewStatus runat="server" Width="60px" Visible='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.Bitacora")).Trim().Length<=0 %>' CssClass="standard-text"></asp:label></TD>
											<TD>
												<table id="Table14" width="40" border="0">
													<TBODY>
														<tr>
															<td></td>
														</tr>
													</TBODY>
												</table>
											</TD>
											<TD><asp:label id="Label58" runat="server" Width="20px" CssClass="standard-text"></asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table15" cellSpacing="1" cellPadding="1" border="0" runat="server">
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>
												<TABLE id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="1"
													cellPadding="1" border="1">
													<TR>
														<TD bgColor="#dedfde"><asp:label id="Label59" runat="server" Width="40px" CssClass="standard-text">Orden</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label60" runat="server" Width="70px" CssClass="standard-text">Pedido</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label61" runat="server" Width="70px" CssClass="standard-text">Lote Insp</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label62" runat="server" Width="40px" CssClass="standard-text">Rendimiento</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label63" runat="server" Width="150px" CssClass="standard-text">Cliente</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label64" runat="server" Width="100px" CssClass="standard-text">Fecha Embarque</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label65" runat="server" Width="150px" CssClass="standard-text">Area actual</asp:label></TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtOrden" CssClass="standard-text" runat="server" Width="40px" MaxLength="50"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD><asp:textbox id="txtPedido" CssClass="standard-text" runat="server" Width="70px" MaxLength="10"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD align="left"><asp:textbox id="txtLoteInsp" CssClass="standard-text" runat="server" Width="70px" MaxLength="50"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD align="left"><asp:textbox id="txtRendimiento" CssClass="standard-text" runat="server" Width="40px" MaxLength="3"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD><asp:textbox id="txtCliente" CssClass="standard-text" runat="server" Width="150px" MaxLength="10"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD><asp:textbox id="txtFechaEmb" CssClass="standard-text" runat="server" Width="100px" MaxLength="20"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD><asp:label id=lblNewArea Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdArea") %>' runat="server" Width="150px" Visible="False" CssClass="standard-text"></asp:label></TD>
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
												<TABLE id="Table17" style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="1"
													cellPadding="1" border="1">
													<TR>
														<TD bgColor="#dedfde"><asp:label id="Label67" runat="server" Width="100px" CssClass="standard-text">Tipo Molde</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label68" runat="server" Width="200px" CssClass="standard-text">Detalle Operación</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label69" runat="server" Width="200px" CssClass="standard-text">Comentarios</asp:label></TD>
														<TD bgColor="#dedfde"><asp:label id="Label70" runat="server" Width="200px" CssClass="standard-text">Bitácora de Piso</asp:label></TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtTipoMolde" CssClass="standard-text" runat="server" Width="100px" MaxLength="3"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD><asp:textbox id="txtDetalleOp" CssClass="standard-text" runat="server" Width="200px" MaxLength="200"
																BorderStyle="Groove"></asp:textbox></TD>
														<TD align="left"><asp:textbox id="txtComentarios" CssClass="standard-text" runat="server" Width="200px" MaxLength="25"
																BorderStyle="Groove"></asp:textbox></TD>
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
											<TD><asp:image id="Imagebutton2" onmouseup="ShowHide(this.id)" ImageUrl="../images/plusButton.jpg"
													runat="server"></asp:image></TD>
											<TD><asp:label id=lblPrioridad Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' CssClass="standard-text" Width="20px" runat="server"></asp:label><asp:textbox id="txtPriority" CssClass="standard-text" MaxLength="3" Width="25px" runat="server"
													Visible="False"></asp:textbox></TD>
											<TD><asp:label id=lblFecha Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Fecha") %>' CssClass="standard-text" Width="60px" runat="server">
												</asp:label><asp:label id=ItemFechaMod Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FechaMod") %>' CssClass="standard-text" Visible="false">
												</asp:label></TD>
											<TD><asp:label id=Label6 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.KCT") %>' CssClass="standard-text" Width="25px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label7 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' CssClass="standard-text" Width="35px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=lblSecuencia Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' CssClass="standard-text" Width="60px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label11 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Corrida") %>' CssClass="standard-text" Width="40px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=lblLote Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.NumeroLote") %>' CssClass="standard-text" Width="35px" runat="server">
												</asp:label></TD>
											<TD align="right"><asp:label id=lblCantidad Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="standard-text" Width="30px" runat="server"></asp:label><asp:textbox id="txtQuantity" CssClass="standard-text" Width="30px" runat="server" Visible="False"></asp:textbox></TD>
											<TD><asp:label id=Label14 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text" Width="45px" runat="server"></asp:label></TD>
											<TD><asp:label id=lblMaterialDesc Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.MaterialDesc") %>' CssClass="standard-text" Width="235px" runat="server"></asp:label></TD>
											<TD>
												<!--
												<asp:label id=Label16 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' CssClass="standard-text" Width="60px" runat="server" Visible="False">
												</asp:label>
												-->
												<asp:label id=Label17 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.AreaDesc") %>' CssClass="standard-text" Width="60px" runat="server">
												</asp:label></TD>
											<TD>
												<table id="buttonsTable" border="0" width="40">
													<TBODY>
														<tr>
															<td><asp:imagebutton id="cmdEdit" ImageUrl="../images/icon-pencil.gif" runat="server" Visible="False"
																	CommandName="Edit"></asp:imagebutton><asp:imagebutton id="cmdDelete" onmouseup="ConfirmOperation(this,'eliminar');" ImageUrl="../images/icon-delete.gif"
																	runat="server" Visible="False" CommandName="Delete"></asp:imagebutton><asp:imagebutton id="cmdUpdate" onmouseup="ConfirmOperation(this,'actualizar');" ImageUrl="../images/icon-floppy.gif"
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
											<TD><asp:label id=Label35 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.NoOrden") %>' CssClass="standard-text" Width="40px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label36 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Pedido") %>' CssClass="standard-text" Width="70px" runat="server">
												</asp:label></TD>
											<TD align="left"><asp:label id=Label37 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.LoteInspeccion") %>' CssClass="standard-text" Width="70px" runat="server">
												</asp:label></TD>
											<TD align="right"><asp:label id=Label86 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Rendimiento") %>' CssClass="standard-text" Width="40px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label87 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Cliente") %>' CssClass="standard-text" Width="150px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label88 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.FechaEmbarque") %>' CssClass="standard-text" Width="100px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label89 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdArea") %>' CssClass="standard-text" Width="150px" runat="server" Visible="False">
												</asp:label><asp:label id=Label90 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.AreaDesc") %>' CssClass="standard-text" Width="150px" runat="server">
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
											<TD><asp:label id=Label95 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TipoMolde") %>' CssClass="standard-text" Width="100px" runat="server">
												</asp:label></TD>
											<TD><asp:label id=Label96 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.DetalleOperacion") %>' CssClass="standard-text" Width="200px" runat="server">
												</asp:label></TD>
											<TD align="left"><asp:label id=Label97 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Comentarios") %>' CssClass="standard-text" Width="200px" runat="server">
												</asp:label></TD>
											<TD align="left"><asp:label id=Label98 Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Bitacora") %>' CssClass="standard-text" Width="200px" runat="server">
												</asp:label><BR>
											</TD>
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
	<TD align="center"></TD>
	<TD align="right"><asp:button id="cmdprint" CssClass="botonesInput" Text="Imprimir" Runat="server"></asp:button></TD>
	<TD align="left"><asp:button id="cmdCancelar" CssClass="botonesInput" Text="Cancelar" Runat="server"></asp:button></TD>
</TR>
</TD>
<TR>
	<TD colSpan="3"><asp:label id="lblmsg" CssClass="standard-text" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></TD>
</TR>
</TBODY></TABLE>
<P></P>
