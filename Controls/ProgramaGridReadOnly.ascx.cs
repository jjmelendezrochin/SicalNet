namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using System.Configuration;
	
	using SICALNet.Utilities;
	using SICALNet.BusinessEntities;
	using SICALNet.BusinessLogicLayer;
	using CrystalDecisions.Shared;

	/// <summary>
	///		Summary description for ProgramaGridReadOnly.
	/// </summary>
	public abstract class ProgramaGridReadOnly : System.Web.UI.UserControl
	{

		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.DropDownList ddlIdLinea;
		protected System.Web.UI.WebControls.DataList lstProgram;
		protected System.Web.UI.WebControls.Label lblmsg;		
		protected System.Web.UI.WebControls.Button cmdprint;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFecha;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label IdLote;
		protected System.Web.UI.WebControls.DropDownList ddlLote;
		protected System.Web.UI.WebControls.Label lblDate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				try
				{

					SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
					theUser  = BLLUser.Load(theUser);

					//to fill the Linea description into the cboLinea control
					SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
					SICALNet.BusinessLogicLayer.Lote BLLLote=new SICALNet.BusinessLogicLayer.Lote();

									
					IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
					ddlIdLinea.DataSource=RsLine;
					ddlIdLinea.DataValueField="IdLinea";
					ddlIdLinea.DataTextField="Description";
					ddlIdLinea.DataBind();
					ddlIdLinea.Items.Add(new ListItem(string.Empty,"0"));

					//Load lotes					
					LoteInfo belLote = new LoteInfo(0,0,0,false);
					Lote bllLote = new Lote();
					
					ddlLote.DataSource=bllLote.getLote(belLote);
					ddlLote.DataValueField="NumeroLote";
					ddlLote.DataTextField="NumeroLote";
					ddlLote.DataBind();

					string lineaDefault;

					switch(theUser.IdPlanta)
					{
						case 1:	// Ocoyoacac
							lineaDefault = "1";
							break;
						case 2: // San Luis
							lineaDefault = "4";
							break;
						default:
							lineaDefault = "0";
							break;
					}

					ddlIdLinea.Items.FindByValue(lineaDefault).Selected=true;
					
					txtFecha.Text =  System.DateTime.Now.ToString("dd-MMM-yyyy");
					//Hide the "new record" controls
					lstProgram.ShowFooter=false;
					  

				}
				catch
				{
//					ErrorHandling errFileWrite=new ErrorHandling();
//					errFileWrite.HandleException("Programa Production",ex,Server.MapPath("SICALNet")+"Error.txt");
//					lblmsg.Text = ex.Message;
//					return;

					throw;
				}
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ddlIdLinea.SelectedIndexChanged += new System.EventHandler(this.ddlIdLinea_SelectedIndexChanged);
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.lstProgram.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_ItemCommand);
			this.lstProgram.CancelCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_CancelCommand);
			this.lstProgram.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_EditCommand);
			this.lstProgram.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_UpdateCommand);
			this.lstProgram.DeleteCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstProgram_DeleteCommand);
			this.lstProgram.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.lstProgram_ItemDataBound);
			this.cmdprint.Click += new System.EventHandler(this.cmdprint_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//If any Fecha is avilable for that Linea, those all Fecha will be in dropdown list
		private void ddlIdLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			

		}
		private void BindGrid()
		{
			
			try
			{
				                
				//to fill the fecha from programm production into fecha combo box
				SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
								
				lstProgram.DataSource = bllProgramma.Load(txtFecha.Text, txtFecha.Text,Int32.Parse(ddlIdLinea.SelectedItem.Value));
				lstProgram.DataBind();
				

			}
			catch
			{
//				ErrorHandling errFileWrite=new ErrorHandling();
//				errFileWrite.HandleException("Programma Production",ex,Server.MapPath("SICALNet")+"Error.txt");
//				lblmsg.Text = ex.Message;
//				return;

				throw;
			}
		}


//		//to set focus for specified control
//		private void setFocus(WebControl web)
//		{
//			Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" + web.ClientID + "').focus();" + "</SCRIPT>");
//		}
			
	
//		private void ClearFooterData()
//		{
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtPrioridad")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCorrida")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCantidad")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCodigoSAP")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtOrden")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtPedido")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtLoteInsp")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtRendimiento")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtCliente")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtFechaEmb")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtTipoMolde")).Text=string.Empty;
//			((TextBox)lstProgram.Controls[lstProgram.Items.Count+1].FindControl("txtComentarios")).Text=string.Empty;
//		}

		public void Expand(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			ImageButton boton=(ImageButton)sender;
			string id =boton.ClientID;
			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			string url = boton.ImageUrl.ToLower();
			//string url = boton.ImageUrl;
			/*** fin de modificación ***/
			int index =Convert.ToInt32(id.Substring(26,id.LastIndexOf("_")-26));		

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			if (String.Compare(url,"../images/plusbutton.jpg")==0)
			//if (url.ToLower()=="../images/plusbutton.jpg")
			/*** fin de modificación ***/
			{
				boton.ImageUrl="../images/minusButton.jpg";
				HtmlTable detailsTable=((HtmlTable)lstProgram.Items[index-1].FindControl("SequenceDetails"));
				detailsTable.Visible=true;			
			}
			else
			{
				boton.ImageUrl="../images/plusButton.jpg";
				HtmlTable detailsTable=((HtmlTable)lstProgram.Items[index-1].FindControl("SequenceDetails"));
				detailsTable.Visible=false;			
			}
		}
					
		private void lstProgram_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "AddMessage":
					string Secuencia = ((Label)e.Item.FindControl("lblSecuencia")).Text.ToString();
					string Fecha = ((Label)e.Item.FindControl("lblFecha")).Text.ToString();
					string Descripcion= ((Label)e.Item.FindControl("lblMaterialDesc")).Text.ToString();
					string Cantidad= ((Label)e.Item.FindControl("lblCantidad")).Text.ToString();
					Page.RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../Production/ConsultMessage.aspx?Secuencia="+Secuencia+"&Fecha="+Fecha+"&Descripcion="+Descripcion+"&Cantidad="+Cantidad+"','anycontent','width=600,height=500,left=100, top=150,status,scrollbars=no'); </script>");
					break;
				
				case  "Save":
				
					break;

				case "CancelNew":
					lstProgram.ShowFooter=false;
					break;

			}
		}

		private void lstProgram_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			//Obtain Controls
			Label oldQuantityControl =(Label)e.Item.FindControl("lblCantidad");
			TextBox newQuantityControl = (TextBox)e.Item.FindControl("txtQuantity");
			Label oldPriorityControl =(Label)e.Item.FindControl("lblPrioridad");
			TextBox newPriorityControl = (TextBox)e.Item.FindControl("txtPriority");
			//Set original Quantity
			newQuantityControl.Text=oldQuantityControl.Text;
			newPriorityControl.Text=oldPriorityControl.Text;
			SetEditMode(e,true);	
		}

		private void lstProgram_CancelCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			SetEditMode(e,false);	
			lblmsg.Text=string.Empty;
		}

		private void SetEditMode(System.Web.UI.WebControls.DataListCommandEventArgs e, bool enabled)
		{
			//Obtain Controls
			Label oldQuantityControl=(Label)e.Item.FindControl("lblCantidad");
			TextBox newQuantityControl = (TextBox)e.Item.FindControl("txtQuantity");
			Label oldPriorityControl =(Label)e.Item.FindControl("lblPrioridad");
			TextBox newPriorityControl = (TextBox)e.Item.FindControl("txtPriority");

			ImageButton editButton=(ImageButton)e.Item.FindControl("cmdEdit");
			ImageButton deleteButton=(ImageButton)e.Item.FindControl("cmdDelete");
			ImageButton updateButton=(ImageButton)e.Item.FindControl("cmdUpdate");
			ImageButton cancelButton=(ImageButton)e.Item.FindControl("cmdCancel");

			//Set Visibility of Quantity Controls
			oldQuantityControl.Visible=!enabled;
			newQuantityControl.Visible=enabled;
			oldPriorityControl.Visible=!enabled;
			newPriorityControl.Visible=enabled;

			//Set Visibility of Buttons
			editButton.Visible=!enabled;
			deleteButton.Visible=!enabled;
			updateButton.Visible=enabled;
			cancelButton.Visible=enabled;
		}

		private void lstProgram_DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			//Initialize any message
			lblmsg.Text=string.Empty;
			try
			{
				string Sequence =((Label)e.Item.FindControl("lblSecuencia")).Text;
				int Cantidad = Convert.ToInt32(((Label)e.Item.FindControl("lblCantidad")).Text);
				int IdStatus = Convert.ToInt32(((Label)e.Item.FindControl("Label16")).Text);
				SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(Sequence);
				SICALNet.BusinessLogicLayer.Programa bllProgramma= new SICALNet.BusinessLogicLayer.Programa();
			
				if(bllProgramma.HasWorkOrders(belProgramma))
				{
					if(IdStatus==Convert.ToInt32(ConfigurationManager.AppSettings["SequenceStatusReleased"]))
						throw new Exception("La Secuencia "+ Sequence+" ya está cancelada, no puede ser cancelada nuevamente");
					else if(IdStatus==Convert.ToInt32(ConfigurationManager.AppSettings["SequenceStatusCancel"]))
						throw new Exception("La Secuencia "+ Sequence+" ya está cancelada, no puede ser cancelada nuevamente");
					SICALNet.BusinessEntities.OrdenesTrabajoInfo oInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Sequence,0,Convert.ToInt32(ConfigurationManager.AppSettings["StatusCancel"]),Convert.ToInt32(ConfigurationManager.AppSettings["SequenceStatusCancel"]));						
					bllProgramma.CancelSecuence(oInfo);
					//to get the weight of each Laminas for the codigosap of that secuencia
					bllProgramma.UpdateReaccion(Sequence,DateTime.Parse(txtFecha.Text).ToString("dd/MMM/yyyy"),Convert.ToInt32(ddlIdLinea.SelectedItem.Value),Cantidad);
					//lblmsg.Text = string.Format("* La secuencia {0} ya tiene sus Ordenes de Trabajo, por lo tanto no podrá eliminarse. Cancele la orden de trabajo",Sequence);
					lblmsg.Text = string.Format("* La secuencia {0} se eliminó con éxito",Sequence);
					return;
				}
				else
				{
					bllProgramma.DeleteSecuence(belProgramma);
					BindGrid();
					lblmsg.Text = "El registro se eliminó con éxito";
					return;
				}
			}
			catch
			{
				//ErrorHandling errFileWrite=new ErrorHandling();
				//errFileWrite.HandleException("Programm Production",ex,Server.MapPath("SICALNet")+"Error.txt");
//				lblmsg.Text = ex.Message;
//				return;

				throw;
			}
		}

		private void lstProgram_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			//Object to validate
			Validation validate = new Validation();

			//Obtain Sequence quantity
			TextBox newQuantityControl = (TextBox)e.Item.FindControl("txtQuantity");
			string newQuantity=newQuantityControl.Text.Trim();
			//Obtain Sequence Priority
			TextBox newPriorityControl = (TextBox)e.Item.FindControl("txtPriority");
			string newPriority=newPriorityControl.Text.Trim();

			//Validate the user provided data
			if(newQuantity != string.Empty)
			{
				
				if(!validate.IsNumber(newQuantity))
				{
					lblmsg.Text = "La cantidad debe ser numérico";
					return;
				}

				int NumeroLote = Int32.Parse(((Label)e.Item.FindControl("lblLote")).Text.Trim());
				//get the IdLinea from linea Dropdowm list that  already got IdLinea as value , Description as text in dropdown list from Linea table when form Load event
				int IdLinea =Int32.Parse(ddlIdLinea.SelectedItem.Value);
				//get fetch from fecha dropdowm list that already got fecha as value and formated fecha as text in drop down list from Programma production table that is related select linea, when user select require linea from dropdown list
				//string Fecha = DateTime.Parse(txtFecha.Text).ToString("dd/MMM/yyyy");
				
				SICALNet.BusinessEntities.LoteInfo belLoteCantidad = new SICALNet.BusinessEntities.LoteInfo(NumeroLote,IdLinea ,0,false);
				SICALNet.BusinessLogicLayer.Lote bllLoteCantidad = new SICALNet.BusinessLogicLayer.Lote();
				
				//to check cantidad is exceet from stock
				if(bllLoteCantidad.getPiezas(belLoteCantidad) >= (Int32.Parse(newQuantity)))
				{
					try
					{
						string secuencia = ((Label)e.Item.FindControl("lblSecuencia")).Text.Trim();
						SICALNet.BusinessEntities.ProgramaInfo belProgramma = new SICALNet.BusinessEntities.ProgramaInfo(secuencia,DateTime.Today.ToString("dd/MMM/yyyy"),Int32.Parse(newQuantity),newPriority);
						SICALNet.BusinessLogicLayer.Programa bllProgramma = new SICALNet.BusinessLogicLayer.Programa();
						bllProgramma.UpdateSequence(belProgramma);
						lstProgram.EditItemIndex=-1;
						lblmsg.Text = "El registro se modifico con éxito";
						BindGrid();
						return;
						
					}
					catch
					{
//						ErrorHandling errFileWrite=new ErrorHandling();
//						//errFileWrite.HandleException("Programa Production",ex,Server.MapPath("SICALNet")+"Error.txt");
//						lblmsg.Text = ex.Message;
//						return;

						throw;
					}
				}
				else
				{
					lblmsg.Text = string.Format("La cantidad de láminas ({0}) de la secuencia es mayor a la capacidad del lote No.{1} (capacidad del lote:{2})",newQuantity,belLoteCantidad.NumeroLote.ToString(),bllLoteCantidad.getPiezas(belLoteCantidad).ToString());
					return;
				}
			}
			else
			{
				lblmsg.Text = "Debe capturar una cantidad";
				return;
			}		
		}

//		private string getNextSequence()
//		{
//			DataTable newTable = new DataTable();
//			DataTable otherTable = new DataTable();
//			DataColumn newColumn = new DataColumn("Sequence");
//			DataColumn otherColumn = new DataColumn("Sequence");
//			newTable.Columns.Add(newColumn);
//			otherTable.Columns.Add(otherColumn);
//
//			DataRow newRow; 
//
//			for (int i=0;i<lstProgram.Items.Count;i++)
//			{
//				newRow=newTable.NewRow();
//				newRow["Sequence"]=((Label)lstProgram.Items[i].FindControl("lblSecuencia")).Text;
//				newTable.Rows.Add(newRow);
//			}
//
//			//Get the elements of the table sorted
//			DataRow[] sortedRows= newTable.Select(string.Empty,"Sequence");
//			
//			for (int i=0;i<sortedRows.Length;i++)
//			{
//				//add elements to other Table
//				otherTable.Rows.Add(sortedRows[i].ItemArray);			
//			}
//			//Create the new sequence based on last element
//			int NewSequence=0;
//			if(otherTable.Rows.Count!=0)
//			{
//				NewSequence = Convert.ToInt32(otherTable.Rows[otherTable.Rows.Count-1]["Sequence"]);
//			}
//			else
//			{
//				DateTime auxFecha;
//				auxFecha = DateTime.Parse(txtFecha.Text.ToString());  
//				NewSequence = Convert.ToInt32(this.ddlIdLinea.SelectedItem.Value.ToString() + auxFecha.ToString("yy") + auxFecha.ToString("MM") + auxFecha.ToString("dd") + "00");
//			}
//			NewSequence=NewSequence+1;
//
//			return NewSequence.ToString();
//		}



		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../NewMenu.aspx");
		}

		private void cmdprint_Click(object sender, System.EventArgs e)
		{
			//to check wheather IdLinea, Fecha dropdown list empty or not
			if(NotEmpty())
			{
				int IdLinea =Int32.Parse(ddlIdLinea.SelectedItem.Value);
				string Fecha = DateTime.Parse(txtFecha.Text).ToString("dd/MMM/yyyy");
				PrepareReport(Fecha,IdLinea);
			}
		}

		private void PrepareReport(string fechaInicial, int linea)
		{
			try
			{

				Forms.Reports.ReportHelper rptHelper = new Forms.Reports.ReportHelper();
				Forms.Reports.ProgramaReport reporte = new Forms.Reports.ProgramaReport();

				ParameterValues campoFecha= new ParameterValues();
				ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
				valorFecha.Value=fechaInicial;
				campoFecha.Add(valorFecha);
				
				reporte.DataDefinition.ParameterFields["FechaInicio"].ApplyCurrentValues(campoFecha);

				valorFecha.Value=linea;
				reporte.DataDefinition.ParameterFields["Linea"].ApplyCurrentValues(campoFecha);


				string	SelectionStr=String.Empty;

				SelectionStr+="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(fechaInicial).ToString("yyyy") + "," + DateTime.Parse(fechaInicial).ToString("MM") + "," + DateTime.Parse(fechaInicial).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + linea;
				reporte.DataDefinition.RecordSelectionFormula=SelectionStr;

			
				string reportName = string.Format("ProgramaProduccion{0}",DateTime.Parse(fechaInicial).ToString("ddMMyy"));

				rptHelper.setPermission(reporte);
				string reportFullName= rptHelper.exportReport(reporte,reportName,Page.User.Identity.Name);

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+reportFullName+".pdf";
				Response.Redirect(redirectPath);

			}
			catch
			{
				throw;
			}
		}

		private void btnSel_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		private void lstProgram_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label lblFechaMod = (Label)e.Item.FindControl("ItemFechaMod");
				if (lblFechaMod.Text != "") 
				{
					e.Item.BackColor = Color.Yellow;
				}				
									
				if (lblFechaMod.Text.ToString()  == DateTime.MinValue.ToString("dd/MMM/yy")) 
					e.Item.BackColor = Color.LightBlue;   

				Label lblStatus = (Label)e.Item.FindControl("Label16");
				if (lblStatus.Text == ConfigurationManager.AppSettings["SequenceStatusCancel"]) 
				{
					e.Item.BackColor = Color.Tomato;
				}	

			}

		}

		//to check wheather IdLinea, Fecha dropdown list empty or not
		private bool NotEmpty()
		{
			if(ddlIdLinea.SelectedItem.Text.Trim() =="")
			{
				lblmsg.Text = "Seleccione una línea";
				return false;
			}
			return true;
		}


	}
}
