
---------------[GetAllCategory]

ALTER PROCEDURE [dbo].[GetAllCategory]  
AS  
BEGIN  
    SELECT  
       [CategoryId],  
	   [CategoryName]  
    FROM  
        [Category] WITH (NOLOCK)
END 

sp_helptext GetCategoryByName


-------------[GetCategoryById]

ALTER PROCEDURE [dbo].[GetCategoryById]  
    @paramCategoryId  BIGINT  
AS  
BEGIN  
    SELECT  
       [CategoryId],  
    [CategoryName]  
    FROM  
        [Category] WITH (NOLOCK)  
    WHERE  
       [CategoryId] = @paramCategoryId   
END


----------- [DeleteCategory]

CREATE PROCEDURE [dbo].[DeleteCategory]  
    @paramCategoryId  INT  
AS  
BEGIN  
    DELETE FROM [dbo].[Category]
    WHERE [CategoryId] = @paramCategoryId
END

------------ [GetCategoryByName]

ALTER PROCEDURE [dbo].[GetCategoryByName]  
    @paramCategoryName  BIGINT  
AS  
BEGIN  
    SELECT  
    [CategoryName]  
    FROM  
        [Category] WITH (NOLOCK)  
    WHERE  
       [CategoryName] = @paramCategoryName  
END  

----------- [AddCategory]
CREATE PROCEDURE [dbo].[AddCategory]  
    @paramCategoryName NVARCHAR(100)  
AS  
BEGIN  
    INSERT INTO [Category]  
        ([CategoryName])  
    VALUES  
        (@paramCategoryName);  

    SELECT SCOPE_IDENTITY()  
END  

----------- [UpdateCategory]

CREATE PROCEDURE [dbo].[UpdateCategory]  
    @paramCategoryId BIGINT,  
    @paramCategoryName VARCHAR(50)  
AS  
BEGIN  
    UPDATE [dbo].[Category] SET  
        [CategoryName] = @paramCategoryName 
    WHERE [CategoryId] = @paramCategoryId;  
END 


----SELECT 

select * from ControleFinanceiro..Category

