<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="Settings.cs" AutoEventWireup="false" Inherits="IssueManager.Settings" %>
<HTML>
	<HEAD>
		<title>Issue Manager Settings</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.3 using 'ASP.NET C#.ccp' build 9/27/2001">
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
			<input type="hidden" id="p_Settings_settings_id" runat="server">
			<table>
				<tr>
					<td valign="top">
						<table id="Settings_holder" runat="Server" class="FormTABLE">
							<tr>
								<td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="SettingsForm_Title" runat="server">Application Settings</asp:label></font><br>
								</td>
							</tr>
							<tr>
								<td colspan="2" class="DataTD">
									<asp:Label id="Settings_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
									<input type="hidden" id="Settings_settings_id" value="1" runat="server">
								</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Upload File Extensions</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_file_extensions" Columns="50" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Upload File Path</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_file_path" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify E-mail From (New 
										Issue)</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_notify_new_from" MaxLength="50" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify E-mail Subject (New 
										Issue)</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_notify_new_subject" Columns="50" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify E-mail Body (New 
										Issue)</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_notify_new_body" cssclass="DataFONT" TextMode="MultiLine" Rows="6"
										Columns="50" runat="server"></asp:TextBox>
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify E-mail From (Issue 
										Change)</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_notify_change_from" MaxLength="50" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify E-mail Subject (Issue 
										Change)</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_notify_change_subject" Columns="50" runat="server" />
									&nbsp;</td>
							</tr>
							<tr>
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Notify E-mail Body (Issue 
										Change)</font></td>
								<td class="DataTD">
									<asp:TextBox id="Settings_notify_change_body" cssclass="DataFONT" TextMode="MultiLine" Rows="6"
										Columns="50" runat="server"></asp:TextBox>
									&nbsp;</td>
							</tr>
							<tr>
								<td align="right" colspan="2">
									<input type="button" id="Settings_update" Value="Update" runat="server"> <input type="button" id="Settings_cancel" Value="Cancel" runat="server">
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
