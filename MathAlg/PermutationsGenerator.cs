namespace MathAlg2;

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

            int i = n;
            for (; 1 < i; i--)
            {
                if (A[i] < A[i - 1])
                    break;
            }

            if(i == 1)
            {
                break;
            }
        }


        return result;
    }
}
