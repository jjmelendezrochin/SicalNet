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
using SICALNet.Utilities;
using System.Configuration;

namespace UserInterface.Forms.Production.ColorRoom
{
	/// <summary>
	/// Summary description for VasosDetails.
	/// </summary>
	public class VasosDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.DataGrid dgdQtyVaso;
		protected System.Web.UI.WebControls.Button btnNext;
		protected DataSet dsVaso;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected static bool isNew;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected static string sec="'";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					txtCantidad.Text=Session[this.Context.User.Identity.Name+"cantidad"].ToString();
					prcFillGrid();
				}
				else 
				{
					int[] Cantidad = new int[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
					Cantidad=(int[])Session[this.Context.User.Identity.Name+"Cantidad"];
					int i=0;
					int sum=0;
					while(i<Cantidad.Length)
					{
					sum+=Cantidad[i];
					i++;
					}
					txtCantidad.Text=sum.ToString();
					prcFillGrid();
				}

				displaySelectedSequenceValues();

			}
		}
		
		private void displaySelectedSequenceValues()
		{
			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
			{
				txtSecuencia.Text = Session[this.Context.User.Identity.Name+"Secuencia"].ToString();
				txtFecha.Text = Session[this.Context.User.Identity.Name+"Fecha"].ToString();
				txtUTEC.Text = Session[this.Context.User.Identity.Name+"UTEC"].ToString();
				txtCantidad.Text  = Session[this.Context.User.Identity.Name+"Cantidad"].ToString();
			}
			else
			{
				string[] Secuencia = (string[]) Session[this.Context.User.Identity.Name+"Secuencia"];
				int[] Cantidad = (int[]) Session[this.Context.User.Identity.Name+"Cantidad"];
				string[] Fecha = (string[])Session[this.Context.User.Identity.Name+"Fecha"];
				txtUTEC.Text=Session[this.Context.User.Identity.Name+"UTEC"].ToString();
				int CantidadSum=0;
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				{
					txtSecuencia.Text+=Secuencia[i]+",";
					txtFecha.Text+=Fecha[i]+",";
					CantidadSum+=Cantidad[i];
				}
				txtCantidad.Text=CantidadSum.ToString();
			}
		}

		//to create the dataset depebds on the no. of visos
		private void prcFillGrid()
		{
/*			if (int.Parse(Session[this.Context.User.Identity.Name+"NoVaso"].ToString()) > 0)
			{
				MakeDataSet(int.Parse(Session[this.Context.User.Identity.Name+"NoVaso"].ToString()));
			}
*/
			int[] NoVaso =(int[])Session[this.Context.User.Identity.Name+"NoVaso"];

			MakeDataSet(NoVaso);
		}
		
		//to create the dataset
		private void MakeDataSet(int[] noVaso)
		{
			// Create a DataSet.
			dsVaso = new DataSet("dsVaso");
			//Create a DataTable.
			DataTable dtVaso = new DataTable("Vaso");
			//Create three columns, and add them to the first table.
			DataColumn dcGroupNo = new DataColumn("GroupNo");
			DataColumn dcVaso = new DataColumn("VasoNo"); 
			DataColumn dcLaminas = new DataColumn("NoLaminas"); 
			//assign the datacolum into datatable
			dtVaso.Columns.Add(dcGroupNo);
			dtVaso.Columns.Add(dcVaso);
			dtVaso.Columns.Add(dcLaminas);
			//Add the tables to the DataSet.
			dsVaso.Tables.Add(dtVaso);

			//Populates the tables., 
			//creates DataRow variables. 
			SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
			IList RsPC = new ArrayList();
			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0" && Request.QueryString["isNew"]=="False")
			{
				//IList RsPC=(IList) BLLPC.LoadVasoPArtidasColor(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(),0,"Laminas");
				RsPC=(IList) BLLPC.GetLaminas(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
			}
			else if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0" && Request.QueryString["isNew"]=="False")
			{
				string[] secuencia = (string[]) Session[this.Context.User.Identity.Name+"Secuencia"];
				if(sec!="'")
					sec="'";
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				{
					sec+=secuencia[i];
					if(i==(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
						sec+="'";
					else
						sec+="','";
				}
				RsPC= (IList)BLLPC.GetLaminasCombined(sec);
   			}
			if (RsPC.Count > 0)
			{
				Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
				dgdQtyVaso.DataSource = RsPC;
				dgdQtyVaso.DataBind();
				isNew = false;
			}
			else
			{
				isNew = true;
				int VasoNo = 1;
				for (int i = 1; i <= Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoGroup"].ToString()); i++)
				{
					for (int iLoop=1; iLoop <= noVaso[i-1]; iLoop++)
					{
						DataRow drVaso = dtVaso.NewRow();
						drVaso["GroupNo"] = i.ToString();
						drVaso["VasoNo"]="Vaso " + VasoNo.ToString(); VasoNo++;
						drVaso["NoLaminas"] = string.Empty;
						dtVaso.Rows.Add(drVaso);
					}
				}
				Session[this.Context.User.Identity.Name+"TotNoVaso"] = VasoNo - 1;
				dgdQtyVaso.DataSource=dsVaso;
				dgdQtyVaso.DataBind();
			}

			if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString() == "5") //if its Released or Already Grouped then disable the textbox column
			{
				dgdQtyVaso.Columns[2].Visible = false;
				dgdQtyVaso.Columns[3].Visible = true;
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//to assign the values and navigate the form
		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				//to get an instance for validation
				Validation pltVdlt=new Validation();
				int[] aryLaminas = new int[20];

				int TtlVaso = 0;
				for(int iLoop = 0; iLoop < dgdQtyVaso.Items.Count; iLoop++)
				{
					string sLaminas;
					if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
						sLaminas=((Label) dgdQtyVaso.Items[iLoop].FindControl("lblLaminas")).Text.ToString();
					else
						sLaminas=((TextBox) dgdQtyVaso.Items[iLoop].FindControl("txtLaminas")).Text.ToString();

					if (pltVdlt.IsNumber(sLaminas) == false)
						throw new Exception("El número de láminas por vaso es incorrecto");
					TtlVaso+=int.Parse(sLaminas);
					aryLaminas[iLoop]=int.Parse(sLaminas);

					if (!isNew)
					{
						int Lamina;
						//To Check the Laminas Changed or Not
						//if Lamina Value changed the set the status to NEW 
						SICALNet.BusinessLogicLayer.PartidasColor PColor = new SICALNet.BusinessLogicLayer.PartidasColor();
						if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
							Lamina = PColor.GetNoLaminas(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(), iLoop + 1);
						else
							Lamina = PColor.GetNoLaminasCombined(sec,iLoop + 1);
						if (Convert.ToInt32(sLaminas)!=Lamina) isNew = true;
					}
				}
	
				if (isNew)
				{
//					int[] NoVaso =(int[])Session[this.Context.User.Identity.Name+"NoVaso"];
//					int VasoQty = 0, tmpCnt = 0;
//					for (int i = 0; i < Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoGroup"].ToString()); i++)
//					{
//						int tmpQty = 0;
//						for (int j = 0; j < NoVaso[i]; j++)
//							tmpQty = tmpQty + Convert.ToInt32(((TextBox)dgdQtyVaso.Items[tmpCnt++].FindControl("txtLaminas")).Text);
//						VasoQty = VasoQty + tmpQty / NoVaso[i];
//					}

					int[] NoVaso =(int[])Session[this.Context.User.Identity.Name+"NoVaso"];
					int VasoQty=0,tmpCnt = 0,tmpCnt2=0;

					for (int i = 0; i < Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoGroup"].ToString()); i++)
					{
						VasoQty=0;
						for (int j = 0; j < NoVaso[i]; j++)
						{	if((Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")&&(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])>=Convert.ToInt32(((TextBox)dgdQtyVaso.Items[tmpCnt2++].FindControl("txtLaminas")).Text)))
									throw new Exception(" The Entered Laminas should be Greater Than or Equal to Number of Secuencias in Combined Consultation");
							VasoQty+= Convert.ToInt32(((TextBox)dgdQtyVaso.Items[tmpCnt++].FindControl("txtLaminas")).Text);
						}
						if((Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")&&(VasoQty!=Convert.ToInt32(txtCantidad.Text)))
								throw new Exception(string.Format("La suma de láminas por vaso debe ser igual a la cantidad total de láminas en los vasos del grupo {0}",i+1));
						if ((VasoQty != Convert.ToInt32(txtCantidad.Text))&&(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0"))
							throw new Exception(string.Format("La suma de láminas por vaso debe ser igual a la cantidad total de láminas en los vasos del grupo {0}",i+1));
//							throw new Exception("Total No. of Laminas and Cantidad should be equal");
					}
				}

				Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;

//				Response.Redirect("ColorWOqty.aspx?linea="+Request.QueryString["linea"]);
				Response.Redirect("ColorWOFinal.aspx?isNew=" + isNew);
			}
			catch(Exception ErrHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ ErrHand.Message +"');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
		}

		//to navigate the form into back
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NoOfVasos.aspx");
		}
		
		

	}
}
