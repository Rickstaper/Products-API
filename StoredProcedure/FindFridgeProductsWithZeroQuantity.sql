USE Products

GO

CREATE PROCEDURE FindFridgeProductsWithZeroQuantity
AS
BEGIN
	SELECT Id, Quantity, ProductId, FridgeId
	FROM fridge_products
	WHERE Quantity = 0
END