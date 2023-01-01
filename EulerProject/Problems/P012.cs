using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P012 : ISolvable<long>, ISequential<long, long>
{
    private const int N = 500;

    public static string AsString() => Solution().ToString();

    public static long Solution() => RawSequence().Last();

    public static IEnumerable<long> Sequence() => RawSequence();

    public static IEnumerable<long> RawSequence() =>
        MathUtils.TriangleSequence(short.MaxValue).Select(e => MathUtils.FindFactors(e)).First(e => e.Count() > N);
}