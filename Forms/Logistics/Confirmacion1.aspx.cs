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
using SICALNet.Utilities;
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using CrystalDecisions.Shared;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultMessage.
	/// </summary>
	public class Confirmacion : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button Cancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNewMessage;
		protected System.Web.UI.WebControls.TextBox txtOldMessages;
		protected System.Web.UI.HtmlControls.HtmlForm PdtLogForm;
		protected System.Web.UI.WebControls.Label lblRequiereNombre;
		protected System.Web.UI.WebControls.Label lblRequiereMotivo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblmsg;
		protected System.Web.UI.WebControls.Label lblOperacion;
		protected System.Web.UI.WebControls.Label lblSecueciaNo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblMensajeOperacion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		protected System.Web.UI.WebControls.DropDownList cboMotivo;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblValores;
		protected System.Web.UI.WebControls.Label lblBitaCora;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				// llenado de combo de familias
				cboMotivo.Items.Clear();						
				SICALNet.BusinessLogicLayer.MotivoAjusteProgramaProduccion BLLMAPP=new SICALNet.BusinessLogicLayer.MotivoAjusteProgramaProduccion();
				IList RsEquals=(IList) BLLMAPP.SelectMotivoAjustesProgramaProduccion(2);
				cboMotivo.DataSource = RsEquals;
				cboMotivo.DataTextField = "Motivo";			
				cboMotivo.DataValueField  = "idMotivo";
				cboMotivo.DataBind();
				cboMotivo.SelectedIndex=1;

				lblSecueciaNo.Text=Request.QueryString["Secuencia"].ToString();
				lblFecha.Text=Request.QueryString["Fecha"].ToString();
				lblLinea.Text=Request.QueryString["Linea"].ToString();
				lblOperacion.Text=Request.QueryString["Operacion"].ToString();
				lblValores.Text=Request.QueryString["Valores"].ToString(); 
				this.lblMensajeOperacion.Text = lblValores.Text;
				// 1 alta, 2 baja en grupo, 3 cambio (No actualiza solo registra), 4 baja individual (No borra solo registra)
				int idOperacion = int.Parse(Request.QueryString["Operacion"].ToString());

				SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
				txtOldMessages.Text=(string)blProgramma.LoadLog(lblSecueciaNo.Text.ToString());

				if (int.Parse(lblOperacion.Text)==2)
				{
					this.Cancelar.Visible=true;
					Page.RegisterStartupScript("mover", "<script>document.forms[0].tabla_interior.style.left=10000;</script>");
				}
				else
				{
					this.Cancelar.Visible=false;
					Page.RegisterStartupScript("mover", "<script>document.forms[0].tabla_interior.style.left=50000;</script>");
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			if(this.txtOldMessages.Text=="")
			{
				this.lblRequiereNombre.Visible=true;
				return;
			}
			else
				this.lblRequiereNombre.Visible=false;
			if(this.txtNewMessage.Text=="")
			{
				this.lblRequiereMotivo.Visible=true;
				return;
			}
			else
				this.lblRequiereMotivo.Visible=false;

			if(lblOperacion.Text=="1")
			{
				// Inserción de secuencia
				this.lblmsg.Visible=true;
				lblmsg.Text = lblmsg.Text + string.Format("La secuencia {0} se insertó con éxito {1} ", lblSecueciaNo.Text, Environment.NewLine);
				string sBitacora = string.Format("La secuencia {0} se agregó por el usuario {1}, por el motivo {2}",lblSecueciaNo.Text, this.txtOldMessages.Text, this.txtNewMessage.Text);
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
				string messageToSave= string.Format("{0} \n {1} [{2} {3}]",string.Empty,sBitacora.Trim(),this.Context.User.Identity.Name,DateTime.Now.ToString("dd-MMM-yy"));
				blProgramma.AddLog(lblSecueciaNo.Text.ToString().Trim(),messageToSave);
			}
			if(lblOperacion.Text=="2")
			{
				// Borrado de secuencia
				string sSecuencias = lblSecueciaNo.Text;
				string [] split = sSecuencias.Split(new Char [] {','});
				foreach (string secuencia in split) 
				{
					if (secuencia.Trim() != "")
					{
						this.lblmsg.Visible=true;
						lblmsg.Text = string.Format("La secuencia {0} se borró con éxito {1} ", secuencia, Environment.NewLine);
						string sBitacora = string.Format("La secuencia {0} se borró por el usuario {1}, por el motivo {2}",secuencia, this.txtOldMessages.Text, this.txtNewMessage.Text);
						// guardamos en la bitacora
						SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
						BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

						SICALNet.BusinessLogicLayer.MotivosAjusteProgProd BLLMotivos = 
							new SICALNet.BusinessLogicLayer.MotivosAjusteProgProd();				
						BLLMotivos.InsertaMotivo(0, int.Parse(Request.QueryString["Linea"].ToString()),int.Parse(this.cboMotivo.SelectedValue), int.Parse(this.lblOperacion.Text),this.txtNewMessage.Text, secuencia,this.txtOldMessages.Text, this.User.Identity.Name.ToString());
						
						this.DelSequence(secuencia.Trim(), sBitacora);

						SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
						string messageToSave= string.Format("{0} \n {1} [{2} {3}]",string.Empty,sBitacora.Trim(),this.Context.User.Identity.Name,DateTime.Now.ToString("dd-MMM-yy"));
						blProgramma.AddLog(secuencia.Trim(),messageToSave);

					}
				}
			}
			if(lblOperacion.Text=="3")
			{
				// Actualización de secuencia
				this.lblmsg.Visible=true;
				lblmsg.Text = lblmsg.Text + string.Format("La secuencia {0} se actualizó con éxito {1} ", lblSecueciaNo.Text, Environment.NewLine);
				// guardamos en la bitacora
				string sBitacora = string.Format("La secuencia {0} se actualizó por el usuario {1}, por el motivo {2}",lblSecueciaNo.Text, this.txtOldMessages.Text, this.txtNewMessage.Text);
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando(sBitacora,this.User.Identity.Name.ToString());

				SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
				string messageToSave= string.Format("{0} \n {1} [{2} {3}]",string.Empty,sBitacora.Trim(),this.Context.User.Identity.Name,DateTime.Now.ToString("dd-MMM-yy"));
				blProgramma.AddLog(lblSecueciaNo.Text.Trim(),messageToSave);
			}
			if(lblOperacion.Text=="4")
			{
				// Borrado de secuencia individual
				this.lblmsg.Visible=true;
				lblmsg.Text = lblmsg.Text + string.Format("La secuencia {0} se eliminó con éxito {1} ", lblSecueciaNo.Text, Environment.NewLine);
				string sBitacora = string.Format("La secuencia {0} se eliminó por el usuario {1}, por el motivo {2}",lblSecueciaNo.Text, this.txtOldMessages.Text, this.txtNewMessage.Text);
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
				string messageToSave= string.Format("{0} \n {1} [{2} {3}]",string.Empty,sBitacora.Trim(),this.Context.User.Identity.Name,DateTime.Now.ToString("dd-MMM-yy"));
				blProgramma.AddLog(lblSecueciaNo.Text.Trim(),messageToSave);
			}
			this.btnAgregar.Enabled= false;
			this.Cancelar.Visible=true;
		}

		private void Cancelar_Click(object sender, System.EventArgs e)
		{
			
			if(lblOperacion.Text=="1")
			{
				Page.RegisterStartupScript("__close", "<script>window.location='ProgrammaProduction.aspx'</script>");
			}
			else if(lblOperacion.Text=="2")
			{
				Page.RegisterStartupScript("__close", "<script>window.close();</script>");
			}
			else if(lblOperacion.Text=="3")
			{
				Page.RegisterStartupScript("__close", "<script>window.location='ProgrammaProduction.aspx';</script>");
			}
			else if(lblOperacion.Text=="4")
			{
				Page.RegisterStartupScript("__close", "<script>window.location='ProgrammaProduction.aspx';</script>");
			}
		}

		private void DelSequence(string Sequence, string sComentario)
		{
			SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(Sequence);
			SICALNet.BusinessLogicLayer.Programa bllProgramma= new SICALNet.BusinessLogicLayer.Programa();

			//Se cargan los datos del la secuencia
			IList objProgramaInfo = bllProgramma.Load(Sequence);
			int Cantidad = Convert.ToInt32(((ProgramaInfo)objProgramaInfo[0]).Cantidad);
			int IdStatus = ((ProgramaInfo)objProgramaInfo[0]).IdStatus;
		
			if(bllProgramma.HasWorkOrders(belProgramma))
			{
				if(IdStatus==Convert.ToInt32(ConfigurationManager.AppSettings["SequenceStatusReleased"]))
					throw new Exception("La Secuencia "+ Sequence+" ya está cancelada, no puede ser cancelada nuevamente");
				else if(IdStatus==Convert.ToInt32(ConfigurationManager.AppSettings["SequenceStatusCancel"]))
					throw new Exception("La Secuencia "+ Sequence+" ya está cancelada, no puede ser cancelada nuevamente");
				SICALNet.BusinessEntities.OrdenesTrabajoInfo oInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Sequence,0,Convert.ToInt32(ConfigurationManager.AppSettings["StatusCancel"]),Convert.ToInt32(ConfigurationManager.AppSettings["SequenceStatusCancel"]));						
				bllProgramma.CancelSecuence(oInfo); 
				bllProgramma.AddLog(Sequence, sComentario);
				//to get the weight of each Laminas for the codigosap of that secuencia
				bllProgramma.UpdateReaccion(Sequence,DateTime.Parse(lblFecha.Text).ToString("dd/MMM/yyyy"),Convert.ToInt32(lblLinea.Text),Cantidad);
				//lblmsg.Text = string.Format("* La secuencia {0} ya tiene sus Ordenes de Trabajo, por lo tanto no podrá eliminarse. Cancele la orden de trabajo",Sequence);				
			}
			else
			{
				
				bllProgramma.DeleteSecuence(belProgramma); // Borrado de la secuencia				
			}
			
			this.lblmsg.Visible=true;
			lblmsg.Text = lblmsg.Text + string.Format("La secuencia {0} se eliminó con éxito {1} ", Sequence, Environment.NewLine);
			string sBitacora = string.Format("La secuencia {0} se eliminó con éxito por el usuario {1}, por el motivo {2}",Sequence, this.txtOldMessages.Text, this.txtNewMessage.Text);
			// guardamos en la bitacora
			SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
			BLLBitacora.Insertcomando("Borrado de Secuencia: " + Sequence + " " + sBitacora ,this.User.Identity.Name.ToString());
		}
	

		

		//this event is called , when the user select the record from datagrid
		/*	private void btnSecuencia_Click(object sender, System.EventArgs e)
			{
				try
				{
				
				
					string sSec = ((Label) ConsultPrgGridControl.dgdProgram.Items[ConsultPrgGridControl.dgdProgram.SelectedIndex].Cells[0].FindControl("lblSecuencia")).Text.ToString();
					//to get the instance for BusinessLogicLayer
					SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
					// to Call the Select method
					txtBitacora.Text= BLLPrg.LoadLog(sSec);
					btnSecuencia.Text=sSec;
					//to set the visibilities
					if (btnCancelar.CommandName != "Add")
						prc_EnableDisable("011110");
					else
						prc_EnableDisable("011111");
				}
				catch
				{
				}
			}

			//to call the add log UC 
			private void btnAddLog_Click(object sender, System.EventArgs e)
			{	btnCancelar.CommandName="Add";
				btnCancelar.Text="Add Log Canceler";
				btnCancelar.Width=120;
				prc_EnableDisable("011010");
			}

			//to cancel the operation
			private void btnCancelar_Click(object sender, System.EventArgs e)
			{
				if (btnCancelar.CommandName != "Cancel")
					prc_EnableDisable("100000");
				else
				{
					btnCancelar.CommandName="Add";
					btnCancelar.Text = "Add Log Canceler";
					prc_EnableDisable("011111");
				}
			}

			//to edit the data
			private void btnEditar_Click(object sender, System.EventArgs e)
			{
				try
				{
					if (btnEditar.CommandName == "Edit")
					{
						btnEditar.CommandName="Accept";
						btnCancelar.CommandName="Cancel";
						btnEditar.Text="Acteptar";
						btnCancelar.Text="Canceler";
					}
					else
					{
						if (txtBitacora.Text.ToString().Trim() == string.Empty)
							throw new Exception("Bitacora should not be null");
						//to get the instance for BusinessLogicLayer
						SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
						// to Call the Select method
						BLLPrg.AddLog(btnSecuencia.Text.ToString(),txtBitacora.Text.ToString());

						//to set the name for corresponding controls
						btnEditar.CommandName="Edit";
						btnCancelar.CommandName="Add";

						btnEditar.Text="Editar";
						btnCancelar.Text="Add Log Canceler";
						//to give the success msg
						throw new Exception("La bitácora se agrego con éxito");
					}
				}
				catch(Exception erHnd)
				{
					//to display the msg for user
					string ScriptString="<script language='javascript'>alert('"+ erHnd.Message +"');</script>"; 
					ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				}
			}*/
	}
}