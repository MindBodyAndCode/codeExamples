using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";

            while (input != "exit")
            {
                Console.WriteLine("Welcome to Design Pattern Examples!!");
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - Factory Method");
                Console.WriteLine("2 - Singleton");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        DesignPatterns.FactoryMethod();
                        break;
                    case "2":
                        DesignPatterns.Singleton();
                        break;
                }

                Console.WriteLine();

            }


        }
    }
}
