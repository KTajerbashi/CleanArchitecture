// See https://aka.ms/new-console-template for more information
using Design.Pattern.Library.Decorator;
using Design.Pattern.Library.Tools;

DesignConsole Design = new();


Design.Background(ConsoleColor.Green);
Design.ForeColor(ConsoleColor.Black);

Design.Start("Start Application");
Design.NewLine();
#region Decorator
Design.Background(ConsoleColor.Blue);
Design.ForeColor(ConsoleColor.Yellow);
Design.Start("Start Decoration Design Pattern");

DecoratorContainer decorator =new(Design);

Design.End("End Decoration Design Pattern");
Design.Background(ConsoleColor.Green);
Design.ForeColor(ConsoleColor.Black);
#endregion






Design.NewLine();
Design.End("Application");

Console.ReadLine();