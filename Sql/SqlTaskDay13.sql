-- Adı şu şekilde olanlar: tAmEr, yAsEmin, tAnEr (A ile E arasında tek bir karakter olanlar)
select FirstName from Employees where FirstName Like '%a_e%'

--Adının içerisinde A ile E arasında iki tane karakter olanlar
select FirstName from Employees where FirstName Like '%a__e%'

-- Adinin ilk harfi M olmayanlar 
select FirstName from Employees where LEFT(FirstName,1) !='M'

--Adı T ile bitmeyenler
select FirstName from Employees where Right(FirstName,1) !='T'

--Adının ilk harfi A ile I aralığında bulunmayanlar
select FirstName from Employees Where FirstName Not LIKE  '[A-I]%'

-- Adının 2. harfi A veya T olmayanlar
select FirstName from Employees Where FirstName Not LIKE  '_A%' and FirstName Not LIKE  '_T%'

--Adının ilk iki harfi LA, LN, AA veya AN olanlar
select FirstName from Employees Where FirstName Like 'LA%' or FirstName Like 'LN%' or FirstName Like 'AA%' or FirstName Like 'AN%' 

-- Adının içerisinde _ geçen isimleri listeleyiniz 
SELECT FirstName FROM EMPLOYEES WHERE FirstName LIKE '%\_%' ESCAPE '\';