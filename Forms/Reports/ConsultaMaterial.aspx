<%@ Page language="c#" Codebehind="ConsultaMaterial.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ConsultaMaterial" %>
<HTML>
	<HEAD>
		<title>ProduccionRpt</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styloDESC.CSS">
		<script language="javascript">	
		function GetDate(CtrlName)        
			{            
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=270,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=yes,resizable=no");
			} 
			function ShowTitle()
			{
				//window.frames["top"].document.title = "SICAL  - Reporte Consulta Material"
				//if(document.getElementById("txtruta").value == ""){
				//	document.getElementById("vinculos").style.visibility=="hidden";
				//	document.getElementById("vinculos").style.display='none';
				//}
				//else{
					document.getElementById("vinculos").style.visibility=="visible";
					document.getElementById("vinculos").style.display='inline';
				//}
			}	
						
			function showWaitControls()
			{
				waitControls.style.display='';				
			}
			
			function hideWaitControls()
			{				
				waitControls.style.display='none';				
			}		
			
			function ActivaVinculos(sredirectPath, ruta){
				document.getElementById("waitControls").style.display='none';				
				document.getElementById("txtruta").value=sredirectPath;
				document.getElementById("txtarchivo").value=ruta;
				
				document.getElementById("vinculos").style.visibility="visible";
				vinculos.style.display='inline';
			}
			
			function Descarga(itipo){
				switch(itipo) {
					case 0:
						//ruta = document.getElementById("txtruta").value + "materiales_"+ document.getElementById("txtarchivo").value + ".xls";							
						window.open("ExportaMateriales.aspx");
						break;
					case 1:
						ruta = document.getElementById("txtruta").value + "colores_"+ document.getElementById("txtarchivo").value + ".xls";							
						break;
					case 2:
						ruta = document.getElementById("txtruta").value + "aditivos_"+ document.getElementById("txtarchivo").value + ".xls";							
						break;
					case 3:
						ruta = document.getElementById("txtruta").value + "pvc_"+ document.getElementById("txtarchivo").value + ".xls";							
						break;
					case 4:
						ruta = document.getElementById("txtruta").value + "pesos_"+ document.getElementById("txtarchivo").value + ".xls";							
						break;		
					case 5:
						ruta = document.getElementById("txtruta").value + "presentacion_"+ document.getElementById("txtarchivo").value + ".xls";							
						break;
					default:
						
				} 
				//alert(ruta);			
				window.location = ruta;
			}
		</script>
	</HEAD>
	<body onload="ShowTitle();  hideWaitControls();" MS_POSITIONING="GridLayout">
		<form id="ProduccionRpt" method="post" runat="server">
			<br>
			<br>
			<table width="445" align="center" style="WIDTH: 445px; HEIGHT: 53px">
				<tr>
					<td colSpan="6" align="center" style="HEIGHT: 36px">
						<asp:label id="lblTitle" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow">Reporte Consulta Materiales</asp:label>
					</td>
				</tr>
				<tr>
					<td colspan="6" height="50"></td>
				</tr>
				<tr>
					<td align="center" style="WIDTH: 33%">
						<asp:button style="Z-INDEX: 0" id="cmdImprimir" runat="server" CssClass="botonesInput" Width="62px"
							Text="Exportar"></asp:button>
					</td>
					<td style="WIDTH: 33%"></td>
					<td align="center" style="WIDTH: 34%">
						<asp:button style="Z-INDEX: 0" id="cmdCancelar" runat="server" CssClass="botonesInput" Width="62px"
							Text="Cancelar"></asp:button>
					</td>
				</tr>
			</table>
			<br>
			<DIV style="DISPLAY: none" id="waitControls" align="center">
				<TABLE style="Z-INDEX: 0; WIDTH: 448px; HEIGHT: 94px">
					<TR>
						<TD align="center"><asp:image id="Image2" runat="server" ImageUrl="../../images/waitImage.gif"></asp:image></TD>
					</TR>
					<TR>
						<TD align="center"><asp:label id="Label4" runat="server" CssClass="standard-text"> Cargando información favor de esperar</asp:label></TD>
					</TR>
				</TABLE>
			</DIV>
			<CENTER>
				<DIV id="vinculos" align="center">
					<TABLE style="Z-INDEX: 0; WIDTH: 291px; HEIGHT: 233px">
						<TR>
							<TD align="center"><input type="hidden" id="txtruta" style="Z-INDEX: 0; WIDTH: 526px; HEIGHT: 22px" size="82"></TD>
						</TR>
						<TR>
							<TD align="center"><input type="hidden" id="txtarchivo" style="WIDTH: 511px; HEIGHT: 22px" size="79"></TD>
						</TR>
						<TR>
							<TD align="left">
								<ul>
									<li>
										<a href="javascript:Descarga(0);"><font size="2">Descargar Materiales</font></a>
									<li>
										<a href="javascript:Descarga(1);"><font size="2">Descargar Colores</font></a>
									<li>
										<a href="javascript:Descarga(2);"><font size="2">Descargar Aditivos</font></a>
									<li>
										<a href="javascript:Descarga(3);"><font size="2">Descargar Pvc</font></a>
									<li>
										<a href="javascript:Descarga(4);"><font size="2">Descargar Tabla de Pesos</font></a>
									<li>
										<a href="javascript:Descarga(5);"><font size="2">Descargar Presentaciones</font></a></li>
								</ul>
							</TD>
						</TR>
					</TABLE>
				</DIV>
			</CENTER>
		</form>
	</body>
</HTML>
