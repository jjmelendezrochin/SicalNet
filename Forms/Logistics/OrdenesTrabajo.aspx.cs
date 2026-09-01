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
				StringBuilder strSequence = new StringBuilder();
				StringBuilder strCancelledSequences = new StringBuilder();
				StringBuilder strGeneratedSequences = new StringBuilder();

				bool noSequenceSelected = true;

				for (int i = 0;
					i < ConsultPrgGridControl.lstProgram.Items.Count;
					i++)
				{
					CheckBox currentCheck = (CheckBox)
						ConsultPrgGridControl.lstProgram.Items[i]
						.FindControl("chkSelected");

					if (currentCheck.Checked)
					{
						noSequenceSelected = false;

						string sSec = ((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblSecuencia")).Text;

						string CodigoSAP = ((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblMaterial")).Text;

						int IdArea = int.Parse(((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblArea")).Text);

						int IdStatus = int.Parse(((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblStatus")).Text);

						string AreaDesc = ((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblAreaDesc")).Text;

						string StatusDesc = ((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblStatusDesc")).Text;

						int IdLinea = int.Parse(((Label)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("lblLinea")).Text);

						int IdPlanta = 1;

						if (IdLinea > 3 && IdLinea != 9)
							IdPlanta = 2;

						SICALNet.BusinessEntities.ProgramaInfo BEPrg =
							new SICALNet.BusinessEntities.ProgramaInfo(
								sSec, "", 0, 0, 0, 0, string.Empty, "",
								0, 0, "", "", 0, "", "", "",
								IdArea, IdStatus, "", AreaDesc, StatusDesc
							);

						SICALNet.BusinessLogicLayer.Programa BLLPrg =
							new SICALNet.BusinessLogicLayer.Programa();

						if (!BLLPrg.HasWorkOrders(BEPrg))
						{
							if (IdStatus == int.Parse(
								ConfigurationManager.AppSettings[
									"SequenceStatusCancel"
								]))
							{
								if (strCancelledSequences.Length == 0)
								{
									strCancelledSequences.Append(
										"La(s) siguiente(s) secuencia(s) fueron " +
										"canceladas, por lo que no se generarán " +
										"sus órdenes de trabajo:"
									);
								}

								strCancelledSequences
									.Append(Environment.NewLine)
									.Append(" - ")
									.Append(BEPrg.Secuencia);
							}
							else
							{
								SICALNet.BusinessEntities.MaterialInfo BEmat =
									new SICALNet.BusinessEntities.MaterialInfo(
										CodigoSAP, "", 0, "", 0, "", 0, "",
										0, 0, 0, 0, 0, "", "", "", "", "",
										"", "", "", "", IdPlanta, false
									);

								SICALNet.BusinessLogicLayer.Material blMaterial =
									new SICALNet.BusinessLogicLayer.Material();

								IList RsMaterial =
									blMaterial.SelectMaterialList(BEmat);

								if (RsMaterial.Count == 0)
								{
									strSequence.Append(
										"La secuencia no tiene existencia, por lo que " +
										"no se podrá generar su orden:"
									);

									strSequence
										.Append(Environment.NewLine)
										.Append(" - ")
										.Append(BEPrg.Secuencia)
										.Append(Environment.NewLine);
								}
								else
								{
									SICALNet.BusinessEntities.MaterialInfo BEmaterial =
										(SICALNet.BusinessEntities.MaterialInfo)
											RsMaterial[0];

									if (BEmaterial.IdEstadoMaterial != int.Parse(
										ConfigurationManager.AppSettings[
											"IdInstrucciones"
										]))
									{
										SICALNet.BusinessEntities.OrdenesTrabajoInfo
											BEOrdTra =
											new SICALNet.BusinessEntities
												.OrdenesTrabajoInfo(
													sSec,
													0,
													0,
													null,
													Context.User.Identity.Name
												);

										SICALNet.BusinessLogicLayer.OrdenesTrabajo
											BLLOrdTra =
											new SICALNet.BusinessLogicLayer
												.OrdenesTrabajo();

										BLLOrdTra.Insert(BEOrdTra);

										if (strGeneratedSequences.Length == 0)
										{
											strGeneratedSequences.Append(
												"Se generaron correctamente las órdenes " +
												"de trabajo para las siguientes secuencias:"
											);
										}

										strGeneratedSequences
											.Append(Environment.NewLine)
											.Append(" - ")
											.Append(BEPrg.Secuencia);

										SICALNet.BusinessLogicLayer.Colour blColor =
											new SICALNet.BusinessLogicLayer.Colour();

										blColor.CheckTransperant(
											BEPrg.Secuencia,
											1
										);
									}
								}
							}
						}
						else
						{
							if (strSequence.Length == 0)
							{
								strSequence.Append(
									"La(s) siguiente(s) secuencia(s) ya cuentan " +
									"con órdenes de trabajo, por lo que no se " +
									"volverán a generar:"
								);
							}

							strSequence
								.Append(Environment.NewLine)
								.Append(" - ")
								.Append(BEPrg.Secuencia);
						}

						SICALNet.BusinessLogicLayer.OrdenesTrabajo WO =
							new SICALNet.BusinessLogicLayer.OrdenesTrabajo();

						WO.InsertReaccionWO(sSec);
					}
				}

				if (ConsultPrgGridControl.lstProgram.Items.Count > 0)
				{
					for (int i = 0;
						i < ConsultPrgGridControl.lstProgram.Items.Count;
						i++)
					{
						((CheckBox)
							ConsultPrgGridControl.lstProgram.Items[i]
								.FindControl("chkSelected")).Checked = false;
					}
				}

				if (noSequenceSelected)
				{
					MostrarSicalAlert(
						"Por favor, seleccione la secuencia para la que " +
						"desea generar las órdenes de trabajo.",
						"warning",
						"Secuencia requerida"
					);

					return;
				}

				StringBuilder mensajeResultado = new StringBuilder();

				if (strSequence.Length > 0)
				{
					mensajeResultado.Append(strSequence);
				}

				if (strCancelledSequences.Length > 0)
				{
					if (mensajeResultado.Length > 0)
					{
						mensajeResultado.Append(Environment.NewLine);
						mensajeResultado.Append(Environment.NewLine);
					}

					mensajeResultado.Append(strCancelledSequences);
				}

				if (strGeneratedSequences.Length > 0)
				{
					if (mensajeResultado.Length > 0)
					{
						mensajeResultado.Append(Environment.NewLine);
						mensajeResultado.Append(Environment.NewLine);
					}

					mensajeResultado.Append(strGeneratedSequences);
				}

				if (mensajeResultado.Length > 0)
				{
					bool existenAdvertencias =
						strSequence.Length > 0 ||
						strCancelledSequences.Length > 0;

					MostrarSicalAlert(
						mensajeResultado.ToString(),
						existenAdvertencias ? "warning" : "success",
						existenAdvertencias
							? "Resultado de la generación"
							: "Órdenes generadas"
					);
				}
			}
			catch (Exception erHnd)
			{
				MostrarSicalAlert(
					erHnd.Message,
					"error",
					"Error al generar las órdenes de trabajo"
				);
			}
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

		private void MostrarSicalAlert(string mensaje, string tipo, string titulo)
		{
			string script = string.Format(
				"SicalAlert.mostrar(\"{0}\", \"{1}\", \"{2}\");",
				System.Web.HttpUtility.JavaScriptStringEncode(mensaje),
				System.Web.HttpUtility.JavaScriptStringEncode(tipo),
				System.Web.HttpUtility.JavaScriptStringEncode(titulo)
			);

			ClientScript.RegisterStartupScript(
				this.GetType(),
				"SicalAlert_" + Guid.NewGuid().ToString("N"),
				script,
				true
			);
		}

	}
}
