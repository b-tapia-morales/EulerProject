using System.Numerics;
using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P014 : ISolvable<int>, ISequential<BigInteger, KeyValuePair<int, IEnumerable<BigInteger>>>
{
    private const int N = 999_999;

    public static string AsString() => Solution().ToString();

    public static int Solution() =>
        RawSequence().MaxBy(e => e.Value.Count()).Key;

    public static IEnumerable<BigInteger> Sequence() =>
        RawSequence().MaxBy(e => e.Value.Count()).Value;

    public static IEnumerable<KeyValuePair<int, IEnumerable<BigInteger>>> RawSequence() =>
        Enumerable.Range(1, N).ToDictionary(e => e, e => SequenceGeneration.Collatz(e));
}