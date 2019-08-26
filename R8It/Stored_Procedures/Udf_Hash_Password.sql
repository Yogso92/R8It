CREATE FUNCTION [dbo].[Udf_Hash_Password]
(
	@password VARCHAR(255),
	@email VARCHAR (255)
)
RETURNS VARBINARY(MAX)
AS
BEGIN
	RETURN HASHBYTES('SHA2_512', @password + @email);
END
