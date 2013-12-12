/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: PriorityList.cs
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
  ///    Summary description for PriorityList.
  /// </summary>
  public class PriorityList : System.Web.UI.Page

  {



    //PriorityList CustomIncludes begin
    protected CCUtility Utility;

    //Grid form PrioritiesList variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow PrioritiesList_no_records;
    protected string PrioritiesList_sSQL;
    protected string PrioritiesList_sCountSQL;
    protected int PrioritiesList_CountPage;
    protected System.Web.UI.WebControls.LinkButton PrioritiesList_insert;
    protected System.Web.UI.WebControls.Repeater PrioritiesList_Repeater;
    protected int i_PrioritiesList_curpage=1;

    // For each PrioritiesList form hiddens for PK's,List of Values and Actions
    protected string PrioritiesList_FormAction="PriorityMaint.aspx?";
    protected System.Web.UI.WebControls.Label PrioritiesListForm_Title;
    protected System.Web.UI.WebControls.Label PrioritiesList_Column_priority_desc;
    protected System.Web.UI.WebControls.Label PrioritiesList_Column_priority_color;
    protected System.Web.UI.WebControls.Label PrioritiesList_Column_priority_order;
    protected System.Web.UI.HtmlControls.HtmlTable PrioritiesList_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_PrioritiesList_priority_id;


    public PriorityList()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // PriorityList CustomIncludes end
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
  // PriorityList Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // PriorityList Open Event begin
      // PriorityList Open Event end
      //===============================

      //===============================
      // PriorityList OpenAnyPage Event begin
      // PriorityList OpenAnyPage Event end
      //===============================
      //
      //===============================
      // PriorityList PageSecurity begin
      Utility.CheckSecurity(2);
      // PriorityList PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_PrioritiesList_priority_id.Value = Utility.GetParam("priority_id");
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
      this.PrioritiesList_insert.Click += new System.EventHandler(this.PrioritiesList_insert_Click);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      PrioritiesList_Bind();

    }



    // PriorityList Show end

    // End of Login form








    const int PrioritiesList_PAGENUM = 20;




    public void PrioritiesList_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // PrioritiesList Show Event begin
      // PrioritiesList Show Event end
    }


    ICollection PrioritiesList_CreateDataSource()
    {


      // PrioritiesList Show begin
      PrioritiesList_sSQL = "";
      PrioritiesList_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool HasParam = false;


      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by p.priority_order Asc";
      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();





      //-------------------------------
      // Build base SQL statement
      //-------------------------------


      PrioritiesList_sSQL = "select [p].[priority_color] as p_priority_color, " +
                            "[p].[priority_desc] as p_priority_desc, " +
                            "[p].[priority_id] as p_priority_id, " +
                            "[p].[priority_order] as p_priority_order " +
                            " from [priorities] p ";

      //-------------------------------
      //-------------------------------

      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------



      PrioritiesList_sSQL = PrioritiesList_sSQL + sWhere + sOrder;
      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(PrioritiesList_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, PrioritiesList_PAGENUM, "PrioritiesList");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        PrioritiesList_no_records.Visible = true;
      }
      else
      {
        PrioritiesList_no_records.Visible = false;
      }


      return Source;
      // PrioritiesList Show end

    }


    void PrioritiesList_Bind()
    {
      PrioritiesList_Repeater.DataSource = PrioritiesList_CreateDataSource();
      PrioritiesList_Repeater.DataBind();

    }

    void PrioritiesList_insert_Click(Object Src, EventArgs E)
    {
      string sURL = PrioritiesList_FormAction+"";
      Response.Redirect(sURL);
    }



  }
}
