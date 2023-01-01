using System.Numerics;
using EulerProject.Utils.MathUtils;
using EulerProject.Utils.MathUtils.PrimeGenerationUtils;

namespace EulerProject.Problems;

public class Problem005 : ISolvable<BigInteger>, ISequential<BigInteger, KeyValuePair<long, int>>
{
    private const int N = 20;

    public static string AsString() => Solution().ToString();

    public static BigInteger Solution() => Sequence().Aggregate(BigInteger.One, BigInteger.Multiply);

    public static IEnumerable<BigInteger> Sequence() =>
        RawSequence().Select(x => BigInteger.Pow(x.Key, x.Value));

    public static IEnumerable<KeyValuePair<long, int>> RawSequence()
    {
        var dictionary = IPrimeSequence.Generate(N).ToDictionary(x => (long) x, _ => 1);
        for (var i = 2; i <= N; i++)
        {
            if (dictionary.ContainsKey(i))
                continue;

            foreach (var (b, n) in MathUtils.FindPrimeFactors(i))
            {
                if (dictionary[b] < n)
                    dictionary[b] = n;
            }
        }

        return dictionary;
    }
}