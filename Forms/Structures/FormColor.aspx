<%@ Register TagPrefix="uc1" TagName="FormColorGrid" Src="../../Controls/FormColorGrid.ascx" %>

<%@ Page Language="c#" CodeBehind="FormColor.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FormColor" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Guía de estilo</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
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
    //-->
    function ShowTitle() {
        window.frames["top"].document.title = "SICAL  - Estructuras - Formulación de Color"
    }
    </script>
    
    <style type="text/css">
        .auto-style1 {
            height: 11px;
        }
    </style>
    <script type="text/javascript">document.addEventListener(
            "DOMContentLoaded",
            function () {
                SicalMenu.init("sicalMenu");
            }
        );
    </script>
</head>
<body onload="ShowTitle()" leftmargin="0" topmargin="0" bgcolor="#ffffff" text="#000000"
    marginwidth="0" marginheight="0">
    <form id="FormColorForm" method="post" runat="server">
        <div align="center">
            <table border="0" cellspacing="0" cellpadding="0" width="740">
                <tr>
                    <td class="contenido" colspan="2">
                        <div id="sicalMenu"></div>
                    </td>
                </tr>
                <tr>
                    <td width="21" class="auto-style1"></td>
                    <td width="700" class="auto-style1"><span class="titulo"><span class="letraAzulBold"><span class="titulo"><font color="#000000"><span class="titulo"><span class="letraAzulBold">&nbsp;Catalogo de formulación de 
      Color</span>
                    </span></font></span>
                    </span>
                    </span></td>
                    <td width="20" class="auto-style1"></td>
                </tr>
                <tr>
                    <td height="14" width="21">&nbsp;</td>
                    <td height="14" width="700">
                        <asp:Label ID="Label2" runat="server" CssClass="standard-text">En este catalogo se formulan los componentes que integran el color</asp:Label>&nbsp;</td>
                    <td height="13" width="20">&nbsp;</td>
                </tr>
                <tr>
                    <td class="contenido" height="131" width="21"></td>
                    <td class="contenido" height="131" width="700" align="center">
                        <table id="Table1"  border="0" cellspacing="12" cellpadding="0" width="700">
                            <tr valign="top">
                                <td class="letraAzulBold" height="13" colspan="4">Seleccione el color</td>
                            </tr>
                            <tr valign="top">
                                <td height="22">
                                    <p align="right">
                                        <asp:Label ID="lblColor" runat="server" CssClass="standard-text"> Color</asp:Label></p>
                                </td>
                                <td height="22">
                                    <asp:DropDownList ID="cboColor" runat="server" CssClass="standard-text" Width="142px"></asp:DropDownList></td>
                                <td height="22">
                                    <p align="right">
                                        <asp:Label ID="lblPlanta" runat="server" CssClass="standard-text">Planta</asp:Label>&nbsp;
                                    </p>
                                </td>
                                <td height="22">
                                    <asp:DropDownList ID="cboPlanta" runat="server" CssClass="standard-text" Width="142px"></asp:DropDownList></td>
                            </tr>
                            <tr valign="top">
                                <td></td>
                                <td>
                                    <p align="right">
                                        <asp:Button ID="cmdEditForm" runat="server" CssClass="botonesInput" Text="Aceptar"></asp:Button></p>
                                </td>                                
                                <td>                                    
                                </td>
                                <td>
                                    <asp:Button ID="cmdCancelar" runat="server" CssClass="botonesInput" Text="Cancelar"></asp:Button></td>
                            </tr>
                        </table>
                    </td>
                    <td class="contenido" height="131" width="20"></td>
                </tr>
                <tr>
                    <td class="contenido" width="21">&nbsp;</td>
                    <td class="contenido" width="700" align="center">
                        <div align="center">
                            <table id="tableComponents"  border="0" cellspacing="12" cellpadding="0"
                                width="700" runat="server" visible="false">
                                <tr valign="top">
                                    <td class="letraAzulBold" height="13" colspan="2">
                                        <p>Componentes Actuales de la Formulación</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="letraAzulBold" height="13" colspan="2">
                                        <p><font color="red">No olvide indicar el aforo de color</font></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        <table>
                                            <tr>
                                                <td valign="middle">
                                                    <asp:Label ID="Label1" runat="server" CssClass="standard-text">Mensaje:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtMensajePiso" runat="server" CssClass="standard-text" Width="500px" Height="100px"
                                                        MaxLength="500" TextMode="MultiLine"></asp:TextBox></td>
                                                <td>
                                                    <asp:ImageButton ID="imgSaveMessage" runat="server" ImageUrl="../../images/icon-floppy.gif" CausesValidation="False"
                                                        NAME="imgSave" CommandName="Save" AlternateText="Save"></asp:ImageButton></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr valign="top">
                                    <td colspan="2">
                                        <table id="Table6" border="0" cellspacing="0" cellpadding="0">
                                        </table>
                                        <uc1:formcolorgrid id="FormColorGridControl" runat="server"></uc1:formcolorgrid>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td class="contenido" width="20">&nbsp;</td>
                </tr>
                <tr>
                    <td width="21">&nbsp;</td>
                    <td align="center">
                        <div>
                            <table id="tableNewComponents"  border="0" cellspacing="12" cellpadding="0"
                                width="700" runat="server" visible="false">
                                <tr valign="top">
                                    <td class="letraAzulBold" height="13" colspan="4">Agregue un componente a la 
											formulación&nbsp;de Color</td>
                                </tr>
                                <tr>
                                    <td height="28" width="122">
                                        <asp:Label ID="lblMaterial" runat="server" CssClass="standard-text">Material</asp:Label></td>
                                    <td height="28">
                                        <asp:TextBox ID="txtCodigoSAP" runat="server" CssClass="standard-text" Width="131px"></asp:TextBox><asp:ImageButton ID="imgbtnFind" runat="server" Height="23px" ImageUrl="../../Images/Find.gif"></asp:ImageButton></td>
                                    <td height="28" colspan="2">
                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="standard-text" Width="362px" BorderStyle="None"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td height="6" width="122">
                                        <asp:Label ID="lblCantidad" runat="server" CssClass="standard-text">Porcentaje de Peso:</asp:Label></td>
                                    <td height="6">
                                        <asp:TextBox ID="txtPorcentaje" runat="server" CssClass="standard-text" Width="131px"></asp:TextBox></td>
                                    <td height="6" width="122">
                                        <asp:Label ID="Label3" runat="server" CssClass="standard-text">Grupo:</asp:Label></td>
                                    <td height="6">
                                        <p>
                                            <asp:TextBox ID="txtGrupo" runat="server" CssClass="standard-text" Width="142px">1</asp:TextBox></p>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td width="122" colspan="2">
                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></td>
                                    <td width="122">
                                        <p align="right">
                                            <asp:Button ID="AddFormColor" runat="server" CssClass="botonesInput" Width="80px" Text="Agregar"
                                                CausesValidation="False"></asp:Button>
                                        </p>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <table id="ew"  border="0" width="700">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="cmdSalir" runat="server" CssClass="botonesInput" Width="80px" Text="Salir" Visible="False">
                                    </asp:Button></td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
