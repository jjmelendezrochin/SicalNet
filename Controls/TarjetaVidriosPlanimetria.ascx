<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TarjetaVidriosPlanimetria.ascx.cs" Inherits="UserInterface.Controls.TarjetaVidriosPlanimetria" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<HTML>
	<HEAD>
		<TITLE>MedidaGrid</TITLE>
	</HEAD>
	<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
	<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		Button.click()
			
}
	</script>
	<asp:datagrid id="dgdEspesor" runat="server" Font-Names="Verdana" AutoGenerateColumns="False"
		Font-Name="Verdana" FontSize="11px" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
		Height="128px" Caption="Planimetría" CaptionAlign="Left" BorderStyle="None" Font-Size="X-Small"
		BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" Width="48px">
		<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
		<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="grid-header" BackColor="#003399"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn>
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="10px" CssClass="grid-first-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemOrden Width="40px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Orden") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:label id=EditOrden Width="40px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Orden") %>'>
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="A">
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemA Width="30px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.A") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditA Width="30px" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.A") %>' MaxLength="15" BorderStyle="Groove">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="B">
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemB Width="30px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.B") %>'>
					</asp:label>
				</ItemTemplate>
				<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
				<EditItemTemplate>
					<asp:textbox id=EditB runat="server" Width="30px" BorderStyle="Groove" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.B") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="C">
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemC Width="30px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.C") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditC runat="server" Width="30px" BorderStyle="Groove" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.C") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="D">
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="30px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label style="Z-INDEX: 0" id=ItemD Width="30px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.D") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox style="Z-INDEX: 0" id=EditD runat="server" Width="30px" BorderStyle="Groove" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.D") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></TD></TR>
	<TR>
		<TD colspan="3"><asp:Label ID="lblErrorMsg" Runat="server" CssClass="standard-text"></asp:Label></TD>
	</TR>
	</TABLE>
</HTML>
