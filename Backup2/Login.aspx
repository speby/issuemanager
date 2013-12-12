<%@ Page language="c#" Codebehind="Login.cs" AutoEventWireup="false" Inherits="IssueManager.Login" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<HTML>
	<HEAD>
		<title>Login</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
		<meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.1 using 'ASP.NET C#.ccp' build 9/27/2001">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta http-equiv="pragma" content="no-cache">
		<meta http-equiv="expires" content="0">
		<meta http-equiv="cache-control" content="no-cache">
		<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
		<link rel="stylesheet" href="Site.css" type="text/css">
			<link rel="stylesheet" href="Footer.css" type="text/css">
				<script>
// Original:  Tom Khoury (twaks@yahoo.com) available free online at
// This script and many more are available free online at
// http://javascript.internet.com/forms/form-focus.html 
function doOnLoad()
{
  if (document.forms.length > 0) {
    var field = document.forms[0];
    for (i = 0; i < field.length; i++) {
      if (
          ((field.elements[i].type == "text") || (field.elements[i].type == "textarea") || 
           (field.elements[i].type == "checkbox") || (field.elements[i].type == "select-one") ||  
           (field.elements[i].type.toString().charAt(0) == "s")) &&
          (!field.elements[i].disabled) && (!field.elements[i].readOnly) && 
          (field.elements[i].FilterList == null) &&
          (field.elements[i].name != "employeeNavControl:sortByList")) {
//          alert("setting focus to " + field.elements[i].name + ", type = " + field.elements[i].type);
          if (field.elements[i].name != "required" && document.forms[0].elements[i].style.visibility != "hidden")
            document.forms[0].elements[i].focus();
        break;
      }
    }
  }
}
				</script>
	</HEAD>
	<body class="PageBODY" onload="doOnLoad();">
		<form method="post" runat="server">
			<CC:Header id="Header" runat="server" />
			<table>
				<tr>
					<td valign="top">
						<table id="Login_holder" runat="Server" class="FormTABLE">
							<tr>
								<td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="LoginForm_Title" runat="server">Login</asp:label></font></td>
							</tr>
							<tr id="Login_trname" runat="server">
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Login</font></td>
								<td class="DataTD"><asp:TextBox id="Login_name" runat="server" /></td>
							</tr>
							<tr id="Login_trpassword" runat="server">
								<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Password</font></td>
								<td class="DataTD"><asp:TextBox TextMode="Password" id="Login_password" runat="server" /></td>
							</tr>
							<tr>
								<td colspan="2" class="ColumnTD">
									<asp:Label id="Login_labelname" cssclass="ColumnFONT" runat="server" />
									<asp:Button id="Login_login" runat="server" />
									&nbsp;&nbsp;&nbsp;
									<asp:Label cssclass="ColumnFONT" Text="Login or Password is incorrect." id="Login_message"
										visible="false" runat="server" />
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
