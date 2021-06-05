using System;

namespace GameLangParser.Exceptions
{
    public class ExecEvalException : Exception
    {
        public ExecEvalException(string message)
            : base(message)
        { }
    }
}
