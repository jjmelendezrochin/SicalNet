<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="PlantGrid.ascx.cs" Inherits="UserInterface.Controls.PlantGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>FoliosAditivosGrid</TITLE>
	<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/sical-menu.css") %>" />
	<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Css/nuevoestilo.css") %>" />

	<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-menu.js") %>"></script>
	<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/sical-alertas.js") %>"></script>

    <script language="javascript">
        function ConfirmOperation(Button, strOperationType) {
            if (confirm("Esta seguro que desea " + strOperationType + " este registro?")) {
                Button.click()
            }
        }
    </script>
	</HEAD>
<body>
    <p class="contenido" align="left">
        <asp:DataGrid ID="dgdPlant"
            BorderStyle="None"
            BorderColor="White"
            DataKeyField="IdPlanta"
            AllowSorting="True"
            FontSize="11px"
            Font-Name="Verdana"
            AutoGenerateColumns="False"
            CellPadding="2"
            Font-Names="Verdana"
            runat="server"
            AllowPaging="True"
            PagerStyle-Mode="NumericPages"
            PagerStyle-HorizontalAlign="Right"
            Width="500px"
            CssClass="GridView grid-header">

            <HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
            <Columns>
                <asp:TemplateColumn HeaderText="Id">
                    <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="ItemPlantId" Width="40px" Text='<%#DataBinder.Eval(Container, "DataItem.IdPlanta") %>' runat="server" CssClass="standard-text">
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="EditPlantId" Width="40px" Text='<%#DataBinder.Eval(Container, "DataItem.IdPlanta") %>' runat="server" CssClass="standard-text">
                        </asp:Label>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                    <HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="ItemPlantDescription" Text='<%#DataBinder.Eval(Container, "DataItem.Description") %>' runat="server" CssClass="standard-text">
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditPlantDescription" Width="120" runat="server" BorderStyle="Groove" Text='<%#DataBinder.Eval(Container, "DataItem.Description") %>' CssClass="Standard-text" MaxLength="50">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Nombre SAP">
                    <HeaderStyle HorizontalAlign="Center" Width="150px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="ItemDenomSAP" Text='<%#DataBinder.Eval(Container, "DataItem.Denominacion_sap") %>' runat="server" CssClass="standard-text">
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditDenomSAP" Width="120" runat="server" BorderStyle="Groove" Text='<%#DataBinder.Eval(Container, "DataItem.Denominacion_sap") %>' CssClass="Standard-text" MaxLength="10">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="% de Merma">
                    <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="ItemMerma" Text='<%#DataBinder.Eval(Container, "DataItem.Merma") %>' runat="server" CssClass="standard-text">
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditMerma" Width="120" runat="server" BorderStyle="Groove" Text='<%#DataBinder.Eval(Container, "DataItem.Merma") %>' CssClass="Standard-text" MaxLength="10">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="% Rendimiento Color">
                    <HeaderStyle HorizontalAlign="Center" Width="120px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container, "DataItem.RendimientoColor") %>' runat="server" CssClass="standard-text">
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="EditRendimientoColor" Width="120" runat="server" BorderStyle="Groove" Text='<%#DataBinder.Eval(Container, "DataItem.RendimientoColor") %>' CssClass="Standard-text" MaxLength="10">
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Editar">
                    <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle CssClass="grid-edit-column"></ItemStyle>
                    <ItemTemplate>
                        <asp:ImageButton ID="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../images/icon-pencil.gif" NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:ImageButton><img src="images/spacer.gif" width="3">
                        <asp:ImageButton onmouseup="ConfirmOperation(this,'eliminar');" ID="Imagebutton6" runat="server" CausesValidation="False" ImageUrl="../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete" AlternateText="Delete"></asp:ImageButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton onmouseup="ConfirmOperation(this,'actualizar');" ID="Imagebutton7" runat="server" CausesValidation="False" ImageUrl="../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update" AlternateText="Update"></asp:ImageButton><img src="images/spacer.gif" width="3">
                        <asp:ImageButton ID="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../images/icon-pencil-x.gif" NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:ImageButton>
                    </EditItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle
		        HorizontalAlign="Center"
		        Mode="NumericPages"
		        CssClass="grid-pager">
	        </PagerStyle>
        </asp:DataGrid>
    </p>
    <p class="contenido" align="left">
        <asp:Label ID="lblErrorMsg" runat="server" CssClass="standard-text"></asp:Label></p>
</body>