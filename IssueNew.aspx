<%@ Page language="c#" Codebehind="IssueNew.cs" AutoEventWireup="false" Inherits="IssueManager.IssueNew" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
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
            <table class="FormTABLE" id="Issues_holder" runat="Server">
              <TBODY>
                <tr>
                  <td class="FormHeaderTD" colSpan="2"><font class="FormHeaderFONT"><asp:label id="IssuesForm_Title" runat="server">Add Issue</asp:label></font><br>
                  </td>
                </tr>
                <tr>
                  <td class="DataTD" colSpan="2"><asp:label id="Issues_ValidationSummary" runat="server" cssclass="DataTD" Visible="false"></asp:label><input id="Issues_issue_id" type="hidden" runat="server">
                    <input id="Issues_date_submitted" type="hidden" runat="server"> <input id="Issues_submitted_by" type="hidden" runat="server">
                    <input id="Issues_date_modified" type="hidden" runat="server"> <input id="Issues_assigned_to_orig" type="hidden" runat="server">
                    <input id="Issues_qaassigned_to_orig" type="hidden" runat="server">
                  </td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Issue Name</font>
                    <asp:requiredfieldvalidator id="Issues_issue_name_Validator_Req" runat="server" ErrorMessage="The value in field Issue Name is required."
                      ControlToValidate="Issues_issue_name" display="None" EnableClientScript="False"></asp:requiredfieldvalidator></td>
                  <td class="DataTD"><asp:textbox id="Issues_issue_name" runat="server" Columns="90" MaxLength="100"></asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Issue Desc</font>
                    <asp:requiredfieldvalidator id="Issues_issue_desc_Validator_Req" runat="server" ErrorMessage="The value in field Issue Desc is required."
                      ControlToValidate="Issues_issue_desc" display="None" EnableClientScript="False"></asp:requiredfieldvalidator></td>
                  <td class="DataTD"><asp:textbox id="Issues_issue_desc" runat="server" cssclass="DataFONT" Columns="80" TextMode="MultiLine"
                      Rows="6"></asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Steps to Recreate</font>
                    <asp:requiredfieldvalidator id="Issues_steps_to_recreate_Validator_Req" runat="server" ErrorMessage="The value in field Steps to Recreate is required."
                      ControlToValidate="Issues_steps_to_recreate" display="None" EnableClientScript="False"></asp:requiredfieldvalidator></td>
                  <td class="DataTD"><asp:textbox id="Issues_steps_to_recreate" runat="server" cssclass="DataFONT" Columns="80" TextMode="MultiLine"
                      Rows="6"></asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font>
                    <asp:requiredfieldvalidator id="Issues_priority_id_Validator_Req" runat="server" ErrorMessage="The value in field Priority is required."
                      ControlToValidate="Issues_priority_id" display="None" EnableClientScript="False"></asp:requiredfieldvalidator><asp:customvalidator id="Issues_priority_id_Validator_Num" runat="server" ErrorMessage="The value in field Priority is incorrect."
                      ControlToValidate="Issues_priority_id" display="None" EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_priority_id" runat="server" cssclass="DataFONT" DataTextField="priority_desc"
                      DataValueField="priority_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">OPS Status</font>
                    <asp:requiredfieldvalidator id="Issues_qastatus_id_Validator_Req" runat="server" ErrorMessage="The value in field Status is required."
                      ControlToValidate="Issues_qastatus_id" display="None" EnableClientScript="False"></asp:requiredfieldvalidator><asp:customvalidator id="Issues_qastatus_id_Validator_Num" runat="server" ErrorMessage="The value in field Status is incorrect."
                      ControlToValidate="Issues_qastatus_id" display="None" EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_qastatus_id" runat="server" cssclass="DataFONT" DataTextField="qastatus"
                      DataValueField="qastatus_id" OnSelectedIndexChanged="Issues_qastatus_id_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Category</font>
                    <asp:requiredfieldvalidator id="Issues_category_id_Validator_Req" runat="server" ErrorMessage="The value in field Status is required."
                      ControlToValidate="Issues_category_id" display="None" EnableClientScript="False"></asp:requiredfieldvalidator><asp:customvalidator id="Issues_category_id_Validator_Num" runat="server" ErrorMessage="The value in field Status is incorrect."
                      ControlToValidate="Issues_category_id" display="None" EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_category_id" runat="server" cssclass="DataFONT" DataTextField="category"
                      DataValueField="category_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Product Reason</font>
                  <td class="DataTD"><asp:dropdownlist id="Issues_product_id" runat="server" cssclass="DataFONT" DataTextField="product"
                      DataValueField="product_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Screen/Module</font>
                    <asp:requiredfieldvalidator id="Issues_screen_Validator_Req" runat="server" ErrorMessage="The value in field Screen is required."
                      ControlToValidate="Issues_screen" display="None" EnableClientScript="False"></asp:requiredfieldvalidator></td>
                  <td class="DataTD"><asp:textbox id="Issues_screen" runat="server" cssclass="DataFONT" Width="504px"></asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Found in Environment</font></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_bugversion" runat="server" cssclass="DataFONT" DataTextField="bugversion"
                      DataValueField="bugversion_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Status</font>
                    <asp:requiredfieldvalidator id="Issues_status_id_Validator_Req" runat="server" ErrorMessage="The value in field Status is required."
                      ControlToValidate="Issues_status_id" display="None" EnableClientScript="False"></asp:requiredfieldvalidator><asp:customvalidator id="Issues_status_id_Validator_Num" runat="server" ErrorMessage="The value in field Status is incorrect."
                      ControlToValidate="Issues_status_id" display="None" EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_status_id" runat="server" cssclass="DataFONT" DataTextField="status"
                      DataValueField="status_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Issue Number</font></td>
                  <td class="DataTD"><asp:textbox id="Issues_dev_number" runat="server" cssclass="DataFONT"></asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">ITS Number</font></td>
                  <td class="DataTD"><asp:textbox id="Issues_its_number" runat="server" cssclass="DataFONT"></asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD">
                    <P><font class="FieldCaptionFONT"> Target Release</font></P>
                  </td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_version" runat="server" cssclass="DataFONT" DataTextField="version" DataValueField="version_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Next Action To</font>&nbsp;
                    <asp:customvalidator id="Issues_assigned_to_Validator_Num" runat="server" ErrorMessage="The value in field Assigned To is incorrect."
                      ControlToValidate="Issues_assigned_to" display="None" EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_assigned_to" runat="server" cssclass="DataFONT" DataTextField="user_name"
                      DataValueField="user_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Assigned&nbsp;For Retest</font>&nbsp;
                    <asp:customvalidator id="Issues_qaassigned_to_Validator_Num" runat="server" ErrorMessage="The value in field Assigned To is incorrect."
                      ControlToValidate="Issues_qaassigned_to" display="None" EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></td>
                  <td class="DataTD"><asp:dropdownlist id="Issues_qaassigned_to" runat="server" cssclass="DataFONT" DataTextField="user_name"
                      DataValueField="user_id"></asp:dropdownlist>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Submitted by</font></td>
                  <td class="DataTD"><asp:label id="Issues_submitted_by_l" runat="server" cssclass="DataFONT"></asp:label>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Date Submitted</font></td>
                  <td class="DataTD"><asp:label id="Issues_date_submitted_l" runat="server" cssclass="DataFONT"></asp:label>&nbsp;</td>
                </tr>
                <tr>
                  <td class="FieldCaptionTD"><font class="FieldCaptionFONT">File Upload</font></td>
                  <td class="DataTD"><asp:label id="Issues_Field1" runat="server" cssclass="DataFONT"></asp:label>&nbsp;</td>
                </tr>
                <tr>
                  <td align="right" colSpan="2"><input id="Issues_insert" type="button" value="Submit" runat="server">
                  </td>
                </tr>
              </TBODY></table>
            <SCRIPT language="JavaScript">
if (document.forms["Issues"]){
document.Issues.encoding="multipart/form-data";
}
            </SCRIPT>
          </td>
        </tr>
      </table>
      <CC:FOOTER id="Footer" runat="server"></CC:FOOTER></form>
  </body>
</HTML>
