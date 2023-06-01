-------------Add/Insert--------------

USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[AddRevenue]    Script Date: 20/05/2023 00:25:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddRevenue] 
	@paramValue DECIMAL (15,2),
	@paramDate DATETIME
AS  
BEGIN  
    INSERT INTO [Revenue]  
        ([Value],
		[Date])
		VALUES  
        (@paramValue,
		@paramDate)
    SELECT SCOPE_IDENTITY()  
END  
GO


---------------------------UPDATE-----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[UpdateRevenue]    Script Date: 20/05/2023 00:07:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateRevenue] 
    @paramRevenueId BIGINT, 
    @paramValue DECIMAL,
	@paramDate DATETIME 
AS  
BEGIN  
    UPDATE [dbo].[Revenue] SET  
        [Value] = @paramValue,
		[Date] = @paramDate
    WHERE [RevenueId] = @paramRevenueId;  
END
GO


-----------------DELETE-----------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[DeleteRevenue]    Script Date: 20/05/2023 00:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteRevenue]  
    @paramRevenueId  INT  
AS  
BEGIN  
    DELETE FROM [dbo].[Revenue]
    WHERE [RevenueId] = @paramRevenueId
END
GO


---------------GET-------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetAllRevenue]    Script Date: 20/05/2023 00:28:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRevenue]
AS
BEGIN
    SELECT
	  [RevenueId],
      [Value],
      [UserId],
      [Date]
    FROM
        [Revenue] WITH (NOLOCK)
    WHERE
       [RevenueId] = RevenueId 
END
GO


----------------GET----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetRevenueById]    Script Date: 20/05/2023 00:28:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRevenueById]
    @paramRevenueId BIGINT

AS
BEGIN
    SELECT
	  [RevenueId],
      [Value],
      [UserId],
      [Date]
    FROM
        [Revenue] WITH (NOLOCK)
    WHERE
       [RevenueId] = @paramRevenueId 
END
GO

