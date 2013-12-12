/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: UserMaint.cs
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
  ///    Summary description for UserMaint.
  /// </summary>
  public class UserMaint : System.Web.UI.Page

  {



    //UserMaint CustomIncludes begin
    protected CCUtility Utility;

    //Record form User variables and controls declarations
    protected System.Web.UI.WebControls.Label User_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton User_insert;
    protected System.Web.UI.HtmlControls.HtmlInputButton User_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton User_delete;
    protected System.Web.UI.HtmlControls.HtmlInputHidden User_user_id;
    protected System.Web.UI.WebControls.TextBox User_login;
    protected System.Web.UI.WebControls.TextBox User_pass;
    protected System.Web.UI.WebControls.DropDownList User_security_level;
    protected System.Web.UI.WebControls.TextBox User_user_name;
    protected System.Web.UI.WebControls.TextBox User_email;
    protected System.Web.UI.WebControls.CheckBox User_allow_upload;
    protected System.Web.UI.WebControls.CheckBox User_notify_new;
    protected System.Web.UI.WebControls.CheckBox User_notify_original;
    protected System.Web.UI.WebControls.CheckBox User_notify_reassignment;

    // For each User form hiddens for PK's,List of Values and Actions
    protected string User_FormAction="UserList.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_User_user_id;
    protected System.Web.UI.WebControls.Label UserForm_Title;
    protected System.Web.UI.WebControls.RequiredFieldValidator User_login_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator User_pass_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator User_security_level_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator User_security_level_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator User_user_name_Validator_Req;
    protected System.Web.UI.HtmlControls.HtmlTable User_holder;
    protected System.Web.UI.WebControls.DropDownList User_supervisor;
    protected String[] User_security_level_lov = "1;1-Standard;2;2-Manager;3;3-Administrator".Split(new Char[] {';'});


    public UserMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // UserMaint CustomIncludes end
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
  // UserMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // UserMaint Open Event begin
      // UserMaint Open Event end
      //===============================

      //===============================
      // UserMaint OpenAnyPage Event begin
      // UserMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // UserMaint PageSecurity begin
      Utility.CheckSecurity(3);
      // UserMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_User_user_id.Value = Utility.GetParam("user_id");
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
      this.User_insert.ServerClick += new System.EventHandler(this.User_Action);
      this.User_update.ServerClick += new System.EventHandler(this.User_Action);
      this.User_delete.ServerClick += new System.EventHandler(this.User_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      User_Show();

    }



    // UserMaint Show end

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
      Utility.buildListBox(User_security_level.Items,User_security_level_lov,null,"");
      Utility.buildListBox(User_supervisor.Items,"select user_id,user_name from users","user_id","user_name",null,"");
      
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

          User_login.Text = CCUtility.GetValue(row, "login");
          User_pass.Text = CCUtility.GetValue(row, "pass");

          {
            string s;
            s=CCUtility.GetValue(row, "security_level");

            try
            {
              User_security_level.SelectedIndex=User_security_level.Items.IndexOf(User_security_level.Items.FindByValue(s));
            }
            catch{}
          }


        {
          string s;
          s=CCUtility.GetValue(row, "supervisor_id");

          try
          {
            User_supervisor.SelectedIndex=User_supervisor.Items.IndexOf(User_supervisor.Items.FindByValue(s));
          }
          catch{}
        }

        User_user_name.Text = CCUtility.GetValue(row, "user_name")
                                ;
          User_email.Text = CCUtility.GetValue(row, "email");
          User_allow_upload.Checked=CCUtility.GetValue(row, "allow_upload").ToLower().Equals("1".ToLower());

          User_notify_new.Checked=CCUtility.GetValue(row, "notify_new").ToLower().Equals("1".ToLower());

          User_notify_original.Checked=CCUtility.GetValue(row, "notify_original").ToLower().Equals("1".ToLower());

          User_notify_reassignment.Checked=CCUtility.GetValue(row, "notify_reassignment").ToLower().Equals("1".ToLower());

          User_insert.Visible=false;
          ActionInsert=false;

          // User ShowEdit Event begin
          // User ShowEdit Event end

        }
      }

      if(ActionInsert)
      {
        User_delete.Visible=false;
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

    bool User_insert_Click(Object Src, EventArgs E)
    {
      string sSQL="";
      bool bResult=User_Validate();

      // User Check Event begin
      // User Check Event end

      if(bResult)
      {
        string p2_login=CCUtility.ToSQL(Utility.GetParam("User_login"), CCUtility.FIELD_TYPE_Text) ;
        string p2_pass=CCUtility.ToSQL(Utility.GetParam("User_pass"), CCUtility.FIELD_TYPE_Text) ;
        string p2_security_level=CCUtility.ToSQL(Utility.GetParam("User_security_level"), CCUtility.FIELD_TYPE_Number) ;
        string p2_user_name=CCUtility.ToSQL(Utility.GetParam("User_user_name"), CCUtility.FIELD_TYPE_Text) ;
        string p2_email=CCUtility.ToSQL(Utility.GetParam("User_email"), CCUtility.FIELD_TYPE_Text) ;
        string c1_allow_upload=CCUtility.getCheckBoxValue(Utility.GetParam("User_allow_upload"), "1", "0", CCUtility.FIELD_TYPE_Number) ;
        string c1_notify_new=CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_new"), "1", "0", CCUtility.FIELD_TYPE_Number) ;
        string c1_notify_original=CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_original"), "1", "0", CCUtility.FIELD_TYPE_Number) ;
        string c1_notify_reassignment=CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_reassignment"), "1", "0", CCUtility.FIELD_TYPE_Number) ;
        string p2_supervisor_id=CCUtility.ToSQL(Utility.GetParam("User_supervisor"), CCUtility.FIELD_TYPE_Number) ;
        // User Insert Event begin
        // User Insert Event end

        sSQL = "insert into users (" +
               "login," +
               "pass," +
               "security_level," +
               "user_name," +
               "email," +
               "allow_upload," +
               "notify_new," +
               "notify_original," +
               "notify_reassignment," +
               "supervisor_id)" +
               " values (" +
               p2_login + "," +
               p2_pass + "," +
               p2_security_level + "," +
               p2_user_name + "," +
               p2_email + "," +
               c1_allow_upload + "," +
               c1_notify_new + "," +
               c1_notify_original + "," +
               c1_notify_reassignment + "," +
               p2_supervisor_id + ")";
        User_BeforeSQLExecute(sSQL,"Insert");
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

        // User AfterInsert Event begin
        // User AfterInsert Event end
      }
      return bResult;
    }

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
                 "[login]=" +CCUtility.ToSQL(Utility.GetParam("User_login"),CCUtility.FIELD_TYPE_Text)  +
                 ",[pass]=" +CCUtility.ToSQL(Utility.GetParam("User_pass"),CCUtility.FIELD_TYPE_Text)  +
                 ",[security_level]=" +CCUtility.ToSQL(Utility.GetParam("User_security_level"),CCUtility.FIELD_TYPE_Number)  +
                 ",[user_name]=" +CCUtility.ToSQL(Utility.GetParam("User_user_name"),CCUtility.FIELD_TYPE_Text)  +
                 ",[email]=" +CCUtility.ToSQL(Utility.GetParam("User_email"),CCUtility.FIELD_TYPE_Text)  +
                 ",[allow_upload]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_allow_upload"),"1","0",CCUtility.FIELD_TYPE_Number)  +
                 ",[notify_new]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_new"),"1","0",CCUtility.FIELD_TYPE_Number)  +
                 ",[notify_original]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_original"),"1","0",CCUtility.FIELD_TYPE_Number)  +
                 ",[notify_reassignment]=" +CCUtility.getCheckBoxValue(Utility.GetParam("User_notify_reassignment"),"1","0",CCUtility.FIELD_TYPE_Number) +
                 ",[supervisor_id]=" +CCUtility.ToSQL(Utility.GetParam("User_supervisor"),CCUtility.FIELD_TYPE_Number) ;


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

    bool User_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_User_user_id.Value.Length > 0)
      {
        sWhere += "user_id=" + CCUtility.ToSQL(p_User_user_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from users where " + sWhere;

      // User Delete Event begin
      // User Delete Event end
      User_BeforeSQLExecute(sSQL,"Delete");
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

      // User AfterDelete Event begin
      // User AfterDelete Event end
      return true;
    }

    void User_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("insert")>0)
        bResult=User_insert_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=User_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=User_delete_Click(Src,E);


      if(bResult)
        Response.Redirect(User_FormAction+"");
    }
    // User Action end



  }
}
