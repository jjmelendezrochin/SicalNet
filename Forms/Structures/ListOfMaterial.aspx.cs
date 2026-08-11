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
using SICALNet.Utilities;
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for ListOfMaterial.
	/// </summary>
	///
	
	public class ListOfMaterial : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboUnidad;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.TextBox txtSAPHijo;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcionHijo;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAPHijo;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected Controls.ListofMaterialGrid LstMatGrid;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button AddLstMat;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
	
		ErrorHandling ExpHand=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindEntryFields();
			}
			// Put user code to initialize the page here
		}

		
		private void BindEntryFields()
		{
			try
			{
				//Load the Unit of Measure.
				SICALNet.BusinessLogicLayer.Planta BLLPlant=new SICALNet.BusinessLogicLayer.Planta();
				IList RsPlanta=(IList) BLLPlant.SelectPlanta();
				prcFillCombo(cboPlanta,"Description","IdPlanta",RsPlanta);

				//Load the Plants Catalog.
				//to fill the Unidad description into the cboUnidad control
				SICALNet.BusinessLogicLayer.Unidad BLLUnidad=new SICALNet.BusinessLogicLayer.Unidad();
				IList RsUnidad=(IList) BLLUnidad.SelectUnidad();
				prcFillCombo(cboUnidad,"Descripcion","IdUnidad",RsUnidad);
				Session["idplantae"]=1;
			}			
			catch
			{
				// Session["errMsg"]=ExpHand.HandleException("Structure","FormCintas",errHand,Server.MapPath(".."),errHand.Message);

				throw;
			}
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
		private void InitializeComponent()
		{    
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.imgbtnFind.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnFind_Click);
			this.txtCodigoSAPHijo.TextChanged += new System.EventHandler(this.txtCodigoSAPHijo_TextChanged);
			this.imgbtnFind1.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnFind1_Click);
			this.cboPlanta.SelectedIndexChanged += new System.EventHandler(this.cboPlanta_SelectedIndexChanged);
			this.AddLstMat.Click += new System.EventHandler(this.AddLstMat_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddLstMat_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ValidateMaterialList())
				{
					SaveMaterialList();
					txtCodigoSAP.Text=string.Empty;
					txtCodigoSAPHijo.Text=string.Empty;
					txtDescripcion.Text=string.Empty;
					txtDescripcionHijo.Text=string.Empty;
					txtCantidad.Text=string.Empty;
				}
			}
			//catch(System.Data.SqlClient.SqlException errHand)
			catch
			{
				lblErrorMsg.Text="Ya existe una formulación de color para el material seleccionado";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;				
			}
//			catch
//			{
//				throw;
//			}
		}

		private bool ValidateMaterialList()
		{
			//to get an instance from validation
			Validation vdtFormCintas = new Validation();


			if (LstMatGrid.funGetCurrentRow() > 0)
			{
				prcErrorDisplay("Se encuentra en modo de edición. cancele el modo de edición para continuar","Error");
				return false;}

			//to check provided quantity 
			if (!vdtFormCintas.IsPositiveNumber(txtCantidad.Text))
			{
				prcErrorDisplay("La cantidad debe ser un número positivo","Error");
				return false;}

			//verify that the user provided the CodigoSAP
			if (txtCodigoSAP.Text.Trim() == String.Empty)
			{
				prcErrorDisplay("Debe de capturar el código SAP del material ","Error");
				return false;
			}

			//verify that the user provided the CodigoSAPHijo
			if (txtCodigoSAPHijo.Text.Trim() == String.Empty)
			{
				prcErrorDisplay("Debe de capturar el código SAP del material hijo (Formulaación de COLOR)","Error");
				return false;}

			//Verify that the provided CodigoSAP is valid
			if (txtCodigoSAP.Text.Trim() != String.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

				if (!Material.isExistMaterial(mInfo))
				{
					prcErrorDisplay("El código SAP del material no se encuentra en el catálogo de Materiales","Error");
					return false;}
			}

			//Verify that the provided CodigoSAP Hijo is valid
			if (txtCodigoSAPHijo.Text.Trim() != String.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(txtCodigoSAPHijo.Text.Trim(), String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

				if (!Material.isExistMaterial(mInfo))
				{
					prcErrorDisplay("El código SAP del material HIJO no se encuentra en el catálogo de Materiales","Error");
					return false;}
			}

			return true;
		}
		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(string strMessage,string errStatus)
		{
			switch (errStatus)
			{
				case "Error":
					//to display the error msg
					lblErrorMsg.Text=strMessage;
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ strMessage +"')"+ "<" + "/script>");
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.Red;
					break;
				case "NoError":
					//to clear label box
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.White;
					break;
				case "Success":
					//to display the success msg
					lblErrorMsg.Text=strMessage;
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.Green;
					break;
			}
		}

		private void cboPlanta_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["idplantae"]= cboPlanta.SelectedItem.Value;
			LstMatGrid.PublicMethodInUsercontrol(System.Convert.ToInt16(cboPlanta.SelectedItem.Value));
		}

		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

		private void txtCodigoSAPHijo_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAPHijo.Text.Trim();
			if (theCodigoSAP!=string.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcionHijo.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{
					MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
					SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
					material=materialBLL.SelectMaterial(material);
					txtDescripcionHijo.Text=material.Descripcion;

					prcErrorDisplay(null,string.Empty,"NoError");
				}
			}
			else
			{
				prcErrorDisplay(null,string.Empty,"NoError");			
			}				
		}

		private void SaveMaterialList()
		{
			//Assign values into variables
			string CodigoSAP=txtCodigoSAP.Text.Trim();
			string CodigoSAPHijo=txtCodigoSAPHijo.Text.Trim();
			int IdUnidad = Convert.ToInt32(cboUnidad.SelectedItem.Value);
			int IdPlanta= Convert.ToInt32(cboPlanta.SelectedItem.Value);
			float Cantidad=(float)Convert.ToDecimal(txtCantidad.Text);
			if(Cantidad<=0)
			{
				prcErrorDisplay("La cantidad debe ser mayor que cero","Error");
				return;}

			try
			{
				//to assign the color info into business entity lager
				ListMaterialInfo BEListMaterial = new ListMaterialInfo(CodigoSAP,string.Empty,CodigoSAPHijo,string.Empty,Cantidad,IdUnidad,IdPlanta,string.Empty,string.Empty);
				//to get an instance from business logic layer
				ListMaterial BLLListMaterial= new ListMaterial();
				//to Call the Insert FormCintas method
				BLLListMaterial.InsertListMaterial(BEListMaterial);
				//to fill the datagrid
				LstMatGrid.BindGrid();
			}
			catch
			{
				throw;
			}
		}

		private void imgbtnFind_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=ListMat&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
							
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
			}
		}

		private void imgbtnFind1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				txtDescripcion.Text=txtDescripcion.Text.ToString();
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=ListMat&CtrlName=txtCodigoSAPHijo&CtrlName2=txtDescripcionHijo&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");

				
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
			}
		
		}

		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
			if (theCodigoSAP!=string.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcion.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{
					MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
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
				ExpHand.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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




	}
}
