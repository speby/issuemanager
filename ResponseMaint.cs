/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: ResponseMaint.cs
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
  ///    Summary description for ResponseMaint.
  /// </summary>
  public class ResponseMaint : System.Web.UI.Page

  {

    //ResponseMaint CustomIncludes begin
    protected CCUtility Utility;

    //Record form Response variables and controls declarations
    protected System.Web.UI.WebControls.Label Response_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton Response_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton Response_delete;
    protected System.Web.UI.HtmlControls.HtmlInputButton Response_cancel;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_response_id;
    protected System.Web.UI.WebControls.DropDownList Response_user_id;
    protected System.Web.UI.WebControls.TextBox Response_date_response;
    protected System.Web.UI.WebControls.TextBox Response_response;
    protected System.Web.UI.WebControls.DropDownList Response_assigned_to;
    protected System.Web.UI.WebControls.DropDownList Response_qaassigned_to;
    protected System.Web.UI.WebControls.DropDownList Response_priority_id;
    protected System.Web.UI.WebControls.DropDownList Response_status_id;

    // For each Response form hiddens for PK's,List of Values and Actions
    protected string Response_FormAction="IssueMaint.aspx?";
    protected System.Web.UI.WebControls.Label ResponseForm_Title;
    protected System.Web.UI.WebControls.CustomValidator Response_user_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Response_assigned_to_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Response_qaassigned_to_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_priority_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Response_priority_id_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_status_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Response_status_id_Validator_Num;
    protected System.Web.UI.HtmlControls.HtmlTable Response_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Response_response_id;

    public ResponseMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // ResponseMaint CustomIncludes end
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
  // ResponseMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // ResponseMaint Open Event begin
      // ResponseMaint Open Event end
      //===============================

      //===============================
      // ResponseMaint OpenAnyPage Event begin
      // ResponseMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // ResponseMaint PageSecurity begin
      Utility.CheckSecurity(3);
      // ResponseMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Response_response_id.Value = Utility.GetParam("response_id");
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
      this.Response_update.ServerClick += new System.EventHandler(this.Response_Action);
      this.Response_delete.ServerClick += new System.EventHandler(this.Response_Action);
      this.Response_cancel.ServerClick += new System.EventHandler(this.Response_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }

    protected void Page_Show(object sender, EventArgs e)
    {
      Response_Show();

    }

    // ResponseMaint Show end

    // End of Login form

    private bool Response_Validate()
    {
      bool result=true;
      Response_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("Response"))
        {
          if(!Page.Validators[i].IsValid)
          {
            Response_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      Response_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/

    void Response_Show()
    {

      // Response Show begin
      Utility.buildListBox(Response_user_id.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Response_assigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Response_qaassigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Response_priority_id.Items,"select priority_id,priority_desc from priorities order by 2","priority_id","priority_desc",null,"");
      Utility.buildListBox(Response_status_id.Items,"select status_id,status from statuses order by 2","status_id","status",null,"");

      bool ActionInsert=true;

      if (p_Response_response_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "response_id=" + CCUtility.ToSQL(p_Response_response_id.Value, CCUtility.FIELD_TYPE_Number);

        // Response Open Event begin
        // Response Open Event end
        string sSQL = "select * from responses where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "Response") > 0)
        {
          row = ds.Tables[0].Rows[0];

          Response_response_id.Value = CCUtility.GetValue(row, "response_id");

          {
            string s;
            s=CCUtility.GetValue(row, "user_id");

            try
            {
              Response_user_id.SelectedIndex=Response_user_id.Items.IndexOf(Response_user_id.Items.FindByValue(s));
            }
            catch{}
          }

        Response_date_response.Text = CCUtility.GetValue(row, "date_response")
                                        .Replace('T', ' ');
          Response_response.Text = CCUtility.GetValue(row, "response");

          {
            string s;
            s=CCUtility.GetValue(row, "assigned_to");

            try
            {
              Response_assigned_to.SelectedIndex=Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "qaassigned_to")
              ;

            try
            {
              Response_qaassigned_to.SelectedIndex=Response_qaassigned_to.Items.IndexOf(Response_qaassigned_to.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "priority_id")
              ;

            try
            {
              Response_priority_id.SelectedIndex=Response_priority_id.Items.IndexOf(Response_priority_id.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "status_id")
              ;

            try
            {
              Response_status_id.SelectedIndex=Response_status_id.Items.IndexOf(Response_status_id.Items.FindByValue(s));
            }
            catch{}
          }

        ActionInsert=false;

        // Response ShowEdit Event begin
        // Response ShowEdit Event end

      }
    }

    if(ActionInsert)
      {
        Response_delete.Visible=false;
        Response_update.Visible=false;

        // Response ShowInsert Event begin
        // Response ShowInsert Event end

      }

      // Response Open Event begin
      // Response Open Event end

      // Response Show Event begin
      // Response Show Event end

      // Response Show end

      // Response Close Event begin
      // Response Close Event end

    }

    // Response Action begin

    void Response_BeforeSQLExecute(string SQL,String Action)
    {

      // Response BeforeExecute Event begin
      // Response BeforeExecute Event end

    }

    bool Response_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=Response_Validate();
      if(bResult)
      {

        if (p_Response_response_id.Value.Length > 0)
        {
          sWhere = sWhere + "response_id=" + CCUtility.ToSQL(p_Response_response_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // Response Check Event begin
        // Response Check Event end

        if (bResult)
        {

          sSQL = "update responses set " +
                 "[user_id]=" +CCUtility.ToSQL(Utility.GetParam("Response_user_id"),CCUtility.FIELD_TYPE_Number)  +
                 ",[date_response]=" +CCUtility.ToSQL(Utility.GetParam("Response_date_response"),CCUtility.FIELD_TYPE_Date)  +
                 ",[response]=" +CCUtility.ToSQL(Utility.GetParam("Response_response"),CCUtility.FIELD_TYPE_Text)  +
                 ",[assigned_to]=" +CCUtility.ToSQL(Utility.GetParam("Response_assigned_to"),CCUtility.FIELD_TYPE_Number)  +
                 ",[qaassigned_to]=" +CCUtility.ToSQL(Utility.GetParam("Response_qaassigned_to"),CCUtility.FIELD_TYPE_Number)  +
                 ",[priority_id]=" +CCUtility.ToSQL(Utility.GetParam("Response_priority_id"),CCUtility.FIELD_TYPE_Number)  +
                 ",[status_id]=" +CCUtility.ToSQL(Utility.GetParam("Response_status_id"),CCUtility.FIELD_TYPE_Number) ;

          sSQL = sSQL + " where " + sWhere;

          // Response Update Event begin
          // Response Update Event end
          Response_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            Response_ValidationSummary.Text += e.Message;
            Response_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // Response AfterUpdate Event begin
          // Response AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool Response_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_Response_response_id.Value.Length > 0)
      {
        sWhere += "response_id=" + CCUtility.ToSQL(p_Response_response_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from responses where " + sWhere;

      // Response Delete Event begin
      // Response Delete Event end
      Response_BeforeSQLExecute(sSQL,"Delete");
      OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        Response_ValidationSummary.Text += e.Message;
        Response_ValidationSummary.Visible = true;
        return false;
      }

      // Response AfterDelete Event begin
      // Response AfterDelete Event end
      return true;
    }

    bool Response_cancel_Click(Object Src, EventArgs E)
    {

      // Response BeforeCancel Event begin
      // Response BeforeCancel Event end

      return true;
    }

    void Response_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=Response_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=Response_delete_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("cancel")>0)
        bResult=Response_cancel_Click(Src,E);

      if(bResult)
        Response.Redirect(Response_FormAction+"issue_id=" + Server.UrlEncode(Utility.GetParam("issue_id")) + "&");
    }
    // Response Action end

  }
}
