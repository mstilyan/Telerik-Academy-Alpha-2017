SELECT m.FirstName, m.LastName
FROM Employees AS emp 
LEFT JOIN Employees AS m ON emp.ReportsTo = m.EmployeeID
GROUP BY m.EmployeeID, m.FirstName, m.LastName
HAVING COUNT(emp.EmployeeID) >= 2
