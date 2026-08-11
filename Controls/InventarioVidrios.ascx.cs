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
using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;

namespace UserInterface.Controls
{
	/// <summary>
	///		Descripción breve de InventarioVidrios.
	/// </summary>
	public class InventarioVidrios : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden SecuenciaActualhtml;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Cubahtml;
		protected System.Web.UI.WebControls.DataGrid dgdInventarioVidrios;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtNumeroVidrio;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cboEspesor;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cboVidrioTamanio;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cboTipo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtLote;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox txtidPlanta;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button cmdMostrarTodos;
		protected System.Web.UI.WebControls.Label lblErrorMsg;


		public void BindGrid()
		{
			try
			{

				if (Session["NumeroVidrio"]!= null)
					this.txtNumeroVidrio.Text = Session["NumeroVidrio"].ToString();

				int idLinea = int.Parse(this.cboLinea.SelectedValue.ToString());
				int idTamanio = int.Parse(this.cboVidrioTamanio.SelectedValue.ToString());
				int idTipo = int.Parse(this.cboTipo.SelectedValue.ToString());
				int idEspesor = int.Parse(this.cboEspesor.SelectedValue.ToString());
				string sNumeroVidrio = this.txtNumeroVidrio.Text;
				string sLote = this.txtLote.Text;
				int idPlanta = int.Parse(this.txtidPlanta.Text);
				long iNumeroVidrio;
				if (sNumeroVidrio.Trim() == "")
					iNumeroVidrio=0;
				else
					iNumeroVidrio= long.Parse(sNumeroVidrio);
				int iLote;
				if (sLote.Trim() =="")
					iLote = 0;
				else
					iLote =int.Parse(sLote);


				SICALNet.BusinessEntities.VidInfo belVidrioInfo  = 
					new SICALNet.BusinessEntities.VidInfo(
					0, 
					"",						// Clave Fabricante
					idTamanio,				// Tamaño
					0,						// Proveedor
					idLinea,				// Linea
					iNumeroVidrio,			// Número Vidrio	
					System.DateTime.Now,	// Fecha Inicio
					System.DateTime.Now,	// Fecha Capa
					System.DateTime.Now,	// FechaRotura
					0,						// Clasificación Calidad
					0,						// Clasificacion Conservación
					idTipo,					// Tipo
					iLote,					// Lote
					idPlanta,				// Planta
					"",						// Udc
					System.DateTime.Now,	// Fdc
					idEspesor,				// Espesor
					0,						// Costo Dólares
					0,						// Costo Pesos
					System.DateTime.Now,	// Fecha Amortizacion
					0,						// idCausaAmortizacion
					System.DateTime.Now,	// Fecha Danio
					0);						// idCausaDanio

				Vidrio bllVidrio=new Vidrio();//create instance for business Logic Layer
				IList ilVidrio=(IList) bllVidrio.LoadVidrioArgs(belVidrioInfo);
				dgdInventarioVidrios.DataSource=ilVidrio;
				dgdInventarioVidrios.DataBind();
				//dgdMedida.EditItemIndex =-1;
				prcErrorDisplay(null,"NoError");
			}
			catch(Exception err)
			{
				prcErrorDisplay(err,"Error");
			}
		}

		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				ErrorHandling errFileWrite=new ErrorHandling();
				errFileWrite.HandleException("Espesor Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
		///		Método necesario para admitir el Diseñador. No se puede modificar
		///		el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{			
			this.cmdMostrarTodos.Click += new System.EventHandler(this.Button2_Click);
			this.Button1.Click += new System.EventHandler(this.btnBuscar_Click);
			this.dgdInventarioVidrios.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdInventarioVidrios_PageIndexChanged);
			this.dgdInventarioVidrios.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdInventarioVidrios_CancelCommand);
			this.dgdInventarioVidrios.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdInventarioVidrios_EditCommand);
			this.dgdInventarioVidrios.DataBinding += new System.EventHandler(this.dgdInventarioVidrios_DataBinding);
			this.dgdInventarioVidrios.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdInventarioVidrios_DeleteCommand);
			this.dgdInventarioVidrios.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdInventarioVidrios_ItemDataBound);
			this.dgdInventarioVidrios.SelectedIndexChanged += new System.EventHandler(this.dgdInventarioVidrios_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdInventarioVidrios_Load(object sender, System.EventArgs e)
		{
			
		}

		private void dgdInventarioVidrios_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdInventarioVidrios.CurrentPageIndex = e.NewPageIndex;
			BindGrid();	
		}

		private void dgdInventarioVidrios_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			dgdInventarioVidrios.EditItemIndex =(int) e.Item.ItemIndex;
			string idVidrio = ((Label)e.Item.FindControl("ItemidVidrio")).Text;
			dgdInventarioVidrios.EditItemIndex=-1;
			//Response.Write("<script>window.parent.location='../../Forms/Structures/InvVidrios.aspx';</script>"); 
			//BindGrid();
		}

		private void dgdInventarioVidrios_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				int idVidrio =Int32.Parse(((Label)e.Item.FindControl("ItemidVidrio")).Text);
				int NumeroVidrio =Int32.Parse(((Label)e.Item.FindControl("ItemNumeroVidrio")).Text);
				
				SICALNet.BusinessEntities.VidInfo  belVidrio=new SICALNet.BusinessEntities.VidInfo(idVidrio);
				SICALNet.BusinessLogicLayer.Vidrio bllVidrio=new SICALNet.BusinessLogicLayer.Vidrio();
				bllVidrio.DeleteVidrio(belVidrio);

				// Borrado de vidrio en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de vidrio: " + belVidrio.idVidrio + " Numero Vidrio: " + NumeroVidrio,Page.User.Identity.Name.ToString());

				dgdInventarioVidrios.EditItemIndex=-1;
				BindGrid();
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "La medida seleccionada actualmente esta siendo utilizada por el sistema, y no sera eliminada");
			}
			catch
			{
				throw;
			}	
		}

		private void dgdInventarioVidrios_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			dgdInventarioVidrios.EditItemIndex =-1;
			BindGrid();
			lblErrorMsg.Text="";
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				// *************************************
				// Llenando Lista cboLinea
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);
	

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt0(theUser);

				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();
				// *************************************
				// Llenando Lista Tamaño del vidrio
				SICALNet.BusinessLogicLayer.VidrioTamanio vidrioTamanioInfo= new SICALNet.BusinessLogicLayer.VidrioTamanio();
				IList vidrioTamanioList= (IList) vidrioTamanioInfo.LoadVidrioTamanio0();
			
				cboVidrioTamanio.DataSource = vidrioTamanioList;
				cboVidrioTamanio.DataValueField = "idTamanio";
				cboVidrioTamanio.DataTextField = "Medida";
				cboVidrioTamanio.DataBind();

				// *************************************
				// Llenando Tipo del vidrio
				SICALNet.BusinessLogicLayer.VidrioCatalogos vidrioCatalogosInfo1= new SICALNet.BusinessLogicLayer.VidrioCatalogos();
				IList vidrioCatalogosList1= (IList) vidrioCatalogosInfo1.LoadVidriosTipo0();
			
				cboTipo.DataSource = vidrioCatalogosList1;
				cboTipo.DataValueField = "idTipo";
				cboTipo.DataTextField = "Nombre";
				cboTipo.DataBind();

				// *************************************
				// Llenando Lista cboEspesor
				SICALNet.BusinessLogicLayer.VidrioEspesor espesorInfo= new SICALNet.BusinessLogicLayer.VidrioEspesor();
				IList espesorList= (IList) espesorInfo.LoadVidriosEspesor0();

				cboEspesor.DataSource= espesorList;
				cboEspesor.DataValueField="idEspesor";
				cboEspesor.DataTextField="Espesor";
				cboEspesor.DataBind();

				this.txtidPlanta.Text = theUser.IdPlanta.ToString();
				BindGrid();
			}
		}

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			long iNumeroVidrio;
			int iLote;
			string sNumeroVidrio = this.txtNumeroVidrio.Text;
			
			if (sNumeroVidrio=="")
				Session["NumeroVidrio"]=null;

			string sLote  = this.txtLote.Text;
			try
			{
				// Validar información 
				if (sNumeroVidrio.Trim() == "")
					iNumeroVidrio=0;
				else
					iNumeroVidrio= long.Parse(sNumeroVidrio);
				// Validar información
				if (sLote.Trim() =="")
					iLote = 0;
				else
					iLote =int.Parse(sLote);
			}
			catch(Exception err)
			{
				prcErrorDisplay(err,"Error");
				return;
			}
			
			try
			{
				int idLinea = int.Parse(this.cboLinea.SelectedValue.ToString());
				int idTamanio = int.Parse(this.cboVidrioTamanio.SelectedValue.ToString());
				int idTipo = int.Parse(this.cboTipo.SelectedValue.ToString());
				int idEspesor = int.Parse(this.cboEspesor.SelectedValue.ToString());				
				int idPlanta = int.Parse(this.txtidPlanta.Text);

				SICALNet.BusinessEntities.VidInfo belVidrioInfo  = 
					new SICALNet.BusinessEntities.VidInfo(
					0,
					"",
					idTamanio,
					0, 
					idLinea,
					iNumeroVidrio,
					System.DateTime.Now,
					System.DateTime.Now,
					System.DateTime.Now,
					0,
					0,
					idTipo,
					iLote,
					idPlanta,
					"",
					System.DateTime.Now,
					idEspesor,
					0,						// Costo Dólares
					0,						// Costo Pesos
					System.DateTime.Now,	// Fecha Amortizacion
					0,						// idCausaAmortizacion
					System.DateTime.Now,	// Fecha Danio
					0);						// idCausaDanio

				Vidrio bllVidrio=new Vidrio();//create instance for business Logic Layer
				IList ilVidrio=(IList) bllVidrio.LoadVidrioArgs(belVidrioInfo);
				dgdInventarioVidrios.CurrentPageIndex = 0;
				dgdInventarioVidrios.DataSource=ilVidrio;
				dgdInventarioVidrios.DataBind();
				//dgdMedida.EditItemIndex =-1;
				prcErrorDisplay(null,"NoError");
			}
			catch(Exception err)
			{
				prcErrorDisplay(err,"Error");
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			this.cboLinea.SelectedIndex=0;
			this.cboVidrioTamanio.SelectedIndex=0;
			this.cboTipo.SelectedIndex=0;
			this.cboEspesor.SelectedIndex= 0;
			this.txtNumeroVidrio.Text = "";
			btnBuscar_Click(null, null);
			
		}

		private void dgdInventarioVidrios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdInventarioVidrios_DataBinding(object sender, System.EventArgs e)
		{
			
		}

		private void dgdInventarioVidrios_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{		
			string sConservacion = "";
			string sCalidad = "";
			string sClaveInterna = "";
			string sIdVidrio = "";

			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{				
				sIdVidrio = ((Label)e.Item.FindControl("ItemidVidrio")).Text;
				sConservacion = ((Label)e.Item.FindControl("ItemConservacion")).Text;
				sCalidad = ((Label)e.Item.FindControl("ItemCalidad")).Text;
				sClaveInterna = ((Label)e.Item.FindControl("ItemNumeroVidrio")).Text;
				//int x=0;
			}
			if (sConservacion.Trim() == "LOTES 4A" || sCalidad.Trim() == "Roto")
			{
				e.Item.BackColor = Color.Orange;
			}						
		}	
	}
}