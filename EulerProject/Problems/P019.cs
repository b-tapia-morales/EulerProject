namespace EulerProject.Problems;

public class P019 : ISolvable<int>, ISequential<int, DateOnly>
{
    public static string AsString() => Solution().ToString();

    public static int Solution() => RawSequence().Count();

    public static IEnumerable<int> Sequence() => throw new NotImplementedException();

    public static IEnumerable<DateOnly> RawSequence()
    {
        var startDate = new DateOnly(1990, 1, 1).AddDays(6);
        var endDate = new DateOnly(2000, 12, 31);
        do
        {
            yield return startDate;
            startDate = startDate.AddDays(7);
        } while (startDate < endDate);
    }
}