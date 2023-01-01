using EulerProject.Utils.MathUtils;
using EulerProject.Utils.MathUtils.PrimeGenerationUtils;

namespace EulerProject.Problems;

public class P037 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 11;
    private const int M = 1_000_000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence()
    {
        var counter = 0;
        var primes = IPrimeSequence.Generate(M).Skip(4).ToHashSet();
        foreach (var number in from prime in primes
                 let left = DigitUtils.Truncate(prime, TruncatingMethod.LeftToRight).ToHashSet()
                 let right = DigitUtils.Truncate(prime, TruncatingMethod.RightToLeft).ToHashSet()
                 where left.All(x => primes.Contains(x)) && right.All(x => primes.Contains(x))
                 select prime)
        {
            counter++;
            yield return number;
            if (counter == N)
                break;
        }
    }
}