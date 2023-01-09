Create Table Positions (
	Id int  Primary Key Identity ,
	Name varchar(50) not null,
)
Create Table Employees (
	Id int  Primary Key Identity ,
	FullName varchar(50) not null,
	Salary decimal,
	PositionId int ,
	FOREIGN KEY (PositionId)
	REFERENCES Positions (Id)
)

Create Table Filials (
	Id int  Primary Key Identity ,
	FilialName varchar(50) not null,
)
Create Table Products (
	Id int  Primary Key Identity ,
	ProductName varchar(50) not null,
	Price decimal,
	Salary_Price decimal,
)
Create Table Orders (
	Id int  Primary Key Identity ,
	ProductId int,
	EmployeeId int,
	FilialId int,
	Order_Date Date Default getdate(),
	FOREIGN KEY (ProductId)
	REFERENCES Products (Id),
	FOREIGN KEY (EmployeeId)
	REFERENCES Employees (Id)
)

alter table Orders
add FilialId int;

alter table Orders
add FOREIGN KEY (FilialId)
REFERENCES Filials (Id)

Insert into Products Values ('Samsung s5',500,600)
Insert into Products Values ('Samsung A51',600,700)
Insert into Products Values ('Samsung A52',400,500)
Insert into Products Values ('Samsung A80',900,1200)

Insert into Positions Values ('Seller')
Insert into Positions Values ('Sales manager')
Insert into Positions Values ('Manager')
Insert into Positions Values ('Cashier')
Insert into Positions Values ('Seller')

Insert into Filials Values ('Baki')
Insert into Filials Values ('Sumqayit')
Insert into Filials Values ('Gence')

Insert into Employees Values ('Nadir Memmedov',1000,3)
Insert into Employees Values ('Tunar Memmedov',500,2)
Insert into Employees Values ('Eli Quliyev',400,1)

Insert into Orders(ProductId,EmployeeId,FilialId) Values (1,1,1)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (2,2,2)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (3,3,3)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (2,1,3)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (3,3,1)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (3,3,1)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (4,2,3)
Insert into Orders(ProductId,EmployeeId,FilialId) Values (4,2,1)


--Satış cədvəlində işçilərin , satılan məhsulların, satışın olduğu filialın, məhsulun alış və satış qiyməti yazılsın.
Create View Orderler
as 
Select 
e.FullName, 
o.ProductId , p.ProductName, p.Price, p.Salary_Price,
f.FilialName
from dbo.Orders o 
Join dbo.Employees e on o.EmployeeId = e.Id 
Join dbo.Products p on o.ProductId = p.Id
Join dbo.Filials f on o.FilialId = f.Id

select * from Orderler
-- Bütün satışların cəmini tap.
Create View Total_Order
as 
Select 
Sum(p.Salary_Price) as Total_Order
from Orders o 
Join Products p on o.ProductId = p.Id
select * from Total_Order

-- Cari ayda məhsul satışından gələn yekun məbləği tap

Create View Month_Order
as 
Select 
Sum(p.Salary_Price) as Total_Order
from Orders o 
Join Products p on o.ProductId = p.Id
where DateDiff(month,GETDATE(),o.Order_Date) =0
select * from Month_Order

-- Hər işçinin satdığı məhsul sayını tap
Create View Emplooye_Order_Count
as 
Select 
e.FullName, Count(*) as Product_Count
from Orders o 
Join Employees e on o.EmployeeId = e.Id
group by FullName

select * from Emplooye_Order_Count

 --Bu gün üzrə ən çox məhsul satılan filialı tap.
Create View Day_Branch_order(fname,count)
as 
Select 
Top(1)
f.FilialName,
Count(*) as OrderCount
from Orders o 
Join Filials f on o.FilialId = f.Id
where DATEDIFF(day,getdate(),o.Order_Date)=0
group by f.FilialName
order by OrderCount DESC
select * from Day_Branch_order

--Cari ayda ən çox satılan məhsulu tap.
Create View Month_Product
as 
Select 
Top(1)
p.ProductName,
Count(*) as ProductCount
from Orders o 
Join Products p on o.ProductId = p.Id
where DateDiff(month,GETDATE(),o.Order_Date) =0
group by P.ProductName
order by ProductCount DESC
select * from Month_Product