//namespace UserInterface.Controls
//{
//	using System;
//	using System.Data;
//	using System.Collections;
//	using System.Drawing;
//	using System.Web;
//	using System.Web.UI.WebControls;
//	using System.Web.UI.HtmlControls;
//
//	/// <summary>
//	///		Summary description for ConsultProgramGrid.
//	/// </summary>
//	public abstract class WorkOrdersGrid : System.Web.UI.UserControl
//	{
//		protected System.Web.UI.WebControls.Label lblLinea;
//		protected System.Web.UI.WebControls.DropDownList ddlIdLinea;
//		protected System.Web.UI.WebControls.DropDownList ddlFecha;
//		protected System.Web.UI.WebControls.DataGrid dgdWorkOrders;
//		protected System.Web.UI.WebControls.Label lblDate;
//
//		private void Page_Load(object sender, System.EventArgs e)
//		{
//			// Put user code to initialize the page here
//			if(!IsPostBack)
//			{
//				//to fill the Linea description into the cboLinea control
//				SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
//			
//
//				IList RsLine=(IList) BLLLine.SelectLinePdt();
//				ddlIdLinea.DataSource=RsLine;
//				ddlIdLinea.DataValueField="IdLinea";
//				ddlIdLinea.DataTextField="Description";
//				ddlIdLinea.DataBind();
//				ddlIdLinea.Items.Add(new ListItem(string.Empty,"0"));
//				ddlIdLinea.Items.FindByValue("0").Selected=true;
//
//
//				
//
//			}
//		}
//
//		/* public void BindGrid(string FrDate,string ToDate,int IdLinea)
//		{
//			try
//			{
//				IList RsPrg=null;
//				//to get the instance for BusinessLogicLayer
//				SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
//				// to Call the Select method
//				if (IdLinea != 0)
//					RsPrg= (IList)BLLPrg.Load(FrDate,ToDate,IdLinea);
//				else
//					RsPrg= (IList)BLLPrg.Load(FrDate,ToDate);
//				//to assign the result set into datagrid
//				if (RsPrg.Count == 0)
//				{
//					dgdWorkOrders.Visible=false;
//				}
//				else
//				{
//					dgdWorkOrders.DataSource = RsPrg;
//					//to fill the datagrid
//					dgdWorkOrders.DataBind();
//					dgdWorkOrders.Visible=true;
//				}
//			}
//			catch(Exception errHand)
//			{
//				//				Session["errMsg"]=ExpHand.HandleException("Structure","Material",errHand,Server.MapPath(".."),errHand.Message);
//			}
//		} */
//
//		#region Web Form Designer generated code
//		override protected void OnInit(EventArgs e)
//		{
//			//
//			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
//			//
//			InitializeComponent();
//			base.OnInit(e);
//		}
//		
//		///		Required method for Designer support - do not modify
//		///		the contents of this method with the code editor.
//		/// </summary>
//		private void InitializeComponent()
//		{
//			this.dgdWorkOrders.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdWorkOrders_ItemCommand);
//			this.Load += new System.EventHandler(this.Page_Load);
//
//		}
//		#endregion
//
//		private void ddlIdLinea_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(Int32.Parse(ddlIdLinea.SelectedItem.Value),string.Empty,string.Empty);
//			//to fill the fecha from programm production into fecha combo box
//			
//			SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
//			
//			
//			ddlFecha.DataSource = (IList) bllProgramma.GetFecha(belProgramma);
//			ddlFecha.DataValueField = "FechaDate";
//			ddlFecha.DataTextField = "Fecha";
//			ddlFecha.DataBind();
//			//ddlFecha.Items.Add( new ListItem(string.Empty,""));
//			//ddlFecha.Items.FindByValue("").Selected = true;
//
//		}
//
//		private void ddlFecha_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			BindGrid();
//		}
//
//		private void dgdWorkOrders_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//		
//		}
//		private void BindGrid()
//		{
//			SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(Int32.Parse(ddlIdLinea.SelectedItem.Value),string.Empty,ddlFecha.SelectedItem.Value);
//			//to fill the fecha from programm production into fecha combo box
//			
//			SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
//			dgdWorkOdders.DataSource = bllProgramma.SelectProgramma(belProgramma);
//			dgdWorkOrders.DataBind();
//		}
//		private void dgdWorkOrders_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
//		{
//			if(e.CommandName == "Select")
//			{
//				dgdWorkOrders.SelectedIndex = e.Item.ItemIndex;
//				dgdWorkOrders.SelectedItem.BackColor = Color.DimGray;
//			}
//
//		}
//		public string EditMode()
//		{
//			
//			dgdWorkOrders.EditItemIndex = dgdWorkOrders.SelectedIndex;
//			BindGrid();
//			Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" + ((TextBox)dgdWorkOrders.SelectedItem.Cells[6].FindControl("txtCantidad")).ClientID + "').focus();" + "</SCRIPT>");
//			return ((Label)dgdWorkOrders.SelectedItem.Cells[2].FindControl("lblLote")).Text;
//			//dgdWorkOrders.SelectedItem.
//		}
//		public string Update()
//		{
//			return ((TextBox)dgdWorkOrders.SelectedItem.Cells[6].FindControl("txtCantidad")).Text;
//		}
//		public void CancelEdit()
//		{
//			dgdWorkOrders.EditItemIndex = -1;
//			BindGrid();
//		}
//		public string getSecuencia()
//		{
//			return ((Label)dgdWorkOrders.SelectedItem.Cells[3].FindControl("lblSecuencia")).Text.ToString();
//		}
//		public void ShowFooter()
//		{
//			dgdWorkOrders.ShowFooter = true;
//			SICALNet.BusinessLogicLayer.Lote bllLote = new SICALNet.BusinessLogicLayer.Lote();
//			((DropDownList) dgdWorkOrders.Controls[0].Controls[dgdWorkOrders.Controls[0].Controls.Count - 1].Controls[2].FindControl("dllLote")).DataSource = bllLote.getLote();
//			((DropDownList) dgdWorkOrders.Controls[0].Controls[dgdWorkOrders.Controls[0].Controls.Count - 1].Controls[2].FindControl("ddlLote")).DataTextField = "NumeroLote";
//			((DropDownList) dgdWorkOrders.Controls[0].Controls[dgdWorkOrders.Controls[0].Controls.Count - 1].Controls[2].FindControl("ddlLote")).DataValueField = "NumeroLote";
//			
//		}
//
//		private void dgdWorkOrders_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
//		{
//			
//			
//		}
//		//public ContinueEdit(int 
//
//		/*	private void btnAceptar_Click(object sender, System.EventArgs e)
//			{
//				if (cboIdLinea.SelectedItem.Text != string.Empty)
//					BindGrid((cdrFrom.SelectedDate.ToString("dd-MMM-yyyy")),(cdrTo.SelectedDate.ToString("dd-MMM-yyyy")),int.Parse(cboIdLinea.SelectedItem.Value));
//				else
//					BindGrid(cdrFrom.SelectedDate.ToString("dd-MMM-yyyy"),cdrTo.SelectedDate.ToString("dd-MMM-yyyy"),0);
//			} */
//	}
//}
