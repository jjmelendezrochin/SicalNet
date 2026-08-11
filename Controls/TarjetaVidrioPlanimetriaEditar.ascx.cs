namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SICALNet.BusinessLogicLayer;

	/// <summary>
	///		Descripción breve de TarjetaVidrioPlanimetriaEditar.
	/// </summary>
	public class TarjetaVidrioPlanimetriaEditar : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox idVidrio;
		protected System.Web.UI.WebControls.TextBox A1;
		protected System.Web.UI.WebControls.TextBox A2;
		protected System.Web.UI.WebControls.TextBox A3;
		protected System.Web.UI.WebControls.TextBox A4;
		protected System.Web.UI.WebControls.TextBox B1;
		protected System.Web.UI.WebControls.TextBox B2;
		protected System.Web.UI.WebControls.TextBox B3;
		protected System.Web.UI.WebControls.TextBox B4;
		protected System.Web.UI.WebControls.TextBox C1;
		protected System.Web.UI.WebControls.TextBox C2;
		protected System.Web.UI.WebControls.TextBox C3;
		protected System.Web.UI.WebControls.TextBox C4;
		protected System.Web.UI.WebControls.TextBox D1;
		protected System.Web.UI.WebControls.TextBox D2;
		protected System.Web.UI.WebControls.TextBox D3;
		protected System.Web.UI.WebControls.TextBox D4;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button cmdGuardar;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				BindGrid();
			}
		}
		public void BindGrid()
		{
			try
			{
				//SICALNet.BusinessEntities.VidriosMedidaEspesorInfo belVidriosMedidaEspesorInfo=new SICALNet.BusinessEntities.VidriosMedidaEspesorInfo();
				EspesorVidrio bllEspesorVidrio = new EspesorVidrio();
				SICALNet.BusinessEntities.VidriosMedidaPlanimetriaInfo MPI = bllEspesorVidrio.LoadPlanimetriaVidrioEditarConsulta();
				this.idVidrio.Text = MPI.idVidrio.ToString();
				double  a1  = Math.Round(MPI.a1,2);
				double  a2	= Math.Round(MPI.a2,2);
				double  a3	= Math.Round(MPI.a3,2);
				double	a4	= Math.Round(MPI.a4,2);				
				double	b1	= Math.Round(MPI.b1,2);
				double	b2	= Math.Round(MPI.b2,2);
				double	b3	= Math.Round(MPI.b3,2);
				double	b4	= Math.Round(MPI.b4,2);
				double	c1	= Math.Round(MPI.c1,2);
				double	c2	= Math.Round(MPI.c2,2);
				double	c3	= Math.Round(MPI.c3,2);
				double	c4	= Math.Round(MPI.c4,2);
				double	d1	= Math.Round(MPI.d1,2);
				double	d2	= Math.Round(MPI.d2,2);
				double	d3	= Math.Round(MPI.d3,2);
				double	d4	= Math.Round(MPI.d4,2);

				this.A1.Text=a1.ToString();
				this.A2.Text=a2.ToString();
				this.A3.Text=a3.ToString();
				this.A4.Text=a4.ToString();

				this.B1.Text=b1.ToString();
				this.B2.Text=b2.ToString();
				this.B3.Text=b3.ToString();
				this.B4.Text=b4.ToString();

				this.C1.Text=c1.ToString();
				this.C2.Text=c2.ToString();
				this.C3.Text=c3.ToString();
				this.C4.Text=c4.ToString();

				this.D1.Text=d1.ToString();
				this.D2.Text=d2.ToString();
				this.D3.Text=d3.ToString();
				this.D4.Text=d4.ToString();
			}
			catch
			{
				throw;
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
			this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdGuardar_Click(object sender, System.EventArgs e)
		{
			try
			{
				int idVidrio = int.Parse(this.idVidrio.Text);
				double a1 = float.Parse(this.A1.Text);
				double a2 = float.Parse(this.A2.Text);
				double a3 = float.Parse(this.A3.Text);
				double a4 = float.Parse(this.A4.Text);
				double b1 = float.Parse(this.B1.Text);
				double b2 = float.Parse(this.B2.Text);
				double b3 = float.Parse(this.B3.Text);
				double b4 = float.Parse(this.B4.Text);
				double c1 = float.Parse(this.C1.Text);
				double c2 = float.Parse(this.C2.Text);
				double c3 = float.Parse(this.C3.Text);
				double c4 = float.Parse(this.C4.Text);
				double d1 = float.Parse(this.D1.Text);
				double d2 = float.Parse(this.D2.Text);
				double d3 = float.Parse(this.D3.Text);
				double d4 = float.Parse(this.D4.Text);
				SICALNet.BusinessEntities.VidriosMedidaPlanimetriaInfo MPI= new SICALNet.BusinessEntities.VidriosMedidaPlanimetriaInfo(
					idVidrio, 
					a1, a2, a3, a4, 
					b1, b2, b3, b4, 
					c1, c2, c3, c4,
					d1, d2, d3, d4
					);
				SICALNet.BusinessLogicLayer.EspesorVidrio bllPlanimetriaVidrio = new SICALNet.BusinessLogicLayer.EspesorVidrio();			
				if(bllPlanimetriaVidrio.ProcActualizaVidriosPlanimetria(MPI)>0)
				{
					prcErrorDisplay(null,"Dato Guardado");
				}
			}
			catch
			{
				throw;
			}
		}

		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
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
	}
}
