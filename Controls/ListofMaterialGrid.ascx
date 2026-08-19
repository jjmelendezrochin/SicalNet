<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ListofMaterialGrid.ascx.cs" Inherits="UserInterface.Controls.ListofMaterialGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
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

<P class="contenido" align="left"><asp:datagrid id="dgdLstMat" ItemStyle-Wrap="True" BorderStyle="None" BorderColor="White" AllowSorting="True"
		FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana" runat="server" Width="650px"
		AllowPaging="True" CssClass="GridView grid-header">
		<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="C&#243;digo">
				<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblCodigo Width="50px" Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=txtCodigo Width="50px" runat="server" CssClass="Standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' MaxLength="50">
					</asp:TextBox>
					<asp:imagebutton id="imgbtnFind1" runat="server" ImageUrl="../Images/Find.gif" CommandName="Find"
						Height="23px"></asp:imagebutton>
					<asp:label id=lblcodigo1 Width="50px" Runat="server" CssClass="standard-text" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Visible="False">
					</asp:label>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:TextBox id=lblMaterialDesc Width="100px" BorderStyle="None" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaterialDesc") %>' CssClass="Standard-text">
					</asp:TextBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Formulaci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="50px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblHijo Width="50px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAPHijo") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=EditHijo Width="50px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAPHijo") %>' MaxLength="50" CssClass="Standard-text">
					</asp:TextBox>
					<asp:imagebutton id="imgbtnFind" runat="server" CommandName="FindHijo" ImageUrl="../../Images/Find.gif"
						Height="23px"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Descripci&#243;n">
				<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:TextBox id=lblHijoDesc Width="100px" BorderStyle="None" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.HijoDesc") %>' CssClass="Standard-text">
					</asp:TextBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Cantidad">
				<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblCandidad Width="50px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=txtCandidad Width="50px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' MaxLength="50" CssClass="Standard-text">
					</asp:TextBox>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Unidad">
				<HeaderStyle HorizontalAlign="Center" Width="70px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="30px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblUnidad Width="30px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UnidadDesc") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList id="cboUnidad" Width="40px" runat="server" CssClass="Standard-text"></asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Planta">
				<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="70px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:label id=lblPlanta Width="70px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlantaDesc") %>' CssClass="standard-text">
					</asp:label>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList id="cboPlanta" Width="50px" runat="server" CssClass="Standard-text"></asp:DropDownList>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Editar">
				<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
				<ItemStyle Width="100px" CssClass="grid-item"></ItemStyle>
				<ItemTemplate>
					<asp:imagebutton id="imgEdit" runat="server" CausesValidation="false" NAME="imgEdit" AlternateText="Edit"
						ImageUrl="../images/icon-pencil.gif" CommandName="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="imgDelete" CausesValidation="False"
						NAME="imgDelete" AlternateText="Delete" ImageUrl="../images/icon-delete.gif" CommandName="Delete"
						Runat="server"></asp:imagebutton>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="imgUpdate" runat="server" CausesValidation="False"
						NAME="imgUpdate" AlternateText="Update" ImageUrl="../images/icon-floppy.gif" CommandName="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
					<asp:imagebutton id="imgCancel" runat="server" CausesValidation="False" NAME="imgCancel" AlternateText="Cancel"
						ImageUrl="../images/icon-pencil-x.gif" CommandName="Cancel"></asp:imagebutton>
				</EditItemTemplate>
			</asp:TemplateColumn>
		</Columns>
		<PagerStyle
			HorizontalAlign="Center"
			Mode="NumericPages"
			CssClass="grid-pager">
		</PagerStyle>
	</asp:datagrid></P>
