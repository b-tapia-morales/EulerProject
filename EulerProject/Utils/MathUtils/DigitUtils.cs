using static System.Math;

namespace EulerProject.Utils.MathUtils;

public static class DigitUtils
{
    public static int DigitCount(int x) => x == 0 ? 1 : (int) Log10(Abs(x)) + 1;

    public static IEnumerable<int> ToDigitArray(int x)
    {
        if (x == 0)
            return Enumerable.Repeat(0, 1);

        var y = Abs(x);
        var m = DigitCount(x);
        var array = new int[m];
        for (var i = m - 1; i >= 0; i--)
        {
            array[i] = y % 10;
            y /= 10;
        }

        return array;
    }

    public static int DigitSum(int x) => x == 0 ? 0 : ToDigitArray(x).Sum();

    public static IEnumerable<int> Truncate(int x, TruncatingMethod method, bool skipOriginalValue = true)
    {
        if (DigitCount(x) == 1)
            return Enumerable.Repeat(Abs(x), 1);

        var enumerable = method switch
        {
            TruncatingMethod.LeftToRight => TruncateLeftToRight(x, skipOriginalValue),
            TruncatingMethod.RightToLeft => TruncateRightToLeft(x, skipOriginalValue),
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, "Method choice is invalid")
        };
        return enumerable;
    }

    public static IEnumerable<int> ToChunks(int x, int digits) => ToChunks((long) x, digits).Select(e => (int) e);

    public static IEnumerable<long> ToChunks(long x, int digits)
    {
        var n = DigitCount((int) x);
        if (n < digits)
        {
            throw new ArgumentException();
        }

        var str = x.ToString();
        return n == digits
            ? Enumerable.Repeat(x, 1)
            : Enumerable.Range(0, n - (digits - 1)).Select(i => str[i..(i + digits)]).Select(long.Parse);
    }

    private static IEnumerable<int> TruncateLeftToRight(int x, bool skipOriginalValue = true)
    {
        var m = DigitCount(x) + (skipOriginalValue ? 0 : 1);
        for (var i = 1; i < m; i++)
        {
            yield return x % (int) Pow(10, i);
        }
    }

    private static IEnumerable<int> TruncateRightToLeft(int x, bool skipOriginalValue = true)
    {
        var m = DigitCount(x) + (skipOriginalValue ? 0 : 1);
        var y = x * (skipOriginalValue ? 1 : 10);
        for (var i = 1; i < m; i++)
        {
            yield return y /= 10;
        }
    }
}

public enum TruncatingMethod : ushort
{
    LeftToRight = 1,
    RightToLeft = 2
}