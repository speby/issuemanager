<%@ Page language="c#" Codebehind="UserMaint.cs" AutoEventWireup="false" Inherits="IssueManager.UserMaint" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<HTML>
	<HEAD>
		<title>User Maintenance</title>
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
			<input type="hidden" id="p_User_user_id" runat="server">
			<table>
				<tr>
					<td valign="top">
						<table id="User_holder" runat="Server" class="FormTABLE">
							<tr>
								<td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="UserForm_Title" runat="server">Add/Edit User</asp:label></font><br>
								</td>
							</tr>
							<tr>
								<td colspan="2" class="DataTD">
									<asp:Label id="User_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
									<input type="hidden" id="User_user_id" runat="server">
								</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Login</font>
									<asp:RequiredFieldValidator id="User_login_Validator_Req" runat="server" ErrorMessage="The value in field Login is required."
										ControlToValidate="User_login" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
								<td class="DataTD">
									<asp:TextBox id="User_login" Columns="15" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Password</font>
									<asp:RequiredFieldValidator id="User_pass_Validator_Req" runat="server" ErrorMessage="The value in field Password is required."
										ControlToValidate="User_pass" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
								<td class="DataTD">
									<asp:TextBox id="User_pass" TextMode="Password" Columns="15" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD" height="17"><font class="FieldCaptionFONT">Security Level</font>
									<asp:RequiredFieldValidator id="User_security_level_Validator_Req" runat="server" ErrorMessage="The value in field Security Level is required."
										ControlToValidate="User_security_level" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
									<asp:CustomValidator id="User_security_level_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
										EnableClientScript="False" ErrorMessage="The value in field Security Level is incorrect." ControlToValidate="User_security_level"
										display="None"></asp:CustomValidator></td>
								<td class="DataTD" height="17">
									<asp:DropDownList cssclass="DataFONT" id="User_security_level" DataTextField="" DataValueField=""
										runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD" height="17"><font class="FieldCaptionFONT">Supervisor</font>
								<td class="DataTD" height="17">
									<asp:DropDownList cssclass="DataFONT" id="User_supervisor" DataTextField="" DataValueField="" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Name</font>
									<asp:RequiredFieldValidator id="User_user_name_Validator_Req" runat="server" ErrorMessage="The value in field Name is required."
										ControlToValidate="User_user_name" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
								<td class="DataTD">
									<asp:TextBox id="User_user_name" Columns="30" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Email</font></td>
								<td class="DataTD">
									<asp:TextBox id="User_email" Columns="30" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">User can upload files?</font></td>
								<td class="DataTD">
									<asp:CheckBox cssclass="DataFONT" id="User_allow_upload" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify when new Issue is 
										assigned to user?</font></td>
								<td class="DataTD">
									<asp:CheckBox cssclass="DataFONT" id="User_notify_new" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify when Issue originated 
										by user changes?</font></td>
								<td class="DataTD">
									<asp:CheckBox cssclass="DataFONT" id="User_notify_original" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify when Issue assigned to 
										user changes?</font></td>
								<td class="DataTD">
									<asp:CheckBox cssclass="DataFONT" id="User_notify_reassignment" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td align="right" colspan="2">
									<input type="button" id="User_insert" Value="Add" runat="server"> <input type="button" id="User_update" Value="Update" runat="server">
									<input type="button" id="User_delete" Value="Delete" runat="server">
								</td>
							</tr>
						</table>
						<SCRIPT Language="JavaScript">
if (document.forms["User"])
document.User.onsubmit=delconf;
function delconf() {
if (document.User.FormAction.value == 'delete')
  return confirm('Delete record?');
}
						</SCRIPT>
					</td>
				</tr>
			</table>
			<CC:Footer id="Footer" runat="server" />
		</form>
	</body>
</HTML>
