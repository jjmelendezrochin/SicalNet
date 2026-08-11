<%@ Page language="c#" Codebehind="FindMaterial.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.dgdFindMaterial1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FindMaterial</title>
		<LINK href="..\..\styloDESC.CSS" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="FindMaterial" method="post" runat="server">
			<TABLE align="center" height="169" cellSpacing="5" cellPadding="5" width="453" border="0">
				<tr>
					<td align="center"><asp:label id="lblTitle" runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14"> Buscar Material</asp:label>
					</td>
				</tr>
				<TR vAlign="top">
					<TD><asp:datagrid id="dgdFindMaterial" runat="server" ShowFooter="True" Width="550px" Font-Names="Verdana"
							CellPadding="2" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True"
							BorderColor="White" BorderStyle="None">
							<Columns>
								<asp:TemplateColumn Visible="False" HeaderText="Characteristic">
									<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblCharCancel Width="130px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Characteristic") %>' Runat="server" Visible="true" CssClass="standard-text">
										</asp:label>
										<asp:label id=lblEqualCancel Width="130px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Equal") %>' Runat="server" Visible="true" CssClass="standard-text">
										</asp:label>
										<asp:label id=lblIdEqual Width="130px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdEqual") %>' Runat="server" Visible="true" CssClass="standard-text">
										</asp:label>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Caracter&#237;stica">
									<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="70px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblChar Width="130px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Characteristic") %>' Runat="server" Visible="true" CssClass="standard-text">
										</asp:label>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
									<FooterTemplate>
										<asp:Button id="btnPlus" runat="server" Width="30px" Text="+" CssClass="Standard-text" CommandName="Plus"></asp:Button>
									</FooterTemplate>
									<EditItemTemplate>
										<asp:DropDownList id="cboChar" runat="server" Width="130px" CssClass="Standard-text" OnSelectedIndexChanged="prcCboCharSelect"
											AutoPostBack="True"></asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Igual a">
									<HeaderStyle HorizontalAlign="Center" Width="130px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="130px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblEqual Width="250px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Equal") %>' Runat="server" CssClass="standard-text">
										</asp:label>
									</ItemTemplate>
									<FooterStyle HorizontalAlign="Left"></FooterStyle>
									<FooterTemplate>
										<asp:Button id="btnFind" runat="server" Width="70px" Text="Buscar" CssClass="Standard-text"
											CommandName="Find"></asp:Button>
									</FooterTemplate>
									<EditItemTemplate>
										<asp:DropDownList id="cboEqual" runat="server" Width="250" CssClass="Standard-text"></asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Editar">
									<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle CssClass="grid-edit-column"></ItemStyle>
									<ItemTemplate>
										<asp:imagebutton id="imgEdit" runat="server" CommandName="Edit" AlternateText="Edit" NAME="imgEdit"
											ImageUrl="../../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
										<asp:imagebutton onmouseup="ConfirmOperation(this,'eliminar');" id="imgDelete" Runat="server" CommandName="Delete"
											AlternateText="Delete" NAME="imgDelete" ImageUrl="../../images/icon-delete.gif" CausesValidation="False"></asp:imagebutton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:imagebutton id="imgSave" runat="server" CommandName="Update" AlternateText="Save" NAME="imgSave"
											ImageUrl="../../images/icon-floppy.gif" CausesValidation="False"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
										<asp:imagebutton id="imgCancel" runat="server" CommandName="Cancel" AlternateText="Cancel" NAME="imgCancel"
											ImageUrl="../../images/icon-pencil-x.gif" CausesValidation="False"></asp:imagebutton>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td><asp:label id="lblCriteria" Width="250px" Runat="server" Text="" CssClass="standard-text"></asp:label></td>
				</tr>
				<TR vAlign="top">
					<TD><asp:datagrid id="dgdMaterial" Font-Names="Verdana" CellPadding="2" AutoGenerateColumns="False"
							Font-Name="Verdana" FontSize="11px" AllowSorting="True" BorderColor="White" BorderStyle="None"
							Runat="server" Width="550px">
							<Columns>
								<asp:TemplateColumn HeaderText="CodigoSAP">
									<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="30px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblCodigo Width="60px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Runat="server" CssClass="standard-text">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Descripcion">
									<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Width="100px" CssClass="grid-first-item"></ItemStyle>
									<ItemTemplate>
										<asp:label id=lblDesc Width="300px" Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' Runat="server" CssClass="standard-text">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Select">
									<HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle CssClass="grid-edit-column"></ItemStyle>
									<ItemTemplate>
										<asp:imagebutton id="imgSelect" runat="server" CommandName="Select" AlternateText="Select" NAME="imgSelect"
											ImageUrl="../../images/icon-pencil.gif" CausesValidation="false"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
