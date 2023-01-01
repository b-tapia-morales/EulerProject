using System.Numerics;

namespace EulerProject.Problems;

public class P028 : ISolvable<BigInteger>
{
    private const int N = 1001;

    public static string AsString() => Solution().ToString();

    public static BigInteger Solution()
    {
        const int m = N / 2;
        return 2 * (8 * BigInteger.Pow(m, 3) + 15 * BigInteger.Pow(m, 2) + 13 * m + 3) / 3;
    }
}