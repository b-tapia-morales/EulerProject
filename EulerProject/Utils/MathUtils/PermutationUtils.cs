using System.Collections.Immutable;
using static System.Math;

namespace EulerProject.Utils.MathUtils;

public static class PermutationUtils
{
    public static IEnumerable<int> Permute(params int[] sequence)
    {
        int ToInteger(IList<int> ints) =>
            Enumerable.Range(0, ints.Count).Select(i => (int) Pow(10, i) * ints[^(i + 1)]).Sum();

        return Permute<int>(sequence).Select(e => ToInteger(e.ToList())).ToImmutableSortedSet();
    }

    public static IEnumerable<string> Permute(string sequence)
    {
        if (string.IsNullOrEmpty(sequence))
            throw new ArgumentException("String is either null or empty");

        if (sequence.Length == 1)
            return Enumerable.Repeat(sequence, 1);

        var permutations = new List<string>();
        var array = sequence.ToCharArray();
        Permute(permutations, array, 0, array.Length - 1);
        return permutations;
    }

    public static IEnumerable<IEnumerable<T>> Permute<T>(T[] sequence)
    {
        if (!sequence.Any())
            throw new ArgumentException("Enumerable does not contain elements");

        if (sequence.Length == 1)
            return Enumerable.Repeat(sequence, 1);

        var permutations = new List<T[]>();
        Permute(permutations, sequence, 0, sequence.Length - 1);
        return permutations;
    }

    public static bool IsPermutation(string x, string y)
    {
        if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
            throw new ArgumentException("One of the Strings is either null or empty");

        return !x.Except(y).Any();
    }

    public static bool IsPermutation<T>(ICollection<T> t1, ICollection<T> t2)
    {
        if (!t1.Any() || !t2.Any())
            throw new ArgumentException("One of the Enumerables is either null or empty");

        return !t1.Except(t2).Any();
    }

    private static void Permute(ICollection<string> permutations, char[] sequence, int k, int m)
    {
        if (k == m)
        {
            permutations.Add(new(sequence));
            return;
        }

        for (var i = k; i <= m; i++)
        {
            (sequence[i], sequence[k]) = (sequence[k], sequence[i]);
            Permute(permutations, sequence, k + 1, m);
            (sequence[i], sequence[k]) = (sequence[k], sequence[i]);
        }
    }

    private static void Permute<T>(ICollection<T[]> permutations, T[] sequence, int k, int m)
    {
        if (k == m)
        {
            permutations.Add(sequence);
            return;
        }

        for (var i = k; i <= m; i++)
        {
            (sequence[i], sequence[k]) = (sequence[k], sequence[i]);
            Permute(permutations, sequence, k + 1, m);
            (sequence[i], sequence[k]) = (sequence[k], sequence[i]);
        }
    }
}