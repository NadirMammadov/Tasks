
string folderPath = "C:\\Users\\nadir\\Source\\Repos\\Tasks\\ClassTask\\AppData\\";
Directory.CreateDirectory(folderPath);
for (int i = 1; i <= 100; i++)
{
    await File.WriteAllLinesAsync(folderPath + $"data{i}.txt", new string[]
    {
        $"{i+1}.Nadir",
        "Memmedov",
        "nadirmemmedov@gmail.com",
        $"+994 ({i.ToString("D3")}) 8538060"
    },Encoding.UTF8);
}
//string exampleFile1 = "testData1.txt";
//foreach (var item in File.ReadAllLines(folderPath + "data1.txt").Select((x, y) => (x, y)))
//{
//    Console.WriteLine($"{item.y} {item.x}");
//}

//foreach (var item in collection)
//{

//}
DirectoryInfo info = new DirectoryInfo(folderPath);
FileInfo[] files = info.GetFiles("*.txt", SearchOption.AllDirectories);
//foreach (var file in files)
//{
//    Console.WriteLine(file.Name);
//    Console.WriteLine(file.FullName);
//    Console.WriteLine(file.LastWriteTime);
//}
