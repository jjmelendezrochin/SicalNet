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
	/// Summary description for Plant.
	/// </summary>
	public class ColourForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtColourId;
		protected System.Web.UI.WebControls.Button AddColour;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected Controls.ColourGrid ColourGridControl;
		protected System.Web.UI.WebControls.CheckBox chkTransparente;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtIdExportacion;
		protected System.Web.UI.WebControls.DropDownList cboIdEspesor;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;

		ErrorHandling ExpHand=new ErrorHandling();

		private void txtColourId_TextChanged(object sender, System.EventArgs e)
		{
			if (txtColourId.Text != string.Empty)
				Session["opMode"]="Insert";
			else
				Session["opMode"]=string.Empty;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					// Put user code to initialize the page here
					SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
					IList RsEspesor=(IList) BLLEspesor.LoadEspesor();
					cboIdEspesor.DataSource=RsEspesor;
					cboIdEspesor.DataTextField="Centimetros";
					cboIdEspesor.DataValueField="IdEspesor";
					cboIdEspesor.DataBind();
				}
				Session["errMsg"]=string.Empty;
			}
			catch(Exception errHand)
			{
				Session["errMsg"]=ExpHand.HandleException("Structure","FormAditivos",errHand,Server.MapPath(".."),errHand.Message);
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
			this.txtColourId.TextChanged += new System.EventHandler(this.txtColourId_TextChanged);
			this.AddColour.Click += new System.EventHandler(this.AddColour_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.ID = "ColourForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddColour_Click(object sender, System.EventArgs e)
		{
			try
			{
				//to get an instance from validation
				//Validation vdtColour = new Validation();

//				if (Session["opMode"] == "Edit")
//					throw new Exception("You are in the Edit Mode. Please cancel the edit mode");

				//to check colorid whether its correct or not
				//if ((vdtColour.IsAlphaNumeric(txtColourId.Text)==false) || (txtColourId.Text==""))
				if(txtColourId.Text.Trim() == string.Empty)
				{
					lblErrorMsg.Text = "Debe capturar un identificador para el color";
					return;
				}
					//throw new Exception("Color ID should be Alpha Numeric and Not Empty");
				//to check the description whether its correct or not
				//if ((vdtColour.IsAlphaNumeric(txtDescripcion.Text)==false) || (txtDescripcion.Text==""))
				if(txtDescripcion.Text.Trim() == string.Empty)
				{
					lblErrorMsg.Text = "Debe capturar la descripción del color";
					return;
				}
					//throw new Exception("Description should be Alpha Numeric and Not Empty");

				//to assign the control box values into variables
				string IdColour = txtColourId.Text.Trim();
				string Descripcion = txtDescripcion.Text.Trim();
				string IdExport= txtIdExportacion.Text.Trim();
				string IdEspesor=cboIdEspesor.SelectedItem.Value;
				bool blnTransparente = chkTransparente.Checked;
				//FALTA TRANSPARENTE - FRM

				//to assign the color info into business entity lager
				ColourInfo BEColour= new ColourInfo(IdColour,IdExport,Descripcion,IdEspesor,blnTransparente); //FRM

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.Colour BLLColour= new SICALNet.BusinessLogicLayer.Colour();
				//to Call the Insert Colour method
				BLLColour.InsertColour(BEColour);
			
				// alta de color en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de color: " + BEColour.IdColour + " descripcion: " + BEColour.Descripcion,this.User.Identity.Name.ToString());


				//to fill the datagrid
				ColourGridControl.BindGrid();

				FormAditClear();
				Session["opMode"]=string.Empty;
				lblErrorMsg.Text = "El color fue dado de alta en el catalogo exitosamente";
			}
			catch(System.Data.SqlClient.SqlException)
			{
				lblErrorMsg.Text = "Este identificador de color ya esta en uso actualmente";
								
			}
			catch
			{				
				throw;
			}
		}

		private void FormAditClear()
		{
			txtColourId.Text=string.Empty;
			txtDescripcion.Text=string.Empty;
			txtIdExportacion.Text=string.Empty;
			cboIdEspesor.SelectedIndex=0;
			chkTransparente.Checked = false;
		}


		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{
			Session["opMode"]=string.Empty;
			FormAditClear();
//			Response.Redirect("../Menu.Aspx",true);
		}
	}
}