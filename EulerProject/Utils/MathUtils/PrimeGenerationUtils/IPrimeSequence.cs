using System.Collections;

namespace EulerProject.Utils.MathUtils.PrimeGenerationUtils;

public interface IPrimeSequence
{
    private static readonly IPrimeSequence Eratosthenes = new EratosthenesMethod();
    private static readonly IPrimeSequence Atkin = new AtkinMethod();
    private static readonly IPrimeSequence Euler = new EulerMethod();

    public static IEnumerable<int> Generate(int limit, Method method = Method.Euler)
    {
        LimitCheck(limit);
        var sieve = method switch
        {
            Method.Eratosthenes => Eratosthenes.GenerateBitArray(limit),
            Method.Atkin => Atkin.GenerateBitArray(limit),
            Method.Euler => Euler.GenerateBitArray(limit),
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, "Method choice is invalid")
        };
        return Enumerable.Range(0, limit + 1).Where(i => (i == 2) || (i % 2 != 0 && sieve.Get(i)));
    }

    public static BitArray GenerateSieve(int limit, Method method = Method.Euler)
    {
        LimitCheck(limit);
        return method switch
        {
            Method.Eratosthenes => Eratosthenes.GenerateBitArray(limit),
            Method.Atkin => Atkin.GenerateBitArray(limit),
            Method.Euler => Euler.GenerateBitArray(limit),
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, "Method choice is invalid")
        };
    }

    private static void LimitCheck(int limit)
    {
        if (limit < 2)
            throw new ArgumentException($"n must be equal or greater than 2 (value given was: {limit})");
    }

    BitArray GenerateBitArray(int limit);
}

public enum Method
{
    Eratosthenes = 1,
    Atkin = 2,
    Euler = 3
}