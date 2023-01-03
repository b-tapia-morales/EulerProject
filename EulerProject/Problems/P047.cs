using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P047 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 4;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().First();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence()
    {
        for (var i = 647;; i++)
        {
            var factors = Enumerable.Range(i, N).Select(e => Factorization.FindRaisedPrimeFactors(e)).ToArray();
            if (factors.Any(e => e.Count() != N))
                continue;
            var set = factors.SelectMany(e => e).ToHashSet();
            if (set.Count == N * N)
                return Enumerable.Range(i, N);
        }
    }
}