<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="ConsultBitacora.ascx.cs" Inherits="UserInterface.Controls.ConsultBitacora" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>


<link href="../styloDESC.CSS" type="text/css" rel="stylesheet">
<meta content="JavaScript" name="vs_defaultClientScript">
<script language="javascript">

    function GetDate() {
        //alert(document.forms[0].elements['grdProgram_txtFecha'].value);
        var txtFechaValue = document.forms[0].elements['grdBitacora_txtFecha'].value;
        ChildWindow = window.open('../Production/Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=grdBitacora_txtFecha' + '&txtDate=' + txtFechaValue, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
    }

    function GetDate2() {
        //alert(document.forms[0].elements['grdProgram_txtFecha'].value);
        var txtFechaValue2 = document.forms[0].elements['grdBitacora_txtFechaFin'].value;
        ChildWindow = window.open('../Production/Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=grdBitacora_txtFechaFin' + '&txtDate=' + txtFechaValue2, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
    }


    function ConfirmOperation(Button, strOperationType) {
        if (confirm("¿Está seguro que desea " + strOperationType + " esta secuencia?")) {
            Button.click()
        }
    }
    function ShowHide(CtrlName) {
        var index = CtrlName.substr(0, CtrlName.lastIndexOf("_"))
        var gridtableid = index.concat("_SequenceDetails");
        if (document.getElementById(gridtableid).style.display != "inline") {
            document.getElementById(gridtableid).style.display = "inline";
            document.getElementById(CtrlName).src = "../../images/minusButton.jpg";
        }
        else {
            document.getElementById(gridtableid).style.display = "none";
            document.getElementById(CtrlName).src = "../../images/plusButton.jpg";
        }
    }
</script>

<table id="Tablemain" width="100%" border="0">
    <tr valign="top">
        <td align="center">
            <table id="Table1" border="0">
                <tbody>
                    <tr valign="top">
                        <td align="center">
                            <table id="Table2" cellpadding="3" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server"
                                            Text="Fecha de la Bitacora"
                                            CssClass="standard-text">
                                        </asp:Label>

                                        <asp:Label ID="Label3" runat="server"
                                            Text=" * (dd-MMM-aaaa)"
                                            CssClass="standard-text"
                                            ForeColor="Red" Visible="False"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="LabelFechaFin" runat="server"
                                            Text="Fecha Final"
                                            CssClass="standard-text">
                                        </asp:Label>
                                    </td>

                                    <td>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td valign="top">
                                        <asp:TextBox ID="txtFecha"
                                            runat="server"
                                            CssClass="Standard-text"
                                            MaxLength="11"
                                            Width="100px"
                                            BorderStyle="Groove"
                                            OnTextChanged="txtFecha_TextChanged">
                                        </asp:TextBox>

                                        <asp:Image ID="imgInitial"
                                            runat="server"
                                            onmouseup="GetDate();"
                                            AlternateText="Inicial Date"
                                            ImageUrl="../Images/icon-calendar.gif"></asp:Image>

                                        <br>

                                        <asp:RegularExpressionValidator ID="revFecha"
                                            CssClass="standard-text"
                                            Display="Dynamic"
                                            ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
                                            ControlToValidate="txtFecha"
                                            ErrorMessage="Fecha incorrecta"
                                            runat="server">
                                        </asp:RegularExpressionValidator>
                                    </td>

                                    <td valign="top">
                                        <asp:TextBox ID="txtFechaFin"
                                            runat="server"
                                            CssClass="Standard-text"
                                            MaxLength="11"
                                            Width="100px"
                                            BorderStyle="Groove">
                                        </asp:TextBox>

                                        <asp:Image ID="imgFin"
                                            runat="server"
                                            onmouseup="GetDate2();"
                                            AlternateText="Final Date"
                                            ImageUrl="../Images/icon-calendar.gif"></asp:Image>

                                        <br>

                                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1"
                                            CssClass="standard-text"
                                            Display="Dynamic"
                                            ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
                                            ControlToValidate="txtFechaFin"
                                            ErrorMessage="Fecha incorrecta"
                                            runat="server">
                                        </asp:RegularExpressionValidator>
                                    </td>

                                    <td valign="top" align="center">
                                        <asp:Button ID="btnSel"
                                            runat="server"
                                            Text="Buscar"
                                            CssClass="botonesInput"
                                            OnClick="btnSel_Click1"
                                            Style="width: 105px;">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:DataGrid
                                ID="gridBitacora"
                                runat="server"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                AllowSorting="True"
                                BorderColor="White"
                                BorderStyle="None"
                                PageSize="20"
                                PagerStyle-HorizontalAlign="Right"
                                PagerStyle-Mode="NumericPages"
                                OnPageIndexChanged="gridBitacora_PageIndexChanged"
                                Font-Size="Small"
                                Width="70%"
                                ShowFooter="True"
                                CssClass="GridView grid-users">

                                <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
                                <Columns>
                                    <asp:BoundColumn
                                        DataField="IdBitacora"
                                        HeaderText="Bitácora">
                                        <HeaderStyle CssClass="grid-header" Width="10%" />
                                        <ItemStyle CssClass="standard-text" Width="10%" />
                                    </asp:BoundColumn>

                                    <asp:BoundColumn
                                        DataField="Fecha"
                                        HeaderText="Fecha">

                                        <HeaderStyle CssClass="grid-header" Width="15%" />
                                        <ItemStyle CssClass="standard-text" Width="15%" />

                                    </asp:BoundColumn>


                                    <asp:BoundColumn
                                        DataField="comando"
                                        HeaderText="Comando">

                                        <HeaderStyle CssClass="grid-header" Width="50%" />
                                        <ItemStyle CssClass="standard-text grid-comando" Width="50%" />

                                    </asp:BoundColumn>


                                    <asp:BoundColumn
                                        DataField="Login"
                                        HeaderText="Usuario">

                                        <HeaderStyle CssClass="grid-header" Width="25%" />
                                        <ItemStyle CssClass="standard-text" Width="25%" />

                                    </asp:BoundColumn>

                                </Columns>

                                <PagerStyle
                                    HorizontalAlign="Center"
                                    Mode="NumericPages"
                                    CssClass="grid-pager"></PagerStyle>

                            </asp:DataGrid>

                            <asp:Label ID="lblmsg" CssClass="standard-text" ForeColor="Red" runat="server" Visible="False"
                                Font-Bold="True">No se encontraron registros</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="cmdprint" runat="server" Text="Imprimir" CssClass="botonesInput"
                                Visible="False"></asp:Button>
                        </td>
                        <td align="left">
                            <asp:Button ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="botonesInput"
                                Visible="False"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </td>
    </tr>
</table>
