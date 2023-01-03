using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P041 : ISolvable<int>, ISequential<int, int>
{
    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Max();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() =>
        Enumerable.Range(4, 6).SelectMany(e => SequenceGeneration.PandigitalPrimes(e, true));
}