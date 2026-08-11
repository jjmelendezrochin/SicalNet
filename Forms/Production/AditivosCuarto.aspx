<%@ Page language="c#" Codebehind="AditivosCuarto.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.AditivosCuarto" %>
<%@ Register TagPrefix="cyberakt" Namespace="CYBERAKT.WebControls.Navigation" Assembly="ASPnetMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultWOAdditivos</title>
		<META content="text/html; charset=windows-1252" http-equiv="Content-Type">
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
		<script language="javascript">	
			var previousvalue=0;
			var prepreviousvalue;	
			function showWaitControls()
			{
				waitControls.style.display='';
			}				
			
			function getConfirm(CtrlName,Button)
			{
				document.forms[0].elements[CtrlName].value=window.confirm("¿Deseas consultar la siguiente secuencia?");
				document.forms[0].elements[Button].click()
			}
			function getdifferance(value,id)
			{
				if(isDigit(value))
				{
					alert("The Entered Value should be Numeric")
					document.getElementById(id).value=prepreviousvalue
					document.getElementById(id).focus();				
										
				}		
				var j=0;
				var Cantidad = 0; 
				var CantidadReal = 0;
				var Diferencia = 0;
				for(i=0;i<document.forms[0].length;i++)
				{
						if (document.forms[0].elements[i].name.indexOf('txtCantidadReal') != -1)
						{
							CantidadReal= document.forms[0].elements[i].value;
						}
						if (document.forms[0].elements[i].name.indexOf('txtCantidadAditivos') != -1)
						{
							Cantidad = document.forms[0].elements[i].value;
						}
						if (document.forms[0].elements[i].name.indexOf('txtDif') != -1)
						{
							Diferencia = Cantidad-CantidadReal;
							document.forms[0].elements[i].value = toFixed(Diferencia, 4);
						}						
				}
				
			}
			
			function toFixed(value, precision) {
				var precision = precision || 0,
					power = Math.pow(10, precision),
					absValue = Math.abs(Math.round(value * power)),
					result = (value < 0 ? '-' : '') + String(Math.floor(absValue / power));

				if (precision > 0) {
					var fraction = String(absValue % power),
						padding = new Array(Math.max(precision - fraction.length, 0) + 1).join('0');
					result += '.' + padding + fraction;
				}
				return result;
			}
			
			function isDigit(num) 
			{
				var string="1234567890.";
				for(i=0;i<num.length;i++)
				{
					if (string.indexOf(num.charAt(i))==-1)
					{
						return true;
						break;
					}
					else
						{return false;}
				}
			}
			function previousvalues(values)
			{	
				prepreviousvalue=previousvalue
				previousvalue=values
				
			}
			
		</script>
	</HEAD>
	<body onload="getdifferance(1,1);" MS_POSITIONING="GridLayout">
		<form id="FormAdditovesWO" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td colSpan="4" align="center"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Fase de Aditivos - Paso 3</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td><asp:label id="lblInitial" CssClass="standard-text" Runat="server" Text="Fecha">Secuencia:</asp:label></td>
						<td><asp:textbox id="txtSecuencia" CssClass="Standard-text" Runat="server" ReadOnly="True" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td><asp:label id="Label2" CssClass="standard-text" Runat="server" Text="Fecha">Fecha:</asp:label></td>
						<td><asp:textbox id="txtFecha" CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label1" CssClass="standard-text" Runat="server" Text="Fecha">UTEC:</asp:label></td>
						<td><asp:textbox id="txtUtec" CssClass="Standard-text" Runat="server" ReadOnly="True" Width="250px"
								BorderStyle="Groove"></asp:textbox></td>
						<td><asp:label id="Label3" CssClass="standard-text" Runat="server" Text="Fecha">Cantidad:</asp:label></td>
						<td><asp:textbox id="txtCantidad" CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td>&nbsp;&nbsp;</td>
						<td><asp:textbox id="txtArea" CssClass="Standard-text" Runat="server" BorderStyle="Groove" Visible="False"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="4"><cyberakt:aspnetmenu id="Menu1" runat="server" DefaultItemCssClass="MenuItem" DefaultItemCssClassOver="MenuItemOver"
								DefaultItemSelectedCssClass="SelectedMenuItem" DefaultItemSelectedCssClassOver="SelectedMenuItem" DefaultItemSpacing="3"></cyberakt:aspnetmenu>
							<div>
								<table style="Z-INDEX: 102; POSITION: relative; TOP: -4px" border="0" cellSpacing="0" cellPadding="0"
									width="700">
									<tr>
										<td bgColor="#276187"><IMG border="0" src="images/spacer.gif" width="5" height="7"></td>
									</tr>
									<tr>
										<td bgColor="lightgrey" colSpan="4"><asp:datagrid id="dgdAditivos" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
												CellPadding="2" BorderColor="DimGray" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True">
												<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="Material">
														<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id=AditivosCodigoSAP CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
															</asp:label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Descripci&#243;n">
														<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id=AditivosDescripcion CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
															</asp:label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="% Peso">
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id="lblPorPeso" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PorcentajePeso") %>'>
															</asp:label><font class="standard-text">%</font>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Cantidad (grs.)">
														<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id=AditivosCantidad Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server" CssClass="standard-text" Visible="False">
															</asp:label>
															<asp:TextBox onblur=getdifferance(this.value,this.id) style="Z-INDEX: 0" id=txtCantidadAditivos onfocus=previousvalues(this.value) Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server" CssClass="Standard-Text" BorderStyle="Groove" Width="100px" Enabled="False">
															</asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Cantidad Real (grs.)">
														<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox onblur=getdifferance(this.value,this.id) id=txtCantidadReal onfocus=previousvalues(this.value) Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>' Runat="server" CssClass="Standard-Text" BorderStyle="Groove" Width="100px">
															</asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn Visible="False" HeaderText="CantidadReal">
														<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id=lblCantidadReal CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
															</asp:label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Diferencia">
														<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:label id="lblDiffrencia" Runat="server" CssClass="standard-text" Visible="False"></asp:label>
															<asp:TextBox onblur=getdifferance(this.value,this.id) style="Z-INDEX: 0" id=txtDif onfocus=previousvalues(this.value) Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>' Runat="server" CssClass="Standard-Text" BorderStyle="Groove" Width="100px" Enabled="False">
															</asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Folio">
														<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
														<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox id=txtFolio onfocus=previousvalues(this.value) BorderStyle="Groove" CssClass="Standard-Text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LoteReferencia") %>'>
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
												</Columns>
											</asp:datagrid></td>
									</tr>
								</table>
							</div>
						</td>
					</tr>
					<tr>
						<td colSpan="4"><asp:label id="Label4" CssClass="standard-text" Runat="server" Text="Fecha">Mensaje de Piso:</asp:label></td>
					</tr>
					<tr>
						<td style="HEIGHT: 71px" colSpan="4"><asp:textbox id="txtPiso" CssClass="Standard-text" Runat="server" ReadOnly="True" Width="700px"
								BorderStyle="Groove" Height="65px" TextMode="MultiLine"></asp:textbox></td>
					</tr>
					<TR>
						<TD colSpan="4">
							<TABLE width="700" align="center">
								<TR>
									<TD vAlign="top" width="100" align="center"><asp:button id="btnColor" runat="server" CssClass="botonesInput" Text="Consultar Color" Width="100px"></asp:button>&nbsp;</TD>
									<TD vAlign="top" width="100" align="center"><asp:button id="btnAgregarMensaje" runat="server" CssClass="botonesInput" Text="Mensaje de Piso"
											Width="100px"></asp:button></TD>
									<TD vAlign="top" width="90" align="center"><asp:button id="btnImprimer" runat="server" CssClass="botonesInput" Text="Imprimir" Width="90px"></asp:button></TD>
									<TD vAlign="top" width="90" align="center"><asp:button id="btnLiberar" runat="server" CssClass="botonesInput" Text="Liberar" Width="90px"></asp:button></TD>
									<TD vAlign="top" width="90" align="center"><asp:button id="btnAgregar" CssClass="botonesInput" Runat="server" Text="Aceptar" Width="90px"></asp:button></TD>
									<TD vAlign="top" width="100" align="center"><asp:button id="btnCancelar" CssClass="botonesInput" Runat="server" Text="Regresar" Width="90px"></asp:button></TD>
									<TD vAlign="top" width="100" align="center">
										<DIV style="DISPLAY: none" id="waitControls">
											<TABLE id="Table1" width="50" DESIGNTIMEDRAGDROP="17">
												<TR>
													<TD vAlign="top" colSpan="3" align="center">
														<P align="center"><asp:label id="Label7" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
															<asp:image id="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P>
													</TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
							<INPUT name="txtHidden" size="8" type="hidden"></TD>
					</TR>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
