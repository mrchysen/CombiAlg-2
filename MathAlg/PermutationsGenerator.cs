using System.Collections.Generic;
using System.Drawing;

namespace MathAlg2;

public class CombinativeGenerator
{
    public static List<string> GenerateCombinations(int n, int k) // 0<=k<=n
    {
        List<string> result = new();

        int[] A = new int[k + 1];

        for (int i = 1; i <= k; i++)
        {
            A[i] = i;
        }

        int p = k;

        while (true) 
        { 
            result.Add(string.Join(" ", A.Skip(1)));

            p = (A[k] == n) ? p - 1 : k;

            if(p < 1)
            {
                break;
            }

            for (int i = k; i > p - 1; i--)
            {
                A[i] = A[p] + i - p + 1;
            }
        }

        return result;
    }

    public static List<string> GeneratePermutations(int n)
    {
        List<string> result = new();

        int[] A = new int[n + 1];

        for (int j = 1;j < n + 1; j++)
        {
            A[j] = j;
        }

        int c = 1;

        while(true) 
        { 
            result.Add(c + ") " + string.Join(" ", A.Skip(1)));
            c++;

            int i = n - 1;
            for (;i >= 1;i--)
            {
                if (A[i] < A[i + 1])
                    break;
            }

            if(i < 1)
            {
                break;
            }

            int j = i + 1;
            int min_ind = j;
            for (; j < n + 1; j++)
            {
                if (A[i] < A[j])
                    min_ind = j;
            }

            j = min_ind;

            (A[i], A[j]) = (A[j], A[i]);

            var cutArr = A.TakeLast(A.Length - i - 1).Reverse().ToList();
            cutArr.CopyTo(A, i+1);
        }

        return result;
    }

    // Задача о регулярном множестве
    public static void SolveTask(List<PointF> points, float Eps = 0.1f)
    {
        int k = 2;
        int n = points.Count;
        bool flag = true;

        List<string> result = new();

        int[] A = new int[k + 1];

        for (int i = 1; i <= k; i++)
        {
            A[i] = i;
        }

        int p = k;

        while (true)
        {
            var comb = A.Skip(1).ToList();

            if (!Condition(comb[0] - 1, comb[1] - 1, points, Eps))
            {
                flag = false;
                break;
            }

            p = (A[k] == n) ? p - 1 : k;

            if (p < 1)
            {
                break;
            }

            for (int i = k; i > p - 1; i--)
            {
                A[i] = A[p] + i - p + 1;
            }
        }

        if (flag)
        {
            Console.WriteLine("Множество регулярно");
        }
        else
        {
            Console.WriteLine("Множество не является регулярным");
        }
    }

    protected static bool Condition(int i, int j, List<PointF> points, float Eps)
    {
        PointF p1 = points[i];
        PointF p2 = points[j];
        float dlina = Norma(p1, p2);

        for (int k = 0; k < points.Count; k++)
        {
            if(k != j && k != i)
            {
                PointF p3 = points[k];

                if (dlina - Norma(p3, p1) < Eps && dlina - Norma(p3,p2) < Eps)
                    return true;
            }
        }

        return false;
    }

    protected static float Norma(PointF p1, PointF p2) => MathF.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

    // Задача о заводах
    public static void SolveTask(Matrix<int> A, Matrix<int> V, Matrix<int> C)
    {
        var n = A.FirstLength;

        int[] Per = new int[n + 1];

        for (int j = 1; j < n + 1; j++)
        {
            Per[j] = j;
        }

        int minSum = int.MaxValue;
        int[] minPer = new int[n];

        while (true) // O(n! * n * n)
        {
            // Тут готовая перестановка
            var resultPer = Per.Skip(1).ToList();
            Console.WriteLine("Перестановка " + string.Join(" ", resultPer));

            // Если нам такая перестановка заводов подходит
            if (IsAvailable(resultPer, A)) 
            {
                Console.WriteLine("Подходит");
                // Считаем сумму
                var S = GetSum(resultPer, V, C);
                Console.WriteLine($"Сумма {S}");

                // Проверям
                if (S < minSum)
                {
                    minSum = S;
                    resultPer.CopyTo(minPer, 0);
                }
            } 

            int i = n - 1;
            for (; i >= 1; i--)
            {
                if (Per[i] < Per[i + 1])
                    break;
            }

            if (i < 1)
            {
                break;
            }

            int j = i + 1;
            int min_ind = j;
            for (; j < n + 1; j++)
            {
                if (Per[i] < Per[j])
                    min_ind = j;
            }

            j = min_ind;

            (Per[i], Per[j]) = (Per[j], Per[i]);

            var cutArr = Per.TakeLast(Per.Length - i - 1).Reverse().ToList();
            cutArr.CopyTo(Per, i + 1);
        }

        Console.WriteLine("Итоговая перестановка " + string.Join(" ", minPer));
        Console.WriteLine("Итоговая сумма " + minSum.ToString());
    }

    protected static bool IsAvailable(List<int> perm, Matrix<int> A)
    {
        int s = 0;

        for (int i = 0; i < perm.Count; i++)
        {
            s += A[perm[i] - 1, i];

            if(s > 0)
            {
                return false;
            }
        }

        return true;
    }

    protected static int GetSum(List<int> perm, Matrix<int> V, Matrix<int> C)
    {
        int S = 0;
        List<string> ans = new();

        for (int i = 0; i < V.FirstLength; i++)
        {
            for (int j = 0; j < V.FirstLength; j++)
            {
                ans.Add($"{C[i, j]} * {V[perm[i] - 1, perm[j] - 1]}");
                S += C[i, j] * V[perm[i]-1,perm[j]-1];
            }
        }

        Console.WriteLine(string.Join(" + ", ans));
        return S;
    }
}
