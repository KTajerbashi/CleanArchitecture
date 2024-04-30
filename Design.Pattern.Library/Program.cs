// See https://aka.ms/new-console-template for more information
using Design.Pattern.Library.Bridge.Abstractions;
using Design.Pattern.Library.Bridge.MailService.Abstraction;
using Design.Pattern.Library.Bridge.MailService.Models;
using Design.Pattern.Library.Decorator;
using Design.Pattern.Library.Decorator.Draw;
using Design.Pattern.Library.Tools;

DesignConsole Design = new();


Design.ForeColor(ConsoleColor.White);

Design.Start("Start Application");
#region Decorator
Design.ForeColor(ConsoleColor.Yellow);
Design.Start("Decoration");
DrawPaint drawPaint = new();
drawPaint.Draw();
ConcreteDecoratorDrawing concreteDecoratorDrawing = new(drawPaint);
concreteDecoratorDrawing.Draw();
Design.End("Decoration");
Design.ForeColor(ConsoleColor.Black);
#endregion
#region Bridge
Design.ForeColor(ConsoleColor.Red);
Design.Start("Bridge");
RefinedAbstractionClass refined = new();
refined.Function();

RefinedMailService refinedMail = new();
refinedMail.SendEmail(new EmailDTO
{
    Reciever="Kamran",
    Title="CV Application",
    Message="This is a Application",
});
Design.End("Bridge");
#endregion




Design.ForeColor(ConsoleColor.White);
Design.Background(ConsoleColor.Black);
Design.NewLine();
Design.End("Application");

Console.ReadLine();