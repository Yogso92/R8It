CREATE PROCEDURE [dbo].[SP_Register]
	@nickname VARCHAR(50),
	@birthdate DATETIME2,
	@email VARCHAR(50),
	@password VARCHAR(50),
	@countryid INT
AS
	INSERT INTO [User] (Nickname, Birthdate, Email, [Password], CountryId) VALUES
	(@nickname,
	@birthdate,
	@email,
	dbo.Udf_Hash_Password(@password, @email),
	@countryid)
RETURN 1
