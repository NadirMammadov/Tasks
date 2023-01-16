
using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using ConsoleApp1.Repository;
using Pluralize;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

public class Program
{
    public static void Menu()
    {
        Console.WriteLine("Kayit eklmek Icin (a)\n Kayit Listelemek icin (l)\n Kayit aramak icin(s)\n ( Cikis (e)");
       
            
       
    }
    public static void Main()
    {
        PersonRepository repository = new();
        string command;
        while (true)
        {
            
            Menu();
            command = Console.ReadLine();
            if (command=="A" || command== "a")
            {
                Console.WriteLine();
                Person person = new();
                Console.Write("FirstName girin: ");
                person.FirstName = Console.ReadLine();
                Console.Write("LastName girin: ");
                person.LastName = Console.ReadLine();
                Console.Write("Telefon numarasini girin: ");
                person.Phone = Console.ReadLine();
                Console.Write("Emaili girin: ");
                person.Email = Console.ReadLine();
                Console.WriteLine("Kaydetmek istiyormusunuz Y/N");
                command = Console.ReadLine();
                if(command == "Y" || command == "y")
                {
                    bool result = repository.Insert(new Person
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Email = person.Email,
                        Phone = person.Phone
                    });
                    if (result) Console.WriteLine("Kayit eklendi");
                }
                else Console.WriteLine("Kayit islemi iptal edildi.");
                
            }
            else if(command == "L" || command == "l")
            {
                var people= repository.GetAllDisConnected();
                string colm = $"Id{new String(' ', 10)}FirstName{new String(' ', 10)}LastName{new String(' ', 10)}Phone{new String(' ', 20)}Email{new String(' ', 10)}";
                Console.Write(colm);
                Console.WriteLine();
                foreach (var person in people)
                {
                    Console.Write($"{person.Id}{new String(' ', 10 - person.Id.ToString().Length+2 )}{person.FirstName}{new String(' ',10-person.FirstName.Length+9)}{person.LastName}{new String(' ', 10 - person.LastName.Length + 8)}{person.Phone}{new String(' ', 20 - person.Phone.Length + 5)}{person.Email}");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Kayit silmek icin (d)\n Islem Menusu Icin(m)");
                command = Console.ReadLine();
                if (command == "d" || command == "D")
                {
                    Console.Write("Silmek istedigin kayitin Id-sini girin: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    repository.Delete(id);
                    Console.WriteLine("Kayit silindi");
                }
                else continue;
            }
            else if(command == "S" ||command== "s")
            {
                Console.Write("Kelimeyi girin: ");
                var result = repository.Search(Console.ReadLine());
                foreach (var person in result)
                {
                    Console.Write($"{person.Id}{new String(' ', 10 - person.Id.ToString().Length + 2)}{person.FirstName}{new String(' ', 10 - person.FirstName.Length + 9)}{person.LastName}{new String(' ', 10 - person.LastName.Length + 8)}{person.Phone}{new String(' ', 20 - person.Phone.Length + 5)}{person.Email}");
                    Console.WriteLine();
                }
                Console.WriteLine("Geriye Donmek icin (M)");
                if (Console.ReadLine() == "M" || Console.ReadLine() == "m")
                    continue;
            }
            else
            {
                Console.WriteLine("Cikis....");
                break;
            }
        }
        
        
    }
}