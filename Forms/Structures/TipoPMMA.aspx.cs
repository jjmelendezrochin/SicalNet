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

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for TipoPMMA.
	/// </summary>
	public class TipoPMMAForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected Controls.TipoPMMAGrid TipoPMMAGridControl;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.Button AddTipoPMMA;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.ImageButton cmdFindMaterial;
		protected System.Web.UI.WebControls.Label Label1;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.AddTipoPMMA.Click += new System.EventHandler(this.AddTipoPMMA_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.ID = "TipoPMMAForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddTipoPMMA_Click(object sender, System.EventArgs e)
		{
			//Validation pltVdlt = new Validation();

			string CodigoSAP;

			try
			{
				//to check the CodigoSAP whether its correct or not
				if (txtCodigoSAP.Text.Trim() == String.Empty)
				{
					prcErrorDisplay(null,"Debe de capturar el código del material código SAP");
					return;
				}

				if (txtCodigoSAP.Text.Trim() != String.Empty)
				{
					MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
					if (!Material.isExistMaterial(mInfo))
					{
						prcErrorDisplay(null,"El código SAP del material no se encuentra en el catalogo de Materiales");
						return;
					}
				}

				// to initialize the Stoage Material info into business entities
				CodigoSAP = txtCodigoSAP.Text.Trim();

				//to assign the TipoPMMA info into business entity lager
				TipoPMMAInfo TipoPMMAInfo = new TipoPMMAInfo(CodigoSAP);

				//to get an instance for business logic layer
				SICALNet.BusinessLogicLayer.TipoPMMA TipoPMMA = new SICALNet.BusinessLogicLayer.TipoPMMA();
				//to Call the Insert TipoPMMA Information method
				TipoPMMA.InsertTipoPMMA(TipoPMMAInfo);
			
				// Alta de tipoPMMA en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de codigo: " + TipoPMMAInfo.CodigoSAP + " descripcion: " +  txtDescripcion.Text,this.User.Identity.Name.ToString());

				//to fill the datagrid
				TipoPMMAGridControl.BindGrid();

				//To Clear the TextBox Controls
				txtCodigoSAP.Text = string.Empty;
				txtDescripcion.Text=string.Empty;

				prcErrorDisplay(null,"NoError");
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"El ID Identificador ya esta siendo usado.");				
			}
			catch (Exception errHand)
			{
				string mensaje =
					errHand.Message
						.Replace("\\", "\\\\")
						.Replace("'", "\\'")
						.Replace("\r", "")
						.Replace("\n", "\\n");

				string ScriptString =
					"<script language='javascript'>" +
					"SicalAlert.mostrar(" +
					"'" + mensaje + "'," +
					"'Aviso'" +
					");" +
					"</script>";

				ClientScript.RegisterStartupScript(
					this.GetType(),
					"ErrorValidacion",
					ScriptString
				);
			}
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("TipoPMMA Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
				lblErrorMsg.BackColor=Color.Red;
			}
		}

		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

		private void cmdFindMaterial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=TipoPMMAForm&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
				txtDescripcion.Text=string.Empty;
			}
		}

		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
			if (theCodigoSAP!=string.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcion.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{
					MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
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
	}
}
