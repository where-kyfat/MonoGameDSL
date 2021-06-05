using System;

namespace GameLangParser.Exceptions
{
    public class LexException : Exception
    {
        public LexException(string msg) : base("Lexical error: " + msg) { }
    }
}
