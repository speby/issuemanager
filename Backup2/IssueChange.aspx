<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="IssueChange.cs" AutoEventWireup="false" Inherits="IssueManager.IssueChange" %>
<HTML>
  <HEAD>
    <title>UltraApps Issue Manager</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
    <meta name="GENERATOR" content="YesSoftware CodeCharge v.2.0.1 using 'ASP.NET C#.ccp' build 9/27/2001">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="expires" content="0">
    <meta http-equiv="cache-control" content="no-cache">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
    <link rel="stylesheet" href="Site.css" type="text/css">
      <link rel="stylesheet" href="IssueChange.css" type="text/css">
        <link rel="stylesheet" href="Footer.css" type="text/css">
  </HEAD>
  <body class="PageBODY">
    <form method="post" runat="server">
      <CC:Header id="Header" runat="server" />
      <input type="hidden" id="p_Issue_issue_id" runat="server"> <input type="hidden" id="p_Response_response_id" runat="server">
      <input type="hidden" id="p_History_response_id" runat="server"> <input type="hidden" id="p_Files_file_id" runat="server">
      <table>
        <tr>
          <td valign="top">
            <table id="Issue_holder" runat="Server" class="FormTABLE">
              <tr>
                <td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT">
                    <asp:label id="IssueForm_Title" runat="server">Issue #</asp:label>
                    <asp:Label id="IssueForm_issue_id" runat="server"></asp:Label>
                  </font>
                  <br>
                </td>
              </tr>
              <tr>
                <td colspan="2" class="DataTD">
                  <asp:Label id="Issue_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
                  <input type="hidden" id="Issue_issue_id" runat="server">
                </td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Issue Name</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_issue_name" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Issue Desc</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_issue_desc" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Steps to Recreate</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_steps_to_recreate" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_priority_id" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">OPS Status</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_qastatus_id" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Category</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_category_id" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Screen</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_screen" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Product Reason</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_product_id" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Found in Environment</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_bugversion" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Status</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_status_id" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT"> Target Release</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_version" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Issue Number</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_dev_issue_number" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">ITS Number</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_its_number" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Orig Next Action To</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_assigned_to_orig" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Now Next Action To</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_assigned_to" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Orig Assigned For Retest</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_qaassigned_to_orig" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Now Assigned For Retest</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_qaassigned_to" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Submitted by</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_user_id" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Date Submitted</font></td>
                <td class="DataTD">
                  <asp:Label id="Issue_date_submitted" cssclass="DataFONT" runat="server"></asp:Label>
                  &nbsp;</td>
              </tr>
            </table>
            <SCRIPT Language="JavaScript">
if (document.forms["Issues"])
document.Issues.onsubmit=delconf;
function delconf() {
if (document.Issues.FormAction.value == 'delete')
  return confirm('Delete record?');
}
            </SCRIPT>
            <P>
              <asp:HyperLink id="HyperLink2" runat="server" NavigateUrl="UpdatedFiles.aspx">Touched Files</asp:HyperLink></P>
            <P>&nbsp;</P>
            <table id="Files_holder" runat="Server" class="FormTABLE">
              <TBODY>
	<tr>
                  <td colspan="5" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="FilesForm_Title" runat="server">Attached Files</asp:label></font></td>
                </tr>
<tr>
                  <td class="ColumnTD"><asp:Label id="Files_Column_file_name" Text="File Name" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Files_Column_uploaded_by" Text="Uploaded By" cssclass="ColumnFONT" runat="server" /></td>
                  <td class="ColumnTD"><asp:Label id="Files_Column_date_uploaded" Text="Date / Time" cssclass="ColumnFONT" runat="server" /></td>
                </tr><tr id="Files_no_records" runat="server">
                  <td class="DataTD" colspan="5"><font class="DataFONT">No records</font></td>
                </tr>
	<tr>
                  <td><asp:Repeater id="Files_Repeater" onitemdatabound="Files_Repeater_ItemDataBound" runat="server">
                      <HeaderTemplate>
                  </td>
                </tr>
	</HeaderTemplate>
	<ItemTemplate>
                  <tr>
                    <td class="DataTD">
                      <asp:HyperLink id=Files_file_name NavigateUrl='<%#  DataBinder.Eval(Container.DataItem, "f_file_name")+"?" +""%>' cssclass="DataFONT" runat="server">
                        <%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_file_name").ToString()) %>
                      </asp:HyperLink>&nbsp;
                    </td>
                    <td class="DataTD">
                      <asp:Label id="Files_uploaded_by" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_name").ToString()) %>
                      </asp:Label>&nbsp;
                    </td>
                    <td class="DataTD">
                      <input type=hidden id=Files_file_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_file_id").ToString()) %>'>
                      <input type=hidden id=Files_issue_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_issue_id").ToString()) %>'>
                      <asp:Label id="Files_date_uploaded" cssclass="DataFONT" runat="server">
                        <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_date_uploaded").ToString().Replace('T', ' ')) %>
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
      </table>
      <table id="Response_holder" runat="Server" class="FormTABLE">
        <tr>
          <td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="ResponseForm_Title" runat="server">Response</asp:label></font><br>
          </td>
        </tr>
        <tr>
          <td colspan="2" class="DataTD">
            <asp:Label id="Response_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
            <input type="hidden" id="Response_response_id" runat="server"> <input type="hidden" id="Response_issue_id" runat="server">
            <input type="hidden" id="Response_user_id" runat="server"> <input type="hidden" id="Response_date_response" runat="server">
            <input type="hidden" id="Response_date_modified" runat="server"> <input type="hidden" id="Response_modified_by" runat="server">
            <input type="hidden" id="Response_date_resolved" runat="server">
          </td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Response</font></td>
          <td class="DataTD">
            <asp:TextBox id="Response_response" cssclass="DataFONT" TextMode="MultiLine" Rows="6" Columns="60"
              runat="server"></asp:TextBox>
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">New OPS Status</font>
            <asp:RequiredFieldValidator id="Response_qastatus_id_Validator_Req" runat="server" ErrorMessage="The value in field New OPS Status is required."
              ControlToValidate="Response_qastatus_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_qastatus_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
              EnableClientScript="False" ErrorMessage="The value in field New OPS Status is incorrect." ControlToValidate="Response_qastatus_id"
              display="None"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList cssclass="DataFONT" id="Response_qastatus_id" DataTextField="qastatus" DataValueField="qastatus_id"
              runat="server" OnSelectedIndexChanged="Response_qastatus_id_SelectedIndexChanged" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Product Reason</font>
            <asp:RequiredFieldValidator id="Response_product_id_Validator_Req" runat="server" display="None" ControlToValidate="Response_product_id"
              ErrorMessage="The value in field Product Reason is required." EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_product_id_Validator_Num" runat="server" display="None" ControlToValidate="Response_product_id"
              ErrorMessage="The value in field Product Reason is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList id="Response_product_id" runat="server" cssclass="DataFONT" DataValueField="product_id"
              DataTextField="product_id" />
            &nbsp;</td>
        </tr>        
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Found in Environment</font>
            <asp:RequiredFieldValidator id="Response_bugversion_Validator_Req" runat="server" display="None" ControlToValidate="Response_bugversion"
              ErrorMessage="The value in field Fixed in Version is required." EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_bugversion_Validator_Num" runat="server" display="None" ControlToValidate="Response_bugversion"
              ErrorMessage="The value in field Fixed in Version is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList id="Response_bugversion" runat="server" cssclass="DataFONT" DataValueField="category_id"
              DataTextField="category" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT"></font><FONT face="Arial" color="#ffffff" size="2">Target 
              Release</FONT>
            <asp:RequiredFieldValidator id="Response_version_Validator_Req" runat="server" display="None" ControlToValidate="Response_version"
              ErrorMessage="The value in field Found in Environment is required." EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_version_Validator_Num" runat="server" display="None" ControlToValidate="Response_version"
              ErrorMessage="The value in field Found in Environment is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList id="Response_version" runat="server" cssclass="DataFONT" DataValueField="category_id"
              DataTextField="category" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Next Action&nbsp;To</font>
            <asp:CustomValidator id="Response_assigned_to_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
              EnableClientScript="False" ErrorMessage="The value in field Dev ReAssign To is incorrect." ControlToValidate="Response_assigned_to"
              display="None"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList cssclass="DataFONT" id="Response_assigned_to" DataTextField="user_name" DataValueField="user_id"
              runat="server" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Assigned For Retest To</font>
            <asp:CustomValidator id="Response_qaassigned_to_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
              EnableClientScript="False" ErrorMessage="The value in field QA ReAssign To is incorrect." ControlToValidate="Response_qaassigned_to"
              display="None"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList cssclass="DataFONT" id="Response_qaassigned_to" DataTextField="user_name" DataValueField="user_id"
              runat="server" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Dev Issue Number</font></td>
          <td class="DataTD"><asp:textbox id="Response_dev_issue_number" runat="server" cssclass="DataFONT"></asp:textbox>&nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">ITS Number</font></td>
          <td class="DataTD"><asp:textbox id="Response_its_number" runat="server" cssclass="DataFONT"></asp:textbox>&nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Priority</font>
            <asp:RequiredFieldValidator id="Response_priority_id_Validator_Req" runat="server" ErrorMessage="The value in field Priority is required."
              ControlToValidate="Response_priority_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_priority_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
              EnableClientScript="False" ErrorMessage="The value in field Priority is incorrect." ControlToValidate="Response_priority_id"
              display="None"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList cssclass="DataFONT" id="Response_priority_id" DataTextField="priority_desc" DataValueField="priority_id"
              runat="server" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">New Dev Status</font>
            <asp:RequiredFieldValidator id="Response_status_id_Validator_Req" runat="server" ErrorMessage="The value in field New Dev Status is required."
              ControlToValidate="Response_status_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_status_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
              EnableClientScript="False" ErrorMessage="The value in field New Dev Status is incorrect." ControlToValidate="Response_status_id"
              display="None"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList cssclass="DataFONT" id="Response_status_id" DataTextField="status" DataValueField="status_id"
              runat="server" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">New Category</font>
            <asp:RequiredFieldValidator id="Response_category_id_Validator_Req" runat="server" ErrorMessage="The value in field Category is required."
              ControlToValidate="Response_category_id" display="None" EnableClientScript="False"></asp:RequiredFieldValidator>
            <asp:CustomValidator id="Response_category_id_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
              EnableClientScript="False" ErrorMessage="The value in field Category is incorrect." ControlToValidate="Response_category_id"
              display="None"></asp:CustomValidator></td>
          <td class="DataTD">
            <asp:DropDownList cssclass="DataFONT" id="Response_category_id" DataTextField="category" DataValueField="category_id"
              runat="server" />
            &nbsp;</td>
        </tr>
        <tr>
          <td class="FieldCaptionTD"><font class="FieldCaptionFONT">File Upload</font></td>
          <td class="DataTD">
            <asp:Label id="Response_Field1" cssclass="DataFONT" runat="server"></asp:Label>
            &nbsp;</td>
        </tr>
        <tr>
          <td align="right" colspan="2">
            <input type="button" id="Response_insert" Value="Submit" runat="server">
          </td>
        </tr>
      </table>
      <SCRIPT Language="JavaScript">
        if (document.forms["Response"]){
          document.Response.encoding="multipart/form-data";
        }
      </SCRIPT>
      </TD><td valign="top">
        <table id="History_holder" runat="Server" class="HistoryFormTABLE">
          <TBODY>
          	<tr>
              <td colspan="2" class="HistoryFormHeaderTD"><font class="HistoryFormHeaderFONT"><asp:label id="HistoryForm_Title" runat="server">Response History</asp:label></font></td>
            </tr>
            <tr id="History_no_records" runat="server">
              <td class="HistoryDataTD" colspan="8"><font class="HistoryDataFONT">No records</font></td>
            </tr>
	          <tr>
              <td><asp:Repeater id="History_Repeater" onitemdatabound="History_Repeater_ItemDataBound" runat="server">
                  <HeaderTemplate>
              </td>
            </tr>
	        </HeaderTemplate>
	         <ItemTemplate>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="By" id="user_id_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_user_id" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_name").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Date" id="date_response_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_date_response" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "r_date_response").ToString().Replace('T', ' ')) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Response" id="response_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_response" cssclass="HistoryDataFONT" runat="server">
                    <%# DataBinder.Eval(Container.DataItem, "r_response") %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Next Action To" id="assigned_to_Column_Title" cssclass="HistoryColumnFONT"
                    runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_assigned_to" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u1_user_name").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Assigned For Retest" id="qaassigned_to_Column_Title" cssclass="HistoryColumnFONT"
                    runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_qaassigned_to" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u2_user_name").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Priority" id="priority_id_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_priority_id" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "p_priority_desc").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Dev Status" id="status_id_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_status_id" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "s_status").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="OPS Status" id="qastatus_id_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_qastatus_id" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "qs_qastatus").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
              <tr>
                <td class="HistoryColumnTD">
                  <asp:Label Text="Category" id="category_id_Column_Title" cssclass="HistoryColumnFONT" runat="server" /></td>
                <td class="HistoryDataTD">
                  <asp:Label id="History_category_id" cssclass="HistoryDataFONT" runat="server">
                    <%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "c_category").ToString()) %>
                  </asp:Label>&nbsp;
                </td>
              </tr>
            </ItemTemplate>

	          <SeparatorTemplate>
              <tr>
                <td colspan="2" class="HistoryRecordSeparatorTD">&nbsp;</td>
              </tr>
            </SeparatorTemplate>

	          <FooterTemplate>
              <tr>
                <td>
            </FooterTemplate>
        </asp:Repeater></td>
      </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <P>&nbsp;</P>
      <P>
        <CC:Footer id="Footer" runat="server" />
    </form>
    </P>
  </body>
</HTML>
