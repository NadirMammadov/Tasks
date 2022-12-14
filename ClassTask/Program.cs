using ClassTask.Model;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        Gitar gitar = new Gitar
        {
            Marka = "Fender",
            Model = "American prof",
            Fiyat = 1700,
            Tur = "Electro",
            Klavye = "Abanoz"
        };
        Keman keman = new Keman()
        {
            Marka = "Yamaha",
            Fiyat = 2000,
            Arse = "At kili",
            Model = "K-120 XC HG"
        };
        Piano piano = new Piano()
        {
            Klavye = "Yeni RHA-3W (3 sensorlu  agak klavye)",
            KulaklikGirisi = true,
            Fonksiyonlar = "String/Damper/Kabin",
            Marka = "Fenix SLP360 Dijital piano",
            Fiyat = 26000 ,
            Model="Fenix"
        };
        Muzisyen muzisyen1 = new Muzisyen()
        {
            Adi = "Faruk",
            LastName = "Kemansoy",
            Instrument = new List<Instrument>            {
                piano,
                keman
            },
            Yasi=200
        };
        Muzisyen muzisyen2 = new Muzisyen()
        {
            Adi = "Abuzer",
            LastName = "Piyanogiller",
            Instrument = new List<Instrument>{
                piano,
                keman
            },
            Yasi = 300

        };
        List<Muzisyen> muzisyenler = new List<Muzisyen> { muzisyen1, muzisyen2 };
        foreach (Muzisyen item in muzisyenler)
        {
            foreach (PropertyInfo property in item.GetType().GetProperties())
            {
                if(property.Name == "Instrument")
                {
                    var items = property.GetValue(item, null);
                    Console.WriteLine($"{item.GetType().Name,-10}");
                    foreach (var ins in (List<Instrument>) items)
                    {
                        foreach (var ss in ins.GetType().GetProperties())
                        {
                            Console.WriteLine($"{new string(' ',13)}{ss.Name,-10} : {ss.GetValue(ins)}");
                        }
                        var func = ins.GetType().GetMethod("Sound");
                        Console.WriteLine($"{new string(' ',12)} {func.Name,-10} : {func.Invoke(ins,null)}");
                    }
                }else
                Console.WriteLine($"{property.Name,-10} : {property.GetValue(item)}");
            }
            Console.WriteLine(new String('-',50));
        }
        
    }
}