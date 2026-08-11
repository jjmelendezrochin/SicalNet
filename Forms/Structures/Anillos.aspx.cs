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

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Descripción breve de Anillos.
	/// </summary>
	public class Anillos : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtLI;
		protected System.Web.UI.WebControls.TextBox txtLII;
		protected System.Web.UI.WebControls.TextBox txtLIII;
		protected System.Web.UI.WebControls.Button cmdAgregar;
		protected System.Web.UI.WebControls.Button cmdConsultar;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox txtCodigoSap;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button cmdTodos;

		protected Controls.AnillosGrid AnillosGridControl;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{							
			}
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
			this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
			this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
			this.cmdTodos.Click += new System.EventHandler(this.cmdTodos_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAgregar_Click(object sender, System.EventArgs e)
		{
			// Validación de que todos los datos tengan un texto
			string sCodigoSap, sLineaI, sLineaII, sLineaIII;
			sCodigoSap	= this.txtCodigoSap.Text;
			sLineaI		= this.txtLI.Text;
			sLineaII	= this.txtLII.Text;
			sLineaIII	= this.txtLIII.Text;

			// Verifica si tiene todos los datos
			if (sCodigoSap == string.Empty || sLineaI == string.Empty || sLineaII == string.Empty || sLineaIII == string.Empty)
			{
				prcErrorDisplay(null,"Favor de capturar todos los datos");
				return;
			}

			// Verifica si no hay duplicados
			SICALNet.BusinessLogicLayer.Anillos bllAnillos = new SICALNet.BusinessLogicLayer.Anillos();
			if (bllAnillos.CuentaAnillos(sCodigoSap)>0)
			{
				prcErrorDisplay(null,"El código [" + sCodigoSap + "] ya existe");
				return;
			}

			
			SICALNet.BusinessEntities.AnillosInfo OInfo = 
				new SICALNet.BusinessEntities.AnillosInfo(0,sCodigoSap, string.Empty, sLineaI, sLineaII, sLineaIII,User.Identity.Name);
			bllAnillos.SaveAnillos(OInfo);

			// guardamos en la bitacora
			SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
			BLLBitacora.Insertcomando("Alta de anillo, codigo SAP: " + sCodigoSap, User.Identity.Name);

			clearControl();		
			AnillosGridControl.BindGrid(string.Empty);
			this.txtCodigoSap.Text = string.Empty;
			this.txtLI.Text = string.Empty; 
			this.txtLII.Text = string.Empty; 
			this.txtLIII.Text = string.Empty; 

			prcErrorDisplay(null,"El nuevo folio se agregó existosamente");


		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("Inforamción sobre el catalogo de Medida",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void clearControl()
		{									
			this.txtCodigoSap.Text = string.Empty;
			this.txtLI.Text = string.Empty; 
			this.txtLII.Text = string.Empty; 
			this.txtLIII.Text = string.Empty; 
			lblErrorMsg.Text = String.Empty;
		}

		private void cmdConsultar_Click(object sender, System.EventArgs e)
		{
			string sCodigoSap = this.txtCodigoSap.Text.Trim();
			AnillosGridControl.ConsultaAnillo(sCodigoSap);
		}

		private void cmdTodos_Click(object sender, System.EventArgs e)
		{
			txtCodigoSap.Text = String.Empty;
			AnillosGridControl.ConsultaAnillo(String.Empty);		
		}
	}
}
