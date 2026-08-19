<%@ Page language="c#" Codebehind="FindMaterialPP.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.FindMaterialPP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>FindMaterialPP</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<LINK href="../../styloDESC.CSS" type="text/css" rel="stylesheet">
		<form id="FindMaterialPP" method="post" runat="server">
			<table align="center" cellSpacing="5" cellPadding="0" width="453" border="0">
				<tr>
					<td align="middle"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Buscar Material</asp:label>
					</td>
				</tr>
				<TR vAlign="top">
					<td width="500"><asp:datagrid id="dgdFindMaterial" runat="server" ShowFooter="True" Width="550px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="DimGray" BorderStyle="None">
<Columns>
<asp:TemplateColumn Visible="False" HeaderText="Characteristic">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="70px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblCharCancel Width="130px" Visible="true" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Characteristic") %>'></asp:label>
<asp:label id=lblEqualCancel Width="130px" Visible="true" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Equal") %>'></asp:label>
<asp:label id=lblIdEqual Width="130px" Visible="true" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdEqual") %>'></asp:label>
</ItemTemplate>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Caracter&#237;stica">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="70px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblChar Width="130px" Visible="true" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Characteristic") %>'></asp:label>
</ItemTemplate>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>

<FooterTemplate>
<asp:Button id=btnPlus runat="server" Width="30px" CommandName="Plus" CssClass="botonesInput" Text="+"></asp:Button>
</FooterTemplate>

<EditItemTemplate>
<asp:DropDownList id=cboChar runat="server" Width="130px" CssClass="Standard-text" OnSelectedIndexChanged="prcCboCharSelect" AutoPostBack="True"></asp:DropDownList>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Igual a">
<HeaderStyle HorizontalAlign="Center" Width="130px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="130px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblEqual Width="130px" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Equal") %>'></asp:label>
</ItemTemplate>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>

<FooterTemplate>
<asp:Button id=btnFind runat="server" Width="70px" CommandName="Find" CssClass="botonesInput" Text="Buscar"></asp:Button>
<asp:Button id=BtnCancelFind runat="server" Width="70px" CommandName="CancelFind" CssClass="botonesInput" Text="Cancelar"></asp:Button>
</FooterTemplate>

<EditItemTemplate>
<asp:DropDownList id=cboEqual runat="server" Width="250" CssClass="Standard-text"></asp:DropDownList>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Editar">
<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle CssClass="grid-edit-column">
</ItemStyle>

<ItemTemplate>
<asp:imagebutton id=imgEdit runat="server" CommandName="Edit" CausesValidation="false" AlternateText="Edit" NAME="imgEdit" ImageUrl="../../images/icon-pencil.gif"></asp:imagebutton><IMG src="images/spacer.gif" width=3> 
<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id=imgDelete Runat="server" CommandName="Delete" CausesValidation="False" AlternateText="Delete" NAME="imgDelete" ImageUrl="../../images/icon-delete.gif"></asp:imagebutton>
</ItemTemplate>

<EditItemTemplate>
<asp:imagebutton id=imgSave runat="server" CommandName="Update" CausesValidation="False" AlternateText="Save" NAME="imgSave" ImageUrl="../../images/icon-floppy.gif"></asp:imagebutton><IMG src="images/spacer.gif" width=3> 
<asp:imagebutton id=imgCancel runat="server" CommandName="Cancel" CausesValidation="False" AlternateText="Cancel" NAME="imgCancel" ImageUrl="../../images/icon-pencil-x.gif"></asp:imagebutton>
</EditItemTemplate>
</asp:TemplateColumn>
</Columns>
						</asp:datagrid></td>
				</TR>
				<tr vAlign="top">
					<td width="100"><asp:datagrid id="dgdMaterial" Width="550px" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="DimGray" BorderStyle="None" Runat="server" Visible="false">
<Columns>
<asp:TemplateColumn>
<HeaderStyle HorizontalAlign="Center" Width="25px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle CssClass="grid-item">
</ItemStyle>

<HeaderTemplate>
<asp:CheckBox id=chkAll Runat="server" OnCheckedChanged="CheckAll" CssClass="standard-text" Text="" AutoPostBack="True" TextAlign="Left"></asp:CheckBox>
</HeaderTemplate>

<ItemTemplate>
<asp:Checkbox id=chkSelect runat="server" CommandName="Select" CausesValidation="false" CssClass="standard-text"></asp:Checkbox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="CodigoSAP">
<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="50px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblCodigo Width="50px" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'></asp:label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Descripcion">
<HeaderStyle HorizontalAlign="Center" Width="250px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="250px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblDesc Width="250px" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.Descripcion") %>'></asp:label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Estado Producto">
<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="80px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblEstadoProductoDesc Width="80px" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.EstadoProductoDesc") %>'></asp:label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Estado Material">
<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="80px" CssClass="grid-first-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblIdEstadoMaterial Width="80px" Visible="False" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.IdEstadoMaterial") %>'></asp:label>
<asp:label id=lblEstadoMaterialDesc Width="80px" Runat="server" CssClass="standard-text" Text='<%#DataBinder.Eval(Container, "DataItem.EstadoMaterialDesc") %>'></asp:label>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td vAlign="center" align="middle"><asp:button id="cmdDone" runat="server" Text="Seleccionar" CssClass="botonesInput" Visible="False"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
