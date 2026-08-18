<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AforoGrid.ascx.cs" Inherits="UserInterface.Controls.AforoGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
	{
		Button.click()
	}
}

</script>

<P class="contenido" align="left">
	<asp:datagrid id="dgdAforo" Width="550px" runat="server" Font-Names="Verdana" CellPadding="2"
		AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" DataKeyField="Id" BorderColor="White"
		BorderStyle="None" AllowPaging="True" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" 
		CssClass="GridView grid-header">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn Visible="False" HeaderText="Id">
				<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="30px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblId Width="30px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditId Width="30px" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.Id") %>' Runat="server">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Color">
				<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="200px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemIdColor CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.idColor") %>' Runat="server" Visible="False">
					</asp:label>
					<asp:label id=lblIdColor0 CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.idColor") %>' Runat="server">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=lblIdColor1 CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.idColor") %>' Runat="server" Visible="False">
					</asp:label>
					<asp:DropDownList id="cboColor" Width="220" runat="server" CssClass="Standard-text"></asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Componente">
				<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id="ItemComponente" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Componente") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id="EditComponente" BorderStyle="Groove" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.Componente") %>' CssClass="Standard-text" MaxLength="8">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Aforo">
				<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id="ItemAforo" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Aforo") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id="EditAforo" BorderStyle="Groove" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.Aforo") %>' CssClass="Standard-text" MaxLength="8">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
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
	</asp:datagrid></P>
<INPUT id="ItemDescripcionhtml" name="ItemDescripcionhtml" type="hidden" runat="server">
<P class="contenido" align="left"><asp:label id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></P>
