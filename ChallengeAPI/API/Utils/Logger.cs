namespace ChallengeAPI.Utils;

public static class Logger
{
    public static void LogError(Exception ex)
    {
        Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.Message}");
        Console.WriteLine(ex.StackTrace);
    }

    public static void LogInfo(string message)
    {
        Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
    }
}