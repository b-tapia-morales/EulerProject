using EulerProject.Utils;

namespace EulerProject.Problems;

public class P008 : ISolvable<long>, ISequential<long, long>
{
    private const int N = 1000;
    private const int Digits = 13;

    public static string AsString() => Solution().ToString();

    public static long Solution() => RawSequence().Aggregate(1L, (x, y) => x * y);

    public static IEnumerable<long> Sequence() => RawSequence();

    public static IEnumerable<long> RawSequence()
    {
        var digits = File.ReadAllText(PathUtils.BuildPath(@"Resources\008.txt"))
            .Replace("\n", string.Empty)
            .Select(c => (long) char.GetNumericValue(c))
            .ToList();
        var maxSequence = digits.Take(Digits).ToArray();
        var maxProduct = maxSequence.Aggregate(1L, (x, y) => x * y);
        for (var i = 1; i < N - Digits; i++)
        {
            var sequence = digits.Skip(i).TakeWhile((e, j) => j < Digits && e != 0).ToArray();
            if (sequence.Length < Digits)
                continue;
            var product = sequence.Aggregate(1L, (x, y) => x * y);
            maxSequence = product > maxProduct ? sequence : maxSequence;
        }

        return maxSequence;
    }
}