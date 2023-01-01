using System.Collections;

namespace EulerProject.Utils.MathUtils.PrimeGenerationUtils;

public class EratosthenesMethod : IPrimeSequence
{
    public BitArray GenerateBitArray(int limit)
    {
        var sieve = new BitArray(limit + 1, true);
        sieve.Set(0, false);
        sieve.Set(1, false);
        for (var i = 2; i * i <= limit; i++)
        {
            if (!sieve.Get(i))
                continue;

            for (var j = i * i; j <= limit; j += i)
            {
                sieve.Set(j, false);
            }
        }

        return sieve;
    }
}