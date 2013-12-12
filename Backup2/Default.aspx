<%@ Page language="c#" Codebehind="Default.cs" AutoEventWireup="false" Inherits="IssueManager.Default" SmartNavigation="true" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<HTML>
  <HEAD>
    <title>UltraApps Issue Manager</title>
    <meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
    <meta content="YesSoftware CodeCharge v.2.0.1 using 'ASP.NET C#.ccp' build 9/27/2001"
      name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="expires" content="0">
    <meta http-equiv="cache-control" content="no-cache">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
    <LINK href="Site.css" type="text/css" rel="stylesheet">
      <LINK href="Footer.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body class="PageBODY">
    <form method="post" runat="server">
      <CC:HEADER id="Header" runat="server"></CC:HEADER><input id="p_Issues_issue_id" type="hidden" runat="server">
      <table>
        <tr>
          <td vAlign="top">
            <table class="FormTABLE" id="Search_holder" runat="Server">
              <tr>
                <td class="FormHeaderTD" colSpan="4"><a name="Search"><font class="FormHeaderFONT"><asp:label id="SearchForm_Title" runat="server">Search</asp:label></font></a></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Keyword(s)</font></td>
                <td class="DataTD" colSpan="3"><asp:textbox id="Search_issue_name" runat="server" Columns="30" MaxLength="200"></asp:textbox>&nbsp;&nbsp;
                  <asp:button id="Search_search_button" runat="server" Text="Search"></asp:button></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font></td>
                <td class="DataTD"><asp:listbox id="Search_priority_id" runat="server" cssclass="DataFONT" SelectionMode="Multiple"
                    DataTextField="priority_desc" DataValueField="priority_id"></asp:listbox></td>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Category</font></td>
                <td class="DataTD"><asp:listbox id="Search_category_id" runat="server" SelectionMode="Multiple" DataTextField="category"
                    DataValueField="category_id" CssClass="DataFONT"></asp:listbox></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Status</font></td>
                <td class="DataTD"><asp:listbox id="Search_status_id" runat="server" SelectionMode="Multiple" DataTextField="status"
                    DataValueField="status_id" CssClass="DataFONT"></asp:listbox></td>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">OPS Status</font></td>
                <td class="DataTD"><asp:listbox id="Search_qastatus_id" runat="server" SelectionMode="Multiple" DataTextField="qastatus"
                    DataValueField="qastatus_id" CssClass="DataFONT"></asp:listbox></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Next Action To</font></td>
                <td class="DataTD"><asp:listbox id="Search_assigned_to" runat="server" cssclass="DataFONT" SelectionMode="Multiple"
                    DataTextField="user_name" DataValueField="user_id"></asp:listbox></td>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Retest Owner</font></td>
                <td class="DataTD"><asp:listbox id="Search_qaassigned_to" runat="server" cssclass="DataFONT" SelectionMode="Multiple"
                    DataTextField="user_name" DataValueField="user_id"></asp:listbox></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Found In Environment</font></td>
                <td class="DataTD"><asp:listbox id="Search_bug_version_id" runat="server" cssclass="DataFONT" SelectionMode="Multiple"
                    DataTextField="version" DataValueField="version_id"></asp:listbox></td>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Target Release</font></td>
                <td class="DataTD"><asp:listbox id="Search_release_version_id" runat="server" cssclass="DataFONT" SelectionMode="Multiple"
                    DataTextField="version" DataValueField="version_id"></asp:listbox></td>
              </tr>
            </table>
          </td>
          <td vAlign="top">
            <table class="FormTABLE" id="Bokmarks_holder" runat="Server">
              <tr>
                <td class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="BokmarksForm_Title" runat="server">Bookmarks</asp:label></font></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_all" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">All Issues</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_pending" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">Pending by Update (default)</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_pending_prior" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">Pending by Priority</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_assigned_by" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">Assigned By Me</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_assigned_to" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx"> Owned By Me</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_qaassigned_to" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">Retest Owned By Me</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_supervised" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">Supervised By Me</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_Dev_Nr_Assigned" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">Dev Nr Assigned</asp:hyperlink></td>
              </tr>
              <tr>
                <td class="DataTD"><asp:hyperlink id="Bokmarks_No_Dev_Nr_Assigned" runat="server" cssclass="DataFONT" NavigateUrl="Default.aspx">No Dev Nr Assigned</asp:hyperlink></td>
              </tr>
            </table>
          </td>
          <td vAlign="top">
            <table class="FormTABLE" id="Summary_holder" runat="Server">
              <TBODY>
        <tr>
                  <td class="FormHeaderTD" colSpan="2"><font class="FormHeaderFONT">Dev Status</font></td>
                </tr>
        <tr>
                  <td class="ColumnTD"><asp:label id="Summary_Column_status" runat="server" Text="" cssclass="ColumnFONT"></asp:label></td>
                  <td class="ColumnTD"><asp:label id="Summary_Column_issue_id" runat="server" Text="" cssclass="ColumnFONT"></asp:label></td>
                </tr>
        <tr id="Summary_no_records" runat="server">
                  <td class="DataTD" colSpan="2"><font class="DataFONT">No records</font></td>
                </tr>
        <tr>
                  <td><asp:repeater id="Summary_Repeater" runat="server">
                      <HeaderTemplate>
                  </td>
                </tr>
								</HeaderTemplate>
								<ItemTemplate>
                  <tr>
                    <td class="DataTD">
                      <asp:HyperLink id=Summary_status NavigateUrl='<%# "Default.aspx"+"?"+"status_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "status_id").ToString()) +"&" +"assigned_by=" + Server.UrlEncode(Utility.GetParam("assigned_by")) + "&assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) + "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&"%>' cssclass="DataFONT" runat="server">
                        <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "status").ToString()) %>
                      </asp:HyperLink>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Summary_issue_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "issue_id").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                  </tr>
                </ItemTemplate>

              					<FooterTemplate>
                  <tr>
                    <td>
                </FooterTemplate>
            </asp:repeater></td>
        </tr>
      </table>
      <table class="FormTABLE" id="Summary1_holder" runat="Server">
        <TBODY>
        <tr>
            <td class="FormHeaderTD" colSpan="2"><font class="FormHeaderFONT">OPS Status</font></td>
          </tr>
        <tr>
            <td class="ColumnTD"><asp:label id="Summary1_Column_status" runat="server" Text="" cssclass="ColumnFONT"></asp:label></td>
            <td class="ColumnTD"><asp:label id="Summary1_Column_issue_id" runat="server" Text="" cssclass="ColumnFONT"></asp:label></td>
          </tr>
        <tr id="Summary1_no_records" runat="server">
            <td class="DataTD" colSpan="2"><font class="DataFONT">No records</font></td>
          </tr>
        <tr>
            <td><asp:repeater id="Summary1_Repeater" runat="server">
                <HeaderTemplate>
            </td>
          </tr>
								</HeaderTemplate>
								<ItemTemplate>
            <tr>
              <td class="DataTD">
                <asp:HyperLink id="Hyperlink1" NavigateUrl='<%# "Default.aspx"+"?"+"qastatus_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "qastatus_id").ToString()) +"&" +"assigned_by=" + Server.UrlEncode(Utility.GetParam("assigned_by")) + "&assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) + "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&"%>' cssclass="DataFONT" runat="server">
                  <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "qastatus").ToString()) %>
                </asp:HyperLink>&nbsp;
              </td>
              <td class="DataTD">
                <asp:Label id="Label3" cssclass="DataFONT" runat="server">
                  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "issue_id").ToString()) %>
                </asp:Label>&nbsp;
              </td>
            </tr>
          </ItemTemplate>

              					<FooterTemplate>
            <tr>
              <td>
          </FooterTemplate>
										</asp:repeater></TD></TR></TBODY></table>
      </TD></TR></TBODY></TABLE>
      <table>
        <tr>
          <td vAlign="top">
            <table class="FormTABLE" id="Issues_holder" runat="Server">
              <TBODY>
        <tr>
                  <td class="FormHeaderTD" colSpan="14" width="853"><font class="FormHeaderFONT"><asp:label id="IssuesForm_Title" runat="server"><% Response.Write(ViewState["Issues_issue_view"].ToString());%></asp:label></font></td>
                </tr>
        <tr>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_issue_id" onclick="Issues_SortChange" runat="server" Text="Issue#"
                      cssclass="ColumnFONT" CommandArgument="i.[issue_id]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_issue_name" onclick="Issues_SortChange" runat="server" Text="Issue"
                      cssclass="ColumnFONT" CommandArgument="i.[issue_name]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_qastatus_id" onclick="Issues_SortChange" runat="server" Text="OPS Status"
                      cssclass="ColumnFONT" CommandArgument="qs.[qastatus]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_priority_id" onclick="Issues_SortChange" runat="server" Text="Priority"
                      cssclass="ColumnFONT" CommandArgument="p.[priority_order]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_status_id" onclick="Issues_SortChange" runat="server" Text="Dev Status"
                      cssclass="ColumnFONT" CommandArgument="s.[status]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_dev_issue_number" onclick="Issues_SortChange" runat="server" Text="Dev Issue Nr"
                      cssclass="ColumnFONT" CommandArgument="i.[dev_issue_number]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_assigned_to" onclick="Issues_SortChange" runat="server" Text="Owner"
                      cssclass="ColumnFONT" CommandArgument="i.[assigned_to]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_qaassigned_to" onclick="Issues_SortChange" runat="server" Text="Retest Owner"
                      cssclass="ColumnFONT" CommandArgument="i.[qaassigned_to]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_bugversion" onclick="Issues_SortChange" runat="server" Text="Found in Environment"
                      cssclass="ColumnFONT" CommandArgument="bv.[version]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_version" onclick="Issues_SortChange" runat="server" Text="Target Release"
                      cssclass="ColumnFONT" CommandArgument="v.[version]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_category_id" onclick="Issues_SortChange" runat="server" Text="Category"
                      cssclass="ColumnFONT" CommandArgument="c.[category]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_user_id" onclick="Issues_SortChange" runat="server" Text="Submitted By"
                      cssclass="ColumnFONT" CommandArgument="i.[user_id]"></asp:linkbutton></td>
                  <td class="ColumnTD" width="92"><asp:linkbutton id="Issues_Column_date_submitted" onclick="Issues_SortChange" runat="server" Text="Date Submitted"
                      cssclass="ColumnFONT" CommandArgument="i.[date_submitted]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_date_modified" onclick="Issues_SortChange" runat="server" Text="Last Update"
                      cssclass="ColumnFONT" CommandArgument="i.[date_modified]"></asp:linkbutton></td>
                </tr>
        <tr id="Issues_no_records" runat="server">
                  <td class="DataTD" colSpan="14" width="853"><font class="DataFONT">No records</font></td>
                </tr>
        <tr>
                  <td><asp:repeater id="Issues_Repeater" runat="server" onitemdatabound="Issues_Repeater_ItemDataBound">
                      <HeaderTemplate>
                  </td>
                </tr>
              </HeaderTemplate>
              <ItemTemplate>
                  <tr>
                    <td class="DataTD">
                      <asp:HyperLink  ID=Issues_issue_id NavigateUrl='<%# "IssueChange.aspx"+"?"+"issue_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "i_issue_id").ToString()) +"&" +"assigned_by=" + Server.UrlEncode(Utility.GetParam("assigned_by")) + "&assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) + "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&status_id=" + Server.UrlEncode(Utility.GetParam("status_id")) + "&qastatus_id=" + Server.UrlEncode(Utility.GetParam("qastatus_id")) + "&category_id=" + Server.UrlEncode(Utility.GetParam("category_id")) + "&version_id=" + Server.UrlEncode(Utility.GetParam("version_id")) + "&"%>' cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_id").ToString()) %>
                      </asp:HyperLink>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:HyperLink id=Issues_issue_name NavigateUrl='<%# "IssueChange.aspx"+"?"+"issue_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "i_issue_id").ToString()) +"&" +"assigned_by=" + Server.UrlEncode(Utility.GetParam("assigned_by")) + "&assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&qaassigned_to=" + Server.UrlEncode(Utility.GetParam("qaassigned_to")) + "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&status_id=" + Server.UrlEncode(Utility.GetParam("status_id")) + "&qastatus_id=" + Server.UrlEncode(Utility.GetParam("qastatus_id")) + "&category_id=" + Server.UrlEncode(Utility.GetParam("category_id")) + "&version_id=" + Server.UrlEncode(Utility.GetParam("version_id")) + "&"%>' cssclass="DataFONT" runat="server">
                        <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_name").ToString()) %>
                      </asp:HyperLink>&nbsp;
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
                      <asp:Label id="Issues_qaassigned_to" cssclass="DataFONT" runat="server">
                        <%# DataBinder.Eval(Container.DataItem, "u3_user_name_qaowner") %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_bugversion" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "bv_version").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <input type=hidden id=Issues_issue_desc runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_desc").ToString()) %>' NAME="Issues_issue_desc">
                      <asp:Label id="Issues_version" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "v_version").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_category_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "c_category").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Label1" cssclass="DataFONT" runat="server">
                        <%# DataBinder.Eval(Container.DataItem, "u_user_name_submitted_by") %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_date_submitted" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_date_submitted").ToString().Replace('T', ' ')) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_date_modified" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_date_modified").ToString().Replace('T', ' ')) %>
                      </asp:Label>&nbsp;
                    </td>
                  </tr>
                </ItemTemplate>

              	<FooterTemplate>
                  <tr>
                    <td>
                </FooterTemplate>
            </asp:repeater></td>
        </tr>
        <tr>
          <td class="ColumnTD" colSpan="14" width="100%"><asp:linkbutton id="Issues_insert" runat="server" cssclass="ColumnFONT">Add New Issue</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <font class="ColumnFONT">
              <CC:PAGER id="Issues_Pager" runat="server" cssclass="ColumnFONT" NumberOfPages="5" PagerStyle="2"
                showprevCaption="Previous" shownextCaption="Next" showtotalstring="of" showtotal="True"
                showLastCaption="Last" ShowFirstCaption="First" shownext="True" showprev="True" showLast="False"
                ShowFirst="False"></CC:PAGER></font></td>
        </tr>
      </table>
      <a 
      href='<% Response.Write(ViewState["Issues_ExportAction"].ToString());%>?<% Response.Write(ViewState["Issues_TransitParams"].ToString());%>' 
      >Export to Excel</a> </TD></TR></TBODY></TABLE><CC:FOOTER id="Footer" runat="server"></CC:FOOTER></form>
  </body>
</HTML>
