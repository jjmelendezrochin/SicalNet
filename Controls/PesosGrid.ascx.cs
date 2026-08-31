namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	using SICALNet.Utilities;
	using SICALNet.BusinessEntities;


	/// <summary>
	///		Summary description for PesosGrid.
	/// </summary>
	public abstract class PesosGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdPeso;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label lblallowedit;

		public int IdMedida
		{
			get { return int.Parse(ViewState["idMedida"].ToString()); }
			set { ViewState["idMedida"] = value;}
		}
		public string IdEspesor
		{
			get { return ViewState["idEspesor"].ToString(); }
			set { ViewState["idEspesor"] = value;}
		}
		public int IdPlanta
		{
			get { return int.Parse(ViewState["idPlanta"].ToString()); }
			set { ViewState["idPlanta"] = value;}
		}
		public int Revision
		{
			get { return int.Parse(ViewState["revision"].ToString()); }
			set { ViewState["revision"] = value;}
		}

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			//BindGrid - to fill the datagrid
			//if (!IsPostBack)
			//	BindGrid();
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
			this.dgdPeso.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdPeso_PageIndexChanged);
			this.dgdPeso.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPeso_CancelCommand);
			this.dgdPeso.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPeso_EditCommand);
			this.dgdPeso.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPeso_UpdateCommand);
			this.dgdPeso.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPeso_DeleteCommand);
			this.dgdPeso.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdPeso_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
/*
		public void BindGrid()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Peso Peso= new SICALNet.BusinessLogicLayer.Peso();
				// to Call the Select method
				IList pesoList = (IList)Peso.SelectPeso();
				//to assign the result set into datagrid
				dgdPeso.DataSource = pesoList;
				//to fill the datagrid
				dgdPeso.DataBind();

				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default
				Session["Mode"]="Default";
			}
			catch(Exception errHand)
			{  
				//to display the error msg
				prcErrorDisplay(errHand,"Error");
			}
		}
*/
		public void BindGrid(bool AllowEdit)
		{
			lblallowedit.Text = AllowEdit.ToString();
            try
			{
				SICALNet.BusinessEntities.PesoInfo belPeso = new PesoInfo(this.IdMedida, this.IdEspesor, this.IdPlanta, this.Revision);
				//to get the instance for BusinessLogicLayer for a data query filter of fields values
				SICALNet.BusinessLogicLayer.Peso Peso= new SICALNet.BusinessLogicLayer.Peso();
				// to Call the Select method
				//IList pesoList = (IList)Peso.SelectPeso(belPeso);
				//to assign the result set into datagrid
				dgdPeso.DataSource = (IList)Peso.LoadPeso(belPeso);//pesoList;
				//to fill the datagrid
				dgdPeso.DataBind();

				if (AllowEdit == true)
					dgdPeso.Columns[8].Visible = true;
					else
					dgdPeso.Columns[8].Visible = false;
				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default
				Session["Mode"]="Default";
			}
			catch(Exception errHand)
			{  
				//to display the error msg
				prcErrorDisplay(errHand,"Error");
			}
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Peso Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
			else if (errStatus.Substring(0,4)=="Warn")
			{
				lblErrorMsg.Text = errStatus.Substring(6,errStatus.Length-7);
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else
			{
				//to display the success msg
				lblErrorMsg.Text=errStatus;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
		}

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
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

		private void dgdPeso_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
			dgdPeso.EditItemIndex = (int)e.Item.ItemIndex;

			//to fill the datagrid
			BindGrid(System.Convert.ToBoolean(lblallowedit.Text));

		}

		private void dgdPeso_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdPeso.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
		}

//		private void loadData(DropDownList DDList, string ValueField, string TextField, string CurrentValue)
//		{
//		
//			if (ValueField == "IdFamiliaProductos")
//			{
//				SICALNet.BusinessLogicLayer.FamiliaProducto FamiliaProducto = new SICALNet.BusinessLogicLayer.FamiliaProducto();
//				DDList.DataSource = FamiliaProducto.SelectFamiliaProducto();
//			}
//
//			if (ValueField == "IdMedida")
//			{
//				SICALNet.BusinessLogicLayer.Medida Medida = new SICALNet.BusinessLogicLayer.Medida();
//				DDList.DataSource = Medida.LoadMedida();
//			}
//
//			if (ValueField == "IdEspesor")
//			{
//				SICALNet.BusinessLogicLayer.Espesor Espesor = new SICALNet.BusinessLogicLayer.Espesor();
//				DDList.DataSource = Espesor.LoadEspesor();
//			}
//
//			if (ValueField == "IdLinea")
//			{
//				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
//				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
//				theUser  = BLLUser.Load(theUser);
//
//				SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();
//				DDList.DataSource = Linea.SelectLinePdt(theUser);
//			}
//
//			if (ValueField == "IdPlanta")
//			{
//				SICALNet.BusinessLogicLayer.Planta Planta = new SICALNet.BusinessLogicLayer.Planta();
//				DDList.DataSource = Planta.SelectPlanta();
//			}
//
//			DDList.DataValueField = ValueField;
//			DDList.DataTextField  = TextField;
//			DDList.DataBind();
//
//			//select the old value in DropDownList
//			DDList.Items.FindByText(CurrentValue.Trim()).Selected=true;
//		}

		private void dgdPeso_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.EditItem)
			{

//				// To Load Data for Medida DropDownList Box
//				Label lblMedida = (Label) e.Item.FindControl("lblMedida");
//				DropDownList cboMedida = (DropDownList) e.Item.FindControl("EditMedida");
//				loadData(cboMedida, "IdMedida","Centimetros",lblMedida.Text);
//
//				// To Load Data for Espesor DropDownList Box
//				Label lblEspesor = (Label) e.Item.FindControl("lblEspesor");
//				DropDownList cboEspesor = (DropDownList) e.Item.FindControl("EditEspesor");
//				loadData(cboEspesor, "IdEspesor","Centimetros",lblEspesor.Text);
//
//				// To Load Data for Planta DropDownList Box
//				Label lblPlanta = (Label) e.Item.FindControl("lblPlanta");
//				DropDownList cboPlanta = (DropDownList) e.Item.FindControl("EditPlanta");
//				loadData(cboPlanta, "IdPlanta","Description",lblPlanta.Text);

			}
		
		}

		private void dgdPeso_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int IdMedida;
			string IdEspesor;
			int IdPlanta;
			int Revision;

			decimal	Kilos;
			decimal Tolerancia;
			string Elaboro;
			bool Activo;

			try
			{
				//Validation pltVdlt = new Validation();

				try{Kilos = Convert.ToDecimal(((TextBox)e.Item.FindControl("EditKilos")).Text.Trim());}
				catch
				{
					prcErrorDisplay(null, "Debe capturar la cantidad de kilos","Warning");
					return;
				}

				try{Tolerancia = Convert.ToDecimal(((TextBox)e.Item.FindControl("EditTolerancia")).Text.Trim());}
				catch
				{
					prcErrorDisplay(null, "Debe de capturar la tolerancia","Warning");
					return;
				}

				if (((TextBox)e.Item.FindControl("EditElaboro")).Text.Trim() == String.Empty)
				{
					prcErrorDisplay(null, "Debe de capturar el nombre de la persona que elaboró","Warning");
					return;
				}
				
				// To store the values which is having the values before editing
				IdMedida = Convert.ToInt32(((Label)e.Item.FindControl("lblIdMedida")).Text);
				string lblMedida = ((Label)e.Item.FindControl("lblMedida")).Text;
				IdEspesor = ((Label)e.Item.FindControl("lblIdEspesor")).Text;
				IdPlanta = Convert.ToInt32(((Label)e.Item.FindControl("lblIdPlanta")).Text);
				Revision=Convert.ToInt32(((Label)e.Item.FindControl("EditRevision")).Text);

				//PesoInfo ppInfo = new PesoInfo(IdMedida,IdEspesor,IdPlanta,Revision);
				
//TODO: Remove NO longer needed code
//NO LONGER NEEDED
//				// To store the values which is having the values after edit
//				IdFamiliaProductos = Convert.ToInt32(((DropDownList)e.Item.FindControl("EditFamiliaProducto")).SelectedItem.Value);
//				IdMedida = Convert.ToInt32(((DropDownList)e.Item.FindControl("EditMedida")).SelectedItem.Value);
//				IdEspesor = ((DropDownList)e.Item.FindControl("EditEspesor")).SelectedItem.Value;
//				IdLinea = Convert.ToInt32(((DropDownList)e.Item.FindControl("EditLinea")).SelectedItem.Value);
//				IdPlanta = Convert.ToInt32(((DropDownList)e.Item.FindControl("EditPlanta")).SelectedItem.Value);
				
				Kilos = Convert.ToDecimal(((TextBox)e.Item.FindControl("EditKilos")).Text.Trim());
				Tolerancia = Convert.ToDecimal(((TextBox)e.Item.FindControl("EditTolerancia")).Text.Trim());
				Elaboro = ((TextBox)e.Item.FindControl("EditElaboro")).Text.Trim();
				Revision = Convert.ToInt32(((Label)e.Item.FindControl("EditRevision")).Text.Trim());
				
				Activo = ((CheckBox)e.Item.FindControl("EditActivo")).Checked;
				
				PesoInfo pInfo = new PesoInfo(IdMedida, string.Empty, IdEspesor, 0, IdPlanta, string.Empty, Kilos, Tolerancia, Elaboro, Revision, Activo);

				SICALNet.BusinessLogicLayer.Peso Peso = new SICALNet.BusinessLogicLayer.Peso();
				Peso.UpdatePeso(pInfo);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de peso: " + lblMedida  + " kilos: " + Kilos,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdPeso.EditItemIndex = -1;
				
				BindGrid(System.Convert.ToBoolean(lblallowedit.Text));

				//to call error msg function
				prcErrorDisplay(null,"El registro se modifico con éxito","Success");
			}
			catch 
			{
				//to display the error msg
				// prcErrorDisplay(errHand,"Error");
				//to set focus

				throw;
			}
		}

//		// Procedure to Set Focus to Controls
//		private void SetFocus(object sender)
//		{
//			if(sender.GetType().Name=="TextBox")
//				Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" + ((TextBox)sender).ClientID + "').focus();" + "</SCRIPT>");
//		}

		private void dgdPeso_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int IdMedida;
			string IdEspesor;
			int IdPlanta;
			int Revision;

			try
			{
				IdMedida = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdMedida")).Text);
				string ItemMedida = ((Label)e.Item.FindControl("ItemMedida")).Text;
				decimal Kilos = Convert.ToDecimal(((Label)e.Item.FindControl("ItemKilos")).Text);
				IdEspesor = ((Label)e.Item.FindControl("ItemIdEspesor")).Text;
				IdPlanta = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdPlanta")).Text);
				Revision=Convert.ToInt32(((Label)e.Item.FindControl("ItemRevision")).Text);

				PesoInfo pInfo = new PesoInfo(IdMedida, IdEspesor, IdPlanta,Revision);

				SICALNet.BusinessLogicLayer.Peso Peso = new SICALNet.BusinessLogicLayer.Peso();
				Peso.DeletePeso(pInfo);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de peso: " + ItemMedida  + " kilos: " + Kilos,Page.User.Identity.Name.ToString());

				dgdPeso.EditItemIndex = -1;
				BindGrid(System.Convert.ToBoolean(lblallowedit.Text));

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}
			catch 
			{
				//to diaplay error msg
				// prcErrorDisplay(ErrHand,"Error");				

				throw;
			}
		}

		private void dgdPeso_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdPeso.EditItemIndex = -1;
			dgdPeso.CurrentPageIndex = e.NewPageIndex;
			BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
		}
	}
}
