namespace EulerProject.Problems;

public class P009 : ISolvable<int>
{
    private const int N = 1000;

    public static string AsString() => Solution().ToString();

    public static int Solution()
    {
        for (var a = 1; a <= (N / 3); a++)
        {
            for (var b = a + 1; b <= (N / 2); b++)
            {
                var c = N - (a + b);
                if ((a * a) + (b * b) == (c * c))
                    return a * b * c;
            }
        }

        return -1;
    }
}