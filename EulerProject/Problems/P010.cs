using EulerProject.Utils.MathUtils.PrimeGenerationUtils;

namespace EulerProject.Problems;

public class P010 : ISolvable<long>, ISequential<int, int>
{
    private const int N = 1_999_999;

    public static string AsString() => Solution().ToString();

    public static long Solution() => Sequence().Select(e => (long) e).Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() => IPrimeSequence.Generate(N);
}