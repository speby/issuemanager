/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: Login.cs
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
  ///    Summary description for Login.
  /// </summary>
  public class Login : System.Web.UI.Page

  {



    //Login CustomIncludes begin
    protected CCUtility Utility;

    //Login form Login variables and controls declarations
    protected System.Web.UI.WebControls.TextBox Login_name;
    protected System.Web.UI.WebControls.TextBox Login_password;
    protected System.Web.UI.WebControls.Button Login_login;
    protected System.Web.UI.HtmlControls.HtmlTableRow Login_trname;
    protected System.Web.UI.HtmlControls.HtmlTableRow Login_trpassword;
    protected System.Web.UI.WebControls.Label Login_labelname;
    protected System.Web.UI.WebControls.Label Login_message;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Login_querystring;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Login_ret_page;
    protected System.Web.UI.WebControls.Label LoginForm_Title;
    protected System.Web.UI.HtmlControls.HtmlTable Login_holder;

    // For each Login form hiddens for PK's,List of Values and Actions
    protected string Login_FormAction="Default.aspx?";



    public Login()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // Login CustomIncludes end
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
  // Login Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // Login Open Event begin
      // Login Open Event end
      //===============================

      //===============================
      // Login OpenAnyPage Event begin
      // Login OpenAnyPage Event end
      //===============================
      //
      //===============================
      // Login PageSecurity begin
      // Login PageSecurity end
      //===============================
      if (Session["UserID"] != null && Int16.Parse(Session["UserID"].ToString()) > 0)
        Login_logged = true;

      if (!IsPostBack)
      {
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
      this.Login_login.Click += new System.EventHandler(this.Login_login_Click);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      Login_Show();

    }



    // Login Show end

    /*===============================
      Display Login Form
      -------------------------------*/
    protected bool Login_logged = false;
    void Login_Show()
    {

      // Login Show begin

      // Login Open Event begin
      // Login Open Event end

      // Login BeforeShow Event begin
      // Login BeforeShow Event end

      if (Login_logged)
      {
        // User logged in
        Login_login.Text = "Logout";
        Login_trpassword.Visible = false;
        Login_trname.Visible = false;
        Login_labelname.Visible = true;
        Login_labelname.Text = Utility.Dlookup("users", "login", "user_id=" + Session["UserID"]) + "&nbsp;&nbsp;&nbsp;";
      }
      else
      {
        // User is not logged in
        Login_login.Text = "Login";
        Login_trpassword.Visible = true;
        Login_trname.Visible = true;
        Login_labelname.Visible = false;
      }

      // Login Close Event begin
      // Login Close Event end

      // Login Show end

    }

    void Login_login_Click(Object Src, EventArgs E)
    {
      if (Login_logged)
      {

        // Login Logout begin

        // Login OnLogout Event begin
        // Login OnLogout Event end
        Login_logged = false;
        Session["UserID"] = 0;
        Session["UserRights"] = 0;
        Login_Show();
        // Login Logout end

      }
      else
      {

        // Login Login begin
        int iPassed = Convert.ToInt32(Utility.Dlookup("users", "count(*)", "login ='" + Login_name.Text + "' and pass='" + CCUtility.Quote(Login_password.Text) + "'"));
        if (iPassed > 0)
        {

          // Login OnLogin Event begin
          // Login OnLogin Event end
          Login_message.Visible = false;
          Session["UserID"] = Convert.ToInt32(Utility.Dlookup("users", "user_id", "login ='" + Login_name.Text + "' and pass='" + CCUtility.Quote(Login_password.Text) +"'"));
          Login_logged = true;

          Session["UserRights"] = Convert.ToInt32(Utility.Dlookup("users", "security_level", "login ='" + Login_name.Text + "' and pass='" + CCUtility.Quote(Login_password.Text) + "'"));

          Session["Supervisor"] = Convert.ToInt32(Utility.Dlookup("users", "supervisor_id", "login ='" + Login_name.Text + "' and pass='" + CCUtility.Quote(Login_password.Text) + "'"));

          string sQueryString = Utility.GetParam("querystring");
          string sPage = Utility.GetParam("ret_page");
          if (! sPage.Equals(Request.ServerVariables["SCRIPT_NAME"]) && sPage.Length > 0)
          {
            Response.Redirect(sPage + "?" + sQueryString);
          }
          else
          {

            Response.Redirect(Login_FormAction);
          }
        }
        else
        {
          Login_message.Visible = true;
        }
        // Login Login end

      }
    }

    // End of Login form
  }
}
