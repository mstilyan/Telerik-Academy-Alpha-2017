use TelerikAcademy

--1
select Employees.EmployeeID, Employees.FirstName, Employees.LastName
from Employees
where Salary = 
	(select min(salary) 
	from Employees);

--2
select Employees.EmployeeID, Employees.FirstName, Employees.LastName
from Employees
where Salary >= 
	(select min(salary) * 1.1
	from Employees);

--3
select emp.FirstName, emp.LastName, emp.DepartmentID
from Employees as emp
where Salary = 
	(select min(Salary)
	from Employees
	where DepartmentID = emp.DepartmentID);

--4
select AVG(Employees.Salary) AvgSalary
from Employees
where DepartmentID = 1

--5
select AVG(Employees.Salary) SalesDepAvgSalary
from Employees
where DepartmentID = 
	(select DepartmentID 
	from Departments 
	where Name = 'Sales');


--6
select COUNT(Employees.EmployeeID) SalesDepEmpCount
from Employees
where DepartmentID = 
	(select DepartmentID
	from Departments
	where Name = 'Sales');

--7
select COUNT(Employees.EmployeeID) EmpWithoutManager
from Employees
where ManagerID is not null

--8
select COUNT(Employees.EmployeeID) EmpWithoutManager
from Employees
where ManagerID is null

--9
select Employees.DepartmentID, AVG(Employees.Salary) DepAvgSalary
from Employees
group by DepartmentID


--10
select Employees.DepartmentID, COUNT(Employees.EmployeeID) DepEmpCount
from Employees
group by DepartmentID

select Addresses.TownID, COUNT(Employees.EmployeeID) as TwnEmpCount
from Employees join Addresses on Employees.AddressID = Addresses.AddressID
group by Addresses.TownID

--11
select m.EmployeeID, m.FirstName, m.LastName
from Employees emp join Employees m on emp.ManagerID = m.EmployeeID
group by m.EmployeeID, m.FirstName, m.LastName
having COUNT(emp.EmployeeID) = 5

--12
select emp.FirstName + ' ' + emp.LastName EmpFullName, 
	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') MngFullName
from Employees emp left join Employees m on emp.ManagerID = m.EmployeeID


--13
select Employees.EmployeeID, Employees.FirstName, Employees.LastName
from Employees
where LEN(LastName) = 5

--14
DECLARE @d DATETIME = GETDATE();
SELECT FORMAT( @d, 'dd.mm.yyyy hh:mm:ss:nnn', 'en-US' ) AS 'DateTime Now'



