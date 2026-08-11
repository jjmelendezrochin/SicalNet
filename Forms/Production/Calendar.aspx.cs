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

namespace WebApplication1
{
	/// <summary>
	/// Summary description for WebForm3.
	/// </summary>
	public class Calendar : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.Calendar cdrControl;
		protected System.Web.UI.WebControls.Button btnReturnDate;
		protected System.Web.UI.WebControls.Button btnCloseWindow;		
		protected System.Web.UI.WebControls.DropDownList cboYear;
		protected System.Web.UI.WebControls.DropDownList cboMonth;
		protected System.Web.UI.WebControls.Button btnSetDate;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label lblAnio;
	
		public string strSelectedDate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			if (!IsPostBack)
			{
				prcFillCombo();
				
				btnCloseWindow.Attributes.Add("onclick", "javascript:Close();");

				try
				{
					string strDate=string.Empty;

					if (Request.QueryString["txtDate"] != "")
					{
						strDate=Request.QueryString["txtDate"];

						try
						{
							cdrControl.VisibleDate = DateTime.Parse(strDate);
							cdrControl.SelectedDate = DateTime.Parse(strDate);
						}
						catch
						{
							strDate=System.DateTime.Now.ToString();
						}
					}
					else
					{
						strDate=System.DateTime.Now.ToString();
					}
					
					strDate = DateTime.Parse(strDate).ToString("dd-MMMM-yyyy");
					string strMonth=strDate.Substring(3,strDate.Length-8);
					string strYear=strDate.Substring(strDate.Length-4,4);

					ddlMonth.SelectedIndex = -1;
					ddlYear.SelectedIndex = -1;

					ddlMonth.Items.FindByText(strMonth).Selected = true;
					ddlYear.Items.FindByText(strYear).Selected = true;
					strSelectedDate = cdrControl.SelectedDate.ToString("dd-MMM-yyyy");
					strSelectedDate = strSelectedDate.Replace(".","");
				}
				catch
				{
					throw;
				}
			}
		}

		private void prcFillCombo()
		{

			try
			{
				string sDate=string.Empty;
				int iIdx,iLoop;
			
				for (iLoop=DateTime.Now.Year+100; iLoop >= DateTime.Now.Year-100; iLoop--)
				{
					ddlYear.Items.Add(new ListItem(Convert.ToString(iLoop),Convert.ToString(iLoop)));				
				}

				for (iLoop = 0; iLoop <= ddlYear.Items.Count - 1; iLoop ++)
				{
					if(ddlYear.Items[iLoop].Text == DateTime.Today.Year.ToString())
					{
						ddlYear.Items[iLoop].Selected = true;
					}
				}
						
				for (iLoop=1; iLoop <= 12; iLoop++)
				{	
					sDate = Convert.ToDateTime("01/" + Convert.ToString(iLoop) + "/2005").ToString("MMMM-dd-yyyy");
					iIdx = sDate.IndexOf("-",0);
					if (iIdx > 0)
						ddlMonth.Items.Add(new ListItem(sDate.Substring(0,iIdx), iLoop.ToString()));
				}

				cdrControl.SelectedDate=DateTime.Now;
			}
			catch
			{
				throw;
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
			this.cdrControl.SelectionChanged += new System.EventHandler(this.myCalendar_SelectionChanged);
			this.btnReturnDate.Click += new System.EventHandler(this.btnReturnDate_Click);			
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void myCalendar_SelectionChanged(object sender, System.EventArgs e)
		{
			strSelectedDate = cdrControl.SelectedDate.ToString("dd-MMM-yyyy");			
			strSelectedDate = strSelectedDate.Replace(".","");
		}

		public void ddl_SelectedIndexChanged(Object sender ,System.EventArgs e)        
		{
			cdrControl.VisibleDate = new DateTime(int.Parse(ddlYear.SelectedItem.Value),int.Parse(ddlMonth.SelectedItem.Value), 1);    
		}

		private void btnReturnDate_Click(object sender, System.EventArgs e)
		{
			strSelectedDate = cdrControl.SelectedDate.ToString("dd-MMM-yyyy");
			strSelectedDate = strSelectedDate.Replace(".","");

			string scriptString = string.Empty;

			scriptString+="<script language='javascript'>ReturnDate();</script>"; 
			Page.RegisterStartupScript("ClientScript",scriptString);		
		}
	
	}
}
