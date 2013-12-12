set quoted_identifier  OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[categories]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[files]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[files]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[issues]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[issues]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[priorities]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[priorities]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[qastatuses]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[qastatuses]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[responses]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[responses]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[settings]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[settings]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[statuses]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[statuses]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[users]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[versions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[versions]
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[categories] (
	[category_id] [int] IDENTITY (1, 1) NOT NULL ,
	[category] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[files]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[files] (
	[file_id] [int] IDENTITY (1, 1) NOT NULL ,
	[file_name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[issue_id] [int] NULL ,
	[date_uploaded] [smalldatetime] NULL ,
	[uploaded_by] [int] NULL 
) ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[issues]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[issues] (
	[issue_id] [int] IDENTITY (1, 1) NOT NULL ,
	[issue_name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[issue_desc] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[user_id] [int] NULL ,
	[priority_id] [int] NOT NULL ,
	[status_id] [int] NOT NULL ,
	[qastatus_id] [int] NOT NULL ,
	[category_id] [int] NOT NULL ,
	[bugversion] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[version] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[assigned_to] [int] NULL ,
	[assigned_to_orig] [int] NULL ,
	[qaassigned_to] [int] NULL ,
	[qaassigned_to_orig] [int] NULL ,
	[date_submitted] [smalldatetime] NULL ,
	[date_resolved] [smalldatetime] NULL ,
	[date_modified] [smalldatetime] NULL ,
	[modified_by] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

create unique clustered index issuesUser_idx 
on issues (user_id, issue_id )

create unique index responsesIssueID_idx 
on issues ( issue_id )
END

GO



if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[priorities]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[priorities] (
	[priority_id] [int] IDENTITY (1, 1) NOT NULL ,
	[priority_desc] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[priority_order] [int] NULL ,
	[priority_color] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[qastatuses]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[qastatuses] (
	[qastatus_id] [int] IDENTITY (1, 1) NOT NULL ,
	[qastatus] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[responses]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[responses] (
	[response_id] [int] IDENTITY (1, 1) NOT NULL ,
	[issue_id] [int] NULL ,
	[response] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[user_id] [int] NULL ,
	[priority_id] [int] NOT NULL ,
	[status_id] [int] NOT NULL ,
	[qastatus_id] [int] NOT NULL ,
	[category_id] [int] NULL ,
	[bugversion] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[version] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[assigned_to] [int] NULL ,
	[qaassigned_to] [int] NULL ,
	[date_response] [smalldatetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

create unique clustered index responsesUser_idx 
on responses (user_id, assigned_to, response_id )

create unique index responsesRespID_idx 
on responses (response_id )

create index responsesIssID_idx 
on responses (issue_id )
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[settings]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[settings] (
	[settings_id] [int] IDENTITY (1, 1) NOT NULL ,
	[file_extensions] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[file_path] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_new_from] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_new_subject] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_new_body] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_change_from] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_change_subject] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_change_body] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[statuses]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[statuses] (
	[status_id] [int] IDENTITY (1, 1) NOT NULL ,
	[status] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[users] (
	[user_id] [int] IDENTITY (1, 1) NOT NULL ,
	[user_name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[login] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[pass] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[email] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[security_level] [tinyint] NULL ,
	[notify_new] [int] NULL ,
	[notify_original] [int] NULL ,
	[notify_reassignment] [int] NULL ,
	[allow_upload] [int] NULL 
) ON [PRIMARY]
END

GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[versions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[versions] (
	[version_id] [int] IDENTITY (1, 1) NOT NULL ,
	[version] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO


INSERT INTO [dbo].[categories]([category])
VALUES('General')

INSERT INTO [dbo].[categories]([category])
VALUES('UI')

INSERT INTO [dbo].[categories]([category])
VALUES('Biz')

INSERT INTO [dbo].[categories]([category])
VALUES('Data')

INSERT INTO [dbo].[categories]([category])
VALUES('Reports')

INSERT INTO [dbo].[categories]([category])
VALUES('Extern')

INSERT INTO [dbo].[categories]([category])
VALUES('Docs')

INSERT INTO [dbo].[priorities]([priority_desc], [priority_order], [priority_color])
VALUES('High','10','blue')

INSERT INTO [dbo].[priorities]([priority_desc], [priority_order], [priority_color])
VALUES('Normal','20',NULL)

INSERT INTO [dbo].[priorities]([priority_desc], [priority_order], [priority_color])
VALUES('Low','30','#444444')

INSERT INTO [dbo].[qastatuses]([qastatus])
VALUES('New')

INSERT INTO [dbo].[qastatuses]([qastatus])
VALUES('On Hold')

INSERT INTO [dbo].[qastatuses]([qastatus])
VALUES('Tested')

INSERT INTO [dbo].[qastatuses]([qastatus])
VALUES('Reproduced')

INSERT INTO [dbo].[settings]([file_extensions], [file_path], [notify_new_from], [notify_new_subject], [notify_new_body], [notify_change_from], [notify_change_subject], [notify_change_body])
VALUES('zip,pdf,doc,rtf,gif,jpg,png,txt', 'uploads', 'admin@company.com', 'New Issue# {issue_no} was Submitted', 'hi {issue_receiver},
<b>{issue_title}</b> was submitted {issue_url} by <b>{issue_poster}</b>', 'milton@ameripay.com', 'Issue# {issue_no} was Changed' , 'hi {issue_receiver},
<b>{issue_title}</b> was changed {issue_url} by <b>{issue_poster}</b>')

INSERT INTO [dbo].[statuses]([status])
VALUES('Open')

INSERT INTO [dbo].[statuses]([status])
VALUES('On Hold')

INSERT INTO [dbo].[statuses]([status])
VALUES('Closed')

INSERT INTO [dbo].[statuses]([status])
VALUES('In Progress')

INSERT INTO [dbo].[statuses]([status])
VALUES('Questions')

INSERT INTO [dbo].[users]([user_name], [login], [pass], [email], [security_level], [notify_new], [notify_original], [notify_reassignment], [allow_upload])
VALUES('Administrator','admin','admin','admin@company.com',3,0,0,0,1)

INSERT INTO [dbo].[users]([user_name], [login], [pass], [email], [security_level], [notify_new], [notify_original], [notify_reassignment], [allow_upload])
VALUES('Guest','guest','guest','guest@company.com',1,0,0,0,0)

INSERT INTO [dbo].[versions]([version])
VALUES('Not Released Yet')

GO

if exists (select 1 from sysobjects where type = 'P' and name = 'getIssues')
  drop proc getIssues
GO
CREATE PROCEDURE getIssues
  @sPriority varchar(30) = NULL,
  @sStatus varchar(40) = NULL,
  @sQAStatus varchar(40) = NULL,
  @sDeveloper varchar(100) = NULL,
  @sQAUserName varchar(100) = NULL,
  @sUserName varchar(100) = NULL,
  @sFixVersion varchar(40) = NULL,
  @sFoundVersion varchar(40) = '%'
AS

IF @sPriority = 'NULL'
  SET @sPriority = NULL

IF @sStatus = 'NULL'
  SET @sStatus = NULL

IF @sQAStatus = 'NULL'
  SET @sQAStatus = NULL

IF @sDeveloper = 'NULL'
  SET @sDeveloper = NULL

IF @sQAUserName = 'NULL'
  SET @sQAUserName = NULL

IF @sUserName = 'NULL'
  SET @sUserName = NULL

IF @sFixVersion = 'NULL'
  SET @sFixVersion = NULL

IF ISNULL(@sFoundVersion, 'NULL') = 'NULL'
  SET @sFoundVersion = '%'

IF CHARINDEX ( '%' , @sFoundVersion  ) = 0
  SET @sFoundVersion = @sFoundVersion + '%'

SELECT 
  I.issue_id, 
  I.issue_name, 
  I.issue_desc, 
  U.user_name, 
  P.priority_desc, 
  S.status, 
  QS.qastatus, 
  D.user_name AS Developer, 
  QA.user_name AS 'QA Resource', 
  CONVERT(varchar(10), 
  I.date_submitted, 1) AS date_submitted, 
  CONVERT(varchar(10), I.date_resolved, 1) AS date_resolved, 
  CASE V.version WHEN 'Not Released Yet' THEN 'N/A' ELSE V.version END AS version, 
  BV.version AS bugversion
FROM 
  dbo.issues I INNER JOIN
    dbo.users U ON I.user_id = U.user_id INNER JOIN
    dbo.priorities P ON I.priority_id = P.priority_id INNER JOIN
    dbo.statuses S ON I.status_id = S.status_id INNER JOIN
    dbo.qastatuses QS ON I.qastatus_id = QS.qastatus_id INNER JOIN
    dbo.users D ON I.assigned_to = D.user_id INNER JOIN
    dbo.users QA ON I.qaassigned_to = QA.user_id INNER JOIN
    dbo.versions V ON I.version = V.version_id INNER JOIN
    dbo.versions BV ON I.bugversion = BV.version_id AND I.bugversion = BV.version_id
WHERE 
  (P.priority_desc = ISNULL(@sPriority, P.priority_desc)) AND 
  (S.status = ISNULL(@sStatus, S.status)) AND 
  (QS.qastatus = ISNULL(@sQAStatus, QS.qastatus)) AND 
  (D.user_name = ISNULL(@sDeveloper, D.user_name)) AND 
  (QA.user_name = ISNULL(@sQAUserName, QA.user_name)) AND 
  (V.version = ISNULL(@sFixVersion, V.version)) 
  AND (ISNULL(BV.version,V.version) LIKE @sFoundVersion)
ORDER BY I.issue_id DESC	

GO
