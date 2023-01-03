using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P045 : ISolvable<int>
{
    public static string AsString() => Solution().ToString();

    public static int Solution()
    {
        var n = GenerateTuple().Triangle;
        return (int) ((1 / 2.0) * (n * (n + 1)));
    }

    public static (int Triangle, int Pentagonal, int Hexagonal) GenerateTuple()
    {
        int i = 286, j = 166, k = 144;
        while (true)
        {
            var triangle = (int) ((1 / 2.0) * (i * (i + 1)));
            var pentagonal = (int) ((1 / 2.0) * j * (3 * j - 1));
            var hexagonal = k * (2 * k + 1);
            var min = MathUtils.Min(triangle, pentagonal, hexagonal);
            if (triangle == pentagonal && pentagonal == hexagonal)
                return (i, j, k);
            if (triangle == min)
                i++;
            if (pentagonal == min)
                j++;
            if (hexagonal == min)
                k++;
        }
    }
}