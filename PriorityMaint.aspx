<%@ Page language="c#" Codebehind="PriorityMaint.cs" AutoEventWireup="false" Inherits="IssueManager.PriorityMaint" %><%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %><%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %><%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<html>
  <head>
	<title>Priority Maintenance</title>
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
	<input type=hidden id=p_PriorityMaint_priority_id runat=server />
	
<table><tr><td valign="top" >

<table  id="PriorityMaint_holder" runat="Server" class="FormTABLE">
	<tr><td colspan=2 class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="PriorityMaintForm_Title" runat="server">Add/Edit Priority</asp:label></font><br>
	</td></tr>
	<tr><td colspan="2" class="DataTD">
	<asp:Label id=PriorityMaint_ValidationSummary cssclass="DataTD" runat="server" Visible="false"></asp:Label>
	<input type="Hidden" id="PriorityMaint_priority_id" value="" runat="server">
</td></tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font>
	<asp:RequiredFieldValidator id=PriorityMaint_priority_desc_Validator_Req runat="server" ErrorMessage="The value in field Priority is required." ControlToValidate="PriorityMaint_priority_desc" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
    	<td class="DataTD">
        <asp:TextBox
	id=PriorityMaint_priority_desc
 Columns=15
	runat="server"/>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Font Color</font></td>
    	<td class="DataTD">
        <asp:TextBox
	id=PriorityMaint_priority_color
 Columns=15 MaxLength=30
	runat="server"/>
&nbsp;</td>
	</tr><tr>
	<td class="FieldCaptionTD"><font class="FieldCaptionFONT">Order</font>
	<asp:CustomValidator  id=PriorityMaint_priority_order_Validator_Num OnServerValidate="ValidateNumeric" runat="server" EnableClientScript="False" ErrorMessage="The value in field Order is incorrect." ControlToValidate="PriorityMaint_priority_order" display="None"></asp:CustomValidator ></td>
    	<td class="DataTD">
        <asp:TextBox
	id=PriorityMaint_priority_order
 Columns=15 MaxLength=15
	runat="server"/>
&nbsp;</td>
	</tr>
    <tr><td align=right colspan=2 >
	<input type="button"
		id=PriorityMaint_insert
		Value="Add"
		runat="server" >
	
	<input type="button"
		id=PriorityMaint_update
		Value="Update"
		runat="server" >
	
	<input type="button"
		id=PriorityMaint_delete
		Value="Delete"
		runat="server" >
	
    </td></tr>

	</table>

</td>
    </tr></table>

<CC:Footer id="Footer" runat="server"/>

    </form>
</body>
</html>