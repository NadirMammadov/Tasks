--1) Parametre olarak verilen doğum tarihi ve yaş değerlerini alarak kişi belirtilen yaşı Yıl - Ay veya Gün olarak doldurup doldurmadığını geri dönen Function.
-- ********************************************************
Alter Function Age_Validate(@brithdate Date, @age int)
returns varchar(50)
as
begin 
declare @message varchar(50) 
Set @message = 
IIF (Year(getdate())-Year(@brithdate)<@age , 'Age not completed in year', 
IIF (Month(@brithdate)>Month(getdate()), 'Age not completed in month',
IIF (Day(@brithdate)>day(getdate()) , 'Age not completed in day',
'has completed the age of ')))
return @message
end
Select dbo.Age_Validate('2003-01-20',20)
-- ********************************************************
-- 2)
-- ********************************************************
create Database WorldDb 
-- ********************************************************
Create Table Country(
	Id int Primary key Identity,
	CountryName varchar(50) not null
)
-- ********************************************************
Create Table City(
	Id int Primary key Identity,
	CityName varchar(50) not null,
	CountryId int not null,
	Foreign Key (CountryId)
	References Country(Id)
)
-- ********************************************************
Create Table District(
	Id int Primary key Identity,
	DistrictName varchar(50) not null,
	CountryId int not null,
	CityId int not null,
	Foreign Key (CountryId)
	References Country(Id),
	Foreign Key (CityId)
	References City(Id)
)
-- ********************************************************
Create Table Town(
	Id int Primary key Identity,
	TownName varchar(50) not null,
	CountryId int not null,
	CityId int not null,
	DistrictId int not null,
	Foreign Key (CountryId)
	References Country(Id),
	Foreign Key (CityId)
	References City(Id),
	Foreign Key(DistrictId)
	References District(Id)
)
-- ********************************************************
Create Function Country_Check(@countryName varchar(50))
returns varchar(15)
AS 
BEGIN
Declare @response varchar(15)
Set @response = IIF((Select Count(*) from dbo.Country c where c.CountryName = @countryName)>0 ,'True','False')
return @response
end
-- ********************************************************
Create Function City_Check(@cityname varchar(50))
returns varchar(15)
AS
BEGIN 
Declare @response varchar(15)
Set @response = IIF((Select Count(*) from dbo.City c where c.CityName = @cityname)>0 ,'True','False')
return @response
end
-- ********************************************************
Create Function District_Check(@districtname varchar(50))
returns varchar(15)
AS
BEGIN 
Declare @response varchar(15)
Set @response = IIF((Select Count(*) from dbo.District d where d.DistrictName = @districtname)>0 ,'True','False')
return @response
end
-- ********************************************************
Create Function Town_Check(@townname varchar(50))
returns varchar(15)
AS
BEGIN 
Declare @response varchar(15)
Set @response = IIF((Select Count(*) from dbo.Town t where t.TownName = @townname)>0 ,'True','False')
return @response
end
-- ********************************************************
Create PROCEDURE Country_Add (@countryName varchar(50))
AS 
BEGIN 
INSERT INTO Country VALUES (@countryName )
END

-- ********************************************************
 Create PROCEDURE AddData
 (
	@CountryName varchar(50),
	@CityName varchar(50),
	@District varchar(50),
	@Town varchar(50)
 )
	AS 
	Begin

	IF (Select dbo.Country_Check(@CountryName))='True' Begin
	Print 'There is a city with this name'
	END
	ELSE BEGIN
	exec Country_Add
	@countryName = @CountryName
	Print 'Country added'
	END

	IF (Select dbo.City_Check(@CityName))='True' Begin
	Print 'There is a city with this name'
	END
	ELSE BEGIN
	exec Country_Add
	@countryName = @CountryName
	Print 'City added'
	END
	END

-- ********************************************************
EXEC AddData
@CountryName = 'saalam',
@cityName = 'ciy',
@District = ' ',
@Town = ''
