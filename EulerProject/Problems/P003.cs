using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P003 : ISolvable<long>, ISequential<long, KeyValuePair<long, int>>
{
    private const long N = 600_851_475_143;

    public static string AsString() => Solution().ToString();

    public static long Solution() => RawSequence().Max(e => e.Key);

    public static IEnumerable<long> Sequence() => RawSequence().Select(e => e.Key);

    public static IEnumerable<KeyValuePair<long, int>> RawSequence() =>
        Factorization.FindPrimeFactors(N);
}