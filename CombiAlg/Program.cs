using MathAlg2;

var a = CombinativeGenerator.GenerateCombinations(5,2);
var b = CombinativeGenerator.GeneratePermutations(3);

Console.WriteLine("--- Комбинации ---");
Console.WriteLine(string.Join($"\n", a));
Console.WriteLine("--- Перестановки ---");
Console.WriteLine(string.Join($"\n", b));