using EulerProject.Utils;

namespace EulerProject.Problems;

public class P022 : ISolvable<long>, ISequential<int, int>
{
    public static string AsString() => Solution().ToString();

    public static long Solution() => RawSequence().Select(e => (long) e).Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() =>
        File.ReadLines(PathUtils.BuildPath(@"Resources\022.txt")).OrderBy(e => e)
            .Select((s, i) => (i + 1) * s.Sum(c => c - 'A' + 1));
}