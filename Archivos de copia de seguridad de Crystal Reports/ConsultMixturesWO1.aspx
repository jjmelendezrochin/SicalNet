<%@ Register TagPrefix="cyberakt" Namespace="CYBERAKT.WebControls.Navigation" Assembly="ASPnetMenu" %>
<%@ Page language="c#" Codebehind="ConsultMixturesWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WebForm1" %>
<HTML>
	<HEAD>
		<title>WebForm1</title>
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
			function SumCantidadReal(value,id)
			{									 
											
				if(isDigit(value)||document.getElementById(id).value=='')
				{
					alert("El valor proporcionado debe ser numérico.")
					document.getElementById(id).value=prepreviousvalue
					document.getElementById(id).focus();				
										
				}
				var Sum = 0
				var k=0
				var j=2
				var m=2
				var p=2
				var PMMARegistro=0
				for(i=0;i<document.forms[0].length;i++)
				{
					if (document.forms[0].elements[i].name.indexOf('txtPMMARegistro') != -1)
					{
						Sum = Sum + parseFloat(document.forms[0].elements[i].value);
						var rlength = 4; // The number of decimal places to round to
						var com="dgdPMMA__ctl"
						var idCantidad= com.concat(p,"_lblPMMACantidad")
						var idDifferance=com.concat(p,"_lblDiferenciasPMMA")
						var diff = 	parseFloat(document.getElementById("txtSubrante").value)-	parseFloat(document.getElementById("sub").value)		
						var Auxdiff = parseFloat(document.getElementById(idCantidad).innerHTML)-diff;
						document.getElementById(idCantidad).innerHTML=Auxdiff.toFixed(4);
						document.getElementById("sub").value=document.getElementById("txtSubrante").value
						//document.getElementById(idDifferance).outerText=parseFloat(document.getElementById(idCantidad).innerText)-parseFloat(document.forms[0].elements[i].value);
						var quantity=parseFloat(parseFloat(document.getElementById(idCantidad).innerText-document.forms[0].elements[i].value));
						document.getElementById(idDifferance).innerHTML=Math.round(quantity*Math.pow(10,rlength))/Math.pow(10,rlength);
						p++;
						k++;
						
						//alert("Sobrante value=[" + value + "]");
						//alert("Sobrante value=[" + document.getElementById("sub").value + "]");
						
						
						//PMMARegistro = parseFloat(document.forms[0].elements[i].value);
						//document.forms[0].elements['txtPiso'].value=PMMARegistro;
					}
						
					//if (document.forms[0].elements[i].name.indexOf('lblPMMACantidad') != -1)
					//{
					//	var PMMACantidad = parseFloat(document.forms[0].elements[i].value);
					//	document.forms[0].elements['txtPiso'].value=PMMARegistro-PMMACantidad;
					//}
					
					//if (document.forms[0].elements[i].name.indexOf('lblDiferenciasPMMA') != -1)
					//{
					//	document.forms[0].elements[i].value = PMMACantidad-PMMARegistro;
					//}
					

					if (document.forms[0].elements[i].name.indexOf('txtAditivosRegistro') != -1)
					{
										
						Sum = Sum + parseInt(document.forms[0].elements[i].value);
						var rlength = 4; // The number of decimal places to round to
						var com="dgdAditivos__ctl"
						var idCantidad= com.concat(j,"_lblAditivosCantidad")
						var idDifferance=com.concat(j,"_lblDiferenciasAditivos")
						
						//document.getElementById(idDifferance).outerText=parseFloat(document.getElementById(idCantidad).innerText)-parseFloat(document.forms[0].elements[i].value);
						var quantity=parseFloat(document.getElementById(idCantidad).innerText-document.forms[0].elements[i].value);
						document.getElementById(idDifferance).innerHTML=Math.round(quantity*Math.pow(10,rlength))/Math.pow(10,rlength);
						j++;
						//PMMARegistro = parseFloat(document.forms[0].elements[i].value);
					}	
					
						//var PMMACantidad;
						
						//if (document.forms[0].elements[i].name.indexOf('lblAditivosCantidad') != -1)
						//{
						//	PMMACantidad = parseFloat(document.forms[0].elements[i].value);
		
						//}
						
						//if (document.forms[0].elements[i].name.indexOf('lblDiferenciasAditivos') != -1)
						//{
						//	document.forms[0].elements[i].value = PMMACantidad-PMMARegistro;
						//}
						

					if (document.forms[0].elements[i].name.indexOf('txtColorRegistro') != -1)
					{
						
						Sum = Sum + parseInt(document.forms[0].elements[i].value);
						var rlength = 4; // The number of decimal places to round to
						var com="dgdColor__ctl"
						var idCantidad= com.concat(m,"_lblColorCantidad")
						var idDifferance=com.concat(m,"_lblDiferenciasColor")
						//document.getElementById(idDifferance).outerText=parseFloat(document.getElementById(idCantidad).innerText)-parseFloat(document.forms[0].elements[i].value);
						var quantity=parseFloat(parseFloat(document.getElementById(idCantidad).innerText-document.forms[0].elements[i].value));
						document.getElementById(idDifferance).innerHTML=Math.round(quantity*Math.pow(10,rlength))/Math.pow(10,rlength);
						m++;
					}
					
					
				}
				
				for(i=0;i<document.forms[0].length;i++)
				{
					if (document.forms[0].elements[i].name.indexOf('txtOllaRegistro') != -1)
						document.forms[0].elements[i].value = Sum;
					
				}
					
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
			function ShowHide(CtrlName)
			{
				
				var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"))
				var gridtableid = index.concat("_dgdColorWO");

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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="WebForm1" method="post" runat="server">
			<table align="center">
				<TBODY>
					<TR>
						<td colSpan="4" align="center"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Fase de Mezclas</asp:label>
							<hr>
						</td>
					</TR>
					<tr>
						<td><asp:label id="Label12" runat="server" CssClass="standard-text">Secuencia:</asp:label></td>
						<td><asp:textbox id="txtSecuencia" CssClass="Standard-text" Runat="server" ReadOnly="True" Width="216px"
								BorderStyle="Groove"></asp:textbox>
							<asp:textbox id="txtidPlanta" CssClass="Standard-text" BorderStyle="Groove" Width="216px" ReadOnly="True"
								Runat="server"></asp:textbox></td>
						<td><asp:label id="Label14" runat="server" CssClass="standard-text">Fecha:</asp:label></td>
						<td><asp:textbox id="txtFecha" CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td><asp:label id="Label13" runat="server" CssClass="standard-text">UTEC:</asp:label></td>
						<td><asp:textbox id="txtUTEC" CssClass="Standard-text" Runat="server" ReadOnly="True" Width="392px"
								BorderStyle="Groove"></asp:textbox></td>
						<td><asp:label id="Label15" runat="server" CssClass="standard-text">Cantidad:</asp:label></td>
						<td><asp:textbox id="txtCantidad" CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
					</tr>
					<tr>
						<td colSpan="4"><cyberakt:aspnetmenu id="tabMixture" runat="server" DefaultItemSpacing="3" DefaultItemSelectedCssClassOver="SelectedMenuItem"
								DefaultItemCssClassOver="MenuItemOver" DefaultItemCssClass="MenuItem" DefaultItemSelectedCssClass="SelectedMenuItem"
								ExpandDelay="50" ImagesBaseURL='="images/"' MenuStyle="ClassicHorizontal"></cyberakt:aspnetmenu>
							<div>
								<table style="POSITION: relative; TOP: -4px" border="0" cellSpacing="0" cellPadding="0"
									width="700">
									<TBODY>
										<tr>
											<td bgColor="#276187" colSpan="4"><IMG border="0" src="images/spacer.gif" width="5" height="7"></td>
										</tr>
										<tr bgColor="#276187">
											<td style="WIDTH: 241px" colSpan="2"></td>
											<td style="WIDTH: 229px"></td>
											<td></td>
										</tr>
										<tr bgColor="#276187">
											<td style="WIDTH: 241px; HEIGHT: 11px" colSpan="2" align="center"><asp:label id="lblOlla" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="12pt"
													Width="41px" ForeColor="White">Olla:</asp:label><asp:dropdownlist id="cmbOlla" CssClass="standard-text" Runat="server" Width="127px"></asp:dropdownlist></td>
											<td style="WIDTH: 229px; HEIGHT: 11px" align="right"><asp:label id="Label4" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="12pt"
													Width="179px" ForeColor="White">No. de Láminas en esta olla:</asp:label></td>
											<td style="HEIGHT: 11px"><asp:label id="lblNoLaminas" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="12pt"
													ForeColor="White"></asp:label></td>
										</tr>
										<tr>
											<td colSpan="4"><font size="3"><B><asp:label id="Label1" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Prepolímero (PMMA)</asp:label></B></font></td>
										</tr>
										<tr>
											<td colSpan="4"><asp:datagrid id="dgdPMMA" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
													AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" BorderColor="DimGray"
													CellPadding="2" BackColor="LightGray">
													<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Material">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblPMMACodigoSAP Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
																</asp:label>
																<asp:label id=lblIdTipoPMMA Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdTipoPMMA") %>' Visible="False">
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n">
															<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblPMMADescripcion Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Tanque">
															<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="120px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblIDTanque" Runat="server" CssClass="standard-text" Visible="False"></asp:label>
																<asp:label id="lblIDTanqueSelected" Runat="server" CssClass="standard-text" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.NoTanque") %>'>
																</asp:label>
																<asp:label id="lblTanque" Runat="server" CssClass="standard-text" Visible="False"></asp:label>
																<asp:DropDownList id="cboTanque" Runat="server" CssClass="standard-text" Visible="False"></asp:DropDownList>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cantidad (kg)">
															<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblPMMACantidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad", "{0:f4}") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cantidad Real (kg)">
															<HeaderStyle HorizontalAlign="Center" Width="100%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:TextBox id=txtPMMARegistro onblur=SumCantidadReal(this.value,this.id) onfocus=previousvalues(this.value) Runat="server" CssClass="Standard-text" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
																</asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn Visible="False" HeaderText="Registro">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblPMMARegistro Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Diferencias">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblDiferenciasPMMA" Runat="server" CssClass="Standard-text"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td colSpan="4"><font size="3"><B><asp:label id="Label2" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Aditivos</asp:label></B></font></td>
										<tr>
											<td colSpan="4"><asp:datagrid id="dgdAditivos" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
													AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" BorderColor="DimGray"
													CellPadding="2" BackColor="LightGray">
													<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Material">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblAditivosCodigoSAP Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Descripci&#243;n">
															<HeaderStyle Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblAditivosDescripcion Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cantidad (grs.)">
															<HeaderStyle Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblAditivosCantidad Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad", "{0:f3}") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td colSpan="4"><font size="3"><B><asp:label id="Label3" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Color</asp:label></B></font></td>
										</tr>
										<tr>
											<td colSpan="4" align="center"><asp:datagrid id="dgdColor" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
													AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" BackColor="LightGray"
													Visible="False">
													<HeaderStyle Font-Bold="True"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="Componente">
															<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblComponente Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.GroupNo") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Cantidad (grs.)">
															<HeaderStyle Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblColorCantidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad", "{0:f3}") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Aforo (grs.)">
															<HeaderStyle Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id=lblAforo Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Aforo", "{0:f3}") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Aforo X Lamina (grs.)">
															<HeaderStyle Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
															<ItemTemplate>
																<asp:label id="lblAfLaminas" Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal", "{0:f3}") %>'>
																</asp:label>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid><asp:datalist id="lstColor" runat="server" Width="700px" BackColor="#E0E0E0">
													<HeaderTemplate>
														<table id="Table7" style="BORDER-COLLAPSE: collapse" borderColor="#000000" width="700px">
															<TR>
																<TD>
																	<TABLE id="Table9" style="BORDER-COLLAPSE: collapse" cellSpacing="1" cellPadding="1" bgColor="#276187"
																		border="1" width="100%">
																		<TR>
																			<TD Width="15%" colspan="2">
																				<asp:label id="Label5" runat="server" ForeColor="White" CssClass="standard-text" Font-Bold="True">Componente</asp:label></TD>
																			<TD Width="30%">
																				<asp:label id="Label8" runat="server" ForeColor="White" CssClass="standard-text" Font-Bold="True">Cantidad (grs.)</asp:label></TD>
																			<TD Width="25%">
																				<asp:label id="Label9" runat="server" ForeColor="White" CssClass="standard-text" Font-Bold="True">Aforo (grs.)</asp:label></TD>
																			<TD Width="30%">
																				<asp:label id="Label40" runat="server" ForeColor="White" CssClass="standard-text" Font-Bold="True">Aforo X Lamina (grs)</asp:label></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
														</table>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="Table8" style="BORDER-COLLAPSE: collapse" width="700" border="0">
															<TR>
																<TD>
																	<TABLE id="Table11" style="BORDER-COLLAPSE: collapse" borderColor="dimgray" cellSpacing="1"
																		cellPadding="1" width="100%" bgColor="gainsboro" border="1">
																		<TR>
																			<TD width="5%">
																				<asp:image onmouseup="ShowHide(this.id)" id="Imagebutton2" runat="server" ImageUrl="../../images/plusButton.jpg"></asp:image></TD>
																			<TD width="10%">
																				<asp:label id=lblNoGrupo runat="server" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.GroupNo") %>'>
																				</asp:label></TD>
																			<TD width="30%">
																				<asp:label id=Label22 runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad", "{0:f3}") %>'>
																				</asp:label></TD>
																			<TD width="25%">
																				<asp:label id=Label21 runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Aforo", "{0:f3}") %>'>
																				</asp:label></TD>
																			<TD width="30%">
																				<asp:label id=Label17 runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal", "{0:f3}") %>'>
																				</asp:label></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<TR>
																<TD>
																	<asp:datagrid id="dgdColorWO" style="DISPLAY: none" runat="server" Font-Names="Verdana" CellPadding="2"
																		BorderColor="DimGray" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True"
																		BorderStyle="None" Width="100%" Visible="True">
																		<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn HeaderText="Material">
																				<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="lblCodigoSAP" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' CssClass="standard-text" Width=60px Runat="server">
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="Descripci&#243;n">
																				<HeaderStyle HorizontalAlign="Center" Width="60%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="lblDescripcion" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text" Width="200px" Runat="server">
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn HeaderText="Cantidad">
																				<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle Width="20%" CssClass="grid-item"></ItemStyle>
																				<ItemTemplate>
																					<asp:label id="lblCantidad" Text='<%# String.Format("{0:f3}",DataBinder.Eval(Container, "DataItem.Cantidad"))%>' CssClass="standard-text" Runat="server">
																					</asp:label>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid>
																</TD>
															</TR>
														</TABLE>
													</ItemTemplate>
												</asp:datalist></td>
										</tr>
										<tr height="50">
											<td style="WIDTH: 120px"><asp:label id="Label11" runat="server" CssClass="standard-text">Registro KG X Olla:</asp:label></td>
											<td style="WIDTH: 134px"><asp:textbox id="txtOllaRegistro" CssClass="Standard-text" Runat="server" BorderStyle="Groove"
													Enabled="False"></asp:textbox></td>
											<td style="WIDTH: 229px"><asp:label id="Label10" runat="server" CssClass="standard-text">Sobrante:&nbsp;</asp:label><asp:textbox onblur="SumCantidadReal(this.value,this.id)" id="txtSubrante" onfocus="previousvalues(this.value)"
													CssClass="Standard-text" Runat="server" BorderStyle="Groove" Enabled="False" EnableViewState="False" Width="120px">0</asp:textbox>
												<asp:textbox style="DISPLAY: none" id="sub" CssClass="Standard-text" Runat="server" BorderStyle="Groove">0</asp:textbox><asp:label style="DISPLAY: none" id="lblSubrante" runat="server" CssClass="standard-text" ForeColor="#0000C0">0</asp:label></td>
											<td width="250" align="right"><asp:label id="Label9" runat="server" CssClass="standard-text">Agitador:</asp:label><asp:textbox id="txtAgitador" onfocus="previousvalues(this.value)" CssClass="Standard-text" Runat="server"
													BorderStyle="Groove"></asp:textbox></td>
										</tr>
										<tr height="50">
											<td style="WIDTH: 241px" colSpan="2"><asp:label id="Label6" runat="server" CssClass="standard-text">Viscosidad Inicial:</asp:label><asp:textbox id="txtViscosidadInicial" onfocus="previousvalues(this.value)" CssClass="Standard-text"
													Runat="server" BorderStyle="Groove"></asp:textbox></td>
											<td style="WIDTH: 229px"><asp:label id="Label7" runat="server" CssClass="standard-text">Viscosidad Final:</asp:label><asp:textbox id="txtViscosidadFinal" onfocus="previousvalues(this.value)" CssClass="Standard-text"
													Runat="server" BorderStyle="Groove"></asp:textbox></td>
											<DIV></DIV>
											<td style="WIDTH: 250px" colSpan="2"><asp:label id="Label8" runat="server" CssClass="standard-text">Secuencia Sobrante:</asp:label><asp:textbox id="txtSecuenciaSobrante" onfocus="previousvalues(this.value)" CssClass="Standard-text"
													Runat="server" BorderStyle="Groove"></asp:textbox></td>
										</tr>
										<tr>
											<td colSpan="4"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text" Width="700px" ForeColor="Red"></asp:label></td>
										</tr>
									</TBODY>
								</table>
							</div>
						</td>
					</tr>
					<tr height="30">
						<td colSpan="4"><b><asp:label id="Label5" runat="server" CssClass="standard-text">Mensaje de Piso</asp:label></b></td>
					</tr>
					<tr>
						<td colSpan="4"><asp:textbox id="txtPiso" CssClass="Standard-text" Runat="server" Width="700px" BorderStyle="Groove"
								TextMode="MultiLine" Height="65px"></asp:textbox></td>
					</tr>
					<tr height="50">
						<td colSpan="4" align="right">
							<TABLE width="100%" align="center">
								<TR height="40">
									<TD vAlign="top" width="150" align="center"><asp:button id="btnAgregarMensaje" CssClass="botonesInput" Runat="server" Width="119px" Text="Mensaje de piso"></asp:button></TD>
									<TD vAlign="top" width="140" align="center"><asp:button id="cmdLiberar" CssClass="botonesInput" Runat="server" Width="80px" Text="Liberar"></asp:button></TD>
									<TD vAlign="top" width="140" align="center"><asp:button id="btnAgregar" CssClass="botonesInput" Runat="server" Width="80px" Text="Aceptar"></asp:button></TD>
									<TD vAlign="top" width="140" align="center"><asp:button id="btnCancel" CssClass="botonesInput" Runat="server" Width="80px" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" width="100" align="center">
										<DIV style="DISPLAY: none" id="waitControls">
											<TABLE id="Table1" width="50">
												<TR>
													<TD vAlign="top" colSpan="3" align="center">
														<P align="center"><asp:label id="Label16" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
															<asp:image id="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P>
													</TD>
												</TR>
											</TABLE>
										</DIV>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</TBODY>
			</table>
			<DIV></DIV>
		</form>
		</TD></TR></TBODY></TABLE></TR></TBODY>
		<DIV></DIV>
		</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
