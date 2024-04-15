using MathAlg2;
using MathAlg2.TimeSpanExtension;
using Spectre.Console;
using System.Text;
using System.Drawing;
using System.Linq;

#region реализация алгоритмов 3.1-3.2
DateTime d = DateTime.Now;
int N = 8;
int M = 2;
var a = CombinativeGenerator.GenerateCombinations(N, M); // генерируем все сочетания M по N
string timeFirstAlg = (DateTime.Now - d).ToStringCustom();
Print("[red]Алгоритм 3.1[/] Сочетания", a, timeFirstAlg, $"[aqua]N = {N}, M = {M}[/]");

d = DateTime.Now;
N = 4;
var b = CombinativeGenerator.GeneratePermutations(N); // генерируем все перестановки
timeFirstAlg = (DateTime.Now - d).ToStringCustom();
Print("[red]Алгоритм 3.2[/] Перестановки", b,timeFirstAlg, $"[aqua]N = {N}[/]");
#endregion

#region Решение квадратичной задачи о назначениях
// Для задачи из примера
var A = MatrixReader.GetMatrixFromTextFile<int>("A1.txt");
var C = MatrixReader.GetMatrixFromTextFile<int>("C1.txt");
var V = MatrixReader.GetMatrixFromTextFile<int>("V1.txt");

CombinativeGenerator.SolveTask(A, V, C);
Console.ReadKey();
Console.Clear();
// Для самостоятельно придуманной задачи
A = MatrixReader.GetMatrixFromTextFile<int>("A2.txt");
C = MatrixReader.GetMatrixFromTextFile<int>("C2.txt");
V = MatrixReader.GetMatrixFromTextFile<int>("V2.txt");

CombinativeGenerator.SolveTask(A, V, C);
Console.ReadKey();
Console.Clear();
#endregion

#region Решение задачи о регулярном множестве
// Считываем первый набор точек
List<PointF> points = File.ReadAllText("Points1.txt").Split("\r\n")
    .Select(line => 
        { 
            var data = line.Split();
            return new PointF(float.Parse(data[0]), float.Parse(data[1])); 
        }).ToList();

CombinativeGenerator.SolveTask(points);
Console.ReadKey();
Console.Clear();
// Считываем второй набор точек
points = File.ReadAllText("Points2.txt").Split("\r\n")
    .Select(line =>
    {
        var data = line.Split();
        return new PointF(float.Parse(data[0]), float.Parse(data[1]));
    }).ToList();

CombinativeGenerator.SolveTask(points);
// Считываем второй набор точек
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

