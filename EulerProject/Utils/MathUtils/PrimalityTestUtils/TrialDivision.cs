using static System.Math;

namespace EulerProject.Utils.MathUtils.PrimalityTestUtils;

public class TrialDivision : IPrimalityTest
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

        for (var i = 2; i <= Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }
}