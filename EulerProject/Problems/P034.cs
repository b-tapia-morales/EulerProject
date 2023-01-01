using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P034 : ISolvable<int>, ISequential<int, KeyValuePair<int, IEnumerable<int>>>
{
    private const int N = 10_000_000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => Sequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence().Select(e => e.Key);

    public static IEnumerable<KeyValuePair<int, IEnumerable<int>>> RawSequence()
    {
        var dictionary = Enumerable.Range(1, 9)
            .ToDictionary(e => e, e => Enumerable.Range(1, e).Aggregate(1, (x, y) => x * y));
        dictionary.Add(0, 1);
        return Enumerable.Range(10, N)
            .ToDictionary(e => e, e => DigitUtils.DigitArray(e).Select(x => dictionary[x]))
            .Where(e => e.Key == e.Value.Sum());
    }
}