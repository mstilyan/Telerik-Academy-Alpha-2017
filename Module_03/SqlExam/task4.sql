SELECT p.ProductName, p.UnitPrice, c.CategoryName
FROM Products AS p JOIN Categories AS c ON p.CategoryID = c.CategoryID
WHERE p.UnitPrice = 
	(SELECT MAX(Products.UnitPrice)
	FROM Products
	WHERE Products.CategoryID = p.CategoryID)
ORDER BY p.UnitPrice	
