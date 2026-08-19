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
using System.Collections.Specialized;
using SICALNet.BusinessEntities;
using SICALNet.Utilities;
namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultReactionWO1.
	/// </summary>
	public class ConsultReactionWO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdTanque;
		protected System.Web.UI.WebControls.DataGrid dgdReaccion;
		protected System.Web.UI.WebControls.Label lblKg;
		protected System.Web.UI.WebControls.TextBox txtKg;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtLinea;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.Label lblTipoPrep;
		protected System.Web.UI.WebControls.DropDownList cmbTipoPMMA;
		protected System.Web.UI.WebControls.DropDownList cmbTanque;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblSpacer;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected static string currentFecha,currentLineaDesc;
		protected static int currentIdLinea,currentIdOrdenTrabajo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				btnAceptar.Attributes.Add("onClick","showWaitControls()");
				btnCancelar.Attributes.Add("onClick","showWaitControls()");
				try
				{
					// To Display Current Line & Fecha in Title
					txtLinea.Text = currentLineaDesc;
					txtFecha.Text = currentFecha.Replace(".", "").ToLower();

					// To Initialize Tanque & PartidasReaccion Grid
					BindGrid(currentIdOrdenTrabajo, currentIdLinea, currentFecha);
					//Load the combos with info
					BindEntryFields(currentIdLinea);
				}
				catch(Exception ex)
				{
					lblErrorMsg.Text=ex.Message;
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
							
			currentFecha = Request.QueryString["Fecha"].ToString();
			currentIdLinea = Convert.ToInt32(Request.QueryString["IdLinea"]);
			currentLineaDesc = Request.QueryString["LineaDesc"].ToString();
			currentIdOrdenTrabajo = Convert.ToInt32(Request.QueryString["IdOrdenTrabajo"]);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid(int IdOrdenTrabajo, int IdLinea, string Fecha)
		{
			// To Load Tanque DataGrid
			SICALNet.BusinessLogicLayer.Tanque Tanque = new SICALNet.BusinessLogicLayer.Tanque();
			IList TanqueList = (IList)Tanque.LoadTank(IdLinea);
			dgdTanque.DataSource = TanqueList;
			dgdTanque.DataBind();

			// Refer DataAccessLayer Public Insert Function for MoreDetails (Conditions) About this Section
			SICALNet.BusinessLogicLayer.PartidadReaccion PReaccion = new SICALNet.BusinessLogicLayer.PartidadReaccion();
			PReaccion.Insert(IdOrdenTrabajo, IdLinea, Fecha);

			// To Load Resultant PartidasReaccion Table
			PartidasReaccionInfo BELPartidasReaccion= new PartidasReaccionInfo(IdOrdenTrabajo,0,0);
			SICALNet.BusinessLogicLayer.PartidadReaccion PartidasReacion = new SICALNet.BusinessLogicLayer.PartidadReaccion();
			IList prList = (IList)PartidasReacion.Load(BELPartidasReaccion);
			dgdReaccion.DataSource = prList;
			dgdReaccion.DataBind();
		}

		/// <summary>
		/// Load the combo boxes that will be used on the screen by the user to enter data.
		/// </summary>
		private void BindEntryFields(int IdLinea)
		{
			//to get an instance for business logic layer
			SICALNet.BusinessLogicLayer.Tanque tank = new SICALNet.BusinessLogicLayer.Tanque();

			//to Call the Insert Linea Information method
			cmbTanque.DataSource=tank.LoadTank(IdLinea);
			cmbTanque.DataTextField="TanqueDesc";
			cmbTanque.DataValueField="IdTanque";
			cmbTanque.DataBind();

			//to get the instance for BusinessLogicLayer
			SICALNet.BusinessLogicLayer.TipoPMMA tipoBL= new SICALNet.BusinessLogicLayer.TipoPMMA();
			IList tipoRs= (IList)tipoBL.SelectTipoPMMA();
			// To Load Data into to the cbotipoPMMA Dropdown List from TipoPMMA table
			cmbTipoPMMA.DataSource= tipoRs;
			cmbTipoPMMA.DataValueField="IdTipoPMMA";
			cmbTipoPMMA.DataTextField="DescripcionMaterial";
			cmbTipoPMMA.DataBind();

		}

		/// <summary>
		/// Determine if the selected tank has the same type of prepolymer selected by the user.
		/// </summary>
		/// <param name="idTank">Id of selected tank</param>
		/// <param name="idPMMAType">Id of PMMA tank</param>
		/// <returns>True when selected tank and selected PMMA is same than current FALSE when not.</returns>
		private bool SamePrepolymerOnTank(int idTank, int idPMMAType)
		{
			bool result =false;
			for (int i=0;i<dgdTanque.Items.Count;i++)
			{
				if (Convert.ToInt32(((Label)dgdTanque.Items[i].FindControl("ItemIdTanque")).Text)==idTank)
				{
					result=(Convert.ToInt32(((Label)dgdTanque.Items[i].FindControl("ItemTipoPMMAId")).Text)==idPMMAType);
				}
			}
			return result;
		}

		private bool QuantityForTankNotExceeded(int idTank, double quantity)
		{
			bool result=false;
			for (int i=0;i<dgdTanque.Items.Count;i++)
			{
				if (Convert.ToInt32(((Label)dgdTanque.Items[i].FindControl("ItemIdTanque")).Text)==idTank)
				{
					result=(Convert.ToDouble(((Label)dgdTanque.Items[i].FindControl("ItemCapacidadDisponible")).Text)>=quantity);
				}
			}	
			return result;
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				Validation vlt = new Validation();
				
				// To Validate the Given Inputed Values is Number or Not
				if(!vlt.IsNumber(txtKg.Text.ToString()) || (txtKg.Text==string.Empty))
					throw new Exception("Proporcione la cantidad de Kilogramos de la Reactada.");

				
				//Validate that selected tank has same prepolymer type.
				if (SamePrepolymerOnTank(Convert.ToInt32(cmbTanque.SelectedItem.Value),Convert.ToInt32(cmbTipoPMMA.SelectedItem.Value)))
				{
					if (QuantityForTankNotExceeded(Convert.ToInt32(cmbTanque.SelectedItem.Value),Convert.ToDouble(txtKg.Text)))
					{
						// To Update the Values in Reactadas Table
						ReactadasInfo RInfo = new ReactadasInfo(Convert.ToInt32(Request.QueryString["IdOrdenTrabajo"]),Convert.ToInt32(cmbTipoPMMA.SelectedItem.Value),DateTime.Now.ToString(),Convert.ToDouble(txtKg.Text),false);
						TanqueInfo TInfo = new TanqueInfo(Convert.ToInt32(cmbTanque.SelectedItem.Value),string.Empty,Convert.ToDouble(txtKg.Text));
						SICALNet.BusinessLogicLayer.Reactadas React = new SICALNet.BusinessLogicLayer.Reactadas();
						React.InsertReactada(RInfo,TInfo);
					}
					else
						throw new Exception(string.Format("La Reactada que desea liberar excede la capacidad máxima disponible del {0} ",cmbTanque.SelectedItem.Text));
				}
				else
					throw new Exception(string.Format("El {0} actualmente no tiene Prepolímero de Tipo: {1}. <br> Seleccione otro tanque que tenga el mismo tipo de prepolímero, o prepare un prepolímero distinto.",cmbTanque.SelectedItem.Text,cmbTipoPMMA.SelectedItem.Text));

				// To Refresh the Results in the Grids
				BindGrid(currentIdOrdenTrabajo,currentIdLinea,currentFecha);
				
				txtKg.Text = string.Empty;
				lblErrorMsg.Text=string.Empty;
			
			}
			catch(Exception ex)
			{
				 lblErrorMsg.Text=ex.Message.ToString();

				//throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultReactionWO.aspx");
		}
		
	}
}
