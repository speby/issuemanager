/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: StatusMaint.cs
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
  ///    Summary description for StatusMaint.
  /// </summary>
  public class StatusMaint : System.Web.UI.Page

  {



    //StatusMaint CustomIncludes begin
    protected CCUtility Utility;

    //Record form StatusMaint variables and controls declarations
    protected System.Web.UI.WebControls.Label StatusMaint_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton StatusMaint_insert;
    protected System.Web.UI.HtmlControls.HtmlInputButton StatusMaint_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton StatusMaint_delete;
    protected System.Web.UI.HtmlControls.HtmlInputHidden StatusMaint_status_id;
    protected System.Web.UI.WebControls.TextBox StatusMaint_status;

    // For each StatusMaint form hiddens for PK's,List of Values and Actions
    protected string StatusMaint_FormAction="StatusList.aspx?";
    protected System.Web.UI.WebControls.Label StatusMaintForm_Title;
    protected System.Web.UI.WebControls.RequiredFieldValidator StatusMaint_status_Validator_Req;
    protected System.Web.UI.HtmlControls.HtmlTable StatusMaint_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_StatusMaint_status_id;


    public StatusMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // StatusMaint CustomIncludes end
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
  // StatusMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // StatusMaint Open Event begin
      // StatusMaint Open Event end
      //===============================

      //===============================
      // StatusMaint OpenAnyPage Event begin
      // StatusMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // StatusMaint PageSecurity begin
      Utility.CheckSecurity(2);
      // StatusMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_StatusMaint_status_id.Value = Utility.GetParam("status_id");
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
      this.StatusMaint_insert.ServerClick += new System.EventHandler(this.StatusMaint_Action);
      this.StatusMaint_update.ServerClick += new System.EventHandler(this.StatusMaint_Action);
      this.StatusMaint_delete.ServerClick += new System.EventHandler(this.StatusMaint_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      StatusMaint_Show();

    }



    // StatusMaint Show end

    // End of Login form






    private bool StatusMaint_Validate()
    {
      bool result=true;
      StatusMaint_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("StatusMaint"))
        {
          if(!Page.Validators[i].IsValid)
          {
            StatusMaint_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      StatusMaint_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/


    void StatusMaint_Show()
    {

      // StatusMaint Show begin

      bool ActionInsert=true;

      if (p_StatusMaint_status_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "status_id=" + CCUtility.ToSQL(p_StatusMaint_status_id.Value, CCUtility.FIELD_TYPE_Number);

        // StatusMaint Open Event begin
        // StatusMaint Open Event end
        string sSQL = "select * from statuses where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "StatusMaint") > 0)
        {
          row = ds.Tables[0].Rows[0];

          StatusMaint_status_id.Value = CCUtility.GetValue(row, "status_id");

          StatusMaint_status.Text = CCUtility.GetValue(row, "status");
          StatusMaint_insert.Visible=false;
          ActionInsert=false;

          // StatusMaint ShowEdit Event begin
          // StatusMaint ShowEdit Event end

        }
      }

      if(ActionInsert)
      {
        StatusMaint_delete.Visible=false;
        StatusMaint_update.Visible=false;

        // StatusMaint ShowInsert Event begin
        // StatusMaint ShowInsert Event end

      }



      // StatusMaint Open Event begin
      // StatusMaint Open Event end

      // StatusMaint Show Event begin
      // StatusMaint Show Event end

      // StatusMaint Show end

      // StatusMaint Close Event begin
      // StatusMaint Close Event end

    }

    // StatusMaint Action begin

    bool StatusMaint_insert_Click(Object Src, EventArgs E)
    {
      string sSQL="";
      bool bResult=StatusMaint_Validate();

      // StatusMaint Check Event begin
      // StatusMaint Check Event end

      if(bResult)
      {


        string p2_status=CCUtility.ToSQL(Utility.GetParam("StatusMaint_status"), CCUtility.FIELD_TYPE_Text) ;
        // StatusMaint Insert Event begin
        // StatusMaint Insert Event end


        sSQL = "insert into statuses (" +
               "status)" +
               " values (" +
               p2_status + ")";
        StatusMaint_BeforeSQLExecute(sSQL,"Insert");
        OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
        try
        {
          cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
          StatusMaint_ValidationSummary.Text += e.Message;
          StatusMaint_ValidationSummary.Visible = true;
          return false;
        }

        // StatusMaint AfterInsert Event begin
        // StatusMaint AfterInsert Event end
      }
      return bResult;
    }


    void StatusMaint_BeforeSQLExecute(string SQL,String Action)
    {

      // StatusMaint BeforeExecute Event begin
      // StatusMaint BeforeExecute Event end

    }


    bool StatusMaint_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=StatusMaint_Validate();
      if(bResult)
      {

        if (p_StatusMaint_status_id.Value.Length > 0)
        {
          sWhere = sWhere + "status_id=" + CCUtility.ToSQL(p_StatusMaint_status_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // StatusMaint Check Event begin
        // StatusMaint Check Event end

        if (bResult)
        {

          sSQL = "update statuses set " +
                 "[status]=" +CCUtility.ToSQL(Utility.GetParam("StatusMaint_status"),CCUtility.FIELD_TYPE_Text) ;


          sSQL = sSQL + " where " + sWhere;

          // StatusMaint Update Event begin
          // StatusMaint Update Event end
          StatusMaint_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            StatusMaint_ValidationSummary.Text += e.Message;
            StatusMaint_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // StatusMaint AfterUpdate Event begin
          // StatusMaint AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool StatusMaint_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_StatusMaint_status_id.Value.Length > 0)
      {
        sWhere += "status_id=" + CCUtility.ToSQL(p_StatusMaint_status_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from statuses where " + sWhere;

      // StatusMaint Delete Event begin
      // StatusMaint Delete Event end
      StatusMaint_BeforeSQLExecute(sSQL,"Delete");
      OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        StatusMaint_ValidationSummary.Text += e.Message;
        StatusMaint_ValidationSummary.Visible = true;
        return false;
      }

      // StatusMaint AfterDelete Event begin
      // StatusMaint AfterDelete Event end
      return true;
    }

    void StatusMaint_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("insert")>0)
        bResult=StatusMaint_insert_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=StatusMaint_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=StatusMaint_delete_Click(Src,E);


      if(bResult)
        Response.Redirect(StatusMaint_FormAction+"");
    }
    // StatusMaint Action end



  }
}
