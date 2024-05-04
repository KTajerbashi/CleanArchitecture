using Design.Pattern.Library.Composite.AssembleSystem;
using Design.Pattern.Library.Flyweight.Pattern;
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
//Design.Pattern.Library.Composite.Component component = new Composite("RouteItem",new Component[]
//{
//    new Leaf("Leaf 1"),
//    new Composite("Composite 1",new Component[]
//    {
//        new Leaf("Leaf 1-1"),
//        new Leaf("Leaf 1-2"),
//        new Composite("Composite 1-1",new Component[]
//        {
//            new Leaf("Leaf 1-1-1"),
//            new Composite("Empty Composite",new Component[]{ })
//        }),
//        new Composite("Composite 1-2"),
//    }),
//    new Leaf("Leaf 2"),
//    new Leaf("Leaf 3"),
//    new Leaf("Leaf 4"),
//});
//component.Display(1);

//IComponent Hdd = new Leaf("Hard Disk",10000);
//IComponent Ram = new Leaf("RAM",16000);
//IComponent Cpu = new Leaf("CPU",15000);
//IComponent Vga = new Leaf("VGA",20000);
//IComponent Keyboard = new Leaf("Keyboard",2200);
//IComponent Mouse = new Leaf("Mouse",2300);
//IComponent Monitor = new Leaf("Monitor",5000);

//Composite MotherBoard = new Composite("MotherBoard",1000);
//Composite Case = new Composite("Case",23000);
//Composite Peripherais = new Composite("Peripherais",0);
//Composite Computer = new Composite("Computer",0);
//MotherBoard.AddComponent(Cpu);
//MotherBoard.AddComponent(Ram);
//MotherBoard.AddComponent(Vga);

//Case.AddComponent(MotherBoard);
//Case.AddComponent(Hdd);

//Peripherais.AddComponent(Mouse);
//Peripherais.AddComponent(Keyboard);

//Computer.AddComponent(Case);
//Computer.AddComponent(Peripherais);
//Computer.AddComponent(Monitor);

//Computer.DisplayPrice();
#endregion

#region Flyweight
FlyweightFactory factory = new();
var obj1 =factory.GetFlyweight("Test1");
var obj2 =factory.GetFlyweight("Test2");
var obj3 =factory.GetFlyweight("Test1");

obj1.Operation("Sample 1");
obj2.Operation("Sample 2");
obj3.Operation("Sample 3");

UnSharedFlyweight flyweightShared = new(new Flyweight[]
{
    factory.GetFlyweight("Test 1"),
    factory.GetFlyweight("Test 2"),
    factory.GetFlyweight("Test 3"),
    factory.GetFlyweight("Test 4"),
});

flyweightShared.Operation("UnSharedFlyweight ====> Extrinsic");

#endregion

Design.ForeColor(ConsoleColor.White);
Design.Background(ConsoleColor.Black);
Design.NewLine();
Design.End("Application");

Console.ReadLine();