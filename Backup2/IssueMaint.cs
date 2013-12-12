/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: IssueMaint.cs
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
  ///    Summary description for IssueMaint.
  /// </summary>
  public class IssueMaint : System.Web.UI.Page

  {



    //IssueMaint CustomIncludes begin
    protected CCUtility Utility;

    //Record form Issue variables and controls declarations
    protected System.Web.UI.WebControls.Label Issue_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton Issue_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton Issue_delete;
    protected System.Web.UI.HtmlControls.HtmlInputButton Issue_cancel;
    protected System.Web.UI.HtmlControls.HtmlInputHidden Issue_issue_id;
    protected System.Web.UI.WebControls.TextBox Issue_issue_name;
    protected System.Web.UI.WebControls.TextBox Issue_issue_desc;
    protected System.Web.UI.WebControls.DropDownList Issue_user_id;
    protected System.Web.UI.WebControls.DropDownList Issue_modified_by;
    protected System.Web.UI.WebControls.TextBox Issue_date_submitted;
    protected System.Web.UI.WebControls.DropDownList Issue_bugversion;
    protected System.Web.UI.WebControls.DropDownList Issue_version;
    protected System.Web.UI.WebControls.DropDownList Issue_assigned_to_orig;
    protected System.Web.UI.WebControls.DropDownList Issue_assigned_to;
    protected System.Web.UI.WebControls.DropDownList Issue_priority_id;
    protected System.Web.UI.WebControls.DropDownList Issue_status_id;

    //Grid form Responses variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Responses_no_records;
    protected string Responses_sSQL;
    protected string Responses_sCountSQL;
    protected int Responses_CountPage;

    protected System.Web.UI.WebControls.Repeater Responses_Repeater;
    protected int i_Responses_curpage=1;

    //Grid form Files variables and controls declarations
    protected System.Web.UI.HtmlControls.HtmlTableRow Files_no_records;
    protected string Files_sSQL;
    protected string Files_sCountSQL;
    protected int Files_CountPage;
    protected CCPager Files_Pager;
    protected System.Web.UI.WebControls.Repeater Files_Repeater;
    protected int i_Files_curpage=1;

    // For each Issue form hiddens for PK's,List of Values and Actions
    protected string Issue_FormAction="IssueList.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Issue_issue_id;
    // For each Responses form hiddens for PK's,List of Values and Actions
    protected string Responses_FormAction=".aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Responses_response_id;
    // For each Files form hiddens for PK's,List of Values and Actions
    protected string Files_FormAction="IssueList.aspx?";
    protected System.Web.UI.WebControls.Label IssueForm_Title;
    protected System.Web.UI.WebControls.CustomValidator Issue_user_id_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issue_modified_by_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issue_assigned_to_orig_Validator_Num;
    protected System.Web.UI.WebControls.CustomValidator Issue_assigned_to_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issue_priority_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Issue_priority_id_Validator_Num;
    protected System.Web.UI.WebControls.RequiredFieldValidator Issue_status_id_Validator_Req;
    protected System.Web.UI.WebControls.CustomValidator Issue_status_id_Validator_Num;
    protected System.Web.UI.WebControls.Label ResponsesForm_Title;
    protected System.Web.UI.WebControls.Label FilesForm_Title;
    protected System.Web.UI.WebControls.LinkButton Files_Column_file_name;
    protected System.Web.UI.WebControls.LinkButton Files_Column_uploaded_by;
    protected System.Web.UI.WebControls.LinkButton Files_Column_date_uploaded;
    protected System.Web.UI.WebControls.Label Files_Column_Field1;
    protected System.Web.UI.HtmlControls.HtmlTable Issue_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Responses_holder;
    protected System.Web.UI.HtmlControls.HtmlTable Files_holder;
    protected System.Web.UI.WebControls.TextBox Issue_steps_to_recreate;
    protected System.Web.UI.WebControls.TextBox Issue_screen;
    protected System.Web.UI.WebControls.TextBox Issue_dev_issue_number;
    protected System.Web.UI.WebControls.TextBox Issue_its_number;
    protected System.Web.UI.WebControls.DropDownList Issue_qastatus_id;
    protected System.Web.UI.WebControls.DropDownList Issue_product_id;
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_Files_file_id;


    public IssueMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // IssueMaint CustomIncludes end
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
  // IssueMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // IssueMaint Open Event begin
      // IssueMaint Open Event end
      //===============================

      //===============================
      // IssueMaint OpenAnyPage Event begin
      // IssueMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // IssueMaint PageSecurity begin
      Utility.CheckSecurity(3);
      // IssueMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_Issue_issue_id.Value = Utility.GetParam("issue_id");
        p_Responses_response_id.Value = Utility.GetParam("response_id");
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
      Files_Pager.NavigateCompleted+=new NavigateCompletedHandler(this.Files_pager_navigate_completed);
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Issue_update.ServerClick += new System.EventHandler(this.Issue_Action);
      this.Issue_delete.ServerClick += new System.EventHandler(this.Issue_Action);
      this.Issue_cancel.ServerClick += new System.EventHandler(this.Issue_Action);
      this.Unload += new System.EventHandler(this.Page_Unload);
      this.Load += new System.EventHandler(this.Page_Load);

    }

    protected void Page_Show(object sender, EventArgs e)
    {
      Issue_Show();
      Responses_Bind();
      Files_Bind();

    }

    // IssueMaint Show end

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
      Utility.buildListBox(Issue_user_id.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Issue_modified_by.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Issue_assigned_to_orig.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Issue_assigned_to.Items,"select user_id,user_name from users order by 2","user_id","user_name",null,"");
      Utility.buildListBox(Issue_priority_id.Items,"select priority_id,priority_desc from priorities order by 2","priority_id","priority_desc",null,"");
      Utility.buildListBox(Issue_status_id.Items,"select status_id,status from statuses order by 2","status_id","status",null,"");
      Utility.buildListBox(Issue_bugversion.Items,"select version_id,version from versions order by 1","version_id","version",null,"");
      Utility.buildListBox(Issue_version.Items,"select version_id,version from fversions order by 1","version_id","version",null,"");
      Utility.buildListBox(Issue_qastatus_id.Items,"select qastatus_id,qastatus from qastatuses order by 1","qastatus_id","qastatus",null,"");
      Utility.buildListBox(Issue_product_id.Items,"select product_id,product from products order by 2","product_id","product",null,"");
      
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

          Issue_issue_name.Text = CCUtility.GetValue(row, "issue_name");
          Issue_issue_desc.Text = CCUtility.GetValue(row, "issue_desc");
          Issue_steps_to_recreate.Text = CCUtility.GetValue(row, "steps_to_recreate");
          Issue_dev_issue_number.Text = CCUtility.GetValue(row, "dev_issue_number");
          Issue_its_number.Text = CCUtility.GetValue(row, "its_number");
          Issue_screen.Text = CCUtility.GetValue(row, "screen");

          {
            string s;
            s=CCUtility.GetValue(row, "user_id");

            try
            {
              Issue_user_id.SelectedIndex=Issue_user_id.Items.IndexOf(Issue_user_id.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "qastatus_id");

          try
          {
            Issue_qastatus_id.SelectedIndex=Issue_qastatus_id.Items.IndexOf(Issue_qastatus_id.Items.FindByValue(s));
          }
          catch{}
        }
          

        {
          string s;
          s=CCUtility.GetValue(row, "modified_by")
              ;

            try
            {
              Issue_modified_by.SelectedIndex=Issue_modified_by.Items.IndexOf(Issue_modified_by.Items.FindByValue(s));
            }
            catch{}
          }

        Issue_date_submitted.Text = CCUtility.GetValue(row, "date_submitted")
                                      .Replace('T', ' ');

        {
          string s;
          s=CCUtility.GetValue(row, "bugversion");

          try
          {
            Issue_bugversion.SelectedIndex=Issue_bugversion.Items.IndexOf(Issue_bugversion.Items.FindByValue(s));
          }
          catch{}
        }

        {
          string s;
          s=CCUtility.GetValue(row, "version");

          try
          {
            Issue_version.SelectedIndex=Issue_version.Items.IndexOf(Issue_version.Items.FindByValue(s));
          }
          catch{}
        }

          {
            string s;
            s=CCUtility.GetValue(row, "assigned_to_orig");

            try
            {
              Issue_assigned_to_orig.SelectedIndex=Issue_assigned_to_orig.Items.IndexOf(Issue_assigned_to_orig.Items.FindByValue(s));
            }
            catch{}
          }


        {
          string s;
          s=CCUtility.GetValue(row, "assigned_to")
              ;

            try
            {
              Issue_assigned_to.SelectedIndex=Issue_assigned_to.Items.IndexOf(Issue_assigned_to.Items.FindByValue(s));
            }
            catch{}
          }


        {
          string s;
          s=CCUtility.GetValue(row, "priority_id")
              ;

            try
            {
              Issue_priority_id.SelectedIndex=Issue_priority_id.Items.IndexOf(Issue_priority_id.Items.FindByValue(s));
            }
            catch{}
          }


        {
          string s;
          s=CCUtility.GetValue(row, "status_id")
              ;

            try
            {
              Issue_status_id.SelectedIndex=Issue_status_id.Items.IndexOf(Issue_status_id.Items.FindByValue(s));
            }
            catch{}
          }

        {
          string s;
          s=CCUtility.GetValue(row, "product_id")
            ;

          try
          {
            Issue_product_id.SelectedIndex=Issue_product_id.Items.IndexOf(Issue_product_id.Items.FindByValue(s));
          }
          catch{}
        }

        ActionInsert=false;

        // Issue ShowEdit Event begin
        // Issue ShowEdit Event end

      }
    }

    if(ActionInsert)
      {
        Issue_delete.Visible=false;
        Issue_update.Visible=false;

        // Issue ShowInsert Event begin
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


    bool Issue_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=Issue_Validate();
      if(bResult)
      {

        if (p_Issue_issue_id.Value.Length > 0)
        {
          sWhere = sWhere + "issue_id=" + CCUtility.ToSQL(p_Issue_issue_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        // Issue Check Event begin
        // Issue Check Event end

        if (bResult)
        {

          sSQL = "update issues set " +
                 "[issue_name]=" +CCUtility.ToSQL(Utility.GetParam("Issue_issue_name"),CCUtility.FIELD_TYPE_Text)  +
                 ",[issue_desc]=" +CCUtility.ToSQL(Utility.GetParam("Issue_issue_desc"),CCUtility.FIELD_TYPE_Text)  +
                 ",[user_id]=" +CCUtility.ToSQL(Utility.GetParam("Issue_user_id"),CCUtility.FIELD_TYPE_Number)  +
                 ",[modified_by]=" +CCUtility.ToSQL(Utility.GetParam("Issue_modified_by"),CCUtility.FIELD_TYPE_Number)  +
                 ",[date_submitted]=" +CCUtility.ToSQL(Utility.GetParam("Issue_date_submitted"),CCUtility.FIELD_TYPE_Date)  +
                 ",[bugversion]=" +CCUtility.ToSQL(Utility.GetParam("Issue_bugversion"),CCUtility.FIELD_TYPE_Text)  +
                 ",[version]=" +CCUtility.ToSQL(Utility.GetParam("Issue_version"),CCUtility.FIELD_TYPE_Text)  +
                 ",[assigned_to_orig]=" +CCUtility.ToSQL(Utility.GetParam("Issue_assigned_to_orig"),CCUtility.FIELD_TYPE_Number)  +
                 ",[assigned_to]=" +CCUtility.ToSQL(Utility.GetParam("Issue_assigned_to"),CCUtility.FIELD_TYPE_Number)  +
                 ",[priority_id]=" +CCUtility.ToSQL(Utility.GetParam("Issue_priority_id"),CCUtility.FIELD_TYPE_Number)  +
                 ",[status_id]=" +CCUtility.ToSQL(Utility.GetParam("Issue_status_id"),CCUtility.FIELD_TYPE_Number) +
                 ",[qastatus_id]=" +CCUtility.ToSQL(Utility.GetParam("Issue_qastatus_id"),CCUtility.FIELD_TYPE_Number) +
                 ",[screen]=" +CCUtility.ToSQL(Utility.GetParam("Issue_screen"),CCUtility.FIELD_TYPE_Text) +
                 ",[dev_issue_number]=" +CCUtility.ToSQL(Utility.GetParam("Issue_dev_issue_number"),CCUtility.FIELD_TYPE_Text) +
                 ",[its_number]=" +CCUtility.ToSQL(Utility.GetParam("Issue_its_number"),CCUtility.FIELD_TYPE_Text) +
                 ",[product_id]=" +CCUtility.ToSQL(Utility.GetParam("Issue_product_id"),CCUtility.FIELD_TYPE_Number) +
                 ",[steps_to_recreate]=" +CCUtility.ToSQL(Utility.GetParam("Issue_steps_to_recreate"),CCUtility.FIELD_TYPE_Text)  ;


          sSQL = sSQL + " where " + sWhere;

          // Issue Update Event begin
          // Issue Update Event end
          Issue_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            Issue_ValidationSummary.Text += e.Message;
            Issue_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // Issue AfterUpdate Event begin
          // Issue AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool Issue_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_Issue_issue_id.Value.Length > 0)
      {
        sWhere += "issue_id=" + CCUtility.ToSQL(p_Issue_issue_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from issues where " + sWhere;

      // Issue Delete Event begin
      string fileSQL="SELECT file_name FROM files WHERE issue_id="+ Issue_issue_id.Value;
      OleDbDataAdapter fileCmd = new OleDbDataAdapter(fileSQL, Utility.Connection);
      DataSet fileSet = new DataSet();
      try
      {
        fileCmd.Fill(fileSet,"files");
        if(fileSet.Tables[0].Rows.Count>0)
        {
          for(int i=0;i<fileSet.Tables[0].Rows.Count;i++)
          {
            System.IO.File.Delete(Server.MapPath(Utility.Dlookup("settings","file_path","settings_id=1"))+"\\"+fileSet.Tables[0].Rows[i]["file_name"].ToString());
          }
        }
      }
      catch(Exception e)
      {
        Issue_ValidationSummary.Text += e.Message;
        Issue_ValidationSummary.Visible = true;
        return false;

      }

      string sSQL1 = "delete from responses where issue_id=" + Issue_issue_id.Value;
      string sSQL2 = "delete from files where issue_id="+ Issue_issue_id.Value;

      OleDbCommand cmd1 = new OleDbCommand(sSQL1, Utility.Connection);
      OleDbCommand cmd2 = new OleDbCommand(sSQL2, Utility.Connection);
      try
      {
        cmd1.ExecuteNonQuery();
        cmd2.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        Issue_ValidationSummary.Text += e.Message;
        Issue_ValidationSummary.Visible = true;
        return false;
      }
      // Issue Delete Event end
      Issue_BeforeSQLExecute(sSQL,"Delete");
      OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        Issue_ValidationSummary.Text += e.Message;
        Issue_ValidationSummary.Visible = true;
        return false;
      }

      // Issue AfterDelete Event begin
      // Issue AfterDelete Event end
      return true;
    }

    bool Issue_cancel_Click(Object Src, EventArgs E)
    {

      // Issue BeforeCancel Event begin
      // Issue BeforeCancel Event end

      return true;
    }

    void Issue_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=Issue_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=Issue_delete_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("cancel")>0)
        bResult=Issue_cancel_Click(Src,E);


      if(bResult)
        Response.Redirect(Issue_FormAction+"");
    }
    // Issue Action end


    // End of Login form








    const int Responses_PAGENUM = 0;




    public void Responses_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Responses Show Event begin
      // Responses Show Event end
    }


    ICollection Responses_CreateDataSource()
    {


      // Responses Show begin
      Responses_sSQL = "";
      Responses_sCountSQL = "";

      string sWhere = "", sOrder = "";


      bool bReq = true;
      bool HasParam = false;


      //-------------------------------
      // Build ORDER BY statement
      //-------------------------------
      sOrder = " order by r.date_response Asc";
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


      Responses_sSQL = "select [r].[assigned_to] as r_assigned_to, " +
                       "[r].[date_response] as r_date_response, " +
                       "[r].[issue_id] as r_issue_id, " +
                       "[r].[priority_id] as r_priority_id, " +
                       "[r].[response] as r_response, " +
                       "[r].[response_id] as r_response_id, " +
                       "[r].[status_id] as r_status_id, " +
                       "[r].[user_id] as r_user_id, " +
                       "[u].[user_id] as u_user_id, " +
                       "[u].[user_name] as u_user_name, " +
                       "[u1].[user_id] as u1_user_id, " +
                       "[u1].[user_name] as u1_user_name, " +
                       "[p].[priority_id] as p_priority_id, " +
                       "[p].[priority_desc] as p_priority_desc, " +
                       "[s].[status_id] as s_status_id, " +
                       "[s].[status] as s_status " +
                       " from [responses] r, [users] u, [users] u1, [priorities] p, [statuses] s" +
                       " where [u].[user_id]=r.[user_id] and [u1].[user_id]=r.[assigned_to] and [p].[priority_id]=r.[priority_id] and [s].[status_id]=r.[status_id]  ";

      //-------------------------------
      //-------------------------------

      //-------------------------------

      //-------------------------------
      // Assemble full SQL statement
      //-------------------------------



      Responses_sSQL = Responses_sSQL + sWhere + sOrder;
      //-------------------------------

      if(!bReq)
      {
        Responses_no_records.Visible = true;

        return null;
      }
      OleDbDataAdapter command = new OleDbDataAdapter(Responses_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, 0, Responses_PAGENUM, "Responses");
      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Responses_no_records.Visible = true;
      }
      else
      {
        Responses_no_records.Visible = false;
      }


      return Source;
      // Responses Show end

    }


    void Responses_Bind()
    {
      Responses_Repeater.DataSource = Responses_CreateDataSource();
      Responses_Repeater.DataBind();

    }


    // End of Login form








    const int Files_PAGENUM = 20;




    public void Files_Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {

      // Files Show Event begin
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
      // Build ORDER BY statement
      //-------------------------------
      if(Utility.GetParam("FormFiles_Sorting").Length>0&&!IsPostBack)
      {
        ViewState["SortColumn"]=Utility.GetParam("FormFiles_Sorting");
        ViewState["SortDir"]="ASC";
      }
      if(ViewState["SortColumn"]!=null)
        sOrder = " ORDER BY " + ViewState["SortColumn"].ToString()+" "+ViewState["SortDir"].ToString();

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
      if (Files_sCountSQL.Length== 0)
      {
        int iTmpI = Files_sSQL.ToLower().IndexOf("select ");
        int iTmpJ = Files_sSQL.ToLower().LastIndexOf(" from ")-1;
        Files_sCountSQL = Files_sSQL.Replace(Files_sSQL.Substring(iTmpI + 7, iTmpJ-6), " count(*) ");
        iTmpI = Files_sCountSQL.ToLower().IndexOf(" order by");
        if (iTmpI > 1)
          Files_sCountSQL = Files_sCountSQL.Substring(0, iTmpI);
      }


      //-------------------------------

      OleDbDataAdapter command = new OleDbDataAdapter(Files_sSQL, Utility.Connection);
      DataSet ds = new DataSet();

      command.Fill(ds, (i_Files_curpage - 1) * Files_PAGENUM, Files_PAGENUM,"Files");
      OleDbCommand ccommand = new OleDbCommand(Files_sCountSQL, Utility.Connection);
      int PageTemp=(int)ccommand.ExecuteScalar();
      Files_Pager.MaxPage=(PageTemp%Files_PAGENUM)>0?(int)(PageTemp/Files_PAGENUM)+1:(int)(PageTemp/Files_PAGENUM);
      bool AllowScroller=Files_Pager.MaxPage==1?false:true;

      DataView Source;
      Source = new DataView(ds.Tables[0]);

      if (ds.Tables[0].Rows.Count == 0)
      {
        Files_no_records.Visible = true;
        AllowScroller=false;
      }
      else
      {
        Files_no_records.Visible = false;
        AllowScroller=AllowScroller&&true;
      }

      Files_Pager.Visible=AllowScroller;
      return Source;
      // Files Show end

    }


    protected void Files_pager_navigate_completed(Object Src, int CurrPage)
    {
      i_Files_curpage=CurrPage;

      // Files CustomNavigation Event begin
      // Files CustomNavigation Event end
      Files_Bind();
    }


    void Files_Bind()
    {
      Files_Repeater.DataSource = Files_CreateDataSource();
      Files_Repeater.DataBind();

    }

    protected void Files_SortChange(Object Src, EventArgs E)
    {
      if(ViewState["SortColumn"]==null || ViewState["SortColumn"].ToString()!=((LinkButton)Src).CommandArgument)
      {
        ViewState["SortColumn"]=((LinkButton)Src).CommandArgument;
        ViewState["SortDir"]="ASC";
      }
      else
      {
        ViewState["SortDir"]=ViewState["SortDir"].ToString()=="ASC"?"DESC":"ASC";
      }
      Files_Bind();
    }

    public void Issue_qastatus_id_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if(Issue_qastatus_id.SelectedItem.Text == "Waiting on Steve")
      {
        Issue_assigned_to.SelectedIndex = Issue_assigned_to.Items.IndexOf(Issue_assigned_to.Items.FindByText("Steve Sarowitz"));
      }
      else if(Issue_qastatus_id.SelectedItem.Text == "In Development") 
      {
        Issue_assigned_to.SelectedIndex = Issue_assigned_to.Items.IndexOf(Issue_assigned_to.Items.FindByText("Diane Sielepkowski"));
      }
      else if(Issue_qastatus_id.SelectedItem.Text == "Retest") 
      {
        Issue_assigned_to.SelectedIndex=Issue_assigned_to.Items.IndexOf(Issue_assigned_to.Items.FindByValue(Session["UserID"].ToString()));
      }
      else if(Issue_qastatus_id.SelectedItem.Text == "Failed") 
      {
        Issue_assigned_to.SelectedIndex = Issue_assigned_to.Items.IndexOf(Issue_assigned_to.Items.FindByText("Diane Sielepkowski"));
      }
      else if(Issue_qastatus_id.SelectedItem.Text == "New") 
      {
        Issue_assigned_to.SelectedIndex=Issue_assigned_to.Items.IndexOf(Issue_assigned_to.Items.FindByValue(Session["Supervisor"].ToString()));
      }
    }

  }
}
