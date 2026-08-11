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
	/// Summary description for FormTemperatura.
	/// </summary>
	public class FormTemperatura : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboFamPdt;
		protected System.Web.UI.WebControls.DropDownList cboEspesor;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.TextBox txtTimeC;
		protected System.Web.UI.WebControls.TextBox txtTempC;
		protected System.Web.UI.WebControls.Button AddFrmTemp;
		protected System.Web.UI.WebControls.TextBox txtTimePC;
		protected System.Web.UI.WebControls.TextBox txtTempPc;
		protected System.Web.UI.WebControls.Button cmdCancelC;

		protected Controls.FormTemparaturaGrid FrmTempGridControl;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		ErrorHandling ExpHand=new ErrorHandling();
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
					theUser  = BLLUser.Load(theUser);

					//to fill the espesor into the cboEspesor control
					Espesor BLLEsp=new Espesor();
					IList RsEsp=(IList) BLLEsp.LoadEspesor();
					prcFillCombo(cboEspesor,"Centimetros","IdEspesor",RsEsp);
					//to fill the familia producto's description into the cbofampdt control
					FamiliaProducto BLLFampdt=new FamiliaProducto();
					IList RsFampdt=(IList) BLLFampdt.SelectFamiliaProducto();
					prcFillCombo(cboFamPdt,"Descripcion","IdFamiliaProductos",RsFampdt);
					//to fill the Linea description into the cboLinea control
					LineaProduccion BLLLine=new LineaProduccion();
					IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
					prcFillCombo(cboLinea,"Description","IdLinea",RsLine);

					FrmTempGridControl.BindGrid(checkpermisions());

				}
			}
			catch
			{
				throw;
			}
		}


		private Boolean checkpermisions()
		{
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo = new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);
			SICALNet.BusinessLogicLayer.Usuario objUsuario = new SICALNet.BusinessLogicLayer.Usuario();
			SICALNet.BusinessEntities.UsuarioInfo objUser = objUsuario.Load(objUsuarioInfo);

			PermisoPerfilInfo ppInfo = new PermisoPerfilInfo (objUser.IdPerfil,string.Empty,0);
			PermisoPerfil bllInfo = new PermisoPerfil();
			IList currentPermissionsList=bllInfo.Load(ppInfo);
			
			for (int i=0;i<currentPermissionsList.Count;i++)
			{
				ppInfo = (PermisoPerfilInfo) currentPermissionsList[i];
				
				if (ppInfo.IdModulo.IndexOf("3.")>=0)
				{
					if (ppInfo.IdModulo == "3.11") 
					{
						if (ppInfo.IdPermiso == 1)
						{
							BlockControlsToEdit(true);
							return true;
						}
						
						if (ppInfo.IdPermiso == 3)
						{
							BlockControlsToEdit(false);
							return false;
						}
					}
				}
			}
			return true;
			
		}

		private void BlockControlsToEdit(Boolean Activar)
		{
		
			tableNewComponents.Visible = Activar;
			
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
			this.AddFrmTemp.Click += new System.EventHandler(this.AddFrmTemp_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{
			FrmTempClear();
		}

		private void AddFrmTemp_Click(object sender, System.EventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtFrmTemp = new Validation();

//				if (FrmTempGridControl.funGetCurrentRow() > 0)
//					throw new Exception("You are in the Edit Mode. Please cancel the edit mode");

				//to check colorid whether its correct or not
				if (vdtFrmTemp.IsInteger(txtTimeC.Text)==false)
					throw new Exception("Tiempo de Curado should be an Integer number");
				if (vdtFrmTemp.IsInteger(txtTimePC.Text)==false)
					throw new Exception("Tiempo de Post Curado should be an Integer number");
			
				//to check colorid whether its correct or not
				if (vdtFrmTemp.IsPositiveNumber(txtTempC.Text)==false)
					throw new Exception("Temp de Curado should be a Postive Real number");
				if (vdtFrmTemp.IsPositiveNumber(txtTempPc.Text)==false)
					throw new Exception("Temp de Post Curado should be a Positive Real number");

				//to assign the control box values into variables
				int IdFamPdt = Convert.ToInt32(cboFamPdt.SelectedItem.Value);
				string IdEspesor = cboEspesor.SelectedItem.Value;
				int IdLinea = Convert.ToInt32(cboLinea.SelectedItem.Value);

				int TimepoC=(int)Convert.ToInt32(txtTimeC.Text);
				int TiempoPC=(int)Convert.ToInt32(txtTimePC.Text);

				float TempC=(float)Convert.ToSingle(txtTempC.Text);
				float TempPC=(float)Convert.ToSingle(txtTempPc.Text);

				//to assign the form temparatura info into business entity lager
				FormTemperaturaInfo BEFrmTemp= new FormTemperaturaInfo (IdFamPdt,IdEspesor,IdLinea,TimepoC,TempC,TiempoPC,TempPC);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.FormTemperatura BLLFrmTemp= new SICALNet.BusinessLogicLayer.FormTemperatura();
				//to Call the Insert FormCintas method
				BLLFrmTemp.InsertFormTemperatura(BEFrmTemp);
				//to fill the datagrid
				FrmTempGridControl.BindGrid(checkpermisions());
				//to clear all the textbox values
				FrmTempClear();
				throw new Exception("Saved Successfully");
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				//to display the msg for user
				/*** modificado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
				string ScriptString="<script language='javascript'>alert('["+ errHand.Number + "]El ID Identificador ya esta siendo usado');</script>"; 
//				string ScriptString="<script language='javascript'>alert('El ID Identificador ya esta siendo usado');</script>"; 
				/*** fin modificación ***/

				Page.RegisterStartupScript("ClientScript",ScriptString);
				// se quita la siguente linea para que sea desplegado el mensaje
				//throw;
			}
			catch
			{
				// alta correcta
				//throw;
				string ScriptString="<script language='javascript'>alert('Alta de temperatura correcta');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
		}

		private void FrmTempClear()
		{
			txtTimeC.Text=string.Empty;
			txtTimePC.Text=string.Empty;
			txtTempC.Text=string.Empty;
			txtTempPc.Text=string.Empty;
		}

//		private void chkMode()
//		{
//			if (txtTimeC.Text.Trim() != string.Empty || txtTimePC.Text.Trim() != string.Empty || txtTempC.Text.Trim() != string.Empty || txtTempPc.Text.Trim() != string.Empty)
//				Session["opMode"]="Insert";
//			else
//				Session["opMode"]=string.Empty;
//		}
	}
}
