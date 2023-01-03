using System.Numerics;
using EulerProject.Utils.MathUtils;
using static System.Math;

namespace EulerProject.Problems;

public class P025 : ISolvable<int>, ISequential<BigInteger, KeyValuePair<int, BigInteger>>
{
    private const int Digits = 1000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Last().Key;

    public static IEnumerable<BigInteger> Sequence() => RawSequence().Select(e => e.Value);

    public static IEnumerable<KeyValuePair<int, BigInteger>> RawSequence() =>
        SequenceGeneration.Fibonacci(x => Floor(BigInteger.Log10(x) + 1) < Digits)
            .Select((e, i) => (Index: i, Number: e))
            .ToDictionary(e => e.Index, e => e.Number);
}