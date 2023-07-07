namespace EulerProject.Utils.MathUtils.PrimalityTestUtils;

public interface IPrimalityTest
{
    private static readonly IPrimalityTest TrialDivision = new TrialDivision();
    private static readonly IPrimalityTest OptimizedTrialDivision = new OptimizedTrialDivision();

    public static bool CheckIsPrime(long n, Method method = Method.OptimizedTrialDivision)
    {
        return method switch
        {
            Method.TrialDivision => TrialDivision.IsPrime(n),
            Method.OptimizedTrialDivision => OptimizedTrialDivision.IsPrime(n),
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, "Method choice is invalid")
        };
    }

    public static IEnumerable<int> Generate(int n)
    {
        if (n < 1)
            throw new ArgumentException($"n must be equal or greater than 1 (value given was: {n})");

        var list = new List<int> {2};
        for (var i = 3; list.Count < n; i += 2)
        {
            if (CheckIsPrime(i))
                list.Add(i);
        }

        return list;
    }

    bool IsPrime(long n);
}

public enum Method
{
    TrialDivision = 1,
    OptimizedTrialDivision = 2
}