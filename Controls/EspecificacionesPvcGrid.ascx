<%@ Control Language="c#" Codebehind="EspecificacionesPvcGrid.ascx.cs" AutoEventWireup="false"  Inherits="UserInterface.Controls.EspecificacionesPvcGrid" %>
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
		<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
			<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
			<meta name="CODE_LANGUAGE" content="C#">
			<meta name="vs_defaultClientScript" content="JavaScript">
			<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE border="0" cellSpacing="0" cellPadding="0" width="654" height="355" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD height="15" width="1"></TD>
				<TD width="581"></TD>
				<TD width="72"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="327"></TD>
				<TD colSpan="2">
					<asp:datagrid id="dgdEspecificaciones" runat="server" Width="448px" Font-Names="Verdana" CellPadding="2"
						AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="idEspecificaciones"
						BorderColor="White" BorderStyle="None" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
						GridLines="Vertical">
						<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn Visible="False" HeaderText="idEspecificaciones">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemidEspecificaciones Width="50px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.idEspecificaciones") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label id=EditidEspecificaciones Width="50px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.idEspecificaciones") %>'>
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="C&#243;digoSap">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemCodigoSap CssClass="standard-text" Text='&nbsp;<%# &#13;&#13;&#10;DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditCodigoSap runat="server" Width="70" BorderStyle="Groove" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.CodigoSAP") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Descripci&#243;n">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=itemDescripcion CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Descripcion") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditDescripcion runat="server" Width="70" BorderStyle="Groove" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Descripcion") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Nominal">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemNominal CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Nominal") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditNominal BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Nominal") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Espesor">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemEspesor CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Espesor") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditEspesor runat="server" Width="70" BorderStyle="Groove" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Espesor") &#13;&#13;&#10;%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="L1">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:Label id="ItemL1" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.L1") %>' runat="server" >
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id="EditItemL1" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.L1") %>' BorderStyle="Groove" CssClass="standard-text">
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="L2">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:Label id="ItemL2" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.L2") %>' runat="server" CssClass="standard-text">
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id="EditItemL2" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.L2") %>' BorderStyle="Groove" CssClass="standard-text">
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="L3">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:Label id="ItemL3" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.L3") %>' CssClass="standard-text">
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id="EditItemL3" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.L3") %>' BorderStyle="Groove" CssClass="standard-text">
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Medida">
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:Label style="Z-INDEX: 0" id="ItemMedida" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Medida") %>' CssClass="standard-text">
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox style="Z-INDEX: 0" id="EditMedida" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Medida") %>' BorderStyle="Groove" CssClass="standard-text">
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Peso">
								<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:Label style="Z-INDEX: 0" id="ItemPeso" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Peso") %>' CssClass="standard-text">
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox style="Z-INDEX: 0" id="EditPeso" runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, &#13;&#13;&#10;"DataItem.Peso") %>' BorderStyle="Groove" CssClass="standard-text">
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn Visible="False" HeaderText="Editar">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle CssClass="grid-edit-column"></ItemStyle>
								<ItemTemplate>
									<asp:imagebutton id="Imagebutton5" runat="server" AlternateText="Edit" CommandName="Edit" NAME="Imagebutton1"
										ImageUrl="../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
									<asp:imagebutton id="Imagebutton6" OnClientClick="return ConfirmOperation(this,'eliminar');" AlternateText="Delete"
										CommandName="Delete" NAME="Imagebutton2" ImageUrl="../images/icon-delete.gif" CausesValidation="False"
										Runat="server"></asp:imagebutton>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:imagebutton id="Imagebutton7" OnClientClick="return ConfirmOperation(this,'actualizar');" runat="server"
										AlternateText="Update" CommandName="Update" NAME="Imagebutton3" ImageUrl="../images/icon-floppy.gif"
										CausesValidation="False"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
									<asp:imagebutton id="Imagebutton8" runat="server" AlternateText="Cancel" CommandName="Cancel" NAME="Imagebutton4"
										ImageUrl="../images/icon-pencil-x.gif" CausesValidation="False"></asp:imagebutton>
								</EditItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
					</asp:datagrid></TD>
			</TR>
			<TR vAlign="top">
				<TD height="13" colSpan="2"></TD>
				<TD><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
			</TR>
		</TABLE>
	</body>
</HTML>
