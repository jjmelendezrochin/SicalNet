<%@ Page language="c#" Codebehind="ConsultRecepcionPT1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.PartidasRecepcionPT.ConsultRecepcionPT1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultRecepcionPT1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language="javascript">
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
			var previousvalue=0;
			var prepreviousvalue;		
			function getConfirm(Button)
			{
				if(window.confirm("¿Estás seguro que deseas liberar esta secuencia?"))
				{
				document.forms[0].elements[Button].click()
				}
			} 
			function getdifferance(value,id)
			{
				if(isDigit(value))
				{
					alert("Favor de proporcionar un valor numérico válido")
					document.getElementById(id).value=prepreviousvalue
					document.getElementById(id).focus();				
										
				}
				var k=2;				
				for(i=0;i<document.forms[0].length;i++)
				{
				if (document.forms[0].elements[i].name.indexOf('txtLaminasReal') != -1)
					{
						var rlength = 4; // The number of decimal places to round to
						var com="dgdRecepcionPT__ctl"
						var idCantidad= com.concat(k,"_lblLaminas")
						var idDifferance=com.concat(k,"_lblDifferencia")
						var idreal=com.concat(k,":txtLaminasReal")
						//document.getElementById(idDifferance).outerText=parseFloat(document.getElementById(idCantidad).innerText)-parseFloat(document.forms[0].elements[i].value);
						var quantity=parseFloat(parseFloat(document.getElementById(idCantidad).innerText)-document.forms[0].elements[i].value);
						document.getElementById(idreal).innerText=55;
						document.getElementById(idDifferance).innerHTML=Math.round(quantity*Math.pow(10,rlength))/Math.pow(10,rlength);
						k++					
					//alert(document.forms[0].tags("asp:label").length);
					}
					
				}
			}
			function isDigit(num) 
			{
			var string="1234567890";
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
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultRecepcionPT1" method="post" runat="server">
			<table width="700" align="center">
				<tbody>
					<tr>
						<td align="center" colSpan="4"><asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Fase de Recepción de Producto Terminado - Paso 2</asp:label>
							<hr>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label1" runat="server" CssClass="standard-text">Secuencia:</asp:Label></td>
						<td><asp:textbox id="txtSecuencia" BorderStyle="Groove" Width="250px" CssClass="Standard-text" ReadOnly="True"
								Runat="server"></asp:textbox></td>
						<td>
							<asp:Label id="Label3" runat="server" CssClass="standard-text">Fecha:</asp:Label></td>
						<td><asp:textbox id="txtFecha" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True" Runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<asp:Label id="Label2" runat="server" CssClass="standard-text">UTEC:</asp:Label></td>
						<td><asp:textbox id="txtUTEC" BorderStyle="Groove" Width="250px" CssClass="Standard-text" ReadOnly="True"
								Runat="server"></asp:textbox></td>
						<td>
							<asp:Label id="Label4" runat="server" CssClass="standard-text">Láminas:</asp:Label></td>
						<td><asp:textbox id="txtCantidad" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True" Runat="server"></asp:textbox></td>
					</tr>
					<tr width="50px">
						<td>
							<P>&nbsp;</P>
							<P>&nbsp;</P>
						</td>
						<td align="center" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</td>
						<td></td>
					</tr>
					<tr>
						<td align="center" colSpan="4">
							<asp:datagrid id="dgdRecepcionPT" runat="server" Font-Names="Verdana" CellPadding="2" BorderColor="DimGray"
								AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderStyle="None"
								Width="300px" BackColor="LightGray">
								<HeaderStyle Font-Bold="True" BackColor="DarkGray"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Numero Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblNoPaquete Runat="server" CssClass="standard-text" Width="60px" Text='<%# DataBinder.Eval(Container, "DataItem.PaqueteNo") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:Label id=lblPaquete Runat="server" CssClass="Standard-text" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.Paquete") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Laminas por Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblLaminas Runat="server" CssClass="standard-text" Width="60px" Text='<%# DataBinder.Eval(Container, "DataItem.Laminas") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Laminas Registro por Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox id=txtLaminasReal onblur=getdifferance(this.value,this.id) onfocus=previousvalues(this.value) CssClass="Standard-text" Runat="server" Width="60px" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.LaminasReal") %>' AutoPostBack="True" OnTextChanged="txtlaminas">
											</asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Laminas Registro por Paquete">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:Label id=lblLaminasReal CssClass="Standard-text" Runat="server" Width="60px" Text='<%# DataBinder.Eval(Container, "DataItem.LaminasReal") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Differencia">
										<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblDifferencia" Runat="server" CssClass="standard-text" Width="60px"></asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tarima">
										<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="160px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id=lblTarima Runat="server" CssClass="standard-text" Width="160px" Text='<%# DataBinder.Eval(Container, "DataItem.Tarima") %>'>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
					<TR>
						<TD colSpan="4">
							<asp:Label id="Label5" runat="server" CssClass="standard-text">Mensaje de Piso</asp:Label></TD>
					</TR>
					<tr>
						<td colspan="4">
							<asp:TextBox id="txtPiso" runat="server" Width="700px" TextMode="MultiLine" Height="92px" CssClass="standard-text"
								BorderStyle="Groove" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<TR>
						<TD colSpan="4"></TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<table align="center" width="100%">
								<TR>
									<TD vAlign="top" align="center" width="150">
										<asp:button id="btnMensaje" onfocus="previousvalues(this.value)" CssClass="botonesInput" Runat="server"
											Width="100px" DESIGNTIMEDRAGDROP="54" Text="Mensaje de Piso"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnLiberar" onfocus="previousvalues(this.value)" CssClass="botonesInput" Runat="server"
											Width="80px" Text="Liberar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnAgregar" onfocus="previousvalues(this.value)" CssClass="botonesInput" Runat="server"
											Width="80px" Text="Aceptar"></asp:button></TD>
									<TD vAlign="top" align="center" width="140">
										<asp:button id="btnCancelar" onfocus="previousvalues(this.value)" CssClass="botonesInput" Runat="server"
											Width="80px" Text="Regresar"></asp:button></TD>
									<TD vAlign="top" align="center" width="100">
										<DIV id="waitControls" style="DISPLAY: none">
											<TABLE id="Table1" width="50">
												<TR>
													<TD vAlign="top" align="center" colSpan="3">
														<P align="center">
															<asp:label id="Label8" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
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
				</tbody>
			</table>
		</form>
	</body>
</HTML>
