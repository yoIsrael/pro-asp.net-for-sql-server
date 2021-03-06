/*
   Thursday, May 24, 200710:22:41 PM
   User: 
   Server: VISTA\SQLEXPRESS
   Database: Chapter09
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_chpt09_Names
	(
	ID bigint NOT NULL IDENTITY (1, 1),
	Name nvarchar(60) NOT NULL,
	Created datetime NOT NULL,
	Modified datetime NOT NULL
	)  ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_chpt09_Names ON
GO
IF EXISTS(SELECT * FROM dbo.chpt09_Names)
	 EXEC('INSERT INTO dbo.Tmp_chpt09_Names (ID, Name, Created, Modified)
		SELECT ID, Name, Created, Modified FROM dbo.chpt09_Names WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_chpt09_Names OFF
GO
DROP TABLE dbo.chpt09_Names
GO
EXECUTE sp_rename N'dbo.Tmp_chpt09_Names', N'chpt09_Names', 'OBJECT' 
GO
ALTER TABLE dbo.chpt09_Names ADD CONSTRAINT
	PK_chpt09_Names PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
