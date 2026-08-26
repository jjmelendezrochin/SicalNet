<%@ Page language="c#" Codebehind="ConsultLiberationWO.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.LiberationPhase.ConsultLiberationWO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultInspectionWorkOrders</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:literal id="ltrRefresh" runat="server"></asp:literal>
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script src="http://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
		<script src="https://code.jquery.com/jquery-3.2.1.js"></script>
		<script language="javascript">		
			function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\..\\..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			}  
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  -Ordenes de Trabajo - Fase de Liberación"
			}	
			
		    function GeneraCbb(listasecuencias, listadatosencbb, selectionformula_secuencias, servercbb, listaordenes)
		    {
		    
				// Colocando la lista de secuencias
				var txtSecuencias = document.getElementById('txtSecuencias');
				var txtOrdenes = document.getElementById('txtOrdenes');
				txtSecuencias.value="";
				txtSecuencias.value=listasecuencias;
				txtOrdenes.value = "";
				txtOrdenes.value=listaordenes;
				
				// Colocando las secuencias del selection formula que vienen en la 2a variable
				var txtSecuenciasSelectionFormula = document.getElementById('txtSecuenciasSelectionFormula');
				txtSecuenciasSelectionFormula.value="";
				txtSecuenciasSelectionFormula.value=selectionformula_secuencias;
				
				var listacompleta=listadatosencbb + " _ " + listaordenes;
				// alert(listacompleta);
				var sRutaCompleta = "http://" + servercbb + "/ServicioWebCbb/api/servicio?secuenciasyordenes=" + listacompleta;
				// alert(sRutaCompleta);
				// ***************************************
				// Llamado al api que genera los códigos de barras
				// No mover la llamada a la url porque no funciona
				var xhttp = new XMLHttpRequest();
				xhttp.onreadystatechange=function(){
					if (this.readyState == 4 && this.status == 200)
					{
						var cmdEjecutaReporte = document.getElementById('cmdEjecutaReporte');
						cmdEjecutaReporte.click();						
						alert(this.responseText);						
					}
				};
				// Petición realizada en forma sincrona, debe esperar a que se concluya para 
				// continuar la ejecución de los demás procedimientos
				// En ambiente desarrollo				
				xhttp.open("GET",sRutaCompleta, true);
				// En ambiente de pruebas
				xhttp.setRequestHeader("Content-type", "application/json");
				xhttp.send();
				// ***************************************
		    }
		    
		    function onSuccess(result){
				alert(result);
		    }
		    
		    function onError(result){
				alert('Algo salio mal');
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
		<form id="ConsultInspectionWO" method="post" runat="server">
			<table style="BORDER-COLLAPSE: collapse" id="Table1" align="center">
				<tr>
					<td colSpan="5" align="left">
						<div id="sicalMenu"></div>
					</td>
				</tr>
				<tr>
					<td colSpan="5" align="center"><br>
						<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Ordenes de Trabajo - Fase de Liberación</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server" CssClass="standard-text">Fecha Inicial</asp:label><asp:label id="Label3" CssClass="standard-text" Runat="server" ForeColor="Red" Text="(dd-MMM-yyyy)"> * (dd-MMM-aaaa)</asp:label></td>
					<td><asp:label id="Label2" runat="server" CssClass="standard-text">Fecha Final</asp:label><asp:label id="Label4" CssClass="standard-text" Runat="server" ForeColor="Red" Text="(dd-MMM-yyyy)"> * (dd-MMM-aaaa)</asp:label></td>
					<td><asp:label id="lblLinea" runat="server" CssClass="standard-text" Width="50px">Linea</asp:label></td>
					<td><asp:label id="lblStatus" runat="server" CssClass="standard-text" Width="50px">Estado</asp:label></td>
				</tr>
				<tr>
					<td><asp:textbox id="txtFechaInicial" runat="server" CssClass="standard-text" Width="100px" MaxLength="11"
							BorderStyle="Groove">10-Sep-2019</asp:textbox><asp:imagebutton id="ImgFechaInicial" OnClientClick="return GetDate('txtFechaInicial');" runat="server" ImageUrl="../../../../Images/icon-calendar.gif"></asp:imagebutton></td>
					<td><asp:textbox id="txtFechaFinal" runat="server" CssClass="standard-text" Width="100px" MaxLength="11"
							BorderStyle="Groove">10-Sep-2019</asp:textbox><asp:imagebutton id="ImgFechaFinal" OnClientClick="return GetDate('txtFechaFinal');" runat="server" ImageUrl="../../../../Images/icon-calendar.gif"></asp:imagebutton></td>
					<td><asp:dropdownlist id="cboLinea" runat="server" CssClass="standard-text" Width="125px"></asp:dropdownlist></td>
					<td><asp:dropdownlist id="cboStatus" runat="server" CssClass="standard-text" Width="125px"></asp:dropdownlist></td>
					<td><asp:button id="cmdAceptar" runat="server" CssClass="botonesInput" Text="Aceptar" Width="80px"></asp:button></td>
				</tr>
				<TR>
					<TD><asp:regularexpressionvalidator id="revInitial" runat="server" CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							ControlToValidate="txtFechaInicial" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
					<TD><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="standard-text" Display="Dynamic"
							ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
							ControlToValidate="txtFechaFinal" ErrorMessage="Fecha incorrecta"></asp:regularexpressionvalidator></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px" colSpan="5" align="center">
						<hr>
						<asp:image style="Z-INDEX: 0" id="Image1" runat="server" Width="1px" Visible="False" Height="8px"></asp:image></TD>
				</TR>
				<tr>
					<td style="HEIGHT: 23px" colSpan="5" align="center">
							<asp:button id="btnImprimir" runat="server" CssClass="botonesInput" Text="Imprimir Etiqueta de Lote"
							Width="180px"></asp:button>
							<asp:button style="Z-INDEX: 0," 
								id="cmdEjecutaReporte" 
								runat="server" 								
								CssClass="botonesInput"
								Text="Ejecuta" Width="0px" 
								Height="0px"
								Visible="False">
							</asp:button>
						<asp:textbox id="txtSecuenciasSelectionFormula" Runat="server" Width="0px" Height="0px" Visible="False"></asp:textbox>
						<asp:textbox id="txtSecuencias" Runat="server" Width="0px" Height="0px" Visible="False"></asp:textbox>
						<asp:textbox id="txtOrdenes" Runat="server" Width="0px" Height="0px" Visible="False"></asp:textbox>
					</td>
					</TD></tr>
				<TR>
					<TD colSpan="5" align="center">
						<HR>
						&nbsp;</TD>
				</TR>
				<tr>
					<td colSpan="5" align="center"><asp:datagrid id="dgdInspectionWO" runat="server" Font-Names="Verdana" Width="770px" BorderStyle="None"
							AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" CellPadding="2" BorderColor="White">
							<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle HorizontalAlign="Center" Width="25px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="25px" CssClass="grid-item"></ItemStyle>
									<HeaderTemplate>
										<asp:CheckBox style="Z-INDEX: 0" id="chkSeleccionaTodos" runat="server" OnCheckedChanged="CheckAll"
											AutoPostBack="True"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="P">
									<HeaderStyle HorizontalAlign="Center" Width="25px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="25px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemPrioridad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' Runat="server" Width="25px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Fecha">
									<HeaderStyle HorizontalAlign="Center" Width="85px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="85px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemFecha CssClass="standard-text" Text='<%# String.Format("{0:dd-MMM-yyyy}",DataBinder.Eval(Container, "DataItem.Fecha")) %>' Runat="server">
										</asp:label>
										<asp:label id=ItemFechaMod CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.FechaMod") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Secuencia">
									<HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemSecuencia CssClass="standard-text" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemCodigoSAP CssClass="standard-text" Width="40px" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="KCT">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="ItemKCT" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.KCT") %>' Runat="server" Width="30px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Lote">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="ItemLote" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Lote") %>' Runat="server" Width="30px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Cant.">
									<HeaderStyle HorizontalAlign="Center" Width="20px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="20px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemCantidad CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Med.">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id="ItemMedida" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.OtraMedida") %>' Runat="server" Width="30px">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descripci&#243;n">
									<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="250px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemDescripcion CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemIdMedida CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdMedida") %>' Runat="server" Visible="False">
										</asp:label>
										<asp:label id=ItemEspesor Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>' CssClass="standard-text" Visible="False">
										</asp:label>
										<asp:label id=ItemIdFamiliaProducto Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProducto") %>' CssClass="standard-text" Visible="False">
										</asp:label>
										<asp:label id=ItemDescFamiliaProducto Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DescFamiliaProducto") %>' CssClass="standard-text" Visible="False">
										</asp:label>
										<asp:label id=ItemIdPresentacion Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IdPresentacion") %>' CssClass="standard-text" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="L&#237;nea">
									<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemLineaDesc CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemIdLinea CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Runat="server" Visible="False">
										</asp:label>
										<asp:label id=ItemIdPlanta Text='<%# DataBinder.Eval(Container, "DataItem.IdPlanta") %>' CssClass="standard-text" Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Estado">
									<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=ItemStatusDesc CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' Runat="server">
										</asp:label>
										<asp:label id=ItemIdStatus CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td colSpan="5"><asp:label id="lblErrorMsg" runat="server" Font-Bold="True" CssClass="standard-text" ForeColor="Red"></asp:label></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
