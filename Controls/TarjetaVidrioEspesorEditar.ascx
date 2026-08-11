<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TarjetaVidrioEspesorEditar.ascx.cs" Inherits="UserInterface.Controls.TarjetaVidrioEspesorEditar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<head>
<LINK rel="stylesheet" type="text/css" href="../styloDESC.CSS">
</head>
<table style="WIDTH: 448px; HEIGHT: 96px" border="0">
	<thead>
		<TR>
			<th colSpan="7">
				Espesor Vidrio</th>
		<tr>
			<td style="HEIGHT: 26px" width="14%"><asp:textbox style="Z-INDEX: 0" id="idVidrio" runat="server" Width="60px" Visible="False"></asp:textbox></td>
			<td style="HEIGHT: 26px" width="14%" align="center">A</td>
			<td style="HEIGHT: 26px" width="14%" align="center">B</td>
			<td style="HEIGHT: 26px" width="14%" align="center">C</td>
			<td style="HEIGHT: 26px" width="14%" align="center">D</td>
			<td style="HEIGHT: 26px" width="14%" align="center">E</td>
			<td style="HEIGHT: 26px" width="14%" align="center">F</td>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td align="center">1</td>
			<td align="center"><asp:textbox id="A1" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A2" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A3" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A4" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A5" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="A6" runat="server" Width="60px"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">2</td>
			<td align="center"><asp:textbox id="B1" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B2" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B3" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B4" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B5" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="B6" runat="server" Width="60px"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">3</td>
			<td align="center"><asp:textbox id="C1" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C2" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C3" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C4" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C5" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="C6" runat="server" Width="60px"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">4</td>
			<td align="center"><asp:textbox id="D1" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D2" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D3" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D4" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D5" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="D6" runat="server" Width="60px"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">5</td>
			<td align="center"><asp:textbox id="E1" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="E2" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="E3" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="E4" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="E5" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="E6" runat="server" Width="60px"></asp:textbox></td>
		</tr>
		<tr>
			<td align="center">6</td>
			<td align="center"><asp:textbox id="F1" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="F2" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="F3" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="F4" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="F5" runat="server" Width="60px"></asp:textbox></td>
			<td align="center"><asp:textbox style="Z-INDEX: 0" id="F6" runat="server" Width="60px"></asp:textbox></td>
		</tr>
		<tr>
			<td></td>
			<td colSpan="6" align="center"><asp:button id="cmdGuardar" runat="server" Width="117px" Text="Guardar" CausesValidation="False"
					CssClass="botonesInput"></asp:button></td>
		</tr>
		<tr>
			<td colSpan="7" align="left">
				<asp:label style="Z-INDEX: 0" id="lblErrorMsg" runat="server" CssClass="standard-text"></asp:label></td>
		</tr>
	</tbody>
</table>
