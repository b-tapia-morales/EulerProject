namespace EulerProject.Utils;

public static class PathUtils
{
    private static readonly string WorkingDirectory =
        Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;

    public static string BuildPath(string relativePath)
    {
        return Path.Combine(WorkingDirectory, relativePath);
    }
}