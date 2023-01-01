namespace EulerProject.Problems;

public class P006 : ISolvable<int>
{
    private const int N = 100;

    public static string AsString() => Solution().ToString();

    public static int Solution()
    {
        const int squaredSum = (N * N * (N + 1) * (N + 1)) / 4;
        const int squaresSum = (N * (N + 1) * (2 * N + 1)) / 6;
        return squaredSum - squaresSum;
    }
}