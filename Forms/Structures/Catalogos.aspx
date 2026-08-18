<%@ Page language="c#" Codebehind="Catalogos.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Structures.Catalogos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Equipment</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styloDESC.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="script.js" type="text/javascript"></script>
		<script language="javascript">
	function ConfirmOperation(Button,strOperationType)
	{
		if (confirm("Esta seguro que desea "+strOperationType+" este registro?")) 
		{
			Button.click()
		}
	}
		
		</script>
	</HEAD>
	<body>
		<div align="center">
			<table width="740" border="0" cellspacing="0" cellpadding="0">
				<form id="TimeEntry" method="post" runat="server">
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="15"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="7" style="WIDTH: 7px"><IMG height="8" src="images/spacer.gif" width="8"></td>
					<td style="WIDTH: 197px" vAlign="top" width="197" bgColor="#77aa88">
						<!-- Left Panel -->
						<table cellSpacing="0" cellPadding="0" width="206" border="0">
							<tr>
								<td style="WIDTH: 225px" vAlign="top">
									<TABLE class="tan-border" id="Table1" style="WIDTH: 215px; HEIGHT: 161px" cellSpacing="12" cellPadding="0" width="215" border="0">
										<TR vAlign="top">
											<TD class="header-gray">Agregue una Compañía</TD>
										</TR>
										<TR vAlign="top">
											<TD>
												<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Proporcione la compañía !" ControlToValidate="CompanyText"></asp:requiredfieldvalidator><BR>
												<asp:textbox id="CompanyText" runat="server" Columns="5" CssClass="standard-text" Width="182px"></asp:textbox></TD>
										</TR>
										<TR vAlign="top">
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD style="HEIGHT: 20px">
															<asp:button id="AddCompany" runat="server" CssClass="standard-text" Width="92px" Text="Agregar" CausesValidation="False"></asp:button>
															<asp:button id="cmdCancelC" runat="server" CssClass="standard-text" Width="92px" Text="Cancelar" CausesValidation="False"></asp:button></TD>
														<TD style="HEIGHT: 20px"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 225px" vAlign="top">
									<P align="center">
										<asp:ImageButton id="cmdRegresar" runat="server" CausesValidation="False" ImageUrl="images/cmdRegresar.gif"></asp:ImageButton></P>
								</TD>
							</TR>
						</table> <!-- End Left Panel -->
						<P align="center">&nbsp;</P>
					</td>
					<TD width="11"></TD>
					<TD vAlign="top"><!-- Right Panel -->
						<TABLE class="tan-border" style="WIDTH: 505px; HEIGHT: 232px" height="232" cellSpacing="11" cellPadding="0" width="505" border="0">
							<TR vAlign="top">
								<TD height="15"><SPAN class="header-gray">Catálogo&nbsp; de Compañías</SPAN></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<P><asp:datagrid id="grdCompanias" runat="server" Width="100%" BorderStyle="None" BorderColor="White" DataKeyField="CompanyId" AllowSorting="True" FontSize="11px" Font-Name="Verdana" AutoGenerateColumns="False" CellPadding="2" Font-Names="Verdana">
											<HeaderStyle Font-Bold="True" CssClass="grid-header"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="Id">
													<HeaderStyle HorizontalAlign="Center" Width="10px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="10px" CssClass="grid-first-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id="ItemCompanyId" Width="40px" Text='&nbsp;' Runat="server"></asp:label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:label id="EditCompanyId" Width="40px" Text='&nbsp;' Runat="server"></asp:label>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Descripci&#243;n">
													<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle Width="150px" CssClass="grid-item"></ItemStyle>
													<ItemTemplate>
														<asp:label id="ItemCompanyDescription" Text='&nbsp;' Runat="server"></asp:label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:textbox id="EditCompanyDescription" runat="server" CssClass="Standard-text" Width="120" Text="" MaxLength="50"></asp:textbox>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="Editar">
													<HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="grid-header" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle CssClass="grid-edit-column"></ItemStyle>
													<ItemTemplate>
														<asp:imagebutton id="Imagebutton5" runat="server" CausesValidation="false" ImageUrl="../../images/icon-pencil.gif" NAME="Imagebutton1" CommandName="Edit" AlternateText="Edit"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
														<asp:imagebutton OnClientClick="return ConfirmOperation(this,'eliminar');" id="Imagebutton6" CausesValidation="False" ImageUrl="../../images/icon-delete.gif" NAME="Imagebutton2" CommandName="Delete" AlternateText="Delete" Runat="server"></asp:imagebutton>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:imagebutton OnClientClick="return ConfirmOperation(this,'actualizar');" id="Imagebutton7" runat="server" CausesValidation="False" ImageUrl="../../images/icon-floppy.gif" NAME="Imagebutton3" CommandName="Update" AlternateText="Update"></asp:imagebutton><IMG src="images/spacer.gif" width="3">
														<asp:imagebutton id="Imagebutton8" runat="server" CausesValidation="False" ImageUrl="../../images/icon-pencil-x.gif" NAME="Imagebutton4" CommandName="Cancel" AlternateText="Cancel"></asp:imagebutton>
													</EditItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></P>
								</TD>
							</TR>
						</TABLE> <!-- End Right Panel -->
					</TD>
				</tr>
			</table>
			</TD></TR></TABLE></FORM></TABLE>
		</div>
	</body>
</HTML>
