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

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Descripción breve de VidriosTamanio.
	/// </summary>
	public class VidriosTamanio : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.TextBox txtIdTamanio;
		protected System.Web.UI.WebControls.TextBox txtMedida;
		protected System.Web.UI.WebControls.TextBox txtAnchoNormal;
		protected System.Web.UI.WebControls.TextBox txtLargoNormal;
		protected System.Web.UI.WebControls.TextBox txtMedidaVidrio;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtEspesor;
		protected System.Web.UI.WebControls.TextBox txtAnchoVidrio;
		protected System.Web.UI.WebControls.TextBox txtLargoVidrio;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		ErrorHandling errFileWrite=new ErrorHandling();
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtGrosor;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected Controls.VidriosTamanio VidriosTamanio1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			cmdAdd.Attributes.Add("onclick", "if(confirm('¿Está seguro que desea insertar esta medida de vidrio?')){}else{return false}"); 
		}

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{   			
			this.txtAnchoVidrio.TextChanged += new System.EventHandler(this.txtAnchoVidrio_TextChanged);
			this.txtEspesor.TextChanged += new System.EventHandler(this.txtEspesor_TextChanged);
			this.txtGrosor.TextChanged += new System.EventHandler(this.txtGrosor_TextChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			// TODO: AGREGAR FUNCIONALIDAD PARA INSERTAR MODIFICAR Y BORRAR UN REGISTRO

//			if(txtAnchoVidrio.Text.Trim() =="" || this.txtLargoVidrio.Text.Trim() =="" ||
//				this.txtLargoNormal.Text.Trim() =="" || this.txtLargoVidrio.Text.Trim() =="" 
//				|| this.txtEspesor.Text.Trim() =="" || this.txtGrosor.Text.Trim() =="" )
//			{
//				lblErrorMsg.Text ="Debe capturar los datos marcados con (*) que son requeridos";
//				Clear();
//				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtMedidaVidrio.ClientID + "').focus();" + "</SCRIPT>");		
//				return;
//			}

			this.txtMedida.Text=this.txtLargoNormal.Text + "X" + this.txtAnchoNormal.Text + "X" + this.txtGrosor.Text ;
			this.txtMedidaVidrio.Text=this.txtLargoVidrio.Text+ "X" + this.txtAnchoVidrio.Text + "X" + this.txtGrosor.Text ;

			VidrioInfo belVidrioTamanio=new VidrioInfo(this.txtMedida.Text,this.txtMedidaVidrio.Text,int.Parse(this.txtAnchoNormal.Text), int.Parse(this.txtLargoNormal.Text), int.Parse(this.txtAnchoVidrio.Text), int.Parse(this.txtLargoVidrio.Text), float.Parse(this.txtEspesor.Text), this.txtGrosor.Text);
			SICALNet.BusinessLogicLayer.VidrioTamanio bllVidrioTamanio=new SICALNet.BusinessLogicLayer.VidrioTamanio();
			try
			{
				if (bllVidrioTamanio.InsertVidrioTamanio(belVidrioTamanio)) 
				{							
					// alta de medida en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
					BLLBitacora.Insertcomando("Alta de medida: " + belVidrioTamanio.Medida,this.User.Identity.Name.ToString());

				    VidriosTamanio1.BindGrid();
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
		}

		private void Clear()
		{
			this.txtIdTamanio.Text=string.Empty;
			this.txtMedida.Text=string.Empty;
			this.txtMedidaVidrio.Text=string.Empty;
			this.txtLargoVidrio.Text=string.Empty;
			this.txtLargoNormal.Text=string.Empty;
			this.txtAnchoVidrio.Text=string.Empty;
			this.txtAnchoNormal.Text=string.Empty;
			this.txtEspesor.Text=string.Empty;
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
				lblErrorMsg.BackColor=Color.Green;
			}
		}

		private void txtEspesor_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtAnchoVidrio_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtGrosor_TextChanged(object sender, System.EventArgs e)
		{
			
		}
	

	}
}
