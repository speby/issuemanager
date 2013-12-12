/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: FileMaint.cs
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
  ///    Summary description for FileMaint.
  /// </summary>
  public class FileMaint : System.Web.UI.Page

  {



    //FileMaint CustomIncludes begin
    protected CCUtility Utility;

    //Record form Files variables and controls declarations
    protected System.Web.UI.WebControls.Label Files_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton Files_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton Files_delete;
    protected System.Web.UI.HtmlControls.HtmlInputButton Files_cancel;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Files_file_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Files_issue_id;
    protected System.Web.UI.WebControls.TextBox Files_file_name;
    protected System.Web.UI.WebControls.DropDownList Files_uploaded_by;
    protected System.Web.UI.WebControls.TextBox Files_date_uploaded;

    // For each Files form hiddens for PK's,List of Values and Actions
    protected string Files_FormAction="IssueMaint.aspx?";
    protected System.Web.UI.WebControls.Label FilesForm_Title;
    protected System.Web.UI.WebControls.CustomValidator Files_uploaded_by_Validator_Num;
    protected System.Web.UI.HtmlControls.HtmlTable Files_holder;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Files_file_id;


    public FileMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // FileMaint CustomIncludes end
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
  // FileMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // FileMaint Open Event begin
      // FileMaint Open Event end
      //===============================

      //===============================
      // FileMaint OpenAnyPage Event begin
      // FileMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // FileMaint PageSecurity begin
      Utility.CheckSecurity(3);
      // FileMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Files_file_id.Value = Utility.GetParam("file_id");
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
      this.Files_update.ServerClick += new System.EventHandler(this.Files_Action);
      this.Files_delete.ServerClick += new System.EventHandler(this.Files_Action);
      this.Files_cancel.ServerClick += new System.EventHandler(this.Files_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      Files_Show();

    }



    // FileMaint Show end

    // End of Login form






    private bool Files_Validate()
    {
      bool result=true;
      Files_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("Files"))
        {
          if(!Page.Validators[i].IsValid)
          {
            Files_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      Files_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/


    void Files_Show()
    {

      // Files Show begin
      Utility.buildListBox(Files_uploaded_by.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");

      bool ActionInsert=true;

      if (p_Files_file_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "file_id=" + CCUtility.ToSQL(p_Files_file_id.Value, CCUtility.FIELD_TYPE_Number);

        // Files Open Event begin
        // Files Open Event end
        string sSQL = "select * from files where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "Files") > 0)
        {
          row = ds.Tables[0].Rows[0];

          Files_file_id.Value = CCUtility.GetValue(row, "file_id");

          Files_issue_id.Value = CCUtility.GetValue(row, "issue_id");

          Files_file_name.Text = CCUtility.GetValue(row, "file_name");

          {
            string s;
            s=CCUtility.GetValue(row, "uploaded_by");

            try
            {
              Files_uploaded_by.SelectedIndex=Files_uploaded_by.Items.IndexOf(Files_uploaded_by.Items.FindByValue(s));
            }
            catch{}
          }

        Files_date_uploaded.Text = CCUtility.GetValue(row, "date_uploaded")
                                     .Replace('T', ' ');

          ActionInsert=false;

          // Files ShowEdit Event begin
          // Files ShowEdit Event end

        }
      }

      if(ActionInsert)
      {

        String pValue;

        pValue = Utility.GetParam("file_id");
        Files_file_id.Value = pValue;
        pValue = Utility.GetParam("issue_id");
        Files_issue_id.Value = pValue;
        Files_delete.Visible=false;
        Files_update.Visible=false;

        // Files ShowInsert Event begin
        // Files ShowInsert Event end

      }



      // Files Open Event begin
      // Files Open Event end

      // Files Show Event begin
      // Files Show Event end

      // Files Show end

      // Files Close Event begin
      // Files Close Event end

    }

    // Files Action begin


    void Files_BeforeSQLExecute(string SQL,String Action)
    {

      // Files BeforeExecute Event begin
      // Files BeforeExecute Event end

    }


    bool Files_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=Files_Validate();
      if(bResult)
      {

        if (p_Files_file_id.Value.Length > 0)
        {
          sWhere = sWhere + "file_id=" + CCUtility.ToSQL(p_Files_file_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // Files Check Event begin
        // Files Check Event end

        if (bResult)
        {

          sSQL = "update files set " +
                 "[issue_id]=" +CCUtility.ToSQL(Utility.GetParam("Files_issue_id"),CCUtility.FIELD_TYPE_Number)  +
                 ",[file_name]=" +CCUtility.ToSQL(Utility.GetParam("Files_file_name"),CCUtility.FIELD_TYPE_Text)  +
                 ",[uploaded_by]=" +CCUtility.ToSQL(Utility.GetParam("Files_uploaded_by"),CCUtility.FIELD_TYPE_Number)  +
                 ",[date_uploaded]=" +CCUtility.ToSQL(Utility.GetParam("Files_date_uploaded"),CCUtility.FIELD_TYPE_Date) ;


          sSQL = sSQL + " where " + sWhere;

          // Files Update Event begin
          // Files Update Event end
          Files_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            Files_ValidationSummary.Text += e.Message;
            Files_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // Files AfterUpdate Event begin
          // Files AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool Files_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_Files_file_id.Value.Length > 0)
      {
        sWhere += "file_id=" + CCUtility.ToSQL(p_Files_file_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from files where " + sWhere;

      // Files Delete Event begin
      System.IO.File.Delete(Server.MapPath(Utility.Dlookup("settings","file_path","settings_id=1"))+"\\"+Files_file_name.Text);
      // Files Delete Event end
      Files_BeforeSQLExecute(sSQL,"Delete");
      OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        Files_ValidationSummary.Text += e.Message;
        Files_ValidationSummary.Visible = true;
        return false;
      }

      // Files AfterDelete Event begin
      // Files AfterDelete Event end
      return true;
    }

    bool Files_cancel_Click(Object Src, EventArgs E)
    {

      // Files BeforeCancel Event begin
      // Files BeforeCancel Event end

      return true;
    }

    void Files_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=Files_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=Files_delete_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("cancel")>0)
        bResult=Files_cancel_Click(Src,E);


      if(bResult)
        Response.Redirect(Files_FormAction+"issue_id=" + Server.UrlEncode(Utility.GetParam("issue_id")) + "&");
    }
    // Files Action end



  }
}
