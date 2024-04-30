namespace Design.Pattern.Library.Tools
{
    public class DesignConsole
    {
        public DesignConsole()
        {
            Console.Title = "Design Pattern";
        }
        public void Background(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public void ForeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void NewLine()
        {
            Console.WriteLine("\n");
        }
        public void Section()
        {
            Console.WriteLine("\n:::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");
        }
        public void Title(string title)
        {
            Console.WriteLine($"\n== == == == == == {title} == == == == == ==\n");
        }
        public void Start(string title)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"== == == == Start Of {title}");
            Console.WriteLine("======================================================");
        }
        public void End(string title)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine($"== == == == End Of {title} ");
            Console.WriteLine("======================================================");
            Section();
        }
    }
}
