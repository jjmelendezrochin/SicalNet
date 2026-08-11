<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FormTemparaturaGrid.ascx.cs" Inherits="UserInterface.Controls.FormTemparaturaGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript">
function ConfirmOperation(Button,strOperationType)
{
	if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
	{
		Button.click()
	}
}
</script>
<LINK href="../styloDESC.CSS" type="text/css" rel="stylesheet">
<P class="contenido" align="left"><asp:datagrid ItemStyle-Wrap="True" id="dgdFrmTemp" BorderStyle="None" BorderColor="White" DataKeyField="IdFamiliaProducto"
		AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana"
		runat="server">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn Visible="False">
				<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="40px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblFamPdtId Width="30px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdFamiliaProducto") %>' Visible="False" CssClass="standard-text">
					</asp:label>
					<asp:label id=lblEspesorId Width="30px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdEspesor") %>' Visible="False" CssClass="standard-text">
					</asp:label>
					<asp:label id=lblLineaId Width="30px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Visible="False" CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Familia de producto">
				<HeaderStyle HorizontalAlign="Center" Width="140px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="140px" CssClass="grid-first-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblFamPdt Width="120px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.FamPdtDesc") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Espesor">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="60px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=Label1 Width="60px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.EspDesc") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Linea">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblLinea Width="100px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.LineDesc") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Tiempo de Curado">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblTimeCurado Width="100px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TiempoCurado") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=txtTimeCurado Width="100px" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TiempoCurado") %>' CssClass="Standard-text" MaxLength="50">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Tempo de Curado">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblTempCurado Width="60px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TempCurado") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=txtTempCurado Width="100px" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TempCurado") %>' CssClass="Standard-text" MaxLength="10">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Tiempo de Post Curado">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblTimePC Width="100px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TiempoPostCurado") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=txtTimePC Width="100px" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TiempoPostCurado") %>' CssClass="Standard-text" MaxLength="50">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Tempo de Post Curado">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblTempPC Width="100px" Runat="server" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TempPostCurado") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=txtTempPC Width="100px" runat="server" BorderStyle="Groove" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TempPostCurado") %>' CssClass="Standard-text" MaxLength="10">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn>
				<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="40px" CssClass="grid-edit-column"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="imgEdit" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif"
						NAME="imgEdit" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id="imgDelete" Runat="server" CausesValidation="False"
						ImageUrl="../images/icon-delete.gif" NAME="imgDelete" CommandName="Delete" AlternateText="Delete"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton onmouseup="ConfirmOperation(this,'actualizar');" id="imgUpdate" runat="server" CausesValidation="False"
						ImageUrl="../images/icon-floppy.gif" NAME="imgUpdate" CommandName="Update" AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgCancel" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif"
						NAME="imgCancel" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
	</asp:datagrid></P>
<asp:Label id="lblallowedit" runat="server" Visible="False">Label</asp:Label>
