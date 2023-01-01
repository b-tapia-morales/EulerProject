using System.Collections.Immutable;
using EulerProject.Utils.MathUtils.PrimalityTestUtils;

namespace EulerProject.Utils.MathUtils;

public static class PandigitalUtils
{
    public static IEnumerable<int> PandigitalSequence(params int[] integers)
    {
        var sequence = string.Join(string.Empty, integers.Where(x => x is >= 0 and <= 9).ToImmutableSortedSet());
        if (!sequence.Any())
            throw new ArgumentException("Enumerable does not contain any positive, single digit number");

        return PermutationUtils.Permute(sequence).Select(int.Parse);
    }

    public static IEnumerable<int> PandigitalSequence(int n, bool zeroless = false)
    {
        if (n < 1)
            throw new ArgumentException($"n must be equal or greater than 1 (value given was: {n})");

        var sequence = Enumerable.Range(zeroless ? 1 : 0, n).ToArray();
        return PandigitalSequence(sequence);
    }

    public static IEnumerable<int> PandigitalPrimeSequence(int n, bool zeroless = false) =>
        PandigitalSequence(n, true).Where(i => IPrimalityTest.CheckIsPrime(i));
}