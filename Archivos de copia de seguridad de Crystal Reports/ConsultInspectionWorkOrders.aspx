<%@ Page language="c#" Codebehind="ConsultInspectionWorkOrders.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.InspectionPhase.ConsultInspectionWorkOrders" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultInspectionWorkOrders</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../../../styloDESC.CSS">
		<script language="javascript">	
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
		function getConfirmQuarentine(Button)
			{
				if(window.confirm("¿Estás seguro que deseas liberar la secuencia a fase de Pendientes/Cuarentena?"))
				{
				document.forms[0].elements[Button].click()
				}
			} 
			function getConfirmEnvio(Button)
			{
				if(window.confirm("¿Estás seguro que deseas liberar la secuencia a la fase de Envío de Producto Terminado?"))
				{
				document.forms[0].elements[Button].click()
				}
			} 
		function showid(id)
		{
			var r1id=id.concat("_0")
			var r2id=id.concat("_1")
			var r3id=id.concat("_2")
			var dummy = id
			var num = id.substr(0,dummy.lastIndexOf("_"))
			if(document.getElementById(r1id).checked==true)
			{	var com = num
				var com1 = num							
				var idDefecto= num.concat("_ddlDefecto")
				var Area = com.concat("_lblDefArea")
				var AreaId = com1.concat("_lblAreaId")
				document.getElementById(idDefecto).style.display="none"
				document.getElementById(Area).innerHTML="Envio Producto Terminado"
				document.getElementById(AreaId).innerHTML="15"
				
			}
			else if(document.getElementById(r2id).checked==true)
			{
				var com = num
				var com1 = num								
				var idDefecto= num.concat("_ddlDefecto")
				var AreaId = com1.concat("_lblAreaId")
				var Area = com.concat("_lblDefArea")
				document.getElementById(idDefecto).style.display="inline"
				document.getElementById(Area).innerHTML="Segundas"
				document.getElementById(AreaId).innerHTML="17"
			}
			else if(document.getElementById(r3id).checked==true)
			{
				var com = num
				var com1 = num										
				var idDefecto= num.concat("_ddlDefecto")
				var Area = com.concat("_lblDefArea")
				var AreaId = com1.concat("_lblAreaId")
				document.getElementById(idDefecto).style.display="inline"
				document.getElementById(Area).innerHTML="Terceras"
				document.getElementById(AreaId).innerHTML="18"
			}
				
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultInspectionWorkOrders" method="post" runat="server">
			<table align="center">
				<tr>
					<td colSpan="4" align="center"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Fase de Inspección</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="lblSecuencia" runat="server" Width="101px" Height="16px" CssClass="standard-text">No. de Secuencia</asp:label></td>
					<td><asp:textbox id="txtSecuencia" Width="250px" CssClass="Standard-text" Runat="server" ReadOnly="True"
							BorderStyle="Groove"></asp:textbox></td>
					<td><asp:label id="lblFecha2" runat="server" Width="100px" Height="16px" CssClass="standard-text">Fecha</asp:label></td>
					<td><asp:textbox id="txtFecha" CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="lblUtec" runat="server" Width="98px" Height="16px" CssClass="standard-text">UTEC</asp:label></td>
					<td><asp:textbox id="txtUtec" Width="250px" CssClass="Standard-text" Runat="server" ReadOnly="True"
							BorderStyle="Groove"></asp:textbox></td>
					<td><asp:label id="lblCantidad" runat="server" Width="98px" Height="16px" CssClass="standard-text">Láminas</asp:label></td>
					<td><asp:textbox id="txtCantidad" CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="lblFamilia" runat="server" Width="98px" Height="16px" CssClass="standard-text">Familia</asp:label></td>
					<td><asp:textbox id="txtFamilia" runat="server" Width="250px" CssClass="standard-text" ReadOnly="True"
							BorderStyle="Groove"></asp:textbox></td>
					<td><asp:label id="lblLinea2" runat="server" Width="98px" Height="16px" CssClass="standard-text">Linea</asp:label></td>
					<td><asp:textbox id="txtLinea2" runat="server" CssClass="standard-text" ReadOnly="True" BorderStyle="Groove"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="4"><asp:label id="lblErrorMsg" Height="25px" CssClass="standard-text" Runat="server" ForeColor="Red"></asp:label></td>
				</tr>
				<TR>
					<TD colSpan="4"><asp:label id="Label1" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Empaque</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:datagrid id="dgdEmpaque" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
							AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="DimGray"
							CellPadding="2" BackColor="LightGray">
							<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Material">
									<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblMaterial CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descripcion">
									<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="300px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=lblDesc CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Cantidad">
									<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="150px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:Label id=lblCantidade CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Cantidad")%>'>
										</asp:Label>
										<asp:Label id=lblUnidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.Unidad")%>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="4"></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:label id="Label2" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Detalle por Lámina</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:datagrid id="dgdDefecto" runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None"
							AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="Gray"
							CellPadding="2" BackColor="Transparent" style="Z-INDEX: 0">
							<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="No Lamina">
									<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblLamina CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoLamina") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Calidad de Lamina">
									<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:RadioButtonList id="RDLCalidad" runat="server" onclick="showid(this.id)" CssClass="standard-text"
											RepeatDirection="Horizontal">
											<asp:ListItem Value="1">1ra</asp:ListItem>
											<asp:ListItem Value="2">2da</asp:ListItem>
											<asp:ListItem Value="3">3ra</asp:ListItem>
										</asp:RadioButtonList>
										<asp:label id=lblCalidad CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Calificacion") %>' Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Defecto">
									<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList style="DISPLAY: none" id="ddlDefecto" CssClass="standard-text" Runat="server"></asp:DropDownList>
										<asp:label id=lblDefecto CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdDefecto") %>' Visible="false">
										</asp:label>
										<asp:label id=lblDescripcionDefecto CssClass="standard-text" Runat="server" Visible="false">
										</asp:label>
										<asp:label id=lblReactivado CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Reactivado") %>' Visible="false">
										</asp:label>
										<asp:label id=lblCuarentena CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cuarentena") %>' Visible="false">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Area Destino">
									<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="150px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:Label id="lblAreaId" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdAreaDestino") %>' style="DISPLAY: none">
										</asp:Label>
										<asp:Label id="lblDefArea" CssClass="standard-text" Runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:label id="Label3" runat="server" CssClass="standard-text">Mensaje de Piso</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:textbox id="txtPiso" runat="server" Width="700px" Height="48px" CssClass="standard-text"
							ReadOnly="True" BorderStyle="Groove" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<table width="700" align="center">
							<TR>
								<TD vAlign="top" width="120" align="center"><asp:button id="btnMensaje" Width="115px" CssClass="botonesInput" Runat="server" Text="Mensaje de Piso"></asp:button></TD>
								<TD vAlign="top" width="140" align="center"><asp:button id="btnQuarentine" onmouseup="getConfirmQuarentine(this.id)" Width="156px" CssClass="botonesInput"
										Runat="server" Text="Liberar Pend./Cuarentena"></asp:button></TD>
								<TD vAlign="top" width="150" align="center">&nbsp;&nbsp;&nbsp;
									<asp:button id="btnLiberar" onmouseup="getConfirmEnvio(this.id)" Width="145px" CssClass="botonesInput"
										Runat="server" Text="Liberar a Entrega de PT"></asp:button></TD>
								<TD vAlign="top" width="120" align="center"><asp:button id="btnAceptar" Width="80px" CssClass="botonesInput" Runat="server" Text="Aceptar"></asp:button></TD>
								<TD vAlign="top" width="120" align="center"><asp:button id="btnCancelar" runat="server" Width="80px" CssClass="botonesInput" Text="Regresar"></asp:button></TD>
								<TD vAlign="top" width="100" align="center">
									<DIV style="DISPLAY: none" id="waitControls">
										<TABLE id="Table1" width="50">
											<TR>
												<TD vAlign="top" colSpan="3" align="center">
													<P align="center"><asp:label id="Label8" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
														<asp:image id="Image1" runat="server" ImageUrl="../../../../Images/waitImage.gif"></asp:image></P>
												</TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</table>
			<BR>
			</ASP:PANEL></form>
		<script language="javascript">
				var p=2
			for(i=0;i<document.forms[0].length;i++)
				{					
					if (document.forms[0].elements[i].id.indexOf('RDLCalidad_1') != -1)
					{					
						var r1id=document.forms[0].elements[i].id;
						if(document.getElementById(r1id).checked==true)
						{												
							var com="dgdDefecto__ctl";
							var idDefecto= com.concat(p,"_ddlDefecto");
							document.getElementById(idDefecto).style.display="inline";
							p++;
						}
					}
					else if (document.forms[0].elements[i].id.indexOf('RDLCalidad_2') != -1)
					{					
						var r1id=document.forms[0].elements[i].id;
						if(document.getElementById(r1id).checked==true)
						{								
							var com="dgdDefecto__ctl";
							var idDefecto= com.concat(p,"_ddlDefecto");
							document.getElementById(idDefecto).style.display="inline";
							p++;
						}
					}
					else if (document.forms[0].elements[i].id.indexOf('RDLCalidad_0') != -1)
					{					
						var r1id=document.forms[0].elements[i].id;
						if(document.getElementById(r1id).checked==true)
						{												
							var com="dgdDefecto__ctl";
							var idDefecto= com.concat(p,"_lblDefArea");
							document.getElementById(idDefecto).innerHTML="Producto Terminado";
							p++;
						}
					}					
					
				}
		</script>
	</body>
</HTML>
