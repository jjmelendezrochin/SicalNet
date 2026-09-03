<%@ Register TagPrefix="uc1" TagName="ListMaterialGrid" Src="../../Controls/ListofMaterialGrid.ascx" %>
<%@ Page language="c#" Codebehind="ListOfMaterial.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.ListOfMaterial" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Guía de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

		<script language="JavaScript">
<!--
    function MM_reloadPage(init) {  //reloads the window if Nav4 resized
        if (init == true) with (navigator) {
            if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
            }
        }
        else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) location.reload();
    }
    MM_reloadPage(true);
    // -->

    function MM_openBrWindow(theURL, winName, features) { //v2.0
        window.open(theURL, winName, features);
    }
    function ShowTitle() {
        window.frames["top"].document.title = "SICAL  - Estructuras - Lista de Materiales"
    }

//-->
        </script>
		
		<script type="text/javascript">document.addEventListener(
                "DOMContentLoaded",
                function () {
                    SicalMenu.init("sicalMenu");
                }
            );
        </script>
		<!--onload="if ('<%= Session["errMsg"]%>' != '') alert('<%= Session["errMsg"]%>')"-->
	</HEAD>
	<body onload="ShowTitle()" text="#000000" bgColor="#ffffff" leftMargin="0" topMargin="0"
		marginheight="0" marginwidth="0">
		<form id="ListMat" method="post" runat="server">			
				<table style="border-collapse: collapse; margin-top: 0; padding-top: 0;"; width="1000"; align="center">
					<tbody>
					<tr class="sical-menu-row">
						<td class="contenido" colSpan="3">
							<div id="sicalMenu"></div>
						</td>
					</tr>
					</tbody>
				</table>
            <div align="center">
                <table cellspacing="0" cellpadding="0" border="0" width="800">
                    <tbody>
                        <tr>
                            <td width="20">&nbsp;</td>
                            <td width="700">
                                <img height="7" src="imagenes/ico-bullet.gif" width="7">&nbsp;
								<span class="titulo">
                                    <span class="letraAzulBold">Lista de Materiales</span>
                                </span></td>
                            <td width="20">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20">&nbsp;</td>
                            <td width="700">
                                <asp:Label ID="Label6" runat="server" CssClass="standard-text">Es una lista en donde se establecen las Formulaciones de Color con las que se preparan los Productos Terminado.</asp:Label>
                                &nbsp;&nbsp;&nbsp;</td>
                            <td width="20">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20">&nbsp;</td>
                            <td width="700">
                                <table cellspacing="0" cellpadding="0" width="700" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="20" height="12">&nbsp;
												<table id="Table1" cellspacing="12" cellpadding="0" width="700" border="0">
                                                    <tr valign="top">
                                                        <td colspan="4" class="letraAzulBold" width="256" height="12">Lista de Materiales</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="105" height="5">
                                                            <p align="right">
                                                                <asp:Label ID="Label1" runat="server" CssClass="standard-text">Código del Material:</asp:Label>
                                                            </p>
                                                        </td>
                                                        <td colspan="3" height="5">
                                                            <asp:TextBox ID="txtCodigoSAP" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox>
                                                            <asp:ImageButton ID="imgbtnFind" runat="server" Height="23px" ImageUrl="../../Images/Find.gif"></asp:ImageButton>
                                                            <asp:TextBox ID="txtDescripcion" CssClass="standard-text" Width="218px" ReadOnly="True" runat="server"
                                                                BorderStyle="None"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="105" height="28">
                                                            <p align="right">
                                                                <asp:Label ID="Label2" runat="server" CssClass="standard-text">Código de la Formulación de Color:</asp:Label>
                                                            </p>
                                                        </td>
                                                        <td colspan="3" height="28">
                                                            <asp:TextBox ID="txtCodigoSAPHijo" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox>
                                                            <asp:ImageButton ID="imgbtnFind1" runat="server" Height="23px" ImageUrl="../../Images/Find.gif"></asp:ImageButton>
                                                            <asp:TextBox ID="txtDescripcionHijo" CssClass="standard-text" Width="217px" ReadOnly="True" runat="server"
                                                                BorderStyle="None"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="105" height="6">
                                                            <p align="right">
                                                                <asp:Label ID="Label3" runat="server" CssClass="standard-text">Cantidad :</asp:Label>
                                                            </p>
                                                        </td>
                                                        <td height="6" width="139" colspan="3">
                                                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="standard-text" Width="142px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="105" height="11">
                                                            <p align="right">
                                                                <asp:Label ID="Label4" runat="server" CssClass="standard-text">Unidad:</asp:Label>
                                                            </p>
                                                        </td>
                                                        <td height="11" width="139">
                                                            <asp:DropDownList ID="cboUnidad" runat="server" CssClass="standard-text" Width="142px"></asp:DropDownList></td>
                                                        <td height="11">
                                                            <p align="right">
                                                                &nbsp;
																<asp:Label ID="Label5" runat="server" CssClass="standard-text">Planta:</asp:Label>
                                                            </p>
                                                        </td>
                                                        <td height="11">
                                                            <asp:DropDownList ID="cboPlanta" runat="server" CssClass="standard-text" Width="142px" AutoPostBack="True"></asp:DropDownList></td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td width="20%">
                                                            <p align="right">
                                                                <asp:Button ID="AddLstMat" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar"
                                                                    CausesValidation="False"></asp:Button>
                                                            </p>
                                                        </td>
                                                        <td width="20%"></td>
                                                        <td width="20%">
                                                            <asp:Button ID="cmdCancelC" runat="server" CssClass="botonesInput" Width="80px" Text="Cancelar"
                                                                CausesValidation="False"></asp:Button></td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="20" height="12"></td>
                                        </tr>
                                        <tr>
                                            <td class="contenido" valign="top" width="20"></td>
                                            <td class="contenido" valign="top" width="20"></td>
                                        </tr>
                                        <tr>
                                            <td class="contenido" valign="top" width="20">
                                                <p class="contenido" align="left">
                                                    <table id="Table3" cellspacing="12" cellpadding="0" width="1000" border="0">
                                                        <tr valign="top">
                                                            <td>
                                                                <uc1:ListMaterialGrid id="LstMatGrid" runat="server"></uc1:ListMaterialGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </p>
                                            </td>
                                            <td class="contenido" valign="top" width="20"></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td width="20">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="contenido" width="20">&nbsp;</td>
                            <td class="contenido" width="700">
                                <div align="right"></div>
                            </td>
                            <td class="contenido" width="20">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <div align="right"></div>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </tbody>
                </table>
            </div>
		</form>
	</body>
</HTML>
