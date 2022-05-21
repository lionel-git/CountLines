// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

try
{
    var dico = new Dictionary<string, int>();

    var extensions = new List<string>() { "cpp", "h", "cxx", "c" };
    var regexSb = new StringBuilder();
    foreach (var extension in extensions)
    {
        if (regexSb.Length > 0)
            regexSb.Append('|');
        regexSb.Append($"[.]{extension}$");
    }
    string path = @"c:\tmp";
    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
    foreach (var file in files)
    {
        if (Regex.IsMatch(file, regexSb.ToString()))
        {
            var lineCount = File.ReadAllLines(file).Length;
            Console.WriteLine($"{file} : {lineCount}");
            var extension = Path.GetExtension(file);
            if (!dico.ContainsKey(extension))
                dico[extension] = 0;
            dico[extension]+=lineCount;
        }
    }

    foreach (var item in dico)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}