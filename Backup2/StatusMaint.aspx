<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="StatusMaint.cs" AutoEventWireup="false" Inherits="IssueManager.StatusMaint" %>
<HTML>
  <HEAD>
    <title>UltraApps Issue Manager - Status Maintenance</title>
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
      <input type="hidden" id="p_StatusMaint_status_id" runat="server">
      <table>
        <tr>
          <td valign="top">
            <table id="StatusMaint_holder" runat="Server" class="FormTABLE">
              <tr>
                <td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="StatusMaintForm_Title" runat="server">Add/Edit Status</asp:label></font><br>
                </td>
              </tr>
              <tr>
                <td colspan="2" class="DataTD">
                  <asp:Label id="StatusMaint_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
                  <input type="hidden" id="StatusMaint_status_id" runat="server">
                </td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Status</font>
                  <asp:RequiredFieldValidator id="StatusMaint_status_Validator_Req" runat="server" ErrorMessage="The value in field Status is required." ControlToValidate="StatusMaint_status" display="None" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                <td class="DataTD">
                  <asp:TextBox id="StatusMaint_status" Columns="20" runat="server" />
                  &nbsp;</td>
              </tr>
              <tr>
                <td align="right" colspan="2">
                  <input type="button" id="StatusMaint_insert" Value="Add" runat="server"> <input type="button" id="StatusMaint_update" Value="Update" runat="server">
                  <input type="button" id="StatusMaint_delete" Value="Delete" runat="server">
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
