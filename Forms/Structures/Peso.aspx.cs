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
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for Users.
	/// </summary>
	public class Peso : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.DropDownList cboEspesorFiltro;
		protected System.Web.UI.WebControls.Label lblMedida;
		protected System.Web.UI.WebControls.DropDownList cboMedidaFiltro;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.Button cmdBuscar;
		protected System.Web.UI.WebControls.DropDownList cboPlantaFiltro;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Button AddPeso;
		protected System.Web.UI.WebControls.CheckBox chkActivo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtElaboro;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtTolerancia;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtKilos;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtRevision;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.DropDownList cboEspesor;
		protected System.Web.UI.WebControls.DropDownList cboMedida;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label lblRevision;
		protected System.Web.UI.WebControls.TextBox txtRevisionFiltro;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.HtmlControls.HtmlTable tableComponents;
		protected Controls.PesosGrid PesosGridControl;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				BindEntryFields();
				checkpermisions();
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
			this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
			this.AddPeso.Click += new System.EventHandler(this.AddPeso_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


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
					if (ppInfo.IdModulo == "3.5") 
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

		private void BindEntryFields()
		{
			//Code to populate Medida Combo Box
			SICALNet.BusinessLogicLayer.Medida Medida = new SICALNet.BusinessLogicLayer.Medida();
			IList MedidaList = (IList) Medida.LoadMedida();
			
			cboMedida.DataSource = MedidaList;
			cboMedida.DataValueField = "IdMedida";
			cboMedida.DataTextField = "Centimetros";
			cboMedida.DataBind();

			//Code to populate Espesor Combo Box
			SICALNet.BusinessLogicLayer.Espesor Espesor = new SICALNet.BusinessLogicLayer.Espesor();
			IList EspesorList = (IList) Espesor.LoadEspesor();
			
			cboEspesor.DataSource = EspesorList;
			cboEspesor.DataValueField = "IdEspesor";
			cboEspesor.DataTextField = "Centimetros";
			cboEspesor.DataBind();

			//Code to populate Planta Combo box
			SICALNet.BusinessLogicLayer.Planta Plant = new SICALNet.BusinessLogicLayer.Planta();
			IList PlantaList = (IList) Plant.SelectPlanta();
			
			cboPlanta.DataSource = PlantaList;
			cboPlanta.DataValueField = "IdPlanta";
			cboPlanta.DataTextField = "Description";
			cboPlanta.DataBind();

			/*
			 * Modification Description:
			 *	Populate combos to filter data query
			 * Autor:
			 *	Ing. Ariel Martínez Morales
			 * Date:
			 *	26-07-2005
			 */
			//Begin Modification
			this.cboMedidaFiltro.DataSource = MedidaList;
			this.cboMedidaFiltro.DataValueField = "IdMedida";
			this.cboMedidaFiltro.DataTextField = "Centimetros";
			this.cboMedidaFiltro.DataBind();
			this.cboMedidaFiltro.Items.Add( new ListItem("--Seleccione una Medida--",""));
			this.cboMedidaFiltro.SelectedIndex = this.cboMedidaFiltro.Items.Count-1;

			this.cboEspesorFiltro.DataSource = EspesorList;
			this.cboEspesorFiltro.DataValueField = "IdEspesor";
			this.cboEspesorFiltro.DataTextField = "Centimetros";
			this.cboEspesorFiltro.DataBind();
			this.cboEspesorFiltro.Items.Add( new ListItem("--Seleccione un Espesor--",""));
			this.cboEspesorFiltro.SelectedIndex = this.cboEspesorFiltro.Items.Count-1;

			this.cboPlantaFiltro.DataSource = PlantaList;
			this.cboPlantaFiltro.DataValueField = "IdPlanta";
			this.cboPlantaFiltro.DataTextField = "Description";
			this.cboPlantaFiltro.DataBind();
			this.cboPlantaFiltro.Items.Add( new ListItem("--Seleccione una Planta--",""));
			this.cboPlantaFiltro.SelectedIndex = this.cboPlantaFiltro.Items.Count-1;
			//End Modification
		}

//		//to display the error msg in the label box and write the error the error msg into error log file
//		private void prcErrorDisplay(Exception errHnd,string errStatus)
//		{
//			if (errStatus=="Error")
//			{
//				//to display the error msg
//				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
//				lblErrorMsg.Text=errHnd.Message;
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Red;
//			}
//			else if (errStatus=="NoError")
//			{
//				//to clear label box
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.White;
//			}
//			else
//			{
//				//to display the success msg
//				lblErrorMsg.Text=errStatus;
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Green;
//			}
//
//			return;
//		}

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
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
		
//		private void cmdCancelC_Click(object sender, System.EventArgs e)
//		{
//			//lblErrorMsg.Text = cboPlanta.SelectedItem.Text + ":" + cboPlanta.SelectedItem.Value;
//			//cboFamiliaProducto.SelectedIndex = 0;
//			cboMedida.SelectedIndex = 0;
//			cboEspesor.SelectedIndex = 0;
//			//cboLinea.SelectedIndex = 0;
//			cboPlanta.SelectedIndex = 0;
//			txtKilos.Text = string.Empty;
//			txtTolerancia.Text = string.Empty;
//			txtElaboro.Text = string.Empty;
//			txtRevision.Text = string.Empty;
//		}

		private void AddPeso_Click(object sender, System.EventArgs e)
		{
			//Validation pltVdlt = new Validation();

//			int IdFamiliaProductos;
//			int IdLinea;
			int IdMedida;
			string IdEspesor;
			int IdPlanta;
			decimal Kilos;
			decimal Tolerancia;
			string Elaboro;
			int Revision;
			bool Activo;
			

			//UserInterface Validations

//			// to check FamiliaProductos List whether its Empty or not
//			try {IdFamiliaProductos = Convert.ToInt32(cboFamiliaProducto.SelectedItem.Value);}
//			catch
//			{
//				throw new Exception("Debe seleccionar la familia de productos");
//			}

			// to check Medida List whether its Empty or Not
			try {IdMedida = Convert.ToInt32(cboMedida.SelectedItem.Value);}
			catch
			{
				throw new Exception("Debe seleccionar una medida valida");
			}

			// to check Espesor List whether its Empty or Not
			try {IdEspesor = cboEspesor.SelectedItem.Value;}
			catch
			{
				throw new Exception("Debe seleccionar un espesor valido");
			}

//			// to check Linea List whether its Empty or Not
//			try {IdLinea = Convert.ToInt32(cboLinea.SelectedItem.Value);}
//			catch
//			{
//				throw new Exception("Debe seleccionar una línea de producción valida");
//			}
			
			// to check Planta List whether its Empty or not
			try {IdPlanta = Convert.ToInt32(cboPlanta.SelectedItem.Value);}
			catch
			{
				throw new Exception("Debe seleccionar una planta valida");
			}
			
			try {Kilos = Convert.ToDecimal(txtKilos.Text.Trim());}
			catch
			{
				prcErrorDisplay(null, "La cantidad en kilos debe ser un dato numerico","Warning");
				return;
			}

			try {Tolerancia = Convert.ToDecimal(txtTolerancia.Text.Trim());}
			catch
			{
				prcErrorDisplay(null, "La tolerancia dede ser un dato numerico","Warning");
				return;
			}

			if (txtElaboro.Text == String.Empty)
			{
				prcErrorDisplay(null, "Debe capturar el nombre de la persona que elaboró formulación","Warning");
				return;
			}

			try {Revision = Convert.ToInt32(txtRevision.Text);}
			catch
			{
				prcErrorDisplay(null, "Debe capturar la revisión y debe ser un dato numerico","Warning");
				return;
			}

			try
			{
//				IdFamiliaProductos = Convert.ToInt32(cboFamiliaProducto.SelectedItem.Value);
//				IdLinea   = Convert.ToInt32(cboLinea.SelectedItem.Value);
				IdMedida  = Convert.ToInt32(cboMedida.SelectedItem.Value);
				IdEspesor = cboEspesor.SelectedItem.Value;
				IdPlanta  = Convert.ToInt32(cboPlanta.SelectedItem.Value);
			
				Kilos = Convert.ToDecimal(txtKilos.Text.Trim());
				Tolerancia = Convert.ToDecimal(txtTolerancia.Text.Trim());
				Elaboro = txtElaboro.Text.Trim();
				Revision = Convert.ToInt32(txtRevision.Text.Trim());

				Activo = chkActivo.Checked;

				PesoInfo pInfo = new PesoInfo(IdMedida, string.Empty, IdEspesor, 0,IdPlanta, string.Empty, Kilos, Tolerancia, Elaboro, Revision, Activo);
				SICALNet.BusinessLogicLayer.Peso Peso = new SICALNet.BusinessLogicLayer.Peso();
				Peso.InsertPeso(pInfo);			
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nuevo peso: " + cboMedida.SelectedItem.Text  + " kilos: " + Kilos + " elaboro: " + Elaboro,this.User.Identity.Name.ToString());

				
				
				//Initialize WUC properties
				this.PesosGridControl.IdMedida = int.Parse( this.cboMedidaFiltro.SelectedValue.Length>0?this.cboMedidaFiltro.SelectedValue:"-1");
				this.PesosGridControl.IdEspesor = this.cboEspesorFiltro.SelectedValue;
				this.PesosGridControl.IdPlanta = int.Parse( this.cboPlantaFiltro.SelectedValue.Length>0?this.cboPlantaFiltro.SelectedValue:"-1");
				this.PesosGridControl.Revision = int.Parse( this.txtRevisionFiltro.Text.Length>0?this.txtRevisionFiltro.Text:"-1");
				//Bind WUC Data
				PesosGridControl.BindGrid(checkpermisions());
				prcErrorDisplay(null, "Se insertó correctamente el registro","Success");

			}			
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}		

			txtKilos.Text=""; txtTolerancia.Text=""; txtElaboro.Text=""; txtRevision.Text="";
		}

		private void cmdBuscar_Click(object sender, System.EventArgs e)
		{
			//Initialize WUC properties
			this.PesosGridControl.IdMedida = int.Parse( this.cboMedidaFiltro.SelectedValue.Length>0?this.cboMedidaFiltro.SelectedValue:"-1");
			this.PesosGridControl.IdEspesor = this.cboEspesorFiltro.SelectedValue;
			this.PesosGridControl.IdPlanta = int.Parse( this.cboPlantaFiltro.SelectedValue.Length>0?this.cboPlantaFiltro.SelectedValue:"-1");
			this.PesosGridControl.Revision = int.Parse( this.txtRevisionFiltro.Text.Length>0?this.txtRevisionFiltro.Text:"-1");
			//Bind WUC Data
			this.PesosGridControl.BindGrid(checkpermisions());
			this.tableComponents.Visible=true;
		}
	}
}
