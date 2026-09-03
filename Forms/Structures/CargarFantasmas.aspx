<%@ Page Language="c#" CodeBehind="CargarFantasmas.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.CargarFantasmas" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>LoadProduccionPrograma</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <script language="JavaScript">
        function showWaitControls() {
            waitControls.style.display = '';
        }
        function ShowTitle() {
            window.frames["top"].document.title = "SICAL  - Logística - Cargar Programa de Producción"
        }

        function ConfirmImport(msg) {
            var hdn = document.getElementById('hdnFileInput');
            if (hdn == null) {
                alert("no se encontro el hidden");
                return;
            }
            if (document.forms[0].fileInput.value != "") {
                if (hdn.value == "" || hdn.value == document.forms[0].fileInput.value) {
                    if (confirm(msg)) {
                        document.forms[0].submit();
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }
        function checkInputFile() {
            if (document.forms[0].fileInput.value == "") {
                alert("Debe especificar el archivo de materials a cargar");
                waitControls.style.display = 'none';
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
</head>
<body ms_positioning="GridLayout">
    <form id="LoadProduccionPrograma" method="post" enctype="multipart/form-data" runat="server"
        onsubmit="return checkInputFile();">

          <table style="border-collapse: collapse; margin-top: 0; padding-top: 0;"; width="1000"; align="center">
            <tbody>
                <tr class="sical-menu-row">
                    <td align="left" colspan="4"  style="padding: 0; margin: 0; vertical-align: top;">
                        <div id="sicalMenu"></div>
                    </td>
                </tr>
            </tbody>
        </table>
        <table style="border-collapse: collapse" width="700" align="center">
            <tbody>                
                <tr>
                    <td align="center" colspan="3">
                        <br>
                        <asp:Label ID="Label1" runat="server" Font-Size="14" Font-Bold="True" Font-Names="Arial Narrow"> Cargar de Archivo con Materiales Fantasmas</asp:Label>
                        <hr>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="Label2" runat="server" CssClass="standard-text">Proporcione el nombre del archivo en formato Excel (c) que contiene  la lista de los materiales fantasmas <br> (Fantasmas.xls) y presione el botón "Cargar Programa" <br></asp:Label></td>
                </tr>
                <tr>
                    <td align="center">
                        <input id="fileInput"
                            class="sical-file-input"
                            type="file"
                            name="fileInput"
                            runat="server">

                        <input id="hdnFileInput"
                            type="hidden"
                            runat="server"
                            name="hdnFileInput">
                    </td>
                    <td align="center"></td>
                    <td align="center">
                        <asp:Button ID="AddPrograma" runat="server" CssClass="standard-text" CausesValidation="False"
                            Text="Cargar Programa" Width="126px"></asp:Button></td>
                </tr>
                <tr>
                    <td class="Normal" align="center" colspan="4">
                        <div id="waitControls" style="display: none">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="../../images/waitImage.gif"></asp:Image></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label4" runat="server" CssClass="standard-text"> Este proceso puede demorar varios segundos, debido a que en este momento <br> estamos subiendo y validando los materiales Fantasma desde el archivo de Excel .<br>Agradecemos su paciencia.</asp:Label></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Size="X-Small" Font-Bold="True" CssClass="standard-text"></asp:Label></td>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
