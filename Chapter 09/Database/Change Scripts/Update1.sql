
BEGIN TRANSACTION
GO
ALTER TABLE chpt09_Names
ALTER COLUMN Name nvarchar(150) NOT NULL
GO
COMMIT
