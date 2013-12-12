/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: IssueList.cs
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
  ///    Summary description for IssueList.
  /// </summary>
  public class IssueList : System.Web.UI.Page

  {



    //IssueList CustomIncludes begin
    protected CCUtility Utility;

    //Grid form Issues variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Issues_no_records;
    protected string Issues_sSQL;
    protected string Issues_sCountSQL;
    protected int Issues_CountPage;
    protected CCPager Issues_Pager;
    protected System.Web.UI.WebControls.Repeater Issues_Repeater;
    protected int i_Issues_curpage=1;

    //Search form Search variables and controls declarations
    protected System.Web.UI.WebControls.Button Search_search_button;
    protected System.Web.UI.WebControls.TextBox Search_issue_name;
    protected System.Web.UI.WebControls.DropDownList Search_priority_id;
    protected System.Web.UI.WebControls.ListBox Search_status_id;
    protected System.Web.UI.WebControls.ListBox Search_qastatus_id;
    protected System.Web.UI.WebControls.DropDownList Search_assigned_to;

    // For each Issues form hiddens for PK's,List of Values and Actions
    protected string Issues_FormAction=".aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issues_issue_id;
    protected System.Web.UI.WebControls.Label SearchForm_Title;
    protected System.Web.UI.WebControls.Label IssuesForm_Title;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_issue_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_issue_name;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_status_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_dev_issue_number;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_qastatus_id;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_assigned_to;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_date_submitted;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_date_modified;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_date_resolved;
    protected System.Web.UI.HtmlControls.HtmlTable Search_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Issues_holder;
    protected System.Web.UI.WebControls.LinkButton Issues_Column_qaassigned_to;
    // For each Search form hiddens for PK's,List of Values and Actions
    protected string Search_FormAction="IssueList.aspx?";



    public IssueList()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // IssueList CustomIncludes end
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
  // IssueList Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // IssueList Open Event begin
      // IssueList Open Event end
      //===============================

      //===============================
      // IssueList OpenAnyPage Event begin
      // IssueList OpenAnyPage Event end
      //===============================
      //
      //===============================
      // IssueList PageSecurity begin
      Utility.CheckSecurity(3);
      // IssueList PageSecurity end
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
      this.Search_search_button.Click += new System.EventHandler(this.Search_search_Click);
      this.Issues_Repeater.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.Issues_Repeater_ItemCommand);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      Issues_Bind();
      Search_Show();

    }



    // IssueList Show end

    // End of Login form








    const int Issues_PAGENUM = 20;




    public void Issues_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Issues Show Event begin
      // Issues Show Event end
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


      if(!Params.ContainsKey("assigned_to"))
      {
        string temp=Utility.GetParam("assigned_to");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
        }
        else
        {
          temp = "";
        }
        Params.Add("assigned_to",temp);
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
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
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
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
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
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
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
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
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
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
        }
        else
        {
          temp = "";
        }
        Params.Add("qastatus_id",temp);
      }

      if (Params["assigned_to"].Length>0)
      {
        HasParam = true;
        sWhere +="i.[assigned_to]=" + Params["assigned_to"];
      }
      if (Params["issue_name"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[issue_name] like '%" + Params["issue_name"].Replace( "'", "''") +  "%'";
      }
      if (Params["notstatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[status_id]<>" + Params["notstatus_id"];
      }
      if (Params["notqastatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[qastatus_id]<>" + Params["notqastatus_id"];
      }
      if (Params["priority_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[priority_id]=" + Params["priority_id"];
      }
      if (Params["status_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[status_id]=" + Params["status_id"];
      }
      if (Params["qastatus_id"].Length>0)
      {
        if (sWhere.Length >0)
          sWhere +=" and ";
        HasParam = true;
        sWhere +="i.[qastatus_id]=" + Params["qastatus_id"];
      }


      if(HasParam)
        sWhere = " WHERE (" + sWhere + ")";

      //-------------------------------
      // Build base SQL statement
      //-------------------------------


      Issues_sSQL = "select [i].[assigned_to] as i_assigned_to, " +
                    "[i].[date_modified] as i_date_modified, " +
                    "[i].[date_resolved] as i_date_resolved, " +
                    "[i].[date_submitted] as i_date_submitted, " +
                    "[i].[issue_id] as i_issue_id, " +
                    "[i].[issue_name] as i_issue_name, " +
                    "[i].[dev_issue_number] as i_dev_issue_number, " +
                    "[i].[priority_id] as i_priority_id, " +
                    "[i].[status_id] as i_status_id, " +
                    "[s].[status_id] as s_status_id, " +
                    "[s].[status] as s_status, " +
                    "[i].[qastatus_id] as i_qastatus_id, " +
                    "[qs].[qastatus_id] as qs_qastatus_id, " +
                    "[qs].[qastatus] as qs_qastatus, " +
                    "[u].[user_id] as u_user_id, " +
                    "[u].[user_name] as u_user_name " +
                    " from ((([issues] i left join [statuses] s on [s].[status_id]=i.[status_id]) left join [qastatuses] qs on [qs].[qastatus_id]=i.[qastatus_id]) inner join [users] u on [u].[user_id]=i.[assigned_to]) ";

      //-------------------------------
      //-------------------------------

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


    // End of Login form


    void Search_Show()
    {

      // Search Open Event begin
      // Search Open Event end

      // Search Show begin
      Utility.buildListBox(Search_priority_id.Items,"select priority_id,priority_desc from priorities order by 2","priority_id","priority_desc","All","");
      Utility.buildListBox(Search_status_id.Items,"select status_id,status from statuses order by 2","status_id","status","All","");
      Utility.buildListBox(Search_qastatus_id.Items,"select qastatus_id,qastatus from qastatuses order by 2","qastatus_id","qastatus","All","");
      Utility.buildListBox(Search_assigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name","Anyone","");


      string s;

      s=Utility.GetParam("issue_name");
      Search_issue_name.Text = s;

      s=Utility.GetParam("priority_id");

      try
      {
        Search_priority_id.SelectedIndex=Search_priority_id.Items.IndexOf(Search_priority_id.Items.FindByValue(s));
      }
      catch{}

      s=Utility.GetParam("status_id")
          ;

      Utility.SetListBoxItems(Search_status_id, s);

      s=Utility.GetParam("qastatus_id");

      Utility.SetListBoxItems(Search_qastatus_id, s);

      s=Utility.GetParam("assigned_to");

      try
      {
        Search_assigned_to.SelectedIndex=Search_assigned_to.Items.IndexOf(Search_assigned_to.Items.FindByValue(s));
      }
      catch{}

      // Search Show Event begin
      // Search Show Event end

      // Search Show end

      // Search Close Event begin
      // Search Close Event end
    }

  void Search_search_Click(Object Src, EventArgs E)
    {
      string sURL = Search_FormAction + "issue_name="+Search_issue_name.Text+"&"
                    + "priority_id="+Search_priority_id.SelectedItem.Value+"&"
                    + "status_id="+Search_status_id.SelectedItem.Value+"&"
                    + "qastatus_id="+Search_qastatus_id.SelectedItem.Value+"&"
                    + "assigned_to="+Search_assigned_to.SelectedItem.Value+"&"
                    ;
      // Transit
      sURL += "";
      Response.Redirect(sURL);
    }

    private void Issues_Repeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
    
    }

  }
}
