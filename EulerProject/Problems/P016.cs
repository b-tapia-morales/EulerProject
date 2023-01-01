using System.Numerics;

namespace EulerProject.Problems;

public class P016 : ISolvable<BigInteger>, ISequential<int, int>
{
    private const int N = 1000;

    public static string AsString() => Solution().ToString();

    public static BigInteger Solution() => RawSequence().Select(e => new BigInteger(e)).Aggregate(BigInteger.Add);

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() =>
        BigInteger.Pow(2, N).ToString().Select(e => e - '0');
}