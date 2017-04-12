/*
	Create a database called AddressBook and run this script
*/
USE [AddressBook]
GO

/****** Object:  Table [dbo].[People]    Script Date: 3/16/2017 10:41:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleInitial] [nchar](1) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[People_Delete]
	@Id INTEGER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE [dbo].[People]
	WHERE [Id] = @Id

END

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[People_Insert]
	@Id INTEGER OUT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MiddleInitial NCHAR(1) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[People](
		[FirstName],
		[LastName],
		[MiddleInitial]
	) VALUES (
		@FirstName,
		@LastName,
		@MiddleInitial
	)

	Set @Id = SCOPE_IDENTITY();

END

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[People_SelectAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
		  ,[FirstName]
		  ,[LastName]
		  ,[MiddleInitial]
	  FROM [dbo].[People]

END

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[People_SelectById]
	@Id INTEGER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
		  ,[FirstName]
		  ,[LastName]
		  ,[MiddleInitial]
	  FROM [dbo].[People]
	  WHERE [Id] = @Id

END

GO

CREATE PROCEDURE [dbo].[People_Update]
	@Id INTEGER,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MiddleInitial NCHAR(1) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[People] SET
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[MiddleInitial] = @MiddleInitial
	WHERE 
		[Id] = @Id

END

GO