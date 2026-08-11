<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ColourGrid.ascx.cs" Inherits="UserInterface.Controls.ColourGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
	{
		Button.click()
	}
}
</script>
<P class="contenido" align="left"><asp:datagrid id="dgdColour" AllowPaging="True" PageSize="10" BorderStyle="None" BorderColor="White"
		DataKeyField="IdColour" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2"
		Font-Names="Verdana" runat="server">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Id">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblColourId Width="100px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdColour") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblDesc Width="120" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=txtDesc Width="120" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Id Exportaci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="120px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblIdExport Width="120" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdExportacion") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=txtIdExport Width="120px" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdExportacion") %>' CssClass="Standard-text" MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Espesor Base (Cent.)">
				<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblEspesor CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Centimetros") %>' Width="50px">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList id=cboEspesor runat="server" CssClass="Standard-text"  Width="50px">
					</asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="*">
				<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:CheckBox id=chkTransItem runat="server" CssClass="standard-text" Checked='<%# DataBinder.Eval(Container, "DataItem.Transparente") %>' Enabled="False">
					</asp:CheckBox>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:CheckBox id=chkTransEdit runat="server" CssClass="standard-text" Checked='<%# DataBinder.Eval(Container, "DataItem.Transparente") %>'>
					</asp:CheckBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="imgEdit" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
						NAME="imgEdit" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgDelete" onmouseup="ConfirmOperation(this,'eliminar');" CausesValidation="False"
						ImageUrl="../images/icon-delete.gif" NAME="imgDelete" CommandName="Delete" AlternateText="Delete"
						Runat="server"></asp:imagebutton>
				</ItemTemplate>
				<FooterStyle Width="40px"></FooterStyle>
				<EditItemTemplate>
					<asp:imagebutton id="imgUpdate" onmouseup="ConfirmOperation(this,'actualizar');" runat="server" CausesValidation="False"
						ImageUrl="../images/icon-floppy.gif" NAME="imgUpdate" CommandName="Update" AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgCancel" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
						NAME="imgCancel" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></P>
<asp:Label id="Label1" runat="server" CssClass="standard-text">*T= Cuando el color es tipo "Transparente" (es decir, carece de formulación de color)</asp:Label><br>
<asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label>
