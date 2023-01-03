using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using static System.Math;

namespace EulerProject.Utils.MathUtils;

public static class TrigonometryUtils
{
    private const int A = 3, B = 4, C = 5;

    private static readonly Matrix<double> Root = DenseMatrix.OfArray(new double[,]
    {
        {A},
        {B},
        {C}
    });

    private static readonly Matrix<double> AMatrix = DenseMatrix.OfArray(new double[,]
    {
        {+1, -2, +2},
        {+2, -1, +2},
        {+2, -2, +3}
    });

    private static readonly Matrix<double> BMatrix = DenseMatrix.OfArray(new double[,]
    {
        {+1, +2, +2},
        {+2, +1, +2},
        {+2, +2, +3}
    });

    private static readonly Matrix<double> CMatrix = DenseMatrix.OfArray(new double[,]
    {
        {-1, +2, +2},
        {-2, +1, +2},
        {-2, +2, +3}
    });

    public static IEnumerable<(int, int, int)> BerggrensTripletTree(int n)
    {
        switch (n)
        {
            case < 0:
                throw new ArgumentException($"n must be an positive integer (value given was: {n})");
            case >= 19:
                throw new ArgumentException(
                    $"Value given for n ({n}) exceeds the maximum value allowable for list (3ⁿ⁺¹ - 1) / 2 > {int.MaxValue})");
            case 0:
                return Enumerable.Repeat((A, B, C), 1);
        }

        var size = ((int) Pow(3, n - 1) - 1) / 2;
        var list = new List<Matrix<double>>(size) {Root};

        for (var i = 0; i <= n; i++)
        {
            var index = (int) (Pow(3, i - 1) - 1) / 2;
            var columnMatrix = list[index];
            for (var j = 1; j <= Pow(3, i - 1); j++, index++)
            {
                list.Add(AMatrix.Multiply(columnMatrix));
                list.Add(BMatrix.Multiply(columnMatrix));
                list.Add(CMatrix.Multiply(columnMatrix));
            }
        }

        return list.Select(m => Array.ConvertAll(m.ToRowMajorArray(), x => (int) x))
            .Select(arr => (A: Min(arr[0], arr[1]), B: Max(arr[0], arr[1]), C: arr[2]));
    }

    public static IEnumerable<(int, int, int)> BerggrensTripletLevel(int n)
    {
        switch (n)
        {
            case < 0:
                throw new ArgumentException($"n must be an positive integer (value given was: {n})");
            case >= 19:
                throw new ArgumentException(
                    $"Value given for n ({n}) exceeds the maximum value allowable for list (3ⁿ⁺¹ - 1) / 2 > {int.MaxValue})");
            case 0:
                return Enumerable.Repeat((A, B, C), 1);
        }

        var size = (int) Pow(3, n);
        var queue = new Queue<Matrix<double>>(size);
        queue.Enqueue(Root);

        for (var i = 0; i <= n; i++)
        {
            for (var j = 1; j <= Pow(3, i - 1); j++)
            {
                var columnMatrix = queue.Dequeue();
                queue.Enqueue(AMatrix.Multiply(columnMatrix));
                queue.Enqueue(BMatrix.Multiply(columnMatrix));
                queue.Enqueue(CMatrix.Multiply(columnMatrix));
            }
        }

        return queue.Select(m => Array.ConvertAll(m.ToRowMajorArray(), x => (int) x))
            .Select(arr => (A: Min(arr[0], arr[1]), B: Max(arr[0], arr[1]), C: arr[2]));
    }
}