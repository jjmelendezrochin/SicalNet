namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SICALNet.BusinessEntities;
	using SICALNet.BusinessLogicLayer;

	/// <summary>
	///		Descripción breve de TarjetaVidrioEspesorEditarascx.
	/// </summary>
	public class TarjetaVidrioEspesorEditar : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Button cmdGuardar;
		protected System.Web.UI.WebControls.TextBox A1;
		protected System.Web.UI.WebControls.TextBox A2;
		protected System.Web.UI.WebControls.TextBox A3;
		protected System.Web.UI.WebControls.TextBox A4;
		protected System.Web.UI.WebControls.TextBox A5;
		protected System.Web.UI.WebControls.TextBox A6;
		protected System.Web.UI.WebControls.TextBox B1;
		protected System.Web.UI.WebControls.TextBox B2;
		protected System.Web.UI.WebControls.TextBox B3;
		protected System.Web.UI.WebControls.TextBox B4;
		protected System.Web.UI.WebControls.TextBox B5;
		protected System.Web.UI.WebControls.TextBox B6;
		protected System.Web.UI.WebControls.TextBox C1;
		protected System.Web.UI.WebControls.TextBox C2;
		protected System.Web.UI.WebControls.TextBox C3;
		protected System.Web.UI.WebControls.TextBox C4;
		protected System.Web.UI.WebControls.TextBox C5;
		protected System.Web.UI.WebControls.TextBox C6;
		protected System.Web.UI.WebControls.TextBox D1;
		protected System.Web.UI.WebControls.TextBox D2;
		protected System.Web.UI.WebControls.TextBox D3;
		protected System.Web.UI.WebControls.TextBox D4;
		protected System.Web.UI.WebControls.TextBox D5;
		protected System.Web.UI.WebControls.TextBox D6;
		protected System.Web.UI.WebControls.TextBox E1;
		protected System.Web.UI.WebControls.TextBox E2;
		protected System.Web.UI.WebControls.TextBox E3;
		protected System.Web.UI.WebControls.TextBox E4;
		protected System.Web.UI.WebControls.TextBox E5;
		protected System.Web.UI.WebControls.TextBox E6;
		protected System.Web.UI.WebControls.TextBox F1;
		protected System.Web.UI.WebControls.TextBox F2;
		protected System.Web.UI.WebControls.TextBox F3;
		protected System.Web.UI.WebControls.TextBox F4;
		protected System.Web.UI.WebControls.TextBox F5;
		protected System.Web.UI.WebControls.TextBox idVidrio;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox F6;

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
				EspesorVidrio0 bllEspesorVidrio = new EspesorVidrio0();
				SICALNet.BusinessEntities.VidriosMedidaEspesorInfo MEI = bllEspesorVidrio.LoadEspesorVidrioEditarConsulta();
				this.idVidrio.Text = MEI.idVidrio.ToString();
				double a1  = Math.Round(MEI.a1,2);
				double a2	= Math.Round(MEI.a2,2);
				double a3	= Math.Round(MEI.a3,2);
				double	a4	=	Math.Round(MEI.a4,2);
				double	a5	=	Math.Round(MEI.a5,2);
				double	a6	=	Math.Round(MEI.a6,2);
				double	a7	=	Math.Round(MEI.a7,2);
				double	b1	=	Math.Round(MEI.b1,2);
				double	b2	=	Math.Round(MEI.b2,2);
				double	b3	=	Math.Round(MEI.b3,2);
				double	b4	=	Math.Round(MEI.b4,2);
				double	b5	=	Math.Round(MEI.b5,2);
				double	b6	=	Math.Round(MEI.b6,2);
				double	b7	=	Math.Round(MEI.b7,2);
				double	c1	=	Math.Round(MEI.c1,2);
				double	c2	=	Math.Round(MEI.c2,2);
				double	c3	=	Math.Round(MEI.c3,2);
				double	c4	=	Math.Round(MEI.c4,2);
				double	c5	=	Math.Round(MEI.c5,2);
				double	c6	=	Math.Round(MEI.c6,2);
				double	c7	=	Math.Round(MEI.c7,2);
				double	d1	=	Math.Round(MEI.d1,2);
				double	d2	=	Math.Round(MEI.d2,2);
				double	d3	=	Math.Round(MEI.d3,2);
				double	d4	=	Math.Round(MEI.d4,2);
				double	d5	=	Math.Round(MEI.d5,2);
				double	d6	=	Math.Round(MEI.d6,2);
				double	d7	=	Math.Round(MEI.d7,2);
				double	e1	=	Math.Round(MEI.e1,2);
				double	e2	=	Math.Round(MEI.e2,2);
				double	e3	=	Math.Round(MEI.e3,2);
				double	e4	=	Math.Round(MEI.e4,2);
				double	e5	=	Math.Round(MEI.e5,2);
				double	e6	=	Math.Round(MEI.e6,2);
				double	e7	=	Math.Round(MEI.e7,2);
				double	f1	=	Math.Round(MEI.f1,2);
				double	f2	=	Math.Round(MEI.f2,2);
				double	f3	=	Math.Round(MEI.f3,2);
				double	f4	=	Math.Round(MEI.f4,2);
				double	f5	=	Math.Round(MEI.f5,2);
				double	f6	=	Math.Round(MEI.f6,2);
				double	f7	=	Math.Round(MEI.f7,2);
				double	g1	=	Math.Round(MEI.g1,2);
				double	g2	=	Math.Round(MEI.g2,2);
				double	g3	=	Math.Round(MEI.g3,2);
				double	g4	=	Math.Round(MEI.g4,2);
				double	g5	=	Math.Round(MEI.g5,2);
				double	g6	=	Math.Round(MEI.g6,2);
				double	g7	=	Math.Round(MEI.g7,2);

				this.A1.Text=a1.ToString();
				this.A2.Text=a2.ToString();
				this.A3.Text=a3.ToString();
				this.A4.Text=a4.ToString();
				this.A5.Text=a5.ToString();
				this.A6.Text=a6.ToString();

				this.B1.Text=b1.ToString();
				this.B2.Text=b2.ToString();
				this.B3.Text=b3.ToString();
				this.B4.Text=b4.ToString();
				this.B5.Text=b5.ToString();
				this.B6.Text=b6.ToString();

				this.C1.Text=c1.ToString();
				this.C2.Text=c2.ToString();
				this.C3.Text=c3.ToString();
				this.C4.Text=c4.ToString();
				this.C5.Text=c5.ToString();
				this.C6.Text=c6.ToString();

				this.D1.Text=d1.ToString();
				this.D2.Text=d2.ToString();
				this.D3.Text=d3.ToString();
				this.D4.Text=d4.ToString();
				this.D5.Text=d5.ToString();
				this.D6.Text=d6.ToString();

				this.E1.Text=e1.ToString();
				this.E2.Text=e2.ToString();
				this.E3.Text=e3.ToString();
				this.E4.Text=e4.ToString();
				this.E5.Text=e5.ToString();
				this.E6.Text=e6.ToString();

				this.F1.Text=f1.ToString();
				this.F2.Text=f2.ToString();
				this.F3.Text=f3.ToString();
				this.F4.Text=f4.ToString();
				this.F5.Text=f5.ToString();
				this.F6.Text=f6.ToString(); 
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
				double a5 = float.Parse(this.A5.Text);
				double a6 = float.Parse(this.A6.Text);
				double b1 = float.Parse(this.B1.Text);
				double b2 = float.Parse(this.B2.Text);
				double b3 = float.Parse(this.B3.Text);
				double b4 = float.Parse(this.B4.Text);
				double b5 = float.Parse(this.B5.Text);
				double b6 = float.Parse(this.B6.Text);
				double c1 = float.Parse(this.C1.Text);
				double c2 = float.Parse(this.C2.Text);
				double c3 = float.Parse(this.C3.Text);
				double c4 = float.Parse(this.C4.Text);
				double c5 = float.Parse(this.C5.Text);
				double c6 = float.Parse(this.C6.Text);
				double d1 = float.Parse(this.D1.Text);
				double d2 = float.Parse(this.D2.Text);
				double d3 = float.Parse(this.D3.Text);
				double d4 = float.Parse(this.D4.Text);
				double d5 = float.Parse(this.D5.Text);
				double d6 = float.Parse(this.D6.Text);
				double e1 = float.Parse(this.E1.Text);
				double e2 = float.Parse(this.E2.Text);
				double e3 = float.Parse(this.E3.Text);
				double e4 = float.Parse(this.E4.Text);
				double e5 = float.Parse(this.E5.Text);
				double e6 = float.Parse(this.E6.Text);
				double f1 = float.Parse(this.F1.Text);
				double f2 = float.Parse(this.F2.Text);
				double f3 = float.Parse(this.F3.Text);
				double f4 = float.Parse(this.F4.Text);
				double f5 = float.Parse(this.F5.Text);
				double f6 = float.Parse(this.F6.Text);
				SICALNet.BusinessEntities.VidriosMedidaEspesorInfo MEI= new SICALNet.BusinessEntities.VidriosMedidaEspesorInfo(
					idVidrio, a1, a2, a3, a4, a5, a6, 0, 
					b1, b2, b3, b4, b5, b6, 0, 
					c1, c2, c3, c4, c5, c6, 0, 
					d1, d2, d3, d4, d5, d6, 0, 
					e1, e2, e3, e4, e5, e6, 0,
					f1, f2, f3, f4, f5, f6, 0, 
					0, 0, 0, 0, 0, 0, 0);
				SICALNet.BusinessLogicLayer.EspesorVidrio0 bllEspesorVidrio = new SICALNet.BusinessLogicLayer.EspesorVidrio0();			
				if(bllEspesorVidrio.ProcActualizaVidriosEspesor(MEI)>0)
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
