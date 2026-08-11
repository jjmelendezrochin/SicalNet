<%@ Page language="c#" Codebehind="ColorWOFinal.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Production.WorkOrder.PartidasColor.ColorWOFinal" %>
<%@ Register TagPrefix="cyberakt" Namespace="CYBERAKT.WebControls.Navigation" Assembly="ASPnetMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ColorWOFinal</title>
<meta content=0 http-equiv=Expires>
<meta name=GENERATOR content="Microsoft Visual Studio 7.0">
<meta name=CODE_LANGUAGE content=C#>
<meta name=vs_defaultClientScript content=JavaScript>
<meta name=vs_targetSchema content=http://schemas.microsoft.com/intellisense/ie5><LINK rel=stylesheet type=text/css href="../../../../styloDESC.CSS" >
<script language=javascript>
			var previousvalue=0;
			var prepreviousvalue;		
			function showWaitControls(buttonName)
			{
				waitControls.style.display='';
			}			
			function getConfirm(CtrlName,Button)
			{
				document.forms[0].elements[CtrlName].value=window.confirm("¿Deseas consultar la siguiente Secuencia?");
				document.forms[0].elements[Button].click()
			} 
			function getdifferance(value,id)
			{
				if(isDigit(value))
				{
					alert("El dato ingresado debe ser numérico")
					document.getElementById(id).value=prepreviousvalue
					document.getElementById(id).focus();										
				}
				
				var j=0;
				var Cantidad = 0; 
				var CantidadReal = 0;
				var Diferencia = 0;
				for(i=0;i<document.forms[0].length;i++)
				{				
					if (document.forms[0].elements[i].name.indexOf('txtCant') != -1)
					{
						Cantidad = document.forms[0].elements[i].value;
					}
					
					if (document.forms[0].elements[i].name.indexOf('txtRegistro') != -1)
					{						
						CantidadReal = document.forms[0].elements[i].value;					
					}
					
					if (document.forms[0].elements[i].name.indexOf('txtDif') != -1)
					{
						Diferencia =Cantidad-CantidadReal;
						document.forms[0].elements[i].value = toFixed(Diferencia, 4);
					}
					
				}
			}
			
			function toFixed(value, precision) {
				var precision = precision || 0,
					power = Math.pow(10, precision),
					absValue = Math.abs(Math.round(value * power)),
					result = (value < 0 ? '-' : '') + String(Math.floor(absValue / power));

				if (precision > 0) {
					var fraction = String(absValue % power),
						padding = new Array(Math.max(precision - fraction.length, 0) + 1).join('0');
					result += '.' + padding + fraction;
				}
				return result;
			}
			
			function isDigit(num) 
			{
			var string="1234567890.";
			for(i=0;i<num.length;i++)
			{
			if (string.indexOf(num.charAt(i))==-1)
			{
			return true;
			break;
			}
			else
			{return false;}
			}
			}
			function previousvalues(values)
			{	
				prepreviousvalue=previousvalue
				previousvalue=values
				
			}
		</script>
</HEAD>
<body onload=getdifferance(1,1) MS_POSITIONING="GridLayout" 
;>
<form id=ColorWOFinal method=post runat="server">
<table width=700 align=center>
  <tbody>
  <tr>
    <td colSpan=4 align=center><asp:label id=lblTitle runat="server" Font-Names="Arial Narrow" Font-Bold="True" Font-Size="14">Fase de Color - Paso 3</asp:label>
      <hr>
    </TD></TR>
  <tr>
    <td><asp:label id=Label3 runat="server" CssClass="standard-text">Secuencia:</asp:label></TD>
    <td><asp:textbox id=txtSecuencia CssClass="Standard-text" Runat="server" ReadOnly="True" Width="250px" BorderStyle="Groove"></asp:textbox></TD>
    <td><asp:label id=Label5 runat="server" CssClass="standard-text">Fecha:</asp:label></TD>
    <td><asp:textbox id=txtFecha CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD></TR>
  <tr>
    <td><asp:label id=Label4 runat="server" CssClass="standard-text">UTEC:</asp:label></TD>
    <td><asp:textbox id=txtUTEC CssClass="Standard-text" Runat="server" ReadOnly="True" Width="250px" BorderStyle="Groove"></asp:textbox></TD>
    <td><asp:label id=Label6 runat="server" CssClass="standard-text">Láminas:</asp:label></TD>
    <td><asp:textbox id=txtCantidad CssClass="Standard-text" Runat="server" ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD></TR>
  <tr>
    <td></TD>
    <td></TD>
    <td></TD>
    <td></TD></TR>
  <tr>
    <td colSpan=4><cyberakt:aspnetmenu id=tabColor runat="server" DefaultItemSelectedCssClass="SelectedMenuItem" ExpandDelay="50" ImagesBaseURL='="images/"' MenuStyle="ClassicHorizontal" DefaultItemCssClass="MenuItem" DefaultItemCssClassOver="MenuItemOver" DefaultItemSelectedCssClassOver="SelectedMenuItem" DefaultItemSpacing="3"></cyberakt:aspnetmenu>
      <div>
      <table style="Z-INDEX: 100; POSITION: relative; TOP: -4px" border=0 
      cellSpacing=0 cellPadding=0 width=700>
        <tr>
          <td style="HEIGHT: 7px" bgColor=#276187><IMG border=0 src="images/spacer.gif" width=5 height=7 ></TD></TR>
        <TR>
          <TD bgColor=#276187 colSpan=4 align=center 
        ></TD></TR>
        <TR>
          <TD bgColor=#276187 colSpan=4 align=center 
        ></TD></TR>
        <tr>
          <td bgColor=lightgrey colSpan=4><asp:datagrid id=dgdColorWO runat="server" Font-Names="Verdana" Width="700px" BorderStyle="None" CellPadding="2" BorderColor="DimGray" AutoGenerateColumns="False" Font-Name="Verdana" FontSize="11px" AllowSorting="True">
<HeaderStyle Font-Bold="True" BackColor="DarkGray">
</HeaderStyle>

<Columns>
<asp:TemplateColumn HeaderText="Material">
<HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="60px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
															<asp:label id=lblCodigoSAP Width="60px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodigoSAP") %>'>
															</asp:label>
														
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Descripci&#243;n">
<HeaderStyle HorizontalAlign="Center" Width="200px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="200px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
															<asp:label id=lblDescripcion Width="200px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
															</asp:label>
														
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Grupo">
<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="50px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
															<asp:label id=lblGrupo Width="50px" CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Grupo") %>'>
															</asp:label>
														
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Cantidad (grs.)">
<HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="50px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblCantidad CssClass="standard-text" Runat="server" Text='<%# String.Format("{0:f4}",DataBinder.Eval(Container, "DataItem.Cantidad"))%>' Visible="False">
															</asp:label>
<asp:label id=lblAforo CssClass="standard-text" Runat="server" Text='<%# String.Format("{0:f3}",DataBinder.Eval(Container, "DataItem.Aforo"))%>' Visible="False">
															</asp:label>
<asp:TextBox onblur=getdifferance(this.value,this.id) style="Z-INDEX: 0" id=txtCant onfocus=previousvalues(this.value) CssClass="Standard-text" Runat="server" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Enabled="False"></asp:TextBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Cantidad Real &lt;br&gt;(grs.)">
<HeaderStyle HorizontalAlign="Center" Width="100%" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="50px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:TextBox onblur=getdifferance(this.value,this.id) id=txtRegistro onfocus=previousvalues(this.value) CssClass="Standard-text" Runat="server" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
															</asp:TextBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn Visible="False" HeaderText="Registro">
<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="80px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblRegistro CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CantidadReal") %>'>
															</asp:label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Diferencia">
<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="80px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
<asp:label id=lblDiffrencia CssClass="standard-text" Runat="server" Visible="False"></asp:label>
<asp:TextBox onblur=getdifferance(this.value,this.id) style="Z-INDEX: 0" id=txtDif CssClass="Standard-text" Runat="server" BorderStyle="Groove" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Enabled="False"></asp:TextBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Lote de Pasta">
<HeaderStyle HorizontalAlign="Center" Width="100px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="50px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
															<asp:TextBox id=txtlotePasta onfocus=previousvalues(this.value) BorderStyle="Groove" CssClass="Standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotePasta") %>'>
															</asp:TextBox>
														
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn Visible="False" HeaderText="Lote Pasta">
<HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="grid-header" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Width="80px" CssClass="grid-item">
</ItemStyle>

<ItemTemplate>
															<asp:label id=lblLotePasta CssClass="standard-text" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LotePasta") %>'>
															</asp:label>
														
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
</asp:datagrid></TD></TR></TABLE></DIV></TD></TR></TD></TR>
  <tr>
    <td colSpan=4><asp:label id=Label1 runat="server" CssClass="standard-text">Mensaje de Piso</asp:label></TD></TR>
  <tr>
    <td colSpan=4><asp:textbox id=txtPiso CssClass="Standard-text" Runat="server" ReadOnly="True" Width="735px" BorderStyle="Groove" TextMode="MultiLine" Height="65px"></asp:textbox></TD></TR>
  <TR>
    <TD colSpan=4>
      <table width="100%" align=center>
        <TR height=40>
          <TD vAlign=top width=112 align=center><asp:button id=btnAditivos CssClass="botonesInput" Runat="server" Width="110px" Text="Consultar Aditivos"></asp:button><INPUT 
            style="WIDTH: 23px; HEIGHT: 22px" name=txtHidden size=1 type=hidden 
            ></TD>
          <TD vAlign=top width=112 align=center><asp:button id=btnAgregarMensaje CssClass="botonesInput" Runat="server" Width="110px" Text="Mensaje de piso"></asp:button></TD>
          <TD vAlign=top width=90 align=center><asp:button id=btnImprimir CssClass="botonesInput" Runat="server" Width="90px" Text="Imprimir"></asp:button></TD>
          <TD vAlign=top width=90 align=center><asp:button id=btnLiberar CssClass="botonesInput" Runat="server" Width="90px" Text="Liberar"></asp:button></TD>
          <TD vAlign=top width=100 align=center><asp:button id=btnAceptar CssClass="botonesInput" Runat="server" Width="90px" Text="Aceptar"></asp:button></TD>
          <TD vAlign=top width=100 align=center><asp:button id=btnCancel CssClass="botonesInput" Runat="server" Width="90px" Text="Regresar"></asp:button></TD>
          <TD vAlign=top width=100 align=center>
            <DIV style="DISPLAY: none" id=waitControls>
            <TABLE id=Table1 width=50>
              <TR>
                <TD vAlign=top colSpan=3 align=center>
                  <P align=center><asp:label id=Label8 runat="server" CssClass="standard-text">Procesando...</asp:label><BR 
                  ><asp:image id=Image2 runat="server" ImageUrl="../../../../Images/waitImage.gif"></asp:image></P></TD></TR></TABLE></DIV></TD></TR></TABLE></TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
