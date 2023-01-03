using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P002 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 4_000_000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() =>
        SequenceGeneration.Fibonacci(x => x <= N).Select(e => (int) e).Where(x => x % 2 == 0);
}