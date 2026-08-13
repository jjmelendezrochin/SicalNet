<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ConsultBitacora.ascx.cs" Inherits="UserInterface.Controls.ConsultBitacora" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>


<LINK href="../styloDESC.CSS" type=text/css rel=stylesheet >
<meta content=JavaScript name=vs_defaultClientScript>
<script language=javascript>
	
function GetDate()        
{            
   //alert(document.forms[0].elements['grdProgram_txtFecha'].value);
   var txtFechaValue = document.forms[0].elements['grdBitacora_txtFecha'].value;
	ChildWindow = window.open('../Production/Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=grdBitacora_txtFecha' + '&txtDate=' + txtFechaValue, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
}

function GetDate2()        
{            
   //alert(document.forms[0].elements['grdProgram_txtFecha'].value);
   var txtFechaValue2 = document.forms[0].elements['grdBitacora_txtFechaFin'].value;
	ChildWindow = window.open('../Production/Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=grdBitacora_txtFechaFin' + '&txtDate=' + txtFechaValue2, "PopUpCalendar", "width=250,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
}


function ConfirmOperation(Button,strOperationType)
{
	if (confirm("¿Está seguro que desea " +strOperationType+ " esta secuencia?")) 
	{
		Button.click()
	}
}
function ShowHide(CtrlName)
{
	var index=CtrlName.substr(0,CtrlName.lastIndexOf("_"))
	var gridtableid = index.concat("_SequenceDetails");
	if (document.getElementById(gridtableid).style.display != "inline")
	{
		document.getElementById(gridtableid).style.display = "inline";				
		document.getElementById(CtrlName).src= "../../images/minusButton.jpg";
	}
	else
	{
		document.getElementById(gridtableid).style.display = "none";				
		document.getElementById(CtrlName).src="../../images/plusButton.jpg";
	}				
}
</script>

<TABLE id=Tablemain width="100%" border=0>
  <TR vAlign=top>
    <TD align=center>
      <TABLE id=Table1 border=0>
        <TBODY>
        <TR vAlign=top>
          <TD align=center>
            <TABLE id=Table2>
              <TR>
                <TD colSpan=2><asp:label id=lblDate Runat="server" Text="Fecha del Programma" CssClass="standard-text">Fecha de la Bitacora</asp:label><asp:label id=Label3 Runat="server" Text="(dd-MMM-yyyy)" CssClass="standard-text" ForeColor="Red"> * (dd-MMM-aaaa)</asp:label></TD></TR>
              <TR>
                <TD><asp:textbox id=txtFecha Runat="server" CssClass="Standard-text" MaxLength="11" Width="77px" BorderStyle="Groove" OnTextChanged="txtFecha_TextChanged"></asp:textbox><asp:image onmouseup=GetDate(); id=imgInitial Runat="server" AlternateText="Inicial Date" ImageUrl="../Images/icon-calendar.gif"></asp:image><br 
                  ><asp:regularexpressionvalidator id=revFecha CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)" ControlToValidate="txtFecha" ErrorMessage="Fecha incorrecta" runat="server"></asp:regularexpressionvalidator></TD>
                <TD><asp:textbox id=txtFechaFin Runat="server" CssClass="Standard-text" MaxLength="11" Width="77px" BorderStyle="Groove"></asp:textbox><asp:image onmouseup=GetDate2(); id=imgFin Runat="server" AlternateText="Final Date" ImageUrl="../Images/icon-calendar.gif"></asp:image><br 
                  ><asp:regularexpressionvalidator id=Regularexpressionvalidator1 CssClass="standard-text" Display="Dynamic" ValidationExpression="(^((31(?!-(feb|abr|jun|sep|nov)))|((30|29)(?!-feb?))|(29(?=-feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ene|feb|mar|may|abr|jul|jun|ago|oct|sep|nov|dic)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(FEB|ABR|JUN|SEP|NOV)))|((30|29)(?!-FEB?))|(29(?=-FEB?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(ENE|FEB|MAR|MAY|ABR|JUL|JUN|AGO|OCT|SEP|NOV|DIC)-((1[6-9]|[2-9]\d)\d{2})$)|(^((31(?!-(Feb|Abr|Jun|Sep|Nov)))|((30|29)(?!-Feb?))|(29(?=-Feb?-(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)))))|(0?[1-9])|1\d|2[0-8])-(Ene|Feb|Mar|May|Abr|Jul|Jun|Ago|Oct|Sep|Nov|Dic)-((1[6-9]|[2-9]\d)\d{2})$)" ControlToValidate="txtFechaFin" ErrorMessage="Fecha incorrecta" runat="server"></asp:regularexpressionvalidator></TD></TR>
              <TR>
                <TD align=center colSpan=2><asp:button id=btnSel Runat="server" Text="Aceptar" CssClass="botonesInput" OnClick="btnSel_Click1"></asp:button></TD></TR></TABLE></TD></TR>
        <TR>
          <TD align=center><asp:datagrid id=gridBitacora runat="server" AutoGenerateColumns="False">
								<Columns>
									<asp:BoundColumn DataField="IdBitacora" HeaderText="Bitacora">
										<HeaderStyle ForeColor="White" BackColor="#276187" Font-Size="10px" Font-Name="Verdana, Arial, Helvetica, sans-serif"></HeaderStyle>
										<ItemStyle CssClass="standard-text"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Fecha" HeaderText="Fecha">
										<HeaderStyle ForeColor="White" BackColor="#276187" Font-Size="10px" Font-Name="Verdana, Arial, Helvetica, sans-serif"></HeaderStyle>
										<ItemStyle CssClass="standard-text"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="comando" HeaderText="Comando">
										<HeaderStyle ForeColor="White" BackColor="#276187" Font-Size="10px" Font-Name="Verdana, Arial, Helvetica, sans-serif"></HeaderStyle>
										<ItemStyle CssClass="standard-text"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Login" HeaderText="Usuario">
										<HeaderStyle ForeColor="White" BackColor="#276187" Font-Size="10px" Font-Name="Verdana, Arial, Helvetica, sans-serif"></HeaderStyle>
										<ItemStyle CssClass="standard-text"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid><asp:label id=lblmsg CssClass="standard-text" ForeColor="Red" runat="server" Visible="False" Font-Bold="True">No se encontraron registros</asp:label></TD></TR>
        <TR>
          <TD colSpan=2></TD></TR>
        <TR>
          <TD align=right><asp:button id=cmdprint Runat="server" Text="Imprimir" CssClass="botonesInput" Visible="False"></asp:button></TD>
          <TD align=left><asp:button id=cmdCancelar Runat="server" Text="Cancelar" CssClass="botonesInput" Visible="False"></asp:button></TD></TR></TD></TABLE></TD></TR></TBODY></TABLE>
