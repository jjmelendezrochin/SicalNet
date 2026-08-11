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
using SICALNet.BusinessEntities;
using  SICALNet.BusinessLogicLayer;

namespace UserInterface.Structures
{
	/// <summary>
	/// Summary description for Medida.
	/// </summary>
	public class Medida : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtIdMedida;
		protected System.Web.UI.WebControls.TextBox txtCentimetros;
		protected System.Web.UI.WebControls.TextBox txtPulgadas;
		protected System.Web.UI.WebControls.TextBox txtNominal;
		protected System.Web.UI.WebControls.TextBox txtOtro;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdCancel;
	
		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;

		protected Controls.MedidaGrid dgMedida;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.txtIdMedida.TextChanged += new System.EventHandler(this.txtIdMedida_TextChanged);
			this.txtCentimetros.TextChanged += new System.EventHandler(this.txtCentimetros_TextChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{		
			/*if(txtIdMedida.Text.Trim() =="")
			{
				lblErrorMsg.Text ="Debe capturar un identificador para la medida";
				Clear();
				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdMedida.ClientID + "').focus();" + "</SCRIPT>");		
				return;
			}
			else
			{
				Validation utlValidate=new Validation();
				if(utlValidate.IsNumber(txtIdMedida.Text))
				{*/
					MedidaInfo belMedida=new MedidaInfo(txtCentimetros.Text.Trim(),txtPulgadas.Text.Trim(),txtNominal.Text.Trim(),txtOtro.Text.Trim());
					SICALNet.BusinessLogicLayer.Medida bllMedida=new SICALNet.BusinessLogicLayer.Medida();
					try
					{
						if (bllMedida.InsertMedida(belMedida)) 
						{
							
							// alta de medida en la bitacora
							SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
							BLLBitacora.Insertcomando("Alta de Id medida: " + belMedida.IdMedida + " medida: " + belMedida.Centimetros,this.User.Identity.Name.ToString());

							dgMedida.BindGrid();
							Clear();
							prcErrorDisplay(null,"La nueva medida se agrego existosamente");
						}
						else
						{
							prcErrorDisplay(null,"Debe de captura o seleccionar los datos requeridos antes de intentar guardar un registro");
						}

					}
					catch(System.Data.SqlClient.SqlException errHand)
					{
						prcErrorDisplay(errHand, "Este identificador ya esta en uso para otra medida");
					}
					catch
					{
						throw;
					}
				/*}
				else
				{
					prcErrorDisplay(null,"Id Medida should be a numeber");
					Clear();
					RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdMedida.ClientID + "').focus();" + "</SCRIPT>");		
					return;
				}*/
			}

			
			private void Clear()
			{
				txtIdMedida.Text=string.Empty;
				txtCentimetros.Text=string.Empty;
				txtPulgadas.Text=string.Empty;
				txtNominal.Text=string.Empty;
				txtOtro.Text=string.Empty;
			}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Inforamción sobre el catalogo de Medida",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (errStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else
			{
				//to display the success msg
				lblErrorMsg.Text=errStatus;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
		}
	
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		private void txtIdMedida_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtCentimetros_TextChanged(object sender, System.EventArgs e)
		{
		
		}
			

		}
	}
