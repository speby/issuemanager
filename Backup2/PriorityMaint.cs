/*
 * (C) Copyright 2001 by UltraApps
 * View files/license.html for Legal Information
 */
namespace IssueManager
{

  //
  //    Filename: PriorityMaint.cs
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
  ///    Summary description for PriorityMaint.
  /// </summary>
  public class PriorityMaint : System.Web.UI.Page

  {



    //PriorityMaint CustomIncludes begin
    protected CCUtility Utility;

    //Record form PriorityMaint variables and controls declarations
    protected System.Web.UI.WebControls.Label PriorityMaint_ValidationSummary;
    protected System.Web.UI.HtmlControls.HtmlInputButton PriorityMaint_insert;
    protected System.Web.UI.HtmlControls.HtmlInputButton PriorityMaint_update;
    protected System.Web.UI.HtmlControls.HtmlInputButton PriorityMaint_delete;
    protected System.Web.UI.HtmlControls.HtmlInputHidden PriorityMaint_priority_id;
    protected System.Web.UI.WebControls.TextBox PriorityMaint_priority_desc;
    protected System.Web.UI.WebControls.TextBox PriorityMaint_priority_color;
    protected System.Web.UI.WebControls.TextBox PriorityMaint_priority_order;

    // For each PriorityMaint form hiddens for PK's,List of Values and Actions
    protected string PriorityMaint_FormAction="PriorityList.aspx?";
    protected System.Web.UI.HtmlControls.HtmlInputHidden p_PriorityMaint_priority_id;


    public PriorityMaint()
    {
      this.Init += new System.EventHandler(Page_Init);
    }

    // PriorityMaint CustomIncludes end
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
  // PriorityMaint Show begin
  protected void Page_Load(object sender, EventArgs e)
    {
      Utility=new CCUtility(this);
      //===============================
      // PriorityMaint Open Event begin
      // PriorityMaint Open Event end
      //===============================

      //===============================
      // PriorityMaint OpenAnyPage Event begin
      // PriorityMaint OpenAnyPage Event end
      //===============================
      //
      //===============================
      // PriorityMaint PageSecurity begin
      Utility.CheckSecurity(2);
      // PriorityMaint PageSecurity end
      //===============================

      if (!IsPostBack)
      {

        p_PriorityMaint_priority_id.Value = Utility.GetParam("priority_id");
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
      PriorityMaint_insert.ServerClick += new System.EventHandler (this.PriorityMaint_Action);
      PriorityMaint_update.ServerClick += new System.EventHandler (this.PriorityMaint_Action);
      PriorityMaint_delete.ServerClick += new System.EventHandler (this.PriorityMaint_Action);

    }


    protected void Page_Show(object sender, EventArgs e)
    {
      PriorityMaint_Show();

    }



    // PriorityMaint Show end

    // End of Login form






    private bool PriorityMaint_Validate()
    {
      bool result=true;
      PriorityMaint_ValidationSummary.Text="";

      for(int i=0;i<Page.Validators.Count;i++)
      {
        if(((System.Web.UI.WebControls.BaseValidator)Page.Validators[i]).ID.ToString().StartsWith("PriorityMaint"))
        {
          if(!Page.Validators[i].IsValid)
          {
            PriorityMaint_ValidationSummary.Text+=Page.Validators[i].ErrorMessage+"<br>";
            result=false;
          }
        }
      }

      PriorityMaint_ValidationSummary.Visible=(!result);
      return result;
    }

    /*===============================
     Display Record Form
    -------------------------------*/


    void PriorityMaint_Show()
    {

      // PriorityMaint Show begin

      bool ActionInsert=true;

      if (p_PriorityMaint_priority_id.Value.Length > 0 )
      {
        string sWhere = "";

        sWhere += "priority_id=" + CCUtility.ToSQL(p_PriorityMaint_priority_id.Value, CCUtility.FIELD_TYPE_Number);

        // PriorityMaint Open Event begin
        // PriorityMaint Open Event end
        string sSQL = "select * from priorities where " + sWhere;
        OleDbDataAdapter dsCommand = new OleDbDataAdapter(sSQL, Utility.Connection);
        DataSet ds = new DataSet();
        DataRow row;

        if (dsCommand.Fill(ds, 0, 1, "PriorityMaint") > 0)
        {
          row = ds.Tables[0].Rows[0];

          PriorityMaint_priority_id.Value = CCUtility.GetValue(row, "priority_id");

          PriorityMaint_priority_desc.Text = CCUtility.GetValue(row, "priority_desc");
          PriorityMaint_priority_color.Text = CCUtility.GetValue(row, "priority_color");
          PriorityMaint_priority_order.Text = CCUtility.GetValue(row, "priority_order");
          PriorityMaint_insert.Visible=false;
          ActionInsert=false;

          // PriorityMaint ShowEdit Event begin
          // PriorityMaint ShowEdit Event end

        }
      }

      if(ActionInsert)
      {

        String pValue;

        pValue = Utility.GetParam("priority_id");
        PriorityMaint_priority_id.Value = pValue;
        PriorityMaint_delete.Visible=false;
        PriorityMaint_update.Visible=false;

        // PriorityMaint ShowInsert Event begin
        // PriorityMaint ShowInsert Event end

      }



      // PriorityMaint Open Event begin
      // PriorityMaint Open Event end

      // PriorityMaint Show Event begin
      // PriorityMaint Show Event end

      // PriorityMaint Show end

      // PriorityMaint Close Event begin
      // PriorityMaint Close Event end

    }

    // PriorityMaint Action begin

    bool PriorityMaint_insert_Click(Object Src, EventArgs E)
    {
      string sSQL="";
      bool bResult=PriorityMaint_Validate();

      {
        int iCount = Utility.DlookupInt("priorities", "count(*)", "priority_order=" + CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_order"), CCUtility.FIELD_TYPE_Number));
        if (iCount!=0)
        {
          PriorityMaint_ValidationSummary.Visible=true;
          PriorityMaint_ValidationSummary.Text+="The value in field Order is already in database."+"<br>";
          bResult=false;
        }
      }

      // PriorityMaint Check Event begin
      // PriorityMaint Check Event end

      if(bResult)
      {


        string p2_priority_desc=CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_desc"), CCUtility.FIELD_TYPE_Text) ;
        string p2_priority_color=CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_color"), CCUtility.FIELD_TYPE_Text) ;
        string p2_priority_order=CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_order"), CCUtility.FIELD_TYPE_Number) ;
        // PriorityMaint Insert Event begin
        // PriorityMaint Insert Event end


        sSQL = "insert into priorities (" +
               "priority_desc," +
               "priority_color," +
               "priority_order)" +
               " values (" +
               p2_priority_desc + "," +
               p2_priority_color + "," +
               p2_priority_order + ")";
        PriorityMaint_BeforeSQLExecute(sSQL,"Insert");
        OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
        try
        {
          cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
          PriorityMaint_ValidationSummary.Text += e.Message;
          PriorityMaint_ValidationSummary.Visible = true;
          return false;
        }

        // PriorityMaint AfterInsert Event begin
        // PriorityMaint AfterInsert Event end
      }
      return bResult;
    }


    void PriorityMaint_BeforeSQLExecute(string SQL,String Action)
    {

      // PriorityMaint BeforeExecute Event begin
      // PriorityMaint BeforeExecute Event end

    }


    bool PriorityMaint_update_Click(Object Src, EventArgs E)
    {
      string sWhere = "";
      string sSQL ="";

      bool bResult=PriorityMaint_Validate();
      if(bResult)
      {

        if (p_PriorityMaint_priority_id.Value.Length > 0)
        {
          sWhere = sWhere + "priority_id=" + CCUtility.ToSQL(p_PriorityMaint_priority_id.Value, CCUtility.FIELD_TYPE_Number);
        }

        {
          int iCount = Utility.DlookupInt("priorities", "count(*)", "priority_order=" + CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_order"), CCUtility.FIELD_TYPE_Number) + " and not(" + sWhere + ")");
          if (iCount!=0)
          {
            PriorityMaint_ValidationSummary.Visible=true;
            PriorityMaint_ValidationSummary.Text+="The value in field Order is already in database."+"<br>";
            bResult=false;
          }
        }

        // PriorityMaint Check Event begin
        // PriorityMaint Check Event end

        if (bResult)
        {

          sSQL = "update priorities set " +
                 "[priority_desc]=" +CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_desc"),CCUtility.FIELD_TYPE_Text)  +
                 ",[priority_color]=" +CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_color"),CCUtility.FIELD_TYPE_Text)  +
                 ",[priority_order]=" +CCUtility.ToSQL(Utility.GetParam("PriorityMaint_priority_order"),CCUtility.FIELD_TYPE_Number) ;


          sSQL = sSQL + " where " + sWhere;

          // PriorityMaint Update Event begin
          // PriorityMaint Update Event end
          PriorityMaint_BeforeSQLExecute(sSQL,"Update");
          OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
          try
          {
            cmd.ExecuteNonQuery();
          }
          catch(Exception e)
          {
            PriorityMaint_ValidationSummary.Text += e.Message;
            PriorityMaint_ValidationSummary.Visible = true;
            return false;
          }
        }

        if (bResult)
        {
          // PriorityMaint AfterUpdate Event begin
          // PriorityMaint AfterUpdate Event end
        }
      }
      return bResult;
    }

    bool PriorityMaint_delete_Click(Object Src, EventArgs E)
    {
      string sWhere = "";

      if (p_PriorityMaint_priority_id.Value.Length > 0)
      {
        sWhere += "priority_id=" + CCUtility.ToSQL(p_PriorityMaint_priority_id.Value, CCUtility.FIELD_TYPE_Number);
      }

      string sSQL = "delete from priorities where " + sWhere;

      // PriorityMaint Delete Event begin
      // PriorityMaint Delete Event end
      PriorityMaint_BeforeSQLExecute(sSQL,"Delete");
      OleDbCommand cmd = new OleDbCommand(sSQL, Utility.Connection);
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch(Exception e)
      {
        PriorityMaint_ValidationSummary.Text += e.Message;
        PriorityMaint_ValidationSummary.Visible = true;
        return false;
      }

      // PriorityMaint AfterDelete Event begin
      // PriorityMaint AfterDelete Event end
      return true;
    }

    void PriorityMaint_Action(Object Src, EventArgs E)
    {
      bool bResult=true;
      if(((HtmlInputButton)Src).ID.IndexOf("insert")>0)
        bResult=PriorityMaint_insert_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("update")>0)
        bResult=PriorityMaint_update_Click(Src,E);
      if(((HtmlInputButton)Src).ID.IndexOf("delete")>0)
        bResult=PriorityMaint_delete_Click(Src,E);


      if(bResult)
        Response.Redirect(PriorityMaint_FormAction+"");
    }
    // PriorityMaint Action end



  }
}
