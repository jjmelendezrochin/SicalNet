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
			if(this.fileInput.PostedFile.FileName==string.Empty && sender!=null)
			{
				this.lblErrMsg.Text="Debe especificar el archivo que contiene el programa de producción";
				return;
			}
			try
			{
				//string fullPath, fileName; int Pos;
				string fileName;
				//fullPath = fileInput.PostedFile.FileName;	
				//Pos = fullPath.LastIndexOf("\\");
				//fileName = fullPath.Substring(Pos, fullPath.Length - Pos);
				//fileInput.PostedFile.SaveAs(Server.MapPath("") + fileName);
				SICALNet.BusinessLogicLayer.Programa Programa = new SICALNet.BusinessLogicLayer.Programa();
				/*
				 * Descripción:
				 *	Obtiene la información del Programa de Producción, verifica si ya se ha cargado uno previamente
				 *	para la fecha y línea contenida en el nuevo programa, en caso de ser así muestra un mensaje
				 *	para confirmar la importación del Programa de Importación.	
				 * Autor:
				 *	Ing. Ariel Martínez Morales
				 * Fecha
				 *	04-08-2005
				 */		
				this.lblErrMsg.Text="";
				this.dgdPrograma.Visible=false;

				if(!this.ConfirmImportData)
				{
					fileName = System.IO.Path.GetFileName(fileInput.PostedFile.FileName);
					this.ImportFileName=Server.MapPath("") + fileName;
					//se guarda el archivo "posteado"
					fileInput.PostedFile.SaveAs(this.ImportFileName);

					SICALNet.BusinessEntities.ProgramaInfo objProgramInfo = Programa.GetProgramInfoFromImportExcelFile(this.ImportFileName);

					if(Programa.IsExistPrograma(objProgramInfo))
					{
						System.Text.StringBuilder script = new System.Text.StringBuilder();
						script.Append("<SCRIPT Language=\"JavaScript\">\n");
						script.Append("	ConfirmImport(\"");
						script.Append(string.Format("Ya existe un Programa de Producción para la Fecha {0} y Línea de Producción {1}, ¿Desea agregar más secuencias?", objProgramInfo.Fecha, objProgramInfo.IdLinea.ToString()));
						script.Append("\")\n");
						script.Append("</SCRIPT>\n");
						this.AddPrograma.Attributes.Add("onclick", "return ConfirmImport(\""+string.Format("Ya existe un Programa de Producción para la Fecha {0} y Línea de Producción {1}, ¿Desea agregar más secuencias?", objProgramInfo.Fecha, objProgramInfo.IdLinea.ToString())+"\");");

						script = new System.Text.StringBuilder();
						script.Append("<SCRIPT Language=\"JavaScript\">\n");
						script.Append("if(confirm(\""+string.Format("Ya existe un Programa de Producción para la Fecha {0} y Línea de Producción {1}, ¿Desea agregar más secuencias?", objProgramInfo.Fecha, objProgramInfo.IdLinea.ToString())+"\"))");
						script.Append("	document.forms[0].submit();");
						script.Append("</SCRIPT>\n");
						
						this.RegisterStartupScript("ConfirmMessage", script.ToString());
						this.ConfirmImportData=true;						
						return;
					}
				}
				// Termina modificación

				dgdPrograma.DataSource = (IList) Programa.ImportExcelFile(this.ImportFileName, this.ConfirmImportData, this.User.Identity.Name.ToString());
				dgdPrograma.DataBind();
				//se apaga la bandera prendida en la confirmación de importación
				this.ConfirmImportData=false;
				
				if(dgdPrograma.DataSource == null)
				{	
					lblErrMsg.ForeColor = Color.Green;
					lblErrMsg.Text = "El programa de producción se cargo a la base de datos con éxito";
				}
				else
				{
					dgdPrograma.Visible = true;
					lblErrMsg.ForeColor = Color.Red;
					lblErrMsg.Text = "No se cargo el programa de producción....por favor verifique los siguientes detalles de error...";
				}
			}
			catch
			{
				throw;			
			}			
		}
	}
}
