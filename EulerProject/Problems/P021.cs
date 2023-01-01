using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P021 : ISolvable<int>, ISequential<int, KeyValuePair<int, int>>
{
    private const int N = 10000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => Sequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence().Select(e => e.Key + e.Value);

    public static IEnumerable<KeyValuePair<int, int>> RawSequence()
    {
        var dictionary =
            Enumerable.Range(2, N - 2).ToDictionary(e => e, e => (int) MathUtils.FindFactors(e).Sum());
        foreach (var (oldKey, oldValue) in dictionary)
        {
            if (dictionary.TryGetValue(oldValue, out var newKey) && dictionary.TryGetValue(newKey, out var newValue) &&
                oldKey == newValue)
                yield return new KeyValuePair<int, int>(oldKey, oldValue);
        }
    }
}