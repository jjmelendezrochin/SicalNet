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

namespace UserInterface.Forms.Logistics
{
	/// <summary>
	/// Summary description for SecuenciasCombinadas.
	/// </summary>
	public class SecuenciasCombinadas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.Button cmdConsultar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DataList lstProgram;
		protected System.Web.UI.WebControls.Button cmdCombinar;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label lblTitle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				String sFechaIni = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				String sFechaFin = DateTime.Now.Date.ToString("dd-MMM-yyyy");

				txtFecha.Text = sFechaIni.Replace(".","");
				txtFechaFinal.Text = sFechaFin.Replace(".","");

				//txtFecha.Text=DateTime.Now.Date.ToString("dd-MMM-yyyy");
				//txtFechaFinal.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");

				LoadLinesCombo();				
			}		
		}

		private void LoadLinesCombo()
		{
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//to fill the Linea description into the cboLinea control
			SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
			cboLinea.DataSource=RsLine;
			cboLinea.DataValueField="IdLinea";
			cboLinea.DataTextField="Description";
			cboLinea.DataBind();
			cboLinea.Items.Add(new ListItem(string.Empty,"0"));

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

			cboLinea.Items.FindByValue(lineaDefault).Selected=true;
			
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
			this.cmdConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
			this.cmdCombinar.Click += new System.EventHandler(this.cmdCombinar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdConsultar_Click(object sender, System.EventArgs e)
		{
			//If user provided initial date and time
			if (txtFecha.Text.Trim()==string.Empty || txtFechaFinal.Text.Trim()==string.Empty)
			{
				string ScriptString="<script language='javascript'>alert('Proporcione una fecha inicial y final');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
			else
				//Load the sequences that match stablished criteria
				BindGrid(txtFecha.Text.Trim(),txtFechaFinal.Text.Trim(), Convert.ToInt32(cboLinea.SelectedItem.Value));			
		}

		//to bind the data into datagrid
		public void BindGrid(string FrDate,string ToDate,int IdLinea)
		{
			try
			{
				IList RsPrg=null;
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
				// to Call the Select method
				if (IdLinea != 0)
					RsPrg= (IList)BLLPrg.Load(FrDate,ToDate,IdLinea);
				else
					RsPrg= (IList)BLLPrg.Load(FrDate,ToDate);
				//to assign the result set into datagrid
				if (RsPrg.Count == 0)
				{
					lstProgram.DataSource=null;
					lstProgram.DataBind();
				}
				else
				{
					//dgdProgram.DataSource = RsPrg;
					//to fill the datagrid
					//dgdProgram.DataBind();
					//dgdProgram.Visible=true;
					lstProgram.DataSource=RsPrg;
					lstProgram.DataBind();
					lstProgram.Visible=true;
				}
				cmdCombinar.Visible=(RsPrg.Count>0);
			}
			catch
			{
				throw;
			}
		}

		public void CheckAll(object sender, System.EventArgs e)
		{
			for(int j=1; j < lstProgram.Controls.Count; j++)
			{
				for (int k=1; k<lstProgram.Controls[j].Controls.Count;k++)
				{
					((CheckBox)lstProgram.Controls[j].Controls[k].FindControl("chkSelected")).Checked = ((CheckBox)sender).Checked;				
				}
			}
		}

		private void cmdCombinar_Click(object sender, System.EventArgs e)
		{
			if (secuenciasSeleccionadas())
			{
				string selectedSequences=string.Empty;
				if (secuenciasMismoTipo(out selectedSequences))
				{
					performCombination(selectedSequences);
					string ScriptString="<script language='javascript'>alert('Las secuencias seleccionadas fueron combinadas exitosamente');</script>"; 
					Page.RegisterStartupScript("ClientScript",ScriptString);
					BindGrid(txtFecha.Text.Trim(),txtFechaFinal.Text.Trim(),Convert.ToInt32(cboLinea.SelectedItem.Value));
				}
				else
				{
					string ScriptString="<script language='javascript'>alert('Las secuencias seleccionadas son de distintos materiales. Solo materiales del mismo código pueden combinarse. Seleccione secuencias que sean del mismo material (mismo CodigoSAP)');</script>"; 
					Page.RegisterStartupScript("ClientScript",ScriptString);
				}
			}
			else
			{
				string ScriptString="<script language='javascript'>alert('Seleccione cuando menos dos secuencias que desee combinar.');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}

		}

		private void performCombination(string secs)
		{
			//SecuenciaCombinasInfo combinadas= new SecuenciaCombinasInfo(secs,0);
			SecuenciaCombinas BLLCombinadas = new SecuenciaCombinas();
			BLLCombinadas.InsertSecuenciaCombinas(secs);
		}

		/// <summary>
		/// Determines if the selected sequences have the same material type.
		/// </summary>
		/// <returns>TRUE when all materials are the same, FALSE when not.</returns>
		private bool secuenciasMismoTipo(out string secuencias)
		{
			ArrayList seqList=new ArrayList();
			secuencias=string.Empty;
			for (int i=0;i<lstProgram.Items.Count;i++)
			{
				CheckBox selSequence= (CheckBox) lstProgram.Items[i].FindControl("chkSelected");
				if (selSequence.Checked) 
				{
					secuencias+=((Label) lstProgram.Items[i].FindControl("lblSecuencia")).Text +",";
					seqList.Add(((Label) lstProgram.Items[i].FindControl("lblMaterial")).Text);
				}
			}

			if (seqList.Count>0)
			{
				string baseSequece=seqList[0].ToString();
				for (int i=1;i<seqList.Count;i++)
				{
					if (baseSequece!=seqList[i].ToString())
						return false;
				}
			}
			else
				return false;

			return true;
		}

		/// <summary>
		/// Determines if the user selected Sequences.
		/// </summary>
		/// <returns>TRUE when selected, FALSE when not</returns>
		private bool secuenciasSeleccionadas()
		{
			int selectedItems=0;

			for (int i=0;i<lstProgram.Items.Count;i++)
			{
				if (((CheckBox) lstProgram.Items[i].FindControl("chkSelected")).Checked) 
				{
					selectedItems++;
				}
			}

			return (selectedItems>1);
		}

	}
}

