<%@ Control language="c#" Codebehind="MedidaGrid.ascx.cs" AutoEventWireup="false" Inherits="UserInterface.Controls.MedidaGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MedidaGrid</title>
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE border="0" cellSpacing="0" cellPadding="0" width="451" height="355" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD height="15" width="1"></TD>
				<TD width="9"></TD>
				<TD width="285"></TD>
				<TD width="156"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="1"></TD>
				<TD rowSpan="2" colSpan="3">
					<asp:datagrid id="dgdMedida" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages"
						AllowPaging="True" BorderStyle="None" BorderColor="White" DataKeyField="IdMedida" AllowSorting="True" FontSize="11px"
						Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" Width="700px" runat="server" CssClass="GridView grid-header">
						<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn HeaderText="IdMedida">
								<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemIdMedida Width="60px" CssClass="standard-text" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.IdMedida") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label id=EditIdMedida Width="60px" CssClass="standard-text" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.IdMedida") %>'>
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Cent&#237;metros">
								<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="70px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemCentimetros CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Centimetros") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditCentimetros BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Centimetros") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Pulgadas">
								<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="70px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemPulgadas CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Pulgadas") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditPulgadas BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Pulgadas") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Nominal">
								<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="70px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemNominal CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nominal") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditNominal BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Nominal") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Otro">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemOtro CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Otro") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditOtro BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Otro") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Editar">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle CssClass="grid-edit-column"></ItemStyle>
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
					</asp:datagrid></TD>
			</TR>
			<TR vAlign="top">
				<TD height="326"></TD>
				<TD><INPUT id="Centrimetros" type="hidden" name="Centrimetros" runat="server"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="13" colSpan="2"></TD>
				<TD colSpan="2"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
			</TR>
		</TABLE>
	</body>
</HTML>
