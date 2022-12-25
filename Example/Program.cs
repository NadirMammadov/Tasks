public class Program
{
    public static void Main()
    {
        string text = "nadir memmedov";
        string dosyadi = @"C:\Users\nadir\Source\Repos\Tasks\Example\AppData\textt2.txt";
        FileInfo fi = new FileInfo(dosyadi);
        
        StreamWriter streamWriter = new StreamWriter(dosyadi);

        streamWriter.WriteLine(text);
        streamWriter.Close();

    }
}