namespace EulerProject.Utils.Text;

public static class TextUtils
{
    public static int[,] TriangleArray(string path, int n)
    {
        var source = File.ReadLines(path)
            .Select(e => e.Split(' ').Select(int.Parse))
            .Select((l, i) => (Enumerable: l, Iterator: i))
            .Select(e => e.Enumerable.Concat(Enumerable.Repeat(0, n - (e.Iterator + 1))).ToArray())
            .ToArray();

        var array = new int[n, n];
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                array[i, j] = source[i][j];
            }
        }

        return array;
    }

    public static int[,] GenerateSquareMatrix(string path, int n)
    {
        var source = File.ReadLines(path).Select(e => e.Split(",").Select(int.Parse).ToList()).ToList();

        var array = new int[n, n];
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                array[i, j] = source[i][j];
            }
        }

        return array;
    }
}