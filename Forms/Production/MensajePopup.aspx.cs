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

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for MensajePopup.
	/// </summary>
	public class MensajePopup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label txtSecuencia;
		protected System.Web.UI.WebControls.Label lblCodigosap;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtMensaje;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.DataList DLArea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				//Display source Sequence Data
				txtSecuencia.Text=Request.QueryString["Secuencia"].ToString();
				lblCodigosap.Text=Request.QueryString["CodigoSAP"].ToString();
				lblDescripcion.Text=Request.QueryString["MaterialDescription"].ToString();

//				MaterialInfo mInfo = new MaterialInfo(lblCodigosap.Text,string.Empty);
//				SICALNet.BusinessLogicLayer.Material blMat = new SICALNet.BusinessLogicLayer.Material();
//				MaterialInfo mInfo1 = new MaterialInfo();
//				mInfo1=(MaterialInfo)blMat.SelectMaterial(mInfo);
//				lblDescripcion.Text=mInfo1.Descripcion.ToString();

				BindList();
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
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindList()
		{
			
			Area blArea = new Area();
			IList Arealist = (IList)blArea.SelectArea();

			for (int i=0;i<Arealist.Count;i++)
			{
				AreaInfo currentArea=(AreaInfo)Arealist[i];
				if (currentArea.IdArea==Convert.ToInt32(Request.QueryString["AreaId"]))
					Arealist.RemoveAt(i);
			}

			DLArea.DataSource=Arealist;
			DLArea.DataBind();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
//			int IdArea=Convert.ToInt32(cmbArea.SelectedItem.Value);
//			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,txtMensaje.Text,IdArea);
//			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();
//			mPiso.Insert(mpInfo);

			bool noAreaChecked=true;

			for (int i=0; i< DLArea.Items.Count;i++)
			{
				if (((CheckBox) DLArea.Items[i].FindControl("chkSelect")).Checked==true)
				{
					noAreaChecked=false;
					int IdArea=Convert.ToInt32(((Label) DLArea.Items[i].FindControl("lblIdArea")).Text);
					
					string[] secuencias = txtSecuencia.Text.Split(Convert.ToChar(","));
					for (int j=0;j<secuencias.Length;j++)
					{
						if (secuencias[j].ToString().Trim()!=string.Empty)
						{
							MensajePisoInfo mpInfo = new MensajePisoInfo(secuencias[j].ToString().Trim(),txtMensaje.Text,IdArea);
							SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();
							mPiso.Insert(mpInfo);
						}
					}


				}	
			}

			if (noAreaChecked)
				Page.RegisterStartupScript("_NoAreaSelected","<script>alert('Seleccione un área a donde enviar el mensaje de piso !')</script>");
			else
				Page.RegisterStartupScript("__close", "<script>window.close();</script>");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Page.RegisterStartupScript("__close", "<script>window.close();</script>");
		}
	}
}
