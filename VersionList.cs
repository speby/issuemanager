/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: VersionList.cs
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
  ///    Summary description for VersionList.
  /// </summary>
  public class VersionList : System.Web.UI.Page

  {



    //VersionList CustomIncludes begin
    protected CCUtility Utility;

    //Grid form VersionList variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow VersionList_no_records;
    protected string VersionList_sSQL;
    protected string VersionList_sCountSQL;
    protected int VersionList_CountPage;
    protected int i_VersionList_curpage=2;
    protected CCPager VersionList_Pager;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_VersionList_version_id;

    // For each VersionList form hiddens for PK's,List of Values and Actions
    protected string VersionList_FormAction="VersionMaint.aspx?";

    protected System.Web.UI.WebControls.Label VersionListForm_Title;
    protected System.Web.UI.WebControls.LinkButton VersionList_Column_version;
    protected System.Web.UI.WebControls.LinkButton VersionList_insert;
    protected System.Web.UI.HtmlControls.HtmlTable VersionList_holder;
    protected System.Web.UI.WebControls.Repeater VersionList_Repeater;


    public VersionList()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // VersionList CustomIncludes end
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
  // VersionList Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // VersionList Open Event begin
      // VersionList Open Event end
      //===============================

      //===============================
      // VersionList OpenAnyPage Event begin
      // VersionList OpenAnyPage Event end
      //===============================
      //
      //===============================
      // VersionList PageSecurity begin
      Utility.CheckSecurity(2);
      // VersionList PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_VersionList_version_id.Value = Utility.GetParam("version_id");
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
      VersionList_Pager.NavigateCompleted += new NavigateCompletedHandler(this.VersionList_pager_navigate_completed);
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.VersionList_Repeater.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.VersionList_Repeater_ItemCommand);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);
    }


    protected void Page_Show(object sender, EventArgs e)
    {
      VersionList_Bind();

    }



    // VersionList Show end

    // End of Login form


    const int VersionList_PAGENUM = 1;




    public void VersionList_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // VersionList Show Event begin
      // VersionList Show Event end
    }


    ICollection VersionList_CreateDataSource()
    {

      // VersionList Show begin
      VersionList_sSQL = "";
      VersionList_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool HasParam = false;


      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by v.version Asc";
     // if(Utility.GetParam("FormVersionList_Sorting").Length>0&&!IsPostBack)
     // {
     //   ViewState["SortColumn"]=Utility.GetParam("FormVersionList_Sorting");
     //   ViewState["SortDir"]="ASC";
     // }
     // if(ViewState["SortColumn"]!=null)
     //   sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();


      //-------------------------------
      // Build WHERE statement
      //-------------------------------
      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();



      //-------------------------------
      // Build base SQL statement
      //-------------------------------


      VersionList_sSQL = "select [v].[version] as v_version, " +
                        "[v].[version_id] as v_version_id " +
                        " from [versions] v ";

      //-------------------------------
      //-------------------------------

      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------



      VersionList_sSQL = VersionList_sSQL + sWhere + sOrder;
      if (VersionList_sCountSQL.Length== 0)
      {
        int iTmpI = VersionList_sSQL.ToLower().IndexOf("select ");
        int iTmpJ = VersionList_sSQL.ToLower().LastIndexOf(" from ")-1;
        VersionList_sCountSQL = VersionList_sSQL.Replace(VersionList_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
        iTmpI = VersionList_sCountSQL.ToLower().IndexOf(" order by");
        if (iTmpI > 1)
          VersionList_sCountSQL = VersionList_sCountSQL.Substring(0, iTmpI);
      }


      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(VersionList_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, (i_VersionList_curpage - 1) * VersionList_PAGENUM, VersionList_PAGENUM,"VersionList");
      OleDbCommand ccommand = new OleDbCommand(VersionList_sCountSQL, Utility.Connection);
      int PageTemp=(int)ccommand.ExecuteScalar();
      VersionList_Pager.MaxPage=(PageTemp%VersionList_PAGENUM)>0?(int)(PageTemp/VersionList_PAGENUM)+1:(int)(PageTemp/VersionList_PAGENUM);
      bool AllowScroller=VersionList_Pager.MaxPage==1?false:true;

      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        VersionList_no_records.Visible = true;
        AllowScroller=false;
      }
      else
      {
        VersionList_no_records.Visible = false;
        AllowScroller=AllowScroller&&true;
      }

      VersionList_Pager.Visible=AllowScroller;
      return Source;
      // VersionList Show end

    }


    protected void VersionList_pager_navigate_completed(Object Src, int CurrPage)
    {
      i_VersionList_curpage=CurrPage;

      // VersionList CustomNavigation Event begin
      // VersionList CustomNavigation Event end
      VersionList_Bind();
    }


    void VersionList_Bind()
    {
      VersionList_Repeater.DataSource = VersionList_CreateDataSource();
      VersionList_Repeater.DataBind();

    }

    protected void VersionList_insert_Click(Object Src, EventArgs E)
    {
      string sURL = VersionList_FormAction+"";
      Response.Redirect(sURL);
    }

    protected void VersionList_SortChange(Object Src, EventArgs E)
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
      VersionList_Bind();
    }

    private void VersionList_Repeater_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
    {
    
    }



  }
}
