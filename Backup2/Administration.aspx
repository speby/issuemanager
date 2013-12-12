<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="Administration.cs" AutoEventWireup="false" Inherits="IssueManager.Administration" %>
<HTML>
  <HEAD>
    <title>Administration</title>
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
      <table>
        <tr>
          <td valign="top">
            <table id="Administration_holder" runat="Server" class="FormTABLE">
              <tr>
                <td class="FormHeaderTD"><font class="FormHeaderFONT"><asp:label id="AdministrationForm_Title" runat="server">Administration</asp:label></font></td>
              </tr>
              <tr>
                <td class="DataTD">
                  <asp:HyperLink NavigateUrl="Settings.aspx" id="Administration_Field1" cssclass="DataFONT" runat="server">Application Settings</asp:HyperLink></td>
              </tr>
              <tr>
                <td class="DataTD">
                  <asp:HyperLink NavigateUrl="UserList.aspx" id="Administration_Users" cssclass="DataFONT" runat="server">Users</asp:HyperLink></td>
              </tr>
              <tr>
                <td class="DataTD">
                  <asp:HyperLink NavigateUrl="PriorityList.aspx" id="Administration_priorities" cssclass="DataFONT"
                    runat="server">Priorities</asp:HyperLink></td>
              </tr>
              <tr>
                <td class="DataTD">
                  <asp:HyperLink NavigateUrl="StatusList.aspx" id="Administration_status" cssclass="DataFONT" runat="server">Statuses</asp:HyperLink></td>
              </tr>
              <tr>
                <td class="DataTD">
                  <asp:HyperLink NavigateUrl="VersionList.aspx" id="Administration_version" cssclass="DataFONT" runat="server">Versions</asp:HyperLink></td>
              </tr>
              <tr>
                <td class="DataTD">
                  <asp:HyperLink NavigateUrl="IssueList.aspx" id="Administration_Issues" cssclass="DataFONT" runat="server">Issues</asp:HyperLink></td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
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
