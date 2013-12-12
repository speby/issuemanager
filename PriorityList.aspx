<%@ Page language="c#" Codebehind="PriorityList.cs" AutoEventWireup="false" Inherits="IssueManager.PriorityList" %><%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %><%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %><%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<html>
  <head>
	<title>Priorities List</title>
	<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
	<meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.1 using 'ASP.NET C#.ccp' build 9/27/2001">
	<meta name="CODE_LANGUAGE" Content="C#">
	<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="expires" content="0">
<meta http-equiv="cache-control" content="no-cache">
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1"><link rel="stylesheet" href="Site.css" type="text/css">
	<link rel="stylesheet" href="Footer.css" type="text/css"></head>
  <body class="PageBODY">

  <form method="post" runat="server"><CC:Header id="Header" runat="server"/>
	<input type=hidden id=p_PrioritiesList_priority_id runat=server />
	
<table><tr><td valign="top" >


	<table   id="PrioritiesList_holder" runat="Server" class="FormTABLE">
	<tr><td colspan="4"
        class="FormHeaderTD"
><font class="FormHeaderFONT"><asp:label id="PrioritiesListForm_Title" runat="server">Priority List</asp:label></font></td></tr>
<tr><td class="ColumnTD"><asp:Label	id="PrioritiesList_Column_priority_desc"	Text="Priority" cssclass="ColumnFONT" runat="server"/></td><td class="ColumnTD"><asp:Label	id="PrioritiesList_Column_priority_color"	Text="Font Color" cssclass="ColumnFONT" runat="server"/></td><td class="ColumnTD"><asp:Label	id="PrioritiesList_Column_priority_order"	Text="Order" cssclass="ColumnFONT" runat="server"/></td></tr><tr id=PrioritiesList_no_records runat="server"><td class="DataTD" colspan="4"><font class="DataFONT">No records</font></td></tr>
	<tr><td><asp:Repeater id=PrioritiesList_Repeater runat="server">
	<HeaderTemplate>
	</td></tr>
	</HeaderTemplate>
	<ItemTemplate>

	<tr>

<td class="DataTD">

<asp:HyperLink id=PrioritiesList_priority_desc NavigateUrl='<%# "PriorityMaint.aspx"+"?"+"priority_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "p_priority_id").ToString()) +"&" +""%>' cssclass="DataFONT" runat="server"> <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "p_priority_desc").ToString()) %> </asp:HyperLink>&nbsp;
</td>
<td class="DataTD">

 <asp:Label id=PrioritiesList_priority_color cssclass="DataFONT" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "p_priority_color").ToString()) %> </asp:Label>&nbsp;
</td>
<td class="DataTD">

 
<input type=hidden id=PrioritiesList_priority_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "p_priority_id").ToString()) %>' >
 <asp:Label id=PrioritiesList_priority_order cssclass="DataFONT" runat="server">  <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "p_priority_order").ToString()) %> </asp:Label>&nbsp;
</td></tr>
</ItemTemplate>

	<FooterTemplate>
	<tr><td>
	</FooterTemplate>
	</asp:Repeater></td></tr>

    <tr><td
        class="ColumnTD"
        colspan=4>

<asp:LinkButton id="PrioritiesList_insert" cssclass="ColumnFONT" runat="server">Add New Priority</asp:LinkButton></font></td></tr>
	</table>

</td>
    </tr></table>

<CC:Footer id="Footer" runat="server"/>

    </form>
</body>
</html>