namespace EulerProject.Utils.MathUtils;

public static class MatrixUtils
{
    public static int[,] ClockwiseSpiralMatrix(int n)
    {
        if (n < 3 || n % 2 == 0)
            throw new ArgumentException(
                $"n must be an odd integer greater equal or greater than 3 (value given was: {n})");

        if (n > 46_340)
            throw new ArgumentException(
                $"Value given for n ({n}) exceeds the maximum value allowable for counter (n² > {int.MaxValue})");
        
        var counter = n * n;
        var matrix = new int[n, n];
        for (var i = 1; i <= n - 2; i++)
        {
            FillBackwards(matrix, i - 1, n - i, i - 1, ref counter);
            FillDownwards(matrix, i - 1, i - 1, n - i, ref counter);
            FillForwards(matrix, n - i, i - 1, n - i, ref counter);
            FillUpwards(matrix, n - i, n - i, i - 1, ref counter);
        }

        matrix[(n - 1) / 2, (n - 1) / 2] = 1;
        return matrix;
    }
    
    public static int[,] CounterClockwiseSpiralMatrix(int n)
    {
        if (n < 3 || n % 2 == 0)
            throw new ArgumentException(
                $"n must be an odd integer greater equal or greater than 3 (value given was: {n})");

        if (n > 46_340)
            throw new ArgumentException(
                $"Value given for n ({n}) exceeds the maximum value allowable for counter (n² > {int.MaxValue})");
        
        var counter = n * n;
        var matrix = new int[n, n];
        for (var i = 1; i <= n - 2; i++)
        {
            FillBackwards(matrix, n - i, n - i, i - 1, ref counter);
            FillUpwards(matrix, i - 1, n - i, i - 1, ref counter);
            FillForwards(matrix, i - 1, i - 1, n - i, ref counter);
            FillDownwards(matrix, n - i, i - 1, n - i, ref counter);
        }

        matrix[(n - 1) / 2, (n - 1) / 2] = 1;
        return matrix;
    }

    private static void FillBackwards(int[,] matrix, int i, int start, int stop, ref int counter)
    {
        for (var j = start; j > stop; j--)
        {
            matrix[i, j] = counter--;
        }
    }

    private static void FillDownwards(int[,] matrix, int j, int start, int stop, ref int counter)
    {
        for (var i = start; i < stop; i++)
        {
            matrix[i, j] = counter--;
        }
    }

    private static void FillForwards(int[,] matrix, int i, int start, int stop, ref int counter)
    {
        for (var j = start; j < stop; j++)
        {
            matrix[i, j] = counter--;
        }
    }

    private static void FillUpwards(int[,] matrix, int j, int start, int stop, ref int counter)
    {
        for (var i = start; i > stop; i--)
        {
            matrix[i, j] = counter--;
        }
    }
}