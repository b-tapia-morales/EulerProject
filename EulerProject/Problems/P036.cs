using EulerProject.Utils;

namespace EulerProject.Problems;

public class P036 : ISolvable<int>, ISequential<int, KeyValuePair<int, string>>
{
    private const int N = 999_999;

    public static string AsString() => Solution().ToString();

    public static int Solution() => Sequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence().Select(e => e.Key);

    public static IEnumerable<KeyValuePair<int, string>> RawSequence() => Enumerable.Range(1, N)
        .ToDictionary(e => e, e => Convert.ToString(e, 2))
        .Where(e => PalindromeUtils.IsPalindrome(e.Key) && PalindromeUtils.IsPalindrome(e.Value));
}