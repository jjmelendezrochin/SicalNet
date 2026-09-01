<%@ Page Language="c#" CodeBehind="FindMaterialPP.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FindMaterialPP" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>FindMaterialPP</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body ms_positioning="GridLayout">

    <form id="FindMaterialPP" method="post" runat="server">
        <table align="center" cellspacing="5" cellpadding="0" width="453" border="0">
            <tr>
                <td align="middle">
                    <asp:Label ID="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Buscar Material</asp:Label>
                </td>
            </tr>
            <tr valign="top">
                <td width="500">
                    <asp:DataGrid ID="dgdFindMaterial" runat="server" ShowFooter="True" Width="550px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="DimGray" BorderStyle="None">
                        <Columns>
                            <asp:TemplateColumn Visible="False" HeaderText="Characteristic">
                                <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblCharCancel" Width="130px" Visible="true" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Characteristic") %>'></asp:Label>
                                    <asp:Label ID="lblEqualCancel" Width="130px" Visible="true" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Equal") %>'></asp:Label>
                                    <asp:Label ID="lblIdEqual" Width="130px" Visible="true" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdEqual") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Right"></FooterStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Caracter&#237;stica">
                                <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblChar" Width="130px" Visible="true" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Characteristic") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                <FooterTemplate>
                                    <asp:Button ID="btnPlus" runat="server" Width="30px" CommandName="Plus" CssClass="botonesInput" Text="+"></asp:Button>
                                </FooterTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList ID="cboChar" runat="server" Width="130px" CssClass="Standard-text" OnSelectedIndexChanged="prcCboCharSelect" AutoPostBack="True"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Igual a">
                                <HeaderStyle HorizontalAlign="Center" Width="130px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="130px" CssClass="grid-first-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblEqual" Width="130px" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Equal") %>'></asp:Label>
                                </ItemTemplate>

                                <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                <FooterTemplate>
                                    <asp:Button ID="btnFind" runat="server" Width="90px" CommandName="Find" CssClass="botonesInput" Text="Buscar"></asp:Button>
                                    <asp:Button ID="BtnCancelFind" runat="server" Width="90px" CommandName="CancelFind" CssClass="botonesInput" Text="Cancelar"></asp:Button>
                                </FooterTemplate>

                                <EditItemTemplate>
                                    <asp:DropDownList ID="cboEqual" runat="server" Width="250" CssClass="Standard-text"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Editar">
                                <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle CssClass="grid-edit-column"></ItemStyle>

                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandName="Edit" CausesValidation="false" AlternateText="Edit" NAME="imgEdit" ImageUrl="../../images/icon-pencil.gif"></asp:ImageButton><img src="images/spacer.gif" width="3">
                                    <asp:ImageButton OnClientClick="return ConfirmOperation(this,'eliminar');" ID="imgDelete" runat="server" CommandName="Delete" CausesValidation="False" AlternateText="Delete" NAME="imgDelete" ImageUrl="../../images/icon-delete.gif"></asp:ImageButton>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgSave" runat="server" CommandName="Update" CausesValidation="False" AlternateText="Save" NAME="imgSave" ImageUrl="../../images/icon-floppy.gif"></asp:ImageButton><img src="images/spacer.gif" width="3">
                                    <asp:ImageButton ID="imgCancel" runat="server" CommandName="Cancel" CausesValidation="False" AlternateText="Cancel" NAME="imgCancel" ImageUrl="../../images/icon-pencil-x.gif"></asp:ImageButton>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr valign="top">
                <td width="100">
                    <asp:DataGrid ID="dgdMaterial" Width="550px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="DimGray" BorderStyle="None" runat="server" Visible="false">
                        <Columns>
                            <asp:TemplateColumn>
                                <HeaderStyle HorizontalAlign="Center" Width="25px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle CssClass="grid-item"></ItemStyle>

                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="CheckAll" CssClass="standard-text" Text="" AutoPostBack="True" TextAlign="Left"></asp:CheckBox>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" CommandName="Select" CausesValidation="false" CssClass="standard-text"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="CodigoSAP">
                                <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" Width="50px" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Descripcion">
                                <HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="250px" CssClass="grid-first-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblDesc" Width="250px" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Estado Producto">
                                <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="80px" CssClass="grid-first-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblEstadoProductoDesc" Width="80px" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.EstadoProductoDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Estado Material">
                                <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>

                                <ItemStyle Width="80px" CssClass="grid-first-item"></ItemStyle>

                                <ItemTemplate>
                                    <asp:Label ID="lblIdEstadoMaterial" Width="80px" Visible="False" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdEstadoMaterial") %>'></asp:Label>
                                    <asp:Label ID="lblEstadoMaterialDesc" Width="80px" runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.EstadoMaterialDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td valign="center" align="middle">
                    <asp:Button ID="cmdDone" runat="server" Text="Seleccionar" CssClass="botonesInput" Visible="False"></asp:Button></td>
            </tr>
        </table>
    </form>
</body>
</html>
