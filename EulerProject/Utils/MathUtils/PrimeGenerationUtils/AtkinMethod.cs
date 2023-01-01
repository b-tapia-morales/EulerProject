using System.Collections;
using static System.Math;

namespace EulerProject.Utils.MathUtils.PrimeGenerationUtils;

public class AtkinMethod : IPrimeSequence
{
    public BitArray GenerateBitArray(int limit)
    {
        var sieve = new BitArray(limit + 1, false);
        sieve.Set(2, true);
        sieve.Set(3, true);
        var sqrtLimit = (int) Sqrt(limit);
        for (var x = 1; x <= sqrtLimit; x++)
        {
            for (var y = 1; y <= sqrtLimit; y++)
            {
                var p = 4 * x * x + y * y;
                if (p <= limit && (p % 12 == 1 || p % 12 == 5))
                    sieve.Set(p, !sieve.Get(p));

                p = 3 * x * x + y * y;
                if (p <= limit && p % 12 == 7)
                    sieve.Set(p, !sieve.Get(p));

                p = 3 * x * x - y * y;
                if (x > y && p <= limit && p % 12 == 11)
                    sieve.Set(p, !sieve.Get(p));
            }
        }

        for (var i = 5; i <= sqrtLimit; i += 2)
        {
            if (!sieve.Get(i))
                continue;

            for (var j = i * i; j <= limit; j += i * i)
            {
                sieve.Set(j, false);
            }
        }

        return sieve;
    }
}