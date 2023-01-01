using EulerProject.Utils.MathUtils.PrimeGenerationUtils;

namespace EulerProject.Problems;

public class P050 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 1_000_000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence()
    {
        var primes = IPrimeSequence.Generate(N).ToHashSet();
        var sum = 0;
        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var prime in primes)
        {
            if (sum + prime > N)
                break;
            sum += prime;
            yield return prime;
        }
    }
}