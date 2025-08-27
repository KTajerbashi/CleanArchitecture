namespace CleanArchitecture.Core.Application.Utilities.Extensions;

public static class ConsoleWriterExtension
{
    public static void PrintConsole(string message)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
}
}
