﻿namespace MathAlg2;

public class CombinativeGenerator
{
    public static List<string> GenerateCombinations(int n, int k)
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

        while(true) 
        { 
            result.Add(string.Join(" ", A.Skip(1)));

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
}
