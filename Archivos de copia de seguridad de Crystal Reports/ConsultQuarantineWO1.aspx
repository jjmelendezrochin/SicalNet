<%@ Page language="c#" Codebehind="ConsultQuarantineWO1.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultQuarantineWO1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultQuarantineWO1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<script language=javascript>	
		function showWaitControls()
		{
			waitControls.style.display='';
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
				var Area = com.concat("_lblArea")
				var AreaId = com1.concat("_lblDefArea")
				document.getElementById(idDefecto).style.display="none"
				document.getElementById(Area).innerHTML="Envio Producto Terminado"
				document.getElementById(AreaId).innerHTML="15"
				
			}
			else if(document.getElementById(r2id).checked==true)
			{
				var com = num
				var com1 = num								
				var idDefecto= num.concat("_ddlDefecto")
				var AreaId = com1.concat("_lblDefArea")
				var Area = com.concat("_lblArea")
				document.getElementById(idDefecto).style.display="inline"
				document.getElementById(Area).innerHTML="Segundas"
				document.getElementById(AreaId).innerHTML="17"
			}
			else if(document.getElementById(r3id).checked==true)
			{
				var com = num
				var com1 = num										
				var idDefecto= num.concat("_ddlDefecto")
				var Area = com.concat("_lblArea")
				var AreaId = com1.concat("_lblDefArea")
				document.getElementById(idDefecto).style.display="inline"
				document.getElementById(Area).innerHTML="Terceras"
				document.getElementById(AreaId).innerHTML="18"
			}
				
		}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="ConsultQuarantineWO1" method="post" runat="server">
			<table align="center">
				<TBODY>
					<tr>
						<td align="center" colSpan="5"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True"> Fase de Pendientes/Cuarentena</asp:label>
							<hr>
						</td>
					</tr>
					<TR>
						<TD><asp:label id="lblSecuencia" runat="server" CssClass="standard-text">No. de Secuencia</asp:label></TD>
						<TD><asp:textbox id="txtSecuencia" runat="server" Width="125px" CssClass="standard-text" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox></TD>
						<TD></TD>
						<TD ><asp:label id="lblFecha2" runat="server" CssClass="standard-text">Fecha:</asp:label></TD>
						<TD><asp:textbox id="txtFecha2" runat="server" Width="124px" CssClass="standard-text" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblUtec" runat="server" CssClass="standard-text">UTEC</asp:label></TD>
						<TD><asp:textbox id="txtUtec" runat="server" Width="125px" CssClass="standard-text" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox></TD>
						<TD></TD>
						<TD><asp:label id="lblCantidad" runat="server" CssClass="standard-text">Láminas:</asp:label></TD>
						<TD><asp:textbox id="txtCantidad" runat="server" Width="125px" CssClass="standard-text" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="lblFamilia" runat="server" CssClass="standard-text">Familia</asp:label></TD>
						<TD><asp:textbox id="txtFamilia" runat="server" Width="125px" CssClass="standard-text" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox></TD>
						<TD></TD>
						<TD><asp:label id="lblLinea2" runat="server" CssClass="standard-text">Linea</asp:label></TD>
						<TD><asp:textbox id="txtLinea2" runat="server" Width="125px" CssClass="standard-text" BorderStyle="Groove"
								ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD  colSpan="5"><FONT size="2"><B><asp:label id="Label1" runat="server" CssClass="standard-text">Empaque</asp:label></B></FONT></TD>
					</TR>
					<TR>
						<TD colSpan="5"><asp:datagrid id="dgdEmpaque" runat="server" Width="100%" Height="120px" BorderStyle="None" AutoGenerateColumns="False"
								Font-Name="Verdana" FontSize="11px" AllowSorting="True" Font-Names="Verdana" CellPadding="2" BackColor="#E0E0E0">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Material">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblMaterial" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server" CssClass="standard-text">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Descripcion">
										<HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="300px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:Label ID="lblDesc" Runat=server Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Cantidad">
										<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="150px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:Label ID="lblCantidade" Runat=server Text='<%# DataBinder.Eval(Container,"DataItem.Cantidad")%>' CssClass="standard-text">
											</asp:Label>
											<asp:Label ID="lblUnidad" Runat=server Text='<%# DataBinder.Eval(Container,"DataItem.Unidad")%>' CssClass="standard-text">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD colSpan="5"></TD>
					</TR>
					<TR>
						<TD colSpan="5" bgColor="#276187">
							<asp:label id="Label4" runat="server" Font-Bold="True" CssClass="standard-text" ForeColor="White">Material Recuperado</asp:label></TD>
					</TR>
					<TR>
						<TD bgColor="#e0e0e0">
							<asp:label id="Label5" runat="server" CssClass="standard-text">Material Recuperado:</asp:label></TD>
						<TD bgColor="#e0e0e0">
							<asp:TextBox id="txtMaterialRecuperado" runat="server" CssClass="standard-text" BorderStyle="Groove"
								AutoPostBack="True"></asp:TextBox>
							<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../../Images/Find.gif"></asp:ImageButton></TD>
						<TD colspan="3" bgColor="#e0e0e0">
							<asp:TextBox id="txtDescripcion" runat="server" CssClass="standard-text" BorderStyle="None" Width="330px"
								ReadOnly="True" BackColor="#E0E0E0"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD bgColor="#e0e0e0">
							<asp:label id="Label6" runat="server" CssClass="standard-text">No. Orden de Recuperación:</asp:label></TD>
						<TD bgColor="#e0e0e0">
							<asp:TextBox id="txtOrdenRecuperacion" runat="server" CssClass="standard-text" BorderStyle="Groove"></asp:TextBox></TD>
						<TD bgColor="#e0e0e0" colSpan="3"></TD>
					</TR>
					<TR>
						<TD colSpan="5"></TD>
					</TR>
					<TR>
						<TD colSpan="5">
							<asp:label id="Label3" runat="server" CssClass="standard-text" Font-Bold="True">Detalle Por Lamina</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="5"><asp:datagrid id="dgdDefecto" runat="server" Width="100%" Height="120px" BorderColor="White" BorderStyle="None"
								AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" Font-Names="Verdana"
								CellPadding="2" BackColor="#E0E0E0">
								<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="No Lamina">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
										<ItemTemplate>
											<asp:label id="lblLamina" Text='<%# DataBinder.Eval(Container, "DataItem.NoLamina") %>' Runat="server" CssClass="standard-text">
											</asp:label>
											<asp:label id="lblCuarentena" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cuarentena") %>' Visible=False>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Calidad de Lamina">
										<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButtonList ID="RDLCalidad" Runat="server" RepeatDirection="Horizontal" CssClass="standard-text" onclick="showid(this.id)">
												<asp:ListItem Value="1">1ra</asp:ListItem>
												<asp:ListItem Value="2">2da</asp:ListItem>
												<asp:ListItem Value="3">3ra</asp:ListItem>
											</asp:RadioButtonList>
											<asp:label id=lblCalidad Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Calificacion") %>' Visible="False" CssClass="standard-text">
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Defecto">
										<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:DropDownList id="ddlDefecto" CssClass="standard-text" Runat="server" style="DISPLAY: none"></asp:DropDownList>
											<asp:label id="lblDefecto" Text='<%# DataBinder.Eval(Container, "DataItem.IdDefecto") %>' Runat="server" CssClass="standard-text" Visible=False>
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Area Destino">
										<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Width="150px" CssClass="grid-first-item"></ItemStyle>
										<ItemTemplate>
											<asp:Label ID="lblArea" Runat="server" CssClass="standard-text"></asp:Label>
											<asp:Label ID="lblDefArea" Runat=server Text='<%# DataBinder.Eval(Container, "DataItem.IdAreaDestino") %>' CssClass="standard-text" style="DISPLAY: none">
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD colSpan="5"><asp:label id="Label2" runat="server" CssClass="standard-text" Font-Bold="True">Mensajes de Piso</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="5"><asp:textbox id="txtPiso" runat="server" Width="100%" Height="48px" CssClass="standard-text"
								BorderStyle="Groove" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" width=150 vAlign=top>
							<asp:Button id="btnMensaje" CssClass="botonesInput" Runat="server" Text="Mensaje de Piso" Width="100px"></asp:Button></TD>
						<TD align="center" width=140 vAlign=top>
							<asp:Button id="btnLiberar" Width="80px" CssClass="botonesInput" Runat="server" Text="Liberar"></asp:Button></TD>
						<TD align="center" width=140 vAlign=top>
							<asp:Button id="btnAcceptar" Width="80px" CssClass="botonesInput" Runat="server" Text="Aceptar"></asp:Button></TD>
						<TD align="center" width=140 vAlign=top>
							<asp:Button id="btnCancelar" Width="80px" CssClass="botonesInput" Runat="server" Text="Regresar"></asp:Button></TD>
						<TD align="right" Width="100" vAlign=top>
	<DIV id="waitControls" style="DISPLAY: none">
      <TABLE id=Table1 width=50>
        <TR>
          <TD vAlign=top align=center colSpan=3>
            <P align=center>
<asp:label id=Label7 runat="server" CssClass="standard-text">Procesando...</asp:label><BR>
<asp:image id=Image1 runat="server" ImageUrl="../../Images/waitImage.gif"></asp:image></P></TD></TR></TABLE></DIV>
							</TD>
					</TR>
					<TR>
						<TD align="left" colspan="5"><asp:label id="lblErrorMsg" CssClass="standard-text" Runat="server" ForeColor="Red" Font-Bold="True"></asp:label></TD>
					</TR>
				</TBODY>
			</table>
		</form>
		<script language="javascript">
				var p=2
			for(i=0;i<document.forms[0].length;i++)
				{
					
					if (document.forms[0].elements[i].id.indexOf('RDLCalidad_1') != -1)
					{					
						var r1id=document.forms[0].elements[i].id
						if(document.getElementById(r1id).checked==true)
						{
												
							var com="dgdDefecto__ctl"
							var idDefecto= com.concat(p,"_ddlDefecto")
							document.getElementById(idDefecto).style.display="inline"
							p++
						}
					}
					else if (document.forms[0].elements[i].id.indexOf('RDLCalidad_2') != -1)
					{					
						var r1id=document.forms[0].elements[i].id
						if(document.getElementById(r1id).checked==true)
						{
								
							var com="dgdDefecto__ctl"
							var idDefecto= com.concat(p,"_ddlDefecto")
							document.getElementById(idDefecto).style.display="inline";
							p++
						}
					}
					else if (document.forms[0].elements[i].id.indexOf('RDLCalidad_0') != -1)
					{					
						var r1id=document.forms[0].elements[i].id
						if(document.getElementById(r1id).checked==true)
						{
												
							var com="dgdDefecto__ctl"
							var idDefecto= com.concat(p,"_lblArea")
							document.getElementById(idDefecto).innerHTML="Envio Producto Terminado";
							p++
						}
					}					
					
				}
		</script>
	</body>
</HTML>
