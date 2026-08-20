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

namespace UserInterface.Forms.Production.Work_Order.Post_Cured
{
	/// <summary>
	/// Summary description for Consultar_PostCured.
	/// </summary>
	public class Consultar_PostCured : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Status;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DataGrid dgdPostCuredWO;
		protected System.Web.UI.WebControls.Literal ltrRefresh;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;

		protected static int localAreaId;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if((ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"] != "0") && (ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"] + "'>" ;			


			if(!IsPostBack)
			{
				prcCboFill();
				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];

				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (tmpInit == null || tmpFin ==null)
				{
					txtFecha.Text = sFechaIni.Replace(".","");
					txtFechaFinal.Text = sFechaFin.Replace(".","");

					//txtFecha.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
					//txtFechaFinal.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
				}
				else
				{
					//txtFecha.Text = sFechaIni.Replace(".","");
					//txtFechaFinal.Text = sFechaFin.Replace(".","");

					txtFecha.Text		=tmpInit.Replace(".","");
					txtFechaFinal.Text	=tmpFin.Replace(".","");
				}
				BindForm();
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
			localAreaId=Convert.ToInt32(ConfigurationManager.AppSettings["PostCuredRoomId"]);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.dgdPostCuredWO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPostCuredWO_ItemCommand);
			this.dgdPostCuredWO.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdPostCuredWO_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void dgdPostCuredWO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Consult")
			{
				try
				{
					int Sts=Convert.ToInt32(((Label)e.Item.FindControl("ItemIdStatus")).Text);
					string secuance=((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
					int PendingStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusPending"]);

					if (Sts == PendingStatus) 
					{
						throw new Exception(string.Format("La Secuencia {0} está en estado PENDIENTE, aún no puede ser Consultada",secuance));
					}			
								
					for (int iLoop=0; iLoop < dgdPostCuredWO.Items.Count; iLoop++)
						dgdPostCuredWO.Items[iLoop].BackColor=Color.White;
					dgdPostCuredWO.Items[e.Item.ItemIndex].BackColor=Color.Lavender;
					string Desc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
					int IdLinea=Convert.ToInt32(((Label)e.Item.FindControl("ItemIdLinea")).Text.ToString());
					string codigoSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
					string idStatus = ((Label) e.Item.FindControl("ItemIdStatus")).Text.ToString();

					Response.Redirect("Consultar_PostCuredWO.aspx?Status="+idStatus+"&Secuencia="+secuance+"&Desc="+Desc+"&IdLinea="+IdLinea.ToString()+"&CodigoSAP="+codigoSAP);
				}
				catch(Exception ex)
				{
					//to display the msg for user
					string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
					ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				}

			}
			else if(e.CommandName == "Agregar")
			{
				string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
				string IdArea= localAreaId.ToString();
				string CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
				string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
			}
				
		}

		private void prcCboFill()
		{
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//to fill the Linea description into the cboLinea control
			SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
			prcCboCommon(cboLinea,"IdLinea","Description",RsLine);
			//to fill the Status description into the cboStatus control
			SICALNet.BusinessLogicLayer.Status BLLStatus=new SICALNet.BusinessLogicLayer.Status();
			IList RsStatus=(IList) BLLStatus.Load();
			prcCboCommon(cboStatus,"IdStatus","Descripcion",RsStatus);
		}

		private void prcCboCommon(DropDownList cbo,string sVal,string sTxt,IList RsList)
		{
			cbo.DataSource=RsList;
			cbo.DataValueField=sVal;
			cbo.DataTextField=sTxt;
			cbo.DataBind();
			cbo.Items.Add(new ListItem(string.Empty,"0"));

			if (sVal=="IdLinea")
			{
				string currentLine=(string)Session["selectedLine"];
				if (currentLine != null)
					cbo.Items.FindByValue(currentLine).Selected=true;
				else
				{
					SICALNet.BusinessEntities.UsuarioInfo User = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				
					User = BLLUser.Load(User);
					string lineaDefault;

					switch(User.IdPlanta)
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

					cbo.Items.FindByValue(lineaDefault).Selected=true;
					
				}
			}
			else if(sVal=="IdStatus" )
			{
				string currentStatus=(string)Session["selectedIdStatus"];
				if (currentStatus != null)
					cbo.Items.FindByValue(currentStatus).Selected=true;
				else
					cbo.Items.FindByValue("2").Selected=true; // Activo por default

			}
			else
			{
				cbo.Items.FindByValue("0").Selected=true;
			}


		}
		private void BindForm()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				//SICALNet.BusinessLogicLayer.OrdenesTrabajo BLLOrdTra= new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				//to Call the Select method
				int IdStatus=int.Parse(cboStatus.SelectedItem.Value);
				int IdLinea=int.Parse(cboLinea.SelectedItem.Value);
				int IdArea=localAreaId;

				string Fecha=txtFecha.Text.ToString();
				string FechaFinal = txtFechaFinal.Text.ToString();
				
				Session["InitialDate"]=Fecha;
				Session["FinalDate"]= FechaFinal;
				Session["selectedLine"] = IdLinea.ToString();
				Session["selectedIdStatus"] = cboStatus.SelectedItem.Value;

				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(dmy2ymd(Fecha),dmy2ymd(FechaFinal),IdLinea, IdStatus, IdArea);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				IList WOList = (IList)WorkOrder.LoadWorkOrders(WOInfo);
				dgdPostCuredWO.DataSource = WOList;
				dgdPostCuredWO.DataBind();
			}
			catch(Exception errHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}

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

		private void btnSel_Click(object sender, System.EventArgs e)
		{
			BindForm();
		}

		private void dgdPostCuredWO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label lblFechaMod = (Label)e.Item.FindControl("ItemFechaMod");
				if (lblFechaMod.Text != "") 
				{
					e.Item.BackColor = Color.Yellow;
					DateTime timeAux = Convert.ToDateTime(lblFechaMod.Text); 
					if (timeAux.ToString("dd/MMM/yy")   == DateTime.MinValue.ToString("dd/MMM/yy")) 
						e.Item.BackColor = Color.LightBlue;   
				}
				Label lblStatus = (Label)e.Item.FindControl("ItemIdStatus");
				if (lblStatus.Text == ConfigurationManager.AppSettings["StatusCancel"]) 
					e.Item.BackColor = Color.Tomato;
			}
		}
	}
}
