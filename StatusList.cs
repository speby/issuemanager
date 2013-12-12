/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: StatusList.cs
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
  ///    Summary description for StatusList.
  /// </summary>
  public class StatusList : System.Web.UI.Page

  {



    //StatusList CustomIncludes begin
    protected CCUtility Utility;

    //Grid form StatusList variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow StatusList_no_records;
    protected string StatusList_sSQL;
    protected string StatusList_sCountSQL;
    protected int StatusList_CountPage;
    protected CCPager StatusList_Pager;
    protected System.Web.UI.WebControls.LinkButton StatusList_insert;
    protected System.Web.UI.WebControls.Repeater StatusList_Repeater;
    protected int i_StatusList_curpage=1;

    // For each StatusList form hiddens for PK's,List of Values and Actions
    protected string StatusList_FormAction="StatusMaint.aspx?";
    protected System.Web.UI.WebControls.Label StatusListForm_Title;
    protected System.Web.UI.WebControls.LinkButton StatusList_Column_status;
    protected System.Web.UI.HtmlControls.HtmlTable StatusList_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_StatusList_status_id;


    public StatusList()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // StatusList CustomIncludes end
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
  // StatusList Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // StatusList Open Event begin
      // StatusList Open Event end
      //===============================

      //===============================
      // StatusList OpenAnyPage Event begin
      // StatusList OpenAnyPage Event end
      //===============================
      //
      //===============================
      // StatusList PageSecurity begin
      Utility.CheckSecurity(2);
      // StatusList PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_StatusList_status_id.Value = Utility.GetParam("status_id");
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
      this.StatusList_insert.Click += new System.EventHandler(this.StatusList_insert_Click);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      StatusList_Bind();

    }



    // StatusList Show end

    // End of Login form








    const int StatusList_PAGENUM = 20;




    public void StatusList_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // StatusList Show Event begin
      // StatusList Show Event end
    }


    ICollection StatusList_CreateDataSource()
    {


      // StatusList Show begin
      StatusList_sSQL = "";
      StatusList_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool HasParam = false;


      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by s.status_id Asc";
      if(Utility.GetParam("FormStatusList_Sorting").Length>0&&!IsPostBack)
      {
        ViewState["SortColumn"]=Utility.GetParam("FormStatusList_Sorting");
        ViewState["SortDir"]="ASC";
      }
      if(ViewState["SortColumn"]!=null)
        sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();

      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();





      //-------------------------------
      // Build base SQL statement
      //-------------------------------


      StatusList_sSQL = "select [s].[status] as s_status, " +
                        "[s].[status_id] as s_status_id " +
                        " from [statuses] s ";

      //-------------------------------
      //-------------------------------

      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------



      StatusList_sSQL = StatusList_sSQL + sWhere + sOrder;
      if (StatusList_sCountSQL.Length== 0)
      {
        int iTmpI = StatusList_sSQL.ToLower().IndexOf("select ");
        int iTmpJ = StatusList_sSQL.ToLower().LastIndexOf(" from ")-1;
        StatusList_sCountSQL = StatusList_sSQL.Replace(StatusList_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
        iTmpI = StatusList_sCountSQL.ToLower().IndexOf(" order by");
        if (iTmpI > 1)
          StatusList_sCountSQL = StatusList_sCountSQL.Substring(0, iTmpI);
      }


      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(StatusList_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, (i_StatusList_curpage - 1) * StatusList_PAGENUM, StatusList_PAGENUM,"StatusList");
      OleDbCommand ccommand = new OleDbCommand(StatusList_sCountSQL, Utility.Connection);
      int PageTemp=(int)ccommand.ExecuteScalar();
      StatusList_Pager.MaxPage=(PageTemp%StatusList_PAGENUM)>0?(int)(PageTemp/StatusList_PAGENUM)+1:(int)(PageTemp/StatusList_PAGENUM);
      bool AllowScroller=StatusList_Pager.MaxPage==1?false:true;

      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        StatusList_no_records.Visible = true;
        AllowScroller=false;
      }
      else
      {
        StatusList_no_records.Visible = false;
        AllowScroller=AllowScroller&&true;
      }

      StatusList_Pager.Visible=AllowScroller;
      return Source;
      // StatusList Show end

    }


    protected void StatusList_pager_navigate_completed(Object Src, int CurrPage)
    {
      i_StatusList_curpage=CurrPage;

      // StatusList CustomNavigation Event begin
      // StatusList CustomNavigation Event end
      StatusList_Bind();
    }


    void StatusList_Bind()
    {
      StatusList_Repeater.DataSource = StatusList_CreateDataSource();
      StatusList_Repeater.DataBind();

    }

    void StatusList_insert_Click(Object Src, EventArgs E)
    {
      string sURL = StatusList_FormAction+"";
      Response.Redirect(sURL);
    }

    protected void StatusList_SortChange(Object Src, EventArgs E)
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
      StatusList_Bind();
    }



  }
}
