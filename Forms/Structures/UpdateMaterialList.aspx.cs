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
using SICALNet.Utilities;
using System.IO;
using OWC10;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for UpdateMaterialList.
	/// </summary>
	public class UpdateMaterialList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.ImageButton cmdFindMaterial;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.DataGrid dgdMaterial;
		protected System.Web.UI.WebControls.Button btnActualizar;
		protected System.Web.UI.WebControls.Button btnInterface;
		protected System.Web.UI.WebControls.Button btnCSV;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.TextBox txtHidden;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.HtmlControls.HtmlTable tableMaterials;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdResults;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPlanta;
	
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				btnActualizar.Attributes.Add("onClick","showWaitControls()");
				btnInterface.Attributes.Add("onClick","showWaitControls()");
				btnCSV.Attributes.Add("onClick","showWaitControls()");
				LoadPlantaInfo();
			}

			if(txtHidden.Text.Trim()!=string.Empty)
			{
				AddMaterial(txtHidden.Text);
			}
			// Put user code to initialize the page here
		}

		private void LoadPlantaInfo()
		{
			SICALNet.BusinessLogicLayer.Planta plantBLL = new SICALNet.BusinessLogicLayer.Planta();
			cboPlanta.DataSource=plantBLL.SelectPlanta();
			cboPlanta.DataTextField="Description";
			cboPlanta.DataValueField="IdPlanta";
			cboPlanta.DataBind();
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
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.cmdFindMaterial.Click += new System.Web.UI.ImageClickEventHandler(this.cmdFindMaterial_Click);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			this.btnInterface.Click += new System.EventHandler(this.btnInterface_Click);
			this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
			this.dgdMaterial.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdMaterial_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
			int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
			if (theCodigoSAP!=string.Empty)
			{
				//MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				MaterialInfo mInfo= new MaterialInfo(theCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcion.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{
					AddMaterial(theCodigoSAP);
					txtDescripcion.Text=string.Empty;
					txtCodigoSAP.Text=string.Empty;
				}
			}
			else
			{
				prcErrorDisplay(null,string.Empty,"NoError");			
			}		
		}

		private void cmdFindMaterial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
				Page.RegisterStartupScript("ClientScript","<script language=JavaScript>window.open('FindMaterialPP.aspx?FormName=UpdateMaterialList&CtrlName=txtHidden&idPlanta=" +  this.cboPlanta.SelectedItem.Value   + "','FindMaterialPopup','width=600,height=400,top=100,left=100,toolbars=no,scrollbars=yes,status=yes,resizable=no');</script>");		
		}

		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
			int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
			if (theCodigoSAP!=string.Empty)
			{
				
				//MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				MaterialInfo mInfo= new MaterialInfo(theCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcion.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{					
					//MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
					MaterialInfo material= new MaterialInfo(theCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
					SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
					material=materialBLL.SelectMaterial(material);
					txtDescripcion.Text=material.Descripcion;

					prcErrorDisplay(null,string.Empty,"NoError");
				}
			}
			else
			{
				prcErrorDisplay(null,string.Empty,"NoError");			
			}		
		}

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ Message +"')"+ "<" + "/script>");
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else if (ErrStatus=="Warning")
			{
				//to display the warning msg
				lblErrorMsg.Text=Message;
				Page.RegisterStartupScript("alert", string.Format("<script language='JavaScript'>alert('{0}')</script>",Message));
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="Success")
			{
				//to display the success msg
				lblErrorMsg.Text=Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}

			return;
		}

		public void AddMaterial(string CodigoSAP)
		{
			try
			{
				ArrayList gridCurrentItems = new ArrayList();
				string currentCodigoSAP;
				int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
				if (dgdMaterial.Items.Count>0)
				{
					for (int i=0; i<dgdMaterial.Items.Count; i++)
					{
						//obtain CodigoSAP from interface
						currentCodigoSAP=((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text;	
						//Create entity to load data
						MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
						//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);
						//Load data from DB
						SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
						//Add item to the grid's datasource
						gridCurrentItems.Add(BLLMaterial.SelectMaterial(BELMaterial));
					}
				}

				string[] Materiales = CodigoSAP.Split(',');

				for (int i=0;i<Materiales.Length;i++)
				{
					//obtain the CodigoSAP 
					currentCodigoSAP=Materiales[i].ToString();	
				
					//If this element has not been added to the list
					if (!PreviouslySelected(currentCodigoSAP))
					{
						//Create entity to load data
						MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);

						//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);

						//Load data from DB
						SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
						//Add item to the grid's datasource
						gridCurrentItems.Add(BLLMaterial.SelectMaterial(BELMaterial));
					}
				}

				dgdMaterial.DataSource=gridCurrentItems;
				dgdMaterial.DataBind();

				txtHidden.Text=string.Empty;
			
				tableMaterials.Visible=(dgdMaterial.Items.Count>0);
			}
			catch
			{
				throw;
			}
		}

		private bool PreviouslySelected(string currentCodigoSAP)
		{
			for (int i=0;i<dgdMaterial.Items.Count;i++)
			{
				if (currentCodigoSAP==((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text)
					return true;
			}
			return false;
		}

//		private void cmdSalir_Click(object sender, System.EventArgs e)
//		{
//
//		}

		private void dgdMaterial_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//Elementos actuales del grid
				ArrayList gridCurrentItems= new ArrayList();
				int idPlanta = Convert.ToInt32(this.cboPlanta.SelectedItem.Value); 
				for (int i=0; i<dgdMaterial.Items.Count; i++)
				{
					if (i!=e.Item.ItemIndex)
					{
						//obtain CodigoSAP from interface
						string currentCodigoSAP=((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text;	
						//Create entity to load data
						//MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty);
						MaterialInfo BELMaterial= new MaterialInfo(currentCodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,idPlanta,false);
						//Load data from DB
						SICALNet.BusinessLogicLayer.Material BLLMaterial = new SICALNet.BusinessLogicLayer.Material();
						//Add item to the grid's datasource
						gridCurrentItems.Add(BLLMaterial.SelectMaterial(BELMaterial));
					}
				}

				dgdMaterial.DataSource=gridCurrentItems;
				dgdMaterial.DataBind();

				tableMaterials.Visible=(dgdMaterial.Items.Count>0);
			}
			catch
			{
				throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
			try
			{
				ArrayList materiales = new ArrayList();

				// if no rows in the grid then return
				if (dgdMaterial.Items.Count<=0)
					return;

				for(int i=0; i<dgdMaterial.Items.Count; i++)
				{
					materiales.Add(((Label)dgdMaterial.Items[i].FindControl("lblCodigoSAP")).Text);
				}

				SICALNet.BusinessLogicLayer.MaterialsSAP mSAP = new SICALNet.BusinessLogicLayer.MaterialsSAP();
				dgdResults.DataSource=mSAP.UpdateMaterialList(materiales,Convert.ToInt32(cboPlanta.SelectedItem.Value));
				dgdResults.DataBind();
			}
			catch
			{
				throw;
			}
		}

		private void btnInterface_Click(object sender, System.EventArgs e)
		{
			ArrayList MSList; 
			SICALNet.BusinessLogicLayer.MaterialsSAP mSAP = new SICALNet.BusinessLogicLayer.MaterialsSAP();
			MSList = (ArrayList)mSAP.Load();

			// Export Data To Excel
			SpreadsheetClass xlsheet = new SpreadsheetClass();
			
			// To Write Excel Header
			xlsheet.ActiveSheet.Cells[1,1] = "CodigoSAP";
			xlsheet.ActiveSheet.Cells[1,2] = "UtilizacionLM";
			xlsheet.ActiveSheet.Cells[1,3] = "Denominacion_SAP";
			xlsheet.ActiveSheet.Cells[1,4] = "Alternativa";
			xlsheet.ActiveSheet.Cells[1,5] = "Descripcion";
			xlsheet.ActiveSheet.Cells[1,6] = "DescripcionMaterialLinea";
			xlsheet.ActiveSheet.Cells[1,7] = "CantidadBase";
			xlsheet.ActiveSheet.Cells[1,8] = "UnidadMedida";
			xlsheet.ActiveSheet.Cells[1,9] = "StatusListaMaterials";
			xlsheet.ActiveSheet.Cells[1,10] = "NoPosicion";
			xlsheet.ActiveSheet.Cells[1,11] = "CodigoSAPHijo";
			xlsheet.ActiveSheet.Cells[1,12] = "CantidadHijo";
			xlsheet.ActiveSheet.Cells[1,13] = "UnidadHijo";
			xlsheet.ActiveSheet.Cells[1,14] = "TipoPosicion";
			xlsheet.ActiveSheet.Cells[1,15] = "Seleccion";
			xlsheet.ActiveSheet.Cells[1,16] = "Rechazo";

			int row = 2, col=1;
			for(int i=0; i<MSList.Count; i++)
			{
				MaterialSAPInfo MSInfo = new MaterialSAPInfo();
				MSInfo = (MaterialSAPInfo) MSList[i];
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.CodigoSAP; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.UtilizacionLM; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Denominacion_SAP; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Alternativa; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Descripcion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.DescripcionMaterialLinea; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.CantidadBase; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.UnidadMedida; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.StatusListaMaterials; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.NoPosicion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.CodigoSAPHijo; col++;
				xlsheet.ActiveSheet.Cells[row,col] = Math.Round(MSInfo.CantidadHijo,3); col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.UnidadHijo; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.TipoPosicion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Seleccion; col++;
				xlsheet.ActiveSheet.Cells[row,col] = MSInfo.Rechazo; col=1;
				row++;
			}

			xlsheet.ActiveSheet.Columns.AutoFit();

			string xlFileName = System.DateTime.Now.ToString("ddMMMyyyy") +".xls";
			
			string fullFileName = string.Format("{0}\\{1}",Server.MapPath("."),xlFileName);
			// save it off to the filesystem...
			xlsheet.Export(fullFileName,OWC10.SheetExportActionEnum.ssExportActionNone,OWC10.SheetExportFormat.ssExportHTML);
			
			DownloadFile(fullFileName);
			// set content header so browser knows you'r sending Excel workbook...
			//Response.ContentType="application/x-msexcel" ;
			// To Save the file in Client's Machine
			//Response.Redirect(xlFileName);
		}

		private void DownloadFile(string filePath)
		{
			System.IO.FileInfo TargetFile = new System.IO.FileInfo(filePath);
			
			//clear the current output content from the buffer
			Response.Clear();
			//add the header that specifies the default filename for the Download/
			//SaveAs dialog
			Response.AddHeader("Content-Disposition", "attachment; filename=" + TargetFile.Name);
			//add the header that specifies the file size, so that the browser
			//can show the download progress
			Response.AddHeader("Content-Length", TargetFile.Length.ToString());
			// specify that the response is a stream that cannot be read by the client and must be downloaded
			Response.ContentType = "application/octet-stream";
			// send the file stream to the client
			Response.WriteFile(TargetFile.FullName);
			// stop the execution of this page
			Response.End();
		}

		private void btnCSV_Click(object sender, System.EventArgs e)
		{
			string fileName=string.Format("{0}.csv",System.DateTime.Now.ToString("ddMMMyyyy"));
			System.IO.StreamWriter sWriter = System.IO.File.CreateText (string.Format("{0}\\{1}",Server.MapPath("."),fileName));

			ArrayList MSList; 
			SICALNet.BusinessLogicLayer.MaterialsSAP mSAP = new SICALNet.BusinessLogicLayer.MaterialsSAP();
			MSList = (ArrayList)mSAP.Load();

			sWriter.WriteLine ("CodigoSAP, UtilizacionLM, Denominacion_SAP, Alternativa, Descripcion, DescripcionMaterialLinea, CantidadBase, UnidadMedida, StatusListaMaterials, NoPosicion, CodigoSAPHijo, CantidadHijo, UnidadHijo, TipoPosicion, Seleccion, Rechazo");

			for(int i = 0; i < MSList.Count; i++)
			{
				string strLine;
				MaterialSAPInfo MSInfo = new MaterialSAPInfo();
				MSInfo = (MaterialSAPInfo) MSList[i];
				
				strLine = string.Format("{0}@{1}@{2}@{3}@{4}@{5}@{6}@{7}@{8}@{9}@{10}@{11}@{12}@{13}@{14}@{15}",
					MSInfo.CodigoSAP, MSInfo.UtilizacionLM,MSInfo.Denominacion_SAP,MSInfo.Alternativa,
					MSInfo.Descripcion,MSInfo.DescripcionMaterialLinea,MSInfo.CantidadBase,MSInfo.UnidadMedida,
					MSInfo.StatusListaMaterials,MSInfo.NoPosicion,MSInfo.CodigoSAPHijo,MSInfo.CantidadHijo,
					MSInfo.UnidadHijo,MSInfo.TipoPosicion,MSInfo.Seleccion,MSInfo.Rechazo);

				sWriter.WriteLine(strLine);
			}
				
			sWriter.Flush();
			sWriter.Close();
			Response.Redirect(fileName);
		}

	}
}
