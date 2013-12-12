<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="ResponseMaint.cs" AutoEventWireup="false" Inherits="IssueManager.ResponseMaint" %>
<HTML>
	<HEAD>
		<title>Response Edit</title>
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
			<input type="hidden" id="p_Response_response_id" runat="server">
			<table>
				<tr>
					<td valign="top">
						<table id="Response_holder" runat="Server" class="FormTABLE">
							<tr>
								<td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="ResponseForm_Title" runat="server">Edit Response</asp:label></font><br>
								</td>
							</tr>
							<tr>
								<td colspan="2" class="DataTD">
									<asp:Label id="Response_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
									<input type="hidden" id="Response_response_id" runat="server">
								</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">By</font>
									<asp:CustomValidator id="Response_user_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server" EnableClientScript="False" ErrorMessage="The value in field By is incorrect." ControlToValidate="Response_user_id" display="None"></asp:CustomValidator></td>
								<td class="DataTD">
									<asp:DropDownList cssclass="DataFONT" id="Response_user_id" DataTextField="user_name" DataValueField="user_id" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Date</font></td>
								<td class="DataTD">
									<asp:TextBox id="Response_date_response" MaxLength="10" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Response</font></td>
								<td class="DataTD">
									<asp:TextBox id="Response_response" cssclass="DataFONT" TextMode="MultiLine" Columns="50" runat="server"></asp:TextBox>
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Assigned To</font>
									<asp:CustomValidator id="Response_assigned_to_Validator_Num" OnServerValidate="ValidateNumeric" runat="server" EnableClientScript="False" ErrorMessage="The value in field Assigned To is incorrect." ControlToValidate="Response_assigned_to" display="None"></asp:CustomValidator></td>
								<td class="DataTD">
									<asp:DropDownList cssclass="DataFONT" id="Response_assigned_to" DataTextField="user_name" DataValueField="user_id" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Assigned To</font>
									<asp:CustomValidator id="Response_qaassigned_to_Validator_Num" OnServerValidate="ValidateNumeric" runat="server" EnableClientScript="False" ErrorMessage="The value in field Assigned To is incorrect." ControlToValidate="Response_qaassigned_to" display="None"></asp:CustomValidator></td>
								<td class="DataTD">
									<asp:DropDownList cssclass="DataFONT" id="Response_qaassigned_to" DataTextField="user_name" DataValueField="user_id" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font>
									<asp:RequiredFieldValidator id="Response_priority_id_Validator_Req" runat="server" ErrorMessage="The value in field Priority is required." ControlToValidate="Response_priority_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
									<asp:CustomValidator id="Response_priority_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server" EnableClientScript="False" ErrorMessage="The value in field Priority is incorrect." ControlToValidate="Response_priority_id" display="None"></asp:CustomValidator></td>
								<td class="DataTD">
									<asp:DropDownList cssclass="DataFONT" id="Response_priority_id" DataTextField="priority_desc" DataValueField="priority_id" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Status</font>
									<asp:RequiredFieldValidator id="Response_status_id_Validator_Req" runat="server" ErrorMessage="The value in field Status is required." ControlToValidate="Response_status_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
									<asp:CustomValidator id="Response_status_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server" EnableClientScript="False" ErrorMessage="The value in field Status is incorrect." ControlToValidate="Response_status_id" display="None"></asp:CustomValidator></td>
								<td class="DataTD">
									<asp:DropDownList cssclass="DataFONT" id="Response_status_id" DataTextField="status" DataValueField="status_id" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td align="right" colspan="2">
									<input type="button" id="Response_update" Value="Update" runat="server"> <input type="button" id="Response_delete" Value="Delete" runat="server">
									<input type="button" id="Response_cancel" Value="Cancel" runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<CC:Footer id="Footer" runat="server" />
		</form>
	</body>
</HTML>
