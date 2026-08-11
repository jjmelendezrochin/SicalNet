<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TarjetaVidrioPlanimetriaEditar.ascx.cs" Inherits="UserInterface.Controls.TarjetaVidrioPlanimetriaEditar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<HEAD>
</HEAD>
<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
<table style="WIDTH: 448px; HEIGHT: 96px" border="0">
	<thead>
		<TR>
			<th colSpan="5">
				PlanimetriaVidrio</th>
		<tr>
			<td style="HEIGHT: 26px" width="14%"><asp:textbox style="Z-INDEX: 0" id="idVidrio" Visible="False" Width="60px" runat="server"></asp:textbox></td>
			<td style="HEIGHT: 26px" width="14%" align="center">A</td>
			<td style="HEIGHT: 26px" width="14%" align="center">B</td>
			<td style="HEIGHT: 26px" width="14%" align="center">C</td>
			<td style="HEIGHT: 26px" width="14%" align="center">D</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td align="center">1</td>
			<td align="center"><asp:textbox id="A1" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A2" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A3" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A4" Width="60px" runat="server"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">2</td>
			<td align="center"><asp:textbox id="B1" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B2" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B3" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B4" Width="60px" runat="server"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">3</td>
			<td align="center"><asp:textbox id="C1" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C2" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C3" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C4" Width="60px" runat="server"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">4</td>
			<td align="center"><asp:textbox id="D1" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D2" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D3" Width="60px" runat="server"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D4" Width="60px" runat="server"></asp:textbox></td>
		</tr>
		<tr>
			<td></td>
			<td colSpan="4" align="center"><asp:button id="cmdGuardar" Width="117px" runat="server" CausesValidation="False" Text="Guardar"
					CssClass="botonesInput"></asp:button></td>
		</tr>
		<tr>
			<td colSpan="5" align="left"><asp:label style="Z-INDEX: 0" id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
		</tr>
	</tbody>
</table>
