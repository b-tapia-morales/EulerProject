using EulerProject.Utils.MathUtils.PrimalityTestUtils;
using static System.Math;

namespace EulerProject.Problems;

public class P058 : ISolvable<int>, ISequential<int, int>
{
    private const double Threshold = 0.1;

    public static string AsString() => Solution().ToString();

    public static int Solution() => GenerateTuple().Length;

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() => GenerateTuple().Primes;

    private static (int Length, IEnumerable<int> Primes) GenerateTuple()
    {
        var primes = new List<int>();
        for (var i = 1;; i++)
        {
            var evenPower = (int) Pow(2 * i, 2);
            var oddPower = (int) Pow(2 * i + 1, 2);

            var upperRight = evenPower - (2 * i - 1);
            if (IPrimalityTest.CheckIsPrime(upperRight))
                primes.Add(upperRight);

            var upperLeft = evenPower + 1;
            if (IPrimalityTest.CheckIsPrime(upperLeft))
                primes.Add(upperLeft);

            var lowerLeft = oddPower - 2 * i;
            if (IPrimalityTest.CheckIsPrime(lowerLeft))
                primes.Add(lowerLeft);

            if (primes.Count / (4.0 * i + 1.0) < Threshold)
                return (2 * i + 1, primes);
        }
    }
}