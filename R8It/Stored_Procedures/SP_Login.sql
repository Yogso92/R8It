CREATE PROCEDURE [dbo].[SP_Login]
	@email NVARCHAR(255),
	@password NVARCHAR(255)
AS
	SELECT Id, RoleId, Nickname, Birthdate, Email, CountryId FROM [User]
	WHERE Email = @email AND [Password] = dbo.Udf_Hash_Password(@password, @email)
RETURN 0
