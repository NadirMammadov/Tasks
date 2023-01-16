using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pluralize;

namespace ConsoleApp1.Repository
{
    public class PersonRepository: IPerson
    {
         private const string _CONNECTION_STRING = @"Server=MACHINE;Database=PhoneBook;Trusted_Connection=True;";
        private readonly string _tableName;
        public PersonRepository()
        {
            //Pluralizer plur = new Pluralizer();

            //_tableName= plur.Pluralize(typeof(T).Name, 1);
            
        }
        
           
       
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _CONNECTION_STRING;
            SqlCommand sqlCommand = new();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = "Delete from People where Id=@id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            
            connection.Open();
            sqlCommand.ExecuteReader();
            connection.Close();
        }

        public List<Person> GetAllConnected()
        {
            //SqlConnection connection = new SqlConnection(_CONNECTION_STRING);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _CONNECTION_STRING;

            //SqlCommand command = new SqlCommand("", connection);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.CommandText = "GetAllPerson";
            //command.CommandText = "INSERT INTO People VALUES ('Ahmet','Mehmet','+90(532) 352 09 98','ahmet.mehmet@code.edu.az')";

            command.CommandText = "SELECT [Id], [FirstName], LastName, Phone, [Email] FROM People";
            if (connection.State == ConnectionState.Closed) connection.Open();
            List<Person> list = new List<Person>();

            // Data okuma işlemi
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Person person = new();
                    person.Id = Convert.ToInt32(dr[0]);
                    person.FirstName = dr["FirstName"].ToString();
                    person.LastName = dr["LastName"].ToString();
                    person.Phone = dr["Phone"].ToString();
                    person.Email = dr["Email"].ToString();

                    list.Add(person);
                }
            }

            dr.Close();
            connection.Close();
            return list;
        }

        public List<Person> GetAllDisConnected()
        {
            string command = "SELECT [Id], [FirstName], LastName, Phone, [Email] FROM People";
            SqlDataAdapter da = new SqlDataAdapter(command, _CONNECTION_STRING);

            DataTable dt = new DataTable();
            da.Fill(dt);

            var list = (from DataRow dr in dt.Rows
                        select new Person
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            Email = dr["Email"].ToString(),
                        }
               ).ToList();

            return list;
        }

        public bool Insert(Person person)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _CONNECTION_STRING;


            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            //command.CommandText = $"INSERT INTO People VALUES ('{person.FirstName}','{person.LastName}','{person.Phone}','{person.Email}')";

            command.CommandText = "INSERT INTO People VALUES ( @FirstName, @LastName, @Phone, @Email)";
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
            //command.Parameters.AddWithValue("@LastName", person.LastName);

            //string text = "delete from People Where Id = @Id" + txtId.Text; 1



            if (connection.State == ConnectionState.Closed) connection.Open();

            bool result = command.ExecuteNonQuery() > 0;

            connection.Close();
            return result;
        }

        public List<Person> Search(string searchtext)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _CONNECTION_STRING;
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from People where FirstName = @searchtext or LastName= @searchtext or Phone=@searchtext or Email=@searchtext";
            command.Parameters.Add("@searchtext", SqlDbType.NVarChar).Value = searchtext;
            command.Connection = connection;
            if (connection.State == ConnectionState.Closed) connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                List<Person> person = new();
                while (dr.Read())
                {
                    Person p = new();
                    p.Id = Convert.ToInt32(dr[0]);
                    p.FirstName = dr["FirstName"].ToString();
                    p.LastName = dr["LastName"].ToString();
                    p.Phone = dr["Phone"].ToString();
                    p.Email = dr["Email"].ToString();
                    person.Add(p);
                }
                return person;
            }
            dr.Close();
            connection.Close();
            return null;
        }
    }
}
