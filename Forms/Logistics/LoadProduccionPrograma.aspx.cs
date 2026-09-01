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

namespace UserInterface.Forms.Logistics
{
	/// <summary>
	/// Summary description for LoadProduccionPrograma.
	/// </summary>
	public class LoadProduccionPrograma : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button AddPrograma;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileInput;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblErrMsg;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdnFileInput;
		protected System.Web.UI.WebControls.DataGrid dgdPrograma;
	
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
			this.AddPrograma.Click += new System.EventHandler(this.AddPrograma_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//		private void ValidateImportFile(string file)
		//		{
		//		}

		private void AddPrograma_Click(object sender, System.EventArgs e)
		{
			if (sender != null &&
				(this.fileInput.PostedFile == null ||
				 this.fileInput.PostedFile.FileName == string.Empty))
			{
				this.lblErrMsg.Text =
					"Debe especificar el archivo que contiene el programa de producción";

				string scriptArchivo =
					"SicalAlert.mostrar(" +
					"\"Debe especificar el archivo que contiene el programa de producción\", " +
					"\"warning\", " +
					"\"Archivo requerido\");";

				ClientScript.RegisterStartupScript(
					this.GetType(),
					"ArchivoRequerido",
					scriptArchivo,
					true
				);

				return;
			}

			try
			{
				string fileName;

				SICALNet.BusinessLogicLayer.Programa Programa =
					new SICALNet.BusinessLogicLayer.Programa();

				this.lblErrMsg.Text = "";
				this.dgdPrograma.Visible = false;

				if (!this.ConfirmImportData)
				{
					fileName = System.IO.Path.GetFileName(
						fileInput.PostedFile.FileName
					);

					this.ImportFileName =
						System.IO.Path.Combine(Server.MapPath(""), fileName);

					fileInput.PostedFile.SaveAs(this.ImportFileName);

					SICALNet.BusinessEntities.ProgramaInfo objProgramInfo =
						Programa.GetProgramInfoFromImportExcelFile(
							this.ImportFileName
						);

					if (Programa.IsExistPrograma(objProgramInfo))
					{
						string mensaje = string.Format(
							"Ya existe un Programa de Producción para la Fecha {0} " +
							"y Línea de Producción {1}, ¿desea agregar más secuencias?",
							objProgramInfo.Fecha,
							objProgramInfo.IdLinea
						);

						string mensajeJavaScript =
							System.Web.HttpUtility.JavaScriptStringEncode(mensaje);

						string scriptConfirmacion =
							"SicalAlert.confirmar(" +
							"\"" + mensajeJavaScript + "\", " +
							"\"Confirmar carga\", " +
							"function () {" +
								"showWaitControls();" +
								"document.forms[0].submit();" +
							"}" +
							");";

						this.ConfirmImportData = true;

						ClientScript.RegisterStartupScript(
							this.GetType(),
							"ConfirmMessage",
							scriptConfirmacion,
							true
						);

						return;
					}
				}

				dgdPrograma.DataSource = (IList)Programa.ImportExcelFile(
					this.ImportFileName,
					this.ConfirmImportData,
					this.User.Identity.Name
				);

				dgdPrograma.DataBind();

				this.ConfirmImportData = false;

				if (dgdPrograma.DataSource == null)
				{
					lblErrMsg.ForeColor = Color.Green;
					lblErrMsg.Text =
						"El programa de producción se cargó a la base de datos con éxito";

					string scriptExito =
						"SicalAlert.mostrar(" +
						"\"El programa de producción se cargó a la base de datos con éxito\", " +
						"\"success\", " +
						"\"Carga concluida\");";

					ClientScript.RegisterStartupScript(
						this.GetType(),
						"CargaConcluida",
						scriptExito,
						true
					);
				}
				else
				{
					dgdPrograma.Visible = true;
					lblErrMsg.ForeColor = Color.Red;
					lblErrMsg.Text =
						"No se cargó el programa de producción. " +
						"Por favor, verifique los detalles de error.";

					string scriptErrorValidacion =
						"SicalAlert.mostrar(" +
						"\"No se cargó el programa de producción. " +
						"Por favor, verifique los detalles de error.\", " +
						"\"error\", " +
						"\"Error de validación\");";

					ClientScript.RegisterStartupScript(
						this.GetType(),
						"ErrorValidacion",
						scriptErrorValidacion,
						true
					);
				}
			}
			catch (Exception ex)
			{
				this.ConfirmImportData = false;
				lblErrMsg.ForeColor = Color.Red;
				lblErrMsg.Text = ex.Message;

				string mensajeError =
					System.Web.HttpUtility.JavaScriptStringEncode(ex.Message);

				string scriptError =
					"SicalAlert.mostrar(" +
					"\"" + mensajeError + "\", " +
					"\"error\", " +
					"\"Error al cargar el programa\");";

				ClientScript.RegisterStartupScript(
					this.GetType(),
					"ErrorCargaPrograma",
					scriptError,
					true
				);
			}
		}
	}
}
