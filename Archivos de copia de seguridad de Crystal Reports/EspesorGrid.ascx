<%@ Control language="c#" Codebehind="EspesorGrid.ascx.cs" AutoEventWireup="false" Inherits="UserInterface.Controls.EspesorGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD><TITLE>MedidaGrid</TITLE>
	<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
  </HEAD>
	<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		Button.click()
			
}
	</script>
			<asp:datagrid id="dgdEspesor" runat="server" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="IdEspesor" BorderColor="White" BorderStyle="None" AllowPaging="True" PageSize="10" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" Width="550px">
<HeaderStyle Font-Bold="True" CssClass="grid-header">
</HeaderStyle>

<Columns>
<asp:TemplateColumn HeaderText="IdEspesor">
<HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="10px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=ItemIdEspesor CssClass="standard-text" Runat="server" Width="40px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>'>
						</asp:label>
</ItemTemplate>

<EditItemTemplate>
<asp:label id=EditIdEspesor CssClass="standard-text" Runat="server" Width="40px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>'>
						</asp:label>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Mil&#237;metros">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="150px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=ItemCentimetros CssClass="standard-text" Runat="server" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Centimetros") %>'></asp:label>
</ItemTemplate>

<EditItemTemplate>
<asp:textbox id=EditCentimetros BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Centimetros") %>' MaxLength="50"></asp:textbox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Pulgadas">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="150px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=ItemPulgadas CssClass="standard-text" Runat="server" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Pulgadas") %>'></asp:label>
</ItemTemplate>

<EditItemTemplate>
<asp:textbox id=EditPulgadas BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Pulgadas") %>' MaxLength="50"></asp:textbox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Nominal">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="150px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=ItemNominal CssClass="standard-text" Runat="server" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Nominal") %>'></asp:label>
</ItemTemplate>

<EditItemTemplate>
<asp:textbox id=EditNominal BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Nominal") %>' MaxLength="50"></asp:textbox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Otro">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="150px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=ItemOtro CssClass="standard-text" Runat="server" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Otro") %>'></asp:label>
</ItemTemplate>

<EditItemTemplate>
<asp:textbox id=EditOtro BorderStyle="Groove" runat="server" CssClass="Standard-text" Width="70px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Otro")%>' MaxLength="50"></asp:textbox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Editar">
<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle CssClass="grid-edit-column">
</ItemStyle>

<ItemTemplate>
<asp:imagebutton id=Imagebutton5 runat="server" AlternateText="Edit" CommandName="Edit" NAME="Imagebutton1" ImageUrl="../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width=3> 
<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id=Imagebutton6 Runat="server" AlternateText="Delete" CommandName="Delete" NAME="Imagebutton2" ImageUrl="../images/icon-delete.gif" CausesValidation="False"></asp:imagebutton>
</ItemTemplate>

<EditItemTemplate>
<asp:imagebutton onmouseup="ConfirmOperation(this,'actualizar');" id=Imagebutton7 runat="server" AlternateText="Update" CommandName="Update" NAME="Imagebutton3" ImageUrl="../images/icon-floppy.gif" CausesValidation="False"></asp:imagebutton><IMG src="images/spacer.gif" width=3> 
<asp:imagebutton id=Imagebutton8 runat="server" AlternateText="Cancel" CommandName="Cancel" NAME="Imagebutton4" ImageUrl="../images/icon-pencil-x.gif" CausesValidation="False"></asp:imagebutton>
</EditItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Right" Mode="NumericPages">
</PagerStyle>
		</asp:datagrid></TD></TR>
			<TR>
			<TD colspan="3"><asp:Label ID="lblErrorMsg" Runat="server" CssClass="standard-text"></asp:Label></TD>
		</TR></TABLE>
</HTML>
