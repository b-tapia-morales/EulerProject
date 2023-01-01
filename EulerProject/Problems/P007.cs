using EulerProject.Utils.MathUtils.PrimalityTestUtils;

namespace EulerProject.Problems;

public class P007 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 10001;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Last();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() => IPrimalityTest.Generate(N);
}