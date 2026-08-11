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

//References to SICALNet specific libraries
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for FindMaterialPP.
	/// </summary>
	public class FindMaterialPP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdMaterial;
		protected System.Web.UI.WebControls.Button cmdDone;
		protected System.Web.UI.WebControls.DataGrid dgdFindMaterial;
	
		private DataSet dsMaterial;
		private string sCharCurText;
		private string sEqualCurText;
		protected System.Web.UI.WebControls.Label lblTitle;
		private string sIdEqualCurText;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack) 
			{
				prcClear();
				
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgdFindMaterial.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFindMaterial_ItemCommand);
			this.dgdFindMaterial.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFindMaterial_CancelCommand);
			this.dgdFindMaterial.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFindMaterial_EditCommand);
			this.dgdFindMaterial.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFindMaterial_UpdateCommand);
			this.dgdFindMaterial.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFindMaterial_DeleteCommand);
			this.dgdFindMaterial.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFindMaterial_ItemDataBound);
			this.dgdFindMaterial.SelectedIndexChanged += new System.EventHandler(this.dgdFindMaterial_SelectedIndexChanged);
			this.cmdDone.Click += new System.EventHandler(this.cmdDone_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ToSetEditMode(string sChar,string sEqual,int idxId,string sIdEqual)
		{
			dgdFindMaterial.EditItemIndex=idxId;
			MakeDataSet(sChar,sEqual,idxId,sIdEqual);
		}

		//to check the charateristic. Its called when the user change the selected index
		public void prcCboCharSelect(object sender, System.EventArgs e)
		{
			DropDownList cboCharSel = (DropDownList)(dgdFindMaterial.Items[dgdFindMaterial.EditItemIndex].Cells[0].FindControl("cboChar"));
			DropDownList cboEqualSel = (DropDownList)(dgdFindMaterial.Items[dgdFindMaterial.EditItemIndex].Cells[1].FindControl("cboEqual"));
			if (cboCharSel.SelectedItem.Text != "")
				prcFillEqualCbo(cboEqualSel,cboCharSel.SelectedItem.Text,string.Empty);
		}

		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill,string CurValue)
		{
			cboCntl.DataSource=RsCboFill;
			cboCntl.DataValueField=valField;
			cboCntl.DataTextField=txtFiled;
			cboCntl.DataBind();
			cboCntl.Items.Add(new ListItem(string.Empty,string.Empty));
			if (CurValue != string.Empty)
				cboCntl.Items.FindByText(CurValue).Selected=true;
			else
				cboCntl.Items.FindByText(string.Empty).Selected=true;
		}

		//to fill the characterisic, use filteration
		private void prcFillCharCbo(DropDownList cboCharacter)
		{
			string sChar;
			cboCharacter.Items.Add(new ListItem(string.Empty,string.Empty));			
			cboCharacter.Items.Add(new ListItem("Color","Color"));
			cboCharacter.Items.Add(new ListItem("Medida","Medida"));
			cboCharacter.Items.Add(new ListItem("Espesor","Espesor"));
			cboCharacter.Items.Add(new ListItem("Mercado","Mercado"));
			cboCharacter.Items.Add(new ListItem("Presentacion","Presentacion"));
			cboCharacter.Items.Add(new ListItem("Acabado","Acabado"));
			cboCharacter.Items.Add(new ListItem("Estado Producto","Estado Producto"));
			cboCharacter.Items.Add(new ListItem("Estado Material","Estado Material"));
			cboCharacter.Items.Add(new ListItem("Familia Producto","Familia Producto"));
			cboCharacter.Items.Add(new ListItem("Linea Base","Linea Base"));

			for(int iLoop=0; iLoop < dgdFindMaterial.Items.Count; iLoop++)
			{
				if (iLoop != dgdFindMaterial.EditItemIndex)
					sChar=((Label)dgdFindMaterial.Items[iLoop].Cells[0].FindControl("lblChar")).Text.ToString();
				else
					sChar=string.Empty;

				switch(sChar)
				{
					case "Color":
						cboCharacter.Items.Remove("Color");
						break;
					case "Medida":
						cboCharacter.Items.Remove("Medida");
						break;
					case "Espesor":
						cboCharacter.Items.Remove("Espesor");
						break;
					case "Mercado":
						cboCharacter.Items.Remove("Mercado");
						break;
					case "Presentacion":
						cboCharacter.Items.Remove("Presentacion");
						break;
					case "Acabado":
						cboCharacter.Items.Remove("Acabado");
						break;
					case "Estado Producto":
						cboCharacter.Items.Remove("Estado Producto");
						break;
					case "Estado Material":
						cboCharacter.Items.Remove("Estado Material");
						break;
					case "Familia Producto":
						cboCharacter.Items.Remove("Familia Producto");
						break;
					case "Linea Base":
						cboCharacter.Items.Remove("Linea Base");
						break;
					default:
						break;
				}
			}
			if (sCharCurText.Trim().Length>0)
			{
				cboCharacter.Items.FindByText(sCharCurText).Selected=true;
			}
		}

		//to fill equal values, use characteristic
		private void prcFillEqualCbo(DropDownList cboEquals,string sCharacter,string sCurval)
		{
			IList RsEquals = null;
			string sTextFld=string.Empty;
			string svalFld=string.Empty;

			switch(sCharacter)
			{
				case "Color":
					//to fill the ColorId into the cboColor control
					SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
					RsEquals=(IList) BLLColor.SelectColour();
					sTextFld= "IdColour";
					svalFld= "IdColour";
					break;
				case "Medida":
					//to fill the medida description into the cboMedida control
					SICALNet.BusinessLogicLayer.Medida BLLMedida=new SICALNet.BusinessLogicLayer.Medida();
					RsEquals=(IList) BLLMedida.LoadMedida();
					sTextFld= "Centimetros";
					svalFld= "IdMedida";
					break;
				case "Espesor":
					//to fill the espesor description into the cboEspesor control
					SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
					RsEquals=(IList) BLLEspesor.LoadEspesor();
					sTextFld= "Centimetros";
					svalFld= "IdEspesor";
					break;
				case "Mercado":
					//to fill the mercado description into the cboMercado control
					SICALNet.BusinessLogicLayer.Mercado BLLMercado=new SICALNet.BusinessLogicLayer.Mercado();
					RsEquals=(IList) BLLMercado.SelectMercado();
					sTextFld= "Descripcion";
					svalFld= "IdMercado";
					break;
				case "Presentacion":
					//to fill the presentation description into the cboPresentation control
					SICALNet.BusinessLogicLayer.Presentacion BLLPresent=new SICALNet.BusinessLogicLayer.Presentacion();
					RsEquals=(IList) BLLPresent.SelectPresentacion();
					sTextFld= "Descripcion";
					svalFld= "IdPresentacion";
					break;
				case "Acabado":
					//to fill the Acabado description into the cboAcabado control
					SICALNet.BusinessLogicLayer.Acabado BLLAcabado=new SICALNet.BusinessLogicLayer.Acabado();
					RsEquals=(IList) BLLAcabado.SelectAcabado();
					sTextFld= "Descripcion";
					svalFld= "IdAcabado";
					break;
				case "Estado Producto":
					//to fill the estado producto into the cboestpdt control
					SICALNet.BusinessLogicLayer.EstadoProducto BLLEstPdt=new SICALNet.BusinessLogicLayer.EstadoProducto();
					RsEquals=(IList) BLLEstPdt.SelectEstadoProducto();
					sTextFld= "Descripcion";
					svalFld= "IdEstadoProducto";
					break;
				case "Estado Material":
					//to fill the estado material description in to the cboestmat control
					SICALNet.BusinessLogicLayer.EstadoMaterial BLLEstMat=new SICALNet.BusinessLogicLayer.EstadoMaterial();
					RsEquals=(IList) BLLEstMat.SelectEstadoMaterial();
					sTextFld= "Descripcion";
					svalFld= "IdEstadoMaterial";
					break;
				case "Familia Producto":
					//to fill the familia producto's description into the cbofampdt control
					SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
					RsEquals=(IList) BLLFampdt.SelectFamiliaProducto();
					sTextFld= "Descripcion";
					svalFld= "IdFamiliaProductos";
					break;
				case "Linea Base":
					//to fill the familia producto's description into the cbofampdt control
					SICALNet.BusinessLogicLayer.LineaProduccion BLLLineaProd =new SICALNet.BusinessLogicLayer.LineaProduccion();
					SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
					theUser  = BLLUser.Load(theUser);
					RsEquals=(IList) BLLLineaProd.SelectLinePdt(theUser);
					sTextFld= "Description";
					svalFld= "IdLinea";
					break;
				default:
					break;
			}
			if (RsEquals != null)
				prcFillCombo(cboEquals,sTextFld,svalFld,RsEquals,sCurval);
		}

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdFindMaterial_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.EditItem)
				{  
					prcFillCharCbo((DropDownList) e.Item.FindControl("cboChar"));
					DropDownList cboEqual = (DropDownList) e.Item.FindControl("cboEqual");
					prcFillEqualCbo(cboEqual,sCharCurText,sEqualCurText);
				}
			}
			catch (Exception errHand)
			{
				String error = errHand.Message;
					//Session["errMsg"]=errHand.HandleException("Structure","FormAditivos",errHand,Server.MapPath(".."),errHand.Message);
			}
		}

		private void MakeDataSet(string sChar,string sEqual,int iIdx,string sIdEqual)
		{
			// Create a DataSet.
			dsMaterial  = new DataSet("dsMaterial");
			//Create two DataTables.
			DataTable dtMaterial = new DataTable("Material");
			//Create two columns, and add them to the first table.
			DataColumn dcChar = new DataColumn("Characteristic"); 
			DataColumn dcEqual = new DataColumn("Equal"); 
			DataColumn dcIdEqual = new DataColumn("IdEqual"); 

			//assign the datacolum into datatable
			dtMaterial.Columns.Add(dcChar);
			dtMaterial.Columns.Add(dcEqual);
			dtMaterial.Columns.Add(dcIdEqual);

			//Add the tables to the DataSet.
			dsMaterial.Tables.Add(dtMaterial);
			//Populates the tables., 
			for(int iLoop=0;iLoop<=dgdFindMaterial.Items.Count;iLoop++)
			{
				if (iLoop<dgdFindMaterial.Items.Count && dgdFindMaterial.EditItemIndex == iLoop && sChar != "Delete" && sEqual != "Delete")
				{
					DataRow drMaterial = dtMaterial.NewRow();
					drMaterial["Characteristic"]=sChar;
					drMaterial["Equal"]=sEqual;
					drMaterial["IdEqual"]=sIdEqual;
					//to add data into datatable
					dtMaterial.Rows.Add(drMaterial);
				}
				else if (iLoop<dgdFindMaterial.Items.Count)
				{
					if (sChar == "Delete" && sEqual == "Delete" && iLoop == iIdx)
						iIdx = -1;
					else
					{
						DataRow drMaterial = dtMaterial.NewRow();
						drMaterial["Characteristic"]=((Label)dgdFindMaterial.Items[iLoop].Cells[0].FindControl("lblChar")).Text;
						drMaterial["Equal"]=((Label)dgdFindMaterial.Items[iLoop].Cells[1].FindControl("lblEqual")).Text;
						drMaterial["IdEqual"]=((Label)dgdFindMaterial.Items[iLoop].Cells[0].FindControl("lblIdEqual")).Text;
						//to add data into datatable
						dtMaterial.Rows.Add(drMaterial);
					}
				}
			}
			if (dgdFindMaterial.Items.Count == iIdx)
			{
				DataRow drMaterial = dtMaterial.NewRow();
				drMaterial["Characteristic"]=string.Empty;
				drMaterial["Equal"]=string.Empty;
				drMaterial["IdEqual"]=string.Empty;
				//to add data into datatable
				dtMaterial.Rows.Add(drMaterial);
			}
			dgdFindMaterial.EditItemIndex=iIdx;
			dgdFindMaterial.DataSource=dsMaterial;
			dgdFindMaterial.DataMember="Material";
			dgdFindMaterial.DataBind();
		}

		private void dgdFindMaterial_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Find" && dgdFindMaterial.EditItemIndex == -1)
			{
				string sChar=string.Empty;
				string sEqual=string.Empty;
				//string sQry=string.Empty;
				string sIdEqual=string.Empty;

				int IdEstadoMaterial = 0;;
				int IdFamiliaProducto = 0;;
				string IdColor = string.Empty;
				int IdMedida = 0;
				string IdEspesor = string.Empty;
				int IdMercado = 0;
				string IdPresentacion = string.Empty;
				int IdAcabado= 0;
				int IdEstadoProducto = 0;
				int IdLineaBase=0;
				int VersionAditivos=0;

				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder sCriteria = new System.Text.StringBuilder();
				//				string sCriteria =string.Empty;

				for(int iLoop=0;iLoop < dgdFindMaterial.Items.Count; iLoop++)
				{
					sChar = ((Label)dgdFindMaterial.Items[iLoop].Cells[1].FindControl("lblChar")).Text;
					sIdEqual = ((Label)dgdFindMaterial.Items[iLoop].Cells[2].FindControl("lblEqual")).Text;
					sEqual = ((Label)dgdFindMaterial.Items[iLoop].Cells[0].FindControl("lblIdEqual")).Text;
					switch(sChar)
					{
						case "Color":
							IdColor = sEqual;
							sCriteria.Append("Color=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Color="+sIdEqual+" + ";
							break;
						case "Medida":
							IdMedida = Convert.ToInt32(sEqual.Trim());
							sCriteria.Append("Medida=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Medida="+sIdEqual+" + ";
							break;
						case "Espesor":
							IdEspesor = sEqual;
							sCriteria.Append("Espesor=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Espesor="+sIdEqual+" + ";
							break;
						case "Mercado":
							IdMercado = Convert.ToInt32(sEqual);
							sCriteria.Append("Mercado=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Mercado="+sIdEqual+" + ";
							break;
						case "Presentacion":
							IdPresentacion = sEqual;
							sCriteria.Append("Presentacion=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Presentacion="+sIdEqual+" + ";
							break;
						case "Acabado":
							IdAcabado = Convert.ToInt32(sEqual);
							sCriteria.Append("Acabado=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Acabado="+sIdEqual+" + ";
							break;
						case "Estado Producto":
							IdEstadoProducto = Convert.ToInt32(sEqual);
							sCriteria.Append("Estado Producto=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Estado Producto="+sIdEqual+" + ";
							break;
						case "Estado Material":
							IdEstadoMaterial = Convert.ToInt32(sEqual);
							sCriteria.Append("Estado Material=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Estado Material="+sIdEqual+" + ";
							break;
						case "Familia Producto":
							IdFamiliaProducto = Convert.ToInt32(sEqual);
							sCriteria.Append("Familia Producto=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Familia Producto="+sIdEqual+" + ";
							break;
						case "Linea Base":
							IdLineaBase = Convert.ToInt32(sEqual);
							sCriteria.Append("Linea Base=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Linea Base="+sIdEqual+" + ";
							break;
						case "Versión Aditivos":
							VersionAditivos = Convert.ToInt32(sEqual);
							sCriteria.Append("Versión Aditivos=").Append(sIdEqual).Append(" + ");
							//							sCriteria += "Versión Aditivos="+sIdEqual+" + ";
							break;
						default:
							break;
					}
				}
				string Planta = Request["idPlanta"];
				int idPlanta=1;
				if (Planta != null)
				{
					if(Planta!="")
						idPlanta = Convert.ToInt32(Planta); 
				}
				MaterialInfo BEMatInfo= new MaterialInfo(string.Empty,string.Empty,IdEstadoMaterial,IdColor,IdMedida,IdEspesor,IdMercado,IdPresentacion,IdAcabado,IdEstadoProducto,IdFamiliaProducto,IdLineaBase,VersionAditivos,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Material BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
				// to Call the Select method
				IList RsMaterial= (IList)BLLMaterial.FindMaterial(BEMatInfo);
				//to assign the result set into datagrid
				dgdMaterial.Visible=true;
				dgdMaterial.DataSource = RsMaterial;
				//to fill the datagrid
				dgdMaterial.DataBind();
				//				if (sCriteria.Length>3)
				//					sCriteria=sCriteria.Substring(0,sCriteria.Length-3);

				if (dgdMaterial.Items.Count > 0)
				{
					cmdDone.Visible=true;	
				}
				//					btnActualizar.Visible = true;
				//					btnInterface.Visible = true;
				//					btnCancelar.Visible = true;
				//					btnCSV.Visible = true;
				//					cboPlanta.Visible=true;
				//
				//					LoadPlantaInfo();
				//				}
				
				//				if (RsMaterial.Count > 0)
				//				{
				//					dgdMaterial.Visible=true;
				//					lblCriteria.Visible=true;
				//					lblCriteria.Text = string.Format("Criterio de búsqueda : {0}",sCriteria); 
				//				}
				//				else
				//					lblCriteria.Text = string.Format("No se encontraron materiales para el criterio de búsqueda: {0}",sCriteria); 
			}
			else if (e.CommandName == "Plus" && dgdFindMaterial.EditItemIndex == -1)
			{
				MakeDataSet(string.Empty,string.Empty,(int) dgdFindMaterial.Items.Count,string.Empty);
			}
			else if (e.CommandName == "CancelFind")
			{
				//	this.Visible=false;
				string strScript1="<script>";
				strScript1+= "window.close();";
				strScript1+=  "</script>";
				Page.RegisterStartupScript("ClientScript1", strScript1);
			}
		}

//		private void LoadPlantaInfo()
//		{
//			SICALNet.BusinessLogicLayer.Planta plantBLL = new SICALNet.BusinessLogicLayer.Planta();
//			cboPlanta.DataSource=plantBLL.SelectPlanta();
//			cboPlanta.DataTextField="Description";
//			cboPlanta.DataValueField="IdPlanta";
//			cboPlanta.DataBind();
//		}

		private void dgdFindMaterial_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			MakeDataSet("Delete","Delete",(int)e.Item.ItemIndex,"Delete");
		}

		private void dgdFindMaterial_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sTmpChar = ((Label)dgdFindMaterial.Items[e.Item.ItemIndex].Cells[0].FindControl("lblCharCancel")).Text;
			string sTmpEqual = ((Label)dgdFindMaterial.Items[e.Item.ItemIndex].Cells[0].FindControl("lblEqualCancel")).Text;
			string sTmpIdEqual = ((Label)dgdFindMaterial.Items[e.Item.ItemIndex].Cells[0].FindControl("lblIdEqual")).Text;
			if (sTmpChar == string.Empty && sTmpEqual == string.Empty)	
				MakeDataSet("Delete","Delete",(int)e.Item.ItemIndex,"Delete");
			else
				MakeDataSet(sTmpChar,sTmpEqual,-1,sTmpIdEqual);
		}

		private void dgdFindMaterial_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sChar = ((DropDownList) e.Item.FindControl("cboChar")).SelectedItem.Text;
			string sEqual = ((DropDownList) e.Item.FindControl("cboEqual")).SelectedItem.Text;
			string sIdEqual = ((DropDownList) e.Item.FindControl("cboEqual")).SelectedItem.Value;
			if (sChar != string.Empty && sEqual != string.Empty)
				MakeDataSet(sChar,sEqual,-1,sIdEqual);
		}

		private void dgdFindMaterial_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			sCharCurText = ((Label)e.Item.FindControl("lblChar")).Text;
			sEqualCurText = ((Label)e.Item.FindControl("lblEqual")).Text;
			sIdEqualCurText = ((Label)e.Item.FindControl("lblIdEqual")).Text;
			ToSetEditMode(sCharCurText,sEqualCurText,(int) e.Item.ItemIndex,sIdEqualCurText);
		}

//		private void dgdMaterial_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
//		{
//			//txtCodigo.Text = string.Empty;
//
//			if (e.Item.BackColor == Color.LemonChiffon)
//				e.Item.BackColor = Color.White;
//			else
//			{
//			//	txtCodigo.Text=((Label)e.Item.FindControl("lblCodigo")).Text;
//				e.Item.BackColor = Color.LemonChiffon;
//			}
//			//this.Visible=false;		
//			//string ScriptString="<script language='javascript'>FormMaterial.submit();</script>"; 
//			//Page.RegisterStartupScript("StartUp",ScriptString); 
//		}

		public void prcClear()
		{
			dgdFindMaterial.DataSource=null;
			dgdFindMaterial.DataBind();
			MakeDataSet(string.Empty,string.Empty,0,string.Empty);
			//dgdMaterial.Visible=false;
			//lblCriteria.Visible=false;
		}

		private void cmdDone_Click(object sender, System.EventArgs e)
		{
		
			try
			{
				//ArrayList arrCadigoSAP = new ArrayList();
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder strCadigoSAP = new System.Text.StringBuilder();
//				string strCadigoSAP=string.Empty;
				if (dgdMaterial.Items.Count>0 )
				{
					for (int i=0; i < dgdMaterial.Items.Count; i++)
					{
						if (((CheckBox)dgdMaterial.Items[i].FindControl("chkSelect")).Checked)
						{
							strCadigoSAP.AppendFormat("{0},",((Label)dgdMaterial.Items[i].FindControl("lblCodigo")).Text.ToString());
//							strCadigoSAP += string.Format("{0},",((Label)dgdMaterial.Items[i].FindControl("lblCodigo")).Text.ToString());
							/*** fin modificación ***/
						}
					}

					strCadigoSAP=strCadigoSAP.Remove(strCadigoSAP.Length-1,1);

					//Session["CodigoSAPsFromPopup"] = arrCadigoSAP;
					string strScript1="<script>";
					strScript1+= "window.opener.document.forms(\"";
					strScript1+=	Request.QueryString["FormName"].ToString();
					strScript1+= "\").elements(\"";
					strScript1+= Request.QueryString["CtrlName"].ToString();
					strScript1+=	"\").value='";
					strScript1+= strCadigoSAP.ToString()+"';";

					strScript1+= "window.opener.document.forms(\"";
					strScript1+=	Request.QueryString["FormName"].ToString();
					strScript1+= "\").submit();";
 
					strScript1+= "window.close();";
					strScript1+=  "</script>";
					Page.RegisterStartupScript("ClientScript1", strScript1);
					//document.forms[0].btnSecuencia.click()
					//parentPage.AddMaterial(strCadigoSAP);
					//Server.Transfer("UpdateMaterialList.aspx");
				}

			}

			catch 
			{
				throw;
				//Page.RegisterStartupScript("ClientScript","<script language=JavaScript> alert('" + ex.Message + "') </script>");
			}

		}
		
		public void CheckAll(object sender, System.EventArgs e)
		{
			for(int i=0;i<dgdMaterial.Items.Count; i++)
			{
				((CheckBox)dgdMaterial.Items[i].FindControl("chkSelect")).Checked = ((CheckBox)sender).Checked;
			}
		}

		private void dgdFindMaterial_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
	}
}
