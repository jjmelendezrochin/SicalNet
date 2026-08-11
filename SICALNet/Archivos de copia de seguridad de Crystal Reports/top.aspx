<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="top.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.top" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Reporte de Materiales</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<asp:literal id="ltrRefresh" runat="server"></asp:literal><LINK rel="stylesheet" type="text/css" href="..\..\styloDESC.CSS">
		<script language="javascript">
		function MostrarTabla() {
			var seleccion = document.getElementById("lstReporte").selectedIndex;
			var txtIni = document.getElementById("txtInitial").value;
			var txtFin = document.getElementById("txtFinal").value;
			switch (seleccion){
				case 1:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=1";
					break;
				case 2:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=2";			
					break;
				case 3:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=3";			
					break;
				case 4:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=4";		
					break;
				case 5:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=5";			
					break;
				case 6:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=6";		
					break;
				case 7:
					window.parent.frames["bottom"].location = "bottom.aspx?bExcel=0&Tabla=7&FechaIni="+txtIni+"&FechaFin="+txtFin;		
					break;
			}
		}
		
		function cambio(){			
			var valor = document.getElementById("lstReporte").value;
			document.getElementById("idReporte").value = valor;
			if (valor == 6){
			}
		}
		
		function GetDate(CtrlName)        
			{   
				ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
			} 

		function Exportar() {
			var seleccion = document.getElementById("lstReporte").selectedIndex;
			var txtIni = document.getElementById("txtInitial").value;
			var txtFin = document.getElementById("txtFinal").value;
				switch (seleccion){
					case 1:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=1";
						break;
					case 2:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=2";			
						break;
					case 3:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=3";			
						break;
					case 4:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=4";		
						break;
					case 5:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=5";			
						break;
					case 6:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=6";		
						break;
					case 7:
						window.parent.frames["bottom"].location = "bottom.aspx?bExcel=1&Tabla=7&FechaIni="+txtIni+"&FechaFin="+txtFin;		
						break;	
				}
		}
		
		function ShowWait()
		{
			document.getElementById("divWait").style.display = "block";
			document.getElementById("divDatos").style.display = "none";
			return true;
		}
		
		function HideWait()
		{
			var div = document.getElementById("divWait");
			document.getElementById("divDatos").style.display = "block";

			if(div != null)
				div.style.display = "none";
		}
		
		function ShowWaitExportar()
		{
			document.getElementById("divWait").style.display = "block";
			document.getElementById("divDatos").style.display = "none";

			setTimeout(function()
			{
				document.getElementById("divWait").style.display = "none";
			}, 10000);

			return true;
		}
		
		
		</script>
		<style type="text/css">
			#divWait { HEIGHT: 100%; WIDTH: 100%; POSITION: fixed; TEXT-ALIGN: center; LEFT: 0px; Z-INDEX: 9999; DISPLAY: none; TOP: 0px; BACKGROUND-COLOR: white }
			#divWaitContent { FONT-SIZE: 14px; FONT-FAMILY: Verdana; MARGIN-TOP: 30px; FONT-WEIGHT: bold }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="HideWait();">
		<table style="BORDER-COLLAPSE: collapse" border="0" width="800" align="center">
			<TBODY>
				<tr>
					<td bgColor="#003366" colSpan="6" align="left"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
				</tr>
			</TBODY>
		</table>
		<form id="ConsultReport" method="post" runat="server">
			<br>
			<div style="TEXT-ALIGN:center">
				<asp:Label ID="Label2" runat="server" Width="496px" Font-Size="Large" ForeColor="DarkBlue"
					Font-Bold="True">
					Reporte de Materiales
				</asp:Label>
			</div>
			<br>
			<center>
				<table id="Table1" width="60%" align="center">
					<tr>
						<td align="center">
							<asp:Label ID="Label3" runat="server" Font-Size="Smaller" ForeColor="Black">
								Seleccionar reporte
							</asp:Label>
						</td>
						<td align="center">
							<asp:DropDownList ID="lstReporte" runat="server" CssClass="standard-text" onchange="cambio()">
								<asp:ListItem Value="0">** Seleccionar **</asp:ListItem>
								<asp:ListItem Value="1">Aditivos</asp:ListItem>
								<asp:ListItem Value="2">Colores</asp:ListItem>
								<asp:ListItem Value="3">Materiales</asp:ListItem>
								<asp:ListItem Value="4">Presentaciones</asp:ListItem>
								<asp:ListItem Value="5">Pvc</asp:ListItem>
								<asp:ListItem Value="6">Tabla de pesos</asp:ListItem>
								<asp:ListItem Value="7">Interface Datasul</asp:ListItem>
							</asp:DropDownList>
							<input type="hidden" id="idReporte" runat="server">
						</td>
						<td align="center">
							<asp:Button ID="cmdCatalogo" runat="server" Text="Mostrar" CssClass="botonesInput" OnClick="cmdCatalogo_Click"
								OnClientClick="return ShowWait();" />
						</td>
						<td align="center">
							<asp:Button ID="cmdExportar" runat="server" Text="Exportar" CssClass="botonesInput" OnClick="cmdExportar_Click"
								OnClientClick="return ShowWait();" />
						</td>
					</tr>
					<TR>
						<td colspan="4" height="10"></td>
					</TR>
					<tr>
						<td align="center">
							<asp:label id="lblInitial" Runat="server" Font-Size="Smaller">Fecha Inicial</asp:label>
						</td>
						<td>
							<asp:textbox id="txtInitial" CssClass="Standard-text" Runat="server" MaxLength="11" BorderStyle="Groove"></asp:textbox>
							<asp:image id="imgInitial" onmouseup="GetDate('txtInitial');" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
								AlternateText="Inicial Date"></asp:image>
						</td>
						<td align="center">
							<asp:label id="lblFinal" Runat="server" Font-Size="Smaller">Fecha Final</asp:label>
						</td>
						<td>
							<asp:textbox id="txtFinal" CssClass="Standard-text" Runat="server" MaxLength="11" BorderStyle="Groove"></asp:textbox>
							<asp:image id="imgFinal" onmouseup="GetDate('txtFinal');" Runat="server" ImageUrl="../../Images/icon-calendar.gif"
								AlternateText="Final Date"></asp:image>
						</td>
					</tr>
					<TR>
						<td colspan="4" height="10"></td>
					</TR>
					<tr>
						<td colSpan="4" align="center">
							<asp:label id="Label1" Runat="server" Text="Fecha Inicial *" ForeColor="#0000C0" Font-Size="Smaller">* Las fechas
								solo se usan para la Interface a Datasul</asp:label></td>
					</tr>
				</table>
				<div id="divWait">
					<div id="divWaitContent">
						<img src="../../images/waitimage.gif" border="0">
						<br>
						<br>
						Consultando información.<br>
						Por favor espere...
					</div>
				</div>
				<br>
				<div id='divDatos'>
					<div style="TEXT-ALIGN:center">
						<asp:Label ID="lblTitulo" runat="server" Width="496px" Font-Size="Medium" ForeColor="DarkBlue"
							Font-Bold="True"></asp:Label>
					</div>
					<br>
					<asp:datagrid id="DataGrid1" runat="server" Width="80%" Font-Size="X-Small" GridLines="Vertical"
						CellPadding="3" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="None"
						Height="46px" Font-Names="Verdana">
						<selecteditemstyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></selecteditemstyle>
						<alternatingitemstyle BackColor="Gainsboro"></alternatingitemstyle>
						<itemstyle BorderWidth="2px" ForeColor="Black" BorderStyle="Solid" BorderColor="Black" BackColor="#EEEEEE"></itemstyle>
						<headerstyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="2px" ForeColor="White" BorderStyle="Solid"
							BorderColor="Black" BackColor="#000084"></headerstyle>
						<footerstyle ForeColor="Black" BackColor="#CCCCCC"></footerstyle>
						<pagerstyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></pagerstyle>
					</asp:datagrid>
				</div>
			</center>
		</form>
	</body>
</HTML>
