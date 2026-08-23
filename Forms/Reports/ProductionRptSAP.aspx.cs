using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections; 
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SICALNet.BusinessEntities;

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for ProductionRptSAP.
	/// </summary>
	public class ProductionRptSAP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cmbDefecto;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList cmbLinea;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cmbEspInicial;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.ImageButton cmdCalInicial;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtLibInicial;
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList cmbColor;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbTurno;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList cmbEspFinal;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.ImageButton Imagebutton2;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtLibFinal;
		protected System.Web.UI.WebControls.ImageButton Imagebutton3;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList cmbMedida;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList cmbFamilia;
		protected System.Web.UI.WebControls.Button cmdImprimir;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
	
		const string const_All = "Todas";
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//To bind data for Defecto DropDownList
				SICALNet.BusinessLogicLayer.PartidasInspeccion Def = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList DefectoList = (IList) Def.LoadDefecto();
				cmbDefecto.DataSource=DefectoList;
				cmbDefecto.DataValueField = "IdDefecto";
				cmbDefecto.DataTextField = "Defecto";
				cmbDefecto.DataBind();
				cmbDefecto.Items.Add(new ListItem(string.Empty,"0"));
				cmbDefecto.Items.FindByValue("0").Selected=true;
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);
				//To bind data for Linea DropDownList
				SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList LineaList = (IList) Linea.SelectLinePdt(theUser);
				cmbLinea.DataSource = LineaList;
				cmbLinea.DataValueField = "IdLinea";
				cmbLinea.DataTextField = "Description";
				cmbLinea.DataBind();
				cmbLinea.Items.Add(new ListItem(string.Empty,"0"));
				cmbLinea.Items.FindByValue("0").Selected=true;
				//To Bind Espesor
				//to fill the espesor description into the cboEspesor control
				SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
				IList EspList=(IList) BLLEspesor.LoadEspesor();
				cmbEspInicial.DataSource=EspList;
				cmbEspInicial.DataTextField= "Centimetros";
				cmbEspInicial.DataValueField= "IdEspesor";
				cmbEspInicial.DataBind();
				cmbEspInicial.Items[0].Selected=true;
				cmbEspFinal.DataSource=EspList;
				cmbEspFinal.DataTextField= "Centimetros";
				cmbEspFinal.DataValueField= "IdEspesor";
				cmbEspFinal.DataBind();
				cmbEspFinal.Items[cmbEspFinal.Items.Count-1].Selected=true;
				//to fill the medida description into the cboMedida control
				SICALNet.BusinessLogicLayer.Medida BLLMedida=new SICALNet.BusinessLogicLayer.Medida();
				IList MedidaList=(IList) BLLMedida.LoadMedida();
				cmbMedida.DataSource=MedidaList;
				cmbMedida.DataTextField="Centimetros";
				cmbMedida.DataValueField= "IdMedida";				
				cmbMedida.DataBind();
				cmbMedida.Items.Add(new ListItem(string.Empty,"0"));
				cmbMedida.Items.FindByValue("0").Selected=true;
				//to fill Color Combo
				SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
				IList ColorList=(IList) BLLColor.SelectColour();
				cmbColor.DataSource=ColorList;
				cmbColor.DataTextField="IdColour";
				cmbColor.DataValueField="IdColour";				
				cmbColor.DataBind();
				cmbColor.Items.Add(new ListItem(string.Empty,"0"));
				cmbColor.Items.FindByValue("0").Selected=true;
				//to fill Familia Producto Combo
				SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList FamiliaList=(IList) BLLFampdt.SelectFamiliaProducto();
				cmbFamilia.DataSource=FamiliaList;
				cmbFamilia.DataTextField= "Descripcion";
				cmbFamilia.DataValueField= "IdFamiliaProductos";
				cmbFamilia.DataBind();
				cmbFamilia.Items.Add(new ListItem(string.Empty,"0"));
				cmbFamilia.Items.FindByValue("0").Selected=true;
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
			this.cmbLinea.SelectedIndexChanged += new System.EventHandler(this.cmbLinea_SelectedIndexChanged);
			this.cmdCalInicial.Click += new System.Web.UI.ImageClickEventHandler(this.cmdCalInicial_Click);
			this.Imagebutton2.Click += new System.Web.UI.ImageClickEventHandler(this.Imagebutton2_Click);
			this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{					
		}

		private void Imagebutton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void cmdCalInicial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../NewMenu.aspx");
		}

		private void cmbLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// fill linea combo

			if (this.cmbLinea.SelectedItem.Value != "0")
			{
				SICALNet.BusinessLogicLayer.Usuario BLLUsuario=new SICALNet.BusinessLogicLayer.Usuario();
				SortedList TurnoList= BLLUsuario.SelectTurnoByLinea(int.Parse(this.cmbLinea.SelectedItem.Value));
				this.cmbTurno.DataSource =  TurnoList;
				this.cmbTurno.DataValueField = "key";
				this.cmbTurno.DataTextField = "value";
				this.cmbTurno.DataBind();
				cmbTurno.Items.Add(new ListItem(string.Empty,"0"));
				cmbTurno.Items.FindByValue("0").Selected=true;
			}
			else
			{
				this.cmbTurno.Items.Clear();
				cmbTurno.Items.Add(new ListItem(string.Empty,"0"));
				cmbTurno.Items.FindByValue("0").Selected=true;


			}

		}

        protected void cmdImprimir_Click1(object sender, EventArgs e)
        {

        }
    }
}
