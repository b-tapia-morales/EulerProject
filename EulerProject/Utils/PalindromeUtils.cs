using static System.Math;

namespace EulerProject.Utils;

public static class PalindromeUtils
{
    public static bool IsPalindrome(string text)
    {
        var n = text.Length;
        return Enumerable.Range(0, n / 2).All(i => text[i] == text[^(i + 1)]);
    }

    public static bool IsPalindrome(int n)
    {
        int original = n, sum = 0;
        while (n > 0)
        {
            sum = sum * 10 + (n % 10);
            n /= 10;
        }

        return original == sum;
    }

    public static IEnumerable<int> GeneratePalindromes(int digits)
    {
        var smallest = (int) Pow(10, digits - 1);
        var largest = (int) Pow(10, digits) - 1;
        for (var i = smallest; i <= largest; i++)
        {
            if (IsPalindrome(i))
                yield return i;
        }
    }
}