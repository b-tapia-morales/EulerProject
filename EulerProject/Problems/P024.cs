using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P024: ISolvable<long>, ISequential<long, long>
{
    public static string AsString() => Solution().ToString();

    public static long Solution() => RawSequence().ElementAt(999_999);

    public static IEnumerable<long> Sequence() => RawSequence();

    public static IEnumerable<long> RawSequence() => SequenceGeneration.Pandigitals(9);
}