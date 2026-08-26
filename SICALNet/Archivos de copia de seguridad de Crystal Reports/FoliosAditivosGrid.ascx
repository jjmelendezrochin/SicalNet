<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FoliosAditivosGrid.ascx.cs" Inherits="UserInterface.Controls.FoliosAditivosGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>FoliosAditivosGrid</TITLE>
	<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

	<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

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
	    <style type="text/css">
            .auto-style1 {
                width: 286px;
            }
        </style>
	</HEAD>

	<table style="width:100%">
		<tr>
			<td align="left">
				<asp:label id="Label1" Width="50px" CssClass="standard-text" Runat="server" Text="Línea :   "></asp:label>&nbsp;&nbsp;
				<asp:DropDownList id="cboLinea" Width="122px" runat="server" CssClass="standard-text"></asp:DropDownList>
				<asp:Button id="btnBuscar" runat="server" Text="Aceptar" CssClass="botonesInput" CausesValidation="False"></asp:Button>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:datagrid 
					id="dgdFoliosAditivos" 
					runat="server" 
					Width="80%" 
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
							<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
							<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
							<ItemTemplate>
								<asp:label id=ItemCodigoSAP Width="70px" CssClass="standard-text" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
								</asp:label>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:label id=EditCodigoSAP Width="70px" CssClass="standard-text" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
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
			<td colspan="2">
				<asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label>
			</td>
		</tr>
	</table>
</HTML>
