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

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultReactionWO.
	/// </summary>
	public class ConsultReactionWO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.DataGrid dgdOTReaccion;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Status;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFinal;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button cmdGo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (!IsPostBack)
			{

				BindEntryFields();
				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];
				

				if (tmpInit == null || tmpFin ==null)
				{
					string fechaActual = DateTime.Now
						.ToString("dd-MMM-yyyy")
						.Replace(".", "")
						.ToLower();

					txtFechaInicial.Text = fechaActual;
					txtFechaFinal.Text = fechaActual;
				}
				else
				{
					txtFechaInicial.Text = tmpInit;
					txtFechaFinal.Text = tmpFin;
				}

				dgdOTReaccion.CurrentPageIndex = 0;

				BindGrid(
					txtFechaInicial.Text,
					txtFechaFinal.Text,
					Convert.ToInt32(cboLinea.SelectedItem.Value),
					Convert.ToInt32(cboStatus.SelectedItem.Value)
				);
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
			this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
			this.dgdOTReaccion.SelectedIndexChanged += new System.EventHandler(this.dgdOTReaccion_SelectedIndexChanged);
			this.dgdOTReaccion.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdOTReaccion_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void BindEntryFields()
		{

			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//Code to populate Linea ComboBox
			SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList LineaList = (IList) Linea.SelectLinePdt(theUser);
			
			cboLinea.DataSource = LineaList;
			cboLinea.DataValueField = "IdLinea";
			cboLinea.DataTextField = "Description";
			cboLinea.DataBind();
			cboLinea.Items.Add(new ListItem(string.Empty,"0"));
			string currentLine=(string)Session["selectedLine"];
			if (currentLine != null)
				cboLinea.Items.FindByValue(currentLine).Selected=true;
			else
			{
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

				cboLinea.Items.FindByValue(lineaDefault).Selected=true;
			}

			//Code to populate Status ComboBox
			SICALNet.BusinessLogicLayer.Status Status = new SICALNet.BusinessLogicLayer.Status();
			IList StatusList = (IList) Status.Load();
			
			cboStatus.DataSource = StatusList;
			cboStatus.DataValueField = "IdStatus";
			cboStatus.DataTextField = "Descripcion";
			cboStatus.DataBind();
			cboStatus.Items.Add(new ListItem(string.Empty,"0"));
			
			cboStatus.Items.FindByValue("2").Selected=true;	// Activo por default


		}

		public void BindGrid(string FechaInicial, string FechaFinal, int IdLinea, int IdStatus)
		{
			Session["InitialDate"]=FechaInicial;
			Session["FinalDate"]=FechaFinal;
			Session["selectedLine"] = IdLinea.ToString();
			
			// To Load the OTReaccion WO List
			SICALNet.BusinessLogicLayer.OTReaccion OTReaccion = new SICALNet.BusinessLogicLayer.OTReaccion();
			IList OTReaccionList = (IList)OTReaccion.Load((FechaInicial), (FechaFinal), IdLinea, IdStatus);
			dgdOTReaccion.DataSource = OTReaccionList;
			dgdOTReaccion.DataBind();			
		}

		private string dmy2ymd(String Fecha)
		{
			String sDia, sMes, sAnio, sFecha, sFecha1;
			sFecha1 = Fecha.Replace(".", "");			
			sDia = sFecha1.Substring(0, 2);
			sMes = sFecha1.Substring(3, 3);
			sAnio = sFecha1.Substring(7);
			sFecha = sAnio + "/" + GetMonth(sMes) + "/" + sDia ;
			return sFecha;
		}

		private string GetMonth(string smes)
		{
			switch (smes.ToUpper())
			{
				case "ENE" :
					return "01";
					//break;
				case "FEB" :
					return "02";
					//break;
				case "MAR" :
					return "03";
					//break;
				case "ABR" :
					return "04";
					//break;
				case "MAY" :
					return "05";
					//break;
				case "JUN" :
					return "06";
					//break;
				case "JUL" :
					return "07";
					//break;
				case "AGO" :
					return "08";
					//break;
				case "SEP" :
					return "09";
					//break;
				case "OCT" :
					return "10";
					//break;
				case "NOV" :
					return "11";
					//break;
				case "DIC" :
					return "12";
					//break;
				default:
					return "Desconocido";
					//break;
			}
		}

		private void cmdGo_Click(object sender, System.EventArgs e)
		{

			// Siempre regresar a la primera página
			// cuando se realiza una nueva consulta.
			dgdOTReaccion.CurrentPageIndex = 0;

			BindGrid(
				txtFechaInicial.Text,
				txtFechaFinal.Text,
				Convert.ToInt32(cboLinea.SelectedItem.Value),
				Convert.ToInt32(cboStatus.SelectedItem.Value)
			);
		}

		private void dgdOTReaccion_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			// To redirect to the Resultant Page
			int IdOrdenTrabajo = Convert.ToInt32(((Label)dgdOTReaccion.SelectedItem.FindControl("ItemIdOrdenTrabajo")).Text);
			int IdLinea = Convert.ToInt32(((Label)dgdOTReaccion.SelectedItem.FindControl("ItemIdLinea")).Text);
			string LineaDesc = ((Label)dgdOTReaccion.SelectedItem.FindControl("ItemLineaDesc")).Text;
			string Fecha = ((Label)dgdOTReaccion.SelectedItem.FindControl("ItemFecha")).Text;
			
			Response.Redirect("ConsultReactionWO1.aspx?Fecha=" + Fecha 
				+ "&IdLinea=" + IdLinea 
				+ "&LineaDesc=" + LineaDesc 
				+ "&IdOrdenTrabajo=" + IdOrdenTrabajo );
		}

		private void dgdOTReaccion_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdOTReaccion.CurrentPageIndex = e.NewPageIndex;

			BindGrid(
				txtFechaInicial.Text,
				txtFechaFinal.Text,
				Convert.ToInt32(cboLinea.SelectedItem.Value),
				Convert.ToInt32(cboStatus.SelectedItem.Value)
			);

		}
	}
}
