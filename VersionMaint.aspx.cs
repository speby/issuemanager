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

namespace IssueManager
{
	/// <summary>
	/// Summary description for VersionMaint1.
	/// </summary>
	public class VersionMaint1 : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.Label VersionMaintForm_Title;
    protected System.Web.UI.WebControls.Label VersionMaint_ValidationSummary;
    protected System.Web.UI.WebControls.RequiredFieldValidator VersionMaint_version_Validator_Req;
    protected System.Web.UI.WebControls.TextBox VersionMaint_version;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_VersionMaint_version_id;
    protected System.Web.UI.HtmlControls.HtmlTable VersionMaint_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden VersionMaint_version_id;
    protected System.Web.UI.HtmlControls.HtmlInputButton VersionMaint_insert;
    protected System.Web.UI.HtmlControls.HtmlInputButton VersionMaint_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton VersionMaint_delete;
  
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
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion
	}
}
