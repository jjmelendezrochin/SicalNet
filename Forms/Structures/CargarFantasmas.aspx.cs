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
	/// Descripción breve de CargarFantasmas.
	/// </summary>
	public class CargarFantasmas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button AddPrograma;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblErrMsg;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileInput;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdnFileInput;
	
		public bool ConfirmImportData
		{
			get 
			{
				if(ViewState["ConfirmImportData"]!=null)
					return Convert.ToBoolean(ViewState["ConfirmImportData"]);
				else
					return false;
			}
			set { ViewState["ConfirmImportData"]=value.ToString(); }
		}

		public string ImportFileName
		{
			get
			{
				if(ViewState["ImportFileName]"]!=null)
					return ViewState["ImportFileName]"].ToString();
				else
					return "";
			}
			set { ViewState["ImportFileName]"] = value; }
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			AddPrograma.Attributes.Add("onClick","showWaitControls()");

			if(this.fileInput.PostedFile!=null)
			{
				if(this.ConfirmImportData)
				{
					this.hdnFileInput.Value = this.fileInput.PostedFile.FileName;
					if(this.ImportFileName!=string.Empty)
					{
						if(System.IO.Path.GetFileName(this.fileInput.PostedFile.FileName)!=string.Empty)
						{
							if(System.IO.Path.GetFileName(this.fileInput.PostedFile.FileName)!= System.IO.Path.GetFileName(this.ImportFileName))
								this.ConfirmImportData=false;
						}
					}
				}
				else
				{
					this.lblErrMsg.Text="Debe especificar el archivo de producción";
				}
			}

			if(this.ConfirmImportData)
				this.AddPrograma_Click(null, null);
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
			this.AddPrograma.Click += new System.EventHandler(this.AddPrograma_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddPrograma_Click(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text="";			
			if(this.fileInput.PostedFile.FileName==string.Empty && sender!=null)
			{
				this.lblErrMsg.Text="Debe especificar el archivo que contiene los materiales fantasma";
				return;
			}
			try
			{
				string fileName;
				int iRes = 0;
				SICALNet.BusinessLogicLayer.MaterialesFantasma materialesfantasma= new SICALNet.BusinessLogicLayer.MaterialesFantasma();								

				if(!this.ConfirmImportData)
				{
					fileName = System.IO.Path.GetFileName(fileInput.PostedFile.FileName);
					this.ImportFileName=Server.MapPath("") + fileName;
					//se guarda el archivo "posteado"
					fileInput.PostedFile.SaveAs(this.ImportFileName);
					lblErrMsg.ForeColor = Color.Green;
					lblErrMsg.Text = "Nombre del archivo " + this.ImportFileName;
					iRes =  materialesfantasma.GetMaterialesFantasmaInfoFromImportExcelFile(this.ImportFileName);
					lblErrMsg.ForeColor = Color.Green;
					lblErrMsg.Text = lblErrMsg.Text +  "<P>" + "Número de registros " + iRes.ToString();
					if(iRes>0)
					{	
						SICALNet.DataAccessLayer.MaterialesFantasma dalMf = new SICALNet.DataAccessLayer.MaterialesFantasma();
						dalMf.TruncaMaterialesFantasmas();		// trunca la tabla de materiales fantasma
						iRes = dalMf.ImportExcelFile(this.ImportFileName);

						//se apaga la bandera prendida en la confirmación de importación
						this.ConfirmImportData=false;
				
						if(iRes>0)
						{	
							lblErrMsg.ForeColor = Color.Green;
							lblErrMsg.Text = "El archivo de materiales fantasmas se cargo a la base de datos con éxito con " + iRes.ToString() + " registros";
						}
						else
						{
							lblErrMsg.ForeColor = Color.Red;
							lblErrMsg.Text = "No se cargo el archivo con la lista de fantasmas";
						}
					}
					else
					{
						lblErrMsg.ForeColor = Color.Red;
						lblErrMsg.Text = "El archivo de Excel seleccionado tiene un formato distinto, Por favor proporcione un archivo de EXCEL que cumpla con el formato establecido";
					}
				}				
			}
			catch
			{
				throw;				
			}		
		}
	}
}
