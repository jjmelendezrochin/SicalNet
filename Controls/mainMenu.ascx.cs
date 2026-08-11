namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Web.Security;
	using System.Collections;
	using System.Security.Principal;
	using System.Web.SessionState;	
	using System.ComponentModel;	
	using System.Web.UI;	
	using SICALNet.BusinessEntities;
	using SICALNet.BusinessLogicLayer;	


	/// <summary>
	///		Summary description for mainMenu.
	/// </summary>
	public abstract class mainMenu : System.Web.UI.UserControl
	{
		protected string modulePath=string.Empty;
		protected CYBERAKT.WebControls.Navigation.ASPnetMenu initialMenu;
		public string sScript = null;
		public UserInterface.Forms.Production.WorkOrder.LiberationPhase.Log log;
		public string path = HttpContext.Current.Request.MapPath("~");
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			log =  new UserInterface.Forms.Production.WorkOrder.LiberationPhase.Log (this.path);
			//reviso si sigo conectado
			if (!SessionSicalnet())
			{
				Response.Clear();
                Response.Write("<script>window.parent.location='"+ modulePath + "../logout.aspx';</script>"); 
				
			}
		

			if (!IsPostBack)
			{			
				string sRuta = this.getModulePath();
				//log.Add("Ruta obtenida " + sRuta);
				
				LoadMenuOptions();
			}
		}

		private Boolean SessionSicalnet()
		{
			bool havesession = true;
			

			foreach(DictionaryEntry objItem in Cache) 
			{ 
				System.Web.UI.Page myUser = new System.Web.UI.Page();

				if (myUser.User.Identity.Name.ToString() + "||TOKILLSESSION" == objItem.Key.ToString())
				{
					// marca de borrar cuentas
					
					HttpContext.Current.Cache.Remove(myUser.User.Identity.Name.ToString());
					HttpContext.Current.Cache.Remove(myUser.User.Identity.Name.ToString() + "||TOKILLSESSION");	

					havesession = false;
					break;
				}
			}
		return havesession;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadMenuOptions()
		{
		
			#region MENU LAYOUT
			//
			//			1.0 Administración
			//				1.1 Usuarios
			//				1.2 Módulos
			//				1.3 Perfiles
			//				1.4 Permisos Perfil

			//			2.0 Catálogos
			//				2.1 Plantas
			//				2.2 Líneas de Producción
			//				2.3 Presentaciones
			//				2.4 Medidas
			//				2.5 Espesores
			//				2.6 Colores
			//				2.7 Familias de Producto
			//				2.8 Tipos Prepolímero (PMMA)
			
			//			3.0 Estructuras
			//				3.1 Catálogo de Materiales 
			//				3.2 Formulación de Color para SAP
			//				3.3 Actualizar Lista de Materiales SAP
			//				3.4 =======================
			//				3.5 Tabla de Pesos
			//				3.6 Formulación de Color
			//				3.7 Formulación de Aditivos
			//				3.8 Formulación de PVC
			//				3.9 Formulación de Presentaciones
			//				3.10 Formulación de Cintas
			//				3.11 Formulación de Temperaturas

			//			4.0 Logística
			//				4.1 Cargar Programa de Producción
			//				4.2 Consultar Programa de Producción
			//				4.3 Generar Órdenes de Trabajo
			//				4.4 Combinar Secuencias
			//				4.5 Reactivar Secuencias

			//			5.0 Producción
			//				5.1 Cuarto de Reacción
			//					5.1.1 Consultar Ordenes de Trabajo
			//					5.1.2 Ajustar Tanques de PMMA
			//				5.2 Cuarto de Color
			//				5.3 Cuarto de Aditivos
			//				5.4 Cuarto de PVC
			//				5.5 Cuarto de Mezclas
			//				5.6 Fase de Armado
			//				5.7 Fase de Llenado
			//				5.8 Fase de Curado
			//				5.9 Fase de Post-Curado
			//				5.10 Fase de Preseparacion
			//				5.11 Fase de Separación
			//				5.12 Fase de Inspección
			//				5.13 Fase de Cuarentena
			//				5.14 Fase de Entrega de Producto Terminado
			//				5.15 Fase de Recepción de Producto Terminado

			//			6.0 Reportes
			//				6.1 Reporte de Consumos
			//				6.2 Reporte de Calidad

			//				6.7 Report de Consult Mezclas 
			//				6.8 Report de Consult Reaccion
			//				6.9 Reporte de Consult Consumption Mezclas
			//				6.10 Reporte de Consult Filling Phase

			//			7.0 Ayuda
			//			8.0 Salir
			#endregion

										
			initialMenu.ImagesBaseURL =modulePath+"../images/";
			initialMenu.DefaultItemSpacing=1;
			initialMenu.DefaultGroupCssClass = "MainMenuGroup";
			initialMenu.DefaultItemCssClass = "MainMenuItem";
			initialMenu.DefaultItemCssClassOver = "MainMenuItemOver";
			initialMenu.MenuStyle = CYBERAKT.WebControls.Navigation.ASPnetMenuStyle.ClassicHorizontal;
			initialMenu.ExpandEffect = CYBERAKT.WebControls.Navigation.ASPnetMenuEffect.Fade;
			initialMenu.ExpandDelay= 80;

			
			CreateHomeMenu();
			
			if (this.Context.User.IsInRole("1.0"))
				CreateAdminMenu();
			if (this.Context.User.IsInRole("2.0"))
				CreateCatalogMenu();
			if (this.Context.User.IsInRole("3.0"))
				CreateStructuresMenu();
			if (this.Context.User.IsInRole("4.0"))
				CreateLogisticsMenu();
			if (this.Context.User.IsInRole("5.0"))
				CreateProductionMenu();
			if (this.Context.User.IsInRole("6.0"))
				CreateReportsMenu();

			CreateHelpMenu();
			CreateExitMenu();
			/**/
		}

		private void CreateHomeMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;

			//0.0 Inicio
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Inicio";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.LeftIconWidth=12;
			newItem.ChildExpandedLeftIcon="grayDots.gif";
			newItem.URL=modulePath+"NewMenu.aspx";
		}

		private void CreateAdminMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//1.0 Administración
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Administración";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Administracion";

			//newGroup = initialMenu.Groups["g_Administracion"];

			 if (this.Context.User.IsInRole("1.1"))
			{
				//1.1 Catalogo de Usuarios
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Usuarios"; 
				newItem.TextAlign="left";
				newItem.ID = "i1.1";
				//newItem.URL=modulePath+"Administration/UsersList.aspx";
				 newItem.URL="/SicalNet/Forms/Administration/UsersList.aspx";
			}
			//log.Add(modulePath+"Administration/UsersList.aspx");

			//1.2 Catalogo de Permisos
			if (this.Context.User.IsInRole("1.2"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Perfiles"; 
				newItem.ID = "i1.2";
				//newItem.URL=modulePath+"Administration/Profiles.aspx";
				newItem.URL="/SicalNet/Forms/Administration/Profiles.aspx";
			}

			//1.3 Desbloqueo de cuentas
			if (this.Context.User.IsInRole("1.3"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Desbloqueo de Cuentas"; 
				newItem.ID = "i1.3";
				//newItem.URL=modulePath+"Administration/UnlockAccounts.aspx";
				newItem.URL="/SicalNet/Forms/Administration/UnlockAccounts.aspx";
			}

			//1.4 Bitacora
			if (this.Context.User.IsInRole("1.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Bitacora de Sucesos"; 
				newItem.ID = "i1.4";
				//newItem.URL=modulePath+"Administration/ConsultBitacora.aspx";
				newItem.URL="/SicalNet/Forms/Administration/ConsultBitacora.aspx";
				
			}

			//1.4 Desconectar Cuentas
			if (this.Context.User.IsInRole("1.5"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Desconectar Cuentas"; 
				newItem.ID = "i1.4";
				//newItem.URL=modulePath+"Administration/DisconnectAccounts.aspx";
				newItem.URL="/SicalNet/Forms/Administration/DisconnectAccounts.aspx";
			}

		}

		private void CreateCatalogMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//2.0 Catálogos
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Catálogos";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Catalogos";

			//newGroup = initialMenu.Groups["g_Administracion"];
///
			if (this.Context.User.IsInRole("2.11") || this.Context.User.IsInRole("2.12"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.RightIcon="arrow_white.gif";
				newItem.Label = "Formulacion"; 
				newItem.ID = "i2.0";
			}
			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_SubFormulacion";

			// 2.11 Folios Color
			if (this.Context.User.IsInRole("2.11"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Folios Color"; 
				newItem.ID = "i2.11";
				//newItem.URL=modulePath+"Structures/FoliosColor.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FoliosColor.aspx";
			}

			// 2.12 Folios Aditivos
			if (this.Context.User.IsInRole("2.12"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Folios Aditivos"; 
				newItem.ID = "i2.12";
				//newItem.URL=modulePath+"Structures/FoliosAditivos.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FoliosAditivos.aspx";
			}

			newGroup = initialMenu.Groups["g_Catalogos"];			
			
			//2.1 Catalogo de Plantas
			if (this.Context.User.IsInRole("2.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Plantas"; 
				newItem.ID = "i2.1";
				//newItem.URL=modulePath+"Structures/Plant.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Plant.aspx";				
			}
			//log.Add(modulePath+"Structures/Plant.aspx");

			//2.2 Catalogo de Líneas de Producción
			if (this.Context.User.IsInRole("2.2"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Líneas de Producción"; 
				newItem.ID = "i2.2";
				//newItem.URL=modulePath+"Structures/Linea.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Linea.aspx";
			}

			//2.3 Catalogo de Plantas
			if (this.Context.User.IsInRole("2.3"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Presentaciones"; 
				newItem.ID = "i2.3";
				//newItem.URL=modulePath+"Structures/Presentacion.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Presentacion.aspx";
			}

			//2.4 Catalogo de Medidas
			if (this.Context.User.IsInRole("2.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Medidas"; 
				newItem.ID = "i2.4";
				//newItem.URL=modulePath+"Structures/Medida.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Medida.aspx";
			}

			//2.5 Catálogo de Espesores
			if (this.Context.User.IsInRole("2.5"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Espesores"; 
				newItem.ID = "i2.5";
				//newItem.URL=modulePath+"Structures/Espesor.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Espesor.aspx";
			}

			//2.6 Catálogo de Colores
			if (this.Context.User.IsInRole("2.6"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Colores"; 
				newItem.ID = "i2.6";
				//newItem.URL=modulePath+"Structures/Colour.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Colour.aspx";
			}

			//	2.7 Catálogo de Familias de Producto
			if (this.Context.User.IsInRole("2.7"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Familias de Producto"; 
				newItem.ID = "i2.7";
				//newItem.URL=modulePath+"Structures/FamiliaProductos.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FamiliaProductos.aspx";
			}

			// 2.8 Catálogo de Tipos Prepolímero (PMMA)
			if (this.Context.User.IsInRole("2.8"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Tipos de Prepolímero (PMMA)"; 
				newItem.ID = "i2.8";
				//newItem.URL=modulePath+"Structures/TipoPMMA.aspx";
				newItem.URL="/SicalNet/Forms/Structures/TipoPMMA.aspx";
			}

			// 2.9 Catálogo de Lotes
			if (this.Context.User.IsInRole("2.9"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Lotes"; 
				newItem.ID = "i2.9";
				//newItem.URL=modulePath+"Structures/Lotes.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Lotes.aspx";
			}
			// 2.10 Catálogo de Ollas
			if (this.Context.User.IsInRole("2.10"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Ollas"; 
				newItem.ID = "i2.10";
				//newItem.URL=modulePath+"Structures/Ollas.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Ollas.aspx";
			}

			// 2.11 Catálogo de Cubas
			if (this.Context.User.IsInRole("2.11"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cubas Area de Curado"; 
				newItem.ID = "i2.11";
				//newItem.URL=modulePath+"Structures/Cubas.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Cubas.aspx";
			}

			// 2.12 Catálogo de Zonas
			if (this.Context.User.IsInRole("2.12"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cubas Area de Post Curado"; 
				newItem.ID = "i2.12";
				//newItem.URL=modulePath+"Structures/Zonas.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Zonas.aspx";
			}

			// 2.12 Catálogo de Vidrios
			if (this.Context.User.IsInRole("2.13"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Vidrios"; 
				newItem.ID = "i2.13";
				//newItem.URL=modulePath+"Structures/VidriosTamanio.aspx";
				newItem.URL="/SicalNet/Forms/Structures/VidriosTamanio.aspx";
			}

			// 2.14 Catálogo de Aforo
			if (this.Context.User.IsInRole("2.14"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Aforo"; 
				newItem.ID = "i3.14";
				//newItem.URL=modulePath+"Structures/Aforo.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Aforo.aspx";
			}

			// 2.15 Catálogo de Anillos
			if (this.Context.User.IsInRole("2.15"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Anillos"; 
				newItem.ID = "i2.15";
				newItem.URL="/SicalNet/Forms/Structures/Anillos.aspx";
			}


		}

		private void CreateStructuresMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//3.0 Estructuras
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Estructuras";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Estructuras";


			//newGroup = initialMenu.Groups["g_Administracion"];

			//3.1 Catalogo de Materiales
			if (this.Context.User.IsInRole("3.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Catálogo de Materiales"; 
				newItem.ID = "i3.1";
				//newItem.URL=modulePath+"Structures/Material.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Material.aspx";
			}

			//3.2 Formulación de Color para SAP
			if (this.Context.User.IsInRole("3.2"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de Color para SAP"; 
				newItem.ID = "i3.2";
				//newItem.URL=modulePath+"Structures/ListOfMaterial.aspx";
				newItem.URL="/SicalNet/Forms/Structures/ListOfMaterial.aspx";
			}

			//3.3 Actualizar Lista de Materiales SAP
			if (this.Context.User.IsInRole("3.3"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Actualizar Lista de Materiales para SAP"; 
				newItem.ID = "i3.3";
				//newItem.URL=modulePath+"Structures/UpdateMaterialList.aspx";
				newItem.URL="/SicalNet/Forms/Structures/UpdateMaterialList.aspx";
			}

			//3.3 Actualizar Lista de Materiales Datasul
			if (this.Context.User.IsInRole("3.3.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Actualizar Lista de Materiales"; 
				newItem.ID = "i3.3";
				//newItem.URL=modulePath+"Structures/UpdateMaterialListDta.aspx";
				newItem.URL="/SicalNet/Forms/Structures/UpdateMaterialListDta.aspx";
			}

			//3.4 Cargar Materiales Fantasmas
			if (this.Context.User.IsInRole("3.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cargar Materiales Fantasmas"; 
				newItem.ID = "i3.4";
				// newItem.URL=modulePath+"Structures/CargarFantasmas.aspx";
				newItem.URL="/SicalNet/Forms/Structures/CargarFantasmas.aspx";
			}

			//3.4.1 Especificaciones de Empaques de PVC y EPDM
			if (this.Context.User.IsInRole("3.4.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Especificaciones de Empaques de PVC y EPDM"; 
				newItem.ID = "i3.4.1";
				//newItem.URL=modulePath+"Structures/EspecificacionesEmpaquesPvc.aspx";
				newItem.URL="/SicalNet/Forms/Structures/EspecificacionesEmpaquesPvc.aspx";
			}

			// 3.4 =======================
			newItem = newGroup.Items.Add(); 
			newItem.Image="Break.gif";
			newItem.CssClass="MenuBreak";
			newItem.Width="100%";
			newItem.Height="2";

			// 3.5 Tabla de Pesos
			if (this.Context.User.IsInRole("3.5"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Tabla de Pesos"; 
				newItem.ID = "i3.5";
				//newItem.URL=modulePath+"Structures/Peso.aspx";
				newItem.URL="/SicalNet/Forms/Structures/Peso.aspx";
			}

			// 3.6 Formulación de Color
			if (this.Context.User.IsInRole("3.6"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de Color"; 
				newItem.ID = "i3.6";
				//newItem.URL=modulePath+"Structures/FormColor.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FormColor.aspx";
			}

			// 3.7 Formulación de Aditivos
			if (this.Context.User.IsInRole("3.7"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de Aditivos"; 
				newItem.ID = "i3.7";
				//newItem.URL=modulePath+"Structures/FormAditivos.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FormAditivos.aspx";
			}

			// 3.8 Formulación de PVC
			if (this.Context.User.IsInRole("3.8"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de PVC"; 
				newItem.ID = "i3.8";
				//newItem.URL=modulePath+"Structures/FormPVC.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FormPVC.aspx";
			}

			// 3.9 Formulación de Presentaciones
			if (this.Context.User.IsInRole("3.9"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de Presentaciones"; 
				newItem.ID = "i3.9";
				//newItem.URL=modulePath+"Structures/FormPresentacion.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FormPresentacion.aspx";
			}

			// 3.10 Formulación de Cintas
			if (this.Context.User.IsInRole("3.10"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de Cintas"; 
				newItem.ID = "i3.10";
				//newItem.URL=modulePath+"Structures/FormCintas.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FormCintas.aspx";
			}

			// 3.11 Formulación de Temperaturas
			if (this.Context.User.IsInRole("3.11"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Formulación de Temperaturas"; 
				newItem.ID = "i3.11";
				//newItem.URL=modulePath+"Structures/FormTemperatura.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FormTemperatura.aspx";
			}

			// 3.12 =======================
			newItem = newGroup.Items.Add(); 
			newItem.Image="Break.gif";
			newItem.CssClass="MenuBreak";
			newItem.Width="100%";
			newItem.Height="2";

			// 3.13 Inventario de Vidrios
			if (this.Context.User.IsInRole("3.13"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Inventario de Vidrios"; 
				newItem.ID = "i3.13";
				newItem.URL=modulePath+"Structures/invVidrios.aspx";
				newItem.URL="/SicalNet/Forms/Structures/invVidrios.aspx";
			}
		}

		private void CreateLogisticsMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//4.0 Logística
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Logística";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Logistica";

			// 4.1 Cargar Programa de Producción
			if (this.Context.User.IsInRole("4.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cargar Programa de Producción"; 
				newItem.ID = "i4.1";
				//newItem.URL=modulePath+"Logistics/LoadProduccionPrograma.aspx";
				newItem.URL="/SicalNet/Forms/Logistics/LoadProduccionPrograma.aspx";
			}
		
			// 4.2 Consultar Programa de Producción
			if (this.Context.User.IsInRole("4.2"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Consultar Programa de Producción"; 
				newItem.ID = "i4.2";
				// newItem.URL=modulePath+"Logistics/ProgrammaProduction.aspx";
				newItem.URL="/SicalNet/Forms/Logistics/ProgrammaProduction.aspx";
			}

			// 4.3 Generar Órdenes de Trabajo
			if (this.Context.User.IsInRole("4.3"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Generar Órdenes de Trabajo"; 
				newItem.ID = "i4.3";
				//newItem.URL=modulePath+"Logistics/OrdenesTrabajo.aspx";
				newItem.URL="/SicalNet/Forms/Logistics/OrdenesTrabajo.aspx";
			}
			
			// 4.4 Combinar Secuencias
			if (this.Context.User.IsInRole("4.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Combinar Secuencias"; 
				newItem.ID = "i4.4";
				//newItem.URL=modulePath+"Logistics/SecuenciasCombinadas.aspx";
				newItem.URL="/SicalNet/Forms/Logistics/SecuenciasCombinadas.aspx";
			}

			if (this.Context.User.IsInRole("4.5"))
			{
				// 4.5 Reactivar Secuencias
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reactivar Secuencias"; 
				newItem.ID = "i4.5";
				//newItem.URL=modulePath+"Production/UnLiberer.aspx";
				newItem.URL="/SicalNet/Forms/Production/Unliberer.aspx";
			}

			// Reporte de ajustes al programa de producción
			if (this.Context.User.IsInRole("4.6"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de Ajustes al programa de Producción"; 
				newItem.ID = "i4.6";
				//newItem.URL=modulePath+"Reports/ReporteMotivosAjusteProgProd.aspx";				
				newItem.URL="/SicalNet/Forms/Reports/ReporteMotivosAjusteProgProd.aspx";
			}		
		}

		private void CreateProductionMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//5.0 Producción
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.LeftIconWidth=12;
			newItem.Label = "Producción";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Produccion";


			// 4.2 Consultar Programa de Producción (OTRA VEZ)
			if (this.Context.User.IsInRole("5.17"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Consultar Programa de Producción"; 
				newItem.ID = "i5.0";
				//newItem.URL=modulePath+"Production/ConsultProgram.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultProgram.aspx";

				// =======================
				newItem = newGroup.Items.Add(); 
				newItem.Image="Break.gif";
				newItem.CssClass="MenuBreak";
				newItem.Width="100%";
				newItem.Height="2";			
			}


			// 5.1 Cuarto de Reacción
			if (this.Context.User.IsInRole("5.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.RightIcon="arrow_white.gif";
				newItem.Label = "Cuarto de Reacción"; 
				newItem.ID = "i5.1";

				newGroup = newItem.AddSubGroup(); 
				newGroup.ID = "g_SubReaccion";

				// 5.1 Cuarto de Reacción
				if (this.Context.User.IsInRole("5.1.1"))
				{
					// 5.1.1 Consultar Ordenes de Trabajo
					newItem = newGroup.Items.Add(); 
					newItem.LeftIconWidth=12;
					newItem.LeftIcon="grayDots.gif";
					newItem.LeftIconOver="orangeDots.gif";
					newItem.Label = "Consultar Ordenes de Trabajo"; 
					newItem.ID = "i5.1.1";
					//newItem.URL=modulePath+"Production/ConsultReactionWO.aspx";
					newItem.URL="/SicalNet/Forms/Production/ConsultReactionWO.aspx";
				}

				// 5.1 Cuarto de Reacción
				if (this.Context.User.IsInRole("5.1.2"))
				{
					// 5.1.2 Ajustar Tanques de PMMA
					newItem = newGroup.Items.Add(); 
					newItem.LeftIconWidth=12;
					newItem.LeftIcon="grayDots.gif";
					newItem.LeftIconOver="orangeDots.gif";
					newItem.Label = "Ajustar Tanque de PMMA"; 
					newItem.ID = "i5.1.2";
					//newItem.URL=modulePath+"Production/AdjustTanque.aspx";
					newItem.URL="/SicalNet/Forms/Production/AdjustTanque.aspx";
				}

			
			}

			
			newGroup = initialMenu.Groups["g_Produccion"];

			// =======================
			newItem = newGroup.Items.Add(); 
			newItem.Image="Break.gif";
			newItem.CssClass="MenuBreak";
			newItem.Width="100%";
			newItem.Height="2";
			
			// 5.2 Cuarto de Color
			if (this.Context.User.IsInRole("5.2"))
			{				
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cuarto de Color"; 
				newItem.ID = "i5.2";
				//newItem.URL=modulePath+"Production/WorkOrder/PartidasColor/ConsultColorWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/WorkOrder/PartidasColor/ConsultColorWO.aspx";
			}

			//	5.3 Cuarto de Aditivos
			if (this.Context.User.IsInRole("5.3"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cuarto de Aditivos"; 
				newItem.ID = "i5.3";
				// newItem.URL=modulePath+"Production/ConsultAditivosWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultAditivosWO.aspx";
			}

			// 5.4 Cuarto de PVC
			if (this.Context.User.IsInRole("5.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cuarto de PVC"; 
				newItem.ID = "i5.4";
				// newItem.URL=modulePath+"Production/ConsultPVCWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultPVCWO.aspx";
			}

			// 5.5 Cuarto de Mezclas
			if (this.Context.User.IsInRole("5.5"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Cuarto de Mezclas"; 
				newItem.ID = "i5.5";
				//newItem.URL=modulePath+"Production/ConsultMixturesWO.aspx";
				//newItem.URL="/SicalNet/Forms/Logistics/Production/ConsultMixuresWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultMixturesWO.aspx";
			}

			// 5.6 Fase de Armado
			if (this.Context.User.IsInRole("5.6"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Armado"; 
				newItem.ID = "i5.6";
				//newItem.URL=modulePath+"Production/ConsultAssembleWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultAssembleWO.aspx";
			}

			// 5.7 Fase de Llenado
			if (this.Context.User.IsInRole("5.7"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Llenado"; 
				newItem.ID = "i5.7";
				//newItem.URL=modulePath+"Production/ConsultFillingWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultFillingWO.aspx";
			}

			// 5.8 Fase de Curado
			if (this.Context.User.IsInRole("5.8"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Curado"; 
				newItem.ID = "i5.8";
				//newItem.URL=modulePath+"Production/ConsultarCured.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultarCured.aspx";
			}

			// 5.9 Fase de Post-Curado
			if (this.Context.User.IsInRole("5.9"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Post-Curado"; 
				newItem.ID = "i5.9";
				//newItem.URL=modulePath+"Production/WorkOrder/PartidasPostCurado/Consultar_PostCured.aspx";
				newItem.URL="/SicalNet/Forms/Production/WorkOrder/PartidasPostCurado/Consultar_PostCured.aspx";
			}

			// 5.10 Fase de Preseparacion
			if (this.Context.User.IsInRole("5.10"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Preseparacion"; 
				newItem.ID = "i5.10";
				//newItem.URL=modulePath+"Production/ConsultPreseparationWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultPreseparationWO.aspx";
			}

			// 5.11 Fase de Separación
			if (this.Context.User.IsInRole("5.11"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Separación"; 
				newItem.ID = "i5.11";
				//newItem.URL=modulePath+"Production/ConsultSeparacionWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultSeparacionWO.aspx";
			}

			// 5.12 Fase de Inspección
			if (this.Context.User.IsInRole("5.12"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Inspección"; 
				newItem.ID = "i5.12";
				//newItem.URL=modulePath+"Production/WorkOrder/InspectionPhase/ConsultInspectionWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/WorkOrder/InspectionPhase/ConsultInspectionWO.aspx";
			}

			// 5.125 Fase de Liberación
			if (this.Context.User.IsInRole("5.125"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Liberación"; 
				newItem.ID = "i5.125";
				//newItem.URL=modulePath+"Production/WorkOrder/LiberationPhase/ConsultLiberationWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/WorkOrder/LiberationPhase/ConsultLiberationWO.aspx";
			}

			// =======================
			newItem = newGroup.Items.Add(); 
			newItem.Image="Break.gif";
			newItem.CssClass="MenuBreak";
			newItem.Width="100%";
			newItem.Height="2";

			// 5.13 Fase de Cuarentena
			if (this.Context.User.IsInRole("5.13"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Fase de Pendientes/Cuarentena"; 
				newItem.ID = "i5.13";
				//newItem.URL=modulePath+"Production/ConsultQuarantineWO.aspx";
				newItem.URL="/SicalNet/Forms/Production/ConsultQuarantineWO.aspx";
			}

			// 5.14 Fase de Entrega de Producto Terminado
			if (this.Context.User.IsInRole("5.14"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Entrega de Producto Terminado"; 
				newItem.ID = "i5.14";
				//newItem.URL=modulePath+"Production/WorkOrder/PartidasEnvioPT/ConsultEnvioPT.aspx";
				newItem.URL="/SicalNet/Forms/Production/WorkOrder/PartidasEnvioPT/ConsultEnvioPT.aspx";
			}

			// 5.15 Fase de Entrega de Producto Terminado
			if (this.Context.User.IsInRole("5.15"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Recepción de Producto Terminado"; 
				newItem.ID = "i5.15";
				//newItem.URL=modulePath+"Production/WorkOrder/PartidasRecepcionPT/ConsultRecepcionPT.aspx";
				newItem.URL="/SicalNet/Forms/Production/WorkOrder/PartidasRecepcionPT/ConsultRecepcionPT.aspx";
			}

			// 5.16 Fase de interfaz SAP
			if (this.Context.User.IsInRole("5.16"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Interfaz SAP"; 
			newItem.ID = "i5.16";
			// newItem.URL=modulePath+"Production/WorkOrder/InterfaceSAP/ConsultInterfaceSAP.aspx";
			newItem.URL="/SicalNet/Forms/Production/WorkOrder/InterfaceSAP/ConsultInterfaceSAP.aspx";
			}

		}

		private void CreateReportsMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//6.0 Reportes
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Reportes";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Reportes";
			//newGroup.ExpandOffsetX=-1;
			//newGroup.ExpandOffsetY=1;

			//newGroup = initialMenu.Groups["g_Administracion"];

			// 6.1 Reportes Fase de Color
			if (this.Context.User.IsInRole("6.1") || this.Context.User.IsInRole("6.2"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.RightIcon="arrow_white.gif";
				newItem.Label = "Fase de Color"; 
				newItem.ID = "i6.0";
			}

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_SubRepAditivos";

				// 6.1 Reporte de Color - Consumos por secuencia
				if (this.Context.User.IsInRole("6.1"))
				{
					newItem = newGroup.Items.Add(); 
					newItem.LeftIconWidth=12;
					newItem.LeftIcon="grayDots.gif";
					newItem.LeftIconOver="orangeDots.gif";
					newItem.Label = "Consumos por Secuencia"; 
					newItem.ID = "i6.1";
					//newItem.URL=modulePath+"Reports/Report.aspx?Title=Color";
					newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Color";
				}

				// 6.2 Reporte de Color - Consumos globales
				if (this.Context.User.IsInRole("6.2"))
				{
					newItem = newGroup.Items.Add(); 
					newItem.LeftIconWidth=12;
					newItem.LeftIcon="grayDots.gif";
					newItem.LeftIconOver="orangeDots.gif";
					newItem.Label = "Consumos globales"; 
					newItem.ID = "i6.2";
					//newItem.URL=modulePath+"Reports/Report.aspx?Title=Consumo de Color";
					newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Consumo de Color";
				}

			newGroup = initialMenu.Groups["g_Reportes"];

			// 6.2 Reportes Fase de Aditivos
			if (this.Context.User.IsInRole("6.3") || this.Context.User.IsInRole("6.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.RightIcon="arrow_white.gif";
				newItem.Label = "Fase de Aditivos"; 
				newItem.ID = "6.0.1";
			}

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_SubRepColor";

			// 6.3 Reporte de Aditivos - Consumos por secuencia
			if (this.Context.User.IsInRole("6.3") )
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Consumos por secuencia"; 
				newItem.ID = "i6.3";
				//newItem.URL=modulePath+"Reports/Report.aspx?Title=Aditivos";
				newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Aditivos";
			}

			// 6.4 Reporte de Color - Consumos globales
			if (this.Context.User.IsInRole("6.4"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Consumos globales"; 
				newItem.ID = "i6.4";
				//newItem.URL=modulePath+"Reports/Report.aspx?Title=Consumo de Aditivos";
				newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Consumo de Aditivos";
			}

			newGroup = initialMenu.Groups["g_Reportes"];

			// 6.5 Reporte de Producción
			if (this.Context.User.IsInRole("6.5"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de Producción"; 
				newItem.ID = "i6.5";
				//newItem.URL=modulePath+"Reports/ProduccionRpt.aspx";
				newItem.URL="/SicalNet/Forms/Reports/ProduccionRpt.aspx";
			}

			// 6.17 Reporte de Utec
			if (this.Context.User.IsInRole("6.17"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de UTEC"; 
				newItem.ID = "i6.17";
				//newItem.URL=modulePath+"Reports/ProductionRptSAP.aspx";
				newItem.URL="/SicalNet/Forms/Reports/ProductionRptSAP.aspx";
			}

			// 6.6 Reporte de Rastreabilidad
			if (this.Context.User.IsInRole("6.6"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de Rastreabilidad"; 
				newItem.ID = "i6.6";
				//newItem.URL=modulePath+"Reports/RastreabilidadRpt.aspx";
				newItem.URL="/SicalNet/Forms/Reports/RastreabilidadRpt.aspx";
			}
			
			// 6.7 Reporte de consult Mezclas  UC 145
			if (this.Context.User.IsInRole("6.7"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de Consulta de Mezclas"; 
				newItem.ID = "i6.7";
				//newItem.URL=modulePath+"Reports/Report.aspx?Title=Mezclas";
				newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Mezclas";
			}
			// 6.8 Reporte de Consult Consumption Mezclas
			if (this.Context.User.IsInRole("6.8"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de Consumo de Mezclas"; 
				newItem.ID = "i6.9";
				// newItem.URL=modulePath+"Reports/Report.aspx?Title=Consumo de Mezclas";				
				newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Consumo de Mezclas";
			}

			// 6.9 Reporte de Consult Reaccion
			if (this.Context.User.IsInRole("6.9"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Reacción"; 
			newItem.ID = "i6.8";
			//newItem.URL=modulePath+"Reports/Report.aspx?Title=Reacción";
			newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Reacción";
			}
			

			// 6.10 Reporte de Consult Filling Phase   UC 147
			if (this.Context.User.IsInRole("6.10"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Llenado"; 
			newItem.ID = "i6.10";			
			//newItem.URL=modulePath+"Reports/Report.aspx?Title=Llenado";
			newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Llenado";
			}
			
			// 6.11 Reporte de Consult Cured Phase   UC 148
			if (this.Context.User.IsInRole("6.11"))
			{ 
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Curado"; 
			newItem.ID = "i6.11";
			// newItem.URL=modulePath+"Reports/ConsultCuradoReport.aspx?Title=Curado";
			newItem.URL="/SicalNet/Forms/Reports/ConsultCuradoReport.aspx?Title=Curado";
			}
			
			// 6.12 Reporte de Consult PostCured Phase   UC 149
			if (this.Context.User.IsInRole("6.12"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de PosCurado"; 
			newItem.ID = "i6.12";			
			newItem.URL="/SicalNet/Forms/Reports/ConsultCuradoReport.aspx?Title=PostCurado";	
			}

			// 6.13 Reporte de Consult Preseparacion Phase   UC 150
			if (this.Context.User.IsInRole("6.13"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Preseparación"; 
			newItem.ID = "i6.13";
			newItem.URL="/SicalNet/Forms/Reports/ConsultCuradoReport.aspx?Title=Preseparación";
			}



			// 6.14 Reporte de Consult separacion Phase   UC 151
			if (this.Context.User.IsInRole("6.14"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Separación"; 
			newItem.ID = "i6.14";
			//newItem.URL=modulePath+"Reports/Report.aspx?Title=Separación";
			newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Separación";	
			}
			
			// 6.15 Reporte de Consult Inspection Phase   UC 152
			if (this.Context.User.IsInRole("6.15"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Inspección"; 
			newItem.ID = "i6.15";
			//newItem.URL=modulePath+"Reports/Report.aspx?Title=Inspección";
			newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Inspección";		
			}


			// 6.16 Reporte de Variaciones de pesados UC 153
			if (this.Context.User.IsInRole("6.16"))
			{
			newItem = newGroup.Items.Add(); 
			newItem.LeftIconWidth=12;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.Label = "Reporte de Variaciones de peso"; 
			newItem.ID = "i6.16";
			// newItem.URL=modulePath+"Reports/Produccion/VariationofWeight.aspx";
			newItem.URL="/SicalNet/Forms/Reports/Produccion/VariationofWeight.aspx";	
			}
			
			// Reporte de material PVC por Programaproduccion
			if (this.Context.User.IsInRole("6.18"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte de Consumo PVC"; 
				newItem.ID = "i6.18";
				//newItem.URL=modulePath+"Reports/Report.aspx?Title=Materiales PVC";		
				newItem.URL="/SicalNet/Forms/Reports/Report.aspx?Title=Materiales PVC";					
			}

			// Reporte de materiales
			if (this.Context.User.IsInRole("6.19"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Reporte Materiales"; 
				newItem.ID = "i6.19";				
				newItem.URL="/SicalNet/Forms/Reports/top.aspx";	
			}
		}


		private void CreateHelpMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;

			//0.0 Ayuda
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Ayuda";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.LeftIconWidth=12;
			newItem.ChildExpandedLeftIcon="grayDots.gif";			
			newItem.URL="/SicalNet/Forms/SICALNet.chm";	
		}

		private void CreateExitMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;

			//0.0 Salir
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Salir"; // + User.Identity.Name;
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.LeftIconWidth=12;
			newItem.ChildExpandedLeftIcon="grayDots.gif";			
			newItem.URL="/SicalNet/LogOut.aspx";
			newItem.URLTarget="_parent";
		}


		private void CreateFormulacionMenu()
		{

			CYBERAKT.WebControls.Navigation.MenuItem newItem;
			CYBERAKT.WebControls.Navigation.MenuGroup newGroup;

			//9.0 Formulaciòn 
			newItem =  initialMenu.TopGroup.Items.Add();
			newItem.Label = "Formulación";
			newItem.LeftIcon="grayDots.gif";
			newItem.LeftIconOver="orangeDots.gif";
			newItem.ChildExpandedLeftIcon="grayDots.gif";

			newGroup = newItem.AddSubGroup(); 
			newGroup.ID = "g_Formulacion";

			// 9.1 Folios Color
			if (this.Context.User.IsInRole("9.1"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Folios Color"; 
				newItem.ID = "i9.1";
				//newItem.URL=modulePath+"Structures/FoliosColor.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FoliosColor.aspx";	
			}

			// 9.2 Folios Aditivos
			if (this.Context.User.IsInRole("9.2"))
			{
				newItem = newGroup.Items.Add(); 
				newItem.LeftIconWidth=12;
				newItem.LeftIcon="grayDots.gif";
				newItem.LeftIconOver="orangeDots.gif";
				newItem.Label = "Folios Aditivos"; 
				newItem.ID = "i9.2";
				//newItem.URL=modulePath+"Structures/FoliosAditivos.aspx";
				newItem.URL="/SicalNet/Forms/Structures/FoliosAditivos.aspx";	
			}

			
		}


		private string getModulePath()
		{
			string obtainedPath=string.Empty;
			string moduleName =  this.Page.TemplateSourceDirectory.ToLower();

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			if	   (String.Compare(moduleName,"/sicalnet/forms")		==0 ||
					String.Compare(moduleName,"/userinterface/forms")	==0)
			{
					obtainedPath=string.Empty;
			}
			else if(String.Compare(moduleName,"/sicalnet/forms/production/workorder/inspectionphase")		  ==0 ||
					String.Compare(moduleName,"/sicalnet/forms/production/workorder/partidascolor")			  ==0 ||
					String.Compare(moduleName,"/sicalnet/forms/production/workorder/partidasenviopt")		  ==0 ||
					String.Compare(moduleName,"/sicalnet/forms/production/workorder/partidaspostcurado")	  ==0 ||
					String.Compare(moduleName,"/sicalnet/forms/production/workorder/partidasrecepcionpt")	  ==0 ||
					String.Compare(moduleName,"/sicalnet/forms/production/workorder/interfacesap")			  ==0 ||
					String.Compare(moduleName,"/userinterface/forms/production/workorder/inspectionphase")	  ==0 ||
					String.Compare(moduleName,"/userinterface/forms/production/workorder/partidascolor")	  ==0 ||
					String.Compare(moduleName,"/userinterface/forms/production/workorder/partidasenviopt")	  ==0 ||
					String.Compare(moduleName,"/userinterface/forms/production/workorder/partidaspostcurado") ==0 ||
					String.Compare(moduleName,"/userinterface/forms/production/workorder/partidasrecepcionpt")==0 ||
					String.Compare(moduleName,"/userinterface/forms/production/workorder/interfacesap")		  ==0)
			{
					obtainedPath="../../../";
			}
			else
			{
					obtainedPath="../";
			}				
				//			switch (moduleName)
				//			{
				//				case "/sicalnet/forms":
				//					obtainedPath=string.Empty;
				//					break;
				//				case "/sicalnet/forms/production/workorder/inspectionphase":
				//					obtainedPath="../../../";
				//					break;
				//				case "/sicalnet/forms/production/workorder/partidascolor":
				//					obtainedPath="../../../";
				//					break;
				//				case "/sicalnet/forms/production/workorder/partidasenviopt":
				//					obtainedPath="../../../";
				//					break;
				//				case "/sicalnet/forms/production/workorder/partidaspostcurado":
				//					obtainedPath="../../../";
				//					break;
				//				case "/sicalnet/forms/production/workorder/partidasrecepcionpt":
				//					obtainedPath="../../../";
				//					break;
				//				case "/sicalnet/forms/production/workorder/interfacesap":
				//					obtainedPath="../../../";
				//					break;
				//				case "/userinterface/forms":
				//					obtainedPath=string.Empty;
				//					break;
				//				case "/userinterface/forms/production/workorder/inspectionphase":
				//					obtainedPath="../../../";
				//					break;
				//				case "/userinterface/forms/production/workorder/partidascolor":
				//					obtainedPath="../../../";
				//					break;
				//				case "/userinterface/forms/production/workorder/partidasenviopt":
				//					obtainedPath="../../../";
				//					break;
				//				case "/userinterface/forms/production/workorder/partidaspostcurado":
				//					obtainedPath="../../../";
				//					break;
				//				case "/userinterface/forms/production/workorder/partidasrecepcionpt":
				//					obtainedPath="../../../";
				//					break;
				//				case "/userinterface/forms/production/workorder/interfacesap":
				//					obtainedPath="../../../";
				//					break;
				//				default:
				//					obtainedPath="../";
				//					break;
				//			}
				/*** fin de modificación ***/
					
				return obtainedPath;
		}

	}
}
