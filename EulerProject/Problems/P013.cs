using System.Numerics;
using EulerProject.Utils;

namespace EulerProject.Problems;

public class P013 : ISolvable<long>, ISequential<BigInteger, BigInteger>
{
    private const int N = 10;

    public static string AsString() => Solution().ToString();

    public static long Solution() =>
        long.Parse(RawSequence().Aggregate(BigInteger.Add).ToString()[..N]);

    public static IEnumerable<BigInteger> Sequence() => RawSequence();

    public static IEnumerable<BigInteger> RawSequence() =>
        File.ReadLines(PathUtils.BuildPath(@"Resources\013.txt")).Select(BigInteger.Parse);
}