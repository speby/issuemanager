<%@ Control language="c#" Codebehind="Header.cs" AutoEventWireup="false" Inherits="IssueManager.Header" %>
<table><tr><td valign="top" >


  <table id="Menu_holder" runat="Server" class="FormTABLE">
  
  <tr>
  
    <td class="DataTD">
    <asp:HyperLink NavigateUrl="Default.aspx" id=Menu_Field4
cssclass="DataFONT" runat="server">IssueManager Home</asp:HyperLink></td>
    <td class="DataTD">
    <asp:HyperLink NavigateUrl="IssueNew.aspx" id=Menu_Field2
cssclass="DataFONT" runat="server">Add New Issue</asp:HyperLink></td>
    <td class="DataTD">
    <asp:HyperLink NavigateUrl="UserProfile.aspx" id=Menu_Field6
cssclass="DataFONT" runat="server">My Profile</asp:HyperLink></td>
    <td class="DataTD">
    <asp:HyperLink NavigateUrl="Login.aspx" id=Menu_Field5
cssclass="DataFONT" runat="server">Login / Logout</asp:HyperLink></td>
    <td class="DataTD">
    <asp:HyperLink NavigateUrl="Administration.aspx" id=Menu_Field3
cssclass="DataFONT" runat="server">Administration</asp:HyperLink></td>
    </tr>
  </table>

</td>
    </tr></table>