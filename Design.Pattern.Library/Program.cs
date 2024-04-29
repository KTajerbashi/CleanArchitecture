// See https://aka.ms/new-console-template for more information
using Design.Pattern.Library.Bridge.Abstractions;
using Design.Pattern.Library.Decorator;
using Design.Pattern.Library.Decorator.Draw;
using Design.Pattern.Library.Tools;

DesignConsole Design = new();


Design.ForeColor(ConsoleColor.White);

Design.Start("Start Application");
#region Decorator
Design.ForeColor(ConsoleColor.Yellow);
Design.Start("Decoration");

Design.Title("DrawPaint");
DrawPaint drawPaint = new();
drawPaint.Draw();

Design.Title("DrawPaint Concrete Decorator Drawing");
ConcreteDecoratorDrawing concreteDecoratorDrawing = new(drawPaint);
concreteDecoratorDrawing.Draw();
Design.NewLine();


Design.End("Decoration");
Design.ForeColor(ConsoleColor.Black);
#endregion

#region Bridge
Design.ForeColor(ConsoleColor.Red);
Design.Start("Bridge");
RefinedAbstractionClass refined = new();

refined.Function();
Design.End("Bridge");
#endregion




Design.ForeColor(ConsoleColor.White);
Design.Background(ConsoleColor.Black);
Design.NewLine();
Design.End("Application");

Console.ReadLine();