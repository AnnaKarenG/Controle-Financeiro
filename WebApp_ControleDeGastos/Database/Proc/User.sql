-------------Add/Insert--------------

USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 20/05/2023 00:25:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser] 
	@paramName VARCHAR (60),
	@paramEmail VARCHAR (60),
	@paramPassword VARCHAR (60),
	@paramAvatar VARCHAR (60)
AS  
BEGIN  
    INSERT INTO [User]  
        ([Name],
		[Email],
		[Password],
		[Avatar])
		VALUES  
        (@paramName,
		@paramEmail,
		@paramPassword,
		@paramAvatar)
    SELECT SCOPE_IDENTITY()  
END  
GO


---------------------------UPDATE-----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 20/05/2023 00:07:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser] 
    @paramUserId BIGINT, 
	@paramName VARCHAR (60),
	@paramEmail VARCHAR (60),
	@paramPassword VARCHAR (60),
	@paramAvatar VARCHAR (60)
 
AS  
BEGIN  
    UPDATE [dbo].[User] SET  
        [Name] = @paramName,
		[Email] = @paramEmail,
		[Password] = @paramPassword,
		[Avatar] = @paramAvatar
    WHERE [UserId] = @paramUserId;  
END
GO


-----------------DELETE-----------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 20/05/2023 00:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]  
    @paramUserId BIGINT 
AS  
BEGIN  
    DELETE FROM [dbo].[User]
    WHERE [UserId] = @paramUserId
END
GO


---------------GET-------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 20/05/2023 00:28:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUser]
AS
BEGIN
    SELECT
	  [UserId],
      [Name],
      [Email],
      [Password],
      [Avatar]
    FROM
        [User] WITH (NOLOCK)
    WHERE
       [UserId] = UserId 
END
GO


----------------GET----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 20/05/2023 00:28:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
    @paramUserId BIGINT

AS
BEGIN
    SELECT
	  [UserId],
      [Name],
      [Email],
      [Password],
      [Avatar]
    FROM
        [User] WITH (NOLOCK)
    WHERE
       [UserId] = @paramUserId 
END
GO

