<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="FileMaint.cs" AutoEventWireup="false" Inherits="IssueManager.FileMaint" %>
<HTML>
  <HEAD>
    <title>IssueManagerNew</title>
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
      <input type="hidden" id="p_Files_file_id" runat="server">
      <table>
        <tr>
          <td valign="top">
            <table id="Files_holder" runat="Server" class="FormTABLE">
              <tr>
                <td colspan="2" class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="FilesForm_Title" runat="server">Attacted Files</asp:label></font><br>
                </td>
              </tr>
              <tr>
                <td colspan="2" class="DataTD">
                  <asp:Label id="Files_ValidationSummary" cssclass="DataTD" runat="server" Visible="false"></asp:Label>
                  <input type="hidden" id="Files_file_id" runat="server"> <input type="hidden" id="Files_issue_id" runat="server">
                </td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">File Name</font></td>
                <td class="DataTD">
                  <asp:TextBox id="Files_file_name" Columns="100" MaxLength="100" runat="server" />
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Uploaded By</font>
                  <asp:CustomValidator id="Files_uploaded_by_Validator_Num" OnServerValidate="ValidateNumeric" runat="server"
                    EnableClientScript="False" ErrorMessage="The value in field Uploaded By is incorrect." ControlToValidate="Files_uploaded_by"
                    display="None"></asp:CustomValidator></td>
                <td class="DataTD">
                  <asp:DropDownList cssclass="DataFONT" id="Files_uploaded_by" DataTextField="user_name" DataValueField="user_id"
                    runat="server" />
                  &nbsp;</td>
              </tr>
              <tr>
                <td class="FieldCaptionTD"><font class="FieldCaptionFONT">Date / Time</font></td>
                <td class="DataTD">
                  <asp:TextBox id="Files_date_uploaded" Columns="10" runat="server" />
                  &nbsp;</td>
              </tr>
              <tr>
                <td align="right" colspan="2">
                  <input type="button" id="Files_update" Value="Update" runat="server"> <input type="button" id="Files_delete" Value="Delete" runat="server">
                  <input type="button" id="Files_cancel" Value="Cancel" runat="server">
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
