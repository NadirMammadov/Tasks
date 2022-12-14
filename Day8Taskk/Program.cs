using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Day8Taskk.Enum;

public static class EnumExtension
{
    public static string GetDisplayName(this Enum value)
    {
        return value.GetType().GetMember(value.ToString())
            .FirstOrDefault()
            .GetCustomAttribute<DisplayAttribute>()?.GetName();
    }
}
public class Program
{
    
    public static void Main()
    {
        Console.WriteLine($"{ColorEnum.Red.GetDisplayName()}");
        Console.WriteLine($"{ColorEnum.Black.GetDisplayName()}");
        Console.WriteLine($"{ColorEnum.Blue.GetDisplayName()}");
        Console.WriteLine($"{ColorEnum.Green.GetDisplayName()}");
        Console.WriteLine($"{DbConnectionEnum.Sql.GetDisplayName()}");
        Console.WriteLine($"{DbConnectionEnum.MongoDb.GetDisplayName()}");
        Console.WriteLine($"{DbConnectionEnum.MySql.GetDisplayName()}");
    }
    
}