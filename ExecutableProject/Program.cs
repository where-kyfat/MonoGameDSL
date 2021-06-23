using System;
using System.IO;
using GameLangParser.Exceptions;

namespace ExecutableProject
{
    public static class Program
    {
        [STAThread]
        static void Main(string [] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Waited to name of program file");
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
            }
            else
            {
                MonogameLib.Classes.ConstructorGame game;
                try
                {
                    Console.WriteLine("Starting compile " + args[0] + " file....");
                    Console.WriteLine("------------------------------------------");
                    var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
                    var path = Path.Combine(exePath, args[0]);
                    game = CodeGenerator.CompileFromFile(path);
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Compile complete!");

                    Console.WriteLine("Start game? y/n \n");
                    var response = Console.ReadKey();
                    if (response.Key == ConsoleKey.Y || response.Key == ConsoleKey.Enter)
                    {
                        //Start game
                        game.Run();
                    }
                }
                catch (GameLangParser.Exceptions.SyntaxException exp)
                {
                    Console.WriteLine(args[0]+ ":" + exp.Message);
                }
                catch (DSL_Error exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }
    }
}