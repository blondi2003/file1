using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.Unicode;

    class Program 
{ 
    static void Main(string[] args)
    { 
        string path = @"C:\Users\User\source\repos\file1\file1\text.txt";
        string vpath = @"..\..\..\..\Text.txt";
        FileInfo info = new FileInfo(path);
        int count = System.IO.File.ReadAllLines(path).Length;
        string s = ""; string[] textMass; 
        StreamReader sr = new StreamReader(path);
        while (sr.EndOfStream != true) 
        { 
            s += sr.ReadLine();
        } 
        textMass = s.Split(' '); 
        sr.Close(); 
        var es = s.Any(ch => ch >= UnicodeRanges.Cyrillic.FirstCodePoint && ch < (UnicodeRanges.Cyrillic.FirstCodePoint + UnicodeRanges.Cyrillic.Length));
        var res = s.Any(ch => ch >= UnicodeRanges.BasicLatin.FirstCodePoint && ch < (UnicodeRanges.BasicLatin.FirstCodePoint + UnicodeRanges.BasicLatin.Length)); 
        var result = "result.txt"; 
        using (StreamWriter streamWriter = new StreamWriter(result)) 
        { 
            streamWriter.WriteLine("Название файла " + info.Name);
            streamWriter.WriteLine("Абсолютный путь: " + info.FullName);
            streamWriter.WriteLine("Относительный путь: " + vpath);
            streamWriter.WriteLine("Время создания " + info.CreationTime);
            streamWriter.WriteLine("Размер файла " + info.Length);
            streamWriter.WriteLine("Присутствуют ли в тексте цифры: " + s.Count(char.IsNumber)); 
            if (s.Count(char.IsNumber) > 0)
            { 
                streamWriter.WriteLine("Есть цифры"); 
            }
            else
            { 
                streamWriter.WriteLine("Нет цифр"); 
            }
            streamWriter.WriteLine("Количество слов: " + textMass.Length);
            streamWriter.WriteLine("Количество строк: " + count);
            streamWriter.WriteLine(es ? "Есть кириллица" : "Нет кириллицы"); 
            streamWriter.WriteLine(res ? "Есть латиница" : "Нет латиницы"); 
        } 
    }
} 


