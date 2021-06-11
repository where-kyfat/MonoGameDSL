using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Exceptions
{
    class WrongTextureException : Exception
    {
        public WrongTextureException(string message)
            : base(message)
        { }
    }
}
