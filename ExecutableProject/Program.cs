using System;
using System.IO;
using MonogameLib;

namespace ExecutableProject
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var path = Path.Combine(exePath, "GameProgram.txt");
            var game = CodeGenerator.CompileFromFile(path);
            game.Run();
        }

    }
}
