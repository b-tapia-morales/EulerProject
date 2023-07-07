using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P074 : ISolvable<int>, ISequential<int, KeyValuePair<int, List<int>>>
{
    private const int Length = 60;
    private const int N = 1_000_000;

    public static string AsString() => Solution().ToString();

    public static int Solution() => Sequence().Count();

    public static IEnumerable<int> Sequence() =>
        RawSequence().Where(e => e.Value.Count == Length).Select(e => e.Key);

    public static IEnumerable<KeyValuePair<int, List<int>>> RawSequence()
    {
        var factorials = Enumerable.Range(0, 10).ToDictionary(e => e, e => (int) MathUtils.Factorial(e));
        var dictionary = new Dictionary<int, List<int>>();
        for (var i = 0; i < N; i++)
        {
            if (dictionary.ContainsKey(i))
                continue;

            dictionary.Add(i, new List<int>());
            var visited = new HashSet<int> {i};
            var currentChain = new List<int> {i};
            var last = i;
            while (true)
            {
                var next = DigitUtils.ToDigitArray(last).Select(e => factorials[e]).Sum();
                if (dictionary.TryGetValue(next, out var previousChain))
                {
                    currentChain.AddRange(previousChain);
                    dictionary.Remove(i);
                    dictionary.Add(i, currentChain);
                    break;
                }

                if (visited.Contains(next))
                {
                    dictionary[i].AddRange(currentChain);
                    var n = currentChain.Count;
                    for (var k = 0; k < (n - 1); k++)
                    {
                        dictionary.TryAdd(currentChain[k], currentChain.GetRange(k, n - k));
                    }

                    break;
                }

                visited.Add(next);
                currentChain.Add(next);
                last = next;
            }
        }

        return dictionary;
    }
}