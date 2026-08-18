<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Cubas.ascx.cs" Inherits="UserInterface.Controls.CubasGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Cubas</TITLE>
	</HEAD>
	<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
	<script language="javascript">
        function ConfirmOperation(Button, strOperationType) {
            if (Button._sicalConfirmado) {
                Button._sicalConfirmado = false;
                return true;
            }

            SicalAlert.confirmar(
                "¿Está seguro que desea " +
                strOperationType +
                " este registro?",
                "Confirmar operación",
                function () {

                    Button._sicalConfirmado = true;
                    Button.click();

                }
            );

            return false;
        }
    </script>
	<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
	<meta name="CODE_LANGUAGE" content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<table width="100%">
		<tr>
			<td align="left" colspan="2">
				<asp:label id="Label1" Text="Línea :   " Runat="server" CssClass="standard-text" Width="50px"></asp:label>&nbsp;&nbsp;
				<asp:dropdownlist id="cboLinea" CssClass="standard-text" Width="122px" runat="server"></asp:dropdownlist>			
				<asp:button id="btnBuscar" Text="Aceptar" CssClass="botonesInput" runat="server" CausesValidation="False"></asp:button>
			</td>
		</tr>
		<tr>
			<td colSpan="2">
				<asp:datagrid id="dgdCubas" Width="100%" runat="server" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages"
					PageSize="10" AllowPaging="True" BorderStyle="None" BorderColor="White" AllowSorting="True" FontSize="11px"
					Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" CssClass="GridView grid-header">
					<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Cuba">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemCuba Width="50px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cuba") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:label id=EditCuba Width="50px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cuba") %>'>
								</asp:label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Linea">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="EditLinea" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IdLinea") %>'>
								</asp:label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="SecuenciaActual">
							<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemSecuenciaActual" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.SecuenciaActual") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id="EditSecuenciaActual" BorderStyle="Groove" Width="110" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.SecuenciaActual") %>' MaxLength="30">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Denominacion ">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemDenominacion" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Denominacion") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id="EditDenominacion" BorderStyle="Groove" Width="200" Height="50" TextMode=MultiLine runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Denominacion") %>' MaxLength="100">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Editar">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="100px" CssClass="grid-edit-column"></ItemStyle>
							<ItemTemplate>
								<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
									NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
									CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
									AlternateText="Delete"></asp:imagebutton>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server"
									CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update"
									AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton id="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
									NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
							</EditItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle
						HorizontalAlign="Center"
						Mode="NumericPages"
						CssClass="grid-pager">
					</PagerStyle>
				</asp:datagrid>
			</td>
		</tr>
		<tr>
			<td colSpan="2"><asp:label id="lblErrorMsg" CssClass="standard-text" runat="server"></asp:label><INPUT id="SecuenciaActualhtml" type="hidden" name="SecuenciaActualhtml" runat="server">
				<INPUT type="hidden" id="Cubahtml" name="Cubahtml" runat="server">
			</td>
		</tr>
	</table>
</HTML>
