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
            var first = MathUtils.FindRaisedPrimeFactors(i).ToArray();
            if (first.Length != N) continue;
            var second = MathUtils.FindRaisedPrimeFactors(i + 1).ToArray();
            if (second.Length != N) continue;
            var third = MathUtils.FindRaisedPrimeFactors(i + 2).ToArray();
            if (third.Length != N) continue;
            var fourth = MathUtils.FindRaisedPrimeFactors(i + 3).ToArray();
            if (fourth.Length != N) continue;
            var concat = new HashSet<long>(first);
            concat.UnionWith(second);
            concat.UnionWith(third);
            concat.UnionWith(fourth);
            if (concat.Count == N * N) return Enumerable.Range(i, i + 3);
        }
    }
}