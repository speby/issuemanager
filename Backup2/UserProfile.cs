/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: UserProfile.cs
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
  ///    Summary description for UserProfile.
  /// </summary>
  public class UserProfile : System.Web.UI.Page

  {



    //UserProfile CustomIncludes begin
    protected CCUtility Utility;

    //Record form User variables and controls declarations
    protected System.Web.UI.WebControls.Label User_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton User_update;
    protected System.Web.UI.HtmlControls.HtmlInputHidden User_user_id;
    protected System.Web.UI.WebControls.Label User_user_name;
    protected System.Web.UI.WebControls.Label User_login;
    protected System.Web.UI.WebControls.TextBox User_pass;
    protected System.Web.UI.WebControls.CheckBox User_notify_new;
    protected System.Web.UI.WebControls.CheckBox User_notify_original;
    protected System.Web.UI.WebControls.CheckBox User_notify_reassignment;
    protected System.Web.UI.WebControls.Label User_allow_upload;
    protected System.Web.UI.WebControls.Label User_security_level;

    // For each User form hiddens for PK's,List of Values and Actions
    protected string User_FormAction="UserProfile.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_User_user_id;
    protected String[] User_notify_new_lov = "0;No;1;Yes".Split(new Char[] {';'});
    protected String[] User_notify_original_lov = "0;No;1;Yes".Split(new Char[] {';'});
    protected String[] User_notify_reassignment_lov = "0;No;1;Yes".Split(new Char[] {';'});
    protected String[] User_allow_upload_lov = "0;No;1;Yes".Split(new Char[] {';'});
    protected String[] User_security_level_lov = "1;1-Standard;2;2-Manager;3;3-Administrator".Split(new Char[] {';'});


    public UserProfile()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // UserProfile CustomIncludes end
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
  // UserProfile Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // UserProfile Open Event begin
      // UserProfile Open Event end
      //===============================

      //===============================
      // UserProfile OpenAnyPage Event begin
      // UserProfile OpenAnyPage Event end
      //===============================
      //
      //===============================
      // UserProfile PageSecurity begin
      Utility.CheckSecurity(1);
      // UserProfile PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        if(Session["UserID"]!=null)
          p_User_user_id.Value = Session["UserID"].ToString();
        else
          p_User_user_id.Value="";
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
      this.Load += new System.EventHandler(this.Page_Load);
      this.Unload += new System.EventHandler(this.Page_Unload);
      User_update.ServerClick += new System.EventHandler (this.User_Action);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      User_Show();

    }



    // UserProfile Show end

    // End of Login form






    private bool User_Validate()
    {
      bool result=true;
      User_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("User"))
        {
          if(!Page.Validators[i].IsValid)
          {
            User_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      User_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/


    void User_Show()
    {

      // User Show begin

      bool ActionInsert=true;

      if (p_User_user_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "user_id=" + CCUtility.ToSQL(p_User_user_id.Value, CCUtility.FIELD_TYPE_Number);

        // User Open Event begin
        // User Open Event end
        string sSQL = "select * from users where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "User") > 0)
        {
          row = ds.Tables[0].Rows[0];

          User_user_id.Value = CCUtility.GetValue(row, "user_id");

          User_user_name.Text =Server.HtmlEncode(CCUtility.GetValue(row, "user_name").ToString());



          User_login.Text =Server.HtmlEncode(CCUtility.GetValue(row, "login").ToString());



          User_pass.Text = CCUtility.GetValue(row, "pass");
          User_notify_new.Checked=CCUtility.GetValue(row, "notify_new").ToLower().Equals("1".ToLower());

          User_notify_original.Checked=CCUtility.GetValue(row, "notify_original").ToLower().Equals("1".ToLower());

          User_notify_reassignment.Checked=CCUtility.GetValue(row, "notify_reassignment").ToLower().Equals("1".ToLower());


          User_allow_upload.Text = Server.HtmlEncode(CCUtility.GetValFromLOV(CCUtility.GetValue(row, "allow_upload"),User_allow_upload_lov).ToString());



          User_security_level.Text = Server.HtmlEncode(CCUtility.GetValFromLOV(CCUtility.GetValue(row, "security_level"),User_security_level_lov).ToString());



          ActionInsert=false;

          // User ShowEdit Event begin
          // User ShowEdit Event end

        }
      }

      if(ActionInsert)
      {

        String pValue;

        if(Session["UserID"]!=null)
          pValue = Session["UserID"].ToString();
        else
          pValue="";
        User_user_id.Value = pValue;
        User_update.Visible=false;

        // User ShowInsert Event begin
        // User ShowInsert Event end

      }



      // User Open Event begin
      // User Open Event end

      // User Show Event begin
      // User Show Event end

      // User Show end

      // User Close Event begin
      // User Close Event end

    }

    // User Action begin


    void User_BeforeSQLExecute(string SQL,String Action)
    {

      // User BeforeExecute Event begin
      // User BeforeExecute Event end

    }


    bool User_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=User_Validate();
      if(bResult)
      {

        if (p_User_user_id.Value.Length > 0)
        {
          sWhere = sWhere + "user_id=" + CCUtility.ToSQL(p_User_user_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // User Check Event begin
        // User Check Event end

        if (bResult)
        {

          sSQL = "update users set " +
                 "[pass]=" +CCUtility.ToSQL(Utility.GetParam("User_pass"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_new]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_new"),"1","0",CCUtility.FIELD_TYPE_Number)  +
                 ",[notify_original]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_original"),"1","0",CCUtility.FIELD_TYPE_Number)  +
                 ",[notify_reassignment]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_reassignment"),"1","0",CCUtility.FIELD_TYPE_Number) ;


          sSQL = sSQL + " where " + sWhere;

          // User Update Event begin
          // User Update Event end
          User_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            User_ValidationSummary.Text += e.Message;
            User_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // User AfterUpdate Event begin
          // User AfterUpdate Event end
        }
      }
      return bResult;
    }

    void User_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=User_update_Click(Src,E);


      if(bResult)
        Response.Redirect(User_FormAction+"");
    }
    // User Action end



  }
}
