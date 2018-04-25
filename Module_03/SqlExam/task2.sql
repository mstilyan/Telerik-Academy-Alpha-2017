SELECT TOP 5 Products.ProductName, Suppliers.CompanyName AS [Supplier company name]
FROM Products JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID
ORDER BY Products.ProductName