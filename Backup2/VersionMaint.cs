/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: VersionMaint.cs
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
  ///    Summary description for VersionMaint.
  /// </summary>
  public class VersionMaint : System.Web.UI.Page

  {



    //VersionMaint CustomIncludes begin
    protected CCUtility Utility;

    //Grid form VersionList variables and controls declarations
    //protected string VersionList_sSQL;
    //protected string VersionList_sCountSQL;
    //protected int VersionList_CountPage;
    //protected int i_VersionList_curpage=1;
    //protected CCPager VersionList_Pager;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_VersionMaint_version_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden VersionMaint_version_id;
    

    //Record form VersionMaint variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlInputButton VersionMaint_insert;
    protected System.Web.UI.HtmlControls.HtmlInputButton VersionMaint_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton VersionMaint_delete;
    protected System.Web.UI.WebControls.Label VersionMaint_ValidationSummary;
    protected System.Web.UI.WebControls.TextBox VersionMaint_version;
    protected System.Web.UI.WebControls.Label VersionMaintForm_Title;
    protected System.Web.UI.WebControls.RequiredFieldValidator VersionMaint_version_Validator_Req;
    protected System.Web.UI.HtmlControls.HtmlTable VersionMaint_holder;

    // For each VersionMaint form hiddens for PK's,List of Values and Actions
    protected string VersionMaint_FormAction="VersionList.aspx?";


    public VersionMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // VersionMaint CustomIncludes end
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
  // VersionMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // VersionMaint Open Event begin
      // VersionMaint Open Event end
      //===============================

      //===============================
      // VersionMaint OpenAnyPage Event begin
      // VersionMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // VersionMaint PageSecurity begin
      Utility.CheckSecurity(2);
      // VersionMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_VersionMaint_version_id.Value = Utility.GetParam("version_id");
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
      this.VersionMaint_insert.ServerClick += new System.EventHandler(this.VersionMaint_Action);
      this.VersionMaint_delete.ServerClick += new System.EventHandler(this.VersionMaint_Action);
      this.VersionMaint_update.ServerClick += new System.EventHandler(this.VersionMaint_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);
    }


    protected void Page_Show(object sender, EventArgs e)
    {
      VersionMaint_Show();

    }



    // VersionMaint Show end

    // End of Login form






    private bool VersionMaint_Validate()
    {
      bool result=true;
      VersionMaint_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("VersionMaint"))
        {
          if(!Page.Validators[i].IsValid)
          {
            VersionMaint_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      VersionMaint_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/


    void VersionMaint_Show()
    {

      // VersionMaint Show begin

      bool ActionInsert=true;

      if (p_VersionMaint_version_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "version_id=" + CCUtility.ToSQL(p_VersionMaint_version_id.Value, CCUtility.FIELD_TYPE_Number);

        // VersionMaint Open Event begin
        // VersionMaint Open Event end
        string sSQL = "select * from versions where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "VersionMaint") > 0)
        {
          row = ds.Tables[0].Rows[0];

          VersionMaint_version_id.Value = CCUtility.GetValue(row, "version_id");

          VersionMaint_version.Text = CCUtility.GetValue(row, "version");
          VersionMaint_insert.Visible=false;
          ActionInsert=false;

          // VersionMaint ShowEdit Event begin
          // VersionMaint ShowEdit Event end

        }
      }

      if(ActionInsert)
      {
        VersionMaint_delete.Visible=false;
        VersionMaint_update.Visible=false;

        // VersionMaint ShowInsert Event begin
        // VersionMaint ShowInsert Event end

      }



      // VersionMaint Open Event begin
      // VersionMaint Open Event end

      // VersionMaint Show Event begin
      // VersionMaint Show Event end

      // VersionMaint Show end

      // VersionMaint Close Event begin
      // VersionMaint Close Event end

    }

    // VersionMaint Action begin

    bool VersionMaint_insert_Click(Object Src, EventArgs E)
    {
      string sSQL="";
      bool bResult=VersionMaint_Validate();

      // VersionMaint Check Event begin
      // VersionMaint Check Event end

      if(bResult)
      {


        string p2_version=CCUtility.ToSQL(Utility.GetParam("VersionMaint_version"), CCUtility.FIELD_TYPE_Text) ;
        // VersionMaint Insert Event begin
        // VersionMaint Insert Event end


        sSQL = "insert into versions (" +
               "version)" +
               " values (" +
               p2_version + ")";
        VersionMaint_BeforeSQLExecute(sSQL,"Insert");
        OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
        try
        {
          cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
          VersionMaint_ValidationSummary.Text += e.Message;
          VersionMaint_ValidationSummary.Visible = true;
          return false;
        }

        // VersionMaint AfterInsert Event begin
        // VersionMaint AfterInsert Event end
      }
      return bResult;
    }


    void VersionMaint_BeforeSQLExecute(string SQL,String Action)
    {

      // VersionMaint BeforeExecute Event begin
      // VersionMaint BeforeExecute Event end

    }


    bool VersionMaint_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=VersionMaint_Validate();
      if(bResult)
      {

        if (p_VersionMaint_version_id.Value.Length > 0)
        {
          sWhere = sWhere + "version_id=" + CCUtility.ToSQL(p_VersionMaint_version_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // VersionMaint Check Event begin
        // VersionMaint Check Event end

        if (bResult)
        {

          sSQL = "update versions set " +
                 "[version]=" +CCUtility.ToSQL(Utility.GetParam("VersionMaint_version"),CCUtility.FIELD_TYPE_Text) ;


          sSQL = sSQL + " where " + sWhere;

          // VersionMaint Update Event begin
          // VersionMaint Update Event end
          VersionMaint_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            VersionMaint_ValidationSummary.Text += e.Message;
            VersionMaint_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // VersionMaint AfterUpdate Event begin
          // VersionMaint AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool VersionMaint_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_VersionMaint_version_id.Value.Length > 0)
      {
        sWhere += "version_id=" + CCUtility.ToSQL(p_VersionMaint_version_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from versions where " + sWhere;

      // VersionMaint Delete Event begin
      // VersionMaint Delete Event end
      VersionMaint_BeforeSQLExecute(sSQL,"Delete");
      OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        VersionMaint_ValidationSummary.Text += e.Message;
        VersionMaint_ValidationSummary.Visible = true;
        return false;
      }

      // VersionMaint AfterDelete Event begin
      // VersionMaint AfterDelete Event end
      return true;
    }

    protected void VersionMaint_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("insert")>0)
        bResult=VersionMaint_insert_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=VersionMaint_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=VersionMaint_delete_Click(Src,E);


      if(bResult)
        Response.Redirect(VersionMaint_FormAction+"");
    }
    // versionMaint Action end



  }
}
