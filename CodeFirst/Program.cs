using CodeFirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Http.Headers;

public class Program
{
    public static NorthwindContext context = new NorthwindContext();
    public static void Main()
    {

        SqlConnection sqlConnection = new SqlConnection("Server=MACHINE; Database=Northwind; Trusted_Connection=True; TrustServerCertificate=True");
        sqlConnection.Open();

        #region SqlSorgulari
        // Siparis Tablosundan MusteriSirketAdi, CalisanAdiSoyadi, SiparisId, SiparisTarihi, KargoSirketiAdi

        /*
        SqlCommand sqlCommand = new SqlCommand("select c.CompanyName, E.FirstName+' '+e.LastName as FullName, o.OrderID, o.OrderDate,s.CompanyName  from Orders o Join  Customers c on o.CustomerID = c.CustomerID Join Employees e on o.EmployeeID = e.EmployeeID Join Shippers s on o.ShipVia = s.ShipperID", sqlConnection);
            DataTable table = new();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.WriteLine(item);
                }
            Console.WriteLine(new String(' ', 50));

            }
       
        */


        // Calisanlarin Adini, Soyadini, Dogum Tarihini ve yasini getiren sorgu 

        /*
        SqlCommand sqlCommand = new SqlCommand("Select FirstName+' '+LastName as FullName, BirthDate, DATEDIFF(YEAR,BirthDate,GETDATE()) as Age from Employees e ", sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            Console.WriteLine($"FullName: {sqlDataReader[0]}");
            Console.WriteLine($"BirthDate: {sqlDataReader[1]}");
            Console.WriteLine($"Age: {sqlDataReader[2]}");
            Console.WriteLine(new String(' ', 50));
        }
        sqlConnection.Close();
         */



        // Musteriler tablosunda sirket adinda Restaurant gecen sirketleri listeleyin
        /*
         SqlCommand sqlCommand = new SqlCommand("Select CustomerID, CompanyName, ContactName  from Customers c where c.CompanyName Like '%Restaurant%'", sqlConnection);
         SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
         while (sqlDataReader.Read())
         {
             Console.WriteLine($"CustomerID: {sqlDataReader[0]}");
             Console.WriteLine($"CompanyName: {sqlDataReader[1]}");
             Console.WriteLine($"ContactName: {sqlDataReader[2]}");
             Console.WriteLine(new String(' ', 50));
         }
         sqlConnection.Close();
         */

        // Kategorilerine gore stoktaki urun sayi
        /*
        SqlCommand sqlCommand = new SqlCommand("Select c.CategoryId ,C.CategoryName, Sum(p.UnitsInStock) as Categorideki_Urun_Sayi from Products p Join Categories c on p.CategoryID = c.CategoryID group by c.CategoryID , c.CategoryName", sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            Console.WriteLine($"CategoryId: {sqlDataReader[0]}");
            Console.WriteLine($"CategoryName: {sqlDataReader[1]}");
            Console.WriteLine($"Categorideki Urun Sayi: {sqlDataReader[2]}");
            Console.WriteLine(new String(' ', 50));
        }
        sqlConnection.Close();
        */

        // Urunler Tablosuna urun ekleyin 
        /*
        Product product = new Product();
        product.ProductName = "Colaaa";
        product.UnitPrice = 5;
        product.UnitsInStock = 10;
        string categoryName = "Beverages";

        SqlCommand sqlCommand1 = new SqlCommand("Select CategoryId from Categories c where c.CategoryName = @categoryName", sqlConnection); ;
        sqlCommand1.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = categoryName;
        SqlDataReader reader = sqlCommand1.ExecuteReader();
        int catId=0;
        while (reader.Read())
        {
            catId = Convert.ToInt32(reader[0]);
        }
        sqlConnection.Close();
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("INSERT INTO Products (ProductName,UnitPrice,UnitsInStock,CategoryID) Values(@ProductName,@UnitPrice,@UnitsInStock,@CategoryID)", sqlConnection);
        sqlCommand.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = product.ProductName;
        sqlCommand.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = product.UnitPrice;
        sqlCommand.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt).Value = product.UnitsInStock;
        sqlCommand.Parameters.Add("@CategoryId", SqlDbType.Int).Value = catId;
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        
        sqlConnection.Close();
        */
        #endregion


        #region Linq to Sql
        // Siparis Tablosundan MusteriSirketAdi, CalisanAdiSoyadi, SiparisId, SiparisTarihi, KargoSirketiAdi
        /*
        var orders = from o in context.Orders
                     join c in context.Customers on o.CustomerId equals c.CustomerId
                     join e in context.Employees on o.EmployeeId equals e.EmployeeId
                     join s in context.Shippers on o.ShipVia equals s.ShipperId
                     select new
                     {
                         c.CompanyName,
                         e.FirstName,
                         e.LastName,
                         o.OrderId,
                         o.OrderDate,
                         ShipperCompany = s.CompanyName
                         
                     };
        foreach (var item in orders)
        {
            Console.WriteLine($"CompanyName: {item.CompanyName}");
            Console.WriteLine($"FirstName: {item.FirstName}");
            Console.WriteLine($"LastName: {item.LastName}");
            Console.WriteLine($"OrderId: {item.OrderId}");
            Console.WriteLine($"OrderDate: {item.OrderDate}");
            Console.WriteLine($"Shipper Company Name: {item.ShipperCompany}");
        }
        */

        // Calisanlarin Adini, Soyadini, Dogum Tarihini ve yasini getiren sorgu 
        /*
        var employees = from e in context.Employees
                        
                        select new
                        {
                            e.FirstName,
                            e.LastName,
                            e.BirthDate,
                            Age = e.BirthDate

                        };
        foreach (var employee in employees)
        {
            Console.WriteLine($"FirstName: {employee.FirstName}");
            Console.WriteLine($"LastName: {employee.LastName}");
            Console.WriteLine($"BirthDate: {employee.BirthDate}");
            Console.WriteLine($"Age: {(employee.BirthDate !=null ? DateTime.Now.Year - DateTime.Parse(employee.BirthDate.ToString()).Year : 0 )} ");
            Console.WriteLine(new String(' ', 50));
        }
        */

        // Musteriler tablosunda sirkt adinda Restaurant gecen sirketleri listeleyin
        /*
        var customers = from c in context.Customers
                        where c.CompanyName.Contains("Restaurant")
                        select new
                        {
                            c.CompanyName,
                            c.ContactName,
                            c.Phone
                        };
        foreach (var customer in customers)
        {
            Console.WriteLine($"CompanyName: {customer.CompanyName}");
            Console.WriteLine($"ContactName: {customer.ContactName}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine(new String(' ', 50));
        }
        */

        // Kategorilerine gore stoktaki urun sayi 
        /*
        var categories = from p in context.Products
                       join c in context.Categories on p.CategoryId equals c.CategoryId
                       group c by c.CategoryId into pg
                       select new
                       {
                           pg.FirstOrDefault().CategoryId,
                           pg.FirstOrDefault().CategoryName,
                           ToplamUrunSayi = pg.Select(x => x.Products.Select(y => y.UnitsInStock))
                       };
                      
                       
        foreach (var category in categories)
        {
            Console.WriteLine($"CategoryId: {category.CategoryId}");
            Console.WriteLine($"CategoryName: {category.CategoryName}");
            var cc = category.ToplamUrunSayi;
            int count = 0;
            foreach (var items in cc)
            {
                foreach (var item in items)
                {
                    count += Convert.ToInt32(item);
                }
            }
            Console.WriteLine($"ToplamUrunSayi: {count}");
            Console.WriteLine(new String(' ', 50));
        }
        */

        // Urunler Tablosuna urun ekleyin
        /*
        Product product = new Product();
        product.ProductName = "Cola 1";
        product.UnitPrice = 50;
        product.UnitsInStock = 5;
        var categoryName = "Beverages";
        var category = from c in context.Categories
                         where c.CategoryName == categoryName
                         select c.CategoryId;
        int catId = 0;
        foreach (var ca in category)
        {
            catId = ca;
        }
        product.CategoryId =catId;
        context.Products.Add(product);
        context.SaveChanges();
        */
        #endregion


        #region Linq To Entity
        // Siparis Tablosundan MusteriSirketAdi, CalisanAdiSoyadi, SiparisId, SiparisTarihi, KargoSirketiAdi


        // Calisanlarin Adini, Soyadini, Dogum Tarihini ve yasini getiren sorgu
        /*
        var employees = context.Employees
                               .Select(x => new
                               {
                                   x.FirstName,
                                   x.LastName,
                                   x.BirthDate,

                               }).ToList();
        foreach (var emp in employees)
        {
            Console.WriteLine($"FirstName: {emp.FirstName}");
            Console.WriteLine($"LastName: {emp.LastName}");
            Console.WriteLine($"BirthDate: {emp.BirthDate}");
            Console.WriteLine($"Age: {(emp.BirthDate != null ? DateTime.Now.Year - DateTime.Parse(emp.BirthDate.ToString()).Year : 0)} ");
            Console.WriteLine(new String(' ', 50));
        }             
        */
        // Musteriler tablosunda sirket adinda Restaurant gecen sirketleri listeleyin
        /*
        var customers = context.Customers
                            .Where(x => x.CompanyName.Contains("Restaurant"))
                            .Select(x => new
                            {
                                x.CompanyName,
                                x.Country,
                                x.Phone
                            })
                            .ToList();
        foreach (var customer in customers)
        {
            Console.WriteLine($"CompanyName: {customer.CompanyName}");
            Console.WriteLine($"Country: {customer.Country}");
            Console.WriteLine($"Phone: {customer.Phone}");
          
            Console.WriteLine(new String(' ', 50));
        }
        */
        // Kategorilerine gore stoktaki urun sayi
        //var categories = context.Products
        //                .Join(context.Categories,
        //                    pr => pr.CategoryId,
        //                    ct => ct.CategoryId,
        //                    (pt, ct) => new
        //                    {
        //                        ct.CategoryId
        //                    }

        //                ); 

        // Urunler Tablosuna urun ekleyin 

        /*
        Product product = new();
        product.ProductName = "Cola 2";
        product.UnitPrice = 20;
        product.UnitsInStock = 10;
        var categoryName = "Beverages";
        var categoryId = context.Categories.Where(x => x.CategoryName == categoryName).Select(x=>x.CategoryId).FirstOrDefault();
       
        product.CategoryId = categoryId;
        context.Products.Add(product);
        context.SaveChanges();
        */
        #endregion
    }
}