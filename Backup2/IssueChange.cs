/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: IssueChange.cs
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
    
  using IssueManager.Mail;
  /// <summary>
  ///    Summary description for IssueChange.
  /// </summary>
  public class IssueChange : System.Web.UI.Page

  {

    //IssueChange CustomIncludes begin
    protected CCUtility Utility;

    //Record form Issue variables and controls declarations
    protected System.Web.UI.WebControls.Label Issue_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issue_issue_id;
    protected System.Web.UI.WebControls.Label Issue_issue_name;
    protected System.Web.UI.WebControls.Label Issue_issue_desc;
    protected System.Web.UI.WebControls.Label Issue_user_id;
    protected System.Web.UI.WebControls.Label Issue_date_submitted;
    protected System.Web.UI.WebControls.Label Issue_bugversion;
    protected System.Web.UI.WebControls.Label Issue_version;
    protected System.Web.UI.WebControls.Label Issue_priority_id;

    //Record form Response variables and controls declarations
    protected System.Web.UI.WebControls.Label Response_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton Response_insert;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_response_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_issue_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_user_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_date_response;
    protected System.Web.UI.WebControls.TextBox Response_response;
    protected System.Web.UI.WebControls.DropDownList Response_assigned_to;
    protected System.Web.UI.WebControls.DropDownList Response_qaassigned_to;
    protected System.Web.UI.WebControls.DropDownList Response_priority_id;
    protected System.Web.UI.WebControls.DropDownList Response_status_id;
    protected System.Web.UI.WebControls.DropDownList Response_qastatus_id;
    protected System.Web.UI.WebControls.DropDownList Response_category_id;
    protected System.Web.UI.WebControls.DropDownList Response_product_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_date_modified;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_modified_by;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Response_date_resolved;
    protected System.Web.UI.WebControls.Label Response_Field1;

    //Grid form History variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow History_no_records;
    protected string History_sSQL;
    protected string History_sCountSQL;
    protected int History_CountPage;

    protected System.Web.UI.WebControls.Repeater History_Repeater;
    protected int i_History_curpage=1;

    //Grid form Files variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Files_no_records;
    protected string Files_sSQL;
    protected string Files_sCountSQL;
    protected int Files_CountPage;

    protected System.Web.UI.WebControls.Repeater Files_Repeater;
    protected int i_Files_curpage=1;

    // For each Issue form hiddens for PK's,List of Values and Actions
    protected string Issue_FormAction="Default.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issue_issue_id;
    // For each Response form hiddens for PK's,List of Values and Actions
    protected string Response_FormAction="Default.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Response_response_id;
    // For each History form hiddens for PK's,List of Values and Actions
    protected string History_FormAction=".aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_History_response_id;
    // For each Files form hiddens for PK's,List of Values and Actions
    protected string Files_FormAction="Default.aspx?";
    protected System.Web.UI.WebControls.Label IssueForm_Title;
    protected System.Web.UI.WebControls.Label FilesForm_Title;
    protected System.Web.UI.WebControls.Label Files_Column_file_name;
    protected System.Web.UI.WebControls.Label Files_Column_uploaded_by;
    protected System.Web.UI.WebControls.Label Files_Column_date_uploaded;
    protected System.Web.UI.WebControls.Label ResponseForm_Title;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_priority_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Response_priority_id_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_product_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Response_product_id_Validator_Num;
    protected System.Web.UI.WebControls.Label HistoryForm_Title;
    protected System.Web.UI.HtmlControls.HtmlTable Issue_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Files_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Response_holder;
    protected System.Web.UI.HtmlControls.HtmlTable History_holder;
    protected System.Web.UI.WebControls.Label Issue_assigned_to_orig;
    protected System.Web.UI.WebControls.Label Issue_assigned_to;
    protected System.Web.UI.WebControls.CustomValidator Response_assigned_to_Validator_Num;
    protected System.Web.UI.WebControls.Label Issue_qaassigned_to_orig;
    protected System.Web.UI.WebControls.Label Issue_qaassigned_to;
    protected System.Web.UI.WebControls.CustomValidator Response_qaassigned_to_Validator_Num;
    protected System.Web.UI.WebControls.Label Issue_status_id;
    protected System.Web.UI.WebControls.Label Issue_qastatus_id;
    protected System.Web.UI.WebControls.Label Issue_category_id;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_status_id_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_qastatus_id_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_category_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Response_status_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Response_qastatus_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Response_category_id_Validator_Num;
    protected System.Web.UI.WebControls.DropDownList Response_version;
    protected System.Web.UI.WebControls.DropDownList Response_bugversion;
    protected System.Web.UI.WebControls.CustomValidator Response_version_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_version_Validator_Req;
    protected System.Web.UI.WebControls.Label IssueForm_issue_id;
      protected System.Web.UI.WebControls.HyperLink HyperLink2;
    protected System.Web.UI.WebControls.Label Issue_steps_to_recreate;
    protected System.Web.UI.WebControls.Label Issue_screen;
    protected System.Web.UI.WebControls.Label Issue_dev_issue_number;
    protected System.Web.UI.WebControls.Label Issue_its_number;
    protected System.Web.UI.WebControls.Label Issue_product_id;
    protected System.Web.UI.WebControls.TextBox Response_its_number;
    protected System.Web.UI.WebControls.RequiredFieldValidator Response_bugversion_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Response_bugversion_Validator_Num;
    protected System.Web.UI.WebControls.TextBox Response_dev_issue_number;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Files_file_id;


    public IssueChange()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // IssueChange CustomIncludes end
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
  // IssueChange Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // IssueChange Open Event begin
      HtmlInputFile FileUpload = new HtmlInputFile();
      Response_Field1.Controls.Add(FileUpload);
      ControlCollection myCol = this.Controls;
      for(int i=0; i<myCol.Count;i++)
      {
        if(myCol[i] is HtmlForm)
        {
          ((HtmlForm)myCol[i]).Enctype ="multipart/form-data";
        }
      }
      // IssueChange Open Event end
      //===============================

      //
      //===============================
      // IssueChange PageSecurity begin
      Utility.CheckSecurity(1);
      // IssueChange PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Issue_issue_id.Value = Utility.GetParam("Issue_id");
        HyperLink2.NavigateUrl = "UpdatedFiles.aspx?Issue_ID="+p_Issue_issue_id.Value.ToString();
        p_Response_response_id.Value = Utility.GetParam("response_id");
        p_History_response_id.Value = Utility.GetParam("response_id");
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
      this.Response_qastatus_id.SelectedIndexChanged += new System.EventHandler(this.Response_qastatus_id_SelectedIndexChanged);
      this.Response_insert.ServerClick += new System.EventHandler(this.Response_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }

    protected void Page_Show(object sender, EventArgs e)
    {
      Issue_Show();
      Response_Show();
      History_Bind();
      Files_Bind();
    }

    // IssueChange Show end

    // End of Login form

    private bool Issue_Validate()
    {
      bool result=true;
      Issue_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("Issue"))
        {
          if(!Page.Validators[i].IsValid)
          {
            Issue_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      Issue_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/

    void Issue_Show()
    {

      // Issue Show begin

      bool ActionInsert=true;

      if (p_Issue_issue_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "issue_id=" + CCUtility.ToSQL(p_Issue_issue_id.Value, CCUtility.FIELD_TYPE_Number);

        // Issue Open Event begin
        // Issue Open Event end
        string sSQL = "select * from issues where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "Issue") > 0)
        {
          row = ds.Tables[0].Rows[0];

          Issue_issue_id.Value = CCUtility.GetValue(row, "issue_id");



          IssueForm_issue_id.Text = Issue_issue_id.Value;



          Issue_issue_name.Text =Server.HtmlEncode(CCUtility.GetValue(row, "issue_name").ToString());



          Issue_issue_desc.Text =CCUtility.GetValue(row, "issue_desc");



          Issue_steps_to_recreate.Text =CCUtility.GetValue(row, "steps_to_recreate");



          Issue_screen.Text =CCUtility.GetValue(row, "screen");



          Issue_dev_issue_number.Text =CCUtility.GetValue(row, "dev_issue_number");
          Response_dev_issue_number.Text =CCUtility.GetValue(row, "dev_issue_number");


          Issue_its_number.Text =CCUtility.GetValue(row, "its_number");
          Response_its_number.Text =CCUtility.GetValue(row, "its_number");



          Issue_user_id.Text =Server.HtmlEncode(	Utility.Dlookup("users", "user_name", "user_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "user_id"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_product_id.Text =Server.HtmlEncode(	Utility.Dlookup("products", "product", "product_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "product_id"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_date_submitted.Text =Server.HtmlEncode(CCUtility.GetValue(row, "date_submitted").ToString().Replace('T', ' '));



          Issue_bugversion.Text =Server.HtmlEncode(	Utility.Dlookup("versions", "version", "version_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "bugversion"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_version.Text =Server.HtmlEncode(	Utility.Dlookup("versions", "version", "version_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "version"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_assigned_to_orig.Text =Server.HtmlEncode(	Utility.Dlookup("users", "user_name", "user_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "assigned_to_orig"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_assigned_to.Text =Server.HtmlEncode(	Utility.Dlookup("users", "user_name", "user_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "assigned_to"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_qaassigned_to_orig.Text =Server.HtmlEncode(	Utility.Dlookup("users", "user_name", "user_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "qaassigned_to_orig"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_qaassigned_to.Text =Server.HtmlEncode(	Utility.Dlookup("users", "user_name", "user_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "qaassigned_to"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_priority_id.Text =Server.HtmlEncode(	Utility.Dlookup("priorities", "priority_desc", "priority_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "priority_id"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_status_id.Text =Server.HtmlEncode(	Utility.Dlookup("statuses", "status", "status_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "status_id"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_qastatus_id.Text =Server.HtmlEncode(	Utility.Dlookup("qastatuses", "qastatus", "qastatus_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "qastatus_id"), CCUtility.FIELD_TYPE_Number)).ToString());



          Issue_category_id.Text =Server.HtmlEncode(	Utility.Dlookup("categories", "category", "category_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "category_id"), CCUtility.FIELD_TYPE_Number)).ToString());



          ActionInsert=false;

          // Issue ShowEdit Event begin
          // Issue ShowEdit Event end

        }
      }

      if(ActionInsert)
      {
        String pValue;

        pValue = Utility.GetParam("Issue_id");
        Issue_issue_id.Value = pValue;
        IssueForm_issue_id.Text = Issue_issue_id.Value;
        // Issue ShowInsert Event begin
        Issue_date_submitted.Text=DateTime.Now.ToString("g");
        // Issue ShowInsert Event end
      }

      // Issue Open Event begin
      // Issue Open Event end

      // Issue Show Event begin
      // Issue Show Event end

      // Issue Show end

      // Issue Close Event begin
      // Issue Close Event end

    }

    // Issue Action begin


    void Issue_BeforeSQLExecute(string SQL,String Action)
    {

      // Issue BeforeExecute Event begin
      // Issue BeforeExecute Event end

    }

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
      Utility.buildListBox(Response_assigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Response_qaassigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Response_priority_id.Items,"select priority_id,priority_desc from priorities order by 2","priority_id","priority_desc",null,"");
      Utility.buildListBox(Response_product_id.Items,"select product_id,product from products order by 2 desc","product_id","product",null,"");
      Utility.buildListBox(Response_status_id.Items,"select status_id,status from statuses order by 2","status_id","status",null,"");
      Utility.buildListBox(Response_qastatus_id.Items,"select qastatus_id,qastatus from qastatuses order by 2","qastatus_id","qastatus",null,"");
      Utility.buildListBox(Response_category_id.Items,"select category_id,category from categories order by 2","category_id","category",null,"");
      Utility.buildListBox(Response_version.Items,"select version_id,version from versions order by 2 DESC","version_id","version",null,"");
      Utility.buildListBox(Response_bugversion.Items,"select version_id,version from versions order by 2 DESC","version_id","version",null,"");

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

          Response_issue_id.Value = CCUtility.GetValue(row, "issue_id");

          Response_user_id.Value = CCUtility.GetValue(row, "user_id");

          Response_date_response.Value = CCUtility.GetValue(row, "date_response").Replace('T', ' ');

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
            s=CCUtility.GetValue(row, "qaassigned_to");

            try
            {
              Response_qaassigned_to.SelectedIndex=Response_qaassigned_to.Items.IndexOf(Response_qaassigned_to.Items.FindByValue(s));
            }
            catch{}
          }


          {
            string s;
            s=CCUtility.GetValue(row, "priority_id");

            try
            {
              Response_priority_id.SelectedIndex=Response_priority_id.Items.IndexOf(Response_priority_id.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "product_id");

          try
          {
            Response_product_id.SelectedIndex=Response_product_id.Items.IndexOf(Response_product_id.Items.FindByValue(s));
          }
          catch{}
        }


          {
            string s;
            s=CCUtility.GetValue(row, "status_id");

            try
            {
              Response_status_id.SelectedIndex=Response_status_id.Items.IndexOf(Response_status_id.Items.FindByValue(s));
            }
            catch{}
          }


          {
            string s;
            s=CCUtility.GetValue(row, "qastatus_id");

            try
            {
              Response_qastatus_id.SelectedIndex=Response_qastatus_id.Items.IndexOf(Response_qastatus_id.Items.FindByValue(s));
            }
            catch{}
          }


          {
            string s;
            s=CCUtility.GetValue(row, "category_id");

            try
            {
              Response_category_id.SelectedIndex=Response_category_id.Items.IndexOf(Response_category_id.Items.FindByValue(s));
            }
            catch{}
          }


          {
            string s;
            s=CCUtility.GetValue(row, "bugversion");

            try
            {
              Response_bugversion.SelectedIndex=Response_bugversion.Items.IndexOf(Response_bugversion.Items.FindByValue(s));
            }
            catch{}
          }


          {
            string s;
            s=CCUtility.GetValue(row, "version");

            try
            {
              Response_version.SelectedIndex=Response_version.Items.IndexOf(Response_version.Items.FindByValue(s));
            }
            catch{}
          }

          Response_insert.Visible=false;
          ActionInsert=false;

          // Response ShowEdit Event begin
          // Response ShowEdit Event end

        }
      }

      if(ActionInsert)
      {

        String pValue;

        pValue = Utility.GetParam("issue_id");
        Response_issue_id.Value = pValue;
        if(Session["UserID"]!=null)
          pValue = Session["UserID"].ToString();
        else
          pValue="";
        Response_user_id.Value = pValue;

        pValue = Utility.GetParam("assigned_to");
        try
        {
          Response_assigned_to.SelectedIndex=Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByValue(pValue));
        }
        catch{}

        pValue = Utility.GetParam("qaassigned_to")
                   ;
        try
        {
          Response_qaassigned_to.SelectedIndex=Response_qaassigned_to.Items.IndexOf(Response_qaassigned_to.Items.FindByValue(pValue));
        }
        catch{}

        pValue = Utility.GetParam("priority_id")
                   ;
        try
        {
          Response_priority_id.SelectedIndex=Response_priority_id.Items.IndexOf(Response_priority_id.Items.FindByValue(pValue));
        }
        catch{}

        pValue = Utility.GetParam("product_id")
          ;
        try
        {
          Response_product_id.SelectedIndex=Response_product_id.Items.IndexOf(Response_product_id.Items.FindByValue(pValue));
        }
        catch{}

        pValue = Utility.GetParam("status_id")
                   ;
        try
        {
          Response_status_id.SelectedIndex=Response_status_id.Items.IndexOf(Response_status_id.Items.FindByValue(pValue));
        }
        catch{}

        pValue = Utility.GetParam("qastatus_id")
                   ;
        try
        {
          Response_qastatus_id.SelectedIndex=Response_qastatus_id.Items.IndexOf(Response_qastatus_id.Items.FindByValue(pValue));
        }
        catch{}

        pValue = Utility.GetParam("category_id")
          ;
        try
        {
          Response_category_id.SelectedIndex=Response_category_id.Items.IndexOf(Response_category_id.Items.FindByValue(pValue));
        }
        catch{}

        // Response ShowInsert Event begin
        // Response ShowInsert Event end

      }

    // Response Open Event begin
    // Response Open Event end

    // Response Show Event begin
    {string issues_sql = "SELECT assigned_to, qaassigned_to, priority_id, product_id, status_id, qastatus_id, category_id, bugversion, version, date_resolved FROM issues where issue_id=" + Utility.GetParam("issue_id")
                             ;

        OleDbDataAdapter command1 = new OleDbDataAdapter(issues_sql, Utility.Connection);
        DataSet ds1 = new DataSet();
        command1.Fill(ds1,"Issues");
        DataRow row1 = ds1.Tables[0].Rows[0];

        string s;

        s=CCUtility.GetValue(row1, "assigned_to");
        try
        {
          Response_assigned_to.SelectedIndex=Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByValue(s));
        }
        catch{}

        s=CCUtility.GetValue(row1, "qaassigned_to");
        try
        {
          Response_qaassigned_to.SelectedIndex=Response_qaassigned_to.Items.IndexOf(Response_qaassigned_to.Items.FindByValue(s));
        }
        catch{}

        s=CCUtility.GetValue(row1, "priority_id");
        try
        {
          Response_priority_id.SelectedIndex=Response_priority_id.Items.IndexOf(Response_priority_id.Items.FindByValue(s));
        }
        catch{}

      s=CCUtility.GetValue(row1, "product_id");
      try
      {
        Response_product_id.SelectedIndex=Response_product_id.Items.IndexOf(Response_product_id.Items.FindByValue(s));
      }
      catch{}

        s=CCUtility.GetValue(row1, "status_id");
        try
        {
          Response_status_id.SelectedIndex=Response_status_id.Items.IndexOf(Response_status_id.Items.FindByValue(s));
        }
        catch{}

        s=CCUtility.GetValue(row1, "qastatus_id");
        try
        {
          Response_qastatus_id.SelectedIndex=Response_qastatus_id.Items.IndexOf(Response_qastatus_id.Items.FindByValue(s));
        }
        catch{}

        s=CCUtility.GetValue(row1, "category_id");
        try
        {
          Response_category_id.SelectedIndex=Response_category_id.Items.IndexOf(Response_category_id.Items.FindByValue(s));
        }
        catch{}

        s=CCUtility.GetValue(row1, "bugversion");
        try
        {
          Response_bugversion.SelectedIndex=Response_bugversion.Items.IndexOf(Response_bugversion.Items.FindByValue(s));
        }
        catch{}

        s=CCUtility.GetValue(row1, "version");
        try
        {
          Response_version.SelectedIndex=Response_version.Items.IndexOf(Response_version.Items.FindByValue(s));
        }
        catch{}

        Response_date_resolved.Value =CCUtility.GetValue(row1, "date_resolved").ToString().Replace('T', ' ');
        Response_date_response.Value=System.DateTime.Now.ToString("g").Replace("T"," ");

      }
      // Response Show Event end

      // Response Show end

      // Response Close Event begin
      // Response Close Event end

    }

    // Response Action begin

    bool Response_insert_Click(Object Src, EventArgs E)
    {
      string sSQL="";
      bool bResult=Response_Validate();

      // Response Check Event begin
      // Response Check Event end

      if(bResult)
      {
        string p2_issue_id=CCUtility.ToSQL(Utility.GetParam("Response_issue_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_user_id=CCUtility.ToSQL(Utility.GetParam("Response_user_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_date_response=CCUtility.ToSQL(Utility.GetParam("Response_date_response"), CCUtility.FIELD_TYPE_Date) ;
        string p2_response=CCUtility.ToSQL(Utility.GetParam("Response_response"), CCUtility.FIELD_TYPE_Text) ;
        string p2_assigned_to=CCUtility.ToSQL(Utility.GetParam("Response_assigned_to"), CCUtility.FIELD_TYPE_Number) ;
        string p2_qaassigned_to=CCUtility.ToSQL(Utility.GetParam("Response_qaassigned_to"), CCUtility.FIELD_TYPE_Number) ;
        string p2_priority_id=CCUtility.ToSQL(Utility.GetParam("Response_priority_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_product_id=CCUtility.ToSQL(Utility.GetParam("Response_product_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_status_id=CCUtility.ToSQL(Utility.GetParam("Response_status_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_qastatus_id=CCUtility.ToSQL(Utility.GetParam("Response_qastatus_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_category_id=CCUtility.ToSQL(Utility.GetParam("Response_category_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_bugversion=CCUtility.ToSQL(Utility.GetParam("Response_bugversion"), CCUtility.FIELD_TYPE_Text) ;
        string p2_version=CCUtility.ToSQL(Utility.GetParam("Response_version"), CCUtility.FIELD_TYPE_Text) ;
        string p2_dev_issue_number=CCUtility.ToSQL(Utility.GetParam("Response_dev_issue_number"), CCUtility.FIELD_TYPE_Text) ;
        string p2_its_number=CCUtility.ToSQL(Utility.GetParam("Response_its_number"), CCUtility.FIELD_TYPE_Text) ;
        // Response Insert Event begin
        {
          HttpPostedFile myFile = Request.Files[0];
          if(myFile.FileName.Length>0)
          {

            if(int.Parse(Utility.Dlookup("users","allow_upload","user_id="+Session["UserID"].ToString()))==1)
            {
              int fileIndex = myFile.FileName.LastIndexOf("\\");
              string rawName = myFile.FileName.Substring(fileIndex);
              int extIndex = rawName.LastIndexOf(".");
              string fileExt = rawName.Substring(extIndex+1);
              string[] allow = Utility.Dlookup("settings","file_extensions","settings_id=1").Split(new Char[] {','});
              bool check=false;
              for(int i=0;i<allow.Length;i++)
              {
                if(fileExt==allow[i])
                {
                  check = true;
                  break;
                }
              }
              if(!check)
              {
                Response_ValidationSummary.Text +="This file type is not allowed!You may zip the file";
                Response_ValidationSummary.Visible = true;
                return false;
              }

            }
            else
            {
              Response_ValidationSummary.Text +="You are not allowed to upload files!";
              Response_ValidationSummary.Visible = true;
              return false;
            }
          }

          //flddate_response = System.DateTime.Today.ToString("g");

          //Build issue update SQL
          string issues_sql = "UPDATE issues SET assigned_to=" + CCUtility.ToSQL(Utility.GetParam("Response_assigned_to"), CCUtility.FIELD_TYPE_Number) +
                              ", qaassigned_to=" + CCUtility.ToSQL(Utility.GetParam("Response_qaassigned_to"), CCUtility.FIELD_TYPE_Number) +
                              ", priority_id=" + CCUtility.ToSQL(Utility.GetParam("Response_priority_id"), CCUtility.FIELD_TYPE_Number) +
                              ", product_id=" + CCUtility.ToSQL(Utility.GetParam("Response_product_id"), CCUtility.FIELD_TYPE_Number) +
                              ", status_id=" + CCUtility.ToSQL(Utility.GetParam("Response_status_id"), CCUtility.FIELD_TYPE_Number) +
                              ", qastatus_id=" + CCUtility.ToSQL(Utility.GetParam("Response_qastatus_id"), CCUtility.FIELD_TYPE_Number) +
                              ", category_id=" + CCUtility.ToSQL(Utility.GetParam("Response_category_id"), CCUtility.FIELD_TYPE_Number) +
                              ", bugversion=" + CCUtility.ToSQL(Utility.GetParam("Response_bugversion"), CCUtility.FIELD_TYPE_Text) +
                              ", version=" + CCUtility.ToSQL(Utility.GetParam("Response_version"), CCUtility.FIELD_TYPE_Text) +
                              ", modified_by=" + CCUtility.ToSQL(Session["UserID"].ToString(), CCUtility.FIELD_TYPE_Text) +
                              ", dev_issue_number=" + CCUtility.ToSQL(Response_dev_issue_number.Text, CCUtility.FIELD_TYPE_Text) +
                              ", its_number=" + CCUtility.ToSQL(Response_its_number.Text, CCUtility.FIELD_TYPE_Text) +
                              ", date_modified=" + CCUtility.ToSQL(System.DateTime.Now.ToString("g").Replace('T', ' '), CCUtility.FIELD_TYPE_Date);

          //If Closed
          if(Utility.Dlookup("statuses","status","status_id=" + CCUtility.ToSQL(Utility.GetParam("Response_status_id"), CCUtility.FIELD_TYPE_Number)) == "Closed")
            issues_sql += ", date_resolved=" + CCUtility.ToSQL(System.DateTime.Now.ToString("g").Replace('T', ' '), CCUtility.FIELD_TYPE_Date);
          //Complete SQL with WHERE
          issues_sql += " WHERE issue_id=" + CCUtility.ToSQL(Utility.GetParam("Response_issue_id"), CCUtility.FIELD_TYPE_Number);
          //Execute SQL
          OleDbCommand cmd1 = new OleDbCommand(issues_sql, Utility.Connection);
          try
          {
            cmd1.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            Response_ValidationSummary.Text += e.Message;
            Response_ValidationSummary.Visible = true;
            return false;
          }}
        // Response Insert Event end

        sSQL = "insert into responses (" +
               "issue_id," +
               "user_id," +
               "date_response," +
               "response," +
               "assigned_to," +
               "qaassigned_to," +
               "priority_id," +
               "product_id," +
               "dev_issue_number," +
               "its_number," +
               "status_id," +
               "qastatus_id," +
               "category_id," +
               "bugversion," +
               "version)" +
               " values (" +
               p2_issue_id + "," +
               p2_user_id + "," +
               p2_date_response + "," +
               p2_response + "," +
               p2_assigned_to + "," +
               p2_qaassigned_to + "," +
               p2_priority_id + "," +
               p2_product_id + "," +
               p2_dev_issue_number + "," +
               p2_its_number + "," +
               p2_status_id + "," +
               p2_qastatus_id + "," +
               p2_category_id + "," +
               p2_bugversion + "," +
               p2_version + ")";
        Response_BeforeSQLExecute(sSQL,"Insert");
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

        // Response AfterInsert Event begin
        string curUserName =Utility.Dlookup("users","user_name","user_id=" + Session["UserID"]);

        if(Request.Files.Count>0)
        {
          HttpPostedFile myFile = Request.Files[0];
          if(myFile.FileName.Length>0)
          {
            int fileIndex = myFile.FileName.LastIndexOf("\\");
            string rawName = myFile.FileName.Substring(fileIndex);
            int extIndex = rawName.IndexOf(".");
            string fileExt = rawName.Substring(extIndex);
            string newName = System.Guid.NewGuid().ToString()+fileExt;
            string fileSQL = "INSERT INTO files (file_name,issue_id,date_uploaded,uploaded_by) VALUES(";
            fileSQL+=CCUtility.ToSQL(newName, CCUtility.FIELD_TYPE_Text)+"," ;
            fileSQL+=CCUtility.ToSQL(p_Issue_issue_id.Value,CCUtility.FIELD_TYPE_Number)+"," ;
            fileSQL+=CCUtility.ToSQL(System.DateTime.Now.ToString("g").Replace("T"," "), CCUtility.FIELD_TYPE_Date)+"," ;
            fileSQL+=CCUtility.ToSQL(Session["UserID"].ToString(),CCUtility.FIELD_TYPE_Number)+")" ;
            OleDbCommand fileCmd = new OleDbCommand(fileSQL, Utility.Connection);
            try
            {
              myFile.SaveAs(Server.MapPath(Utility.Dlookup("settings","file_path","settings_id=1"))+"\\"+newName);
              fileCmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
              Response_ValidationSummary.Text += e.Message;
              Response_ValidationSummary.Visible = true;
              return false;
            }
          }
        }

        //create a new Postman object to manage and send email notification
        Postman post = new Postman(ref Utility);
        
        //add a message to the original user
        if(Issue_user_id.Text!=curUserName&&Int32.Parse(Utility.Dlookup("users","notify_original","user_name='" + Issue_user_id.Text +"'"))==1)
        {
          EmailMessage msg = new EmailMessage(Issue_user_id.Text,Utility.Dlookup("settings","notify_change_from","settings_id=1"),
            Utility.Dlookup("settings","notify_change_body","settings_id=1"),Utility.Dlookup("settings","notify_change_subject","settings_id=1"));
          //set the message body
          msg.SetBodyElement("issue_receiver",Issue_user_id.Text);
          //set the message subject
          msg.SetSubjectElement("issue_no",Issue_issue_id.Value);
          msg.SetSubjectElement("issue_receiver",Issue_user_id.Text );
          InitMailMessage(ref msg,curUserName);
          //add the message to the postman
          post.AddMessage(msg,false);
        }
        //add message to the person this issue is assigned to
        if(Issue_assigned_to.Text!=curUserName&& Int32.Parse(Utility.Dlookup("users","notify_reassignment","user_name='" + Issue_assigned_to.Text+"'"))==1)
        {
          EmailMessage msg = new EmailMessage(Issue_assigned_to.Text,Utility.Dlookup("settings","notify_change_from","settings_id=1"),
            Utility.Dlookup("settings","notify_change_body","settings_id=1"),Utility.Dlookup("settings","notify_change_subject","settings_id=1"));
          //set the message body
          msg.SetBodyElement("issue_receiver",Issue_assigned_to.Text);
          msg.SetSubjectElement("issue_receiver",Issue_assigned_to.Text );
          InitMailMessage(ref msg,curUserName);          
          //add the message to the postman
          post.AddMessage(msg,false);
        }
        //add response message
        if(Issue_assigned_to.Text!=Response_assigned_to.SelectedItem.Text&& Int32.Parse(Utility.Dlookup("users","notify_new","user_name='" + Response_assigned_to.SelectedItem.Text+"'"))==1)
        {
          EmailMessage msg = new EmailMessage(Response_assigned_to.SelectedItem.Text,Utility.Dlookup("settings","notify_change_from","settings_id=1"),
            Utility.Dlookup("settings","notify_change_body","settings_id=1"),Utility.Dlookup("settings","notify_change_subject","settings_id=1"));
          //set the message body
          msg.SetBodyElement("issue_receiver",Response_assigned_to.SelectedItem.Text);
          msg.SetSubjectElement("issue_receiver",Response_assigned_to.SelectedItem.Text );
          InitMailMessage(ref msg,curUserName);          
          //add the message to the postman
          post.AddMessage(msg,false);
        }

        //add message to assigned QA person
        if(Issue_qaassigned_to.Text!=curUserName&& Int32.Parse(Utility.Dlookup("users","notify_reassignment","user_name='" + Issue_qaassigned_to.Text+"'"))==1)
        {
          EmailMessage msg = new EmailMessage(Issue_qaassigned_to.Text,Utility.Dlookup("settings","notify_change_from","settings_id=1"),
            Utility.Dlookup("settings","notify_change_body","settings_id=1"),Utility.Dlookup("settings","notify_change_subject","settings_id=1"));
          //set the message body
          msg.SetBodyElement("issue_receiver",Issue_qaassigned_to.Text);
          msg.SetSubjectElement("issue_receiver",Issue_qaassigned_to.Text );
          InitMailMessage(ref msg,curUserName);          
          //add the message to the postman
          post.AddMessage(msg,false);
        }

        //add message to notify of QA response
        if(Issue_qaassigned_to.Text!=Response_qaassigned_to.SelectedItem.Text&& Int32.Parse(Utility.Dlookup("users","notify_new","user_name='" + Response_qaassigned_to.SelectedItem.Text+"'"))==1)
        {
          EmailMessage msg = new EmailMessage(Issue_qaassigned_to.Text,Utility.Dlookup("settings","notify_change_from","settings_id=1"),
            Utility.Dlookup("settings","notify_change_body","settings_id=1"),Utility.Dlookup("settings","notify_change_subject","settings_id=1"));
          //set the message body
          msg.SetBodyElement("issue_receiver",Response_qaassigned_to.SelectedItem.Text);
          msg.SetSubjectElement("issue_receiver",Response_qaassigned_to.SelectedItem.Text );
          InitMailMessage(ref msg,curUserName); 
          //add the message to the postman
          post.AddMessage(msg,false);
        }

        //send any initialized e-mail messages
        post.DeliverMail();
        // Response AfterInsert Event end
      }
      return bResult;
    }

    void Response_BeforeSQLExecute(string SQL,String Action)
    {

      // Response BeforeExecute Event begin
      // Response BeforeExecute Event end

    }

    void Response_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("insert")>0)
        bResult=Response_insert_Click(Src,E);

      if(bResult)
        Response.Redirect(Response_FormAction+"assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) + "&issue_id=" + Server.UrlEncode(Utility.GetParam("issue_id")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&status_id=" + Server.UrlEncode(Utility.GetParam("status_id")) + "&qastatus_id=" + Server.UrlEncode(Utility.GetParam("qastatus_id")) + "&category_id=" + Server.UrlEncode(Utility.GetParam("category_id")) + "&version_id=" + Server.UrlEncode(Utility.GetParam("version_id")) + "&");
    }
    // Response Action end


    // End of Login form

    const int History_PAGENUM = 0;

    public void History_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // History Show Event begin
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        ((Label)e.Item.FindControl("History_response")).Text.Replace("\r\n","<br>");
      }
      // History Show Event end
    }
    public void History_Open(ref string sWhere, ref string sOrder)
    {

      // History Open Event begin
      //Don't Display if no records
      DataSet dsTemp=new DataSet();
      if(Utility.FillDataSet(History_sSQL + sWhere + sOrder,ref dsTemp,0,1)>0)
        ((HtmlTable)Page.FindControl("History_holder")).Visible=true;
      else
        ((HtmlTable)Page.FindControl("History_holder")).Visible=false;
      // History Open Event end
    }

    ICollection History_CreateDataSource()
    {
      // History Show begin
      History_sSQL = "";
      History_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool bReq = true;
      bool HasParam = false;


      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by r.date_response Desc";
      //-------------------------------
      // Build WHERE statement
      //-------------------------------
      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();

      if(!Params.ContainsKey("issue_id"))
      {
        string temp=Utility.GetParam("issue_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
        }
        else
        {
          temp = "";
        }
        Params.Add("issue_id",temp);
      }

      if (Params["issue_id"].Length>0)
      {
        HasParam = true;
        sWhere +="r.[issue_id]=" + Params["issue_id"];
      }
      else
      {
        bReq = false;
      }

      if(HasParam)
        sWhere = " AND (" + sWhere + ")";

      //-------------------------------
      // Build base SQL statement
      //-------------------------------

      History_sSQL = "select [r].[assigned_to] as r_assigned_to, " +
                     "[r].[qaassigned_to] as r_qaassigned_to, " +
                     "[r].[date_response] as r_date_response, " +
                     "[r].[issue_id] as r_issue_id, " +
                     "[r].[priority_id] as r_priority_id, " +
                     "[r].[response] as r_response, " +
                     "[r].[response_id] as r_response_id, " +
                     "[r].[status_id] as r_status_id, " +
                     "[r].[qastatus_id] as r_qastatus_id, " +
                     "[r].[category_id] as r_category_id, " +
                     "[r].[user_id] as r_user_id, " +
                     "[u].[user_id] as u_user_id, " +
                     "[u].[user_name] as u_user_name, " +
                     "[u1].[user_id] as u1_user_id, " +
                     "[u1].[user_name] as u1_user_name, " +
                     "[u2].[user_id] as u2_user_id, " +
                     "[u2].[user_name] as u2_user_name, " +
                     "[p].[priority_id] as p_priority_id, " +
                     "[p].[priority_desc] as p_priority_desc, " +
                     "[s].[status_id] as s_status_id, " +
                     "[s].[status] as s_status, " +
                     "[qs].[qastatus_id] as qs_qastatus_id, " +
                     "[qs].[qastatus] as qs_qastatus, " +
                     "[c].[category_id] as c_category_id, " +
                     "[c].[category] as c_category " +
                     " from [responses] r, [users] u, [users] u1, [users] u2, [priorities] p, [statuses] s, [qastatuses] qs, [categories] c" +
                     " where [u].[user_id]=r.[user_id] and [u1].[user_id]=r.[assigned_to] and [u2].[user_id]=r.[qaassigned_to]" +
                     " and [p].[priority_id]=r.[priority_id] and [s].[status_id]=r.[status_id] and [qs].[qastatus_id]=r.[qastatus_id]" +
                     " and [c].[category_id]=r.[category_id]  ";
      //-------------------------------
      //-------------------------------
      History_Open(ref sWhere, ref sOrder);
      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------

      History_sSQL = History_sSQL + sWhere + sOrder;
      //-------------------------------

      if(!bReq)
      {
        History_no_records.Visible = true;

        return null;
      }
      OleDbDataAdapter command = new OleDbDataAdapter(History_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, History_PAGENUM, "History");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        History_no_records.Visible = true;
      }
      else
      {
        History_no_records.Visible = false;
      }


      return Source;
      // History Show end

    }


    void History_Bind()
    {
      History_Repeater.DataSource = History_CreateDataSource();
      History_Repeater.DataBind();

    }


    // End of Login form








    const int Files_PAGENUM = 20;




    public void Files_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Files Show Event begin
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        if(e.Item.HasControls())
        {
          HyperLink fileLink =(HyperLink)e.Item.FindControl("Files_file_name");
          fileLink.NavigateUrl =Utility.Dlookup("settings","file_path","settings_id=1")+"/"+fileLink.NavigateUrl;
        }
      }
      // Files Show Event end
    }


    ICollection Files_CreateDataSource()
    {


      // Files Show begin
      Files_sSQL = "";
      Files_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool HasParam = false;


      //-------------------------------
      // Build WHERE statement
      //-------------------------------
      System.Collections.Specialized.StringDictionary Params =new System.Collections.Specialized.StringDictionary();


      if(!Params.ContainsKey("issue_id"))
      {
        string temp=Utility.GetParam("issue_id");
        if (Utility.IsNumeric(null,temp) && temp.Length>0)
        {
          temp = CCUtility.ToSQL(temp, CCUtility.FIELD_TYPE_Number);
        }
        else
        {
          temp = "";
        }
        Params.Add("issue_id",temp);
      }

      if (Params["issue_id"].Length>0)
      {
        HasParam = true;
        sWhere +="f.[issue_id]=" + Params["issue_id"];
      }


      if(HasParam)
        sWhere = " AND (" + sWhere + ")";

      //-------------------------------
      // Build base SQL statement
      //-------------------------------


      Files_sSQL = "select [f].[date_uploaded] as f_date_uploaded, " +
                   "[f].[file_id] as f_file_id, " +
                   "[f].[file_name] as f_file_name, " +
                   "[f].[issue_id] as f_issue_id, " +
                   "[f].[uploaded_by] as f_uploaded_by, " +
                   "[u].[user_id] as u_user_id, " +
                   "[u].[user_name] as u_user_name " +
                   " from [files] f, [users] u" +
                   " where [u].[user_id]=f.[uploaded_by]  ";

      //-------------------------------
      //-------------------------------

      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------



      Files_sSQL = Files_sSQL + sWhere + sOrder;
      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Files_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, Files_PAGENUM, "Files");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Files_no_records.Visible = true;
      }
      else
      {
        Files_no_records.Visible = false;
      }


      return Source;
      // Files Show end

    }


    void Files_Bind()
    {
      Files_Repeater.DataSource = Files_CreateDataSource();
      Files_Repeater.DataBind();

    }

    /// <summary>
    /// initialize common element in all email messages
    /// </summary>
    /// <param name="msg">ref to an EmailMessage object</param>
    /// <param name="sCurrentName">name of the person who is submitting the change</param>
    void InitMailMessage(ref EmailMessage msg,string sCurrentName)
    {
      msg.SetBodyElement("issue_no",Issue_issue_id.Value);
      msg.SetBodyElement("issue_title",Issue_issue_name.Text);
      msg.SetBodyElement("issue_url","<a href='http://"+Request.Url.Host+Request.ApplicationPath+"/IssueChange.aspx?issue_id="+Issue_issue_id.Value+"'target=\"_blank\">here</a>");
      msg.SetBodyElement("issue_poster",sCurrentName);
      msg.SetSubjectElement("issue_no",Issue_issue_id.Value);
      msg.SetSubjectElement("issue_title",Issue_issue_name.Text);
      msg.SetSubjectElement("issue_poster",sCurrentName);
    }

    protected void Response_qastatus_id_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if(Response_qastatus_id.SelectedItem.Text == "Waiting on Steve")
      {
        Response_assigned_to.SelectedIndex = Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByText("Steve Sarowitz"));
      }
      else if(Response_qastatus_id.SelectedItem.Text == "In Development") 
      {
        Response_assigned_to.SelectedIndex = Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByText("Diane Sielepkowski"));
      }
      else if(Response_qastatus_id.SelectedItem.Text == "Retest") 
      {
        Response_assigned_to.SelectedIndex=Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByValue(Session["UserID"].ToString()));
      }
      else if(Response_qastatus_id.SelectedItem.Text == "Failed") 
      {
        Response_assigned_to.SelectedIndex = Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByText("Diane Sielepkowski"));
      }
      else if(Response_qastatus_id.SelectedItem.Text == "New") 
      {
        Response_assigned_to.SelectedIndex=Response_assigned_to.Items.IndexOf(Response_assigned_to.Items.FindByValue(Session["Supervisor"].ToString()));
      }
    }
  }
}
