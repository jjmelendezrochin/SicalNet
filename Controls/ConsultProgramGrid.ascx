<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ConsultProgramGrid.ascx.cs" Inherits="UserInterface.Controls.ConsultProgramGrid" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="..\styloDESC.CSS" type="text/css" rel="stylesheet">
<script language="javascript">

	function GetDate(CtrlName)        
	{   
		ChildWindow = window.open('..\\Production\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
	}    

	function ShowHide(CtrlName)
	{
		var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"));
		var gridtableid = index.concat("_SequenceDetails");
		if (document.getElementById(gridtableid).style.display != "inline")
		{
			document.getElementById(gridtableid).style.display = "inline";				
			document.getElementById(CtrlName).src= "../Images/minusButton.JPG";
		}
		else
		{
			document.getElementById(gridtableid).style.display = "none";				
			document.getElementById(CtrlName).src= "../Images/plusButton.JPG";
		}				
	}
</script>
<!-- <P class="contenido" align="left">   -->
<TABLE id="Table1" cellSpacing="0" cellPadding="5" align="center" border="0" width="740">
	<tr>
		<td><asp:label id="lblFrom" Runat="server" Text="Statement From Date" CssClass="standard-text">Fecha de inicio</asp:label>
			<asp:label id="Label3" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
		<td><asp:label id="lblTo" Runat="server" Text="To Date" CssClass="standard-text">Fecha Final</asp:label>
			<asp:label id="Label1" CssClass="standard-text" Text="(dd-MMM-yyyy)" Runat="server" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></td>
		<TD><asp:label id="lblLine" Runat="server" Text="IdLinea" CssClass="standard-text">Línea</asp:label>&nbsp;&nbsp;&nbsp;
		</TD>
		<td align="center"></td>
	</tr>
	<TR>
		<TD>
			<asp:textbox id="txtFrom" Runat="server" CssClass="Standard-text" Width="100px" MaxLength="11"></asp:textbox>
			<asp:image OnClientClick="return GetDate('ConsultPrgGridControl_txtFrom');" id="imgFrom" name="imgFrom" Runat="server"
				ImageUrl="../Images/icon-calendar.gif" AlternateText="Inicial Date"></asp:image></TD>
		<TD>
			<asp:textbox id="txtTo" Runat="server" CssClass="Standard-text" Width="100px" MaxLength="11"></asp:textbox>
			<asp:image OnClientClick="return GetDate('ConsultPrgGridControl_txtTo');" id="imgTo" Runat="server" ImageUrl="../Images/icon-calendar.gif"
				AlternateText="Final Date"></asp:image></TD>
		<TD>
			<asp:dropdownlist id="cboIdLinea" Runat="server" CssClass="standard-text"></asp:dropdownlist></TD>
		<TD align="center"><asp:button id="btnAceptar" Text="Aceptar" CssClass="botonesInput" runat="server"></asp:button></TD>
	</TR>
	<TR>
		<TD>
			<asp:RegularExpressionValidator id="revInitial" CssClass="standard-text" runat="server" ErrorMessage="Fecha incorrecta"
				ControlToValidate="txtFrom" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				Display="Dynamic"></asp:RegularExpressionValidator></TD>
		<TD>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" CssClass="standard-text" runat="server" ErrorMessage="Fecha incorrecta"
				ControlToValidate="txtTo" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)"
				Display="Dynamic"></asp:RegularExpressionValidator></TD>
		<TD></TD>
		<TD align="center"></TD>
	</TR>
</TABLE>
<asp:datalist id="lstProgram" runat="server">
	<HeaderTemplate>
		<TABLE id="tableFrame" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="1"
			cellPadding="1" border="1">
			<TR>
				<TD>
					<TABLE id="Table14" style="BORDER-COLLAPSE: collapse" borderColor="white" cellSpacing="1"
						cellPadding="1" bgColor="#276187" border="1">
						<TR>
							<TD>
								<asp:Label id="Label13" Width="10px" CssClass="standard-text" runat="server" ForeColor="White"></asp:Label></TD>
							<TD>
								<asp:CheckBox id="chkSelectAll" Width="20px" CssClass="standard-text" runat="server" OnCheckedChanged="CheckAll"
									ForeColor="White" AutoPostBack="True"></asp:CheckBox></TD>
							<TD>
								<asp:Label id="P" Width="23px" CssClass="standard-text" runat="server" ForeColor="White">P</asp:Label></TD>
							<TD>
								<asp:Label id="Fecha" Width="60px" CssClass="standard-text" runat="server" ForeColor="White">Fecha</asp:Label></TD>
							<TD>
								<asp:Label id="KCT" Width="30px" CssClass="standard-text" runat="server" ForeColor="White">KCT</asp:Label></TD>
							<TD>
								<asp:Label id="Línea" Width="30px" CssClass="standard-text" runat="server" ForeColor="White">Línea</asp:Label></TD>
							<TD>
								<asp:Label id="Secuencia" Width="70px" CssClass="standard-text" runat="server" ForeColor="White">Secuencia</asp:Label></TD>
							<TD>
								<asp:Label id="Corrida" Width="40px" CssClass="standard-text" runat="server" ForeColor="White">Corrida</asp:Label></TD>
							<TD>
								<asp:Label id="Lote" Width="25px" CssClass="standard-text" runat="server" ForeColor="White">Lote</asp:Label></TD>
							<TD>
								<asp:Label id="Cantidad" Width="30px" CssClass="standard-text" runat="server" ForeColor="White">Cant.</asp:Label></TD>
							<TD>
								<asp:Label id="Material" Width="60px" CssClass="standard-text" runat="server" ForeColor="White">Material</asp:Label></TD>
							<TD>
								<asp:Label id="Descripción" Width="230px" CssClass="standard-text" runat="server" ForeColor="White">Descripción</asp:Label></TD>
							<TD>
								<asp:Label id="Status" Width="60px" CssClass="standard-text" runat="server" ForeColor="White">Status</asp:Label></TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
	</HeaderTemplate>
	<ItemTemplate>
		<TABLE id="tableDance" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="1"
			cellPadding="1" border="1">
			<TR>
				<TD>
					<TABLE id="Table8" style="BORDER-COLLAPSE: collapse" borderColor="white" cellSpacing="1"
						cellPadding="1" bgColor="#dedfde" border="1">
						<TR>
							<TD>
								<asp:Image id="cmdExpand" OnClientClick="return ShowHide(this.id);" ImageUrl="../images/plusButton.jpg"
									runat="server"></asp:Image></TD>
							<TD>
								<asp:CheckBox id="chkSelected" Width="20px" CssClass="standard-text" runat="server" ForeColor="White"></asp:CheckBox></TD>
							<TD>
								<asp:Label id=lblPrioridad Text='<%# DataBinder.Eval(Container, "DataItem.Prioridad") %>' Width="23px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblFecha Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Fecha") %>' Width="60px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblKct Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.KCT") %>' Width="30px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblLinea Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdLinea") %>' Width="30px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblSecuencia Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Secuencia") %>' Width="70px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblCorrida Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Corrida") %>' Width="40px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblLote Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.NumeroLote") %>' Width="25px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD align="right">
								<asp:Label id=lblCantidad Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Width="30px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblMaterial Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>' Width="60px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblDescripcion Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.MaterialDesc") %>' Width="230px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
							<TD>
								<asp:Label id=lblStatus Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdStatus") %>' Width="60px" CssClass="standard-text" runat="server" Visible="False">
								</asp:Label>
								<asp:Label id=lblStatusDesc Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.StatusDesc") %>' Width="60px" CssClass="standard-text" runat="server">
								</asp:Label></TD>
						</TR>
					</TABLE>
					<TABLE id="SequenceDetails" cellSpacing="1" cellPadding="1" border="0" runat="server" style="DISPLAY: none">
						<TR>
							<TD width="50" height="10"></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD width="50"></TD>
							<TD>
								<TABLE id="Details1" style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="1"
									cellPadding="1" border="1">
									<TR>
										<TD bgColor="#dedfde">
											<asp:Label id="Orden" Width="40px" CssClass="standard-text" runat="server">Orden</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="Pedido" Width="70px" CssClass="standard-text" runat="server">Pedido</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="LoteInsp" Width="70px" CssClass="standard-text" runat="server">Lote Insp</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="Rendimiento" Width="40px" CssClass="standard-text" runat="server">Rendimiento</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="Cliente" Width="150px" CssClass="standard-text" runat="server">Cliente</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="FechaEmb" Width="100px" CssClass="standard-text" runat="server">Fecha Emb</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="Area" Width="150px" CssClass="standard-text" runat="server">Area actual</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id=lblOrden Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.NoOrden") %>' Width="40px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD>
											<asp:Label id=lblPedido Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Pedido") %>' Width="70px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD align="left">
											<asp:Label id=lblLoteInsp Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.LoteInspeccion") %>' Width="70px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD align="right">
											<asp:Label id=lblRendimiento Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Rendimiento") %>' Width="40px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD>
											<asp:Label id=lblCliente Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Cliente") %>' Width="150px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD>
											<asp:Label id=lblFechaEmb Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.FechaEmbarque") %>' Width="100px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD>
											<asp:Label id=lblArea Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.IdArea") %>' Width="150px" CssClass="standard-text" runat="server" Visible="False">
											</asp:Label>
											<asp:Label id=lblAreaDesc Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.AreaDesc") %>' Width="150px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD width="50" height="10"></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD width="50"></TD>
							<TD>
								<TABLE id="Details2" style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="1"
									cellPadding="1" border="1">
									<TR>
										<TD bgColor="#dedfde">
											<asp:Label id="Label14" Width="100px" CssClass="standard-text" runat="server">Tipo Molde</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="Label15" Width="330px" CssClass="standard-text" runat="server">Detalle Operación</asp:Label></TD>
										<TD bgColor="#dedfde">
											<asp:Label id="Label16" Width="255px" CssClass="standard-text" runat="server">Comentarios</asp:Label></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id=lblTipoMolde Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.TipoMolde") %>' Width="100px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD>
											<asp:Label id=lblDetalleOp Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.DetalleOperacion") %>' Width="330px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
										<TD align="left">
											<asp:Label id=lblComentarios Text='&nbsp;<%# DataBinder.Eval(Container, "DataItem.Comentarios") %>' Width="255px" CssClass="standard-text" runat="server">
											</asp:Label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TABLE>
				</TD>
			</TR>
		</TABLE>
	</ItemTemplate>
</asp:datalist>
