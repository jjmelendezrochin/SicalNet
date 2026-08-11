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

using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;


namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Descripción breve de Aforo.
	/// </summary>
	public class Aforo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtComponente;
		protected System.Web.UI.WebControls.DropDownList cboColor;
		protected System.Web.UI.WebControls.TextBox txtAforo;
		protected System.Web.UI.WebControls.Button cmdAgregarAforo;
		protected System.Web.UI.WebControls.Button cmdCancelAforo;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button cmdConsulta;
		protected System.Web.UI.WebControls.Button cmdMostrarTodos;
		protected Controls.AforoGrid AforoGrid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Colour color= new SICALNet.BusinessLogicLayer.Colour();
				IList ListaColor= (IList)color.SelectColour();
				// To Load Data into to the cbotipoPMMA Dropdown List from TipoPMMA table
				cboColor.DataSource= ListaColor;
				cboColor.DataValueField="IdColour";
				cboColor.DataTextField="IdColour";
				cboColor.DataBind();
			}
		}




		private void prcClearControls()
		{
			txtComponente.Text=String.Empty;
			cboColor.SelectedIndex=0;
			txtAforo.Text = string.Empty;
			
		}
		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("Información del catalogo de Familias de productos",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (errStatus=="La combinación aforo - componente debe ser única")
			{
				lblErrorMsg.Text=errStatus;
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
			this.cmdAgregarAforo.Click += new System.EventHandler(this.cmdAgregarAforo_Click);
			this.cmdCancelAforo.Click += new System.EventHandler(this.cmdCancelAforo_Click);
			this.cmdConsulta.Click += new System.EventHandler(this.cmdConsulta_Click);
			this.cmdMostrarTodos.Click += new System.EventHandler(this.cmdMostrarTodos_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdCancelAforo_Click(object sender, System.EventArgs e)
		{
			this.cboColor.SelectedIndex=0;
			this.txtComponente.Text = String.Empty;
			this.txtAforo.Text= String.Empty;			
		}

		private void cmdAgregarAforo_Click(object sender, System.EventArgs e)
		{
			Validation Vdlt = new Validation();
			String idColor;
			int Componente;
			int Aforo;
			
			try
			{
				if(this.txtAforo.Text.Trim()=="" || 
					this.txtComponente.Text.Trim() =="" || 
					!Vdlt.IsNumber(this.txtAforo.Text.Trim()) || 
					!Vdlt.IsNumber(this.txtComponente.Text.Trim()))
				{
					lblErrorMsg.Text = "Debe Capturar color, Componente y Aforo, éstos últimos deben ser numéricos ";
					return;
				}
				Componente = int.Parse(this.txtComponente.Text.Trim());
				Aforo = int.Parse(this.txtAforo .Text.Trim());
				idColor = this.cboColor.SelectedItem.Value;
				
				AforoInfo aforoinfo = new AforoInfo(idColor,Componente, Aforo);
				SICALNet.BusinessLogicLayer.Aforo bllaforo= new SICALNet.BusinessLogicLayer.Aforo();
				int resp = bllaforo.InsertaAforo(aforoinfo);

				if (resp > 0 )
				{
					// Alta de aforo en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();

					String sAltaAforo = "Alta de aforo: (color=" + aforoinfo.idColor + ",componente=" + aforoinfo.Componente.ToString() + ", aforo=" + aforoinfo.Aforo + ")";
					BLLBitacora.Insertcomando(sAltaAforo,this.User.Identity.Name.ToString());

					this.AforoGrid.BindGrid();
					prcErrorDisplay(null,"El nuevo Aforo se agrego exitosamente");						
					prcClearControls();
				}
				if (resp == -1)
				{
					this.AforoGrid.BindGrid();
					prcErrorDisplay(null,"La combinación aforo - componente debe ser única");
					prcClearControls();
				}
			}
			catch
			{
				throw;
			}			
		}

		private void cmdConsulta_Click(object sender, System.EventArgs e)
		{
			String idColor = this.cboColor.SelectedItem.Value;
			this.AforoGrid.ConsultaAforo(idColor);
		}

		private void cmdMostrarTodos_Click(object sender, System.EventArgs e)
		{			
			this.AforoGrid.BindGrid();
			
		}
	}
}
