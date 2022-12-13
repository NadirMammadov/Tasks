using ClassTask.Model;

public class Program
{
    public static void Main()
    {
        Flute flute = new Flute
        {
            ModelName = "Flute Model",
            Brand = "Flute Brand",
            Price = 45,
            Color = "White",
            Count = 5,
            Type = "Fluet TYPE"
        };
        Sintezator sintezator = new Sintezator
        {
            ModelName = "King-111",
            Brand = "King",
            Price = 3000,
            Color = "Black",
            Count = 3,
            Type = "Sintezator type",
            ButtonCount = 128,
            Kq = 15.5
        };
        Gitar gitar = new Gitar
        {
            ModelName = "Gitar 1212",
            Brand = "Gitar brand",
            Price = 150,
            Color = "Red",
            Count = 10,
            Type = "Electronic",
            Material = "Gitar Material"
        };
        Piano piano = new Piano
        {
            ModelName = "Piano 1215",
            Brand = "Piano brand",
            Price = 4550,
            Color = "White",
            Count = 10,
            PedalCount = 3
        };
        List<Instrument> instruments = new List<Instrument>();

        instruments.Add(piano);
        instruments.Add(gitar);
        instruments.Add(sintezator);
        instruments.Add(flute);
        void PrintALlInstrument()
        {
            instruments.ForEach(ob => ob.GetType().GetProperties().ToList().ForEach(p => Console.WriteLine($"{p.Name}: {p.GetValue(ob)}") ));
        }
        PrintALlInstrument();
     
    }
}