/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: Default.cs
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
  using System.Text.RegularExpressions;
  using System.Web;
  using System.Web.SessionState;
  using System.Web.UI;
  using System.Web.UI.WebControls;
  using System.Web.UI.HtmlControls;

  /// <summary>
  ///    Summary description for Default.
  /// </summary>
  public class Default : System.Web.UI.Page

  {

    //Default CustomIncludes begin
    protected CCUtility Utility;
    //Search form Search variables and controls declarations
    protected System.Web.UI.WebControls.Button Search_search_button;
    protected System.Web.UI.WebControls.TextBox Search_issue_name;
    protected System.Web.UI.WebControls.ListBox Search_priority_id;
    protected System.Web.UI.WebControls.ListBox Search_assigned_to;
    protected System.Web.UI.WebControls.ListBox Search_qaassigned_to;
    protected System.Web.UI.WebControls.ListBox Search_bug_version_id;
    protected System.Web.UI.WebControls.ListBox Search_release_version_id;

    //Grid form Summary variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Summary_no_records;
    protected string Summary_sSQL;
    protected string Summary_sCountSQL;
    protected int Summary_CountPage;

    protected System.Web.UI.WebControls.Repeater Summary_Repeater;
    protected int i_Summary_curpage=1;
    protected int i_Summary1_curpage=1;

    //Grid form Issues variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Issues_no_records;
    protected string Issues_sSQL;
    protected string Issues_sCountSQL;
    protected int Issues_CountPage;
    protected CCPager Issues_Pager;
    protected System.Web.UI.WebControls.LinkButton Issues_insert;
    protected System.Web.UI.WebControls.Repeater Issues_Repeater;
    protected int i_Issues_curpage=1;

    // For each Search form hiddens for PK's,List of Values and Actions
    protected string Search_FormAction="Default.aspx?";

    // For each Summary form hiddens for PK's,List of Values and Actions
    protected string Summary_FormAction=".aspx?";

    // For each Bokmarks form hiddens for PK's,List of Values and Actions
    protected string Bokmarks_FormAction=".aspx?";

    // For each Issues form hiddens for PK's,List of Values and Actions
    protected string Issues_FormAction="IssueNew.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issues_issue_id;
    protected System.Web.UI.WebControls.Label SearchForm_Title;
    protected System.Web.UI.WebControls.Label BokmarksForm_Title;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_all;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_pending;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_pending_prior;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_assigned_by;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_assigned_to;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_qaassigned_to;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_Dev_Nr_Assigned;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_No_Dev_Nr_Assigned;
    protected System.Web.UI.WebControls.Label Summary_Column_status;
    protected System.Web.UI.WebControls.Label Summary_Column_qastatus;
    protected System.Web.UI.WebControls.Label Summary_Column_issue_id;
    protected System.Web.UI.WebControls.Label IssuesForm_Title;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_issue_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_issue_name;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_status_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_dev_issue_nr;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_qastatus_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_category_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_priority_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_assigned_to;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_qaassigned_to;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_date_submitted;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_date_modified;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_bugversion;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_version;
    protected System.Web.UI.HtmlControls.HtmlTable Search_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Bokmarks_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Summary_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Issues_holder;
    protected System.Web.UI.WebControls.ListBox Search_status_id;
    protected System.Web.UI.WebControls.ListBox Search_qastatus_id;
    protected System.Web.UI.WebControls.Label Summary1_Column_status;
    protected System.Web.UI.WebControls.Repeater Summary1_Repeater;
    protected System.Web.UI.HtmlControls.HtmlTable Summary1_holder;
    protected System.Web.UI.WebControls.Label Summary1_Column_issue_id;
    protected System.Web.UI.HtmlControls.HtmlTableRow Summary1_no_records;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_dev_issue_number;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_user_id;
    protected System.Web.UI.WebControls.HyperLink Bokmarks_supervised;
    protected System.Web.UI.WebControls.ListBox Search_category_id;

    public Default()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // Default CustomIncludes end
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
    // Default Show begin
    protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // Default Open Event begin
      // Default Open Event end
      //===============================

      //===============================
      // Default OpenAnyPage Event begin
      // Default OpenAnyPage Event end
      //===============================
      //
      //===============================
      // Default PageSecurity begin
      Utility.CheckSecurity(1);
      // Default PageSecurity end
      //===============================
      
      if (!IsPostBack)
      {

        p_Issues_issue_id.Value = Utility.GetParam("issue_id");
        Page_Show(sender, e);
      }
      
      // When user clicks "Enter" key it performs the Search Functionality
      Page.RegisterHiddenField("__EVENTTARGET", "Search_search_button");
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
      Issues_Pager.NavigateCompleted+=new NavigateCompletedHandler(this.Issues_pager_navigate_completed);
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Search_search_button.Click += new System.EventHandler(this.Search_search_Click);
      this.Issues_Column_version.Click += new System.EventHandler(this.Issues_Column_version_Click);
      this.Issues_insert.Click += new System.EventHandler(this.Issues_insert_Click);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }

    protected void Page_Show(object sender, EventArgs e)
    {
      Search_Show();
      Summary_Bind();
      Summary1_Bind();
      Bokmarks_Show();
      Issues_Bind();

    }

    // Default Show end

    // End of Login form

    void Search_Show()
    {

      // Search Open Event begin
      // Search Open Event end

      // Search Show begin
      Utility.buildListBox(Search_priority_id.Items,"select priority_id,priority_desc from priorities order by 2","priority_id","priority_desc","All","");
      Utility.buildListBox(Search_status_id.Items,"select status_id,status from statuses order by 2","status_id","status","All","");
      Utility.buildListBox(Search_qastatus_id.Items,"select qastatus_id,qastatus from qastatuses order by 2","qastatus_id","qastatus","All","");
      Utility.buildListBox(Search_category_id.Items,"select category_id,category from categories order by 2","category_id","category","All","");
      Utility.buildListBox(Search_assigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name","All","");
      Utility.buildListBox(Search_qaassigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name","All","");
      Utility.buildListBox(Search_bug_version_id.Items,"select version_id,version from versions order by 2","version_id","version","All","");
      Utility.buildListBox(Search_release_version_id.Items,"select version_id,version from versions order by 2","version_id","version","All","");

      string s;

      s=Utility.GetParam("issue_name");
      Search_issue_name.Text = s;

      s=Utility.GetParam("priority_id");

      Utility.SetListBoxItems(Search_priority_id, s);

      s=Utility.GetParam("status_id");

      Utility.SetListBoxItems(Search_status_id, s);

      s=Utility.GetParam("qastatus_id");

      Utility.SetListBoxItems(Search_qastatus_id, s);

      s=Utility.GetParam("category_id");

      Utility.SetListBoxItems(Search_category_id, s);

      s=Utility.GetParam("assigned_to");

      Utility.SetListBoxItems(Search_assigned_to, s);

      s=Utility.GetParam("qaassigned_to");

      Utility.SetListBoxItems(Search_qaassigned_to, s);

      s=Utility.GetParam("bug_version_id");

      Utility.SetListBoxItems(Search_bug_version_id, s);

      s=Utility.GetParam("release_version_id");

      Utility.SetListBoxItems(Search_release_version_id, s);

      // Search Show Event begin
      // Search Show Event end

      // Search Show end

      // Search Close Event begin
      // Search Close Event end
    }

  void Search_search_Click(Object Src, EventArgs E)
    {
      string sURL = Search_FormAction + "search_click=1&"
                    + "issue_name="+Search_issue_name.Text+"&"
                    + "priority_id="+Utility.GetListBoxItems(Search_priority_id)+"&"
                    + "status_id="+Utility.GetListBoxItems(Search_status_id)+"&"
                    + "qastatus_id="+Utility.GetListBoxItems(Search_qastatus_id)+"&"
                    + "category_id="+Utility.GetListBoxItems(Search_category_id)+"&"
                    + "assigned_to="+Utility.GetListBoxItems(Search_assigned_to)+"&"
                    + "qaassigned_to="+Utility.GetListBoxItems(Search_qaassigned_to)+"&"
                    + "bug_version_id="+Utility.GetListBoxItems(Search_bug_version_id)+"&"
                    + "release_version_id="+Utility.GetListBoxItems(Search_release_version_id)+"&"
                    + "version_id=&"
                    //+ "version_id="+Utility.GetListBoxItems(Search_version_id)+"&"
                    ;
      // Transit
      sURL += "";
      Response.Redirect(sURL);
    }

    // End of Login form

    const int Summary_PAGENUM = 0;
    const int Summary1_PAGENUM = 0;
    public void Summary_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Summary Show Event begin
      // Summary Show Event end
    }
    public void Summary1_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Summary Show Event begin
      // Summary Show Event end
    }
    public void Summary_Open(ref string sWhere, ref string sOrder)
    {

      // Summary Open Event begin
      sWhere = sWhere.Replace("[sstatus_id]","s.status_id");
      sWhere = sWhere.Replace("[sqastatus_id]","qs.qastatus_id");
      // Summary Open Event end
    }
    public void Summary1_Open(ref string sWhere, ref string sOrder)
    {

      // Summary Open Event begin
      sWhere = sWhere.Replace("[sstatus_id]","s.status_id");
      sWhere = sWhere.Replace("[sqastatus_id]","qs.qastatus_id");
      // Summary Open Event end
    }
    ICollection Summary_CreateDataSource()
    {

      // Summary Show begin
      Summary_sSQL = "";
      Summary_sCountSQL = "";

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

      if(!Params.ContainsKey("issue_name"))
      {
        string temp=Utility.GetParam("issue_name");
        Params.Add("issue_name",temp);
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
        sWhere +="[user_id] IN (" + Params["assigned_by"] + ")";
      }
      if (Params["assigned_to"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[assigned_to] IN (" + Params["assigned_to"] + ")";
      }
      if (Params["qaassigned_to"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[qaassigned_to] IN (" + Params["qaassigned_to"] + ")";
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
      if (Params["priority_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[priority_id] IN (" + Params["priority_id"] + ")";
      }
      if (Params["status_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[sstatus_id] IN (" + Params["status_id"] + ")";
      }
      if (Params["category_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[category_id] IN (" + Params["category_id"] + ")";
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
      //**********************************

      if(HasParam)
        sWhere = " AND (" + sWhere + ")";

      //-------------------------------
      // Build base SQL statement
      //-------------------------------

      Summary_sSQL = "SELECT s.status_id, s.status, Count(i.issue_id) AS issue_id FROM statuses s, issues i WHERE s.status_id = i.status_id";
      sOrder = " GROUP BY s.status_id, s.status;";

      //-------------------------------
      //-------------------------------
      Summary_Open(ref sWhere, ref sOrder);
      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------

      Summary_sSQL = Summary_sSQL + sWhere + sOrder;
      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Summary_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, Summary_PAGENUM, "Summary");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Summary_no_records.Visible = true;
      }
      else
      {
        Summary_no_records.Visible = false;
      }

      return Source;
      // Summary Show end

    }

    ICollection Summary1_CreateDataSource()
    {

      // Summary Show begin
      Summary_sSQL = "";
      Summary_sCountSQL = "";

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

      if(!Params.ContainsKey("issue_name"))
      {
        string temp=Utility.GetParam("issue_name");
        Params.Add("issue_name",temp);
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

      //***************************
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
      //***************************

      if (Params["assigned_by"].Length>0)
      {
        HasParam = true;
        sWhere +="[user_id] IN (" + Params["assigned_by"] + ")";
      }
      if (Params["assigned_to"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[assigned_to] IN (" + Params["assigned_to"] + ")";
      }
      if (Params["qaassigned_to"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[qaassigned_to] IN (" + Params["qaassigned_to"] + ")";
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
      if (Params["priority_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[priority_id] IN (" + Params["priority_id"] + ")";
      }
      if (Params["qastatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[sqastatus_id] IN (" + Params["qastatus_id"] + ")";
      }
      if (Params["category_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="[category_id] IN (" + Params["category_id"] + ")";
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
      //**********************************

      if(HasParam)
        sWhere = " AND (" + sWhere + ")";

      //-------------------------------
      // Build base SQL statement
      //-------------------------------

      Summary_sSQL = "SELECT qs.qastatus_id, qs.qastatus, Count(i.issue_id) AS issue_id FROM qastatuses qs, issues i WHERE qs.qastatus_id = i.qastatus_id";
      sOrder = " GROUP BY qs.qastatus_id, qs.qastatus;";

      //-------------------------------
      //-------------------------------
      Summary1_Open(ref sWhere, ref sOrder);
      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------

      Summary_sSQL = Summary_sSQL + sWhere + sOrder;
      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Summary_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, Summary1_PAGENUM, "Summary1");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Summary1_no_records.Visible = true;
      }
      else
      {
        Summary1_no_records.Visible = false;
      }

      return Source;
      // Summary Show end

    }

    void Summary_Bind()
    {
      Summary_Repeater.DataSource = Summary_CreateDataSource();
      Summary_Repeater.DataBind();

    }

    void Summary1_Bind()
    {
      Summary1_Repeater.DataSource = Summary1_CreateDataSource();
      Summary1_Repeater.DataBind();

    }
    // End of Login form

    protected void Bokmarks_Show()
    {

      // Bokmarks Open Event begin
      // Bokmarks Open Event end

      // Bokmarks Show begin

      // Bokmarks BeforeShow Event begin
      string closedstatus = Utility.Dlookup("statuses","status_id","status LIKE '%close%'");
      ((HyperLink)Page.FindControl("Bokmarks_all")).NavigateUrl += "?notstatus_id=0";
      ((HyperLink)Page.FindControl("Bokmarks_pending")).NavigateUrl += "?notstatus_id=" + closedstatus;
      ((HyperLink)Page.FindControl("Bokmarks_pending_prior")).NavigateUrl += "?notstatus_id=" + closedstatus + "&FormIssues_Sorting=p.[priority_order]";
      ((HyperLink)Page.FindControl("Bokmarks_assigned_by")).NavigateUrl += "?assigned_by=" + Session["UserID"].ToString();
      ((HyperLink)Page.FindControl("Bokmarks_assigned_to")).NavigateUrl += "?assigned_to=" + Session["UserID"].ToString();
      ((HyperLink)Page.FindControl("Bokmarks_qaassigned_to")).NavigateUrl += "?qaassigned_to=" + Session["UserID"].ToString();
      ((HyperLink)Page.FindControl("Bokmarks_Dev_Nr_Assigned")).NavigateUrl +=  "?dev_nr=1";
      ((HyperLink)Page.FindControl("Bokmarks_No_Dev_Nr_Assigned")).NavigateUrl +=  "?dev_nr=0";

      
      if (Session["UserID"].ToString() == Session["Supervisor"].ToString())
      {
        ((HyperLink)Page.FindControl("Bokmarks_supervised")).NavigateUrl += "?supervisor_id=" + Session["UserID"].ToString();
      }
      else
      {
        Page.FindControl("Bokmarks_supervised").Visible = false;
      }
      // Bokmarks BeforeShow Event end

      // Bokmarks Show end

    }

    // End of Login form

    const int Issues_PAGENUM = 15;

    public void Issues_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Issues Show Event begin
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        //Process Assigned To

        if(((DataRowView)e.Item.DataItem )["i_assigned_to"].ToString() == Session["UserID"].ToString())
          ((Label)e.Item.FindControl("Issues_assigned_to")).Text = "<font color=\"red\">" + ((DataRowView)e.Item.DataItem )["u2_user_name_owner"].ToString()+ "</font>";

        if(((DataRowView)e.Item.DataItem )["i_qaassigned_to"].ToString() == Session["UserID"].ToString())
          ((Label)e.Item.FindControl("Issues_qaassigned_to")).Text = "<font color=\"red\">" + ((DataRowView)e.Item.DataItem )["u3_user_name_qaowner"].ToString()+ "</font>";

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
      if(param_status == "0")
        param_status = "";
      if(param_notstatus == "0")
        param_notstatus = "";
      if (param_status == "" && param_notstatus == "")
        param_notstatus = "3";  // Default case: hide closed items
      string param_qastatus = Utility.GetParam("qastatus_id");
      string param_notqastatus = Utility.GetParam("notqastatus_id");
      if(param_qastatus == "0")
        param_qastatus = "";
      if(param_notqastatus == "0")
        param_notqastatus = "";
      if (param_qastatus == "" && param_notqastatus == "")
        param_notqastatus = "3";  // Default case: hide closed items

      string issue_look="",issue_view="";
      if (param_notstatus.Length>0)
      {
        issue_look = Utility.Dlookup("statuses","status","status_id NOT IN (" + param_notstatus + ")");
        issue_view = "Issues that are not " + issue_look;
      }
      if (param_status.Length>0)
      {
        issue_look = Utility.Dlookup("statuses","status","status_id IN (" + param_status +")");
        issue_view = issue_look + " Issues";
      }
      if (param_status=="" && param_notstatus=="")
        issue_view = "All Issues";

      if (param_notqastatus.Length>0)
      {
        issue_look = Utility.Dlookup("qastatuses","qastatus","qastatus_id NOT IN (" + param_notqastatus + ")");
        issue_view = "Issues that are not " + issue_look;
      }
      if (param_qastatus.Length>0)
      {
        issue_look = Utility.Dlookup("qastatuses","qastatus","qastatus_id IN (" + param_qastatus +")");
        issue_view = issue_look + " Issues";
      }
      if (param_qastatus=="" && param_notqastatus=="")
        issue_view = "All Issues";

      if (sOrder.IndexOf("date_modified")!=-1)
        issue_view = issue_view + "<br><font size=-1>(sorted by Last Update Date, descending)</font>";

      ((Label)Page.FindControl("IssuesForm_Title")).Text=issue_view;
      ViewState["Issues_ExportAction"]="IssueExport.aspx";
      ViewState["Issues_TransitParams"]=
        "assigned_by=" + Server.UrlEncode(Utility.GetParam("assigned_by")) +
        "&assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) +
        "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) +
        "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) +
        "&notstatus_id=" + Server.UrlEncode(Utility.GetParam("notstatus_id")) +
        "&notqastatus_id=" + Server.UrlEncode(Utility.GetParam("notqastatus_id")) +
        "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) +
        "&status_id=" + Server.UrlEncode(Utility.GetParam("status_id")) +
        "&qastatus_id=" + Server.UrlEncode(Utility.GetParam("qastatus_id")) +
        "&category_id=" + Server.UrlEncode(Utility.GetParam("category_id")) +
        "&bug_version_id=" + Server.UrlEncode(Utility.GetParam("bug_version_id")) +
        "&release_version_id=" + Server.UrlEncode(Utility.GetParam("release_version_id")) +
        "&dev_nr=" + Server.UrlEncode(Utility.GetParam("dev_nr")) +
        "&version_id=" + Server.UrlEncode(Utility.GetParam("version_id")) +
        "&";
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
      sOrder = " order by i.date_modified Desc";
      if(Utility.GetParam("FormIssues_Sorting").Length>0&&!IsPostBack)
      {
        ViewState["SortColumn"]=Utility.GetParam("FormIssues_Sorting");
        ViewState["SortDir"]="ASC";
      }
      if(ViewState["SortColumn"]!=null)
        sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();

      //-------------------------------
      // Build WHERE statement
      //-------------------------------
      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();

      if(!Params.ContainsKey("search_click"))
      {
        string temp=Utility.GetParam("search_click");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("search_click",temp);
      }

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

      if(!Params.ContainsKey("notqastatus_id"))
      {
        string temp=Utility.GetParam("notqastatus_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("notqastatus_id",temp);
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

      if(!Params.ContainsKey("supervisor_id"))
      {
        string temp=Utility.GetParam("supervisor_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number, true);
        }
        else
        {
          temp = "";
        }
        Params.Add("supervisor_id",temp);
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
        sWhere +="i.[qaassigned_to] IN (" + Params["qaassigned_to"] + ")";
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
          }
          bHasKeys = true;
        }
        
      }
      if (Params["notstatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[status_id] NOT IN (" + Params["notstatus_id"] + ")";
      }
      if (Params["notqastatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[qastatus_id] NOT IN (" + Params["notqastatus_id"] + ")";
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
      if (Params["category_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[category_id] IN (" + Params["category_id"] + ")";
      }
      if (Params["supervisor_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="u.[supervisor_id] IN (" + Params["supervisor_id"] + ")";
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
      {
        sWhere = " WHERE (" + sWhere + ")";
      } else if (Params["search_click"].Length == 0) {
        sWhere = " WHERE s.status_id<>3";
      }

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
          "[s].[status_id] as s_dev_status_id, " +
          "[s].[status] as s_dev_status, " +
          "[qs].[qastatus_id] as qa_qastatus_id, " +
          "[qs].[qastatus] as qa_qastatus, " +
          "[p].[priority_id] as p_priority_id, " +
          "[p].[priority_desc] as p_priority_desc, " +
          "[c].[category_id] as c_category_id, " +
          "[c].[category] as c_category, " +
          "[u1].[user_id] as u_user_id_submitted_by, " +
          "[u1].[user_name] as u_user_name_submitted_by, " +
          "[u2].[user_id] as u2_user_id_owner, " +
          "[u2].[user_name] as u2_user_name_owner, " +
          "[u3].[user_id] as u3_user_id_qaowner, " +
          "[u3].[user_name] as u3_user_name_qaowner, " +
          "[u4].[user_id] as u4_user_id_last_updated_by, " +
          "[u4].[user_name] as u4_user_name_last_updated_by, " +
          "[v].[version] as v_version, " +
          "[bv].[version] as bv_version " +
          " from (((((((((([issues] i left join [statuses] s on [s].[status_id]=i.[status_id]) left join [qastatuses] qs on [qs].[qastatus_id]=i.[qastatus_id]) left join [priorities] p on [p].[priority_id]=i.[priority_id]) left join [users] u1 on [u1].[user_id]=i.[user_id]) left join [users] u2 on [u2].[user_id]=i.[assigned_to]) left join [users] u3 on [u3].[user_id]=i.[qaassigned_to]) left join [users] u4 on [u4].[user_id]=i.[modified_by]) left join [versions] v on [v].[version_id]=[i].[version]) left join [versions] bv on [bv].[version_id]=[i].[bugversion]) left join [categories] c on [c].[category_id]=i.[category_id]) ";
                    //" from (((((((([issues] i left join [statuses] s on [s].[status_id]=i.[status_id]) left join [qastatuses] qs on [qs].[qastatus_id]=i.[qastatus_id]) left join [categories] c on [c].[category_id]=i.[category_id]) left join [priorities] p on [p].[priority_id]=i.[priority_id]) left join [users] u on [u].[user_id]=i.[assigned_to]) left join [users] u1 on [u1].[user_id]=i.[qaassigned_to]) left join [versions] bv on [bv].[version_id]=[i].[bugversion]) left join [fversions] v on [v].[version_id]=[i].[version])";

      //-------------------------------
      //-------------------------------
      Issues_Open(ref sWhere, ref sOrder);
      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------

      Issues_sSQL = Issues_sSQL + sWhere + sOrder;
      if (Issues_sCountSQL.Length== 0)
      {
        int iTmpI = Issues_sSQL.ToLower().IndexOf("select ");
        int iTmpJ = Issues_sSQL.ToLower().LastIndexOf(" from ")-1;
        Issues_sCountSQL = Issues_sSQL.Replace(Issues_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
        iTmpI = Issues_sCountSQL.ToLower().IndexOf(" order by");
        if (iTmpI > 1)
          Issues_sCountSQL = Issues_sCountSQL.Substring(0, iTmpI);
      }

      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Issues_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, (i_Issues_curpage - 1) * Issues_PAGENUM, Issues_PAGENUM,"Issues");
      OleDbCommand ccommand = new OleDbCommand(Issues_sCountSQL, Utility.Connection);
      int PageTemp=(int)ccommand.ExecuteScalar();
      Issues_Pager.MaxPage=(PageTemp%Issues_PAGENUM)>0?(int)(PageTemp/Issues_PAGENUM)+1:(int)(PageTemp/Issues_PAGENUM);
      bool AllowScroller=Issues_Pager.MaxPage==1?false:true;

      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Issues_no_records.Visible = true;
        AllowScroller=false;
      }
      else
      {
        Issues_no_records.Visible = false;
        AllowScroller=AllowScroller&&true;
      }

      Issues_Pager.Visible=AllowScroller;
      return Source;
      // Issues Show end

    }

    protected void Issues_pager_navigate_completed(Object Src, int CurrPage)
    {
      i_Issues_curpage=CurrPage;

      // Issues CustomNavigation Event begin
      // Issues CustomNavigation Event end
      Issues_Bind();
    }

    void Issues_Bind()
    {
      Issues_Repeater.DataSource = Issues_CreateDataSource();
      Issues_Repeater.DataBind();

    }

    void Issues_insert_Click(Object Src, EventArgs E)
    {
      string sURL = Issues_FormAction+"assigned_by=" + Server.UrlEncode(Utility.GetParam("assigned_by")) + "&assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) + "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) + "&notstatus_id=" + Server.UrlEncode(Utility.GetParam("notstatus_id")) + "&notqastatus_id=" + Server.UrlEncode(Utility.GetParam("notqastatus_id")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&status_id=" + Server.UrlEncode(Utility.GetParam("status_id")) + "&qastatus_id=" + Server.UrlEncode(Utility.GetParam("qastatus_id")) + "&category_id=" + Server.UrlEncode(Utility.GetParam("category_id")) + "&bug_version_id=" + Server.UrlEncode(Utility.GetParam("bug_version_id")) + "&release_version_id=" + Server.UrlEncode(Utility.GetParam("release_version_id")) + "&version_id=" + Server.UrlEncode(Utility.GetParam("version_id")) + "&";
      Response.Redirect(sURL);
    }

    protected void Issues_SortChange(Object Src, EventArgs E)
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
      Issues_Bind();
    }

    private void Issues_Column_version_Click(object sender, System.EventArgs e)
    {
    
    }
  }
}
