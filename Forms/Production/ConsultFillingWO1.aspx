<%@ Page language="c#" Codebehind="ConsultFillingWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultFillingWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultFillingWO1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="javascript">
		function isDigit(num,button) 
			{
				var string="1234567890"
				var KCT=document.getElementById("txtKCT").value
				if(KCT.length==0)
				{					
                    SicalAlert.mostrar(
                        "El KCT debe ser especificado",
                        "advertencia"
                    );
					return false
				}

				for(i=0;i<KCT.length;i++)
				{
					if (string.indexOf(KCT.charAt(i))==-1)
					{
						alert(" El KCT debe ser un número")
						return true
						break;
					}
					else
					{
						button.click()
					}
				}
			}
			function showWaitControls()
			{
				waitControls.style.display='';
			}		
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultFillingWO1" method="post" runat="server">
			<table align="center">
				<tr>
					<td align="center" colSpan="6"><asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Fase de Llenado</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 172px"><asp:label id="lblSecuencia" runat="server" CssClass="standard-text"> Secuencia:</asp:label></td>
					<td style="WIDTH: 175px"><asp:textbox id="txtSecuencia" BorderStyle="Groove" Width="200px" CssClass="Standard-text" ReadOnly="True"
							Runat="server"></asp:textbox></td>
					<td style="WIDTH: 6px">
						<asp:label id="Label6" runat="server" Height="16px" CssClass="standard-text">Fecha:</asp:label></td>
					<td><asp:textbox id="txtFecha" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 172px">
						<asp:label id="Label4" runat="server" Height="16px" CssClass="standard-text">UTEC:</asp:label></td>
					<td style="WIDTH: 175px"><asp:textbox id="txtUTEC" BorderStyle="Groove" Width="200px" CssClass="Standard-text" ReadOnly="True"
							Runat="server"></asp:textbox></td>
					<td style="WIDTH: 6px">
						<asp:label id="Label7" runat="server" Height="16px" CssClass="standard-text">Láminas:</asp:label></td>
					<td><asp:textbox id="txtCantidad" BorderStyle="Groove" CssClass="Standard-text" ReadOnly="True" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 172px">
						<P>
							<asp:label id="Label5" runat="server" Height="16px" CssClass="standard-text">Familia Producto:</asp:label></P>
					</td>
					<td style="WIDTH: 175px"><asp:textbox id="txtFamilia" BorderStyle="Groove" Width="200px" CssClass="Standard-text" Runat="server"></asp:textbox></td>
					<td style="WIDTH: 6px"><asp:label id="lblLinea2" runat="server" CssClass="standard-text">Línea:</asp:label></td>
					<td><asp:textbox id="txtLinea2" runat="server" BorderStyle="Groove" CssClass="standard-text" ReadOnly="True"></asp:textbox></td>
				</tr>
				<TR>
					<td style="WIDTH: 172px"></td>
					<td style="WIDTH: 175px"></td>
					<td style="WIDTH: 6px"></td>
					<td></td>
				</TR>
				<TR>
					<TD bgColor="#276187" colSpan="6"><asp:label id="Label1" runat="server" Font-Bold="True" Height="16px" ForeColor="White" CssClass="standard-text">Llene los moldes de acuerdo a la siguiente información:</asp:label></TD>
				</TR>
				<TR>
					<td style="WIDTH: 172px; HEIGHT: 22px" bgColor="lightgrey"><asp:label id="lblKilos" runat="server" Height="16px" CssClass="standard-text">Kilos por Lamina</asp:label>
						<asp:textbox id="txtKilos" runat="server" BorderStyle="Groove" CssClass="standard-text" ReadOnly="True"></asp:textbox></td>
					<td style="WIDTH: 263px; HEIGHT: 22px" bgColor="#d3d3d3" colspan="2"><asp:label id="lblTolen" runat="server" Height="16px" Width="98px" CssClass="standard-text">Tolerancia</asp:label>
						<asp:textbox id="txtTolen" runat="server" BorderStyle="Groove" Width="65px" CssClass="standard-text"
							ReadOnly="True"></asp:textbox><asp:label id="Label2" runat="server" Height="16px" CssClass="standard-text">gramos</asp:label></td>
					<TD style="HEIGHT: 22px" bgColor="lightgrey"><asp:label id="Label3" runat="server" Height="16px" CssClass="standard-text">KCT</asp:label>
						<asp:textbox id="txtKCT" runat="server" BorderStyle="Groove" CssClass="standard-text"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 172px"></TD>
					<TD style="WIDTH: 175px" colspan="3">
						<asp:datagrid id="dgdQtyOlla" BorderStyle="None" BorderColor="White" DataKeyField="NumeroOlla"
							AllowSorting="True" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana"
							runat="server" Width="100%">
							<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Numero de Olla">
									<HeaderStyle HorizontalAlign="Left" Width="300px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="300px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=txtLaminas Runat="server" CssClass="Standard-text" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<Columns>
								<asp:TemplateColumn HeaderText="Numero de Láminas">
									<HeaderStyle HorizontalAlign="Left" Width="300px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="300px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="Label8" Runat="server" CssClass="Standard-text" Width="120px" Text='<%# DataBinder.Eval(Container, "DataItem.NoLaminas") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td colSpan="5"><asp:textbox id="txtPiso" runat="server" Height="48px" BorderStyle="Groove" Width="750px" ReadOnly="True"
							TextMode="MultiLine" CssClass="standard-text"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="5">
						<table width="100%" align="center">
							<TR height="40">
								<TD vAlign="top" align="center" width="150">
									<asp:button id="btnAgregarMensaje" runat="server" CssClass="botonesInput" Width="200px" Text="Mensaje de piso"></asp:button></TD>
								<TD vAlign="top" align="center" width="140">
									<asp:button OnClientClick="return isDigit(this.value,this)" id="btnLiberar" CssClass="botonesInput" Runat="server"
										Width="80px" Text="Liberar"></asp:button></TD>
								<TD vAlign="top" align="center" width="140">
									<asp:button OnClientClick="return isDigit(this.value,this)" id="btnAgregar" CssClass="botonesInput" Runat="server"
										Width="80px" Text="Aceptar"></asp:button></TD>
								<TD vAlign="top" align="center" width="140">
									<asp:button id="btnCancel" CssClass="botonesInput" Runat="server" Width="90px" Text="Regresar"></asp:button></TD>
								<TD vAlign="top" align="center" width="100">
									<DIV id="waitControls" style="DISPLAY: none" title="100">
										<TABLE id="Table1" width="100">
											<TR>
												<TD vAlign="top" align="center" colSpan="3">
													<P align="center">
														<asp:label id="Label16" runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
														<asp:image id="Image1" runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P>
												</TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
						</table>
						<asp:label id="lblErrorMsg" Runat="server" ForeColor="Red" CssClass="standard-text"></asp:label></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
