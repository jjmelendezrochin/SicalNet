<%@ Page language="c#" Codebehind="Bottom.aspx.cs" AutoEventWireup="false" Inherits="ExportaExcel1.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Exportar Catálogos</title>
		<meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<script language="javascript">
		
		function ShowWait()
		{
			document.getElementById("divWait").style.display = "";
		}
		
		function HideWait() {
			document.getElementById("divWait").style.display = "none";
		}
		
		</script>
				
		
	</HEAD>
	<body MS_POSITIONING="FormLayout" onload='HideWait();'>
		<center>
			
			<asp:label style="POSITION: absolute; LEFT: 448px; Z-INDEX: 101; TOP: 8px" id="lblTitulo" runat="server"
				Width="496px" Font-Size="Large" ForeColor="DarkBlue" Font-Bold="True"></asp:label>
				<br>
				<br>
				
				<div id="divWait" 
            LEFT:0px;
            Z-INDEX:9999;
            DISPLAY:none;
            TOP:0px;
            BACKGROUND-COLOR:white">
				<img src="../../images/waitimage.gif" border="0">
				<br>
				<br>
				<font face="Verdana" size="3">Consulta de datos por favor espere... </font>
			</div>		
		</center>
		<BR>
		<BR>
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id="DataGrid1" runat="server" Width="100%" Font-Size="X-Small" GridLines="Vertical"
				CellPadding="3" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="None"
				Height="46px" Font-Names="Verdana">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle BorderWidth="2px" ForeColor="Black" BorderStyle="Solid" BorderColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="2px" ForeColor="White" BorderStyle="Solid"
					BorderColor="Black" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>&nbsp;
		</form>
	</body>
</HTML>
