<%@ Page language="c#" Codebehind="NewMenu.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.NewMenu" %>
<%@ Register TagPrefix="cc1" Namespace="CYBERAKT.WebControls.Navigation" Assembly="ASPnetMenu" %>
<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../Controls/mainMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NewMenu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
		<script type="text/javascript" src="stmenu.js">
		<script language="javascript">	
			function ShowTitle()
			{
					window.frames["top"].document.title = "SICAL"
			}			
		</script>
	</HEAD>
	<body>
		<form id="NewMenu" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="800">
					<tr>
						<td style="FONT-FAMILY: Verdana, Arial; COLOR: white; FONT-SIZE: 10px; FONT-WEIGHT: bold"
							bgColor="#003366" colSpan="2">
							<uc1:mainMenu id="MainMenu1" runat="server"></uc1:mainMenu></td>
					</tr>
					<tr>
						<td width="25%"></td>
						<td width="75%"></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
