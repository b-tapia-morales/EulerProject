using System.Numerics;
using static System.Math;

namespace EulerProject.Utils.MathUtils;

public static class MathUtils
{
    public static int Gcd(IEnumerable<int> numbers) =>
        numbers.Aggregate(Gcd);

    public static int Gcd(int a, int b) =>
        b == 0 ? a : Gcd(b, a % b);

    public static IEnumerable<BigInteger> FibonacciSequence(int n)
    {
        IEnumerable<BigInteger> GenerateSequence(int m)
        {
            var first = BigInteger.Zero;
            var second = BigInteger.One;
            for (var i = 1; i <= m; i++)
            {
                var temp = first;
                first = second;
                second += temp;
                yield return second;
            }
        }

        if (n < 1)
            throw new ArgumentException($"n must be equal or greater than 1 (value given was: {n})");
        return GenerateSequence(n);
    }

    public static IEnumerable<BigInteger> FibonacciSequence(Predicate<BigInteger> predicate)
    {
        var first = BigInteger.Zero;
        var second = BigInteger.One;
        while (predicate(second))
        {
            var temp = first;
            first = second;
            second += temp;
            yield return second;
        }
    }

    public static IEnumerable<BigInteger> CollatzSequence(BigInteger n)
    {
        IEnumerable<BigInteger> GenerateSequence(BigInteger m)
        {
            while (true)
            {
                yield return m;
                if (m <= 1)
                    break;
                if (m % 2 == 0)
                {
                    m /= 2;
                    continue;
                }

                m = 3 * m + 1;
            }
        }

        if (n < 1)
            throw new ArgumentException($"n must be equal or greater than 1 (value given was: {n})");
        return GenerateSequence(n);
    }

    public static IEnumerable<int> TriangleSequence(int n)
    {
        return Enumerable.Range(1, n).Select(x => x * (x + 1) / 2);
    }

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
        (long) FindUniquePrimeFactors(n).Select(p => 1D - 1D / p).Aggregate((double) n, (x, y) => x * y);

    public static bool IsPowerful(int n) =>
        FindPrimeFactors(n).All(x => x.Value >= 2);
}