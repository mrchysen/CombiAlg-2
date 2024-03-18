using MathAlg2;
using MathAlg2.TimeSpanExtension;
using Spectre.Console;
using System.Text;

#region реализация алгоритмов 3.1-3.2
DateTime d = DateTime.Now;
int N = 8;
int M = 3;
var a = CombinativeGenerator.GenerateCombinations(N, M);
string timeFirstAlg = (DateTime.Now - d).ToStringCustom();
Print("[red]Алгоритм 3.1[/] Сочетания", a, timeFirstAlg, $"[aqua]N = {N}, M = {M}[/]");

d = DateTime.Now;
N = 6;
var b = CombinativeGenerator.GeneratePermutations(N);
timeFirstAlg = (DateTime.Now - d).ToStringCustom();
//Console.WriteLine(string.Join("\n", b));
Print("[red]Алгоритм 3.2[/] Перестановки", b,timeFirstAlg, $"[aqua]N = {N}[/]");
#endregion


static void Print(string titleName, List<string> data, string timeSpan, string addInfo)
{
    string additionInfo = $"[aqua]время {timeSpan}[/]" + '\n' +
         addInfo + '\n' +
         string.Join($"\n", data);
    var panel = new Panel(new Markup(additionInfo))
    {
        Expand = true,
        Header = new(titleName),
        Border = BoxBorder.Ascii
    };
    AnsiConsole.Write(panel);
    Console.ReadKey();
    Console.Clear();
}

