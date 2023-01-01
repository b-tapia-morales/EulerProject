using EulerProject.Utils;

namespace EulerProject.Problems;

public class P004 : ISolvable<int>, ISequential<int, (int First, int Second)>
{
    private const int N = 3;

    public static string AsString() => Solution().ToString();

    public static int Solution() => Sequence().Max();

    public static IEnumerable<int> Sequence() => RawSequence().Select(e => e.First * e.Second);

    public static IEnumerable<(int First, int Second)> RawSequence()
    {
        var lowerBound = (int) Math.Pow(10, N - 1);
        var upperBound = (int) Math.Pow(10, N) - 1;
        for (var i = lowerBound; i <= upperBound; i++)
        {
            for (var j = i; j <= upperBound; j++)
            {
                if (PalindromeUtils.IsPalindrome(i * j))
                    yield return (i, j);
            }
        }
    }
}