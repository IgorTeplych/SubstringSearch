using SubstringSearch;
using System.Diagnostics;
using System.Text;

public static class Programm
{
    static int T = 1000;
    static string sub = "Twenty men were convicted";
    public static void Main()
    {
        //SearchInBook();
        SearchInText();
    }

    static void SearchInBook()
    {
        string text = GetText();
        string substring = "Twenty men were convicted";
        Substring search = new Substring();

        Console.WriteLine("ПОИСК СТРОКИ, КОТОРАЯ ВСТРЕЧАЕТСЯ В ТЕКСТЕ");
        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, методом полного перебора занимает {Search(search.SearchSubstringByBrutalForce, text, substring)} мс.");
        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, методом Бойера-Мура занимает {Search(search.SearchBoyerMoore, text, substring)} мс.");
        Console.WriteLine();
        Console.WriteLine("ПОИСК СТРОКИ, КОТОРАЯ НЕ ВСТРЕЧАЕТСЯ В ТЕКСТЕ");
        substring = "Такой подстроки в тексте нет";
        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, методом полного перебора занимает {Search(search.SearchSubstringByBrutalForce, text, substring)} мс.");
        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, методом Бойера-Мура занимает {Search(search.SearchBoyerMoore, text, substring)} мс.");
        Console.ReadLine();
    }
    static void SearchInText()
    {
        string substring = "aaBaaaBaBaBaaB";
        string text = GenerateText(substring, "aaBaaaBaBaBaa");
        Substring search = new Substring();
        Console.WriteLine("ПОИСК СТРОКИ, КОТОРАЯ ВСТРЕЧАЕТСЯ В ТЕКСТЕ");
        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, методом полного перебора занимает {Search(search.SearchSubstringByBrutalForce, text, substring)} мс.");
        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, методом Бойера-Мура занимает {Search(search.SearchBoyerMoore, text, substring)} мс.");
        Console.ReadLine();
    }
    static long Search(Func<string, string, int> searchMethod, string text, string substring)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int count = 0;
        while (count < T)
        {
            var pos = searchMethod.Invoke(text, substring);
            count++;
        }
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
    static string GetText()
    {
        string path = Environment.CurrentDirectory + @"\text.doc";
        return File.ReadAllText(path);
    }
    static string GenerateText(string substring, string agr)
    {
        string s = "";
        string text = GetText();
        Substring search = new Substring();
        var pos = search.SearchBoyerMoore(text, sub);
        bool wr = false;
        while (s.Length < text.Length)
        {
            if (s.Length >= pos && !wr)
            {
                s += substring;
                wr = true;
            }
            s += agr;
        }

        return s;
    }
}