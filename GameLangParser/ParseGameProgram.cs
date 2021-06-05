using GameLangParser.Exceptions;
using System;
using System.IO;

namespace GameLangParser
{
    public static class GameLangParser
    {
        public static string ParseGameProgram(string pathGameProgram)
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//path to exe file
            var pathProg = Path.Combine(exePath, pathGameProgram);
            var pathPattern = Path.Combine(exePath, "GamePattern.txt");

            string GameProg = File.ReadAllText(pathProg);
            string GamePattern = File.ReadAllText(pathPattern);

            Scanner scanner = new Scanner();
            scanner.SetSource(GameProg, 0);

            Parser parser = new Parser(scanner, GamePattern);

            var b = parser.Parse();
            if (!b)
                throw new ExecEvalException("Unrecovered errors");

            //Генерация класса
            return parser.root.ToString();
        }
    }
}
