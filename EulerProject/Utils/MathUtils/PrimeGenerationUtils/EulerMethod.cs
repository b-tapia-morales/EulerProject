using System.Collections;

namespace EulerProject.Utils.MathUtils.PrimeGenerationUtils;

public class EulerMethod : IPrimeSequence
{
    public BitArray GenerateBitArray(int limit)
    {
        var sieve = new BitArray(limit + 1, true);
        sieve.Set(0, false);
        sieve.Set(1, false);
        for (var i = 3; i <= limit; i += 2)
        {
            if (!sieve.Get(i))
                continue;

            var n = limit / i;
            if (n % 2 == 0)
                n--;

            for (var j = n; j >= i; j -= 2)
            {
                if (sieve.Get(j))
                    sieve.Set(i * j, false);
            }
        }

        return sieve;
    }
}