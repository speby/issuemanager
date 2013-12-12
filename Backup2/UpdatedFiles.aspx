<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="UpdatedFiles.cs" AutoEventWireup="false" Inherits="IssueManager.UpdatedFiles" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
    <HEAD>
        <title>UpdatedFiles</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
        <LINK href="Site.css" type="text/css" rel="stylesheet">
            <LINK href="IssueChange.css" type="text/css" rel="stylesheet">
                <LINK href="Footer.css" type="text/css" rel="stylesheet">
    </HEAD>
    <body class="PageBODY" MS_POSITIONING="FlowLayout">
        <form id="Form1" method="post" runat="server">
            <P><cc:header id="Header1" runat="server"></cc:header></P>
            <P>&nbsp;
                <asp:label id="Label1" runat="server" CssClass="DataTD">Label</asp:label></P>
            <P><asp:repeater id="Repeater" runat="server">
                    <headertemplate>
                        <table width="90%" cellpadding="5">
                            <tr style="background-color:#ddc">
                                <th class="FieldCaptionTD">
                                    <asp:LinkButton ID="HyperLinkFileSort" OnClick="Files_SortChange" CommandArgument="dir" Runat="server"
                                        CssClass="ColumnFONT" Text="Directory"></asp:LinkButton></th>
                                <th class="FieldCaptionTD">
                                    <asp:LinkButton ID="FileSort" OnClick="Files_SortChange" CommandArgument="file" Runat="server" CssClass="ColumnFONT"
                                        Text="File"></asp:LinkButton></th>
                                <th class="FieldCaptionTD">
                                    <asp:LinkButton ID="Repository" OnClick="Files_SortChange" CommandArgument="repository" Runat="server"
                                        CssClass="ColumnFONT" Text="Repository"></asp:LinkButton></th>
                                <th class="FieldCaptionTD">
                                    <asp:LinkButton ID="Revision" OnClick="Files_SortChange" CommandArgument="revision" Runat="server"
                                        CssClass="ColumnFONT" Text="Revision"></asp:LinkButton></th>
                                <th class="FieldCaptionTD">
                                    <asp:LinkButton ID="Description" OnClick="Files_SortChange" CommandArgument="description" Runat="server"
                                        CssClass="ColumnFONT" Text="Description"></asp:LinkButton></th>
                            </tr>
                    </headertemplate>
                    <itemtemplate>
                        <tr class="DataTD">
                            <td>
                                <asp:Label>
                                    <%# DataBinder.Eval ( Container.DataItem, "dir" ) %>
                                </asp:Label></td>
                            <!--      <td align="left"><%# DataBinder.Eval ( Container.DataItem, "file" ) %></td> -->
                            <!--             <td align="left"><asp:HyperLink NavigateUrl="http://swingline/cvsweb/viewcvs.cgi/<%# DataBinder.Eval ( Container.DataItem, "dir" ) %>/<%# DataBinder.Eval ( Container.DataItem, "file" ) %>?rev=<%# DataBinder.Eval ( Container.DataItem, "revision" ) %>&cvsroot=Development&content-type=text/vnd.viewcvs-markup"></asp:HyperLink> </td> -->
                            <td align="left">
                            <a href = "http://swingline/cvsweb/viewcvs.cgi/<%#DataBinder.Eval ( Container.DataItem, "dir" )%>/<%#DataBinder.Eval ( Container.DataItem, "file" )%>?rev=<%#DataBinder.Eval ( Container.DataItem, "revision" )%>&cvsroot=Development&content-type=text/vnd.viewcvs-markup"><%# DataBinder.Eval ( Container.DataItem, "file" ) %></a>
                                
                            </td>
                            <td align="left"><%# DataBinder.Eval ( Container.DataItem, "repository" ) %></td>
                            <td align="left">
                                <%# DataBinder.Eval ( Container.DataItem, "revision" ) %>
                            </td>
                            <td align="left">
                                <%# DataBinder.Eval ( Container.DataItem, "description" ) %>
                            </td>
                        </tr>
                    </itemtemplate>
                    <footertemplate>
                        </table>
                    </footertemplate>
                </asp:repeater></P>
            <P><asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" CellPadding="4" CssClass="ColumnTD">
                    <SelectedItemStyle CssClass="FieldCaptionTD"></SelectedItemStyle>
                    <ItemStyle CssClass="DataTD"></ItemStyle>
                    <HeaderStyle CssClass="FieldCaptionTD"></HeaderStyle>
                    <FooterStyle CssClass="FieldCaptionTD"></FooterStyle>
                    <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
                </asp:datagrid></P>
            <P><cc:footer id="Footer1" runat="server"></cc:footer></P>
            <P>&nbsp;</P>
            <P>
                </P>
        </form>
        <P>&nbsp;</P>
        <P>&nbsp;</P>
    </body>
</HTML>
