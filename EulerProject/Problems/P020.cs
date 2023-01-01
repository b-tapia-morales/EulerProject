using System.Numerics;

namespace EulerProject.Problems;

public class P020 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 100;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() =>
        Enumerable.Range(1, N).Select(x => new BigInteger(x)).Aggregate(BigInteger.One, BigInteger.Multiply).ToString()
            .Select(c => c - '0');
}