<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MaterialGrid.ascx.cs" Inherits="UserInterface.Controls.MaterialGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:DataGrid id="dgdMaterial" runat="server">
	<Columns>
		<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
	</Columns>
</asp:DataGrid>
