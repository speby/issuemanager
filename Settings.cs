/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: Settings.cs
  //    Generated with CodeCharge 2.0.3
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
  ///    Summary description for Settings.
  /// </summary>

  public class Settings : System.Web.UI.Page

  {



    //Settings CustomIncludes begin
    protected CCUtility Utility;

    //Record form Settings variables and controls declarations
    protected System.Web.UI.WebControls.Label Settings_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton Settings_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton Settings_cancel;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Settings_settings_id;
    protected System.Web.UI.WebControls.TextBox Settings_file_extensions;
    protected System.Web.UI.WebControls.TextBox Settings_file_path;
    protected System.Web.UI.WebControls.TextBox Settings_notify_new_from;
    protected System.Web.UI.WebControls.TextBox Settings_notify_new_subject;
    protected System.Web.UI.WebControls.TextBox Settings_notify_new_body;
    protected System.Web.UI.WebControls.TextBox Settings_notify_change_from;
    protected System.Web.UI.WebControls.TextBox Settings_notify_change_subject;
    protected System.Web.UI.WebControls.TextBox Settings_notify_change_body;

    // For each Settings form hiddens for PK's,List of Values and Actions
    protected string Settings_FormAction="Administration.aspx?";
    protected System.Web.UI.WebControls.Label SettingsForm_Title;
    protected System.Web.UI.HtmlControls.HtmlTable Settings_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Settings_settings_id;


    public Settings()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // Settings CustomIncludes end
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
  // Settings Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // Settings Open Event begin
      Settings_settings_id.Value="1";
      // Settings Open Event end
      //===============================

      //
      //===============================
      // Settings PageSecurity begin
      Utility.CheckSecurity(3);
      // Settings PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Settings_settings_id.Value = Utility.GetParam("settings_id");
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
      this.Settings_update.ServerClick += new System.EventHandler(this.Settings_Action);
      this.Settings_cancel.ServerClick += new System.EventHandler(this.Settings_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      Settings_Show();

    }



    // Settings Show end

    // End of Login form






    private bool Settings_Validate()
    {
      bool result=true;
      Settings_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("Settings"))
        {
          if(!Page.Validators[i].IsValid)
          {
            Settings_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      Settings_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/


    void Settings_Show()
    {

      // Settings Show begin

      bool ActionInsert=true;

      if (p_Settings_settings_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "settings_id=" + CCUtility.ToSQL(p_Settings_settings_id.Value, CCUtility.FIELD_TYPE_Number);

        // Settings Open Event begin
        // Settings Open Event end
        string sSQL = "select * from settings where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "Settings") > 0)
        {
          row = ds.Tables[0].Rows[0];

          Settings_settings_id.Value = CCUtility.GetValue(row, "settings_id");


          Settings_file_extensions.Text = CCUtility.GetValue(row, "file_extensions");
          Settings_file_path.Text = CCUtility.GetValue(row, "file_path");
          Settings_notify_new_from.Text = CCUtility.GetValue(row, "notify_new_from");
          Settings_notify_new_subject.Text = CCUtility.GetValue(row, "notify_new_subject");
          Settings_notify_new_body.Text = CCUtility.GetValue(row, "notify_new_body");


          Settings_notify_change_from.Text = CCUtility.GetValue(row, "notify_change_from");
          Settings_notify_change_subject.Text = CCUtility.GetValue(row, "notify_change_subject");
          Settings_notify_change_body.Text = CCUtility.GetValue(row, "notify_change_body");



          ActionInsert=false;

          // Settings ShowEdit Event begin
          // Settings ShowEdit Event end

        }
      }

      if(ActionInsert)
      {
        Settings_update.Visible=false;

        // Settings ShowInsert Event begin
        // Settings ShowInsert Event end

      }



      // Settings Open Event begin
      // Settings Open Event end

      // Settings Show Event begin
      Settings_settings_id.Value="1";
      // Settings Show Event end

      // Settings Show end

      // Settings Close Event begin
      // Settings Close Event end

    }

    // Settings Action begin


    void Settings_BeforeSQLExecute(string SQL,String Action)
    {

      // Settings BeforeExecute Event begin
      // Settings BeforeExecute Event end

    }


    bool Settings_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=Settings_Validate();
      if(bResult)
      {

        if (p_Settings_settings_id.Value.Length > 0)
        {
          sWhere = sWhere + "settings_id=" + CCUtility.ToSQL(p_Settings_settings_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // Settings Check Event begin
        // Settings Check Event end

        if (bResult)
        {

          sSQL = "update settings set " +
                 "[file_extensions]=" +CCUtility.ToSQL(Utility.GetParam("Settings_file_extensions"),CCUtility.FIELD_TYPE_Text)  +
                 ",[file_path]=" +CCUtility.ToSQL(Utility.GetParam("Settings_file_path"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_new_from]=" +CCUtility.ToSQL(Utility.GetParam("Settings_notify_new_from"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_new_subject]=" +CCUtility.ToSQL(Utility.GetParam("Settings_notify_new_subject"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_new_body]=" +CCUtility.ToSQL(Utility.GetParam("Settings_notify_new_body"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_change_from]=" +CCUtility.ToSQL(Utility.GetParam("Settings_notify_change_from"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_change_subject]=" +CCUtility.ToSQL(Utility.GetParam("Settings_notify_change_subject"),CCUtility.FIELD_TYPE_Text)  +
                 ",[notify_change_body]=" +CCUtility.ToSQL(Utility.GetParam("Settings_notify_change_body"),CCUtility.FIELD_TYPE_Text) ;


          sSQL = sSQL + " where " + sWhere;

          // Settings Update Event begin
          if(!System.IO.Directory.Exists(Server.MapPath( (Settings_file_path.Text).Trim() )))
          {
            try
            {
              System.IO.Directory.CreateDirectory(Server.MapPath( (Settings_file_path.Text).Trim() ));
            }
            catch(Exception ed)
            {
              Settings_ValidationSummary.Text +=ed.ToString()+"<BR>Please contact with server administrator";
              Settings_ValidationSummary.Visible = true;
              return false;
            }
          }
          try
          {
            System.IO.FileStream fs =System.IO.File.Create( Server.MapPath((Settings_file_path.Text).Trim()+"\\test.tmp"));
            fs.Close();
            System.IO.File.Delete(Server.MapPath((Settings_file_path.Text).Trim()+"\\test.tmp"));
          }
          catch(Exception ed)
          {
            Settings_ValidationSummary.Text +=ed.ToString()+"<BR>Please contact with server administrator";
            Settings_ValidationSummary.Visible = true;
            return false;
          }
          // Settings Update Event end
          Settings_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            Settings_ValidationSummary.Text += e.Message;
            Settings_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // Settings AfterUpdate Event begin
          // Settings AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool Settings_cancel_Click(Object Src, EventArgs E)
    {

      // Settings BeforeCancel Event begin
      // Settings BeforeCancel Event end

      return true;
    }

    void Settings_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=Settings_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("cancel")>0)
        bResult=Settings_cancel_Click(Src,E);


      if(bResult)
        Response.Redirect(Settings_FormAction+"");
    }
    // Settings Action end



  }
}
