<%@ Control language="c#" Codebehind="VidriosTamanio.ascx.cs" AutoEventWireup="false" Inherits="UserInterface.Controls.VidriosTamanio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Tamaño Vidrios</title>
		<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		Button.click()
			
}
		</script>
		<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
			<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
			<meta name="CODE_LANGUAGE" content="C#">
			<meta name="vs_defaultClientScript" content="JavaScript">
			<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" height="477" ms_2d_layout="TRUE">			
			<TR vAlign="top">
				<TD height="1"></TD>
				<TD rowSpan="2" colSpan="2">
					<asp:datagrid id="dgdVidriosTamanio" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages"
						AllowPaging="True" DataKeyField="IdTamanio" AllowSorting="True" FontSize="11px" Font-Name="Verdana" 
						AutoGenerateColumns="False"
						Font-Names="Verdana" Width="100%" runat="server" CssClass="GridView grid-header">
						<HeaderStyle CssClass="grid-header"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn HeaderText="IdTamanio" Visible="False">
								<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemidTamanio Width="50px" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdTamanio") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label id=EditidTamanio Width="50px" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdTamanio") %>' Runat="server">
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Medida Nominal">
								<HeaderStyle HorizontalAlign="Center" Width="160px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemMedida Width="50px" CssClass="standard-text" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Medida") %>'>
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label style="Z-INDEX: 0" id=EditMedida Width="50px" CssClass="standard-text" Runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Medida") %>'>
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Medida Vidrio">
								<HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemMedidaVidrio CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.MedidaVidrio") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:label style="Z-INDEX: 0" id=EditMedidaVidrio Width="50px" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.MedidaVidrio") %>' Runat="server">
									</asp:label>
								</EditItemTemplate>
							</asp:TemplateColumn>
							
							<asp:TemplateColumn HeaderText="Largo Normal">
								<HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemLargoNormal CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.LargoNormal") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditLargoNormal BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.LargoNormal")%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							
							<asp:TemplateColumn HeaderText="Ancho Normal">
								<HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
								<ItemTemplate>
									<asp:label id=ItemAnchoNormal CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.AnchoNormal") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox id=EditAnchoNormal BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.AnchoNormal") %>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>

											
							<asp:TemplateColumn HeaderText="Largo Vidrio">
								<HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemLargoVidrio CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.LargoVidrio") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id=EditLargoVidrio BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.LargoVidrio")%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							
							<asp:TemplateColumn HeaderText="Ancho Vidrio">
								<HeaderStyle HorizontalAlign="Center" Width="110px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemAnchoVidrio CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.AnchoVidrio") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id=EditAnchoVidrio BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.AnchoVidrio")%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Espesor">
								<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id=ItemEspesor CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Espesor") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id=EditEspesor BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Espesor")%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Grosor">
								<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemTemplate>
									<asp:label style="Z-INDEX: 0" id="Label1" CssClass="standard-text" Text='<%# DataBinder.Eval(Container,"DataItem.Grosor") %>' Runat="server">
									</asp:label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:textbox style="Z-INDEX: 0" id="EditGrosor" BorderStyle="Groove" Width="70" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Grosor")%>' MaxLength="50">
									</asp:textbox>
								</EditItemTemplate>
							</asp:TemplateColumn>			
																
							<asp:TemplateColumn HeaderText="Editar">
								<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
								<ItemStyle CssClass="grid-edit-column"></ItemStyle>
								<ItemTemplate>
									<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
										NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
									<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id="Imagebutton6" Runat="server"
										CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete"
										AlternateText="Delete"></asp:imagebutton>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:imagebutton onmouseup="ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server"
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
				</TD>
			</TR>
			<TR vAlign="top">
				<TD></TD>
				<TD><INPUT id="Medida" type="hidden" name="Medida" runat="server"></TD>
			</TR>
			<TR vAlign="top">
				<TD height="13" colSpan="2"></TD>
				<TD colSpan="2"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></TD>
			</TR>
		</TABLE>
	</body>
</HTML>
