<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TarjetaVidriosHistorial.ascx.cs" Inherits="UserInterface.Controls.TarjetaVidriosHistorial" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<HTML>
	<HEAD>
		<TITLE>MedidaGrid</TITLE>
	</HEAD>
	<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
	<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		Button.click()
			
}
	</script>
	<asp:datagrid id="dgdEspesor" Width="520px" CellPadding="4" BackColor="White" BorderWidth="1px"
		BorderColor="#3366CC" Font-Size="X-Small" BorderStyle="None" CaptionAlign="Left" Caption="Historial Calidad"
		Height="16px" PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" FontSize="11px"
		Font-Name="Verdana" AutoGenerateColumns="False" Font-Names="Verdana" runat="server">
		<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
		<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="grid-header" BackColor="#003399"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Fecha Lectura">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="60px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemA Height="12px" Width="60px" Runat="server" CssClass="standard-text" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.FechaLectura") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditA runat="server" BorderStyle="Groove" Width="60px" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.FechaLectura") %>' MaxLength="15">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Clasificaci&#243;n">
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="60px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemB Width="290px" Height="12px" CssClass="standard-text-left" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Clasificacion") %>'>
					</asp:label>
				</ItemTemplate>
				<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
				<EditItemTemplate>
					<asp:textbox id=EditB Width="258px" BorderStyle="Groove" Height="30px" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.Clasificacion") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Fecha Rotura">
				<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" Width="60px" CssClass="grid-item" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:label id=ItemC Width="60px" CssClass="standard-text" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.FechaRotura") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:textbox id=EditC Width="30px" BorderStyle="Groove" runat="server" CssClass="Standard-text" Text='&nbsp;<%# DataBinder.Eval(Container,"DataItem.FechaRotura") %>' MaxLength="50">
					</asp:textbox>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></TD></TR><TR>
		<TD colspan="3"><asp:label id="lblErrorMsg" CssClass="standard-text" Runat="server"></asp:label></TD>
	</TR>
	</TABLE>
</HTML>
