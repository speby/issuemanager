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
    /// Summary description for UpdatedFiles.
    /// </summary>
    public class UpdatedFiles : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label Label1;
        //  protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
        protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issue_issue_id;
        //IssueChange CustomIncludes begin
        protected CCUtility Utility;
        protected System.Web.UI.WebControls.Repeater Repeater;
//        protected System.Web.UI.WebControls.DataGrid DataGrid1;
        protected System.Data.DataView dvFiles;

        protected ViewCvs.ViewCvs CvsFiles;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;

        static protected System.Data.DataSet ds;
        
		private void Page_Load(object sender, System.EventArgs e)
		{


			Utility=new CCUtility(this);
			CvsFiles = new ViewCvs.ViewCvs();
			Utility.CheckSecurity(1);

           

			if (!IsPostBack)
			{
				int iIssueID = Convert.ToInt32(Utility.GetParam("Issue_ID"));
				Label1.Text = "Files for Issue: "+iIssueID.ToString();
				try
				{
				

					CvsFiles.OpenDB();
					ds = CvsFiles.GetIssueFiles(iIssueID) ;
            
					//test
					//                DataGrid1.DataSource = ds;
					//                DataGrid1.AllowSorting = true;
					//
					//                DataGrid1.DataBind();

                
					dvFiles.Table =ds.Tables[0];

					if (dvFiles.Count > 0)
					{
						Repeater.DataSource =dvFiles;
                
						Repeater.Visible = true;
						Repeater.DataBind();

					}
					else
					{
						Label1.Text += " No Files!";
					}
					

					//                DataGrid1.DataBind();
					//     ds.Clear();
					
				}
				catch (Exception ex)
				{
					Label1.Text = ex.Message;
				}
				finally
				{
					CvsFiles.CloseDB();
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
		
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {    
            this.dvFiles = new System.Data.DataView();
            ((System.ComponentModel.ISupportInitialize)(this.dvFiles)).BeginInit();
            // 
            // dvFiles
            // 
            this.dvFiles.AllowDelete = false;
            this.dvFiles.AllowEdit = false;
            this.dvFiles.AllowNew = false;
            this.dvFiles.ApplyDefaultSort = true;
            this.Load += new System.EventHandler(this.Page_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvFiles)).EndInit();

        }
        #endregion



//        private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
//        {
//           dvFiles.Table = ds.Tables[0];
//           dvFiles.Sort = e.SortExpression.ToString();
//           DataGrid1.DataSource = dvFiles; 
//           DataGrid1.DataBind();
//           DataGrid1.Visible = true;
//        }

        protected void Files_SortChange(Object Src, EventArgs E)
        {
            if(ViewState["SortColumn"]==null || ViewState["SortColumn"].ToString()!=((LinkButton)Src).CommandArgument)
            {
                ViewState["SortColumn"]=((LinkButton)Src).CommandArgument;
                ViewState["SortDir"]="ASC";
            }
            else
            {
                ViewState["SortDir"]=ViewState["SortDir"].ToString()=="ASC"?"DESC":"ASC";
            }

            dvFiles.Table =ds.Tables[0];

   //         dvFiles.Sort =Src.ToString().ToLower()+" "+ViewState["SortDir"];
            string sSort = ((LinkButton)Src).CommandArgument;
            sSort = sSort.ToLower();
            sSort+=" ";
            sSort+=ViewState["SortDir"];
            dvFiles.Sort = sSort;
            Repeater.DataSource =dvFiles;
                
            Repeater.Visible = true;
            Repeater.DataBind();
          //  Issues_Bind();
        }


    }
}
