
<%@ Page language="c#" Codebehind="CargarFantasmas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.CargarFantasmas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoadProduccionPrograma</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="Stylesheet" type="text/css" href="/SicalNet/Css/sical-menu.css" />
		<script type="text/javascript" src="/SicalNet/Scripts/sical-menu.js"></script>

		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->
		<script language="JavaScript">
			function showWaitControls()
			{
				waitControls.style.display='';
			}			
			function ShowTitle()
			{
				window.frames["top"].document.title = "SICAL  - Logística - Cargar Programa de Producción"
			}

			function ConfirmImport(msg)
			{
				var hdn = document.getElementById('hdnFileInput');
				if(hdn==null) 
				{
					alert("no se encontro el hidden");
					return;
				}
				if(document.forms[0].fileInput.value!="")
				{
					if(hdn.value=="" || hdn.value==document.forms[0].fileInput.value)
					{
						if(confirm(msg))
						{
							document.forms[0].submit();
							return true;
						}
						else
						{
							return false;
						}
					}
				}
			}
			function checkInputFile()
			{
				if(document.forms[0].fileInput.value=="")
				{
					alert("Debe especificar el archivo de materials a cargar");
					waitControls.style.display='none';
					return false;
				}
				return true;
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
	<body MS_POSITIONING="GridLayout">
		<form id="LoadProduccionPrograma" method="post" encType="multipart/form-data" runat="server"
			onsubmit="return checkInputFile();">
			<table style="BORDER-COLLAPSE: collapse" width="700" align="center">
				<TBODY>
					<tr>
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td align="center" colSpan="3"><br>
							<asp:label id="Label1" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Cargar de Archivo con Materiales Fantasmas</asp:label>
							<hr>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="3"><asp:label id="Label2" runat="server" CssClass="standard-text">Proporcione el nombre del archivo en formato Excel (c) que contiene  la lista de los materiales fantasmas <br> (Fantasmas.xls) y presione el botón "Cargar Programa" <br></asp:label></TD>
					</TR>
					<TR>
						<TD align="center"><INPUT id="fileInput" style="WIDTH: 489px; FONT-FAMILY: Verdana; HEIGHT: 18px; FONT-SIZE: xx-small"
								type="file" name="fileInput" runat="server" size="62">&nbsp;<INPUT id="hdnFileInput" type="hidden" runat="server" NAME="hdnFileInput" style="WIDTH: 16px; HEIGHT: 22px"
								size="1"></TD>
						<TD align="center"></TD>
						<TD align="center"><asp:button id="AddPrograma" runat="server" CssClass="standard-text" CausesValidation="False"
								Text="Cargar Programa" Width="126px"></asp:button></TD>
					</TR>
					<TR>
						<TD class="Normal" align="center" colSpan="4">
							<DIV id="waitControls" style="DISPLAY: none">
								<TABLE>
									<TR>
										<TD align="center"><asp:image id="Image2" runat="server" ImageUrl="../../images/waitImage.gif"></asp:image></TD>
									</TR>
									<TR>
										<TD align="center"><asp:label id="Label4" runat="server" CssClass="standard-text"> Este proceso puede demorar varios segundos, debido a que en este momento <br> estamos subiendo y validando los materiales Fantasma desde el archivo de Excel .<br>Agradecemos su paciencia.</asp:label></TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><asp:label id="lblErrMsg" runat="server" Font-Size="X-Small" Font-Bold="True" CssClass="standard-text"></asp:label></TD>
					<tr>
						<TD colSpan="3">
						</TD>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
