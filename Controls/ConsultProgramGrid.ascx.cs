namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;


	/// <summary>
	///		Summary description for ConsultProgramGrid.
	/// </summary>
	public abstract class ConsultProgramGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblFrom;
		protected System.Web.UI.WebControls.Label lblTo;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.TextBox txtFrom;
		protected System.Web.UI.WebControls.Image imgFrom;
		protected System.Web.UI.WebControls.TextBox txtTo;
		protected System.Web.UI.WebControls.Image imgTo;
		protected System.Web.UI.WebControls.Label lblLine;
		public System.Web.UI.WebControls.DataList lstProgram;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.DropDownList cboIdLinea;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				String sFechaIni = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				String sFechaFin = DateTime.Now.Date.ToString("dd-MMM-yyyy");

				txtFrom.Text = sFechaIni.Replace(".","");
				txtTo.Text = sFechaFin.Replace(".","");

				//to fill the Linea description into the cboLinea control
				SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
				cboIdLinea.DataSource=RsLine;
				cboIdLinea.DataValueField="IdLinea";
				cboIdLinea.DataTextField="Description";
				cboIdLinea.DataBind();
				cboIdLinea.Items.Add(new ListItem(string.Empty,"0"));

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

				cboIdLinea.Items.FindByValue(lineaDefault).Selected=true;
				
			}
		}

		//to bind the data into datagrid
		public void BindGrid(string FrDate,string ToDate,int IdLinea)
		{
			try
			{
				IList RsPrg=null;
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
				// to Call the Select method
				if (IdLinea != 0)
					RsPrg= (IList)BLLPrg.Load(FrDate,ToDate,IdLinea);
				else
					RsPrg= (IList)BLLPrg.Load(FrDate,ToDate);
				//to assign the result set into datagrid
				if (RsPrg.Count == 0)
				{
					lstProgram.DataSource=null;
					lstProgram.DataBind();
				}
				else
				{
					//dgdProgram.DataSource = RsPrg;
					//to fill the datagrid
					//dgdProgram.DataBind();
					//dgdProgram.Visible=true;
					lstProgram.DataSource=RsPrg;
					lstProgram.DataBind();
					lstProgram.Visible=true;
				}
			}
			catch
			{
				throw;
//				Session["errMsg"]=ExpHand.HandleException("Structure","Material",errHand,Server.MapPath(".."),errHand.Message);
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//to display the record in datagrid
		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (cboIdLinea.SelectedItem.Text != string.Empty)
				BindGrid(txtFrom.Text,txtTo.Text,int.Parse(cboIdLinea.SelectedItem.Value));
			else
				BindGrid(txtFrom.Text,txtTo.Text,0);

			if (lstProgram.Items.Count>1)
			{
				//if (dgdProgram.Controls.Count>0) 
				//	((CheckBox) dgdProgram.Controls[0].FindControl("chkAll")).Checked=false;
				//if (dgdProgram.HasControls()) ((CheckBox) dgdProgram.Controls[0].FindControl("chkAll")).Checked=false;
				for (int i=0; i<lstProgram.Items.Count;i++)
				{
					((CheckBox)(lstProgram.Items[i].FindControl("chkSelected"))).Checked = false;
				}
			}
			
		}

		public void CheckAll(object sender, System.EventArgs e)
		{
//			for(int i=1; i < dgdProgram.Controls[0].Controls.Count-1; i++)
//			{
//				((CheckBox)dgdProgram.Controls[0].Controls[i].FindControl("chkItemChecked")).Checked = ((CheckBox)sender).Checked;
//			}

			for(int j=1; j < lstProgram.Controls.Count; j++)
			{
				for (int k=1; k<lstProgram.Controls[j].Controls.Count;k++)
				{
					((CheckBox)lstProgram.Controls[j].Controls[k].FindControl("chkSelected")).Checked = ((CheckBox)sender).Checked;				
				}
			}
		}

		public void Expand(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			ImageButton boton=(ImageButton)sender;
			string id =boton.ClientID;
			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			string url = boton.ImageUrl.ToLower();
			//string url = boton.ImageUrl;
			/*** fin de modificación ***/
			int index =Convert.ToInt32(id.Substring(37,id.LastIndexOf("_")-37));		

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			if (String.Compare(url,"../images/plusbutton.jpg") == 0)
			//if (url.ToLower()=="../images/plusbutton.jpg")
			/*** fin de modificación ***/
			{
				boton.ImageUrl="../images/minusButton.jpg";
				HtmlTable detailsTable=((HtmlTable)lstProgram.Items[index-1].FindControl("SequenceDetails"));
				detailsTable.Visible=true;			
			}
			else
			{
				boton.ImageUrl="../images/plusButton.jpg";
				HtmlTable detailsTable=((HtmlTable)lstProgram.Items[index-1].FindControl("SequenceDetails"));
				detailsTable.Visible=false;			
			}
		}

	}
}
