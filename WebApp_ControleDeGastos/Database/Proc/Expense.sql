-------------Add/Insert--------------

USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[AddExpense]    Script Date: 20/05/2023 00:25:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddExpense] 
	@paramValue DECIMAL (15,2),
	@paramDescription VARCHAR (60),
	@paramtype TINYINT,
	@paramNumberInstallments DECIMAL,
	@paramStatus TINYINT,
	@paramDate DATETIME,
	@paramNumberCard BIGINT, 
	@paramCategoryId BIGINT, 
	@paramUserId BIGINT

AS  
BEGIN  
    INSERT INTO [Expense]  
        ([Value],
		 [Description],
		 [type],
		 [NumberInstallments],
		 [Status],
		 [Date],
		 [NumberCard],
		 [CategoryId],
		 [UserId])
		VALUES  
        (@paramValue,
		 @paramDescription,
		 @paramtype,
		 @paramNumberInstallments,
		 @paramStatus,
		 @paramDate,
		 @paramNumberCard, 
		 @paramCategoryId, 
		 @paramUserId)
    SELECT SCOPE_IDENTITY()  
END  
GO


---------------------------UPDATE-----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[UpdateExpense]   Script Date: 20/05/2023 00:07:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateExpense] 
    @paramExpenseId BIGINT, 
    @paramValue DECIMAL (15,2),
	@paramDescription VARCHAR (60),
	@paramtype TINYINT,
	@paramNumberInstallments DECIMAL,
	@paramStatus TINYINT,
	@paramDate DATETIME,
	@paramNumberCard BIGINT, 
	@paramCategoryId BIGINT, 
	@paramUserId BIGINT
AS  
BEGIN  
    UPDATE [dbo].[Expense] SET  
		 [Value]= @paramValue,
		 [Description] = @paramDescription,
		 [type] = @paramtype ,
		 [NumberInstallments] = @paramNumberInstallments,
		 [Status] = @paramStatus,
		 [Date] = @paramDate,
		 [NumberCard] = @paramNumberCard,
		 [CategoryId] = @paramCategoryId,
		 [UserId] = @paramUserId
    WHERE [ExpenseId] = @paramExpenseId;  
END
GO


-----------------DELETE-----------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[DeleteExpense]   Script Date: 20/05/2023 00:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteExpense]  
    @paramExpenseId  INT  
AS  
BEGIN  
    DELETE FROM [dbo].[Expense]
    WHERE [ExpenseId] = @paramExpenseId
END
GO


---------------GET-------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetAllExpense]    Script Date: 20/05/2023 00:28:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllExpense]
AS
BEGIN
    SELECT
	  [ExpenseId]
	  [Value],
	  [Description],
	  [type],
	  [NumberInstallments],
	  [Status],
	  [Date],
	  [NumberCard],
	  [CategoryId],
	  [UserId]
    FROM
        [Expense] WITH (NOLOCK)
    WHERE
       [ExpenseId] = ExpenseId 
END
GO


----------------GET----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetExpenseById]    Script Date: 20/05/2023 00:28:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetExpenseById]
    @paramExpenseId BIGINT

AS
BEGIN
    SELECT
	  [ExpenseId]
	  [Value],
	  [Description],
	  [type],
	  [NumberInstallments],
	  [Status],
	  [Date],
	  [NumberCard],
	  [CategoryId],
	  [UserId]
    FROM
        [Expense] WITH (NOLOCK)
    WHERE
       [ExpenseId] = @paramExpenseId 
END
GO

