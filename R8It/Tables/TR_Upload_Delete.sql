CREATE TRIGGER [TR_Upload_Delete]
ON [dbo].[Upload]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [Upload]
	SET 
		Deleted = 1, Active = 0 WHERE Id IN (SELECT Id FROM deleted)
END
