using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace EulerProject.Utils.MathUtils;

[SuppressMessage("ReSharper", "TailRecursiveCall")]
public static class MathUtils
{
    public static T Min<T>(T a, T b, T c) where T : INumber<T> => T.Min(T.Min(a, b), c);

    public static T Min<T>(T a, T b, T c, T d) where T : INumber<T> => T.Min(T.Min(a, b), T.Min(c, d));

    public static T Min<T>(params T[] numbers) where T : INumber<T> => numbers.Min() ?? T.Zero;

    public static T Max<T>(T a, T b, T c) where T : INumber<T> => T.Max(T.Max(a, b), c);

    public static T Max<T>(T a, T b, T c, T d) where T : INumber<T> => T.Max(T.Max(a, b), T.Max(c, d));

    public static T Max<T>(params T[] numbers) where T : INumber<T> => numbers.Max() ?? T.Zero;

    public static int Gcd(IEnumerable<int> numbers) =>
        numbers.Aggregate(Gcd);

    public static int Gcd(int a, int b) =>
        b == 0 ? a : Gcd(b, a % b);

    public static BigInteger Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Negative values are not allowed");
        return n <= 1 ? BigInteger.One : Enumerable.Range(1, n).Aggregate(1, (x, y) => x * y);
    }
        
}