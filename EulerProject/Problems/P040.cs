using System.Text;
using EulerProject.Utils.MathUtils;
using static System.Math;

namespace EulerProject.Problems;

public class P040 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 10_000_000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Aggregate(1, (x, y) => x * y);

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence()
    {
        var m = DigitUtils.DigitCount(N);
        var sequence = new StringBuilder();
        for (var i = 1; i <= N; i++)
            sequence.Append(i);
        return Enumerable.Range(0, m - 1).Select(e => (int) Pow(10, e)).Select(e => sequence[e - 1] - '0');
    }
}