<%@ Page language="c#" Codebehind="ConsultBitacora.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.ConsultBitacora" %>
<%@ Register TagPrefix="uc1" TagName="ProgrammaGrid" Src="../../Controls/ConsultBitacora.ascx" %>
<script language="javascript">	
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL  - Consultar Programa de Producción"
			}
</script>
<link rel="stylesheet" type="text/css" href="/SicalNet/Css/sical-menu.css">
<script type="text/javascript" src="/SicalNet/Scripts/sical-menu.js"></script>
<script type="text/javascript">
    document.addEventListener(
        "DOMContentLoaded",
        function () {
            SicalMenu.init("sicalMenu");
        }
    );
</script>
<!--<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">-->
	<body text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
		onload="ShowTitle()">
		<form id="ProductionProgram" method="post" runat="server">
			<table align="center" width="700" height="0" style="BORDER-COLLAPSE: collapse">
				<TBODY>
					<tr>
						<td align="left" colSpan="5">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					<tr>
						<td colspan="3" align="center"><br>
							<asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Size="14" Font-Bold="True"> Consultar Bitacora</asp:label>
							<hr>
							<asp:Label id="Label1" runat="server" CssClass="standard-text"> Seleccione la fecha que desea consultar</asp:Label>
						</td>
					</tr>
					<tr>
						<td colspan="3" width="100%" align="center">
							<uc1:ProgrammaGrid id="grdBitacora" runat="server"></uc1:ProgrammaGrid>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
