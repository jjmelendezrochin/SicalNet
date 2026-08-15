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

using System.Configuration;
using SICALNet.BusinessEntities;


namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultQuarantineWO.
	/// </summary>
	public class ConsultQuarantineWO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.DataGrid dgdWorkOrder;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.ImageButton cmdCalendar;
		protected System.Web.UI.WebControls.Button cmdAceptar;
		protected System.Web.UI.WebControls.Label lblFechaFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.ImageButton ImgFechaFinal;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Literal ltrRefresh;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			if((ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"] != "0") && (ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"] + "'>" ;			


			if (!IsPostBack)
			{

				BindEntryFields();
				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];
				
				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (tmpInit == null || tmpFin ==null)
				{
					txtFecha.Text = sFechaIni.Replace(".","");
					txtFechaFinal.Text = sFechaFin.Replace(".","");

					// txtFecha.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
					//txtFechaFinal.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
				}
				else
				{
					//txtFecha.Text = sFechaIni.Replace(".","");
					//txtFechaFinal.Text = sFechaFin.Replace(".","");

					txtFecha.Text=tmpInit.Replace(".","");
					txtFechaFinal.Text=tmpFin.Replace(".","");
				}

				BindGrid(Convert.ToInt32(cboLinea.SelectedItem.Value), Convert.ToInt32(cboStatus.SelectedItem.Value));				
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
			this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
			this.dgdWorkOrder.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdWorkOrder_ItemCommand);
			this.dgdWorkOrder.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdWorkOrder_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAceptar_Click(object sender, System.EventArgs e)
		{
			int IdLinea = (cboLinea.SelectedItem.Text == "ALL" ? 0 : Convert.ToInt32(cboLinea.SelectedItem.Value));
			int IdStatus = (cboStatus.SelectedItem.Text == "ALL" ? 0 : Convert.ToInt32(cboStatus.SelectedItem.Value));
			BindGrid(IdLinea, IdStatus);

		}

		public void BindGrid( int IdLinea, int IdStatus)
		{
			Session["InitialDate"]=txtFecha.Text;
			Session["FinalDate"]=txtFechaFinal.Text;
			Session["selectedLine"] = IdLinea.ToString();
			Session["selectedIdStatus"] = cboStatus.SelectedItem.Value;

			int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["QuarantineRoomId"]); // Area Id For Quarantine Room
			OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(dmy2ymd(txtFecha.Text), dmy2ymd(txtFechaFinal.Text), IdLinea, IdStatus, IdArea);
			// To Load the WO List
			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList WOList = (IList)WorkOrder.LoadWorkOrders(WOInfo);
			dgdWorkOrder.DataSource = WOList;
			dgdWorkOrder.DataBind();
			
		}

		private DateTime dmy2ymd(String Fecha)
		{
			String sDia, sMes, sAnio, sFecha, sFecha1;
			sFecha1 = Fecha.Replace(".", "");			
			sDia = sFecha1.Substring(0, 2);
			sMes = sFecha1.Substring(3, 3);
			sAnio = sFecha1.Substring(7);
			sFecha = sAnio + "/" + GetMonth(sMes) + "/" + sDia ;
			return DateTime.Parse(sFecha);
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




		private void dgdWorkOrder_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if (e.CommandName=="Consult")
				{
					int Sts=Convert.ToInt32(((Label)e.Item.FindControl("ItemIdStatus")).Text);
					string Secuencia =((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
					string Fecha2 =((Label)e.Item.FindControl("ItemFecha")).Text.ToString();
					string Utec =((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
					string Linea2 =((Label)e.Item.FindControl("ItemLineaDesc")).Text.ToString();
					string Cantidad =((Label)e.Item.FindControl("ItemCantidad")).Text.ToString();
					string Familia =((Label)e.Item.FindControl("ItemDescFamilia")).Text.ToString();
					int IdFamilio=Convert.ToInt32(((Label)e.Item.FindControl("ItemFamiliaProducto")).Text);
					int IdMedida=Convert.ToInt32(((Label)e.Item.FindControl("ItemIdMedida")).Text);
					int IdLinea=Convert.ToInt32(((Label)e.Item.FindControl("ItemIdLinea")).Text);
					int IdPlanta=Convert.ToInt32(((Label)e.Item.FindControl("ItemIdPlanta")).Text);					
					string IdPresentacion=((Label)e.Item.FindControl("ItemIdPresentacion")).Text.ToString();
					string CodigoSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text;

					Response.Redirect("ConsultQuarantineWO1.aspx?Secuencia=" + Secuencia 
						+ "&Fecha2=" + Fecha2  
						+ "&Linea2=" + Linea2 
						+ "&Cantidad=" + Cantidad 
						+ "&Familia=" + Familia 
						+ "&IdFamilio=" + IdFamilio 
						+ "&IdMedida=" + IdMedida 
						+ "&IdLinea=" + IdLinea 
						+ "&IdPlanta=" + IdPlanta 
						+ "&IdPresentacion=" + IdPresentacion 
						+ "&Status=" + Sts 
						+ "&CodigoSAP=" + CodigoSAP
						+ "&UTEC=" + Utec );
				}

				if (e.CommandName=="Agregar")
				{
					string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
					string IdArea=ConfigurationSettings.AppSettings["QuarantineRoomId"].ToString(); // Area Id For Quarantine Room
					string CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
					string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
				}
		
			}
			catch(Exception ex)
			{
				lblErrorMsg.Text=ex.Message;
			}
		}
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
			string currentIdStatus=(string)Session["selectedIdStatus"];
			if (currentIdStatus != null)
				cboStatus.Items.FindByValue(currentIdStatus).Selected=true;
			else
				cboStatus.Items.FindByValue("2").Selected=true;	// Activo por default			
		}

		private void dgdWorkOrder_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//to change the color of the row if Fecha Modif is Present.
			if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
			{
				string fecmod=((Label)e.Item.FindControl("ItemFechaMod")).Text.ToString();
				if(fecmod!=string.Empty)
				{
					e.Item.BackColor=Color.Yellow;
					DateTime timeAux = Convert.ToDateTime(fecmod); 
					if (timeAux.ToString("dd/MMM/yy")   == DateTime.MinValue.ToString("dd/MMM/yy")) 
						e.Item.BackColor = Color.LightBlue;
				}
				Label lblStatus = (Label)e.Item.FindControl("ItemIdStatus");
				if (lblStatus.Text == ConfigurationSettings.AppSettings["StatusCancel"]) 
					e.Item.BackColor = Color.Tomato;
			}
		}

	}
}
