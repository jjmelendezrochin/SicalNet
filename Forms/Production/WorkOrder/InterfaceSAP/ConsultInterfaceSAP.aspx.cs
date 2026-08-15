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
using UserInterface.Helpers;

namespace UserInterface.Forms.Production.WorkOrder.InterfaceSAP
{
	/// <summary>
	/// Summary description for ConsultEnvioPT.
	/// </summary>
	public class ConsultInterfaceSAP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtInitial;
		protected System.Web.UI.WebControls.TextBox txtFinal;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtHoraInical;
		protected System.Web.UI.WebControls.TextBox txtHoraFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaInterfaz;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.DataList lstWorkOrder;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);
			
			if(!IsPostBack)
			{
				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];
				this.btnLiberar.Visible = false;
				if (tmpInit == null || tmpFin ==null)
				{
					txtInitial.Text=System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
					txtFinal.Text=System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
					this.txtFechaInterfaz.Text = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
					BindWorkOrders();
				}
				else
				{
					txtInitial.Text=tmpInit;
					txtFinal.Text=tmpFin;
					this.txtFechaInterfaz.Text = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
					BindWorkOrders();
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
			BindEntryFields();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.lstWorkOrder.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstWorkOrder_ItemCommand);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindEntryFields()
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
			for(int i=0;i<RsStatus.Count;i++)
			{
				SICALNet.BusinessEntities.StatusInfo Aux = (SICALNet.BusinessEntities.StatusInfo)RsStatus[i]; 
				if(Aux.IdStatus  != Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"]) && Aux.IdStatus != Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]))
																																							{					
						RsStatus.Remove(Aux);
						i--;

																																								}
			}
			prcCboCommon(cboStatus,"IdStatus","Descripcion",RsStatus);
		}

		//common function is used to fill the combo box
		private void prcCboCommon(DropDownList cbo,string sVal,string sTxt,IList RsList)
		{
			cbo.DataSource=RsList;
			cbo.DataValueField=sVal;
			cbo.DataTextField=sTxt;
			cbo.DataBind();
			

			if (sVal=="IdLinea")
			{
				cbo.Items.Add(new ListItem("Todas","0"));
				string currentLine=(string)Session["selectedLine"];
				if (currentLine != null)
					cbo.Items.FindByValue(currentLine).Selected=true;
				else
					cbo.Items.FindByValue("0").Selected=true;
			}
			else
				cbo.SelectedIndex = 0;
		}
		private bool BindWorkOrders()
		{
			try
			{
				SICALNet.BusinessLogicLayer.InterfazSAP BLLOrdTra= new SICALNet.BusinessLogicLayer.InterfazSAP();
				//int IdArea=Convert.ToInt32(ConfigurationSettings.AppSettings["InterfazSAP"]);
				int IdStatus=int.Parse(cboStatus.SelectedItem.Value);
				int IdLine=int.Parse(cboLinea.SelectedItem.Value);

				UserInterface.Helpers.Funciones fn = new Funciones();

				string InitDt = Convert.ToDateTime(fn.ConvertirFechaMesNumero(txtInitial.Text)).ToString("MM/dd/yy").Replace(".", "").ToLower();
				string FinalDt = Convert.ToDateTime(fn.ConvertirFechaMesNumero(txtFinal.Text)).ToString("MM/dd/yy").Replace(".", "").ToLower();

				string InitalHour = (this.txtHoraInical.Text==string.Empty)?"00:00:00":this.txtHoraInical.Text;
				string FinalHour = (this.txtHoraFinal.Text==string.Empty)?"23:59:59":this.txtHoraFinal.Text;
				
				Session["InitialDate"] = txtInitial.Text.ToString();
				Session["FinalDate"] = txtFinal.Text.ToString();
				
				Session["selectedLine"] = IdLine.ToString();
				InitDt = InitDt + " " + InitalHour;
				FinalDt = FinalDt + " " + FinalHour;
				System.IFormatProvider format = new System.Globalization.CultureInfo("en-US",true); 
				DateTime fInicial;
				DateTime fFinal;
				try
				{
					fInicial = DateTime.Parse(InitDt,format);
					fFinal = DateTime.Parse(FinalDt,format);
				}
				catch
				{
					throw new Exception("El formato de la fecha y/o hora de Inicio ó Final de recepción de PT es incorrecto, Favor de usar el formato correcto. Por ejemplo 30-Sep-2004 13:30");
				}

				DataSet RsOrdTra= BLLOrdTra.GetWorkOrdersForIntSAP(fInicial,fFinal,IdLine,IdStatus);
				if (RsOrdTra.Tables[0].Rows.Count == 0)
				{
					lstWorkOrder.DataSource = null;
					lstWorkOrder.DataBind();
					this.btnLiberar.Visible = false;
					return false;
				}
				//to fill the datagrid
				lstWorkOrder.DataSource = RsOrdTra;
				lstWorkOrder.DataBind();
				this.btnLiberar.Visible = true;
				return true;
			}
			catch
				{
					throw;
				}
		}

		private void btnSel_Click(object sender, System.EventArgs e)
		{
			BindWorkOrders();
		}
		
		private void lstWorkOrder_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			try
			{
				switch(e.CommandName)
				{
					case "Consult":
						string CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
						Session["CodigoSAP"]=CodeSAP;
						int IdPendingStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusPending"]);
						string secuencia=((Label)e.Item.FindControl("ItemSecuencia")).Text;
						string Descripcion = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
						string Fecha = ((Label)e.Item.FindControl("ItemFecha")).Text;
						int IdStatus = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdStatus")).Text);
						if(IdStatus==IdPendingStatus)
							throw new Exception(string.Format("La Secuencia {0} está en estado PENDIENTE, aún no puede ser Consultada",secuencia));
						if(((CheckBox)e.Item.FindControl("chkSelect")).Checked==true)
						{
							SICALNet.BusinessEntities.PartidasInspeccionInfo PIInfo = new SICALNet.BusinessEntities.PartidasInspeccionInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["InspeccionRoomId"]));
							SICALNet.BusinessLogicLayer.PartidasInspeccion BLIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
							int Laminas=BLIns.ActiveLaminas(PIInfo);
							Response.Redirect("EnvioPTFinal.aspx?InitialDate="+txtInitial.Text+"&FinalDate="+txtFinal.Text+"&cboStatus="+cboStatus.SelectedItem.Value+"&cboLinea="+cboLinea.SelectedItem.Value+"&Reflag=True&Packages=1&Secuencia="+secuencia+"&Descripcion="+Descripcion+"&Laminas="+Laminas+"&Flag=New&IdStatus="+IdStatus+"&Fecha="+Fecha);
						}
						else
						Response.Redirect("NumeroPaquete.aspx?Secuencia="+secuencia+"&Descripcion="+Descripcion+"&IdStatus="+IdStatus+"&CboStatus="+cboStatus.SelectedItem.Value+"&cboLinea="+cboLinea.SelectedItem.Value+"&InitialDate="+txtInitial.Text+"&FinalDate="+txtFinal.Text+"&Fecha="+Fecha);
						break;

					case "Mensaje":
						string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
						string IdArea= ConfigurationSettings.AppSettings["SendFinishProductRoomId"].ToString();
						CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
						string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
						RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
						break;
				}
			}
			catch
			{
				throw;
			}
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{

				bool bliberar=false;
				DateTime fInterfaz;
				if(this.txtFechaInterfaz.Text==String.Empty)
				{
					throw new Exception("La fecha de la interface es requerida"); 
				}
			
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{									
					if(((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Checked==true)
					{
						string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text;					
						try
						{
							System.IFormatProvider format = new System.Globalization.CultureInfo("en-US",true); 
							fInterfaz = DateTime.Parse(this.txtFechaInterfaz.Text.ToString(),format);
						}
						catch
						{
							throw new Exception("La fecha de la interface esta en un formato inválido");
						}


						// To Release the Work Order
						SICALNet.BusinessEntities.OrdenesTrabajoInfo WOInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia, Convert.ToInt32(ConfigurationSettings.AppSettings["InterfazSAP"]), Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]), DateTime.Now.Date.ToString("dd/MMM/yyyy"), Context.User.Identity.Name); 
						SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						WorkOrder.UpdateStatus(WOInfo);
						bool bolPF = ((CheckBox)lstWorkOrder.Items[i].FindControl("chkEF")).Checked;
						

						//string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),string.Empty,0,0,string.Empty);
						SICALNet.BusinessLogicLayer.InterfazSAP BlPRPT1 = new SICALNet.BusinessLogicLayer.InterfazSAP();
						BlPRPT1.SaveInterfazSAP(secuencia,bolPF,fInterfaz,Context.User.Identity.Name);
						bliberar=true;						
					}

				}
				if(bliberar)
				{
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"')" + "<" + "/script>");
				}
				Response.Redirect("ConsultInterfaceSAP.aspx");
			}
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}		



		}

//		private void btnCancelar_Click(object sender, System.EventArgs e)
//		{
//			Response.Redirect("/Forms/NewMenu.aspx");
//		}

	}
}
