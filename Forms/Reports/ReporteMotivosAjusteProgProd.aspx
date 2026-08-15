<%@ Page language="c#" Codebehind="ReporteMotivosAjusteProgProd.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Reports.ReporteMotivosAjusteProgProd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReporteMotivosAjusteProgProd</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
		<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
		<!-- <LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet"> -->
		<script language="javascript">		
            function GetDate(CtrlName) {
                ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=270,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=yes,resizable=no");
            }
            function ShowTitle() {
                window.frames["top"].document.title = "SICAL  - Ajustes Reporte Programa de Producción"
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
	<body>

    <!-- Menú -->
    <table align="center">
        <tr>
            <td align="left" colspan="5">
                <div id="sicalMenu"></div>
            </td>
        </tr>
        <tr>
		<td align="center" colspan="2"><br />
			<asp:Label id="Label3" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">
                Reporte Fase de Ajustes al programa de Producción
			</asp:Label>
		</td>
	</tr>
    </table>

    
    <form id="Form1" method="post" runat="server">

        <!-- Contenedor principal -->
        <div style="width: 700px; margin: 0 auto;">
            <br />
            <!-- Filtros -->
            <table
                border="0"
                cellpadding="0"
                cellspacing="0"
                style="width:100%;">

                <!-- Etiquetas -->
                <tr>
                    <td style="width:225px; padding-right:25px;">
                        <asp:Label 
                            ID="Label1"
                            runat="server"
                            Width="40px"
                            Height="22px"
                            CssClass="standard-text">
                            Planta
                        </asp:Label>
                    </td>

                    <td style="width:180px; padding-right:25px;">
                        <asp:Label 
                            ID="lblLinea"
                            runat="server"
                            Width="40px"
                            Height="22px"
                            CssClass="standard-text">
                            Linea
                        </asp:Label>
                    </td>

                    <td>
                        <asp:Label 
                            ID="Label2"
                            runat="server"
                            Width="40px"
                            Height="22px"
                            CssClass="standard-text">
                            Causa
                        </asp:Label>
                    </td>
                </tr>


                <!-- Combos -->
                <tr>

                    <td style="padding-right:25px; padding-bottom:28px;">

                        <asp:DropDownList
                            ID="cboPlanta"
                            runat="server"
                            Width="142px"
                            CssClass="standard-text">
                        </asp:DropDownList>

                    </td>

                    <td style="padding-right:25px; padding-bottom:28px;">

                        <asp:DropDownList
                            ID="cboLinea"
                            runat="server"
                            Width="142px"
                            CssClass="standard-text">
                        </asp:DropDownList>

                    </td>

                    <td style="padding-bottom:28px;">

                        <asp:DropDownList
                            ID="cboCausa"
                            runat="server"
                            Width="253px"
                            CssClass="standard-text">
                        </asp:DropDownList>

                    </td>

                </tr>


                <!-- Etiquetas de fechas -->
                <tr>

                    <td>

                        <asp:Label
                            ID="lblFechaInicial"
                            runat="server"
                            Width="154px"
                            Height="22px"
                            CssClass="standard-text">
                            Fecha Programa Inicial
                        </asp:Label>

                    </td>

                    <td>

                        <asp:Label
                            ID="lblFechaFinal"
                            runat="server"
                            Width="142px"
                            Height="22px"
                            CssClass="standard-text">
                            Fecha Programa Final
                        </asp:Label>

                    </td>

                    <td>
                    </td>

                </tr>


                <!-- Fechas + botones -->
                <tr>

                    <!-- Fecha inicial -->
                    <td style="vertical-align:top;">

                        <asp:TextBox
                            ID="txtFechaInicial"
                            runat="server"
                            Width="121px"
                            CssClass="standard-text"
                            BorderStyle="Groove">
                        </asp:TextBox>

                        <asp:ImageButton
                            ID="imgFInicial"
                            runat="server"
                            ImageUrl="../../Images/icon-calendar.gif"
                            onmouseup="GetDate('txtFechaInicial');">
                        </asp:ImageButton>

                        <asp:RegularExpressionValidator
                            ID="revInitial"
                            runat="server"
                            CssClass="standard-text"
                            ControlToValidate="txtFechaInicial"
                            ErrorMessage="Fecha incorrecta en programa inicial"
                            ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">
                            *
                        </asp:RegularExpressionValidator>

                    </td>


                    <!-- Fecha final -->
                    <td style="vertical-align:top;">

                        <asp:TextBox
                            ID="txtFechaFinal"
                            runat="server"
                            Width="119px"
                            CssClass="standard-text"
                            BorderStyle="Groove">
                        </asp:TextBox>

                        <asp:ImageButton
                            ID="imgFFinal"
                            runat="server"
                            ImageUrl="../../Images/icon-calendar.gif"
                            onmouseup="GetDate('txtFechaFinal');">
                        </asp:ImageButton>

                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1"
                            runat="server"
                            CssClass="standard-text"
                            ControlToValidate="txtFechaFinal"
                            ErrorMessage="Fecha incorrecta en programa final"
                            ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)">
                            *
                        </asp:RegularExpressionValidator>

                    </td>


                    <!-- Botones -->
                    <td style="vertical-align:top; white-space:nowrap;">

                        <asp:Button
                            ID="cmdReporte"
                            runat="server"
                            CssClass="botonesInput"
                            Text="Reporte">
                        </asp:Button>

                        &nbsp;&nbsp;

                        <asp:Button
                            ID="cmdExportaPvc"
                            runat="server"
                            CssClass="botonesInput"
                            Text="Exportar">
                        </asp:Button>

                        &nbsp;&nbsp;

                        <asp:Button
                            ID="btnCancelar"
                            runat="server"
                            CssClass="botonesInput"
                            Text="Cancelar">
                        </asp:Button>

                    </td>

                </tr>

            </table>


            <!-- Mensajes -->
            <div style="margin-top:12px; text-align:center; min-height:20px;">

                <asp:Label
                    ID="lblErrMsg"
                    runat="server"
                    Width="658px"
                    Height="20px"
                    CssClass="standard-text"
                    ForeColor="Red">
                </asp:Label>

            </div>


            <!-- Separación real antes del DataGrid -->
            <div style="height:20px;"></div>


            <!-- DataGrid -->
            <div style="width:100%;">

                <asp:DataGrid
                    ID="DataGrid1"
                    runat="server"
                    Width="100%"
                    Height="46px"
                    Font-Names="Verdana"
                    Font-Size="X-Small"
                    BorderStyle="None"
                    BorderWidth="1px"
                    BorderColor="#999999"
                    BackColor="White"
                    CellPadding="3"
                    GridLines="Vertical">

                    <FooterStyle
                        ForeColor="Black"
                        BackColor="#CCCCCC">
                    </FooterStyle>

                    <SelectedItemStyle
                        Font-Bold="True"
                        ForeColor="White"
                        BackColor="#008A8C">
                    </SelectedItemStyle>

                    <AlternatingItemStyle
                        BackColor="Gainsboro">
                    </AlternatingItemStyle>

                    <ItemStyle
                        BorderWidth="2px"
                        ForeColor="Black"
                        BorderStyle="Solid"
                        BorderColor="Black"
                        BackColor="#EEEEEE">
                    </ItemStyle>

                    <HeaderStyle
                        Font-Bold="True"
                        HorizontalAlign="Center"
                        BorderWidth="2px"
                        ForeColor="White"
                        BorderStyle="Solid"
                        BorderColor="Black"
                        BackColor="#000084">
                    </HeaderStyle>

                    <PagerStyle
                        HorizontalAlign="Center"
                        ForeColor="Black"
                        BackColor="#999999"
                        Mode="NumericPages">
                    </PagerStyle>

                </asp:DataGrid>

            </div>

        </div>

    </form>

</body>


</HTML>
