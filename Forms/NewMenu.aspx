<%@ Page language="c#" Codebehind="NewMenu.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.NewMenu" %>
<%@ Register TagPrefix="cc1" Namespace="CYBERAKT.WebControls.Navigation" Assembly="ASPnetMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	    <HEAD>

        <title>NewMenu</title>

        <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
        <meta name="CODE_LANGUAGE" content="C#">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema"
              content="http://schemas.microsoft.com/intellisense/ie5">

        <script type="text/javascript">
            window.SicalAppPath = '<%= ResolveUrl("~/") %>';
        </script>

        <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
        <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />

        <!-- Funciones propias de la página -->
        <script type="text/javascript">

            function ShowTitle() {
                window.frames["top"].document.title = "SICAL";
            }

        </script>

        <!-- Nuevo menú -->
        

        <script type="text/javascript">

            document.addEventListener(
                "DOMContentLoaded",
                function () {
                    SicalMenu.init("sicalMenu");
                }
            );

        </script>

    </HEAD>
	<body>
		<form id="NewMenu" method="post" runat="server">
			<div align="center">
				<table border="0" cellSpacing="0" cellPadding="0" width="800">
					<tr class="sical-menu-row">						
                        <td align="left" colSpan="4">
							<div id="sicalMenu"></div>
						</td>
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
