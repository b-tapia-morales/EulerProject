using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P012 : ISolvable<long>, ISequential<long, long>
{
    private const int N = 500;

    public static string AsString() => Solution().ToString();

    public static long Solution() => RawSequence().Last();

    public static IEnumerable<long> Sequence() => RawSequence();

    public static IEnumerable<long> RawSequence() =>
        SequenceGeneration.TriangularNumbers(short.MaxValue).Select(e => Factorization.FindFactors(e)).First(e => e.Count() > N);
}