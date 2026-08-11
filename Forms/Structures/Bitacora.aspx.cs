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
using System.IO;
using System.Configuration;


namespace BitacoraExportacion1
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class Bitacora : System.Web.UI.Page
	{

				
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label2;
		
		
		
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DataGrid dgdVerBitacora;
		protected System.Web.UI.WebControls.TextBox txtDespliega;
		protected System.Web.UI.WebControls.RadioButton rdbDatasul;
		protected System.Web.UI.WebControls.RadioButton rdbSicalnet;
		protected System.Web.UI.WebControls.LinkButton linkbitacora;
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{			
				viewcontrols(false);
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
			this.linkbitacora.Click += new System.EventHandler(this.linkbitacora_Click);
			this.rdbSicalnet.CheckedChanged += new System.EventHandler(this.rdbSicalnet_CheckedChanged);
			this.rdbDatasul.CheckedChanged += new System.EventHandler(this.rdbDatasul_CheckedChanged);
			this.dgdVerBitacora.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdVerBitacora_ItemCommand);
			this.dgdVerBitacora.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdVerBitacora_Page);
			this.dgdVerBitacora.SelectedIndexChanged += new System.EventHandler(this.dgdVerBitacora_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	

		private void dgdVerBitacora_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void rdbSicalnet_CheckedChanged(object sender, System.EventArgs e)
		{
			dgdVerBitacora.CurrentPageIndex=0;
			execventRadioButton(1);
		
		}

		private void rdbDatasul_CheckedChanged(object sender, System.EventArgs e)
		{
			dgdVerBitacora.CurrentPageIndex=0;
			execventRadioButton(2);
		
		}

		private void dgdVerBitacora_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		
		{
			if (e.CommandName == "Consulta")
			{
				string txtcadena;
				string _path = "";

				if (rdbSicalnet.Checked == true)
					_path = ConfigurationSettings.AppSettings["ExportBitDirectory"];
					else
					_path = ConfigurationSettings.AppSettings["ImportBitDirectory"];

				string archivo = ((Label)e.Item.FindControl("Label2")).Text;
				string tamano = ((Label)e.Item.FindControl("Label4")).Text;

				int tam = int.Parse(tamano);
                
				if (tam <= 610700) 
				{   

					txtcadena=_path + "\\" + archivo;
					StreamReader objReader = new StreamReader(txtcadena);
					string sLine="";
					int total = 0;
					ArrayList arrText = new ArrayList();
					while (sLine != null)
					{
						sLine = objReader.ReadLine();

						if (sLine != null)
							arrText.Add(sLine);
						total = arrText.Count;

					}

					objReader.Close();
					string body="";
									 
					for (int y=0;y<arrText.Count;y++)
					{
						body += arrText[y]+ "\n";
					}
					this.txtDespliega.Text=body;
					txtDespliega.Visible = true; 
				
				}
				else
				{
					txtDespliega.Text = "";
					//Response.Write("<script>confirm('Debido al tamaño de la bitacora esta será descargada');</script>");
					txtcadena=_path + "\\" + archivo;
					//this.Response.AppendHeader("content-disposition", "attachment; filename=" + archivo);
					DownloadFile(this,_path + "\\" + archivo,false,archivo,"txt");



				}
         
			}
		}

		
		public static void DownloadFile(Page page, string tempfilename, bool deleteAfterDownload, string filenameForDialog, string mimeType )
		{
			//Preparing information to download file
			page.Response.Clear();
		
			page.Response.ContentType=mimeType; //"text/xml";
			page.Response.AddHeader("Content-Disposition","attachment; filename="+filenameForDialog);
			page.Response.AddHeader("Content-Transfer-Encoding","binary");
			StreamReader sr=new StreamReader(tempfilename,System.Text.Encoding.ASCII);
			BinaryReader br=new BinaryReader(sr.BaseStream,System.Text.Encoding.ASCII);

			
			byte[] bytes={0};
			bool reading=true;
			int kbytes=0;
			long total=0;
			try
			{
				while ((reading)&&(page.Response.IsClientConnected))
				{
					bytes=br.ReadBytes(30000); //leo en bloques de 30kbytes
					if (bytes.Length!=0)
						page.Response.BinaryWrite(bytes);
					else
						reading=false;
					kbytes++; total++;
					if (kbytes==10000)
					{
						//Debug.WriteLine(total.ToString());
						kbytes=0;
					}
				}
			}
			catch(Exception ex)
			{
				if (ex.Message=="Unable to read beyond the end of the stream.")
				{
					reading=false;
				}
				else
				{
					throw;
				}
			}
			finally
			{
				br.Close();
				sr.Close();
				if (deleteAfterDownload)
				{
					FileInfo auxfile2=new FileInfo(tempfilename);
					auxfile2.Delete();
				}
			}
			page.Response.End();
		}

		private void execventRadioButton(short button)	  
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("ConsultaValue", typeof(Int32)));
			dt.Columns.Add(new DataColumn("FechaValue", typeof(String)));
			dt.Columns.Add(new DataColumn("NombreValue", typeof(String)));
			dt.Columns.Add(new DataColumn("TamañoValue", typeof(String)));

			string ArchivosDatasul=ConfigurationSettings.AppSettings["ImportBitDirectory"];
			string ArchivosSical=ConfigurationSettings.AppSettings["ExportBitDirectory"];

			string _path;
			

			int Longitud; 
			string sExtension;
			if(button ==1)
			{
				// bitacora sicalnet
				_path=ArchivosSical;
				sExtension = "BitExp*.txt";
			}
			else
			{
				// bitacora Datasul
				_path=ArchivosDatasul;
				sExtension = "BitImp*.txt";
			}
		
			txtDespliega.Text="";
			DirectoryInfo miDir = new DirectoryInfo(_path);
			string sc1,sano,smes,sdia,sfecha;
			
			int dia,ano;
		
			if (!miDir.Exists)
			{
				lblError.Text = " Alerta !! Directorio No valido, Favor de revisar la configuración en el archivo Web.config";
				dgdVerBitacora.Visible=false;
				txtDespliega.Visible=false;
                
			}
			else
			{
				// creamos datatable temporal de vaciado de dias
				
				DataRow dr;

				lblError.Text = "";               
				foreach (FileInfo fi in miDir.GetFiles(sExtension))
				{					
					sc1   = fi.ToString();
					Longitud = sc1.Length; 	
					sano   = sc1.Substring(6, 4);
					smes   = sc1.Substring(10, 2);
					sdia   = sc1.Substring(12, 2);
					dia=int.Parse(sdia);
					ano=int.Parse(sano);				

					if (Longitud ==18)
					{
						if (validdate(sano + "-" + smes + "-" + sdia))
							{
								smes = GetMonth(smes);
					
								if (smes!="Desconocido")
								{
									dr = dt.NewRow();
									sdia   = sc1.Substring(12, 2);
									sfecha = sdia + " de " + smes + " de " + sano;
									dr[1] = (sfecha);
									dr[2] = (fi);
									dr[3] = (fi.Length);
									dt.Rows.Add(dr);									
								}	
							}
					}
										
				}      					     			
				cargar(dt); 		
			}					
			
		}

		
		

		private void cargar(DataTable dt)
		{
			dgdVerBitacora.DataSource = dt;
			dgdVerBitacora.DataBind();
			dgdVerBitacora.Visible = dgdVerBitacora.Items.Count > 0;
			txtDespliega.Visible = false;

			if (dgdVerBitacora.Items.Count <= 0)
				lblError.Text = "No se han encontrados bitacoras registradas";
		}
		

		private bool validdate(string DateyyyyMMdd)
		{
			DateTime dt;
			bool isDate = true;

			try
			{
				dt = DateTime.Parse(DateyyyyMMdd); 
			}
			catch //(Exception ex)
			{
				// isDate = false;
			}

			return isDate;


		}

		//		void ShowStats() 
		//		{
		//	lblCurrentIndex.Text = "CurrentPageIndex es " + dgdVerBitacora.CurrentPageIndex;
		//	lblPageCount.Text = "PageCount es " + dgdVerBitacora.PageCount;
		//		}
		



		private void dgdVerBitacora_Page(object source,System.Web.UI.WebControls.DataGridPageChangedEventArgs e) 
		{      
			int startIndex = 0;
			// Set CurrentPageIndex to the page the user clicked.
			dgdVerBitacora.CurrentPageIndex = e.NewPageIndex;
			//dgdVerBitacora.CurrentPageIndex = 1;

			// Calculate the index of the first item to display on the page 
			// using the current page index and the page size.
			startIndex = dgdVerBitacora.CurrentPageIndex * dgdVerBitacora.PageSize;

			// Retrieve the segment of data to display on the page from the 
			// data source and bind it to the DataGrid control.
			//BindGrid();

			//dgdVerBitacora.CurrentPageIndex = e.NewPageIndex;
			if(rdbSicalnet.Checked)
				execventRadioButton(1);
			else
				execventRadioButton(2);
			
		}

		private void linkbitacora_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("UpdateMaterialListDta.aspx");
		}

		private void txtDespliega_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	
		private void viewcontrols(bool estado)
		{
			dgdVerBitacora.Visible = estado;
			txtDespliega.Visible = estado;
		}

		private string GetMonth(string smes)
		{
			switch (smes)
			{
				case "01" :
					return "Enero";
					//break;
				case "02" :
					return "Febrero";
					//break;
				case "03" :
					return "Marzo";
					//break;
				case "04" :
					return "Abril";
					//break;
				case "05" :
					return "Mayo";
					//break;
				case "06" :
					return "Junio";
					//break;
				case "07" :
					return "Julio";
					//break;
				case "08" :
					return "Agosto";
					//break;
				case "09" :
					return "Septiembre";
					//break;
				case "10" :
					return "Octubre";
					//break;
				case "11" :
					return "Noviembre";
					//break;
				case "12" :
					return "Diciembre";
					//break;
				default:
					return "Desconocido";
					//break;
			}
	}
	}
}
