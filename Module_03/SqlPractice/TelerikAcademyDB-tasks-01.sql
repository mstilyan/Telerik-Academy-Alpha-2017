use TelerikAcademy;

--6
SELECT CONCAT(FirstName, '.', LastName, '@telerik.com') as [Full Email Addresses]
FROM Employees;


--7
SELECT Employees.FirstName, Employees.LastName
FROM Employees	

--8
select Employees.FirstName, Employees.LastName
from Employees
where Employees.JobTitle = 'Sales Representative';

--9
select Employees.FirstName
from Employees
where FirstName like 'Sa%';

--10
select Employees.FirstName, Employees.LastName
from Employees
where LastName like '%ei%';

--11
select Employees.Salary 
from Employees
where Salary between 20000 and 30000;

--12
select Employees.Salary
from Employees
where Salary in (25000, 14000, 12500, 23600);

--13
select *
from Employees
where ManagerID is null

--14
select *
from Employees
where Salary >= 50000 
order by Salary;

--15
select top 5 *
from Employees
order by Salary desc;

--16 
select Employees.FirstName, Employees.LastName, Addresses.AddressText 
from Employees inner join Addresses on Employees.AddressID = Addresses.AddressID;

--17 Use equijoins (conditions in the WHERE clause)
select Employees.FirstName, Employees.LastName, Addresses.AddressText 
from Employees, Addresses
where Employees.AddressID = Addresses.AddressID;

--18
select 
	CONCAT(emp.FirstName, ' ', emp.LastName) as EmployeeFullName,
	CONCAT(mng.FirstName, ' ', mng.LastName) as ManagerFullName
from Employees as emp join Employees as mng on emp.ManagerID = mng.EmployeeID;

--19
select 
	emp.EmployeeID,
	CONCAT(emp.FirstName, ' ', emp.LastName) as Employee,
	adr.AddressText as EmployeeAddress,
	CONCAT(mng.FirstName, ' ', mng.LastName) as Manager
from 
	(Employees as emp left join Employees as mng on emp.ManagerID = mng.EmployeeID) 
	join Addresses as adr on emp.AddressID  = adr.AddressID;


--20
select Towns.TownID, Towns.Name
from Towns	
union 
select Departments.DepartmentID, Departments.Name
from Departments;

--21
select 
	CONCAT(emp.FirstName, ' ', emp.LastName) as EmployeeFullName,
	CONCAT(mng.FirstName, ' ', mng.LastName) as ManagerFullName00
from Employees as emp left join Employees as mng on emp.ManagerID = mng.EmployeeID

--list all employees that are not managers
select mng.EmployeeID, mng.FirstName, mng.LastName
from Employees as emp right join Employees as mng on emp.ManagerID = mng.EmployeeID
where emp.ManagerID is null;

--list only managers
select FirstName, LastName
from 
	(select distinct Employees.ManagerID as ID
	from Employees) as Managers join Employees on Managers.ID = Employees.EmployeeID;

--22
select emp.FirstName, emp.LastName, emp.HireDate, dp.Name
from Employees as emp left join Departments as dp on emp.DepartmentID = dp.DepartmentID
where dp.Name in ('Sales', 'Finance') and emp.HireDate between '1995' AND '2005-01-01';