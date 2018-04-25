SELECT TOP 1 sh.CompanyName
FROM Orders AS o JOIN Shippers AS sh ON o.ShipVia = sh.ShipperID
GROUP BY sh.CompanyName
ORDER BY COUNT(o.OrderID)