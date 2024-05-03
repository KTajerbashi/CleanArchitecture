using Design.Pattern.Library.Composite;
using Design.Pattern.Library.Tools;

DesignConsole Design = new();


Design.ForeColor(ConsoleColor.White);

Design.Start("Start Application");
#region Decorator
//Design.ForeColor(ConsoleColor.Yellow);
//Design.Start("Decoration");
//DrawPaint drawPaint = new();
//drawPaint.Draw();
//ConcreteDecoratorDrawing concreteDecoratorDrawing = new(drawPaint);
//concreteDecoratorDrawing.Draw();
//Design.End("Decoration");
//Design.ForeColor(ConsoleColor.Black);
#endregion

#region Bridge
//Design.ForeColor(ConsoleColor.Red);
//Design.Start("Bridge");
//RefinedAbstractionClass refined = new();
//refined.Function();

//Design.NewLine();
//RefinedMailService refinedMail = new();
//refinedMail.SendEmail(new EmailDTO
//{
//    Reciever="Kamran",
//    Title="CV Application",
//    Message="This is a Application",
//});

//Design.NewLine();
//Circle vectorCircle = new Circle(new VectorRenderer(), 5);
//vectorCircle.Draw();

//Design.NewLine();
//Square rasterSquare = new Square(new RasterRenderer(), 10);
//rasterSquare.Draw();

//Design.End("Bridge");
#endregion

#region Facade
//IFacadContainer facad = new FacadContainer();
//facad.BackupRepository.Execute();
//facad.DrawRepository.Execute();
//facad.EmailRepository.Execute();
#endregion

#region Proxy
//IBankRepository bank = new BankServerProxy();
//bank.Deposit();
//bank.Harvest();
#endregion

#region Composite
Design.Pattern.Library.Composite.Component component = new Composite("RouteItem",new Component[]
{
    new Leaf("Leaf 1"),
    new Composite("Composite 1",new Component[]
    {
        new Leaf("Leaf 1-1"),
        new Leaf("Leaf 1-2"),
        new Composite("Composite 1-1",new Component[]
        {
            new Leaf("Leaf 1-1-1"),
            new Composite("Empty Composite",new Component[]{ })
        }),
        new Composite("Composite 1-2"),
    }),
    new Leaf("Leaf 2"),
    new Leaf("Leaf 3"),
    new Leaf("Leaf 4"),
});
component.Display(1);
#endregion

Design.ForeColor(ConsoleColor.White);
Design.Background(ConsoleColor.Black);
Design.NewLine();
Design.End("Application");

Console.ReadLine();