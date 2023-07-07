using EulerProject.Utils;
using EulerProject.Utils.Text;

namespace EulerProject.Problems;

public class P067 : ISolvable<int>
{
    private const int N = 100;

    public static string AsString() => Solution().ToString();

    public static int Solution()
    {
        var matrix = TextUtils.TriangleArray(PathUtils.BuildPath(@"Resources\067.txt"), N);
        return MaxPathSum(matrix, 0, 0);
    }

    private static int MaxPathSum(int[,] matrix, int i, int j)
    {
        if (i == N - 1)
            return 0;
        var y = matrix[i + 1, j] > matrix[i + 1, j + 1] ? j : j + 1;
        return matrix[i, j] + MaxPathSum(matrix, i + 1, y);
    }
}