using System.Numerics;

namespace EulerProject.Problems;

public class P048 : ISolvable<long>, ISequential<BigInteger, BigInteger>
{
    private const int N = 1000;

    public static string AsString() => Solution().ToString();

    public static long Solution() => 
        long.Parse(RawSequence().Aggregate(BigInteger.Add).ToString().AsSpan()[^10..]);

    public static IEnumerable<BigInteger> Sequence() => RawSequence();

    public static IEnumerable<BigInteger> RawSequence() =>
        Enumerable.Range(1, N).Select(e => BigInteger.Pow(e, e));
}