using System.Numerics;
using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P028A : ISolvable<BigInteger>, ISequential<BigInteger, (BigInteger First, BigInteger Second)>
{
    private const int N = 1001;

    public static string AsString() => Solution().ToString();

    public static BigInteger Solution()
    {
        const int m = N / 2;
        return 2 * (8 * BigInteger.Pow(m, 3) + 15 * BigInteger.Pow(m, 2) + 13 * m + 3) / 3;
    }

    public static IEnumerable<BigInteger> Sequence() => RawSequence().Select(e => e.First + e.Second);

    public static IEnumerable<(BigInteger First, BigInteger Second)> RawSequence()
    {
        var matrix = MatrixUtils.ClockwiseSpiralMatrix(N);
        return Enumerable.Range(0, N)
            .Select(i => (First: new BigInteger(matrix[i, i]), Second: new BigInteger(matrix[i, N - (i + 1)])));
    }
}