using ClassTask1.Models;

public class Program
{
    public static void Main()
    {
        int n=9;
       
        
        while (n!=0)
        {
           
            
            n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.Write("Square ucun eded daxil edin: ");
                    double sq = Convert.ToDouble(Console.ReadLine());
                    Square square = new Square(sq);
                    Console.WriteLine($"square: {square.GetType().GetMethod("CalcArea").Invoke(square,null)}");
                    break;
                case 2:
                    Console.Write("Rectangular ucun Width daxil edin: ");
                    double rc = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Rectangular ucun Length daxil edin: ");
                    double rd = Convert.ToDouble(Console.ReadLine());

                    Rectangular rectangular = new Rectangular(rc, rd);
                    Console.WriteLine($"rectangular: {rectangular.GetType().GetMethod("CalcArea").Invoke(rectangular,null)}");
                    break;
                default:
                    break;
            }
        }
    }
}