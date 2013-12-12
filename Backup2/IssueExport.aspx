<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="IssueExport.cs" AutoEventWireup="false" Inherits="IssueManager.IssueExport" %>
<HTML>
  <HEAD>
    <title>UltraApps Issue Manager</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
    <meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.1 using 'ASP.NET C#.ccp' build 9/27/2001">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="expires" content="0">
    <meta http-equiv="cache-control" content="no-cache">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
    <link rel="stylesheet" href="Site.css" type="text/css">
      <link rel="stylesheet" href="Footer.css" type="text/css">
  </HEAD>
  <body class="PageBODY">
    <form method="post" runat="server">
      <CC:Header id="Header" runat="server" />
      <input type="hidden" id="p_Issues_issue_id" runat="server">
      <table>
        <tr>
          <td valign="top">
            <table id="Issues_holder" runat="Server" class="FormTABLE">
              <TBODY>
	              <tr>
                  <td colspan="14" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="IssuesForm_Title" runat="server"><% Response.Write(ViewState["Issues_issue_view"].ToString());%></asp:label></font></td>
                </tr>
                <tr>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_issue_id" Text="Issue #" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD" width="26"><asp:Label id="Issues_Column_issue_name" Text="Issue" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_Issue_desc" Text="Issue Desc" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_Issue_steps_to_recreate" Text="Steps To Recreate" cssclass="ColumnFONT"
                      runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_status_id" Text="Ops Status" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_priority_id" Text="Priority" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_dev_status_id" Text="Dev Status" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_dev_issue_number" Text="Dev Issue Nr" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_user_name_owner" Text="Owner" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_user_name_qaowner" Text="Retest Owner" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_bugversion" Text="Found In Environment" cssclass="ColumnFONT"
                      runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_version" Text="Target Release" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_category" Text="Category" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_user_name_submitted_by" Text="Submitted By" cssclass="ColumnFONT"
                      runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_date_submitted" Text="Date Submitted" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Issues_Column_date_modified" Text="Last Update Date" cssclass="ColumnFONT" runat="server" /></td>
                </tr>
                <tr id="Issues_no_records" runat="server">
                  <td class="DataTD" colspan="14"><font class="DataFONT">No records</font></td>
                </tr>
	              <tr>
                  <td><asp:Repeater id="Issues_Repeater" onitemdatabound="Issues_Repeater_ItemDataBound" runat="server">
                      <HeaderTemplate>
                  </td>
                </tr>
	</HeaderTemplate>
	<ItemTemplate>
                  <tr>
                    <td class="DataTD">
                      <asp:Label id="Issues_issue_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_id").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_issue_name" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_name").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_issue_desc" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_desc").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_steps_to_recreate" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_steps_to_recreate").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_qastatus_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "qa_qastatus").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_priority_id" cssclass="DataFONT" runat="server">
                        <%# DataBinder.Eval(Container.DataItem, "p_priority_desc") %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_status_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "s_dev_status").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_dev_issue_number" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_dev_issue_number").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_assigned_to" cssclass="DataFONT" runat="server">
                        <%# DataBinder.Eval(Container.DataItem, "u2_user_name_owner") %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_assigned_to_retest" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u3_user_name_qaowner").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_bugversion" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "bv_version").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_version" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "v_version").ToString().Replace('T', ' ')) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_category" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "c_category").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_submitted_by" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u1_user_name_submitted_by").ToString().Replace('T', ' ')) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_date_submitted" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_date_submitted").ToString().Replace('T', ' ')) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_date_modified" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_date_modified").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                  </tr>
                </ItemTemplate>

	<FooterTemplate>
                  <tr>
                    <td>
                </FooterTemplate>
            </asp:Repeater></td>
        </tr>
      </table>
      </TD></TR></TBODY></TABLE>
      <CC:Footer id="Footer" runat="server" />
    </form>
  </body>
</HTML>
