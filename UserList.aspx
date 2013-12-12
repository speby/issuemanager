<%@ Page language="c#" Codebehind="UserList.cs" AutoEventWireup="false" Inherits="IssueManager.UserList" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<HTML>
	<HEAD>
		<title>User List</title>
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
			<input type="hidden" id="p_Users_user_id" runat="server">
			<table>
				<tr>
					<td valign="top">
						<table id="Users_holder" runat="Server" class="FormTABLE">
							<TBODY>
	<tr>
									<td colspan="5" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="UsersForm_Title" runat="server">Users</asp:label></font></td>
								</tr>
<tr>
									<td class="ColumnTD"><asp:LinkButton id="Users_Column_user_name" Text="User" CommandArgument="u.[user_name]" onClick="Users_SortChange" cssclass="ColumnFONT" runat="server" /></td>
									<td class="ColumnTD"><asp:LinkButton id="Users_Column_email" Text="Email" CommandArgument="u.[email]" onClick="Users_SortChange" cssclass="ColumnFONT" runat="server" /></td>
									<td class="ColumnTD"><asp:LinkButton id="Users_Column_security_level" Text="Security Level" CommandArgument="u.[security_level]" onClick="Users_SortChange" cssclass="ColumnFONT" runat="server" /></td>
									<td class="ColumnTD"><asp:LinkButton id="Users_Column_allow_upload" Text="Can Upload Files" CommandArgument="u.[allow_upload]" onClick="Users_SortChange" cssclass="ColumnFONT" runat="server" /></td>
								</tr><tr id="Users_no_records" runat="server">
									<td class="DataTD" colspan="5"><font class="DataFONT">No records</font></td>
								</tr>
	<tr>
									<td><asp:Repeater id="Users_Repeater" runat="server">
											<HeaderTemplate>
									</td>
								</tr>
	</HeaderTemplate>
	<ItemTemplate>
									<tr>
										<td class="DataTD">
											<asp:HyperLink id=Users_user_name NavigateUrl='<%# "UserMaint.aspx"+"?"+"User_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "u_user_id").ToString()) +"&" +""%>' cssclass="DataFONT" runat="server">
												<%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_name").ToString()) %>
											</asp:HyperLink>&nbsp;
										</td>
										<td class="DataTD">
											<asp:Label id="Users_email" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_email").ToString()) %>
											</asp:Label>&nbsp;
										</td>
										<td class="DataTD">
											<asp:Label id="Users_security_level" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(IssueManager.CCUtility.GetValFromLOV(DataBinder.Eval(Container.DataItem, "u_security_level").ToString(),Users_security_level_lov).ToString()) %>
											</asp:Label>&nbsp;
										</td>
										<td class="DataTD">
											<input type=hidden id=Users_user_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_id").ToString()) %>'>
											<asp:Label id="Users_allow_upload" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(IssueManager.CCUtility.GetValFromLOV(DataBinder.Eval(Container.DataItem, "u_allow_upload").ToString(),Users_allow_upload_lov).ToString()) %>
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
				<tr>
					<td class="ColumnTD" colspan="5">
						<asp:LinkButton id="Users_insert" cssclass="ColumnFONT" runat="server">Add New User</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<font class="ColumnFONT">
							<CC:Pager id="Users_Pager" cssclass="ColumnFONT" ShowFirst="False" showLast="False" showprev="True" shownext="True" ShowFirstCaption="" showLastCaption="" showtotal="False" showtotalstring="of" shownextCaption="Next" showprevCaption="Previous" PagerStyle="1" NumberOfPages="10" runat="server" />
						</font>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE>
			<CC:Footer id="Footer" runat="server" />
		</form>
	</body>
</HTML>
