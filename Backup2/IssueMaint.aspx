<%@ Page language="c#" Codebehind="IssueMaint.cs" AutoEventWireup="false" Inherits="IssueManager.IssueMaint" %>
<%@ Register TagPrefix="CC" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="CC" TagName="Footer" Src="Footer.ascx" %>
<%@Register TagPrefix="CC" TagName="Pager" Src="CCPager.ascx"%>

<HTML>
  <HEAD>
		<title>UltraApps Issue Manager</title>
<meta content=http://schemas.microsoft.com/intellisense/ie3-2nav3-0 
name=vs_targetSchema>
<meta 
content="YesSoftware CodeCharge v.2.0.1 using 'ASP.NET C#.ccp' build 9/27/2001" 
name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta http-equiv=pragma content=no-cache>
<meta http-equiv=expires content=0>
<meta http-equiv=cache-control content=no-cache>
<meta http-equiv=Content-Type content="text/html; charset=ISO-8859-1"><LINK href="Site.css" type=text/css rel=stylesheet ><LINK href="Footer.css" type=text/css rel=stylesheet >
  </HEAD>
<body class=PageBODY>
<form method=post runat="server"><CC:HEADER id=Header runat="server"></CC:HEADER><input 
id=p_Issue_issue_id type=hidden runat="server"> <input 
id=p_Responses_response_id type=hidden runat="server"> 
<input id=p_Files_file_id type=hidden runat="server"> 
<table>
  <tr>
    <td vAlign=top>
      <table class=FormTABLE id=Issue_holder 
runat="Server">
        <TBODY>
        <tr>
          <td class=FormHeaderTD colSpan=2><font 
            class=FormHeaderFONT><asp:label id=IssueForm_Title runat="server"></asp:label></FONT><br 
            ></TD></TR>
        <tr>
          <td class=DataTD colSpan=2><asp:label id=Issue_ValidationSummary runat="server" Visible="false" cssclass="DataTD"></asp:label><input 
            id=Issue_issue_id type=hidden 
        runat="server"></TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Name</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_issue_name runat="server" MaxLength="100" Columns="70"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Description</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_issue_desc runat="server" cssclass="DataFONT" Columns="70" Rows="5" TextMode="MultiLine"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Steps to 
          Recreate</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_steps_to_recreate runat="server" cssclass="DataFONT" Columns="70" Rows="5" TextMode="MultiLine"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Priority</FONT> <asp:requiredfieldvalidator id=Issue_priority_id_Validator_Req runat="server" display="None" ControlToValidate="Issue_priority_id" ErrorMessage="The value in field Priority is required." EnableClientScript="False"></asp:requiredfieldvalidator><asp:customvalidator id=Issue_priority_id_Validator_Num runat="server" display="None" ControlToValidate="Issue_priority_id" ErrorMessage="The value in field Priority is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_priority_id runat="server" cssclass="DataFONT" DataValueField="priority_id" DataTextField="priority_desc"></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>OPS Status</FONT></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_qastatus_id runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name" OnSelectedIndexChanged="Issue_qastatus_id_SelectedIndexChanged" AutoPostBack="True"></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Product Reason</FONT></TD>
          <td class=DataTD><asp:dropdownlist id="Issue_product_id" runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name" ></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Screen</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_screen runat="server" MaxLength="20" Width="440px"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Submitted By</FONT> <asp:customvalidator id=Issue_user_id_Validator_Num runat="server" display="None" ControlToValidate="Issue_user_id" ErrorMessage="The value in field Submitted By is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_user_id runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name"></asp:dropdownlist>&nbsp; 
          </TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Modified By</FONT> <asp:customvalidator id=Issue_modified_by_Validator_Num runat="server" display="None" ControlToValidate="Issue_modified_by" ErrorMessage="The value in field modified_by is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_modified_by runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name"></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Submitted Date</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_date_submitted runat="server" MaxLength="20"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Found in 
            Environment</FONT></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_bugversion runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name"></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Fixed in 
          Version</FONT></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_version runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name"></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Dev Issue 
          Number</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_dev_issue_number runat="server" MaxLength="20" Width="144px"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>ITS Number</FONT></TD>
          <td class=DataTD><asp:textbox id=Issue_its_number runat="server" MaxLength="20" Width="144px"></asp:textbox>&nbsp;</TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Orig Next Action 
            To</FONT> <asp:customvalidator id=Issue_assigned_to_orig_Validator_Num runat="server" display="None" ControlToValidate="Issue_assigned_to_orig" ErrorMessage="The value in field Orig Assigned To is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_assigned_to_orig runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name"></asp:dropdownlist>&nbsp; 
          </TD></TR>
        <tr>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT 
            >Now&nbsp;Next&nbsp;Action To</FONT>&nbsp; <asp:customvalidator id=Issue_assigned_to_Validator_Num runat="server" display="None" ControlToValidate="Issue_assigned_to" ErrorMessage="The value in field Now Assigned To is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_assigned_to runat="server" cssclass="DataFONT" DataValueField="user_id" DataTextField="user_name"></asp:dropdownlist>&nbsp;</TD></TR>
        <TR>
          <td class=FieldCaptionTD><font 
            class=FieldCaptionFONT>Status</FONT> <asp:requiredfieldvalidator id=Issue_status_id_Validator_Req runat="server" display="None" ControlToValidate="Issue_status_id" ErrorMessage="The value in field Status is required." EnableClientScript="False"></asp:requiredfieldvalidator><asp:customvalidator id=Issue_status_id_Validator_Num runat="server" display="None" ControlToValidate="Issue_status_id" ErrorMessage="The value in field Status is incorrect." EnableClientScript="False" OnServerValidate="ValidateNumeric"></asp:customvalidator></TD>
          <td class=DataTD><asp:dropdownlist id=Issue_status_id runat="server" cssclass="DataFONT" DataValueField="status_id" DataTextField="status"></asp:dropdownlist>&nbsp;</TD></TR>
        <tr>
          <td align=right colSpan=2><input id=Issue_update type=button value=Update runat="server"> 
<input id=Issue_delete type=button value="Delete with all responses" runat="server"> 
<input id=Issue_cancel type=button value=Cancel runat="server"> 
          </TD></TR></TBODY></TABLE></TD>
    <td vAlign=top>
      <table class=FormTABLE id=Responses_holder 
      runat="Server">
        <TBODY>
        <tr>
          <td class=FormHeaderTD colSpan=2><font 
            class=FormHeaderFONT><asp:label id=ResponsesForm_Title runat="server">Response History</asp:label></FONT></TD></TR>
        <tr id=Responses_no_records runat="server">
          <td class=DataTD colSpan=8><font class=DataFONT 
            >No records</FONT></TD></TR>
        <tr>
          <td><asp:repeater id=Responses_Repeater runat="server">
											<HeaderTemplate></td>
								</tr></HeaderTemplate>
	        <ItemTemplate>
									<tr>
										<td class="ColumnTD"><asp:Label Text="By" id="user_id_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<asp:Label id="Responses_user_id" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_name").ToString()) %>
											</asp:Label>&nbsp;
										</td>
									</tr>
									<tr>
										<td class="ColumnTD"><asp:Label Text="Date" id="date_response_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<asp:Label id="Responses_date_response" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "r_date_response").ToString().Replace('T', ' ')) %>
											</asp:Label>&nbsp;
										</td>
									</tr>
									<tr>
										<td class="ColumnTD"><asp:Label Text="Response" id="response_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<asp:Label id="Responses_response" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "r_response").ToString()) %>
											</asp:Label>&nbsp;
										</td>
									</tr>
									<tr>
										<td class="ColumnTD"><asp:Label Text="Assigned To" id="assigned_to_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<asp:Label id="Responses_assigned_to" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u1_user_name").ToString()) %>
											</asp:Label>&nbsp;
										</td>
									</tr>
									<tr>
										<td class="ColumnTD"><asp:Label Text="Priority" id="priority_id_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<asp:Label id="Responses_priority_id" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "p_priority_desc").ToString()) %>
											</asp:Label>&nbsp;
										</td>
									</tr>
									<tr>
										<td class="ColumnTD"><asp:Label Text="Status" id="status_id_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<asp:Label id="Responses_status_id" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "s_status").ToString()) %>
											</asp:Label>&nbsp;
										</td>
									</tr>
									<tr>
										<td class="ColumnTD"><asp:Label Text="Edit" id="Field1_Column_Title" cssclass="ColumnFONT" runat="server" /></td>
										<td class="DataTD">
											<input type=hidden id=Responses_response_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "r_response_id").ToString()) %>' >
											<asp:HyperLink id=Responses_Field1 NavigateUrl='<%# "ResponseMaint.aspx"+"?"+"response_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "r_response_id").ToString()) +"&" +"issue_id=" + Server.UrlEncode(Utility.GetParam("issue_id")) + "&"%>' cssclass="DataFONT" runat="server">Edit</asp:HyperLink>&nbsp;
										</td>
									</tr>
								</ItemTemplate>
        	<SeparatorTemplate>
									<tr>
										<td colspan="2class="RecordSeparatorTD">&nbsp;</td>
									</tr>
								</SeparatorTemplate>
      	  <FooterTemplate>
									<tr>
										<td>
								</FooterTemplate>
						</asp:repeater></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
<TABLE>
  <TBODY>
  <TR>
    <TD vAlign=top>
      <TABLE class=FormTABLE id=Files_holder runat="Server">
        <TBODY>
        <TR>
          <TD class=FormHeaderTD colSpan=6 designtimesp="41480"><font 
            class=FormHeaderFONT><asp:label id=FilesForm_Title runat="server">Attached Files</asp:label></FONT></TD>
								</tr>
        <tr>
          <td class=ColumnTD><asp:linkbutton id=Files_Column_file_name onclick=Files_SortChange runat="server" cssclass="ColumnFONT" CommandArgument="f.[file_name]" Text="File Name"></asp:linkbutton></TD>
          <td class=ColumnTD><asp:linkbutton id=Files_Column_uploaded_by onclick=Files_SortChange runat="server" cssclass="ColumnFONT" CommandArgument="u.[user_name]" Text="Uploaded By"></asp:linkbutton></TD>
          <td class=ColumnTD><asp:linkbutton id=Files_Column_date_uploaded onclick=Files_SortChange runat="server" cssclass="ColumnFONT" CommandArgument="f.[date_uploaded]" Text="Date / Time"></asp:linkbutton></TD>
          <td class=ColumnTD><asp:label id=Files_Column_Field1 runat="server" cssclass="ColumnFONT" Text="Edit"></asp:label></TD></TR>
        <tr id=Files_no_records runat="server">
          <td class=DataTD colSpan=6><font class=DataFONT 
            >No records</FONT></TD></TR>
        <tr>
          <td><asp:repeater id=Files_Repeater runat="server">
											<HeaderTemplate></td>
								</tr></HeaderTemplate>
	              <ItemTemplate>
									<tr>
										<td class="DataTD"><asp:Label id="Files_file_name" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_file_name").ToString()) %>
											</asp:Label>&nbsp;</td>
										<td class="DataTD"><asp:Label id="Files_uploaded_by" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "u_user_name").ToString()) %>
											</asp:Label>&nbsp;</td>
										<td class="DataTD"><asp:Label id="Files_date_uploaded" cssclass="DataFONT" runat="server">
												<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_date_uploaded").ToString().Replace('T', ' ')) %>
											</asp:Label>&nbsp;</td>
										<td class="DataTD">
											<input type=hidden id=Files_file_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_file_id").ToString()) %>' >
											<input type=hidden id=Files_issue_id runat="server" value='<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "f_issue_id").ToString()) %>' >
											<asp:HyperLink id=Files_Field1 NavigateUrl='<%# "FileMaint.aspx"+"?"+"issue_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "f_issue_id").ToString()) +"&"+"file_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "f_file_id").ToString()) +"&" +""%>' cssclass="DataFONT" runat="server">Edit</asp:HyperLink>&nbsp;
										</td>
									</tr>
								</ItemTemplate>
        	      <FooterTemplate>
									<tr>
										<td>
								</FooterTemplate>
						</asp:repeater></TD></TR>
        <tr>
          <td class=ColumnTD colSpan=6><font 
            class=ColumnFONT><CC:PAGER id=Files_Pager runat="server" cssclass="ColumnFONT" NumberOfPages="10" PagerStyle="1" showprevCaption="Previous" shownextCaption="Next" showtotalstring="of" showtotal="False" showLastCaption="Last" ShowFirstCaption="First" shownext="True" showprev="True" showLast="False" ShowFirst="False"></CC:PAGER></FONT></TD></TR></TABLE></TD></TR></TBODY></TABLE><CC:FOOTER id=Footer runat="server"></CC:FOOTER></FORM>
	</body>
</HTML>