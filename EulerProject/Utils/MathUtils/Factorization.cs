using System.Numerics;
using static System.Math;

// ReSharper disable TailRecursiveCall

namespace EulerProject.Utils.MathUtils;

public static class Factorization
{
    public static T Min<T>(params T[] numbers) where T : INumber<T> => numbers.Min() ?? T.Zero;

    public static T Max<T>(params T[] numbers) where T : INumber<T> => numbers.Max() ?? T.Zero;

    public static int Gcd(IEnumerable<int> numbers) =>
        numbers.Aggregate(Gcd);

    public static int Gcd(int a, int b) =>
        b == 0 ? a : Gcd(b, a % b);

    public static IEnumerable<long> FindFactors(long n, bool skipLast = true)
    {
        IEnumerable<long> GenerateSequence(long m)
        {
            for (var i = 1L; i <= Sqrt(m); i++)
            {
                if (m % i != 0)
                    continue;

                if (m / i == i)
                {
                    yield return i;
                    continue;
                }

                yield return i;
                yield return m / i;
            }
        }

        if (n < 1)
            throw new ArgumentException($"n must be equal or greater than 1 (value given was: {n})");
        var sequence = GenerateSequence(n).OrderBy(e => e);
        return skipLast ? sequence.SkipLast(1) : sequence;
    }

    public static IEnumerable<(long first, long second)> FindFactorTuples(long n)
    {
        if (n is 1 or 2 or 3)
            return Enumerable.Repeat((n, 1L), 1);

        var factors = FindFactors(n).ToArray();
        var m = factors.Length;
        var tuples = Enumerable.Range(0, m / 2).Select(i => (factors[i], factors[^(i + 1)])).ToList();
        if (m % 2 != 0)
            tuples.Add((factors[m / 2], factors[m / 2]));
        return tuples;
    }

    public static Dictionary<long, int> FindPrimeFactors(long n)
    {
        var dictionary = new Dictionary<long, int>();
        while (n % 2 == 0)
        {
            if (!dictionary.TryAdd(2, 1))
                dictionary[2] += 1;

            n /= 2;
        }

        for (var i = 3L; i <= Sqrt(n); i += 2)
        {
            while (n % i == 0)
            {
                if (!dictionary.TryAdd(i, 1))
                    dictionary[i] += 1;

                n /= i;
            }
        }

        if (n > 2)
            dictionary[n] = 1;

        return dictionary;
    }

    public static IEnumerable<long> FindUniquePrimeFactors(long n) =>
        FindPrimeFactors(n).Keys;

    public static IEnumerable<long> FindRaisedPrimeFactors(long n) =>
        FindPrimeFactors(n).Select(x => (long) Pow(x.Key, x.Value));

    public static long EulerTotientFunction(long n) =>
        (long) FindUniquePrimeFactors(n).Select(p => 1.0 - 1.0 / p).Aggregate((double) n, (x, y) => x * y);

    public static bool IsPowerful(int n) =>
        FindPrimeFactors(n).All(x => x.Value >= 2);
}