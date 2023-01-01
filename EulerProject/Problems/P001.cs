namespace EulerProject.Problems;

public class P001 : ISolvable<int>, ISequential<int, int>
{
    private const int N = 199;

    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Sum();

    public static IEnumerable<int> Sequence() => RawSequence();

    public static IEnumerable<int> RawSequence() =>
        Enumerable.Range(1, N).Where(x => x % 3 == 0 || x % 5 == 0);
}