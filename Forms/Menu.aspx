<%@ Register TagPrefix="uc1" TagName="mainMenu" Src="../Controls/mainMenu.ascx" %>
<%@ Page language="c#" Codebehind="Menu.aspx.cs" AutoEventWireup="false" Inherits="UserInterface.Forms.Menu" %>
<HTML>
	<HEAD>
		<title>Gu�a de estilo</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script language="JavaScript">
<!--

<!--
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);
// -->
//-->
		</script>
		
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<div align="center">
			<table cellSpacing="0" cellPadding="0" width="800" border="0">
				<tr>
					<td bgColor="#003366" colSpan="3"><uc1:mainmenu id="MainMenu1" runat="server"></uc1:mainmenu></td>
				</tr>
				<tr>
					<td width="20" height="13">&nbsp;</td>
					<td width="760" height="13">&nbsp;</td>
					<td width="20" height="13">&nbsp;</td>
				</tr>
				<tr>
					<td width="20">&nbsp;</td>
					<td vAlign="top" width="760">
						<table height="582" cellSpacing="3" cellPadding="0" align="center" border="0">
							<TBODY>
								<tr>
									<td class="contenido" vAlign="top" width="334" height="174">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td width="16" bgColor="#003366" height="14"><IMG height="16" src="../images/img-corte_inicio.gif" width="16"></td>
												<td class="letra_blanca" bgColor="#003366" height="14">
													<P>Cat�logos Generales</P>
												</td>
											</tr>
											<tr>
												<td width="16" bgColor="#ffffff"></td>
												<td vAlign="top" bgColor="#ededed"><IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="lnkPlant" runat="server" NavigateUrl="Structures/Plant.aspx">Planta</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="hlkLinea" runat="server" NavigateUrl="Structures/Linea.aspx">Lineas de Producci�n</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="lnkPresentacion" runat="server" NavigateUrl="Structures/Presentacion.aspx">Presentacion</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="lnkMedida" runat="server" NavigateUrl="Structures/Medida.aspx">Medida</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="lnkEspesor" runat="server" NavigateUrl="Structures/Espesor.aspx">Espesor</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="Structures/Colour.aspx">Color</asp:hyperlink>&nbsp;<br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink4" runat="server" NavigateUrl="Structures/FamiliaProductos.aspx">Familia de Productos</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink7" runat="server" NavigateUrl="Structures/TipoPMMA.aspx">Tipo de Prepol�mero (PMMA)</asp:hyperlink><br>
													<br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink11" runat="server" NavigateUrl="Structures/Material.aspx">Material</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink14" runat="server" NavigateUrl="Structures/ListOfMaterial.aspx">Asignar formulaci�n de Color para SAP</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink17" runat="server" NavigateUrl="Structures/UpdateMaterialList.aspx">Actualizar Lista de Materiales en SAP</asp:hyperlink><br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;&nbsp;
													<asp:hyperlink id="Hyperlink19" runat="server" NavigateUrl="Structures/UpdateMaterialListDta.aspx">Actualizar Lista de Materiales</asp:hyperlink><br>
												</td>
											</tr>
											<tr vAlign="top">
												<td bgColor="#ffffff">
													<div align="right"><IMG height="5" src="imagenes/img-trans.gif" width="5"></div>
												</td>
												<td bgColor="#999999">
													<div align="right"><IMG height="5" src="IMAGENES/esquinaTablaBase.gif" width="5"></div>
												</td>
											</tr>
										</table>
										<br>
									</td>
									<td class="contenido" vAlign="top" width="20" height="174">&nbsp;</td>
									<td class="contenido" vAlign="top" width="340" height="174">
										<div align="right">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td width="16" bgColor="#003366"><IMG height="16" src="../images/img-corte_inicio.gif" width="16"></td>
													<td class="letra_blanca" bgColor="#003366">Estructuras</td>
												</tr>
												<tr>
													<td width="16" bgColor="#ffffff"></td>
													<td vAlign="top" bgColor="#ededed">
														<P><IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink6" runat="server" NavigateUrl="Structures/Peso.aspx">Tabla de Pesos</asp:hyperlink><br>
															<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink3" runat="server" NavigateUrl="Structures/FormAditivos.aspx">Formulaci�n de Aditivos</asp:hyperlink><br>
															<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink5" runat="server" NavigateUrl="Structures/FormColor.aspx">Formulaci�n de Color</asp:hyperlink><br>
															<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink10" runat="server" NavigateUrl="Structures/FormPresentacion.aspx">Formulaci�n de Presentaciones</asp:hyperlink><br>
															<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink9" runat="server" NavigateUrl="Structures/FormPVC.aspx">Formulaci�n de PVC</asp:hyperlink><br>
															<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink8" runat="server" NavigateUrl="Structures/FormCintas.aspx">Formulaci�n de Cintas</asp:hyperlink><br>
															<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
															<asp:hyperlink id="Hyperlink15" runat="server" NavigateUrl="Structures/FormTemperatura.aspx">Formulaci�n de Temperatura</asp:hyperlink><br>
														</P>
													</td>
												</tr>
												<tr vAlign="top">
													<td bgColor="#ffffff">
														<div align="right"><IMG height="5" src="imagenes/img-trans.gif" width="5"></div>
													</td>
													<td bgColor="#999999">
														<div align="right"><IMG height="5" src="IMAGENES/esquinaTablaBase.gif" width="5"></div>
													</td>
												</tr>
											</table>
										</div>
									</td>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="334">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td width="16" bgColor="#003366"><IMG height="16" src="../images/img-corte_inicio.gif" width="16"></td>
												<td class="letra_blanca" bgColor="#003366">Logistica</td>
											</tr>
											<tr>
												<td width="16" bgColor="#ffffff"></td>
												<td vAlign="top" bgColor="#ededed">
													<P><IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkPrgPdt" runat="server" NavigateUrl="Logistics/LoadProduccionPrograma.aspx">Cargar Programa de Producci�n</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="Logistics/ProgrammaProduction.aspx">Consultar Programa de Producci�n</asp:hyperlink>&nbsp;<br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkOrdTra" runat="server" NavigateUrl="Logistics/OrdenesTrabajo.aspx">Generar �rdenes de Trabajo</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="Hyperlink18" runat="server" NavigateUrl="Logistics/SecuenciasCombinadas.aspx">Secuencias Combinadas</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="lnkunLibrer" runat="server" NavigateUrl="Production/UnLiberer.aspx">Reactivar Secuencias</asp:hyperlink><U></U></P>
													<P><U>Administracion</U><BR>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">
														<asp:hyperlink id="lnkPermiso" runat="server" NavigateUrl="Administration/Permission.aspx">Permiso Perfil</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">
														<asp:hyperlink id="lnkUsuarios" runat="server" NavigateUrl="Administration/Users.aspx">Cat�logo de Usuarios</asp:hyperlink><br>
													</P>
												</td>
											</tr>
											<TR vAlign="top">
												<TD bgColor="#ffffff">
													<DIV align="right"><IMG height="5" src="imagenes/img-trans.gif" width="5"></DIV>
												</TD>
												<TD bgColor="#999999">
													<DIV align="right"><IMG height="5" src="IMAGENES/esquinaTablaBase.gif" width="5"></DIV>
												</TD>
											</TR>
										</table>
										<BR>
									</td>
									<TD class="contenido" vAlign="top" width="20">&nbsp;</TD>
									<TD class="contenido" vAlign="top" width="340">
										<DIV align="right">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
													<TR>
														<TD width="16" bgColor="#003366"><IMG height="16" src="../images/img-corte_inicio.gif" width="16"></TD>
														<TD class="letra_blanca" bgColor="#003366">Producci�n</TD>
													</TR>
													<TR>
														<td width="16" bgColor="#ffffff"></td>
														<td vAlign="top" bgColor="#ededed">
															<P><IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultReaccionWO" runat="server" NavigateUrl="Production/ConsultReactionWO.aspx">Cuarto de Reacci�n</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkAdjustTank" runat="server" NavigateUrl="Production/AdjustTanque.aspx">Ajustar Tanques de PMMA</asp:hyperlink><br>
																<br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="Hyperlink16" runat="server" NavigateUrl="Production/WorkOrder/PartidasColor/ConsultColorWO.aspx">Cuarto de Color</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultAditivosWO" runat="server" NavigateUrl="Production/ConsultAditivosWO.aspx">Cuarto de Aditivos</asp:hyperlink><BR>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultPVCWO" runat="server" NavigateUrl="Production/ConsultPVCWO.aspx">Cuarto de PVC</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultMixtureWO" runat="server" NavigateUrl="Production/ConsultMixturesWO.aspx">Cuarto de Mezclas</asp:hyperlink><BR>
																<br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultAssembleWO" runat="server" NavigateUrl="Production/ConsultAssembleWO.aspx">Fase de Armado</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultFillingWO" runat="server" NavigateUrl="Production/ConsultFillingWO.aspx">Fase de Llenado</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkCurado" runat="server" NavigateUrl="Production/ConsultarCured.aspx">Fase de Curado</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="Hyperlink12" runat="server" NavigateUrl="Production/WorkOrder/PartidasPostCurado/Consultar_PostCured.aspx">Fase de Post Curado</asp:hyperlink><br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="lnkPreseparation" runat="server" NavigateUrl="Production/ConsultPreseparationWO.aspx">Fase de Preseparaci�n</asp:hyperlink><BR>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="hlkConsultSeparacionWO" runat="server" NavigateUrl="Production/ConsultSeparacionWO.aspx">Fase de Separaci�n</asp:hyperlink><BR>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="LnkConsultInspectionWorkOrders" runat="server" NavigateUrl="Production/WorkOrder/InspectionPhase/ConsultInspectionWO.aspx">Fase de Inspecci�n</asp:hyperlink><BR>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="lnkQuarantineWO" runat="server" NavigateUrl="Production/ConsultQuarantineWO.aspx">Fase de Cuarentena</asp:hyperlink>&nbsp;<BR>
																<br>
																<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
																<asp:hyperlink id="Hyperlink13" runat="server" NavigateUrl="Production/ConsultFPStorageWO.aspx">Almac�n de Producto Terminado</asp:hyperlink>&nbsp;<BR>
															</P>
														</td>
													</TR>
													<TR vAlign="top">
														<td bgColor="#ffffff">
															<div align="right"><IMG height="5" src="imagenes/img-trans.gif" width="5"></div>
														</td>
														<td bgColor="#999999">
															<div align="right"><IMG height="5" src="IMAGENES/esquinaTablaBase.gif" width="5"></div>
														</td>
													</TR>
												</TBODY></TABLE>
										</DIV>
									</TD>
								</tr>
								<tr>
									<td class="contenido" vAlign="top" width="334">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td width="16" bgColor="#003366"><IMG height="16" src="../images/img-corte_inicio.gif" width="16"></td>
												<td class="letra_blanca" bgColor="#003366">Calidad</td>
											</tr>
											<tr>
												<td width="16" bgColor="#ffffff"><IMG height="100" src="imagenes/img-trans.gif" width="5"></td>
												<td vAlign="top" bgColor="#ededed"><IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;<br>
													<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
												</td>
											</tr>
											<tr vAlign="top">
												<td bgColor="#ffffff">
													<div align="right"><IMG height="5" src="imagenes/img-trans.gif" width="5"></div>
												</td>
												<td bgColor="#999999">
													<div align="right"><IMG height="5" src="IMAGENES/esquinaTablaBase.gif" width="5"></div>
												</td>
											</tr>
										</table>
										<br>
									</td>
									<td class="contenido" vAlign="top" width="20">&nbsp;</td>
									<td class="contenido" vAlign="top" width="340">
										<div align="right">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td width="16" bgColor="#003366"><IMG height="16" src="../images/img-corte_inicio.gif" width="16"></td>
													<td class="letra_blanca" bgColor="#003366">Reportes</td>
												</tr>
												<tr>
													<td width="16" bgColor="#ffffff"></td>
													<td vAlign="top" bgColor="#ededed"><IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="LnkAdditivesPhaseReports" runat="server" NavigateUrl="Reports/Report.aspx?Title=Aditivos">Additive Phase Reports</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="LnkPartidasColorRpt" runat="server" NavigateUrl="Reports/Report.aspx?Title=Color">Color Phase Reports</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkConAditivosRep" runat="server" NavigateUrl="Reports/Report.aspx?Title=Consumptions Aditivos">Consult Consumption Additivos Report</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkReaccionRep" runat="server" NavigateUrl="Reports/Report.aspx?Title=Reaccion">Consult Reaccion Report</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkMezclasRep" runat="server" NavigateUrl="Reports/Report.aspx?Title=Mezclas">Consult Mezclas Report</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkConMezclasRep" runat="server" NavigateUrl="Reports/Report.aspx?Title=Consumptions Mezclas">Consult Consumption Mezclas Report</asp:hyperlink><br>
														<IMG height="7" src="../images/ico-bullet_azul.gif" width="7">&nbsp;
														<asp:hyperlink id="hlkConColorRep" runat="server" NavigateUrl="Reports/Report.aspx?Title=Consumptions Color">Consult Consumption Color Report</asp:hyperlink><br>
													</td>
												</tr>
												<tr vAlign="top">
													<td bgColor="#ffffff">
														<div align="right"><IMG height="5" src="imagenes/img-trans.gif" width="5"></div>
													</td>
													<td bgColor="#999999">
														<div align="right"><IMG height="5" src="IMAGENES/esquinaTablaBase.gif" width="5"></div>
													</td>
												</tr>
											</table>
										</div>
									</td>
								</tr>
							</TBODY></table>
					</td>
					<td width="20"></td>
				</tr>
			</table>
		</div>
		<P></P>
		</TD></TR></TBODY>
		<DIV></DIV>
		</TR></TBODY></TABLE>
		<DIV></DIV>
		</TD></TR></TBODY>
		<DIV></DIV>
		</TABLE></TR>
		<DIV></DIV>
	</body>
</HTML>
