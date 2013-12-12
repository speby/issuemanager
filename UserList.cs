/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: UserList.cs
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
  ///    Summary description for UserList.
  /// </summary>
  public class UserList : System.Web.UI.Page

  {



    //UserList CustomIncludes begin
    protected CCUtility Utility;

    //Grid form Users variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Users_no_records;
    protected string Users_sSQL;
    protected string Users_sCountSQL;
    protected int Users_CountPage;
    protected CCPager Users_Pager;
    protected System.Web.UI.WebControls.LinkButton Users_insert;
    protected System.Web.UI.WebControls.Repeater Users_Repeater;
    protected int i_Users_curpage=1;

    // For each Users form hiddens for PK's,List of Values and Actions
    protected string Users_FormAction="UserMaint.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Users_user_id;
    protected String[] Users_security_level_lov = "1;1-Standard;2;2-Manager;3;3-Administrator".Split(new Char[] {';'});
    protected System.Web.UI.WebControls.Label UsersForm_Title;
    protected System.Web.UI.WebControls.LinkButton Users_Column_user_name;
    protected System.Web.UI.WebControls.LinkButton Users_Column_email;
    protected System.Web.UI.WebControls.LinkButton Users_Column_security_level;
    protected System.Web.UI.WebControls.LinkButton Users_Column_allow_upload;
    protected System.Web.UI.HtmlControls.HtmlTable Users_holder;
    protected String[] Users_allow_upload_lov = "0;No;1;Yes".Split(new Char[] {';'});


    public UserList()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // UserList CustomIncludes end
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
  // UserList Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // UserList Open Event begin
      // UserList Open Event end
      //===============================

      //===============================
      // UserList OpenAnyPage Event begin
      // UserList OpenAnyPage Event end
      //===============================
      //
      //===============================
      // UserList PageSecurity begin
      Utility.CheckSecurity(2);
      // UserList PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Users_user_id.Value = Utility.GetParam("user_id");
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
      Users_Pager.NavigateCompleted+=new NavigateCompletedHandler(this.Users_pager_navigate_completed);
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Users_insert.Click += new System.EventHandler(this.Users_insert_Click);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      Users_Bind();

    }



    // UserList Show end

    // End of Login form








    const int Users_PAGENUM = 20;




    public void Users_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Users Show Event begin
      // Users Show Event end
    }


    ICollection Users_CreateDataSource()
    {


      // Users Show begin
      Users_sSQL = "";
      Users_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool HasParam = false;


      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by u.User_name Asc";
      if(Utility.GetParam("FormUsers_Sorting").Length>0&&!IsPostBack)
      {
        ViewState["SortColumn"]=Utility.GetParam("FormUsers_Sorting");
        ViewState["SortDir"]="ASC";
      }
      if(ViewState["SortColumn"]!=null)
        sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();

      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();





      //-------------------------------
      // Build base SQL statement
      //-------------------------------


      Users_sSQL = "select [u].[allow_upload] as u_allow_upload, " +
                   "[u].[email] as u_email, " +
                   "[u].[security_level] as u_security_level, " +
                   "[u].[user_id] as u_user_id, " +
                   "[u].[user_name] as u_user_name " +
                   " from [users] u ";

      //-------------------------------
      //-------------------------------

      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------



      Users_sSQL = Users_sSQL + sWhere + sOrder;
      if (Users_sCountSQL.Length== 0)
      {
        int iTmpI = Users_sSQL.ToLower().IndexOf("select ");
        int iTmpJ = Users_sSQL.ToLower().LastIndexOf(" from ")-1;
        Users_sCountSQL = Users_sSQL.Replace(Users_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
        iTmpI = Users_sCountSQL.ToLower().IndexOf(" order by");
        if (iTmpI > 1)
          Users_sCountSQL = Users_sCountSQL.Substring(0, iTmpI);
      }


      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Users_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, (i_Users_curpage - 1) * Users_PAGENUM, Users_PAGENUM,"Users");
      OleDbCommand ccommand = new OleDbCommand(Users_sCountSQL, Utility.Connection);
      int PageTemp=(int)ccommand.ExecuteScalar();
      Users_Pager.MaxPage=(PageTemp%Users_PAGENUM)>0?(int)(PageTemp/Users_PAGENUM)+1:(int)(PageTemp/Users_PAGENUM);
      bool AllowScroller=Users_Pager.MaxPage==1?false:true;

      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Users_no_records.Visible = true;
        AllowScroller=false;
      }
      else
      {
        Users_no_records.Visible = false;
        AllowScroller=AllowScroller&&true;
      }

      Users_Pager.Visible=AllowScroller;
      return Source;
      // Users Show end

    }


    protected void Users_pager_navigate_completed(Object Src, int CurrPage)
    {
      i_Users_curpage=CurrPage;

      // Users CustomNavigation Event begin
      // Users CustomNavigation Event end
      Users_Bind();
    }


    void Users_Bind()
    {
      Users_Repeater.DataSource = Users_CreateDataSource();
      Users_Repeater.DataBind();

    }

    void Users_insert_Click(Object Src, EventArgs E)
    {
      string sURL = Users_FormAction+"";
      Response.Redirect(sURL);
    }

    protected void Users_SortChange(Object Src, EventArgs E)
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
      Users_Bind();
    }



  }
}
