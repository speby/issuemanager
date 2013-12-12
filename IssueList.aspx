<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="IssueList.cs" AutoEventWireup="false" Inherits="IssueManager.IssueList" SmartNavigation="true" %>
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
                <td class="FormHeaderTD" colSpan="11"><a name="Search"><font class="FormHeaderFONT"><asp:label id="SearchForm_Title" runat="server">Search</asp:label></font></a></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Keyword</font></td>
                <td class="DataTD"><asp:textbox id="Search_issue_name" runat="server" MaxLength="100" Columns="30"></asp:textbox></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font></td>
                <td class="DataTD"><asp:dropdownlist id="Search_priority_id" runat="server" DataValueField="priority_id" DataTextField="priority_desc"
                    cssclass="DataFONT"></asp:dropdownlist></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Status</font></td>
                <td class="DataTD"><asp:listbox id="Search_status_id" runat="server" DataValueField="status_id" DataTextField="status"
                    CssClass="DataFONT" SelectionMode="Multiple"></asp:listbox></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">OPS Status</font></td>
                <td class="DataTD"><asp:listbox id="Search_qastatus_id" runat="server" DataValueField="qastatus_id" DataTextField="qastatus"
                    CssClass="DataFONT" SelectionMode="Multiple"></asp:listbox></td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Next Action&nbsp;To</font></td>
                <td class="DataTD"><asp:dropdownlist id="Search_assigned_to" runat="server" DataValueField="user_id" DataTextField="user_name"
                    cssclass="DataFONT"></asp:dropdownlist></td>
              </tr>
              <tr>
                <td align="right" colSpan="3"><asp:button id="Search_search_button" runat="server" Text="Search"></asp:button></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
      <table>
        <tr>
          <td vAlign="top">
            <table class="FormTABLE" id="Issues_holder" runat="Server">
              <TBODY>
        <tr>
                  <td class="FormHeaderTD" colSpan="9" width="795"><font class="FormHeaderFONT"><asp:label id="IssuesForm_Title" runat="server">Issues</asp:label></font></td>
                </tr>
        <tr>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_issue_id" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Issue #" CommandArgument="i.[issue_id]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_issue_name" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Issue" CommandArgument="i.[issue_name]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_status_id" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Dev Status" CommandArgument="s.[status]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_dev_issue_number" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Dev Issue Nr" CommandArgument="i.[dev_issue_number]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_qastatus_id" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="OPS Status" CommandArgument="qs.[qastatus]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_assigned_to" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Dev Assigned To" CommandArgument="u.[user_name]">Next Action To</asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_date_submitted" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Submited" CommandArgument="i.[date_submitted]"></asp:linkbutton></td>
                  <td class="ColumnTD" width="56"><asp:linkbutton id="Issues_Column_date_modified" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Last Updated" CommandArgument="i.[date_modified]"></asp:linkbutton></td>
                  <td class="ColumnTD"><asp:linkbutton id="Issues_Column_date_resolved" onclick="Issues_SortChange" runat="server" cssclass="ColumnFONT"
                      Text="Resolved" CommandArgument="i.[date_resolved]"></asp:linkbutton></td>
                </tr>
        <tr id="Issues_no_records" runat="server">
                  <td class="DataTD" colSpan="9" width="795"><font class="DataFONT">No records</font></td>
                </tr>
        <tr>
                  <td><asp:repeater id="Issues_Repeater" runat="server">
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
                      <asp:HyperLink id=Issues_issue_name NavigateUrl='<%# "IssueMaint.aspx"+"?"+"issue_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "i_issue_id").ToString()) +"&" +"assigned_to=" + Server.UrlEncode(Utility.GetParam("assigned_to")) + "&issue_name=" + Server.UrlEncode(Utility.GetParam("issue_name")) + "&notstatus_id=" + Server.UrlEncode(Utility.GetParam("notstatus_id")) + "&notqastatus_id=" + Server.UrlEncode(Utility.GetParam("notqastatus_id")) + "&priority_id=" + Server.UrlEncode(Utility.GetParam("priority_id")) + "&status_id=" + Server.UrlEncode(Utility.GetParam("status_id")) + "&qastatus_id=" + Server.UrlEncode(Utility.GetParam("qastatus_id")) + "&"%>' cssclass="DataFONT" runat="server">
                        <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_issue_name").ToString()) %>
                      </asp:HyperLink>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_status_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "s_status").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_dev_issue_number" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_dev_issue_number").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_qastatus_id" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "qs_qastatus").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Issues_assigned_to" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_name").ToString()) %>
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
                    <td class="DataTD">
                      <asp:Label id="Issues_date_resolved" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "i_date_resolved").ToString().Replace('T', ' ')) %>
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
          <td class="ColumnTD" colSpan="9" width="795"><font class="ColumnFONT"><CC:PAGER id="Issues_Pager" runat="server" cssclass="ColumnFONT" NumberOfPages="10" PagerStyle="1"
                showprevCaption="Prev" shownextCaption="Next" showtotalstring="of" showtotal="False" showLastCaption="Ïîñëåäíèé" ShowFirstCaption="Ïåðâûé" shownext="True"
                showprev="True" showLast="False" ShowFirst="False"></CC:PAGER></font></td>
        </tr>
      </table>
      </TD></TR></TBODY></TABLE><CC:FOOTER id="Footer" runat="server"></CC:FOOTER></form>
  </body>
</HTML>
