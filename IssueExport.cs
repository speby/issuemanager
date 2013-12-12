/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: IssueExport.cs
  //    Generated with CodeCharge 2.0.1
  //    ASP.NET C#.ccp build 09/27/2001
  //
  //-------------------------------
  //

  using System;
  using System.Collections;
  using System.ComponentModel;
  using System.Data;
  using System.Data.OleDb;
  using System.Drawing;
  using System.Web;
  using System.Web.SessionState;
  using System.Web.UI;
  using System.Web.UI.WebControls;
  using System.Web.UI.HtmlControls;

  /// <summary>
  ///    Summary description for IssueExport.
  /// </summary>
  public class IssueExport : System.Web.UI.Page

  {

    //IssueExport CustomIncludes begin
    protected CCUtility Utility;

    //Grid form Issues variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Issues_no_records;
    protected string Issues_sSQL;
    protected string Issues_sCountSQL;
    protected int Issues_CountPage;

    protected System.Web.UI.WebControls.Repeater Issues_Repeater;
    protected int i_Issues_curpage=1;

    // For each Issues form hiddens for PK's,List of Values and Actions
    protected string Issues_FormAction=".aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issues_issue_id;
    protected System.Web.UI.WebControls.Label IssuesForm_Title;
    protected System.Web.UI.WebControls.Label Issues_Column_issue_id;
    protected System.Web.UI.WebControls.Label Issues_Column_issue_name;
    protected System.Web.UI.WebControls.Label Issues_Column_status_id;
    protected System.Web.UI.WebControls.Label Issues_Column_dev_issue_number;
    protected System.Web.UI.WebControls.Label Issues_Column_priority_id;
    protected System.Web.UI.WebControls.Label Issues_Column_user_id;
    protected System.Web.UI.WebControls.Label Issues_Column_date_submitted;
    protected System.Web.UI.WebControls.Label Issues_Column_assigned_to_orig;
    protected System.Web.UI.WebControls.Label Issues_Column_assigned_to;
    protected System.Web.UI.WebControls.Label Issues_Column_modified_by;
    protected System.Web.UI.WebControls.Label Issues_Column_date_modified;
    protected System.Web.UI.WebControls.Label Issues_Column_bugversion;
    protected System.Web.UI.WebControls.Label Issues_Column_version;
    protected System.Web.UI.WebControls.Label Issues_Column_Issue_desc;
    protected System.Web.UI.WebControls.Label Issues_Column_dev_status_id;
    protected System.Web.UI.WebControls.Label Issues_Column_user_name_owner;
    protected System.Web.UI.WebControls.Label Issues_Column_user_name_qaowner;
    protected System.Web.UI.WebControls.Label Issues_Column_category;
    protected System.Web.UI.WebControls.Label Issues_Column_user_name_submitted_by;
    protected System.Web.UI.WebControls.Label Issues_Column_Issue_steps_to_recreate;
    protected System.Web.UI.HtmlControls.HtmlTable Issues_holder;

    public IssueExport()
    {

      this.Init += new System.EventHandler(Page_Init);
    }

    // IssueExport CustomIncludes end
    //-------------------------------

    public void ValidateNumeric(object source, ServerValidateEventArgs args)
    {
      try
      {
        Decimal temp=Decimal.Parse(args.Value);
        args.IsValid=true;
      }
      catch{
        args.IsValid=false;
      }
    }
  //===============================
  // IssueExport Show begin
  protected void Page_Load(object sender, EventArgs e)
    {

      Utility=new CCUtility(this);
      //===============================
      // IssueExport Open Event begin
      //No Header or Footer needed
      ((UserControl)Page.FindControl("Header")).Visible=false;
      ((UserControl)Page.FindControl("Footer")).Visible=false;
      this.EnableViewState=false;
      Response.ContentType="application/vnd.ms-excel";
      //Change HTML header to specify Excel's MIME content type
      // IssueExport Open Event end
      //===============================

      //
      //===============================
      // IssueExport PageSecurity begin
      // IssueExport PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Issues_issue_id.Value = Utility.GetParam("issue_id");
        Page_Show(sender, e);
      }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
      //
      // CODEGEN: This call is required by the ASP+ Windows Form Designer.
      //
      if(Utility!=null)
        Utility.DBClose();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
      //
      // CODEGEN: This call is required by the ASP+ Windows Form Designer.
      //
      InitializeComponent();

    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }

    protected void Page_Show(object sender, EventArgs e)
    {
      Issues_Bind();

    }

    // IssueExport Show end

    // End of Login form

    const int Issues_PAGENUM = 0;

    public void Issues_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Issues Show Event begin
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        //Process Assigned To

        if(((DataRowView)e.Item.DataItem )["i_assigned_to"].ToString() == Session["UserID"].ToString())
          ((Label)e.Item.FindControl("Issues_assigned_to")).Text = "<font color=\"red\">" + ((DataRowView)e.Item.DataItem )["u_user_name"].ToString()+ "</font>";

        //Process Priority (value and color)
        string priority_id = Utility.Dlookup("priorities","priority_desc","priority_id=" +  ((DataRowView)e.Item.DataItem)["i_priority_id"].ToString());
        string priority_color= Utility.Dlookup("priorities","priority_color","priority_id=" + ((DataRowView)e.Item.DataItem)["i_priority_id"].ToString());
        ((Label)e.Item.FindControl("Issues_priority_id")).Text = "<font color=\"" + priority_color + "\">" + priority_id + "</font>";
      }
      // Issues Show Event end
    }
    public void Issues_Open(ref string sWhere, ref string sOrder)
    {

      // Issues Open Event begin
      //Show Status of Shown Issues

      string param_status = Utility.GetParam("status_id");
      string param_notstatus = Utility.GetParam("notstatus_id");
      if(param_notstatus == "0")
        param_notstatus = "";
      string issue_look="",issue_view="";
      if (param_notstatus.Length>0)
      {
        issue_look = Utility.Dlookup("statuses","status","status_id=" + param_notstatus);
        issue_view = "Issues that are not " + issue_look;
      }
      if (param_status.Length>0)
      {
        issue_look = Utility.Dlookup("statuses","status","status_id in (" + param_status + ")");
        issue_view = issue_look + " Issues";
      }
      if (param_status=="" && param_notstatus=="")
        issue_view = "All Issues";

      if (sOrder.IndexOf("date_modified")!=-1)
        issue_view = issue_view + "<br><font size=-1>(sorted by Last Update Date, descending)</font>";

      ((Label)Page.FindControl("IssuesForm_Title")).Text=issue_view;
      // Issues Open Event end
    }

    ICollection Issues_CreateDataSource()
    {

      // Issues Show begin
      Issues_sSQL = "";
      Issues_sCountSQL = "";

      string sWhere = "", sOrder = "";

      bool HasParam = false;

      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by date_modified Desc";
      //-------------------------------
      // Build WHERE statement
      //-------------------------------
      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();

      if(!Params.ContainsKey("assigned_by"))
      {
        string temp=Utility.GetParam("assigned_by");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("assigned_by",temp);
      }

      if(!Params.ContainsKey("assigned_to"))
      {
        string temp=Utility.GetParam("assigned_to");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("assigned_to",temp);
      }

      if(!Params.ContainsKey("qaassigned_to"))
      {
        string temp=Utility.GetParam("qaassigned_to");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("qaassigned_to",temp);
      }

	  if(!Params.ContainsKey("category_id"))
	  {
		  string temp=Utility.GetParam("category_id");
		  if (Utility.IsNumeric(null,temp) && temp.Length>0)
		  {
			  temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
		  }
		  else
		  {
			  temp = "";
		  }
		  Params.Add("category_id",temp);
	  }

      if(!Params.ContainsKey("issue_name"))
      {
        string temp=Utility.GetParam("issue_name");
        Params.Add("issue_name",temp);
      }

      if(!Params.ContainsKey("notstatus_id"))
      {
        string temp=Utility.GetParam("notstatus_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("notstatus_id",temp);
      }

      if(!Params.ContainsKey("priority_id"))
      {
        string temp=Utility.GetParam("priority_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("priority_id",temp);
      }

      if(!Params.ContainsKey("status_id"))
      {
        string temp=Utility.GetParam("status_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("status_id",temp);
      }

      if(!Params.ContainsKey("qastatus_id"))
      {
        string temp=Utility.GetParam("qastatus_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("qastatus_id",temp);
      }

      //**************************
      if(!Params.ContainsKey("bug_version_id"))
      {
        string temp=Utility.GetParam("bug_version_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("bug_version_id",temp);
      }
      if(!Params.ContainsKey("release_version_id"))
      {
        string temp=Utility.GetParam("release_version_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("release_version_id",temp);
      }
      if(!Params.ContainsKey("dev_nr"))
      {
        string temp=Utility.GetParam("dev_nr");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("dev_nr",temp);
      }
      //**************************

      if (Params["assigned_by"].Length>0)
      {
        HasParam = true;
        sWhere +="i.[user_id] IN (" + Params["assigned_by"] + ")";
      }
      if (Params["assigned_to"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[assigned_to] IN (" + Params["assigned_to"] + ")";
      }
      if (Params["qaassigned_to"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[qaassigned_to] IN (" + Params["qaassigned_to"] + ")";
      }
		  if (Params["category_id"].Length>0)
		  {
			  if (sWhere.Length >0)
				  sWhere +=" and ";
			  HasParam = true;
  		  sWhere +="i.[category_id] IN (" + Params["category_id"] + ")";
		  }
      if (Params["issue_name"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        
        bool bHasKeys = false;
        string[] Keys = Params["issue_name"].Split(' ');
        foreach (string key in Keys)
        {
          if (key.Equals(" ")==false)
          {
            if (bHasKeys==true)
            {
              sWhere+=" and ";
            }
            sWhere +="(";
            sWhere +="i.[issue_desc] like '%" + key.Replace( "'", "''") +  "%'";
            sWhere += " OR ";
            sWhere +="i.[issue_name] like '%" + key.Replace( "'", "''") +  "%'";
            sWhere += " OR ";
            sWhere +="i.[dev_issue_number] like '%" + key.Replace( "'", "''") +  "%'";
            sWhere += " OR ";
            int iId = 0;
            try
            {
              iId = Convert.ToInt32(key);
            }
            catch(Exception e)
            {
              e.ToString();
              iId=0;
            }
            sWhere +="i.[issue_id] = " + iId.ToString() ;
            sWhere +=")";
            bHasKeys = true;
          }
        }

     
        //      sWhere +="[issue_desc] like '%" + Params["issue_name"].Replace( "'", "''") +  "%'";
      }
      if (Params["notstatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[status_id]<>" + Params["notstatus_id"];
      }
      if (Params["priority_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[priority_id] IN (" + Params["priority_id"] + ")";
      }
      if (Params["status_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[status_id] IN (" + Params["status_id"] + ")";
      }
      if (Params["qastatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
			  sWhere +="i.[qastatus_id] IN (" + Params["qastatus_id"] + ")";
      }

      //**********************************
      if (Params["bug_version_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +=" [bugversion] IN (" + Params["bug_version_id"] + ")";
      }
      if (Params["release_version_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +=" i.[version] IN (" + Params["release_version_id"] + ")";
      }
      if (Params["dev_nr"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        if (Params["dev_nr"].ToString() == "0")
        {
          sWhere +=" i.[dev_issue_number] is null";
        }
        else
        {
          sWhere +=" i.[dev_issue_number] is not null";
        }
      }
      //**********************************

      if(HasParam)
        sWhere = " WHERE (" + sWhere + ")";

      //-------------------------------
      // Build base SQL statement
      //-------------------------------

      Issues_sSQL = "select " +
          "[i].[assigned_to] as i_assigned_to, " +
          "[i].[qaassigned_to] as i_qaassigned_to, " +
          "[i].[date_modified] as i_date_modified, " +
          "[i].[date_submitted] as i_date_submitted, " +
          "[i].[issue_desc] as i_issue_desc, " +
          "[i].[issue_id] as i_issue_id, " +
          "[i].[issue_name] as i_issue_name, " +
          "[i].[dev_issue_number] as i_dev_issue_number, " +
          "[i].[modified_by] as i_modified_by, " +
          "[i].[priority_id] as i_priority_id, " +
          "[i].[status_id] as i_status_id, " +
          "[i].[user_id] as i_user_id, " +
          "[i].[bugversion] as i_bugversion, " +
          "[i].[version] as i_version, " +
          "[i].[steps_to_recreate] as i_steps_to_recreate, " +
          "[s].[status_id] as s_dev_status_id, " +
          "[s].[status] as s_dev_status, " +
          "[qa].[qastatus_id] as qa_qastatus_id, " +
          "[qa].[qastatus] as qa_qastatus, " +
          "[p].[priority_id] as p_priority_id, " +
          "[p].[priority_desc] as p_priority_desc, " +
          "[c].[category_id] as c_category_id, " +
          "[c].[category] as c_category, " +
          "[u1].[user_id] as u1_user_id_submitted_by, " +
          "[u1].[user_name] as u1_user_name_submitted_by, " +
          "[u2].[user_id] as u2_user_id_owner, " +
          "[u2].[user_name] as u2_user_name_owner, " +
          "[u3].[user_id] as u3_user_id_qaowner, " +
          "[u3].[user_name] as u3_user_name_qaowner, " +
          "[u4].[user_id] as u4_user_id_last_updated_by, " +
          "[u4].[user_name] as u4_user_name_last_updated_by, " +
          "[v].[version] as v_version, " +
          "[bv].[version] as bv_version " +
          " from (((((((((([issues] i left join [statuses] s on [s].[status_id]=i.[status_id]) left join [qastatuses] qa on [qa].[qastatus_id]=i.[qastatus_id]) left join [priorities] p on [p].[priority_id]=i.[priority_id]) left join [users] u1 on [u1].[user_id]=i.[user_id]) left join [users] u2 on [u2].[user_id]=i.[assigned_to]) left join [users] u3 on [u3].[user_id]=i.[qaassigned_to]) left join [users] u4 on [u4].[user_id]=i.[modified_by]) left join [versions] v on [v].[version_id]=[i].[version]) left join [versions] bv on [bv].[version_id]=[i].[bugversion]) left join [categories] c on [c].[category_id]=i.[category_id]) ";

      //-------------------------------
      //-------------------------------
      Issues_Open(ref sWhere, ref sOrder);
      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------

      Issues_sSQL = Issues_sSQL + sWhere + sOrder;
      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Issues_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, Issues_PAGENUM, "Issues");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Issues_no_records.Visible = true;
      }
      else
      {
        Issues_no_records.Visible = false;
      }

      return Source;
      // Issues Show end

    }

    void Issues_Bind()
    {
      Issues_Repeater.DataSource = Issues_CreateDataSource();
      Issues_Repeater.DataBind();

    }

  }
}
