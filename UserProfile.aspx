<%@ Page language="c#" Codebehind="UserProfile.cs" AutoEventWireup="false" Inherits="IssueManager.UserProfile" %><%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %><%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %><%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<html>
  <head>
	<title>User Profile</title>
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
	<input type=hidden id=p_User_user_id runat=server />
	
<table><tr><td valign="top" >

<table  id="User_holder" runat="Server" class="FormTABLE">
	<tr><td colspan=2 class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="UserForm_Title" runat="server">My Profile</asp:label></font><br>
	</td></tr>
	<tr><td colspan="2" class="DataTD">
	<asp:Label id=User_ValidationSummary cssclass="DataTD" runat="server" Visible="false"></asp:Label>
	<input type="Hidden" id="User_user_id" value="" runat="server">
</td></tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Name</font></td>
    	<td class="DataTD">
        
	<asp:Label id=User_user_name
cssclass="DataFONT" runat="server">
	
	</asp:Label>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Login</font></td>
    	<td class="DataTD">
        
	<asp:Label id=User_login
cssclass="DataFONT" runat="server">
	
	</asp:Label>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Password</font>
	<asp:RequiredFieldValidator id=User_pass_Validator_Req runat="server" ErrorMessage="The value in field Password is required." ControlToValidate="User_pass" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
    	<td class="DataTD">
        <asp:TextBox
	id=User_pass
 TextMode=Password Columns=15
	runat="server"/>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Alert Me when new Issue is Assigned to Me?</font></td>
    	<td class="DataTD">
        
	<asp:CheckBox cssclass="DataFONT" id=User_notify_new runat="server"/>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Alert Me when Issue originated by Myself changes?</font></td>
    	<td class="DataTD">
        
	<asp:CheckBox cssclass="DataFONT" id=User_notify_original runat="server"/>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Alert Me when Issue Assigned to Me changes?<br>(for example when I respond to it)</font></td>
    	<td class="DataTD">
        
	<asp:CheckBox cssclass="DataFONT" id=User_notify_reassignment runat="server"/>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Can I upload files?</font></td>
    	<td class="DataTD">
        
	<asp:Label id=User_allow_upload
cssclass="DataFONT" runat="server">
	
	</asp:Label>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Security Level</font></td>
    	<td class="DataTD">
        
	<asp:Label id=User_security_level
cssclass="DataFONT" runat="server">
	
	</asp:Label>
&nbsp;</td>
	</tr>
    <tr><td align=right colspan=2 >
	<input type="button"
		id=User_update
		Value="Update"
		runat="server" >
	
    </td></tr>

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
    </tr></table>

<CC:Footer id="Footer" runat="server"/>

    </form>
</body>
</html>