using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//References to SICALNet specific libraries
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for Material.
	/// </summary>
	public class Material : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.DropDownList cboEstPdt;
		protected System.Web.UI.WebControls.DropDownList cboEstMaterial;
		protected System.Web.UI.WebControls.DropDownList cboFamPdt;
		protected System.Web.UI.WebControls.DropDownList cboColor;
		protected System.Web.UI.WebControls.DropDownList cboMedida;
		protected System.Web.UI.WebControls.DropDownList cboEspesor;
		protected System.Web.UI.WebControls.DropDownList cboMercado;
		protected System.Web.UI.WebControls.DropDownList cboPresentation;
		protected System.Web.UI.WebControls.DropDownList cboAcabado;
		protected System.Web.UI.WebControls.Label lblAcabado;
		protected System.Web.UI.WebControls.ImageButton imgFind;
		protected System.Web.UI.WebControls.Label lblCodigo;
		protected System.Web.UI.WebControls.Panel pnlCodigo;
		protected System.Web.UI.WebControls.Panel pnlNew;
		protected System.Web.UI.WebControls.Panel pnlFinished;
		protected System.Web.UI.WebControls.Label lblDesc;
		protected System.Web.UI.WebControls.ImageButton imgEdit;
		protected System.Web.UI.WebControls.ImageButton imgDel;
		protected System.Web.UI.WebControls.ImageButton imgCancel;
		protected System.Web.UI.WebControls.Button btnNew;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Panel pnlOperation;
		protected System.Web.UI.WebControls.ImageButton imgSave;
		protected System.Web.UI.WebControls.TextBox cboCodigo;
		protected System.Web.UI.WebControls.Label lblErr;	
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cboLineaBase;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtVersionAd;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.CheckBox chkSegundas;
		protected System.Web.UI.WebControls.Panel pnlPlanta;
		protected System.Web.UI.WebControls.Label lblTipoEtiqueta;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.CheckBox chkMezclado;
		protected System.Web.UI.WebControls.CheckBox chkEtiquetaColor;
		//ErrorHandling ExpHand=new ErrorHandling();
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//to enable or disable the image button or panel
				prcEnableDisable("0000100000");
				prcEntityToCombo();
			}
		}

		private void prcEntityToCombo()
		{
			try
			{
				// to fill the planta 
				SICALNet.BusinessLogicLayer.Planta  BRPlanta = new SICALNet.BusinessLogicLayer.Planta();
				IList tipoRs2= (IList)BRPlanta.SelectPlanta();						
				cboPlanta.DataSource= tipoRs2;
				cboPlanta.DataValueField="IdPlanta";
				cboPlanta.DataTextField="Description";
				cboPlanta.DataBind();	
				
				//to fill the estado producto into the cboestpdt control
				SICALNet.BusinessLogicLayer.EstadoProducto BLLEstPdt=new SICALNet.BusinessLogicLayer.EstadoProducto();
				IList RsEstPdt=(IList) BLLEstPdt.SelectEstadoProducto();
				prcFillCombo(cboEstPdt,"Descripcion","IdEstadoProducto",RsEstPdt);
				
				//to fill the estado material description in to the cboestmat control
				SICALNet.BusinessLogicLayer.EstadoMaterial BLLEstMat=new SICALNet.BusinessLogicLayer.EstadoMaterial();
				IList RsEstMat=(IList) BLLEstMat.SelectEstadoMaterial();
				prcFillCombo(cboEstMaterial,"Descripcion","IdEstadoMaterial",RsEstMat);

				//to fill the familia producto's description into the cbofampdt control
				SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList RsFampdt=(IList) BLLFampdt.SelectFamiliaProducto();
				prcFillCombo(cboFamPdt,"Descripcion","IdFamiliaProductos",RsFampdt);

				//to fill the color description into the cbocolor control
				SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
				IList RsColor=(IList) BLLColor.SelectColour();
				prcFillCombo(cboColor,"IdColour","IdColour",RsColor);
				
				//to fill the medida description into the cboMedida control
				SICALNet.BusinessLogicLayer.Medida BLLMedida=new SICALNet.BusinessLogicLayer.Medida();
				IList RsMedida=(IList) BLLMedida.LoadMedida();
				prcFillCombo(cboMedida,"Centimetros","IdMedida",RsMedida);
				
				//to fill the espesor description into the cboEspesor control
				SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
				IList RsEspesor=(IList) BLLEspesor.LoadEspesor();
				prcFillCombo(cboEspesor,"Centimetros","IdEspesor",RsEspesor);
				
				//to fill the mercado description into the cboMercado control
				SICALNet.BusinessLogicLayer.Mercado BLLMercado=new SICALNet.BusinessLogicLayer.Mercado();
				IList RsMercado=(IList) BLLMercado.SelectMercado();
				prcFillCombo(cboMercado,"Descripcion","IdMercado",RsMercado);

				//to fill the presentation description into the cboPresentation control
				SICALNet.BusinessLogicLayer.Presentacion BLLPresent=new SICALNet.BusinessLogicLayer.Presentacion();
				IList RsPresent=(IList) BLLPresent.SelectPresentacion();
				prcFillCombo(cboPresentation,"Descripcion","IdPresentacion",RsPresent);

				//to fill the Acabado description into the cboAcabado control
				SICALNet.BusinessLogicLayer.Acabado BLLAcabado=new SICALNet.BusinessLogicLayer.Acabado();
				IList RsAcabado=(IList) BLLAcabado.SelectAcabado();
				prcFillCombo(cboAcabado,"Descripcion","IdAcabado",RsAcabado);

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				//to fill the Acabado description into the cboLineaBase control
				SICALNet.BusinessLogicLayer.LineaProduccion BLLLineaBase=new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList RsLinea=(IList) BLLLineaBase.SelectLinePdt(theUser);
				prcFillCombo(cboLineaBase,"Description","IdLinea",RsLinea);

//				/*
//				 * Modificación:
//				 *	Se asignan los elementos TipoEtiqueta al combo  
//				 * Autor:
//				 *	Ing. Ariel Martínez Morales
//				 * Fecha:
//				 *	05-08-2005
//				 */
//				SICALNet.BusinessLogicLayer.TipoEtiqueta bllTipoEtiqueta=new SICALNet.BusinessLogicLayer.TipoEtiqueta();
//				IList lstTipoEtiqueta=(IList) bllTipoEtiqueta.LoadTipoEtiqueta();
//				prcFillCombo(this.cboTipoEtiqueta,"Nombre","IdTipoEtiqueta", lstTipoEtiqueta);

			}
			catch(Exception errHand)
			{
				
				//errFileWrite.HandleException("Structure","Material",errHand,Server.MapPath(".."),errHand.Message);
				lblErr.Text = errHand.Message;
			}
		}

		private void prcFillCombobyIdPlanta()
		{
		//to fill the lines by combo

		SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, System.Convert.ToInt32(cboPlanta.SelectedItem.Value) , string.Empty, 0, string.Empty, 0, string.Empty, true);
		SICALNet.BusinessLogicLayer.LineaProduccion BLLLineaBase=new SICALNet.BusinessLogicLayer.LineaProduccion();
		IList RsLinea=(IList) BLLLineaBase.SelectLinePdt(theUser);
		prcFillCombo(cboLineaBase,"Description","IdLinea",RsLinea);
		}

		//to assign the data source and value into the dropdown combo
		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill)
		{
			cboCntl.DataSource=RsCboFill;
			cboCntl.DataValueField=valField;
			cboCntl.DataTextField=txtFiled;
			cboCntl.DataBind();
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
		[Obsolete]
		private void InitializeComponent()
		{    
			this.imgFind.Click += new System.Web.UI.ImageClickEventHandler(this.imgFind_Click);
			this.imgEdit.Click += new System.Web.UI.ImageClickEventHandler(this.imgEdit_Click);
			this.imgSave.Click += new System.Web.UI.ImageClickEventHandler(this.imgSave_Click);
			this.imgDel.Click += new System.Web.UI.ImageClickEventHandler(this.imgDel_Click);
			this.imgCancel.Click += new System.Web.UI.ImageClickEventHandler(this.imgCancel_Click);
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.cboEstMaterial.SelectedIndexChanged += new System.EventHandler(this.cboEstMaterial_SelectedIndexChanged);
			this.ID = "FormMaterial";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			lblErr.Text=string.Empty;
			lblErr.BackColor=Color.White;
			//to enable or disable the image button or panel
			prcEnableDisable("0101001100");
			imgSave.AlternateText="Save";
			MaterialClear();
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			lblErr.Text=string.Empty;
			lblErr.BackColor=Color.White;
			//to enable or disable the image button or panel
			prcEnableDisable("0100010101");
			imgSave.AlternateText="Update";
			MaterialClear();
		}


		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			lblErr.Text=string.Empty;	
			lblErr.BackColor=Color.White;
			txtCodigo.Text = "";
			//to enable or disable the im4age button or panel
			prcEnableDisable("0100010110");
			txtCodigo.Text=String.Empty; 
			
		}


		private void prcEnableDisable(string sEnable)
		{
			//pnlFindGrid.Visible= sEnable.Substring(0,1) == "0" ? false : true;
			pnlCodigo.Visible=sEnable.Substring(1,1) == "0" ? false : true;
			pnlFinished.Visible=sEnable.Substring(2,1) == "0" ? false : true;
			pnlNew.Visible=sEnable.Substring(3,1) == "0" ? false : true;
			pnlOperation.Visible=sEnable.Substring(4,1) == "0" ? false : true;

			imgFind.Visible=sEnable.Substring(5,1) == "0" ? false : true;
			imgSave.Visible=sEnable.Substring(6,1) == "0" ? false : true;
			imgCancel.Visible=sEnable.Substring(7,1) == "0" ? false : true;
			imgDel.Visible=sEnable.Substring(8,1) == "0" ? false : true;
			imgEdit.Visible=sEnable.Substring(9,1) == "0" ? false : true;
		}


		private void imgCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			lblErr.Text=string.Empty;
			lblErr.BackColor=Color.White;
			this.txtCodigo.Enabled = true;
			this.cboPlanta.Enabled = true;
			this.pnlPlanta.Visible = false;		
			//to enable or disable the image button or panel
			prcEnableDisable("0000100000");
		}


		private void cboEstMaterial_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			prcToshowFinishPdt();
			if (Convert.ToInt32(cboEstMaterial.SelectedItem.Value) == Convert.ToInt32(ConfigurationManager.AppSettings["IdProductoTerminado"]))
			{
				//to enable or disable the image button or panel
				prcEnableDisable("0111001100");
				this.lblPlanta.Visible=true;
				this.cboPlanta.Visible=true; 
				this.pnlPlanta.Visible = true;
			}
			else
			{
				prcEnableDisable("0101001100");
				this.lblPlanta.Visible=false;
				this.cboPlanta.Visible=false; 
				this.pnlPlanta.Visible = false;
			}
		}

		private void prcToshowFinishPdt()
		{
			if (Convert.ToInt32(cboEstMaterial.SelectedItem.Value) == Convert.ToInt32(ConfigurationManager.AppSettings["IdProductoTerminado"]))
			{
				//to enable or disable the image button or panel
				prcEnableDisable("0111001100");

			}
			else
				prcEnableDisable("0101001100");
		}

		private void imgSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

				try
				{
					//to get an instance from validation
					Validation vdtMaterial = new Validation();
					if(txtCodigo.Text.Trim()=="")
					{
						lblErr.Text = "Debe de capturar el código del material código SAP";
						lblErr.ForeColor=Color.White;
						lblErr.BackColor= Color.Green;
						return;
					}
					if(txtDesc.Text.Trim()=="")
					{
						lblErr.Text = "Debe de capturar la descripción del material";
						lblErr.ForeColor=Color.White;
						lblErr.BackColor= Color.Green;
						return;
					}
					//to check colorid whether its correct or not
					if (vdtMaterial.IsNumber(txtCodigo.Text)== true)
						if(vdtMaterial.IsAlphaNumeric(txtDesc.Text)==true)
						{
							//Declare the object;
							MaterialInfo BEMatInfo;
							SICALNet.BusinessLogicLayer.Material BLLMaterial;

							//Correction made by Daniel Novelo
							//Determine if the material is "Finished Product", then save all the data,
							//to assign the control box values into variables
							if (Convert.ToInt32(cboEstMaterial.SelectedItem.Value)==Convert.ToInt32(ConfigurationManager.AppSettings["IdProductoTerminado"]))
							{
								string Codigo = txtCodigo.Text.ToString().Trim();
								string Desc = txtDesc.Text.ToString().Trim();
								int EstPdt = Convert.ToInt32(cboEstPdt.SelectedItem.Value);
								int EstMat = Convert.ToInt32(cboEstMaterial.SelectedItem.Value);
								int IdFamPdt = Convert.ToInt32(cboFamPdt.SelectedItem.Value);
								string IdColor = cboColor.SelectedItem.Value.ToString().Trim();
								int IdMedida = Convert.ToInt32(cboMedida.SelectedItem.Value);
								string IdEspesor = cboEspesor.SelectedItem.Value.ToString().Trim();
								int IdMercado = Convert.ToInt32(cboMercado.SelectedItem.Value);
								string IdPresent = cboPresentation.SelectedItem.Value.ToString().Trim();
								int IdAcabado = Convert.ToInt32(cboAcabado.SelectedItem.Value);
								int IdLineaBase = Convert.ToInt32(cboLineaBase.SelectedItem.Value);
								int VersionAditivos = Convert.ToInt32(txtVersionAd.Text.Trim());
								int IdPlanta = Convert.ToInt32(cboPlanta.SelectedItem.Value);
								bool segundas=chkSegundas.Checked;

								//to assign the color info into business entity lager
								BEMatInfo= new MaterialInfo(Codigo,Desc,EstMat,IdColor,IdMedida,IdEspesor,IdMercado,IdPresent,IdAcabado,EstPdt,IdFamPdt,IdLineaBase,VersionAditivos,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,IdPlanta,segundas);
								//to get an instance from business logic layer
								BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
							}
							else
							{
								string Codigo = txtCodigo.Text.ToString().Trim();
								string Desc = txtDesc.Text.ToString().Trim();
								int EstPdt = Convert.ToInt32(cboEstPdt.SelectedItem.Value);
								int EstMat = Convert.ToInt32(cboEstMaterial.SelectedItem.Value);
								bool etiquetaColor = chkEtiquetaColor.Checked;
								bool mezclado = chkMezclado.Checked;
								//to assign the color info into business entity lager
								//BEMatInfo= new MaterialInfo(Codigo,Desc,EstMat,EstPdt);
								BEMatInfo= new MaterialInfo(Codigo,Desc,EstMat,EstPdt, etiquetaColor,mezclado);
								//Termina Modificación

								//to get an instance from business logic layer
								BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
							}

							if (imgSave.AlternateText == "Save")
							{
								//to Call the Insert FormCintas method
								BLLMaterial.InsertMaterial(BEMatInfo);

							}
							else if (imgSave.AlternateText == "Update")
							{
								//to Call the update FormCintas method
								BLLMaterial.UpdateMaterial(BEMatInfo);
							}
							txtCodigo.Text = "";
							txtDesc.Text = "";
							lblErr.Text="La información del material se guardo con éxito";
							lblErr.ForeColor=Color.White;
							lblErr.BackColor=Color.Green;
							//to enable or disable the image button or panel
							prcEnableDisable("0100010101");
							imgSave.AlternateText = "Update";
							this.lblPlanta.Visible=false;
							this.cboPlanta.Visible=false;
							this.pnlPlanta.Visible=false; 
							this.cboPlanta.Enabled = true;
							this.txtCodigo.Enabled = true; 
						}
					else
						throw new Exception("Debe capturar la descripción");
				else
					throw new Exception("El codigo SAP debe ser un número");
				}			
				catch
				{
					// prcErrorDisplay(errHand,"Error");			
					throw;
				}				
		}

		private void MaterialClear()
		{
			try
			{
				txtCodigo.Text=string.Empty;
				txtDesc.Text=string.Empty;
				cboPlanta.SelectedIndex=0;  
				cboAcabado.SelectedIndex=cboAcabado.Items.Count-1;
				cboColor.SelectedIndex=cboColor.Items.Count-1;
				cboEspesor.SelectedIndex= cboEspesor.Items.Count-1;
				cboEstMaterial.SelectedIndex= cboEstMaterial.Items.Count-1;
				cboFamPdt.SelectedIndex= cboFamPdt.Items.Count-1;
				cboMedida.SelectedIndex= cboMedida.Items.Count-1;
				cboMercado.SelectedIndex= cboMercado.Items.Count-1;
				cboPresentation.SelectedIndex=cboPresentation.Items.Count-1;
				for(int i=0;i<cboEstPdt.Items.Count-1;i++)
				{
					if (cboEstPdt.Items[i].Value == "1" && cboEstPdt.Items[i].Text == "Released Product")
					{
						cboEstPdt.SelectedIndex=i;
						break;
					}
				}
				if(imgSave.AlternateText == "Save")
					prcEnableDisable("0101001100");
				else if(imgSave.AlternateText == "Update")
					prcEnableDisable("0100010101");

			}
			catch
			{
				throw;
			}
		}
		
		private void prcToSetIndex(DropDownList cboIndex,string chqVal)
		{
			if (chqVal != "0" || chqVal != string.Empty)
			{
				for(int i=0;i<cboIndex.Items.Count;i++)
				{
					if (cboIndex.Items[i].Value.ToString() == chqVal)
					{
						cboIndex.SelectedIndex=i;
						break;
					}
				}
			}
		}

		private void imgEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//initialize the controls without legend on the label
				lblErr.Text="";
				lblErr.BackColor=Color.White;
				lblErr.ForeColor=Color.White;

				if (txtCodigo.Text == string.Empty)
					throw new Exception("El código SAP debe ser proporcionado");
				string Codigo = txtCodigo.Text.ToString().Trim();
				MaterialInfo BEMatInfo;
				if(cboPlanta.Visible==false)
					BEMatInfo= new MaterialInfo(Codigo,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty);
				else
					BEMatInfo= new MaterialInfo(Codigo,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,Convert.ToInt32(cboPlanta.SelectedItem.Value.ToString()),false);	
				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.Material BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
				//to Call the Insert FormCintas method
				MaterialInfo BEMat = BLLMaterial.SelectMaterial(BEMatInfo);

				if(BEMat ==null)
				{
					// Busca en la planta 2
					MaterialInfo BEMatInfo2= new MaterialInfo(Codigo,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,2,false);						
					MaterialInfo BEMat2 = BLLMaterial.SelectMaterial(BEMatInfo2);
					if (BEMat2==null)
					throw new Exception("No existe un material para el Código SAP proporcionado");
					else
					BEMat=BEMat2;

				}

					int AuxPlanta;

					if(BEMat.IdPlanta==1)
						AuxPlanta=2;
					else
						AuxPlanta=1;
					MaterialInfo BEMatInfoAux= new MaterialInfo(Codigo,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,AuxPlanta,false);	
					IList listAux= BLLMaterial.SelectMaterialList(BEMatInfoAux);					

					//fill lines combo
				    prcFillCombobyIdPlanta();

					if(listAux.Count == 1)				
					{
						if(!pnlPlanta.Visible)
						{
							lblPlanta.Visible = true;
							cboPlanta.Visible = true;
							prcToSetIndex(cboPlanta,BEMat.IdPlanta.ToString());
							this.pnlPlanta.Visible =true;
							return;
						}
					}
				

				if(BEMat.IdEstadoMaterial==Convert.ToInt32(ConfigurationManager.AppSettings["IdProductoTerminado"]))
				{
					lblPlanta.Visible = true;
					cboPlanta.Visible = true;
					prcToSetIndex(cboPlanta,BEMat.IdPlanta.ToString());
					this.pnlPlanta.Visible =true;
					cboPlanta.Enabled = false;

				}


				txtCodigo.Enabled = false;
				txtCodigo.Text=BEMat.CodigoSAP;
				
				txtDesc.Text=BEMat.Descripcion;
				prcToSetIndex(cboEstPdt,BEMat.IdEstadoProducto.ToString());
				prcToSetIndex(cboEstMaterial,BEMat.IdEstadoMaterial.ToString());
					
				chkEtiquetaColor.Checked = BEMat.EtiquetaColor;
				chkMezclado.Checked=BEMat.Mezclado;

				if (BEMat.IdEstadoMaterial==Convert.ToInt32(ConfigurationManager.AppSettings["IdProductoTerminado"]))
				{
					prcToSetIndex(cboFamPdt,BEMat.IdFamiliaProducto.ToString());
					prcToSetIndex(cboColor,BEMat.IdColor);
					prcToSetIndex(cboMedida,BEMat.IdMedida.ToString());

					prcToSetIndex(cboEspesor,BEMat.IdEspesor.ToString());
					prcToSetIndex(cboMercado,BEMat.IdMercado.ToString());
					prcToSetIndex(cboPresentation,BEMat.IdPresentacion.ToString());
					prcToSetIndex(cboAcabado,BEMat.IdAcabado.ToString());
					prcToSetIndex(cboLineaBase,BEMat.IdLineaBase.ToString());
					txtVersionAd.Text=BEMat.VersionAditivos.ToString().Trim();
					this.chkSegundas.Checked=BEMat.Segundas;
				}

				//to show or hide the fn\inished product details
				prcToshowFinishPdt();				
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");
				
				//throw;
				RegisterClientScriptBlock("", "<script language='JavaScript'> alert('No existe un material para el Código SAP proporcionado'); </script>");
			}
		}

		private void imgDel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if (txtCodigo.Text == string.Empty)
					throw new Exception("CodigoSAP should not be null");
				string Codigo = txtCodigo.Text.ToString().Trim();

				MaterialInfo BEMatInfo= new MaterialInfo(Codigo,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty);
				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.Material BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
				//to Call the Insert FormCintas method
				BLLMaterial.DeleteMaterial(BEMatInfo);
				txtCodigo.Text=String.Empty; 
				lblErr.Text="La información del material fue eliminada";
				lblErr.ForeColor=Color.White;
				lblErr.BackColor=Color.Green;
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"El detalle de este material esta referenciado a otro catálogo");
			}
			catch
			{
				
				// prcErrorDisplay(errHand,"Error");

				throw;
			}

		}

		[Obsolete]
		private void imgFind_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormMaterial&CtrlName=txtCodigo&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
			}
			catch(Exception ex)
			{
				lblErr.ForeColor=Color.Red;
				lblErr.Text=ex.Message;
				txtCodigo.Text=string.Empty;
			}
		}

		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("Material Information",errHnd,Server.MapPath("")+"Error.txt");
				lblErr.ForeColor=Color.White;
				lblErr.BackColor=Color.Red;
				lblErr.Text=errHnd.Message;
				
			}
			else if (errStatus=="NoError")
			{
				//to clear label box
				lblErr.ForeColor=Color.Black; //White;
				lblErr.BackColor=Color.Green;
			}
			else
			{
				//to display the success msg
				lblErr.Text=errStatus;
				lblErr.ForeColor=Color.White;
				lblErr.BackColor=Color.Green;
			}
		}

	}
}
