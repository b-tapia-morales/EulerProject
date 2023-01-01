using EulerProject.Utils;
using EulerProject.Utils.MathUtils;
using EulerProject.Utils.Text;
using static System.Math;

namespace EulerProject.Problems;

public static class BuggySolutions
{
    public static int Seventeenth(int n = 1000)
    {
        var dictionary = new Dictionary<int, string>
        {
            {0, string.Empty}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"}, {6, "Six"}, {7, "Seven"},
            {8, "Eight"}, {9, "Nine"}, {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
            {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, {20, "Twenty"},
            {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, {70, "Seventy"}, {80, "Eighty"},
            {90, "Ninety"}, {100, "Hundred"}, {1_000, "Thousand"}, {1_000_000, "Million"}
        };
        var letters = 0;
        for (var i = 1; i <= n; i++)
        {
            if (i < 20)
            {
                letters += dictionary[i].Length;
                continue;
            }

            for (var j = 0; j < DigitUtils.DigitCount(i); j++)
            {
                var power = (int) Pow(10, j);
                var number = i % power;
                letters += dictionary[number].Length;
            }

            if (i is >= 100 and < 1_000)
                letters += dictionary[100].Length;
        }

        return letters;
    }

    public static int Eighteenth(int n = 15)
    {
        var triangleArray = TextUtils.TriangleArray(PathUtils.BuildPath(@"Resources\018.txt"), n);
        var largestValues = new int[n];
        for (var i = 0; i < n; i++)
        {
            largestValues[i] = triangleArray[n - 1, i];
        }

        for (var i = n - 2; i >= 0; i--)
        {
            for (var j = 0; j <= i; j++)
            {
                largestValues[j] = triangleArray[i, j] + Max(largestValues[j], largestValues[j + 1]);
            }
        }

        return largestValues[0];
    }

    public static int ThirtyThree(int n = 100)
    {
        var numerator = 1;
        var denominator = 1;
        for (var i = 10; i < n; i++)
        {
            for (var j = 10; j < i; j++)
            {
                int n0 = j % 10, n1 = j / 10;
                int d0 = i % 10, d1 = i / 10;
                if ((n1 != d0 || n0 * i != j * d1) &&
                    (n0 != d1 || n1 * i != j * d0)) continue;
                numerator *= j;
                denominator *= i;
            }
        }

        return denominator / MathUtils.Gcd(numerator, denominator);
    }

    public static int EightyOne(int n = 80)
    {
        var matrix = TextUtils.GenerateSquareMatrix(PathUtils.BuildPath(@"Resources\081.txt"), n);
        int i = 0, j = 0, sum = matrix[i, j];
        var coordinates = new List<(int x, int y)>
        {
            (0, 0)
        };
        while (i < (n - 1) || j < (n - 1))
        {
            var right = j == n - 1 ? int.MaxValue : matrix[i, j + 1];
            var down = i == n - 1 ? int.MaxValue : matrix[i + 1, j];
            var min = Min(right, down);
            sum += min;
            j = right == min ? j + 1 : j;
            i = down == min ? i + 1 : i;
            coordinates.Add((i, j));
        }

        Console.WriteLine(string.Join('\n', coordinates));
        return sum;
    }

    public static IEnumerable<long> ThreeHundredTwo()
    {
        var n = (long) Pow(10, 4);
        var list = new List<long>();
        for (var i = 3L; i <= n; i++)
        {
            var primeFactorizations = MathUtils.FindPrimeFactors(i);
            if (primeFactorizations.Values.Any(v => v < 2) || primeFactorizations.Values.All(v => v % 2 == 0))
                continue;

            var primes = primeFactorizations.Keys;
            var eulerTotient = (long) primes.Select(p => 1D - (1D / p)).Aggregate((double) i, (x, y) => x * y);
            var eulerFactorizations = MathUtils.FindPrimeFactors(eulerTotient);
            if (eulerFactorizations.Values.Any(v => v < 2) || eulerFactorizations.Values.All(v => v % 2 == 0))
                continue;

            list.Add(i);
        }

        return list;
    }
}