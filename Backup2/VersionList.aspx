<%@ Page language="c#" Inherits="IssueManager.VersionList" CodeBehind="VersionList.cs" AutoEventWireup="false" SmartNavigation="true" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<HTML>
  <HEAD>
    <title>Version List</title>
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
      <input type="hidden" id="p_VersionList_version_id" runat="server">
      <table>
        <tr>
          <td valign="top">
            <table id="VersionList_holder" runat="Server" class="FormTABLE">
              <TBODY>
	              <tr>
                  <td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="VersionListForm_Title" runat="server">Version List</asp:label></font></td>
                </tr>
                <tr>
                  <td class="ColumnTD"><asp:LinkButton id="VersionList_Column_version" Text="Version" CommandArgument="v.[version]" onClick="VersionList_SortChange"
                      cssclass="ColumnFONT" runat="server" /></td>
                </tr><tr id="VersionList_no_records" runat="server">
                  <td class="DataTD" colspan="2"><font class="DataFONT">No records</font></td>
                </tr>
	              <tr>
                  <td><asp:Repeater id="VersionList_Repeater" runat="server">
                      <HeaderTemplate>
                  </td>
                </tr>
	</HeaderTemplate>
	<ItemTemplate>
                  <tr>
                    <td class="DataTD">
                      <input type=hidden id=VersionList_version_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "v_version_id").ToString()) %>' NAME="VersionList_version_id">
                      <asp:HyperLink id=VersionList_version NavigateUrl='<%# "VersionMaint.aspx"+"?"+"version_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "v_version_id").ToString()) +"&" +""%>' cssclass="DataFONT" runat="server">
                        <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "v_version").ToString()) %>
                      </asp:HyperLink>&nbsp;
                    </td>
                  </tr>
                </ItemTemplate>

	<FooterTemplate>
                  <tr>
                    <td>
                </FooterTemplate>
            </asp:Repeater></td>
        </tr>
        <tr>
          <td class="ColumnTD" colspan="2">
            <asp:LinkButton id="VersionList_insert" cssclass="ColumnFONT" runat="server" onclick="VersionList_insert_Click">Add New Version</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <font class="ColumnFONT">
              <CC:Pager id="VersionList_Pager" cssclass="ColumnFONT" ShowFirst="False" showLast="False"
                showprev="True" shownext="True" ShowFirstCaption="" showLastCaption="" showtotal="False"
                showtotalstring="of" shownextCaption="Next" showprevCaption="Previous" PagerStyle="1" NumberOfPages="10"
                runat="server" />
            </font>
          </td>
        </tr>
      </table>
      </TD></TR></TBODY></TABLE>
      <CC:Footer id="Footer" runat="server" />
    </form>
  </body>
</HTML>
