using System.Numerics;
using EulerProject.Utils.MathUtils;

namespace EulerProject.Problems;

public class P043 : ISolvable<BigInteger>, ISequential<long, long>
{
    private const int Digits = 3;
    private const int N = 10;

    public static string AsString() => throw new NotImplementedException();

    public static BigInteger Solution() => RawSequence().Select(x => new BigInteger(x)).Aggregate(BigInteger.Add);

    public static IEnumerable<long> Sequence() => RawSequence();

    public static IEnumerable<long> RawSequence()
    {
        bool IsDivisible(IList<long> chunks, IList<int> primes) =>
            Enumerable.Range(0, chunks.Count).All(i => chunks[i] % primes[i] == 0);


        var pandigitals = SequenceGeneration.Pandigitals(N).ToList();
        var primes = new List<int> {2, 3, 5, 7, 11, 13, 17};
        foreach (var pandigital in pandigitals)
        {
            var chunks = DigitUtils.ToChunks(pandigital, Digits).Skip(1).ToList();
            if (IsDivisible(chunks, primes))
                yield return pandigital;
        }
    }
}