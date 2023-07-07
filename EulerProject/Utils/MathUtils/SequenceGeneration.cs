using System.Numerics;
using EulerProject.Utils.MathUtils.PrimalityTestUtils;

namespace EulerProject.Utils.MathUtils;

public static class SequenceGeneration
{
    public static IEnumerable<BigInteger> Fibonacci(int n)
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

    public static IEnumerable<BigInteger> Fibonacci(Predicate<BigInteger> predicate)
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

    public static IEnumerable<BigInteger> Collatz(BigInteger n)
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

    public static IEnumerable<int> TriangularNumbers(int n) => Enumerable.Range(1, n).Select(x => x * (x + 1) / 2);

    public static IEnumerable<long> Pandigitals(params int[] integers)
    {
        if (integers.Any(e => e is < 0 or > 9))
            throw new ArgumentException(
                $@"Only positive, single digit numbers are allowed. Values not allowed are (Index, Number): 
{string.Join("; ", integers.Select((e, i) => (Index: i, Number: e)).Where(e => e.Number is < 0 or > 9))}");

        return PermutationUtils.Permute(string.Join(string.Empty, integers.ToHashSet())).Select(long.Parse);
    }

    public static IEnumerable<long> Pandigitals(int n, bool zeroless = false)
    {
        if (n < 1)
            throw new ArgumentException($"n must be equal or greater than 1 (value given was: {n})");

        return Pandigitals(Enumerable.Range(zeroless ? 1 : 0, zeroless ? n + 1 : n).ToArray()).Distinct();
    }

    public static IEnumerable<long> PandigitalPrimes(int n, bool zeroless = false) =>
        Pandigitals(n, zeroless).Where(i => IPrimalityTest.CheckIsPrime(i));
}