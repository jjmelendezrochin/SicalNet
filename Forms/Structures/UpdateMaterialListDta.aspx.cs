using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SICALNet.BusinessEntities;
using SICALNet.Utilities;
using System.IO;
using OWC10;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for UpdateMaterialList.
	/// </summary>
	public class UpdateMaterialListDta : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.DataGrid dgdMaterial;
		protected System.Web.UI.WebControls.Button btnActualizar;
		protected System.Web.UI.WebControls.Button btnInterface;
		protected System.Web.UI.WebControls.Button btnCSV;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.HtmlControls.HtmlTable tableMaterials;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdResults;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RadioButtonList rdoseleccion;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label lblFamilia;
		protected System.Web.UI.WebControls.DropDownList cbofamilia;
		protected System.Web.UI.WebControls.CompareValidator cvfamilia;
		protected System.Web.UI.WebControls.Label lblsel;
		protected System.Web.UI.WebControls.TextBox txtHidden;
		protected System.Web.UI.WebControls.LinkButton linkbitacora;
		protected System.Web.UI.WebControls.ImageButton cmdFindMaterialN;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCodigoSap;
		protected System.Web.UI.WebControls.Label lblidPlanta;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.Button btnclean;
		protected System.Web.UI.WebControls.Label lblresultexp;
		protected System.Web.UI.WebControls.Label lblColor;
		protected System.Web.UI.WebControls.DropDownList cbocolor;
		protected System.Web.UI.WebControls.CompareValidator cvcolor;
		protected System.Web.UI.WebControls.Label lblTamanio;
		protected System.Web.UI.WebControls.DropDownList cbotamanio;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected System.Web.UI.WebControls.DropDownList cboespesor;
		protected System.Web.UI.WebControls.CompareValidator cvespesor;
		protected System.Web.UI.WebControls.CompareValidator cvtamanio;
	
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				btnActualizar.Attributes.Add("onClick","showWaitControls()");
				btnInterface.Attributes.Add("onClick","showWaitControls()");
				btnCSV.Attributes.Add("onClick","showWaitControls()");
				LoadPlantaInfo();
				filldropdownlistfamilias();				
				
			}

			if(txtHidden.Text.Trim()!=string.Empty)
			{
				AddMaterial(txtHidden.Text);
			}
			
			
		}

		

		private void LoadPlantaInfo()
		{
			SICALNet.BusinessLogicLayer.Planta plantBLL = new SICALNet.BusinessLogicLayer.Planta();
			cboPlanta.DataSource=plantBLL.SelectPlanta();
			cboPlanta.DataTextField="Description";
			cboPlanta.DataValueField="IdPlanta";
			cboPlanta.DataBind();
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.linkbitacora.Click += new System.EventHandler(this.linkbitacora_Click);
			this.rdoseleccion.SelectedIndexChanged += new System.EventHandler(this.rdoseleccion_SelectedIndexChanged);
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.cmdFindMaterialN.Click += new System.Web.UI.ImageClickEventHandler(this.cmdFindMaterialN_Click);
			this.cbofamilia.SelectedIndexChanged += new System.EventHandler(this.cbofamilia_SelectedIndexChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.btnclean.Click += new System.EventHandler(this.btnclean_Click);
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			this.btnInterface.Click += new System.EventHandler(this.btnInterface_Click);
			this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
			this.dgdMaterial.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdMaterial_DeleteCommand);
			this.dgdMaterial.SelectedIndexChanged += new System.EventHandler(this.dgdMaterial_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
            string theCodigoSAP=txtCodigoSAP.Text.Trim();
			int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 		
			
			if (rdoseleccion.SelectedItem.Value == "1")
			{   //por material
				if (theCodigoSAP!=string.Empty)
				{
					//MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
					MaterialInfo mInfo= new MaterialInfo(theCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
					if (!Material.isExistMaterial(mInfo))
					{
						txtDescripcion.Text=string.Empty;
						prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
						return;
					}
					else
					{
						AddMaterial(theCodigoSAP);
						txtDescripcion.Text=string.Empty;
						txtCodigoSAP.Text=string.Empty;
					}
				}
				else
				{
					prcErrorDisplay(null,string.Empty,"NoError");			
				}
			}
			if (rdoseleccion.SelectedItem.Value == "2")
			{	// por familia
				if (cbofamilia.SelectedIndex >0 )
				{
					if (cbofamilia.SelectedItem.Value == "all")
					{
						// todas las familias
						for (int u = 2;u<cbofamilia.Items.Count;u++)
						{
							InsertMaterialsOfFamily(System.Convert.ToInt32(cbofamilia.Items[u].Value), "", 0, ""); 
						}
					}
					else	// por familia
					InsertMaterialsOfFamily(System.Convert.ToInt32(cbofamilia.SelectedItem.Value), "", 0, ""); 
				}				
			}			
			if (rdoseleccion.SelectedItem.Value == "3")
			{	// por color
				if (cbocolor.SelectedIndex >0 )
				{
					if (cbocolor.SelectedItem.Value == "all")
					{
						// todos los colores
						for (int u = 2;u<cbocolor.Items.Count;u++)
						{
							InsertMaterialsOfFamily(0,this.cbocolor.Items[u].Value,0,""); 
						}
					}
					else	// por color
						InsertMaterialsOfFamily(0,this.cbocolor.SelectedItem.Value,0,""); 
				}				
			}
			if (rdoseleccion.SelectedItem.Value == "4")
			{	// por tamaño
				if (cbotamanio.SelectedIndex >0 )
				{
					if (cbotamanio.SelectedItem.Value == "all")
					{
						// todos los colores
						for (int u = 2;u<cbotamanio.Items.Count;u++)
						{
							InsertMaterialsOfFamily(0,"",int.Parse(this.cbotamanio.Items[u].Value),""); 
						}
					}
					else	// por color
						InsertMaterialsOfFamily(0,"",int.Parse(this.cbotamanio.SelectedItem.Value),""); 
				}				
			}
			if (rdoseleccion.SelectedItem.Value == "5")
			{	// por espesor
				if (cboespesor.SelectedIndex >0 )
				{
					if (cboespesor.SelectedItem.Value == "all")
					{
						// todos los colores
						for (int u = 2;u<cboespesor.Items.Count;u++)
						{
							InsertMaterialsOfFamily(0,"",0,this.cboespesor.Items[u].Value); 
						}
					}
					else	// por color
						InsertMaterialsOfFamily(0,"",0,this.cboespesor.SelectedItem.Value); 
				}				
			}
		}

		private void cmdFindMaterial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.RegisterStartupScript("ClientScript","<script language=JavaScript>window.open('FindMaterialPP.aspx?FormName=UpdateMaterialList&CtrlName=txtHidden&idPlanta=" +  this.cboPlanta.SelectedItem.Value   + "','FindMaterialPopup','width=600,height=400,top=100,left=100,toolbars=no,scrollbars=yes,status=yes,resizable=no');</script>");		
		}


		public string GetplantName(int idPlanta)
		{
			PlantaInfo myPlantaInfo = new PlantaInfo(System.Convert.ToInt32(cboPlanta.SelectedItem.Value),string.Empty,string.Empty,0);
 
			SICALNet.BusinessLogicLayer.Planta plantaBL= new SICALNet.BusinessLogicLayer.Planta();
			// to Call the Select method
			myPlantaInfo = plantaBL.Load(myPlantaInfo);

			return myPlantaInfo.Description; 

			 
		}
		
		
		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
			int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
			if (theCodigoSAP!=string.Empty)
			{
				
				//MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				MaterialInfo mInfo= new MaterialInfo(theCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcion.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{					
					//MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
					MaterialInfo material= new MaterialInfo(theCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
					SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
					material=materialBLL.SelectMaterial(material);
					txtDescripcion.Text=material.Descripcion;

					prcErrorDisplay(null,string.Empty,"NoError");
				}
			}
			else
			{
				prcErrorDisplay(null,string.Empty,"NoError");			
			}		
		}

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ Message +"')"+ "<" + "/script>");
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else if (ErrStatus=="Warning")
			{
				//to display the warning msg
				lblErrorMsg.Text=Message;
				Page.RegisterStartupScript("alert", string.Format("<script language='JavaScript'>alert('{0}')</script>",Message));
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="Success")
			{
				//to display the success msg
				lblErrorMsg.Text=Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}

			return;
		}

		private string getOtherBasePlantas(string currentCodigoSAP,int IdPlanta)
		{
			//se inicializa el usuario ficticio para establecer la planta y de ahi las lineas
			string lineas = string.Empty;
			UsuarioInfo myUsuarioInfoLineas = new UsuarioInfo(string.Empty,string.Empty,string.Empty,0,IdPlanta,string.Empty,
				0,string.Empty,0,string.Empty,false);

			SICALNet.BusinessLogicLayer.LineaProduccion Linea= new SICALNet.BusinessLogicLayer.LineaProduccion();
			
			IList LineaRs= (IList)Linea.SelectLinePdt(myUsuarioInfoLineas);

			for(int x=0;x<LineaRs.Count;x++)
			{
				if (x>0)
					lineas = lineas + ";";
				LineaProduccionInfo myLineaProduccionInfo = (LineaProduccionInfo) LineaRs[x];
				
				lineas = lineas + myLineaProduccionInfo.IdLinea;
			}
			
			return lineas;
		}

		
		public void AddMaterialSinLinea(string CodigoSAP, string Linea)
		{
			try
			{
				ArrayList gridCurrentItems = new ArrayList();
				string currentCodigoSAP;
				string currentlinea;
				int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
				string idLineasList = getOtherBasePlantas(CodigoSAP,idPlanta);
				idLineasList = idLineasList.Replace(Linea,"0");

				if (dgdMaterial.Items.Count>0)
				{
					for (int i=0; i<dgdMaterial.Items.Count; i++)
					{
						//obtain CodigoSAP from interface
						currentCodigoSAP=((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text;	
						currentlinea=((Label)dgdMaterial.Items[i].FindControl("lblLineaN")).Text;	

						if((currentCodigoSAP != CodigoSAP) || (currentlinea != Linea))
						{
							//Create entity to load data
							MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
							//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);
							//Load data from DB
							SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
							//Add item to the grid's datasource
							BELMaterial = BLLMaterial.SelectMaterial(BELMaterial);
						
							MaterialInfo BELMaterialPrevious = new MaterialInfo(BELMaterial.CodigoSAP,BELMaterial.Descripcion,BELMaterial.IdEstadoMaterial,BELMaterial.IdColor,BELMaterial.IdMedida,BELMaterial.IdEspesor,BELMaterial.IdMercado,BELMaterial.IdPresentacion,BELMaterial.IdAcabado,BELMaterial.IdEstadoProducto,BELMaterial.IdFamiliaProducto,System.Convert.ToInt32(currentlinea),BELMaterial.VersionAditivos,BELMaterial.EstadoMaterialDesc,BELMaterial.MedidaDesc,BELMaterial.EspesorDesc,BELMaterial.MercadoDesc,BELMaterial.PresentacionDesc,BELMaterial.AcabadoDesc,BELMaterial.EstadoProductoDesc,BELMaterial.FamiliaProductoDesc,getlineadescripcion(currentlinea),BELMaterial.IdPlanta,BELMaterial.Segundas);										

							gridCurrentItems.Add(BELMaterialPrevious);
						}
						
					}
				}

				string[] Materiales = CodigoSAP.Split(',');

				for (int i=0;i<Materiales.Length;i++)
				{
					//obtain the CodigoSAP 
					currentCodigoSAP=Materiales[i].ToString();	
				
					//If this element has not been added to the list
					if (!PreviouslySelected(currentCodigoSAP))
					{
						//Create entity to load data
						MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);

						//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);

						//Load data from DB
						SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
						//Add item to the grid's datasource
						BELMaterial = BLLMaterial.SelectMaterial(BELMaterial);
						
						gridCurrentItems.Add(BELMaterial);

						// revisamos las lienas que no son base del material ya que solo se configura 1 a nivel material
						// pero se revisa las otras lineas
						
						string[] LineasBase = idLineasList.Split(';');

						for (int u=0;u<LineasBase.Length;u++)
						{
							if ((System.Convert.ToInt32(LineasBase[u]) != BELMaterial.IdLineaBase))
							{
								//validamos si tiene aditivos
								try
								{
									string _idColor= BELMaterial.IdColor; 
									string _idEspesor= BELMaterial.IdEspesor;
									int _idLinea= System.Convert.ToInt32(LineasBase[u]);
									int _idPlanta= BELMaterial.IdPlanta;

									//to get the instance form BusinessLogicLayer
									SICALNet.BusinessEntities.FormAditivosInfo BELFormAditivos= new SICALNet.BusinessEntities.FormAditivosInfo(_idColor,_idEspesor,_idLinea,_idPlanta);
									//to get the instance form BusinessLogicLayer
									SICALNet.BusinessLogicLayer.FormAditivos BLLFormAditivos= new SICALNet.BusinessLogicLayer.FormAditivos();
									// to Call the Select method
									IList RsGrdFormAditivos = (IList)BLLFormAditivos.SelectFormAditivos(BELFormAditivos);
									//to assign the result set into datagrid
									
									if (RsGrdFormAditivos.Count > 0)
									{
										// agregamos el material al grid con la linea correspondiente
										if(rdoseleccion.SelectedValue == "2")
											CodigoSAP = currentCodigoSAP;

										MaterialInfo BELMaterialExtra = new MaterialInfo(CodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);										
										BELMaterialExtra = BLLMaterial.SelectMaterial(BELMaterialExtra);																			
										

										MaterialInfo BELMaterialExtraFinal = new MaterialInfo(BELMaterialExtra.CodigoSAP,BELMaterialExtra.Descripcion,BELMaterialExtra.IdEstadoMaterial,BELMaterialExtra.IdColor,BELMaterialExtra.IdMedida,BELMaterialExtra.IdEspesor,BELMaterialExtra.IdMercado,BELMaterialExtra.IdPresentacion,BELMaterialExtra.IdAcabado,BELMaterialExtra.IdEstadoProducto,BELMaterialExtra.IdFamiliaProducto,System.Convert.ToInt32(LineasBase[u]),BELMaterialExtra.VersionAditivos,BELMaterialExtra.EstadoMaterialDesc,BELMaterialExtra.MedidaDesc,BELMaterialExtra.EspesorDesc,BELMaterialExtra.MercadoDesc,BELMaterialExtra.PresentacionDesc,BELMaterialExtra.AcabadoDesc,BELMaterialExtra.EstadoProductoDesc,BELMaterialExtra.FamiliaProductoDesc,getlineadescripcion(LineasBase[u]),BELMaterialExtra.IdPlanta,BELMaterialExtra.Segundas);										
										
										gridCurrentItems.Add(BELMaterialExtraFinal);
									}
								}
								catch
								{
									throw;
								}
								
							}
						}
					}
				}

				dgdMaterial.DataSource=gridCurrentItems;
				dgdMaterial.DataBind();
			}
			catch
			{
				throw;
			}
		}
		
		public void AddMaterial(string CodigoSAP)
		{
			try
			{
				ArrayList gridCurrentItems = new ArrayList();
				string currentCodigoSAP;
				string currentlinea;
				int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
				string idLineasList = getOtherBasePlantas(CodigoSAP,idPlanta);

				if (dgdMaterial.Items.Count>0)
				{
					for (int i=0; i<dgdMaterial.Items.Count; i++)
					{
						//obtain CodigoSAP from interface
						currentCodigoSAP=((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text;	
						currentlinea=((Label)dgdMaterial.Items[i].FindControl("lblLineaN")).Text;	

						//Create entity to load data
						MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
						//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);
						//Load data from DB
						SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
						//Add item to the grid's datasource
						BELMaterial = BLLMaterial.SelectMaterial(BELMaterial);
						
						MaterialInfo BELMaterialPrevious = new MaterialInfo(BELMaterial.CodigoSAP,BELMaterial.Descripcion,BELMaterial.IdEstadoMaterial,BELMaterial.IdColor,BELMaterial.IdMedida,BELMaterial.IdEspesor,BELMaterial.IdMercado,BELMaterial.IdPresentacion,BELMaterial.IdAcabado,BELMaterial.IdEstadoProducto,BELMaterial.IdFamiliaProducto,System.Convert.ToInt32(currentlinea),BELMaterial.VersionAditivos,BELMaterial.EstadoMaterialDesc,BELMaterial.MedidaDesc,BELMaterial.EspesorDesc,BELMaterial.MercadoDesc,BELMaterial.PresentacionDesc,BELMaterial.AcabadoDesc,BELMaterial.EstadoProductoDesc,BELMaterial.FamiliaProductoDesc,getlineadescripcion(currentlinea),BELMaterial.IdPlanta,BELMaterial.Segundas);										

						gridCurrentItems.Add(BELMaterialPrevious);
						
						
					}
				}

				string[] Materiales = CodigoSAP.Split(',');

				for (int i=0;i<Materiales.Length;i++)
				{
					//obtain the CodigoSAP 
					currentCodigoSAP=Materiales[i].ToString();	
				
					//If this element has not been added to the list
					if (!PreviouslySelected(currentCodigoSAP))
					{
						//Create entity to load data
						MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);

						//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);

						//Load data from DB
						SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
						//Add item to the grid's datasource
						BELMaterial = BLLMaterial.SelectMaterial(BELMaterial);
						
						gridCurrentItems.Add(BELMaterial);

						// revisamos las lienas que no son base del material ya que solo se configura 1 a nivel material
						// pero se revisa las otras lineas
						
						string[] LineasBase = idLineasList.Split(';');

						for (int u=0;u<LineasBase.Length;u++)
						{
							if (System.Convert.ToInt32(LineasBase[u]) != BELMaterial.IdLineaBase)
							{
								//validamos si tiene aditivos
								try
								{
									string _idColor= BELMaterial.IdColor; 
									string _idEspesor= BELMaterial.IdEspesor;
									int _idLinea= System.Convert.ToInt32(LineasBase[u]);
									int _idPlanta= BELMaterial.IdPlanta;

									//to get the instance form BusinessLogicLayer
									SICALNet.BusinessEntities.FormAditivosInfo BELFormAditivos= new SICALNet.BusinessEntities.FormAditivosInfo(_idColor,_idEspesor,_idLinea,_idPlanta);
									//to get the instance form BusinessLogicLayer
									SICALNet.BusinessLogicLayer.FormAditivos BLLFormAditivos= new SICALNet.BusinessLogicLayer.FormAditivos();
									// to Call the Select method
									IList RsGrdFormAditivos = (IList)BLLFormAditivos.SelectFormAditivos(BELFormAditivos);
									//to assign the result set into datagrid
									
									if (RsGrdFormAditivos.Count > 0)
									{
										// agregamos el material al grid con la linea correspondiente
										if(rdoseleccion.SelectedValue == "2" || rdoseleccion.SelectedValue == "3" || rdoseleccion.SelectedValue == "4" || rdoseleccion.SelectedValue == "5")
											CodigoSAP = currentCodigoSAP;

										MaterialInfo BELMaterialExtra = new MaterialInfo(CodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);										
										BELMaterialExtra = BLLMaterial.SelectMaterial(BELMaterialExtra);																			
										

										MaterialInfo BELMaterialExtraFinal = new MaterialInfo(BELMaterialExtra.CodigoSAP,BELMaterialExtra.Descripcion,BELMaterialExtra.IdEstadoMaterial,BELMaterialExtra.IdColor,BELMaterialExtra.IdMedida,BELMaterialExtra.IdEspesor,BELMaterialExtra.IdMercado,BELMaterialExtra.IdPresentacion,BELMaterialExtra.IdAcabado,BELMaterialExtra.IdEstadoProducto,BELMaterialExtra.IdFamiliaProducto,System.Convert.ToInt32(LineasBase[u]),BELMaterialExtra.VersionAditivos,BELMaterialExtra.EstadoMaterialDesc,BELMaterialExtra.MedidaDesc,BELMaterialExtra.EspesorDesc,BELMaterialExtra.MercadoDesc,BELMaterialExtra.PresentacionDesc,BELMaterialExtra.AcabadoDesc,BELMaterialExtra.EstadoProductoDesc,BELMaterialExtra.FamiliaProductoDesc,getlineadescripcion(LineasBase[u]),BELMaterialExtra.IdPlanta,BELMaterialExtra.Segundas);										
										
										gridCurrentItems.Add(BELMaterialExtraFinal);
									}
								}
								catch
								{
									throw;
								}
								
							}
						}
					}
				}

				dgdMaterial.DataSource=gridCurrentItems;
				dgdMaterial.DataBind();
				
				dgdResults.DataSource = null;
				dgdResults.DataBind();

				lblresultexp.Visible = dgdResults.Items.Count > 0;

				txtHidden.Text=string.Empty;
			
				tableMaterials.Visible=(dgdMaterial.Items.Count>0);
			}
			catch
			{
				throw;
			}
		}

		private string getlineadescripcion(string linea)
		{
			switch (linea)
			{
				case "1":
					return "Linea I";
				case "2":
					return "Linea II";
				case "3":
					return "Linea III";
				case "4":
					return "Linea IV";
				case "5":
					return "Linea V";
				case "6":
					return "Linea VI";
				default:
					return string.Empty;
			
			}
		}
		
		private bool PreviouslySelected(string currentCodigoSAP)
		{
			for (int i=0;i<dgdMaterial.Items.Count;i++)
			{
				if (currentCodigoSAP==((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text)
					return true;
			}
			return false;
		}

		//		private void cmdSalir_Click(object sender, System.EventArgs e)
		//		{
		//
		//		}

		private void dgdMaterial_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string currentCodigoSAP=((Label)dgdMaterial.Items[e.Item.ItemIndex].FindControl("lblCodigoSAP")).Text;
				string currentLine =((Label)dgdMaterial.Items[e.Item.ItemIndex].FindControl("lblLineaN")).Text;
				AddMaterialSinLinea(currentCodigoSAP,currentLine);
				tableMaterials.Visible=(dgdMaterial.Items.Count>0);
			}
			catch
			{
				throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			cboPlanta.Enabled = true;
			Response.Redirect("..\\NewMenu.aspx");
		}

		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
			try
			{
				ArrayList materiales = new ArrayList();
				// if no rows in the grid then return
				if (dgdMaterial.Items.Count<=0)
					return;
				
				for(int i=0; i<dgdMaterial.Items.Count; i++)
				{
					materiales.Add( ((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text + ";" + ((Label)dgdMaterial.Items[i].FindControl("lblLineaN")).Text);
				}
				SICALNet.BusinessLogicLayer.MaterialsSAP mSAP = new SICALNet.BusinessLogicLayer.MaterialsSAP();
				dgdResults.DataSource=mSAP.UpdateMaterialList(materiales,Convert.ToInt32(cboPlanta.SelectedItem.Value));
				dgdResults.DataBind();
				lblresultexp.Visible = dgdResults.Items.Count > 0;
			}
			catch
			{
				throw;
			}
		}

		private void btnInterface_Click(object sender, System.EventArgs e)
		{
			ArrayList MSList; 
			SICALNet.BusinessLogicLayer.MaterialsSAP mSAP = new SICALNet.BusinessLogicLayer.MaterialsSAP();
			MSList = (ArrayList)mSAP.Load();

			// Export Data To Excel
			SpreadsheetClass xlsheet = new SpreadsheetClass();
			
			// To Write Excel Header
			xlsheet.ActiveSheet.Cells[1,1] = "CodigoSAP";
			xlsheet.ActiveSheet.Cells[1,2] = "UtilizacionLM";
			xlsheet.ActiveSheet.Cells[1,3] = "Denominacion_SAP";
			xlsheet.ActiveSheet.Cells[1,4] = "Alternativa";
			xlsheet.ActiveSheet.Cells[1,5] = "Descripcion";
			xlsheet.ActiveSheet.Cells[1,6] = "DescripcionMaterialLinea";
			xlsheet.ActiveSheet.Cells[1,7] = "CantidadBase";
			xlsheet.ActiveSheet.Cells[1,8] = "UnidadMedida";
			xlsheet.ActiveSheet.Cells[1,9] = "StatusListaMaterials";
			xlsheet.ActiveSheet.Cells[1,10] = "NoPosicion";
			xlsheet.ActiveSheet.Cells[1,11] = "CodigoSAPHijo";
			xlsheet.ActiveSheet.Cells[1,12] = "CantidadHijo";
			xlsheet.ActiveSheet.Cells[1,13] = "UnidadHijo";
			xlsheet.ActiveSheet.Cells[1,14] = "TipoPosicion";
			xlsheet.ActiveSheet.Cells[1,15] = "Seleccion";
			xlsheet.ActiveSheet.Cells[1,16] = "Rechazo";

			int row = 2, col=1;
			for(int i=0; i<MSList.Count; i++)
			{
				MaterialSAPInfo MSInfo = new MaterialSAPInfo();
				MSInfo = (MaterialSAPInfo) MSList[i];
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.CodigoSAP; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.UtilizacionLM; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Denominacion_SAP; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Alternativa; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Descripcion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.DescripcionMaterialLinea; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.CantidadBase; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.UnidadMedida; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.StatusListaMaterials; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.NoPosicion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.CodigoSAPHijo; col++;
				xlsheet.ActiveSheet.Cells[row,col] = Math.Round(MSInfo.CantidadHijo,3); col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.UnidadHijo; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.TipoPosicion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Seleccion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Rechazo; col=1;
				row++;
			}

			xlsheet.ActiveSheet.Columns.AutoFit();

			string xlFileName = System.DateTime.Now.ToString("ddMMMyyyy") +".xls";
			
			string fullFileName = string.Format("{0}\\{1}",Server.MapPath("."),xlFileName);
			// save it off to the filesystem...
			xlsheet.Export(fullFileName,OWC10.SheetExportActionEnum.ssExportActionNone,OWC10.SheetExportFormat.ssExportHTML);
			
			DownloadFile(fullFileName);
			// set content header so browser knows you'r sending Excel workbook...
			//Response.ContentType="application/x-msexcel" ;
			// To Save the file in Client's Machine
			//Response.Redirect(xlFileName);
		}

		private void DownloadFile(string filePath)
		{
			System.IO.FileInfo TargetFile = new System.IO.FileInfo(filePath);
			
			//clear the current output content from the buffer
			Response.Clear();
			//add the header that specifies the default filename for the Download/
			//SaveAs dialog
			Response.AddHeader("Content-Disposition", "attachment; filename=" + TargetFile.Name);
			//add the header that specifies the file size, so that the browser
			//can show the download progress
			Response.AddHeader("Content-Length", TargetFile.Length.ToString());
			// specify that the response is a stream that cannot be read by the client and must be downloaded
			Response.ContentType = "application/octet-stream";
			// send the file stream to the client
			Response.WriteFile(TargetFile.FullName);
			// stop the execution of this page
			Response.End();
		}


		private void writeExportResults(IList myILitsResults)
		{
			string linestr;
			if (myILitsResults.Count > 0)
			{
				// escribimos el archivo de salida de bitacora.


					string LogFileName=@"c:\Temp\BITEXP"+
					DateTime.Now.Year.ToString()+
					DateTime.Now.Month.ToString("00")+
					DateTime.Now.Day.ToString("00")+".txt";	
//					JJMR
//				    string LogFileName=ConfigurationSettings.AppSettings["ExportBitDirectory"]+ @"\BITEXP"+
//					DateTime.Now.Year.ToString()+
//					DateTime.Now.Month.ToString("00")+
//					DateTime.Now.Day.ToString("00")+".txt";		
					StreamWriter sw=new StreamWriter(LogFileName,true);
				
				sw.WriteLine("********************************************************");
				sw.WriteLine("EJECUCIÓN DEL <" + DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year.ToString() + " – " + DateTime.Now.Hour.ToString("00") +":"+DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00") + ">");
				sw.WriteLine("");


				for(int u=0;u<myILitsResults.Count;u++)
				{
					linestr = (string) myILitsResults[u].ToString();
					sw.WriteLine(linestr);
					
				}
				sw.Close();
			}
			else
			{
				linestr = "El proceso no genero salida de resultados de exportación";	
			}
		}
		
		
		private void btnCSV_Click(object sender, System.EventArgs e)
		{
			// actualizamos la lista de materiales
			ArrayList materiales = new ArrayList();

			// if no rows in the grid then return
			if (dgdMaterial.Items.Count<=0)
				return;

			for(int i=0; i<dgdMaterial.Items.Count; i++)
			{
				materiales.Add(((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text + ";" + ((Label)dgdMaterial.Items[i].FindControl("lblLineaN")).Text);
			}

			SICALNet.BusinessLogicLayer.MaterialsSAP mSAPupdate = new SICALNet.BusinessLogicLayer.MaterialsSAP();
			// TODO AQUI SE HACE LA EXPORTACIÓN DE MATERIALES 19/06/2016
			//generamos los materiales a exportar
			IList myILitsResults=mSAPupdate.UpdateMaterialList(materiales,Convert.ToInt32(cboPlanta.SelectedItem.Value));
			//escribimos en la bitacora del día actual lo que arrojo el proceso de actualización.
			writeExportResults(myILitsResults);

			// **************************************************
			// Inserción de datos en la tabla ExportaMaterialesSAP
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Proc_ExportaMaterialesDatasul");
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
			// **************************************************

			Response.Write("<script>alert('Se ha relizado la exportacion de la lista de materiales a la tabla ExportaMateriales DataSul, ya puede realizar la consulta de información en ese sitio');</script>");	
		}
	
		private string GetDataSulCodeForPlant(int IdPlant)
		{	
			switch (IdPlant)
			{
				case 1: // 201 corresponde a la planta de Ocoyocac 
					return "201";
					//break;
				case 2: // el codigo 202 a de San Luis Potossi
					return "202";
					//break;
				default:
					return "";
					//break;
				
			}
		}

		private string IntegerToRoman(int i)
		{
			int [] valor = {1000,900,500,400,100,90,50,40,10,9,5,4,1};

			string[] simbolo = {"M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};

			string r = "";

			int p = 0;

			if ((i >=1) && (i < 4000))
			{
				int x = i;
				while (x>0)
				{
					while (x>=valor[p])
					{
						r += simbolo[p];
						x = x-valor[p];
					}
					p++;
				}
			}	
			return r;
		}

		private void ControlsToMaterialOrFamilia(string tipo)
		{
			
			int iTipo = int.Parse(tipo);

			switch(iTipo)
			{
				case 1:
					// controles de material	
					lblMaterial.Visible = true;
					txtCodigoSAP.Visible = true;
					cmdFindMaterialN.Visible = true;
					txtDescripcion.Visible = true;		
					btnBuscar.Visible = true;
					rfvCodigoSap.Enabled = true;
			
					// controles de familia	
					lblFamilia.Visible = !true;
					cbofamilia.Visible = !true;
					cvfamilia.Visible = !true;

					// controles de color	
					this.lblColor.Visible = !true;
					this.cbocolor.Visible = !true;
					this.cvcolor.Visible = !true;

					// controles de tamaño	
					this.lblTamanio .Visible = !true;
					this.cbotamanio.Visible = !true;
					this.cvtamanio.Visible = !true;

					// controles de espesor	
					this.lblEspesor.Visible = !true;
					this.cboespesor.Visible = !true;
					this.cvespesor.Visible = !true;
					break;
				case 2:
					// controles de material	
					lblMaterial.Visible = !true;
					txtCodigoSAP.Visible = !true;
					cmdFindMaterialN.Visible = !true;
					txtDescripcion.Visible = !true;		
					btnBuscar.Visible = !true;
					rfvCodigoSap.Enabled = true;
			
					// controles de familia	
					lblFamilia.Visible = true;
					cbofamilia.Visible = true;
					cvfamilia.Visible = true;

					// controles de color	
					this.lblColor.Visible = !true;
					this.cbocolor.Visible = !true;
					this.cvcolor.Visible = !true;

					// controles de tamaño	
					this.lblTamanio .Visible = !true;
					this.cbotamanio.Visible = !true;
					this.cvtamanio.Visible = !true;

					// controles de espesor	
					this.lblEspesor.Visible = !true;
					this.cboespesor.Visible = !true;
					this.cvespesor.Visible = !true;
					break;
				case 3:
					// controles de material	
					lblMaterial.Visible = !true;
					txtCodigoSAP.Visible = !true;
					cmdFindMaterialN.Visible = !true;
					txtDescripcion.Visible = !true;		
					btnBuscar.Visible = !true;
					rfvCodigoSap.Enabled = true;
			
					// controles de familia	
					lblFamilia.Visible = !true;
					cbofamilia.Visible = !true;
					cvfamilia.Visible = !true;

					// controles de color	
					this.lblColor.Visible = true;
					this.cbocolor.Visible = true;
					this.cvcolor.Visible = true;

					// controles de tamaño	
					this.lblTamanio .Visible = !true;
					this.cbotamanio.Visible = !true;
					this.cvtamanio.Visible = !true;

					// controles de espesor	
					this.lblEspesor.Visible = !true;
					this.cboespesor.Visible = !true;
					this.cvespesor.Visible = !true;
					break;
				case 4:
					// controles de material	
					lblMaterial.Visible = !true;
					txtCodigoSAP.Visible = !true;
					cmdFindMaterialN.Visible = !true;
					txtDescripcion.Visible = !true;		
					btnBuscar.Visible = !true;
					rfvCodigoSap.Enabled = true;
			
					// controles de familia	
					lblFamilia.Visible = !true;
					cbofamilia.Visible = !true;
					cvfamilia.Visible = !true;

					// controles de color	
					this.lblColor.Visible = !true;
					this.cbocolor.Visible = !true;
					this.cvcolor.Visible = !true;

					// controles de tamaño	
					this.lblTamanio .Visible = true;
					this.cbotamanio.Visible = true;
					this.cvtamanio.Visible = true;

					// controles de espesor	
					this.lblEspesor.Visible = !true;
					this.cboespesor.Visible = !true;
					this.cvespesor.Visible = !true;
					break;
				case 5:
					// controles de material	
					lblMaterial.Visible = !true;
					txtCodigoSAP.Visible = !true;
					cmdFindMaterialN.Visible = !true;
					txtDescripcion.Visible = !true;		
					btnBuscar.Visible = !true;
					rfvCodigoSap.Enabled = true;
			
					// controles de familia	
					lblFamilia.Visible = !true;
					cbofamilia.Visible = !true;
					cvfamilia.Visible = !true;

					// controles de color	
					this.lblColor.Visible = !true;
					this.cbocolor.Visible = !true;
					this.cvcolor.Visible = !true;

					// controles de tamaño	
					this.lblTamanio .Visible = !true;
					this.cbotamanio.Visible = !true;
					this.cvtamanio.Visible = !true;

					// controles de espesor	
					this.lblEspesor.Visible = true;
					this.cboespesor.Visible = true;
					this.cvespesor.Visible = true;
					break;
			}
		}


		private void blockfamily_Materail_Controls()
		{
			// controles de material	
			lblMaterial.Visible = false;
			txtCodigoSAP.Visible = false;
			cmdFindMaterialN.Visible = false;
			txtDescripcion.Visible = false;	

		
			btnBuscar.Visible = false;
			rfvCodigoSap.Enabled = false;
			
			// controles de familia	
			lblFamilia.Visible = false;
			cbofamilia.Visible = false;
			cvfamilia.Visible = false;	
		
		}
		private void filldropdownlistfamilias()
		{
			// llenado de combo de familias
			cbofamilia.Items.Clear();						
			SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
			IList RsEquals=(IList) BLLFampdt.SelectFamiliaProducto();
			cbofamilia.DataSource = RsEquals;
			cbofamilia.DataTextField = "Descripcion";			
			cbofamilia.DataValueField  = "IdFamiliaProductos";
			cbofamilia.DataBind();
			cbofamilia.Items.Insert(0,new ListItem("Seleccione una Familia","-1"));
			cbofamilia.Items.Insert(1,new ListItem("Todas las familias","all"));

			// llenado de combo de colores
			this.cbocolor.Items.Clear();						
			SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
			IList RsColor=(IList) BLLColor.SelectColour();
			cbocolor.DataSource = RsColor;
			cbocolor.DataTextField = "IdColour";			
			cbocolor.DataValueField  = "IdColour";
			cbocolor.DataBind();
			cbocolor.Items.Insert(0,new ListItem("Seleccione una Color","-1"));
			cbocolor.Items.Insert(1,new ListItem("Todos los colores","all"));

			// llenado de combo de tamaño
			this.cbotamanio.Items.Clear();						
			SICALNet.BusinessLogicLayer.Medida BLLMedida=new SICALNet.BusinessLogicLayer.Medida();
			IList RsMedida=(IList) BLLMedida.LoadMedida();
			cbotamanio.DataSource = RsMedida;
			cbotamanio.DataTextField = "Centimetros";			
			cbotamanio.DataValueField  = "idMedida";
			cbotamanio.DataBind();
			cbotamanio.Items.Insert(0,new ListItem("Seleccione una Medida","-1"));
			cbotamanio.Items.Insert(1,new ListItem("Todas las medidas","all"));

			// llenado de combo de espesor
			this.cboespesor.Items.Clear();						
			SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
			IList RsEspesor=(IList) BLLEspesor.LoadEspesor();
			cboespesor.DataSource = RsEspesor;
			cboespesor.DataTextField = "Centimetros";			
			cboespesor.DataValueField  = "IdEspesor";
			cboespesor.DataBind();
			cboespesor.Items.Insert(0,new ListItem("Seleccione una Espesor","-1"));
			cboespesor.Items.Insert(1,new ListItem("Todos los espesores","all"));
		}
		
		

		private void cbofamilia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void InsertMaterialsOfFamily(int IdFamiliaProducto, string Color, int IdMedida, string Espesor)
		{
			// llenamos el grid con los proudctos de la familia
			string sChar=string.Empty;
			string sEqual=string.Empty;
			//string sQry=string.Empty;
			string sIdEqual=string.Empty;

			int IdEstadoMaterial = 0;

			string IdColor;
			if (Color == "")
				IdColor = string.Empty;
			else
				IdColor = Color;	
			string IdEspesor;
			if (Espesor == "")
				IdEspesor = string.Empty;
			else
				IdEspesor = Espesor;

			int IdMercado = 0;
			string IdPresentacion = string.Empty;
			int IdAcabado= 0;
			int IdEstadoProducto = 0;
			int IdLineaBase=0;
			int VersionAditivos=0;

			
			int idPlanta=Convert.ToInt32(cboPlanta.SelectedItem.Value); 
			
			
			MaterialInfo BEMatInfo= new MaterialInfo(string.Empty,string.Empty,IdEstadoMaterial,IdColor,IdMedida,IdEspesor,IdMercado,IdPresentacion,IdAcabado,IdEstadoProducto,IdFamiliaProducto,IdLineaBase,VersionAditivos,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
			//to get the instance for BusinessLogicLayer
			SICALNet.BusinessLogicLayer.Material BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
			// to Call the Select method
			IList RsMaterial= (IList)BLLMaterial.FindMaterial(BEMatInfo);
			// obtenemos la lista de los codigos sap

			System.Text.StringBuilder strCadigoSAP = new System.Text.StringBuilder();

			if (RsMaterial.Count > 0)
			{
				for (int i=0; i < RsMaterial.Count; i++)
				{
				MaterialInfo BEMatInfotemp = (MaterialInfo) RsMaterial[i];
	
				strCadigoSAP.AppendFormat("{0},",BEMatInfotemp.CodigoSAP.ToString());
					
				}

				strCadigoSAP=strCadigoSAP.Remove(strCadigoSAP.Length-1,1);

				// procesamos la lista al grid de exportación
				AddMaterial(strCadigoSAP.ToString());
			}
		}

		private void cmdFindMaterialN_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if ((e.X > 0) && (e.Y > 0))
                Page.RegisterStartupScript("ClientScript","<script language=JavaScript>window.open('FindMaterialPP.aspx?FormName=UpdateMaterialList&CtrlName=txtHidden&idPlanta=" +  this.cboPlanta.SelectedItem.Value   + "','FindMaterialPopup','width=600,height=400,top=100,left=100,toolbars=no,scrollbars=yes,status=yes,resizable=no');</script>");		
		}

		private void btnclean_Click(object sender, System.EventArgs e)
		{
			rdoseleccion.SelectedIndex = -1;
			cboPlanta.Enabled = true;
			dgdMaterial.DataSource = null;
			dgdMaterial.DataBind();
			dgdResults.DataSource = null;
			dgdResults.DataBind();
			blockfamily_Materail_Controls();			
			cmdAdd.Visible = false;
			btnCancelar.Visible = false;
			tableMaterials.Visible=(false);
			lblresultexp.Visible = false;
		}

		private void Reset_Material_Family_Controls()
		{
			// material
			txtCodigoSAP.Text = "";
			txtCodigoSAP.Text = "";
			// Familia
			cbofamilia.SelectedIndex = 0; 
		}

		private void linkbitacora_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Bitacora.aspx");
		}

		private void dgdMaterial_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void rdoseleccion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// congelamos el combo de planta
			cboPlanta.Enabled = false;
			cmdAdd.Visible = true;
			btnCancelar.Visible = true;
			Reset_Material_Family_Controls();
			ControlsToMaterialOrFamilia(rdoseleccion.SelectedItem.Value);  
		}
	}
}
