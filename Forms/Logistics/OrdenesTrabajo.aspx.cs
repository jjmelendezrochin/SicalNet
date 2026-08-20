using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace UserInterface.Forms.Logistics
{
	/// <summary>
	/// Summary description for OrdenesTrabajo.
	/// </summary>
	public class OrdenesTrabajo : System.Web.UI.Page
	{
		protected Controls.ConsultProgramGrid ConsultPrgGridControl;
		protected System.Web.UI.WebControls.Button cmdCreateWO;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button cmdExit;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label2;

		private void Page_Load(object sender, System.EventArgs e)
		{
			cmdCreateWO.Attributes.Add("onClick","showWaitControls();");
			// Put user code to initialize the page here
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
			this.cmdCreateWO.Click += new System.EventHandler(this.cmdCreateWO_Click);
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void cmdCreateWO_Click(object sender, System.EventArgs e)
		{

			try
			{
				/*****modificado por alejandro.hernandez@nasoft.com 21022006****/
				StringBuilder strSequence = new StringBuilder();
				//string strSequence=string.Empty;
				StringBuilder strCancelledSequences=new StringBuilder();
				//string strCancelledSequences=string.Empty;
				StringBuilder strGeneratedSequences= new StringBuilder();
				//string strGeneratedSequences= string.Empty;
				/*****fin modificación***/

				bool noSequenceSelected=true;
				for (int i=0;i<ConsultPrgGridControl.lstProgram.Items.Count;i++)
				{
					CheckBox currentCheck=(CheckBox)ConsultPrgGridControl.lstProgram.Items[i].FindControl("chkSelected");
					if(currentCheck.Checked==true)
					{
						noSequenceSelected=false;
						string sSec = ((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblSecuencia")).Text.ToString();
						string CodigoSAP = ((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblMaterial")).Text.ToString();
						int IdArea = int.Parse(((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblArea")).Text.ToString());
						int IdStatus = int.Parse(((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblStatus")).Text.ToString());
						string AreaDesc = ((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblAreaDesc")).Text.ToString();
						string StatusDesc = ((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblStatusDesc")).Text.ToString();
						int IdLinea  = int.Parse(((Label) ConsultPrgGridControl.lstProgram.Items[i].FindControl("lblLinea")).Text.ToString());
						int IdPlanta=1;
						if (IdLinea >3 && IdLinea!=9)
							IdPlanta=2;
						
						//to get the instance for Business entities
						SICALNet.BusinessEntities.ProgramaInfo BEPrg= new SICALNet.BusinessEntities.ProgramaInfo(sSec,"",0,0,0,0,string.Empty,"",0,0,"","",0,"","","",IdArea,IdStatus,"",AreaDesc,StatusDesc);
						//to get the instance for BusinessLogicLayer
						SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
						// to Call the Select method
						if (!BLLPrg.HasWorkOrders(BEPrg))
						{
							if (IdStatus==int.Parse(ConfigurationManager.AppSettings["SequenceStatusCancel"]))
							{
								/****modificado por alejandro.hernandez@nasoft.com 21022006****/
								if (strCancelledSequences.Length == 0)
								{
									strCancelledSequences = new StringBuilder("La(s) siguiente(s) Secuencia(s) fueron canceladas, por lo que no se generarán sus órdenes de trabajo: ");
								}
								strCancelledSequences.Append("\\n - ").Append(BEPrg.Secuencia); 
								//strCancelledSequences += "\\n - " + BEPrg.Secuencia;

								/***fin modificación***/

							}
							else
							{
								//throw new Exception("La Orden de Trabajo ya existe");
								//to get the info from material table
							   
								SICALNet.BusinessEntities.MaterialInfo BEmat=new SICALNet.BusinessEntities.MaterialInfo(CodigoSAP,"",0,"",0,"",0,"",0,0,0,0,0,"","","","","","","","","", IdPlanta,false);
								SICALNet.BusinessLogicLayer.Material blMaterial = new SICALNet.BusinessLogicLayer.Material();
								IList RsMaterial = blMaterial.SelectMaterialList(BEmat);
								if (RsMaterial.Count==0)
								{
									string sError = "";
									sError = "La(s) siguiente(s) Secuencia(s) no tienen existencia, \\n por lo que no se podrá generar su órden: ";
									strSequence.Append(sError);
									strSequence.Append("\\n  - ").Append(BEPrg.Secuencia);
									strSequence.Append("\\n");
								}
								else
								{
									SICALNet.BusinessEntities.MaterialInfo BEmaterial = (SICALNet.BusinessEntities.MaterialInfo) RsMaterial[0];
									if(BEmaterial.IdEstadoMaterial!=int.Parse(ConfigurationManager.AppSettings["IdInstrucciones"]))
									{
										//to get the instance for Business entities
										SICALNet.BusinessEntities.OrdenesTrabajoInfo BEOrdTra= new SICALNet.BusinessEntities.OrdenesTrabajoInfo(sSec,0,0,null,Context.User.Identity.Name);
										//to get the instance for BusinessLogicLayer
										SICALNet.BusinessLogicLayer.OrdenesTrabajo BLLOrdTra= new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
										BLLOrdTra.Insert(BEOrdTra);
										//Generate message informing the results to the user

										/****modificado por alejandro.hernandez@nasoft.com 21022006****/
										if (strGeneratedSequences.Length==0)
											//if (strGeneratedSequences==string.Empty)
										{
											strGeneratedSequences= new StringBuilder("Se generaron exitosamente las órdenes de trabajo para las siguientes secuencias: ");
										}
										strGeneratedSequences.Append("\\n - ").Append(BEPrg.Secuencia);
										//strGeneratedSequences+= "\\n - " + BEPrg.Secuencia;
										/***fin modificación***/

										SICALNet.BusinessLogicLayer.Colour blColor = new SICALNet.BusinessLogicLayer.Colour();
										blColor.CheckTransperant(BEPrg.Secuencia,1);
									}
								}
							}
						}
						else
						{
							//if (strSequence.Length==0) 
							//{
							strSequence.Append("La(s) siguiente(s) Secuencia(s) ya cuentan con sus órdenes de trabajo, \\n por lo que no se volverán a generar: ");
							//}
							//modificado por alejandro.hernandez@nasoft.com 21022006
							strSequence.Append("\\n - ").Append(BEPrg.Secuencia);
							strSequence.Append("\\n");
							//strSequence += "\\n - " + BEPrg.Secuencia; 
							//fin modificación
						}
					
						// Code to Insert Record for OTReaccion
						SICALNet.BusinessLogicLayer.OrdenesTrabajo WO = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						WO.InsertReaccionWO(sSec);
					}
				}

				//Clear the Check boxes in the Grid
				if (ConsultPrgGridControl.lstProgram.Items.Count>0)
				{
					//((CheckBox) ConsultPrgGridControl.dgdProgram.Controls[0].FindControl("chkAll")).Checked=false;
					for (int i=0; i<ConsultPrgGridControl.lstProgram.Items.Count;i++)
					{
						((CheckBox)(ConsultPrgGridControl.lstProgram.Items[i].FindControl("chkSelected"))).Checked = false;
					}
				}

				//To Popup the message box if the user didnt select any sequence
				if (noSequenceSelected)
				{
					Page.RegisterStartupScript("existing", "<script language='JavaScript'>alert('Por favor seleccione la secuencia para la que desea generar las órdenes de trabajo.');</script>");
				}

				//To Popup the message box for the work order already generated Sequencia
				//modificado por alejandro.hernandez@nasoft.com 21022006
				if (strSequence.Length>0)
				//if (strSequence!="")
				//fin modificación
				{
					Page.RegisterStartupScript("existing", "<script language='JavaScript'>alert('"+strSequence.ToString()+"');</script>");
				}
				//To Popup the message box for the work order cancelled
				//modificado por alejandro.hernandez@nasoft.com 21022006
				if (strCancelledSequences.Length>0)
				//if (strCancelledSequences!="")
				{
					Page.RegisterStartupScript("cancelled", "<script language='JavaScript'>alert('"+strCancelledSequences.ToString()+"');</script>");
				}

				//To Popup the message box for the work order cancelled
				//modificado por alejandro.hernandez@nasoft.com 21022006
				if (strGeneratedSequences.Length>0)
				{
					Page.RegisterStartupScript("successfull", "<script language='JavaScript'>alert('"+strGeneratedSequences.ToString()+"');</script>");
				}
				

			}
			catch(Exception erHnd)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ erHnd.Message.Replace("'"," ") +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}		
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

	}
}
