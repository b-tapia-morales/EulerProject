using static System.Math;

namespace EulerProject.Utils.MathUtils.PrimalityTestUtils;

public class OptimizedTrialDivision : IPrimalityTest
{
    public bool IsPrime(long n)
    {
        switch (n)
        {
            case 0 or 1:
                return false;
            case 2 or 3:
                return true;
        }

        if (n % 2 == 0 || n % 3 == 0)
            return false;

        for (long i = 5; Pow(i, 2) <= n; i += 6)
        {
            if (n % i == 0 || n % (i + 2) == 0)
                return false;
        }

        return true;
    }
}