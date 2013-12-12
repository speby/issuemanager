/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: IssueNew.cs
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
  ///    Summary description for IssueNew.
  /// </summary>
  public class IssueNew : System.Web.UI.Page

  {

    //IssueNew CustomIncludes begin
    protected CCUtility Utility;

    //Record form Issues variables and controls declarations
    protected System.Web.UI.WebControls.Label Issues_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton Issues_insert;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issues_issue_id;
    protected System.Web.UI.WebControls.TextBox Issues_issue_name;
    protected System.Web.UI.WebControls.TextBox Issues_issue_desc;
    protected System.Web.UI.WebControls.DropDownList Issues_priority_id;
    protected System.Web.UI.WebControls.DropDownList Issues_status_id;
    protected System.Web.UI.WebControls.DropDownList Issues_qastatus_id;
    protected System.Web.UI.WebControls.DropDownList Issues_category_id;
    protected System.Web.UI.WebControls.DropDownList Issues_bugversion;
    protected System.Web.UI.WebControls.DropDownList Issues_version;
    protected System.Web.UI.WebControls.DropDownList Issues_assigned_to;
    protected System.Web.UI.WebControls.DropDownList Issues_qaassigned_to;
    protected System.Web.UI.WebControls.Label Issues_submitted_by_l;
    protected System.Web.UI.WebControls.Label Issues_date_submitted_l;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issues_date_submitted;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issues_submitted_by;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issues_date_modified;
    protected System.Web.UI.WebControls.Label Issues_Field1;

    // For each Issues form hiddens for PK's,List of Values and Actions
    protected string Issues_FormAction="Default.aspx?";
    protected System.Web.UI.WebControls.Label IssuesForm_Title;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_issue_name_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_priority_id_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_status_id_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_qastatus_id_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_category_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Issues_priority_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issues_status_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issues_qastatus_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issues_category_id_Validator_Num;
    protected System.Web.UI.HtmlControls.HtmlTable Issues_holder;
    protected System.Web.UI.WebControls.CustomValidator Issues_assigned_to_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issues_qaassigned_to_Validator_Num;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issues_assigned_to_orig;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issues_qaassigned_to_orig;
    protected System.Web.UI.WebControls.TextBox Issues_steps_to_recreate;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_issue_desc_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_steps_to_recreate_Validator_Req;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issues_screen_Validator_Req;
    protected System.Web.UI.WebControls.TextBox Issues_screen;
    protected System.Web.UI.WebControls.TextBox Issues_dev_number;
    protected System.Web.UI.WebControls.TextBox Issues_its_number;
    protected System.Web.UI.WebControls.DropDownList Issues_product_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issues_issue_id;

    public IssueNew()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // IssueNew CustomIncludes end
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
  // IssueNew Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // IssueNew Open Event begin
      HtmlInputFile FileUpload = new HtmlInputFile();
      Issues_Field1.Controls.Add(FileUpload);
      ControlCollection myCol = this.Controls;
      for(int i=0; i<myCol.Count;i++)
      {
        if(myCol[i] is HtmlForm)
        {
          ((HtmlForm)myCol[i]).Enctype ="multipart/form-data";
        }
      }
      // IssueNew Open Event end
      //===============================

      //
      //===============================
      // IssueNew PageSecurity begin
      Utility.CheckSecurity(1);
      // IssueNew PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Issues_issue_id.Value = Utility.GetParam("issue_id");
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
      this.Issues_qastatus_id.SelectedIndexChanged += new System.EventHandler(this.Issues_qastatus_id_SelectedIndexChanged);
      this.Issues_issue_id.ServerChange += new System.EventHandler(this.Issues_issue_id_ServerChange);
      this.Issues_insert.ServerClick += new System.EventHandler(this.Issues_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }

    protected void Page_Show(object sender, EventArgs e)
    {
      Issues_Show();

    }

    // IssueNew Show end

    // End of Login form

    private bool Issues_Validate()
    {
      bool result=true;
      Issues_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("Issues"))
        {
          if(!Page.Validators[i].IsValid)
          {
            Issues_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      Issues_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/

    void Issues_Show()
    {

      // Issues Show begin
      Utility.buildListBox(Issues_priority_id.Items,"select priority_id,priority_desc from priorities order by 1","priority_id","priority_desc",null,"");
      Utility.buildListBox(Issues_status_id.Items,"select status_id,status from statuses order by 1","status_id","status",null,"");
      Utility.buildListBox(Issues_qastatus_id.Items,"select qastatus_id,qastatus from qastatuses order by 1","qastatus_id","qastatus",null,"");
      Utility.buildListBox(Issues_category_id.Items,"select category_id,category from categories order by 1","category_id","category",null,"");
      Utility.buildListBox(Issues_bugversion.Items,"select version_id,version from versions order by 2","version_id","version",null,"");
      Utility.buildListBox(Issues_version.Items,"select version_id,version from versions order by 2","version_id","version",null,"");
      Utility.buildListBox(Issues_assigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Issues_qaassigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Issues_product_id.Items,"select product_id,product from products order by 2 desc","product_id","product",null,"");
      Issues_priority_id.SelectedIndex=Issues_priority_id.Items.IndexOf(Issues_priority_id.Items.FindByValue("7"));
      Issues_status_id.SelectedIndex=Issues_status_id.Items.IndexOf(Issues_status_id.Items.FindByValue("1"));
      Issues_qastatus_id.SelectedIndex=Issues_qastatus_id.Items.IndexOf(Issues_qastatus_id.Items.FindByValue("1"));
      Issues_category_id.SelectedIndex=Issues_category_id.Items.IndexOf(Issues_category_id.Items.FindByValue("1"));
      Issues_assigned_to.SelectedIndex=Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByValue(Session["Supervisor"].ToString()));
      Issues_qaassigned_to.SelectedIndex=Issues_qaassigned_to.Items.IndexOf(Issues_qaassigned_to.Items.FindByValue(Session["UserID"].ToString()));

      bool ActionInsert=true;

      if (p_Issues_issue_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "issue_id=" + CCUtility.ToSQL(p_Issues_issue_id.Value, CCUtility.FIELD_TYPE_Number);

        // Issues Open Event begin
        // Issues Open Event end
        string sSQL = "select * from issues where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "Issues") > 0)
        {
          row = ds.Tables[0].Rows[0];

          Issues_issue_id.Value = CCUtility.GetValue(row, "issue_id");

          Issues_issue_name.Text = CCUtility.GetValue(row, "issue_name");
          Issues_issue_desc.Text = CCUtility.GetValue(row, "issue_desc");
          Issues_steps_to_recreate.Text = CCUtility.GetValue(row, "steps_to_recreate");
          Issues_screen.Text = CCUtility.GetValue(row, "steps_screen");
          Issues_dev_number.Text = CCUtility.GetValue(row, "dev_issue_number");
          Issues_its_number.Text = CCUtility.GetValue(row, "its_number");

          {
            string s;
            s=CCUtility.GetValue(row, "priority_id");
            if(s.Length==0)
              s= "3";
            try {
              Issues_priority_id.SelectedIndex=Issues_priority_id.Items.IndexOf(Issues_priority_id.Items.FindByValue(s));
            }
            catch{}
          }

          {
            string s;
            s=CCUtility.GetValue(row, "status_id");
            if(s.Length==0)
              s= "1";
            try {
              Issues_status_id.SelectedIndex=Issues_status_id.Items.IndexOf(Issues_status_id.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "product_id");
          if(s.Length==0)
            s= "1";
          try 
          {
            Issues_product_id.SelectedIndex=Issues_product_id.Items.IndexOf(Issues_product_id.Items.FindByValue(s));
          }
          catch{}
        }

          {
            string s;
            s=CCUtility.GetValue(row, "qastatus_id");
            if(s.Length==0)
              s= "1";
            try {
              Issues_qastatus_id.SelectedIndex=Issues_qastatus_id.Items.IndexOf(Issues_qastatus_id.Items.FindByValue(s));
            }
            catch{}
          }

          {
            string s;
            s=CCUtility.GetValue(row, "category_id");
            if(s.Length==0)
              s= "1";
            try {
              Issues_category_id.SelectedIndex=Issues_category_id.Items.IndexOf(Issues_category_id.Items.FindByValue(s));
            }
            catch{}
          }

          {
            string s;
            s=CCUtility.GetValue(row, "bugversion");
            if(s.Length==0)
              s= "1";
            try
            {
              Issues_bugversion.SelectedIndex=Issues_bugversion.Items.IndexOf(Issues_bugversion.Items.FindByValue(s));
            }
            catch{}
          }

          {
            string s;
            s=CCUtility.GetValue(row, "version");
            if(s.Length==0)
              s= "1";
            try
            {
              Issues_version.SelectedIndex=Issues_version.Items.IndexOf(Issues_version.Items.FindByValue(s));
            }
            catch{}
          }

          {
            string s;
            s=CCUtility.GetValue(row, "assigned_to");

            try
            {
              Issues_assigned_to.SelectedIndex=Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByValue(s));
            }
            catch{}
          }

          {
            string s;
            s=CCUtility.GetValue(row, "qaassigned_to");

            try
            {
              Issues_qaassigned_to.SelectedIndex=Issues_qaassigned_to.Items.IndexOf(Issues_qaassigned_to.Items.FindByValue(s));
            }
            catch{}
          }

          Issues_submitted_by_l.Text =Server.HtmlEncode(	Utility.Dlookup("users", "user_name", "user_id=" + CCUtility.ToSQL(CCUtility.GetValue(row, "user_id"), CCUtility.FIELD_TYPE_Number)).ToString());

          Issues_date_submitted_l.Text =Server.HtmlEncode(CCUtility.GetValue(row, "date_submitted").ToString().Replace('T', ' '));

          Issues_date_submitted.Value = CCUtility.GetValue(row, "date_submitted").Replace('T', ' ');

          Issues_submitted_by.Value = CCUtility.GetValue(row, "user_id");

          Issues_date_modified.Value = CCUtility.GetValue(row, "date_modified").Replace('T', ' ');

          Issues_assigned_to_orig.Value = CCUtility.GetValue(row, "assigned_to_orig");

          Issues_qaassigned_to_orig.Value = CCUtility.GetValue(row, "qaassigned_to_orig");

          Issues_insert.Visible=false;
          ActionInsert=false;

          // Issues ShowEdit Event begin
          // Issues ShowEdit Event end

        }
      }
      else
      {
        try
        {
          Issues_bugversion.SelectedIndex = Issues_bugversion.Items.IndexOf(Issues_bugversion.Items.FindByText("Awaiting Approval")) + 1;
          //Issues_version.SelectedIndex = Issues_version.Items.IndexOf(Issues_version.Items.FindByText("Not Released Yet"));
        }
        catch{}
      }
      

      if(ActionInsert)
      {

        String pValue;

        pValue = Utility.GetParam("issue_id");
        Issues_issue_id.Value = pValue;
        if(Session["UserID"]!=null)
          pValue = Session["UserID"].ToString();
        else
          pValue="";
        if (pValue.Length>0)
        {
          Issues_submitted_by_l.Text = Utility.Dlookup("users", "user_name", "user_id=" + pValue);
        }
        if(Session["UserID"]!=null)
          pValue = Session["UserID"].ToString();
        else
          pValue="";
        Issues_submitted_by.Value = pValue;
        // Issues ShowInsert Event begin
        // Issues ShowInsert Event end

      }

      // Issues Open Event begin
      // Issues Open Event end

      // Issues Show Event begin
      Issues_date_submitted.Value=DateTime.Now.ToString("g").Replace("T"," ");
      Issues_date_submitted_l.Text=DateTime.Now.ToString("g").Replace("T"," ");
      Issues_submitted_by_l.Text = Utility.Dlookup("users","user_name","user_id=" + Issues_submitted_by.Value);
      Issues_date_modified.Value = System.DateTime.Now.ToString("g");
      // Issues Show Event end

      // Issues Show end

      // Issues Close Event begin
      // Issues Close Event end

    }

    // Issues Action begin

    bool Issues_insert_Click(Object Src, EventArgs E)
    {
      string sSQL="";
      bool bResult=Issues_Validate();

      // Issues Check Event begin
      // Issues Check Event end

      if(bResult)
      {

        string p2_issue_name=CCUtility.ToSQL(Utility.GetParam("Issues_issue_name"), CCUtility.FIELD_TYPE_Text) ;
        string p2_issue_desc=CCUtility.ToSQL(Utility.GetParam("Issues_issue_desc"), CCUtility.FIELD_TYPE_Text) ;
        string p2_issue_steps_to_recreate=CCUtility.ToSQL(Utility.GetParam("Issues_steps_to_recreate"), CCUtility.FIELD_TYPE_Text) ;
        string p2_issue_screen=CCUtility.ToSQL(Utility.GetParam("Issues_screen"), CCUtility.FIELD_TYPE_Text) ;
        string p2_issue_dev_number=CCUtility.ToSQL(Utility.GetParam("Issues_dev_number"), CCUtility.FIELD_TYPE_Text) ;
        string p2_issue_its_number=CCUtility.ToSQL(Utility.GetParam("Issues_its_number"), CCUtility.FIELD_TYPE_Text) ;
        string p2_priority_id=CCUtility.ToSQL(Utility.GetParam("Issues_priority_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_status_id=CCUtility.ToSQL(Utility.GetParam("Issues_status_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_product_id=CCUtility.ToSQL(Utility.GetParam("Issues_product_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_qastatus_id=CCUtility.ToSQL(Utility.GetParam("Issues_qastatus_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_category_id=CCUtility.ToSQL(Utility.GetParam("Issues_category_id"), CCUtility.FIELD_TYPE_Number) ;
        string p2_bugversion=CCUtility.ToSQL(Utility.GetParam("Issues_bugversion"), CCUtility.FIELD_TYPE_Text) ;
        string p2_version=CCUtility.ToSQL(Utility.GetParam("Issues_version"), CCUtility.FIELD_TYPE_Text) ;
        string p2_assigned_to=CCUtility.ToSQL(Utility.GetParam("Issues_assigned_to"), CCUtility.FIELD_TYPE_Number) ;
        string p2_qaassigned_to=CCUtility.ToSQL(Utility.GetParam("Issues_qaassigned_to"), CCUtility.FIELD_TYPE_Number) ;
        string p2_date_submitted=CCUtility.ToSQL(Utility.GetParam("Issues_date_submitted"), CCUtility.FIELD_TYPE_Date) ;
        string p2_submitted_by=CCUtility.ToSQL(Utility.GetParam("Issues_submitted_by"), CCUtility.FIELD_TYPE_Number) ;
        string p2_date_modified=CCUtility.ToSQL(Utility.GetParam("Issues_date_modified"), CCUtility.FIELD_TYPE_Date) ;
        string p2_assigned_to_orig=CCUtility.ToSQL(Utility.GetParam("Issues_assigned_to_orig"), CCUtility.FIELD_TYPE_Number) ;
        string p2_qaassigned_to_orig=CCUtility.ToSQL(Utility.GetParam("Issues_qaassigned_to_orig"), CCUtility.FIELD_TYPE_Number) ;
        // Issues Insert Event begin
        p2_assigned_to_orig = p2_assigned_to;
        p2_qaassigned_to_orig = p2_qaassigned_to;
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
              string[] allow = Utility.Dlookup("settings","file_extensions","settings_id=1").Split(new char[]{','});
              bool check =false;
              for(int i=0;i<allow.Length;i++)
              {
                if(fileExt==allow[i])
                {
                  check=true;
                  break;
                }

              }
              if(!check)
              {
                Issues_ValidationSummary.Text +="This file type is not allowed!You may zip the file";
                Issues_ValidationSummary.Visible = true;
                return false;
              }
            }
            else
            {
              Issues_ValidationSummary.Text +="You are not allowed to upload files!";
              Issues_ValidationSummary.Visible = true;
              return false;
            }
          }
        }
        // Issues Insert Event end

        sSQL = "insert into issues (" +
               "issue_name," +
               "issue_desc," +
               "priority_id," +
               "status_id," +
               "qastatus_id," +
               "category_id," +
               "bugversion," +
               "version," +
               "assigned_to," +
               "qaassigned_to," +
               "date_submitted," +
               "user_id," +
               "date_modified," +
               "modified_by," +
               "assigned_to_orig," +
               "qaassigned_to_orig," +
               "steps_to_recreate," +
               "screen," +
               "dev_issue_number," +
               "its_number," +
               "product_id)" +
               " values (" +
               p2_issue_name + "," +
               p2_issue_desc + "," +
               p2_priority_id + "," +
               p2_status_id + "," +
               p2_qastatus_id + "," +
               p2_category_id + "," +
               p2_bugversion + "," +
               p2_version + "," +
               p2_assigned_to + "," +
               p2_qaassigned_to + "," +
               p2_date_submitted + "," +
               p2_submitted_by + "," +
               p2_date_modified + "," +
               p2_submitted_by + "," +
               p2_assigned_to_orig + "," +
               p2_qaassigned_to_orig + "," +
               p2_issue_steps_to_recreate + "," +
               p2_issue_screen + "," +
               p2_issue_dev_number + "," +
               p2_issue_its_number + "," +
               p2_product_id + ")";
        Issues_BeforeSQLExecute(sSQL,"Insert");
        OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
        try
        {
          cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
          Issues_ValidationSummary.Text += e.Message;
          Issues_ValidationSummary.Visible = true;
          return false;
        }

        // Issues AfterInsert Event begin
        string issueNumber = Utility.Dlookup("issues","max(issue_id)","user_id=" +Session["UserID"].ToString());

        if(Request.Files.Count>0)
        {
          HttpPostedFile myFile = Request.Files[0];
          if(myFile!=null&&myFile.FileName.Length>0)
          {
            int fileIndex = myFile.FileName.LastIndexOf("\\");
            string rawName = myFile.FileName.Substring(fileIndex);
            int extIndex = rawName.IndexOf(".");
            string fileExt = rawName.Substring(extIndex);
            string newName = System.Guid.NewGuid().ToString()+fileExt;
            string fileSQL = "INSERT INTO files (file_name,issue_id,date_uploaded,uploaded_by) VALUES(";
            fileSQL+=CCUtility.ToSQL(newName, CCUtility.FIELD_TYPE_Text)+"," ;
            fileSQL+=CCUtility.ToSQL(issueNumber,CCUtility.FIELD_TYPE_Number)+"," ;
            fileSQL+=CCUtility.ToSQL(System.DateTime.Now.ToString("g").Replace("T"," "), CCUtility.FIELD_TYPE_Date)+"," ;
            fileSQL+=CCUtility.ToSQL(Session["UserID"].ToString(),CCUtility.FIELD_TYPE_Number)+")" ;
            OleDbCommand fileCmd = new OleDbCommand(fileSQL, Utility.Connection);
            try
            {
              myFile.SaveAs(Server.MapPath(Utility.Dlookup("settings","file_path","settings_id=1"))+ "\\"+newName);
              fileCmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
              Issues_ValidationSummary.Text += e.Message;
              Issues_ValidationSummary.Visible = true;
              return false;
            }
          }
        }

        //create a new postman object
        Postman post = new Postman(ref Utility);

        //create a new issue mail notification to notify the Developer this issue is assigned to
        if(Int32.Parse(Utility.Dlookup("users","notify_new","user_name='" + Issues_assigned_to.SelectedItem.Text+"'"))==1)
        {
          EmailMessage msg = new EmailMessage(Issues_assigned_to.SelectedItem.Text,
            Utility.Dlookup("settings","notify_new_from","settings_id=1"),
            Utility.Dlookup("settings","notify_new_body","settings_id=1"),
            Utility.Dlookup("settings","notify_new_subject","settings_id=1"));

          msg.SetBodyElement("issue_receiver",Issues_assigned_to.SelectedItem.Text);
          msg.SetBodyElement("issue_no",issueNumber);
          msg.SetBodyElement("issue_title",Issues_issue_name.Text);
          msg.SetBodyElement("issue_url","<a href='http://"+Request.Url.Host+Request.ApplicationPath+"/IssueChange.aspx?issue_id="+issueNumber+"'target=\"_blank\">here</a>");
          msg.SetBodyElement("issue_poster",Issues_submitted_by_l.Text);
          msg.SetSubjectElement("issue_receiver",Issues_assigned_to.SelectedItem.Text);
          msg.SetSubjectElement("issue_no",issueNumber);
          msg.SetSubjectElement("issue_title",Issues_issue_name.Text);
          msg.SetSubjectElement("issue_poster",Issues_submitted_by_l.Text);

          post.AddMessage(msg,true);
        }
        //create a new issue mail notification to notify the QA person this issue is assigned to
        if(Int32.Parse(Utility.Dlookup("users","notify_new","user_name='" + Issues_qaassigned_to.SelectedItem.Text+"'"))==1)
        {

          EmailMessage msg = new EmailMessage(Issues_qaassigned_to.SelectedItem.Text,
            Utility.Dlookup("settings","notify_new_from","settings_id=1"),
            Utility.Dlookup("settings","notify_new_body","settings_id=1"),
            Utility.Dlookup("settings","notify_new_subject","settings_id=1"));
                              
          msg.SetBodyElement("issue_receiver",Issues_qaassigned_to.SelectedItem.Text);
          msg.SetBodyElement("issue_no",issueNumber);
          msg.SetBodyElement("issue_title",Issues_issue_name.Text);
          msg.SetBodyElement("issue_url","<a href='http://"+Request.Url.Host+Request.ApplicationPath+"/IssueChange.aspx?issue_id="+issueNumber+"'target=\"_blank\">here</a>");
          msg.SetBodyElement("issue_poster",Issues_submitted_by_l.Text);

          msg.SetSubjectElement("issue_receiver",Issues_qaassigned_to.SelectedItem.Text);
          msg.SetSubjectElement("issue_no",issueNumber);
          msg.SetSubjectElement("issue_title",Issues_issue_name.Text);
          msg.SetSubjectElement("issue_poster",Issues_submitted_by_l.Text);


          post.AddMessage(msg,true);

        }
        // Issues AfterInsert Event end

        //deliver outgoing e-mails
        post.DeliverMail();
      }
      return bResult;
    }

    void Issues_BeforeSQLExecute(string SQL,String Action)
    {

      // Issues BeforeExecute Event begin
      // Issues BeforeExecute Event end

    }

    void Issues_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("insert")>0)
        bResult=Issues_insert_Click(Src,E);

      if(bResult)
        Response.Redirect(Issues_FormAction+"");
    }

    public void Issues_qastatus_id_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if(Issues_qastatus_id.SelectedItem.Text == "Waiting on Steve")
      {
        Issues_assigned_to.SelectedIndex = Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByText("Steve Sarowitz"));
      }
      else if(Issues_qastatus_id.SelectedItem.Text == "In Development") 
      {
        Issues_assigned_to.SelectedIndex = Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByText("Diane Sielepkowski"));
      }
      else if(Issues_qastatus_id.SelectedItem.Text == "Retest") 
      {
        Issues_assigned_to.SelectedIndex=Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByValue(Session["UserID"].ToString()));
      }
      else if(Issues_qastatus_id.SelectedItem.Text == "Failed") 
      {
        Issues_assigned_to.SelectedIndex = Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByText("Diane Sielepkowski"));
      }
      else if(Issues_qastatus_id.SelectedItem.Text == "New") 
      {
        Issues_assigned_to.SelectedIndex=Issues_assigned_to.Items.IndexOf(Issues_assigned_to.Items.FindByValue(Session["Supervisor"].ToString()));
      }
    }

    private void Issues_issue_id_ServerChange(object sender, System.EventArgs e)
    {
    
    }
    // Issues Action end


  }
}
