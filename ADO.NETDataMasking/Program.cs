
using System.Data;
using System.Data.SqlClient;

public class Program
{
    public static void Main()
    {

        SqlConnection sqlConnection = new SqlConnection("Server=MACHINE;Database=DynemicDataMaskingLingDb;Trusted_Connection=true");
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("EXECUTE AS USER = 'DemoUser'\r\nSELECT Id,Name,Surname,CardNumber FROM Kullanicilar\r\nREVERT;", sqlConnection);
        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
        adapter.Fill(table);
        sqlConnection.Close();

        Console.WriteLine(new string('-', 100));
        for (int i = 0; i < table.Columns.Count; i++)
        {
            Console.Write(table.Columns[i]);
            Console.Write($"{new String(' ', 10)}{'|'}{new String(' ', 10)}");


        }
        Console.WriteLine();
        foreach (DataRow row in table.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write(item);
                Console.Write($"{new String(' ', 10)}{'|'}{new String(' ', 10)}");

            }
            Console.WriteLine();
        }
        Console.WriteLine(new String('-', 100));
    }
}