-------------Add/Insert--------------

USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[AddCard]    Script Date: 20/05/2023 00:25:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddCard] 
    @paramNumberCard BIGINT, 
	@paramNome VARCHAR (30),
	@paramtype TINYINT,
	@paramBalance DECIMAL,
	@paramLimite DECIMAL,
	@paramInvoiceAmount DECIMAL,
	@paramInvoiceDate DATETIME,
	@paramFlag VARCHAR (30)
AS  
BEGIN  
    INSERT INTO [Card]  
        ([NumberCard],
		[Nome],
		[type],
		[Balance],
		[Limite],
		[InvoiceAmount],
		[InvoiceDate],
		[Flag])
		VALUES  
        (@paramNumberCard,
		@paramNome,
		@paramtype,
		@paramBalance,
		@paramLimite,
		@paramInvoiceAmount,
		@paramInvoiceDate,
		@paramFlag)
    SELECT SCOPE_IDENTITY()  
END  
GO


---------------------------UPDATE-----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[UpdateCard]    Script Date: 20/05/2023 00:07:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCard] 
    @paramCardId BIGINT, 
    @paramNumberCard BIGINT, 
	@paramNome VARCHAR (30),
	@paramtype TINYINT,
	@paramBalance DECIMAL,
	@paramLimite DECIMAL,
	@paramInvoiceAmount DECIMAL,
	@paramInvoiceDate DATETIME,
	@paramFlag VARCHAR (30) 
AS  
BEGIN  
    UPDATE [dbo].[Card] SET  
        [NumberCard] = @paramNumberCard,
		[Nome] = @paramNome,
		[type] = @paramtype,
		[Balance] = @paramBalance,
		[Limite] = @paramLimite,
		[InvoiceAmount]= @paramInvoiceAmount,
		[InvoiceDate] = @paramInvoiceDate,
		[Flag] = @paramFlag
    WHERE [CardId] = @paramCardId;  
END
GO


-----------------DELETE-----------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCard]    Script Date: 20/05/2023 00:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCard]  
    @paramCardId  INT  
AS  
BEGIN  
    DELETE FROM [dbo].[Card]
    WHERE [CardId] = @paramCardId
END
GO


---------------GET-------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetAllCard]    Script Date: 20/05/2023 00:28:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCard]
AS
BEGIN
    SELECT
	  [CardId],
      [NumberCard],
      [type],
      [Balance],
      [Limite],
      [InvoiceAmount],
      [InvoiceDate],
      [Flag],
      [Nome]
    FROM
        [Card] WITH (NOLOCK)
    WHERE
       [CardId] = CardId 
END
GO


----------------GET----------------
USE [ControleFinanceiro]
GO

/****** Object:  StoredProcedure [dbo].[GetCardById]    Script Date: 20/05/2023 00:28:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCardById]
    @paramCardId BIGINT

AS
BEGIN
    SELECT
	  [CardId],
      [NumberCard],
      [type],
      [Balance],
      [Limite],
      [InvoiceAmount],
      [InvoiceDate],
      [Flag],
      [Nome]
    FROM
        [Card] WITH (NOLOCK)
    WHERE
       [CardId] = @paramCardId 
END
GO

