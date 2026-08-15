namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;
	using SICALNet.Utilities;
	using SICALNet.BusinessEntities;
	using SICALNet.BusinessLogicLayer;
	using CrystalDecisions.Shared;
	using System.Threading;
	using System.Data.SqlClient;
	using System.Data.OleDb;
	using Microsoft.ApplicationBlocks.Data;

	/// <summary>
	///		Summary description for ConsultProgramGrid.
	/// </summary>
	public abstract class ProgrammaGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.DropDownList ddlIdLinea;
		protected System.Web.UI.WebControls.DataList lstProgram;
		protected System.Web.UI.WebControls.Label lblmsg;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFecha;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button btnCancelarSecuencias;
		protected System.Web.UI.WebControls.Button cmdprint;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label IdLote;
		protected System.Web.UI.WebControls.DropDownList ddlLote;
		protected System.Web.UI.WebControls.Label lblDate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				try
				{
					//to fill the Linea description into the cboLinea control
					SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();

					SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
					theUser  = BLLUser.Load(theUser);

					// Carga de Línea
					IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
					ddlIdLinea.DataSource=RsLine;
					ddlIdLinea.DataValueField="IdLinea";
					ddlIdLinea.DataTextField="Description";
					ddlIdLinea.DataBind();
					ddlIdLinea.Items.Add(new ListItem(string.Empty,"0"));

					string lineaDefault;

					switch(theUser.IdPlanta)
					{
						case 1:	// Ocoyoacac
							lineaDefault = "1";
							break;
						case 2: // San Luis
							lineaDefault = "4";
							break;
						default:
							lineaDefault = "0";
							break;
					}

					ddlIdLinea.Items.FindByValue(lineaDefault).Selected=true;
					// Llena los lotes de la linea por devault
					ListaLotes(int.Parse(lineaDefault));
					ListaLotes(0);
					
					txtFecha.Text =  System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
					
					lstProgram.ShowFooter=false;
					this.cmdAdd.Enabled = false;  

				}
				catch(Exception ex)
				{
					ErrorHandling errFileWrite=new ErrorHandling();
					errFileWrite.HandleException("Programa Production",ex,Server.MapPath("SICALNet")+"Error.txt");
					lblmsg.Text = ex.Message;
					return;
				}
			}
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
			this.ddlIdLinea.SelectedIndexChanged += new System.EventHandler(this.ddlIdLinea_SelectedIndexChanged);
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.lstProgram.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_ItemCommand);
			this.lstProgram.CancelCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_CancelCommand);
			this.lstProgram.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_EditCommand);
			this.lstProgram.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_UpdateCommand);
			this.lstProgram.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_DeleteCommand);
			this.lstProgram.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.lstProgram_ItemDataBound);
			this.lstProgram.SelectedIndexChanged += new System.EventHandler(this.lstProgram_SelectedIndexChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.btnCancelarSecuencias.Click += new System.EventHandler(this.btnCancelarSecuencias_Click);
			this.cmdprint.Click += new System.EventHandler(this.cmdprint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//If any Fecha is avilable for that Linea, those all Fecha will be in dropdown list
		private void ddlIdLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{						
			int iLinea = int.Parse(ddlIdLinea.SelectedItem.Value);
			// Llena los lotes de la linea
			ListaLotes(iLinea);
		}

		// Llena la lista de lotes con el número de línea seleccionado
		private void ListaLotes(int iLinea)
		{
			// *************************
			string	sConsultaLotes = " sp_sicalnet_Logistica_Get_Lote_By_Linea1 @IdLinea = '" + iLinea + "'";
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
			{
				using(SqlDataReader dsLote = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["SICALConnString"],CommandType.Text,sConsultaLotes))
				{
					ddlLote.DataSource=dsLote;
					ddlLote.DataValueField="NumeroLote";
					ddlLote.DataTextField="Valor";
					ddlLote.DataBind();
				}
			}
			// *************************			
		}

		private void BindGrid()
		{		
			try
			{
				//to fill the fecha from programm production into fecha combo box
				SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
				//lstProgram.DataSource = bllProgramma.Load(ddlFecha.SelectedItem.Value,ddlFecha.SelectedItem.Value,Int32.Parse(ddlIdLinea.SelectedItem.Value));
				lstProgram.DataSource = bllProgramma.Carga(txtFecha.Text,txtFecha.Text,Int32.Parse(ddlIdLinea.SelectedItem.Value), int.Parse(this.ddlLote.SelectedItem.Value));
				lstProgram.DataBind();
				this.cmdAdd.Enabled = true;

			}
			catch(Exception ex)
			{
				ErrorHandling errFileWrite=new ErrorHandling();
				errFileWrite.HandleException("Programma Production",ex,Server.MapPath("SICALNet")+"Error.txt");
				lblmsg.Text = ex.Message;
				return;
			}
		}


		//to set focus for specified control
		private void setFocus(WebControl web)
		{
			Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" + web.ClientID + "').focus();" + "</SCRIPT>");
		}
			
		public bool AddSequence()
		{
			
			try
			{
				//declare the variable to handle the user input
				string Secuencia,CodigoSAP,NoOrder,Fecha,DetaileOperacion,LoteInspec;
				int IdLinea,IdPlanta,NumeroLote,IdLineaLote,Corrida,Rendimiento;
				float Cantidad;
		
				Validation Validate = new Validation();

				//get the IdLinea from linea Dropdowm list that  already got IdLinea as value , Description as text in dropdown list from Linea table when form Load event
				IdLinea =Int32.Parse(ddlIdLinea.SelectedItem.Value);
				//get fetch from fecha dropdowm list that already got fecha as value and formated fecha as text in drop down list from Programma production table that is related select linea, when user select require linea from dropdown list
				Fecha =txtFecha.Text.ToString();
				// get the IdLinealote from footer drop down list that is filled in dropdown list as value when user press Agregar button
				IdLineaLote = IdLinea;
				//get IdPlanta from web config file

				//IdPlanta = Int32.Parse(ConfigurationSettings.AppSettings["LocalPlant"]);
				if(IdLinea >3 && IdLinea!=9)
					IdPlanta = 2;
				else
					IdPlanta = 1;
			
				//to check Idplanta  textbox wheathear is exists or not
				SICALNet.BusinessEntities.PlantaInfo belPlanta = new SICALNet.BusinessEntities.PlantaInfo(IdPlanta ,string.Empty,string.Empty,0);
				SICALNet.BusinessLogicLayer.Planta bllPlanta = new SICALNet.BusinessLogicLayer.Planta();
				//to check the IdPlanta that is exists or not in planta table
				if(!bllPlanta.isExistPlanta(belPlanta))
				{
					lblmsg.Text = "No se encontro la planta";
					return false;
				}
				// assign the secuencia
				Secuencia = ((Label) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewSequence")).Text.Trim();
				
				TextBox textCorrida = (TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCorrida");
				//to chaeck Corrida textbox wheathear is empty or not
				if(textCorrida.Text.Trim() == string.Empty)
				{
					setFocus(textCorrida);
					lblmsg.Text = "El campo corrida no puede ser vacio";
					return false;
				}
				else
				{
					//to check whehear number or not
					if(! Validate.IsNumber(textCorrida.Text))
					{
						//set the focus to this control 
						setFocus(textCorrida);
						//clear the invalid input
						textCorrida.Text = String.Empty;
						//return user define input
						lblmsg.Text = "El campo corrida debe ser númerico";
					}
					//assign the corrida text box value
					Corrida =Int32.Parse(textCorrida.Text);
				}
				// get the Numero Lote from Numebro lote footer dropdown list that is filled in dropdown list as text when user press Agregar button
				NumeroLote = Int32.Parse(((DropDownList) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("cboLote")).SelectedItem.Text);
				
				//assign the lote Inspeccion
				
				LoteInspec = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtLoteInsp")).Text.Trim();
				//assign the order number
				NoOrder = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtOrden")).Text.Trim();
				if(NoOrder =="")
				{
					setFocus(((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtOrden")));
					lblmsg.Text = "Proporcione el número de orden";
				}
				// get the CodigoSAP from codigoSAp footer dropdown list that is filled in dropdown list as text when user press Agregar button
				CodigoSAP = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCodigoSAP")).Text.Trim();
				if(CodigoSAP == "") 
				{
					setFocus(((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCodigoSAP")));
					lblmsg.Text = "Proporcione el Material";
					return false;
				}

				TextBox textCantidad = (TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCantidad");
				//to chaeck Cantidad textbox wheathear is empty or not
				if(textCantidad.Text.Trim() == string.Empty)
				{
					setFocus(textCantidad);
					lblmsg.Text = "Proporcione la cantidad de láminas a producir";
					return false;
				}
				else
				{
					//to check whehear number or not
					if(!Validate.IsNumber(textCantidad.Text.Trim()))
					{
						//to set focus to that invalid input control
						setFocus(textCantidad);
						//to clear the invalid input 
						textCantidad.Text = string.Empty;
						//return the user define error
						lblmsg.Text = "La cantidad debe ser un dato númerico";
						return false;
					}
					//assign the user input thas from Cantidad textbox
					Cantidad = (float)decimal.Parse((textCantidad.Text.Trim()));
				}

				TextBox textRendimiento = (TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtRendimiento");
				//to chaeck Corrida textbox wheathear is empty or not

				
				if(textRendimiento.Text.Trim()==string.Empty)
				{
					//setFocus(textRendimiento);
					//lblmsg.Text = "Proporcione el Rendimiento del material";
					//return false;
					Rendimiento=0;
				}
				else
				{ 
					//to check whehear number or not
					if(! Validate.IsNumber(textRendimiento.Text))
					{
						//to set focus for that control
						setFocus(textRendimiento);
						//clear the invalid input
						textRendimiento.Text = string.Empty;
						//return the user define Error
						lblmsg.Text = "El rendimiento debe ser un dato númerico";
						return false;
					}
					//assign the user input thats from Rendimiento text box
				    Rendimiento = Int32.Parse(textRendimiento.Text);
					
				}

				//assign the user input thats from Detaileoperacion
				
				DetaileOperacion = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtDetalleOp")).Text.Trim();
				string TipoMolde = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtTipoMolde")).Text.Trim();
				string Pedido = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtPedido")).Text.Trim();
				string Cliente = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCliente")).Text.Trim();
				string Comentarios = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtComentarios")).Text.Trim();
				string Prioridad = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtPrioridad")).Text.Trim();
				string FechaEmb = ((TextBox) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtFechaEmb")).Text.Trim();

				SICALNet.BusinessEntities.LoteInfo belLoteCantidad = new SICALNet.BusinessEntities.LoteInfo(NumeroLote,IdLineaLote,0,false);
				SICALNet.BusinessLogicLayer.Lote bllLoteCantidad = new SICALNet.BusinessLogicLayer.Lote();
				

				//MaterialInfo BEMaterial = new MaterialInfo(CodigoSAP,string.Empty);	
				MaterialInfo BEMaterial = new MaterialInfo(CodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,IdPlanta,false);	
				Material  BLMaterial = new Material();
				BEMaterial=BLMaterial.SelectMaterial(BEMaterial);


				// -------------------------------------------------------------------------------
				// 
				// Validate that there exists at least one formulation of additives for that Material 
				// for the current row
				// -------------------------------------------------------------------------------

				//Nasoft 07 dic 2005
				// se agrego validar si el codigo sap es Liberado
				
				FormAditivosInfo faInfo = new FormAditivosInfo(string.Empty,string.Empty,IdLinea,IdPlanta,CodigoSAP,0);
				FormAditivos FormAditivos = new FormAditivos();
				if(!FormAditivos.isExistMaterialFormAditivos(faInfo) && (BEMaterial.IdEstadoMaterial!=Convert.ToInt32(ConfigurationSettings.AppSettings["IdInstrucciones"])))
				{
					lblmsg.Text = "El material " + CodigoSAP + " " + BEMaterial.IdColor + "/" + BEMaterial.IdEspesor + "/" + BEMaterial.VersionAditivos + " no tiene formulación de Aditivos";
					return false;

				}	
				
						
				FormColorInfo fcInfo = new FormColorInfo(IdPlanta,CodigoSAP);
				FormColor FormColor = new FormColor();
				if(!FormColor.isExistMaterialFormColor(fcInfo) && (BEMaterial.IdEstadoMaterial==Convert.ToInt32(ConfigurationSettings.AppSettings["IdProductoTerminado"])))
				{
					ColourInfo BEColor = new ColourInfo(BEMaterial.IdColor,string.Empty,string.Empty,string.Empty,0,false);
					Colour BLLColor = new Colour();
					BEColor=BLLColor.Load(BEColor);
					if 	(!BEColor.Transparente)
					{
						lblmsg.Text = "El material " + CodigoSAP + " no tiene formulación de Color";
						return false;
					}
				}



				//to check Cantidad is exceed the stock
				if(bllLoteCantidad.getPiezas(belLoteCantidad) >= Cantidad)
				{
					
					// add the programma information
					int IdStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["SequenceStatusInProcess"]);

					//To Get the IdArea based on Parametro
					//In default Area is 'Color Room', the Corresponding IdParametro Value for Area is 1.
					
					SICALNet.BusinessEntities.ParametroInfo  proInfo = new SICALNet.BusinessEntities.ParametroInfo();
					SICALNet.BusinessLogicLayer.Parametro bllParametro = new SICALNet.BusinessLogicLayer.Parametro();
					proInfo = bllParametro.LoadParametro(1);
					int IdArea = Convert.ToInt32(proInfo.Valor);


					SICALNet.BusinessEntities.ProgramaInfo  belProgramma = new SICALNet.BusinessEntities.ProgramaInfo
						(Secuencia,CodigoSAP,IdLinea,IdPlanta,NumeroLote,IdLineaLote,string.Empty,Fecha,Cantidad,Cantidad,
						Corrida,NoOrder,LoteInspec,Rendimiento,FechaEmb,DetaileOperacion,string.Empty,IdStatus,
						IdArea,DateTime.MinValue.ToString("dd-MMM-yy"),TipoMolde,Pedido,Cliente,Comentarios,Prioridad,string.Empty,string.Empty,string.Empty, string.Empty);
					SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
					bllProgramma.Insert(belProgramma);
				
//					//to update the secuencia table 
//					long SecuenciaUpdate = long.Parse(((TextBox) dgdProgram.Controls[0].Controls[dgdProgram.Controls[0].Controls.Count-1].Controls[0].FindControl("txtSecuencia")).Attributes["Secuencia"])+1;
//					SICALNet.BusinessEntities.SecuenciasLineaInfo belSecuencia = new SICALNet.BusinessEntities.SecuenciasLineaInfo(Int32.Parse(ddlIdLinea.SelectedItem.Value),DateTime.Today.Year,SecuenciaUpdate);
//					SICALNet.BusinessLogicLayer.SecuenciasLinea bllSecuencia = new SICALNet.BusinessLogicLayer.SecuenciasLinea();
//					bllSecuencia.UpdateConsecutive(belSecuencia);
				
					ClearFooterData();
					BindGrid();
					lblmsg.Text = "La secuencia se agregó exitosamente";
					
					this.lstProgram.ShowFooter=false;
					this.lstProgram.ShowFooter=false;
					this.lstProgram.ShowFooter=false;
					this.lstProgram.EditItemIndex = -1;
					this.lstProgram.EditItemIndex = -1;
					this.lstProgram.EditItemIndex = -1;
					BindGrid();
					BindGrid();
					BindGrid();

					// Inserción de Secuencia
					Thread.Sleep(3000);
					string sValores = "Se agregó la secuencia " + Secuencia;
					string Confirma="<script language='javascript'>window.location='../Logistics/Confirmacion.aspx?Secuencia=" + Secuencia +"&Fecha=" + txtFecha.Text +"&Linea=" + ddlIdLinea.SelectedItem.Value +  "&Valores=" + sValores + "&Operacion=1';</script>";
					Page.RegisterStartupScript("ClientScript",Confirma);
					return true;
				}
				else
				{
					lblmsg.Text = "La cantidad no es valida";
					return false;
				}

			}
			catch(Exception ex)
			{
				//ErrorHandling errFileWrite=new ErrorHandling();
				//errFileWrite.HandleException("Programma Production",ex,Server.MapPath("SICALNet")+"Error.txt");
				lblmsg.Text = ex.Message;
				return false;
			}
		}

		private void ClearFooterData()
		{
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtPrioridad")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCorrida")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCantidad")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCodigoSAP")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtOrden")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtPedido")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtLoteInsp")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtRendimiento")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCliente")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtFechaEmb")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtTipoMolde")).Text=string.Empty;
			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtComentarios")).Text=string.Empty;
		}

		public void Expand(object sender, System.Web.UI.ImageClickEventArgs e)
			{

			ImageButton boton=(ImageButton)sender;
			string id =boton.ClientID;
			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			string url = boton.ImageUrl.ToLower();
//			string url = boton.ImageUrl;
			/*** fin de modificación ***/
			int index =Convert.ToInt32(id.Substring(26,id.LastIndexOf("_")-26));		

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			if (String.Compare(url,"../images/plusbutton.jpg")==0)
//			if (url.ToLower()=="../images/plusbutton.jpg")
			/*** fin de modificación ***/
				{
				boton.ImageUrl="../images/minusButton.jpg";
				HtmlTable detailsTable=((HtmlTable)lstProgram.Items[index-1].FindControl("SequenceDetails"));
				detailsTable.Visible=true;			
			}
			else
					{
				boton.ImageUrl="../images/plusButton.jpg";
				HtmlTable detailsTable=((HtmlTable)lstProgram.Items[index-1].FindControl("SequenceDetails"));
				detailsTable.Visible=false;			
			}
					}
					
		private void lstProgram_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
					{
			switch (e.CommandName)
			{
				case "AddMessage":
					string Secuencia = ((Label)e.Item.FindControl("lblSecuencia")).Text.ToString();
					string Fecha = ((Label)e.Item.FindControl("lblFecha")).Text.ToString();
					string Descripcion= ((Label)e.Item.FindControl("lblMaterialDesc")).Text.ToString();
					string Cantidad= ((Label)e.Item.FindControl("lblCantidad")).Text.ToString();
					Page.RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../Production/ConsultMessage.aspx?Secuencia="+Secuencia+"&Fecha="+Fecha+"&Descripcion="+Descripcion+"&Cantidad="+Cantidad+"','anycontent','width=1500,height=500,left=50, top=50,status,scrollbars=no'); </script>");
					break;
				
				case  "Save":
					
					//Save New Sequence
					if (AddSequence())
					{
						//Clear provided data

						//Hide Footer
						lstProgram.ShowFooter=false;
					}
					break;

				case "CancelNew":
					lstProgram.ShowFooter=false;
					break;

				}
		}

		private void lstProgram_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		 {
			//Obtain Controls
			Label oldQuantityControl =(Label)e.Item.FindControl("lblCantidad");
			TextBox newQuantityControl = (TextBox)e.Item.FindControl("txtQuantity");
			Label oldPriorityControl =(Label)e.Item.FindControl("lblPrioridad");
			TextBox newPriorityControl = (TextBox)e.Item.FindControl("txtPriority");
			//Set original Quantity
			newQuantityControl.Text=oldQuantityControl.Text;
			newPriorityControl.Text=oldPriorityControl.Text;
			SetEditMode(e,true);	
		}

		private void lstProgram_CancelCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			SetEditMode(e,false);	
			lblmsg.Text=string.Empty;
		}

		private void SetEditMode(System.Web.UI.WebControls.DataListCommandEventArgs e, bool enabled)
		{
			//Obtain Controls
			Label oldQuantityControl=(Label)e.Item.FindControl("lblCantidad");
			TextBox newQuantityControl = (TextBox)e.Item.FindControl("txtQuantity");
			Label oldPriorityControl =(Label)e.Item.FindControl("lblPrioridad");
			TextBox newPriorityControl = (TextBox)e.Item.FindControl("txtPriority");

			ImageButton editButton=(ImageButton)e.Item.FindControl("cmdEdit");
			ImageButton deleteButton=(ImageButton)e.Item.FindControl("cmdDelete");
			ImageButton updateButton=(ImageButton)e.Item.FindControl("cmdUpdate");
			ImageButton cancelButton=(ImageButton)e.Item.FindControl("cmdCancel");

			//Set Visibility of Quantity Controls
			oldQuantityControl.Visible=!enabled;
			newQuantityControl.Visible=enabled;
			oldPriorityControl.Visible=!enabled;
			newPriorityControl.Visible=enabled;

			//Set Visibility of Buttons
			editButton.Visible=!enabled;
			deleteButton.Visible=!enabled;
			updateButton.Visible=enabled;
			cancelButton.Visible=enabled;
		}

		private void lstProgram_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			//Initialize any message
			lblmsg.Text=string.Empty;
			try
			{
				string Sequence =((Label)e.Item.FindControl("lblSecuencia")).Text;
				string sValores = "Borrado de secuencia(s)";
				Page.RegisterClientScriptBlock("", "<script language='JavaScript'>var ruta = '../Logistics/Confirmacion1.aspx?Secuencia=" + Sequence + "&Fecha=" + this.txtFecha.Text  +  "&Linea=" + ddlIdLinea.SelectedItem.Value +  "&Valores=" + sValores + "&Operacion=2'; var w = 800; var h = 500; var x = (screen.width) ? (screen.width-w)/2 : 0; var y = (screen.height) ? (screen.height-h)/2 : 0;	searchWin = window.open(ruta,'imagen','scrollbars=no,resizable=no,top=' + y + ',left=' + x + ',width=' + w + ',height=' + h + ',status=no,location=no,toolbar=no');</script>");
			}
			catch(Exception ex)
			{
				//ErrorHandling errFileWrite=new ErrorHandling();
				//errFileWrite.HandleException("Programm Production",ex,Server.MapPath("SICALNet")+"Error.txt");
				lblmsg.Text = ex.Message;
				return;
			}
		}


		private string getNextSequence()
		{
			DataTable newTable = new DataTable();
			DataTable otherTable = new DataTable();
			DataColumn newColumn = new DataColumn("Sequence");
			DataColumn otherColumn = new DataColumn("Sequence");
			newTable.Columns.Add(newColumn);
			otherTable.Columns.Add(otherColumn);

			DataRow newRow; 

			for (int i=0;i<lstProgram.Items.Count;i++)
			{
				newRow=newTable.NewRow();
				newRow["Sequence"]=((Label)lstProgram.Items[i].FindControl("lblSecuencia")).Text;
				newTable.Rows.Add(newRow);
			}

			//Get the elements of the table sorted
			DataRow[] sortedRows= newTable.Select(string.Empty,"Sequence");
			
			for (int i=0;i<sortedRows.Length;i++)
				{
				//add elements to other Table
				otherTable.Rows.Add(sortedRows[i].ItemArray);			
				}
			//Create the new sequence based on last element
			int NewSequence=0;
			if(otherTable.Rows.Count!=0)
			{
				NewSequence = Convert.ToInt32(otherTable.Rows[otherTable.Rows.Count-1]["Sequence"]);
			}
			else
			{
				DateTime auxFecha;
				auxFecha = DateTime.Parse(txtFecha.Text.ToString());  
				NewSequence = Convert.ToInt32(this.ddlIdLinea.SelectedItem.Value.ToString() + auxFecha.ToString("yy") + auxFecha.ToString("MM") + auxFecha.ToString("dd") + "00");
			}

			string stringSequence = NewSequence.ToString();
			NewSequence = int.Parse(stringSequence.Substring(0,7));
			int ordinal = int.Parse(stringSequence.Substring(7));
			ordinal++;
			NewSequence = int.Parse(string.Format("{0}{1}",NewSequence.ToString(),ordinal.ToString("00")));

			return NewSequence.ToString();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			if (NotEmpty())
			{
				//Calculate new sequence
				Label newLabel = (Label)  lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewSequence");
				newLabel.Text=getNextSequence();

				//Set New Item Default Values
				Label newFecha= (Label) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewFecha");
				//newFecha.Text=DateTime.Parse(ddlFecha.SelectedItem.Text).ToString("dd/MMM/yy");
				newFecha.Text=txtFecha.Text;
				Label newLine = (Label) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewLine");
				newLine.Text=ddlIdLinea.SelectedItem.Value.Trim();
				Label newArea = (Label) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewArea");
				newArea.Text="Cuarto de Color";
				Label newStatus = (Label) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewStatus");
				newStatus.Text="En Proceso";

				//Load lotes
				LoteInfo belLote = new LoteInfo(0,Convert.ToInt32(newLine.Text),0,false);
				Lote bllLote = new Lote();

				DropDownList cboNewLote = (DropDownList) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("cboLote");
				cboNewLote.DataSource=bllLote.getLote(belLote);
				cboNewLote.DataValueField="NumeroLote";
				cboNewLote.DataTextField="NumeroLote";
				cboNewLote.DataBind();

				//Display Footer to the user.
				lstProgram.ShowFooter=true;
			}
		}

		//to check wheather IdLinea, Fecha dropdown list empty or not
		private bool NotEmpty()
		{
			if(ddlIdLinea.SelectedItem.Text.Trim() =="")
			{
				lblmsg.Text = "Seleccione una línea";
				return false;
			}
			return true;
		}

		public void CodigoSAPChanged(object sender, System.EventArgs e)
		{
			TextBox CodigoSapTextBox=(TextBox)sender;
			int IdLinea =Int32.Parse(ddlIdLinea.SelectedItem.Value);
			int IdPlantaAux;
			if(IdLinea >3 && IdLinea!=9)
				IdPlantaAux = 2;
			else
				IdPlantaAux = 1;
			MaterialInfo mInfo = new MaterialInfo(CodigoSapTextBox.Text,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,IdPlantaAux,false);	
			//MaterialInfo mInfo = new MaterialInfo(CodigoSapTextBox.Text, String.Empty);
			SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

			Label newDescription= (Label) lstProgram.Controls[lstProgram.Items.Count+1].FindControl("lblNewDescription");
			
			if (!Material.isExistMaterial(mInfo))
			{
				newDescription.Text=string.Empty;
				CodigoSapTextBox.Text=string.Empty;
				Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>alert('El sistema no pudo encontrar el codigoSAP proporcionado');</SCRIPT>");
				return;
			}
			else
			{
				// int IdLineaAux =Int32.Parse(ddlIdLinea.SelectedItem.Value);
				int IdPlanta;
				if(IdLinea >3 && IdLinea!=9)
					IdPlanta = 2;
				else
					IdPlanta = 1;

				MaterialInfo material = new MaterialInfo(CodigoSapTextBox.Text,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,IdPlanta,false);	
				//MaterialInfo material = new MaterialInfo(CodigoSapTextBox.Text,string.Empty);
				SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
				material=materialBLL.SelectMaterial(material);
				newDescription.Text=material.Descripcion;
				// Nasoft - Roberto Carlos Guzman Vargas
				// Se rebisa que el articulo no sea descontinuado
				// si lo es se despliega un error
				if(material.IdEstadoProducto == 3){
					newDescription.Text=string.Empty;
					CodigoSapTextBox.Text=string.Empty;
					Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>alert('El codigoSAP que ha proporcionado se encuentra descontinuado');</SCRIPT>");
					return;
				}

			}
		}


		private void cmdprint_Click(object sender, System.EventArgs e)
		{
			//to check wheather IdLinea, Fecha dropdown list empty or not
			if(NotEmpty())
			{
				int IdLinea =Int32.Parse(ddlIdLinea.SelectedItem.Value);
				string Fecha = DateTime.Parse(txtFecha.Text).ToString("dd/MMM/yyyy");
				PrepareReport(Fecha,IdLinea);
			}
		}

		private void PrepareReport(string fechaInicial, int linea)
		{
			try
			{

				Forms.Reports.ReportHelper rptHelper = new Forms.Reports.ReportHelper();
				Forms.Reports.ProgramaReport reporte = new Forms.Reports.ProgramaReport();

				ParameterValues campoFecha= new ParameterValues();
				ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
				valorFecha.Value=fechaInicial;
				campoFecha.Add(valorFecha);
				
				reporte.DataDefinition.ParameterFields["FechaInicio"].ApplyCurrentValues(campoFecha);

				valorFecha.Value=linea;
				reporte.DataDefinition.ParameterFields["Linea"].ApplyCurrentValues(campoFecha);


				string	SelectionStr=String.Empty;

				SelectionStr+="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(fechaInicial).ToString("yyyy") + "," + DateTime.Parse(fechaInicial).ToString("MM") + "," + DateTime.Parse(fechaInicial).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + linea;
				reporte.DataDefinition.RecordSelectionFormula=SelectionStr;
				

				// ********************************
				// Ordenamiento por campo de prioridad 06/04/2017 JJMR
				// ********************************
				CrystalDecisions.CrystalReports.Engine.DatabaseFieldDefinition 
					Campo = reporte.Database.Tables["ProgramaProduccion"].Fields["Prioridad"];
				
				reporte.DataDefinition.SortFields[0].Field = Campo;
				reporte.DataDefinition.SortFields[0].SortDirection= 
					CrystalDecisions.Shared.SortDirection.AscendingOrder;
				// ********************************

				string reportName = string.Format("ProgramaProduccion{0}",DateTime.Parse(fechaInicial).ToString("ddMMyy"));

				rptHelper.setPermission(reporte);
				string reportFullName = rptHelper.exportReport(reporte,reportName,Page.User.Identity.Name);

				string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"] + reportFullName + ".pdf";
				Response.Redirect(redirectPath);
			}
			catch(Exception errHand)
			{
				string error = errHand.ToString();
				throw;
			}
		}

		private void btnSel_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		private void lstProgram_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				// *************************
				// Consulta de secuencia
				Label lblSecuencia = (Label)e.Item.FindControl("lblSecuencia");
				string sSecuencia = lblSecuencia.Text;
				// *************************
				// obtiene los datos de Cantidad, Cantidad Original, Prioridad y Prioridad original
				double dCantidad = 0.00;
				double dCantidadOriginal = 0.00;
				string sPrioridad = "";
				string sPrioridadOriginal = "";
				int iCorrida = 0;

				string	sConsultaSecuencia = " Select Cantidad, Isnull(CantidadOriginal,Cantidad) CantidadOriginal, Prioridad, isnull(PrioridadOriginal, Prioridad) PrioridadOriginal, corrida " ;
				sConsultaSecuencia += " from ProgramaProduccion where Secuencia = '" + sSecuencia + "'";				
				using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
				{
					using(SqlDataReader sdrSec = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["SICALConnString"],CommandType.Text,sConsultaSecuencia))
					{
						while(sdrSec.Read())
						{
							dCantidad = double.Parse(sdrSec["Cantidad"].ToString());
							dCantidadOriginal = double.Parse(sdrSec["CantidadOriginal"].ToString()); 
							sPrioridad = sdrSec["Prioridad"].ToString(); 
							sPrioridadOriginal =sdrSec["PrioridadOriginal"].ToString();
							iCorrida = int.Parse(sdrSec["corrida"].ToString());
						}
					}
				}
				// *************************
				
				// Si no tiene fecha de modificación coloca color amarillo
				Label lblFechaMod = (Label)e.Item.FindControl("ItemFechaMod");
				//if ((lblFechaMod.Text != "") && ((sPrioridad != sPrioridadOriginal) || (dCantidad != dCantidadOriginal)))
				if ((lblFechaMod.Text != ""))
				{
					e.Item.BackColor = Color.Yellow;
				}								
				// Modificada el día de hoy	 color azul claro
				if (lblFechaMod.Text.ToString()  == DateTime.MinValue.ToString("dd/MMM/yy")) 
					e.Item.BackColor = Color.LightBlue;   

				// Si el estatus es 3 color rojo
				Label lblStatus = (Label)e.Item.FindControl("Label16");				
				// *************************
				if (dCantidad != dCantidadOriginal)
				{
					e.Item.BackColor = Color.GreenYellow;
				}
				if (sPrioridad != sPrioridadOriginal)
				{
					e.Item.BackColor = Color.Yellow;
				}
				if ((sPrioridad != sPrioridadOriginal) && (dCantidad != dCantidadOriginal))
				{
					e.Item.BackColor = Color.Orange;
				}				
				if (iCorrida == 1)
				{
					e.Item.BackColor = Color.Violet;
				}
				if (lblStatus.Text == ConfigurationSettings.AppSettings["SequenceStatusCancel"]) 
				{
					e.Item.BackColor = Color.Tomato;
				}	
				// *************************
				((System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("chkBorrar")).Value=((SICALNet.BusinessEntities.ProgramaInfo)e.Item.DataItem).Secuencia;
			}
		}

		/// <summary>
		/// Recorre los checkbox's seleccionados por el usuario para eliminar las secuencias respectivas
		/// </summary>
		/// <autor>Ing. Ariel Martínez Morales</autor>
		/// <date>03-08-2005</date>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancelarSecuencias_Click(object sender, System.EventArgs e)
		{
			string sCadenaSecuencias="";
			int j=0;
			foreach(DataListItem item in this.lstProgram.Items)
			{
				System.Web.UI.HtmlControls.HtmlInputCheckBox chk = (System.Web.UI.HtmlControls.HtmlInputCheckBox)item.Controls[1];
				if(chk!=null)
				{
					if(chk.Checked)
					{
						sCadenaSecuencias += chk.Value + ",";
						j++;
					}
				}
			}
			if(j>0)
			{
				// Borrado de Secuencias en grupo
				sCadenaSecuencias = sCadenaSecuencias.Substring(0,sCadenaSecuencias.Length-1); 
				string sValores = "Borrado de secuencia(s)";
				Page.RegisterClientScriptBlock("", "<script language='JavaScript'>var ruta = '../Logistics/Confirmacion1.aspx?Secuencia=" + sCadenaSecuencias + "&Fecha=" + this.txtFecha.Text  +  "&Linea=" + ddlIdLinea.SelectedItem.Value +  "&Valores=" + sValores + "&Operacion=2'; var w = 800; var h = 500; var x = (screen.width) ? (screen.width-w)/2 : 0; var y = (screen.height) ? (screen.height-h)/2 : 0;	searchWin = window.open(ruta,'imagen','scrollbars=no,resizable=no,top=' + y + ',left=' + x + ',width=' + w + ',height=' + h + ',status=no,location=no,toolbar=no');</script>");				
			}
			else
			{
				Page.RegisterClientScriptBlock("", "<script language='JavaScript'>alert('Favor de seleccionar una secuencia');</script>");
			}
		}
		/// <summary>
		/// Método para eliminar una secuencia, en el caso de que la secuencia tenga ordenes de trabajo asignadas
		/// actualiza la composición de la "reacción", en caso contrario elimina la secuencia.
		/// </summary>
		/// <autor>Ing. Ariel Martínez Morales</autor>
		/// <date>03-08-2005</date>
		/// <param name="Sequence">Clave de la secuencia a eliminar</param>
		/// 

		private void lstProgram_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e){
			//Object to validate
			Validation validate = new Validation();

			//Obtain Sequence quantity
			Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");
			TextBox newQuantityControl = (TextBox)e.Item.FindControl("txtQuantity");
			string sCantidad = lblCantidad.Text.Trim();
			string newQuantity=newQuantityControl.Text.Trim();

			//Obtain Sequence Priority
			Label lblPrioridad = (Label)e.Item.FindControl("lblPrioridad");
			TextBox newPriorityControl = (TextBox)e.Item.FindControl("txtPriority");
			string sPrioridad = lblPrioridad.Text.Trim();
			string newPriority=newPriorityControl.Text.Trim();

			//Validate the user provided data
			if(newQuantity != string.Empty)
			{
				
				if(!validate.IsNumber(newQuantity))
				{
					lblmsg.Text = "La cantidad debe ser numérico";
					return;
				}

				int NumeroLote = Int32.Parse(((Label)e.Item.FindControl("lblLote")).Text.Trim());
				//get the IdLinea from linea Dropdowm list that  already got IdLinea as value , Description as text in dropdown list from Linea table when form Load event
				int IdLinea =Int32.Parse(ddlIdLinea.SelectedItem.Value);
				//get fetch from fecha dropdowm list that already got fecha as value and formated fecha as text in drop down list from Programma production table that is related select linea, when user select require linea from dropdown list
				//string Fecha = DateTime.Parse(txtFecha.Text).ToString("dd/MMM/yyyy");
				
				SICALNet.BusinessEntities.LoteInfo belLoteCantidad = new SICALNet.BusinessEntities.LoteInfo(NumeroLote,IdLinea ,0,false);
				SICALNet.BusinessLogicLayer.Lote bllLoteCantidad = new SICALNet.BusinessLogicLayer.Lote();
				
				//to check cantidad is exceet from stock
				if(bllLoteCantidad.getPiezas(belLoteCantidad) >= (Int32.Parse(newQuantity)))
				{
					try
					{
						string secuencia = ((Label)e.Item.FindControl("lblSecuencia")).Text.Trim();
						SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(secuencia,DateTime.Today.ToString("dd/MMM/yyyy"),Int32.Parse(newQuantity),newPriority);
						SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
						bllProgramma.UpdateSequence(belProgramma);
						
						this.lstProgram.EditItemIndex = -1;
						this.lstProgram.EditItemIndex = -1;
						this.lstProgram.EditItemIndex = -1;
						BindGrid();
						BindGrid();
						BindGrid();
						
						// Actualización de secuencia
						Thread.Sleep(3000);
						string sValores = "";
						if (sCantidad != newQuantity)
						{
							sValores = "Cambió la cantidad de " + sCantidad + " a " + newQuantity;
						}
						if (sPrioridad != newPriority)
						{
							if (sValores.Length >0)
								sValores += ", Cambió la prioridad de " + sPrioridad + " a " + newPriority;
							else
								sValores = "Cambió la prioridad de " + sPrioridad + " a " + newPriority;
						}
						
						string Confirma="<script language='javascript'>window.location='../Logistics/Confirmacion.aspx?Secuencia=" + secuencia +"&Fecha=" + this.txtFecha.Text  +  "&Linea=" + ddlIdLinea.SelectedItem.Value +  "&Valores=" + sValores +"&Operacion=3';</script>"; 
						Page.RegisterStartupScript("ClientScript",Confirma);
						return;
						
					}
					catch(Exception ex)
					{
						//ErrorHandling errFileWrite=new ErrorHandling();
						//errFileWrite.HandleException("Programa Production",ex,Server.MapPath("SICALNet")+"Error.txt");
						lblmsg.Text = ex.Message;
						return;
					}
				}
				else
				{
					lblmsg.Text = string.Format("La cantidad de láminas ({0}) de la secuencia es mayor a la capacidad del lote No.{1} (capacidad del lote:{2})",newQuantity,belLoteCantidad.NumeroLote.ToString(),bllLoteCantidad.getPiezas(belLoteCantidad).ToString());
					return;
				}
			}
			else
			{
				lblmsg.Text = "Debe capturar una cantidad";
				return;
			}		
		}


		private void DelSequence(string Sequence)
		{
			SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(Sequence);
			SICALNet.BusinessLogicLayer.Programa bllProgramma= new SICALNet.BusinessLogicLayer.Programa();

			//Se cargan los datos del la secuencia
			IList objProgramaInfo = bllProgramma.Load(Sequence);
			int Cantidad = Convert.ToInt32(((ProgramaInfo)objProgramaInfo[0]).Cantidad);
			int IdStatus = ((ProgramaInfo)objProgramaInfo[0]).IdStatus;
		
			if(bllProgramma.HasWorkOrders(belProgramma))
			{
				if(IdStatus==Convert.ToInt32(ConfigurationSettings.AppSettings["SequenceStatusReleased"]))
					throw new Exception("La Secuencia "+ Sequence+" ya está cancelada, no puede ser cancelada nuevamente");
				else if(IdStatus==Convert.ToInt32(ConfigurationSettings.AppSettings["SequenceStatusCancel"]))
					throw new Exception("La Secuencia "+ Sequence+" ya está cancelada, no puede ser cancelada nuevamente");
				SICALNet.BusinessEntities.OrdenesTrabajoInfo oInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Sequence,0,Convert.ToInt32(ConfigurationSettings.AppSettings["StatusCancel"]),Convert.ToInt32(ConfigurationSettings.AppSettings["SequenceStatusCancel"]));						
				bllProgramma.CancelSecuence(oInfo);
				//to get the weight of each Laminas for the codigosap of that secuencia
				bllProgramma.UpdateReaccion(Sequence,DateTime.Parse(txtFecha.Text).ToString("dd/MMM/yyyy"),Convert.ToInt32(ddlIdLinea.SelectedItem.Value),Cantidad);
				//lblmsg.Text = string.Format("* La secuencia {0} ya tiene sus Ordenes de Trabajo, por lo tanto no podrá eliminarse. Cancele la orden de trabajo",Sequence);
				lblmsg.Text = string.Format("* La secuencia {0} se eliminó con éxito",Sequence);
			}
			else
			{
				bllProgramma.DeleteSecuence(belProgramma);
			}
		}

		private void lstProgram_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	
	}
}
