// See https://aka.ms/new-console-template for more information
using Design.Pattern.Library.Decorator;
using Design.Pattern.Library.Decorator.Draw;
using Design.Pattern.Library.Tools;

DesignConsole Design = new();


Design.ForeColor(ConsoleColor.White);

Design.Start("Start Application");
#region Decorator
Design.ForeColor(ConsoleColor.Yellow);
Design.Start("Start Decoration Design Pattern");

Design.Start("DrawPaint");
Design.Title("DrawPaint");
DrawPaint drawPaint = new();
drawPaint.Draw();

Design.Title("DrawPaint Concrete Decorator Drawing");
ConcreteDecoratorDrawing concreteDecoratorDrawing = new(drawPaint);
concreteDecoratorDrawing.Draw();

Design.NewLine();
Design.End("DrawPaint");


Design.End("End Decoration Design Pattern");
Design.Background(ConsoleColor.Green);
Design.ForeColor(ConsoleColor.Black);
#endregion






Design.NewLine();
Design.End("Application");

Console.ReadLine();