<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FoliosColorGrid.ascx.cs" Inherits="UserInterface.Controls.FoliosColorGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>FoliosColorGrid</TITLE>	
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

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
	<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>

	<table>
		<tr>
			<td align="left">
				<asp:label id="Label1" Width="50px" CssClass="standard-text" Runat="server" Text="Línea :   "></asp:label>&nbsp;&nbsp;
				<asp:DropDownList id="cboLinea" Width="122px" runat="server" CssClass="standard-text"></asp:DropDownList>
				<asp:Button id="btnBuscar" runat="server" Text="Aceptar" CssClass="botonesInput" CausesValidation="False" OnClick="btnBuscar_Click1"></asp:Button>
			</td>			
		</tr>
		<tr>
			<td colspan="2">
				<asp:datagrid 
					id="dgdFoliosColor" 
					runat="server" 
					Width="100%" 
					Font-Names="Verdana" 
					CellPadding="2"
					AutoGenerateColumns="False" 
					Font-Name="Verdana" 
					FontSize="11px" 
					AllowSorting="True" 
					BorderColor="White"
					BorderStyle="None" 
					AllowPaging="True" 
					PageSize="10" 
					PagerStyle-Mode="NumericPages" 
					PagerStyle-HorizontalAlign="Right"
					CssClass="GridView grid-users">

					<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="Código&nbsp;SAP">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemCodigoSAP Width="50px" CssClass="standard-text" Runat="server" Text='<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:label id=EditCodigoSAP Width="50px" CssClass="standard-text" Runat="server" Text='<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
								</asp:label>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Linea">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemLinea" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IdLinea") %>'>
								</asp:label>
							</ItemTemplate>
							<ItemTemplate>
								<asp:label id="EditLinea" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.IdLinea") %>'>
								</asp:label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Folio">
							<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemFolio" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Folio") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id="EditFolio" BorderStyle="Groove" Width="110" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Folio") %>' MaxLength="30">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Observaciones ">
							<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id="ItemObservaciones" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Observaciones") %>' Runat="server">
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:textbox id="EditObservaciones" BorderStyle="Groove" Width="200" Height="50" TextMode=MultiLine runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Observaciones") %>' MaxLength="100">
								</asp:textbox>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Editar">
							<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="100px" CssClass="grid-edit-column"></ItemStyle>
							<ItemTemplate>
								<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
									NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit" OnClick="Imagebutton5_Click"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
								<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
									CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
									AlternateText="Delete"></asp:imagebutton>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server"
									CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update"
									AlternateText="Update" OnClick="Imagebutton7_Click"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
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
			<td colspan="2">
				<asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label>
				<INPUT type="hidden" id="Foliohtml" name="Foliohtml" runat="server">
			</td>
		</tr>
	</table>
</HTML>
