using System;

namespace GameLangParser.Exceptions
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string msg) : base("Syntax error: " + msg) { }
    }
}
